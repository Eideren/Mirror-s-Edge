namespace MEdge
{
	using System.Collections.Generic;
	using System.Linq;
	using Engine;
	using TdGame;
	using UnityEngine;
	using static UnityEngine.Debug;



	public class AnimationPlayer
	{
		public GameObject GameObject;
		AnimNode _tree;
		WeakCache<AnimNode, Cache> _caches = new WeakCache<AnimNode, Cache>();
		AnimationClip[] _clips;
		AnimSet _set;
		Actor _actor;
		HashSet<AnimNode> _previousRelevant = new HashSet<AnimNode>();


		class Cache
		{
			public AnimationClip Clip;
			public AnimSequence Sequence;
		}
		
		
		public AnimationPlayer(AnimationClip[] clips, AnimSet animSet, AnimNode tree, GameObject gameObject, Actor actor)
		{
			_tree = tree;
			_clips = clips;
			_set = animSet;
			GameObject = gameObject;
			_actor = actor;
		}



		public void Sample( float dt )
		{
			foreach( AnimNode node in _previousRelevant )
				node.bRelevant = false;
			
			SampleInner( _tree, dt, 1f );

			using var toRemove = TempBuffer<object>.Borrow();
			foreach( AnimNode node in _previousRelevant )
			{
				if( node.bRelevant == false )
				{
					toRemove.Add( node );
					node.OnCeaseRelevant();
				}
			}

			foreach( AnimNode nodeToRemove in toRemove )
				_previousRelevant.Remove( nodeToRemove );
		}
		
		
		
		bool NodeIs<T>( AnimNode n, out T val, ref bool mark )
		{
			if( n is T v )
			{
				mark = mark || n.GetType() == typeof(T);
				val = v;
				return true;
			}

			val = default;
			return false;
		}



		void SampleInner( AnimNode node, float dt, float weightHint )
		{
			bool marked = false;
			node.NodeTotalWeight = weightHint; // Not too sure that's how it works 
			try
			{
				if( _caches.TryGetValue( node, out var cache ) == false )
				{
					node.OnInit();
					cache = _caches[ node ];
				}

				node.bRelevant = true;
				if( _previousRelevant.Contains( node ) == false )
				{
					_previousRelevant.Add( node );
					node.OnBecomeRelevant();
					node.bJustBecameRelevant = true;
				}
				else
				{
					node.bJustBecameRelevant = false;
				}

				TdPawn pawnActor = _actor as TdPawn;

				if( NodeIs<TdAnimNodeMovementState>( node, out var nodeMovement, ref marked ) && pawnActor != null )
				{
					var state = pawnActor.MovementState;
					nodeMovement.ActiveChildIndex = 0; // 0 is the default branch
					for( int i = 0; i < nodeMovement.EnumStates.Length; i++ )
					{
						if( nodeMovement.EnumStates[ i ] == state )
						{
							nodeMovement.ActiveChildIndex = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}
				}
				else if( NodeIs<TdAnimNodeWalkingState>( node, out var nodeWalking, ref marked ) && pawnActor != null )
				{
					var state = pawnActor.CurrentWalkingState;
					nodeWalking.ActiveChildIndex = 0; // 0 is the default branch
					for( int i = 0; i < nodeWalking.EnumStates.Length; i++ )
					{
						if( nodeWalking.EnumStates[ i ] == state )
						{
							nodeWalking.ActiveChildIndex = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}
				}

				if( NodeIs<TdAnimNodeCinematicSwitch>( node, out var cinematicSwitch, ref marked ) )
				{
					// I don't care
					cinematicSwitch.ActiveChildIndex = 1;
				}

				if( NodeIs<TdAnimNodeBlendBySpeed>( node, out var tdBySpeed, ref marked ) )
				{
					tdBySpeed.Speed = tdBySpeed.bUseAverageSpeed ? pawnActor.AverageSpeed : 
						tdBySpeed.bUseAcceleration ? _actor.Acceleration.Size() : _actor.Velocity.Size();
				}

				if( NodeIs<AnimNodeBlendBySpeed>( node, out var bySpeed, ref marked ) )
				{
					if( bySpeed.BlendUpTime != 0f || bySpeed.BlendDownTime != 0f )
						LogWarning( $"{nameof(SampleInner)}: Blend up and down time not implemented" );

					if(node.GetType() == typeof(AnimNodeBlendBySpeed))
						bySpeed.Speed = bySpeed.bUseAcceleration ? _actor.Acceleration.Size() : _actor.Velocity.Size();
					bySpeed.ActiveChildIndex = 0;
					for( int i = 0; i < bySpeed.Constraints.Length; i++ )
					{
						if( bySpeed.Speed < bySpeed.Constraints[ i ] )
							bySpeed.ActiveChildIndex = i-1;
					}
				}

				if( NodeIs<TdAnimNodeBlendDirectional>( node, out var tdDirectional, ref marked ) )
				{
					var children = tdDirectional.Children;
						
					#warning not finished
					tdDirectional.Direction.X = 0f;
					tdDirectional.Direction.Y = 1f;
						
					var dir = new UnityEngine.Vector2( tdDirectional.Direction.X, tdDirectional.Direction.Y );
					// Editor shows this specific 'normalization' method
					var l = dir.x + dir.y;
					dir /= l == 0f ? 1f : l;

					AnimNode a, b;
					if( dir.y >= 0f )
					{
						a = children[ 0 ].Anim;
						b = dir.x >= 0f ? children[ 1 ].Anim : children[ 2 ].Anim;
					}
					else
					{
						a = children[ 3 ].Anim;
						b = dir.x >= 0f ? children[ 4 ].Anim : children[ 5 ].Anim;
					}
						
					BlendBetween( a, b, node.NodeTotalWeight, dir.y < 0f ? -dir.y : dir.y, dt );
					return;
				}

				if( NodeIs<AnimNodeSequence>( node, out var nodeSequence, ref marked ) )
				{
					if( cache.Clip == null || cache.Clip.name != nodeSequence.AnimSeqName )
					{
						cache.Clip ??= _clips.FirstOrDefault( x => x.name == nodeSequence.AnimSeqName );
						if( cache.Clip == null )
						{
							LogWarning( $"Animation clip '{nodeSequence.AnimSeqName}' not found" );
							return;
						}
					}
					if( cache.Sequence == null || cache.Sequence.Name != nodeSequence.AnimSeqName )
					{
						cache.Sequence ??= _set.Sequences.FirstOrDefault( x => x.SequenceName == nodeSequence.AnimSeqName );
						nodeSequence.AnimSeq = cache.Sequence;
						if( cache.Sequence == null )
						{
							LogWarning( $"Animation sequence '{nodeSequence.AnimSeqName}' not found" );
							return;
						}
					}

					cache.Clip.wrapMode = nodeSequence.bLooping ? WrapMode.Loop : WrapMode.Clamp;	
					
					
					//sequence.notifyweightthreshold

					float rate = nodeSequence.Rate;
					if( nodeSequence is TdAnimNodeSequence td )
					{
						if( td.ScalePlayRateBySpeed )
						{
							float speed;
							// Not confirmed
							switch( td.ScalePlayRateType )
							{
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_GroundSpeed: // Could be based on just the forward value
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_GroundSpeedSize:
								{
									var vel = _actor.Velocity;
									vel.Z = 0;
									speed = vel.Size();
									break;
								}
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_ActorSpeed: speed = _actor.Velocity.Size(); break;
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_ZSpeed: speed = _actor.Velocity.Z; break;
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_AverageActorSpeed: speed = pawnActor.GetAverageSpeed( 1f ); break;
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_MAX:
								default: throw new System.ArgumentOutOfRangeException();
							}

							speed = (speed - td.BaseSpeed) * td.ScaleByValue;
							speed = speed < td.RateMin ? td.RateMin : speed;
							speed = speed > td.RateMax ? td.RateMax : speed;
							// tooltip: fast rate on low speed
							//td.InversePlayRate ? (1f / speed) : speed; ??? Probably not
							rate *= speed;
						}
					
						//td.snaptokeyframes
						//td.bForceFullplayback
						//td.bLoopingwithnotify
						//td.bDeltaCameraAnimation
						//td.bForceWeaponPose
						//td.AnimationType
					}

					nodeSequence.PreviousTime = nodeSequence.CurrentTime;
					var timeOffset = nodeSequence.bPlaying ? dt * rate : 0f;
					if( timeOffset != 0f )
					{
						nodeSequence.CurrentTime += timeOffset;
						if( nodeSequence.bLooping )
						{
							nodeSequence.CurrentTime %= cache.Clip.length;
							if( nodeSequence.CurrentTime < 0f )
								nodeSequence.CurrentTime = cache.Clip.length + nodeSequence.CurrentTime;
						}
						else if( nodeSequence.CurrentTime > cache.Clip.length )
						{
							nodeSequence.CurrentTime = cache.Clip.length;
						}

						if( nodeSequence.NodeTotalWeight >= nodeSequence.NotifyWeightThreshold )
						{
							RunNotify( _actor, nodeSequence, timeOffset );
						}
					}

					
					cache.Clip.SampleAnimation( GameObject, nodeSequence.CurrentTime );
					return;
				}
				
				if( NodeIs<AnimNodeBlendPerBone>( node, out var perBone, ref marked ) )
				{
					var source = perBone.Children[ 0 ].Anim;
					var target = perBone.Children[ 1 ].Anim;
					float weight = perBone.Child2Weight;
					if( weight < 0.01f )
					{
						SampleInner( source, dt, node.NodeTotalWeight * 1f );
						return;
					}

					SampleInner( target, dt, node.NodeTotalWeight * (1f-weight) );
						
					using var bonesTrs = TempBuffer<(Vector3 t, Quaternion r, Vector3 s)>.Borrow();
					using var bonesToBlend = TempBuffer<Transform>.Borrow();
					foreach( var branchName in perBone.BranchStartBoneName )
					{
						var bone = FindInHierarchy( GameObject.transform, branchName );
						if( bone == null )
						{
							LogWarning( $"Could not find bone '{branchName}'" );
							continue;
						}

						if( perBone.bOnlyJointsBelowParent )
						{
							for( int i = 0; i < bone.childCount; i++ )
								AddHierarchyToBuffer( bone.GetChild(i), bonesToBlend );
						}
						else
						{
							AddHierarchyToBuffer( bone, bonesToBlend );
						}
					}
					foreach( var transform in bonesToBlend )
						bonesTrs.Add( (transform.localPosition, transform.localRotation, transform.localScale) );
						
					SampleInner( source, dt, node.NodeTotalWeight );
						
					for( int i = 0; i < bonesToBlend.Count; i++ )
					{
						var t = bonesToBlend[ i ];
						t.localPosition = Vector3.Lerp( bonesTrs[ i ].t, t.localPosition, 1f-weight );
						t.localRotation = Quaternion.Lerp( bonesTrs[ i ].r, t.localRotation, 1f-weight );
						t.localScale = Vector3.Lerp( bonesTrs[ i ].s, t.localScale, 1f-weight );
					}
					return;
				}

				if( NodeIs<AnimNodeBlendList>( node, out var anbl, ref marked ) )
				{
					SampleInner( anbl.Children[ anbl.ActiveChildIndex ].Anim, dt, node.NodeTotalWeight );
					return;
				}

				if( NodeIs<AnimTree>( node, out var animTree, ref marked ) )
				{
					//animTree.PrioritizedSkelBranches
					//animTree.RootMorphNodes
					//animTree.SkelControlLists
					if( animTree.Children.Length > 0 )
						SampleInner( animTree.Children[ 0 ].Anim, dt, node.NodeTotalWeight );
					return;
				}

				if( NodeIs<AnimNodeBlendBase>( node, out var blender, ref marked ) )
				{
					// Depending on the node type we should handle this differently, this branch is just a fallback
					if( blender.Children.Length > 0 )
						SampleInner( blender.Children[ 0 ].Anim, dt, node.NodeTotalWeight );
					return;
				}
			}
			finally
			{
				if(marked == false)
					LogWarning( $"Unhandled type: {node.GetType()}" );
			}
		}



		void BlendBetween( AnimNode a, AnimNode b, float thisNodeWeight, float weight, float dt )
		{
			if( weight < 0.01f )
			{
				SampleInner( a, dt, thisNodeWeight );
				return;
			}
			if( weight > 0.99f )
			{
				SampleInner( b, dt, thisNodeWeight );
				return;
			} 
			
			SampleInner( a, dt, thisNodeWeight * weight );
			
			using var buff = TempBuffer<Transform>.Borrow();
			using var boneState = TempBuffer<(Vector3 t, Quaternion r, Vector3 s)>.Borrow();
			AddHierarchyToBuffer( GameObject.transform, buff );
			foreach( var transform in buff )
				boneState.Add( (transform.localPosition, transform.localRotation, transform.localScale) );
			
			SampleInner( b, dt, thisNodeWeight * (1f-weight) );
			
			for( int i = 0; i < buff.Count; i++ )
			{
				var t = buff[ i ];
				t.localPosition = Vector3.Lerp( boneState[ i ].t, t.localPosition, weight );
				t.localRotation = Quaternion.Lerp( boneState[ i ].r, t.localRotation, weight );
				t.localScale = Vector3.Lerp( boneState[ i ].s, t.localScale, weight );
			}
		}


		static void Deactivate(AnimNode n)
		{
			if(n.bRelevant == false)
				return;

			n.bRelevant = false;
			if( n is AnimNodeBlendBase bb )
			{
				foreach( var child in bb.Children )
				{
					if(child.Anim != null)
						Deactivate( child.Anim );
				}
			}
		}



		static Transform FindInHierarchy( Transform trs, MEdge.Core.name trsName )
		{
			if( trs.name == trsName )
				return trs;
			for( int i = 0; i < trs.childCount; i++ )
			{
				var child = trs.GetChild( i );
				var t = FindInHierarchy( child, trsName );
				if( t != null )
					return t;
			}

			return null;
		}



		static void AddHierarchyToBuffer( Transform trs, TempBuffer<Transform> tList )
		{
			tList.Add( trs ?? throw new System.NullReferenceException() );
			for( int i = tList.Count - 1; i < tList.Count; i++ )
			{
				var childTransform = tList[ i ];
				for( int j = 0; j < childTransform.childCount; j++ )
				{
					var child = childTransform.GetChild( j );
					tList.Add( child );
				}
			}
		}



		static void RunNotify(Actor actor, AnimNodeSequence nodeSequence, float timeOffset)
		{
			Vector4 ranges = Vector4.zero;
			int timeSlices;
			if( timeOffset > 0f && nodeSequence.CurrentTime < nodeSequence.PreviousTime )
			{
				// Looped around, execute from 
				ranges[ 0 ] = nodeSequence.PreviousTime;
				ranges[ 1 ] = nodeSequence.AnimSeq.SequenceLength;
				ranges[ 2 ] = 0f;
				ranges[ 3 ] = nodeSequence.CurrentTime;
				timeSlices = 2;
			}
			else if( timeOffset < 0f && nodeSequence.CurrentTime > nodeSequence.PreviousTime )
			{
				// Looped around backwards, execute from
				ranges[ 0 ] = 0f;
				ranges[ 1 ] = nodeSequence.PreviousTime;
				ranges[ 2 ] = nodeSequence.CurrentTime;
				ranges[ 3 ] = nodeSequence.AnimSeq.SequenceLength;
				timeSlices = 2;
			}
			else
			{
				ranges[ 0 ] = nodeSequence.PreviousTime;
				ranges[ 1 ] = nodeSequence.CurrentTime;
				timeSlices = 1;
			}

			for( int i = 0; i < timeSlices; i++ )
			{
				var timeMin = ranges[i*2+0];
				var timeMax = ranges[i*2+1];

				bool inverted = timeOffset < 0f;
				var notifiesCount = nodeSequence.AnimSeq.Notifies.Length;
				for( int j = 0; j < notifiesCount; j++ )
				{
					var notifyEvent = inverted ? nodeSequence.AnimSeq.Notifies[ notifiesCount - 1 - j ] : nodeSequence.AnimSeq.Notifies[ j ];
					if( notifyEvent.Time > timeMin && notifyEvent.Time <= timeMax )
					{
						if( notifyEvent.Notify is AnimNotify_Scripted scriptedNotify )
						{
							scriptedNotify.Notify( actor, nodeSequence );
						}
						else
						{
							LogWarning( $"Notify '{notifyEvent.Notify.GetType()}' not implemented" );
						}
					}
				}
			}
		}
	}
}