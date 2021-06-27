namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowFriendsUI : UIAction/*
		hidecategories(Object)*/{
	public UIAction_ShowFriendsUI()
	{
		// Object Offset:0x004172D5
		bAutoTargetOwner = true;
		ObjName = "Show Friends UI";
		ObjCategory = "Online";
	}
}
}