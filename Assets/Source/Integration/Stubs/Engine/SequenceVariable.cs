namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceVariable : SequenceObject/*
		abstract
		native
		hidecategories(Object)*/{
	public/*()*/ name VarName;
	
	public override /*event */bool IsValidUISequenceObject(/*optional */UIScreenObject _TargetObject = default)
	{
		// stub
		return default;
	}
	
	public SequenceVariable()
	{
		// Object Offset:0x003406A7
		ObjName = "Undefined Variable";
		ObjColor = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		bDrawLast = true;
	}
}
}