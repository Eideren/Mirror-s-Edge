namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_AISeeEnemy : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public/*()*/ float MaxSightDistance;
	
	public SeqEvent_AISeeEnemy()
	{
		// Object Offset:0x003DA73F
		ObjName = "See Enemy";
		ObjCategory = "AI";
	}
}
}