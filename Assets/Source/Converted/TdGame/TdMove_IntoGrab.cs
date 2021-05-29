namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_IntoGrab : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public/*(Gameplay)*/ /*config */float IntoGrabMaxAngle;
	public/*(Gameplay)*/ /*config */float IntoGrabAlignSpeed;
	public/*(Gameplay)*/ /*config */float IntoGrabMinInitialAlignSpeed;
	public/*(Gameplay)*/ /*config */float GrabMinGrabableZNormal;
	public/*(Gameplay)*/ /*config */Object.Vector GrabDesiredLedgeOffset;
	public/*(Gameplay)*/ /*config */float MinGrabLedgeAdjustDistance;
	public/*(Gameplay)*/ /*config */float IntoGrabMaxDistance;
	public/*(Gameplay)*/ /*config */float IntoGrabZVelocityThreshold;
	public float IntoGrabSpeed;
	public/*(Grab)*/ /*config */float HangFoldedDownwardSpeedLimit;
	public/*(Grab)*/ /*config */float HangFoldedIntoGrabZSpeedThreshold;
	public/*(Grab)*/ /*config */float HangFoldedIntoGrabSpeed2DThreshold;
	public/*(Grab)*/ /*config */float HangFoldedUpperDeltaDistance;
	public/*(Grab)*/ /*config */float HangFoldedLowerDeltaDistance;
	public/*(Grab)*/ /*config */float HangFoldedMaxDistance;
	public/*(Grab)*/ /*config */float HangImpactMinZSpeed;
	public/*(Grab)*/ /*config */float HangHardImpactMinZSpeed;
	public bool bPrepareToGrab;
	public /*private transient */bool bSlopedLedge;
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default);
		return base.HandleDeath(Damage);
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		/*local */Object.Rotator WantedGrabRotation = default;
		/*local */TdMove_Grab GrabMove = default;
	
		if(PawnOwner.Moves[3].CanDoMove())
		{
			bPrepareToGrab = true;
			WantedGrabRotation = ((Rotator)(-PawnOwner.MoveNormal));
			PawnOwner.SetRotation(WantedGrabRotation);
			PawnOwner.SetLocation(PawnOwner.MoveLocation);
			PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
			PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
			GrabMove = ((PawnOwner.Moves[3]) as TdMove_Grab);
			GrabMove.SetGrabType(((TdMove_Grab.EGrabType)GrabMove.CheckWallLegPlacement()));
			GrabMove.PreviousGrabType = ((TdMove_Grab.EGrabType)GrabMove.GetGrabType());
			if(PawnOwner.GrabAnimNode1p != default)
			{
				PawnOwner.GrabAnimNode1p.SetActiveMove(((((int)GrabMove.GetGrabType()) == ((int)TdMove_Grab.EGrabType.GT_LegsOnWall/*0*/)) ? 0 : 1), default);
			}
			if(PawnOwner.GrabAnimNode3p != default)
			{
				PawnOwner.GrabAnimNode3p.SetActiveMove(((((int)GrabMove.GetGrabType()) == ((int)TdMove_Grab.EGrabType.GT_LegsOnWall/*0*/)) ? 0 : 1), default);
			}
			if(((int)GrabMove.CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
			{			
			}
			else
			{
				if((((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallClimbing/*6*/)) && ((PawnOwner.Moves[6]) as TdMove_WallClimb).bPerformedDoubleJump)
				{
					GrabMove.SetGrabFromVerticalWallrun(true);
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "hanghardstartvertical", 1.0f, 0.20f, ((bSlopedLedge) ? 0.80f : 0.20f), default, default);				
				}
				else
				{
					if(GrabMove.IsHangingFree())
					{
						PlayMoveAnim(((TdPawn.CustomNodeType)((bSlopedLedge) ? 6 : 2)), "HangFreeHardStart", 1.0f, 0.10f, 0.20f, default, default);
						GrabMove.StartLookingAtLedgeTime = 0.50f;
						GrabMove.StopLookingAtLedgeTime = 1.0f;					
					}
					else
					{
						if(!bSlopedLedge && IntoGrabSpeed < HangImpactMinZSpeed)
						{
							if(IntoGrabSpeed < HangHardImpactMinZSpeed)
							{
								PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "HangHardStart3", 1.0f, 0.10f, ((bSlopedLedge) ? 0.80f : 0.20f), default, default);
								PlayMoveAnim(TdPawn.CustomNodeType.CNT_Camera/*6*/, "gethitfront", 1.0f, 0.050f, ((bSlopedLedge) ? 0.80f : 0.20f), default, default);
								GrabMove.StartLookingAtLedgeTime = 1.60f;
								GrabMove.StopLookingAtLedgeTime = 2.0f;
								GrabMove.bGrabFromHighZSpeed = true;							
							}
							else
							{
								PlayMoveAnim(((TdPawn.CustomNodeType)((bSlopedLedge) ? 6 : 2)), "HangHardStart2", 1.0f, 0.10f, 0.20f, default, default);
								GrabMove.StartLookingAtLedgeTime = 0.80f;
								GrabMove.StopLookingAtLedgeTime = 1.20f;
							}						
						}
						else
						{
							PlayMoveAnim(((TdPawn.CustomNodeType)((bSlopedLedge) ? 6 : 2)), "HangHardStart", 1.0f, 0.10f, 0.20f, default, default);
							GrabMove.StartLookingAtLedgeTime = 0.50f;
							GrabMove.StopLookingAtLedgeTime = 1.0f;
						}
					}
				}
			}
			GrabMove.ResetCameraLook(0.150f);
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Grabbing/*3*/, default, default);		
		}
		else
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
		}
	}
	
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_IntoClimb/*22*/))
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector WantedGrabLocation = default, MoveNormal2D = default;
		/*local */float NeededHeight = default, NeededSpeed = default, Gravity = default, RelativeExtent = default;
	
		base.StartMove();
		if(PawnOwner.Weapon != default)
		{
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);
		}
		bSlopedLedge = PawnOwner.MoveLedgeNormal.Z < 0.9990f;
		((PawnOwner.Moves[3]) as TdMove_Grab).bSlopedLedge = bSlopedLedge;
		MoveNormal2D = PawnOwner.MoveNormal;
		MoveNormal2D.Z = 0.0f;
		MoveNormal2D = Normal(MoveNormal2D);
		WantedGrabLocation = PawnOwner.MoveLedgeLocation;
		WantedGrabLocation.Z -= GrabDesiredLedgeOffset.Z;
		RelativeExtent = CalculateRelativeExtent(PawnOwner.CylinderComponent.CollisionRadius);
		WantedGrabLocation += (MoveNormal2D * (PawnOwner.CylinderComponent.CollisionRadius + RelativeExtent));
		RootOffset.X += RelativeExtent;
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallClimbing/*6*/))
		{
			Gravity = Abs(PawnOwner.GetGravityZ());
			NeededHeight = PawnOwner.MoveLedgeLocation.Z - (PawnOwner.Location.Z + PawnOwner.CylinderComponent.CollisionHeight);
			NeededSpeed = Sqrt(((float)(Max(0, ((int)((((float)(4)) * (NeededHeight + 4.0f)) * Gravity))))));
			PawnOwner.Velocity.Z = ((float)(Min(((int)(NeededSpeed)), ((int)(PawnOwner.Velocity.Z)))));
		}
		PawnOwner.MoveLocation = WantedGrabLocation;
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_GrabTransfer/*31*/))
		{
			ReachedPreciseLocation();		
		}
		else
		{
			SetPreciseLocation(WantedGrabLocation, TdMove.EPreciseLocationMode.PLM_Fall/*4*/, FMax(IntoGrabAlignSpeed, VSize2D(PawnOwner.Velocity)));
			SetPreciseRotation(((Rotator)(-PawnOwner.MoveNormal)), 0.20f);
		}
		IntoGrabSpeed = PawnOwner.Velocity.Z;
		((PawnOwner.Moves[3]) as TdMove_Grab).SetCurrentFoldedType(TdMove_Grab.EGrabFoldedType.GFT_None/*0*/);
		CheckForFoldedHang();
		bPrepareToGrab = false;
	}
	
	public virtual /*simulated function */void CheckForFoldedHang()
	{
		/*local */TdMove_Grab GrabMove = default;
		/*local */float Vel2D = default, Distance2D = default;
		/*local */Object.Vector FloorOverLedgeLocation = default, StartTrace = default, EndTrace = default, Extent = default;
	
		GrabMove = ((PawnOwner.Moves[3]) as TdMove_Grab);
		Vel2D = VSize2D(PawnOwner.Velocity);
		Distance2D = VSize2D(PawnOwner.MoveLedgeLocation - PawnOwner.Location);
		if(bSlopedLedge)
		{
			return;
		}
		if(IntoGrabSpeed > HangFoldedIntoGrabZSpeedThreshold)
		{
			return;
		}
		if(IntoGrabSpeed < ((float)(-1200)))
		{
			return;
		}
		if(Vel2D < HangFoldedIntoGrabSpeed2DThreshold)
		{
			return;
		}
		if(Distance2D > HangFoldedMaxDistance)
		{
			return;
		}
		if(PawnOwner.MoveLedgeNormal.Z < 0.980f)
		{
			return;
		}
		if(PawnOwner.MoveLedgeLocation.Z > (PawnOwner.Location.Z + HangFoldedUpperDeltaDistance))
		{
			return;
		}
		if(PawnOwner.MoveLedgeLocation.Z < (PawnOwner.Location.Z - HangFoldedLowerDeltaDistance))
		{
			return;
		}
		if(((int)GrabMove.CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
		{
			return;
		}
		if(!GrabMove.IsFacingLedge())
		{
			return;
		}
		StartTrace = PawnOwner.MoveLocation;
		EndTrace = StartTrace;
		EndTrace.Z -= (PawnOwner.CylinderComponent.CollisionHeight + 1.0f);
		Extent = PawnOwner.GetCollisionExtent();
		Extent.Z = 0.0f;
		if(MovementTraceForBlocking(EndTrace, StartTrace, Extent))
		{
			return;
		}
		FloorOverLedgeLocation = PawnOwner.Location;
		FloorOverLedgeLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		FindFloorOverLedge(98.0f, ref/*probably?*/ FloorOverLedgeLocation, PawnOwner.MaxStepHeight + 4.0f);
		if(FloorOverLedgeLocation.Z < (PawnOwner.MoveLedgeLocation.Z - 4.0f))
		{
			return;
		}
		FloorOverLedgeLocation.Z = PawnOwner.MoveLedgeLocation.Z + 4.0f;
		if(!CanHeaveOverLedgeCrouched(98.0f, FloorOverLedgeLocation, FloorOverLedgeLocation.Z))
		{
			return;
		}
		((PawnOwner.Moves[3]) as TdMove_Grab).EnableFoldedHang();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Grabbing/*3*/, default);
		PawnOwner.Velocity.Z = ((float)(Clamp(((int)(PawnOwner.Velocity.Z)), ((int)(HangFoldedDownwardSpeedLimit)), ((int)(HangFoldedIntoGrabZSpeedThreshold)))));
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		RootOffset = DefaultAs<TdMove>().RootOffset;
		if(((int)((PawnOwner.Moves[3]) as TdMove_Grab).CurrentFoldedType) != ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
		{
			((PawnOwner.Moves[3]) as TdMove_Grab).SetCurrentFoldedType(TdMove_Grab.EGrabFoldedType.GFT_None/*0*/);
		}
		if(((int)PawnOwner.PendingMovementState) != ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/))
		{
			if(((int)((PawnOwner.Moves[3]) as TdMove_Grab).CurrentFoldedType) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
			{
				PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
			}
		}
		bPrepareToGrab = false;
	}
	
	public TdMove_IntoGrab()
	{
		// Object Offset:0x005C43D9
		IntoGrabMaxAngle = 70.0f;
		IntoGrabAlignSpeed = 300.0f;
		IntoGrabMinInitialAlignSpeed = -3000.0f;
		GrabMinGrabableZNormal = 0.7070f;
		GrabDesiredLedgeOffset = new Vector
		{
			X=30.0f,
			Y=0.0f,
			Z=92.80f
		};
		MinGrabLedgeAdjustDistance = 32.0f;
		IntoGrabMaxDistance = 200.0f;
		IntoGrabZVelocityThreshold = 150.0f;
		HangFoldedDownwardSpeedLimit = -300.0f;
		HangFoldedIntoGrabZSpeedThreshold = 150.0f;
		HangFoldedIntoGrabSpeed2DThreshold = 50.0f;
		HangFoldedUpperDeltaDistance = 35.0f;
		HangFoldedLowerDeltaDistance = 70.0f;
		HangFoldedMaxDistance = 60.0f;
		HangImpactMinZSpeed = -600.0f;
		HangHardImpactMinZSpeed = -1000.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForVaultOver = true;
		bCheckExitToUncontrolledFalling = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
	}
}
}