namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_SniperIdiot : AITemplate_SniperCop/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_SniperIdiot()
	{
		// Object Offset:0x0048D816
		LoseTargetTime = 2.50f;
		TimeToCalibrateEasy = 6.0f;
		TimeToCalibrateMedium = 6.0f;
		TimeToCalibrateHard = 6.0f;
		TriggerBotAccuracy = 0.20f;
		HomingInOnTargetSpeed = 500.0f;
	}
}
}