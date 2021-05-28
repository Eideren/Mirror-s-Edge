namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpDebugger : Object/*
		transient
		native*/{
	public /*private native const noexport */Object.Pointer VfTable_FTickableObject;
	
	// Export UTpDebugger::execRegister(FFrame&, void* const)
	public /*native simulated function */static void Register(Object InObject)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpDebugger::execStateChanged(FFrame&, void* const)
	public /*native simulated function */static void StateChanged(Object InObject)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpDebugger::execStateFaulted(FFrame&, void* const)
	public /*native simulated function */static void StateFaulted(Object InObject, string InWhere)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpDebugger::execLog(FFrame&, void* const)
	public /*native simulated function */static void Log(string Str)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated event */void Login(OnlineSubsystem InSys, string InName, string InPasswd)
	{
	
	}
	
	public virtual /*simulated function */void OnLoginChange()
	{
	
	}
	
	public virtual /*simulated function */void OnLoginFailed(byte LocalUserNum, OnlineSubsystem.EOnlineServerConnectionStatus ErrorCode)
	{
	
	}
	
	public virtual /*simulated event */void Logout(OnlineSubsystem InSys)
	{
	
	}
	
	public virtual /*simulated function */void OnLogout(bool bOk)
	{
	
	}
	
	public virtual /*simulated event */void CreateAccount(OnlineSubsystem InSys, string InName, string InPassword, string InEmail)
	{
	
	}
	
	public virtual /*simulated function */void OnCreateAccount(bool bOk)
	{
	
	}
	
	public virtual /*simulated event */void CreateGame(OnlineSubsystem InSys, string InName, bool bInIsLan)
	{
	
	}
	
	public virtual /*simulated function */void OnCreateGame(bool bOk)
	{
	
	}
	
	public virtual /*simulated event */void DestroyGame(OnlineSubsystem InSys)
	{
	
	}
	
	public virtual /*simulated function */void OnDestroyGame(bool bOk)
	{
	
	}
	
}
}