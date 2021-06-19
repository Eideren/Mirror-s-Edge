namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRotationRateMultiplyLife : ParticleModuleRotationRateBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Rotation)*/ DistributionFloat.RawDistributionFloat LifeMultiplier;
	
	public ParticleModuleRotationRateMultiplyLife()
	{
		var Default__ParticleModuleRotationRateMultiplyLife_DistributionLifeMultiplier = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleRotationRateMultiplyLife.DistributionLifeMultiplier' */;
		// Object Offset:0x003817C7
		LifeMultiplier = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleRotationRateMultiplyLife.DistributionLifeMultiplier")/*Ref DistributionFloatConstant'Default__ParticleModuleRotationRateMultiplyLife.DistributionLifeMultiplier'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
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