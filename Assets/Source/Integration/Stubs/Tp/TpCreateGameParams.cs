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
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpCreateGameParams::execSetGameName(FFrame&, void* const)
	public virtual /*native simulated function */void SetGameName(String InName)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetPlayerTypeCapacity(FFrame&, void* const)
	public virtual /*native simulated function */void SetPlayerTypeCapacity(TpCreateGameParams.TpPlayerType InType, int InCapacity)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetPasswordUsed(FFrame&, void* const)
	public virtual /*native simulated function */void SetPasswordUsed(bool bInUsed)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetRanked(FFrame&, void* const)
	public virtual /*native simulated function */void SetRanked(bool bInRanked)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetJoinInProgressEnabled(FFrame&, void* const)
	public virtual /*native simulated function */void SetJoinInProgressEnabled(bool bInEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetJoinViaPresenceEnabled(FFrame&, void* const)
	public virtual /*native simulated function */void SetJoinViaPresenceEnabled(bool bInEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetInviteStatus(FFrame&, void* const)
	public virtual /*native simulated function */void SetInviteStatus(TpCreateGameParams.TpInviteStatus InStatus)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpCreateGameParams::execSetHostMigrationEnabled(FFrame&, void* const)
	public virtual /*native simulated function */void SetHostMigrationEnabled(bool bInEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}