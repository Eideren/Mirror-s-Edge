namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberRainSplashA : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public/*(Lifetime)*/ DistributionFloat.RawDistributionFloat Lifetime;
	public/*(Size)*/ DistributionVector.RawDistributionVector StartSize;
	public/*(Rotation)*/ DistributionVector.RawDistributionVector StartRotation;
	public/*(Rotation)*/ bool bInheritParent;
	public/*(Size)*/ bool MultiplyX;
	public/*(Size)*/ bool MultiplyY;
	public/*(Size)*/ bool MultiplyZ;
	public/*(Size)*/ DistributionVector.RawDistributionVector LifeMultiplier;
	public/*(Color)*/ DistributionVector.RawDistributionVector ColorOverLife;
	public/*(Color)*/ DistributionFloat.RawDistributionFloat AlphaOverLife;
	
	public ParticleModuleUberRainSplashA()
	{
		var Default__ParticleModuleUberRainSplashA_DistributionLifetime = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberRainSplashA.DistributionLifetime' */;
		var Default__ParticleModuleUberRainSplashA_DistributionStartSize = new DistributionVectorUniform
		{
			// Object Offset:0x00468903
			Max = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			Min = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberRainSplashA.DistributionStartSize' */;
		var Default__ParticleModuleUberRainSplashA_DistributionStartRotation = new DistributionVectorUniform
		{
			// Object Offset:0x004688BF
			Max = new Vector
			{
				X=360.0f,
				Y=360.0f,
				Z=360.0f
			},
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberRainSplashA.DistributionStartRotation' */;
		var Default__ParticleModuleUberRainSplashA_DistributionLifeMultiplier = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleUberRainSplashA.DistributionLifeMultiplier' */;
		var Default__ParticleModuleUberRainSplashA_DistributionColorOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleUberRainSplashA.DistributionColorOverLife' */;
		var Default__ParticleModuleUberRainSplashA_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x004671C7
			Constant = 255.90f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainSplashA.DistributionAlphaOverLife' */;
		// Object Offset:0x00389BE0
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberRainSplashA.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleUberRainSplashA.DistributionLifetime'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
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
		StartSize = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberRainSplashA.DistributionStartSize")/*Ref DistributionVectorUniform'Default__ParticleModuleUberRainSplashA.DistributionStartSize'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
				1.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		StartRotation = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberRainSplashA.DistributionStartRotation")/*Ref DistributionVectorUniform'Default__ParticleModuleUberRainSplashA.DistributionStartRotation'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 6,
			LookupTable = new array<float>
			{
				0.0f,
				360.0f,
				0.0f,
				0.0f,
				0.0f,
				360.0f,
				360.0f,
				360.0f,
				0.0f,
				0.0f,
				0.0f,
				360.0f,
				360.0f,
				360.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		MultiplyX = true;
		MultiplyY = true;
		MultiplyZ = true;
		LifeMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleUberRainSplashA.DistributionLifeMultiplier")/*Ref DistributionVectorConstant'Default__ParticleModuleUberRainSplashA.DistributionLifeMultiplier'*/,
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
		ColorOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleUberRainSplashA.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleUberRainSplashA.DistributionColorOverLife'*/,
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
		AlphaOverLife = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainSplashA.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainSplashA.DistributionAlphaOverLife'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				255.90f,
				255.90f,
				255.90f,
				255.90f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}