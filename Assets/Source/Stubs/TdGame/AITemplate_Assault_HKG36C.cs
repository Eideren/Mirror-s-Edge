namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Assault_HKG36C : AITemplate_Assault/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Assault_HKG36C()
	{
		// Object Offset:0x00488589
		ProfileName = "AssaultTwoHanded-HKG36C";
		AnimationSets[1] = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded_G36C";
		MainWeaponClass = "TdSharedContent.TdWeapon_AssaultRifle_HKG36";
		MainWeaponAmmoDrops_Dropped = new AITemplate.AmmoDropSettings
		{
			Easy = 27,
			Medium = 27,
			Hard = 27,
		};
		MainWeaponAmmoDrops_Disarmed = new AITemplate.AmmoDropSettings
		{
			Easy = 27,
			Medium = 27,
			Hard = 27,
		};
	}
}
}