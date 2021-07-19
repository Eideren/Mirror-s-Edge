namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleAttractorParticle : ParticleModuleAttractorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum EAttractorParticleSelectionMethod 
	{
		EAPSM_Random,
		EAPSM_Sequential,
		EAPSM_MAX
	};
	
	[Category("Attractor")] [noclear, export] public name EmitterName;
	[Category("Attractor")] public DistributionFloat.RawDistributionFloat Range;
	[Category("Attractor")] public bool bStrengthByDistance;
	[Category("Attractor")] public bool bAffectBaseVelocity;
	[Category("Attractor")] public bool bRenewSource;
	[Category("Attractor")] public bool bInheritSourceVel;
	[Category("Attractor")] public DistributionFloat.RawDistributionFloat Strength;
	[Category("Location")] public ParticleModuleAttractorParticle.EAttractorParticleSelectionMethod SelectionMethod;
	public int LastSelIndex;
	
	public ParticleModuleAttractorParticle()
	{
		var Default__ParticleModuleAttractorParticle_DistributionRange = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleAttractorParticle.DistributionRange' */;
		var Default__ParticleModuleAttractorParticle_DistributionStrength = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleAttractorParticle.DistributionStrength' */;
		// Object Offset:0x0037959E
		Range = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleAttractorParticle.DistributionRange")/*Ref DistributionFloatConstant'Default__ParticleModuleAttractorParticle.DistributionRange'*/,
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
		bStrengthByDistance = true;
		Strength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleAttractorParticle.DistributionStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleAttractorParticle.DistributionStrength'*/,
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