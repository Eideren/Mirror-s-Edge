namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdMoveMapCycleMap : UIAction/*
		native
		hidecategories(Object)*/{
	[Category] public int MoveAmount;
	
	public UIAction_TdMoveMapCycleMap()
	{
		// Object Offset:0x006D5DFF
		bAutoTargetOwner = true;
		ObjName = "TdMove Map in Map Cycle";
		ObjCategory = "Takedown";
	}
}
}