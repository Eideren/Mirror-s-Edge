namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdOpenScene : UIAction_Scene/*
		native
		hidecategories(Object)*/{
	public TdUIScene OpenedScene;
	
	public UIAction_TdOpenScene()
	{
		// Object Offset:0x006D5F1B
		bAutoTargetOwner = true;
		ObjName = "TdOpenScene";
		ObjCategory = "Takedown";
	}
}
}