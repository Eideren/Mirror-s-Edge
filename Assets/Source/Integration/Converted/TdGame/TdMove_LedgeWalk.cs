namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_LedgeWalk : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public TdLedgeWalkVolume Volume;
	public float CurrentParamOnCurve;
	public float StrafeFactor;
	public float StrafeSpeed;
	public bool bPendingLeavingVolume;
	
	public override /*function */bool CanDoMove()
	{
		switch(PawnOwner.MovementState)
		{
			case TdPawn.EMovement.MOVE_Walking/*1*/:
				return base.CanDoMove();
				break;
			case TdPawn.EMovement.MOVE_Landing/*20*/:
				return base.CanDoMove();
				break;
			case TdPawn.EMovement.MOVE_Balance/*29*/:
				return base.CanDoMove();
				break;
			default:
				return false;
				break;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Rotator LookAtAngle = default;
		/*local */Object.Vector Vel2D = default;
	
		base.StartMove();
		if(((int)Volume.LedgeWalkType) == ((int)TdLedgeWalkVolume.ELedgeWalkType.LWT_NarrowSpace/*1*/))
		{
			SetCustomCollisionSize(10.0f, PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight);
		}
		SetLookAtTargetAngle(((Rotator)(Volume.WallNormal)), 0.50f, 0.50f);
		SetPreciseRotation(((Rotator)(Volume.WallNormal)), 0.50f);
		StrafeFactor = 0.0f;
		LookAtAngle = ((Rotator)(Volume.WallNormal));
		Vel2D = Normal(PawnOwner.Velocity);
		Vel2D.Z = 0.0f;
		if(((int)Volume.LedgeWalkType) == ((int)TdLedgeWalkVolume.ELedgeWalkType.LWT_Ledge/*0*/))
		{
			LookAtAngle.Pitch = MinLookConstraint.Pitch + 7000;
			SetLookAtTargetAngle(LookAtAngle, 0.20f, default(float?));		
		}
		else
		{
			if(Cross(Volume.WallNormal, Vel2D).Z < 0.0f)
			{
				LookAtAngle.Yaw += MinLookConstraint.Yaw;			
			}
			else
			{
				LookAtAngle.Yaw += MaxLookConstraint.Yaw;
			}
			if(VSize2D(PawnOwner.Velocity) > 50.0f)
			{
				SetLookAtTargetAngle(LookAtAngle, 0.20f, default(float?));
			}
		}
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		bPendingLeavingVolume = false;
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("LedgeInto")), 1.0f, 0.20f, 0.30f, false, default(bool?));
		CheckLedgeWalkType();
	}
	
	public virtual /*simulated function */void CheckLedgeWalkType()
	{
		if(Volume != default)
		{
			switch(Volume.LedgeWalkType)
			{
				case TdLedgeWalkVolume.ELedgeWalkType.LWT_NarrowSpace/*1*/:
					MinLookConstraint.Pitch = -6000;
					break;
				case TdLedgeWalkVolume.ELedgeWalkType.LWT_Ledge/*0*/:
				default:
					MinLookConstraint.Pitch = DefaultAs<TdMove>().MinLookConstraint.Pitch;
					break;
			}
		}
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		base.HandleMoveAction(((TdPawn.EMovementAction)Action));
		if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Jump/*1*/)) && ((int)Volume.LedgeWalkType) == ((int)TdLedgeWalkVolume.ELedgeWalkType.LWT_Ledge/*0*/))
		{
			if(PawnOwner.Moves[11].CanDoMove())
			{
				PawnOwner.Velocity = ((Vector)(PawnOwner.Rotation)) * 200.0f;
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Jump/*11*/, default(bool?), default(bool?));
			}
			return;
		}
		if((((int)Action) != ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/)) && ((int)Action) != ((int)TdPawn.EMovementAction.MA_ShimmyRight/*14*/))
		{
			StrafeSpeed = 0.0f;		
		}
		else
		{
			if(((int)Action) == ((int)TdPawn.EMovementAction.MA_ShimmyLeft/*12*/))
			{
				StrafeSpeed = 80.0f;			
			}
			else
			{
				StrafeSpeed = -80.0f;
			}
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		if(((((DeltaRot.Yaw > 0) || DeltaRot.Yaw < 0)) || ((DeltaRot.Pitch > 0) || DeltaRot.Pitch < 0)))
		{
			AbortLookAtTarget();
		}
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
	}
	
	public virtual /*simulated function */void NotifyLeavingVolume()
	{
		bPendingLeavingVolume = true;
		SetTimer(0.20f);
	}
	
	public virtual /*simulated function */void NotifyEnteringVolume()
	{
		bPendingLeavingVolume = false;
		SetPreciseRotation(((Rotator)(Volume.WallNormal)), 0.50f);
		CheckLedgeWalkType();
	}
	
	public override /*simulated function */void OnTimer()
	{
		if(bPendingLeavingVolume)
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		SetCustomCollisionSize(PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionRadius, PawnOwner.DefaultAs<Pawn>().CylinderComponent.CollisionHeight);
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_LedgeWalk()
	{
		// Object Offset:0x005CB530
		ControllerState = (name)"PlayerLedgeWalking";
		SpeedModifier = 0.10f;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		bDisableControllerFacingPawnYawRotation = true;
		bAvoidLedges = false;
		bEnableAgainstWall = true;
		MovementGroup = TdMove.EMovementGroup.MG_OneHandBusy;
		MinLookConstraint = new Rotator
		{
			Pitch=-14000,
			Yaw=-10000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16384,
			Yaw=10000,
			Roll=32768
		};
	}
}
}