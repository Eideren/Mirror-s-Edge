namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSpawn : ParticleModuleSpawnBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object,ParticleModuleSpawnBase)*/{
	public/*(Spawn)*/ DistributionFloat.RawDistributionFloat Rate;
	public/*(Spawn)*/ DistributionFloat.RawDistributionFloat RateScale;
	public/*(Burst)*/ ParticleEmitter.EParticleBurstMethod ParticleBurstMethod;
	public/*(Burst)*/ /*noclear export */array</*export */ParticleEmitter.ParticleBurst> BurstList;
	
	public ParticleModuleSpawn()
	{
		// Object Offset:0x003826E0
		Rate = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleSpawn.RequiredDistributionSpawnRate")/*Ref DistributionFloatConstant'Default__ParticleModuleSpawn.RequiredDistributionSpawnRate'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				20.0f,
				20.0f,
				20.0f,
				20.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		RateScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleSpawn.RequiredDistributionSpawnRateScale")/*Ref DistributionFloatConstant'Default__ParticleModuleSpawn.RequiredDistributionSpawnRateScale'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		LODDuplicate = false;
	}
}
}