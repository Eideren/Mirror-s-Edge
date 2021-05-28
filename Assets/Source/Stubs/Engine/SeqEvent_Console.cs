namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_Console : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public/*()*/ name ConsoleEventName;
	public/*()*/ string EventDesc;
	
	public SeqEvent_Console()
	{
		// Object Offset:0x003DA853
		ConsoleEventName = (name)"Default";
		EventDesc = "No description";
		MaxTriggerCount = 0;
		ObjName = "Console Event";
		ObjCategory = "Misc";
	}
}
}