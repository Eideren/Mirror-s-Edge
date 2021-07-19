namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_AssignController : SequenceAction/*
		hidecategories(Object)*/{
	[Category] public Core.ClassT<Controller> ControllerClass;
	
	public SeqAct_AssignController()
	{
		// Object Offset:0x003B89E5
		ObjName = "Assign Controller";
		ObjCategory = "Actor";
	}
}
}