namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimationCompressionAlgorithm_RemoveEverySecondKey : AnimationCompressionAlgorithm/*
		native
		hidecategories(Object)*/{
	[Category] public int MinKeys;
	[Category] public bool bStartAtSecondKey;
	
	public AnimationCompressionAlgorithm_RemoveEverySecondKey()
	{
		// Object Offset:0x0029567A
		MinKeys = 10;
		Description = "Remove Every Second Key";
	}
}
}