namespace MEdge
{
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
		AnimNode _tree;
		Dictionary<MEdge.Core.name, AnimationClip> _clips;
		AnimSet _set;
		Actor _actor;
		HashSet<AnimNode> _isRelevantThisFrame = new HashSet<AnimNode>();
		HashSet<AnimNodeSynch> _stackSync = new HashSet<AnimNodeSynch>();
		int _tick;
		Transform[] _bones;
		Dictionary<name, int> _boneNameToIndex;
		
		
		
		public AnimationPlayer(AnimationClip[] clips, AnimSet animSet, AnimNode tree, GameObject gameObject, Actor actor, SkeletalMeshComponent skel)
		{
			_tree = tree;
			_clips = clips.ToDictionary( x => (MEdge.Core.name)x.name );
			_set = animSet;
			GameObject = gameObject;
			_actor = actor;
			_bones = new Transform[ animSet.TrackBoneNames.Length ];
			_boneNameToIndex = new Dictionary<name, int>( _bones.Length );
			var allTransforms = GameObject.GetComponentsInChildren<Transform>().ToDictionary( x => (name)x.name );
			for( int i = 0; i < animSet.TrackBoneNames.Length; i++ )
			{
				var t = allTransforms[ animSet.TrackBoneNames[ i ] ];
				_bones[ i ] = t;
				_boneNameToIndex.Add( (name)t.name, i );
			}

			foreach( var node in Enumerate( tree ) )
			{
				if( node is AnimNodeSequence seq )
				{
					seq.SkelComponent = skel;
				}

				if( node is TdAnimNodeBlendList anbl )
				{
					anbl.TdPawnOwner = actor as TdPawn;
				}
				node.OnInit();
			}
		}



		IEnumerable<AnimNode> Enumerate( AnimNode n )
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



