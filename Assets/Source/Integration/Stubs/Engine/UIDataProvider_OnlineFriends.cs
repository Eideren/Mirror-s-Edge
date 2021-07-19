namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineFriends : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlineFriend> FriendsList;
	[Const, localized] public String NickNameCol;
	[Const, localized] public String PresenceInfoCol;
	[Const, localized] public String bIsOnlineCol;
	[Const, localized] public String bIsPlayingCol;
	[Const, localized] public String bIsPlayingThisGameCol;
	[Const, localized] public String bIsJoinableCol;
	[Const, localized] public String bHasVoiceSupportCol;
	
	public override /*event */void OnRegister(LocalPlayer InPlayer)
	{
		// stub
	}
	
	public override /*event */void OnUnregister()
	{
		// stub
	}
	
	public virtual /*function */void OnFriendsReadComplete(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void OnLoginChange()
	{
		// stub
	}
	
	public virtual /*event */void RefreshFriendsList()
	{
		// stub
	}
	
	public UIDataProvider_OnlineFriends()
	{
		// Object Offset:0x00426988
		NickNameCol = "Name";
		PresenceInfoCol = "Online Status";
		bIsOnlineCol = "Is Online";
		bIsPlayingCol = "Is Playing";
		bIsPlayingThisGameCol = "Is Playing This Game";
		bIsJoinableCol = "Is Joinable";
		bHasVoiceSupportCol = "Has Voice Support";
	}
}
}