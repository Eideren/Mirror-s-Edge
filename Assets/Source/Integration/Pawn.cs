
using static MEdge.Source.DecFn;
using FLOAT = System.Single;
using INT = System.Int32;
using UINT = System.UInt32;
using BOOL = System.Boolean;
using UBOOL = System.Boolean;
using BYTE = System.Byte;
using FVector = MEdge.Core.Object.Vector;
using FRotator = MEdge.Core.Object.Rotator;
using FQuat = MEdge.Core.Object.Quat;
using FMatrix = MEdge.Core.Object.Matrix;
using FCheckResult = MEdge.Source.DecFn.CheckResult;
using static MEdge.Engine.SkeletalMeshComponent.ERootMotionMode;
using static MEdge.Engine.Actor.ENetRole;
using static MEdge.Engine.Actor.EPhysics;
using static MEdge.Source.DecFn.EMoveFlags;
using static MEdge.Core.Object.EObjectFlags;
using System;
using MEdge.Core;
using Object = MEdge.Core.Object;
using static MEdge.Core.Object.ETraceFlags;

namespace MEdge.Engine
{
	using Source;



	public partial class Pawn
	{
		public override void PostBeginPlay()
		{
			base.PostBeginPlay();
			if ( !bDeleteMe )
			{
				NativeMarkers.MarkUnimplemented("Just adding pawn to world coll");
				//GWorld.AddPawn( this );
			}
		}
		// Export UPawn::execIsLocallyControlled(FFrame&, void* const)
		public virtual /*native final simulated function */ bool IsLocallyControlled()
		{
			if ( !Controller )
				return false;
			/*if ( GWorld.GetNetMode() == NM_Standalone )
				return true;*/
			if ( !(Controller is PlayerController) )
				return true;

			return Controller.LocalPlayerController();
		}
		// Export UPawn::execIsHumanControlled(FFrame&, void* const)
		public virtual /*native final simulated function */bool IsHumanControlled()
		{
			return Controller is PlayerController;
		}
		
		
		
		// Export UPawn::execSetAnchor(FFrame&, void* const)
		public virtual /*native function */void SetAnchor(NavigationPoint NewAnchor)
		{
			if (Anchor != NULL &&
			    Anchor.AnchoredPawn == this)
			{
				Anchor.AnchoredPawn = null;
				Anchor.LastAnchoredPawnTime = GWorld.GetTimeSeconds();
			}

			Anchor = NewAnchor;
			if ( Anchor )
			{
				LastValidAnchorTime = GWorld.GetTimeSeconds();
				LastAnchor = Anchor;
				// set the anchor reference for path finding purposes
				// only for AI pawns as PlayerControllers using pathfinding is usually sporadic, so this might not get updated for a long time
				if (!IsHumanControlled())
				{
					Anchor.AnchoredPawn = this;
				}
			}
		}
		
		
		
		const int MAXPATHDIST = 1200; // maximum distance for paths between two nodes
		public void rotateToward(FVector FocalPoint)
		{
			if( bRollToDesired || Physics == PHYS_Spider )
			{
				return;
			}

			if( IsGlider() )
			{
				Acceleration = Rotation.Vector() * AccelRate;
			}

			FVector Direction = FocalPoint - Location;
			if ( (Physics == PHYS_Flying) 
			     && Controller && Controller.MoveTarget && (Controller.MoveTarget != Controller.Focus) )
			{
				FVector MoveDir = (Controller.MoveTarget.Location - Location);
				FLOAT Dist = MoveDir.Size();
				if ( Dist < MAXPATHDIST )
				{
					Direction = Direction/Dist;
					MoveDir = MoveDir.SafeNormal();
					if ( (Direction | MoveDir) < 0.9f )
					{
						Direction = MoveDir;
						Controller.Focus = Controller.MoveTarget;
					}
				}
			}

			// Rotate toward destination
			DesiredRotation = Direction.Rotation();
			DesiredRotation.Yaw = DesiredRotation.Yaw & 65535;
			if ( (Physics == PHYS_Walking) && (!Controller || !Controller.MoveTarget || !Controller.MoveTarget.GetAPawn()) )
			{
				DesiredRotation.Pitch = 0;
			}
		}
		public UBOOL IsGlider()
		{
			return !bCanStrafe && (Physics == PHYS_Flying || Physics == PHYS_Swimming);
		}
		
		public override void SmoothHitWall(FVector HitNormal, Actor HitActor)
		{
			if ( Controller )
			{
				if ( Physics == PHYS_Walking )
				{
					HitNormal.Z = 0;
				}
				if ( Controller.NotifyHitWall(HitNormal, HitActor) )
					return;
			}
			HitWall(HitNormal, HitActor, null);
		}
		
		public override void TickSpecial( FLOAT DeltaSeconds )
		{
			if( (Role==ROLE_Authority) && (BreathTime > 0f) )
			{
				BreathTime -= DeltaSeconds;
				if (BreathTime < 0.001f)
				{
					BreathTime = 0.0f;
					BreathTimer();
				}
			}
			// update MoveTimer here if no physics
			if (Physics == PHYS_None && Controller != NULL)
			{
				Controller.MoveTimer -= DeltaSeconds;
			}
		}
		public override void TickSimulated( FLOAT DeltaSeconds )
		{
			// Simulated Physics for pawns
			// simulate gravity

			if ( bHardAttach )
			{
				Acceleration = FVector(0f,0f,0f);
				if (Physics == PHYS_RigidBody)
					setPhysics(PHYS_None);
				else
					Physics = PHYS_None;
			}
			else if (Physics == PHYS_RigidBody || Physics == PHYS_Interpolating)
			{
				performPhysics(DeltaSeconds);
			}
			else if (Physics == PHYS_Spider)
			{
				// never try to detect/simulate other physics or gravity when spidering
				Acceleration = Velocity.SafeNormal();
				moveSmooth(Velocity * DeltaSeconds);
			}
			else
			{
				// make sure we have a valid physicsvolume (level streaming might kill it)
				if (PhysicsVolume == NULL)
				{
					SetZone(FALSE, FALSE);
				}

				Acceleration = Velocity.SafeNormal();
				if ( PhysicsVolume.bWaterVolume )
					Physics = PHYS_Swimming;
				else if ( bCanClimbLadders && PhysicsVolume is LadderVolume )
					Physics = PHYS_Ladder;
				else if ( bSimulateGravity )
					Physics = PHYS_Walking;	// set physics mode guess for use by animation
				else
					Physics = PHYS_Flying;

				//simulated pawns just predict location, no script execution
				moveSmooth(Velocity * DeltaSeconds);

				// allow touched actors to impact physics
				if( PendingTouch )
				{
					PendingTouch.PostTouch(this);
					Actor OldTouch = PendingTouch;
					PendingTouch = PendingTouch.PendingTouch;
					OldTouch.PendingTouch = null;
				}

				// if simulated gravity, check if falling
				if ( bSimulateGravity && !bSimGravityDisabled && !PhysicsVolume.bWaterVolume)
				{
					FVector CollisionCenter = Location + CylinderComponent.Translation;
					FCheckResult Hit = new FCheckResult(1f);
					if ( Velocity.Z == 0f )
					{
						GWorld.SingleLineCheck(ref Hit, this, CollisionCenter - FVector(0f,0f,1.5f * CylinderComponent.CollisionHeight), CollisionCenter, (int)TRACE_AllBlocking, FVector(CylinderComponent.CollisionRadius,CylinderComponent.CollisionRadius,4f));
					}
					else if ( Velocity.Z < 0f )
					{
						GWorld.SingleLineCheck(ref Hit, this, CollisionCenter - FVector(0f,0f,8f), CollisionCenter, (int)TRACE_AllBlocking, GetCylinderExtent());
					}

					if ( (Hit.Time == 1f) || (Hit.Normal.Z < WalkableFloorZ) )
					{
						if ( Velocity.Z == 0f )
							Velocity.Z = 0.15f * GetGravityZ();
						Velocity.Z += GetGravityZ() * DeltaSeconds;
						Physics = PHYS_Falling;
					}
					else
					{
						if ( (Velocity.Z == 0f) && (Hit.Time > 0.67f) )
						{
							// step down if walking
							GWorld.MoveActor( this, FVector(0f,0f, -1f*MaxStepHeight), Rotation, 0, ref Hit );
						}
						Velocity.Z = 0f;
					}
				}
			}

			// Tick the nonplayer.
			//clockSlow(GStats.DWORDStats(GEngineStats.STATS_Game_ScriptTickCycles));
			eventTick(DeltaSeconds);
			//unclockSlow(GStats.DWORDStats(GEngineStats.STATS_Game_ScriptTickCycles));

			// Update the actor's script state code.
			ProcessState( DeltaSeconds );

			UpdateTimers(DeltaSeconds );
		}

		
		
		
		public override UBOOL PlayerControlled()
		{
			return ( IsLocallyControlled() && Controller != NULL && Controller is PlayerController );
		}
		
		public override void ReverseBasedRotation()
		{
			if (Controller != NULL && !bIgnoreBaseRotation)
			{
				Controller.Rotation = Controller.OldBasedRotation;
			}
		}
		
		public override void PushedBy(Actor Other)
		{
			bForceFloorCheck = TRUE;
		}
		public override void NotifyBump(Actor Other, PrimitiveComponent OtherComp, in FVector HitNormal)
		{
			if( Controller == default || !Controller.NotifyBump(Other, HitNormal) )
			{
				Bump(Other, OtherComp, HitNormal);
			}
		}
		
		public override void UpdatePushBody()
		{
			#if WITH_NOVODEX
			if(CollisionComponent && CollisionComponent->IsAttached())
			{
				// Axis aligned bounding box.
				FTranslationMatrix CollisionTM(CollisionComponent->LocalToWorld.GetOrigin());
				NxMat34 nCollisionTM = U2NTransform(CollisionTM);

				NxActor* KinActor = (NxActor*)PhysicsPushBody;
				if(KinActor)
				{
					KinActor->moveGlobalPose(nCollisionTM);
				}
			}
			#endif // WITH_NOVODEX
		}
        
        // Export UPawn::execIsPlayerPawn(FFrame&, void* const)
        public virtual /*native simulated function */bool IsPlayerPawn()
        {
	        NativeMarkers.MarkUnimplemented(); // Check with source
	        // IsPlayerPawn() return true if controlled by a Player (AI or human) on local machine (any controller on server, localclient's pawn on client)
        	return true;
        }
        
        public virtual /*native final function */void SetRemoteViewPitch(int NewRemoteViewPitch)
        {
	        RemoteViewPitch = (byte)((NewRemoteViewPitch & 65535) >> 8);
        }
        
        public override void UpdateBasedRotation(ref Object.Rotator FinalRotation, in Object.Rotator ReducedRotation)
        {
	        float ControllerRoll = 0;
	        if ( Controller )
	        {
		        Controller.OldBasedRotation = Controller.Rotation;
		        ControllerRoll = Controller.Rotation.Roll;
		        Controller.Rotation += ReducedRotation;
	        }

	        // If its a pawn, and its not a crawler, remove roll.
	        if( !bCrawler )
	        {
		        FinalRotation.Roll = Rotation.Roll;
		        if( Controller )
		        {
			        Controller.Rotation.Roll = appTrunc(ControllerRoll);
		        }
	        }
        }

        public virtual FVector NewFallVelocity(FVector OldVelocity, FVector OldAcceleration, FLOAT timeTick)
        {
	        FLOAT NetBuoyancy = 0f;
	        FLOAT NetFluidFriction = 0f;
	        GetNetBuoyancy(ref NetBuoyancy, ref NetFluidFriction);

	        FVector NewVelocity = OldVelocity * (1 - NetFluidFriction * timeTick)
	                              + OldAcceleration * (1f - NetBuoyancy) * timeTick;

	        return NewVelocity;
        }
        
        public override unsafe void physFalling(FLOAT deltaTime, INT Iterations)
		{
			//bound acceleration, falling object has minimal ability to impact acceleration
			FLOAT BoundSpeed = 0; //Bound final 2d portion of velocity to this if non-zero

			if( Controller )
			{
				Controller.PreAirSteering(deltaTime);
			}

			// Is the Pawn using root motion?
			UBOOL bDoRootMotionVelocity	= (Mesh && Mesh.RootMotionMode == RMM_Velocity && Mesh.PreviousRMM != RMM_Ignore && !bForceRegularVelocity);
			UBOOL bDoRootMotionAccel		= (Mesh && Mesh.RootMotionMode == RMM_Accel && Mesh.PreviousRMM != RMM_Ignore && !bForceRegularVelocity);
			UBOOL	bDoRootMotion			= (bDoRootMotionVelocity ||  bDoRootMotionAccel);

			// If doing root motion, get root motion velocity.
			if( bDoRootMotion )
			{
				// bForceRMVelocity is set when replaying moves that used root motion derived velocity on a client in a network game
				// the velocity can't be derived again, since the animation state isn't saved.
				if( bForceRMVelocity )
				{
					Velocity = RMVelocity;
				}
				else
				{
					FVector CurrentVelocity		= Velocity;
					FVector RootMotionTranslation	= bDoRootMotion ? Mesh.RootMotionDelta.Translation : FVector(0f);	

					// check to see if acceleration is being driven by animation
					if( bDoRootMotionAccel )
					{
						// When falling, only have root motion take over X and Y, not Z.
						Velocity		= RootMotionTranslation / deltaTime;
						Velocity.Z		= CurrentVelocity.Z;

						// Do not allow any sort of AirControl when doing root motion accel.
						Acceleration	= FVector(0f);
						RMVelocity		= Velocity;

						//DEBUGPHYSONLY(debugf(TEXT("%3.3f [%s] bDoRootMotionAccel Move: %3.3f, Vect: %s"), GWorld.GetTimeSeconds(), *GetName(), Velocity.Size() * deltaTime, *(Velocity*deltaTime).ToString());)
					}

					// We've used root motion, clear the accumulator.
					Mesh.RootMotionDelta.Translation = FVector(0f);
				}
			}

			FVector RealAcceleration = Acceleration;
			CheckResult Hit = new CheckResult(1f);

			// test for slope to avoid using air control to climb walls
			FLOAT TickAirControl = AirControl;
			Acceleration.Z = 0f;
			if( !bDoRootMotion && TickAirControl > 0.05f )
			{
				FVector TestWalk = ( TickAirControl * AccelRate * Acceleration.SafeNormal() + Velocity ) * deltaTime;
				TestWalk.Z = 0f;
				if(!TestWalk.IsZero())
				{
					FVector ColLocation = CollisionComponent ? Location + CollisionComponent.Translation : Location;
					var v1 = ColLocation + TestWalk;
					var v2 = FVector( CylinderComponent.CollisionRadius, CylinderComponent.CollisionRadius, CylinderComponent.CollisionHeight );
					GWorld.SingleLineCheck( ref Hit, this, v1, ColLocation, (int)(TRACE_World|TRACE_StopAtAnyHit), v2 );
					if( Hit.Actor )
					{
						TickAirControl = 0f;
					}
				}
			}

			if( !bDoRootMotion )
			{
				// Boost maxAccel to increase player's control when falling
				FLOAT	maxAccel		= AccelRate * TickAirControl;
				FVector Velocity2D		= Velocity;
						Velocity2D.Z	= 0;
				FLOAT	speed2d			= Velocity2D.Size2D();

				if( (speed2d < 10f) && (TickAirControl > 0f) ) //allow initial burst
				{
					maxAccel = maxAccel + (10 - speed2d)/deltaTime;
				}
				else if( speed2d >= GroundSpeed )
				{
					if( TickAirControl <= 0.05f )
					{
						maxAccel = 1f;
					}
					else
					{
						BoundSpeed = speed2d;
					}
				}

				if( Acceleration.SizeSquared() > maxAccel * maxAccel )
				{
					Acceleration = Acceleration.SafeNormal();
					Acceleration *= maxAccel;
				}
			}

			if( Controller )
			{
				Controller.PostAirSteering(deltaTime);
			}

			FLOAT remainingTime = deltaTime;
			FLOAT timeTick = 0.1f;
			FVector OldLocation = Location;

			while( (remainingTime > 0f) && (Iterations < 8) )
			{
				Iterations++;

				if( remainingTime > 0.05f )
				{
					timeTick = Min(0.05f, remainingTime * 0.5f);
				}
				else 
				{
					timeTick = remainingTime;
				}

				remainingTime -= timeTick;
				OldLocation = Location;
				bJustTeleported = false;

				FVector OldVelocity = Velocity;
				Velocity = NewFallVelocity(OldVelocity, Acceleration + FVector(0f,0f,GetGravityZ()),timeTick);
				if( Controller && Controller.bNotifyApex && (Velocity.Z <= 0f) )
				{
					bJustTeleported = true;
					Controller.bNotifyApex = false;
					Controller.NotifyJumpApex();
				}

				if( !bDoRootMotion && BoundSpeed != 0 )
				{
					// using air control, so make sure not exceeding acceptable speed
					FVector Vel2D = Velocity;
					Vel2D.Z = 0;
					if( Vel2D.SizeSquared() > BoundSpeed * BoundSpeed )
					{
						Vel2D = Vel2D.SafeNormal();
						Vel2D = Vel2D * BoundSpeed;
						Vel2D.Z = Velocity.Z;
						Velocity = Vel2D;
					}
				}
				FVector Adjusted = (Velocity + PhysicsVolume.ZoneVelocity) * timeTick;

				GWorld.MoveActor(this, Adjusted, Rotation, (int)MOVE_TraceHitMaterial, ref Hit);
				if( bDeleteMe )
				{
					return;
				}
				else if ( Physics == PHYS_Swimming ) //just entered water
				{
					remainingTime = remainingTime + timeTick * (1f - Hit.Time);
					startSwimming(OldLocation, OldVelocity, timeTick, remainingTime, Iterations);
					return;
				}
				else if ( Hit.Time < 1f )
				{
					if ( Hit.Actor && Hit.Actor.GetAPawn() && (Adjusted.Z > 0f) && (Hit.Time == 0f) && (Hit.Normal.Z == 1f) )
					{
						// used to address pawns getting stuck on each other due to precision issues when Z component of location is far from the origin
						StuckOnPawn(Hit.Actor.GetAPawn());
					}
					if (Hit.Normal.Z >= WalkableFloorZ)
					{
						remainingTime += timeTick * (1f - Hit.Time);
						if (!bJustTeleported && (Hit.Time > 0.1f) && (Hit.Time * timeTick > 0.003f) )
							Velocity = (Location - OldLocation)/(timeTick * Hit.Time);
						processLanded(Hit.Normal, Hit.Actor, remainingTime, Iterations);
						return;
					}
					else
					{
						if( !RealAcceleration.IsZero() || !Controller || !Controller.AirControlFromWall(timeTick, ref RealAcceleration) )
						{
							processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
							
							// If we've changed physics mode, abort.
							if( bDeleteMe || Physics != PHYS_Falling )
							{
								return;
							}
						}
						FVector OldHitNormal = Hit.Normal;
						FVector Delta = CalculateSlopeSlide(ref Adjusted, ref Hit);

						if( (Delta | Adjusted) >= 0f )
						{
							GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
							if (Hit.Time < 1f) //hit second wall
							{
								if ( Hit.Normal.Z >= WalkableFloorZ )
								{
									remainingTime = 0f;
									processLanded(Hit.Normal, Hit.Actor, remainingTime, Iterations);
									return;
								}

								processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
								
								// If we've changed physics mode, abort.
								if( bDeleteMe || Physics != PHYS_Falling )
								{
									return;
								}

								FVector DesiredDir = Adjusted.SafeNormal();
								TwoWallAdjust(DesiredDir, ref Delta, Hit.Normal, OldHitNormal, Hit.Time);
								bool bDitch = ( (OldHitNormal.Z > 0f) && (Hit.Normal.Z > 0f) && (Delta.Z == 0f) && ((Hit.Normal | OldHitNormal) < 0f) );
								GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
								if ( bDitch || (Hit.Normal.Z >= WalkableFloorZ) )
								{
									remainingTime = 0f;
									processLanded(Hit.Normal, Hit.Actor, remainingTime, Iterations);
									return;
								}
							}
						}
						FLOAT OldVelZ = OldVelocity.Z;
						OldVelocity = (Location - OldLocation)/timeTick;
						OldVelocity.Z = OldVelZ;
					}
				}

				if (!bDoRootMotion && !bJustTeleported && Physics != PHYS_None)
				{
					// refine the velocity by figuring out the average actual velocity over the tick, and then the final velocity.
					// This particularly corrects for situations where level geometry affected the fall.
					Velocity = (Location - OldLocation)/timeTick; //actual average velocity
					if( (Velocity.Z < OldVelocity.Z) || (OldVelocity.Z >= 0f) )
					{
						Velocity = 2f * Velocity - OldVelocity; //end velocity has 2* accel of avg
					}

					if( Velocity.SizeSquared() > Square(GetTerminalVelocity()) )
					{
						Velocity = Velocity.SafeNormal();
						Velocity *= GetTerminalVelocity();
					}
				}
			}

			if( Controller )
			{
				Controller.PostPhysFalling(deltaTime);
			}

			Acceleration = RealAcceleration;
		}
        
        public virtual unsafe void physSwimming(FLOAT deltaTime, INT Iterations)
		{
			NativeMarkers.MarkUnimplemented();
			/*
			FLOAT NetBuoyancy = 0f;
			FLOAT NetFluidFriction  = 0f;
			GetNetBuoyancy(ref NetBuoyancy, ref NetFluidFriction);
			if ( (Velocity.Z > FASTWALKSPEED) && (Buoyancy != 0f) )
			{
				//damp positive Z out of water
				Velocity.Z = Velocity.Z * NetBuoyancy/Buoyancy;
			}

			Iterations++;
			FVector OldLocation = Location;
			bJustTeleported = false;
			FVector AccelDir;
			if ( Acceleration.IsZero() )
				AccelDir = Acceleration;
			else
				AccelDir = Acceleration.SafeNormal();
			CalcVelocity(ref AccelDir, deltaTime, WaterSpeed, 0.5f * PhysicsVolume.FluidFriction, 1, 0, 1);
			FLOAT velZ = Velocity.Z;
			FVector Adjusted = (Velocity + PhysicsVolume.ZoneVelocity * 25 * deltaTime) * deltaTime;
			CheckResult Hit = new CheckResult(1f);
			FLOAT remainingTime = deltaTime * Swim(Adjusted, Hit);

			//may have left water - if so, script might have set new physics mode
			if ( Physics != PHYS_Swimming )
			{
				startNewPhysics(remainingTime, Iterations);
				return;
			}

			if (Hit.Time < 1f)
			{
				Floor = Hit.Normal;
				FLOAT stepZ = Location.Z;
				FVector RealVelocity = Velocity;
				Velocity.Z = 1f;	// HACK: since will be moving up, in case pawn leaves the water
				stepUp(-1f*Hit.Normal, Adjusted.SafeNormal(), Adjusted * (1f - Hit.Time), Hit);
				//may have left water - if so, script might have set new physics mode
				if ( Physics != PHYS_Swimming )
				{
					startNewPhysics(remainingTime, Iterations);
					return;
				}
				Velocity = RealVelocity;
				OldLocation.Z = Location.Z + (OldLocation.Z - stepZ);
			}
			else
				Floor = FVector(0f,0f,1f);

			if (!bJustTeleported && (remainingTime < deltaTime))
			{
				UBOOL bWaterJump = !PhysicsVolume.bWaterVolume;
				if (bWaterJump)
					velZ = Velocity.Z;
				Velocity = (Location - OldLocation) / (deltaTime - remainingTime);
				if (bWaterJump)
					Velocity.Z = velZ;
			}

			if ( !PhysicsVolume.bWaterVolume )
			{
				if (Physics == PHYS_Swimming)
					setPhysics(PHYS_Falling); //in case script didn't change it (w/ zone change)
				if ((Velocity.Z < 160f) && (Velocity.Z > 0)) //allow for falling out of water
					Velocity.Z = 40f + Velocity.Size2D() * 0.4; //smooth bobbing
			}

			//may have left water - if so, script might have set new physics mode
			if ( Physics != PHYS_Swimming )
				startNewPhysics(remainingTime, Iterations);*/
		}
        
