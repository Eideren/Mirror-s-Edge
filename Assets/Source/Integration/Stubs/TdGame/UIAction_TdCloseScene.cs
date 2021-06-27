namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdCloseScene : UIAction_Scene/*
		native
		hidecategories(Object)*/{
	public TdUIScene ClosedScene;
	
	public UIAction_TdCloseScene()
	{
		// Object Offset:0x006D0FFA
		bAutoTargetOwner = true;
		bLatentExecution = true;
		ObjName = "TdCloseScene";
		ObjCategory = "Takedown";
	}
}
}