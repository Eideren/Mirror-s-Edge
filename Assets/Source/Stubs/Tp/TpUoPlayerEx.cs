namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoPlayerEx : TpSystemHandler, 
		OnlinePlayerInterfaceEx/*
		transient
		native*/{
	public /*private */array< /*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult > __OnShowGamerCardResult__Multicaster;
	public /*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult __OnShowGamerCardResult__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete __OnDeviceSelectionComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete __OnUnlockAchievementComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged __OnProfileDataChanged__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
	
	}
	
	public virtual /*function */bool ShowFeedbackUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShowGamerCardUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	public virtual /*final simulated event */void OnShowGamerCardResult_Invoke(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*final simulated event */void OnShowGamerCardResult_Add(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult D)
	{
	
	}
	
	public virtual /*final simulated event */void OnShowGamerCardResult_Remove(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult D)
	{
	
	}
	
	public virtual /*function */void AddShowGamerCardResultDelegate(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult GamerCardDelegate)
	{
	
	}
	
	public virtual /*function */void ClearShowGamerCardResultDelegate(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult GamerCardDelegate)
	{
	
	}
	
	public virtual /*function */void OnShowGamerCardUI(bool bWasSuccessful)
	{
	
	}
	
	public virtual /*function */void CancelShowGamerCardUI()
	{
	
	}
	
	public virtual /*function */bool ShowMessagesUI(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShowAchievementsUI(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShowInviteUI(byte LocalUserNum, /*optional */string InviteText = default)
	{
	
		return default;
	}
	
	// Export UTpUoPlayerEx::execShowContentMarketplaceUI(FFrame&, void* const)
	public virtual /*native function */bool ShowContentMarketplaceUI(byte LocalUserNum)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool ShowMembershipMarketplaceUI(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShowDeviceSelectionUI(byte LocalUserNum, int SizeNeeded, /*optional */bool bForceShowUI = default)
	{
	
		return default;
	}
	
	public virtual /*function */void AddDeviceSelectionDoneDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete DeviceDelegate)
	{
	
	}
	
	public virtual /*function */void ClearDeviceSelectionDoneDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete DeviceDelegate)
	{
	
	}
	
	public virtual /*function */int GetDeviceSelectionResults(byte LocalUserNum, ref string DeviceName)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsDeviceValid(int DeviceID)
	{
	
		return default;
	}
	
	public virtual /*function */bool UnlockAchievement(byte LocalUserNum, int AchievementId)
	{
	
		return default;
	}
	
	public virtual /*function */void AddUnlockAchievementCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete UnlockAchievementCompleteDelegate)
	{
	
	}
	
	public virtual /*function */void ClearUnlockAchievementCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete UnlockAchievementCompleteDelegate)
	{
	
	}
	
	public virtual /*function */bool UnlockGamerPicture(byte LocalUserNum, int PictureId)
	{
	
		return default;
	}
	
	public virtual /*function */void AddProfileDataChangedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged ProfileDataChangedDelegate)
	{
	
	}
	
	public virtual /*function */void ClearProfileDataChangedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged ProfileDataChangedDelegate)
	{
	
	}
	
	public virtual /*function */bool ShowFriendsInviteUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShowPlayersUI(byte LocalUserNum)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShowSendMessageUI(OnlineSubsystem.UniqueNetId PlayerId, bool bIsFriendRequest)
	{
	
		return default;
	}
	
}
}