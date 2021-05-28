namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Assault_Neostead : AITemplate_Assault/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Assault_Neostead()
	{
		// Object Offset:0x00488A0A
		ProfileName = "AssaultTwoHanded-Neostead";
		AnimationSets[1] = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded_Neostead";
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
		MainWeaponClass = "TdSharedContent.TdWeapon_Shotgun_Neostead";
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
		DisarmWindow = 0.120f;
		MeleePredictionTimeMin = 0.180f;
	}
}
}