namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolCop3 : AITemplate_PatrolCop/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolCop3()
	{
		// Object Offset:0x0048B29A
		AdditionalSkeletalMesh = "CH_TKY_Cop_Patrol.SK_TKY_Cop_Patrol_Head_5";
		bEnableMeleePose = true;
	}
}
}