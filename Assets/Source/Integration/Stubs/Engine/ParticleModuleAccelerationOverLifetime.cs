namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleAccelerationOverLifetime : ParticleModuleAccelerationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Acceleration")] public DistributionVector.RawDistributionVector AccelOverLife;
	
	public ParticleModuleAccelerationOverLifetime()
	{
		var Default__ParticleModuleAccelerationOverLifetime_DistributionAccelOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleAccelerationOverLifetime.DistributionAccelOverLife' */;
		// Object Offset:0x00378DDD
		AccelOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleAccelerationOverLifetime_DistributionAccelOverLife/*Ref DistributionVectorConstantCurve'Default__ParticleModuleAccelerationOverLifetime.DistributionAccelOverLife'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
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
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bUpdateModule = true;
	}
}
}