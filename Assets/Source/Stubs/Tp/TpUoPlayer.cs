// NO OVERWRITE

namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoPlayer : TpSystemHandler, 
		OnlinePlayerInterface/*
		transient
		native*/{
	public string ProfileDataDirectory;
	public string ProfileDataExtension;
	public string StoredMessage;
	public string OSKeyboardResult;
	public byte OnLoginChangeControllerId;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnLoginChange > __OnLoginChange__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnLoginCancelled > __OnLoginCancelled__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnMutingChange > __OnMutingChange__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnFriendsChange > __OnFriendsChange__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnLoginFailed > __OnLoginFailed__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnLogoutCompleted > __OnLogoutCompleted__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete > __OnReadProfileSettingsComplete__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete > __OnWriteProfileSettingsComplete__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete > __OnReadFriendsComplete__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete > __OnAddFriendByNameComplete__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived > __OnFriendInviteReceived__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived > __OnFriendMessageReceived__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete > __OnReadPlayersComplete__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete > __OnKeyboardInputComplete__Multicaster;
	public /*private */array< /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername > __OnSendMessageByUsername__Multicaster;
	public /*delegate*/OnlinePlayerInterface.OnLoginChange __OnLoginChange__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnLoginCancelled __OnLoginCancelled__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnMutingChange __OnMutingChange__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnFriendsChange __OnFriendsChange__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnLoginFailed __OnLoginFailed__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnLogoutCompleted __OnLogoutCompleted__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete __OnReadProfileSettingsComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete __OnWriteProfileSettingsComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete __OnReadFriendsComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete __OnKeyboardInputComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete __OnAddFriendByNameComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived __OnFriendInviteReceived__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername __OnSendMessageByUsername__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnReceivedGameInvite __OnReceivedGameInvite__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnJoinFriendGameComplete __OnJoinFriendGameComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived __OnFriendMessageReceived__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete __OnReadPlayersComplete__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
	
	}
	
	// Export UTpUoPlayer::execInitializeNative(FFrame&, void* const)
	public virtual /*native function */void InitializeNative()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final simulated event */void OnLoginChange_Invoke()
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginChange_Add(/*delegate*/OnlinePlayerInterface.OnLoginChange D)
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginChange_Remove(/*delegate*/OnlinePlayerInterface.OnLoginChange D)
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginCancelled_Invoke()
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginCancelled_Add(/*delegate*/OnlinePlayerInterface.OnLoginCancelled D)
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginCancelled_Remove(/*delegate*/OnlinePlayerInterface.OnLoginCancelled D)
	{
	
	}
	
	public virtual /*final simulated event */void OnMutingChange_Invoke()
	{
	
	}
	
	public virtual /*final simulated event */void OnMutingChange_Add(/*delegate*/OnlinePlayerInterface.OnMutingChange D)
	{
	
	}
	
	public virtual /*final simulated event */void OnMutingChange_Remove(/*delegate*/OnlinePlayerInterface.OnMutingChange D)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendsChange_Invoke()
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendsChange_Add(/*delegate*/OnlinePlayerInterface.OnFriendsChange D)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendsChange_Remove(/*delegate*/OnlinePlayerInterface.OnFriendsChange D)
	{
	
	}
	
	// Export UTpUoPlayer::execShowLoginUI(FFrame&, void* const)
	public virtual /*native simulated function */bool ShowLoginUI(/*optional */bool? _bShowOnlineOnly = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool Login(byte LocalUserNum, string LoginName, string Password, /*optional */bool? _bWantsLocalOnly = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool AutoLogin()
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnLoginFailed_Invoke(byte LocalUserNum, OnlineSubsystem.EOnlineServerConnectionStatus ErrorCode)
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginFailed_Add(/*delegate*/OnlinePlayerInterface.OnLoginFailed D)
	{
	
	}
	
	public virtual /*final simulated event */void OnLoginFailed_Remove(/*delegate*/OnlinePlayerInterface.OnLoginFailed D)
	{
	
	}
	
	public virtual /*simulated function */void AddLoginFailedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLoginFailed LoginDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearLoginFailedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLoginFailed LoginDelegate)
	{
	
	}
	
	public virtual /*simulated function */bool Logout(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnLogoutCompleted_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnLogoutCompleted_Add(/*delegate*/OnlinePlayerInterface.OnLogoutCompleted D)
	{
	
	}
	
	public virtual /*final simulated event */void OnLogoutCompleted_Remove(/*delegate*/OnlinePlayerInterface.OnLogoutCompleted D)
	{
	
	}
	
	public virtual /*simulated function */void AddLogoutCompletedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLogoutCompleted LogoutDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearLogoutCompletedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnLogoutCompleted LogoutDelegate)
	{
	
	}
	
	public virtual /*simulated function */OnlineSubsystem.ELoginStatus GetLoginStatus(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool GetUniquePlayerId(byte LocalUserNum, ref OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	public virtual /*simulated function */string GetPlayerNickname(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */OnlineSubsystem.EFeaturePrivilegeLevel CanPlayOnline(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */OnlineSubsystem.EFeaturePrivilegeLevel CanCommunicate(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */OnlineSubsystem.EFeaturePrivilegeLevel CanDownloadUserContent(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */OnlineSubsystem.EFeaturePrivilegeLevel CanPurchaseContent(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */OnlineSubsystem.EFeaturePrivilegeLevel CanViewPlayerProfiles(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */OnlineSubsystem.EFeaturePrivilegeLevel CanShowPresenceInformation(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool IsFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool AreAnyFriends(byte LocalUserNum, ref array<OnlineSubsystem.FriendsQuery> Query)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool IsMuted(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	// Export UTpUoPlayer::execShowFriendsUI(FFrame&, void* const)
	public virtual /*native simulated function */bool ShowFriendsUI(byte LocalUserNum)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */void AddLoginChangeDelegate(/*delegate*/OnlinePlayerInterface.OnLoginChange LoginDelegate, /*optional */byte? _LocalUserNum = default)
	{
	
	}
	
	public virtual /*simulated function */void ClearLoginChangeDelegate(/*delegate*/OnlinePlayerInterface.OnLoginChange LoginDelegate, /*optional */byte? _LocalUserNum = default)
	{
	
	}
	
	public virtual /*simulated function */void AddLoginCancelledDelegate(/*delegate*/OnlinePlayerInterface.OnLoginCancelled CancelledDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearLoginCancelledDelegate(/*delegate*/OnlinePlayerInterface.OnLoginCancelled CancelledDelegate)
	{
	
	}
	
	public virtual /*simulated function */void AddMutingChangeDelegate(/*delegate*/OnlinePlayerInterface.OnMutingChange MutingDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearMutingChangeDelegate(/*delegate*/OnlinePlayerInterface.OnMutingChange MutingDelegate)
	{
	
	}
	
	public virtual /*private final function */void OnPresenceChangeDelegate()
	{
	
	}
	
	public virtual /*private final function */void OnFriendsChangeDelegate()
	{
	
	}
	
	public virtual /*simulated function */void AddFriendsChangeDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendsChange FriendsDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearFriendsChangeDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendsChange FriendsDelegate)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadProfileSettingsComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadProfileSettingsComplete_Add(/*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadProfileSettingsComplete_Remove(/*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete D)
	{
	
	}
	
	public virtual /*function */bool ReadProfileSettings(byte LocalUserNum, OnlineProfileSettings ProfileSettings)
	{
	
		return default;
	}
	
	public virtual /*function */void SaveSystemReadProfileComplete(TsSystem.ETsResult Result)
	{
	
	}
	
	public virtual /*simulated function */void AddReadProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete ReadProfileSettingsCompleteDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearReadProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadProfileSettingsComplete ReadProfileSettingsCompleteDelegate)
	{
	
	}
	
	public virtual /*function */OnlineProfileSettings GetProfileSettings(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnWriteProfileSettingsComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnWriteProfileSettingsComplete_Add(/*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnWriteProfileSettingsComplete_Remove(/*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete D)
	{
	
	}
	
	public virtual /*function */bool WriteProfileSettings(byte LocalUserNum, OnlineProfileSettings ProfileSettings)
	{
	
		return default;
	}
	
	public virtual /*function */void SaveSystemWriteProfileComplete(TsSystem.ETsResult Result)
	{
	
	}
	
	public virtual /*simulated function */void AddWriteProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete WriteProfileSettingsCompleteDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearWriteProfileSettingsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnWriteProfileSettingsComplete WriteProfileSettingsCompleteDelegate)
	{
	
	}
	
	public virtual /*simulated function */bool ReadFriendsList(byte LocalUserNum, /*optional */int? _Count = default, /*optional */int? _StartingAt = default)
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnReadFriendsComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadFriendsComplete_Add(/*delegate*/OnlinePlayerInterface.OnReadFriendsComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadFriendsComplete_Remove(/*delegate*/OnlinePlayerInterface.OnReadFriendsComplete D)
	{
	
	}
	
	public virtual /*simulated function */void OnFriendsListLoaded(bool bInOk)
	{
	
	}
	
	public virtual /*simulated function */void AddReadFriendsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete ReadFriendsCompleteDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearReadFriendsCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadFriendsComplete ReadFriendsCompleteDelegate)
	{
	
	}
	
	public virtual /*simulated function */OnlineSubsystem.EOnlineEnumerationReadState GetFriendsList(byte LocalUserNum, ref array<OnlineSubsystem.OnlineFriend> Friends, /*optional */int? _Count = default, /*optional */int? _StartingAt = default)
	{
	
		return default;
	}
	
	public virtual /*function */void SetOnlineStatus(byte LocalUserNum, int StatusId, /*const */ref array<Settings.LocalizedStringSetting> LocalizedStringSettings, /*const */ref array<Settings.SettingsProperty> Properties)
	{
	
	}
	
	// Export UTpUoPlayer::execShowKeyboardUI(FFrame&, void* const)
	public virtual /*native function */bool ShowKeyboardUI(byte LocalUserNum, string TitleText, string DescriptionText, /*optional */bool? _bIsPassword = default, /*optional */bool? _bShouldValidate = default, /*optional */string? _DefaultText = default, /*optional */int? _MaxResultLength = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final simulated event */void OnKeyboardInputComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnKeyboardInputComplete_Add(/*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnKeyboardInputComplete_Remove(/*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete D)
	{
	
	}
	
	public virtual /*function */void AddKeyboardInputDoneDelegate(/*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete InputDelegate)
	{
	
	}
	
	public virtual /*function */void ClearKeyboardInputDoneDelegate(/*delegate*/OnlinePlayerInterface.OnKeyboardInputComplete InputDelegate)
	{
	
	}
	
	// Export UTpUoPlayer::execGetKeyboardInputResults(FFrame&, void* const)
	public virtual /*native function */string GetKeyboardInputResults(ref byte bWasCanceled)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpUoPlayer::execSetKeyboardInputResults(FFrame&, void* const)
	public virtual /*native function */void SetKeyboardInputResults(string Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */bool AddFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId NewFriend, /*optional */string? _Message = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool AddFriendByName(byte LocalUserNum, string FriendName, /*optional */string? _Message = default)
	{
	
		return default;
	}
	
	public virtual /*private final simulated function */void OnLookupPlayerIdForAddFriend(OnlineSubsystem.UniqueNetId UserId, bool bSuccess)
	{
	
	}
	
	public virtual /*private final simulated function */void OnAddFriend(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnAddFriendByNameComplete_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnAddFriendByNameComplete_Add(/*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnAddFriendByNameComplete_Remove(/*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete D)
	{
	
	}
	
	public virtual /*simulated function */void AddAddFriendByNameCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete FriendDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearAddFriendByNameCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnAddFriendByNameComplete FriendDelegate)
	{
	
	}
	
	public virtual /*simulated function */bool AcceptFriendInvite(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool DenyFriendInvite(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool RemoveFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId FormerFriend)
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnFriendInviteReceived_Invoke(byte LocalUserNum, OnlineSubsystem.UniqueNetId RequestingPlayer, string RequestingNick, string Message)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendInviteReceived_Add(/*delegate*/OnlinePlayerInterface.OnFriendInviteReceived D)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendInviteReceived_Remove(/*delegate*/OnlinePlayerInterface.OnFriendInviteReceived D)
	{
	
	}
	
	public virtual /*simulated function */void AddFriendInviteReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived InviteDelegate)
	{
	
	}
	
	public virtual /*simulated function */void ClearFriendInviteReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendInviteReceived InviteDelegate)
	{
	
	}
	
	public virtual /*simulated function */void OnFriendRequestDelegate(OnlineSubsystem.UniqueNetId RequestingPlayer, string Message)
	{
	
	}
	
	public virtual /*function */bool SendMessageToFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId Friend, string Message)
	{
	
		return default;
	}
	
	public virtual /*function */void SendMessageByUsername(byte LocalUserNum, string UserName, string Message)
	{
	
	}
	
	public virtual /*function */void SendMessageByUsernameStepTwo(OnlineSubsystem.UniqueNetId PlayerId, bool bInOk)
	{
	
	}
	
	public virtual /*function */void OnSendMessageByUsernameDone(bool bInOk)
	{
	
	}
	
	public virtual /*final simulated event */void OnSendMessageByUsername_Invoke(bool bSuccess)
	{
	
	}
	
	public virtual /*final simulated event */void OnSendMessageByUsername_Add(/*delegate*/OnlinePlayerInterface.OnSendMessageByUsername D)
	{
	
	}
	
	public virtual /*final simulated event */void OnSendMessageByUsername_Remove(/*delegate*/OnlinePlayerInterface.OnSendMessageByUsername D)
	{
	
	}
	
	public virtual /*function */void AddSendMessageByUsernameDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername SendMessageDelegate)
	{
	
	}
	
	public virtual /*function */void ClearSendMessageByUsernameDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnSendMessageByUsername SendMessageDelegate)
	{
	
	}
	
	public virtual /*function */bool SendGameInviteToFriend(byte LocalUserNum, OnlineSubsystem.UniqueNetId Friend, /*optional */string? _Text = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool SendGameInviteToFriends(byte LocalUserNum, array<OnlineSubsystem.UniqueNetId> Friends, /*optional */string? _Text = default)
	{
	
		return default;
	}
	
	public virtual /*function */void AddReceivedGameInviteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReceivedGameInvite ReceivedGameInviteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearReceivedGameInviteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReceivedGameInvite ReceivedGameInviteDelegate)
	{
	
	}
	
	public virtual /*function */bool JoinFriendGame(byte LocalUserNum, OnlineSubsystem.UniqueNetId Friend)
	{
	
		return default;
	}
	
	public virtual /*function */void AddJoinFriendGameCompleteDelegate(/*delegate*/OnlinePlayerInterface.OnJoinFriendGameComplete JoinFriendGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearJoinFriendGameCompleteDelegate(/*delegate*/OnlinePlayerInterface.OnJoinFriendGameComplete JoinFriendGameCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void GetFriendMessages(byte LocalUserNum, ref array<OnlineSubsystem.OnlineFriendMessage> FriendMessages)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendMessageReceived_Invoke(byte LocalUserNum, OnlineSubsystem.UniqueNetId SendingPlayer, string SendingNick, string Message)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendMessageReceived_Add(/*delegate*/OnlinePlayerInterface.OnFriendMessageReceived D)
	{
	
	}
	
	public virtual /*final simulated event */void OnFriendMessageReceived_Remove(/*delegate*/OnlinePlayerInterface.OnFriendMessageReceived D)
	{
	
	}
	
	public virtual /*function */void AddFriendMessageReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived MessageDelegate)
	{
	
	}
	
	public virtual /*function */void ClearFriendMessageReceivedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnFriendMessageReceived MessageDelegate)
	{
	
	}
	
	public virtual /*private final simulated function */void OnNewMessage(OnlineSubsystem.UniqueNetId PlayerId, string Message)
	{
	
	}
	
	public virtual /*function */bool DeleteMessage(byte LocalUserNum, int MessageIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool ReadPlayersList(byte LocalUserNum, /*optional */int? _Count = default, /*optional */int? _StartingAt = default)
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnReadPlayersComplete_Invoke()
	{
	
	}
	
	public virtual /*final simulated event */void OnReadPlayersComplete_Add(/*delegate*/OnlinePlayerInterface.OnReadPlayersComplete D)
	{
	
	}
	
	public virtual /*final simulated event */void OnReadPlayersComplete_Remove(/*delegate*/OnlinePlayerInterface.OnReadPlayersComplete D)
	{
	
	}
	
	public virtual /*function */void SetReadPlayersCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete ReadPlayersCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearReadPlayersCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterface.OnReadPlayersComplete ReadPlayersCompleteDelegate)
	{
	
	}
	
	public virtual /*function */OnlineSubsystem.EOnlineEnumerationReadState GetPlayersList(byte LocalUserNum, ref array<OnlineSubsystem.OnlinePlayer> Players, /*optional */int? _Count = default, /*optional */int? _StartingAt = default)
	{
	
		return default;
	}
	
	public virtual /*function */void SetActiveControllerId(byte LocalUserNum)
	{
	
	}
	
	// Export UTpUoPlayer::execProcessTick(FFrame&, void* const)
	public virtual /*native function */void ProcessTick(float DeltaSeconds)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpUoPlayer::execIsSignedIn(FFrame&, void* const)
	public virtual /*native function */bool IsSignedIn(byte LocalUserNum)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpUoPlayer::execSetActiveControllerIdNative(FFrame&, void* const)
	public virtual /*native function */void SetActiveControllerIdNative(byte LocalUserNum)
	{
		#warning NATIVE FUNCTION !
	}
	
	public TpUoPlayer()
	{
		// Object Offset:0x000533C0
		ProfileDataDirectory = "Profiles/";
		ProfileDataExtension = ".profile";
	}
}
}