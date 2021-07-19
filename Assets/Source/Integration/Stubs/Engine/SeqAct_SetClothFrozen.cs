namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetClothFrozen : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public bool ParamValue;
	
	public SeqAct_SetClothFrozen()
	{
		// Object Offset:0x003CC779
		ObjName = "Set Cloth Frozen";
		ObjCategory = "Physics";
	}
}
}