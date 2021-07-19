namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Lobby : TdUIScene, 
		TdLobbyEventListener/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct LobbyTeamWidgets
	{
		public StaticArray<TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget>/*[8]*/ PlayerWidgets;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0069C454
	//		PlayerWidgets = new StaticArray<TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget, TdUILobbyPlayerWidget>/*[8]*/()
	//		{ 
	//			[0] = default,
	//			[1] = default,
	//			[2] = default,
	//			[3] = default,
	//			[4] = default,
	//			[5] = default,
	//			[6] = default,
	//			[7] = default,
	// 		};
	//	}
	};
	
	public UIDataStore_TdGameData TdGameData;
	public UIDataStore_TdMPData TdMPData;
	[Category] public name SettingsDataStoreName;
	[transient] public/*private*/ TdLobbyBackend Backend;
	[transient] public StaticArray<TdUIScene_Lobby.LobbyTeamWidgets, TdUIScene_Lobby.LobbyTeamWidgets>/*[2]*/ TeamWidgets;
	[transient] public UILabelButton StartGameButton;
	[transient] public UIPanel SettingsPanel;
	[transient] public UILabel NumPlayersInLobbyLabel;
	[transient] public TdUIDrawLobbyPlayersPanel PlayersPanel;
	[transient] public UITdOptionButton MapOptionList;
	[transient] public UIPanel ButtonsPanel;
	public bool bIsControllingClient;
	public /*delegate*/TdUIScene_Lobby.OnSceneClosed __OnSceneClosed__Delegate;
	
	public delegate void OnSceneClosed();
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*event */void SceneDeactivated()
	{
		// stub
	}
	
	public virtual /*simulated function */void SetPlayerDataWidgetBindings()
	{
		// stub
	}
	
	public virtual /*function */void OnMapOptionList_ActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public virtual /*function */void OnButtonsPanel_ActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public virtual /*function */void OnPrepareEnterPlayerPanel(UIRoot.EUIWidgetFace EnterFromFace)
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerJoin(Controller Player)
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerLeave(Controller Player)
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerSwitchTeam(Controller Player)
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerSwitchRole(Controller Player)
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerSetReady(Controller Player)
	{
		// stub
	}
	
	public virtual /*function */void OnGameStarted()
	{
		// stub
	}
	
	public virtual /*simulated function */void UpdatePlayers(array<PlayerReplicationInfo> pris)
	{
		// stub
	}
	
	public virtual /*function */bool OnStartGamePrepare(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnStartGame()
	{
		// stub
	}
	
	public virtual /*function */void OnQuitToMainMenu()
	{
		// stub
	}
	
	public virtual /*function */void PlayersPanel_OnPlayerSlotClicked(TdPlayerReplicationInfo TdPRI)
	{
		// stub
	}
	
	public virtual /*function */void OnKick()
	{
		// stub
	}
	
	public virtual /*function */void OnCompare()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_Lobby()
	{
		var Default__TdUIScene_Lobby_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Lobby.SceneEventComponent' */;
		// Object Offset:0x0069D34C
		SettingsDataStoreName = (name)"TdMPGameSettings";
		EventProvider = Default__TdUIScene_Lobby_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Lobby.SceneEventComponent'*/;
	}
}
}