namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Vector : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public/*()*/ Object.Vector VectValue;
	
	public SeqVar_Vector()
	{
		// Object Offset:0x003E1767
		ObjName = "Vector";
		ObjColor = new Color
		{
			R=128,
			G=128,
			B=0,
			A=255
		};
	}
}
}