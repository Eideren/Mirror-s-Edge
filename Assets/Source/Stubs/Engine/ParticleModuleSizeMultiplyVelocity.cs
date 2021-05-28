namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSizeMultiplyVelocity : ParticleModuleSizeBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Size)*/ DistributionVector.RawDistributionVector VelocityMultiplier;
	public/*(Size)*/ bool MultiplyX;
	public/*(Size)*/ bool MultiplyY;
	public/*(Size)*/ bool MultiplyZ;
	
	public ParticleModuleSizeMultiplyVelocity()
	{
		// Object Offset:0x00381FD3
		VelocityMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleSizeMultiplyVelocity.DistributionVelocityMultiplier")/*Ref DistributionVectorConstant'Default__ParticleModuleSizeMultiplyVelocity.DistributionVelocityMultiplier'*/,
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