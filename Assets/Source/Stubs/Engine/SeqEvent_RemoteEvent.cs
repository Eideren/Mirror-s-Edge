namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_RemoteEvent : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public/*()*/ name EventName;
	public /*transient */bool bStatusIsOk;
	
	public SeqEvent_RemoteEvent()
	{
		// Object Offset:0x003DCD29
		EventName = (name)"DefaultEvent";
		bPlayerOnly = false;
		ObjName = "Remote Event";
	}
}
}