namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdRemoveMapFromCycle : UIAction/*
		native
		hidecategories(Object)*/{
	[Category] public bool bRemoveAll;
	
	public UIAction_TdRemoveMapFromCycle()
	{
		// Object Offset:0x006D6027
		bAutoTargetOwner = true;
		ObjName = "TdRemove map from cycle";
		ObjCategory = "Takedown";
	}
}
}