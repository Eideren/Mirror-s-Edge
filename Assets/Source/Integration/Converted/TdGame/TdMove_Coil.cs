namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Coil : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	[config] public float HeightBoostDuration;
	[config] public float TotalHeightBoost;
	[config] public float CoilMinTriggerSpeed;
	[config] public float CoilTime;
	public float HeightBoostLeft;
	
	public override /*function */bool CanDoMove()
	{
		if(PawnOwner.bIsUsingRootRotation)
		{
			return false;
		}
		if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_Falling/*2*/))
		{
			return false;
		}
		if((((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_IntoGrab/*14*/)) && PawnOwner.Velocity.Z < 0.0f)
		{
			return false;
		}
		if(((int)PawnOwner.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/))
		{
			return false;
		}
		if((Dot(((Vector)(PawnOwner.Rotation)), PawnOwner.Velocity)) < CoilMinTriggerSpeed)
		{
			return false;
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		HeightBoostLeft = TotalHeightBoost;
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Crouch/*15*/, default(float?));
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpCoil")), 1.0f, 0.150f, 0.150f, default(bool?), default(bool?));
	}
	
	public override /*simulated function */bool IsThisMoveStringable()
	{
		return AreWeCoilingOverSomething();
	}
	
	public virtual /*simulated function */bool AreWeCoilingOverSomething()
	{
		/*local */Object.Vector TraceStart = default, TraceEnd = default, TraceExtent = default;
		/*local */bool Result = default;
	
		TraceExtent = PawnOwner.GetCollisionExtent() * 0.90f;
		TraceStart = PawnOwner.Location;
		TraceEnd = TraceStart;
		TraceEnd += (PawnOwner.Velocity * 0.50f);
		Result = !MovementTraceForBlocking(TraceEnd, TraceStart, TraceExtent);
		if(Result)
		{
			TraceStart = PawnOwner.Location;
			TraceStart.Z -= TraceExtent.Z;
			TraceEnd = TraceStart;
			TraceEnd += (PawnOwner.Velocity * 0.40f);
			TraceExtent.Z *= ((PawnOwner.Velocity.Z > 0.0f) ? 1.0f : 0.50f);
			Result = MovementTraceForBlocking(TraceEnd, TraceStart, TraceExtent);
		}
		return Result;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpCoilEnd")), 1.0f, 0.250f, 0.350f, default(bool?), default(bool?));
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float?));
	}
	
	public TdMove_Coil()
	{
		// Object Offset:0x005AF364
		HeightBoostDuration = 0.250f;
		TotalHeightBoost = 60.0f;
		CoilMinTriggerSpeed = 100.0f;
		CoilTime = 0.50f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckExitToUncontrolledFalling = true;
		bConstrainLook = true;
		bUseCustomCollision = true;
		bTwoHandedFullBodyAnimations = true;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		MinLookConstraint = new Rotator
		{
			Pitch=-5000,
			Yaw=-32768,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=30000,
			Yaw=32768,
			Roll=32768
		};
	}
}
}