namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleKillHeight : ParticleModuleKillBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Kill")] public DistributionFloat.RawDistributionFloat Height;
	[Category("Kill")] public bool bAbsolute;
	[Category("Kill")] public bool bFloor;
	
	public ParticleModuleKillHeight()
	{
		var Default__ParticleModuleKillHeight_DistributionHeight = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleKillHeight.DistributionHeight' */;
		// Object Offset:0x0037D69A
		Height = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleKillHeight.DistributionHeight")/*Ref DistributionFloatConstant'Default__ParticleModuleKillHeight.DistributionHeight'*/,
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
		bUpdateModule = true;
		bSupported3DDrawMode = true;
	}
}
}