        public override void stepUp(in FVector GravDir, in FVector DesiredDir, in FVector Delta, ref CheckResult Hit)
        {
	        FVector Down = GravDir * (MaxStepHeight + MAXSTEPHEIGHTFUDGE);
	        UBOOL bStepDown = TRUE;

	        // If walking up a slope that is walkable (step up - used instead of trying to slide up)
	        FLOAT StepSideZ = -1f * (Hit.Normal | GravDir);
	        if( (StepSideZ < MAXSTEPSIDEZ) || (Hit.Normal.Z >= WalkableFloorZ) )
	        {
		        // step up - treat as vertical wall
		        GWorld.MoveActor(this, -1 * Down, Rotation, 0, ref Hit);
		        GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
	        }
	        else if ( Physics != PHYS_Walking )
	        {
		        // slide up slope
		        FLOAT Dist = Delta.Size();
		        GWorld.MoveActor(this, Delta + FVector(0,0,Dist*Hit.Normal.Z), Rotation, 0, ref Hit);
		        bStepDown = FALSE;
	        }

	        if (Hit.Time < 1f)
	        {
		        if ( ( -1f * (Hit.Normal | GravDir) < MAXSTEPSIDEZ) && (Hit.Time * Delta.SizeSquared() > MINSTEPSIZESQUARED) )
		        {
			        // try another step
			        if ( bStepDown )
				        GWorld.MoveActor(this, Down, Rotation, 0, ref Hit);
			        stepUp(GravDir, DesiredDir, Delta * (1 - Hit.Time), ref Hit);
			        return;
		        }
		        // notify script that pawn ran into a wall
		        processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
		        if ( Physics == PHYS_Falling )
			        return;

		        //adjust and try again
		        Hit.Normal.Z = 0f;	// treat barrier as vertical;
		        Hit.Normal = Hit.Normal.SafeNormal();
		        FVector NewDelta = Delta;
		        FVector OldHitNormal = Hit.Normal;
		        NewDelta = (Delta - Hit.Normal * (Delta | Hit.Normal)) * (1f - Hit.Time);
		        if( (NewDelta | Delta) >= 0f )
		        {
			        GWorld.MoveActor(this, NewDelta, Rotation, 0, ref Hit);
			        if (Hit.Time < 1f)
			        {
				        processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
				        if ( Physics == PHYS_Falling )
					        return;
				        TwoWallAdjust(DesiredDir, ref NewDelta, Hit.Normal, OldHitNormal, Hit.Time);
				        GWorld.MoveActor(this, NewDelta, Rotation, 0, ref Hit);
			        }
		        }
	        }
	        if ( bStepDown )
	        {
		        GWorld.MoveActor(this, Down, Rotation, 0, ref Hit);
	        }
        }
        
        public virtual unsafe void physFlying(FLOAT deltaTime, INT Iterations)
		{
			FVector AccelDir;

			if( Acceleration.IsZero() )
			{
				AccelDir = Acceleration;
			}
			else
			{
				AccelDir = Acceleration.SafeNormal();
			}

			CalcVelocity(ref AccelDir, deltaTime, AirSpeed, 0.5f * PhysicsVolume.FluidFriction, 1, 0, 0);

			Iterations++;
			bJustTeleported = false;

			FVector OldLocation = Location;
			FVector Adjusted = (Velocity + PhysicsVolume.ZoneVelocity) * deltaTime;
			
			//DEBUGPHYSONLY(debugf(TEXT("%3.3f [%s] physFlying OriginalMove: %s, Adjusted: %s"), GWorld.GetTimeSeconds(), *GetName(), *(Velocity*deltaTime).ToString(), *Adjusted.ToString());)
			
			CheckResult Hit = new CheckResult(1f);
			GWorld.MoveActor(this, Adjusted, Rotation, 0, ref Hit);

			if( Hit.Time < 1f )
			{
				//DEBUGPHYSONLY(debugf(TEXT("-- hit %s"),Hit.Actor != null ? *Hit.Actor.GetName() : TEXT("NULL"));)
				Floor = Hit.Normal;
				FVector GravDir = FVector(0,0,-1);
				FVector DesiredDir = Adjusted.SafeNormal();
				FVector VelDir = Velocity.SafeNormal();
				FLOAT UpDown = GravDir | VelDir;
				
				if( (Abs(Hit.Normal.Z) < 0.2f) && (UpDown < 0.5f) && (UpDown > -0.2f) )
				{
					FLOAT stepZ = Location.Z;
					stepUp(GravDir, DesiredDir, Adjusted * (1f - Hit.Time), ref Hit);
					OldLocation.Z = Location.Z + (OldLocation.Z - stepZ);
				}
				else
				{
					processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
					//adjust and try again
					FVector OldHitNormal = Hit.Normal;
					FVector Delta = (Adjusted - Hit.Normal * (Adjusted | Hit.Normal)) * (1f - Hit.Time);
					if( (Delta | Adjusted) >= 0 )
					{
						GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
						
						if( Hit.Time < 1f ) //hit second wall
						{
							processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
							TwoWallAdjust(DesiredDir, ref Delta, Hit.Normal, OldHitNormal, Hit.Time);
							GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
						}
					}
				}
			}
			else
			{
				Floor = FVector(0f,0f,1f);
			}

			if( !bJustTeleported )
			{
				Velocity = (Location - OldLocation) / deltaTime;
				//DEBUGPHYSONLY( debugf(TEXT("%3.3f [%s] physFlying Adjusted velocity to: %s, DeltaMove: %s"), GWorld.GetTimeSeconds(), *GetName(), *Velocity.ToString(), *(Velocity*deltaTime).ToString()); )
			}
		}
        
        public virtual unsafe void physSpider(FLOAT deltaTime, INT Iterations)
		{
			NativeMarkers.MarkUnimplemented();
			/*
			if( !Controller )
			{
				return;
			}
			if( Floor.IsNearlyZero() && 
				!findNewFloor( Location, deltaTime, deltaTime, Iterations ) )
			{
				return;
			}


			FVector AccelDir = Acceleration.SafeNormal();
			CalcVelocity( AccelDir, deltaTime, GroundSpeed, PhysicsVolume.GroundFriction, 0, 1, 0 );
			FLOAT Mag = Velocity.Size();
			Velocity = (Velocity - Floor * (Floor | Velocity)).SafeNormal() * Mag;
			

			FVector DesiredMove = Velocity;
			Iterations++;

			//-------------------------------------------------------------------------------------------
			//Perform the move
			CheckResult Hit = new CheckResult(1f);
			FVector OldLocation = Location;
			bJustTeleported = 0;

			FLOAT remainingTime = deltaTime;
			FLOAT timeTick;
			FLOAT MaxStepHeightSq = MaxStepHeight * MaxStepHeight;
			while ( (remainingTime > 0f) && (Iterations < 8) )
			{
				Iterations++;

				// Subdivide moves to be no longer than 0.05 seconds for players, or no longer than the collision radius for non-players
				if( remainingTime > 0.05f && 
						(IsHumanControlled() ||
							(DesiredMove.SizeSquared() * remainingTime * remainingTime > 
							 Min(CylinderComponent.CollisionRadius * CylinderComponent.CollisionRadius, MaxStepHeightSq))) )
				{
						timeTick = Min(0.05f, remainingTime * 0.5f);
				}
				else 
				{
					timeTick = remainingTime;
				}

				remainingTime -= timeTick;
				FVector Delta = timeTick * DesiredMove;
				FVector subLoc = Location;
				UBOOL bZeroMove = Delta.IsNearlyZero();

				if( bZeroMove )
				{
					// If not moving, quick check if still on valid floor
					remainingTime = 0;
					FVector Foot = Location - CylinderComponent.CollisionHeight * Floor;
					GWorld.SingleLineCheck( Hit, this, Foot - 20 * Floor, Foot, TRACE_World );
					FLOAT FloorDist = Hit.Time * 20;
					bZeroMove = ((Base == Hit.Actor) && (FloorDist <= MAXFLOORDIST + CYLINDERREPULSION) && (FloorDist >= MINFLOORDIST + CYLINDERREPULSION));
				}
				else
				{
					// try to move forward
					GWorld.MoveActor( this, Delta, Rotation, 0, Hit );


					// If we bumped into something besides a pawn
					if( Hit.Time < 1f && (!Hit.Actor || !Hit.Actor.GetAPawn()) )
					{
						// hit a barrier, try to step up
						FVector DesiredDir = Delta.SafeNormal();
						SpiderstepUp(DesiredDir, Delta * (1f - Hit.Time), Hit);
					}

					if ( Physics == PHYS_Swimming ) //just entered water
					{
						startSwimming(OldLocation, Velocity, timeTick, remainingTime, Iterations);
						return;
					}
				}

				if( !bZeroMove )
				{
					//drop to floor
					FVector ColLocation = CollisionComponent ? Location + CollisionComponent.Translation : Location;
					GWorld.SingleLineCheck( Hit, this, ColLocation - Floor * (MaxStepHeight + MAXSTEPHEIGHTFUDGE), ColLocation, TRACE_AllBlocking, GetCylinderExtent() );
					if ( Hit.Time == 1f )
					{
						GWorld.MoveActor(this, -8f * Floor, Rotation, 0, Hit);
						// find new floor or fall
						if( !findNewFloor(Location, deltaTime, deltaTime, Iterations) )
						{
							return;
						}
					}
					else
					{
						Floor = Hit.Normal;
						GWorld.MoveActor(this, -1f * Floor * (MaxStepHeight + MAXSTEPHEIGHTFUDGE), Rotation, 0, Hit);

						if ( Hit.Actor != Base )
						{
							SetBase(Hit.Actor, Hit.Normal);
						}
					}
				}
			}

			// make velocity reflect actual move
			if( !bJustTeleported )
			{
				Velocity = (Location - OldLocation) / deltaTime;
			}

			if( Controller )
			{
				Controller.PostPhysSpider( deltaTime );
			}*/
		}
        
        public virtual unsafe void physLadder(FLOAT deltaTime, INT Iterations)
		{
			Iterations++;
			FLOAT remainingTime = deltaTime;
			LadderVolume OldLadder = OnLadder;
			Velocity = FVector(0f,0f,0f);

			if ( OnLadder && Controller && !Acceleration.IsZero() )
			{
				CheckResult Hit = new CheckResult(1f);
				UBOOL bClimbUp = ((Acceleration | (OnLadder.ClimbDir + OnLadder.LookDir)) > 0f);
				// First, push into ladder
				if ( !OnLadder.bNoPhysicalLadder && bClimbUp )
				{
					Velocity = OnLadder.LookDir * GroundSpeed;
					GWorld.MoveActor(this, OnLadder.LookDir * remainingTime * GroundSpeed, Rotation, 0, ref Hit);
					remainingTime = remainingTime * (1f - Hit.Time);
					if ( !OnLadder )
					{
						if ( PhysicsVolume.bWaterVolume )
							setPhysics((byte)PHYS_Swimming);
						else
							setPhysics((byte)PHYS_Walking);
						startNewPhysics(remainingTime, Iterations);
						return;
					}
					if ( remainingTime == 0f )
						return;
				}
				FVector AccelDir = Acceleration.SafeNormal();
				Velocity = FVector(0f,0f,0f);

				// set up or down movement velocity
				if ( !OnLadder.bAllowLadderStrafing || (Abs(AccelDir | OnLadder.ClimbDir) > 0.1f) )
				Velocity = OnLadder.ClimbDir * LadderSpeed;
				if ( !bClimbUp )
					Velocity *= -1f;

				// support moving sideways on ladder
				if ( OnLadder.bAllowLadderStrafing )
				{
					FVector LeftDir = OnLadder.LookDir ^ OnLadder.ClimbDir;
					LeftDir = LeftDir.SafeNormal();
					Velocity += (LeftDir | AccelDir) * LeftDir * LadderSpeed;
				}

				FVector MoveDir = Velocity * remainingTime;

				// move along ladder
				GWorld.MoveActor(this, MoveDir, Rotation, 0, ref Hit);
				remainingTime = remainingTime * (1f - Hit.Time);

				if ( !OnLadder )
				{
					//Moved out of ladder, try to step onto ledge
					if ( MoveDir.Z * GetGravityZ() > 0f )
					{
						setPhysics(PHYS_Falling);
						return;
					}
					FVector Out = MoveDir.SafeNormal();
					Out *= 1.1f * CylinderComponent.CollisionHeight;
					GWorld.MoveActor(this, Out, Rotation, 0, ref Hit);
					GWorld.MoveActor(this, 0.5f * OldLadder.LookDir * CylinderComponent.CollisionRadius, Rotation, 0, ref Hit);
					GWorld.MoveActor(this, -1f * (Out + MoveDir), Rotation, 0, ref Hit);
					GWorld.MoveActor(this, (-0.5f * CylinderComponent.CollisionRadius + LADDEROUTPUSH) * OldLadder.LookDir , Rotation, 0, ref Hit);
					Velocity = FVector(0,0,0);
					if ( PhysicsVolume.bWaterVolume )
						setPhysics(PHYS_Swimming);
					else
						setPhysics(PHYS_Walking);
					startNewPhysics(remainingTime, Iterations);
					return;
				}	
				else if ( (Hit.Time < 1f) && Hit.Actor.bWorldGeometry )
				{
					// hit ground
					FVector OldLocation = Location;
					MoveDir = OnLadder.LookDir * GroundSpeed * remainingTime;
					if ( !bClimbUp )
						MoveDir *= -1f;

					// try to move along ground
					GWorld.MoveActor(this, MoveDir, Rotation, 0, ref Hit);
					if ( Hit.Time < 1f )
					{
						FVector GravDir = FVector(0,0,-1);
						FVector DesiredDir = MoveDir.SafeNormal();
						stepUp(GravDir, DesiredDir, MoveDir, ref Hit);
						if ( OnLadder && (Physics != PHYS_Ladder) )
							setPhysics(PHYS_Ladder);
					}
					Velocity = (Location - OldLocation)/remainingTime;
				}
				else if ( !OnLadder.bNoPhysicalLadder && !bClimbUp )
				{
					FVector ClimbDir = OnLadder.ClimbDir;
					FVector PushDir = OnLadder.LookDir;
					GWorld.MoveActor(this, -1f * ClimbDir * MaxStepHeight, Rotation, 0, ref Hit);
					FLOAT Dist = Hit.Time * MaxStepHeight;
					if ( Hit.Time == 1f )
						GWorld.MoveActor(this, PushDir * deltaTime * GroundSpeed, Rotation, 0, ref Hit);
					GWorld.MoveActor(this, ClimbDir * Dist, Rotation, 0, ref Hit);
					if ( !OnLadder )
					{
						if ( PhysicsVolume.bWaterVolume )
							setPhysics(PHYS_Swimming);
						else
							setPhysics(PHYS_Walking);
					}
				}
			}
			
			if ( !Controller )
				setPhysics(PHYS_Falling);

		}
        
        public override unsafe void performPhysics(FLOAT DeltaSeconds)
		{
			CheckStillInWorld();

			if( bDeleteMe )
			{
				return;
			}

			// make sure we have a valid physicsvolume (level streaming might kill it)
			if (PhysicsVolume == null)
			{
				SetZone(FALSE, FALSE);
			}

			FVector OldVelocity = Velocity;
			OldZ = Location.Z;	// used for eyeheight smoothing

			if( Physics != PHYS_Walking )
			{
				// only crouch while walking
				if( Physics != PHYS_Falling && bIsCrouched )
				{
					UnCrouch();
				}
			}
			else if( bWantsToCrouch && bCanCrouch ) 
			{
				// players crouch by setting bWantsToCrouch to true
				if( !bIsCrouched )
				{
					Crouch();
				}
				else if( bTryToUncrouch )
				{
					UncrouchTime -= DeltaSeconds;
					if( UncrouchTime <= 0f )
					{
						bWantsToCrouch = FALSE;
						bTryToUncrouch = FALSE;
					}
				}
			}

			// change position
			startNewPhysics(DeltaSeconds,0);

			// Pawn has moved, post process this movement.
			PostProcessPhysics(DeltaSeconds, OldVelocity);

			bSimulateGravity = ((Physics == PHYS_Falling) || (Physics == PHYS_Walking));

			// uncrouch if no longer desiring crouch
			// or if not in walking physics
			if( bIsCrouched && ((Physics != PHYS_Walking && Physics != PHYS_Falling) || !bWantsToCrouch))
			{
				UnCrouch();
			}

			if( Controller )
			{
				Controller.MoveTimer -= DeltaSeconds;
				if (Physics != PHYS_RigidBody && Physics != PHYS_Interpolating)
				{
					physicsRotation(DeltaSeconds, OldVelocity);
				}
			}

			AvgPhysicsTime = 0.8f * AvgPhysicsTime + 0.2f * DeltaSeconds;

			if( PendingTouch )
			{
				PendingTouch.PostTouch(this);
				if( PendingTouch )
				{
					Actor OldTouch = PendingTouch;
					PendingTouch = PendingTouch.PendingTouch;
					OldTouch.PendingTouch = null;
				}
			}
		}

        /** Called in PerformPhysics(), after StartNewPhysics() is done moving the Actor, and before the PendingTouch() event is dispatched. */
        public void PostProcessPhysics( FLOAT DeltaSeconds, in FVector OldVelocity ) {}
        
        public override void physWalking(FLOAT deltaTime, INT Iterations)
		{
			NativeMarkers.MarkUnimplemented();
		}
        
		public virtual unsafe void startNewPhysics(FLOAT deltaTime, INT Iterations)
		{
			if ( (deltaTime < 0.0003f) || (Iterations > 7) )
				return;
			switch (Physics)
			{
				case PHYS_None: return;
				case PHYS_Walking: physWalking(deltaTime, Iterations); break;
				case PHYS_Falling: physFalling(deltaTime, Iterations); break;
				case PHYS_Flying: physFlying(deltaTime, Iterations); break;
				case PHYS_Swimming: physSwimming(deltaTime, Iterations); break;
				case PHYS_Spider: physSpider(deltaTime, Iterations); break;
				case PHYS_Ladder: physLadder(deltaTime, Iterations); break;
				case PHYS_RigidBody: physRigidBody(deltaTime); break;
				case PHYS_SoftBody: NativeMarkers.MarkUnimplemented(); break;//physSoftBody(deltaTime); break;
				case PHYS_Interpolating: physInterpolating(deltaTime); break;
				default:
					//debugf(NAME_Warning, TEXT("%s has unsupported physics mode %d"), *GetName(), INT(Physics));
					setPhysics(PHYS_None);
					break;
			}
		}
		
		public FLOAT MaxSpeedModifier()
		{
			FLOAT Result = 1f;

			if( !IsHumanControlled() )
			{
				Result *= DesiredSpeed;
			}

			if( bIsCrouched )
			{
				Result *= CrouchedPct;
			}
			else if( bIsWalking )
			{
				Result *= WalkingPct;
			}

			return Result;
		}
		
		public UBOOL ReachedDestination(in FVector TestPosition, in FVector Dest, Actor GoalActor)
		{
			if ( GoalActor && (!Controller || !Controller.bAdjusting) )
			{
				return GoalActor.ReachedBy(this, TestPosition, Dest);
			}

			return ReachThresholdTest(TestPosition, Dest, null, 0f, 0f, 0f);
		}
		
		public override UBOOL IgnoreBlockingBy( Actor Other )
		{
			return ((Physics == PHYS_RigidBody && Other.bIgnoreRigidBodyPawns) || (bIgnoreEncroachers && Other.IsEncroacher()));
		}
		
