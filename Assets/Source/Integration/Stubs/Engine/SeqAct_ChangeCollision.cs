namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ChangeCollision : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] [Const, editconst] public bool bCollideActors;
	[Category] [Const, editconst] public bool bBlockActors;
	[Category] [Const, editconst] public bool bIgnoreEncroachers;
	[Category] public Actor.ECollisionType CollisionType;
	
	public SeqAct_ChangeCollision()
	{
		// Object Offset:0x003BB79D
		ObjClassVersion = 5;
		ObjName = "Change Collision";
		ObjCategory = "Actor";
	}
}
}