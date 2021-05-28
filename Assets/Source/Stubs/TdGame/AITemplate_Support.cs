namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Support : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public /*config */float GrenadeRange;
	public /*config */float GrenadeDelay;
	
	public AITemplate_Support()
	{
		// Object Offset:0x0048D985
		GrenadeRange = 2000.0f;
		GrenadeDelay = 30.0f;
		ControllerClass = "TdGame.TdAI_Support";
		PawnClass = "TdSpContent.TdBotPawn_Support";
		ProfileName = "SupportTwoHanded";
		AnimationSets = "AS_AI_Support_TwoHanded.AS_AI_Support_TwoHanded";
		SkeletalMesh = "CH_TKY_Cop_Support.SK_TKY_Cop_Support";
		LegOffsetWalkFwd = 0.0f;
		LegOffsetWalkLeft60 = 0.0f;
		LegOffsetWalkLeftBwd120 = 0.0f;
		LegOffsetWalkRight60 = 0.0f;
		LegOffsetWalkRightBwd120 = 0.0f;
		LegOffsetWalkBack = 0.0f;
		LegOffsetRunFwd = 0.0f;
		LegOffsetRunLeft90 = 0.0f;
		LegOffsetRunLeft180 = 0.0f;
		LegOffsetRunRight90 = 0.0f;
		LegOffsetRunRight180 = 0.0f;
		CanRun = false;
		CanUseSuppressionFire = true;
		bEnableMeleePose = true;
		ShouldBlink = false;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 60.0f,
			Medium = 140.0f,
		};
		OffsetThreshold = new AITemplate.DistanceBasedValue
		{
			Far = 120.0f,
		};
		MoveSidewaysMultiplier = 1.0f;
		MoveAwayMultiplier = -0.20f;
		MoveTowardMultiplier = 2.0f;
		SpeedCurve_LightWeapon = new Object.InterpCurveFloat
		{
			Points = new array<Object.InterpCurvePointFloat>
			{
				new Object.InterpCurvePointFloat
				{
					InVal = 0.0f,
					OutVal = 0.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 0.10f,
					OutVal = 400.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 0.80f,
					OutVal = 600.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 4.30f,
					OutVal = 650.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 8.50f,
					OutVal = 700.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 9.0f,
					OutVal = 720.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
		};
		MainWeaponClass = "TdSharedContent.TdWeapon_Machinegun_FNMinimi";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 70,
			Medium = 70,
			Hard = 70,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 70,
			Medium = 70,
			Hard = 70,
		};
		DisarmWindow = 0.10f;
		MeleePredictionTimeMin = 0.080f;
		MeleePredictionTimeMax = 0.280f;
		MeleeAttackLimit = 2;
		SuppressionTime = 2.50f;
		MaxEyesOffsetUpper = 0.30f;
		MaxEyesOffsetLower = 1.80f;
		MinEyesOffsetLower = -0.90f;
	}
}
}