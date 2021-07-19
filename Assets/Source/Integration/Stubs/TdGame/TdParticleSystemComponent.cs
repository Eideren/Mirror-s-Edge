namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdParticleSystemComponent : ParticleSystemComponent/*
		native
		editinlinenew
		hidecategories(Object,Physics,Collision)*/{
	[Category] public float BoundingBoxSideLength;
	
	public TdParticleSystemComponent()
	{
		// Object Offset:0x00541A08
		BoundingBoxSideLength = 100.0f;
		bForceOcclusionTest = true;
	}
}
}