namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpAssociationManager : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*delegate*/TpAssociationManager.OnRemoveMember __OnRemoveMember__Delegate;
	public /*delegate*/TpAssociationManager.OnAddMember __OnAddMember__Delegate;
	public /*delegate*/TpAssociationManager.OnFriendsListLoaded __OnFriendsListLoaded__Delegate;
	public /*delegate*/TpAssociationManager.OnFriendsListChange __OnFriendsListChange__Delegate;
	
	// Export UTpAssociationManager::execAddFriendAsync(FFrame&, void* const)
	public virtual /*native simulated function */void AddFriendAsync(OnlineSubsystem.UniqueNetId NewFriend)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpAssociationManager::execRemoveFriendAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool RemoveFriendAsync(OnlineSubsystem.UniqueNetId FormerFriend)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execGetMyFriendsList(FFrame&, void* const)
	public virtual /*native simulated function */array<String> GetMyFriendsList()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execGetMyFriendsListEx(FFrame&, void* const)
	public virtual /*native simulated function */bool GetMyFriendsListEx(byte LocalUserNum, ref array<OnlineSubsystem.OnlineFriend> Friends, /*optional */int? _Count = default, /*optional */int? _StartingAt = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execGetPlayersList(FFrame&, void* const)
	public virtual /*native simulated function */bool GetPlayersList(ref array<OnlineSubsystem.OnlinePlayer> Players, /*optional */int? _Count = default, /*optional */int? _StartingAt = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execIsFriend(FFrame&, void* const)
	public virtual /*native simulated function */bool IsFriend(OnlineSubsystem.UniqueNetId PlayerId)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execBlockUserAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool BlockUserAsync(OnlineSubsystem.UniqueNetId UserRef)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execUnBlockUserAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool UnBlockUserAsync(OnlineSubsystem.UniqueNetId UserRef)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpAssociationManager::execListBlockedUsers(FFrame&, void* const)
	public virtual /*native simulated function */array<String> ListBlockedUsers()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnRemoveMember(bool bInOk);
	
	public delegate void OnAddMember(bool bInOk);
	
	public delegate void OnFriendsListLoaded(bool bInOk);
	
	public delegate void OnFriendsListChange();
	
	// Export UTpAssociationManager::execIsFriendsListLoaded(FFrame&, void* const)
	public virtual /*native simulated function */bool IsFriendsListLoaded()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}