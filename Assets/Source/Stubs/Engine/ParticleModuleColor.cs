namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleColor : ParticleModuleColorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Color)*/ DistributionVector.RawDistributionVector StartColor;
	public/*(Color)*/ DistributionFloat.RawDistributionFloat StartAlpha;
	public/*(Color)*/ bool bClampAlpha;
	
	public ParticleModuleColor()
	{
		// Object Offset:0x0037C640
		StartColor = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleColor.DistributionStartColor")/*Ref DistributionVectorConstant'Default__ParticleModuleColor.DistributionStartColor'*/,
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
		StartAlpha = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleColor.DistributionStartAlpha")/*Ref DistributionFloatConstant'Default__ParticleModuleColor.DistributionStartAlpha'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bClampAlpha = true;
		bSpawnModule = true;
		bCurvesAsColor = true;
	}
}
}