namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_MakeNoise : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public float Loudness;
	
	public SeqAct_MakeNoise()
	{
		// Object Offset:0x003C792C
		Loudness = 1.0f;
		ObjClassVersion = 2;
		ObjName = "MakeNoise";
		ObjCategory = "AI";
	}
}
}