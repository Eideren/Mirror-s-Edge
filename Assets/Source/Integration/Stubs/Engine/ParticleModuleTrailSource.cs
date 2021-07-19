namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTrailSource : ParticleModuleTrailBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum ETrail2SourceMethod 
	{
		PET2SRCM_Default,
		PET2SRCM_Particle,
		PET2SRCM_Actor,
		PET2SRCM_MAX
	};
	
	[Category("Source")] public ParticleModuleTrailSource.ETrail2SourceMethod SourceMethod;
	[Category("Source")] public ParticleModule.EParticleSourceSelectionMethod SelectionMethod;
	[Category("Source")] public name SourceName;
	[Category("Source")] public DistributionFloat.RawDistributionFloat SourceStrength;
	[Category("Source")] public bool bLockSourceStength;
	[Category("Source")] public bool bInheritRotation;
	[Category("Source")] public int SourceOffsetCount;
	[Category("Source")] [editfixedsize] public array<Object.Vector> SourceOffsetDefaults;
	
	public ParticleModuleTrailSource()
	{
		var Default__ParticleModuleTrailSource_DistributionSourceStrength = new DistributionFloatConstant
		{
			// Object Offset:0x00466EA7
			Constant = 100.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleTrailSource.DistributionSourceStrength' */;
		// Object Offset:0x0038368D
		SelectionMethod = ParticleModule.EParticleSourceSelectionMethod.EPSSM_Sequential;
		SourceStrength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleTrailSource.DistributionSourceStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleTrailSource.DistributionSourceStrength'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				100.0f,
				100.0f,
				100.0f,
				100.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}