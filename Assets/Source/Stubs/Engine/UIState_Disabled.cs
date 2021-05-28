namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIState_Disabled : UIState/*
		native
		editinlinenew
		hidecategories(Object,UIRoot)*/{
	public override /*event */bool ActivateState(UIScreenObject Target, int PlayerIndex)
	{
	
		return default;
	}
	
	public override /*event */bool IsStateAllowed(UIScreenObject Target, UIState NewState, int PlayerIndex)
	{
	
		return default;
	}
	
	public UIState_Disabled()
	{
		// Object Offset:0x00451DE7
		StackPriority = 5;
	}
}
}