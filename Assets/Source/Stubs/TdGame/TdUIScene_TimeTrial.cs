namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TimeTrial : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public UIDataStore_TdTimeTrialData TimeTrialData;
	public /*transient */UIList StretchList;
	public /*transient */UILabel UnlockDesc;
	public /*transient */UILabel QualifyingTimeLabel1;
	public /*transient */UILabel QualifyingTimeLabel2;
	public /*transient */UILabel QualifyingTimeLabel3;
	public /*transient */UILabel WorldBestLabel;
	public /*transient */UILabel WorldBestTimeLabel;
	public /*transient */UILabel FriendsBestLabel;
	public /*transient */UILabel FriendsBestTimeLabel;
	public UIScene StartStretchScene;
	public UIScene SPLeaderboardScene;
	public UIScene SPLeaderboardScenePC;
	public /*transient */int LevelEventDelay;
	public /*const */float RequestDelay;
	public /*transient */float TimeToRequest;
	public /*transient */int PlayerFilterIndex;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void DelayedRefreshStats()
	{
	
	}
	
	public virtual /*function */void RefreshStats()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_RaceFriends(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_RaceWorlds(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnStretchList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnReadTimesCompleteDelegate(bool bSuccessful)
	{
	
	}
	
	public virtual /*private final function */void OnReadTimesError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void StartRace()
	{
	
	}
	
	public virtual /*function */void OnLauncherFinished(int Result)
	{
	
	}
	
	public virtual /*function */void OnOpenFriendsLeaderBoard()
	{
	
	}
	
	public virtual /*function */void OnOpenWorldsLeaderBoard()
	{
	
	}
	
	public virtual /*function */void OpenLeaderboard(int InPlayerFilterIndex)
	{
	
	}
	
	public virtual /*function */void OnOpenLeaderboard(UIScene ActivatedScene, bool bInitialActivation)
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
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void StretchList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
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
	
	public TdUIScene_TimeTrial()
	{
		// Object Offset:0x006B2CB2
		RequestDelay = 0.30f;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_TimeTrial.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_TimeTrial.SceneEventComponent'*/;
	}
}
}