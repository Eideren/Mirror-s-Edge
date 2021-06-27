namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ChangeVisibility : UIAction/*
		hidecategories(Object)*/{
	public/*()*/ bool bVisible;
	
	public UIAction_ChangeVisibility()
	{
		// Object Offset:0x0040351D
		bVisible = true;
		ObjName = "Change Visibility";
	}
}
}