namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIState_TargetedTab : UIState/*
		native
		editinlinenew
		hidecategories(Object,UIRoot)*/{
	public override /*event */bool IsWidgetClassSupported(Core.ClassT<UIScreenObject> WidgetClass)
	{
		// stub
		return default;
	}
	
	public UIState_TargetedTab()
	{
		// Object Offset:0x00452266
		StackPriority = 11;
	}
}
}