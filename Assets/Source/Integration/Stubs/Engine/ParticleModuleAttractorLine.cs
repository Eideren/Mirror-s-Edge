namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleAttractorLine : ParticleModuleAttractorBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Attractor)*/ Object.Vector EndPoint0;
	public/*(Attractor)*/ Object.Vector EndPoint1;
	public/*(Attractor)*/ DistributionFloat.RawDistributionFloat Range;
	public/*(Attractor)*/ DistributionFloat.RawDistributionFloat Strength;
	
	public ParticleModuleAttractorLine()
	{
		var Default__ParticleModuleAttractorLine_DistributionRange = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleAttractorLine.DistributionRange' */;
		var Default__ParticleModuleAttractorLine_DistributionStrength = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleAttractorLine.DistributionStrength' */;
		// Object Offset:0x003790E7
		Range = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleAttractorLine.DistributionRange")/*Ref DistributionFloatConstant'Default__ParticleModuleAttractorLine.DistributionRange'*/,
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleAttractorLine.DistributionStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleAttractorLine.DistributionStrength'*/,
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