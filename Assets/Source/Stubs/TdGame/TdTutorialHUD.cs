namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTutorialHUD : TdSPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public/*(HUDIcons)*/ Object.Vector2D RaceTimerPos;
	public/*(HUDIcons)*/ Object.Vector2D TutorialInfoPos;
	public /*transient */UIScene TutorialMessageScene;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public TdTutorialHUD()
	{
		// Object Offset:0x0067EDF2
		RaceTimerPos = new Vector2D
		{
			X=50.0f,
			Y=20.0f
		};
		TutorialInfoPos = new Vector2D
		{
			X=640.0f,
			Y=500.0f
		};
		bDisplayGameMessages = true;
		HUDContentClassName = "TdTuContent.TdHUDContentTutorial";
	}
}
}