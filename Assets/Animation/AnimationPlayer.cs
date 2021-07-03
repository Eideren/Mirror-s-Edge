namespace MEdge
{
	using System;
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
			Deactivate( _tree );
			SampleInner( _tree, dt );
		}
		
		

		void SampleInner( AnimNode node, float dt )
		{
			TdPawn pawnActor = _actor as TdPawn;
			node.bRelevant = true;
			
			if( node is TdAnimNodeMovementState nodeMovement && pawnActor != null )
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
			else if( node is TdAnimNodeWalkingState nodeWalking && pawnActor != null )
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

			
			
			
			switch( node )
			{
				case AnimNodeBlendList anbl:
					//BlendWeight?
					SampleInner( anbl.Children[ anbl.ActiveChildIndex ].Anim, dt );
					break;
				case TdAnimNodeWeaponPoseOffset _:
				case TdAnimNodeIKEffectorController _:
				#warning verify this stuff, why is it just passing through
				case AnimNodeSynch _:
				case TdAnimNodeSlot _:
				case TdAnimNodeLandOffset _:
				case TdAnimNodeDirBone _:
				{
					var bb = (AnimNodeBlendBase)node;
					if( bb.Children.Length > 0 )
						SampleInner( bb.Children[ 0 ].Anim, dt );
					break;
				}
				case TdAnimNodeBlendDirectional tdDirectional:
				{
					var children = tdDirectional.Children;
					
					#warning not finished
					tdDirectional.Direction.X = 0f;
					tdDirectional.Direction.Y = 1f;
					
					var dir = new UnityEngine.Vector2( tdDirectional.Direction.X, tdDirectional.Direction.Y );
					// Editor shows this specific normalization method
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
					
					BlendBetween( a, b, dir.y < 0f ? -dir.y : dir.y, dt );
					break;
				}
				case AnimNodeBlendPerBone perBone:
				{
					if( perBone.bOnlyJointsBelowParent == false )
						LogWarning( $"{nameof(perBone.bOnlyJointsBelowParent)}:False not supported" );
					
					
					var source = perBone.Children[ 0 ].Anim;
					var target = perBone.Children[ 1 ].Anim;
					float weight = perBone.Child2Weight;
					if( weight < 0.01f )
					{
						SampleInner( source, dt );
						break;
					}

					SampleInner( target, dt );
					
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

						AddHierarchyToBuffer( bone, bonesToBlend );
					}
					foreach( var transform in bonesToBlend )
						bonesTrs.Add( (transform.localPosition, transform.localRotation, transform.localScale) );
					
					SampleInner( source, dt );
					
					for( int i = 0; i < bonesToBlend.Count; i++ )
					{
						var t = bonesToBlend[ i ];
						t.localPosition = Vector3.Lerp( bonesTrs[ i ].t, t.localPosition, 1f-weight );
						t.localRotation = Quaternion.Lerp( bonesTrs[ i ].r, t.localRotation, 1f-weight );
						t.localScale = Vector3.Lerp( bonesTrs[ i ].s, t.localScale, 1f-weight );
					}
					break;
				}
				case AnimTree animTree:
				{
					//animTree.PrioritizedSkelBranches
					//animTree.RootMorphNodes
					//animTree.SkelControlLists
					if( animTree.Children.Length > 0 )
						SampleInner( animTree.Children[ 0 ].Anim, dt );
					break;
				}
				case AnimNodeBlendBase blender:
				{
					UnityEngine.Debug.LogWarning( $"Unhandled type: {node.GetType()}" );
					// Depending on the node type we should handle this differently, this branch is just a fallback
					if( blender.Children.Length > 0 )
						SampleInner( blender.Children[ 0 ].Anim, dt );
					break;
				}
				case AnimNodeSequence nodeSequence:
				{
					var cache = _caches[ node ];
					if( cache.Clip == null || cache.Clip.name != nodeSequence.AnimSeqName )
					{
						cache.Clip ??= _clips.FirstOrDefault( x => x.name == nodeSequence.AnimSeqName );
						if( cache.Clip == null )
						{
							Debug.LogWarning( $"Animation clip '{nodeSequence.AnimSeqName}' not found" );
							return;
						}
					}
					if( cache.Sequence == null || cache.Sequence.Name != nodeSequence.AnimSeqName )
					{
						cache.Sequence ??= _set.Sequences.FirstOrDefault( x => x.SequenceName == nodeSequence.AnimSeqName );
						if( cache.Sequence == null )
						{
							Debug.LogWarning( $"Animation sequence '{nodeSequence.AnimSeqName}' not found" );
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
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_ActorSpeed: speed = _actor.Velocity.Size(); break;
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_GroundSpeed: // Could be based on just the forward value
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_GroundSpeedSize:
								{
									var vel = _actor.Velocity;
									vel.Z = 0;
									speed = vel.Size();
									break;
								}
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_ZSpeed: speed = _actor.Velocity.Z; break;
								case TdAnimNodeSequence.EScalePlayRateType.SPRT_AverageActorSpeed: speed = pawnActor.GetAverageSpeed( 1f ); break;
								default: throw new ArgumentOutOfRangeException();
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
						#warning td.bResetOnBecomeRelevant
						//td.bDeltaCameraAnimation
						//td.bForceWeaponPose
						//td.AnimationType
					}
					if( nodeSequence.bPlaying )
					{
						nodeSequence.CurrentTime += dt * rate;
						if( nodeSequence.bLooping )
						{
							nodeSequence.CurrentTime %= cache.Clip.length;
							if( nodeSequence.CurrentTime < 0f )
								nodeSequence.CurrentTime = cache.Clip.length + nodeSequence.CurrentTime;
						}
					}
					cache.Clip.SampleAnimation( GameObject, nodeSequence.CurrentTime );
					break;
				}
				default: 
					UnityEngine.Debug.LogWarning( $"Unhandled type: {node.GetType()}" );
					break;
			}
		}



		void BlendBetween( AnimNode a, AnimNode b, float weight, float dt )
		{
			if( weight < 0.01f )
			{
				SampleInner( a, dt );
				return;
			}
			if( weight > 0.99f )
			{
				SampleInner( b, dt );
				return;
			} 
			
			SampleInner( a, dt );
			
			using var buff = TempBuffer<Transform>.Borrow();
			using var boneState = TempBuffer<(Vector3 t, Quaternion r, Vector3 s)>.Borrow();
			AddHierarchyToBuffer( GameObject.transform, buff );
			foreach( var transform in buff )
				boneState.Add( (transform.localPosition, transform.localRotation, transform.localScale) );
			
			SampleInner( b, dt );
			
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
	}
}