namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SPLeaderboard : TdUIScene_Leaderboard/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIDataStore_TdTimeTrialData TimeTrialData;
	[transient] public UIDataStore_TdOnlineStats TdLeaderboardData;
	[transient] public UIDataStore_TdOnlineStats StatsDataStore;
	[transient] public TdLeaderboardSettings StatsSettings;
	[transient] public UIList PlayerRankList;
	[transient] public UIList LeaderBoardList;
	[transient] public UILabel TitleLabel;
	[transient] public UILabel StretchFilterLabel;
	[transient] public UILabel StretchLabel;
	[transient] public UILabel PlayersFilterLabel;
	[transient] public UILabel TimeFrameFilterLabel;
	[transient] public UITdOptionButton GameModeOptionButton;
	[transient] public UITdOptionButton StretchFilterOptionButton;
	[transient] public UITdOptionButton PlayersFilterOptionButton;
	[transient] public UITdOptionButton TimeFrameFilterOptionButton;
	public UIScene StartStretchScene;
	public/*private*/ int CurrentStretchProviderIndex;
	public/*private*/ name CurrentStretchProviderName;
	public/*private*/ int CurrentPlayerIndex;
	public/*private*/ OnlineSubsystem.UniqueNetId CurrentPlayerNetId;
	public/*private*/ String CurrentPlayerNickname;
	[transient] public int LevelEventDelay;
	[Const] public float RequestDelay;
	[transient] public float TimeToRequest;
	[transient] public/*private*/ bool bIsFriendRequestParam;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*private final function */void SetStretchFilterLabel(int ProviderIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnLeaderBoardList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void ValueUpdated()
	{
		// stub
	}
	
	public virtual /*function */void OnFilterOptionButton_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void DelayedRefreshStats()
	{
		// stub
	}
	
	public virtual /*function */void RefreshStats()
	{
		// stub
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void InitSceneData()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */void UpdateButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_AddFriend(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_StartRace(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_ShowFriends(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_GamerCard(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ShowAddFriend()
	{
		// stub
	}
	
	public virtual /*private final function */void ShowAddFriend_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void ToggleLB(int GameMode)
	{
		// stub
	}
	
	public virtual /*function */void SetUpLB(name NewStretchProviderName, int NewStretchProviderIndex, int PlayerFilter)
	{
		// stub
	}
	
	public virtual /*function */void GamerCard()
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
	
	public virtual /*private final function */void OnLevelLocked_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void SaveSceneState()
	{
		// stub
	}
	
	public override /*function */void SceneSavedForRestore()
	{
		// stub
	}
	
	public override /*function */void SceneRestored()
	{
		// stub
	}
	
	public override /*event */void OnPreTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public virtual /*function */void RaceReadCompleted(bool Success)
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public virtual /*function */void StepStretch(bool bIncrease)
	{
		// stub
	}
	
	public virtual /*function */void StepPlayerFilter()
	{
		// stub
	}
	
	public virtual /*function */void StepTimeFrame()
	{
		// stub
	}
	
	public virtual /*function */void OnStatsReadComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*private final function */void OnStatsReadError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void LeaderboardList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
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