		/** 
		 * CalcVelocity()
		 * Calculates new velocity and acceleration for pawn for this tick
		 * bounds acceleration and velocity, adds effects of friction and momentum
		 * @param	AccelDir	Acceleration direction. (Normalized vector).
		 * @param	DeltaTime	time elapsed since last frame.
		 * @param	MaxSpeed	Maximum speed Pawn can go at. (f.e. Pawn.GroundSpeed for walking physics).
		 * @param	Friction	friction
		 * @param	bFluid		bFluid
		 * @param	bBrake		if should brake to a stop when acceleration is zero.
		 * @param	bBuoyant	Apply buoyancy for swimming physics
		 */
		public virtual unsafe void CalcVelocity(ref Vector AccelDir, FLOAT DeltaTime, FLOAT MaxSpeed, FLOAT Friction, INT bFluid, INT bBrake, INT bBuoyant)
		{
			AngularVelocity = FVector(0f);

			// bForceRMVelocity is set when replaying moves that used root motion derived velocity on a client in a network game
			// the velocity can't be derived again, since the animation state isn't saved.
			if ( bForceRMVelocity )
			{
				Velocity = RMVelocity;
				return;
			}

			/** 
			 * In order to be able to do Root Motion Mode velocity, Animations must have been processed once.
			 * So we check for PreviousRMM to be up to date with the current root motion mode.
			 * We need to do this to get a valid motion.
			 */
			UBOOL bDoRootMotionVelocity	= (Mesh && Mesh.RootMotionMode == RMM_Velocity && Mesh.PreviousRMM != RMM_Ignore && !bForceRegularVelocity);
			UBOOL bDoRootMotionAccel		= (Mesh && Mesh.RootMotionMode == RMM_Accel && Mesh.PreviousRMM != RMM_Ignore && !bForceRegularVelocity);
			UBOOL	bDoRootMotion			= (bDoRootMotionVelocity ||  bDoRootMotionAccel);

			/** 
			 * Root Motion Magnitude.
			 */
			FVector	RootMotionTranslation	= bDoRootMotion ? Mesh.RootMotionDelta.Translation : FVector(0f);	
			FLOAT		RootMotionMag			= bDoRootMotion ? (RootMotionTranslation.Size() / DeltaTime) : 0f;

			// if we're using root motion, then clear accumulated root motion
			// See USkeletalMeshComponent::UpdateSkelPose() for details.
			if( bDoRootMotion )
			{
				Mesh.RootMotionDelta.Translation = FVector(0f);
			}

			// Scale MaxSpeed and AccelRate.
			FLOAT SpeedModifier = MaxSpeedModifier();

			/** 
			 * When using root motion mode velocity, use that to limit the max acceleration allowed.
			 * This helps the Pawn catch up quicker with RootMotion Velocity when it is very irregular.
			 * Otherwise when it drops really low, it takes a while for the velocity to catch with a much higher value.
			 * We don't want to force the velocity to match root motion, since we want to keep code control on movement.
			 */
			FLOAT MaxAccel = bDoRootMotionAccel ? (RootMotionMag / DeltaTime) : (bDoRootMotionVelocity ? Max(AccelRate * SpeedModifier, (RootMotionMag / DeltaTime)) : AccelRate * SpeedModifier);

			// Adjust MaxSpeed by Root Motion or SpeedModifier.
			MaxSpeed = bDoRootMotion ? RootMotionMag : MaxSpeed * SpeedModifier;

			// Debug RootMotionVelocity
			/*DEBUGPHYSONLY
			(
				if( bDoRootMotionVelocity )
				{
					debugf(TEXT("%3.3f [%s] bDoRootMotionVelocity MaxSpeed: %3.2f"), GWorld.GetTimeSeconds(), *GetName(), MaxSpeed);
				}
			)*/

			// Drive velocity by destination
			// This doesn't work with Root Motion Accel
			if( !bDoRootMotionAccel && Controller && Controller.bPreciseDestination )
			{
				// check to see if we've reached the destination
				if( ReachedDestination(Location, Controller.Destination, null) )
				{
					Controller.bPreciseDestination = FALSE;

					// clear velocity/accel, otherwise it's possible to continue drifting
					Velocity		= FVector(0f);
					Acceleration	= FVector(0f);
				}
				else
				if( bForceMaxAccel )
				{
					FVector Dir = (Controller.Destination - Location).SafeNormal();
					Acceleration = Dir * MaxAccel;
					Velocity	 = Dir * MaxSpeed;
				}
				else
				{
					// otherwise calculate velocity towards the destination
					Velocity = (Controller.Destination - Location) / DeltaTime;
				}
				RMVelocity = Velocity;
			}
			else
			{
				// check to see if acceleration is being driven by animation
				if( bDoRootMotionAccel )
				{
					Velocity		= RootMotionTranslation / DeltaTime;
					AccelDir		= Velocity.SafeNormal();
					Acceleration	= Velocity / DeltaTime;
					RMVelocity		= Velocity;

					//DEBUGPHYSONLY(debugf(TEXT("%3.3f [%s] bDoRootMotionAccel Move: %3.3f, Vect: %s"), GWorld.GetTimeSeconds(), *GetName(), Velocity.Size() * DeltaTime, *(Velocity*DeltaTime).ToString());)
					return;
				}

				// Force acceleration at full speed.
				// In condideration order for direction: Acceleration, then Velocity, then Pawn's rotation.
				if( bForceMaxAccel )
				{
					if( !Acceleration.IsNearlyZero() )
					{
						Acceleration	= AccelDir * MaxAccel;
						//DEBUGPHYSONLY( debugf(TEXT("%3.3f [%s] bForceMaxAccel picked from Acceleration. Acceleration: %s"), GWorld.GetTimeSeconds(), *GetName(), *Acceleration.ToString()); )
					}
					else if( !Velocity.IsNearlyZero() )
					{
						Acceleration	= Velocity.SafeNormal() * MaxAccel;
						AccelDir		= Acceleration.SafeNormal();
						//DEBUGPHYSONLY( debugf(TEXT("%3.3f [%s] bForceMaxAccel picked from Velocity. Acceleration: %s"), GWorld.GetTimeSeconds(), *GetName(), *Acceleration.ToString()); )
					}
					else
					{
						Acceleration	= Rotation.Vector() * MaxAccel;
						AccelDir		= Acceleration.SafeNormal();
						//DEBUGPHYSONLY( debugf(TEXT("%3.3f [%s] bForceMaxAccel picked from Rotation. Acceleration: %s"), GWorld.GetTimeSeconds(), *GetName(), *Acceleration.ToString()); )
					}
				}
				// If doing root motion velocity, make sure Acceleration is high enough to match root motion velocity
				// Only adjust acceleration if it is non zero (this means player wants to stop to a break).
				else if( bDoRootMotionVelocity && !Acceleration.IsNearlyZero() )
				{
					Acceleration = AccelDir * MaxAccel;
				}

				//DEBUGPHYSONLY(debugf(TEXT("%3.3f [%s] bForceMaxAccel: %d, Accel Mag: %3.2f, Accel Vect: %s"), GWorld.GetTimeSeconds(), *GetName(), bForceMaxAccel, Acceleration.Size(), *Acceleration.ToString());)

				if( bBrake.AsBool() && Acceleration.IsZero() )
				{
						FVector OldVel = Velocity;
							FVector SumVel = FVector(0);

					// subdivide braking to get reasonably consistent results at lower frame rates
					// (important for packet loss situations w/ networking)
							FLOAT RemainingTime = DeltaTime;
						FLOAT TimeStep		= 0.03f;

					while( RemainingTime > 0f )
					{
						FLOAT dt = ((RemainingTime > TimeStep) ? TimeStep : RemainingTime);
						RemainingTime -= dt;

						// don't drift to a stop, brake
						Velocity = Velocity - (2f * Velocity) * dt * Friction; 
						if( (Velocity | OldVel) > 0f )
						{
							SumVel += dt * Velocity/DeltaTime;
						}
					}

					Velocity = SumVel;
					
					// brake to a stop, not backwards
					if( ((OldVel | Velocity) < 0f)	|| (Velocity.SizeSquared() < SLOWVELOCITYSQUARED) )
					{
						Velocity = FVector(0f);
					}
				}
				else
				{
					if( Acceleration.SizeSquared() > MaxAccel * MaxAccel )
					{
						Acceleration = Acceleration.SafeNormal() * MaxAccel;
					}
					FLOAT VelSize = Velocity.Size();
					Velocity = Velocity - (Velocity - AccelDir * VelSize) * DeltaTime * Friction;
				}

				Velocity = Velocity * (1 - bFluid * Friction * DeltaTime) + Acceleration * DeltaTime;

				if( bBuoyant.AsBool() )
				{
					Velocity.Z += GetGravityZ() * DeltaTime * (1f - Buoyancy);
				}
			}

			// Make sure velocity does not exceed MaxSpeed
			if( Velocity.SizeSquared() > MaxSpeed * MaxSpeed )
			{
				Velocity = Velocity.SafeNormal() * MaxSpeed;
			}

			RMVelocity	= Velocity;

			//DEBUGPHYSONLY(debugf(TEXT("%3.3f [%s] CalcVelocity MaxSpeed: %3.2f, Vel Mag: %3.2f, Vel Vect: %s"), GWorld.GetTimeSeconds(), *GetName(), MaxSpeed, Velocity.Size(), *Velocity.ToString());)
		}
		
		public override void GetBoundingCylinder(ref FLOAT CollisionRadius, ref FLOAT CollisionHeight)
		{
			// if we are a template, no components will be attached and the default implementation of calling GetComponentsBoundingBox() will do nothing
			// so use our CylinderComponent instead if possible
			if (CylinderComponent != CollisionComponent && IsTemplate() && CylinderComponent != NULL)
			{
				CollisionRadius = CylinderComponent.CollisionRadius;
				CollisionHeight = CylinderComponent.CollisionHeight;
			}
			else
			{
				base.GetBoundingCylinder(ref CollisionRadius, ref CollisionHeight);
			}
		}
		
		public UBOOL ReachThresholdTest(in FVector TestPosition, in FVector Dest, Actor GoalActor, FLOAT UpThresholdAdjust, FLOAT DownThresholdAdjust, FLOAT ThresholdAdjust)
		{
			// get the pawn's normal height (might be crouching or a Scout, so use the max of current/default)
			 FLOAT PawnFullHeight = Max(CylinderComponent.CollisionHeight, ((Pawn)(Class.GetDefaultObject(0))).CylinderComponent.CollisionHeight);
			FLOAT UpThreshold = UpThresholdAdjust + PawnFullHeight + PawnFullHeight - CylinderComponent.CollisionHeight;
			FLOAT DownThreshold = DownThresholdAdjust + CylinderComponent.CollisionHeight;
			FLOAT Threshold = ThresholdAdjust + CylinderComponent.CollisionRadius;

			FVector Dir = Dest - TestPosition;

			if ( GoalActor )
				Threshold += DestinationOffset;

			// give gliding pawns more leeway
			if ( !bCanStrafe && ((Physics == PHYS_Flying) || (Physics == PHYS_Swimming)) 
				&& ((Velocity | Dir) < 0f) )
			{
				UpThreshold = 2f * UpThreshold;
				DownThreshold = 2f * DownThreshold;
				Threshold = 2f * Threshold;
			}
			else if ( Physics == PHYS_RigidBody )
			{
				if ( GoalActor )
				{
					FLOAT GoalRadius = 0, GoalHeight = 0;
					GoalActor.GetBoundingCylinder(ref GoalRadius, ref GoalHeight);
					UpThreshold = Max(UpThreshold, GoalHeight);
				}
				UpThreshold = Max(UpThreshold, CylinderComponent.CollisionHeight);
				DownThreshold = Max(3f * CylinderComponent.CollisionHeight, DownThreshold);
			}

			FLOAT Zdiff = Dir.Z;
			Dir.Z = 0f;
			if ( Dir.SizeSquared() > Threshold * Threshold )
				return false;

			if ( (Zdiff > 0f) ? (Abs(Zdiff) > UpThreshold) : (Abs(Zdiff) > DownThreshold) )
			{
				if ( (Zdiff > 0f) ? (Abs(Zdiff) > 2f * UpThreshold) : (Abs(Zdiff) > 2f * DownThreshold) )
					return false;

				// Check if above or below because of slope
				CheckResult Hit = new CheckResult(1f);
				UBOOL bCheckSlope = false;
				if ( (Zdiff < 0f) && (CylinderComponent.CollisionRadius > CylinderComponent.CollisionHeight) )
				{
					// if wide pawn, use a smaller trace down and check for overlap 
					GWorld.SingleLineCheck( ref Hit, this, TestPosition - FVector(0f,0f,CylinderComponent.CollisionHeight), TestPosition, (int)TRACE_World, FVector(CylinderComponent.CollisionHeight,CylinderComponent.CollisionHeight,CylinderComponent.CollisionHeight));
					bCheckSlope = ( Hit.Time < 1f );
					Zdiff = Dest.Z - Hit.Location.Z;
				}
				else
				{
					// see if on slope
					GWorld.SingleLineCheck( ref Hit, this, TestPosition - FVector(0f,0f,LEDGECHECKTHRESHOLD+MAXSTEPHEIGHTFUDGE), TestPosition, (int)TRACE_World, FVector(CylinderComponent.CollisionRadius,CylinderComponent.CollisionRadius,CylinderComponent.CollisionHeight));
					bCheckSlope = ( (Hit.Normal.Z < 0.95f) && (Hit.Normal.Z >= WalkableFloorZ) );
				}
				if ( bCheckSlope )
				{
					// check if above because of slope
					if ( (Zdiff < 0f)
						&& (Zdiff * -1f < PawnFullHeight + CylinderComponent.CollisionRadius * sqrt(1f/(Hit.Normal.Z * Hit.Normal.Z) - 1f)) )
					{
						return true;
					}
					else
					{
						// might be below because on slope
						FLOAT adjRad = 0f;
						if ( GoalActor )
						{
							FLOAT GoalHeight = 0;
							GoalActor.GetBoundingCylinder(ref adjRad, ref GoalHeight);
						}
						else
						{
							NavigationPoint DefaultNavPoint = ClassT<NavigationPoint>().DefaultAs<NavigationPoint>(); //(NavigationPoint)ANavigationPoint::StaticClass()->GetDefaultActor();
							adjRad = DefaultNavPoint.CylinderComponent.CollisionRadius;
						}
						if ( (CylinderComponent.CollisionRadius < adjRad)
							&& (Zdiff < PawnFullHeight + (adjRad + 15f - CylinderComponent.CollisionRadius) * sqrt(1f/(Hit.Normal.Z * Hit.Normal.Z) - 1f)) )
						{
							return true;
						}
					}
				}
				return false;
			}
			return true;
		}
		
		public override unsafe void processHitWall(FVector HitNormal, Actor HitActor, PrimitiveComponent HitComp)
		{
			if ( !HitActor )
			{
				return;
			}

			PortalTeleporter Portal = HitActor.GetAPortalTeleporter();
			if (Portal != null && Portal.TransformActor(this))
			{
				return;
			}

			// if we have both a controller and that controller has a pawn
			FVector DesiredDir = (Controller && Controller.Pawn) ? Controller.DesiredDirection() : Velocity;
			Pawn HitPawn = HitActor.GetAPawn();
			if (HitPawn != null)
			{
				if ( !Controller || (Physics == PHYS_Falling) || !(HitActor as Vehicle) )
					return;
				if ( Controller.NotifyHitWall(HitNormal, HitActor) )
					return;
				FVector Cross = DesiredDir ^ FVector(0f,0f,1f);
				FLOAT ColRadius = HitPawn.CylinderComponent 
									? HitPawn.CylinderComponent.CollisionRadius
									: 100f;
				FVector Dir = 1.2f * ColRadius * Cross.SafeNormal();
				if ( (Cross | DesiredDir) < 0f )
					Dir *= -1f;
				if ( appFrand() < 0.3f )
					Dir *= -2f;
				FVector AdjustLoc = Location + Dir;
				CheckResult Hit = new CheckResult(1.0f);
				if (!GWorld.SingleLineCheck(ref Hit, this, AdjustLoc, Location, (int)TRACE_World))
				{
					FLOAT MyColRadius = CylinderComponent 
										? CylinderComponent.CollisionRadius
										: 100f;
					AdjustLoc = Hit.Location - (Dir.SafeNormal() * MyColRadius);
				}
				if ( Controller )
				{
					Controller.SetAdjustLocation(AdjustLoc);
				}
				return;		
			}

			if ( !bDirectHitWall && Controller )
			{
				if ( Acceleration.IsZero() )
					return;
				FVector Dir = DesiredDir.SafeNormal();
				if ( Physics == PHYS_Walking )
				{
					HitNormal.Z = 0;
					Dir.Z = 0;
					HitNormal = HitNormal.SafeNormal();
					Dir = Dir.SafeNormal();
				}
				if ( Controller.MinHitWall < (Dir | HitNormal) )
				{
					if ( Controller.bNotifyFallingHitWall && (Physics == PHYS_Falling) )
					{
						FVector OldVel = Velocity;
						Controller.NotifyFallingHitWall(HitNormal, HitActor);
						if ( Velocity != OldVel )
							bJustTeleported = true;
					}
					return;
				}
				// give controller the opportunity to handle the hitwall event instead of the controlled pawn
				if ( Controller.NotifyHitWall(HitNormal, HitActor) )
					return;
				if ( Physics != PHYS_Falling )
				{
					UBOOL bTryCrouch = (Physics == PHYS_Walking) && !IsHumanControlled() && bCanCrouch && !bIsCrouched;
					// try moving crouched stepped up
					if ( bTryCrouch && CanCrouchWalk( Location, Location + CylinderComponent.CollisionRadius*Dir, HitActor) )
						return;
					CheckResult Hit = new CheckResult(1f);
					GWorld.MoveActor(this,FVector(0,0,-1f * MaxStepHeight), Rotation, 0, ref Hit);
					if ( bTryCrouch && CanCrouchWalk( Location, Location + CylinderComponent.CollisionRadius*Dir, HitActor) )
						return;
					if ( Controller && HitActor.bWorldGeometry )
					{
						Controller.AdjustFromWall(HitNormal, HitActor);
					}
				}
				else if ( Controller != null && Controller.bNotifyFallingHitWall )
				{
					FVector OldVel = Velocity;
					Controller.NotifyFallingHitWall(HitNormal, HitActor);
					if ( Velocity != OldVel )
						bJustTeleported = true;
				}
			}
			HitWall(HitNormal, HitActor, HitComp);
		}
		
		public UBOOL CanCrouchWalk( in FVector StartLocation, in FVector EndLocation, Actor HitActor )
		{
			FVector CrouchedOffset = FVector(0.0f,0.0f,CrouchHeight-CylinderComponent.CollisionHeight);

			if( !bCanCrouch )
				return FALSE;

			var TraceFlags = TRACE_World;
			if ( HitActor && !HitActor.bWorldGeometry )
				TraceFlags = TRACE_AllBlocking;

			// quick zero extent trace from start location
			CheckResult Hit = new(1.0f);
			GWorld.SingleLineCheck(
				ref Hit,
				this,
				EndLocation + CrouchedOffset,
				StartLocation + CrouchedOffset,
				(int)(TraceFlags | TRACE_StopAtAnyHit) );

			if( !Hit.Actor )
			{
				// try slower extent trace
				GWorld.SingleLineCheck(
					ref Hit,
					this,
					EndLocation + CrouchedOffset,
					StartLocation + CrouchedOffset,
					(int)TraceFlags,
					FVector(CrouchRadius,CrouchRadius,CrouchHeight) );

				if ( Hit.Time == 1.0f )
				{
					bWantsToCrouch = TRUE;
					bTryToUncrouch = TRUE;
					UncrouchTime = 0.5f;
					return TRUE;
				}
			}
			return FALSE;
		}

		public virtual unsafe void startSwimming(FVector OldLocation, FVector OldVelocity, FLOAT timeTick, FLOAT remainingTime, INT Iterations)
		{
			NativeMarkers.MarkUnimplemented();
			return;
			/*
			if ( !bJustTeleported )
			{
				if ( timeTick > 0f )
					Velocity = (Location - OldLocation)/timeTick; //actual average velocity
				Velocity = 2f * Velocity - OldVelocity; //end velocity has 2* accel of avg
				if (Velocity.SizeSquared() > Square(GetTerminalVelocity()))
				{
					Velocity = Velocity.SafeNormal();
					Velocity *= GetTerminalVelocity();
				}
			}
			FVector End = findWaterLine(Location, OldLocation);
			FLOAT waterTime = 0f;
			if (End != Location)
			{	
				waterTime = timeTick * (End - Location).Size()/(Location - OldLocation).Size();
				remainingTime += waterTime;
				CheckResult Hit = new CheckResult(1f);
				GWorld.MoveActor(this, End - Location, Rotation, 0, Hit);
			}
			if ((Velocity.Z > 2f*SWIMBOBSPEED) && (Velocity.Z < 0f)) //allow for falling out of water
				Velocity.Z = SWIMBOBSPEED - Velocity.Size2D() * 0.7f; //smooth bobbing
			if ( (remainingTime > 0.01f) && (Iterations < 8) )
				physSwimming(remainingTime, Iterations);
			*/
		}
		
		public override unsafe void SetBase( Actor NewBase, FVector NewFloor, int bNotifyActor = 1, SkeletalMeshComponent SkelComp = null, name AttachName = default )
		{
			Floor = NewFloor;
			base.SetBase(NewBase,NewFloor,bNotifyActor,SkelComp,AttachName);
		}
		
		public virtual unsafe FVector CalculateSlopeSlide(ref Vector Adjusted, ref CheckResult Hit)
		{
			FVector Result = (Adjusted - Hit.Normal * (Adjusted | Hit.Normal)) * (1f - Hit.Time);

			// prevent boosting up slopes
			if ( Result.Z > 0f )
			{
				Result.Z = Min(Result.Z, Adjusted.Z * (1f - Hit.Time));
			}
			return Result;
		}
		public override unsafe UBOOL ShouldTrace(PrimitiveComponent Primitive,Actor SourceActor, ETraceFlags TraceFlags)
		{
			return (TraceFlags & TRACE_Pawns) != 0 || (bStationary && (TraceFlags & TRACE_Others) != 0);
		}

/*
GetNetBuoyancy()
determine how deep in water actor is standing:
0 = not in water,
1 = fully in water
*/
		public override unsafe void GetNetBuoyancy(ref FLOAT NetBuoyancy, ref FLOAT NetFluidFriction)
		{
			PhysicsVolume WaterVolume = null;
			FLOAT depth = 0f;

			if ( PhysicsVolume.bWaterVolume )
			{
				FLOAT CollisionHeight = 0, CollisionRadius = 0;
				GetBoundingCylinder(ref CollisionRadius, ref CollisionHeight);

				WaterVolume = PhysicsVolume;
				if ( (CollisionHeight == 0f) || (Buoyancy == 0f) )
					depth = 1f;
				else
				{
					CheckResult Hit = new CheckResult(1f);
					if ( PhysicsVolume.CollisionComponent )
						PhysicsVolume.CollisionComponent.LineCheck(ref Hit,
							Location - FVector(0f,0f,CollisionHeight),
							Location + FVector(0f,0f,CollisionHeight),
							FVector(0f,0f,0f),
							0);
					if ( Hit.Time == 1f )
						depth = 1f;
					else
						depth = (1f - Hit.Time);
				}
			}
			if ( WaterVolume )
			{
				NetBuoyancy = Buoyancy * depth;
				NetFluidFriction = WaterVolume.FluidFriction * depth;
			}
		}
		
		void SetPostLandedPhysics(Actor HitActor, FVector HitNormal)
		{
			if( Health > 0 )
			{
				setPhysics((byte)PHYS_Walking, HitActor, HitNormal);
			}
			else
			{
				setPhysics((byte)PHYS_None, HitActor, HitNormal);
			}
		}
			

		public override unsafe void processLanded(FVector HitNormal, Actor HitActor, FLOAT remainingTime, INT Iterations)
		{
			// We want to make sure that this is a valid landing spot, and not a very small protrusion (like a BSP cut)
			// To do this, we trace down with a slightly smaller box.  If it doesn't hit a floor, we bounce this pawn off of this protrusion
			CheckResult Hit = new CheckResult(1f);
			FVector ColLocation = CollisionComponent ? Location + CollisionComponent.Translation : Location;
			GWorld.SingleLineCheck(ref Hit, this, ColLocation - FVector(0,0,0.2f * CylinderComponent.CollisionHeight + 2f*LEDGECHECKTHRESHOLD),
				ColLocation, (int)(TRACE_AllBlocking|TRACE_StopAtAnyHit), 0.9f * GetCylinderExtent());

			if( Hit.Time == 1f ) //Not a valid landing
			{
				FVector Adjusted = Location;
				if( GWorld.FindSpot(1.1f * GetCylinderExtent(), ref Adjusted, bCollideComplex) && (Adjusted != Location) )
				{
					GWorld.FarMoveActor(this, Adjusted, false, false);
					Velocity.X += 0.2f * GroundSpeed * (appFrand() - 0.5f);
					Velocity.Y += 0.2f * GroundSpeed * (appFrand() - 0.5f);
					//@HACK: increment/handle failure counter to make sure Pawns don't get stuck here
					FailedLandingCount++;
					if (FailedLandingCount > 300)
					{
						TakeDamage(1000, Controller, Location, FVector(0f, 0f, 0f), ClassT<DamageType>());
					}
					else if (FailedLandingCount >= 150 && FailedLandingCount % 50 == 0)
					{
						Velocity.Z = Max(JumpZ, 1f);
					}
					return;
				}
			}
	
			//@HACK: reset failure counter
			FailedLandingCount = 0;

			Floor = HitNormal;
			if( !Controller || !Controller.NotifyLanded(HitNormal, HitActor) )
			{
				Landed(HitNormal, HitActor);
			}

			if( Physics == PHYS_Falling )
			{
				SetPostLandedPhysics(HitActor, HitNormal);
			}
	
			if( Physics == PHYS_Walking )
			{
				Acceleration = Acceleration.SafeNormal();
			}
	
			startNewPhysics(remainingTime, Iterations);

			if( Controller && Controller.bNotifyPostLanded )
			{
				Controller.NotifyPostLanded();
			}
		}
		
