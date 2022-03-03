namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleColorOverLife : ParticleModuleColorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Color")] public DistributionVector.RawDistributionVector ColorOverLife;
	[Category("Color")] public DistributionFloat.RawDistributionFloat AlphaOverLife;
	[Category("Color")] public bool bClampAlpha;
	
	public ParticleModuleColorOverLife()
	{
		var Default__ParticleModuleColorOverLife_DistributionColorOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleColorOverLife.DistributionColorOverLife' */;
		var Default__ParticleModuleColorOverLife_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x00466C7B
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleColorOverLife.DistributionAlphaOverLife' */;
		// Object Offset:0x0037CB0A
		ColorOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleColorOverLife_DistributionColorOverLife/*Ref DistributionVectorConstantCurve'Default__ParticleModuleColorOverLife.DistributionColorOverLife'*/,
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
			Distribution = Default__ParticleModuleColorOverLife_DistributionAlphaOverLife/*Ref DistributionFloatConstant'Default__ParticleModuleColorOverLife.DistributionAlphaOverLife'*/,
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