		public void Sample( float dt )
		{
			_tick++;
			try
			{
				SampleInner( _tree, dt, 1f );
			}
			finally
			{
				_isRelevantThisFrame.Clear();
			}
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
			bool needToTick = node.NodeTickTag != _tick;
			node.NodeTickTag = _tick;
			bool marked = false;
			node.NodeTotalWeight = weightHint; // Not too sure that's how it works 
			try
			{
				if( needToTick )
				{
					_isRelevantThisFrame.Add( node );
					if( node.bRelevant == false )
					{
						node.bRelevant = true;
						node.OnBecomeRelevant();
						node.bJustBecameRelevant = true;
					}
					else
					{
						node.bRelevant = true;
						node.bJustBecameRelevant = false;
					}
				}

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
					if( needToTick )
					{
						// I think ?
						var localDir = Quaternion.Inverse( (Quaternion)_actor.Rotation ) * _actor.Velocity.ToUnityDir().normalized;
						var dir = tdDirectional.Direction;
						// probably not but I don't know, we need some sort of time left for accuracy
						dir.X = Mathf.Lerp( dir.X, localDir.x, dt / tdDirectional.DirInterpTime );
						dir.Y = Mathf.Lerp( dir.Y, localDir.z, dt / tdDirectional.DirInterpTime );
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

					//var weightForNotification = node is TdAnimNodeSequence tdSeq && tdSeq.bLooping && tdSeq.bLoopingWithNotify ? 0f : nodeSequence.NodeTotalWeight;
					if( IsSynchronized( nodeSequence, out var controlSequence ) )
					{
						//var controlDeltaTime = ComputeDeltaTime( controlSequence, dt );
						// Note that the control node might not have been updated yet so this time might be one frame behind ...
						nodeSequence.AdvanceBy( GetSynchTime( nodeSequence, controlSequence ) - nodeSequence.CurrentTime, dt, nodeSequence.SkelComponent.bUseRawData ? false : true );
					}
					else if( needToTick )
					{
						var deltaTime = ComputeDeltaTime( nodeSequence, dt );
						nodeSequence.AdvanceBy( deltaTime, dt, nodeSequence.SkelComponent.bUseRawData ? false : true );
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
						SampleInner( source, dt, node.NodeTotalWeight );
						return;
					}

					SampleInner( target, dt, node.NodeTotalWeight * weight );
						
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
						
					SampleInner( source, dt, node.NodeTotalWeight/* Do not modulate this, weight depends on bones not a single value */ );
						
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
					for( int i = 0; i < synch.Groups.Length; i++ )
						synch.Groups[ i ].MasterNode = null;

					_stackSync.Add( synch );
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

				if( NodeIs<TdAnimNodeAimOffset>( node, out var tdAimOffset, ref marked ) && needToTick )
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

					SampleInner( aimOffset.Children[0].Anim, dt, node.NodeTotalWeight );
					
					foreach( var component in profile.AimComponents )
					{
						var t = _bones[ _boneNameToIndex[ component.BoneName ] ];
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

				if( NodeIs<AnimNodeBlendList>( node, out var anbl, ref marked ) && needToTick )
				{
					MatchTargetWeight( ref anbl.Children, anbl.TargetWeight, ref anbl.BlendTimeToGo, dt );
				}

				if( NodeIs<TdAnimNodeSlot>( node, out var tdSlot, ref marked ) )
				{
					// Nothing to do afaict
				}

				if( NodeIs<AnimNodeSlot>( node, out var slot, ref marked ) && needToTick )
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
						SampleInner( animTree.Children[ 0 ].Anim, dt, node.NodeTotalWeight );
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
							SampleInner( blender.Children[ 0 ].Anim, dt, node.NodeTotalWeight );
							return;
						}
					}
					
					BlendAll( ref blender.Children, dt, node.NodeTotalWeight );
					return;
				}
			}
			finally
			{
				if( marked == false )
					LogWarning( $"Unhandled type: {node.GetType()}" );
				
				TrySetChildrenIrrelevant( node );
				
				if( node is AnimNodeSynch synch )
				{
					_stackSync.Remove( synch );
					// Ensures that irrelevant sequences are still properly synchronized
					for( int i = 0; i < synch.Groups.Length; i++ )
					{
						ref var grp = ref synch.Groups[ i ];
						grp.MasterNode = GetControlSequence( grp.SeqNodes );
						foreach( var nodeSequence in grp.SeqNodes )
						{
							if( nodeSequence.bRelevant )
								continue;

							nodeSequence.PreviousTime = nodeSequence.CurrentTime = GetSynchTime( nodeSequence, grp.MasterNode );
						}
					}
				}
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
			for( int i = 0; i < _bones.Length; i++ )
				buffer.Add( new TRS( _bones[ i ], withLocalTRS ) );
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



		bool IsSynchronized( AnimNodeSequence thisSequence, out AnimNodeSequence controlSequence )
		{
			if( thisSequence.bSynchronize == false || thisSequence.SynchGroupName == "" )
			{
				controlSequence = default;
				return false;
			}
			
			foreach( var synchInStack in _stackSync )
			{
				foreach( var synchGroup in synchInStack.Groups )
				{
					if( synchGroup.GroupName == thisSequence.SynchGroupName )
					{
						controlSequence = GetControlSequence(synchGroup.SeqNodes);
						return thisSequence != controlSequence;
					}
				}
			}
			
			LogError( $"Could not find synch group {thisSequence.SynchGroupName}" );
			controlSequence = default;
			return false;
		}



		static AnimNodeSequence GetControlSequence( array<AnimNodeSequence> sequences )
		{
			var controlSequence = sequences[ 0 ];
			foreach( var seqNode in sequences )
			{
				if( seqNode.bRelevant && seqNode.NodeTotalWeight > controlSequence.NodeTotalWeight )
				{
					controlSequence = seqNode;
				}
			}

			return controlSequence;
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
		


		static float ComputeDeltaTime(AnimNodeSequence nodeSequence, float dt)
		{
			if( nodeSequence.AnimSeq.RateScale != 1f )
			{
				LogWarning( $"{nameof(nodeSequence.AnimSeq.RateScale)} is not supported yet, have to investigate further but it might be linked with {nameof(nodeSequence.AnimSeq.SequenceLength)} in some way which would throw off animation logic" );
			}

			if( nodeSequence.bPlaying == false )
				return 0f;

			return nodeSequence.Rate * nodeSequence.AnimSeq.RateScale * nodeSequence.SkelComponent.GlobalAnimRateScale * dt;
		}



		void TrySetChildrenIrrelevant( AnimNode n )
		{
			if( n.bRelevant == false || _isRelevantThisFrame.Contains( n ) )
				return;
			
			n.bRelevant = false;
			n.NodeTotalWeight = 0f;
			n.OnCeaseRelevant();
			if( n is AnimNodeBlendBase anbb )
			{
				foreach( var child in anbb.Children )
				{
					if( child.Anim != null )
						TrySetChildrenIrrelevant( child.Anim );
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



		public void Test(TdAnimNodeTurn node, float probablyAngleDiff)
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
		}
	}
}