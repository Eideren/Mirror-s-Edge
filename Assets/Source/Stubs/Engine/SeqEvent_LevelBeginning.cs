namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_LevelBeginning : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public SeqEvent_LevelBeginning()
	{
		// Object Offset:0x003DAE3E
		bPlayerOnly = false;
		VariableLinks = default;
		ObjName = "Level Beginning";
	}
}
}