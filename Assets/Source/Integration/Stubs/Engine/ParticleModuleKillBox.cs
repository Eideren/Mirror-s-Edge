namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleKillBox : ParticleModuleKillBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Kill")] public DistributionVector.RawDistributionVector LowerLeftCorner;
	[Category("Kill")] public DistributionVector.RawDistributionVector UpperRightCorner;
	[Category("Kill")] public bool bAbsolute;
	[Category("Kill")] public bool bKillInside;
	
	public ParticleModuleKillBox()
	{
		var Default__ParticleModuleKillBox_DistributionLowerLeftCorner = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleKillBox.DistributionLowerLeftCorner' */;
		var Default__ParticleModuleKillBox_DistributionUpperRightCorner = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleKillBox.DistributionUpperRightCorner' */;
		// Object Offset:0x0037D303
		LowerLeftCorner = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleKillBox.DistributionLowerLeftCorner")/*Ref DistributionVectorConstant'Default__ParticleModuleKillBox.DistributionLowerLeftCorner'*/,
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
		UpperRightCorner = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleKillBox.DistributionUpperRightCorner")/*Ref DistributionVectorConstant'Default__ParticleModuleKillBox.DistributionUpperRightCorner'*/,
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
		bUpdateModule = true;
		bSupported3DDrawMode = true;
	}
}
}