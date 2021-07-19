namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_SniperCop : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	[Category("BotControl")] [config] public float LoseTargetTime;
	[Category("BotControl")] [config] public float AimOffset;
	[Category("BotControl")] [config] public float RandomWalkSpeed;
	[Category("BotControl")] [config] public float TimeToCalibrateEasy;
	[Category("BotControl")] [config] public float TimeToCalibrateMedium;
	[Category("BotControl")] [config] public float TimeToCalibrateHard;
	[Category("BotControl")] [config] public float TimeToCalibrateOnObjectFactor;
	[Category("BotControl")] [config] public float TriggerBotAccuracy;
	[Category("BotControl")] [config] public float BreakDistance;
	[Category("BotControl")] [config] public float HomingInOnTargetSpeed;
	
	public AITemplate_SniperCop()
	{
		// Object Offset:0x0048CB8B
		LoseTargetTime = 0.50f;
		AimOffset = 600.0f;
		RandomWalkSpeed = 0.070f;
		TimeToCalibrateEasy = 3.0f;
		TimeToCalibrateMedium = 3.0f;
		TimeToCalibrateHard = 3.0f;
		TimeToCalibrateOnObjectFactor = 0.80f;
		TriggerBotAccuracy = 0.70f;
		BreakDistance = 1000.0f;
		HomingInOnTargetSpeed = 1200.0f;
		ControllerClass = "TdGame.TdAI_Sniper";
		PawnClass = "TdSpContent.TdBotPawn_SniperCop";
		ProfileName = "AssaultTwoHanded-M95";
		AnimationSets = new StaticArray<String, String>/*[2]*/()
		{ 
			[0] = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded",
			[1] = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded_M95",
	 	};
		SkeletalMesh = "CH_TKY_Cop_SWAT.SK_TKY_Cop_Swat_Sniper";
		bEnableInverseKinematics = true;
		bEnableMeleePose = true;
		Dispersion_Max = 0.0f;
		Dispersion_Min = 0.0f;
		HorizontalOffset_Max = new AITemplate.DistanceBasedValue
		{
			Near = 100.0f,
			Medium = 100.0f,
			Far = 100.0f,
		};
		OffsetThreshold = new AITemplate.DistanceBasedValue
		{
			Near = 75.0f,
			Medium = 75.0f,
			Far = 75.0f,
		};
		VisionAngle = 60.0f;
		CertainVisionRange = 10000.0f;
		UncertainVisionRange = 20000.0f;
		HearingRange = 8000.0f;
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
		MainWeaponClass = "TdSharedContent.TdWeapon_Sniper_BarretM95";
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
	}
}
}