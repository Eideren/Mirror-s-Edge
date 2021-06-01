namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface OnlinePlayerInterfaceEx : Interface/*
		abstract*/{
	public /*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult __OnShowGamerCardResult__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete __OnDeviceSelectionComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete __OnUnlockAchievementComplete__Delegate{ get; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged __OnProfileDataChanged__Delegate{ get; }
	
	public /*function */bool ShowFeedbackUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool ShowGamerCardUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */void AddShowGamerCardResultDelegate(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult GamerCardDelegate);
	
	public /*function */void ClearShowGamerCardResultDelegate(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult GamerCardDelegate);
	
	public delegate void OnShowGamerCardResult(bool bWasSuccessful);
	
	public /*function */void CancelShowGamerCardUI();
	
	public /*function */bool ShowMessagesUI(byte LocalUserNum);
	
	public /*function */bool ShowAchievementsUI(byte LocalUserNum);
	
	public /*function */bool ShowInviteUI(byte LocalUserNum, /*optional */String? _InviteText = default);
	
	public /*function */bool ShowContentMarketplaceUI(byte LocalUserNum);
	
	public /*function */bool ShowMembershipMarketplaceUI(byte LocalUserNum);
	
	public /*function */bool ShowDeviceSelectionUI(byte LocalUserNum, int SizeNeeded, /*optional */bool? _bForceShowUI = default);
	
	public /*function */void AddDeviceSelectionDoneDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete DeviceDelegate);
	
	public /*function */void ClearDeviceSelectionDoneDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete DeviceDelegate);
	
	public /*function */int GetDeviceSelectionResults(byte LocalUserNum, ref String DeviceName);
	
	public delegate void OnDeviceSelectionComplete(bool bWasSuccessful);
	
	public /*function */bool IsDeviceValid(int DeviceID);
	
	public /*function */bool UnlockAchievement(byte LocalUserNum, int AchievementId);
	
	public /*function */void AddUnlockAchievementCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete UnlockAchievementCompleteDelegate);
	
	public /*function */void ClearUnlockAchievementCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete UnlockAchievementCompleteDelegate);
	
	public delegate void OnUnlockAchievementComplete(bool bWasSuccessful);
	
	public /*function */bool UnlockGamerPicture(byte LocalUserNum, int PictureId);
	
	public delegate void OnProfileDataChanged();
	
	public /*function */void AddProfileDataChangedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged ProfileDataChangedDelegate);
	
	public /*function */void ClearProfileDataChangedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged ProfileDataChangedDelegate);
	
	public /*function */bool ShowFriendsInviteUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId);
	
	public /*function */bool ShowPlayersUI(byte LocalUserNum);
	
	public /*function */bool ShowSendMessageUI(OnlineSubsystem.UniqueNetId PlayerId, bool bIsFriendRequest);
	
}
}