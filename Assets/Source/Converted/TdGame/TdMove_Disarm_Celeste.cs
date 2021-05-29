namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Disarm_Celeste : TdMOVE_Disarm/*
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		return true;
	}
	
	public override /*function */void TakeDisarmedPawnsWeapon()
	{
	
	}
	
	public override /*simulated function */void MeleeAttackNotify()
	{
		/*local */Object.Vector HitLocation = default, ImpactMomentum = default;
		/*local */TdPawn Instigator = default;
		/*local */Actor.TraceHitInfo Hit = default;
	
		Instigator = DisarmedPawn;
		HitLocation = PawnOwner.Location + (((Vector)(PawnOwner.Rotation)) * ((float)(30)));
		Hit.Material = default;
		Hit.PhysMaterial = PawnOwner.Mesh3p.GetPhysicalMaterialFromBone("Neck");
		Hit.BoneName = "Neck";
		Hit.HitComponent = PawnOwner.Mesh3p;
		ImpactMomentum = -((Vector)(PawnOwner.Rotation)) * 600.0f;
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default, default);
		((Instigator) as TdBotPawn).bShouldNextMeleeCausePlayerFall = true;
		PawnOwner.TakeDamage(10, Instigator.Controller, HitLocation, ImpactMomentum, ClassT<TdDmgType_MeleeLeft>(), Hit, default);
	}
	
	public override /*function */void ChooseDisarmType(ref Object.Rotator YawOffset)
	{
		/*local */TdAi_Celeste.ECelesteStage BossFightStage = default;
	
		BossFightStage = ((TdAi_Celeste.ECelesteStage)((DisarmedPawn.Controller) as TdAi_Celeste).GetCelesteBossFightStage());
		switch(BossFightStage)
		{
			case TdAi_Celeste.ECelesteStage.EC_Stage1/*0*/:
				YawOffset.Yaw = 0;
				DisarmOffset = 100.0f;
				DisarmAnim = "SnatchFwd2";
				break;
			case TdAi_Celeste.ECelesteStage.EC_Stage2/*1*/:
				YawOffset.Yaw = 0;
				DisarmOffset = 100.0f;
				DisarmAnim = "SnatchFwd3";
				break;
			default:
				break;
		}
	}
	
}
}