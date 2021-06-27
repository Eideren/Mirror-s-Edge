namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdOnlineFriendMessages : UIDataProvider_OnlineFriendMessages/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public UIDataProvider_TdOnlineFriendMessages()
	{
		// Object Offset:0x006D8E8D
		SendingPlayerNameCol = "FROM";
		bIsFriendInviteCol = " ";
	}
}
}