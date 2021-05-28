namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleKillBox : ParticleModuleKillBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Kill)*/ DistributionVector.RawDistributionVector LowerLeftCorner;
	public/*(Kill)*/ DistributionVector.RawDistributionVector UpperRightCorner;
	public/*(Kill)*/ bool bAbsolute;
	public/*(Kill)*/ bool bKillInside;
	
	public ParticleModuleKillBox()
	{
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