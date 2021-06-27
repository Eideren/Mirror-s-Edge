namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_SniperCeleste : AITemplate_SniperCop/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_SniperCeleste()
	{
		// Object Offset:0x0048D577
		LoseTargetTime = 2.50f;
		AimOffset = 500.0f;
		TimeToCalibrateEasy = 2.20f;
		TimeToCalibrateMedium = 2.20f;
		TimeToCalibrateHard = 2.20f;
		TriggerBotAccuracy = 1.0f;
		BreakDistance = 500.0f;
		ControllerClass = "TdGame.TdAI_SniperCeleste";
		PawnClass = "TdSpBossContent.TdBotPawn_SniperCeleste";
		ProfileName = "BossCelesteSniper";
		AnimationSets[0] = "AS_AI_PursuitFemale_TwoHanded.AS_AI_PursuitFemale_TwoHanded";
		SkeletalMesh = "CH_TKY_Cop_Pursuit_Female.SK_TKY_Cop_Pursuit_Female";
		bMute = true;
	}
}
}