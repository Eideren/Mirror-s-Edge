namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdTutorialCheckpointCompleted : SequenceEvent/*
		hidecategories(Object)*/{
	public SeqEvt_TdTutorialCheckpointCompleted()
	{
		// Object Offset:0x004A8558
		MaxTriggerCount = 0;
		bPlayerOnly = false;
		ObjName = "Completed";
		ObjCategory = "Tutorial";
	}
}
}