namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Assault_MP5K : AITemplate_Assault/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Assault_MP5K()
	{
		// Object Offset:0x004887BD
		ProfileName = "AssaultTwoHanded-MP5K";
		AnimationSets[1] = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded_MP5K";
		MainWeaponClass = "TdSharedContent.TdWeapon_AssaultRifle_MP5K";
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
		DisarmWindow = 0.250f;
	}
}
}