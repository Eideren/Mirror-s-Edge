namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetMaterial : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public MaterialInterface NewMaterial;
	[Category] public int MaterialIndex;
	
	public SeqAct_SetMaterial()
	{
		// Object Offset:0x003CDA9F
		ObjName = "Set Material";
		ObjCategory = "Actor";
	}
}
}