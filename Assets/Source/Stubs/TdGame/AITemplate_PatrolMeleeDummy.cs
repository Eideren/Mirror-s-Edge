namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITemplate_PatrolMeleeDummy : AITemplate_MeleeDummy/*
		config(AITemplates)
		editinlinenew*/{
	public AITemplate_PatrolMeleeDummy()
	{
		// Object Offset:0x0048BEE0
		ControllerClass = "TdGame.TdAI_MeleeDummy";
		MainWeaponClass = "TdSharedContent.TdWeapon_Pistol_Colt1911";
	}
}
}