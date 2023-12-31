namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRotation : ParticleModuleRotationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Rotation")] public DistributionFloat.RawDistributionFloat StartRotation;
	
	public ParticleModuleRotation()
	{
		var Default__ParticleModuleRotation_DistributionStartRotation = new DistributionFloatUniform
		{
			// Object Offset:0x0046760B
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleRotation.DistributionStartRotation' */;
		// Object Offset:0x003811B6
		StartRotation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleRotation_DistributionStartRotation/*Ref DistributionFloatUniform'Default__ParticleModuleRotation.DistributionStartRotation'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				0.0f,
				1.0f,
				0.0f,
				1.0f,
				0.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpawnModule = true;
	}
}
}