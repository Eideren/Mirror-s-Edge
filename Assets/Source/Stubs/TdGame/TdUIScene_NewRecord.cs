namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_NewRecord : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel OldRecordName;
	public /*transient */UILabel OldRecordTime;
	public /*transient */UILabel NewRecordName;
	public /*transient */UILabel NewRecordTime;
	public /*transient */UILabel NewRecordDesc;
	public /*transient */UIImage MapStar1;
	public /*transient */UIImage MapStar2;
	public /*transient */UIImage MapStar3;
	public /*transient */OnlineSubsystem.UniqueNetId GamerCardId;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void SetMapStarRating(UIDataStore_TdTimeTrialData TimeTrialData)
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_ShowGamerCard(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnShowGamerCard()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx)
	{
	
	}
	
	public virtual /*function */void SetRecordInfo(TdTTResult TTResult)
	{
	
	}
	
	public virtual /*function */void SetUndefinedOldRecord()
	{
	
	}
	
	public virtual /*function */void SetOldRecord(float Time, String PlayerName, int NumStars)
	{
	
	}
	
	public virtual /*function */bool IsOldRecordUndefined(float Time)
	{
	
		return default;
	}
	
	public virtual /*function */String GetOldName(String OldName)
	{
	
		return default;
	}
	
	public virtual /*function */String GetOldTime(float Time)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetRecordDescription(TdTTResult TTResult, ref String winStr)
	{
	
		return default;
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_NewRecord()
	{
		var Default__TdUIScene_NewRecord_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_NewRecord.SceneEventComponent' */;
		// Object Offset:0x006A3ECF
		EventProvider = Default__TdUIScene_NewRecord_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_NewRecord.SceneEventComponent'*/;
	}
}
}