namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineFriends : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlineFriend> FriendsList;
	public /*const localized */string NickNameCol;
	public /*const localized */string PresenceInfoCol;
	public /*const localized */string bIsOnlineCol;
	public /*const localized */string bIsPlayingCol;
	public /*const localized */string bIsPlayingThisGameCol;
	public /*const localized */string bIsJoinableCol;
	public /*const localized */string bHasVoiceSupportCol;
	
	public override /*event */void OnRegister(LocalPlayer InPlayer)
	{
	
	}
	
	public override /*event */void OnUnregister()
	{
	
	}
	
	public virtual /*function */void OnFriendsReadComplete(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */void OnLoginChange()
	{
	
	}
	
	public virtual /*event */void RefreshFriendsList()
	{
	
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