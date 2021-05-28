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
	
	}
	
	public virtual /*function */void SetMapStarRating(UIDataStore_TdTimeTrialData TimeTrialData)
	{
	
	}
	
	public virtual /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void SetUpRaceProgressBar(UIDataStore_TdTimeTrialData TimeTrialData, TdTTResult TTResult, TdTTInput.TTData CompareData)
	{
	
	}
	
	public virtual /*function */void SetUndefinedTargetTime()
	{
	
	}
	
	public virtual /*function */string FormatDistance(float Distance)
	{
	
		return default;
	}
	
	public virtual /*function */string FormatAverageSpeed(float AverageSpeed)
	{
	
		return default;
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx, TdTTResult TTResult, TdTTInput.TTData CompareData)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Restart(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_Continue(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void OnRestart()
	{
	
	}
	
	public virtual /*function */void HUDFadeScreenCallback()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_Restart(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_ShowGamerCard(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnShowGamerCard()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_EndOfRace()
	{
		// Object Offset:0x00698051
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_EndOfRace.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_EndOfRace.SceneEventComponent'*/;
	}
}
}