		public override void SetZone( UBOOL bTest, UBOOL bForceRefresh )
		{
			if( bDeleteMe )
			{
				return;
			}

			// update physics volume
			PhysicsVolume NewVolume = GWorld.GetWorldInfo().GetPhysicsVolume(Location,this,bCollideActors && !bTest && !bForceRefresh);
			PhysicsVolume NewHeadVolume = GWorld.GetWorldInfo().GetPhysicsVolume(Location + FVector(0,0,BaseEyeHeight),this,bCollideActors && !bTest && !bForceRefresh);
			if ( NewVolume != PhysicsVolume )
			{
				if ( !bTest )
				{
					if ( PhysicsVolume )
					{
						PhysicsVolume.PawnLeavingVolume(this);
						PhysicsVolumeChange(NewVolume);
					}
					if ( Controller )
						Controller.NotifyPhysicsVolumeChange( NewVolume );
				}
				PhysicsVolume = NewVolume;
				if ( !bTest )
					PhysicsVolume.PawnEnteredVolume(this);
			}
			if ( NewHeadVolume != HeadVolume )
			{
				if ( !bTest && (!Controller || !Controller.NotifyHeadVolumeChange(NewHeadVolume)) )
				{
					HeadVolumeChange(NewHeadVolume);
				}
				HeadVolume = NewHeadVolume;
			}
			checkSlow(PhysicsVolume);
		}
		
		public unsafe virtual void Crouch(INT bClientSimulation = 0)
		{
			// Do not perform if collision is already at desired size.
			if( (CylinderComponent.CollisionHeight == CrouchHeight) && (CylinderComponent.CollisionRadius == CrouchRadius) )
			{
				return;
			}

			// Change collision size to crouching dimensions
			FLOAT OldHeight = CylinderComponent.CollisionHeight;
			FLOAT OldRadius = CylinderComponent.CollisionRadius;
			SetCollisionSize(CrouchRadius, CrouchHeight);
			FLOAT HeightAdjust	= OldHeight - CrouchHeight;

			if( !bClientSimulation.AsBool() )
			{
				if ( (CrouchRadius > OldRadius) || (CrouchHeight > OldHeight) )
				{
					FMemMark Mark = new(GMem);
					CheckResult* FirstHit = GWorld.ActorEncroachmentCheck
					(	ref GMem,
						this, 
						Location - FVector(0,0,HeightAdjust), 
						Rotation, 
						(int)(TRACE_Pawns | TRACE_Movers | TRACE_Others) 
					);

					UBOOL bEncroached	= false;
					for( FCheckResult* Test = FirstHit; Test!=null; Test=Test->GetNext() )
					{
						if ( (Test->Actor != this) && IsBlockedBy(Test->Actor,Test->Component) )
						{
							bEncroached = true;
							break;
						}
					}
					Mark.Pop();
					// If encroached, cancel

					if( bEncroached )
					{
						SetCollisionSize(OldRadius, OldHeight);
						return;
					}
				}

				bNetDirty = true;	// bIsCrouched replication controlled by bNetDirty
				bIsCrouched = true;
			}
			bForceFloorCheck = TRUE;
			StartCrouch( HeightAdjust );

		}
		public virtual void physicsRotation(FLOAT deltaTime, FVector OldVelocity)
		{
			if ( !Controller )
				return;
			// always call SetRotationRate() as it may change our DesiredRotation
			FRotator deltaRot = Controller.SetRotationRate(deltaTime);
			if( !bCrawler && (Rotation == DesiredRotation) && !IsHumanControlled() )
				return;

			// Accumulate a desired new rotation.
			FRotator NewRotation = Rotation;	

			if( (Physics == PHYS_Ladder) && OnLadder )
			{
				// must face ladder
				NewRotation = OnLadder.WallDir;
			}
			else
			{
				//YAW
				if( DesiredRotation.Yaw != NewRotation.Yaw )
				{
					NewRotation.Yaw = fixedTurn(NewRotation.Yaw, DesiredRotation.Yaw, deltaRot.Yaw);
				}

				// PITCH
				if( !bRollToDesired && ((Physics == PHYS_Walking) || (Physics == PHYS_Falling)) )
				{
					DesiredRotation.Pitch = 0;
				}
				if( (!bCrawler || (Physics != PHYS_Walking)) && (DesiredRotation.Pitch != NewRotation.Pitch) )
				{
					NewRotation.Pitch = fixedTurn(NewRotation.Pitch, DesiredRotation.Pitch, deltaRot.Pitch);
				}
			}

			// ROLL
			if( bRollToDesired )
			{
				if( DesiredRotation.Roll != NewRotation.Roll )
				{
					NewRotation.Roll = fixedTurn(NewRotation.Roll, DesiredRotation.Roll, deltaRot.Roll);
				}
			}
			else if( bCrawler  )
			{
				if( Physics != PHYS_Walking )
				{
					// Straighten out
					NewRotation.Pitch = fixedTurn(NewRotation.Pitch, 0, deltaRot.Pitch);
					NewRotation.Roll = fixedTurn(NewRotation.Roll, 0, deltaRot.Roll);
				}
				else
				{
					NewRotation = FindSlopeRotation(Floor,NewRotation);
				}
			}
			else
			{
				NewRotation.Roll = 0;
			}

			// Set the new rotation.
			// fixedTurn() returns denormalized results so we must convert Rotation to prevent negative values in Rotation from causing unnecessary MoveActor() calls
			if( NewRotation != Rotation.Denormalize() )
			{
				FCheckResult Hit = new(1f);
				GWorld.MoveActor( this, FVector(0,0,0), NewRotation, 0, ref Hit );
			}
		}
		
		public override FRotator FindSlopeRotation(FVector FloorNormal, FRotator NewRotation)
		{
			if (Physics == PHYS_Spider && Controller )
			{
				Matrix M = Matrix.Identity;
				M.SetAxis( 0, Controller.ViewY ^ Floor );
				M.SetAxis( 1, Controller.ViewY );
				M.SetAxis( 2, Floor );
				return M.Rotator();
			}
			else
				return base.FindSlopeRotation(FloorNormal,NewRotation);
		}
	}
	
	public enum ELevelTick
	{
		LEVELTICK_TimeOnly		= 0,	// Update the level time only.
		LEVELTICK_ViewportsOnly	= 1,	// Update time and viewports.
		LEVELTICK_All			= 2,	// Update all.
	};


	public partial class Actor
	{
		// Export UActor::execSetCollision(FFrame&, void* const)
		public virtual /*native(262) final function */void SetCollision(/*optional */bool bNewCollideActors = false, /*optional */bool bNewBlockActors = false, /*optional */bool? _bNewIgnoreEncroachers = false)
		{
			var bNewIgnoreEncroachers = _bNewIgnoreEncroachers ?? false;
			// Make sure we're calling this function to change something.
			if( ( bCollideActors == bNewCollideActors )
			    && ( bBlockActors == bNewBlockActors )
			    && ( bIgnoreEncroachers == bNewIgnoreEncroachers )
			)
			{
				return;
			}

			/*#if !FINAL_RELEASE
			// Check to see if this move is illegal during this tick group
			if( GWorld->InTick && GWorld->TickGroup == TG_DuringAsyncWork )
			{
				debugf(NAME_Error,TEXT("Can't change collision on actor (%s) during async work!"),*GetName());
			}
			#endif*/

			/*const UBOOL*/var bOldCollideActors = bCollideActors;

			// Untouch everything if we're turning collision off.
			if( bCollideActors && !bNewCollideActors )
			{
				for( int i=0; i<Touching.Num(); )
				{
					if( Touching[i] )
					{
						Touching[i].EndTouch(this, false);
					}
					else
					{
						i++;
					}
				}
			}

			// If the collide actors flag is changing, then all collidable components
			// need to be detached and then reattached
			var bClearAndUpdate = bCollideActors != bNewCollideActors;
			if (bClearAndUpdate)
			{
				// clear only primitive components so we don't needlessly reattach components that never collide
				for (int ComponentIndex = 0; ComponentIndex < Components.Num(); ComponentIndex++)
				{
					PrimitiveComponent Primitive = (Components[ComponentIndex]) as PrimitiveComponent;
					if (Primitive != NULL && Primitive.CollideActors)
					{
						Primitive.ConditionalDetach();
					}
				}
			}
			// Set properties.
			bCollideActors = bNewCollideActors;
			bBlockActors   = bNewBlockActors;
			bIgnoreEncroachers = bNewIgnoreEncroachers;
			// Collision flags changed and collidable components need to be re-added
			if (bClearAndUpdate)
			{
				ConditionalUpdateComponents();
			}

			// Touch.
			if( bNewCollideActors && !bOldCollideActors )
			{
				FindTouchingActors();
			}
			// notify script
			CollisionChanged();
			// dirty this actor for replication
			bNetDirty = TRUE;
		}
		
		public virtual void Spawned()
		{
			SetDefaultCollisionType();
		}
		
		public virtual void SetDefaultCollisionType()
		{
			// default to 'custom' (programmer set nonstandard settings)
			CollisionType = ECollisionType.COLLIDE_CustomDefault;

			if (bCollideActors && CollisionComponent != null && CollisionComponent.CollideActors)
			{
				if (!bBlockActors || CollisionComponent.BlockActors)
				{
					if (CollisionComponent.BlockZeroExtent)
					{
						if (CollisionComponent.BlockNonZeroExtent)
						{
							CollisionType = (bBlockActors && CollisionComponent.BlockActors) ? ECollisionType.COLLIDE_BlockAll : ECollisionType.COLLIDE_TouchAll;
						}
						else
						{
							CollisionType = (bBlockActors && CollisionComponent.BlockActors) ? ECollisionType.COLLIDE_BlockWeapons : ECollisionType.COLLIDE_TouchWeapons;
						}
					}
					else if (CollisionComponent.BlockNonZeroExtent)
					{
						CollisionType = (bBlockActors && CollisionComponent.BlockActors) ? ECollisionType.COLLIDE_BlockAllButWeapons : ECollisionType.COLLIDE_TouchAllButWeapons;
					}
				}
				// else (bBlockActors && !CollisionComponent.BlockActors), we're using some custom collision (e.g. only secondary collision component blocks)
			}
			else if (!bCollideActors && (!CollisionComponent || !CollisionComponent.BlockRigidBody))
			{
				CollisionType = ECollisionType.COLLIDE_NoCollision;
			}

			// match mirrored BlockRigidBody flag
			if (CollisionComponent != null)
			{
				BlockRigidBody = CollisionComponent.BlockRigidBody;
			}

			// also make sure archetype CollisionType is set so that it only shows up bold in the property window if it has actually been changed
			/*Actor TemplateActor = GetArchetype<AActor>(); 
			if (TemplateActor != null)
			{
				TemplateActor.SetDefaultCollisionType();
			}*/ // Not sure what this maps to
		}
		
		public override void InitExecution()
		{
			base.InitExecution();

			/*checkSlow(GetStateFrame());
			checkSlow(GetStateFrame()->Object==this);
			checkSlow(GWorld!=NULL);*/
		}
		
		public virtual void InitRBPhys()
		{
			NativeMarkers.MarkUnimplemented( "Not important, has overrides in Pawn and others" );
		}
		
		public virtual void ConditionalForceUpdateComponents(UBOOL bCollisionUpdate,UBOOL bTransformOnly)
		{
			if ( GIsEditor )
			{
				MarkComponentsAsDirty(bTransformOnly);
			}
			ConditionalUpdateComponents( bCollisionUpdate );
		}
		
		public UBOOL IsTimerActive( name? _FuncName = default, Object inObj = null )
		{
			var FuncName = _FuncName ?? default(name);
			if( !inObj ) { inObj = this; }

			UBOOL Return = FALSE;
			for (INT Idx = 0; Idx < Timers.Num(); Idx++)
			{
				if( Timers[Idx].FuncName == FuncName &&
				    Timers[Idx].TimerObj == inObj )
				{
					Return = (Timers[Idx].Rate > 0f);
					break;
				}
			}
			return Return;
		}
		
		// Export UActor::execGetComponentsBoundingBox(FFrame&, void* const)
		public virtual /*native final function */void GetComponentsBoundingBox(ref Object.Box ActorBox)
		{
			ActorBox = GetComponentsBoundingBox();
		}
		
		public Box GetComponentsBoundingBox(UBOOL bNonColliding = false)
		{
			Box Box = new();

			for(UINT ComponentIndex = 0;ComponentIndex < (UINT)this.Components.Num();ComponentIndex++)
			{
				PrimitiveComponent	primComp = (this.Components[ComponentIndex]) as PrimitiveComponent;

				// Only use collidable components to find collision bounding box.
				if( primComp && primComp.IsAttached() && (bNonColliding || primComp.CollideActors) )
				{
					Box += primComp.Bounds.GetBox();
				}
			}

			return Box;
		}
		
		// Export UActor::execFastTrace(FFrame&, void* const)
		public virtual /*native(548) final function */bool FastTrace(Object.Vector TraceEnd, /*optional */Object.Vector? _TraceStart = default, /*optional */Object.Vector? _BoxExtent = default, /*optional */bool? _bTraceBullet = default)
		{
			//P_GET_VECTOR(TraceEnd);
			var TraceStart = _TraceStart ?? Location;
			var BoxExtent = _BoxExtent ?? FVector(0f,0f,0f);
			var bTraceComplex = /*_bTraceComplex*/_bTraceBullet ??  FALSE;
			//P_FINISH;

			ETraceFlags TraceFlags = TRACE_World|TRACE_StopAtAnyHit;
			if( bTraceComplex )
			{
				TraceFlags |= TRACE_ComplexCollision;
			}

			// Trace the line.
			//LINE_CHECK_TRACE_SCRIPT(TraceFlags, &Stack);
			FCheckResult Hit = new(1f);
			GWorld.SingleLineCheck( ref Hit, this, TraceEnd, TraceStart, (int)TraceFlags, BoxExtent );

			return !Hit.Actor;
		}



		const bool pHitInfo = true; // No idea what that is
		
		// Export UActor::execTrace(FFrame&, void* const)
		public virtual /*native(277) final function */Actor Trace(ref Object.Vector HitLocation, ref Object.Vector HitNormal, Object.Vector TraceEnd, /*optional */Object.Vector? _TraceStart/* = default*/, /*optional */bool? _bTraceActors/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */ref Actor.TraceHitInfo HitInfo/* = default*/, /*optional */int? _ExtraTraceFlags = default)
		{
			//P_GET_VECTOR_REF(HitLocation);
			//P_GET_VECTOR_REF(HitNormal);
			//P_GET_VECTOR(TraceEnd);
			var TraceStart = _TraceStart ?? Location;
			var bTraceActors = _bTraceActors ?? bCollideActors;
			var TraceExtent = _Extent??FVector(0,0,0);
			//var FTraceHitInfo = _HitInfo ?? new TraceHitInfo();	// optional
			var ExtraTraceFlags = _ExtraTraceFlags ?? 0;
			//P_FINISH;

			// Trace the line.
			FCheckResult Hit = new FCheckResult(1.0f);
			ETraceFlags TraceFlags;
			if( bTraceActors )
			{
				TraceFlags = (ExtraTraceFlags & UCONST_TRACEFLAG_Blocking) != 0 ? TRACE_AllBlocking : TRACE_ProjTargets;
			}
			else
			{
				TraceFlags = TRACE_World;
			}

			if( pHitInfo )
			{
				TraceFlags |= TRACE_Material;
			}
			if( (ExtraTraceFlags & UCONST_TRACEFLAG_PhysicsVolumes) != 0 )
			{
				TraceFlags |= TRACE_PhysicsVolumes;
			}
			if( (ExtraTraceFlags & UCONST_TRACEFLAG_Bullet) != 0 )
			{
				TraceFlags |= TRACE_ComplexCollision;
			}
			if( (ExtraTraceFlags & UCONST_TRACEFLAG_SkipMovers) !=0 && (TraceFlags & TRACE_Movers) != 0 )
			{
				TraceFlags -= TRACE_Movers;
			}

			Actor TraceActor = this;
			Controller C = this as Controller;
			if ( C && C.Pawn )
			{
				TraceActor = C.Pawn;
			}

			//If enabled, capture the callstack that triggered this script linecheck
			//LINE_CHECK_TRACE_SCRIPT(TraceFlags, &Stack);
			GWorld.SingleLineCheck( ref Hit, TraceActor, TraceEnd, TraceStart, (int)TraceFlags, TraceExtent );

			//*(Actor**)Result = Hit.Actor;
			HitLocation      = Hit.Location;
			HitNormal        = Hit.Normal;

			if(pHitInfo)
			{
				//DetermineCorrectPhysicalMaterial<FCheckResult, FTraceHitInfo>( Hit, HitInfo );
				NativeMarkers.MarkUnimplemented("DetermineCorrectPhysicalMaterial");

				HitInfo.Material = Hit.Material ? Hit.Material.GetMaterial() : null;

				HitInfo.Item = Hit.Item;
				HitInfo.LevelIndex = Hit.LevelIndex;
				HitInfo.BoneName = Hit.BoneName;
				HitInfo.HitComponent = Hit.Component;
			}
			return Hit.Actor;
		}
	
		// Export UActor::execTraceComponent(FFrame&, void* const)
		public virtual /*native final function */bool TraceComponent(ref Object.Vector HitLocation, ref Object.Vector HitNormal, PrimitiveComponent InComponent, Object.Vector TraceEnd, /*optional */Object.Vector? _TraceStart/* = default*/, /*optional */Object.Vector? _Extent/* = default*/, /*optional */ref Actor.TraceHitInfo HitInfo/* = default*/)
		{
			//P_GET_VECTOR_REF(HitLocation);
			//P_GET_VECTOR_REF(HitNormal);
			//P_GET_OBJECT(UPrimitiveComponent, InComponent);
			//P_GET_VECTOR(TraceEnd);
			var TraceStart = _TraceStart ?? Location;
			var TraceExtent = _Extent ?? FVector(0,0,0);
			//P_GET_STRUCT_OPTX_REF(FTraceHitInfo, HitInfo, FTraceHitInfo());
			//P_FINISH;

			UBOOL bNoHit = TRUE;
			FCheckResult Hit = new(1.0f);

			// Ensure the component is valid and attached before checking the line against it.
			// LineCheck needs a transform and IsValidComponent()==TRUE, both of which are implied by IsAttached()==TRUE.
			if( InComponent != NULL && InComponent.IsAttached() )
			{
				bNoHit = InComponent.LineCheck(ref Hit, TraceEnd, TraceStart, TraceExtent, (int)TRACE_AllBlocking);

				HitLocation      = Hit.Location;
				HitNormal        = Hit.Normal;

				if(pHitInfo)
				{
					//DetermineCorrectPhysicalMaterial<FCheckResult, FTraceHitInfo>( Hit, HitInfo );
					NativeMarkers.MarkUnimplemented("DetermineCorrectPhysicalMaterial");

					HitInfo.Material = Hit.Material ? Hit.Material.GetMaterial() : null;

					HitInfo.Item = Hit.Item;
					HitInfo.LevelIndex = Hit.LevelIndex;
					HitInfo.BoneName = Hit.BoneName;
					HitInfo.HitComponent = Hit.Component;
				}
			}

			return !bNoHit;
		}
	
		// Export UActor::execSetCollisionSize(FFrame&, void* const)
		public virtual /*native(283) final function */void SetCollisionSize(float NewRadius, float NewHeight)
		{
			CylinderComponent CylComp = CollisionComponent as CylinderComponent;

			if(CylComp)
				CylComp.SetCylinderSize(NewRadius, NewHeight);

			UnTouchActors();
			FindTouchingActors();
			// notify script
			CollisionChanged();
			// dirty this actor for replication
			bNetDirty = true;	
		}
	
		// Export UActor::execMove(FFrame&, void* const)
		public virtual /*native(266) final function */bool Move(Object.Vector Delta)
		{
			FCheckResult Hit = new(1.0f);
			return GWorld.MoveActor( this, Delta, Rotation, 0, ref Hit );
		}
		
		public virtual void PostBeginPlay()
		{
			// Send PostBeginPlay.
			eventPostBeginPlay();

			if( bDeleteMe )
				return;

			// Init scripting.
			SetInitialState();

			// Find Base
			if( !Base && bCollideWorld && bShouldBaseAtStartup && ((Physics == PHYS_None) || (Physics == PHYS_Rotating)) )
			{
				FindBase();
			}
		}
		
		// Export UActor::execIsBasedOn(FFrame&, void* const)
		public virtual /*native final function */bool IsBasedOn(Actor Other)
		{
			for( Actor Test=this; Test!=NULL; Test=Test.Base )
				if( Test == Other )
					return true;
			return false;
		}
		
		// Export UActor::execForceUpdateComponents(FFrame&, void* const)
		public virtual /*native function */void ForceUpdateComponents(/*optional */bool? _bCollisionUpdate = default, /*optional */bool? _bTransformOnly = default)
		{
			MarkComponentsAsDirty(_bTransformOnly ?? true);
			ConditionalUpdateComponents( _bCollisionUpdate ?? false );
		}
		
		// Export UActor::execGetTerminalVelocity(FFrame&, void* const)
		public virtual /*native function */float GetTerminalVelocity()
		{
			return PhysicsVolume ? PhysicsVolume.TerminalVelocity :  ClassT<PhysicsVolume>().DefaultAs<PhysicsVolume>().TerminalVelocity;
		}
		// Export UActor::execFindBase(FFrame&, void* const)
		public virtual /*native function */void FindBase()
		{
			FCheckResult Hit = new(1f);
	
			FVector ColLocation = CollisionComponent ? Location + CollisionComponent.Translation : Location;
	
			GWorld.SingleLineCheck(ref Hit, this, ColLocation + FVector(0,0,-8), ColLocation, (int)TRACE_AllBlocking, GetCylinderExtent());
	
			if( Base != Hit.Actor )
			{
				SetBase(Hit.Actor, Hit.Normal);
			}
		}
		
		// Export UActor::execSetLocation(FFrame&, void* const)
		public virtual /*native(267) final function */bool SetLocation(Object.Vector NewLocation)
		{
			return GWorld.FarMoveActor( this, NewLocation );
		}

		// Export UActor::execSetRotation(FFrame&, void* const)
		public virtual /*native(299) final function */bool SetRotation(Object.Rotator NewRotation)
		{
			FCheckResult Hit = new(1.0f);
			return GWorld.MoveActor( this, FVector(0,0,0), NewRotation, 0, ref Hit );
		}
		static void MarkOwnerRelevantComponentsDirty(Actor TheActor)
		{
			for (INT i = 0; i < TheActor.AllComponents.Num(); i++)
			{
				PrimitiveComponent Primitive = (TheActor.AllComponents[i]) as PrimitiveComponent;
				if (Primitive != NULL && (TheActor.bOnlyOwnerSee || Primitive.bOnlyOwnerSee || Primitive.bOwnerNoSee))
				{
					Primitive.BeginDeferredReattach();
				}
			}

			// recurse over children of this Actor
			for (INT i = 0; i < TheActor.Children.Num(); i++)
			{
				Actor Child = TheActor.Children[i];
				if (Child != NULL && !Child.ActorIsPendingKill())
				{
					MarkOwnerRelevantComponentsDirty(Child);
				}
			}
		}
		public void MarkComponentsAsDirty(UBOOL bTransformOnly)
		{
			// Make a copy of the AllComponents array, since BeginDeferredReattach may change the order by reattaching the component.
			var LocalAllComponents = AllComponents;

			for (INT Idx = 0; Idx < LocalAllComponents.Num(); Idx++)
			{
				if (LocalAllComponents[Idx] != NULL)
				{
					if (bStatic)
					{
						LocalAllComponents[Idx].ConditionalDetach();
					}
					else
					{
						if(bTransformOnly)
						{
							LocalAllComponents[Idx].BeginDeferredUpdateTransform();
						}
						else
						{
							LocalAllComponents[Idx].BeginDeferredReattach();
						}
					}
				}
			}

			if (bStatic  && !IsPendingKill())
			{
				ConditionalUpdateComponents(FALSE);
			}
		}
		
