namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIDrawLobbyPlayersPanel : TdUIDrawPlayersPanel/*
		hidecategories(Object,UIRoot,Object)*/{
	public/*()*/ Texture2D IsReadyImage;
	public array<int> Roles;
	
	public override /*protected function */void DrawPlayerSlotBG(Canvas C, int TeamIndex, int PlayerSlotIndex, int X, int Y, int XL, int YL)
	{
	
	}
	
	public override /*protected function */void DrawPlayer(Canvas C, TdPlayerReplicationInfo TdPRI, int TeamIndex, bool bIsSelected, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public virtual /*protected function */void DrawPlayerName(Canvas C, String PlayerName, bool bIsSelected, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public virtual /*protected function */void DrawPlayerRole(Canvas C, int RoleId, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public virtual /*protected function */void DrawPlayerIsReady(Canvas C, int Left, int Top, int Width, int Height)
	{
	
	}
	
	public TdUIDrawLobbyPlayersPanel()
	{
		var Default__TdUIDrawLobbyPlayersPanel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIDrawLobbyPlayersPanel.WidgetEventComponent' */;
		// Object Offset:0x006870ED
		PlayerSlotBGColor = new Color
		{
			R=200,
			G=200,
			B=200,
			A=255
		};
		PlayerSlotSelectedBgColor = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		EventProvider = Default__TdUIDrawLobbyPlayersPanel_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIDrawLobbyPlayersPanel.WidgetEventComponent'*/;
	}
}
}