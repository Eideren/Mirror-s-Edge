namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdTransferMapCycle : UIAction/*
		native
		hidecategories(Object)*/{
	[Category] public bool bTransferToProfile;
	
	public UIAction_TdTransferMapCycle()
	{
		// Object Offset:0x006D761A
		bAutoTargetOwner = true;
		ObjName = "Transfer Map Cycle";
		ObjCategory = "Takedown";
	}
}
}