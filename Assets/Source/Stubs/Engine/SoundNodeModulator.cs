namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeModulator : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ DistributionFloat.RawDistributionFloat VolumeModulation;
	public/*()*/ DistributionFloat.RawDistributionFloat PitchModulation;
	
	public SoundNodeModulator()
	{
		// Object Offset:0x003E99B9
		VolumeModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeModulator.DistributionVolume")/*Ref DistributionFloatUniform'Default__SoundNodeModulator.DistributionVolume'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				0.90f,
				1.10f,
				0.90f,
				1.10f,
				0.90f,
				1.10f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		PitchModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeModulator.DistributionPitch")/*Ref DistributionFloatUniform'Default__SoundNodeModulator.DistributionPitch'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				0.90f,
				1.10f,
				0.90f,
				1.10f,
				0.90f,
				1.10f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}