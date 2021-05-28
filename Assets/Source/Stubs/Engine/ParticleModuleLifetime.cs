namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleLifetime : ParticleModuleLifetimeBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Lifetime)*/ DistributionFloat.RawDistributionFloat Lifetime;
	
	public ParticleModuleLifetime()
	{
		// Object Offset:0x0037D920
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleLifetime.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleLifetime.DistributionLifetime'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpawnModule = true;
	}
}
}