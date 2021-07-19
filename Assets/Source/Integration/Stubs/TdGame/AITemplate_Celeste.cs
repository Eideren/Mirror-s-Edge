namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Celeste : AITemplate_PursuitCop/*
		config(AITemplates)
		editinlinenew*/{
	public partial struct /*native */HitsToTakeStruct
	{
		public int Easy;
		public int Medium;
		public int Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00489677
	//		Easy = 0;
	//		Medium = 0;
	//		Hard = 0;
	//	}
	};
	
	[config] public AITemplate_Celeste.HitsToTakeStruct NrOfHitsToTake;
	
	public AITemplate_Celeste()
	{
		// Object Offset:0x00489733
		NrOfHitsToTake = new AITemplate_Celeste.HitsToTakeStruct
		{
			Easy = 5,
			Medium = 8,
			Hard = 8,
		};
		ControllerClass = "TdGame.TdAI_Celeste";
		PawnClass = "TdSpBossContent.TdBotPawn_Celeste";
		ProfileName = "BossCeleste";
		AnimationSets[0] = "AS_BF_SP07_PursuitFemale.AS_BF_SP07_PursuitFemale";
		SkeletalMesh = "CH_TKY_Cop_Pursuit_Female.SK_TKY_Cop_Pursuit_Female";
		ExtraFaithAnimationSet1p = "AS_BF_SP07_PursuitFemale.AS_BF_SP07_PursuitFemale_Character1p";
		ExtraFaithAnimationSet3p = "AS_BF_SP07_PursuitFemale.AS_BF_SP07_PursuitFemale_Faith";
		LegOffsetWalkFwd = 0.0f;
		LegOffsetRunLeft90 = 0.0f;
		LegOffsetRunRight90 = 0.0f;
		Dispersion_Max = 35.0f;
		Dispersion_Min = 25.0f;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 50.0f,
			Medium = 50.0f,
			Far = 50.0f,
		};
		HorizontalOffset_Min = 5.0f;
		VerticalOffset_Max = 40.0f;
		VerticalOffset_Min = 10.0f;
		OffsetThreshold = new AITemplate.DistanceBasedValue
		{
			Near = 45.0f,
			Medium = 45.0f,
			Far = 45.0f,
		};
		MoveSidewaysMultiplier = 0.50f;
		MoveAwayMultiplier = 0.10f;
		MoveTowardMultiplier = 1.0f;
		ImprovementRates_Near = new AITemplate.ImprovementRateSettings
		{
			Easy = 15.0f,
			Medium = 30.0f,
			Hard = 25.0f,
		};
		ImprovementRates_Medium = new AITemplate.ImprovementRateSettings
		{
			Easy = 10.0f,
			Medium = 15.0f,
			Hard = 20.0f,
		};
		ImprovementRates_Far = new AITemplate.ImprovementRateSettings
		{
			Easy = 5.0f,
			Medium = 10.0f,
			Hard = 15.0f,
		};
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_BerettaM93R";
		MeleeRange = 3000.0f;
	}
}
}