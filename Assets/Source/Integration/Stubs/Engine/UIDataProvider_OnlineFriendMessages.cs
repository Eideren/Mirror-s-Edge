namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlineFriendMessages : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlineFriendMessage> Messages;
	[Const, localized] public String SendingPlayerNameCol;
	[Const, localized] public String bIsFriendInviteCol;
	[Const, localized] public String bWasAcceptedCol;
	[Const, localized] public String bWasDeniedCol;
	[Const, localized] public String MessageCol;
	public String LastInviteFrom;
	
	public override /*event */void OnRegister(LocalPlayer InPlayer)
	{
		// stub
	}
	
	public override /*event */void OnUnregister()
	{
		// stub
	}
	
	public virtual /*function */void ReadMessages()
	{
		// stub
	}
	
	public virtual /*function */void OnFriendInviteReceived(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer, String RequestingNick, String Message)
	{
		// stub
	}
	
	public virtual /*function */void OnFriendMessageReceived(byte LocalUserNum, OnlineSubsystem.UniqueNetId SendingPlayer, String SendingNick, String Message)
	{
		// stub
	}
	
	public virtual /*function */void OnLoginChange()
	{
		// stub
	}
	
	public virtual /*function */void OnGameInviteReceived(byte LocalUserNum, String InviterName)
	{
		// stub
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