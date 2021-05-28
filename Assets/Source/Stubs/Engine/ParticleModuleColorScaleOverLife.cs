namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleColorScaleOverLife : ParticleModuleColorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Color)*/ DistributionVector.RawDistributionVector ColorScaleOverLife;
	public/*(Color)*/ DistributionFloat.RawDistributionFloat AlphaScaleOverLife;
	public/*(Color)*/ bool bEmitterTime;
	
	public ParticleModuleColorScaleOverLife()
	{
		// Object Offset:0x0037CECD
		ColorScaleOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleColorScaleOverLife.DistributionColorScaleOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleColorScaleOverLife.DistributionColorScaleOverLife'*/,
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
		AlphaScaleOverLife = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleColorScaleOverLife.DistributionAlphaScaleOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleColorScaleOverLife.DistributionAlphaScaleOverLife'*/,
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
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}