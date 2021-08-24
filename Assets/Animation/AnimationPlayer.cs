// STILL HAVE TO HOOK UP PARENT NODES 

namespace MEdge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Engine;
	using TdGame;
	using UnityEngine;
	using static UnityEngine.Mathf;
	using static UnityEngine.Debug;



	public class AnimationPlayer
	{
		const float ZERO_ANIMWEIGHT_THRESH = 0.00001f;
		
		public GameObject GameObject;
		public SkeletalMeshComponent Skel{ get; private set; }
		AnimNode _tree;
		AnimSet _set;
		Actor _actor;
		
		int _tick;
		HashSet<AnimNode> _nodes = new HashSet<AnimNode>();
		Dictionary<MEdge.Core.name, AnimationClip> _clips;
		Dictionary<AnimNode, TempBuffer<TRS>> _relevantNodes = new Dictionary<AnimNode,TempBuffer<TRS>>();

		public Transform[] Bones{ get; private set; }
		public Dictionary<name, int> BoneNameToIndex{ get; private set; }
		TRS[] _bindPose;



		public AnimationPlayer(AnimationClip[] clips, AnimSet animSet, AnimNode tree, GameObject gameObject, Actor actor, SkeletalMeshComponent skel)
		{
			Skel = skel;
			_tree = tree;
			_clips = clips.ToDictionary( x => (MEdge.Core.name)x.name );
			_set = animSet;
			GameObject = gameObject;
			_actor = actor;
			Bones = new Transform[ animSet.TrackBoneNames.Length ];
			_bindPose = new TRS[ animSet.TrackBoneNames.Length ];
			BoneNameToIndex = new Dictionary<name, int>( Bones.Length );
			var allTransforms = GameObject.GetComponentsInChildren<Transform>().ToDictionary( x => (name)x.name );
			for( int i = 0; i < animSet.TrackBoneNames.Length; i++ )
			{
				var t = allTransforms[ animSet.TrackBoneNames[ i ] ];
				Bones[ i ] = t;
				_bindPose[ i ] = new TRS( t, true );
				BoneNameToIndex.Add( (name)t.name, i );
			}

			foreach( var node in EnumerateTree( _tree ) )
			{
				_nodes.Add( node );
				node.ParentNodes.Remove(0, node.ParentNodes.Count);
			}

			foreach( var node in _nodes )
			{
				if( node is AnimNodeBlendBase anbb )
				{
					foreach( var child in anbb.Children )
					{
						child.Anim?.ParentNodes.Add( anbb );
					}
				}

				node.SkelComponent = Skel;
				if( node is TdAnimNodeBlendList anbl )
					anbl.TdPawnOwner = _actor as TdPawn;
				node.OnInit();
			}



			static IEnumerable<AnimNode> EnumerateTree( AnimNode n )
			{
				if( n == null )
					yield break;
			
				yield return n;
				if( n is AnimNodeBlendBase anbb )
				{
					foreach( var child in anbb.Children )
					{
						foreach( var node in EnumerateTree( child.Anim ) )
						{
							yield return node;
						}
					}
				}
			}
		}



		public void Sample( float dt )
		{
			_tick++;
			try
			{
				SampleInner( _tree, dt, 1f );
			}
			finally
			{
				foreach( var node in _nodes )
				{
					node.NodeTotalWeight = Math.Min(node.TotalWeightAccumulator, 1f);
					node.TotalWeightAccumulator = 0f;
					node.bJustBecameRelevant = false;
					
					if( node.bRelevant && _relevantNodes.ContainsKey( node ) == false )
					{
						node.bRelevant = false;
					}

					if( node.bRelevant == false )
					{
						if( node.NodeTotalWeight > ZERO_ANIMWEIGHT_THRESH )
						{
							node.OnBecomeRelevant();
							node.bRelevant = true;
							node.bJustBecameRelevant = true;
						}
					}
					else
					{
						if( node.NodeTotalWeight <= ZERO_ANIMWEIGHT_THRESH )
						{
							node.OnCeaseRelevant();
							node.bRelevant = false;
						}
					}
				}

				foreach( var kvp in _relevantNodes )
				{
					// Can be null when the node is only shared once
					kvp.Value?.Dispose();
				}
				_relevantNodes.Clear();
			}
		}


		
		void SampleInner( AnimNode node, float dt, float weightHint )
		{
			node.TotalWeightAccumulator += weightHint; // Not close to source
			if( _relevantNodes.TryGetValue( node, out var precomputedPose ) )
			{
				// This node has already been computed in this frame,
				// set hierarchy to that pose already precomputed and exit
				foreach( TRS trs in precomputedPose )
				{
					trs.Transform.localPosition = trs.T;
					trs.Transform.localRotation = trs.R;
				}
				return;
			}
			
			// Now the rest of this is guaranteed to run only once

			bool marked = false;
			try
			{
				node.NodeTickTag = _tick;

				TdPawn pawnActor = _actor as TdPawn;

				if( NodeIs<TdAnimNodeMovementState>( node, out var nodeMovement, ref marked ) && pawnActor != null )
				{
					var state = pawnActor.MovementState;
					var newActive = 0; // 0 is the default branch
					for( int i = 0; i < nodeMovement.EnumStates.Length; i++ )
					{
						if( nodeMovement.EnumStates[ i ] == state )
						{
							newActive = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}

					if( nodeMovement.ActiveChildIndex != newActive )
						nodeMovement.SetActiveMove( newActive );
				}

				if( NodeIs<TdAnimNodeWeaponState>( node, out var weaponState, ref marked ) && pawnActor != null )
				{
					var state = pawnActor.WeaponAnimState;
					var newActive = 0; // 0 is the default branch
					for( int i = 0; i < weaponState.EnumStates.Length; i++ )
					{
						if( weaponState.EnumStates[ i ] == state )
						{
							newActive = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}

					if( weaponState.ActiveChildIndex != newActive )
						weaponState.SetActiveMove( newActive );
				}

				if( NodeIs<TdAnimNodeWalkingState>( node, out var nodeWalking, ref marked ) && pawnActor != null )
				{
					var state = pawnActor.CurrentWalkingState;
					var newActive = 0; // 0 is the default branch
					for( int i = 0; i < nodeWalking.EnumStates.Length; i++ )
					{
						if( nodeWalking.EnumStates[ i ] == state )
						{
							newActive = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}

					if( nodeWalking.ActiveChildIndex != newActive )
						nodeWalking.SetActiveMove( newActive );
				}

				if( NodeIs<TdAnimNodeAgainstWallState>( node, out var againstWall, ref marked ) )
				{
					var state = pawnActor.AgainstWallState;
					var newActive = 0; // 0 is the default branch
					for( int i = 0; i < againstWall.EnumStates.Length; i++ )
					{
						if( againstWall.EnumStates[ i ] == state )
						{
							newActive = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}

					if( againstWall.ActiveChildIndex != newActive )
						againstWall.SetActiveMove( newActive );
				}

				if( NodeIs<TdAnimNodeWeaponTypeState>( node, out var wts, ref marked ) )
				{
					var state = pawnActor.GetWeaponType();
					var newActive = 0; // 0 is the default branch
					for( int i = 0; i < wts.EnumStates.Length; i++ )
					{
						if( wts.EnumStates[ i ] == state )
						{
							newActive = i + 1; // 0 is default, so 1->Length are each states bound to enums
							break;
						}
					}

					if( wts.ActiveChildIndex != newActive )
						wts.SetActiveMove( newActive );
				}

				if( NodeIs<TdAnimNodeGrabbing>( node, out var grabbing, ref marked ) )
				{
					// Nothing to do afaict
				}

				if( NodeIs<TdAnimNodeGrabSlope>( node, out var grabSlope, ref marked ) )
				{
					// Nothing to do afaict
				}

				if( NodeIs<TdAnimNodeCinematicSwitch>( node, out var cinematicSwitch, ref marked ) )
				{
					// I don't care
					if( cinematicSwitch.ActiveChildIndex != 1 )
						cinematicSwitch.SetActiveChild( 1, 0f );
				}

				if( NodeIs<TdAnimNodeBlendDirectional>( node, out var tdDirectional, ref marked ) )
				{
					// I think ?
					var localDir = Quaternion.Inverse( (Quaternion)_actor.Rotation ) * _actor.Velocity.ToUnityDir().normalized;
					var dir = tdDirectional.Direction;
					// probably not but I don't know, we need some sort of time left for accuracy
					dir.X = Lerp( dir.X, localDir.x, dt / tdDirectional.DirInterpTime );
					dir.Y = Lerp( dir.Y, localDir.z, dt / tdDirectional.DirInterpTime );
					// Editor shows this specific 'normalization' method
					var l = dir.X + dir.Y;
					l = l == 0f ? 1f : l;
					dir.X /= l;
					dir.Y /= l;
					tdDirectional.Direction = dir;

					var isNowForward = tdDirectional.Direction.Y > 0f;
					tdDirectional.bGoingForward = isNowForward;
					tdDirectional.ForwardBlend += dt / tdDirectional.ForwardInterpTime * ( tdDirectional.bGoingForward ? 1f : - 1f );
					tdDirectional.ForwardBlend = tdDirectional.ForwardBlend > 1f ? 1f : tdDirectional.ForwardBlend < 0f ? 0f : tdDirectional.ForwardBlend;
						
					var children = tdDirectional.Children;

					var absY = dir.Y < 0f ? - dir.Y : dir.Y;
					var backwardBlend = 1f - tdDirectional.ForwardBlend;
					// From the weird blending behavior seen in the anime tree editor when clicking on 0.5,-0.5 and clicking on the opposite -0.5,0.5
					// this (fairly weird) blending method seems most accurate to source
					children[ 0 ].Weight = absY * tdDirectional.ForwardBlend;
					children[ 1 ].Weight = dir.X >= 0f ? dir.X * tdDirectional.ForwardBlend : 0f;
					children[ 2 ].Weight = dir.X < 0f ? -dir.X * tdDirectional.ForwardBlend : 0f;
					children[ 3 ].Weight = absY * backwardBlend;
					children[ 4 ].Weight = dir.X >= 0f ? dir.X * backwardBlend : 0f;
					children[ 5 ].Weight = dir.X < 0f ? -dir.X * backwardBlend : 0f;
				}

				if( NodeIs<TdAnimNodeBlendBySpeed>( node, out var tdBySpeed, ref marked ) )
				{
					tdBySpeed.Speed = tdBySpeed.bUseAverageSpeed ? 
						pawnActor.AverageSpeed 
						: tdBySpeed.bUseAcceleration ? 
							_actor.Acceleration.Size() 
							: _actor.Velocity.Size();
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

				if( NodeIs<TdAnimNodeSequence>( node, out var td, ref marked ) )
				{
					if( td.ScalePlayRateBySpeed )
					{
						float speed;
						// Not confirmed
						switch( td.ScalePlayRateType )
						{
							case TdAnimNodeSequence.EScalePlayRateType.SPRT_GroundSpeed: // Could be based on just the forward value ?
							case TdAnimNodeSequence.EScalePlayRateType.SPRT_GroundSpeedSize:
							{
								var vel = _actor.Velocity;
								vel.Z = 0;
								speed = vel.Size();
								break;
							}
							case TdAnimNodeSequence.EScalePlayRateType.SPRT_ActorSpeed: speed = _actor.Velocity.Size(); break;
							case TdAnimNodeSequence.EScalePlayRateType.SPRT_ZSpeed: speed = _actor.Velocity.Z; break;
							case TdAnimNodeSequence.EScalePlayRateType.SPRT_AverageActorSpeed: speed = (_actor as TdPawn).GetAverageSpeed( 1f ); break;
							case TdAnimNodeSequence.EScalePlayRateType.SPRT_MAX:
							default: throw new System.ArgumentOutOfRangeException();
						}

						speed = (speed - td.BaseSpeed) * td.ScaleByValue;
						speed = speed < td.RateMin ? td.RateMin : speed;
						speed = speed > td.RateMax ? td.RateMax : speed;
						td.Rate = speed;
						// tooltip: fast rate on low speed
						//td.InversePlayRate ? (1f / speed) : speed; ??? Probably not
					}
					if( td.InversePlayRate )
						LogWarning( $"{nameof(td.InversePlayRate)} not implemented yet" );
					if( td.bSnapToKeyFrames )
						LogWarning( $"{nameof(td.bSnapToKeyFrames)} not implemented yet" );
					if( td.bForceFullPlayback)
						LogWarning( $"{nameof(td.bForceFullPlayback)} not implemented yet" ); 
					if( td.bDeltaCameraAnimation )
						LogWarning( $"{nameof(td.bDeltaCameraAnimation)} not implemented yet" );
					if( td.bForceNoWeaponPose )
						LogWarning( $"{nameof(td.bForceNoWeaponPose)} not supported" );
				}


				if( NodeIs<AnimNodeSequence>( node, out var nodeSequence, ref marked ) )
				{
					if( _clips.TryGetValue( nodeSequence.AnimSeqName, out var clip ) == false )
					{
						LogWarning( $"Animation clip '{nodeSequence.AnimSeqName}' not found" );
						return;
					}
					if( nodeSequence.AnimSeq == null || nodeSequence.AnimSeq.Name != nodeSequence.AnimSeqName )
					{
						nodeSequence.AnimSeq = _set.Sequences.FirstOrDefault( x => x.SequenceName == nodeSequence.AnimSeqName );
						if( nodeSequence.AnimSeq == null )
						{
							LogWarning( $"Animation sequence '{nodeSequence.AnimSeqName}' not found" );
							return;
						}
					}

					clip.wrapMode = nodeSequence.bLooping ? WrapMode.Loop : WrapMode.Clamp;

					// If this node is part of a group, animation is going to be advanced in a second pass, once all weights have been calculated in the tree.
					if( nodeSequence.SynchGroupName == default )
					{
						// Keep track of PreviousTime before any update. This is used by Root Motion.
						nodeSequence.PreviousTime = nodeSequence.CurrentTime;

						// Can only do something if we are currently playing a valid AnimSequence
						if( nodeSequence.bPlaying && nodeSequence.AnimSeq != null )
						{
							// Time to move forwards by - DeltaSeconds scaled by various factors.
							float MoveDelta = nodeSequence.Rate * nodeSequence.AnimSeq.RateScale * nodeSequence.SkelComponent.GlobalAnimRateScale * dt;
							nodeSequence.AdvanceBy(MoveDelta, dt, (nodeSequence.SkelComponent.bUseRawData) ? false : true);
						}
					}

					clip.SampleAnimation( GameObject, nodeSequence.CurrentTime );
					return;
				}
				
				if( NodeIs<AnimNodeBlendPerBone>( node, out var perBone, ref marked ) )
				{
					var source = perBone.Children[ 0 ].Anim;
					var target = perBone.Children[ 1 ].Anim;
					float weight = perBone.Child2Weight;
					if( weight < ZERO_ANIMWEIGHT_THRESH )
					{
						SampleInner( source, dt, weightHint );
						return;
					}

					SampleInner( target, dt, weightHint * weight );
						
					using var bonesTrs = TempBuffer<TRS>.Borrow();
					foreach( var branchName in perBone.BranchStartBoneName )
					{
						var bone = FindInHierarchy( GameObject.transform, branchName );
						if( bone == null )
							continue;

						if( perBone.bOnlyJointsBelowParent )
						{
							for( int i = 0; i < bone.childCount; i++ )
								FetchHierarchyTRS( bone.GetChild(i), bonesTrs, withLocalTRS:true );
						}
						else
						{
							FetchHierarchyTRS( bone, bonesTrs, withLocalTRS:true );
						}
					}
					
					if( source == null )
						SetSkeletonToBindPose();
					else
						SampleInner( source, dt, weightHint/* Do not modulate this, weight depends on bones not a single value */ );
						
					for( int i = 0; i < bonesTrs.Count; i++ )
					{
						var targetData = bonesTrs[ i ];
						var t = targetData.Transform;
						t.localPosition = Vector3.Lerp( t.localPosition, targetData.T, weight );
						t.localRotation = Quaternion.Lerp( t.localRotation, targetData.R, weight );
					}
					return;
				}

				if( NodeIs<AnimNodeSynch>( node, out var synch, ref marked ) )
				{
					// Update groups
					for(var GroupIdx=0; GroupIdx<synch.Groups.Num(); GroupIdx++)
					{
						ref var SynchGroup = ref synch.Groups[GroupIdx];

						// Update Master Node
						UpdateMasterNodeForGroup(synch, ref SynchGroup);

						// Now that we have the master node, have it update all the others
						if( SynchGroup.MasterNode != null && SynchGroup.MasterNode.AnimSeq != null )
						{
							ref AnimNodeSequence MasterNode	= ref SynchGroup.MasterNode;
							float	OldPosition			= MasterNode.CurrentTime;
							float MasterMoveDelta		= SynchGroup.RateScale * MasterNode.Rate * MasterNode.AnimSeq.RateScale * dt;

							if( MasterNode.bPlaying )
							{
								// Keep track of PreviousTime before any update. This is used by Root Motion.
								MasterNode.PreviousTime = MasterNode.CurrentTime;

								// Update Master Node
								// Master Node has already been ticked, so now we advance its CurrentTime position...
								// Time to move forward by - DeltaSeconds scaled by various factors.
								MasterNode.AdvanceBy(MasterMoveDelta, dt, true);
							}

							// Master node was changed during the tick?
							// Skip this round of updates...
							if( SynchGroup.MasterNode != MasterNode )
							{
								continue;
							}

							// Update slave nodes only if master node has changed.
							if( MasterNode.CurrentTime != OldPosition &&
								MasterNode.AnimSeq != null &&
								MasterNode.AnimSeq.SequenceLength > 0.0f )
							{
								// Find it's relative position on its time line.
								float MasterRelativePosition = GetNodeRelativePosition(ref MasterNode);

								// Update slaves to match relative position of master node.
								for(var i=0; i<SynchGroup.SeqNodes.Num(); i++)
								{
									ref AnimNodeSequence SlaveNode = ref SynchGroup.SeqNodes[i];

									if( SlaveNode != null && 
										SlaveNode != MasterNode && 
										SlaveNode.AnimSeq != null &&
										SlaveNode.AnimSeq.SequenceLength > 0.0f )
									{
										// Slave's new time
										float NewTime		= FindNodePositionFromRelative(ref SlaveNode, MasterRelativePosition);
										float SlaveMoveDelta	= appFmod(NewTime - SlaveNode.CurrentTime, SlaveNode.AnimSeq.SequenceLength);

										// Make sure SlaveMoveDelta And MasterMoveDelta are the same sign, so they both move in the same direction.
										if( SlaveMoveDelta * MasterMoveDelta < 0.0f )
										{
											if( SlaveMoveDelta >= 0.0f )
											{
												SlaveMoveDelta -= SlaveNode.AnimSeq.SequenceLength;
											}
											else
											{
												SlaveMoveDelta += SlaveNode.AnimSeq.SequenceLength;
											}
										}

										// Keep track of PreviousTime before any update. This is used by Root Motion.
										SlaveNode.PreviousTime = SlaveNode.CurrentTime;

										// Move slave node to correct position
										SlaveNode.AdvanceBy(SlaveMoveDelta, dt, SynchGroup.bFireSlaveNotifies);
									}
								}
							}
						}
					}
					
					
					/*for( int i = 0; i < synch.Groups.Length; i++ )
						synch.Groups[ i ].MasterNode = null;

					_stackSync.Add( synch );*/
					synch.Children[ 0 ].Weight = 1f;
				}

				if( node is AnimNodeAimOffset aimOffsetPre )
				{
					ref var aimRef = ref aimOffsetPre.Aim;
					var actorRot = (Quaternion)_actor.Rotation;
					var viewRot = (Quaternion)(_actor as Pawn).GetBaseAimRotation();

					var localDir = (Quaternion.Inverse( actorRot ) * viewRot) * Vector3.forward; // I think ?
					aimRef.X = localDir.x;
					aimRef.Y = localDir.y;
				}

				if( NodeIs<TdAnimNodeLandOffset>( node, out var landOffset, ref marked ) )
				{
					if ( landOffset.Landed > 0.0f )
					{
						if ( landOffset.IsLanding == false )
						{
							landOffset.LandTimer = 0.0f;
							landOffset.IsLanding = true;
						}
					}
					if ( landOffset.IsLanding )
					{
						landOffset.LandTimer += dt;
						if ( landOffset.LandInto <= landOffset.LandTimer )
						{
							var landTimer_Minus_LandInto = landOffset.LandTimer - landOffset.LandInto;
							if ( landOffset.LandOut <= landTimer_Minus_LandInto )
							{
								if ( landOffset.LandOverlap <= (landTimer_Minus_LandInto - landOffset.LandOut) )
								{
									landOffset.Aim.Y = 0.0f;
									landOffset.IsLanding = false;
									landOffset.Landed = 0.0f;
								}
								else
								{
									landOffset.Aim.Y = (Sin((landTimer_Minus_LandInto - landOffset.LandOut) / landOffset.LandOverlap * 1.5707964f) - 1.0f) * landOffset.OverlapSize;
								}
							}
							else
							{
								landOffset.Aim.Y = 1.0f - (landOffset.OverlapSize + 1.0f) * Sin(landTimer_Minus_LandInto / landOffset.LandOut * 1.5707964f);
							}
						}
						else
						{
							landOffset.Aim.Y = Sin(landOffset.LandTimer / landOffset.LandInto * 1.5707964f);
						}
						landOffset.Aim.Y = landOffset.Landed * landOffset.Aim.Y;
					}
				}

				if( NodeIs<TdAnimNodeAimOffset>( node, out var tdAimOffset, ref marked ) )
				{
					if( tdAimOffset.bManualAim )
						LogWarning( $"{nameof(tdAimOffset.bManualAim)} not implemented yet" );
					
					ref var aimRef = ref tdAimOffset.Aim;
					var baseURot = _actor.Rotation;
					if( tdAimOffset.bAimSourceIsLegRotation )
						baseURot.Yaw = ( _actor as TdPawn ).LegRotation;
					var actorRot = (Quaternion)baseURot;
					var viewRot = (Quaternion)(_actor as Pawn).GetBaseAimRotation();

					var localDir = (Quaternion.Inverse( actorRot ) * viewRot) * Vector3.forward; // I think ?
					tdAimOffset.WantedAiming.X = localDir.x;
					tdAimOffset.WantedAiming.Y = localDir.y;
					aimRef.X = tdAimOffset.bInterpolateHorizontalAiming ? MoveTowards( aimRef.X, tdAimOffset.WantedAiming.X, dt * tdAimOffset.HorizontalInterpolationSpeed ) : tdAimOffset.WantedAiming.X;
					aimRef.Y = tdAimOffset.WantedAiming.Y;
				}

				if( NodeIs<TdAnimNodeDirBone>( node, out var nodeDirBone, ref marked ) )
				{
					ref var aimRef = ref nodeDirBone.Aim;
					
					aimRef.X = nodeDirBone.bInvertXAxis ? -aimRef.X : aimRef.X;
					aimRef.Y = nodeDirBone.bUsePitch ? aimRef.Y : 0f;
				}

				if( NodeIs<AnimNodeAimOffset>( node, out var aimOffset, ref marked ) )
				{
					if( aimOffset.bForceAimDir )
						LogWarning( $"{nameof(aimOffset.bForceAimDir)} not implemented yet" );
					if( aimOffset.AngleOffset.X != default || aimOffset.AngleOffset.Y != default )
						LogWarning( $"{nameof(aimOffset.AngleOffset)} not implemented yet" );

					var profile = aimOffset.Profiles[ aimOffset.CurrentProfileIndex ];

					var constrainedAim = aimOffset.Aim;
					constrainedAim.X = Clamp( constrainedAim.X, profile.HorizontalRange.X, profile.HorizontalRange.Y );
					constrainedAim.Y = Clamp( constrainedAim.Y, profile.VerticalRange.X, profile.VerticalRange.Y );

					var weightX = constrainedAim.X < 0f ? 1f + constrainedAim.X : constrainedAim.X;
					var weightY = constrainedAim.Y < 0f ? 1f + constrainedAim.Y : constrainedAim.Y;

					SampleInner( aimOffset.Children[0].Anim, dt, weightHint );
					
					foreach( var component in profile.AimComponents )
					{
						if( BoneNameToIndex.TryGetValue( component.BoneName, out var index ) == false )
						{
							// Those bones are unique to 1st/3rd person skeletons while node setups are sometimes shared between skeletons
							// Safe to ignore when they don't exist
							if( component.BoneName == "CameraJoint" || component.BoneName == "RightArmRoll" || component.BoneName == "LeftArmRoll" )
								continue;
							
							LogWarning( $"Could not find bone named '{component.BoneName}' for {nameof(AnimNodeAimOffset)}" );
							continue;
						}

						var t = Bones[ index ];
						var v00 = GetTRSAt( component, FloorToInt( constrainedAim.X ), FloorToInt( constrainedAim.Y ) );
						var v10 = GetTRSAt( component, CeilToInt( constrainedAim.X ), FloorToInt( constrainedAim.Y ) );
						var v01 = GetTRSAt( component, FloorToInt( constrainedAim.X ), CeilToInt( constrainedAim.Y ) );
						var	v11 = GetTRSAt( component, CeilToInt( constrainedAim.X ), CeilToInt( constrainedAim.Y ) );
						
						t.localPosition += Vector3.Lerp(
							Vector3.Lerp( v00.Translation.ToUnityPos(), v10.Translation.ToUnityPos(), weightX ),
							Vector3.Lerp( v01.Translation.ToUnityPos(), v11.Translation.ToUnityPos(), weightX ),
							weightY
						);
						t.localRotation *= Quaternion.Normalize( Quaternion.Lerp(
							Quaternion.Lerp( (Quaternion)v00.Quaternion, (Quaternion)v10.Quaternion, weightX ),
							Quaternion.Lerp( (Quaternion)v01.Quaternion, (Quaternion)v11.Quaternion, weightX ),
							weightY
						) );
					}
					return;
				}

				if( NodeIs<TdAnimNodeBlendList>( node, out var tdbl, ref marked ) )
				{
					if( tdbl.bScaleBlendTimeBySpeed )
						LogWarning( $"{nameof(tdbl.bScaleBlendTimeBySpeed)} not implemented yet" );
				}

				if( NodeIs<AnimNodeBlendList>( node, out var anbl, ref marked ) )
				{
					MatchTargetWeight( ref anbl.Children, anbl.TargetWeight, ref anbl.BlendTimeToGo, dt );
				}

				if( NodeIs<TdAnimNodeSlot>( node, out var tdSlot, ref marked ) )
				{
					// Nothing to do afaict
				}

				if( NodeIs<AnimNodeSlot>( node, out var slot, ref marked ) )
				{
					#warning not fully implemented yet, looks like most of the logic setting up this stuff is in native
					MatchTargetWeight( ref slot.Children, slot.TargetWeight, ref slot.BlendTimeToGo, dt );
				}

				if( NodeIs<AnimTree>( node, out var animTree, ref marked ) )
				{
					//animTree.PrioritizedSkelBranches
					//animTree.RootMorphNodes
					//animTree.SkelControlLists
					if( animTree.Children.Length > 0 )
						SampleInner( animTree.Children[ 0 ].Anim, dt, weightHint );
					return;
				}

				if( NodeIs<AnimNodeBlendBase>( node, out var blender, ref marked ) )
				{
					// Hack
					if( marked == false )
					{
						bool emptyWeight = true;
						foreach( var child in blender.Children )
						{
							if( child.Weight != 0f )
								emptyWeight = false;
						}

						if( emptyWeight )
						{
							SampleInner( blender.Children[ 0 ].Anim, dt, weightHint );
							return;
						}
					}
					
					BlendAll( ref blender.Children, dt, weightHint );
					return;
				}
			}
			finally
			{
				if( _relevantNodes.ContainsKey( node ) == false )
				{
					// Will be released later in the frame after everything is done sampling
					TempBuffer<TRS> pose = null;
					// Only store and compute pose if this node is used by multiple parents
					if( node.ParentNodes.Length > 1 )
					{
						pose = TempBuffer<TRS>.Borrow();
						PushSkeletonTRSInto( pose, true );
					}
					_relevantNodes.Add( node, pose );
				}

				if( marked == false )
					LogWarning( $"Unhandled type: {node.GetType()}" );
			}
		}
		
		
		
		/// <summary>
		/// Updates the Master Node of a given group
		/// </summary>
		static void UpdateMasterNodeForGroup(AnimNodeSynch synch, ref AnimNodeSynch.SynchGroup SynchGroup)
		{
			// start with our previous node. see if we can find better!
			ref AnimNodeSequence MasterNode		= ref SynchGroup.MasterNode;	
			// Find the node which has the highest weight... that's our master node
			float				HighestWeight	= MasterNode != null ? MasterNode.NodeTotalWeight : 0.0f;

			// if the previous master node has a full weight, then don't bother looking for another one.
			if( SynchGroup.MasterNode == null || (SynchGroup.MasterNode.NodeTotalWeight < (1.0f - ZERO_ANIMWEIGHT_THRESH)) )
			{
				for(var i=0; i < SynchGroup.SeqNodes.Num(); i++)
				{
					ref AnimNodeSequence SeqNode = ref SynchGroup.SeqNodes[i];
					if( SeqNode != null &&									
					    !SeqNode.bForceAlwaysSlave && 
					    SeqNode.NodeTotalWeight >= HighestWeight )  // Must be the most relevant to the final blend
					{
						MasterNode		= SeqNode;
						HighestWeight	= SeqNode.NodeTotalWeight;
					}
				}

				SynchGroup.MasterNode = MasterNode;
			}
		}
		
		
		
		/// <summary>
		/// Get relative position of a synchronized node.
		/// Taking into account node's relative offset.
		/// </summary>
		static float GetNodeRelativePosition(ref AnimNodeSequence SeqNode)
		{
			if( SeqNode != null && SeqNode.AnimSeq != null && SeqNode.AnimSeq.SequenceLength > 0.0f )
			{
				// Find it's relative position on its time line.
				float RelativePosition = appFmod((SeqNode.CurrentTime / SeqNode.AnimSeq.SequenceLength) - SeqNode.SynchPosOffset, 1.0f);
				if( RelativePosition < 0.0f )
				{
					RelativePosition += 1.0f;
				}

				return RelativePosition;
			}

			return 0.0f;
		}
		
		
		
		/// <summary>
		/// Find out position of a synchronized node given a relative position.
		/// Taking into account node's relative offset.
		/// </summary>
		static float FindNodePositionFromRelative(ref AnimNodeSequence SeqNode, float RelativePosition)
		{
			if( SeqNode != null && SeqNode.AnimSeq != null )
			{
				var SynchedRelPosition = appFmod(RelativePosition + SeqNode.SynchPosOffset, 1.0f);
				if( SynchedRelPosition < 0.0f )
				{
					SynchedRelPosition += 1.0f;
				}

				return SynchedRelPosition * SeqNode.AnimSeq.SequenceLength;
			}

			return 0.0f;
		}




		static float appFmod( float x, float y ) => x % y;

		
		
		
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



		void SetSkeletonToBindPose()
		{
			foreach( TRS trs in _bindPose )
			{
				trs.Transform.localPosition = trs.T;
				trs.Transform.localRotation = trs.R;
			}
		}



		void MatchTargetWeight( ref array<AnimNodeBlendBase.AnimBlendChild> children, array<float> targetWeights, ref float blendTimeToGo, float dt )
		{
			for( int i = 0; i < children.Length; i++ )
			{
				ref var weightRef = ref children[ i ].Weight;
				var targetWeight = targetWeights[ i ];
							
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if( blendTimeToGo != 0f && targetWeight != weightRef )
				{
					var diff = targetWeight - weightRef;
					var rateOfChangePerSecond = diff / blendTimeToGo;
					var changeThisFrame = rateOfChangePerSecond * dt;
					weightRef += changeThisFrame;
							
					// Don't overshoot target
					if( diff > 0 )
						weightRef = System.Math.Min( weightRef, targetWeight );
					else if( diff < 0 )
						weightRef = System.Math.Max( weightRef, targetWeight );
				}
				else
				{
					weightRef = targetWeight;
				}
			}
					
			blendTimeToGo = blendTimeToGo < dt ? 0f : blendTimeToGo - dt;
		}



		void BlendAll(ref array<AnimNodeBlendBase.AnimBlendChild> arrayToBlend, float dt, float callingNodeWeight)
		{
			using var accumulatedData = TempBuffer<TRS>.Borrow();
			(int i, float weight) highestWeightedItem = (0, 0f);
			float accumulatedWeight = 0f;
			for( int i = 0; i < arrayToBlend.Length; i++ )
			{
				ref var item = ref arrayToBlend[ i ];
				if( callingNodeWeight * item.Weight < ZERO_ANIMWEIGHT_THRESH )
					continue;
				
				if( item.Weight > highestWeightedItem.weight )
					highestWeightedItem = ( i, item.Weight );
				accumulatedWeight += item.Weight;
			}
			
			if(accumulatedWeight == 0f)
				return;
			
			PushSkeletonTRSInto( accumulatedData );
			for( int i = 0; i < arrayToBlend.Length; i++ )
			{
				ref var item = ref arrayToBlend[ i ];
				if( callingNodeWeight * item.Weight < ZERO_ANIMWEIGHT_THRESH )
					continue;
				
				SampleInner( item.Anim, dt, callingNodeWeight * item.Weight );

				var realUnitWeight = item.Weight / accumulatedWeight;
				for( int j = 0; j < accumulatedData.Count; j++ )
				{
					var data = accumulatedData[ j ];
					var t = data.Transform;
					data.T += t.localPosition * realUnitWeight;
					#warning how the heck do I accumulate rotations ?
					data.R = Quaternion.Lerp( data.R, t.localRotation, realUnitWeight );
					accumulatedData[ j ] = data;
				}
			}

			for( int j = 0; j < accumulatedData.Count; j++ )
			{
				var animData = accumulatedData[ j ];
				var t = animData.Transform;
				t.localPosition = animData.T;
				t.localRotation = animData.R;
			}
		}



		struct TRS
		{
			public Transform Transform;
			public Vector3 T;
			public Quaternion R;



			public TRS( Transform pTransform, bool setTRSToLocal )
			{
				if( setTRSToLocal )
				{
					Transform = pTransform;
					T = pTransform.localPosition;
					R = pTransform.localRotation;
				}
				else
				{
					T = default;
					R = Quaternion.identity;
					Transform = pTransform;
				}
			}
		}



		void PushSkeletonTRSInto( TempBuffer<TRS> buffer, bool withLocalTRS = false )
		{
			for( int i = 0; i < Bones.Length; i++ )
				buffer.Add( new TRS( Bones[ i ], withLocalTRS ) );
		}



		void FetchHierarchyTRS( Transform t, TempBuffer<TRS> buffer, bool withLocalTRS = false )
		{
			buffer.Add( new TRS( t, withLocalTRS ) );
			for( int i = buffer.Count - 1; i < buffer.Count; i++ )
			{
				t = buffer[ i ].Transform;
				for( int j = 0; j < t.childCount; j++ )
				{
					buffer.Add( new TRS( t.GetChild( j ), withLocalTRS ) );
				}
			}
		}



		float GetSynchTime( AnimNodeSequence sequenceToSynchronize, AnimNodeSequence controlSequence )
		{
			if( controlSequence.AnimSeq == null || sequenceToSynchronize.AnimSeq == null )
				return 0f;
			var normalized = controlSequence.CurrentTime / controlSequence.AnimSeq.SequenceLength;
			normalized -= controlSequence.SynchPosOffset;
			normalized += sequenceToSynchronize.SynchPosOffset;
			normalized %= 1f;
			if( normalized < 0f )
				normalized = 1f + normalized;
			
			return normalized * sequenceToSynchronize.AnimSeq.SequenceLength;
		}


		
		static AnimNodeAimOffset.AimTransform GetTRSAt( AnimNodeAimOffset.AimComponent comp, int x, int y )
		{
			return (x, y) switch
			{
				(1, 1) => comp.RU,
				(0, 1) => comp.CU,
				(-1, 1) => comp.LU,
				(1, 0) => comp.RC,
				(0, 0) => comp.CC,
				(-1, 0) => comp.LC,
				(1, -1) => comp.RD,
				(0, -1) => comp.CD,
				(-1, -1) => comp.LD,
				_ => throw new System.ArgumentOutOfRangeException()
			};
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



		/*public void TickAnim( TdAnimNodeTurn nodeTurn, float deltaTimeMaybe, float probablyWeight )
		{
    TdPawn skelPawn; // r30
    int aTdPawnClass; // r11
    Class pawnClassCheck; // r9
    TdPawn tdPawnOwner; // r9
    double velY; // fp12
    double velMagnitude; // fp10
    TdPawn skelPawn2; // r28
    Class skelPawn2Class; // r9
    uint legAngleDeltaWithFudge; // r9
    double safeRegionLimit; // fp12
    double deltaInEuler; // fp1
    double absDeltaEuler; // fp13
    double newTimeStandingStill; // fp8
    double idleTimer; // fp9
    uint newFudge; // r9

    if ( nodeTurn.SkelComponent == null )
        goto PASS_PLAYANIM;
    skelPawn = (TdPawn)nodeTurn.SkelComponent.Owner;
    if ( skelPawn == null )
        goto PASS_PLAYANIM;
    aTdPawnClass = ATdPawn::PrivateStaticClass;
    if ( !ATdPawn::PrivateStaticClass )
    {
        ATdPawn::PrivateStaticClass = (uint)ATdPawn::GetPrivateStaticClassATdPawn((const wchar_t *)&off_18D0160);
        ATdPawn::InitializePrivateStaticClassATdPawn();
        aTdPawnClass = ATdPawn::PrivateStaticClass;
    }
    pawnClassCheck = skelPawn.Class;
    if ( pawnClassCheck )
    {
        if ( (Class)aTdPawnClass == pawnClassCheck )
            goto LABEL_17;
        while ( 1 )
        {
            pawnClassCheck = (Class)pawnClassCheck.Next;
            if ( !pawnClassCheck )
                break;
            if ( (Class)aTdPawnClass == pawnClassCheck )
                goto LABEL_17;
        }
    }
    if ( aTdPawnClass )
        goto PASS_PLAYANIM;
LABEL_17:
    if ( nodeTurn.PlayingTurnAnimation == true && probablyWeight > 0.1 )
    {
        if ( nodeTurn.SkelComponent != null )
        {
            skelPawn2 = (TdPawn)nodeTurn.SkelComponent.Owner;
            if ( skelPawn2 != null )
            {
                if ( !aTdPawnClass )
                {
                    ATdPawn::PrivateStaticClass = (uint)ATdPawn::GetPrivateStaticClassATdPawn((const wchar_t *)&off_18D0160);
                    ATdPawn::InitializePrivateStaticClassATdPawn();
                }
                skelPawn2Class = skelPawn2.Class;
                if ( skelPawn2Class )
                {
                    if ( (Class)ATdPawn::PrivateStaticClass == skelPawn2Class )
                    {
TWEAK_LEG_FUDGE:
                        if ( nodeTurn.SkelComponent == (SkeletalMeshComponent)LODWORD(skelPawn2.TakeHitLocation.Y) )
                        {
                            newFudge = (System.UInt16)((int)(float)((float)deltaTimeMaybe * nodeTurn.LegTurnPerSecond)
                                                        + skelPawn2.LegAngleLimitFudge);
                            if ( newFudge > 32767 )
                                newFudge -= 65536;
                            skelPawn2.LegAngleLimitFudge = (int)newFudge;
                        }
                        goto TEST_WHETHER_PLAYANIM;
                    }
                    while ( 1 )
                    {
                        skelPawn2Class = (Class)skelPawn2Class.Next;
                        if ( !skelPawn2Class )
                            break;
                        if ( (Class)ATdPawn::PrivateStaticClass == skelPawn2Class )
                            goto TWEAK_LEG_FUDGE;
                    }
                }
                if ( ATdPawn::PrivateStaticClass )
                    goto TEST_WHETHER_PLAYANIM;
                goto TWEAK_LEG_FUDGE;
            }
        }
    }
TEST_WHETHER_PLAYANIM:
    legAngleDeltaWithFudge = (unsigned __int16)(skelPawn.Rotation.Yaw - skelPawn.LegAngleLimitFudge);
    if ( legAngleDeltaWithFudge > 32767 )
        legAngleDeltaWithFudge -= 65536;
    if ( *(__int64 *)&nodeTurn.bitfield_PlayingTurnAnimation < 0
      || (safeRegionLimit = nodeTurn.SafeRegionLimit,
          deltaInEuler = (float)((float)(int)legAngleDeltaWithFudge * (float)0.0054931641),
          absDeltaEuler = __fabs(deltaInEuler),
          absDeltaEuler < safeRegionLimit) )
    {
        nodeTurn.TimeStandingStill = 0.0;
    }
    else
    {
        if ( absDeltaEuler > safeRegionLimit && nodeTurn.ExtendedRegionLimit > absDeltaEuler )
        {
            newTimeStandingStill = (float)((float)deltaTimeMaybe + nodeTurn.TimeStandingStill);
            idleTimer = nodeTurn.IdleTimer;
            nodeTurn.TimeStandingStill = (float)deltaTimeMaybe + nodeTurn.TimeStandingStill;
            if ( idleTimer >= newTimeStandingStill )
                goto PASS_PLAYANIM;
            goto PLAYANIM;
        }
        if ( nodeTurn.ExtendedRegionLimit < __fabs(deltaInEuler) )
        {
PLAYANIM:
            UTdAnimNodeTurn::PlayTurnAnimation(nodeTurn, deltaInEuler);
            goto PASS_PLAYANIM;
        }
    }
PASS_PLAYANIM:
    tdPawnOwner = nodeTurn.TdPawnOwner;
    if ( tdPawnOwner )
    {
        velY = *(float *)((uint)&tdPawnOwner.Velocity + 4LL);
        velMagnitude = __fsqrts((float)((float)(*(float *)(uint)&tdPawnOwner.Velocity.X
                                              * *(float *)(uint)&tdPawnOwner.Velocity.X)
                                      + (float)((float)velY * (float)velY)));
        if ( nodeTurn.BlendTimeToGo > 0.0 )
        {
            if ( nodeTurn.ActiveChildIndex )
            {
                if ( (*(_QWORD *)&nodeTurn.BlendOutWeight.Max & 0x80000000LL) != 0 )
                {
                    _FP7 = (float)((float)((float)velMagnitude * (float)0.0099999998) - (float)1.0);// deltaTime = deltaTime * Clamp(velMag * 0.0099999998, 0.1, 1)
                    __asm { fsel      f13, f7, f9, f8# Floating-Point Select }
                    _FP5 = (float)((float)_FP13 - (float)0.1);
                    __asm { fsel      f4, f5, f13, f6# Floating-Point Select }
                    deltaTimeMaybe = (float)((float)deltaTimeMaybe * (float)_FP4);
                }
            }
        }
    }
    UAnimNodeBlendList::TickAnim_Proxy((UAnimNodeBlendList *)nodeTurn, deltaTimeMaybe, probablyWeight);// call to base
		}*/



		/*public void Test(TdAnimNodeTurn node, float probablyAngleDiff)
		{
			float absAngle; // st7
			double extendedRegionLimit; // st6
			int mostLikelyAnimationToUse; // eax
			//AnimNodeSequence selectedSequence; // eax
			//AnimNodeSequence selectedSequenceCpy; // esi
			AnimSequence animSeq; // esi
			float extendedBoostSpeed; // xmm3_4
			float baseTurnPerSecond; // xmm0_4
			float absAngleCpy; // [esp+18h] [ebp-4h]

			absAngle = Abs(probablyAngleDiff);
			absAngleCpy = absAngle;
			extendedRegionLimit = node.ExtendedRegionLimit;
			node.PlayingTurnAnimation = true;
			if ( absAngle <= extendedRegionLimit )
			{
				mostLikelyAnimationToUse = 1;
				if ( probablyAngleDiff >= 0.0 )
					mostLikelyAnimationToUse = 3;
			}
			else
			{
				mostLikelyAnimationToUse = 2;
				if ( probablyAngleDiff >= 0.0 )
					mostLikelyAnimationToUse = 4;
			}

			node.SetActiveMove( mostLikelyAnimationToUse, true );
			if ( node.Children[ node.ActiveChildIndex ].Anim is AnimNodeSequence selectedSequence )
			{
				selectedSequence.PlayAnim( selectedSequence.bLooping, selectedSequence.Rate, 0.0f );
				animSeq = selectedSequence.AnimSeq;
				if ( animSeq != null )
				{
					if ( absAngleCpy <= node.ExtendedRegionLimit )
						extendedBoostSpeed = 8192.0f;
					else
						extendedBoostSpeed = 16384.0f;
					if ( probablyAngleDiff == 0.0f )
						baseTurnPerSecond = 0.0f;
					else
						baseTurnPerSecond = probablyAngleDiff / absAngleCpy;
					node.LegTurnPerSecond = (float)(baseTurnPerSecond / animSeq.SequenceLength) * extendedBoostSpeed;
				}
			}
		}*/
	}
}