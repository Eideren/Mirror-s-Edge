namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetPhysics : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ Actor.EPhysics newPhysics;
	
	public SeqAct_SetPhysics()
	{
		// Object Offset:0x003CF200
		ObjName = "Set Physics";
		ObjCategory = "Physics";
	}
}
}