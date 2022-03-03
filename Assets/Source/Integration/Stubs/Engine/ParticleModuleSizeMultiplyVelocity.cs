namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSizeMultiplyVelocity : ParticleModuleSizeBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Size")] public DistributionVector.RawDistributionVector VelocityMultiplier;
	[Category("Size")] public bool MultiplyX;
	[Category("Size")] public bool MultiplyY;
	[Category("Size")] public bool MultiplyZ;
	
	public ParticleModuleSizeMultiplyVelocity()
	{
		var Default__ParticleModuleSizeMultiplyVelocity_DistributionVelocityMultiplier = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleSizeMultiplyVelocity.DistributionVelocityMultiplier' */;
		// Object Offset:0x00381FD3
		VelocityMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleSizeMultiplyVelocity_DistributionVelocityMultiplier/*Ref DistributionVectorConstant'Default__ParticleModuleSizeMultiplyVelocity.DistributionVelocityMultiplier'*/,
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