namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleBeamNoise : ParticleModuleBeamBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(LowFreq)*/ bool bLowFreq_Enabled;
	public/*(LowFreq)*/ bool bNRScaleEmitterTime;
	public/*(LowFreq)*/ bool bSmooth;
	public /*const */bool bNoiseLock;
	public/*(LowFreq)*/ bool bOscillate;
	public/*(LowFreq)*/ bool bUseNoiseTangents;
	public/*(LowFreq)*/ bool bTargetNoise;
	public/*(LowFreq)*/ bool bApplyNoiseScale;
	public/*(LowFreq)*/ int Frequency;
	public/*(LowFreq)*/ int Frequency_LowRange;
	public/*(LowFreq)*/ DistributionVector.RawDistributionVector NoiseRange;
	public/*(LowFreq)*/ DistributionFloat.RawDistributionFloat NoiseRangeScale;
	public/*(LowFreq)*/ DistributionVector.RawDistributionVector NoiseSpeed;
	public/*(LowFreq)*/ float NoiseLockRadius;
	public/*(LowFreq)*/ float NoiseLockTime;
	public/*(LowFreq)*/ float NoiseTension;
	public/*(LowFreq)*/ DistributionFloat.RawDistributionFloat NoiseTangentStrength;
	public/*(LowFreq)*/ int NoiseTessellation;
	public/*(LowFreq)*/ float FrequencyDistance;
	public/*(LowFreq)*/ DistributionFloat.RawDistributionFloat NoiseScale;
	
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