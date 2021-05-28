namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpUserManager : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*transient */bool bCancelGamerCard;
	public /*delegate*/TpUserManager.OnGetPlayerId __OnGetPlayerId__Delegate;
	public /*delegate*/TpUserManager.OnShowGamerCardUI __OnShowGamerCardUI__Delegate;
	
	// Export UTpUserManager::execGetLocalPlayerId(FFrame&, void* const)
	public virtual /*native simulated function */OnlineSubsystem.UniqueNetId GetLocalPlayerId()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpUserManager::execGetLocalUsername(FFrame&, void* const)
	public virtual /*native simulated function */string GetLocalUsername(byte LocalUserNum)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpUserManager::execGetPlayerId(FFrame&, void* const)
	public virtual /*native simulated function */OnlineSubsystem.UniqueNetId GetPlayerId(string UserName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpUserManager::execGetUsername(FFrame&, void* const)
	public virtual /*native simulated function */string GetUsername(OnlineSubsystem.UniqueNetId PlayerId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpUserManager::execLookupPlayerId(FFrame&, void* const)
	public virtual /*native simulated function */bool LookupPlayerId(string UserName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void OnGetPlayerId(OnlineSubsystem.UniqueNetId PlayerId, bool bInOk);
	
	// Export UTpUserManager::execShowGamerCardUI(FFrame&, void* const)
	public virtual /*native simulated function */bool ShowGamerCardUI(byte LocalUserNum, OnlineSubsystem.UniqueNetId PlayerId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void OnShowGamerCardUI(bool bInOk);
	
	// Export UTpUserManager::execCancelShowGamerCardUI(FFrame&, void* const)
	public virtual /*native simulated function */void CancelShowGamerCardUI()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpUserManager::execShowSendMessageUI(FFrame&, void* const)
	public virtual /*native simulated function */bool ShowSendMessageUI(OnlineSubsystem.UniqueNetId Recipient, bool bIsFriendRequest)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}