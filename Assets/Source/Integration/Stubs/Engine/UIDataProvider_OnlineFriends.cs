namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineFriends : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlineFriend> FriendsList;
	public /*const localized */String NickNameCol;
	public /*const localized */String PresenceInfoCol;
	public /*const localized */String bIsOnlineCol;
	public /*const localized */String bIsPlayingCol;
	public /*const localized */String bIsPlayingThisGameCol;
	public /*const localized */String bIsJoinableCol;
	public /*const localized */String bHasVoiceSupportCol;
	
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