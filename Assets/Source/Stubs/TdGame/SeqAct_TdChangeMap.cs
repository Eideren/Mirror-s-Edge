namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdChangeMap : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ string LevelName;
	public/*()*/ string CheckpointName;
	
	public override /*event */void Activated()
	{
	
	}
	
	public SeqAct_TdChangeMap()
	{
		// Object Offset:0x00497447
		ObjName = "Change Map";
		ObjCategory = "Takedown";
	}
}
}