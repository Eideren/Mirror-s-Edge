namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSizeScale : ParticleModuleSizeBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*()*/ DistributionVector.RawDistributionVector SizeScale;
	public/*()*/ bool EnableX;
	public/*()*/ bool EnableY;
	public/*()*/ bool EnableZ;
	
	public ParticleModuleSizeScale()
	{
		// Object Offset:0x003822C2
		SizeScale = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleSizeScale.DistributionSizeScale")/*Ref DistributionVectorConstant'Default__ParticleModuleSizeScale.DistributionSizeScale'*/,
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
		EnableX = true;
		EnableY = true;
		EnableZ = true;
		bUpdateModule = true;
	}
}
}