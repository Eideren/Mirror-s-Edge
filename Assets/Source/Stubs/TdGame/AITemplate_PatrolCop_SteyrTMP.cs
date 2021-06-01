namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolCop_SteyrTMP : AITemplate_PatrolCop/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolCop_SteyrTMP()
	{
		// Object Offset:0x0048B5A5
		PawnClass = "TdSpContent.TdBotPawn_PatrolCop_Steyr";
		ProfileName = "PatrolCopOneHanded-SteyrTMP";
		AnimationSets[0] = "AS_AI_PatrolCop_OneHanded.AS_AI_PatrolCop_OneHanded_SteyrTMP";
		SkeletalMesh = "CH_TKY_Cop_Patrol.SK_TKY_Cop_Patrol_PK";
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
		DisarmWindow = 0.150f;
	}
}
}