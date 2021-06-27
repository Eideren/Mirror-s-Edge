namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_HeliSniper : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_HeliSniper()
	{
		// Object Offset:0x0048A6C8
		ControllerClass = "TdGame.TdAI_HeliSniper";
		PawnClass = "TdSpContent.TdBotPawn_JKSniper";
		ProfileName = "BossJacknifeSniper";
		AnimationSets[0] = "AS_BF_SP09_Jacknife.AS_BF_SP09_Jacknife";
		SkeletalMesh = "CH_TKY_Crim_Jacknife.SK_TKY_Crim_Jacknife";
		ExtraFaithAnimationSet1p = "AS_BF_SP02_Jacknife.AS_BF_SP02_Jacknife_Character1p";
		ExtraFaithAnimationSet3p = "AS_BF_SP02_Jacknife.AS_BF_SP02_Jacknife_Faith";
		bMute = true;
		MoveSidewaysMultiplier = 0.50f;
		MoveTowardMultiplier = 0.50f;
		CosHalfAttackAngle = 0.70f;
	}
}
}