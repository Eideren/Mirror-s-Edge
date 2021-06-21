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
		// stub
	}
	
	// Export UTpDebugger::execStateChanged(FFrame&, void* const)
	public /*native simulated function */static void StateChanged(Object InObject)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpDebugger::execStateFaulted(FFrame&, void* const)
	public /*native simulated function */static void StateFaulted(Object InObject, String InWhere)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTpDebugger::execLog(FFrame&, void* const)
	public /*native simulated function */static void Log(String Str)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*simulated event */void Login(OnlineSubsystem InSys, String InName, String InPasswd)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnLoginChange()
	{
		// stub
	}
	
	public virtual /*simulated function */void OnLoginFailed(byte LocalUserNum, OnlineSubsystem.EOnlineServerConnectionStatus ErrorCode)
	{
		// stub
	}
	
	public virtual /*simulated event */void Logout(OnlineSubsystem InSys)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnLogout(bool bOk)
	{
		// stub
	}
	
	public virtual /*simulated event */void CreateAccount(OnlineSubsystem InSys, String InName, String InPassword, String InEmail)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnCreateAccount(bool bOk)
	{
		// stub
	}
	
	public virtual /*simulated event */void CreateGame(OnlineSubsystem InSys, String InName, bool bInIsLan)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnCreateGame(bool bOk)
	{
		// stub
	}
	
	public virtual /*simulated event */void DestroyGame(OnlineSubsystem InSys)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnDestroyGame(bool bOk)
	{
		// stub
	}
	
}
}