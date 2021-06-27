namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolCop : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolCop()
	{
		// Object Offset:0x0048AA0A
		ControllerClass = "TdGame.TdAI_PatrolCop";
		PawnClass = "TdSpContent.TdBotPawn_PatrolCop";
		ProfileName = "PatrolCopOneHanded";
		AnimationSets[0] = "AS_AI_PatrolCop_OneHanded.AS_AI_PatrolCop_OneHanded";
		SkeletalMesh = "CH_TKY_Cop_Patrol.SK_TKY_Cop_Patrol";
		AdditionalSkeletalMesh = "CH_TKY_Cop_Patrol.SK_TKY_Cop_Patrol_Head_2";
		LegOffsetWalkFwd = 0.0f;
		LegOffsetWalkLeft60 = 0.0f;
		LegOffsetWalkLeftBwd120 = 0.0f;
		LegOffsetWalkRight60 = 0.0f;
		LegOffsetWalkRightBwd120 = 0.0f;
		LegOffsetWalkBack = 0.0f;
		LegOffsetRunRight90 = 0.0f;
		LegOffsetRunRight180 = 0.0f;
		bLeftFootWalkCycle = true;
		bEnableInverseKinematics = true;
		ShouldBlink = false;
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
					OutVal = 300.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 0.40f,
					OutVal = 500.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
		};
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_Colt1911";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 8,
			Medium = 8,
			Hard = 8,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 8,
			Medium = 8,
			Hard = 8,
		};
		DisarmWindow = 0.10f;
		MeleePredictionTimeMin = 0.10f;
		MeleePredictionTimeMax = 0.20f;
		MaxEyesOffsetUpper = 0.0f;
		MinEyesOffsetUpper = -0.80f;
		MaxEyesOffsetLower = 0.90f;
		MinEyesOffsetLower = -0.70f;
	}
}
}