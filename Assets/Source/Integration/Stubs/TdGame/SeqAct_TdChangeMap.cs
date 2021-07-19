namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdChangeMap : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public String LevelName;
	[Category] public String CheckpointName;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdChangeMap()
	{
		// Object Offset:0x00497447
		ObjName = "Change Map";
		ObjCategory = "Takedown";
	}
}
}