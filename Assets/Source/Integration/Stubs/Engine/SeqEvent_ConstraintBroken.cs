namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_ConstraintBroken : SequenceEvent/*
		native
		hidecategories(Object)*/{
	public SeqEvent_ConstraintBroken()
	{
		// Object Offset:0x003DA97C
		bPlayerOnly = false;
		ObjName = "Constraint Broken";
		ObjCategory = "Physics";
	}
}
}