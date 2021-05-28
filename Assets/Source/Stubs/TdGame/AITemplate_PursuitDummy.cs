namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PursuitDummy : AITemplate_Dummy/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PursuitDummy()
	{
		// Object Offset:0x0048BFC7
		AnimationSets = "AS_AI_PursuitCop_OneHanded.AS_AI_PursuitCop_OneHanded";
		SkeletalMesh = "CH_TKY_Cop_Pursuit.SK_TKY_Cop_Pursuit";
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_TaserContent";
	}
}
}