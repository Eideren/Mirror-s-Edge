namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_ShowFriendInviteUI : UIAction/*
		hidecategories(Object)*/{
	public UIAction_ShowFriendInviteUI()
	{
		// Object Offset:0x004171ED
		bAutoTargetOwner = true;
		ObjName = "Show Friend Invite UI";
		ObjCategory = "Online";
	}
}
}