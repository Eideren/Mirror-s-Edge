namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlinePlayGroupInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated __OnPlayGroupCreated__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined __OnPlayGroupJoined__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete __OnInviteToPlayGroupComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived __OnInviteToPlayGroupReceived__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin __OnPlayGroupMemberJoin__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived __OnPlayGroupChatMessageReceived__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed __OnPlayGroupDestroyed__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked __OnPlayGroupKicked__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete __OnLeavePlayGroupComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave __OnPlayGroupMemberLeave__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart __OnPlayGroupOwnerTransitionStart__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish __OnPlayGroupOwnerTransitionFinish__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined __OnPlayGroupGameJoined__Delegate{ get; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave __OnPlayGroupGameLeave__Delegate{ get; }
	
	public /*function */bool IsInPlayGroup();
	
	public /*function */bool IsPlayGroupOwner();
	
	public /*function */array<OnlineSubsystem.PlayGroupListEntry> GetMyPlayGroupList();
	
	public /*function */void CreatePlayGroupAsync(OnlineSubsystem.PlayGroupCreateParams Params);
	
	public delegate void OnPlayGroupCreated(bool bInOk);
	
	public /*function */void AddPlayGroupCreatedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated OnPlayGroupCreatedDelegate);
	
	public /*function */void ClearPlayGroupCreatedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated OnPlayGroupCreatedDelegate);
	
	public /*function */void JoinPlayGroupAsync(OnlineSubsystem.UniqueNetId UserId);
	
	public delegate void OnPlayGroupJoined(bool bInOk);
	
	public /*function */void AddPlayGroupJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined OnPlayGroupJoinedDelegate);
	
	public /*function */void ClearPlayGroupJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined OnPlayGroupJoinedDelegate);
	
	public /*function */bool InviteToPlayGroupAsync(OnlineSubsystem.UniqueNetId UserId);
	
	public delegate void OnInviteToPlayGroupComplete(bool bWasSuccessful);
	
	public /*function */void AddOnInviteToPlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete OnInviteToPlayGroupComplete);
	
	public /*function */void ClearOnInviteToPlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete OnInviteToPlayGroupComplete);
	
	public delegate void OnInviteToPlayGroupReceived(OnlineSubsystem.UniqueNetId RequestingUserId);
	
	public /*function */void AddOnInviteToPlayGroupReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived OnInviteToPlayGroupReceived);
	
	public /*function */void ClearOnInviteToPlayGroupReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived OnInviteToPlayGroupReceived);
	
	public /*function */bool AcceptInviteToPlayGroup(OnlineSubsystem.UniqueNetId RequestingUserId);
	
	public delegate void OnPlayGroupMemberJoin(OnlineSubsystem.UniqueNetId NewMemberUserId);
	
	public /*function */void AddPlayGroupMemberJoinDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin OnPlayGroupMemberJoinDelegate);
	
	public /*function */void ClearPlayGroupMemberJoinDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin OnPlayGroupMemberJoinDelegate);
	
	public /*function */void BroadCastChatMessageAsync(String Message);
	
	public delegate void OnPlayGroupChatMessageReceived(OnlineSubsystem.UniqueNetId SenderId, String Message);
	
	public /*function */void AddPlayGroupChatMessageReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived OnPlayGroupChatMessageReceivedDelegate);
	
	public /*function */void ClearPlayGroupChatMessageReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived OnPlayGroupChatMessageReceivedDelegate);
	
	public /*function */void DestroyPlayGroupAsync();
	
	public delegate void OnPlayGroupDestroyed();
	
	public /*function */void AddPlayGroupDestroyedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed OnPlayGroupDestroyedDelegate);
	
	public /*function */void ClearPlayGroupDestroyedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed OnPlayGroupDestroyedDelegate);
	
	public /*function */void KickMemberAsync(OnlineSubsystem.UniqueNetId UserId);
	
	public delegate void OnPlayGroupKicked();
	
	public /*function */void AddPlayGroupKickedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked OnPlayGroupKickedDelegate);
	
	public /*function */void ClearPlayGroupKickedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked OnPlayGroupKickedDelegate);
	
	public /*function */void LeavePlayGroupAsync();
	
	public delegate void OnLeavePlayGroupComplete();
	
	public /*function */void AddLeavePlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete OnLeavePlayGroupCompleteDelegate);
	
	public /*function */void ClearLeavePlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete OnLeavePlayGroupCompleteDelegate);
	
	public delegate void OnPlayGroupMemberLeave(OnlineSubsystem.UniqueNetId UserId, OnlineSubsystem.PlayGroupLeaveReason Reason);
	
	public /*function */void AddPlayGroupMemberLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave OnPlayGroupMemberLeaveDelegate);
	
	public /*function */void ClearPlayGroupMemberLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave OnPlayGroupMemberLeaveDelegate);
	
	public /*function */void TransferOwnerShipAsync(OnlineSubsystem.UniqueNetId NewOwnerId);
	
	public delegate void OnPlayGroupOwnerTransitionStart();
	
	public /*function */void AddPlayGroupOwnerTransitionStartDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart OnPlayGroupOwnerTransitionStartDelegate);
	
	public /*function */void ClearPlayGroupOwnerTransitionStartDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart OnPlayGroupOwnerTransitionStartDelegate);
	
	public delegate void OnPlayGroupOwnerTransitionFinish();
	
	public /*function */void AddPlayGroupOwnerTransitionFinishDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish OnPlayGroupOwnerTransitionFinishDelegate);
	
	public /*function */void ClearPlayGroupOwnerTransitionFinishDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish OnPlayGroupOwnerTransitionFinishDelegate);
	
	public delegate void OnPlayGroupGameJoined();
	
	public /*function */void AddPlayGroupGameJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined OnPlayGroupGameJoinedDelegate);
	
	public /*function */void ClearPlayGroupGameJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined OnPlayGroupGameJoinedDelegate);
	
	public /*function */void JoinGroupGame();
	
	public delegate void OnPlayGroupGameLeave();
	
	public /*function */void AddPlayGroupGameLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave OnPlayGroupGameLeaveDelegate);
	
	public /*function */void ClearPlayGroupGameLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave OnPlayGroupGameLeaveDelegate);
	
	public /*function */void LeaveGroupGame();
	
}
}