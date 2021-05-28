namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Named : SequenceVariable/*
		native
		hidecategories(Object,SequenceVariable)*/{
	public Core.ClassT<SequenceVariable> ExpectedType;
	public/*()*/ name FindVarName;
	public /*transient */bool bStatusIsOk;
	
	public SeqVar_Named()
	{
		// Object Offset:0x003E08D0
		ObjName = "Named Variable";
	}
}
}