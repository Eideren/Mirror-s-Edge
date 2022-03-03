namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleAcceleration : ParticleModuleAccelerationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Acceleration")] public DistributionVector.RawDistributionVector Acceleration;
	
	public ParticleModuleAcceleration()
	{
		var Default__ParticleModuleAcceleration_DistributionAcceleration = new DistributionVectorUniform
		{
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleAcceleration.DistributionAcceleration' */;
		// Object Offset:0x00378BAE
		Acceleration = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleAcceleration_DistributionAcceleration/*Ref DistributionVectorUniform'Default__ParticleModuleAcceleration.DistributionAcceleration'*/,
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
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}