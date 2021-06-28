namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SPLevelRace : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList StretchList;
	public UIScene SPLeaderboardScene;
	public UIScene SPLeaderboardScenePC;
	public /*transient */UILabel WorldBestLabel;
	public /*transient */UILabel WorldBestTimeLabel;
	public /*transient */UILabel FriendsBestLabel;
	public /*transient */UILabel FriendsBestTimeLabel;
	public /*transient */int LevelEventDelay;
	public /*const */float RequestDelay;
	public /*transient */float TimeToRequest;
	public UIDataStore_TdTimeTrialData TimeTrialData;
	public /*private transient */int PlayerFilterIndex;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_RaceFriends(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_RaceWorlds(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnStretchList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnReadTimesCompleteDelegate(bool bSuccessful)
	{
		// stub
	}
	
	public virtual /*private final function */void OnReadTimesCompleteError_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void StartRace()
	{
		// stub
	}
	
	public virtual /*function */void OnLauncherFinished(int Result)
	{
		// stub
	}
	
	public virtual /*function */void DelayedRefreshStats()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenFriendsLeaderBoard()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenWorldsLeaderBoard()
	{
		// stub
	}
	
	public virtual /*function */void OpenLeaderboard(int InPlayerFilterIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnLBSceneActivated(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void SaveSceneState()
	{
		// stub
	}
	
	public override /*function */void SceneRestored()
	{
		// stub
	}
	
	public override /*function */void SceneSavedForRestore()
	{
		// stub
	}
	
	public override /*event */void OnPreTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void StretchList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_SPLevelRace()
	{
		var Default__TdUIScene_SPLevelRace_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SPLevelRace.SceneEventComponent' */;
		// Object Offset:0x006AB2FB
		RequestDelay = 0.30f;
		EventProvider = Default__TdUIScene_SPLevelRace_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SPLevelRace.SceneEventComponent'*/;
	}
}
}