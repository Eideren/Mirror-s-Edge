namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Bool : SequenceVariable/*
		native
		hidecategories(Object)*/{
	[Category] public int bValue;
	
	public SeqVar_Bool()
	{
		// Object Offset:0x003DFBEF
		ObjName = "Bool";
		ObjColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
	}
}
}