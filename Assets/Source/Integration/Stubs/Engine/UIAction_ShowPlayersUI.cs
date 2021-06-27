namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowPlayersUI : UIAction/*
		hidecategories(Object)*/{
	public UIAction_ShowPlayersUI()
	{
		// Object Offset:0x00418D75
		bAutoTargetOwner = true;
		ObjName = "Show Recent Players UI";
		ObjCategory = "Online";
	}
}
}