		public UBOOL ActorIsPendingKill()
		{
			return bDeleteMe || HasAnyFlags(RF_PendingKill);
		}
		public void ConditionalUpdateComponents(UBOOL bCollisionUpdate = false)
		{
			#if DO_GUARD_SLOW
	// Verify that actor has no references to unreachable components.
	VerifyNoUnreachableReferences();
			#endif
			#if LOG_DETAILED_ACTOR_UPDATE_STATS
	static QWORD LastFrameCounter = 0;
	if( LastFrameCounter != GFrameCounter )
	{
		GDetailedActorUpdateStats.DumpStats();
		GDetailedActorUpdateStats.Reset();
		LastFrameCounter = GFrameCounter;
	}
			#endif

			//SCOPE_CYCLE_COUNTER(STAT_UpdateComponentsTime);

			// Don't update components on destroyed actors and default objects/ archetypes.
			if( !ActorIsPendingKill()
			    &&	!HasAnyFlags(RF_ArchetypeObject|RF_ClassDefaultObject) )
			{
				//TRACK_DETAILED_ACTOR_UPDATE_STATS(this);
				UpdateComponentsInternal( bCollisionUpdate );
			}
		}
		public virtual void UpdateComponentsInternal(UBOOL bCollisionUpdate = false)
		{
			/*checkf(!HasAnyFlags(RF_Unreachable), TEXT("%s"), *GetFullName());
			checkf(!HasAnyFlags(RF_ArchetypeObject|RF_ClassDefaultObject), TEXT("%s"), *GetFullName());
			checkf(!ActorIsPendingKill(), TEXT("%s"), *GetFullName());*/

			FMatrix	ActorToWorld = LocalToWorld();

			// if it's a collision only update
			if (bCollisionUpdate)
			{
				// then only bother with the collision component
				if (CollisionComponent != NULL)
				{
					CollisionComponent.UpdateComponent(GWorld.Scene,this,ActorToWorld,TRUE);
				}
			}
			else
			{
				// Look for components which should be directly attached to the actor, but aren't yet.
				for(INT ComponentIndex = 0;ComponentIndex < Components.Num();ComponentIndex++)
				{
					ActorComponent Component = Components[ComponentIndex]; 
					if( Component )
					{
						Component.UpdateComponent(GWorld.Scene,this,ActorToWorld);
					}
				}
			}
		}
		
		public virtual void stepUp(in FVector GravDir, in FVector DesiredDir, in FVector Delta, ref FCheckResult Hit)
		{
			FVector Down = GravDir * UCONST_ACTORMAXSTEPHEIGHT;

			if (Abs(Hit.Normal.Z) < MAXSTEPSIDEZ)
			{
				// step up - treat as vertical wall
				GWorld.MoveActor(this, -1 * Down, Rotation, 0, ref Hit);
				GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
			}
			else
			{
				// slide up slope
				FLOAT Dist = Delta.Size();
				GWorld.MoveActor(this, Delta + FVector(0,0,Dist*Hit.Normal.Z), Rotation, 0, ref Hit);
			}

			if (Hit.Time < 1f)
			{
				if ( (Abs(Hit.Normal.Z) < MAXSTEPSIDEZ) && (Hit.Time * Delta.SizeSquared() > MINSTEPSIZESQUARED) )
				{
					// try another step
					GWorld.MoveActor(this, Down, Rotation, 0, ref Hit);
					stepUp(GravDir, DesiredDir, Delta * (1f - Hit.Time), ref Hit);
					return;
				}

				// notify script that actor ran into a wall
				processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
				if ( Physics == PHYS_Falling )
					return;

				//adjust and try again
				Hit.Normal.Z = 0;	// treat barrier as vertical;
				Hit.Normal = Hit.Normal.SafeNormal();
				FVector NewDelta = Delta;
				FVector OldHitNormal = Hit.Normal;
				NewDelta = (Delta - Hit.Normal * (Delta | Hit.Normal)) * (1f - Hit.Time);
				if( (NewDelta | Delta) >= 0f )
				{
					GWorld.MoveActor(this, NewDelta, Rotation, 0, ref Hit);
					if (Hit.Time < 1f)
					{
						processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
						if ( Physics == PHYS_Falling )
							return;
						TwoWallAdjust(DesiredDir, ref NewDelta, Hit.Normal, OldHitNormal, Hit.Time);
						GWorld.MoveActor(this, NewDelta, Rotation, 0, ref Hit);
					}
				}
			}
			GWorld.MoveActor(this, Down, Rotation, 0, ref Hit);
		}
		public UBOOL InStasis()
		{
			return ((Physics==PHYS_None) || (Physics == PHYS_Rotating))
			       && (WorldInfo.TimeSeconds - LastRenderTime > 5.0f || WorldInfo.NetMode == WorldInfo.ENetMode.NM_DedicatedServer);
		}
		
		public virtual UBOOL PlayerControlled()
		{
			return false;
		}
		public Actor GetTopOwner()
		{
			Actor Top;
			for( Top=this; Top.Owner; Top=Top.Owner );
			return Top;
		}
		public virtual PlayerController GetTopPlayerController()
		{
			Actor TopActor = GetTopOwner();
			return (TopActor ? TopActor as PlayerController : null);
		}
		
		public UBOOL moveSmooth(FVector Delta)
		{
			FCheckResult Hit = new FCheckResult(1f);
			UBOOL didHit = GWorld.MoveActor( this, Delta, Rotation, 0, ref Hit );
			if (Hit.Time < 1f)
			{
				FVector GravDir = FVector(0,0,-1);
				FVector DesiredDir = Delta.SafeNormal();

				FLOAT UpDown = GravDir | DesiredDir;
				if ( (Abs(Hit.Normal.Z) < 0.2f) && (UpDown < 0.5f) && (UpDown > -0.2f) )
				{
					stepUp(GravDir, DesiredDir, Delta * (1f - Hit.Time), ref Hit);
				}
				else
				{
					FVector Adjusted = (Delta - Hit.Normal * (Delta | Hit.Normal)) * (1f - Hit.Time);
					if( (Delta | Adjusted) >= 0 )
					{
						FVector OldHitNormal = Hit.Normal;
						DesiredDir = Delta.SafeNormal();
						GWorld.MoveActor(this, Adjusted, Rotation, 0, ref Hit);
						if (Hit.Time < 1f)
						{
							SmoothHitWall(Hit.Normal, Hit.Actor);
							TwoWallAdjust(DesiredDir, ref Adjusted, Hit.Normal, OldHitNormal, Hit.Time);
							GWorld.MoveActor(this, Adjusted, Rotation, 0, ref Hit);
						}
					}
				}
			}
			return didHit;
		}
		
		public virtual void SmoothHitWall(FVector HitNormal, Actor HitActor)
		{
			HitWall(HitNormal, HitActor, null);
		}
		
		public virtual bool Tick( FLOAT DeltaSeconds, ELevelTick TickType )
		{
			bTicked = GWorld.Ticked;

			// Ignore actors in stasis
			if (bStasis && InStasis())
			{
				return FALSE;
			}

			// Non-player update.
			UBOOL bShouldTick = ((TickType!=ELevelTick.LEVELTICK_ViewportsOnly) || PlayerControlled());
			if(bShouldTick)
			{
				// This actor is tickable.
				if( RemoteRole == ROLE_AutonomousProxy )
				{
					PlayerController PC = GetTopPlayerController();
					if ( (PC && PC.IsLocalPlayerController()) || Physics == PHYS_RigidBody || Physics == PHYS_Interpolating )
					{
						TickAuthoritative(DeltaSeconds);
					}
					else
					{
						eventTick(DeltaSeconds);

						// Update the actor's script state code.
						ProcessState( DeltaSeconds );
						// Server handles timers for autonomous proxy.
						UpdateTimers( DeltaSeconds );
					}
				}
				else if ( Role>ROLE_SimulatedProxy )
				{
					TickAuthoritative(DeltaSeconds);
				}
				else if ( Role == ROLE_SimulatedProxy )
				{
					TickSimulated(DeltaSeconds);
				}
				else if ( !bDeleteMe && ((Physics == PHYS_Falling) || (Physics == PHYS_Rotating) || (Physics == PHYS_Projectile) || (Physics == PHYS_Interpolating)) ) // dumbproxies simulate falling if client side physics set
				{
					performPhysics( DeltaSeconds );
				}

				if (!bDeleteMe)
				{
					TickSpecial(DeltaSeconds);	// perform any tick functions unique to an actor subclass

					// If a component was added outside the world, we call OutsideWorldBounds, to let gameplay destroy or teleport Actor.
					if(bComponentOutsideWorld)
					{
						OutsideWorldBounds();
						SetCollision(FALSE, FALSE, bIgnoreEncroachers);
						setPhysics(PHYS_None);

						bComponentOutsideWorld = FALSE;
					}
				}
			}
	
			return TRUE;
		}
		
