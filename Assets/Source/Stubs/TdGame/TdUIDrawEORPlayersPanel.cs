namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIDrawEORPlayersPanel : TdUIDrawPlayersPanel/*
		hidecategories(Object,UIRoot,Object)*/{
	public override /*protected function */void DrawPlayerSlotBG(Canvas C, int TeamIndex, int PlayerSlotIndex, int X, int Y, int XL, int YL)
	{
	
	}
	
	public override /*protected function */void DrawPlayer(Canvas C, TdPlayerReplicationInfo TdPRI, int TeamIndex, bool bIsSelected, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public virtual /*protected function */void DrawPlayerName(Canvas C, String PlayerName, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public virtual /*protected function */void DrawPlayerKillsDeaths(Canvas C, int Kills, int Deaths, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public virtual /*protected function */void DrawPlayerScore(Canvas C, int Score, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public TdUIDrawEORPlayersPanel()
	{
		// Object Offset:0x00686162
		PlayerSlotBGColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=50
		};
		PlayerSlotSelectedBgColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		TeamSpacing = 10;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIDrawEORPlayersPanel.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIDrawEORPlayersPanel.WidgetEventComponent'*/;
	}
}
}