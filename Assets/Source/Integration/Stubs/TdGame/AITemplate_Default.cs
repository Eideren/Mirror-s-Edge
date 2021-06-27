namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Default : AITemplate/*
		native
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Default()
	{
		// Object Offset:0x00487159
		ControllerClass = "TdGame.TdAIController";
		PawnClass = "TdSpContent.TdBotPawn_Assault";
		ProfileName = "AssaultTwoHanded";
		LegOffsetWalkFwd = 0.50f;
		LegOffsetWalkLeft60 = 0.50f;
		LegOffsetWalkLeftBwd120 = 0.50f;
		LegOffsetWalkRight60 = 0.50f;
		LegOffsetWalkRightBwd120 = 0.50f;
		LegOffsetWalkBack = 0.50f;
		LegOffsetRunFwd = 0.50f;
		LegOffsetRunLeft90 = 0.50f;
		LegOffsetRunLeft180 = 0.50f;
		LegOffsetRunRight90 = 0.50f;
		LegOffsetRunRight180 = 0.50f;
		CanRun = true;
		ShouldBlink = true;
		Dispersion_Max = 35.0f;
		Dispersion_Min = 10.0f;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 50.0f,
			Medium = 90.0f,
			Far = 200.0f,
		};
		HorizontalOffset_Min = 5.0f;
		VerticalOffset_Max = 40.0f;
		VerticalOffset_Min = 10.0f;
		OffsetThreshold = new AITemplate.DistanceBasedValue
		{
			Near = 40.0f,
			Medium = 70.0f,
			Far = 130.0f,
		};
		MoveSidewaysMultiplier = 0.80f;
		MoveAwayMultiplier = 0.150f;
		MoveTowardMultiplier = 1.30f;
		ImprovementRates_Near = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 35.0f,
			Hard = 40.0f,
		};
		ImprovementRates_Medium = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 35.0f,
			Hard = 40.0f,
		};
		ImprovementRates_Far = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 35.0f,
			Hard = 40.0f,
		};
		ImprovementRates_Near_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 35.0f,
			Hard = 40.0f,
		};
		ImprovementRates_Medium_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 35.0f,
			Hard = 40.0f,
		};
		ImprovementRates_Far_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 35.0f,
			Hard = 40.0f,
		};
		MeleeAttackLimit_CHASE = 1;
		RegenerationDelay = new AITemplate.ImprovementRateSettings
		{
			Easy = 20.0f,
			Medium = 20.0f,
			Hard = 20.0f,
		};
		MovementRate_Horizontal = 0.90f;
		MovementRate_Vertical = 25.0f;
		CosHalfAttackAngle = 0.950f;
		DamageMultiplier_Head = 2.0f;
		DamageMultiplier_Body = 1.0f;
		VisionAngle = 120.0f;
		CertainVisionRange = 3000.0f;
		UncertainVisionRange = 9000.0f;
		HearingRange = 5000.0f;
		SpeedCurve_HeavyWeapon = new Object.InterpCurveFloat
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
					InVal = 0.50f,
					OutVal = 500.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
		};
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
			},
		};
		RotationSpeed = 60000;
		MainWeaponClass = "TdSharedContent.TdWeapon_AssaultRifle_FNSCARL";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 6,
			Medium = 6,
			Hard = 6,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 6,
			Medium = 6,
			Hard = 6,
		};
		DroppedGrenadeClass = "TdGame.TdProj_SmokeGrenade";
		MaxHealth = 100;
		SuppressionRecoveryTime = 6.0f;
		SuppressionDeclineTime = 2.0f;
		SuppressionDistance = 700.0f;
		SuppressionFactorForDirectHit = 0.30f;
		MeleeRange = 150.0f;
		MeleeRangeSecondAttack = 200.0f;
		DisarmWindow = 0.010f;
		MeleePredictionTimeMin = 0.30f;
		MeleePredictionTimeMax = 0.30f;
		MeleeAttackLimit = 3;
		MeleeLayDownIdleTime = 0.250f;
		SoftLockStrength = 1.20f;
		YawLimitDrop = 140.0f;
		YawLimitActivate = 110.0f;
		YawLimitMin = -70.0f;
		YawLimitMax = 70.0f;
		PitchLimitMin = -20.0f;
		PitchLimitMax = 60.0f;
		HeadAimScale = 0.60f;
		MaxEyesOffsetUpper = 0.420f;
		MinEyesOffsetUpper = -0.40f;
		MaxEyesOffsetLower = 0.40f;
		MinEyesOffsetLower = -0.20f;
		ClosedEyeOffsetUpper = 0.820f;
		ClosedEyeOffsetLower = -0.10f;
	}
}
}