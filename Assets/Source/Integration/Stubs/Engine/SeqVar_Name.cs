namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_Name : SequenceVariable/*
		native
		hidecategories(Object)*/{
	public/*()*/ name NameValue;
	
	public SeqVar_Name()
	{
		// Object Offset:0x003E0788
		ObjName = "Name";
		ObjColor = new Color
		{
			R=128,
			G=255,
			B=255,
			A=255
		};
	}
}
}