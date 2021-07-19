namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberRainSplashB : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	[Category("Lifetime")] public DistributionFloat.RawDistributionFloat Lifetime;
	[Category("Size")] public DistributionVector.RawDistributionVector StartSize;
	[Category("Color")] public DistributionVector.RawDistributionVector ColorOverLife;
	[Category("Color")] public DistributionFloat.RawDistributionFloat AlphaOverLife;
	[Category("Size")] public DistributionVector.RawDistributionVector LifeMultiplier;
	[Category("Size")] public bool MultiplyX;
	[Category("Size")] public bool MultiplyY;
	[Category("Size")] public bool MultiplyZ;
	[Category("Rotation")] public DistributionFloat.RawDistributionFloat StartRotationRate;
	
	public ParticleModuleUberRainSplashB()
	{
		var Default__ParticleModuleUberRainSplashB_DistributionLifetime = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__ParticleModuleUberRainSplashB.DistributionLifetime' */;
		var Default__ParticleModuleUberRainSplashB_DistributionStartSize = new DistributionVectorUniform
		{
			// Object Offset:0x00468973
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
		}/* Reference: DistributionVectorUniform'Default__ParticleModuleUberRainSplashB.DistributionStartSize' */;
		var Default__ParticleModuleUberRainSplashB_DistributionColorOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleUberRainSplashB.DistributionColorOverLife' */;
		var Default__ParticleModuleUberRainSplashB_DistributionAlphaOverLife = new DistributionFloatConstant
		{
			// Object Offset:0x004671FB
			Constant = 255.90f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainSplashB.DistributionAlphaOverLife' */;
		var Default__ParticleModuleUberRainSplashB_DistributionLifeMultiplier = new DistributionVectorConstant
		{
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleUberRainSplashB.DistributionLifeMultiplier' */;
		var Default__ParticleModuleUberRainSplashB_DistributionStartRotationRate = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleUberRainSplashB.DistributionStartRotationRate' */;
		// Object Offset:0x0038A59F
		Lifetime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__ParticleModuleUberRainSplashB.DistributionLifetime")/*Ref DistributionFloatUniform'Default__ParticleModuleUberRainSplashB.DistributionLifetime'*/,
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
			Distribution = LoadAsset<DistributionVectorUniform>("Default__ParticleModuleUberRainSplashB.DistributionStartSize")/*Ref DistributionVectorUniform'Default__ParticleModuleUberRainSplashB.DistributionStartSize'*/,
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
		ColorOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleUberRainSplashB.DistributionColorOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleUberRainSplashB.DistributionColorOverLife'*/,
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainSplashB.DistributionAlphaOverLife")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainSplashB.DistributionAlphaOverLife'*/,
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
		LifeMultiplier = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleUberRainSplashB.DistributionLifeMultiplier")/*Ref DistributionVectorConstant'Default__ParticleModuleUberRainSplashB.DistributionLifeMultiplier'*/,
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
		MultiplyX = true;
		MultiplyY = true;
		MultiplyZ = true;
		StartRotationRate = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleUberRainSplashB.DistributionStartRotationRate")/*Ref DistributionFloatConstant'Default__ParticleModuleUberRainSplashB.DistributionStartRotationRate'*/,
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
		bSupported3DDrawMode = true;
	}
}
}