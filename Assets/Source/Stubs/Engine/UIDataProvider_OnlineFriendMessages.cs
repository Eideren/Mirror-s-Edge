namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineFriendMessages : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlineFriendMessage> Messages;
	public /*const localized */String SendingPlayerNameCol;
	public /*const localized */String bIsFriendInviteCol;
	public /*const localized */String bWasAcceptedCol;
	public /*const localized */String bWasDeniedCol;
	public /*const localized */String MessageCol;
	public String LastInviteFrom;
	
	public override /*event */void OnRegister(LocalPlayer InPlayer)
	{
	
	}
	
	public override /*event */void OnUnregister()
	{
	
	}
	
	public virtual /*function */void ReadMessages()
	{
	
	}
	
	public virtual /*function */void OnFriendInviteReceived(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer, String RequestingNick, String Message)
	{
	
	}
	
	public virtual /*function */void OnFriendMessageReceived(byte LocalUserNum, OnlineSubsystem.UniqueNetId SendingPlayer, String SendingNick, String Message)
	{
	
	}
	
	public virtual /*function */void OnLoginChange()
	{
	
	}
	
	public virtual /*function */void OnGameInviteReceived(byte LocalUserNum, String InviterName)
	{
	
	}
	
	public UIDataProvider_OnlineFriendMessages()
	{
		// Object Offset:0x00425F61
		SendingPlayerNameCol = "Sender's Name";
		bIsFriendInviteCol = "Friend Invitation";
		bWasAcceptedCol = "Friend Was Accepted";
		bWasDeniedCol = "Friend Was Denied";
		MessageCol = "Message";
	}
}
}