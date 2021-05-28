namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Gunner : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Gunner()
	{
		// Object Offset:0x00489F61
		ControllerClass = "TdGame.TdAI_Gunner";
		PawnClass = "TdSpContent.TdBotPawn_SupportHelicopterGunner";
		ProfileName = "SupportCopHelicopter";
		AnimationSets = "AS_AI_Support_TwoHanded.AS_AI_Support_TwoHanded_Helicopter";
		SkeletalMesh = "CH_TKY_Cop_Support.SK_TKY_Cop_Support_LowPoly";
		CanUseSuppressionFire = true;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 200.0f,
			Medium = 200.0f,
		};
		OffsetThreshold = new AITemplate.DistanceBasedValue
		{
			Near = 80.0f,
			Medium = 80.0f,
			Far = 80.0f,
		};
		MoveSidewaysMultiplier = 0.550f;
		MoveAwayMultiplier = -0.20f;
		MoveTowardMultiplier = 1.0f;
		ImprovementRates_Near = new AITemplate.ImprovementRateSettings
		{
			Easy = 15.0f,
			Medium = 30.0f,
			Hard = 35.0f,
		};
		ImprovementRates_Medium = new AITemplate.ImprovementRateSettings
		{
			Easy = 10.0f,
			Medium = 25.0f,
			Hard = 30.0f,
		};
		ImprovementRates_Far = new AITemplate.ImprovementRateSettings
		{
			Easy = 5.0f,
			Medium = 15.0f,
			Hard = 25.0f,
		};
		ImprovementRates_Near_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 15.0f,
			Medium = 30.0f,
			Hard = 35.0f,
		};
		ImprovementRates_Medium_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 10.0f,
			Medium = 25.0f,
			Hard = 30.0f,
		};
		ImprovementRates_Far_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 5.0f,
			Medium = 15.0f,
			Hard = 25.0f,
		};
		CosHalfAttackAngle = 0.680f;
		MainWeaponClass = "TdSharedContent.TdWeapon_Machinegun_FNMinimi";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 70,
			Medium = 45,
			Hard = 20,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 99,
			Medium = 70,
			Hard = 45,
		};
		SuppressionTime = 3.0f;
	}
}
}