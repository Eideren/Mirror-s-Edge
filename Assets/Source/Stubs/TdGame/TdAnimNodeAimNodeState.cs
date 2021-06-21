namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeAimNodeState : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ /*editoronly transient */array<TdAIAnimationController.EAimState> EnumStates;
	
	// Export UTdAnimNodeAimNodeState::execGetActiveState(FFrame&, void* const)
	public override /*native function */int GetActiveState()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdAnimNodeAimNodeState::execGetBlendValue(FFrame&, void* const)
	public override /*native function */float GetBlendValue(int PreviousState, int PendingState)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*event */void OnInit()
	{
		// stub
	}
	
	public override /*event */void OverrideStateMapping()
	{
		// stub
	}
	
	public TdAnimNodeAimNodeState()
	{
		// Object Offset:0x004FC776
		EnumStringName = "EAimState";
		bUseCustomBlend = true;
	}
}
}