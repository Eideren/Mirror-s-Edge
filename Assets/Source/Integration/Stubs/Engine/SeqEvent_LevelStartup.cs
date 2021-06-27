namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_LevelStartup : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public SeqEvent_LevelStartup()
	{
		// Object Offset:0x003DB0D4
		bPlayerOnly = false;
		VariableLinks = default;
		ObjName = "Level Startup";
	}
}
}