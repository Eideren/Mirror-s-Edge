namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolCop_Glock : AITemplate_PatrolCop/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolCop_Glock()
	{
		// Object Offset:0x0048B36C
		ProfileName = "PatrolCopOneHanded-Glock";
		AnimationSets[0] = "AS_AI_PatrolCop_OneHanded.AS_AI_PatrolCop_Onehanded_Glock18";
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_Glock18c";
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
	}
}
}