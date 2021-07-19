namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_NewRecord : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UILabel OldRecordName;
	[transient] public UILabel OldRecordTime;
	[transient] public UILabel NewRecordName;
	[transient] public UILabel NewRecordTime;
	[transient] public UILabel NewRecordDesc;
	[transient] public UIImage MapStar1;
	[transient] public UIImage MapStar2;
	[transient] public UIImage MapStar3;
	[transient] public OnlineSubsystem.UniqueNetId GamerCardId;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void SetMapStarRating(UIDataStore_TdTimeTrialData TimeTrialData)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
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
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*function */void InitializeScene(UIDataStore_TdTimeTrialData TimeTrialData, int CurrentStretchProviderIdx)
	{
		// stub
	}
	
	public virtual /*function */void SetRecordInfo(TdTTResult TTResult)
	{
		// stub
	}
	
	public virtual /*function */void SetUndefinedOldRecord()
	{
		// stub
	}
	
	public virtual /*function */void SetOldRecord(float Time, String PlayerName, int NumStars)
	{
		// stub
	}
	
	public virtual /*function */bool IsOldRecordUndefined(float Time)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String GetOldName(String OldName)
	{
		// stub
		return default;
	}
	
	public virtual /*function */String GetOldTime(float Time)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool GetRecordDescription(TdTTResult TTResult, ref String winStr)
	{
		// stub
		return default;
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
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