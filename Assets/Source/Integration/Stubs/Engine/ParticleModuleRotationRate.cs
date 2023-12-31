namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRotationRate : ParticleModuleRotationRateBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Rotation")] public DistributionFloat.RawDistributionFloat StartRotationRate;
	
	public ParticleModuleRotationRate()
	{
		var Default__ParticleModuleRotationRate_DistributionStartRotationRate = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleRotationRate.DistributionStartRotationRate' */;
		// Object Offset:0x003815DC
		StartRotationRate = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleRotationRate_DistributionStartRotationRate/*Ref DistributionFloatConstant'Default__ParticleModuleRotationRate.DistributionStartRotationRate'*/,
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
	}
}
}