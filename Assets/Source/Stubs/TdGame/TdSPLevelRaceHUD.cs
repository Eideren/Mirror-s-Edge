namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPLevelRaceHUD : TdSPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public UIDataStore_TdGameData GameData;
	public/*(HUDIcons)*/ Object.Vector2D RaceTimerPos;
	public/*(HUDIcons)*/ Object.Vector2D TargetTimePos;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
	
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override /*function */void DrawLivingHUD()
	{
	
	}
	
	public virtual /*function */void DrawRaceTimer(TdSPLevelRace Game, bool bBothTimes)
	{
	
	}
	
	public TdSPLevelRaceHUD()
	{
		// Object Offset:0x0065FDD2
		RaceTimerPos = new Vector2D
		{
			X=1056.0f,
			Y=55.0f
		};
		TargetTimePos = new Vector2D
		{
			X=1056.0f,
			Y=88.0f
		};
	}
}
}