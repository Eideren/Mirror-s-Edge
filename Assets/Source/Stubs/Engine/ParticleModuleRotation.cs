namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRotation : ParticleModuleRotationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Rotation)*/ DistributionFloat.RawDistributionFloat StartRotation;
	
	public ParticleModuleRotation()
	{
		// Object Offset:0x003811B6
		StartRotation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleRotation.DistributionStartRotation")/*Ref DistributionFloatUniform'Default__ParticleModuleRotation.DistributionStartRotation'*/,
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