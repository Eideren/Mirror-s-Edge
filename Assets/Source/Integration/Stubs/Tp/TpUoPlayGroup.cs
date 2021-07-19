namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoPlayGroup : TpSystemHandler, 
		OnlinePlayGroupInterface/*
		transient*/{
	public/*private*/ TpGameBrowser.TpLobbyRef GroupLobby;
	public/*private*/ TpGameBrowser.TpGameRef GroupGame;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated > __OnPlayGroupCreated__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined > __OnPlayGroupJoined__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete > __OnInviteToPlayGroupComplete__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived > __OnInviteToPlayGroupReceived__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin > __OnPlayGroupMemberJoin__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived > __OnPlayGroupChatMessageReceived__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed > __OnPlayGroupDestroyed__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked > __OnPlayGroupKicked__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete > __OnLeavePlayGroupComplete__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave > __OnPlayGroupMemberLeave__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart > __OnPlayGroupOwnerTransitionStart__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish > __OnPlayGroupOwnerTransitionFinish__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined > __OnPlayGroupGameJoined__Multicaster;
	public/*private*/ array< /*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave > __OnPlayGroupGameLeave__Multicaster;
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated __OnPlayGroupCreated__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined __OnPlayGroupJoined__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete __OnInviteToPlayGroupComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived __OnInviteToPlayGroupReceived__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin __OnPlayGroupMemberJoin__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived __OnPlayGroupChatMessageReceived__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed __OnPlayGroupDestroyed__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked __OnPlayGroupKicked__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete __OnLeavePlayGroupComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave __OnPlayGroupMemberLeave__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart __OnPlayGroupOwnerTransitionStart__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish __OnPlayGroupOwnerTransitionFinish__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined __OnPlayGroupGameJoined__Delegate{ get; set; }
	public /*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave __OnPlayGroupGameLeave__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	public virtual /*function */bool IsInPlayGroup()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsPlayGroupOwner()
	{
		// stub
		return default;
	}
	
	public virtual /*function */array<OnlineSubsystem.PlayGroupListEntry> GetMyPlayGroupList()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void CreatePlayGroupAsync(OnlineSubsystem.PlayGroupCreateParams Params)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupCreated_Invoke(bool bInOk)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupCreated_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupCreated_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupCreatedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated OnPlayGroupCreatedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupCreatedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupCreated OnPlayGroupCreatedDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupCreated(bool bInOk)
	{
		// stub
	}
	
	public virtual /*function */void JoinPlayGroupAsync(OnlineSubsystem.UniqueNetId UserId)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupJoined_Invoke(bool bInOk)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupJoined_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupJoined_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined OnPlayGroupJoinedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupJoined OnPlayGroupJoinedDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupJoined(bool bInOk)
	{
		// stub
	}
	
	public virtual /*function */bool InviteToPlayGroupAsync(OnlineSubsystem.UniqueNetId UserId)
	{
		// stub
		return default;
	}
	
	public virtual /*private final simulated function */void OnInviteSent(bool bInOk)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnInviteToPlayGroupComplete_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnInviteToPlayGroupComplete_Add(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnInviteToPlayGroupComplete_Remove(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddOnInviteToPlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete OnInviteToPlayGroupComplete)
	{
		// stub
	}
	
	public virtual /*function */void ClearOnInviteToPlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupComplete OnInviteToPlayGroupComplete)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void OnInviteToPlayGroup(OnlineSubsystem.UniqueNetId RequestingPlayer)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnInviteToPlayGroupReceived_Invoke(OnlineSubsystem.UniqueNetId RequestingUserId)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnInviteToPlayGroupReceived_Add(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnInviteToPlayGroupReceived_Remove(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived D)
	{
		// stub
	}
	
	public virtual /*function */void AddOnInviteToPlayGroupReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived OnInviteToPlayGroupReceived)
	{
		// stub
	}
	
	public virtual /*function */void ClearOnInviteToPlayGroupReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnInviteToPlayGroupReceived OnInviteToPlayGroupReceived)
	{
		// stub
	}
	
	public virtual /*function */bool AcceptInviteToPlayGroup(OnlineSubsystem.UniqueNetId RequestingUserId)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnPlayGroupMemberJoin_Invoke(OnlineSubsystem.UniqueNetId NewMemberUserId)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupMemberJoin_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupMemberJoin_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupMemberJoinDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin OnPlayGroupMemberJoinDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupMemberJoinDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberJoin OnPlayGroupMemberJoinDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupMemberJoin(OnlineSubsystem.UniqueNetId NewMemberUserId)
	{
		// stub
	}
	
	public virtual /*function */void BroadCastChatMessageAsync(String Message)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupChatMessageReceived_Invoke(OnlineSubsystem.UniqueNetId SenderId, String Message)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupChatMessageReceived_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupChatMessageReceived_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupChatMessageReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived OnPlayGroupChatMessageReceivedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupChatMessageReceivedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupChatMessageReceived OnPlayGroupChatMessageReceivedDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupChatMessageReceived(OnlineSubsystem.UniqueNetId SenderId, String Message)
	{
		// stub
	}
	
	public virtual /*function */void DestroyPlayGroupAsync()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupDestroyed_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupDestroyed_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupDestroyed_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupDestroyedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed OnPlayGroupDestroyedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupDestroyedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupDestroyed OnPlayGroupDestroyedDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupDestroyed()
	{
		// stub
	}
	
	public virtual /*function */void KickMemberAsync(OnlineSubsystem.UniqueNetId UserId)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupKicked_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupKicked_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupKicked_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupKickedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked OnPlayGroupKickedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupKickedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupKicked OnPlayGroupKickedDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupKicked()
	{
		// stub
	}
	
	public virtual /*function */void LeavePlayGroupAsync()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnLeavePlayGroupComplete_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnLeavePlayGroupComplete_Add(/*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnLeavePlayGroupComplete_Remove(/*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete D)
	{
		// stub
	}
	
	public virtual /*function */void AddLeavePlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete OnLeavePlayGroupCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearLeavePlayGroupCompleteDelegate(/*delegate*/OnlinePlayGroupInterface.OnLeavePlayGroupComplete OnLeavePlayGroupCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnLeavePlayGroupComplete()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupMemberLeave_Invoke(OnlineSubsystem.UniqueNetId UserId, OnlineSubsystem.PlayGroupLeaveReason Reason)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupMemberLeave_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupMemberLeave_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupMemberLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave OnPlayGroupMemberLeaveDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupMemberLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupMemberLeave OnPlayGroupMemberLeaveDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupMemberLeave(OnlineSubsystem.UniqueNetId UserId, OnlineSubsystem.PlayGroupLeaveReason Reason)
	{
		// stub
	}
	
	public virtual /*function */void TransferOwnerShipAsync(OnlineSubsystem.UniqueNetId NewOwnerId)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupOwnerTransitionStart_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupOwnerTransitionStart_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupOwnerTransitionStart_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupOwnerTransitionStartDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart OnPlayGroupOwnerTransitionStartDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupOwnerTransitionStartDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionStart OnPlayGroupOwnerTransitionStartDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupOwnerTransitionStart()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupOwnerTransitionFinish_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupOwnerTransitionFinish_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupOwnerTransitionFinish_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupOwnerTransitionFinishDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish OnPlayGroupOwnerTransitionFinishDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupOwnerTransitionFinishDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupOwnerTransitionFinish OnPlayGroupOwnerTransitionFinishDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupOwnerTransitionFinish()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupGameJoined_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupGameJoined_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupGameJoined_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupGameJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined OnPlayGroupGameJoinedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupGameJoinedDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameJoined OnPlayGroupGameJoinedDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupGameJoined(TpGameBrowser.TpLobbyRef InLobby, TpGameBrowser.TpGameRef InGame)
	{
		// stub
	}
	
	public virtual /*function */void JoinGroupGame()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupGameLeave_Invoke()
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupGameLeave_Add(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnPlayGroupGameLeave_Remove(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave D)
	{
		// stub
	}
	
	public virtual /*function */void AddPlayGroupGameLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave OnPlayGroupGameLeaveDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearPlayGroupGameLeaveDelegate(/*delegate*/OnlinePlayGroupInterface.OnPlayGroupGameLeave OnPlayGroupGameLeaveDelegate)
	{
		// stub
	}
	
	public virtual /*private final simulated function */void Del_OnPlayGroupGameLeave()
	{
		// stub
	}
	
	public virtual /*function */void LeaveGroupGame()
	{
		// stub
	}
	
}
}