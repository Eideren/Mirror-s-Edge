namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlinePlayerInterface : Interface/*
		abstract*/{
	public /*delegate*/OnlinePlayerInterface.OnLoginChange __OnLoginChange__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnLoginCancelled __OnLoginCancelled__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnMutingChange __OnMutingChange__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnFriendsChange __OnFriendsChange__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnLoginFailed __OnLoginFailed__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnLogoutCompleted __OnLogoutCompleted__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete __OnReadProfileSettingsComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete __OnWriteProfileSettingsComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete __OnReadFriendsComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete __OnKeyboardInputComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete __OnAddFriendByNameComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived __OnFriendInviteReceived__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername __OnSendMessageByUsername__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnReceivedGameInvite __OnReceivedGameInvite__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnJoinFriendGameComplete __OnJoinFriendGameComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete __OnReadPlayersComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived __OnFriendMessageReceived__Delegate{ get; }
	
	public delegate void OnLoginChange();
	
	public delegate void OnLoginCancelled();
	
	public delegate void OnMutingChange();
	
	public delegate void OnFriendsChange();
	
	public /*function */bool ShowLoginUI(/*optional */bool? _bShowOnlineOnly = default);
	
	public /*function */bool Login(byte LocalUserNum, String LoginName, String Password, /*optional */bool? _bWantsLocalOnly = default);
	
	public /*function */bool AutoLogin();
	
	public delegate void OnLoginFailed(byte LocalUserNum, OnlineSubsystem.EOnlineServerConnectionStatus ErrorCode);
	
	public /*function */void AddLoginFailedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLoginFailed LoginDelegate);
	
	public /*function */void ClearLoginFailedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLoginFailed LoginDelegate);
	
	public /*function */bool Logout(byte LocalUserNum);
	
	public delegate void OnLogoutCompleted(bool bWasSuccessful);
	
	public /*function */void AddLogoutCompletedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLogoutCompleted LogoutDelegate);
	
	public /*function */void ClearLogoutCompletedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLogoutCompleted LogoutDelegate);
	
	public /*function */OnlineSubsystem.ELoginStatus GetLoginStatus(byte LocalUserNum);
	
	public /*function */bool GetUniquePlayerId(byte LocalUserNum, ref OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */String GetPlayerNickname(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EFeaturePrivilegeLevel CanPlayOnline(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EFeaturePrivilegeLevel CanCommunicate(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EFeaturePrivilegeLevel CanDownloadUserContent(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EFeaturePrivilegeLevel CanPurchaseContent(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EFeaturePrivilegeLevel CanViewPlayerProfiles(byte LocalUserNum);
	
	public /*function */OnlineSubsystem.EFeaturePrivilegeLevel CanShowPresenceInformation(byte LocalUserNum);
	
	public /*function */bool IsFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool AreAnyFriends(byte LocalUserNum, ref array<OnlineSubsystem.FriendsQuery> Query);
	
	public /*function */bool IsMuted(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool ShowFriendsUI(byte LocalUserNum);
	
	public /*function */void AddLoginChangeDelegate(/*delegate*/OnlinePlayerInterface.OnLoginChange LoginDelegate, /*optional */byte? _LocalUserNum = default);
	
	public /*function */void ClearLoginChangeDelegate(/*delegate*/OnlinePlayerInterface.OnLoginChange LoginDelegate, /*optional */byte? _LocalUserNum = default);
	
	public /*function */void AddLoginCancelledDelegate(/*delegate*/OnlinePlayerInterface.OnLoginCancelled CancelledDelegate);
	
	public /*function */void ClearLoginCancelledDelegate(/*delegate*/OnlinePlayerInterface.OnLoginCancelled CancelledDelegate);
	
	public /*function */void AddMutingChangeDelegate(/*delegate*/OnlinePlayerInterface.OnMutingChange MutingDelegate);
	
	public /*function */void ClearMutingChangeDelegate(/*delegate*/OnlinePlayerInterface.OnMutingChange MutingDelegate);
	
	public /*function */void AddFriendsChangeDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendsChange FriendsDelegate);
	
	public /*function */void ClearFriendsChangeDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendsChange FriendsDelegate);
	
	public /*function */bool ReadProfileSettings(byte LocalUserNum, OnlineProfileSettings ProfileSettings);
	
	public delegate void OnReadProfileSettingsComplete(bool bWasSuccessful);
	
	public /*function */void AddReadProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete ReadProfileSettingsCompleteDelegate);
	
	public /*function */void ClearReadProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete ReadProfileSettingsCompleteDelegate);
	
	public /*function */OnlineProfileSettings GetProfileSettings(byte LocalUserNum);
	
	public /*function */bool WriteProfileSettings(byte LocalUserNum, OnlineProfileSettings ProfileSettings);
	
	public delegate void OnWriteProfileSettingsComplete(bool bWasSuccessful);
	
	public /*function */void AddWriteProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete WriteProfileSettingsCompleteDelegate);
	
	public /*function */void ClearWriteProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete WriteProfileSettingsCompleteDelegate);
	
	public /*function */bool ReadFriendsList(byte LocalUserNum, /*optional */int? _Count = default, /*optional */int? _StartingAt = default);
	
	public delegate void OnReadFriendsComplete(bool bWasSuccessful);
	
	public /*function */void AddReadFriendsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete ReadFriendsCompleteDelegate);
	
	public /*function */void ClearReadFriendsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete ReadFriendsCompleteDelegate);
	
	public /*function */OnlineSubsystem.EOnlineEnumerationReadState GetFriendsList(byte LocalUserNum, ref array<OnlineSubsystem.OnlineFriend> Friends, /*optional */int? _Count = default, /*optional */int? _StartingAt = default);
	
	public /*function */void SetOnlineStatus(byte LocalUserNum, int StatusId, /*const */ref array<Settings.LocalizedStringSetting> LocalizedStringSettings, /*const */ref array<Settings.SettingsProperty> Properties);
	
	public /*function */bool ShowKeyboardUI(byte LocalUserNum, String TitleText, String DescriptionText, /*optional */bool? _bIsPassword = default, /*optional */bool? _bShouldValidate = default, /*optional */String? _DefaultText = default, /*optional */int? _MaxResultLength = default);
	
	public /*function */void AddKeyboardInputDoneDelegate(/*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete InputDelegate);
	
	public /*function */void ClearKeyboardInputDoneDelegate(/*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete InputDelegate);
	
	public /*function */String GetKeyboardInputResults(ref byte bWasCanceled);
	
	public delegate void OnKeyboardInputComplete(bool bWasSuccessful);
	
	public /*function */bool AddFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId NewFriend, /*optional */String? _Message = default);
	
	public /*function */bool AddFriendByName(byte LocalUserNum, String FriendName, /*optional */String? _Message = default);
	
	public delegate void OnAddFriendByNameComplete(bool bWasSuccessful);
	
	public /*function */void AddAddFriendByNameCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete FriendDelegate);
	
	public /*function */void ClearAddFriendByNameCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete FriendDelegate);
	
	public /*function */bool AcceptFriendInvite(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer);
	
	public /*function */bool DenyFriendInvite(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer);
	
	public /*function */bool RemoveFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId FormerFriend);
	
	public delegate void OnFriendInviteReceived(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer, String RequestingNick, String Message);
	
	public /*function */void AddFriendInviteReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived InviteDelegate);
	
	public /*function */void ClearFriendInviteReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived InviteDelegate);
	
	public /*function */bool SendMessageToFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId Friend, String Message);
	
	public /*function */void SendMessageByUsername(byte LocalUserNum, String UserName, String Message);
	
	public delegate void OnSendMessageByUsername(bool bSuccess);
	
	public /*function */void AddSendMessageByUsernameDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername SendMessageDelegate);
	
	public /*function */void ClearSendMessageByUsernameDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername SendMessageDelegate);
	
	public /*function */bool SendGameInviteToFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId Friend, /*optional */String? _Text = default);
	
	public /*function */bool SendGameInviteToFriends(byte LocalUserNum, array<OnlineSubsystem.UniqueNetId> Friends, /*optional */String? _Text = default);
	
	public delegate void OnReceivedGameInvite(byte LocalUserNum, String InviterName);
	
	public /*function */void AddReceivedGameInviteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReceivedGameInvite ReceivedGameInviteDelegate);
	
	public /*function */void ClearReceivedGameInviteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReceivedGameInvite ReceivedGameInviteDelegate);
	
	public /*function */bool JoinFriendGame(byte LocalUserNum, OnlineSubsystem.UniqueNetId Friend);
	
	public delegate void OnJoinFriendGameComplete(bool bWasSuccessful);
	
	public /*function */void AddJoinFriendGameCompleteDelegate(/*delegate*/OnlinePlayerInterface.OnJoinFriendGameComplete JoinFriendGameCompleteDelegate);
	
	public /*function */void ClearJoinFriendGameCompleteDelegate(/*delegate*/OnlinePlayerInterface.OnJoinFriendGameComplete JoinFriendGameCompleteDelegate);
	
	public /*function */bool ReadPlayersList(byte LocalUserNum, /*optional */int? _Count = default, /*optional */int? _StartingAt = default);
	
	public delegate void OnReadPlayersComplete();
	
	public /*function */void SetReadPlayersCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete ReadPlayersCompleteDelegate);
	
	public /*function */void ClearReadPlayersCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete ReadPlayersCompleteDelegate);
	
	public /*function */OnlineSubsystem.EOnlineEnumerationReadState GetPlayersList(byte LocalUserNum, ref array<OnlineSubsystem.OnlinePlayer> Players, /*optional */int? _Count = default, /*optional */int? _StartingAt = default);
	
	public /*function */void GetFriendMessages(byte LocalUserNum, ref array<OnlineSubsystem.OnlineFriendMessage> FriendMessages);
	
	public delegate void OnFriendMessageReceived(byte LocalUserNum, OnlineSubsystem.UniqueNetId SendingPlayer, String SendingNick, String Message);
	
	public /*function */void AddFriendMessageReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived MessageDelegate);
	
	public /*function */void ClearFriendMessageReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived MessageDelegate);
	
	public /*function */bool DeleteMessage(byte LocalUserNum, int MessageIndex);
	
	public /*function */void SetActiveControllerId(byte LocalUserNum);
	
}
}