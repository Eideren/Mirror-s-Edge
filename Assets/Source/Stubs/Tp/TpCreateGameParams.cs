namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpCreateGameParams : Object/*
		abstract
		transient
		native*/{
	public enum TpInviteStatus 
	{
		kTpIs_Enabled,
		kTpIs_HostOnly,
		kTpIs_Disabled,
		kTpIs_MAX
	};
	
	public enum TpPlayerType 
	{
		kTpPt_Participant,
		kTpPt_Observer,
		kTpPt_MAX
	};
	
	// Export UTpCreateGameParams::execGetOpaqueFeslPointer(FFrame&, void* const)
	public virtual /*native simulated function */Object.Pointer GetOpaqueFeslPointer()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpCreateGameParams::execSetGameName(FFrame&, void* const)
	public virtual /*native simulated function */void SetGameName(String InName)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetPlayerTypeCapacity(FFrame&, void* const)
	public virtual /*native simulated function */void SetPlayerTypeCapacity(TpCreateGameParams.TpPlayerType InType, int InCapacity)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetPasswordUsed(FFrame&, void* const)
	public virtual /*native simulated function */void SetPasswordUsed(bool bInUsed)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetRanked(FFrame&, void* const)
	public virtual /*native simulated function */void SetRanked(bool bInRanked)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetJoinInProgressEnabled(FFrame&, void* const)
	public virtual /*native simulated function */void SetJoinInProgressEnabled(bool bInEnabled)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetJoinViaPresenceEnabled(FFrame&, void* const)
	public virtual /*native simulated function */void SetJoinViaPresenceEnabled(bool bInEnabled)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetInviteStatus(FFrame&, void* const)
	public virtual /*native simulated function */void SetInviteStatus(TpCreateGameParams.TpInviteStatus InStatus)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpCreateGameParams::execSetHostMigrationEnabled(FFrame&, void* const)
	public virtual /*native simulated function */void SetHostMigrationEnabled(bool bInEnabled)
	{
		#warning NATIVE FUNCTION !
	}
	
}
}