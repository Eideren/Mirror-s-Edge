namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_EndOfRace : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel YouName;
	public /*transient */UILabel TargetName;
	public /*transient */UILabel TimeYou;
	public /*transient */UILabel TimeTarget;
	public /*transient */UILabel DistanceYou;
	public /*transient */UILabel DistanceTarget;
	public /*transient */UILabel AverageSpeedYou;
	public /*transient */UILabel AverageSpeedTarget;
	public /*transient */UILabel StarRatingYou;
	public /*transient */UILabel StarRatingTarget;
	public /*transient */UIImage MapStar1;
	public /*transient */UIImage MapStar2;
	public /*transient */UIImage MapStar3;
	public /*transient */UITdOptionButton CompareTarget;
	public /*transient */TdUIRaceProgressBar RaceProgressBar;
	public /*transient */OnlineSubsystem.UniqueNetId GamerCardId;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void SetMapStarRating(UIDataStore_TdTimeTrialData TimeTrialData)
	{
		// stub
	}
	
	public virtual /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void SetUpRaceProgressBar(UIDataStore_TdTimeTrialData TimeTrialData, TdTTResult TTResult, TdTTInput.TTData CompareData)
	{
		// stub
	}
	
	public virtual /*function */void SetUndefinedTargetTime()
	{
		// stub
	}
	
	public virtual /*function */String FormatDistance(float Distance)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String FormatAverageSpeed(float AverageSpeed)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx, TdTTResult TTResult, TdTTInput.TTData CompareData)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Restart(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_Continue(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void OnRestart()
	{
		// stub
	}
	
	public virtual /*function */void HUDFadeScreenCallback()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed_Restart(UIScene ClosedScene)
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
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_EndOfRace()
	{
		var Default__TdUIScene_EndOfRace_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_EndOfRace.SceneEventComponent' */;
		// Object Offset:0x00698051
		EventProvider = Default__TdUIScene_EndOfRace_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_EndOfRace.SceneEventComponent'*/;
	}
}
}