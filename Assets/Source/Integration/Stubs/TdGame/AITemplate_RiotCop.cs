namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_RiotCop : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_RiotCop()
	{
		// Object Offset:0x0048C182
		ControllerClass = "TdGame.TdAI_Riot";
		PawnClass = "TdSpContent.TdBotPawn_RiotCop";
		ProfileName = "RiotCopOneHanded";
		AnimationSets[0] = "AS_AI_RiotCop_OneHanded.AS_AI_RiotCop_OneHanded";
		SkeletalMesh = "CH_TKY_Cop_Riot.SK_TKY_Cop_Riot";
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
		RotationSpeed = 20000;
		MainWeaponClass = "TdSharedContent.TdWeapon_SMG_SteyrTMP";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 30,
			Medium = 30,
			Hard = 30,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 30,
			Medium = 30,
			Hard = 30,
		};
		ShieldClass = "TdGame.TdInv_Shield";
		MeleeRange = 230.0f;
	}
}
}