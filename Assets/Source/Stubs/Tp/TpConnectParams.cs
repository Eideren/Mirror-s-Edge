namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpConnectParams : Object/*
		abstract
		transient
		native*/{
	public enum TpConnectMode 
	{
		kTpCm_AuthenticatedWan,
		kTpCm_AuthenticatedLan,
		kTpCm_UnauthenticatedLan,
		kTpCm_MAX
	};
	
	public enum TpLoginMode 
	{
		kTpLm_SilentLogin,
		kTpLm_LoginNoDisconnect,
		kTpLm_Login,
		kTpLm_MAX
	};
	
	// Export UTpConnectParams::execGetOpaqueFeslPointer(FFrame&, void* const)
	public virtual /*native simulated function */Object.Pointer GetOpaqueFeslPointer()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpConnectParams::execSetConnectMode(FFrame&, void* const)
	public virtual /*native simulated function */void SetConnectMode(TpConnectParams.TpConnectMode InMode)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnectParams::execGetConnectMode(FFrame&, void* const)
	public virtual /*native simulated function */TpConnectParams.TpConnectMode GetConnectMode()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpConnectParams::execSetUnauthenticatedPlayerName(FFrame&, void* const)
	public virtual /*native simulated function */void SetUnauthenticatedPlayerName(string InName)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpConnectParams::execGetUnauthenticatedPlayerName(FFrame&, void* const)
	public virtual /*native simulated function */string GetUnauthenticatedPlayerName()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpConnectParams::execInitializeAuthentication(FFrame&, void* const)
	public virtual /*native simulated function */void InitializeAuthentication(TpConnectParams.TpLoginMode InLoginMode)
	{
		#warning NATIVE FUNCTION !
	}
	
}
}