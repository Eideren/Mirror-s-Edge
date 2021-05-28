namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleVelocity : ParticleModuleVelocityBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Velocity)*/ DistributionVector.RawDistributionVector StartVelocity;
	public/*(Velocity)*/ DistributionFloat.RawDistributionFloat StartVelocityRadial;
	
	public ParticleModuleVelocity()
	{
		// Object Offset:0x0038AE8D
		StartVelocity = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleVelocity.DistributionStartVelocity")/*Ref DistributionVectorUniform'Default__ParticleModuleVelocity.DistributionStartVelocity'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
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
		StartVelocityRadial = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleVelocity.DistributionStartVelocityRadial")/*Ref DistributionFloatUniform'Default__ParticleModuleVelocity.DistributionStartVelocityRadial'*/,
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