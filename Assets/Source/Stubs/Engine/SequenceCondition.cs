namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceCondition : SequenceOp/*
		abstract
		native
		hidecategories(Object)*/{
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject? _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SequenceCondition()
	{
		// Object Offset:0x003D4CFD
		bAutoActivateOutputLinks = false;
		ObjName = "Undefined Condition";
		ObjColor = new Color
		{
			R=0,
			G=0,
			B=255,
			A=255
		};
	}
}
}