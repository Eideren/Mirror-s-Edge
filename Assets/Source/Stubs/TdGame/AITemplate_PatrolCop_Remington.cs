namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolCop_Remington : AITemplate_PatrolCop/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolCop_Remington()
	{
		// Object Offset:0x0048B8EF
		PawnClass = "TdSpContent.TdBotPawn_PatrolCop_Remington";
		ProfileName = "PatrolCopTwoHanded";
		AnimationSets = "AS_AI_PatrolCop_TwoHanded.AS_AI_PatrolCop_TwoHanded";
		SkeletalMesh = "CH_TKY_Cop_Patrol.SK_TKY_Cop_Patrol_PK";
		LegOffsetWalkFwd = 0.50f;
		LegOffsetWalkLeft60 = 0.50f;
		LegOffsetWalkLeftBwd120 = 0.50f;
		LegOffsetWalkRight60 = 0.50f;
		LegOffsetWalkRightBwd120 = 0.50f;
		LegOffsetWalkBack = 0.50f;
		bLeftFootWalkCycle = false;
		bEnableMeleePose = true;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 15.0f,
			Medium = 40.0f,
		};
		OffsetThreshold = new AITemplate.DistanceBasedValue
		{
			Near = 10.0f,
			Medium = 20.0f,
		};
		MainWeaponClass = "TdSharedContent.TdWeapon_Shotgun_Remington870";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 5,
			Medium = 5,
			Hard = 5,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 5,
			Medium = 5,
			Hard = 5,
		};
		MeleePredictionTimeMin = 0.180f;
		MeleePredictionTimeMax = 0.380f;
		MeleeAttackLimit = 4;
	}
}
}