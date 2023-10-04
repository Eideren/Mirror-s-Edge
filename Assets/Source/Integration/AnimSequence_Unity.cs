using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace MEdge.Engine
{
	using Core;
	using UnityEngine;
	using static Source.DecFn;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FVector4 = Core.Object.Vector4;
	using FRotator = Core.Object.Rotator;
	using FQuat = Core.Object.Quat;
	using FBoneAtom = AnimNode.BoneAtom;
	using UBOOL = System.Boolean;
	using BoneAtom = AnimNode.BoneAtom;
	using FMatrix = Core.Object.Matrix;
	using BYTE = System.Byte;
	using UINT = System.UInt32;
	
	public partial class AnimSequence
	{
		public UnityEngine.AnimationClip _unityClip;
		public UnityEngine.Transform[] _unityBones;
		public UnityEngine.Animator _unityClipTarget;
		public (FBoneAtom[] start, FBoneAtom[] end) _unityPoses;
		(Vector3 loc, Quaternion rot)[] _unitySamplingCache;
		(float, bool) _cacheData;
		
		public unsafe void GetBoneAtom(ref FBoneAtom OutAtom, INT TrackIndex, FLOAT Time, UBOOL bLooping, UBOOL bUseRawData)
		{
			if( _unityClip == null )
			{
				OutAtom = BoneAtom.Identity;
				return;
			}

			// Make sure to normalize it within the unity clip's duration instead of the unreal one
			Time = Time / SequenceLength * _unityClip.length;

			if( Time <= 0f || NumFrames == 1/*small hack as unity animations have two frames instead of just one like source does*/ )
			{
				OutAtom = _unityPoses.start[ TrackIndex ];
				return;
			}

			if( Time >= _unityClip.length )
			{
				OutAtom = bLooping ? _unityPoses.start[ TrackIndex ] : _unityPoses.end[ TrackIndex ];
				return;
			}

			if( _unitySamplingCache == null || _cacheData != (Time, bLooping) )
			{
				_unitySamplingCache ??= new (Vector3, Quaternion)[_unityBones.Length];
				_cacheData = (Time, bLooping);
				
				_unityClip.wrapMode = bLooping ? WrapMode.Loop : WrapMode.ClampForever;
				foreach( var b in _unityBones )
				{
					b.localPosition = default;
					b.localRotation = Quaternion.identity;
					b.localScale = Vector3.one;
				}

				_unityClip.EvaluateArbitrarily(Time, _unityClipTarget);

				for( int i = 0; i < _unityBones.Length; i++ )
				{
					var b = _unityBones[i];
					_unitySamplingCache[i] = (b.localPosition, b.localRotation);
				}
			}
			var thisBone = _unitySamplingCache[ TrackIndex ];
			OutAtom = new BoneAtom( thisBone.rot.ToUnrealAnim(), thisBone.loc.ToUnrealAnim(), 1f );

			return;
			
			#if UNUSED
			// If the caller didn't request that raw animation data be used . . .
			if ( !bUseRawData )
			{
		#if false
				if( CompressedTranslationData.Num() > 0 )
				{
					//const FScopedTimer Timer( TEXT("Compressed") );
					// Build the pose using bitwise compressed data.
					ReconstructBoneAtom( OutAtom,
											CompressedTranslationData(TrackIndex),
											CompressedRotationData(TrackIndex),
											static_cast<AnimationCompressionFormat>(TranslationCompressionFormat),
											static_cast<AnimationCompressionFormat>(RotationCompressionFormat),
											SequenceLength,
											Time,
											bLooping );
					return;
				}
		#else
				if ( CompressedTrackOffsets.Num() > 0 )
				{
					ReconstructBoneAtom( OutAtom,
											CompressedByteStream.GetTypedData()+CompressedTrackOffsets[TrackIndex*4],
											CompressedTrackOffsets[TrackIndex*4+1],
											CompressedByteStream.GetTypedData()+CompressedTrackOffsets[TrackIndex*4+2],
											CompressedTrackOffsets[TrackIndex*4+3],
											static_cast<AnimationCompressionFormat>(TranslationCompressionFormat),
											static_cast<AnimationCompressionFormat>(RotationCompressionFormat),
											SequenceLength,
											Time,
											bLooping );
					return;
				}
		#endif
				/*
				else if ( TranslationData.Num() > 0 )
				{
					// Build the pose using the key reduced data.
					ReconstructBoneAtom( OutAtom, TranslationData(TrackIndex), RotationData(TrackIndex), SequenceLength, Time, bLooping );
					return;
				}
				*/
			}
			#endif

			//const FScopedTimer Timer( TEXT("Raw") );
			OutAtom.Scale = 1f;

			// Bail out if the animation data doesn't exists (e.g. was stripped by the cooker).
			if ( RawAnimData.Num() == 0 )
			{
				debugf( TEXT("UAnimSequence.GetBoneAtom : No anim data in AnimSequence!") );
				OutAtom.Rotation = FQuat.Identity;
				OutAtom.Translation = FVector(0f, 0f, 0f);
				return;
			}

			ref RawAnimSequenceTrack RawTrack = ref RawAnimData[TrackIndex];

			// Bail out (with rather wacky data) if data is empty for some reason.
			if( RawTrack.KeyTimes.Num() == 0 || 
				RawTrack.PosKeys.Num() == 0 ||
				RawTrack.RotKeys.Num() == 0 )
			{
				debugf( TEXT("UAnimSequence.GetBoneAtom : No anim data in AnimSequence!") );
				OutAtom.Rotation = FQuat.Identity;
				OutAtom.Translation = FVector(0f, 0f, 0f);
				return;
			}

   			// Check for 1-frame, before-first-frame and after-last-frame cases.
			if( Time <= 0f || RawTrack.KeyTimes.Num() == 1 )
			{
				OutAtom.Translation = RawTrack.PosKeys[0];
				OutAtom.Rotation	= RawTrack.RotKeys[0];
				return;
			}

			INT LastIndex		= RawTrack.KeyTimes.Num() - 1;
			INT LastPosIndex	= Min(LastIndex, RawTrack.PosKeys.Num()-1);
			INT LastRotIndex	= Min(LastIndex, RawTrack.RotKeys.Num()-1);
			if( Time >= SequenceLength )
			{
				// If we're not looping, key n-1 is the final key.
				// If we're looping, key 0 is the final key.
				OutAtom.Translation = RawTrack.PosKeys[ bLooping ? 0 : LastPosIndex ];
				OutAtom.Rotation	= RawTrack.RotKeys[ bLooping ? 0 : LastRotIndex ];
				return;
			}

			// This assumes that all keys are equally spaced (ie. won't work if we have dropped unimportant frames etc).	
			FLOAT FrameInterval = bLooping ?
			(
				// by default, for looping animation, the last frame has a duration, and interpolates back to the first one.
				//RawTrack.KeyTimes(1) - RawTrack.KeyTimes(0);
				SequenceLength / (FLOAT)RawTrack.KeyTimes.Num()
			)
				:
			(
				// For non looping animation, the last frame is the ending frame, and has no duration.
				SequenceLength / ((FLOAT)RawTrack.KeyTimes.Num()-1)
			);

			// Keyframe we want is somewhere in the actual data. 

			// Find key position as a float.
			FLOAT KeyPos = Time/FrameInterval;

			// Find the integer part (ensuring within range) and that gives us the 'starting' key index.
			INT KeyIndex1 = Clamp( appFloor(KeyPos), 0, RawTrack.KeyTimes.Num()-1 );  // @todo should be changed to appTrunc

			// The alpha (fractional part) is then just the remainder.
			FLOAT Alpha = KeyPos - (FLOAT)KeyIndex1;

			INT KeyIndex2 = KeyIndex1 + 1;

			// If we have gone over the end, do different things in case of looping
			if( KeyIndex2 == RawTrack.KeyTimes.Num() )
			{
				// If looping, interpolate between last and first frame
				if( bLooping )
				{
					KeyIndex2 = 0;
				}
				// If not looping - hold the last frame.
				else
				{
					KeyIndex2 = KeyIndex1;
				}
			}

			INT PosKeyIndex1 = Min(KeyIndex1, RawTrack.PosKeys.Num()-1);
			INT RotKeyIndex1 = Min(KeyIndex1, RawTrack.RotKeys.Num()-1);
			INT PosKeyIndex2 = Min(KeyIndex2, RawTrack.PosKeys.Num()-1);
			INT RotKeyIndex2 = Min(KeyIndex2, RawTrack.RotKeys.Num()-1);

			OutAtom.Translation = VLerp(RawTrack.PosKeys[PosKeyIndex1], RawTrack.PosKeys[PosKeyIndex2], Alpha);

		#if !USE_SLERP
			// Fast linear quaternion interpolation.
			// To ensure the 'shortest route', we make sure the dot product between the two keys is positive.
			if( (RawTrack.RotKeys[RotKeyIndex1] | RawTrack.RotKeys[RotKeyIndex2]) < 0f )
			{
				// To clarify the code here: a slight optimization of inverting the parametric variable as opposed to the quaternion.
				OutAtom.Rotation = (RawTrack.RotKeys[RotKeyIndex1] * (1f-Alpha)) + (RawTrack.RotKeys[RotKeyIndex2] * -Alpha);
			}
			else
			{
				OutAtom.Rotation = (RawTrack.RotKeys[RotKeyIndex1] * (1f-Alpha)) + (RawTrack.RotKeys[RotKeyIndex2] * Alpha);
				OutAtom.Rotation = (RawTrack.RotKeys[RotKeyIndex1] * (1f-Alpha)) + (RawTrack.RotKeys[RotKeyIndex2] * Alpha);
			}
		#else
			OutAtom.Rotation = SlerpQuat( RawTrack.RotKeys(RotKeyIndex1), RawTrack.RotKeys(RotKeyIndex2), Alpha );
		#endif
			OutAtom.Rotation.Normalize();
		}
	}
	public class AnimationCleanup : MonoBehaviour
	{
		static readonly Dictionary<Animator, (PlayableGraph graph, AnimationPlayableOutput output, Dictionary<AnimationClip, AnimationClipPlayable> clips)> AllGraphs = new();
		readonly List<PlayableGraph> _graphs = new();

		void OnDestroy()
		{
			for (int i = 0; i < _graphs.Count; i++)
				_graphs[i].Destroy();
			_graphs.Clear();
		}

		public static (PlayableGraph graph, AnimationPlayableOutput output, Dictionary<AnimationClip, AnimationClipPlayable> clips) GetGraph(Animator animator)
		{
			if (!AllGraphs.TryGetValue(animator, out (PlayableGraph, AnimationPlayableOutput, Dictionary<AnimationClip, AnimationClipPlayable>) graphData))
			{
				if (!animator.gameObject.TryGetComponent(out AnimationCleanup cleaner))
					cleaner = animator.gameObject.AddComponent<AnimationCleanup>();
				PlayableGraph graph = PlayableGraph.Create();
				cleaner._graphs.Add(graph);
				graph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
				graphData = (graph, AnimationPlayableOutput.Create(graph, "Routine Sample", animator), new Dictionary<AnimationClip, AnimationClipPlayable>());
				AllGraphs.Add(animator, graphData);
			}

			return graphData;
		}
	}

	public static class ClipExtension
	{
		public static void EvaluateArbitrarily(this AnimationClip clip, double time, Animator animator)
		{
			(PlayableGraph, AnimationPlayableOutput, Dictionary<AnimationClip, AnimationClipPlayable>) graphData = AnimationCleanup.GetGraph(animator);
			if (!graphData.Item3.TryGetValue(clip, out AnimationClipPlayable playableClip))
			{
				playableClip = AnimationClipPlayable.Create(graphData.Item1, clip);
				graphData.Item3.Add(clip, playableClip);
			}

			graphData.Item2.SetSourcePlayable(playableClip);
			playableClip.SetTime(time);
			graphData.Item1.Evaluate();
		}
	}
}