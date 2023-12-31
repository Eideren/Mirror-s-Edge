namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleColor : ParticleModuleColorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Color")] public DistributionVector.RawDistributionVector StartColor;
	[Category("Color")] public DistributionFloat.RawDistributionFloat StartAlpha;
	[Category("Color")] public bool bClampAlpha;
	
	public ParticleModuleColor()
	{
		var Default__ParticleModuleColor_DistributionStartColor = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleColor.DistributionStartColor' */;
		var Default__ParticleModuleColor_DistributionStartAlpha = new DistributionFloatConstant
		{
			// Object Offset:0x00466C47
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleColor.DistributionStartAlpha' */;
		// Object Offset:0x0037C640
		StartColor = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleColor_DistributionStartColor/*Ref DistributionVectorConstant'Default__ParticleModuleColor.DistributionStartColor'*/,
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
			Distribution = Default__ParticleModuleColor_DistributionStartAlpha/*Ref DistributionFloatConstant'Default__ParticleModuleColor.DistributionStartAlpha'*/,
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