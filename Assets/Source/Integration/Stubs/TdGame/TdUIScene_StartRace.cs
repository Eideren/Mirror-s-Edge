namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_StartRace : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel QualifyingTimeLabel1;
	public /*transient */UILabel QualifyingTimeLabel2;
	public /*transient */UILabel QualifyingTimeLabel3;
	public /*transient */UIImage MapStar1;
	public /*transient */UIImage MapStar2;
	public /*transient */UIImage MapStar3;
	public /*transient */UILabel TrackLegnth;
	public /*transient */UILabel TargetName;
	public /*transient */TdUIRaceProgressBar RaceProgressBar;
	public /*transient */bool bIsFaded;
	public /*transient */float FadeTimer;
	public /*transient */float TimeToFadeStart;
	public /*transient */float FadeTime;
	public /*transient */OnlineSubsystem.UniqueNetId GamerCardId;
	
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