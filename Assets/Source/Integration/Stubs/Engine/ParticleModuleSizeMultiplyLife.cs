namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSizeMultiplyLife : ParticleModuleSizeBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Size")] public DistributionVector.RawDistributionVector LifeMultiplier;
	[Category("Size")] public bool MultiplyX;
	[Category("Size")] public bool MultiplyY;
	[Category("Size")] public bool MultiplyZ;
	
	public ParticleModuleSizeMultiplyLife()
	{
		var Default__ParticleModuleSizeMultiplyLife_DistributionLifeMultiplier = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleSizeMultiplyLife.DistributionLifeMultiplier' */;
		// Object Offset:0x00381CE4
		LifeMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleSizeMultiplyLife_DistributionLifeMultiplier/*Ref DistributionVectorConstant'Default__ParticleModuleSizeMultiplyLife.DistributionLifeMultiplier'*/,
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
		MultiplyX = true;
		MultiplyY = true;
		MultiplyZ = true;
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}