namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_SwingJump : TdPhysicsMove/*
		config(PawnMovement)*/{
	public TdSwingVolume TargetVolume;
	[config] public float GravityModifier;
	[config] public float GravityModifierTimer;
	[config] public Object.Vector TargetVolumeOffset;
	
	public override /*function */bool CanDoMove()
	{
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector PawnToSwing = default;
		/*local */float DistanceToTarget = default;
	
		PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Swing/*60*/, default(float?));
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, 0.30f);
		base.StartMove();
		if(TargetVolume != default)
		{
			PawnOwner.GravityModifier = GravityModifier;
			PawnOwner.GravityModifierTimer = GravityModifierTimer;
			PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
			PawnToSwing = TargetVolume.Location - PawnOwner.Location;
			DistanceToTarget = VSize2D(TargetVolume.Location - PawnOwner.Location);
			SetPreciseLocation((TargetVolume.Location + (Normal(PawnToSwing) * TargetVolumeOffset.X)) + (vect(0.0f, 0.0f, 1.0f) * TargetVolumeOffset.Z), TdMove.EPreciseLocationMode.PLM_SimJump/*3*/, DistanceToTarget / 0.90f);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("SwingOff")), 1.0f, 0.20f, 0.20f, false, default(bool?));
			SetTimer(0.90f);
			if(PawnOwner.Weapon != default)
			{
				PawnOwner.SetUnarmed();
				MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy/*2*/;
				AimMode = TdPawn.MoveAimMode.MAM_NoHands/*3*/;
			}
		}
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
	}
	
	public TdMove_SwingJump()
	{
		// Object Offset:0x005E7D26
		GravityModifier = 0.730f;
		GravityModifierTimer = 0.750f;
		TargetVolumeOffset = new Vector
		{
			X=-120.0f,
			Y=0.0f,
			Z=-20.0f
		};
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bCheckForWallClimb = true;
		bCheckExitToFalling = true;
		bTriggersCompliment = true;
		bConstrainLook = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 200.0f,
			Medium = 200.0f,
			Hard = 200.0f,
		};
		MinLookConstraint = new Rotator
		{
			Pitch=-11000,
			Yaw=-32768,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=16384,
			Yaw=32768,
			Roll=32768
		};
	}
}
}