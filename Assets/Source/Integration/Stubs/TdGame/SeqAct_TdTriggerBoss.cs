namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdTriggerBoss : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ int BossFightIndex;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public SeqAct_TdTriggerBoss()
	{
		// Object Offset:0x004A23BE
		ObjName = "Trigger Boss Fight";
		ObjCategory = "Takedown";
	}
}
}