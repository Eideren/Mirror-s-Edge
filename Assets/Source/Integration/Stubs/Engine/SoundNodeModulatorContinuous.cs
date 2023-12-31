namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeModulatorContinuous : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public DistributionFloat.RawDistributionFloat VolumeModulation;
	[Category] public DistributionFloat.RawDistributionFloat PitchModulation;
	
	public SoundNodeModulatorContinuous()
	{
		var Default__SoundNodeModulatorContinuous_DistributionVolume = new DistributionFloatUniform
		{
			// Object Offset:0x00467B93
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeModulatorContinuous.DistributionVolume' */;
		var Default__SoundNodeModulatorContinuous_DistributionPitch = new DistributionFloatUniform
		{
			// Object Offset:0x00467B43
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeModulatorContinuous.DistributionPitch' */;
		// Object Offset:0x003E9CD8
		VolumeModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SoundNodeModulatorContinuous_DistributionVolume/*Ref DistributionFloatUniform'Default__SoundNodeModulatorContinuous.DistributionVolume'*/,
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
			Distribution = Default__SoundNodeModulatorContinuous_DistributionPitch/*Ref DistributionFloatUniform'Default__SoundNodeModulatorContinuous.DistributionPitch'*/,
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