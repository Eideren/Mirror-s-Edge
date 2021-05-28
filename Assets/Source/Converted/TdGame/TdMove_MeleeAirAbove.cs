namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeAirAbove : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public /*private */Object.Rotator TargetRotation;
	public /*private */Object.Vector TargetLocation;
	
	public override /*simulated function */void StartMove()
	{
		/*local */TdPawn TargetPawnCached = default;
	
		if((TargetPawn == default) || TargetPawn.IsPendingKill())
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool), default(bool));
			return;
		}
		if(!((TargetPawn.Controller) as TdAIController).StartCannedMove(82))
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool), default(bool));
			return;
		}
		TargetPawnCached = TargetPawn;
		base.StartMove();
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Jump/*11*/, default(float));
		TargetPawn = TargetPawnCached;
		ResetCameraLook(0.20f);
		TargetLocation = TargetPawn.Location + (vect(0.0f, 0.0f, 1.0f) * (TargetPawn.GetCollisionHeight() + PawnOwner.GetCollisionHeight()));
		TargetRotation = ((Rotator)(-((Vector)(TargetPawn.Rotation))));
		SetPreciseLocation(TargetLocation, TdMove.EPreciseLocationMode.PLM_Jump/*2*/, VSize(PawnOwner.Velocity));
		SetPreciseRotation(TargetRotation, 0.20f);
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_None/*0*/, default(float));
		PlayCannedAnim();
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool), default(bool));
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		/*local */Object.Rotator WantedRotation = default, HeadRot = default, Delta = default;
	
		if(bResetCameraLook)
		{
			if(CancelResetCameraLookTime > PawnOwner.WorldInfo.TimeSeconds)
			{
				WantedRotation = PawnOwner.Rotation;
				WantedRotation.Pitch = 0;
				WantedRotation = Normalize(WantedRotation);
				HeadRot = Normalize(out_Rotation);
				Delta = Normalize(WantedRotation - HeadRot);
				out_Rotation += (Delta / FMax(1.0f, (CancelResetCameraLookTime - PawnOwner.WorldInfo.TimeSeconds) / DeltaTime));			
			}
			else
			{
				out_Rotation.Pitch = 0;
				bResetCameraLook = false;
			}
		}
	}
	
	public virtual /*function */void PlayCannedAnim()
	{
		PawnOwner.UseRootMotion(true);
		PawnOwner.UseRootRotation(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "MarioMove", 1.0f, 0.10f, 0.20f, true, true);
		((TargetPawn.Controller) as TdAIController).TriggerCannedAnim(82, "MarioMove");
		SetTimer(1.0f);
	}
	
	public override /*simulated function */void OnTimer()
	{
		TriggerDamage(TargetPawn);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
	}
	
	public override /*event */void TriggerDamage(TdPawn Victim)
	{
		/*local */Actor.TraceHitInfo Hit = default;
		/*local */float Damage = default;
		/*local */Object.Vector HitLocation = default, ImpactMomentum = default;
	
		if(TargetPawn != Victim)
		{
			return;
		}
		((PawnOwner.Controller) as TdPlayerController).AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_LandingOnEnemyHead/*9*/);
		HitLocation = PawnOwner.Mesh3p.GetBoneLocation("RightFoot", default(int));
		Hit.Material = default;
		Hit.PhysMaterial = TargetPawn.Mesh3p.GetPhysicalMaterialFromBone("Neck");
		Hit.BoneName = "Neck";
		Hit.HitComponent = TargetPawn.Mesh3p;
		Damage = MeleeDamage;
		DeliverDamage(Damage, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeAirAbove>(), Hit);
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_MeleeAirAbove()
	{
		// Object Offset:0x005D385D
		bTargeting = false;
		MeleeDamage = 300.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}