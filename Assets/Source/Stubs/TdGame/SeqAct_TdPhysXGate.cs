namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdPhysXGate : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ bool bPhysXNotGate;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
		return default;
	}
	
	public SeqAct_TdPhysXGate()
	{
		// Object Offset:0x0049DD71
		bAutoActivateOutputLinks = false;
		VariableLinks = default;
		ObjName = "PhysX Gate";
		ObjCategory = "Physics";
	}
}
}