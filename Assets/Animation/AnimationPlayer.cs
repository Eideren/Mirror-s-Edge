namespace MEdge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Engine;
	using UnityEngine;
	using ERootMotionMode = MEdge.Engine.SkeletalMeshComponent.ERootMotionMode;
	using ERootMotionRotationMode = MEdge.Engine.SkeletalMeshComponent.ERootMotionRotationMode;
	using Object = Core.Object;
	using BoneAtom = MEdge.Engine.AnimNode.BoneAtom;
	using AimOffsetProfile = MEdge.Engine.AnimNodeAimOffset.AimOffsetProfile;
	using EAnimAimDir = MEdge.Engine.AnimNodeAimOffset.EAnimAimDir;
	using ERootBoneAxis = MEdge.Engine.AnimNodeSequence.ERootBoneAxis;
	using ERootRotationOption = MEdge.Engine.AnimNodeSequence.ERootRotationOption;



	public class AnimationPlayer
	{
		const float SMALL_NUMBER = 1e-8f;
		const float ZERO_ANIMWEIGHT_THRESH = 0.00001f;
		const float DELTA = 0.00001f;
		
		public GameObject GameObject;
		SkeletalMeshComponent _skel;
		AnimNode _root;
		//int TickTag;
		Dictionary<AnimNode, (TempBuffer<TR> buff, TR rootMotion)> _cachedNode;
		
		public Transform[] Bones;
		TR[] _bindPose;
		TR[] _currentPose;
		public Dictionary<name, int> NameToIndex;
		Dictionary<name, AnimationClip> _clips;
		Dictionary<name, (TR start, TR end)> _rootMotion;



		public AnimationPlayer(AnimationClip[] clips, AnimSet animSet, AnimNode root, GameObject gameObject, Actor actor, SkeletalMeshComponent skel)
		{
			GameObject = gameObject;
			_skel = skel;
			_skel.InitAnimTree(true);
			_root = root;
			Bones = new Transform[ animSet.TrackBoneNames.Length ];
			_bindPose = new TR[ animSet.TrackBoneNames.Length ];
			NameToIndex = new Dictionary<name, int>();
			var allTransforms = gameObject.GetComponentsInChildren<Transform>().ToDictionary( x => (name)x.name );
			for( int i = 0; i < animSet.TrackBoneNames.Length; i++ )
			{
				var t = allTransforms[ animSet.TrackBoneNames[ i ] ];
				Bones[ i ] = t;
				_bindPose[ i ] = new TR{ Translation = t.localPosition, Rotation = t.localRotation };
				NameToIndex.Add( animSet.TrackBoneNames[i], i );
			}

			_clips = clips.ToDictionary( x => (name)x.name, x => x );
			_cachedNode = new Dictionary<AnimNode, (TempBuffer<TR> buff, TR rootMotion)>();
			_rootMotion = clips.ToDictionary( x => (name)x.name, x =>
			{
				x.wrapMode = WrapMode.Clamp;
				var root = Bones[ 0 ];
				x.SampleAnimation( gameObject, 0f );
				var start = new TR { Translation = root.localPosition, Rotation = root.localRotation };
				x.SampleAnimation( gameObject, x.length );
				var end = new TR { Translation = root.localPosition, Rotation = root.localRotation };
				return ( start, end );
			} );
			_currentPose = new TR[ Bones.Length ];
		
			static IEnumerable<AnimNode> Enumerate( AnimNode n )
			{
				yield return n;
				if( n is AnimNodeBlendBase anbb )
				{
					foreach( var child in anbb.Children )
					{
						foreach( var node in Enumerate( child.Anim ) )
						{
							if( node != null )
								yield return node;
						}
					}
				}
			}
		}


		public void Sample( float dt )
		{
			// Mix of USkeletalMeshComponent::Tick and USkeletalMeshComponent::UpdateSkelPose
			_skel.TickAnimNodes( dt );
			_skel.TickSkelControls( dt );
			TR ExtractedRootMotionDelta = TR.Identity;
			int bHasRootMotion	= 0;
			try
			{
				var asSpan = _currentPose.AsSpan();
				GetBoneAtoms(_root, asSpan, ref ExtractedRootMotionDelta, ref bHasRootMotion);
				// _skel.Animations.GetBoneAtoms(ref _skel.LocalAtoms, ref _skel.RequiredBones, ref ExtractedRootMotionDelta, ref bHasRootMotion);
			}
			finally
			{
				foreach( var kvp in _cachedNode )
				{
					kvp.Value.buff.Dispose();
				}
				_cachedNode.Clear();
			}

			// If PendingRMM has changed, set it
			if( _skel.PendingRMM != _skel.OldPendingRMM )
			{
				// Already set, do nothing
				if( _skel.RootMotionMode == _skel.PendingRMM )
				{
					_skel.OldPendingRMM = _skel.PendingRMM;
				}
				// delay by a frame if setting to RMM_Ignore AND animation extracted root motion on this frame.
				// This is to force physics to process the entire root motion.
				else if( _skel.PendingRMM != ERootMotionMode.RMM_Ignore || bHasRootMotion == 0 || _skel.bRMMOneFrameDelay == 1 )
				{
					_skel.RootMotionMode		= _skel.PendingRMM;
					_skel.OldPendingRMM		= _skel.PendingRMM;
					_skel.bRMMOneFrameDelay	= 0;
				}
				else
				{
					_skel.bRMMOneFrameDelay	= 1;
				}
			}

			// if root motion is requested, then transform it from mesh space to world space so it can be used.
			if( bHasRootMotion != 0 && _skel.RootMotionMode != ERootMotionMode.RMM_Ignore )
			{
	#if false//0 // DEBUG
				debugf(TEXT("%3.2f [%s] Extracted RM, PreProcessing, Translation: %3.3f, vect: %s, RootMotionAccelScale: %s"), 
					GWorld.GetTimeSeconds(), *Owner.GetName(), ExtractedRootMotionDelta.Translation.Size(), *ExtractedRootMotionDelta.Translation.ToString(), *RootMotionAccelScale.ToString());
	#endif
				// Transform mesh space root delta translation to world space
				ExtractedRootMotionDelta.Translation = Bones[ 0 ].parent.rotation * ExtractedRootMotionDelta.Translation;//_skel.LocalToWorld.TransformNormal(ExtractedRootMotionDelta.Translation);

				// Scale RootMotion translation in Mesh Space.
				//if( _skel.RootMotionAccelScale != FVector(1.f) )
				{
					ExtractedRootMotionDelta.Translation = Vector3.Scale(ExtractedRootMotionDelta.Translation, _skel.RootMotionAccelScale.ToUnityDir());
				}

				// If Owner required a Script event forwarded when root motion has been extracted, forward it
				if( _skel.Owner && _skel.bRootMotionExtractedNotify )
				{
					throw new Exception($"{nameof(_skel.bRootMotionExtractedNotify)} not supported");
					// Would need to change rotation and translation to unreal space and back to unity space after calling this function
					//_skel.Owner.RootMotionExtracted(_skel, ref ExtractedRootMotionDelta);
				}

				// Root Motion delta is accumulated every time it is extracted.
				// This is because on servers using autonomous physics, physics updates and ticking are out of synch.
				// So 2 physics updates can happen in a row, or 2 animation updates, effectively
				// making client and server out of synch.
				// So root motion is accumulated, and reset when used by physics.
				_skel.RootMotionDelta.Translation	+= ExtractedRootMotionDelta.Translation.ToUnrealPos();
				_skel.RootMotionVelocity			= ExtractedRootMotionDelta.Translation.ToUnrealPos() / dt;
			}
			else
			{
				_skel.RootMotionDelta.Translation = default;
				_skel.RootMotionVelocity = default;
			}




			if( bHasRootMotion != 0 && _skel.RootMotionRotationMode != ERootMotionRotationMode.RMRM_Ignore )
			{
				//Object.Quat	MeshToWorldQuat = new Object.Quat(_skel.LocalToWorld);

				// Transform mesh space delta rotation to world space.
				_skel.RootMotionDelta.Rotation = (Object.Quat)(Bones[ 0 ].parent.rotation * ExtractedRootMotionDelta.Rotation).normalized;//MeshToWorldQuat * ExtractedRootMotionDelta.Rotation * (-MeshToWorldQuat);
				//_skel.RootMotionDelta.Rotation.Normalize();
			}
			else
			{
				_skel.RootMotionDelta.Rotation = (Object.Quat)Quaternion.identity; //Object.Quat.Identity;
			}






			// Motion applied right away
			if( bHasRootMotion != 0 && 
				(_skel.RootMotionMode == ERootMotionMode.RMM_Translate || _skel.RootMotionRotationMode == ERootMotionRotationMode.RMRM_RotateActor || 
				 (_skel.RootMotionMode == ERootMotionMode.RMM_Ignore && _skel.PreviousRMM == ERootMotionMode.RMM_Translate)) )	// If root motion was just turned off, forward remaining root motion.
			{
				/*
				 * Delay applying instant translation for one frame
				 * So we check for PreviousRMM to be up to date with the current root motion mode.
				 * We need to do this because in-game physics have already been applied for this tick.
				 * So we want root motion to kick in for next frame.
				 */
				bool bCanDoTranslation = (_skel.RootMotionMode == ERootMotionMode.RMM_Translate && _skel.PreviousRMM == ERootMotionMode.RMM_Translate);
				Object.Vector InstantTranslation = bCanDoTranslation ? _skel.RootMotionDelta.Translation : default;

				bool bCanDoRotation = (_skel.RootMotionRotationMode == ERootMotionRotationMode.RMRM_RotateActor);
				Object.Rotator InstantRotation = bCanDoRotation ? /*FQuatRotationTranslationMatrix(_skel.RootMotionDelta.Rotation, default).Rotator()*/(Object.Rotator)(Quaternion)_skel.RootMotionDelta.Rotation : default;

				if( _skel.Owner && (!InstantRotation.IsZero() || InstantTranslation.SizeSquared() > SMALL_NUMBER) )
				{
	#if false//0 // DEBUG ROOT MOTION
					debugf(TEXT("%3.2f Root Motion Instant. DeltaRot: %s"), GWorld.GetTimeSeconds(), *InstantRotation.ToString());
	#endif
					// Transform mesh directly. Doesn't take in-game physics into account.
					//FCheckResult Hit(1.f);
					UWorld.Instance.MoveActor(_skel.Owner, InstantTranslation, _skel.Owner.Rotation + InstantRotation, 0, out _);

					// If we have used translation, reset the accumulator.
					if( bCanDoTranslation )
					{
						_skel.RootMotionDelta.Translation = default;
					}

					if( bCanDoRotation )
					{
						_skel.Owner.DesiredRotation = _skel.Owner.Rotation;

						// Update DesiredRotation for AI Controlled Pawns
						Pawn PawnOwner = _skel.Owner as Pawn;
						if( PawnOwner && PawnOwner.Controller && PawnOwner.Controller.bForceDesiredRotation )
						{
							PawnOwner.Controller.DesiredRotation = _skel.Owner.Rotation;
						}
					}
				}
			}

			// Track root motion mode changes
			if( _skel.RootMotionMode != _skel.PreviousRMM )
			{
				// notify owner that root motion mode changed. 
				// if RootMotionMode != RMM_Ignore, then on next frame root motion will kick in.
				if( _skel.bRootMotionModeChangeNotify && _skel.Owner )
				{
					_skel.Owner.RootMotionModeChanged(_skel);
				}
				_skel.PreviousRMM = _skel.RootMotionMode;
			}



			if( _skel.bForceDiscardRootMotion )
			{
				_currentPose[ 0 ] = TR.Identity;
			}

			// Remember the root bone's translation so we can move the bounds.
			//_skel.RootBoneTranslation = LocalAtoms[0].Pos - _skel.SkeletalMesh.RefSkeleton[0].BonePos.Position;


			for( int i = 0; i < Bones.Length; i++ )
			{
				var t = Bones[ i ];
				var tr = _currentPose[ i ];
				t.localPosition = tr.Translation;
				t.localRotation = tr.Rotation;
			}
			
			_skel.bHasHadPhysicsBlendedIn = false;
		}



		void GetBoneAtoms( AnimNode n, Span<TR> Atoms, ref TR RootMotionDelta, ref int bHasRootMotion )
		{
			// GetCachedResults
			if( _cachedNode.TryGetValue( n, out var v ) )
			{
				for( int i = 0; i < Atoms.Length; i++ )
					Atoms[ i ] = v.buff[ i ];
				bHasRootMotion = (v.rootMotion.Translation == default && v.rootMotion.Rotation == default) ? 0 : 1;
				RootMotionDelta = v.rootMotion;
				return;
			}

			if( n is AnimNodeMirror )
				throw new NodeNotSupportedException( n );
			else if( n is AnimNodeBlendMultiBone )
				throw new NodeNotSupportedException( n );
			else if( n is AnimNodeSequenceBlendByAim )
				throw new NodeNotSupportedException( n );
			else if( n is AnimNodeSequenceBlendBase )
				throw new NodeNotSupportedException( n );
			else if( n is AnimNodeAimOffset anao )
				AnimNodeAimOffset_GetBoneAtoms( anao, Atoms, ref RootMotionDelta, ref bHasRootMotion );
			else if( n is AnimNodeBlendPerBone anbpb )
				AnimNodeBlendPerBone_GetBoneAtoms( anbpb, Atoms, ref RootMotionDelta, ref bHasRootMotion );
			else if( n is AnimNodeBlendBase anbb )
				AnimNodeBlendBase_GetBoneAtoms( anbb, Atoms, ref RootMotionDelta, ref bHasRootMotion );
			else if( n is AnimNodeSequence ans )
				AnimNodeSequence_GetBoneAtoms( ans, Atoms, ref RootMotionDelta, ref bHasRootMotion );
			else
			{
				_bindPose.CopyTo( Atoms );
				RootMotionDelta = default;
				bHasRootMotion = 0;
			}

			if( n.ParentNodes.Count > 1 )
			{
				var tempClearedAtEndOfStack = TempBuffer<TR>.Borrow();
				for( int i = 0; i < Atoms.Length; i++ )
					tempClearedAtEndOfStack.Add(Atoms[ i ]);
				_cachedNode.Add( n, (tempClearedAtEndOfStack, bHasRootMotion == 0 ? default : RootMotionDelta) );
			}
		}



		void AnimNodeSequence_GetBoneAtoms( AnimNodeSequence n, Span<TR> Atoms, ref TR RootMotionDelta, ref int bHasRootMotion )
		{
			// Source: AnimNodeSequence::GetAnimationPose
			var InAnimSeq = n.AnimSeq;
			//ref var InAnimLinkupIndex = ref n.AnimLinkupIndex;
			
			//SCOPE_CYCLE_COUNTER(STAT_GetAnimationPose);

			//check(SkelComponent);
			//check(SkelComponent.SkeletalMesh);

			// Set root motion delta to identity, so it's always initialized, even when not extracted.
			RootMotionDelta = TR.Identity;
			bHasRootMotion	= 0;

			if( !InAnimSeq /*|| InAnimLinkupIndex == INDEX_NONE*/ )
			{
		#if false//0
				debugf(TEXT("UAnimNodeSequence::GetAnimationPose - %s - No animation data!"), *GetFName());
		#endif
				_bindPose.CopyTo( Atoms );
				//FillWithRefPose(Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
				return;
			}

			// Get the reference skeleton
			//ref array<MeshBone> RefSkel = ref n.SkelComponent.SkeletalMesh.RefSkeleton;
			//const int NumBones = RefSkel.Num();
			//check(NumBones == Atoms.Num());

			AnimSet AnimSet = (AnimSet)InAnimSeq.Outer;
			//check(InAnimLinkupIndex < AnimSet.LinkupCache.Num());

			//ref var AnimLinkup = ref AnimSet.LinkupCache[InAnimLinkupIndex];

			// @remove me, trying to figure out why this is failing
			/*if( AnimLinkup.BoneToTrackTable.Num() != NumBones )
			{
				debugf(TEXT("AnimLinkup.BoneToTrackTable.Num() != NumBones, BoneToTrackTable.Num(): %d, NumBones: %d, AnimName: %s, Owner: %s, Mesh: %s"), AnimLinkup.BoneToTrackTable.Num(), NumBones, *InAnimSeq.SequenceName.ToString(), *SkelComponent.GetOwner().GetName(), *SkelComponent.SkeletalMesh.GetName());
			}*/
			//check(AnimLinkup.BoneToTrackTable.Num() == NumBones);

			// Are we doing root motion for this node?
			bool bDoRootTranslation	= (n.RootBoneOption[0] != ERootBoneAxis.RBA_Default) || (n.RootBoneOption[1] != ERootBoneAxis.RBA_Default) || (n.RootBoneOption[2] != ERootBoneAxis.RBA_Default);
			bool bDoRootRotation	= (n.RootRotationOption[0] != ERootRotationOption.RRO_Default) || (n.RootRotationOption[1] != ERootRotationOption.RRO_Default) || (n.RootRotationOption[2] != ERootRotationOption.RRO_Default);
			bool bDoingRootMotion	= bDoRootTranslation || bDoRootRotation;

			// Is the skeletal mesh component requesting that raw animation data be used?
			bool bUseRawData = n.SkelComponent.bUseRawData;

			// Handle Last Frame to First Frame interpolation when looping.
			// It is however disabled for the Root Bone.
			// And the 'bNoLoopingInterpolation' flag on the animation can also disable that behavior.
			bool bLoopingInterpolation = n.bLooping && !InAnimSeq.bNoLoopingInterpolation;

			var unityClip = _clips[ InAnimSeq.SequenceName ];
			unityClip.wrapMode = bLoopingInterpolation ? WrapMode.Loop : WrapMode.Default;
			unityClip.SampleAnimation( GameObject, n.CurrentTime );

			// For each desired bone...
			for( int BoneIndex=0; BoneIndex<Atoms.Length; BoneIndex++ )
			{
				var t = Bones[ BoneIndex ];
				// Find which track in the sequence we look in for this bones data
				//int	TrackIndex = AnimLinkup.BoneToTrackTable[BoneIndex];

				// If there is no track for this bone, we just use the reference pose.
				/*if( TrackIndex == INDEX_NONE )
				{
					Atoms[BoneIndex] = FBoneAtom(RefSkel[BoneIndex].BonePos.Orientation, RefSkel[BoneIndex].BonePos.Position, 1f);					
				}
				else*/ 
				{
					// Non Root Bone
					if( BoneIndex > 0 )
					{
						// Otherwise read it from the sequence.
						Atoms[ BoneIndex ] = new TR{ Translation = t.localPosition, Rotation = t.localRotation };
						//InAnimSeq.GetBoneAtom(Atoms[BoneIndex], TrackIndex, n.CurrentTime, bLoopingInterpolation, bUseRawData);

						// If doing 'rotation only' case, use ref pose for all non-root bones that are not in the BoneUseAnimTranslation array.
						if(	AnimSet.bAnimRotationOnly /*&& AnimLinkup.BoneUseAnimTranslation[BoneIndex] == 0*/ )
						{
							Atoms[BoneIndex].Translation = _bindPose[BoneIndex].Translation;
						}

						// Apply quaternion fix for ActorX-exported quaternions.
						//Atoms[BoneIndex].Rotation.w *= -1.0f;
					}
					else
					{
						// Otherwise read it from the sequence.
						
						// RootMotion isn't as straightforward when the root position loops back to the start
						// Unreal can sample animation on a per bone basis leading to them being capable of skipping looping animation for root but
						// To do this with unity's AnimationClip would require a big perf hit or a tool which would preprocess AnimationClip
						// into a better format/API in the editor
						if(bLoopingInterpolation && bDoingRootMotion)
							Debug.LogWarning( $"Verify that when doing looping interpolation and needing RootMotion, the RootMotion is properly computed (@{n.NodeName}: {InAnimSeq.Name})" );
						Atoms[ BoneIndex ] = new TR{ Translation = t.localPosition, Rotation = t.localRotation };
						//InAnimSeq->GetBoneAtom(Atoms(BoneIndex), TrackIndex, CurrentTime, bLoopingInterpolation && !bDoingRootMotion, bUseRawData);

						// If doing root motion for this animation, extract it!
						if( bDoingRootMotion )
						{
							var rmAsTR = (TR)RootMotionDelta;
							ExtractRootMotion(n, InAnimSeq/*, TrackIndex*/, ref Atoms[0], ref rmAsTR, ref bHasRootMotion);
							RootMotionDelta = rmAsTR;
						}

						// If desired, zero out Root Bone rotation.
						if( n.bZeroRootRotation )
						{
							Atoms[0].Rotation = Quaternion.identity;
						}

						// If desired, zero out Root Bone translation.
						if( n.bZeroRootTranslation )
						{
							Atoms[0].Translation = default;
						}
					}
				}
			}
		}
		
		
		
		void ExtractRootMotion(AnimNodeSequence thisSeq, AnimSequence InAnimSeq/*, ref int TrackIndex*/, ref TR CurrentFrameAtom, ref TR DeltaMotionAtom, ref int bHasRootMotion)
		{
			// SkeletalMesh has a transformation that is applied between the component and the actor, 
			// instead of being between mesh and component. 
			// So we have to take that into account when doing operations happening in component space (such as per Axis masking/locking).
			/*const FMatrix MeshToCompTM = FRotationMatrix(SkelComponent->SkeletalMesh->RotOrigin);
			// Inverse transform, from component space to mesh space.
			const FMatrix CompToMeshTM = MeshToCompTM.Inverse();*/

			// Get the exact translation of the root bone on the first frame of the animation
			var (FirstFrameAtom, LastFrameAtom) = _rootMotion[ InAnimSeq.SequenceName ];
			/*FBoneAtom FirstFrameAtom;
			InAnimSeq.GetBoneAtom(FirstFrameAtom, TrackIndex, 0f, false, thisSeq.SkelComponent.bUseRawData);*/

			// Do we need to extract root motion?
			bool bExtractRootTranslation= (thisSeq.RootBoneOption[0] == ERootBoneAxis.RBA_Translate) || (thisSeq.RootBoneOption[1] == ERootBoneAxis.RBA_Translate) || (thisSeq.RootBoneOption[2] == ERootBoneAxis.RBA_Translate);
			bool bExtractRootRotation	= (thisSeq.RootRotationOption[0] == ERootRotationOption.RRO_Extract) || (thisSeq.RootRotationOption[1] == ERootRotationOption.RRO_Extract) || (thisSeq.RootRotationOption[2] == ERootRotationOption.RRO_Extract);
			bool bExtractRootMotion		= bExtractRootTranslation || bExtractRootRotation;

			// Calculate bone motion
			if( bExtractRootMotion )
			{
				// We are extracting root motion, so set the flag to TRUE
				bHasRootMotion	= 1;
				float StartTime	= thisSeq.PreviousTime;
				float EndTime	= thisSeq.CurrentTime;

				/*
				 * If FromTime == ToTime, then we can't give a root delta for this frame.
				 * To avoid delaying it to next frame, because physics may need it right away,
				 * see if we can make up one by simulating forward.
				 */
				if( StartTime == EndTime )
				{
					// Only try to make up movement if animation is allowed to play
					if( thisSeq.bPlaying && InAnimSeq )
					{
						// See how much time would have passed on this frame
						float DeltaTime = thisSeq.Rate * InAnimSeq.RateScale * thisSeq.SkelComponent.GlobalAnimRateScale * /*GWorld.GetDeltaSeconds()*/UWorld.Instance.WorldInfo.DeltaSeconds;

						// If we can push back FromTime, then do so.
						if( StartTime > DeltaTime )
						{
							StartTime -= DeltaTime;
						}
						else
						{
							// otherwise, advance in time, to predict the movement
							EndTime += DeltaTime;

							// See if we passed the end of the animation.
							if( EndTime > InAnimSeq.SequenceLength )
							{
								// If we are looping, wrap over. If not, snap time to end of sequence.
								EndTime = thisSeq.bLooping ? EndTime % InAnimSeq.SequenceLength : InAnimSeq.SequenceLength;
							}
						}
					}
					else
					{
						// If animation is done playing we're not extracting root motion anymore.
						bHasRootMotion = 0;
					}
				}

				// If time has passed, compute root delta movement
				if( StartTime != EndTime )
				{
					// Get Root Bone Position of start of movement
					/*BoneAtom*/TR StartAtom;
					if( StartTime != thisSeq.CurrentTime )
					{
						StartAtom = RootBoneAt( InAnimSeq, StartTime );
						//InAnimSeq.GetBoneAtom(StartAtom, TrackIndex, StartTime, false, thisSeq.SkelComponent.bUseRawData);
					}
					else
					{
						StartAtom = CurrentFrameAtom;
					}

					// Get Root Bone Position of end of movement
					/*BoneAtom*/TR EndAtom;
					if( EndTime != thisSeq.CurrentTime )
					{
						EndAtom = RootBoneAt( InAnimSeq, EndTime );
						//InAnimSeq.GetBoneAtom(EndAtom, TrackIndex, EndTime, false, thisSeq.SkelComponent.bUseRawData);
					}
					else
					{
						EndAtom = CurrentFrameAtom;
					}

					// Get position on last frame if we extract translation and/or rotation
					//BoneAtom LastFrameAtom;
					if( StartTime > EndTime && (bExtractRootTranslation || bExtractRootRotation) )
					{
						// Get the exact root position of the root bone on the last frame of the animation
						//InAnimSeq.GetBoneAtom(LastFrameAtom, TrackIndex, InAnimSeq.SequenceLength, false, thisSeq.SkelComponent.bUseRawData);
					}
					else
					{
						LastFrameAtom = default;
					}

					// We don't support scale
					//DeltaMotionAtom.Scale = 0f;

					// If extracting root translation, filter out any axis
					if( bExtractRootTranslation )
					{
						// Handle case if animation looped
						if( StartTime > EndTime )
						{
							// Handle proper translation wrapping. We don't want the mesh to translate back to origin. So split that in 2 moves.
							DeltaMotionAtom.Translation = (LastFrameAtom.Translation - StartAtom.Translation) + (EndAtom.Translation - FirstFrameAtom.Translation);
						}
						else
						{
							// Delta motion of the root bone in mesh space
							DeltaMotionAtom.Translation = EndAtom.Translation - StartAtom.Translation;
						}

						// Only do that if an axis needs to be filtered out.
						if( thisSeq.RootBoneOption[0] != ERootBoneAxis.RBA_Translate || thisSeq.RootBoneOption[1] != ERootBoneAxis.RBA_Translate || thisSeq.RootBoneOption[2] != ERootBoneAxis.RBA_Translate )
						{
							throw new Exception($"{nameof(ERootBoneAxis)} not supported");
							// Convert Delta translation from mesh space to component space
							// We do this for axis filtering
							/*Object.Vector CompDeltaTranslation = MeshToCompTM.TransformNormal(DeltaMotionAtom.Translation);

							// Filter out any of the X, Y, Z channels in mesh space
							if( thisSeq.RootBoneOption[0] != ERootBoneAxis.RBA_Translate )
							{
								CompDeltaTranslation.X = 0f;
							}
							if( thisSeq.RootBoneOption[1] != ERootBoneAxis.RBA_Translate )
							{
								CompDeltaTranslation.Y = 0f;
							}
							if( thisSeq.RootBoneOption[2] != ERootBoneAxis.RBA_Translate )
							{
								CompDeltaTranslation.Z = 0f;
							}

							// Convert back to mesh space.
							DeltaMotionAtom.Translation = MeshToCompTM.InverseTransformNormal(CompDeltaTranslation);*/
						}
		#if false//0
						debugf(TEXT("%3.2f [%s] [%s] Extracted Root Motion Trans: %3.3f, Vect: %s, StartTime: %3.3f, EndTime: %3.3f"), GWorld->GetTimeSeconds(), *SkelComponent->GetOwner()->GetName(), *AnimSeqName.ToString(), DeltaMotionAtom.Translation.Size(), *DeltaMotionAtom.Translation.ToString(), StartTime, EndTime);
		#endif
					}
					else
					{
						// Otherwise, don't extract any translation
						DeltaMotionAtom.Translation = default;
					}

					// If extracting root translation, filter out any axis
					if( bExtractRootRotation )
					{
						// Delta rotation
						// Handle case if animation looped
						if( StartTime > EndTime )
						{
							// Handle proper Rotation wrapping. We don't want the mesh to rotate back to origin. So split that in 2 turns.
							DeltaMotionAtom.Rotation = (LastFrameAtom.Rotation * MinQ(StartAtom.Rotation)) * (EndAtom.Rotation * MinQ(FirstFrameAtom.Rotation));
						}
						else
						{
							// Delta motion of the root bone in mesh space
							DeltaMotionAtom.Rotation = EndAtom.Rotation * MinQ(StartAtom.Rotation);
						}
						DeltaMotionAtom.Rotation.Normalize();

		#if false//0 // DEBUG ROOT ROTATION
						debugf(TEXT("%3.2f Root Rotation StartAtom: %s, EndAtom: %s, DeltaMotionAtom: %s"), GWorld->GetTimeSeconds(), 
							*(FQuatRotationTranslationMatrix(StartAtom.Rotation, FVector(0.f)).Rotator()).ToString(), 
							*(FQuatRotationTranslationMatrix(EndAtom.Rotation, FVector(0.f)).Rotator()).ToString(), 
							*(FQuatRotationTranslationMatrix(DeltaMotionAtom.Rotation, FVector(0.f)).Rotator()).ToString());
		#endif

						// Only do that if an axis needs to be filtered out.
						if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Extract || thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Extract || thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Extract )
						{
							throw new Exception($"{nameof(ERootRotationOption)} not supported");
							/*
							Quat	MeshToCompQuat(MeshToCompTM);

							// Turn delta rotation from mesh space to component space
							Quat	CompDeltaQuat = MeshToCompQuat * DeltaMotionAtom.Rotation * (-MeshToCompQuat);
							CompDeltaQuat.Normalize();

		#if false//0 // DEBUG ROOT ROTATION
							debugf(TEXT("%3.2f Mesh To Comp Delta: %s"), GWorld->GetTimeSeconds(), *(FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0.f)).Rotator()).ToString());
		#endif

							// Turn component space delta rotation to FRotator
							// @note going through rotators introduces some errors. See if this can be done using quaterions instead.
							Rotator CompDeltaRot = FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0.f)).Rotator();

							// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) channels in mesh space
							if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Extract )
							{
								CompDeltaRot.Roll	= 0;
							}
							if( thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Extract )
							{
								CompDeltaRot.Pitch	= 0;
							}
							if( thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Extract )
							{
								CompDeltaRot.Yaw	= 0;
							}

							// Turn back filtered component space delta rotator to quaterion
							Quat CompNewDeltaQuat	= CompDeltaRot.Quaternion();

							// Turn component space delta to mesh space.
							DeltaMotionAtom.Rotation = (-MeshToCompQuat) * CompNewDeltaQuat * MeshToCompQuat;
							DeltaMotionAtom.Rotation.Normalize();

		#if false//0 // DEBUG ROOT ROTATION
							debugf(TEXT("%3.2f Post Comp Filter. CompDelta: %s, MeshDelta: %s"), GWorld->GetTimeSeconds(), 
								*(FQuatRotationTranslationMatrix(CompNewDeltaQuat, FVector(0.f)).Rotator()).ToString(), 
								*(FQuatRotationTranslationMatrix(DeltaMotionAtom.Rotation, FVector(0.f)).Rotator()).ToString());
		#endif
*/
						}

		#if false//0 // DEBUG ROOT ROTATION
						FQuat	MeshToCompQuat(MeshToCompTM);

						// Transform mesh space delta rotation to component space.
						FQuat	CompDeltaQuat	= MeshToCompQuat * DeltaMotionAtom.Rotation * (-MeshToCompQuat);
						CompDeltaQuat.Normalize();

						debugf(TEXT("%3.2f Extracted Root Rotation: %s"), GWorld->GetTimeSeconds(), *(FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0.f)).Rotator()).ToString());
		#endif

						// Transform delta translation by this delta rotation.
						// This is to compensate the fact that the rotation will rotate the actor, and affect the translation.
						// This assumes that root rotation won't be weighted down the tree, and that Actor will actually use it...
						// Also we don't filter rotation per axis here.. what is done for delta root rotation, should be done here as well.
						if( DeltaMotionAtom.Translation != default )
						{
							// Delta rotation since first frame
							// Remove delta we just extracted, because translation is going to be applied with current rotation, not new one.
							var	MeshDeltaRotQuat = (CurrentFrameAtom.Rotation * MinQ(FirstFrameAtom.Rotation)) * MinQ(DeltaMotionAtom.Rotation);
							MeshDeltaRotQuat.Normalize();

							// Only do that if an axis needs to be filtered out.
							if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Extract || thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Extract || thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Extract )
							{
								throw new Exception($"{nameof(ERootRotationOption)} not supported");
								/*
								FQuat	MeshToCompQuat(MeshToCompTM);

								// Turn delta rotation from mesh space to component space
								FQuat	CompDeltaQuat = MeshToCompQuat * MeshDeltaRotQuat * (-MeshToCompQuat);
								CompDeltaQuat.Normalize();

								// Turn component space delta rotation to FRotator
								// @note going through rotators introduces some errors. See if this can be done using quaterions instead.
								FRotator CompDeltaRot = FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0.f)).Rotator();

								// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) channels in mesh space
								if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Extract )
								{
									CompDeltaRot.Roll	= 0;
								}
								if( thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Extract )
								{
									CompDeltaRot.Pitch	= 0;
								}
								if( thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Extract )
								{
									CompDeltaRot.Yaw	= 0;
								}

								// Turn back filtered component space delta rotator to quaterion
								FQuat CompNewDeltaQuat = CompDeltaRot.Quaternion();

								// Turn component space delta to mesh space.
								MeshDeltaRotQuat = (-MeshToCompQuat) * CompNewDeltaQuat * MeshToCompQuat;
								MeshDeltaRotQuat.Normalize();*/
							}

							/*FMatrix	MeshDeltaRotTM		= FQuatRotationTranslationMatrix(MeshDeltaRotQuat, FVector(0.f));
							DeltaMotionAtom.Translation = MeshDeltaRotTM.InverseTransformNormal( DeltaMotionAtom.Translation );*/
							// Something like this I think ?
							DeltaMotionAtom.Translation = Quaternion.Inverse(MeshDeltaRotQuat) * ( DeltaMotionAtom.Translation );
						}
					}
					else
					{			
						// If we're not extracting rotation, then set to identity
						DeltaMotionAtom.Rotation = Quaternion.identity;
					}
				}
				else // if( StartTime != EndTime )
				{
					// Root Motion cannot be extracted.
					DeltaMotionAtom = TR.Identity;
				}
			}

			// Apply bone locking, with axis filtering (in component space)
			// Bone is locked to its position on the first frame of animation.
			{
				// Lock full rotation to first frame.
				if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Default && thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Default && thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Default)
				{
					CurrentFrameAtom.Rotation = FirstFrameAtom.Rotation;
				}
				// Do we need to lock at least one axis of the bone's rotation to the first frame's value?
				else if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Default || thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Default || thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Default )
				{
					throw new Exception($"{nameof(ERootRotationOption)} not supported");/*
					FQuat	MeshToCompQuat(MeshToCompTM);

					// Find delta between current frame and first frame
					FQuat	CompFirstQuat	= MeshToCompQuat * FirstFrameAtom.Rotation;
					FQuat	CompCurrentQuat	= MeshToCompQuat * CurrentFrameAtom.Rotation;
					FQuat	CompDeltaQuat	= CompCurrentQuat * (-CompFirstQuat);
					CompDeltaQuat.Normalize();

					FRotator CompDeltaRot = FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0.f)).Rotator();

					// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) channels in mesh space
					if( thisSeq.RootRotationOption[0] != ERootRotationOption.RRO_Default )
					{
						CompDeltaRot.Roll	= 0;
					}
					if( thisSeq.RootRotationOption[1] != ERootRotationOption.RRO_Default )
					{
						CompDeltaRot.Pitch	= 0;
					}
					if( thisSeq.RootRotationOption[2] != ERootRotationOption.RRO_Default )
					{
						CompDeltaRot.Yaw	= 0;
					}

					// Use new delta and first frame to find out new current rotation.
					FQuat	CompNewDeltaQuat	= CompDeltaRot.Quaternion();
					FQuat	CompNewCurrentQuat	= CompNewDeltaQuat * CompFirstQuat;
					CompNewCurrentQuat.Normalize();

					CurrentFrameAtom.Rotation	= (-MeshToCompQuat) * CompNewCurrentQuat;
					CurrentFrameAtom.Rotation.Normalize();*/
				}

				// Lock full bone translation to first frame
				if( thisSeq.RootBoneOption[0] != ERootBoneAxis.RBA_Default && thisSeq.RootBoneOption[1] != ERootBoneAxis.RBA_Default && thisSeq.RootBoneOption[2] != ERootBoneAxis.RBA_Default )
				{
					CurrentFrameAtom.Translation = FirstFrameAtom.Translation;

		#if false//0
					debugf(TEXT("%3.2f Lock Root Bone to first frame translation: %s"), GWorld->GetTimeSeconds(), *FirstFrameAtom.Translation.ToString());
		#endif
				}
				// Do we need to lock at least one axis of the bone's translation to the first frame's value?
				else if( thisSeq.RootBoneOption[0] != ERootBoneAxis.RBA_Default || thisSeq.RootBoneOption[1] != ERootBoneAxis.RBA_Default || thisSeq.RootBoneOption[2] != ERootBoneAxis.RBA_Default )
				{
					throw new Exception($"{nameof(ERootBoneAxis)} not supported");/*
					FVector CompCurrentFrameTranslation			= MeshToCompTM.TransformNormal(CurrentFrameAtom.Translation);
					const	FVector	CompFirstFrameTranslation	= MeshToCompTM.TransformNormal(FirstFrameAtom.Translation);

					// Lock back to first frame position any of the X, Y, Z axis
					if( thisSeq.RootBoneOption[0] != ERootBoneAxis.RBA_Default  )
					{
						CompCurrentFrameTranslation.X = CompFirstFrameTranslation.X;
					}
					if( thisSeq.RootBoneOption[1] != ERootBoneAxis.RBA_Default  )
					{
						CompCurrentFrameTranslation.Y = CompFirstFrameTranslation.Y;
					}
					if( thisSeq.RootBoneOption[2] != ERootBoneAxis.RBA_Default  )
					{
						CompCurrentFrameTranslation.Z = CompFirstFrameTranslation.Z;
					}

					// convert back to mesh space
					CurrentFrameAtom.Translation = MeshToCompTM.InverseTransformNormal(CompCurrentFrameTranslation);*/
				}
			}
		}



		void AnimNodeAimOffset_GetBoneAtoms( AnimNodeAimOffset n, Span<TR> Atoms, ref TR RootMotionDelta, ref int bHasRootMotion )
		{
			var Children = n.Children;
			ref var AngleOffset = ref n.AngleOffset;
			
			// Get local space atoms from child
			if( Children[0].Anim )
			{
				// EXCLUDE_CHILD_TIME
				GetBoneAtoms(Children[0].Anim, Atoms, ref RootMotionDelta, ref bHasRootMotion);
			}
			else
			{
				RootMotionDelta = TR.Identity;
				bHasRootMotion	= 0;
				_bindPose.CopyTo(Atoms);
			}

			// Have the option of doing nothing if at a low LOD.
			/*if( !SkelComponent || RequiredBones.Num() == 0 || SkelComponent.PredictedLODLevel >= PassThroughAtOrAboveLOD )
			{
				return;
			}*/

			//SkeletalMesh	SkelMesh = SkelComponent.SkeletalMesh;
			//int				NumBones = SkelMesh.RefSkeleton.Num();

			// Make sure we have a valid setup
			if( TryGetCurrentProfile(n, out var P) == false /*|| BoneToAimCpnt.Num() != NumBones*/ )
			{
				return;
			}

			Object.Vector2D SafeAim = n.Aim;
			
			// Add in rotation offset, but not in the editor
			//if( !GIsEditor || GIsGame )
			{
				if( AngleOffset.X != 0f )
				{
					SafeAim.X = UnWindNormalizedAimAngle(SafeAim.X - AngleOffset.X);
				}
				if( AngleOffset.Y != 0f )
				{
					SafeAim.Y = UnWindNormalizedAimAngle(SafeAim.Y - AngleOffset.Y);
				}
			}

			// Scale by range
			if( P.HorizontalRange.X != 0f && SafeAim.X < 0f )
			{
				SafeAim.X = SafeAim.X / Mathf.Abs(P.HorizontalRange.X);
			}
			if( P.HorizontalRange.Y != 0f && SafeAim.X > 0f )
			{
				SafeAim.X = SafeAim.X / P.HorizontalRange.Y;
			}
			if( P.VerticalRange.X != 0f && SafeAim.Y < 0f )
			{
				SafeAim.Y = SafeAim.Y / Mathf.Abs(P.VerticalRange.X);
			}
			if( P.VerticalRange.Y != 0f && SafeAim.Y > 0f )
			{
				SafeAim.Y = SafeAim.Y / P.VerticalRange.Y;
			}

			// Make sure we're using correct values within legal range.
			SafeAim.X = Object.Clamp<float>(SafeAim.X, -1f, +1f);
			SafeAim.Y = Object.Clamp<float>(SafeAim.Y, -1f, +1f);

			// Post process final Aim.
			n.PostAimProcessing(ref SafeAim);

			// Bypass node if using center center position.
			if( (!n.bForceAimDir && SafeAim.IsNearlyZero()) || (n.bForceAimDir && n.ForcedAimDir == EAnimAimDir.ANIMAIM_CENTERCENTER) )
			{
				return;
			}

			// We build the mesh-space matrices of the source bones.
			/*if( AimOffsetBoneTM.Num() < NumBones )
			{
				AimOffsetBoneTM.Reset();
				AimOffsetBoneTM.Add(NumBones);
			}*/

			/* int NumAimComp = P.AimComponents.Num();
			 int RequiredNum = RequiredBones.Num();
			 int DesiredNum = DesiredBones.Num();
			int DesiredPos = 0;
			int RequiredPos = 0;
			int BoneIndex = 0;
			while( DesiredPos < DesiredNum && RequiredPos < RequiredNum )
			*/
			for( int i = 0; i < P.AimComponents.Count; i++ )
			{
				var AimCpnt = P.AimComponents[ i ];
				var BoneIndex = NameToIndex[ AimCpnt.BoneName ];
				
				Quaternion QuaternionOffset = default;
				Vector3 TranslationOffset = default;

				// If bForceAimDir - just use whatever ForcedAimDir is set to - ignore Aim.
				if( n.bForceAimDir )
				{
					switch( n.ForcedAimDir )
					{
						case EAnimAimDir.ANIMAIM_LEFTUP			:	QuaternionOffset	= (Quaternion)AimCpnt.LU.Quaternion; 
														TranslationOffset	= AimCpnt.LU.Translation.ToUnityDir();	
														break;
						case EAnimAimDir.ANIMAIM_CENTERUP		:	QuaternionOffset	= (Quaternion)AimCpnt.CU.Quaternion; 
														TranslationOffset	= AimCpnt.CU.Translation.ToUnityDir();	
														break;
						case EAnimAimDir.ANIMAIM_RIGHTUP		:	QuaternionOffset	= (Quaternion)AimCpnt.RU.Quaternion; 
														TranslationOffset	= AimCpnt.RU.Translation.ToUnityDir(); 
														break;
						case EAnimAimDir.ANIMAIM_LEFTCENTER		:	QuaternionOffset	= (Quaternion)AimCpnt.LC.Quaternion; 
														TranslationOffset	= AimCpnt.LC.Translation.ToUnityDir(); 
														break;
						case EAnimAimDir.ANIMAIM_CENTERCENTER	:	QuaternionOffset	= (Quaternion)AimCpnt.CC.Quaternion; 
														TranslationOffset	= AimCpnt.CC.Translation.ToUnityDir(); 
														break;
						case EAnimAimDir.ANIMAIM_RIGHTCENTER	:	QuaternionOffset	= (Quaternion)AimCpnt.RC.Quaternion; 
														TranslationOffset	= AimCpnt.RC.Translation.ToUnityDir(); 
														break;
						case EAnimAimDir.ANIMAIM_LEFTDOWN		:	QuaternionOffset	= (Quaternion)AimCpnt.LD.Quaternion; 
														TranslationOffset	= AimCpnt.LD.Translation.ToUnityDir(); 
														break;
						case EAnimAimDir.ANIMAIM_CENTERDOWN		:	QuaternionOffset	= (Quaternion)AimCpnt.CD.Quaternion; 
														TranslationOffset	= AimCpnt.CD.Translation.ToUnityDir(); 
														break;
						case EAnimAimDir.ANIMAIM_RIGHTDOWN		:	QuaternionOffset	= (Quaternion)AimCpnt.RD.Quaternion; 
														TranslationOffset	= AimCpnt.RD.Translation.ToUnityDir(); 
														break;
					}
				}
				else
				{
					if( SafeAim.X >= 0f && SafeAim.Y >= 0f ) // Up Right
					{
						QuaternionOffset	= BiLerpQuat(AimCpnt.CC.Quaternion, AimCpnt.RC.Quaternion, AimCpnt.CU.Quaternion, AimCpnt.RU.Quaternion, SafeAim.X, SafeAim.Y);
						TranslationOffset	= BiLerp(AimCpnt.CC.Translation, AimCpnt.RC.Translation, AimCpnt.CU.Translation, AimCpnt.RU.Translation, SafeAim.X, SafeAim.Y);
					}
					else if( SafeAim.X >= 0f && SafeAim.Y < 0f ) // Bottom Right
					{
						QuaternionOffset	= BiLerpQuat(AimCpnt.CD.Quaternion, AimCpnt.RD.Quaternion, AimCpnt.CC.Quaternion, AimCpnt.RC.Quaternion, SafeAim.X, SafeAim.Y+1f);
						TranslationOffset	= BiLerp(AimCpnt.CD.Translation, AimCpnt.RD.Translation, AimCpnt.CC.Translation, AimCpnt.RC.Translation, SafeAim.X, SafeAim.Y+1f);
					}
					else if( SafeAim.X < 0f && SafeAim.Y >= 0f ) // Up Left
					{
						QuaternionOffset	= BiLerpQuat(AimCpnt.LC.Quaternion, AimCpnt.CC.Quaternion, AimCpnt.LU.Quaternion, AimCpnt.CU.Quaternion, SafeAim.X+1f, SafeAim.Y);
						TranslationOffset	= BiLerp(AimCpnt.LC.Translation, AimCpnt.CC.Translation, AimCpnt.LU.Translation, AimCpnt.CU.Translation, SafeAim.X+1f, SafeAim.Y);
					}
					else if( SafeAim.X < 0f && SafeAim.Y < 0f ) // Bottom Left
					{
						QuaternionOffset	= BiLerpQuat(AimCpnt.LD.Quaternion, AimCpnt.CD.Quaternion, AimCpnt.LC.Quaternion, AimCpnt.CC.Quaternion, SafeAim.X+1f, SafeAim.Y+1f);
						TranslationOffset	= BiLerp(AimCpnt.LD.Translation, AimCpnt.CD.Translation, AimCpnt.LC.Translation, AimCpnt.CC.Translation, SafeAim.X+1f, SafeAim.Y+1f);
					}

					// Normalize Resulting Quaternion
					QuaternionOffset.Normalize();
				}

				// only perform a transformation if it is significant
				// (Since it's something expensive to do)
				bool	bDoRotation	= QuaternionOffset.w * QuaternionOffset.w < 1f - DELTA * DELTA;
				if( bDoRotation || !TranslationOffset.IsNearlyZero() )
				{
					// Find bone translation
					 /*Vector BoneOrigin = TranslationOffset + AimOffsetBoneTM[BoneIndex].GetOrigin();

					// Apply bone rotation
					if( bDoRotation )
					{
						AimOffsetBoneTM[BoneIndex] *= FQuatRotationTranslationMatrix(QuaternionOffset, Vector(0f));
					}

					// Apply bone translation
					AimOffsetBoneTM[BoneIndex].SetOrigin(BoneOrigin);

					// Transform back to parent bone space
					MEdge.Core.Object.Matrix RelTM;
					if( BoneIndex == 0 )
					{
						RelTM = AimOffsetBoneTM[BoneIndex];
					}
					else
					{
						 int ParentIndex = SkelMesh.RefSkeleton[BoneIndex].ParentIndex;
						RelTM = AimOffsetBoneTM[BoneIndex] * AimOffsetBoneTM[ParentIndex].Inverse();
					}

					 TR	TransformedAtom = new TR(RelTM);
					Atoms[BoneIndex].Rotation		= TransformedAtom.Rotation;
					Atoms[BoneIndex].Translation	= TransformedAtom.Translation;*/
					 Atoms[ BoneIndex ] = new TR { Rotation = Atoms[ BoneIndex ].Rotation * QuaternionOffset, Translation = Atoms[ BoneIndex ].Translation + TranslationOffset };
				}
				
			}
			
			// Lots of unnecessary operations
			#if UNUSED
			for( int i = 0; i < n.RequiredBones.Count; i++ )
			{
				int BoneIndex = n.RequiredBones[ i ];
				// Perform intersection of RequiredBones and DesiredBones array.
				// If they are the same, BoneIndex is relevant and we should process it.
				/*if( DesiredBones[DesiredPos] == RequiredBones[RequiredPos] )
				{
					BoneIndex = DesiredBones[DesiredPos];
					DesiredPos++;
					RequiredPos++;
				}
				// If value at DesiredPos is lower, increment DesiredPos.
				else if( DesiredBones[DesiredPos] < RequiredBones[RequiredPos] )
				{
					DesiredPos++;
					continue;
				}
				// If value at RequiredPos is lower, increment RequiredPos.
				else
				{
					RequiredPos++;
					continue;
				}*/

				// transform required bones into component space
				Atoms[BoneIndex].ToTransform(AimOffsetBoneTM[BoneIndex]);
				if( BoneIndex > 0 )
				{
					AimOffsetBoneTM[BoneIndex] *= AimOffsetBoneTM[SkelMesh.RefSkeleton[BoneIndex].ParentIndex];
				}

				// See if this bone should be transformed. ie there is an AimComponent defined for it
				 int AimCompIndex = BoneToAimCpnt[BoneIndex];
				if( AimCompIndex != INDEX_NONE )
				{
							Quat			QuaternionOffset;
							Vector			TranslationOffset;
						AimComponent	AimCpnt = P.AimComponents[AimCompIndex];

					// If bForceAimDir - just use whatever ForcedAimDir is set to - ignore Aim.
					if( n.bForceAimDir )
					{
						switch( n.ForcedAimDir )
						{
							case EAnimAimDir.ANIMAIM_LEFTUP			:	QuaternionOffset	= AimCpnt.LU.Quaternion; 
															TranslationOffset	= AimCpnt.LU.Translation;	
															break;
							case EAnimAimDir.ANIMAIM_CENTERUP		:	QuaternionOffset	= AimCpnt.CU.Quaternion; 
															TranslationOffset	= AimCpnt.CU.Translation;	
															break;
							case EAnimAimDir.ANIMAIM_RIGHTUP		:	QuaternionOffset	= AimCpnt.RU.Quaternion; 
															TranslationOffset	= AimCpnt.RU.Translation; 
															break;
							case EAnimAimDir.ANIMAIM_LEFTCENTER		:	QuaternionOffset	= AimCpnt.LC.Quaternion; 
															TranslationOffset	= AimCpnt.LC.Translation; 
															break;
							case EAnimAimDir.ANIMAIM_CENTERCENTER	:	QuaternionOffset	= AimCpnt.CC.Quaternion; 
															TranslationOffset	= AimCpnt.CC.Translation; 
															break;
							case EAnimAimDir.ANIMAIM_RIGHTCENTER	:	QuaternionOffset	= AimCpnt.RC.Quaternion; 
															TranslationOffset	= AimCpnt.RC.Translation; 
															break;
							case EAnimAimDir.ANIMAIM_LEFTDOWN		:	QuaternionOffset	= AimCpnt.LD.Quaternion; 
															TranslationOffset	= AimCpnt.LD.Translation; 
															break;
							case EAnimAimDir.ANIMAIM_CENTERDOWN		:	QuaternionOffset	= AimCpnt.CD.Quaternion; 
															TranslationOffset	= AimCpnt.CD.Translation; 
															break;
							case EAnimAimDir.ANIMAIM_RIGHTDOWN		:	QuaternionOffset	= AimCpnt.RD.Quaternion; 
															TranslationOffset	= AimCpnt.RD.Translation; 
															break;
						}
					}
					else
					{
						if( SafeAim.X >= 0f && SafeAim.Y >= 0f ) // Up Right
						{
							QuaternionOffset	= BiLerpQuat(AimCpnt.CC.Quaternion, AimCpnt.RC.Quaternion, AimCpnt.CU.Quaternion, AimCpnt.RU.Quaternion, SafeAim.X, SafeAim.Y);
							TranslationOffset	= BiLerp(AimCpnt.CC.Translation, AimCpnt.RC.Translation, AimCpnt.CU.Translation, AimCpnt.RU.Translation, SafeAim.X, SafeAim.Y);
						}
						else if( SafeAim.X >= 0f && SafeAim.Y < 0f ) // Bottom Right
						{
							QuaternionOffset	= BiLerpQuat(AimCpnt.CD.Quaternion, AimCpnt.RD.Quaternion, AimCpnt.CC.Quaternion, AimCpnt.RC.Quaternion, SafeAim.X, SafeAim.Y+1f);
							TranslationOffset	= BiLerp(AimCpnt.CD.Translation, AimCpnt.RD.Translation, AimCpnt.CC.Translation, AimCpnt.RC.Translation, SafeAim.X, SafeAim.Y+1f);
						}
						else if( SafeAim.X < 0f && SafeAim.Y >= 0f ) // Up Left
						{
							QuaternionOffset	= BiLerpQuat(AimCpnt.LC.Quaternion, AimCpnt.CC.Quaternion, AimCpnt.LU.Quaternion, AimCpnt.CU.Quaternion, SafeAim.X+1f, SafeAim.Y);
							TranslationOffset	= BiLerp(AimCpnt.LC.Translation, AimCpnt.CC.Translation, AimCpnt.LU.Translation, AimCpnt.CU.Translation, SafeAim.X+1f, SafeAim.Y);
						}
						else if( SafeAim.X < 0f && SafeAim.Y < 0f ) // Bottom Left
						{
							QuaternionOffset	= BiLerpQuat(AimCpnt.LD.Quaternion, AimCpnt.CD.Quaternion, AimCpnt.LC.Quaternion, AimCpnt.CC.Quaternion, SafeAim.X+1f, SafeAim.Y+1f);
							TranslationOffset	= BiLerp(AimCpnt.LD.Translation, AimCpnt.CD.Translation, AimCpnt.LC.Translation, AimCpnt.CC.Translation, SafeAim.X+1f, SafeAim.Y+1f);
						}

						// Normalize Resulting Quaternion
						QuaternionOffset.Normalize();
					}

					// only perform a transformation if it is significant
					// (Since it's something expensive to do)
					 bool	bDoRotation	= Square(QuaternionOffset.W) < 1f - DELTA * DELTA;
					if( bDoRotation || !TranslationOffset.IsNearlyZero() )
					{
						// Find bone translation
						 Vector BoneOrigin = TranslationOffset + AimOffsetBoneTM[BoneIndex].GetOrigin();

						// Apply bone rotation
						if( bDoRotation )
						{
							AimOffsetBoneTM[BoneIndex] *= FQuatRotationTranslationMatrix(QuaternionOffset, Vector(0f));
						}

						// Apply bone translation
						AimOffsetBoneTM[BoneIndex].SetOrigin(BoneOrigin);

						// Transform back to parent bone space
						MEdge.Core.Object.Matrix RelTM;
						if( BoneIndex == 0 )
						{
							RelTM = AimOffsetBoneTM[BoneIndex];
						}
						else
						{
							 int ParentIndex = SkelMesh.RefSkeleton[BoneIndex].ParentIndex;
							RelTM = AimOffsetBoneTM[BoneIndex] * AimOffsetBoneTM[ParentIndex].Inverse();
						}

						 TR	TransformedAtom = new TR(RelTM);
						Atoms[BoneIndex].Rotation		= TransformedAtom.Rotation;
						Atoms[BoneIndex].Translation	= TransformedAtom.Translation;
					}
				}
			}
			#endif
		}



		unsafe void AnimNodeBlendPerBone_GetBoneAtoms( AnimNodeBlendPerBone n, Span<TR> Atoms, ref TR RootMotionDelta, ref int bHasRootMotion )
		{
			// START_GETBONEATOM_TIMER

			var Children = n.Children;
			

			// If drawing all from Children[0], no need to look at Children[1]. Pass Atoms array directly to Children[0].
			if( Children[0].Weight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
			{
				if( Children[0].Anim )
				{
					// EXCLUDE_CHILD_TIME
					GetBoneAtoms(Children[0].Anim, Atoms, ref RootMotionDelta, ref bHasRootMotion);
				}
				else
				{
					RootMotionDelta = TR.Identity;
					bHasRootMotion	= 0;
					_bindPose.CopyTo(Atoms);
				}

				// Pass-through, no caching needed.
				return;
			}

			//ref MEdge.array<FMeshBone> RefSkel = SkelComponent.SkeletalMesh.RefSkeleton;
			//int NumAtoms = RefSkel.Num();

			Span<TR> Child1Atoms = stackalloc TR[ Bones.Length ];
			Span<TR> Child2Atoms = stackalloc TR[ Bones.Length ];

			// Get bone atoms from each child (if no child - use ref pose).
			TR	Child1RMD = TR.Identity;
			int bChild1HasRootMotion = 0;
			if( Children[0].Anim )
			{
				// EXCLUDE_CHILD_TIME
				GetBoneAtoms(Children[0].Anim, Child1Atoms, ref Child1RMD, ref bChild1HasRootMotion);
			}
			else
			{
				_bindPose.CopyTo(Child1Atoms);
			}

			// Get only the necessary bones from child2. The ones that have a Child2PerBoneWeight[BoneIndex] > 0
			TR	Child2RMD				= TR.Identity;
			int		bChild2HasRootMotion	= 0;

			//debugf(TEXT("child2 went from %d bones to %d bones."), DesiredBones.Num(), Child2DesiredBones.Num() );
			if( Children[1].Anim )
			{
				// EXCLUDE_CHILD_TIME
				GetBoneAtoms(Children[1].Anim, Child2Atoms, ref Child2RMD, ref bChild2HasRootMotion);
			}
			else
			{
				_bindPose.CopyTo(Child2Atoms);
			}

			// If we are doing component-space blend, ensure working buffers are big enough
			if(!n.bForceLocalSpaceBlend)
			{
				NativeMarkers.MarkUnimplemented();
				#if UNUSED
				Child1CompSpace.Reset();
				Child1CompSpace.Add(NumAtoms);

				Child2CompSpace.Reset();
				Child2CompSpace.Add(NumAtoms);

				ResultCompSpace.Reset();
				ResultCompSpace.Add(NumAtoms);
				#endif
			}

			int LocalToCompReqIndex = 0;

			// do blend
			for(int BoneIndex=0; BoneIndex<Atoms.Length; BoneIndex++)
			{
				 float Child2BoneWeight	= Children[1].Weight * n.Child2PerBoneWeight[BoneIndex];

				//debugf(TEXT("  (%2d) %1.1f %s"), BoneIndex, Child2PerBoneWeight[BoneIndex], *RefSkel[BoneIndex].Name);
				 bool bDoComponentSpaceBlend =	LocalToCompReqIndex < n.LocalToCompReqBones.Num() && 
														BoneIndex == n.LocalToCompReqBones[LocalToCompReqIndex];

				if( !n.bForceLocalSpaceBlend && bDoComponentSpaceBlend )
				{
					NativeMarkers.MarkUnimplemented();
					#if UNUSED
					//debugf(TEXT("  (%2d) %1.1f %s"), BoneIndex, Child2PerBoneWeight[BoneIndex], *RefSkel[BoneIndex].Name);
					LocalToCompReqIndex++;

					 int ParentIndex	= RefSkel[BoneIndex].ParentIndex;

					// turn bone atoms to matrices
					Child1Atoms[BoneIndex].ToTransform(Child1CompSpace[BoneIndex]);
					Child2Atoms[BoneIndex].ToTransform(Child2CompSpace[BoneIndex]);

					// transform to component space
					if( BoneIndex > 0 )
					{
						Child1CompSpace[BoneIndex] *= Child1CompSpace[ParentIndex];
						Child2CompSpace[BoneIndex] *= Child2CompSpace[ParentIndex];
					}

					// everything comes from child1 copy directly
					if( Child2BoneWeight <= ZERO_ANIMWEIGHT_THRESH )
					{
						ResultCompSpace[BoneIndex] = Child1CompSpace[BoneIndex];
					}
					// everything comes from child2, copy directly
					else if( Child2BoneWeight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
					{
						ResultCompSpace[BoneIndex] = Child2CompSpace[BoneIndex];
					}
					// blend rotation in component space of both childs
					else
					{
						// convert matrices to FBoneAtoms
						TR Child1CompSpaceAtom = new BoneAtom(Child1CompSpace[BoneIndex]);
						TR Child2CompSpaceAtom = new BoneAtom(Child2CompSpace[BoneIndex]);

						// blend BoneAtom rotation. We store everything in Child1

						// We use a linear interpolation and a re-normalize for the rotation.
						// Treating Rotation as an accumulator, initialise to a scaled version of Atom1.
						Child1CompSpaceAtom.Rotation = Child1CompSpaceAtom.Rotation * (1f - Child2BoneWeight);

						// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming rotation is positive.
						if( (Child1CompSpaceAtom.Rotation | Child2CompSpaceAtom.Rotation) < 0f )
						{
							Child1CompSpaceAtom.Rotation = Child1CompSpaceAtom.Rotation * -1f;
						}

						// Then add on the second rotation..
						Child1CompSpaceAtom.Rotation = Child1CompSpaceAtom.Rotation + (Child2CompSpaceAtom.Rotation * Child2BoneWeight);

						// ..and renormalize
						Child1CompSpaceAtom.Rotation.Normalize();

						// convert back BoneAtom to MEdge.Core.Object.Matrix
						Child1CompSpaceAtom.ToTransform(ResultCompSpace[BoneIndex]);
					}

					// Blend Translation and Scale in local space
					if( Child2BoneWeight <= ZERO_ANIMWEIGHT_THRESH )
					{
						// if blend is all the way for child1, then just copy its bone atoms
						Atoms[BoneIndex] = Child1Atoms[BoneIndex];
					}
					else if( Child2BoneWeight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
					{
						// if blend is all the way for child2, then just copy its bone atoms
						Atoms[BoneIndex] = Child2Atoms[BoneIndex];
					}
					else
					{
						// Simple linear interpolation for translation and scale.
						Atoms[BoneIndex].Translation	= Lerp(Child1Atoms[BoneIndex].Translation, Child2Atoms[BoneIndex].Translation, Child2BoneWeight);
						Atoms[BoneIndex].Scale			= Lerp(Child1Atoms[BoneIndex].Scale, Child2Atoms[BoneIndex].Scale, Child2BoneWeight);
					}

					// and rotation was blended in component space...
					// convert bone atom back to local space
					MEdge.Core.Object.Matrix ParentTM = MEdge.Core.Object.Matrix.Identity;
					if( BoneIndex > 0 )
					{
						ParentTM = ResultCompSpace[ParentIndex];
					}

					// Then work out relative transform, and convert to BoneAtom.
					 MEdge.Core.Object.Matrix RelTM = ResultCompSpace[BoneIndex] * ParentTM.Inverse();				
					Atoms[BoneIndex].Rotation = BoneAtom(RelTM).Rotation;
					#endif
				}	
				else
				{
					// otherwise do faster local space blending.
					Atoms[BoneIndex].Blend(Child1Atoms[BoneIndex], Child2Atoms[BoneIndex], Child2BoneWeight);
				}

				// Blend root motion
				if( BoneIndex == 0 )
				{
					bHasRootMotion = bChild1HasRootMotion != 0 || bChild2HasRootMotion != 0 ? 1 : 0;

					if( bChild1HasRootMotion != 0 && bChild2HasRootMotion != 0 )
					{
						RootMotionDelta.Blend( Child1RMD, Child2RMD, Child2BoneWeight );
					}
					else if( bChild1HasRootMotion != 0 )
					{
						RootMotionDelta = Child1RMD;
					}
					else if( bChild2HasRootMotion != 0 )
					{
						RootMotionDelta = Child2RMD;
					}
				}
			}
		}



		unsafe void AnimNodeBlendBase_GetBoneAtoms( AnimNodeBlendBase n, Span<TR> Atoms, ref TR RootMotionDelta, ref int bHasRootMotion )
		{
			if( n.Children.Num() == 0 )
			{
				RootMotionDelta = default;
				bHasRootMotion = 0;
				_bindPose.CopyTo(Atoms);
				return;
			}
			
			int LastChildIndex = -1;
			var Children = n.Children;
			for(int i=0; i<Children.Num(); i++)
			{
				if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH )
				{
					// If this is the only child with any weight, pass Atoms array into it directly.
					if( Children[i].Weight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
					{
						if( Children[i].Anim )
						{
							// EXCLUDE_CHILD_TIME
							if( Children[i].bMirrorSkeleton )
							{
								throw new Exception( "bMirrorSkeleton not supported" );
								//GetMirroredBoneAtoms(ref Atoms, i, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
							}
							else
							{
								GetBoneAtoms(Children[i].Anim, Atoms, ref RootMotionDelta, ref bHasRootMotion);
							}
						}
						else
						{
							RootMotionDelta = TR.Identity;
							bHasRootMotion	= 0;
							_bindPose.CopyTo(Atoms);
						}

						// If we're modifying the input, then cache results.
						// Otherwise just pass through without caching anything.
						if( Children[i].bMirrorSkeleton )
						{
							throw new Exception( "bMirrorSkeleton not supported" );
							//SaveCachedResults(Atoms, RootMotionDelta, bHasRootMotion);
						}
						return;
					}
					LastChildIndex = i;
				}
			}







			Span<TR> ChildAtoms = stackalloc TR[Bones.Length];
			bool bNoChildrenYet = true;

			bHasRootMotion						= 0;
			int		LastRootMotionChildIndex	= -1;
			float	AccumulatedRootMotionWeight	= 0f;

			// Iterate over each child getting its atoms, scaling them and adding them to output (Atoms array)
			for(int i=0; i<=LastChildIndex; i++)
			{
				// If this child has non-zero weight, blend it into accumulator.
				if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH )
				{
					// Do need to request atoms, so allocate array here.
					if( ChildAtoms.Length == 0 )
					{
						var identity = TR.Identity;
						for( int j = 0; j < ChildAtoms.Length; j++ )
							ChildAtoms[ j ] = identity;
					}

					// Get bone atoms from child node (if no child - use ref pose).
					if( Children[i].Anim )
					{
						// EXCLUDE_CHILD_TIME
						if( Children[i].bMirrorSkeleton )
						{
							throw new Exception( "bMirrorSkeleton not supported" );
							//GetMirroredBoneAtoms(ChildAtoms, i, DesiredBones, Children[i].RootMotion, Children[i].bHasRootMotion);
						}
						else
						{
							var rmAsTR = (TR)Children[ i ].RootMotion;
							GetBoneAtoms(Children[i].Anim, ChildAtoms, ref rmAsTR, ref Children[i].bHasRootMotion);
							Children[ i ].RootMotion = rmAsTR;
						}


						// If this children received root motion information, accumulate its weight
						if( Children[i].bHasRootMotion != 0 )
						{
							bHasRootMotion				= 1;
							LastRootMotionChildIndex	= i;
							AccumulatedRootMotionWeight += Children[i].Weight;
						}
					}
					else
					{	
						Children[i].RootMotion		= TR.Identity;
						Children[i].bHasRootMotion	= 0;
						_bindPose.CopyTo(ChildAtoms);
					}

					for(int BoneIndex=0; BoneIndex<ChildAtoms.Length; BoneIndex++)
					{
						// We just write the first childrens atoms into the output array. Avoids zero-ing it out.
						if( bNoChildrenYet )
						{
							Atoms[BoneIndex] = ChildAtoms[BoneIndex] * Children[i].Weight;
						}
						else
						{
							var childVal = ChildAtoms[ BoneIndex ];
							// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
							if( Quaternion.Dot( Atoms[BoneIndex].Rotation, childVal.Rotation) < 0f )
							{
								childVal.Rotation = QTimesF( childVal.Rotation, - 1f );
							}

							Atoms[BoneIndex] += childVal * Children[i].Weight;
						}

						// If last child - normalize the rotation quaternion now.
						if( i == LastChildIndex )
						{
							Atoms[BoneIndex].Rotation.Normalize();
						}
					}

					bNoChildrenYet = false;
				}
			}

			// 2nd pass, iterate over all childs who received root motion
			// And blend root motion only between these childs.
			if( bHasRootMotion != 0 )
			{
				bNoChildrenYet = true;
				for(int i=0; i<=LastRootMotionChildIndex; i++)
				{
					if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH && Children[i].bHasRootMotion != 0 )
					{
						 float	Weight				= Children[i].Weight / AccumulatedRootMotionWeight;
						var	WeightedRootMotion	= (TR)(Children[i].RootMotion) * Weight;


		#if false // Debug Root Motion
						if( !WeightedRootMotion.Translation.IsZero() )
						{
							debugf(TEXT("%3.2f [%s]  Adding weighted (%3.2f) root motion trans: %3.2f, vect: %s. ChildWeight: %3.3f"), GWorld.GetTimeSeconds(), *SkelComponent.Owner.Name, Weight, WeightedRootMotion.Translation.Size(), *WeightedRootMotion.Translation.ToString(), Children[i].Weight);
						}
		#endif

						// Accumulate Root Motion
						if( bNoChildrenYet )
						{
							RootMotionDelta = WeightedRootMotion;
							bNoChildrenYet	= false;
						}
						else
						{
							// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
							if( Quaternion.Dot(((TR)RootMotionDelta).Rotation, WeightedRootMotion.Rotation) < 0f )
							{
								WeightedRootMotion.Rotation = QTimesF( WeightedRootMotion.Rotation, -1f );
							}

							RootMotionDelta += WeightedRootMotion;
						}
					}
				}

				// Normalize rotation quaternion at the end.
				RootMotionDelta = new TR{ Translation = ( (TR)RootMotionDelta ).Translation, Rotation = ( (TR)RootMotionDelta ).Rotation.normalized };
			}

		#if false // Debug Root Motion
			if( !RootMotionDelta.Translation.IsZero() )
			{
				debugf(TEXT("%3.2f [%s] Root Motion Trans: %3.2f, vect: %s"), GWorld.GetTimeSeconds(), *SkelComponent.Owner.Name, RootMotionDelta.Translation.Size(), *RootMotionDelta.Translation.ToString());
			}
		#endif
		}



		bool TryGetCurrentProfile(AnimNodeAimOffset n, out AimOffsetProfile P)
		{
			// Check profile index is not outside range.
			if(n.TemplateNode)
			{
				if(n.CurrentProfileIndex < n.TemplateNode.Profiles.Num())
				{
					P = n.TemplateNode.Profiles[n.CurrentProfileIndex];
					return true;
				}
			}
			else
			{
				if(n.CurrentProfileIndex < n.Profiles.Num())
				{
					P = n.Profiles[n.CurrentProfileIndex];
					return true;
				}
			}

			P = default;
			return false;
		}

		
		
		TR RootBoneAt( AnimSequence seq, float t )
		{
			var clip = _clips[ seq.SequenceName ];
			clip.SampleAnimation( GameObject, t );
			var root = Bones[0];
			return new TR { Translation = root.localPosition, Rotation = root.localRotation };
		}



		static Quaternion BiLerpQuat(Object.Quat P00, Object.Quat P10, Object.Quat P01, Object.Quat P11, float FracX, float FracY)
		{
			return Quaternion.Lerp( Quaternion.Lerp( (Quaternion)P00, (Quaternion)P10, FracX ), Quaternion.Lerp( (Quaternion)P01, (Quaternion)P11, FracX ), FracY );
		}
		
		static Vector3 BiLerp(Object.Vector P00, Object.Vector P10, Object.Vector P01, Object.Vector P11, float FracX, float FracY)
		{
			return Vector3.Lerp( Vector3.Lerp( P00.ToUnityDir(), P10.ToUnityDir(), FracX ), Vector3.Lerp( P01.ToUnityDir(), P11.ToUnityDir(), FracX ), FracY );
		}
		
		static float UnWindNormalizedAimAngle(float Angle)
		{
			while( Angle >= 2f )
			{
				Angle -= 4f;
			}

			while( Angle < -2f )
			{
				Angle += 4f;
			}

			return Angle;
		}
		



		static Quaternion QTimesF( Quaternion q, float f )
		{
			q.x *= f;
			q.y *= f;
			q.z *= f;
			q.w *= f;
			return q;
		}
		
		static Quaternion QPlusQ( Quaternion q, Quaternion q2 )
		{
			q.x += q2.x;
			q.y += q2.y;
			q.z += q2.z;
			q.w += q2.w;
			return q;
		}
		
		static Quaternion QMinQ( Quaternion q, Quaternion q2 )
		{
			q.x -= q2.x;
			q.y -= q2.y;
			q.z -= q2.z;
			q.w -= q2.w;
			return q;
		}
		
		static Quaternion MinQ( Quaternion q )
		{
			q.x = -q.x;
			q.y = -q.y;
			q.z = -q.z;
			return q;
		}



		class NodeNotSupportedException : Exception
		{
			public NodeNotSupportedException( AnimNode n ) : base( $"{n.GetType()} not supported" )
			{
			}
		}



		struct TR
		{
			public Quaternion Rotation;
			public Vector3 Translation;
			public static readonly TR Identity = new TR { Rotation = Quaternion.identity };
			
			public void Blend(TR Atom1, TR Atom2, float Alpha)
			{
				if( Alpha <= ZERO_ANIMWEIGHT_THRESH )
				{
					// if blend is all the way for child1, then just copy its bone atoms
					this = Atom1;
				}
				else if( Alpha >= 1f - ZERO_ANIMWEIGHT_THRESH )
				{
					// if blend is all the way for child2, then just copy its bone atoms
					this = Atom2;
				}
				else
				{
					// Simple linear interpolation for translation and scale.
					Translation = Vector3.Lerp(Atom1.Translation, Atom2.Translation, Alpha);
					//Scale		= Lerp(Atom1.Scale, Atom2.Scale, Alpha);

					// We use a linear interpolation and a re-normalize for the rotation.
					// Treating Rotation as an accumulator, initialise to a scaled version of Atom1.
					Rotation = QTimesF(Atom1.Rotation, (1f - Alpha));

					// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming rotation is positive.
					if( Quaternion.Dot(Rotation, Atom2.Rotation) < 0f )
					{
						Rotation = QMinQ(QTimesF(Atom2.Rotation, Alpha), Rotation);
					}
					else
					{
						// Then add on the second rotation..
						Rotation = QPlusQ(QTimesF(Atom2.Rotation, Alpha), Rotation);
					}

					// ..and renormalize
					Rotation.Normalize();
				}
			}



			public static implicit operator BoneAtom( TR v )
			{
				return new BoneAtom
				{
					Rotation = new Object.Quat{ X = v.Rotation.x, Y = v.Rotation.y, Z = v.Rotation.z, W = v.Rotation.w },
					Translation = new Object.Vector{ X = v.Translation.x, Y = v.Translation.y, Z = v.Translation.z },
					Scale = 1f
				};
			}
			
			public static implicit operator TR( BoneAtom v )
			{
				return new TR
				{
					Rotation = new Quaternion{ x = v.Rotation.X, y = v.Rotation.Y, z = v.Rotation.Z, w = v.Rotation.W },
					Translation = new Vector3{ x = v.Translation.X, y = v.Translation.Y, z = v.Translation.Z },
				};
			}
			
			public static TR operator *( TR v, float f )
			{
				var p = v.Translation * f;
				var r = v.Rotation;
				r.x *= f;
				r.y *= f;
				r.z *= f;
				r.w *= f;
				return new TR{ Translation = p, Rotation = r  };
			}
			
			public static TR operator +( TR a, TR b )
			{
				var p = a.Translation + b.Translation;
				var r = a.Rotation;
				r.x += b.Rotation.x;
				r.y += b.Rotation.y;
				r.z += b.Rotation.z;
				r.w += b.Rotation.w;
				return new TR{ Translation = p, Rotation = r  };
			}
		}
	}
}