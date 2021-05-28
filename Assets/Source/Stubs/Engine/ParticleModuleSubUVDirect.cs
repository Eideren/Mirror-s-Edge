namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSubUVDirect : ParticleModuleSubUVBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(SubUV)*/ DistributionVector.RawDistributionVector SubUVPosition;
	public/*(SubUV)*/ DistributionVector.RawDistributionVector SubUVSize;
	
	public ParticleModuleSubUVDirect()
	{
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