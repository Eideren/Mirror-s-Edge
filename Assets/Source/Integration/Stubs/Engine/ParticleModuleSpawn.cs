namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSpawn : ParticleModuleSpawnBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object,ParticleModuleSpawnBase)*/{
	[Category("Spawn")] public DistributionFloat.RawDistributionFloat Rate;
	[Category("Spawn")] public DistributionFloat.RawDistributionFloat RateScale;
	[Category("Burst")] public ParticleEmitter.EParticleBurstMethod ParticleBurstMethod;
	[Category("Burst")] [noclear, export] public array</*export */ParticleEmitter.ParticleBurst> BurstList;
	
	public ParticleModuleSpawn()
	{
		var Default__ParticleModuleSpawn_RequiredDistributionSpawnRate = new DistributionFloatConstant
		{
			// Object Offset:0x00466E0F
			Constant = 20.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleSpawn.RequiredDistributionSpawnRate' */;
		var Default__ParticleModuleSpawn_RequiredDistributionSpawnRateScale = new DistributionFloatConstant
		{
			// Object Offset:0x00466E43
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleSpawn.RequiredDistributionSpawnRateScale' */;
		// Object Offset:0x003826E0
		Rate = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleSpawn_RequiredDistributionSpawnRate/*Ref DistributionFloatConstant'Default__ParticleModuleSpawn.RequiredDistributionSpawnRate'*/,
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
			Distribution = Default__ParticleModuleSpawn_RequiredDistributionSpawnRateScale/*Ref DistributionFloatConstant'Default__ParticleModuleSpawn.RequiredDistributionSpawnRateScale'*/,
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