		public virtual void TickAuthoritative( FLOAT DeltaSeconds )
		{
			// Tick the nonplayer.
			//clockSlow(GStats.DWORDStats(GEngineStats.STATS_Game_ScriptTickCycles));
			eventTick(DeltaSeconds);
			//unclockSlow(GStats.DWORDStats(GEngineStats.STATS_Game_ScriptTickCycles));

			// Update the actor's script state code.
			ProcessState(DeltaSeconds);

			UpdateTimers(DeltaSeconds);

			// Update LifeSpan.
			if( LifeSpan!=0f )
			{
				LifeSpan -= DeltaSeconds;
				if( LifeSpan <= 0.0001f )
				{
					// Actor's LifeSpan expired.
					GWorld.DestroyActor( this );
					return;
				}
			}

			// Perform physics.
			if ( !bDeleteMe && (Physics!=PHYS_None) && (Role!=ROLE_AutonomousProxy) )
				performPhysics( DeltaSeconds );
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public virtual void TickSimulated( FLOAT DeltaSeconds )
		{
			TickAuthoritative(DeltaSeconds);
		}
		
		public virtual void TickSpecial( FLOAT DeltaSeconds )
		{
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public unsafe void FindTouchingActors()
		{
			FMemMark Mark = new FMemMark(GMem);
			FLOAT ColRadius = 0f, ColHeight = 0f;
			GetBoundingCylinder(ref ColRadius, ref ColHeight);
			UBOOL bIsZeroExtent = (ColRadius == 0f) && (ColHeight == 0f);
			FCheckResult* FirstHit = GWorld.Hash != null ? GWorld.Hash.ActorEncroachmentCheck( ref GMem, this, Location, Rotation, (int)TRACE_AllColliding ) : null;	
			for( FCheckResult* Test = FirstHit; Test != null; Test=Test->GetNext() )
				if(	Test->Actor!=this && !Test->Actor.IsBasedOn(this) && Test->Actor != GWorld.GetWorldInfo() )
				{
					if( !IsBlockedBy(Test->Actor,Test->Component)
					    && (!Test->Component || (bIsZeroExtent ? Test->Component.BlockZeroExtent : Test->Component.BlockNonZeroExtent)) )
					{
						// Make sure Test->Location is not Zero, if that's the case, use Location
						FVector	HitLocation = Test->Location.IsZero() ? Location : Test->Location;

						// Make sure we have a valid Normal
						FVector NormalDir = Test->Normal.IsZero() ? (Location - HitLocation) : Test->Normal;
						if( !NormalDir.IsZero() )
						{
							NormalDir.Normalize();
						}
						else
						{
							NormalDir = FVector(0,0,1f);
						}

						BeginTouch( Test->Actor, Test->Component, HitLocation, NormalDir );
					}
				}						
			Mark.Pop();
		}
		
		public UBOOL ActorLineCheck(ref FCheckResult Result, in FVector End, in FVector Start, in FVector Extent, int TraceFlags)
		{
			UBOOL Hit = false;
			for(INT ComponentIndex = 0;ComponentIndex < Components.Num();ComponentIndex++)
			{
				PrimitiveComponent Primitive = (Components[ComponentIndex]) as PrimitiveComponent;
				if(Primitive && !Primitive.LineCheck(ref Result,End,Start,Extent,TraceFlags))
				{
					Hit = true;
				}
			}
			return !Hit;
		}
		
		public virtual void ReverseBasedRotation() {}
		public virtual void PushedBy(Actor Other) {}
		
		public Vector OverlapAdjust;
		
		public UBOOL IsOverlapping( Actor Other, ref FCheckResult Hit, PrimitiveComponent OtherPrimitiveComponent = null )
		{
			checkSlow(Other!=NULL);

			if ( (this.IsBrush() && Other.IsBrush()) || (Other == GWorld.GetWorldInfo()) )
			{
				// We cannot detect whether these actors are overlapping so we say they aren't.
				return false;
			}

			// Things dont overlap themselves
			if(this == Other)
			{
				return false;
			}

			// Things that do encroaching (movers, rigid body actors etc.) can't encroach each other!
			if(this.IsEncroacher() && Other.IsEncroacher())
			{
				return false;
			}

			// Things that are joined together dont overlap.
			if( this.IsBasedOn(Other) || Other.IsBasedOn(this) )
			{
				return false;
			}

			// Can't overlap actors with collision turned off.
			if( !this.bCollideActors || !Other.bCollideActors )
			{
				return false;
			}

			// Now have 2 actors we want to overlap, so we have to pick which one to treat as a box and test against the PrimitiveComponents of the other.
			Actor PrimitiveActor = null;
			Actor BoxActor = null;

			// For volumes, test the bounding box against the volume primitive.
			// in the volume case, we cannot test per-poly
			UBOOL bForceSimpleCollision = FALSE;
			if(this is Volume) // maybe ?
			{
				PrimitiveActor = this;
				BoxActor = Other;
				bForceSimpleCollision = TRUE;
			}
			else if(Other is Volume) // maybe ?
			{
				PrimitiveActor = Other;
				BoxActor = this;
				bForceSimpleCollision = TRUE;
			}
			// For Encroachers, we test the complex primitive of the mover against the bounding box of the other thing.
			else if(this.IsEncroacher())
			{
				PrimitiveActor = this;
				BoxActor = Other;	
			}
			else if(Other.IsEncroacher())
			{
				PrimitiveActor = Other;	
				BoxActor = this;
			}
			// If none of these cases, try a cylinder/cylinder overlap.
			else
			{
				// Fallback - see if collision component cylinders are overlapping.
				// @fixme - perhaps use bounding box of any collisioncomponent for this test?
				CylinderComponent CylComp1 = (this.CollisionComponent) as CylinderComponent;
				CylinderComponent CylComp2 = (Other.CollisionComponent) as CylinderComponent;

				if(CylComp1 && CylComp2)
				{
					// use OverlapAdjust because actor may have been temporarily moved
					FVector CylOrigin1 = CylComp1.GetOrigin() + OverlapAdjust;
					FVector CylOrigin2 = CylComp2.GetOrigin();

					if ( (Square(CylOrigin1.Z - CylOrigin2.Z) < Square(CylComp1.CollisionHeight + CylComp2.CollisionHeight))
					&&	(Square(CylOrigin1.X - CylOrigin2.X) + Square(CylOrigin1.Y - CylOrigin2.Y)
						< Square(CylComp1.CollisionRadius + CylComp2.CollisionRadius)) )
					{
						/*if( Hit )*/
							Hit.Component = CylComp2;
						return true;
					}
					else
						return false;
				}
				// if only one has a cylinder, use the box for that and the primitives for the other
				else if (CylComp1 != NULL)
				{
					BoxActor = this;
					PrimitiveActor = Other;
				}
				else if (CylComp2 != NULL)
				{
					BoxActor = Other;
					PrimitiveActor = this;
				}
				else
				{
					// neither has a cylinder, so we can't detect whether they overlap and just say they don't
					return false;
				}
			}

			check(BoxActor);
			check(PrimitiveActor);
			check(BoxActor != PrimitiveActor);

			if(!BoxActor.CollisionComponent)
				return false;
				
			// Check bounding box of collision component against each colliding PrimitiveComponent.
			Box BoxActorBox = BoxActor.CollisionComponent.Bounds.GetBox();
			if(BoxActorBox.IsValid != default)
			{
				// adjust box position since overlap check is for different location than actor's current location
				if ( BoxActor == this )
				{
					BoxActorBox.Min += OverlapAdjust;
					BoxActorBox.Max += OverlapAdjust;
				}
				else
				{
					BoxActorBox.Min -= OverlapAdjust;
					BoxActorBox.Max -= OverlapAdjust;
				}
			}

			//GWorld.LineBatcher.DrawWireBox( BoxActorBox, FColor(255,255,0) );

			// If we failed to get a valid bounding box from the Box actor, we can't get an overlap.
			if(!(BoxActorBox.IsValid != default))
			{
				return false;
			}

			FVector BoxCenter, BoxExtent;
			BoxActorBox.GetCenterAndExtents(out BoxCenter, out BoxExtent);

			// If we were not supplied an FCheckResult, use a temp one.
			FCheckResult TestHit = default;
			/*if(Hit==null)*/
			{
				Hit = TestHit;
			}

			// DEBUGGING: Time how long the point checks take, and print if its more than SHOW_SLOW_OVERLAPS_TAKING_LONG_TIME_AMOUNT.
		/*#if defined(SHOW_SLOW_OVERLAPS) || LOOKING_FOR_PERF_ISSUES
			DWORD Time=0;
			CLOCK_CYCLES(Time);
		#endif*/

			PrimitiveComponent HitComponent = null;

			// Only check against passed in component if passed in.
			if (OtherPrimitiveComponent != NULL && PrimitiveActor == Other)
			{
				if( OtherPrimitiveComponent.CollideActors && OtherPrimitiveComponent.BlockNonZeroExtent )
				{
					throw new NotImplementedException();
					/*if( OtherPrimitiveComponent.PointCheck(*Hit, BoxCenter, BoxExtent, (BoxActor.bCollideComplex && !bForceSimpleCollision) ? TRACE_ComplexCollision : 0) == 0 )
					{
						HitComponent = OtherPrimitiveComponent;
					}*/
				}
			}
			// Check box against each colliding primitive component.
			else
			{
				for(UINT ComponentIndex = 0; ComponentIndex < (UINT)PrimitiveActor.Components.Num(); ComponentIndex++)
				{
					PrimitiveComponent PrimComp = (PrimitiveActor.Components[ComponentIndex]) as PrimitiveComponent;
					if(PrimComp && PrimComp.CollideActors && PrimComp.BlockNonZeroExtent)
					{
						if( UWorldBridge.GetUWorld().PointCheck(PrimComp, ref Hit, BoxCenter, BoxExtent, (BoxActor.bCollideComplex && !bForceSimpleCollision) ? TRACE_ComplexCollision : 0) == false )
						{
							HitComponent = PrimComp;
							break;
						}
					}
				}
			}

			Hit.Component = HitComponent;

		/*#if defined(SHOW_SLOW_OVERLAPS) || LOOKING_FOR_PERF_ISSUES
			UNCLOCK_CYCLES(Time);
			FLOAT MSec = Time * GSecondsPerCycle * 1000.f;
			if( MSec > SHOW_SLOW_OVERLAPS_TAKING_LONG_TIME_AMOUNT )
			{
				debugf( NAME_PerfWarning, TEXT("IsOverLapping: Testing: P:%s - B:%s Time: %f"), *(PrimitiveActor.GetPathName()), *(BoxActor.GetPathName()), MSec );
			}
		#endif*/

			return HitComponent != NULL;

		}
		
		public virtual FMatrix WorldToLocal()
		{
			return	FTranslationMatrix(-Location) *
			        FInverseRotationMatrix(Rotation) *
			        FScaleMatrix(FVector( 1f / DrawScale3D.X, 1f / DrawScale3D.Y, 1f / DrawScale3D.Z) / DrawScale) *
			        FTranslationMatrix(PrePivot);
		}
		
		public virtual FMatrix LocalToWorld()
		{
			#if false
			FTranslationMatrix	LToW		( -PrePivot					);
			FScaleMatrix		TempScale	( DrawScale3D * DrawScale	);
			FRotationMatrix		TempRot		( Rotation					);
			FTranslationMatrix	TempTrans	( Location					);
			LToW *= TempScale;
			LToW *= TempRot;
			LToW *= TempTrans;
			return LToW;
			#else
			FMatrix Result = default;

			FLOAT	SR = GMath.SinTab(Rotation.Roll),
					    SP = GMath.SinTab(Rotation.Pitch),
						SY = GMath.SinTab(Rotation.Yaw),
						CR = GMath.CosTab(Rotation.Roll),
						CP = GMath.CosTab(Rotation.Pitch),
						CY = GMath.CosTab(Rotation.Yaw);

			FLOAT	LX = Location.X,
					    LY = Location.Y,
						LZ = Location.Z,
						PX = PrePivot.X,
						PY = PrePivot.Y,
						PZ = PrePivot.Z;

			FLOAT	DX = DrawScale3D.X * DrawScale,
				        DY = DrawScale3D.Y * DrawScale,
						DZ = DrawScale3D.Z * DrawScale;

			Result.M[0,0] = CP * CY * DX;
			Result.M[0,1] = CP * DX * SY;
			Result.M[0,2] = DX * SP;
			Result.M[0,3] = 0f;

			Result.M[1,0] = DY * ( CY * SP * SR - CR * SY );
			Result.M[1,1] = DY * ( CR * CY + SP * SR * SY );
			Result.M[1,2] = -CP * DY * SR;
			Result.M[1,3] = 0f;

			Result.M[2,0] = -DZ * ( CR * CY * SP + SR * SY );
			Result.M[2,1] =  DZ * ( CY * SR - CR * SP * SY );
			Result.M[2,2] = CP * CR * DZ;
			Result.M[2,3] = 0f;

			Result.M[3,0] = LX - CP * CY * DX * PX + CR * CY * DZ * PZ * SP - CY * DY * PY * SP * SR + CR * DY * PY * SY + DZ * PZ * SR * SY;
			Result.M[3,1] = LY - (CR * CY * DY * PY + CY * DZ * PZ * SR + CP * DX * PX * SY - CR * DZ * PZ * SP * SY + DY * PY * SP * SR * SY);
			Result.M[3,2] = LZ - (CP * CR * DZ * PZ + DX * PX * SP - CP * DY * PY * SR);
			Result.M[3,3] = 1f;

			return Result;
			#endif
		}
		
		
		public virtual void UpdatePushBody()
		{
			
		}



		static UBOOL TouchTo( Actor Actor, Actor Other, PrimitiveComponent OtherComp, in FVector HitLocation, in FVector HitNormal)
		{
			check(Actor);
			check(Other);
			check(Actor!=Other);

			// if already touching, then don't bother with further checks
			if (Actor.Touching.ContainsItem(Other))
			{
				return true;
			}

			// check for touch sequence events
			if (GIsGame)
			{
				for (INT Idx = 0; Idx < Actor.GeneratedEvents.Num(); Idx++)
				{
					SeqEvent_Touch TouchEvent = (Actor.GeneratedEvents[Idx]) as SeqEvent_Touch;
					if (TouchEvent != NULL)
					{
						TouchEvent.CheckTouchActivate(Actor,Other);
					}
				}
			}

			// Make Actor touch TouchActor.
			Actor.Touching.AddItem(Other);
			Actor.Touch( Other, OtherComp, HitLocation, HitNormal );

			// See if first actor did something that caused an UnTouch.
			INT i = 0;
			return ( Actor.Touching.FindItem(Other,ref i) );
		}
		
		public void BeginTouch( Actor Other, PrimitiveComponent OtherComp, in FVector HitLocation, in FVector HitNormal)
		{
			// Perform reflective touch.
			if ( TouchTo( this, Other, OtherComp, HitLocation, HitNormal ) )
				TouchTo( Other, this, this.CollisionComponent, HitLocation, HitNormal );

		}
		public virtual void NotifyBumpLevel(in FVector HitLocation, in FVector HitNormal)
		{
		}
		
		public void UnTouchActors()
		{
			for( int i=0; i<Touching.Num(); )
			{
				if( Touching[i] && !IsOverlapping(Touching[i]) )
				{
					EndTouch( Touching[i], false );
				}
				else
				{
					i++;
				}
			}
		}
		
		public void EndTouch( Actor Other, UBOOL bNoNotifySelf )
		{
			check(Other!=this);

			// Notify Actor.
			INT i=0;
			if ( !bNoNotifySelf && Touching.FindItem(Other,ref i) )
			{
				UnTouch( Other );
			}
			Touching.RemoveItem(Other);

			// check for untouch sequence events on both actors
			if (GIsGame)
			{
				SeqEvent_Touch TouchEvent = null;
				for (INT Idx = 0; Idx < GeneratedEvents.Num(); Idx++)
				{
					TouchEvent = (GeneratedEvents[Idx]) as SeqEvent_Touch;
					if (TouchEvent != NULL)
					{
						TouchEvent.CheckUnTouchActivate(this,Other);
					}
				}
				for (INT Idx = 0; Idx < Other.GeneratedEvents.Num(); Idx++)
				{
					TouchEvent = (Other.GeneratedEvents[Idx]) as SeqEvent_Touch;
					if (TouchEvent != NULL)
					{
						TouchEvent.CheckUnTouchActivate(Other,this);
					}
				}
			}

			if ( Other.Touching.FindItem(this,ref i) )
			{
				Other.UnTouch( this );
				Other.Touching.RemoveItem(this);
			}
		}

		public virtual void NotifyBump(Actor Other, PrimitiveComponent OtherComp, in FVector HitNormal)
		{
			Bump(Other, OtherComp, HitNormal);
		}
			
		public virtual FRotator FindSlopeRotation(FVector FloorNormal, FRotator NewRotation)
		{
			if ( (FloorNormal.Z < 0.99f) && !FloorNormal.IsNearlyZero() )
			{
				FRotator TempRot = NewRotation;
				// allow yawing, but pitch and roll fixed based on wall
				TempRot.Pitch = 0;
				FVector YawDir = TempRot.Vector();
				FVector PitchDir = YawDir - FloorNormal * (YawDir | FloorNormal);
				TempRot = PitchDir.Rotation();
				NewRotation.Pitch = TempRot.Pitch;
				FVector RollDir = PitchDir ^ FloorNormal;
				TempRot = RollDir.Rotation();
				NewRotation.Roll = TempRot.Pitch;
			}
			else
				return FRotator(0,NewRotation.Yaw, 0);

			return NewRotation;
		}
		public virtual void physWalking(FLOAT deltaTime, INT Iterations)
		{
			NativeMarkers.MarkUnimplemented();
		}
		
		public virtual void physicsRotation(FLOAT deltaTime)
		{
			// Accumulate a desired new rotation.
			FRotator OldRotation = Rotation;
			FRotator NewRotation = Rotation;
			FRotator deltaRotation = RotationRate * deltaTime;

			if ( Physics == PHYS_Rotating )
			{
				NewRotation = NewRotation + deltaRotation;
			}
			else
			{
				//YAW
				if ( (deltaRotation.Yaw != 0) && (DesiredRotation.Yaw != NewRotation.Yaw) )
					NewRotation.Yaw = fixedTurn(NewRotation.Yaw, DesiredRotation.Yaw, deltaRotation.Yaw);
				//PITCH
				if ( (deltaRotation.Pitch != 0) && (DesiredRotation.Pitch != NewRotation.Pitch) )
					NewRotation.Pitch = fixedTurn(NewRotation.Pitch, DesiredRotation.Pitch, deltaRotation.Pitch);
				//ROLL
				if ( (deltaRotation.Roll != 0) && (DesiredRotation.Roll != NewRotation.Roll) )
					NewRotation.Roll = fixedTurn(NewRotation.Roll, DesiredRotation.Roll, deltaRotation.Roll);	
			}

			// Set the new rotation.
			// fixedTurn() returns denormalized results so we must convert Rotation to prevent negative values in Rotation from causing unnecessary MoveActor() calls
			if (NewRotation != Rotation.Denormalize())
			{
				FCheckResult Hit = new (1f);
				GWorld.MoveActor( this, FVector(0,0,0), NewRotation, 0, ref Hit );
			}

			AngularVelocity = CalcAngularVelocity(OldRotation, NewRotation, deltaTime);
		}
		static FVector CalcAngularVelocity(in FRotator OldRot, in FRotator NewRot, FLOAT DeltaTime)
		{
			FVector RetAngVel = FVector(0f);

			if (OldRot != NewRot)
			{
				FLOAT InvDeltaTime = 1f / DeltaTime;
				FQuat DeltaQRot = (NewRot - OldRot).Quaternion();
		
				FVector Axis = default;
				FLOAT Angle = default;
				DeltaQRot.ToAxisAndAngle(ref Axis, ref Angle);

				RetAngVel = Axis * Angle * InvDeltaTime;
			}

			return RetAngVel;
		}
		public virtual unsafe void GetNetBuoyancy(ref FLOAT NetBuoyancy, ref FLOAT NetFluidFriction)
		{
		}
		public virtual unsafe void physInterpolating(FLOAT DeltaTime)
		{
			InterpTrackMove		MoveTrack = null;
			InterpTrackInstMove	MoveInst = null;
			SeqAct_Interp			Seq = null;

			UBOOL bMovingNow = FALSE;

			//debugf(TEXT("AActor::physInterpolating %f - %s"), GWorld.GetTimeSeconds(), *GetFName());

			// If we have a movement track currently working on this Actor, update position to co-incide with it.
			if( FindInterpMoveTrack(ref MoveTrack, ref MoveInst, ref Seq) )
			{
				NativeMarkers.MarkUnimplemented();
				//bMovingNow = MoveWithInterpMoveTrack(MoveTrack, MoveInst, Seq.Position, DeltaTime);
			}
			else
			{
				Velocity = FVector(0f);
			}

			// If we have just stopped moving - update all components so their PreviousLocalToWorld is the same as their LocalToWorld,
			// and so motion blur realises they have stopped moving.
			if(bIsMoving && !bMovingNow)
			{
				ForceUpdateComponents(FALSE);
			}
			bIsMoving = bMovingNow;
		}
		
		public UBOOL FindInterpMoveTrack(ref InterpTrackMove OutMoveTrack, ref InterpTrackInstMove OutMoveTrackInst, ref SeqAct_Interp OutSeq)
		{
			for(INT i=0; i<LatentActions.Num(); i++)
			{
				SeqAct_Interp InterpAct = (LatentActions[i] as SeqAct_Interp);
				if(InterpAct)
				{
					InterpGroupInst GrInst = InterpAct.FindGroupInst(this);
					check(GrInst); // Should have an instance of some group for this actor.
					check(GrInst.Group); // Should be based on an InterpGroup
					check(GrInst.TrackInst.Num() == GrInst.Group.InterpTracks.Num()); // Check number of tracks match up.

					for(INT j=0; j<GrInst.Group.InterpTracks.Num(); j++)
					{
						InterpTrackMove MoveTrack = GrInst.Group.InterpTracks[j] as InterpTrackMove;
						if(MoveTrack)
						{
							OutMoveTrack = MoveTrack;
							OutMoveTrackInst = ( GrInst.TrackInst[j] as InterpTrackInstMove );
							OutSeq = InterpAct;
							return true;
						}
					}
				}
			}

			OutMoveTrack = null;
			OutMoveTrackInst = null;
			OutSeq = null;
			return false;
		}
		public virtual void GrowCollision() {}
		public virtual UBOOL ShrinkCollision(Actor HitActor, PrimitiveComponent HitComponent, in FVector StartLocation)
		{
			return false;
		}
		public virtual void physFalling(FLOAT deltaTime, INT Iterations)
		{
			CheckStillInWorld();

			//bound acceleration, falling object has minimal ability to impact acceleration
			FVector RealAcceleration = Acceleration;
			CheckResult Hit = new CheckResult(1f);
			FLOAT remainingTime = deltaTime;
			FLOAT timeTick = 0.1f;
			int numBounces = 0;
			GrowCollision();
			FVector OldLocation = Location;

			while ( (remainingTime > 0f) && (Iterations < 8) )
			{
				Iterations++;
				if (remainingTime > 0.05f)
					timeTick = Min(0.05f, remainingTime * 0.5f);
				else timeTick = remainingTime;

				remainingTime -= timeTick;
				OldLocation = Location;
				bJustTeleported = false;

				FVector OldVelocity = Velocity;
				FLOAT NetBuoyancy = 0f;
				FLOAT NetFluidFriction = 0f;
				GetNetBuoyancy(ref NetBuoyancy, ref NetFluidFriction);
				Velocity = OldVelocity * (1f - NetFluidFriction * timeTick) + Acceleration;
				Velocity.Z += GetGravityZ() * (1f - NetBuoyancy) * timeTick;

				FVector Adjusted = (Velocity + PhysicsVolume.ZoneVelocity) * timeTick;

				FVector TmpVelocity = Velocity;

				GWorld.MoveActor(this, Adjusted, Rotation, 0, ref Hit);

				if (Velocity != TmpVelocity)
				{
					bJustTeleported = true;
				}

				if ( bDeleteMe )
					return;
				if ( (Hit.Time < 1f) && ShrinkCollision(Hit.Actor, Hit.Component, OldLocation) )
				{
					Adjusted = (Velocity + PhysicsVolume.ZoneVelocity) * timeTick * (1f - Hit.Time);
					GWorld.MoveActor(this, Adjusted, Rotation, 0, ref Hit);
					if ( bDeleteMe )
						return;
				}
				if ( Hit.Time < 1f )
				{
					if (bBounce)
					{
						processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
						if (bDeleteMe || Physics != PHYS_Falling)
							return;
						else if ( numBounces < 2 )
							remainingTime += timeTick * (1f - Hit.Time);
						numBounces++;
						bJustTeleported = TRUE; // don't average velocity, since bounced
					}
					else
					{
						if (Hit.Normal.Z >= UCONST_MINFLOORZ)
						{
							remainingTime += timeTick * (1f - Hit.Time);
							if (!bJustTeleported && (Hit.Time > 0.1f) && (Hit.Time * timeTick > 0.003f) )
								Velocity = (Location - OldLocation)/(timeTick * Hit.Time);
							processLanded(Hit.Normal, Hit.Actor, remainingTime, Iterations);
							return;
						}
						else
						{
							processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
							if (bDeleteMe || Physics != PHYS_Falling)
								return;
							FVector OldHitNormal = Hit.Normal;
							FVector Delta = (Adjusted - Hit.Normal * (Adjusted | Hit.Normal)) * (1f - Hit.Time);
							if( (Delta | Adjusted) >= 0 )
							{
								if ( Delta.Z > 0f ) // friction slows sliding up slopes
									Delta *= 0.5f;
								GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
								if ( bDeleteMe )
									return;
								if (Hit.Time < 1f) //hit second wall
								{
									if ( Hit.Normal.Z >= UCONST_MINFLOORZ )
									{
										remainingTime = 0f;
										processLanded(Hit.Normal, Hit.Actor, remainingTime, Iterations);
										return;
									}
									else
										processHitWall(Hit.Normal, Hit.Actor, Hit.Component);
				
									if ( bDeleteMe )
										return;
									FVector DesiredDir = Adjusted.SafeNormal();
									TwoWallAdjust(DesiredDir, ref Delta, Hit.Normal, OldHitNormal, Hit.Time);
									if ( bDeleteMe )
										return;
									UBOOL bDitch = ( (OldHitNormal.Z > 0) && (Hit.Normal.Z > 0) && (Delta.Z == 0) && ((Hit.Normal | OldHitNormal) < 0) );
									GWorld.MoveActor(this, Delta, Rotation, 0, ref Hit);
									if ( bDeleteMe )
										return;
									if ( bDitch || (Hit.Normal.Z >= UCONST_MINFLOORZ) )
									{
										remainingTime = 0f;
										processLanded(Hit.Normal, Hit.Actor, remainingTime, Iterations);
										return;
									}
								}
							}
							FLOAT OldVelZ = OldVelocity.Z;
							OldVelocity = (Location - OldLocation)/timeTick;
							OldVelocity.Z = OldVelZ;
						}
					}
				}

				if ( !bJustTeleported )
				{
					// refine the velocity by figuring out the average actual velocity over the tick, and then the final velocity.
					// This particularly corrects for situations where level geometry affected the fall.
					Velocity = (Location - OldLocation)/timeTick; //actual average velocity
					if ( (Velocity.Z < OldVelocity.Z) || (OldVelocity.Z >= 0) )
						Velocity = 2f * Velocity - OldVelocity; //end velocity has 2* accel of avg
					if (Velocity.SizeSquared() > Square(GetTerminalVelocity()))
					{
						Velocity = Velocity.SafeNormal();
						Velocity *= GetTerminalVelocity();
					}
				}
			}

			Acceleration = RealAcceleration;
		}
		
		public virtual void UpdateBasedRotation(ref FRotator FinalRotation, in FRotator ReducedRotation) {}
		
		public UBOOL TouchReachSucceeded(Pawn P, in FVector TestPosition)
		{
			UBOOL bTouchTest = bCollideActors && P.bCollideActors && !GIsEditor;
			if ( bTouchTest )
			{
				if ( TestPosition == P.Location )
				{
					for (INT i = 0; i < Touching.Num(); i++)
					{
						if ( Touching[i] == P )
						{
							// succeed if touching
							return TRUE;
						}
					}
					return FALSE;
				}

				// if TestPosition != P->Location, can't use touching array
				CylinderComponent CylComp1 = (this.CollisionComponent) as CylinderComponent;
				if (CylComp1 != NULL && (!bBlockActors || !CylComp1.BlockActors))
				{
					return
						( (Square(Location.Z - TestPosition.Z) < Square(CylComp1.CollisionHeight + P.CylinderComponent.CollisionHeight))
						  &&	( Square(Location.X - TestPosition.X) + Square(Location.Y - TestPosition.Y) <
						          Square(CylComp1.CollisionRadius + P.CylinderComponent.CollisionRadius) ) );
				}
			}
			return FALSE;
		}
		
		public UBOOL ReachedBy(Pawn P, in FVector TestPosition, in FVector Dest)
		{
			if ( TouchReachSucceeded(P, TestPosition) )
				return true;

			FLOAT ColHeight = 0f, ColRadius = 0f;
			GetBoundingCylinder(ref ColRadius, ref ColHeight);
			if ( !bBlockActors && GWorld.HasBegunPlay() )
				ColRadius = 0f;
			return P.ReachThresholdTest(TestPosition, Dest, this, ColHeight, ColHeight, ColRadius);	
		}



		public virtual unsafe void physRigidBody( FLOAT DeltaTime )
		{
			NativeMarkers.MarkUnimplemented();
		}



		public virtual void setPhysics( Actor.EPhysics NewPhysics )
		{
			setPhysics((byte)NewPhysics);
		}
		
		public virtual void GetBoundingCylinder(ref FLOAT CollisionRadius, ref FLOAT CollisionHeight)
		{
			Box Box = default;
			GetComponentsBoundingBox(ref Box);
			FVector BoxExtent = GetExtent(Box);

			CollisionHeight = BoxExtent.Z;
			CollisionRadius = (float)sqrt( (BoxExtent.X * BoxExtent.X) + (BoxExtent.Y * BoxExtent.Y) );

			static FVector GetExtent(Box thiss)
			{
				return 0.5f * ( thiss.Max - thiss.Min );
			}
		}
		
		public FVector GetCylinderExtent()
		{
			CylinderComponent CylComp = CollisionComponent as CylinderComponent;
	
			if(CylComp)
			{
				return FVector(CylComp.CollisionRadius, CylComp.CollisionRadius, CylComp.CollisionHeight);
			}
			else
			{
				// use bounding cylinder
				FLOAT CollisionRadius = 0, CollisionHeight = 0;
				((Actor)this).GetBoundingCylinder(ref CollisionRadius, ref CollisionHeight);
				return FVector(CollisionRadius,CollisionRadius,CollisionHeight);
			}
		}



		public unsafe void SetPhysics( EPhysics NewPhysics, Actor NewFloor = null, FVector? _NewFloorV = null )
		{
			setPhysics((byte)NewPhysics, NewFloor, _NewFloorV);
		}



		public virtual unsafe void setPhysics(BYTE NewPhysics, Actor NewFloor = null, FVector? _NewFloorV = null)
		{
			var NewFloorV = _NewFloorV ?? FVector( 0, 0, 1 );
			if( (BYTE)Physics == NewPhysics )
			{
				return;
			}

			// log C++ call stack of physics mode changes on Pawns
			/*DEBUGPHYSONLY
				(
			if( Cast<APawn>(this) != null )
			{
				debugf(TEXT("%3.2f %s SetPhysics: %d, OldPhysics: %d, NewFloor: %s"), GWorld.GetTimeSeconds(), *GetName(), NewPhysics, Physics, *NewFloor.GetName());
			
				// Dump call stack to log
				appDumpCallStackToLog();
			}
			)*/
			BYTE OldPhysics = (BYTE)Physics;

			Physics = (EPhysics)NewPhysics;

			if( (Physics == PHYS_Walking) || (Physics == PHYS_None) || (Physics == PHYS_Rotating) || (Physics == PHYS_Spider) )
			{	
				if( NewFloor == null )
				{
					FindBase();
				}
				else if( Base != NewFloor )
				{
					SetBase(NewFloor, NewFloorV);
				}
			}
			else if( Base != null )
			{
				SetBase(null, new Vector(0f, 0f, 1f));
			}
	
			if( (Physics == PHYS_None) || (Physics == PHYS_Rotating) )
			{
				Velocity		= FVector(0f);
				Acceleration	= FVector(0f);
			}
	
			if( PhysicsVolume )
			{
				PhysicsVolume.PhysicsChangedFor(this);
			}

			// Handle changing to and from rigid-body physics mode.
			if( Physics == PHYS_RigidBody )
			{
				if( CollisionComponent )
				{
					CollisionComponent.SetComponentRBFixed(FALSE);

					// Should we always wake when we switch to PHYS_RigidBody? Seems like a sensible thing to do anyway...
					CollisionComponent.WakeRigidBody(); 
				}
			}
			else if( OldPhysics == (BYTE)PHYS_RigidBody )
			{
				if( CollisionComponent )
				{
					CollisionComponent.SetComponentRBFixed(TRUE);
				}
			}
		}
		
		public virtual UBOOL ShouldTrace(PrimitiveComponent Primitive,Actor SourceActor, ETraceFlags TraceFlags)
		{
			return ( bWorldGeometry && (TraceFlags & TRACE_LevelGeometry) != default )
			       || ( !bWorldGeometry && (TraceFlags & TRACE_Others) != default 
			                            && ((TraceFlags & TRACE_OnlyProjActor) != default 
				                            ? (bProjTarget || (bBlockActors && Primitive.BlockActors)) 
				                            : (!((TraceFlags & TRACE_Blocking) != default) || (SourceActor && SourceActor.IsBlockedBy(this,Primitive)))) );
		}

		public virtual unsafe void performPhysics(FLOAT DeltaSeconds)
		{
			// make sure we have a valid physicsvolume (level streaming might kill it)
			if (PhysicsVolume == null)
			{
				SetZone(FALSE, FALSE);
			}

			// change position
			switch (Physics)
			{
				case PHYS_None: return;
				case PHYS_Walking: physWalking(DeltaSeconds, 0); break;
				case PHYS_Projectile: /*physProjectile(DeltaSeconds, 0);*/NativeMarkers.MarkUnimplemented(); break;
				case PHYS_Falling: physFalling(DeltaSeconds, 0); break;
				case PHYS_Rotating: break;
				case PHYS_RigidBody: physRigidBody(DeltaSeconds); break;
				case PHYS_SoftBody: /*physSoftBody(DeltaSeconds);*/NativeMarkers.MarkUnimplemented(); break;
				case PHYS_Interpolating: physInterpolating(DeltaSeconds); break;
				default:
					//debugf(NAME_Warning, TEXT("%s has unsupported physics mode %d"), *GetName(), INT(Physics));
					setPhysics(PHYS_None);
					break;
			}
	
			if( bDeleteMe )
			{
				return;
			}

			// rotate
			if (!RotationRate.IsZero() && Physics != PHYS_Interpolating)
			{
				physicsRotation(DeltaSeconds);
			}

			// allow touched actors to impact physics
			if( PendingTouch )
			{
				PendingTouch.PostTouch(this);
				Actor OldTouch = PendingTouch;
				PendingTouch = PendingTouch.PendingTouch;
				OldTouch.PendingTouch = null;
			}
		}
		public virtual unsafe void processHitWall(FVector HitNormal, Actor HitActor, PrimitiveComponent HitComp)
		{
			if (HitActor != null)
			{
				PortalTeleporter Portal = HitActor.GetAPortalTeleporter();
				if (Portal != null && Portal.TransformActor(this))
				{
					return;
				}
				if (!bBlockActors && HitActor.GetAPawn() && !HitActor.IsEncroacher())
				{
					return;
				}
			}
			HitWall(HitNormal, HitActor, HitComp);
		}
		
		public UBOOL IsBlockedBy( Actor Other, PrimitiveComponent Primitive )
		{
			checkSlow(this!=NULL);
			checkSlow(Other!=NULL);

			if(Primitive && !Primitive.BlockActors)
				return false;

			if( Other.bWorldGeometry )
				return bCollideWorld && Other.bBlockActors;
			else if ( Other.IgnoreBlockingBy((Actor)this) )
				return false;
			else if ( IgnoreBlockingBy((Actor)Other) )
				return false;
			else if( Other.IsBrush() || Other.IsEncroacher() )
				return bCollideWorld && Other.bBlockActors;
			else if ( IsBrush() || IsEncroacher() )
				return Other.bCollideWorld && bBlockActors;
			else
				return Other.bBlockActors && bBlockActors;

		}
		
		public UBOOL IsBrush(){return ((Actor)this).IsABrush();}
		public UBOOL IsABrush(){return this is Brush;}
		
		public virtual UBOOL IgnoreBlockingBy( Actor Other )
		{
			if ( bIgnoreEncroachers && Other.IsEncroacher() )
				return true;
			return false;
		}
		
		public void UpdateRelativeRotation()
		{
			if ( !Base || Base.bWorldGeometry || (BaseBoneName != NAME_None) )
				return;

			// update RelativeRotation which is the rotation relative to the base's rotation
			RelativeRotation = (FRotationMatrix(Rotation) * FRotationMatrix(Base.Rotation).Transpose()).Rotator();
		}



		public virtual unsafe void SetBase( Actor NewBase, FVector? NewFloor, SkeletalMeshComponent? SkelComp, name? AttachName )
		{
			SetBase( NewBase, NewFloor ?? new Vector(0f, 0f, 1f), 1, SkelComp, AttachName ?? default );
		}



		public void SetBase( Actor NewBase ) => SetBase( NewBase, new Vector(0f, 0f, 1f) );



		public virtual unsafe void SetBase( Actor NewBase, FVector NewFloor, int bNotifyActor = 1, SkeletalMeshComponent SkelComp = null, name AttachName = default )
		{
			// Verify no recursion.
			for( Actor Loop=NewBase; Loop!=null; Loop=Loop.Base )
			{
				if( Loop == this )
				{
					//debugf(TEXT(" SetBase failed! Recursion detected. Actor %s already based on %s."), *GetName(), *NewBase.GetName());
					return;
				}
			}

			// Don't allow static actors to be based on movable or deleted actors
			if( NewBase != null && (bStatic || !bMovable) && ((!NewBase.bStatic && NewBase.bMovable) || NewBase.bDeleteMe) )
			{
				//debugf(TEXT("SetBase failed! Cannot base static actor %s on moveable actor %s"), *GetName(), *NewBase.GetName());
				return;
			}

			// If anything is different from current base, update the based information.
			if( (NewBase != Base) || (SkelComp != BaseSkelComponent) || (AttachName != BaseBoneName) )
			{
				//debugf(TEXT("%3.2f SetBase %s -> %s, SkelComp: %s, AttachName: %s"), GWorld.GetTimeSeconds(), *GetName(), NewBase ? *NewBase.GetName() : TEXT("NULL"), *SkelComp.GetName(), *AttachName.ToString());

				// Notify old base, unless it's the level or terrain (but not movers).
				if( Base && !Base.bWorldGeometry )
				{
					/*INT RemovalCount = */Base.Attached.RemoveItem(this);
					//@fixme - disabled check for editor since it was being triggered during import, is this safe?
					//checkf(!GIsGame || RemovalCount <= 1, TEXT("%s was in Attached array of %s multiple times!"), *GetFullName(), *Base.GetFullName()); // Verify that an actor wasn't attached multiple times. @todo: might want to also check > 0?
					Base.Detach( this );
				}

				// Set base.
				Base = NewBase;
				BaseSkelComponent = null;
				BaseBoneName = NAME_None;

				if ( Base && !Base.bWorldGeometry )
				{
					if ( !bHardAttach || (Role == ROLE_Authority) )
					{
						RelativeLocation = Location - Base.Location;
						UpdateRelativeRotation();
					}

					// If skeletal case, check bone is valid before we try and attach.
					INT BoneIndex = INDEX_NONE;

					// Check to see if it is a socket first
					SkeletalMeshSocket Socket = (SkelComp && SkelComp.SkeletalMesh) ? SkelComp.SkeletalMesh.FindSocket( AttachName ) : null;
					if( Socket )
					{
						// Use socket bone name
						AttachName = Socket.BoneName;
					}

					if( SkelComp && (AttachName != NAME_None) )
					{
						// Check we are not trying to base on a bone of a SkeletalMeshComponent that is 
						// using another SkeletalMeshComponent for its bone transforms.
						if(SkelComp.ParentAnimComponent)
						{
							/*debugf( 
								TEXT("SkeletalMeshComponent %s in Actor %s has a ParentAnimComponent - should attach Actor %s to that instead."), 
								*SkelComp.GetPathName(),
								*Base.GetPathName(),
								*GetPathName()
								);*/
						}
						else
						{
							BoneIndex = SkelComp.MatchRefBone(AttachName);
							if(BoneIndex == INDEX_NONE)
							{
								//debugf( TEXT("AActor::SetBase : Bone (%s) not found on %s for %s!"), *AttachName.ToString() , *Base.GetName(), *GetName());					
							}
						}
					}

					// Bone exists and component is successfully initialized, so remember offset from it.
					if(BoneIndex != INDEX_NONE /*&& SkelComp.IsAttached()*/ && SkelComp.GetOwner() != null)
					{				
						check(SkelComp);
						check(SkelComp.GetOwner() == Base); // SkelComp should always be owned by the Actor we are basing on.

						if( Socket )
						{
							RelativeLocation = Socket.RelativeLocation;
							RelativeRotation = Socket.RelativeRotation;
						}
						else
						{
							// Get transform of bone we wish to attach to.
							FMatrix BaseTM = SkelComp.GetBoneMatrix(BoneIndex);
							BaseTM.RemoveScaling();
							FMatrix BaseInvTM = BaseTM.Inverse();

							var ChildTM = FRotationTranslationMatrix(Rotation,Location);

							// Find relative transform of actor from its base bone, and store it.
							FMatrix HardRelMatrix =  ChildTM * BaseInvTM;
							RelativeLocation = HardRelMatrix.GetOrigin();
							RelativeRotation = HardRelMatrix.Rotator();
						}

						BaseSkelComponent = SkelComp;
						BaseBoneName = AttachName;
					}
					// Calculate the transform of this actor relative to its base.
					else if(bHardAttach)
					{
						FMatrix BaseInvTM = FTranslationMatrix(-Base.Location) * FInverseRotationMatrix(Base.Rotation);
						var ChildTM = FRotationTranslationMatrix(Rotation, Location);

						FMatrix HardRelMatrix =  ChildTM * BaseInvTM;
						RelativeLocation = HardRelMatrix.GetOrigin();
						RelativeRotation = HardRelMatrix.Rotator();
					}
				}

				// Notify new base, unless it's the level.
				if( Base && !Base.bWorldGeometry )
				{
					Base.Attached.AddItem(this);
					Base.Attach( this );
				}

				// Notify this actor of his new floor.
				if ( bNotifyActor.AsBool() )
				{
					BaseChange();
				}
			}
		}
		public virtual unsafe void processLanded(FVector HitNormal, Actor HitActor, FLOAT remainingTime, INT Iterations)
		{
			CheckStillInWorld();

			if ( bDeleteMe )
			{
				return;
			}

			if ( PhysicsVolume.bBounceVelocity && !PhysicsVolume.ZoneVelocity.IsZero() )
			{
				Velocity = PhysicsVolume.ZoneVelocity + FVector(0f, 0f, 2f * UCONST_ACTORMAXSTEPHEIGHT);
				return;
			}

			Landed(HitNormal, HitActor);
			if ( bDeleteMe )
			{
				return;
			}
			if (Physics == PHYS_Falling)
			{
				setPhysics((byte)PHYS_None, HitActor, HitNormal);
				Velocity = FVector(0,0,0);
			}
			if ( bOrientOnSlope && (Physics == PHYS_None) )
			{
				// rotate properly onto slope
				CheckResult Hit = new CheckResult(1f);
				FRotator NewRotation = FindSlopeRotation(HitNormal,Rotation);
				GWorld.MoveActor(this, FVector(0,0,0), NewRotation, 0, ref Hit);
			}
		}



		public virtual void CheckStillInWorld()
		{
			// check the variations of KillZ
			WorldInfo WorldInfo = GWorld.GetWorldInfo();
			if( Location.Z < ((WorldInfo.bSoftKillZ && Physics == PHYS_Falling) ? (WorldInfo.KillZ - WorldInfo.SoftKill) : WorldInfo.KillZ) )
			{
				FellOutOfWorld(WorldInfo.KillZDamageType);
			}
			// Check if box has poked outside the world
			else if( ( CollisionComponent != NULL ) && ( CollisionComponent.IsAttached() == TRUE ) )
			{
				Box	Box = CollisionComponent.Bounds.GetBox();
				if(	Box.Min.X < -HALF_WORLD_MAX || Box.Max.X > HALF_WORLD_MAX ||
				    Box.Min.Y < -HALF_WORLD_MAX || Box.Max.Y > HALF_WORLD_MAX ||
				    Box.Min.Z < -HALF_WORLD_MAX || Box.Max.Z > HALF_WORLD_MAX )
				{
					//debugf(NAME_Warning, TEXT("%s is outside the world bounds!"), *GetName());
					OutsideWorldBounds();
					// not safe to use physics or collision at this point
					SetCollision(FALSE, FALSE, bIgnoreEncroachers);
					setPhysics(PHYS_None);
				}
			}
		}
		
		public virtual void SetZone( UBOOL bTest, UBOOL bForceRefresh )
		{
			if( bDeleteMe )
			{
				return;
			}

			// update physics volume
			PhysicsVolume NewVolume = GWorld.GetWorldInfo().GetPhysicsVolume(Location,this,bCollideActors && !bTest && !bForceRefresh);
			if( !bTest )
			{
				if( NewVolume != PhysicsVolume )
				{
					if( PhysicsVolume )
					{
						PhysicsVolume.ActorLeavingVolume(this);
						PhysicsVolumeChange(NewVolume);
					}
					PhysicsVolume = NewVolume;
					PhysicsVolume.ActorEnteredVolume(this);
				}
			}
			else
			{
				PhysicsVolume = NewVolume;
			}
		}
		
		public virtual PortalTeleporter GetAPortalTeleporter() { return this as PortalTeleporter; }
		
		public int fixedTurn(int current, int desired, int deltaRate)
		{
			if (deltaRate == 0)
				return (current & 65535);

			int result = current & 65535;
			current = result;
			desired = desired & 65535;

			if (current > desired)
			{
				if (current - desired < 32768)
					result -= Min((current - desired), Abs(deltaRate));
				else
					result += Min((desired + 65536 - current), Abs(deltaRate));
			}
			else
			{
				if (desired - current < 32768)
					result += Min((desired - current), Abs(deltaRate));
				else
					result -= Min((current + 65536 - desired), Abs(deltaRate));
			}
			return (result & 65535);
		}
	}



	public partial class ActorComponent
	{
		public void ConditionalTick(FLOAT DeltaTime)
		{
			if(bAttached)
			{
				Tick(DeltaTime);
			}
		}
		public virtual void Tick(float deltaTime) => check(bAttached);
		public UBOOL NeedsUpdateTransform(){ return bNeedsUpdateTransform; }
		public virtual void BeginPlay()
		{
			check(bAttached);
		}
		
		public virtual void ConditionalBeginPlay()
		{
			if(bAttached)
			{
				BeginPlay();
			}
		}
		
		public void BeginDeferredReattach()
		{
			bNeedsReattach = TRUE;

			if(Owner)
			{
				// If the component has a static owner, reattach it directly.
				// If it has a dynamic owner, it will be reattached at the end of the tick.
				if(Owner.bStatic)
				{
					Owner.ConditionalUpdateComponents(FALSE);
				}
			}
			else
			{
				// If the component doesn't have an owner, reattach it directly using its existing transform.
				//FComponentReattachContext(this);
				throw new NotImplementedException();
			}
		}
		public void BeginDeferredUpdateTransform()
		{
			bNeedsUpdateTransform = TRUE;

			if(Owner)
			{
				// If the component has a static owner, update its transform directly.
				// If it has a dynamic owner, it will be updated at the end of the tick.
				if(Owner.bStatic)
				{
					Owner.ConditionalUpdateComponents(FALSE);
				}
			}
			else
			{
				// If the component doesn't have an owner, just call UpdateTransform without actually applying a new transform.
				ConditionalUpdateTransform();
			}
		}
		public virtual void SetParentToWorld( in FMatrix ParentToWorld )
		{
		}



		public UBOOL IsAttached(){ return bAttached; }
		public Actor GetOwner(){ return Owner; }
		public virtual void UpdateTransform()
		{
			check(bAttached);
		}



		public void UpdateComponent(FSceneInterface InScene,Actor InOwner,in FMatrix InLocalToWorld, UBOOL bCollisionUpdate=FALSE)
		{
			#if LOG_DETAILED_COMPONENT_UPDATE_STATS
			static QWORD LastFrameCounter = 0;
			if( LastFrameCounter != GFrameCounter )
			{
				GDetailedComponentUpdateStats.DumpStats();
				GDetailedComponentUpdateStats.Reset();
				LastFrameCounter = GFrameCounter;
			}
			#endif

			{
				//TRACK_DETAILED_COMPONENT_UPDATE_STATS(this);

				if( !IsAttached() )
				{
					// initialize the component if it hasn't already been
					ConditionalAttach(InScene,InOwner,InLocalToWorld);
				}
				else if(bNeedsReattach)
				{
					// Reattach the component if it has changed since it was last updated.
					ConditionalDetach();
					ConditionalAttach(InScene,InOwner,InLocalToWorld);
				}
				else if(bNeedsUpdateTransform)
				{
					// Update the component's transform if the actor has been moved since it was last updated.
					ConditionalUpdateTransform(InLocalToWorld);
				}
			}

			// Update the components attached indirectly via this component.
			//@note - testing whether or not we can skip this for collision only updates to improve performance
			if (!bCollisionUpdate)
			{
				UpdateChildComponents();
			}
		}
		
		public virtual void UpdateChildComponents()
		{
		}



		public void ConditionalDetach( UBOOL bWillReattach = false )
		{
			if(bAttached)
			{
				Detach( bWillReattach );
			}
			Scene = default;
			Owner = null;
		}
		
		void DetachFromAny()
		{
			if (IsAttached())
			{
				// if there is no owner, just call Detach()
				if (Owner == NULL)
				{
					ConditionalDetach();
				}
				else
				{
					// try to detach from the actor directly
					Owner.DetachComponent(this);
					if (IsAttached())
					{
						// check if the owner has any SkeletalMeshComponents, and if so make sure this component is not attached to them
						// we could optimize this by adding a pointer to ActorComponent for the SkeletalMeshComponent it's attached to
						for (INT i = 0; i < Owner.AllComponents.Num(); i++)
						{
							SkeletalMeshComponent Mesh = Owner.AllComponents[i] as SkeletalMeshComponent;
							if (Mesh != NULL && DetachComponentFromMesh(this, Mesh))
							{
								break;
							}
						}
					}
				}
				check(!IsAttached());
			}
		}
		
		static UBOOL DetachComponentFromMesh(ActorComponent Component, SkeletalMeshComponent Mesh)
		{
			Mesh.DetachComponent(Component);
			if (!Component.IsAttached())
			{
				// successfully removed from Mesh
				return TRUE;
			}
			else
			{
				// iterate over attachments and recurse over any SkeletalMeshComponents found
				for (INT i = 0; i < Mesh.Attachments.Num(); i++)
				{
					SkeletalMeshComponent AttachedMesh = (Mesh.Attachments[i].Component) as SkeletalMeshComponent;
					if (AttachedMesh != NULL && DetachComponentFromMesh(Component, AttachedMesh))
					{
						return TRUE;
					}
				}

				return FALSE;
			}
		}
		public virtual UBOOL IsValidComponent() 
		{ 
			return IsPendingKill() == FALSE; 
		}
		public void ConditionalAttach(FSceneInterface InScene,Actor InOwner,in FMatrix ParentToWorld)
		{
			// If the component was already attached, detach it before reattaching.
			if(IsAttached())
			{
				DetachFromAny();
			}

			bNeedsReattach = FALSE;
			bNeedsUpdateTransform = FALSE;

			//Scene = InScene;
			Owner = InOwner;
			SetParentToWorld(ParentToWorld);
			if(IsValidComponent())
			{
				Attach();
			}
		}
		
		/**
		 * Conditionally calls UpdateTransform if bAttached == true.
		 * @param ParentToWorld - The ParentToWorld transform the component is attached to.
		 */
		public void ConditionalUpdateTransform(in FMatrix ParentToWorld)
		{
			bNeedsUpdateTransform = FALSE;

			SetParentToWorld(ParentToWorld);
			if(bAttached)
			{
				UpdateTransform();
			}
		}

		/**
		 * Conditionally calls UpdateTransform if bAttached == true.
		 */
		public void ConditionalUpdateTransform()
		{
			if(bAttached)
			{
				UpdateTransform();
			}
		}
		/**
		 * Detaches the component from the scene it is in.
		 * Requires bAttached == true
		 */
		public virtual void Detach( UBOOL bWillReattach )
		{
			check(IsAttached());

			bAttached = FALSE;

			if(Owner)
			{
				// Remove the component from the owner's list of all owned components.
				Owner.AllComponents.RemoveItem(this);
			}
		}
		
		public virtual void Attach()
		{
			/*checkf(!HasAnyFlags(RF_Unreachable), TEXT("%s"), *GetFullName());
			checkf(!GetOuter()->IsTemplate(), TEXT("'%s' (%s)"), *GetOuter()->GetFullName(), *GetFullName());
			checkf(!IsTemplate(), TEXT("'%s' (%s)"), *GetOuter()->GetFullName(), *GetFullName() );
			check(Scene);
			check(IsValidComponent());*/
			check(!IsAttached());
			check(!IsPendingKill());

			bAttached = TRUE;

			if(Owner)
			{
				check(!Owner.IsPendingKill());
				// Add the component to the owner's list of all owned components.
				Owner.AllComponents.AddItem(this);
			}
		}
	}



	public partial class PlayerController
	{
		// Export UPlayerController::execGetViewTarget(FFrame&, void* const)
		public override /*native function */Actor GetViewTarget()
		{
			if( PlayerCamera )
			{
				return PlayerCamera.GetViewTarget();
			}

			if ( RealViewTarget && !RealViewTarget.bDeleteMe )
			{
				if ( !ViewTarget || ViewTarget.bDeleteMe || !ViewTarget.GetAPawn() || (ViewTarget.GetAPawn().PlayerReplicationInfo != RealViewTarget) )
				{
					// not viewing pawn associated with RealViewTarget, so look for one
					// Assuming on server, so PRI Owner is valid
					if ( !RealViewTarget.Owner )
					{
						RealViewTarget = null;
					}
					else
					{
						Controller PRIOwner = RealViewTarget.Owner as Controller;
						if ( PRIOwner )
						{
							if ( PRIOwner as PlayerController && (PRIOwner as PlayerController).ViewTarget && !(PRIOwner as PlayerController).ViewTarget.bDeleteMe )
							{
								UpdateViewTarget((PRIOwner as PlayerController).ViewTarget);
							}
							else if ( PRIOwner.Pawn )
							{
								UpdateViewTarget(PRIOwner.Pawn);
							}
						}
						else
						{
							RealViewTarget = null;
						}
					}
				}
			}

			if ( !ViewTarget || ViewTarget.bDeleteMe )
			{
				if ( Pawn && !Pawn.bDeleteMe && !Pawn.bPendingDelete )
					UpdateViewTarget(Pawn);
				else
					UpdateViewTarget(this);
			}
			return ViewTarget;
		}
		
		public void UpdateViewTarget(Actor NewViewTarget)
		{
			if ( (NewViewTarget == ViewTarget) || !NewViewTarget )
				return;

			Actor OldViewTarget = ViewTarget;
			ViewTarget = NewViewTarget;

			ViewTarget.BecomeViewTarget(this);
			if ( OldViewTarget )
				OldViewTarget.EndViewTarget(this);

			if ( !LocalPlayerController() && (GWorld.GetNetMode() != WorldInfo.ENetMode.NM_Client) )
			{
				ClientSetViewTarget(ViewTarget);
			}
		}
		
		public void SetPlayer( Player InPlayer )
		{
			check(InPlayer!=NULL);

			// Detach old player.
			if( InPlayer.Actor )
				InPlayer.Actor.Player = null;

			// Set the viewport.
			Player = InPlayer;
			InPlayer.Actor = this;

			// cap outgoing rate to max set by server
			NativeMarkers.MarkUnimplemented("Stripped bloat");
			/*NetDriver Driver = GWorld.NetDriver;
			if( (ClientCap>=2600) && Driver && Driver.ServerConnection )
				Player.CurrentNetSpeed = Driver.ServerConnection.CurrentNetSpeed = Clamp( ClientCap, 1800, Driver.MaxClientRate );*/

			// initialize the input system only if local player
			if ( InPlayer as LocalPlayer )
			{
				InitInputSystem();
			}

			// This is done in controller replicated event for clients
			if (GWorld.GetWorldInfo().NetMode != WorldInfo.ENetMode.NM_Client)
			{
				InitUniquePlayerId();
			}
			SpawnPlayerCamera();

			// notify script that we've been assigned a valid player
			ReceivedPlayer();
		}
		public override UBOOL LocalPlayerController()
		{
			return ( Player && Player is LocalPlayer );
		}
		public override UBOOL Tick( FLOAT DeltaSeconds, ELevelTick TickType )
		{
			bTicked = GWorld.Ticked;

			GetViewTarget();
			if( (RemoteRole == ROLE_AutonomousProxy) && !LocalPlayerController() )
			{
				throw new NotImplementedException();
				#if false
				// kick idlers
				if ( PlayerReplicationInfo )
				{
					if ( (Pawn && ( !GWorld.GetWorldInfo().Game || !GWorld.GetWorldInfo().Game.bKickLiveIdlers || (Pawn.Physics != PHYS_Walking)) ) || !bShortConnectTimeOut || (PlayerReplicationInfo.bOnlySpectator && (ViewTarget != this)) || PlayerReplicationInfo.bOutOfLives 
					|| GWorld.GetWorldInfo().Pauser || (GWorld.GetGameInfo() && (GWorld.GetGameInfo().bWaitingToStartMatch || GWorld.GetGameInfo().bGameEnded || (GWorld.GetGameInfo().NumPlayers < 2))) || PlayerReplicationInfo.bAdmin )
					{
						LastActiveTime = GWorld.GetTimeSeconds();
					}
					else if ( (GWorld.GetGameInfo().MaxIdleTime > 0) && (GWorld.GetTimeSeconds() - LastActiveTime > GWorld.GetGameInfo().MaxIdleTime - 10) )
					{
						if ( GWorld.GetTimeSeconds() - LastActiveTime > GWorld.GetGameInfo().MaxIdleTime )
						{
							GWorld.GetGameInfo().KickIdler(this);
							LastActiveTime = GWorld.GetTimeSeconds() - GWorld.GetGameInfo().MaxIdleTime + 3f;
						}
						else
							KickWarning();
					}
				}

				// force physics update for clients that aren't sending movement updates in a timely manner 
				// this prevents cheats associated with artificially induced ping spikes
				if ( Pawn && !Pawn.bDeleteMe 
					&& (Pawn.Physics!=PHYS_None) && (Pawn.Physics != PHYS_RigidBody)
					&& (GWorld.GetTimeSeconds() - ServerTimeStamp > Max<FLOAT>(DeltaSeconds+0.06f,UCONST_MAXCLIENTUPDATEINTERVAL)) 
					&& (ServerTimeStamp != 0f) )
				{
					// force position update
					if ( !Pawn.Velocity.IsZero() )
					{
						Pawn.performPhysics( GWorld.GetTimeSeconds() - ServerTimeStamp );
					}
					ServerTimeStamp = GWorld.GetTimeSeconds();
					TimeMargin = 0f;
					MaxTimeMargin = ((AGameInfo *)(AGameInfo::StaticClass().GetDefaultActor())).MaxTimeMargin;
				}

				// update viewtarget replicated info
				if( ViewTarget != Pawn )
				{
		            Pawn TargetPawn = ViewTarget ? ViewTarget.GetAPawn() : null; 
					if ( TargetPawn )
					{
						if ( TargetPawn.Controller && TargetPawn.Controller is PlayerController )
							TargetViewRotation = TargetPawn.Controller.Rotation;
						else
							TargetViewRotation = TargetPawn.Rotation;
						TargetEyeHeight = TargetPawn.BaseEyeHeight;
					}
				}

				// Update the actor's script state code.
				ProcessState( DeltaSeconds );
				// Server handles timers for autonomous proxy.
				UpdateTimers( DeltaSeconds );

				// send ClientAdjustment if necessary
				if ( PendingAdjustment.TimeStamp > 0f )
					SendClientAdjustment();
				#endif
			}
			else if( Role>=ROLE_SimulatedProxy )
			{
				// Process PlayerTick with input.
				if ( !PlayerInput )
					InitInputSystem();

				for(INT InteractionIndex = 0;InteractionIndex < Interactions.Num();InteractionIndex++)
					if(Interactions[InteractionIndex])
						Interactions[InteractionIndex].Tick(DeltaSeconds);

				if(PlayerInput)
					PlayerTick(DeltaSeconds);

				for(INT InteractionIndex = 0;InteractionIndex < Interactions.Num();InteractionIndex++)
					if(Interactions[InteractionIndex])
						Interactions[InteractionIndex].Tick(-1.0f);

				// Update the actor's script state code.
				ProcessState( DeltaSeconds );

				UpdateTimers( DeltaSeconds );

				if ( bDeleteMe )
					return true;

				// Perform physics.
				if( Physics!=PHYS_None && Role!=ROLE_AutonomousProxy )
					performPhysics( DeltaSeconds );

				// update viewtarget replicated info
				if( ViewTarget != Pawn )
				{
		            Pawn TargetPawn = ViewTarget ? ViewTarget.GetAPawn() : null; 
					if ( TargetPawn )
					{
						SmoothTargetViewRotation(TargetPawn, DeltaSeconds);
					}
				}

			}

			// Update eyeheight and send visibility updates
			// with PVS, monsters look for other monsters, rather than sending msgs
			if( Role==ROLE_Authority && TickType==ELevelTick.LEVELTICK_All )
			{
				if( SightCounter < 0.0f )
				{
					SightCounter += 0.2f;
				}
				SightCounter = SightCounter - DeltaSeconds;

				if( Pawn && !Pawn.bHidden )
				{
					ShowSelf();
				}
			}

			return true;
		}
		
		public void SmoothTargetViewRotation(Pawn TargetPawn, FLOAT DeltaSeconds)
		{
			if ( TargetPawn.bSimulateGravity )
				TargetViewRotation.Roll = 0;
			BlendedTargetViewRotation.Pitch = BlendRot(DeltaSeconds, BlendedTargetViewRotation.Pitch, TargetViewRotation.Pitch & 65535);
			BlendedTargetViewRotation.Yaw = BlendRot(DeltaSeconds, BlendedTargetViewRotation.Yaw, TargetViewRotation.Yaw & 65535);
			BlendedTargetViewRotation.Roll = BlendRot(DeltaSeconds, BlendedTargetViewRotation.Roll, TargetViewRotation.Roll & 65535);
		}
		
		public INT BlendRot(FLOAT DeltaTime, INT BlendC, INT NewC)
		{
			if ( Abs(BlendC - NewC) > 32767 )
			{
				if ( BlendC > NewC )
					NewC += 65536;
				else
					BlendC += 65536;
			}
			if ( Abs(BlendC - NewC) > 4096 )
				BlendC = NewC;
			else
				BlendC = appTrunc(BlendC + (NewC - BlendC) * Min(1f,24f * DeltaTime));

			return (BlendC & 65535);
		}
	}



	public partial class Camera
	{
		public Actor GetViewTarget()
		{
			// if blending to another view target, return this one first
			if( PendingViewTarget.Target )
			{
				CheckViewTarget(ref PendingViewTarget);
				if( PendingViewTarget.Target )
				{
					return PendingViewTarget.Target;
				}
			}

			CheckViewTarget(ref ViewTarget);
			return ViewTarget.Target;
		}
	}



	public partial class Controller
	{
		public virtual Actor GetViewTarget()
		{
			if ( Pawn )
				return Pawn;
			return this;
		}
		public UBOOL ShouldCheckVisibilityOf(Controller C)
		{
			// only check visibility if this or C is a player, and sightcounter has counted down, and is probing event.
			if ( (bIsPlayer || C.bIsPlayer) && (SightCounter < 0f) /*&& (C.bIsPlayer ? IsProbing(NAME_SeePlayer) : IsProbing(NAME_SeeMonster))*/ )
			{
				// don't check visibility if on same team if bSeeFriendly==false
				return ( bSeeFriendly || (WorldInfo.Game && !WorldInfo.Game.bTeamGame) || !PlayerReplicationInfo || !PlayerReplicationInfo.Team 
				         || !C.PlayerReplicationInfo || !C.PlayerReplicationInfo.Team
				         || (PlayerReplicationInfo.Team != C.PlayerReplicationInfo.Team) );
			}
			return FALSE;
		}
		public virtual UBOOL LocalPlayerController()
		{
			return false;
		}
		public void CheckEnemyVisible()
		{
			if ( Enemy )
			{
				check(Enemy != null/*.IsValid()*/);
				if ( !LineOfSightTo(Enemy) )
					EnemyNotVisible();
			}
		}
		
		public override UBOOL Tick( FLOAT DeltaSeconds, ELevelTick TickType )
		{
			bTicked = GWorld.Ticked;

			if (TickType == ELevelTick.LEVELTICK_ViewportsOnly)
			{
				return TRUE;
			}

			// Ignore controllers whose pawn is in stasis
			if ( (Pawn && Pawn.bStasis && Pawn.InStasis())
			     || (bStasis && InStasis()) )
			{
				return FALSE;
			}

			if( Role>=ROLE_SimulatedProxy )
			{
				TickAuthoritative(DeltaSeconds);
			}
	
			// Update eyeheight and send visibility updates
			// with PVS, monsters look for other monsters, rather than sending msgs

			if( Role==ROLE_Authority && TickType==ELevelTick.LEVELTICK_All )
			{
				if( SightCounter < 0.0f )
				{
					//if( IsProbing(NAME_EnemyNotVisible) )
					{
						CheckEnemyVisible();
					}
					SightCounter += 0.15f + 0.1f * appSRand();
				}

				SightCounter = SightCounter - DeltaSeconds;
				// for best performance, players show themselves to players and non-players (e.g. monsters),
				// and monsters show themselves to players
				// but monsters don't show themselves to each other
				// also

				if( Pawn && !Pawn.bHidden && !Pawn.bAmbientCreature )
				{
					ShowSelf();
				}
			}

			if ( Pawn != NULL )
			{
				UpdatePawnRotation();
			}
			return TRUE;
		}
		public void ShowSelf()
		{
			if ( !Pawn )
				return;
			NativeMarkers.MarkUnimplemented();
			/*for ( Controller C=GWorld.GetFirstController(); C!=null; C=C.NextController )
			{
				if( C!=this && C.ShouldCheckVisibilityOf(this) && C.SeePawn(Pawn) )
				{
					if ( bIsPlayer )
						C.SeePlayer(Pawn);
					else
						C.SeeMonster(Pawn);
				}
			}*/
		}
		
		public UBOOL SeePawn(Pawn Other, UBOOL bMaySkipChecks = TRUE)
		{
			if ( !Other || !Pawn || Other.IsInvisible() )
				return false;

			if (Other != Enemy)
				bLOSflag = !bLOSflag;
			else
				return LineOfSightTo(Other);

			if ( BeyondFogDistance(Pawn.Location, Other.Location) )
				return false;

			FLOAT maxdist = Pawn.SightRadius;

			// fixed max sight distance
			if ( (Other.Location - Pawn.Location).SizeSquared() > maxdist * maxdist )
				return false;

			FLOAT dist = (Other.Location - Pawn.Location).Size();

			// may skip if more than 1/5 of maxdist away (longer time to acquire)
			if ( bMaySkipChecks && (appFrand() * dist > 0.1f * maxdist) )
				return false;

			// check field of view
			FVector SightDir = (Other.Location - Pawn.Location).SafeNormal();
			FVector LookDir = Rotation.Vector();
			FLOAT Stimulus = (SightDir | LookDir);
			if ( Stimulus < Pawn.PeripheralVision )
				return false;

			// need to make this only have effect at edge of vision
			//if ( bMaySkipChecks && (appFrand() * (1.f - Pawn->PeripheralVision) < 1.f - Stimulus) )
			//	return 0;
			if ( bMaySkipChecks && bSlowerZAcquire && (appFrand() * dist > 0.1f * maxdist) )
			{
				// lower FOV vertically
				SightDir.Z *= 2f;
				SightDir.Normalize();
				if ( (SightDir | LookDir) < Pawn.PeripheralVision )
					return false;

				// notice other pawns at very different heights more slowly
				FLOAT heightMod = Abs(Other.Location.Z - Pawn.Location.Z);
				if ( appFrand() * dist < heightMod )
					return false;
			}

			Stimulus = 1;
			NativeMarkers.MarkUnimplemented();
			return false;
			//return LineOfSightTo(Other, bMaySkipChecks);

		}

		
		public void UpdatePawnRotation()
		{
			if ( Focus )
			{
				NavigationPoint NavFocus = (Focus) as NavigationPoint;
				if ( NavFocus && CurrentPath && CurrentPath.Start && (MoveTarget == NavFocus) && !Pawn.Velocity.IsZero() )
				{
					// gliding pawns must focus on where they are going
					if ( Pawn.IsGlider() )
					{
						FocalPoint = bAdjusting ? AdjustLoc : Focus.Location;
					}
					else
					{
						FocalPoint = Focus.Location - CurrentPath.Start.Location + Pawn.Location;
					}
				}
				else
				{
					FocalPoint = Focus.Location;
				}
			}

			// rotate pawn toward focus
			Pawn.rotateToward(FocalPoint);

			// face same direction as pawn
			Rotation = Pawn.Rotation;
		}
		public virtual void PreAirSteering(FLOAT DeltaTime){}
		public virtual void PostAirSteering(FLOAT DeltaTime){}
		public virtual void PostPhysFalling(FLOAT DeltaTime){}
		public virtual void PostPhysWalking(FLOAT DeltaTime){}
		public virtual void PostPhysSpider(FLOAT DeltaTime){}
		public unsafe virtual bool AirControlFromWall(float DeltaTime, ref Vector RealAcceleration) { return FALSE; }
		public virtual void PostScriptDestroyed() {}
		public virtual void SetAdjustLocation(FVector NewLoc)
		{
		}
		public virtual FVector DesiredDirection()
		{
			return Pawn.Velocity;
		}
		public virtual void AdjustFromWall(FVector HitNormal, Actor HitActor)
		{
		}
		public virtual FRotator SetRotationRate(FLOAT deltaTime)
		{
			if (Pawn == NULL || Pawn.IsHumanControlled())
			{
				return FRotator(0,0,0);
			}
			else
			{
				if ( bForceDesiredRotation )
				{
					Pawn.DesiredRotation = DesiredRotation;
				}
				return FRotator(appRound(RotationRate.Pitch * deltaTime), appRound(RotationRate.Yaw * deltaTime), appRound(RotationRate.Roll * deltaTime));
			}
		}
	}



	public partial class SkeletalMesh
	{
		public SkeletalMeshSocket FindSocket(name InSocketName)
		{
			if(InSocketName == NAME_None)
			{
				return null;
			}

			for(INT i=0; i<Sockets.Num(); i++)
			{
				SkeletalMeshSocket Socket = Sockets[i];
				if(Socket && Socket.SocketName == InSocketName)
				{
					return Socket;
				}
			}

			return null;
		}
		
		public INT MatchRefBone(name StartBoneName)
		{
			throw new Exception();
			INT BoneIndex = INDEX_NONE;
			if( StartBoneName != NAME_None )
			{
				if( NameIndexMap.TryGetValue( StartBoneName, out var index ) )
				{
					return index;
				}
				/*INT* IndexPtr = NameIndexMap.Find(StartBoneName);
				if(IndexPtr)
				{
					BoneIndex = *IndexPtr;
				}*/
			}
			return BoneIndex;
		}
	}



	public partial class CylinderComponent
	{
		public override void UpdateBounds()
		{
			FVector BoxPoint = FVector(CollisionRadius,CollisionRadius,CollisionHeight);
			Bounds = new BoxSphereBounds
			{
				Origin = GetOrigin(), 
				BoxExtent = BoxPoint, 
				SphereRadius = BoxPoint.Size()
			};
		}
	
		// Export UCylinderComponent::execSetCylinderSize(FFrame&, void* const)
		public virtual /*native final function */void SetCylinderSize(float NewRadius, float NewHeight)
		{
			CollisionHeight = NewHeight;
			CollisionRadius = NewRadius;
			BeginDeferredReattach();
		}
	}



	public partial class PrimitiveComponent
	{
		public static int CurrentTag;
		public Vector GetOrigin()
		{
			return LocalToWorld.GetOrigin();
		}
		public override void SetParentToWorld(in FMatrix ParentToWorld)
        {
        	CachedParentToWorld = ParentToWorld;
        }
		
		public virtual UBOOL LineCheck( ref CheckResult Result, in FVector End, in FVector Start, in FVector Extent, int TraceFlags )
		{
			NativeMarkers.MarkUnimplemented();
			return false;
		}
		
		public virtual void UpdateBounds()
		{
			Bounds.Origin = FVector(0,0,0);
			Bounds.BoxExtent = FVector(HALF_WORLD_MAX,HALF_WORLD_MAX,HALF_WORLD_MAX);
			Bounds.SphereRadius = appSqrt(3.0f * Square(HALF_WORLD_MAX));
		}
		
		public virtual void SetTransformedToWorld()
		{
			LocalToWorld = CachedParentToWorld;

			if(AbsoluteTranslation)
				LocalToWorld.M[3,0] = LocalToWorld.M[3,1] = LocalToWorld.M[3,2] = 0.0f;

			if(AbsoluteRotation || AbsoluteScale)
			{
				FVector	X = FVector(LocalToWorld.M[0,0],LocalToWorld.M[1,0],LocalToWorld.M[2,0]),
				Y = FVector(LocalToWorld.M[0,1],LocalToWorld.M[1,1],LocalToWorld.M[2,1]),
				Z = FVector(LocalToWorld.M[0,2],LocalToWorld.M[1,2],LocalToWorld.M[2,2]);

				if(AbsoluteScale)
				{
					X.Normalize();
					Y.Normalize();
					Z.Normalize();
				}

				if(AbsoluteRotation)
				{
					X = FVector(X.Size(),0,0);
					Y = FVector(0,Y.Size(),0);
					Z = FVector(0,0,Z.Size());
				}

				LocalToWorld.M[0,0] = X.X;
				LocalToWorld.M[1,0] = X.Y;
				LocalToWorld.M[2,0] = X.Z;
				LocalToWorld.M[0,1] = Y.X;
				LocalToWorld.M[1,1] = Y.Y;
				LocalToWorld.M[2,1] = Y.Z;
				LocalToWorld.M[0,2] = Z.X;
				LocalToWorld.M[1,2] = Z.Y;
				LocalToWorld.M[2,2] = Z.Z;
			}

			LocalToWorld = FScaleRotationTranslationMatrix( Scale * Scale3D , Rotation, Translation) * LocalToWorld; 
			LocalToWorldDeterminant = LocalToWorld.Determinant();
		}
		public virtual UBOOL ShouldCollide()
		{
			return CollideActors && (!Owner || Owner.bCollideActors); 
		}
		public override void UpdateTransform()
		{
			base.UpdateTransform();

			SetTransformedToWorld();

			UpdateBounds();

			NativeMarkers.MarkUnimplemented("Stripped bloat");
			
			// If there primitive collides(or it's the editor) and the scene is associated with a world, update the primitive in the world's hash.
			/*World World = Scene.GetWorld();
			if(ShouldCollide() && World)
			{
				World.Hash.RemovePrimitive(this);
				World.Hash.AddPrimitive(this);
			}*/

			// If the primitive isn't hidden update its transform.
			/*UBOOL bShowInEditor = !HiddenEditor && (!Owner || !Owner.bHiddenEd);
			UBOOL bShowInGame = !HiddenGame && (!Owner || !Owner.bHidden || bIgnoreOwnerHidden || bCastHiddenShadow);
			UBOOL bDetailModeAllowsRendering	= DetailMode <= GSystemSettings.DetailMode;
			if( bDetailModeAllowsRendering && ((GIsGame && bShowInGame) || (!GIsGame && bShowInEditor)) )
			{
				// Update the scene info's transform for this primitive.
				Scene.UpdatePrimitiveTransform(this);
			}*/

			UpdateRBKinematicData();
		}
		
		public virtual void UpdateRBKinematicData()
		{
			#if WITH_NOVODEX
			NxActor* nActor = GetNxActor();

			if(!nActor || !nActor->isDynamic() || !nActor->readBodyFlag(NX_BF_KINEMATIC) || nActor->readBodyFlag(NX_BF_FROZEN))
			{
				return;
			}
		#if !FINAL_RELEASE
			// Check to see if this physics call is illegal during this tick group
			if (GWorld->InTick && GWorld->TickGroup == TG_DuringAsyncWork)
			{
				debugf(NAME_Error,TEXT("Can't call UpdateRBKinematicData() on (%s)->(%s) during async work!"), *Owner->GetName(), *GetName());
			}
		#endif

			// Synchronize the position and orientation of the rigid body to match the actor.
			FVector FullScale;
			FMatrix PrimTM;
			GetTransformAndScale(PrimTM, FullScale);
			check(!PrimTM.ContainsNaN());
			NxMat34 nNewPose = U2NTransform(PrimTM);

			// Don't call moveGlobalPose if we are already in the correct pose. 
			// Also check matrix we are passing in is valid.
			NxMat34 nCurrentPose = nActor->getGlobalPose();
			if( !FullScale.IsNearlyZero() && 
				nNewPose.M.determinant() > (FLOAT)KINDA_SMALL_NUMBER && 
				!MatricesAreEqual(nNewPose, nCurrentPose, (FLOAT)KINDA_SMALL_NUMBER) )
			{
				nActor->moveGlobalPose( nNewPose );
			}
			#endif // WITH_NOVODEX
		}
		
		public override void Detach( UBOOL bWillReattach )
		{
			// Clear the actor's shadow parent if it's the BaseSkelComponent.
			if( Owner && Owner.bShadowParented )
			{
				ShadowParent = null;
			}

			NativeMarkers.MarkUnimplemented("Stripped bloat");
			// If there primitive collides(or it's the editor) and the scene is associated with a world, remove the primitive from the world's hash.
			/*World World = Scene.GetWorld();
			if(World)
			{
				World.Hash.RemovePrimitive(this);
			}

			//remove the fog volume component
			if (FogVolumeComponent)
			{
				Scene.RemoveFogVolume(this);
			}

			// Remove the primitive from the scene.
			Scene.RemovePrimitive(this);

			// Use a fence to keep track of when the rendering thread executes this scene detachment.
			DetachFence.BeginFence();
			if(Owner)
			{
				Owner.DetachFence.BeginFence();
			}*/

			base.Detach( bWillReattach );
		}
		public override void Attach()
		{
			NativeMarkers.MarkUnimplemented("Stripped bloat");
			if( !LightingChannels.bInitialized )
			{
				/*UBOOL bHasStaticShadowing		= HasStaticShadowing();
				LightingChannels.Static			= bHasStaticShadowing;
				LightingChannels.Dynamic		= !bHasStaticShadowing;*/
				LightingChannels.CompositeDynamic = FALSE;
				LightingChannels.bInitialized	= TRUE;
			}

			base.Attach();

			// build the crazy matrix
			SetTransformedToWorld();

			UpdateBounds();

			// If there primitive collides(or it's the editor) and the scene is associated with a world, add it to the world's hash.
			/*UWorld* World = Scene.GetWorld();
			if(ShouldCollide() && World)
			{
				World.Hash.AddPrimitive(this);
			}
	
			//add the fog volume component if one has been set
			if (FogVolumeComponent)
			{
				Scene.AddFogVolume(FogVolumeComponent.CreateFogVolumeDensityInfo(Bounds.GetBox()), this);
			}*/

			// Use BaseSkelComponent as the shadow parent for this actor if requested.
			if( Owner && Owner.bShadowParented )
			{
				ShadowParent = Owner.BaseSkelComponent;
			}

			// If the primitive isn't hidden and the detail mode setting allows it, add it to the scene.
			/*UBOOL bShowInEditor				= !HiddenEditor && (!Owner || !Owner.bHiddenEd);
			UBOOL bShowInGame					= !HiddenGame && (!Owner || !Owner.bHidden || bIgnoreOwnerHidden || bCastHiddenShadow);
			UBOOL bDetailModeAllowsRendering	= DetailMode <= GSystemSettings.DetailMode;
			if( bDetailModeAllowsRendering && ((GIsGame && bShowInGame) || (!GIsGame && bShowInEditor)) )
			{
				Scene.AddPrimitive(this);
			}*/
		}
	}



	public partial class WorldInfo
	{
		public PhysicsVolume GetDefaultPhysicsVolume()
		{
			if ( !PhysicsVolume )
			{
				PhysicsVolume = (PhysicsVolume)(GWorld.SpawnActor(ClassT<DefaultPhysicsVolume>()));
			}
			PhysicsVolume.Priority = -1000000;
			PhysicsVolume.bNoDelete = true;
			return PhysicsVolume;
		}
		public unsafe PhysicsVolume GetPhysicsVolume( in FVector Loc, Actor A, UBOOL bUseTouch )
		{
			PhysicsVolume NewVolume = GWorld.GetDefaultPhysicsVolume();
			if (A != NULL)
			{
				// use the base physics volume if possible for skeletal attachments
				if (A.Base != NULL && A.BaseSkelComponent != NULL)
				{
					return A.Base.PhysicsVolume ? A.Base.PhysicsVolume : NewVolume;
				}
				// if this actor has no collision
				if ( !A.bCollideActors && !A.bCollideWorld && GIsGame )
				{
					// use base's physics volume if possible
					if (A.Base != NULL)
					{
						return A.Base.PhysicsVolume ? A.Base.PhysicsVolume : NewVolume;
					}
					else
					{
						// otherwise use the default one
						return NewVolume;
					}
				}
				// check touching array for volumes if possible
				if ( bUseTouch )
				{
					for ( INT Idx = 0; Idx < A.Touching.Num(); Idx++ )
					{
						PhysicsVolume V = A.Touching[Idx] as PhysicsVolume;
						if ( V && (V.Priority > NewVolume.Priority) && (V.bPhysicsOnContact || V.Encompasses(Loc)) )
						{
							NewVolume = V;
						}
					}
					return NewVolume;
				}
			}
			// check for all volumes at that point
			//MemMark Mark = new(GMem);
			for( CheckResult* Link=GWorld.ActorPointCheck( ref GMem, Loc, FVector(0f,0f,0f), (int)TRACE_PhysicsVolumes); Link != null; Link=Link->Next )
			{
				PhysicsVolume V = (PhysicsVolume)(Link->Actor);
				if ( V && (V.Priority > NewVolume.Priority) )
				{
					NewVolume = V;
				}
			}
			//Mark.Pop();

			return NewVolume;
		}
	}



	public partial class SeqAct_Interp
	{
		public InterpGroupInst FindGroupInst(Actor Actor)
		{
			NativeMarkers.MarkUnimplemented();
			return null;
			/*if(!Actor || Actor.bDeleteMe)
			{
				return null;
			}

			for(INT i=0; i<GroupInst.Num(); i++)
			{
				if( GroupInst[i].GetGroupActor() == Actor )
				{
					return GroupInst[i];
				}
			}

			return null;*/
		}
	}



	public partial class BlockingVolume
	{
		public override UBOOL IgnoreBlockingBy( Actor Other )
		{
			return ( Other as Projectile != null );
		}
	}
}



namespace MEdge.Core
{
	public partial class Object
	{
		public UBOOL IsTemplate( EObjectFlags TemplateTypes = (RF_ArchetypeObject|RF_ClassDefaultObject) )
		{
			for ( Object TestOuter = this; TestOuter != null; TestOuter = TestOuter.Outer )
			{
				if ( TestOuter.HasAnyFlags(TemplateTypes) )
					return true;
			}

			return false;
		}
		public virtual void InitExecution()
		{
			NativeMarkers.MarkUnimplemented("Not important, flags and state frame");
		}
	}
}