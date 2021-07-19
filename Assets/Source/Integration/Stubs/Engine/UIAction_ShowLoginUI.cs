namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowLoginUI : UIAction/*
		native
		hidecategories(Object)*/{
	public bool bIsDone;
	[Category] public bool bShowOnlineOnly;
	
	public virtual /*event */void ShowUI()
	{
		// stub
	}
	
	public virtual /*function */void OnLoginChanged()
	{
		// stub
	}
	
	public virtual /*function */void OnLoginCancelled()
	{
		// stub
	}
	
	public UIAction_ShowLoginUI()
	{
		// Object Offset:0x00418A81
		bAutoTargetOwner = true;
		bLatentExecution = true;
		ObjName = "Show Login UI";
		ObjCategory = "Online";
	}
}
}