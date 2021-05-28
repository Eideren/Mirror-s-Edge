namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_MeleeDummy : AITemplate_Dummy/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_MeleeDummy()
	{
		// Object Offset:0x0048A968
		ControllerClass = "TdGame.TdBotPawn_Dummy";
	}
}
}