namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_GrabPullUp : TdPhysicsMove/*
		config(PawnMovement)*/{
	public enum EGrabPullUpType 
	{
		GPUT_IntoWalking,
		GPUT_IntoCrouch,
		GPUT_MAX
	};
	
	public TdMove_GrabPullUp.EGrabPullUpType GrabPullUpType;
	public Object.Vector FloorOverLedgeLocation;
	public/*(Gameplay)*/ /*config */int GrabAllowedPullUpAngle;
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Rotator ControllerRotation = default;
		/*local */float FindFloorDepthCheck = default, LedgeAndFloorDeltaHeight = default, MaxLedgeThickness = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		if(((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/))
		{
			return false;
		}
		if(!((PawnOwner.Moves[3]) as TdMove_Grab).CanPullUp())
		{
			return false;
		}
		ControllerRotation = Normalize(PawnOwner.Rotation - PawnOwner.Controller.Rotation);
		if(Abs(((float)(ControllerRotation.Yaw))) > (((float)(32768 * GrabAllowedPullUpAngle)) / 180.0f))
		{
			return false;
		}
		FloorOverLedgeLocation = PawnOwner.Location;
		FloorOverLedgeLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		MaxLedgeThickness = 5.0f;
		FindFloorDepthCheck = 64.0f + MaxLedgeThickness;
		FindFloorOverLedge(FindFloorDepthCheck, ref/*probably?*/ FloorOverLedgeLocation, PawnOwner.MaxStepHeight + 4.0f);
		LedgeAndFloorDeltaHeight = FloorOverLedgeLocation.Z - PawnOwner.MoveLedgeLocation.Z;
		if(LedgeAndFloorDeltaHeight > -PawnOwner.MaxStepHeight)
		{
			return CanPullUp(63.0f);		
		}
		else
		{
			if(!CanPullUp(90.0f + MaxLedgeThickness))
			{
				FloorOverLedgeLocation.Z = PawnOwner.MoveLedgeLocation.Z;
				return CanPullUp(63.0f);
			}
			return true;
		}
		return false;
	}
	
	public virtual /*function */bool CanPullUp(float CheckDepth)
	{
		/*local */TdMove_Grab GrabMove = default;
		/*local */float HighestLocation = default;
	
		GrabMove = ((PawnOwner.Moves[3]) as TdMove_Grab);
		HighestLocation = PawnOwner.MoveLedgeLocation.Z + (Tan(Acos(PawnOwner.MoveLedgeNormal.Z)) * PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius);
		if(CanHeaveOverLedgeFullyExtented(CheckDepth, FloorOverLedgeLocation, HighestLocation))
		{
			GrabPullUpType = TdMove_GrabPullUp.EGrabPullUpType.GPUT_IntoWalking/*0*/;
			return true;		
		}
		else
		{
			if((((int)GrabMove.GetCurrentFoldedType()) != ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/)) && CanHeaveOverLedgeCrouched(CheckDepth, FloorOverLedgeLocation, HighestLocation))
			{
				GrabPullUpType = TdMove_GrabPullUp.EGrabPullUpType.GPUT_IntoCrouch/*1*/;
				if(FloorOverLedgeLocation.Z < (PawnOwner.MoveLedgeLocation.Z - PawnOwner.MaxStepHeight))
				{
					return false;
				}
				return true;
			}
		}
		return false;
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */bool bHangingFree = default, bHeaveOver = default;
		/*local */float TimeToReleaseCamera = default, TimeToEnableCollision = default;
	
		base.StartMove();
		bHeaveOver = FloorOverLedgeLocation.Z < (PawnOwner.MoveLedgeLocation.Z - PawnOwner.MaxStepHeight);
		bHangingFree = ((PawnOwner.Moves[3]) as TdMove_Grab).IsHangingFree();
		if(((int)((PawnOwner.Moves[3]) as TdMove_Grab).GetCurrentFoldedType()) == ((int)TdMove_Grab.EGrabFoldedType.GFT_Start/*1*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "HangFoldedHeaveUp", 1.0f, 0.10f, 0.20f, true, default(bool?));
			((PawnOwner.Moves[3]) as TdMove_Grab).SetCurrentFoldedType(TdMove_Grab.EGrabFoldedType.GFT_None/*0*/);
			TimeToReleaseCamera = 0.80f;
			TimeToEnableCollision = 0.80f;		
		}
		else
		{
			if(!bHeaveOver)
			{
				if(bHangingFree)
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)GrabPullUpType) == ((int)TdMove_GrabPullUp.EGrabPullUpType.GPUT_IntoCrouch/*1*/)) ? "hangfreeheaveuptocrouch" : "HangFreeHeaveUp"), 1.0f, 0.10f, 0.20f, PawnOwner.IsLocallyControlled(), default(bool?));				
				}
				else
				{
					PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((((int)GrabPullUpType) == ((int)TdMove_GrabPullUp.EGrabPullUpType.GPUT_IntoCrouch/*1*/)) ? "HangHeaveUpToCrouch" : "HangHeaveUp"), 1.0f, 0.10f, 0.20f, PawnOwner.IsLocallyControlled(), default(bool?));
				}
				TimeToReleaseCamera = 0.80f;
				TimeToEnableCollision = 1.40f;			
			}
			else
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((bHangingFree) ? "HangFreeHeaveOver" : "HangHeaveOver"), 1.0f, 0.20f, 0.20f, PawnOwner.IsLocallyControlled(), default(bool?));
				TimeToReleaseCamera = ((bHangingFree) ? 0.70f : 0.60f);
				TimeToEnableCollision = 0.60f;
			}
		}
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Grabbing/*3*/, default(float?));
		if(((int)GrabPullUpType) == ((int)TdMove_GrabPullUp.EGrabPullUpType.GPUT_IntoCrouch/*1*/))
		{
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Crouch/*15*/, 0.20f);		
		}
		else
		{
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, 0.20f);
		}
		bDisableFaceRotation = true;
		PawnOwner.UseRootMotion(true);
		ResetCameraLook(DisableLookTime);
		PawnOwner.Mesh.bUseLegRotationHack1 = true;
		PawnOwner.UpdateLegToWorldMatrix(((Rotator)(-PawnOwner.MoveNormal)).Yaw);
		SetMoveTimer(TimeToReleaseCamera, false, "ReleaseCamera");
		SetMoveTimer(TimeToEnableCollision, false, "EnableCollision");
	}
	
	public virtual /*simulated function */void ReleaseCamera()
	{
		bDisableFaceRotation = false;
		PawnOwner.FaceRotationTimeLeft = 0.250f;
		AbortLookAtTarget();
	}
	
	public virtual /*simulated function */void EnableCollision()
	{
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
		PawnOwner.Mesh.bUseLegRotationHack1 = false;
		PawnOwner.StopIgnoreMoveInput();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		EnableCollision();
		PawnOwner.DisableHandsWorldIK(default(float?));
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		PawnOwner.UseRootMotion(false);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.UseRootMotion(false);
		PawnOwner.Acceleration = Normal(PawnOwner.Velocity);
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		PawnOwner.SetMove(((TdPawn.EMovement)((((int)GrabPullUpType) == ((int)TdMove_GrabPullUp.EGrabPullUpType.GPUT_IntoCrouch/*1*/)) ? 15 : 1)), default(bool?), default(bool?));
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		return PawnOwner.Health - 1;
	}
	
	public override /*function */void CheckForCameraCollision(Object.Vector CameraLocation, Object.Rotator CameraRotation)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default, TraceEnd = default, TraceStart = default, TraceExtent = default;
	
		TraceStart = CameraLocation - (((Vector)(PawnOwner.Controller.Rotation)) * 5.0f);
		TraceEnd = CameraLocation + (((Vector)(PawnOwner.Controller.Rotation)) * 20.0f);
		TraceExtent = vect(2.0f, 2.0f, 2.0f);
		if(MovementTraceForBlockingEx(TraceEnd, TraceStart, TraceExtent, ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal))
		{
			PawnOwner.OffsetMeshXY(HitLocation - TraceEnd, true);
		}
	}
	
	public TdMove_GrabPullUp()
	{
		// Object Offset:0x005BD893
		GrabAllowedPullUpAngle = 45;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerWalking";
		bDisableCollision = true;
		bShouldHolsterWeapon = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bUseCameraCollision = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableMovementTime = -1.0f;
		DisableLookTime = 0.20f;
		MinLookConstraint = new Rotator
		{
			Pitch=0,
			Yaw=-10000,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16384,
			Yaw=10000,
			Roll=0
		};
	}
}
}