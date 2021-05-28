namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeAmbient : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ SoundNodeAttenuation.SoundDistanceModel DistanceModel;
	public/*()*/ DistributionFloat.RawDistributionFloat MinRadius;
	public/*()*/ DistributionFloat.RawDistributionFloat MaxRadius;
	public/*()*/ DistributionFloat.RawDistributionFloat LPFMinRadius;
	public/*()*/ DistributionFloat.RawDistributionFloat LPFMaxRadius;
	public/*()*/ bool bSpatialize;
	public/*()*/ bool bAttenuate;
	public/*()*/ bool bAttenuateWithLowPassFilter;
	public/*()*/ SoundNodeWave Wave;
	public/*()*/ DistributionFloat.RawDistributionFloat VolumeModulation;
	public/*()*/ DistributionFloat.RawDistributionFloat PitchModulation;
	
	public SoundNodeAmbient()
	{
		// Object Offset:0x0028FDA6
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbient.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionMinRadius'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				400.0f,
				400.0f,
				400.0f,
				400.0f,
				400.0f,
				400.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		MaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbient.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionMaxRadius'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				5000.0f,
				5000.0f,
				5000.0f,
				5000.0f,
				5000.0f,
				5000.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		LPFMinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbient.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionLPFMinRadius'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				1500.0f,
				1500.0f,
				1500.0f,
				1500.0f,
				1500.0f,
				1500.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		LPFMaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbient.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionLPFMaxRadius'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				2500.0f,
				2500.0f,
				2500.0f,
				2500.0f,
				2500.0f,
				2500.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		bSpatialize = true;
		bAttenuate = true;
		VolumeModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbient.DistributionVolume")/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionVolume'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
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
		PitchModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbient.DistributionPitch")/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionPitch'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
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
	}
}
}