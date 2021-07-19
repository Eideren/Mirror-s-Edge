namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUoPlayerEx : TpSystemHandler, 
		OnlinePlayerInterfaceEx/*
		transient
		native*/{
	public/*private*/ array< /*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult > __OnShowGamerCardResult__Multicaster;
	public /*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult __OnShowGamerCardResult__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete __OnDeviceSelectionComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete __OnUnlockAchievementComplete__Delegate{ get; set; }
	public /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged __OnProfileDataChanged__Delegate{ get; set; }
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	public virtual /*function */bool ShowFeedbackUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowGamerCardUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
		// stub
		return default;
	}
	
	public virtual /*final simulated event */void OnShowGamerCardResult_Invoke(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnShowGamerCardResult_Add(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult D)
	{
		// stub
	}
	
	public virtual /*final simulated event */void OnShowGamerCardResult_Remove(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult D)
	{
		// stub
	}
	
	public virtual /*function */void AddShowGamerCardResultDelegate(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult GamerCardDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearShowGamerCardResultDelegate(/*delegate*/OnlinePlayerInterfaceEx.OnShowGamerCardResult GamerCardDelegate)
	{
		// stub
	}
	
	public virtual /*function */void OnShowGamerCardUI(bool bWasSuccessful)
	{
		// stub
	}
	
	public virtual /*function */void CancelShowGamerCardUI()
	{
		// stub
	}
	
	public virtual /*function */bool ShowMessagesUI(byte LocalUserNum)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowAchievementsUI(byte LocalUserNum)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowInviteUI(byte LocalUserNum, /*optional */String? _InviteText = default)
	{
		// stub
		return default;
	}
	
	// Export UTpUoPlayerEx::execShowContentMarketplaceUI(FFrame&, void* const)
	public virtual /*native function */bool ShowContentMarketplaceUI(byte LocalUserNum)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowMembershipMarketplaceUI(byte LocalUserNum)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowDeviceSelectionUI(byte LocalUserNum, int SizeNeeded, /*optional */bool? _bForceShowUI = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddDeviceSelectionDoneDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete DeviceDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearDeviceSelectionDoneDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnDeviceSelectionComplete DeviceDelegate)
	{
		// stub
	}
	
	public virtual /*function */int GetDeviceSelectionResults(byte LocalUserNum, ref String DeviceName)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsDeviceValid(int DeviceID)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool UnlockAchievement(byte LocalUserNum, int AchievementId)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddUnlockAchievementCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete UnlockAchievementCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearUnlockAchievementCompleteDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnUnlockAchievementComplete UnlockAchievementCompleteDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool UnlockGamerPicture(byte LocalUserNum, int PictureId)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AddProfileDataChangedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged ProfileDataChangedDelegate)
	{
		// stub
	}
	
	public virtual /*function */void ClearProfileDataChangedDelegate(byte LocalUserNum, /*delegate*/OnlinePlayerInterfaceEx.OnProfileDataChanged ProfileDataChangedDelegate)
	{
		// stub
	}
	
	public virtual /*function */bool ShowFriendsInviteUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowPlayersUI(byte LocalUserNum)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShowSendMessageUI(OnlineSubsystem.UniqueNetId PlayerId, bool bIsFriendRequest)
	{
		// stub
		return default;
	}
	
}
}