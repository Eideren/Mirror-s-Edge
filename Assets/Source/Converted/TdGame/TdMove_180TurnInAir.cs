namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_180TurnInAir : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public Object.Rotator WantedRotation;
	
	public override /*function */bool CanDoMove()
	{
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			return false;
		}
		if(((int)PawnOwner.MovementState) == ((int)TdPawn.EMovement.MOVE_SoftLanding/*78*/))
		{
			return false;
		}
		if((Dot(Normal(((Vector)(PawnOwner.Rotation))), Normal(PawnOwner.Velocity))) < 0.20f)
		{
			return false;
		}
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector LookAtPosition = default;
		/*local */TdPlayerController TdPC = default;
	
		base.StartMove();
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("JumpTurnFly")), 1.0f, 0.10f, 0.10f, false, true);
		TdPC = ((PawnOwner.Controller) as TdPlayerController);
		if(TdPC != default)
		{
			TdPC.TargetingPawn = default;
		}
		PawnOwner.UseRootRotation(true);
		LookAtPosition = PawnOwner.LastJumpLocation;
		LookAtPosition.Z += 90.0f;
		SetLookAtTargetLocation(LookAtPosition, 0.30f, 2.0f);
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		PawnOwner.UseRootRotation(false);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.20f);
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if((DeltaRot.Yaw > 0) || DeltaRot.Yaw < 0)
		{
			AbortLookAtTarget();
		}
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		if(SeqNode.AnimSeqName == "JumpTurnFly")
		{
			PawnOwner.UseRootRotation(false);
		}
	}
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		/*local */TdPlayerController TdPC = default;
		/*local */TdPawn P = default;
		/*local */TdBotPawn BotPawn = default;
	
		if((((int)Action) == ((int)TdPawn.EMovementAction.MA_Melee/*3*/)) && ((int)PawnOwner.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Unarmed/*0*/))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, ((name)("Taunt")), 1.0f, 0.10f, 0.20f, default(bool?), default(bool?));
			TdPC = ((PawnOwner.Controller) as TdPlayerController);
			if(TdPC != default)
			{
				
				// foreach TdPC.LocalEnemyActors(ref/*probably?*/ P)
				using var e115 = TdPC.LocalEnemyActors().GetEnumerator();
				while(e115.MoveNext() && (P = (TdPawn)e115.Current) == P)
				{
					BotPawn = ((P) as TdBotPawn);
					if(((((BotPawn != default) && BotPawn.Controller != default) && BotPawn.Controller.Enemy == PawnOwner) && BotPawn.Controller.CanSee(PawnOwner)) && !BotPawn.IsA("TdBotPawn_Tutorial"))
					{
						TdPC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_180Taunt/*10*/);
					}				
				}			
			}
		}
	}
	
	public TdMove_180TurnInAir()
	{
		// Object Offset:0x00599CC4
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		bCheckExitToUncontrolledFalling = true;
		bCheckForSoftLanding = true;
		bConstrainLook = true;
		bLookAtTargetLocation = true;
		bDisableFaceRotation = true;
		bUseCustomCollision = true;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		DisableMovementTime = -1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=0,
			Yaw=-5000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=32768,
			Yaw=5000,
			Roll=32768
		};
		SwanNeckEnableAtPitch = 0;
		SwanNeckForward = 0.0f;
		SwanNeckDown = 0.0f;
	}
}
}