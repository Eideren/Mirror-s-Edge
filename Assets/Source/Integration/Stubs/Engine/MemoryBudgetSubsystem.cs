namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MemoryBudgetSubsystem : Subsystem/*
		transient
		native*/{
	public float MemoryBudgetRefreshRate;
	public float MemoryBudgetTimeSinceLastRefresh;
	
	// Export UMemoryBudgetSubsystem::execGetSubsystem(FFrame&, void* const)
	public /*native event */static MemoryBudgetSubsystem GetSubsystem()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMemoryBudgetSubsystem::execRenderAllocations(FFrame&, void* const)
	public virtual /*native function */void RenderAllocations(Canvas Canvas)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UMemoryBudgetSubsystem::execDumpAllocations(FFrame&, void* const)
	public virtual /*native function */void DumpAllocations()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UMemoryBudgetSubsystem::execDumpAudioAllocationsByType(FFrame&, void* const)
	public virtual /*native function */void DumpAudioAllocationsByType()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public MemoryBudgetSubsystem()
	{
		// Object Offset:0x0035C5AF
		MemoryBudgetTimeSinceLastRefresh = 1000.0f;
	}
}
}