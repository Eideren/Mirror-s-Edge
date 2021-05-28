namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlinePlayers : UIDataProvider_OnlinePlayerDataBase, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	public array<OnlineSubsystem.OnlinePlayer> PlayersList;
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
	
	public virtual /*function */void OnPlayersReadComplete()
	{
	
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