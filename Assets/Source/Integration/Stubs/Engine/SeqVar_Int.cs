namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Int : SequenceVariable/*
		native
		hidecategories(Object)*/{
	[Category] public int IntValue;
	
	public SeqVar_Int()
	{
		// Object Offset:0x003E02FE
		ObjName = "Int";
		ObjCategory = "Int";
		ObjColor = new Color
		{
			R=0,
			G=255,
			B=255,
			A=255
		};
	}
}
}