namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvt_TdCheckpointLoaded : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public SeqEvt_TdCheckpointLoaded()
	{
		// Object Offset:0x004A7A64
		bPlayerOnly = false;
		ObjName = "TdCheckpointLoaded";
		ObjCategory = "Takedown";
	}
}
}