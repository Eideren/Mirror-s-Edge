namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeAgainstWallState : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ /*editoronly transient */array<TdPawn.EAgainstWallState> EnumStates;
	
	// Export UTdAnimNodeAgainstWallState::execGetBlendValue(FFrame&, void* const)
	public override /*native function */float GetBlendValue(int PreviousState, int NewState)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void OnInit()
	{
		/*local */int ArrayItem = default;
	
		EnumStates.Remove(0, EnumStates.Length);
		using var v = StateMapping.GetEnumerator();while(v.MoveNext() && (ArrayItem = (int)v.Current) == ArrayItem)
		{
			EnumStates.AddItem(((TdPawn.EAgainstWallState)(byte)(ArrayItem)));		
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
	
	public TdAnimNodeAgainstWallState()
	{
		// Object Offset:0x004FC15C
		EnumStringName = "EAgainstWallState";
		bUseCustomBlend = true;
	}
}
}