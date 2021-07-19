namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Float : SequenceVariable/*
		native
		hidecategories(Object)*/{
	[Category] public float FloatValue;
	
	public SeqVar_Float()
	{
		// Object Offset:0x003DFE04
		ObjName = "Float";
		ObjCategory = "Float";
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