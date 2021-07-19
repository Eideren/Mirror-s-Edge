namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdLevelCompleted : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public String NextLevelName;
	[Category] public String NextCheckpointName;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdLevelCompleted()
	{
		// Object Offset:0x0049D3C6
		ObjName = "Complete A Level";
		ObjCategory = "Takedown";
	}
}
}