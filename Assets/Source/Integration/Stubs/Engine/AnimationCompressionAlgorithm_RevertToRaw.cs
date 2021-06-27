namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimationCompressionAlgorithm_RevertToRaw : AnimationCompressionAlgorithm/*
		native
		hidecategories(Object)*/{
	public AnimationCompressionAlgorithm_RevertToRaw()
	{
		// Object Offset:0x00295878
		Description = "Revert To Raw";
		RotationCompressionFormat = AnimSequence.AnimationCompressionFormat.ACF_None;
	}
}
}