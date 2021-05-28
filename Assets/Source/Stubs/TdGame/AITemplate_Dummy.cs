namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Dummy : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Dummy()
	{
		// Object Offset:0x00489E04
		ControllerClass = "TdGame.TdAI_Dummy";
		PawnClass = "TdSpContent.TdBotPawn_Dummy";
		AnimationSets = "AS_AI_Assault_TwoHanded.AS_AI_Assault_TwoHanded";
		SkeletalMesh = "CH_TKY_Cop_SWAT.CH_TKY_Cop_SWAT";
	}
}
}