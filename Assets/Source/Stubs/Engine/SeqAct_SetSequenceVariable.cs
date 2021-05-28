namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetSequenceVariable : SequenceAction/*
		abstract
		native
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject TargetObject = default)
	{
	
		return default;
	}
	
	public SeqAct_SetSequenceVariable()
	{
		// Object Offset:0x003B7142
		ObjName = "Set Variable";
		ObjCategory = "Set Variable";
	}
}
}