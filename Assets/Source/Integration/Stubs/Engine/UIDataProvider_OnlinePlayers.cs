namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlinePlayers : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlinePlayer> PlayersList;
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
	
	public virtual /*function */void OnPlayersReadComplete()
	{
		// stub
	}
	
	public UIDataProvider_OnlinePlayers()
	{
		// Object Offset:0x00426F4A
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