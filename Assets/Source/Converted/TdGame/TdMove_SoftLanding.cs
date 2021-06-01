namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_SoftLanding : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public bool bMovingBackwards;
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		if(((int)PawnOwner.OldMovementState) == ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/))
		{
			PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_180TurnInAir/*25*/, default(float?));
			bMovingBackwards = true;		
		}
		else
		{
			PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("fallinglandintosoftlanding")), 1.0f, 0.60f, 0.20f, true, true, false, false);
			bMovingBackwards = false;
		}
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if((DeltaRot.Yaw > 0) || DeltaRot.Yaw < 0)
		{
			AbortLookAtTarget();
		}
	}
	
	public TdMove_SoftLanding()
	{
		// Object Offset:0x005DA3C5
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckExitToFalling = true;
		bCheckForSoftLanding = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		DisableMovementTime = -1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-16384,
			Yaw=-5000,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16384,
			Yaw=5000,
			Roll=0
		};
	}
}
}