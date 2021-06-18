namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTrailTaper : ParticleModuleTrailBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public enum ETrailTaperMethod 
	{
		PETTM_None,
		PETTM_Full,
		PETTM_Partial,
		PETTM_MAX
	};
	
	public/*(Taper)*/ ParticleModuleTrailTaper.ETrailTaperMethod TaperMethod;
	public/*(Taper)*/ DistributionFloat.RawDistributionFloat TaperFactor;
	
	public ParticleModuleTrailTaper()
	{
		var Default__ParticleModuleTrailTaper_DistributionTaperFactor = new DistributionFloatConstant
		{
			// Object Offset:0x00466EDB
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTrailTaper.DistributionTaperFactor' */;
		// Object Offset:0x00383A27
		TaperFactor = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTrailTaper.DistributionTaperFactor")/*Ref DistributionFloatConstant'Default__ParticleModuleTrailTaper.DistributionTaperFactor'*/,
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
	}
}
}