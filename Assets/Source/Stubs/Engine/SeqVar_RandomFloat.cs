namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_RandomFloat : SeqVar_Float/*
		native
		hidecategories(Object)*/{
	public/*()*/ float Min;
	public/*()*/ float Max;
	
	public SeqVar_RandomFloat()
	{
		// Object Offset:0x003E10C3
		Max = 1.0f;
		ObjName = "Random Float";
	}
}
}