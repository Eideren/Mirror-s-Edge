namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeModulatorContinuous : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ DistributionFloat.RawDistributionFloat VolumeModulation;
	public/*()*/ DistributionFloat.RawDistributionFloat PitchModulation;
	
	public SoundNodeModulatorContinuous()
	{
		// Object Offset:0x003E9CD8
		VolumeModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeModulatorContinuous.DistributionVolume")/*Ref DistributionFloatUniform'Default__SoundNodeModulatorContinuous.DistributionVolume'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeModulatorContinuous.DistributionPitch")/*Ref DistributionFloatUniform'Default__SoundNodeModulatorContinuous.DistributionPitch'*/,
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