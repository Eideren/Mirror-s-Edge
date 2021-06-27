namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdEmitterPool : EmitterPool/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public TdEmitterPool()
	{
		var Default__TdEmitterPool_ParticleSystemComponent0 = new ParticleSystemComponent
		{
		}/* Reference: ParticleSystemComponent'Default__TdEmitterPool.ParticleSystemComponent0' */;
		// Object Offset:0x005443CF
		PSCTemplate = Default__TdEmitterPool_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__TdEmitterPool.ParticleSystemComponent0'*/;
		MaxActiveEffects = 20;
		SMC_MIC_ReductionTime = 2.0f;
		IdealStaticMeshComponents = 200;
		IdealMaterialInstanceConstants = 200;
	}
}
}