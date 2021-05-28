namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_Tutorial : AITemplate_Default/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_Tutorial()
	{
		// Object Offset:0x0048E451
		ControllerClass = "TdGame.TdAI_Tutorial";
		PawnClass = "TdGame.TdBotPawn_Tutorial";
		ProfileName = "CelesteUnarmed";
		AnimationSets = "AS_AI_Celeste_Unarmed.AS_AI_Celeste_Unarmed";
		SkeletalMesh = "CH_Celeste.SK_Celeste";
		bEnableMeleePose = true;
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_Colt1911";
		DisarmWindow = 0.480f;
		SoftLockStrength = 0.0f;
		MaxEyesOffsetUpper = 0.320f;
		MaxEyesOffsetLower = 0.20f;
	}
}
}