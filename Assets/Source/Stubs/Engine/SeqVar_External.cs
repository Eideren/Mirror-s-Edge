namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_External : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public Core.ClassT<SequenceVariable> ExpectedType;
	public/*()*/ string VariableLabel;
	
	public SeqVar_External()
	{
		// Object Offset:0x003DFD0B
		VariableLabel = "Default Var";
		ObjName = "External Variable";
	}
}
}