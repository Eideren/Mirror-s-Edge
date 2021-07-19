namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimationCompressionAlgorithm_RemoveTrivialKeys : AnimationCompressionAlgorithm/*
		native
		hidecategories(Object)*/{
	[Category] public float MaxPosDiff;
	[Category] public float MaxAngleDiff;
	
	public AnimationCompressionAlgorithm_RemoveTrivialKeys()
	{
		// Object Offset:0x00295799
		MaxPosDiff = 0.00010f;
		MaxAngleDiff = 0.00030f;
		Description = "Remove Trivial Keys";
	}
}
}