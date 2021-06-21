namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_OnlinePlayerData : UIDataStore_Remote, 
		UIListElementProvider/*
		transient
		native
		config(Engine)
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementProvider;
	public UIDataProvider_OnlineFriends FriendsProvider;
	public UIDataProvider_OnlinePlayers PlayersProvider;
	public UIDataProvider_OnlineClanMates ClanMatesProvider;
	public LocalPlayer Player;
	public String PlayerNick;
	public int NumNewDownloads;
	public int NumTotalDownloads;
	public /*config */String ProfileSettingsClassName;
	public Core.ClassT<OnlineProfileSettings> ProfileSettingsClass;
	public UIDataProvider_OnlineProfileSettings ProfileProvider;
	public UIDataProvider_OnlineFriendMessages FriendMessagesProvider;
	public /*config */String FriendsProviderClassName;
	public Core.ClassT<UIDataProvider_OnlineFriends> FriendsProviderClass;
	public /*config */String PlayersProviderClassName;
	public Core.ClassT<UIDataProvider_OnlinePlayers> PlayersProviderClass;
	public /*config */String ClanMatesProviderClassName;
	public Core.ClassT<UIDataProvider_OnlineClanMates> ClanMatesProviderClass;
	public /*config */String FriendMessagesProviderClassName;
	public Core.ClassT<UIDataProvider_OnlineFriendMessages> FriendMessagesProviderClass;
	
	public virtual /*event */void OnRegister(LocalPlayer InPlayer)
	{
		// stub
	}
	
	public virtual /*event */void OnUnregister()
	{
		// stub
	}
	
	public virtual /*function */void OnLoginChange()
	{
		// stub
	}
	
	public virtual /*function */void OnPlayerDataChange()
	{
		// stub
	}
	
	public virtual /*event */void RegisterDelegates()
	{
		// stub
	}
	
	public virtual /*function */void OnProviderChanged(UIDataProvider SourceProvider, /*optional */name? _PropTag = default)
	{
		// stub
	}
	
	public virtual /*function */void OnDownloadableContentQueryDone(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*event */bool SaveProfileData()
	{
		// stub
		return default;
	}
	
	public UIDataStore_OnlinePlayerData()
	{
		// Object Offset:0x0042B47F
		PlayerNick = "PlayerNickNameHere";
		ProfileSettingsClassName = "TdGame.TdProfileSettings";
		FriendsProviderClassName = "TdGame.UIDataProvider_TdOnlineFriends";
		FriendMessagesProviderClassName = "TdGame.UIDataProvider_TdOnlineFriendMessages";
		Tag = (name)"OnlinePlayerData";
	}
}
}