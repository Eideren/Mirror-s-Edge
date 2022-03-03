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



		public void PlaySoundCue( SoundCue cue, Actor SourceActor, bool bUseLocation, Vector SourceLocation )
		{
			if( _mixCache.TryPop( out var cleanInstance ) == false )
			{
				cleanInstance = new Mix();
			}

			cleanInstance.param = ( cue, SourceActor, bUseLocation, SourceLocation );
			_playingMixes.Add(cleanInstance);
			
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
		
		
		
		void UpdateMixes()
		{
			var mixes = _playingMixes;
			for( int i = mixes.Count - 1; i >= 0; i-- )
			{
				mixes[i].Tick();
			}
		}



		public class Mix
		{
			public (SoundCue cue, Actor SourceActor, bool bUseLocation, Vector SourceLocation) param;
			Dictionary<SoundNodeWave, AudioSource> _waveToSource = new();
			Dictionary<SoundNodeRandom, int> _randChoice = new();
			bool _initialRun = true;
			bool _playing;

			static List<SoundNode> _stack = new ();
			static AudioDevice _fakeAudioDevice = new();



			public void Recycle()
			{
				_initialRun = true;
				_playingMixes.Remove(this);
				foreach( var (_, source) in _waveToSource )
				{
					source.Stop();
					if( _sourceCache.Count < 248 )
						_sourceCache.Push( source );
					else
						UnityEngine.Object.Destroy( source.gameObject );
				}
				_waveToSource.Clear();
				_randChoice.Clear();
				if(_mixCache.Count < 248)
					_mixCache.Push(this);
			}



			public void Tick()
			{
				try
				{
					_playing = false;
					if( _initialRun )
					{
						Recurse(param.cue.FirstNode, param.SourceActor, param.bUseLocation, param.SourceLocation, param.cue.VolumeMultiplier, param.cue.PitchMultiplier, false);
					}
					else
					{
						foreach( var (_, source) in _waveToSource )
						{
							if( source.isPlaying )
							{
								_playing = true;
								break;
							}
						}
					}
				}
				finally
				{
					_initialRun = false;
					if(_playing == false)
						Recycle();
				}
			}
			
			

			void Recurse(SoundNode node, Actor SourceActor, bool bUseLocation, Vector SourceLocation, float volume, float pitch, bool loop)
			{
				if( node is SoundNodeWave snw )
				{
					AudioSource unity;
					if( _initialRun )
					{
						if( Asset.Clips.TryGetValue( snw.Name, out var clip ) == false 
						    && snw.Name.ToString().LastIndexOf('.') is int i && i != -1 )
						{
							// snw.Name is a long name, includes package and such, get short part
							var shortName = snw.Name.ToString().Substring( i+1 );
							if( Asset.Clips.TryGetValue( shortName, out clip ) )
							{
								// Add it in as a duplicate under its full name
								Asset.Clips.Add(snw.Name, clip);
							}
						}

						clip = clip ?? throw new NullReferenceException();

						if( _sourceCache.TryPop( out unity ) == false )
						{
							unity = new GameObject("PooledAudioSource").AddComponent<AudioSource>();
							unity.playOnAwake = false;
						}

						unity.clip = clip;
						unity.Play();
						unity.spatialBlend = 0f;
						foreach( SoundNode soundNode in _stack )
						{
							if( soundNode is SoundNodeAttenuation sna )
							{
								if(sna.bSpatialize != sna.bAttenuate)
									UnityEngine.Debug.LogWarning( $"{sna.bSpatialize} {sna.bAttenuate} {unity.clip}" );
								unity.spatialBlend = sna.bAttenuate && sna.bSpatialize ? 1f : 0f;
							}
						}
						_waveToSource.Add( snw, unity );
						unity.transform.parent = ! bUseLocation && Asset.UScriptToUnity.TryGetValue( SourceActor, out var gObject ) ? ( gObject as GameObject ).transform : null;
						unity.transform.localPosition = SourceLocation.ToUnityPos();
						_playing = true;
					}
					else
					{
						unity = _waveToSource[ snw ];
						_playing = _playing || unity.isPlaying;
					}

					unity.volume = volume * snw.Volume;
					unity.pitch = pitch * snw.Pitch;
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
						/*case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Listener: break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Relative: break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_Custom: break;
						case TdSoundNodeVelocity.SpeedType.SPEEDTYPE_MAX: break;*/
						default: throw new NotImplementedException();
					}

					float speedAsUnit = (speedVal - vel.MinSpeed) / (vel.MaxSpeed - vel.MinSpeed);
					speedAsUnit = FClamp( speedAsUnit, 0f, 1f );

					if(vel.bModulateVolume)
						volume *= Lerp( vel.VolumeAtMinSpeed, vel.VolumeAtMaxSpeed, speedAsUnit );
					if(vel.bModulatePitch)
						pitch *= Lerp( vel.PitchAtMinSpeed, vel.PitchAtMaxSpeed, speedAsUnit );
					NativeMarkers.MarkUnimplemented("Fade*TimeFilter and interpolation");
				}
				else if( node is SoundNodeRandom rand )
				{
					// First run ?
					if( _randChoice.TryGetValue( rand, out var nodeIndex ) == false )
					{
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
						
						_randChoice.Add(rand, nodeIndex);
					}
					
					if( nodeIndex < rand.ChildNodes.Num() && rand.ChildNodes[nodeIndex] )
					{
						Recurse(rand.ChildNodes[nodeIndex], SourceActor, bUseLocation, SourceLocation, volume, pitch, false);
					}
					
					return;
				}
				else if( node is SoundNodeMixer mixer )
				{
					for( int i = 0; i < mixer.ChildNodes.Length; i++ )
					{
						var childNode = mixer.ChildNodes[ i ];
						if(childNode != null)
							Recurse(childNode, SourceActor, bUseLocation, SourceLocation, volume*mixer.InputVolume[i], pitch, false);
					}

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
						if(childNode != null)
							Recurse(childNode, SourceActor, bUseLocation, SourceLocation, volume, pitch, node is SoundNodeLooping);
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