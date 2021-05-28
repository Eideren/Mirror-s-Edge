namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PursuitCop : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PursuitCop()
	{
		// Object Offset:0x00488D3A
		ControllerClass = "TdGame.TdAI_Pursuit";
		PawnClass = "TdSpContent.TdBotPawn_PursuitCop";
		ProfileName = "PursuitCopOneHanded";
		AnimationSets = "AS_AI_PursuitCop_OneHanded.AS_AI_PursuitCop_OneHanded";
		SkeletalMesh = "CH_TKY_Cop_Pursuit.SK_TKY_Cop_Pursuit";
		LegOffsetWalkLeft60 = 0.0f;
		LegOffsetWalkLeftBwd120 = 0.0f;
		LegOffsetWalkRight60 = 0.0f;
		LegOffsetWalkRightBwd120 = 0.0f;
		LegOffsetWalkBack = 0.0f;
		LegOffsetRunFwd = 0.0f;
		LegOffsetRunLeft180 = 0.0f;
		LegOffsetRunRight180 = 0.0f;
		bCanDoSpecialMoves = true;
		bMute = true;
		Dispersion_Max = 1.0f;
		Dispersion_Min = 1.0f;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 1.0f,
			Medium = 1.0f,
			Far = 1.0f,
		};
		HorizontalOffset_Min = 1.0f;
		VerticalOffset_Max = 1.0f;
		VerticalOffset_Min = 1.0f;
		ImprovementRates_Near_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 10.0f,
			Medium = 10.0f,
			Hard = 10.0f,
		};
		ImprovementRates_Medium_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 10.0f,
			Medium = 10.0f,
			Hard = 10.0f,
		};
		ImprovementRates_Far_CHASE = new AITemplate.ImprovementRateSettings
		{
			Easy = 10.0f,
			Medium = 10.0f,
			Hard = 10.0f,
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
					OutVal = 300.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 0.40f,
					OutVal = 720.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
		};
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_TaserContent";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 0,
			Medium = 0,
			Hard = 0,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 0,
			Medium = 0,
			Hard = 0,
		};
		MeleeRange = 1200.0f;
		SoftLockStrength = 0.60f;
	}
}
}