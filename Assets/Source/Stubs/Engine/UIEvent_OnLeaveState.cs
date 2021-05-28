namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEvent_OnLeaveState : UIEvent_State/*
		native
		hidecategories(Object)*/{
	public UIEvent_OnLeaveState()
	{
		// Object Offset:0x00432745
		Description = "Activated whenever a widget leaves a menu state, such as disabled or focused";
		ObjPosX = 424;
		ObjPosY = 384;
		ObjName = "Leave State";
	}
}
}