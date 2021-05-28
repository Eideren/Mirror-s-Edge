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
	
	public/*(Attractor)*/ /*noclear export */name EmitterName;
	public/*(Attractor)*/ DistributionFloat.RawDistributionFloat Range;
	public/*(Attractor)*/ bool bStrengthByDistance;
	public/*(Attractor)*/ bool bAffectBaseVelocity;
	public/*(Attractor)*/ bool bRenewSource;
	public/*(Attractor)*/ bool bInheritSourceVel;
	public/*(Attractor)*/ DistributionFloat.RawDistributionFloat Strength;
	public/*(Location)*/ ParticleModuleAttractorParticle.EAttractorParticleSelectionMethod SelectionMethod;
	public int LastSelIndex;
	
	public ParticleModuleAttractorParticle()
	{
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