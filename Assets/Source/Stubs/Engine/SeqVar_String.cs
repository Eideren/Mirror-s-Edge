namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_String : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public/*()*/ string StrValue;
	
	public SeqVar_String()
	{
		// Object Offset:0x003E12BD
		ObjName = "String";
		ObjColor = new Color
		{
			R=0,
			G=255,
			B=0,
			A=255
		};
	}
}
}