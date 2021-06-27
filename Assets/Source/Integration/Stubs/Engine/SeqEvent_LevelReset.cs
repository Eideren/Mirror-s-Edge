namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_LevelReset : SequenceEvent/*
		hidecategories(Object)*/{
	public SeqEvent_LevelReset()
	{
		// Object Offset:0x003DAFFD
		bPlayerOnly = false;
		VariableLinks = default;
		ObjName = "Level Reset";
	}
}
}