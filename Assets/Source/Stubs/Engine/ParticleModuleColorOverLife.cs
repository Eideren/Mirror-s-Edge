namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleColorOverLife : ParticleModuleColorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Color)*/ DistributionVector.RawDistributionVector ColorOverLife;
	public/*(Color)*/ DistributionFloat.RawDistributionFloat AlphaOverLife;
	public/*(Color)*/ bool bClampAlpha;
	
	public ParticleModuleColorOverLife()
	{
		// Object Offset:0x0037CB0A
		ColorOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleColorOverLife.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleColorOverLife.DistributionColorOverLife'*/,
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
		AlphaOverLife = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleColorOverLife.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleColorOverLife.DistributionAlphaOverLife'*/,
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
		bUpdateModule = true;
		bCurvesAsColor = true;
	}
}
}