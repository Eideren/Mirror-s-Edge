namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_SequenceActivated : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public/*()*/ string InputLabel;
	
	public SeqEvent_SequenceActivated()
	{
		// Object Offset:0x003DD82E
		InputLabel = "Default Input";
		MaxTriggerCount = 0;
		bPlayerOnly = false;
		ObjName = "Sequence Activated";
	}
}
}