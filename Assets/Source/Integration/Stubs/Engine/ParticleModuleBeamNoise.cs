namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamNoise : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("LowFreq")] public bool bLowFreq_Enabled;
	[Category("LowFreq")] public bool bNRScaleEmitterTime;
	[Category("LowFreq")] public bool bSmooth;
	[Const] public bool bNoiseLock;
	[Category("LowFreq")] public bool bOscillate;
	[Category("LowFreq")] public bool bUseNoiseTangents;
	[Category("LowFreq")] public bool bTargetNoise;
	[Category("LowFreq")] public bool bApplyNoiseScale;
	[Category("LowFreq")] public int Frequency;
	[Category("LowFreq")] public int Frequency_LowRange;
	[Category("LowFreq")] public DistributionVector.RawDistributionVector NoiseRange;
	[Category("LowFreq")] public DistributionFloat.RawDistributionFloat NoiseRangeScale;
	[Category("LowFreq")] public DistributionVector.RawDistributionVector NoiseSpeed;
	[Category("LowFreq")] public float NoiseLockRadius;
	[Category("LowFreq")] public float NoiseLockTime;
	[Category("LowFreq")] public float NoiseTension;
	[Category("LowFreq")] public DistributionFloat.RawDistributionFloat NoiseTangentStrength;
	[Category("LowFreq")] public int NoiseTessellation;
	[Category("LowFreq")] public float FrequencyDistance;
	[Category("LowFreq")] public DistributionFloat.RawDistributionFloat NoiseScale;
	
	public ParticleModuleBeamNoise()
	{
		var Default__ParticleModuleBeamNoise_DistributionNoiseRange = new DistributionVectorConstant
		{
			// Object Offset:0x00467DB3
			Constant = new Vector
			{
				X=50.0f,
				Y=50.0f,
				Z=50.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamNoise.DistributionNoiseRange' */;
		var Default__ParticleModuleBeamNoise_DistributionNoiseRangeScale = new DistributionFloatConstant
		{
			// Object Offset:0x00466B2B
			Constant = 1.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleBeamNoise.DistributionNoiseRangeScale' */;
		var Default__ParticleModuleBeamNoise_DistributionNoiseSpeed = new DistributionVectorConstant
		{
			// Object Offset:0x00467DF7
			Constant = new Vector
			{
				X=50.0f,
				Y=50.0f,
				Z=50.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleBeamNoise.DistributionNoiseSpeed' */;
		var Default__ParticleModuleBeamNoise_DistributionNoiseTangentStrength = new DistributionFloatConstant
		{
			// Object Offset:0x00466B5F
			Constant = 250.0f,
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleBeamNoise.DistributionNoiseTangentStrength' */;
		var Default__ParticleModuleBeamNoise_DistributionNoiseScale = new DistributionFloatConstantCurve
		{
		}/* Reference: DistributionFloatConstantCurve'Default__ParticleModuleBeamNoise.DistributionNoiseScale' */;
		// Object Offset:0x0037A926
		NoiseRange = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamNoise.DistributionNoiseRange")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamNoise.DistributionNoiseRange'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		NoiseRangeScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleBeamNoise.DistributionNoiseRangeScale")/*Ref DistributionFloatConstant'Default__ParticleModuleBeamNoise.DistributionNoiseRangeScale'*/,
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
		NoiseSpeed = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleBeamNoise.DistributionNoiseSpeed")/*Ref DistributionVectorConstant'Default__ParticleModuleBeamNoise.DistributionNoiseSpeed'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
				50.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		NoiseLockRadius = 1.0f;
		NoiseTension = 0.50f;
		NoiseTangentStrength = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleBeamNoise.DistributionNoiseTangentStrength")/*Ref DistributionFloatConstant'Default__ParticleModuleBeamNoise.DistributionNoiseTangentStrength'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				250.0f,
				250.0f,
				250.0f,
				250.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		NoiseTessellation = 1;
		NoiseScale = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstantCurve>("Default__ParticleModuleBeamNoise.DistributionNoiseScale")/*Ref DistributionFloatConstantCurve'Default__ParticleModuleBeamNoise.DistributionNoiseScale'*/,
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
	}
}
}