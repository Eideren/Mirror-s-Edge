namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpSystemHandler : Object/*
		abstract
		transient
		native*/{
	public /*protected transient */TpSystemBase SystemBase;
	
	// Export UTpSystemHandler::execInitializeNative(FFrame&, void* const)
	public virtual /*private native final simulated function */void InitializeNative()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpSystemHandler::execFinalizeNative(FFrame&, void* const)
	public virtual /*private native final simulated function */void FinalizeNative()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	public virtual /*final simulated function */void Finalize()
	{
		// stub
	}
	
}
}