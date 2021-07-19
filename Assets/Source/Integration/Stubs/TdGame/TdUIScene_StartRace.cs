namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_StartRace : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UILabel QualifyingTimeLabel1;
	[transient] public UILabel QualifyingTimeLabel2;
	[transient] public UILabel QualifyingTimeLabel3;
	[transient] public UIImage MapStar1;
	[transient] public UIImage MapStar2;
	[transient] public UIImage MapStar3;
	[transient] public UILabel TrackLegnth;
	[transient] public UILabel TargetName;
	[transient] public TdUIRaceProgressBar RaceProgressBar;
	[transient] public bool bIsFaded;
	[transient] public float FadeTimer;
	[transient] public float TimeToFadeStart;
	[transient] public float FadeTime;
	[transient] public OnlineSubsystem.UniqueNetId GamerCardId;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Quit(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnQuit()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_ShowGamerCard(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnShowGamerCard()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Race(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetMapStarRating(UIDataStore_TdTimeTrialData TimeTrialData)
	{
		// stub
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TTData)
	{
		// stub
	}
	
	public virtual /*function */void OnStartRace()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void TurnOffFade()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*event */void OnPreTick(float DeltaTime, bool bTopmostScene)
	{
		// stub
	}
	
	public TdUIScene_StartRace()
	{
		var Default__TdUIScene_StartRace_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_StartRace.SceneEventComponent' */;
		// Object Offset:0x006B05F9
		TimeToFadeStart = 17.0f;
		FadeTime = 2.0f;
		EventProvider = Default__TdUIScene_StartRace_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_StartRace.SceneEventComponent'*/;
	}
}
}