namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeMovementState : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	[Category] public bool bUseOldState;
	[Category] [editoronly, transient] public array<TdPawn.EMovement> EnumStates;
	
	// Export UTdAnimNodeMovementState::execGetActiveState(FFrame&, void* const)
	public override /*native function */int GetActiveState()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdAnimNodeMovementState::execGetBlendValue(FFrame&, void* const)
	public override /*native function */float GetBlendValue(int PreviousState, int NewState)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*event */void OnInit()
	{
		/*local */int ArrayItem = default;
	
		EnumStates.Remove(0, EnumStates.Length);
		using var v = StateMapping.GetEnumerator();while(v.MoveNext() && (ArrayItem = (int)v.Current) == ArrayItem)
		{
			EnumStates.AddItem(((TdPawn.EMovement)(byte)(ArrayItem)));		
		}	
		base.OnInit();
	}
	
	public override /*event */void OverrideStateMapping()
	{
		/*local */int ArrayItem = default;
	
		StateMapping.Remove(0, StateMapping.Length);
		using var v = EnumStates.GetEnumerator();while(v.MoveNext() && (ArrayItem = (int)v.Current) == ArrayItem)
		{
			StateMapping.AddItem(ArrayItem);		
		}	
	}
	
	public TdAnimNodeMovementState()
	{
		// Object Offset:0x00505585
		EnumStringName = "EMovement";
		bUseCustomBlend = true;
	}
}
}