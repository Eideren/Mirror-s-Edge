namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ConsoleCommand : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ string Command;
	
	public SeqAct_ConsoleCommand()
	{
		// Object Offset:0x003BBA99
		ObjName = "Console Command";
		ObjCategory = "Misc";
	}
}
}