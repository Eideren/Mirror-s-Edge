namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimationCompressionAlgorithm : Object/*
		abstract
		native
		hidecategories(Object)*/{
	public String Description;
	public bool bNeedsSkeleton;
	public AnimSequence.AnimationCompressionFormat TranslationCompressionFormat;
	public/*()*/ AnimSequence.AnimationCompressionFormat RotationCompressionFormat;
	
	public AnimationCompressionAlgorithm()
	{
		// Object Offset:0x002954C1
		Description = "None";
		RotationCompressionFormat = AnimSequence.AnimationCompressionFormat.ACF_Fixed48NoW;
	}
}
}