namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolDummy : AITemplate_Dummy/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolDummy()
	{
		// Object Offset:0x0048BD9C
		AnimationSets = "AS_AI_PatrolCop_OneHanded.AS_AI_PatrolCop_OneHanded";
		SkeletalMesh = "CH_TKY_Cop_Patrol.SK_TKY_Cop_Patrol";
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_Colt1911";
	}
}
}