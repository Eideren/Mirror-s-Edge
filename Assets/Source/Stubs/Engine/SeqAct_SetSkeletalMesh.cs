namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetSkeletalMesh : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ SkeletalMesh NewSkeletalMesh;
	
	public SeqAct_SetSkeletalMesh()
	{
		// Object Offset:0x003CF5C3
		ObjName = "Set SkeletalMesh";
		ObjCategory = "Actor";
	}
}
}