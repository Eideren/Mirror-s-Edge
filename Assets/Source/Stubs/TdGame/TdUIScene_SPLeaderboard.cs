namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SPLeaderboard : TdUIScene_Leaderboard/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIDataStore_TdTimeTrialData TimeTrialData;
	public /*transient */UIDataStore_TdOnlineStats TdLeaderboardData;
	public /*transient */UIDataStore_TdOnlineStats StatsDataStore;
	public /*transient */TdLeaderboardSettings StatsSettings;
	public /*transient */UIList PlayerRankList;
	public /*transient */UIList LeaderBoardList;
	public /*transient */UILabel TitleLabel;
	public /*transient */UILabel StretchFilterLabel;
	public /*transient */UILabel StretchLabel;
	public /*transient */UILabel PlayersFilterLabel;
	public /*transient */UILabel TimeFrameFilterLabel;
	public /*transient */UITdOptionButton GameModeOptionButton;
	public /*transient */UITdOptionButton StretchFilterOptionButton;
	public /*transient */UITdOptionButton PlayersFilterOptionButton;
	public /*transient */UITdOptionButton TimeFrameFilterOptionButton;
	public UIScene StartStretchScene;
	public /*private */int CurrentStretchProviderIndex;
	public /*private */name CurrentStretchProviderName;
	public /*private */int CurrentPlayerIndex;
	public /*private */OnlineSubsystem.UniqueNetId CurrentPlayerNetId;
	public /*private */String CurrentPlayerNickname;
	public /*transient */int LevelEventDelay;
	public /*const */float RequestDelay;
	public /*transient */float TimeToRequest;
	public /*private transient */bool bIsFriendRequestParam;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*private final function */void SetStretchFilterLabel(int ProviderIndex)
	{
	
	}
	
	public virtual /*function */void OnLeaderBoardList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void ValueUpdated()
	{
	
	}
	
	public virtual /*function */void OnFilterOptionButton_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void DelayedRefreshStats()
	{
	
	}
	
	public virtual /*function */void RefreshStats()
	{
	
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void InitSceneData()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */void UpdateButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_AddFriend(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_StartRace(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_ShowFriends(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_GamerCard(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void ShowAddFriend()
	{
	
	}
	
	public virtual /*private final function */void ShowAddFriend_Init(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void ToggleLB(int GameMode)
	{
	
	}
	
	public virtual /*function */void SetUpLB(name NewStretchProviderName, int NewStretchProviderIndex, int PlayerFilter)
	{
	
	}
	
	public virtual /*function */void GamerCard()
	{
	
	}
	
	public virtual /*function */void StartRace()
	{
	
	}
	
	public virtual /*function */void OnLauncherFinished(int Result)
	{
	
	}
	
	public virtual /*private final function */void OnLevelLocked_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void SaveSceneState()
	{
	
	}
	
	public override /*function */void SceneSavedForRestore()
	{
	
	}
	
	public override /*function */void SceneRestored()
	{
	
	}
	
	public override /*event */void OnPreTick(float DeltaTime, bool bTopmostScene)
	{
	
	}
	
	public virtual /*function */void RaceReadCompleted(bool Success)
	{
	
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void StepStretch(bool bIncrease)
	{
	
	}
	
	public virtual /*function */void StepPlayerFilter()
	{
	
	}
	
	public virtual /*function */void StepTimeFrame()
	{
	
	}
	
	public virtual /*function */void OnStatsReadComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*private final function */void OnStatsReadError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void LeaderboardList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_SPLeaderboard()
	{
		var Default__TdUIScene_SPLeaderboard_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SPLeaderboard.SceneEventComponent' */;
		// Object Offset:0x006A9723
		CurrentStretchProviderName = (name)"TdTimeTrialStretches";
		RequestDelay = 0.30f;
		EventProvider = Default__TdUIScene_SPLeaderboard_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SPLeaderboard.SceneEventComponent'*/;
	}
}
}