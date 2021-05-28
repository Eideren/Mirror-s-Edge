namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Assault : AITemplate_Default/*
		native
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Assault()
	{
		// Object Offset:0x004882A6
		ControllerClass = "TdGame.TdAI_Assault";
		AnimationSets = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded";
		SkeletalMesh = "CH_TKY_Cop_SWAT.CH_TKY_Cop_SWAT";
		LegOffsetRunRight90 = 0.0f;
		LegOffsetRunRight180 = 0.0f;
		bEnableInverseKinematics = true;
		bEnableMeleePose = true;
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 24,
			Medium = 24,
			Hard = 24,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 24,
			Medium = 24,
			Hard = 24,
		};
		DisarmWindow = 0.280f;
		MeleePredictionTimeMin = 0.080f;
		MeleePredictionTimeMax = 0.380f;
	}
}
}