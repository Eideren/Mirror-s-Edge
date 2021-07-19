namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_180Turn : TdMove/*
		config(PawnMovement)*/{
	[Category("Turn")] [config] public float TurnAnimBlendInTime;
	[Category("Turn")] [config] public float TurnAnimBlendOutTime;
	
	public override /*function */bool CanDoMove()
	{
		if(((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			return false;
		}
		if((PawnOwner.Weapon != default) && ((PawnOwner.Weapon) as TdWeapon).IsZooming())
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */TdPlayerController TdPC = default;
		/*local */Object.Rotator WantedRotation = default;
	
		base.StartMove();
		TdPC = ((PawnOwner.Controller) as TdPlayerController);
		if(TdPC != default)
		{
			TdPC.TargetingPawn = default;
		}
		if(((int)PawnOwner.GetWeaponType()) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			if(((int)PawnOwner.CurrentWalkingState) != ((int)TdPawn.WalkingState.WAS_Idle/*0*/))
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "RunTurn180", 1.0f, TurnAnimBlendInTime, TurnAnimBlendOutTime, false, true);			
			}
			else
			{
				PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "StandTurn180Right", 1.0f, TurnAnimBlendInTime, TurnAnimBlendOutTime, false, true);
			}		
		}
		else
		{
			WantedRotation = PawnOwner.Controller.Rotation;
			WantedRotation.Yaw += ((int)(32767.0f));
			SetPreciseRotation(Normalize(WantedRotation), DisableMovementTime);
		}
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/))
		{
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
		}
		PawnOwner.UseRootRotation(true);
		SetTimer(DisableMovementTime);
		PawnOwner.OnTutorialEvent(13);
	}
	
	public override /*simulated function */void StopMove()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PawnOwner.UseRootRotation(false);
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy/*2*/;
		base.StopMove();
	}
	
	public override /*simulated function */void OnTimer()
	{
		if(MoveActiveTime > 0.40f)
		{
			MovementGroup = TdMove.EMovementGroup.MG_Free/*0*/;
		}
		PawnOwner.UseRootRotation(false);
		bDisableFaceRotation = false;
		PawnOwner.FaceRotationTimeLeft = 0.250f;
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/))
		{
			PawnOwner.SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
		}
		SetTimer(0.20f);
	}
	
	public override /*simulated event */void ReachedPreciseRotation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public TdMove_180Turn()
	{
		// Object Offset:0x00598353
		TurnAnimBlendInTime = 0.20f;
		TurnAnimBlendOutTime = 0.20f;
		FrictionModifier = 0.30f;
		bConstrainLook = true;
		bUseCameraCollision = true;
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		DisableMovementTime = 0.30f;
		RedoMoveTime = 0.50f;
		MinLookConstraint = new Rotator
		{
			Pitch=-10000,
			Yaw=-16384,
			Roll=0
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=10000,
			Yaw=16384,
			Roll=0
		};
	}
}
}