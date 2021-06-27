namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdTransferMap : UIAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ bool bTransferToProfile;
	
	public UIAction_TdTransferMap()
	{
		// Object Offset:0x006D750B
		bAutoTargetOwner = true;
		ObjName = "TdTransfer map";
		ObjCategory = "Takedown";
	}
}
}