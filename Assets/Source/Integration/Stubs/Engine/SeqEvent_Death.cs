namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_Death : SequenceEvent/*
		hidecategories(Object)*/{
	public SeqEvent_Death()
	{
		// Object Offset:0x003DAA61
		bPlayerOnly = false;
		ObjName = "Death";
		ObjCategory = "Pawn";
	}
}
}