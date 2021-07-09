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
		const float WEIGHT_MIN_THRESHOLD = 0.01f;
		const float WEIGHT_MAX_THRESHOLD = 1f-WEIGHT_MIN_THRESHOLD;
		
		public GameObject GameObject;
		AnimNode _tree;
		Dictionary<MEdge.Core.name, AnimationClip> _clips;
		AnimSet _set;
		Actor _actor;
		HashSet<AnimNode> _isRelevantThisFrame = new HashSet<AnimNode>();
		HashSet<AnimNodeSynch> _stackSync = new HashSet<AnimNodeSynch>();
		int _tick;
		
		
		public AnimationPlayer(AnimationClip[] clips, AnimSet animSet, AnimNode tree, GameObject gameObject, Actor actor)
		{
			_tree = tree;
			_clips = clips.ToDictionary( x => (MEdge.Core.name)x.name );
			_set = animSet;
			GameObject = gameObject;
			_actor = actor;
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
				
				// Hack
				if( node.InstanceVersionNumber == 0 )
				{
					node.InstanceVersionNumber = 1;
					node.OnInit();
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
					if( td.bLoopingWithNotify == false )
						LogWarning( $"'{nameof(td.bLoopingWithNotify)} == false' not implemented yet" );
					if( td.bDeltaCameraAnimation )
						LogWarning( $"{nameof(td.bDeltaCameraAnimation)} not implemented yet" );
					if( td.bForceNoWeaponPose )
						LogWarning( $"{nameof(td.bForceNoWeaponPose)} not supported" );
				}


				if( NodeIs<AnimNodeSequence>( node, out var nodeSequence, ref marked ) )
				{
					if( _clips.TryGetValue( nodeSequence.AnimSeqName, out var clip ) )
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

					if( IsSynchronized( nodeSequence, out var controlSequence ) )
					{
						var controlDeltaTime = ComputeDeltaTime( controlSequence, dt );
						// Note that the control node might not have been updated yet so this time might be one frame behind ...
						nodeSequence.CurrentTime = GetSynchTime( nodeSequence, controlSequence );
						ApplyTimeChange( nodeSequence, controlDeltaTime > 0f, nodeSequence.NodeTotalWeight, _actor );
					}
					else if( needToTick )
					{
						var deltaTime = ComputeDeltaTime( nodeSequence, dt );
						nodeSequence.CurrentTime += deltaTime;
						ApplyTimeChange( nodeSequence, deltaTime > 0f, nodeSequence.NodeTotalWeight, _actor );
					}

					clip.SampleAnimation( GameObject, nodeSequence.CurrentTime );
					return;
				}
				
				if( NodeIs<AnimNodeBlendPerBone>( node, out var perBone, ref marked ) )
				{
					var source = perBone.Children[ 0 ].Anim;
					var target = perBone.Children[ 1 ].Anim;
					float weight = perBone.Child2Weight;
					if( weight < WEIGHT_MIN_THRESHOLD )
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
						{
							LogWarning( $"Could not find bone '{branchName}'" );
							continue;
						}

						if( perBone.bOnlyJointsBelowParent )
						{
							for( int i = 0; i < bone.childCount; i++ )
								BuildHierarchy( bone.GetChild(i), bonesTrs, withLocalTRS:true );
						}
						else
						{
							BuildHierarchy( bone, bonesTrs, withLocalTRS:true );
						}
					}
						
					SampleInner( source, dt, node.NodeTotalWeight * (1f-weight) );
						
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
					_stackSync.Add( synch );
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

				if( NodeIs<TdAnimNodeAimOffset>( node, out var tdAimOffset, ref marked ) && needToTick )
				{
					if( tdAimOffset.bManualAim )
						LogWarning( $"{nameof(tdAimOffset.bManualAim)} not implemented yet" );
					if( tdAimOffset.bAimSourceIsLegRotation )
						LogWarning( $"{nameof(tdAimOffset.bAimSourceIsLegRotation)} not implemented yet" );
					if( tdAimOffset.WantedAiming.X != default || tdAimOffset.WantedAiming.Y != default )
						LogWarning( $"{nameof(tdAimOffset.WantedAiming)} not implemented yet" );
					
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
					

					var aim = aimOffset.Aim;
					var profile = aimOffset.Profiles[ aimOffset.CurrentProfileIndex ];
					#warning what's AimComponents purpose ? Looks like it's some kind of offset for each bone ?

					var constrainedAim = aim;
					constrainedAim.X = Clamp( constrainedAim.X, profile.HorizontalRange.X, profile.HorizontalRange.Y );
					constrainedAim.Y = Clamp( constrainedAim.Y, profile.VerticalRange.X, profile.VerticalRange.Y );

					var weightX = constrainedAim.X < 0f ? 1f + constrainedAim.X : constrainedAim.X;
					var weightY = constrainedAim.Y < 0f ? 1f + constrainedAim.Y : constrainedAim.Y;

					using var buffer0 = TempBuffer<TRS>.Borrow();
					using var buffer1 = TempBuffer<TRS>.Borrow();
					// Blend clip00 with clip10 by weights.x -> a
					BlendClips( ( FloorToInt( aim.X ), FloorToInt( aim.Y ) ), ( FloorToInt( aim.X ), CeilToInt( aim.Y ) ) , buffer0, weightX, ref profile );
					// Blend clip01 with clip11 by weights.x -> b
					BlendClips( (CeilToInt( aim.X ), FloorToInt( aim.Y )), (CeilToInt( aim.X ), CeilToInt( aim.Y )), buffer1, weightX, ref profile );
					
					SampleInner( aimOffset.Children[0].Anim, dt, node.NodeTotalWeight );

					// Blend a with b by weights.y and add it over the pose
					var iWeightY = 1f-weightY;
					for( int i = 0; i < buffer0.Count; i++ )
					{
						var lowData = buffer0[ i ];
						var highData = buffer1[ i ];
						var t = lowData.Transform;
						t.localPosition += lowData.T * iWeightY + highData.T * weightY;
						t.localRotation *= Quaternion.Lerp( lowData.R, highData.R, weightY );
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
					/*if( blender.Children.Length > 0 )
						SampleInner( blender.Children[ 0 ].Anim, dt, node.NodeTotalWeight );*/
					
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
					foreach( var grp in synch.Groups )
					{
						var controlSequence = GetControlSequence( grp.SeqNodes );
						foreach( var nodeSequence in grp.SeqNodes )
						{
							if( nodeSequence.bRelevant )
								continue;

							nodeSequence.PreviousTime = nodeSequence.CurrentTime = GetSynchTime( nodeSequence, controlSequence );
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
				if( callingNodeWeight * item.Weight < WEIGHT_MIN_THRESHOLD )
					continue;
				
				if( item.Weight > highestWeightedItem.weight )
					highestWeightedItem = ( i, item.Weight );
				accumulatedWeight += item.Weight;
			}
			
			if(accumulatedWeight == 0f)
				return;
			
			BuildHierarchy(GameObject.transform, accumulatedData);
			for( int i = 0; i < arrayToBlend.Length; i++ )
			{
				ref var item = ref arrayToBlend[ i ];
				if( callingNodeWeight * item.Weight < WEIGHT_MIN_THRESHOLD )
					continue;
				
				SampleInner( item.Anim, dt, callingNodeWeight * item.Weight );

				for( int j = 0; j < accumulatedData.Count; j++ )
				{
					var data = accumulatedData[ j ];
					var t = data.Transform;
					var scaledWeight = item.Weight / accumulatedWeight;
					data.T += t.localPosition * scaledWeight;
					AccumulateQuat(ref data.R, t.localRotation, scaledWeight);
					accumulatedData[ j ] = data;
				}
			}

			// Normalize quaternion
			for( int j = 0; j < accumulatedData.Count; j++ )
			{
				var animData = accumulatedData[ j ];
				ref var qRef = ref animData.R;
				float inverseLength = 1f / Mathf.Sqrt(qRef.x * qRef.x 
				                                      + qRef.y * qRef.y 
				                                      + qRef.z * qRef.z 
				                                      + qRef.w * qRef.w);
				qRef.x *= inverseLength;
				qRef.y *= inverseLength;
				qRef.z *= inverseLength;
				qRef.w *= inverseLength;
				accumulatedData[ j ] = animData;
			}

			for( int j = 0; j < accumulatedData.Count; j++ )
			{
				var animData = accumulatedData[ j ];
				var t = animData.Transform;
				t.localPosition = animData.T;
				t.localRotation = animData.R;
			}
		}





		void AccumulateQuat(ref Quaternion current, Quaternion newQ, float weight)
		{
			if (current.x * newQ.x + current.y * newQ.y + current.z * newQ.z + current.w * newQ.w >= 0.0f)
			{
				current.x += weight * newQ.x;
				current.y += weight * newQ.y;
				current.z += weight * newQ.z;
				current.w += weight * newQ.w;
			}
			else
			{
				current.x -= weight * newQ.x;
				current.y -= weight * newQ.y;
				current.z -= weight * newQ.z;
				current.w -= weight * newQ.w;
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
					this = default;
					Transform = pTransform;
				}
			}
		}



		void BuildHierarchy( Transform t, TempBuffer<TRS> buffer, bool withLocalTRS = false )
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



		static float GetSynchTime( AnimNodeSequence sequenceToSynchronize, AnimNodeSequence controlSequence )
		{
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
				if( seqNode.NodeTotalWeight > controlSequence.NodeTotalWeight )
				{
					controlSequence = seqNode;
				}
			}

			return controlSequence;
		}



		static name GetClipAt( AnimNodeAimOffset.AimOffsetProfile profile, (int x, int y) p )
		{
			return p switch
			{
				(1, 1) => profile.AnimName_RU,
				(0, 1) => profile.AnimName_CU,
				(-1, 1) => profile.AnimName_LU,
				
				(1, 0) => profile.AnimName_RC,
				(0, 0) => profile.AnimName_CC,
				(-1, 0) => profile.AnimName_LC,
				
				(1, -1) => profile.AnimName_RD,
				(0, -1) => profile.AnimName_CD,
				(-1, -1) => profile.AnimName_LD,
				_ => throw new System.ArgumentOutOfRangeException()
			};
		}



		static AnimNodeAimOffset.AimTransform GetTRSAt( AnimNodeAimOffset.AimComponent comp, (int x, int y) p )
		{
			return p switch
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



		void BlendClips( (int x, int y) clipASelector, (int x, int y) clipB, TempBuffer<TRS> buffer0, float weightX, ref AnimNodeAimOffset.AimOffsetProfile profile )
		{
			var clip00 = GetClipAt( profile, clipASelector );
			var clip10 = GetClipAt( profile, clipB );
			float iWeightX = 1f - weightX;
			if( clip00 != "" )
			{
				_clips[ clip00 ].SampleAnimation( GameObject, 0f );
				BuildHierarchy( GameObject.transform, buffer0, true );
			}
			else
			{
				BuildHierarchy( GameObject.transform, buffer0, false );
			}

			for( int i = 0; i < buffer0.Count; i++ )
			{
				name tName = buffer0[ i ].Transform.name;
				foreach( var component in profile.AimComponents )
				{
					if( component.BoneName != tName )
						continue;
					var trs = GetTRSAt( component, clipASelector );
					var data = buffer0[ i ];
					data.T = trs.Translation.ToUnityPos();
					data.R = (Quaternion)MEdge.Core.Object.QuatToRotator(trs.Quaternion);
					buffer0[ i ] = data;
					break;
				}
			}
			
			if( clip10 != "" )
			{
				_clips[clip10].SampleAnimation( GameObject, 0f );
				for( int i = 0; i < buffer0.Count; i++ )
				{
					var clip00Data = buffer0[ i ];
					var t = clip00Data.Transform;

					var translation = t.localPosition;
					var rotation = t.localRotation;
					name tName = buffer0[ i ].Transform.name;
					foreach( var component in profile.AimComponents )
					{
						if( component.BoneName != tName )
							continue;
						var trs = GetTRSAt( component, clipASelector );
						translation = trs.Translation.ToUnityPos();
						rotation = (Quaternion)MEdge.Core.Object.QuatToRotator(trs.Quaternion);
						break;
					}
					
					clip00Data.T = clip00Data.T * iWeightX + translation * weightX;
					clip00Data.R = Quaternion.Lerp( clip00Data.R, rotation, weightX );
					buffer0[ i ] = clip00Data;
				}
			}
			else
			{
				for( int i = 0; i < buffer0.Count; i++ )
				{
					var clip00Data = buffer0[ i ];

					name tName = buffer0[ i ].Transform.name;
					foreach( var component in profile.AimComponents )
					{
						if( component.BoneName != tName )
							continue;
						var trs = GetTRSAt( component, clipASelector );
						clip00Data.T = clip00Data.T * iWeightX + trs.Translation.ToUnityPos() * weightX;
						clip00Data.R = Quaternion.Lerp( clip00Data.R, (Quaternion)MEdge.Core.Object.QuatToRotator(trs.Quaternion), weightX );
						goto ASSIGN_AND_NEXT;
					}
					
					clip00Data.T *= iWeightX;
					clip00Data.R = Quaternion.Lerp( clip00Data.R, Quaternion.identity, weightX );
					
					ASSIGN_AND_NEXT:
					buffer0[ i ] = clip00Data;
				}
			}
		}



		static float ComputeDeltaTime(AnimNodeSequence nodeSequence, float dt)
		{
			if( nodeSequence.AnimSeq.RateScale != 1f )
			{
				LogWarning( $"{nameof(nodeSequence.AnimSeq.RateScale)} is not supported yet, have to investigate further but it might be linked with {nameof(nodeSequence.AnimSeq.SequenceLength)} in some way which would throw off animation logic" );
			}

			if( nodeSequence.bPlaying == false )
				return 0f;

			#warning weird stuff going on with animsequence RateScale and length, they seem to be related in some way, make sure I'm doing the right thing here
			return dt * nodeSequence.Rate * nodeSequence.AnimSeq.RateScale;
		}



		static void ApplyTimeChange( AnimNodeSequence nodeSequence, bool timeGoesForward, float currentWeightForNotification, Actor actor )
		{
			try
			{
				ref var refCurrentTime = ref nodeSequence.CurrentTime;
				ref var refPreviousTime = ref nodeSequence.PreviousTime;
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if( refPreviousTime == refCurrentTime )
					return;
				
				var sequenceLength = nodeSequence.AnimSeq.SequenceLength;
				if( nodeSequence.bLooping )
				{
					refCurrentTime %= sequenceLength;
					if( refCurrentTime < 0f )
						refCurrentTime = sequenceLength + refCurrentTime;
				}
				else if( refCurrentTime > sequenceLength )
				{
					refCurrentTime = sequenceLength;
				}

				if( currentWeightForNotification < nodeSequence.NotifyWeightThreshold )
					return;
				
				Vector4 ranges = Vector4.zero;
				int timeSlices;
				if( timeGoesForward && refCurrentTime < refPreviousTime )
				{
					// Looped around, execute from 
					ranges[ 0 ] = refPreviousTime;
					ranges[ 1 ] = sequenceLength;
					ranges[ 2 ] = 0f;
					ranges[ 3 ] = refCurrentTime;
					timeSlices = 2;
				}
				else if( timeGoesForward == false && refCurrentTime > refPreviousTime )
				{
					// Looped around backwards, execute from
					ranges[ 0 ] = 0f;
					ranges[ 1 ] = refPreviousTime;
					ranges[ 2 ] = refCurrentTime;
					ranges[ 3 ] = sequenceLength;
					timeSlices = 2;
				}
				else
				{
					ranges[ 0 ] = refPreviousTime;
					ranges[ 1 ] = refCurrentTime;
					timeSlices = 1;
				}

				for( int i = 0; i < timeSlices; i++ )
				{
					var from = ranges[i*2+0];
					var to = ranges[i*2+1];

					var notifies = nodeSequence.AnimSeq.Notifies;
					var notifiesCount = notifies.Length;
					for( int j = 0; j < notifiesCount; j++ )
					{
						var notifyEvent = timeGoesForward ? notifies[ j ] : notifies[ notifiesCount - 1 - j ];
						if( (notifyEvent.Time > from && notifyEvent.Time <= to) == false ) 
							continue;
						
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
			finally
			{
				nodeSequence.PreviousTime = nodeSequence.CurrentTime;
			}
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
	}
}