namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleAttractorPoint : ParticleModuleAttractorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Attractor)*/ DistributionVector.RawDistributionVector Position;
	public/*(Attractor)*/ DistributionFloat.RawDistributionFloat Range;
	public/*(Attractor)*/ DistributionFloat.RawDistributionFloat Strength;
	public/*(Attractor)*/ bool StrengthByDistance;
	public/*(Attractor)*/ bool bAffectBaseVelocity;
	public/*(Attractor)*/ bool bOverrideVelocity;
	
	public ParticleModuleAttractorPoint()
	{
		// Object Offset:0x003799BD
		Position = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleAttractorPoint.DistributionPosition")/*Ref DistributionVectorConstant'Default__ParticleModuleAttractorPoint.DistributionPosition'*/,
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
		Range = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleAttractorPoint.DistributionRange")/*Ref DistributionFloatConstant'Default__ParticleModuleAttractorPoint.DistributionRange'*/,
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
		Strength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleAttractorPoint.DistributionStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleAttractorPoint.DistributionStrength'*/,
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
		StrengthByDistance = true;
		bUpdateModule = true;
		bSupported3DDrawMode = true;
	}
}
}