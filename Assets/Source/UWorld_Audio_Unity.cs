namespace MEdge.Engine
{
	using System;
	using System.Collections.Generic;
	using Core;
	using Source;
	using TdGame;
	using UnityEngine;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FRotator = Core.Object.Rotator;
	using FMatrix = Core.Object.Matrix;
	using UBOOL = System.Boolean;
	using FCheckResult = Source.DecFn.CheckResult;
	using DWORD = System.Int32;
	using Object = Core.Object;
	using static Source.DecFn;
	using static Core.Object;



	public partial class UWorld
	{
		static Stack<AudioSource> _sourceCache = new();
		static Stack<Mix> _mixCache = new();
		static List<Mix> _playingMixes = new();



		public void PlaySoundCue( SoundCue cue, Actor SourceActor, bool bUseLocation, Vector SourceLocation, AudioComponent associatedComp = null )
		{
			if( cue == null )
				return;
			var cleanInstance = _mixCache.TryPop( out var _t ) ? _t : new Mix();

			cleanInstance.param = ( cue, SourceActor, bUseLocation, SourceLocation );
			cleanInstance.AssociatedComp = associatedComp;
			cleanInstance.Setup();
			_playingMixes.Add(cleanInstance);

			if(associatedComp)
				return;

			int currentCount = 0;
			for( int i = _playingMixes.Count - 1; i >= 0; i-- )
			{
				var mix = _playingMixes[ i ];
				if( mix.param.cue == cue && ++currentCount > cue.MaxConcurrentPlayCount )
				{
					mix.Recycle();
				}
			}
		}
		
		
		
		void UpdateMixes(float DeltaTime)
		{
			var mixes = _playingMixes;
			for( int i = mixes.Count - 1; i >= 0; i-- )
			{
				mixes[i].Tick(DeltaTime);
			}
		}



		public class Mix
		{
			public (SoundCue cue, Actor SourceActor, bool bUseLocation, Vector SourceLocation) param;
			public AudioComponent AssociatedComp;
			List<(AudioSource audio, float vol, float pitch)> _sources = new();
			Dictionary<SoundNodeRandom, SoundNode> _selectedRandom = new();
			Dictionary<TdSoundNodeVelocity, float> _fadeTimer = new();

			static List<SoundNode> _stack = new();
			static AudioDevice _fakeAudioDevice = new();

			float _targetVolume = 1f;
			float _targetDuration = 1f;
			int _sourceIndex = 0;
			float _volumeMult = 1f;
			float _deltaTime;
			



			public void Recycle()
			{
				if( AssociatedComp )
					throw new Exception();

				_deltaTime = 0f;
				_fadeTimer.Clear();
				_selectedRandom.Clear();
				_playingMixes.Remove(this);
				foreach( var source in _sources )
				{
					source.audio.Stop();
					if( _sourceCache.Count < 248 )
						_sourceCache.Push( source.audio );
					else
						UnityEngine.Object.Destroy( source.audio.gameObject );
				}
				_sources.Clear();
				if(_mixCache.Count < 248)
					_mixCache.Push(this);
				
				_targetVolume = 1f;
				_targetDuration = 1f;
				_sourceIndex = 0;
				_volumeMult = 1f;
			}



			public void Tick(float DeltaTime)
			{
				if( AssociatedComp )
				{
					_sourceIndex = 0;
					( SoundCue cue, Actor SourceActor, bool bUseLocation, Vector SourceLocation ) = param;
					_deltaTime = DeltaTime;
					Recurse(cue.FirstNode, SourceActor, bUseLocation, SourceLocation, cue.VolumeMultiplier, cue.PitchMultiplier, 0f);
				}

				_volumeMult = _targetDuration == 0f ? _targetVolume : Mathf.MoveTowards( _volumeMult, _targetVolume, DeltaTime / _targetDuration );
				foreach( var source in _sources )
					source.audio.volume = _volumeMult * source.vol;

				if( AssociatedComp == null )
				{
					// See if finished
					foreach( var source in _sources )
					{
						if( source.audio.isPlaying )
							return;
					}
					Recycle();
				}
			}



			public void Setup()
			{
				( SoundCue cue, Actor SourceActor, bool bUseLocation, Vector SourceLocation ) = param;
				Recurse(cue.FirstNode, SourceActor, bUseLocation, SourceLocation, cue.VolumeMultiplier, cue.PitchMultiplier, 0f);
				if( AssociatedComp )
				{
					AssociatedComp._Play += () =>
					{
						foreach( var source in _sources )
						{
							source.audio.Stop();
							if( _sourceCache.Count < 248 )
								_sourceCache.Push( source.audio );
							else
								UnityEngine.Object.Destroy( source.audio.gameObject );
						}
						_sources.Clear();
						Recurse(cue.FirstNode, SourceActor, bUseLocation, SourceLocation, cue.VolumeMultiplier, cue.PitchMultiplier, 0f);
					};
					AssociatedComp._Stop += () =>
					{
						foreach( var source in _sources )
						{
							source.audio.Stop();
						}
					};
					AssociatedComp._AdjustVolume += ( AdjustVolumeDuration, AdjustVolumeLevel ) =>
					{
						_targetVolume = AdjustVolumeLevel;
						_targetDuration = AdjustVolumeDuration;
					};
					AssociatedComp._FadeIn += (FadeInDuration, FadeVolumeLevel) =>
					{
						foreach( var source in _sources )
						{
							source.audio.Stop();
							if( _sourceCache.Count < 248 )
								_sourceCache.Push( source.audio );
							else
								UnityEngine.Object.Destroy( source.audio.gameObject );
						}
						_sources.Clear();
						Recurse(cue.FirstNode, SourceActor, bUseLocation, SourceLocation, cue.VolumeMultiplier, cue.PitchMultiplier, 0f);
						
						_targetVolume = FadeVolumeLevel;
						_targetDuration = FadeInDuration;
					};
					AssociatedComp._FadeOut += (FadeOutDuration, FadeVolumeLevel) =>
					{
						_targetVolume = FadeVolumeLevel;
						_targetDuration = FadeOutDuration;
					};
				}
			}



			unsafe void Recurse(SoundNode node, Actor SourceActor, bool bUseLocation, Vector SourceLocation, float volume, float pitch, float delay)
			{
				if( node is SoundNodeWave snw )
				{
					AudioSource unity;
					
					if( _sources.Count > _sourceIndex )
					{
						// Reuse existing source
						unity = _sources[0].audio;
						_sources.RemoveAt(0);
						_sourceIndex++;
					}
					else if( _sourceCache.TryPop( out unity ) == false )
					{
						unity = new GameObject().AddComponent<AudioSource>();
						unity.playOnAwake = false;
					}
					try
					{
						unity.gameObject.name = node.Name;
						unity.clip = Asset.GetClip( snw.Name ) ?? throw new NullReferenceException();
						
						unity.loop = false;
						unity.spatialBlend = 0f;
						unity.rolloffMode = AudioRolloffMode.Logarithmic;
						TdSoundNodeRelativePosition relPos = null;
						foreach( SoundNode soundNode in _stack )
						{
							if( soundNode is SoundNodeAttenuation sna )
							{
								if(sna.DistanceModel == SoundNodeAttenuation.SoundDistanceModel.ATTENUATION_Linear)
									unity.rolloffMode = AudioRolloffMode.Linear;
								// We ignore sna.bAttenuate here as unity doesn't have a similar concept
								// And I don't think it makes a lot of sense, why would a spatialized noise' volume not be affected by distance ?
								unity.spatialBlend = sna.bSpatialize ? 1f : 0f;
							}
							else if( soundNode is TdSoundNodeRelativePosition rPos )
								relPos = rPos;
							else if( soundNode is SoundNodeLooping )
								unity.loop = true;
						}

						Actor actorParent;
						Vector Location;
						if( AssociatedComp )
						{
							if(AssociatedComp.bUseOwnerLocation == false)
								throw new Exception(); // Not sure what to do here
							
							actorParent = SourceActor;
							Location = SourceActor.Location;
						}
						else if( relPos )
						{
							var pawn = (TdPlayerPawn)SourceActor;
							Location = default;
							if( relPos.bRelativeToCamera )
							{
								// Not sure that's how it works
								pawn.Rotation.Quaternion().RotateVector(&Location, relPos.RelativePos);
								Location += pawn.PlayerCameraLocation;
							}
							else
							{
								pawn.Rotation.Quaternion().RotateVector(&Location, relPos.RelativePos);
								Location += pawn.Location;
							}

							actorParent = SourceActor;
						}
						else
						{
							bool bUseOwnerLocation;
							if( SourceActor )
							{
								bUseOwnerLocation = !bUseLocation;
								Location = SourceLocation;
							}
							else
							{
								bUseOwnerLocation = FALSE;
								if (bUseLocation)
								{
									Location = SourceLocation;
								}
								else if (SourceActor != NULL)
								{
									Location = SourceActor.Location;
								}
								else
								{
									throw new Exception();
								}
							}
							
							if(bUseOwnerLocation)
							{
								actorParent = SourceActor;
							}
							else
							{
								actorParent = null;
							}
						}

						Transform tParent;
						if( actorParent != null )
						{
							UnityEngine.Object gObject;
							if( actorParent is TdPlayerPawn tdpawn )
							{
								Asset.UScriptToUnity.TryGetValue( tdpawn.Mesh1p.SkeletalMesh, out gObject );
								tParent = ((UnityEngine.Component)gObject).transform;
							}
							else
							{
								Asset.UScriptToUnity.TryGetValue( actorParent, out gObject );
								tParent = ((UnityEngine.GameObject)gObject).transform;
							}
						}
						else
						{
							tParent = null;
						}

						unity.transform.parent = tParent;
						unity.transform.position = Location.ToUnityPos();

						unity.volume = volume * snw.Volume;
						unity.pitch = pitch * snw.Pitch;

						if( unity.isPlaying == false && (AssociatedComp == null || AssociatedComp.bAutoDestroy) )
						{
							if(delay>0f)
								unity.PlayDelayed(delay);
							else
								unity.Play();
						}
						
						_sources.Add( (unity, unity.volume, unity.pitch) );
					}
					catch(Exception e)
					{
						_sourceCache.Push(unity);
						throw e;
					}
				}
				else if( node is SoundNodeDelay delayN )
				{
					delay += delayN.DelayDuration.Distribution.GetValue(0f, null);
				}
				else if( node is SoundNodeModulator mod )
				{
					pitch *= mod.PitchModulation.Distribution.GetValue(0f, null);
					volume *= mod.VolumeModulation.Distribution.GetValue(0f, null);
				}
				else if( node is TdSoundNodeMixGroup mxGrp )
				{
					if(mxGrp.MixGroups.Length != 1)
						throw new Exception();

					foreach( var mixGroupInfo in _fakeAudioDevice.MixGroups )
					{
						if( mixGroupInfo.GroupName == mxGrp.MixGroups[ 0 ] )
						{
							if( mxGrp.bModulatePitch )
								pitch *= mixGroupInfo.Pitch;
							if( mxGrp.bModulateVolume )
								volume *= mixGroupInfo.Volume;
							goto VALID;
						}
					}

					throw new Exception();
					
					VALID:{}
				}
				else if( node is TdSoundNodeVelocity vel )
				{
					float speedVal;
					switch( vel.TypeOfSpeed )
					{
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Source: 
							speedVal = SourceActor.Velocity.Size();
							break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Listener:
							if( SourceActor is TdPlayerPawn == false ) throw new Exception( "cannot handle non player character as listeners source for velocity" );
							speedVal = SourceActor.Velocity.Size();
							break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Relative:
							NativeMarkers.MarkUnimplemented();
							goto SKIP;
						/*case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Listener: break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Relative: break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Custom: break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_MAX: break;*/
						default: 
							NativeMarkers.MarkUnimplemented($"{vel.TypeOfSpeed.ToString()} not implemented");
							speedVal = vel.MinSpeed;
							break;
					}

					float speedAsUnit = (speedVal - vel.MinSpeed) / (vel.MaxSpeed - vel.MinSpeed);
					speedAsUnit = FClamp( speedAsUnit, 0f, 1f );

					#warning not sure that's how it works but it's good enough for now, I'll investigate later
					if( AssociatedComp )
					{
						_fadeTimer.TryAdd( vel, 0f );
						var currentT = _fadeTimer[vel];

						_fadeTimer[ vel ] = speedAsUnit = Mathf.MoveTowards( currentT, speedAsUnit, (currentT > speedAsUnit ? vel.FadeOutTimeFilter : vel.FadeInTimeFilter) * _deltaTime );
					}

					if(vel.bModulateVolume)
						volume *= Lerp( vel.VolumeAtMinSpeed, vel.VolumeAtMaxSpeed, speedAsUnit );
					if(vel.bModulatePitch)
						pitch *= Lerp( vel.PitchAtMinSpeed, vel.PitchAtMaxSpeed, speedAsUnit );
					NativeMarkers.MarkUnimplemented("Fade*TimeFilter and interpolation");
					SKIP:{}
				}
				else if( node is SoundNodeRandom rand )
				{
					if( _selectedRandom.TryGetValue( rand, out var selected ) )
					{
						Recurse(selected, SourceActor, bUseLocation, SourceLocation, volume, pitch, delay);
						return;
					}

					if( rand.Weights.Length != rand.HasBeenUsed.Length )
						rand.HasBeenUsed.Length = rand.Weights.Length;
					
					// reset
					if( rand.bRandomizeWithoutReplacement && rand.NumRandomUsed >= rand.HasBeenUsed.Length )
					{
						rand.NumRandomUsed = 0;
						for( int i = 0; i < rand.HasBeenUsed.Length; i++ )
							rand.HasBeenUsed[i] = false;
					}

					float weightTotal = 0;
					for( INT i=0; i<rand.Weights.Num(); i++ )
					{
						if( rand.bRandomizeWithoutReplacement == false ) 
						{
							weightTotal += rand.Weights[i];
						}
						else if( rand.HasBeenUsed[i] != true )
						{
							weightTotal += rand.Weights[i];
						}
					}

					float weight = appFrand() * weightTotal;
					int nodeIndex = 0;
					for( INT i=0; i<rand.ChildNodes.Num() && i<rand.Weights.Num(); i++ )
					{
						if( rand.bRandomizeWithoutReplacement && rand.HasBeenUsed[ i ] )
							continue;

						if( rand.Weights[ i ] >= weight )
						{
							if( rand.bRandomizeWithoutReplacement )
							{
								rand.HasBeenUsed[i] = true;
								rand.NumRandomUsed++;
							}	

							nodeIndex = i;
							break;
						}
						
						weight -= rand.Weights[ i ];
					}
					
					
					if( nodeIndex < rand.ChildNodes.Num() && rand.ChildNodes[nodeIndex] )
					{
						if( AssociatedComp )
						{
							_selectedRandom[rand] = rand.ChildNodes[nodeIndex];
							// Would just need to figure when the random is rerolled,
							// probably whenever the playing clip in this branch has finished playing
							Debug.LogWarning($"Random with {nameof(AssociatedComp)} not implemented");
						}

						Recurse(rand.ChildNodes[nodeIndex], SourceActor, bUseLocation, SourceLocation, volume, pitch, delay);
					}
					
					return;
				}
				else if( node is SoundNodeMixer mixer )
				{
					for( int i = 0; i < mixer.ChildNodes.Length; i++ )
					{
						Recurse(mixer.ChildNodes[ i ], SourceActor, bUseLocation, SourceLocation, volume*mixer.InputVolume[i], pitch, delay);
					}

					return;
				}
				else if( node is SoundNodeLooping or SoundNodeAttenuation or TdSoundNodeRelativePosition )
				{
					// Taken care of inside the SoundNodeWave if
				}
				else if( node is null )
				{
					// Should be reported through missing asset load stuff
					return;
				}
				else
				{
					NativeMarkers.MarkUnimplemented(node.GetType().ToString());
				}

				_stack.Add(node);
				try
				{
					foreach( var childNode in node.ChildNodes )
					{
						Recurse(childNode, SourceActor, bUseLocation, SourceLocation, volume, pitch, delay);
					}
				}
				finally
				{
					_stack.RemoveAt(_stack.Count - 1);
				}
			}
		}
	}
}