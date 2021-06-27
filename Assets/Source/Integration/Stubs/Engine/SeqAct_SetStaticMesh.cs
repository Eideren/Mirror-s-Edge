namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetStaticMesh : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ StaticMesh NewStaticMesh;
	
	public SeqAct_SetStaticMesh()
	{
		// Object Offset:0x003CF6B9
		ObjName = "Set StaticMesh";
		ObjCategory = "Actor";
	}
}
}