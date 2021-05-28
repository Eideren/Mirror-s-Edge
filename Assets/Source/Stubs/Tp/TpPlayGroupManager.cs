namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpPlayGroupManager : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*delegate*/TpPlayGroupManager.OnPlayGroupCreated __OnPlayGroupCreated__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupJoined __OnPlayGroupJoined__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupMemberJoin __OnPlayGroupMemberJoin__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupChatMessageReceived __OnPlayGroupChatMessageReceived__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupDestroyed __OnPlayGroupDestroyed__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupKicked __OnPlayGroupKicked__Delegate;
	public /*delegate*/TpPlayGroupManager.OnLeavePlayGroupComplete __OnLeavePlayGroupComplete__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupMemberLeave __OnPlayGroupMemberLeave__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupOwnerTransitionStart __OnPlayGroupOwnerTransitionStart__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupOwnerTransitionFinish __OnPlayGroupOwnerTransitionFinish__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupGameJoined __OnPlayGroupGameJoined__Delegate;
	public /*delegate*/TpPlayGroupManager.OnPlayGroupGameLeave __OnPlayGroupGameLeave__Delegate;
	
	// Export UTpPlayGroupManager::execIsInPlayGroup(FFrame&, void* const)
	public virtual /*native simulated function */bool IsInPlayGroup()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpPlayGroupManager::execIsPlayGroupOwner(FFrame&, void* const)
	public virtual /*native simulated function */bool IsPlayGroupOwner()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpPlayGroupManager::execGetMyPlayGroupList(FFrame&, void* const)
	public virtual /*native simulated function */array<OnlineSubsystem.PlayGroupListEntry> GetMyPlayGroupList()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpPlayGroupManager::execCreatePlayGroupAsync(FFrame&, void* const)
	public virtual /*native simulated function */void CreatePlayGroupAsync(OnlineSubsystem.PlayGroupCreateParams Params)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPlayGroupCreated(bool bInOk);
	
	// Export UTpPlayGroupManager::execJoinPlayGroupAsync(FFrame&, void* const)
	public virtual /*native simulated function */void JoinPlayGroupAsync(OnlineSubsystem.UniqueNetId UserId)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPlayGroupJoined(bool bInOk);
	
	public delegate void OnPlayGroupMemberJoin(OnlineSubsystem.UniqueNetId UserId);
	
	// Export UTpPlayGroupManager::execBroadCastChatMessageAsync(FFrame&, void* const)
	public virtual /*native simulated function */void BroadCastChatMessageAsync(string Message)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPlayGroupChatMessageReceived(OnlineSubsystem.UniqueNetId SenderId, string Message);
	
	// Export UTpPlayGroupManager::execDestroyPlayGroupAsync(FFrame&, void* const)
	public virtual /*native simulated function */void DestroyPlayGroupAsync()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPlayGroupDestroyed();
	
	// Export UTpPlayGroupManager::execKickMemberAsync(FFrame&, void* const)
	public virtual /*native simulated function */void KickMemberAsync(OnlineSubsystem.UniqueNetId UserId)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPlayGroupKicked();
	
	// Export UTpPlayGroupManager::execLeavePlayGroupAsync(FFrame&, void* const)
	public virtual /*native simulated function */void LeavePlayGroupAsync()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnLeavePlayGroupComplete();
	
	public delegate void OnPlayGroupMemberLeave(OnlineSubsystem.UniqueNetId UserId, OnlineSubsystem.PlayGroupLeaveReason Reason);
	
	// Export UTpPlayGroupManager::execTransferOwnerShipAsync(FFrame&, void* const)
	public virtual /*native simulated function */void TransferOwnerShipAsync(OnlineSubsystem.UniqueNetId NewOwnerId)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnPlayGroupOwnerTransitionStart();
	
	public delegate void OnPlayGroupOwnerTransitionFinish();
	
	public delegate void OnPlayGroupGameJoined(TpGameBrowser.TpLobbyRef InLobby, TpGameBrowser.TpGameRef InGame);
	
	public delegate void OnPlayGroupGameLeave();
	
}
}