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
	public/*()*/ name SettingsDataStoreName;
	public /*private transient */TdLobbyBackend Backend;
	public /*transient */StaticArray<TdUIScene_Lobby.LobbyTeamWidgets, TdUIScene_Lobby.LobbyTeamWidgets>/*[2]*/ TeamWidgets;
	public /*transient */UILabelButton StartGameButton;
	public /*transient */UIPanel SettingsPanel;
	public /*transient */UILabel NumPlayersInLobbyLabel;
	public /*transient */TdUIDrawLobbyPlayersPanel PlayersPanel;
	public /*transient */UITdOptionButton MapOptionList;
	public /*transient */UIPanel ButtonsPanel;
	public bool bIsControllingClient;
	public /*delegate*/TdUIScene_Lobby.OnSceneClosed __OnSceneClosed__Delegate;
	
	public delegate void OnSceneClosed();
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*event */void SceneDeactivated()
	{
	
	}
	
	public virtual /*simulated function */void SetPlayerDataWidgetBindings()
	{
	
	}
	
	public virtual /*function */void OnMapOptionList_ActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public virtual /*function */void OnButtonsPanel_ActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public virtual /*function */void OnPrepareEnterPlayerPanel(UIRoot.EUIWidgetFace EnterFromFace)
	{
	
	}
	
	public virtual /*function */void OnPlayerJoin(Controller Player)
	{
	
	}
	
	public virtual /*function */void OnPlayerLeave(Controller Player)
	{
	
	}
	
	public virtual /*function */void OnPlayerSwitchTeam(Controller Player)
	{
	
	}
	
	public virtual /*function */void OnPlayerSwitchRole(Controller Player)
	{
	
	}
	
	public virtual /*function */void OnPlayerSetReady(Controller Player)
	{
	
	}
	
	public virtual /*function */void OnGameStarted()
	{
	
	}
	
	public virtual /*simulated function */void UpdatePlayers(array<PlayerReplicationInfo> pris)
	{
	
	}
	
	public virtual /*function */bool OnStartGamePrepare(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnStartGame()
	{
	
	}
	
	public virtual /*function */void OnQuitToMainMenu()
	{
	
	}
	
	public virtual /*function */void PlayersPanel_OnPlayerSlotClicked(TdPlayerReplicationInfo TdPRI)
	{
	
	}
	
	public virtual /*function */void OnKick()
	{
	
	}
	
	public virtual /*function */void OnCompare()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
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