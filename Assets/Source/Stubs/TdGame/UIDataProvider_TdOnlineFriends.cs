namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdOnlineFriends : UIDataProvider_OnlineFriends/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public override /*event */void OnRegister(LocalPlayer InPlayer)
	{
	
	}
	
	public override /*event */void OnUnregister()
	{
	
	}
	
	public virtual /*function */void OnFriendsChange()
	{
	
	}
	
	public UIDataProvider_TdOnlineFriends()
	{
		// Object Offset:0x006D920E
		NickNameCol = "ONLINE ID";
	}
}
}