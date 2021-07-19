namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_RandomInt : SeqVar_Int/*
		native
		hidecategories(Object)*/{
	[Category] public int Min;
	[Category] public int Max;
	
	public SeqVar_RandomInt()
	{
		// Object Offset:0x003E11D7
		Max = 100;
		ObjName = "Random Int";
	}
}
}