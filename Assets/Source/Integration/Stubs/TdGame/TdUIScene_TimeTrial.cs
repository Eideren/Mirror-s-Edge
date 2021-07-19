namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TimeTrial : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public UIDataStore_TdTimeTrialData TimeTrialData;
	[transient] public UIList StretchList;
	[transient] public UILabel UnlockDesc;
	[transient] public UILabel QualifyingTimeLabel1;
	[transient] public UILabel QualifyingTimeLabel2;
	[transient] public UILabel QualifyingTimeLabel3;
	[transient] public UILabel WorldBestLabel;
	[transient] public UILabel WorldBestTimeLabel;
	[transient] public UILabel FriendsBestLabel;
	[transient] public UILabel FriendsBestTimeLabel;
	public UIScene StartStretchScene;
	public UIScene SPLeaderboardScene;
	public UIScene SPLeaderboardScenePC;
	[transient] public int LevelEventDelay;
	[Const] public float RequestDelay;
	[transient] public float TimeToRequest;
	[transient] public int PlayerFilterIndex;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void DelayedRefreshStats()
	{
		// stub
	}
	
	public virtual /*function */void RefreshStats()
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
	
	public virtual /*private final function */void OnReadTimesError_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
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
	
	public virtual /*function */void OnOpenLeaderboard(UIScene ActivatedScene, bool bInitialActivation)
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
	
	public TdUIScene_TimeTrial()
	{
		var Default__TdUIScene_TimeTrial_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_TimeTrial.SceneEventComponent' */;
		// Object Offset:0x006B2CB2
		RequestDelay = 0.30f;
		EventProvider = Default__TdUIScene_TimeTrial_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_TimeTrial.SceneEventComponent'*/;
	}
}
}