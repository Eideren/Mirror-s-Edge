namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSubUVSelect : ParticleModuleSubUVBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(SubUV)*/ DistributionVector.RawDistributionVector SubImageSelect;
	
	public ParticleModuleSubUVSelect()
	{
		// Object Offset:0x0038326B
		SubImageSelect = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleSubUVSelect.DistributionSubImageSelect")/*Ref DistributionVectorConstant'Default__ParticleModuleSubUVSelect.DistributionSubImageSelect'*/,
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