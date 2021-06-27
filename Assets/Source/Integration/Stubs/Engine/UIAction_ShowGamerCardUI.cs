namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowGamerCardUI : UIAction/*
		hidecategories(Object)*/{
	public UIAction_ShowGamerCardUI()
	{
		// Object Offset:0x004176EF
		bAutoTargetOwner = true;
		ObjName = "Show Gamercard UI";
		ObjCategory = "Online";
	}
}
}