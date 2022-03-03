namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeAmbient : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public SoundNodeAttenuation.SoundDistanceModel DistanceModel;
	[Category] public DistributionFloat.RawDistributionFloat MinRadius;
	[Category] public DistributionFloat.RawDistributionFloat MaxRadius;
	[Category] public DistributionFloat.RawDistributionFloat LPFMinRadius;
	[Category] public DistributionFloat.RawDistributionFloat LPFMaxRadius;
	[Category] public bool bSpatialize;
	[Category] public bool bAttenuate;
	[Category] public bool bAttenuateWithLowPassFilter;
	[Category] public SoundNodeWave Wave;
	[Category] public DistributionFloat.RawDistributionFloat VolumeModulation;
	[Category] public DistributionFloat.RawDistributionFloat PitchModulation;
	
	public SoundNodeAmbient()
	{
		var Default__SoundNodeAmbient_DistributionMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x00290760
			Min = 400.0f,
			Max = 400.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbient.DistributionMinRadius' */;
		var Default__SoundNodeAmbient_DistributionMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x002907B0
			Min = 5000.0f,
			Max = 5000.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbient.DistributionMaxRadius' */;
		var Default__SoundNodeAmbient_DistributionLPFMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x00290800
			Min = 1500.0f,
			Max = 1500.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbient.DistributionLPFMinRadius' */;
		var Default__SoundNodeAmbient_DistributionLPFMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x00290850
			Min = 2500.0f,
			Max = 2500.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbient.DistributionLPFMaxRadius' */;
		var Default__SoundNodeAmbient_DistributionVolume = new DistributionFloatUniform
		{
			// Object Offset:0x002908A0
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbient.DistributionVolume' */;
		var Default__SoundNodeAmbient_DistributionPitch = new DistributionFloatUniform
		{
			// Object Offset:0x002908F0
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbient.DistributionPitch' */;
		// Object Offset:0x0028FDA6
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SoundNodeAmbient_DistributionMinRadius/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionMinRadius'*/,
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
			Distribution = Default__SoundNodeAmbient_DistributionMaxRadius/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionMaxRadius'*/,
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
			Distribution = Default__SoundNodeAmbient_DistributionLPFMinRadius/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionLPFMinRadius'*/,
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
			Distribution = Default__SoundNodeAmbient_DistributionLPFMaxRadius/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionLPFMaxRadius'*/,
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
			Distribution = Default__SoundNodeAmbient_DistributionVolume/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionVolume'*/,
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
			Distribution = Default__SoundNodeAmbient_DistributionPitch/*Ref DistributionFloatUniform'Default__SoundNodeAmbient.DistributionPitch'*/,
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