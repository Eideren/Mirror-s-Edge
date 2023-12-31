namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSubUVDirect : ParticleModuleSubUVBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("SubUV")] public DistributionVector.RawDistributionVector SubUVPosition;
	[Category("SubUV")] public DistributionVector.RawDistributionVector SubUVSize;
	
	public ParticleModuleSubUVDirect()
	{
		var Default__ParticleModuleSubUVDirect_DistributionSubImagePosition = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleSubUVDirect.DistributionSubImagePosition' */;
		var Default__ParticleModuleSubUVDirect_DistributionSubImageSize = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleSubUVDirect.DistributionSubImageSize' */;
		// Object Offset:0x00382F48
		SubUVPosition = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleSubUVDirect.DistributionSubImagePosition")/*Ref DistributionVectorConstant'Default__ParticleModuleSubUVDirect.DistributionSubImagePosition'*/,
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
		SubUVSize = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleSubUVDirect.DistributionSubImageSize")/*Ref DistributionVectorConstant'Default__ParticleModuleSubUVDirect.DistributionSubImageSize'*/,
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
	}
}
}