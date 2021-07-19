namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleMeshRotationRateMultiplyLife : ParticleModuleRotationRateBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Rotation")] public DistributionVector.RawDistributionVector LifeMultiplier;
	
	public ParticleModuleMeshRotationRateMultiplyLife()
	{
		var Default__ParticleModuleMeshRotationRateMultiplyLife_DistributionLifeMultiplier = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleMeshRotationRateMultiplyLife.DistributionLifeMultiplier' */;
		// Object Offset:0x0037FC50
		LifeMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleMeshRotationRateMultiplyLife.DistributionLifeMultiplier")/*Ref DistributionVectorConstant'Default__ParticleModuleMeshRotationRateMultiplyLife.DistributionLifeMultiplier'*/,
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
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}