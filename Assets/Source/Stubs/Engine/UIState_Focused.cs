namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIState_Focused : UIState/*
		native
		editinlinenew
		hidecategories(Object,UIRoot)*/{
	public override /*event */bool ActivateState(UIScreenObject Target, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public UIState_Focused()
	{
		// Object Offset:0x00452070
		StackPriority = 10;
	}
}
}