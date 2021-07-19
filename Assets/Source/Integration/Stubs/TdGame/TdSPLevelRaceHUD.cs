namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPLevelRaceHUD : TdSPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public UIDataStore_TdGameData GameData;
	[Category("HUDIcons")] public Object.Vector2D RaceTimerPos;
	[Category("HUDIcons")] public Object.Vector2D TargetTimePos;
	
	public override /*function */void LoadHUDContent(Core.ClassT<TdHUDContent> ContentClass)
	{
		// stub
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*function */void DrawLivingHUD()
	{
		// stub
	}
	
	public virtual /*function */void DrawRaceTimer(TdSPLevelRace Game, bool bBothTimes)
	{
		// stub
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