namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpMessageService : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*delegate*/TpMessageService.OnCheckInbox __OnCheckInbox__Delegate;
	public /*delegate*/TpMessageService.OnFriendRequestSent __OnFriendRequestSent__Delegate;
	public /*delegate*/TpMessageService.OnNewMessage __OnNewMessage__Delegate;
	public /*delegate*/TpMessageService.OnFriendRequestDelegate __OnFriendRequestDelegate__Delegate;
	public /*delegate*/TpMessageService.OnSendMessage __OnSendMessage__Delegate;
	public /*delegate*/TpMessageService.OnRemoveMessage __OnRemoveMessage__Delegate;
	public /*delegate*/TpMessageService.OnInviteToPlayGroupSent __OnInviteToPlayGroupSent__Delegate;
	public /*delegate*/TpMessageService.OnInviteToPlayGroupReceived __OnInviteToPlayGroupReceived__Delegate;
	
	// Export UTpMessageService::execUpdate(FFrame&, void* const)
	public virtual /*native simulated function */void Update(float DeltaSeconds)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpMessageService::execCheckInboxAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool CheckInboxAsync()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnCheckInbox();
	
	// Export UTpMessageService::execFriendRequestAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool FriendRequestAsync(OnlineSubsystem.UniqueNetId NewFriend, /*optional */String? _Message = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpMessageService::execFriendResponse(FFrame&, void* const)
	public virtual /*native simulated function */bool FriendResponse(OnlineSubsystem.UniqueNetId NewFriend)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnFriendRequestSent(bool bInOk);
	
	public delegate void OnNewMessage(OnlineSubsystem.UniqueNetId Sender, String Message);
	
	public delegate void OnFriendRequestDelegate(OnlineSubsystem.UniqueNetId Sender, String Message);
	
	// Export UTpMessageService::execSendMessageAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool SendMessageAsync(OnlineSubsystem.UniqueNetId PlayerId, String Message)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnSendMessage(bool bInOk);
	
	// Export UTpMessageService::execGetFriendMessages(FFrame&, void* const)
	public virtual /*native simulated function */void GetFriendMessages(ref array<OnlineSubsystem.OnlineFriendMessage> FriendMessages)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpMessageService::execRemoveMessage(FFrame&, void* const)
	public virtual /*native simulated function */bool RemoveMessage(int MessageIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnRemoveMessage(bool bInOk);
	
	// Export UTpMessageService::execPlayGroupInviteAsync(FFrame&, void* const)
	public virtual /*native simulated function */bool PlayGroupInviteAsync(OnlineSubsystem.UniqueNetId User)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnInviteToPlayGroupSent(bool bWasSuccessful);
	
	public delegate void OnInviteToPlayGroupReceived(OnlineSubsystem.UniqueNetId RequestingPlayer);
	
	// Export UTpMessageService::execInviteToPlayGroupResponse(FFrame&, void* const)
	public virtual /*native simulated function */bool InviteToPlayGroupResponse(OnlineSubsystem.UniqueNetId RequestingPlayer)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}