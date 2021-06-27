namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSubUV : ParticleModuleSubUVBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(SubUV)*/ DistributionFloat.RawDistributionFloat SubImageIndex;
	
	public ParticleModuleSubUV()
	{
		var Default__ParticleModuleSubUV_DistributionSubImage = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleSubUV.DistributionSubImage' */;
		// Object Offset:0x00382D11
		SubImageIndex = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleSubUV.DistributionSubImage")/*Ref DistributionFloatConstant'Default__ParticleModuleSubUV.DistributionSubImage'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}