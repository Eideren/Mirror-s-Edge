namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeModulator : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public DistributionFloat.RawDistributionFloat VolumeModulation;
	[Category] public DistributionFloat.RawDistributionFloat PitchModulation;



	public class DistributionVolume : DistributionFloatUniform
	{
		public DistributionVolume()
		{
			Min = 0.90f;
			Max = 1.10f;
		}
	}
	
	public class DistributionPitch : DistributionFloatUniform
	{
		public DistributionPitch()
		{
			Min = 0.90f;
			Max = 1.10f;
		}
	}



	public SoundNodeModulator()
	{
		var Default__SoundNodeModulator_DistributionVolume = new DistributionFloatUniform
		{
			// Object Offset:0x00467AF3
			Min = 0.90f,
			Max = 1.10f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeModulator.DistributionVolume' */;
		var Default__SoundNodeModulator_DistributionPitch = new DistributionFloatUniform
		{
			// Object Offset:0x00467AA3
			Min = 0.90f,
			Max = 1.10f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeModulator.DistributionPitch' */;
		// Object Offset:0x003E99B9
		VolumeModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SoundNodeModulator_DistributionVolume/*Ref DistributionFloatUniform'Default__SoundNodeModulator.DistributionVolume'*/,
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
			Distribution = Default__SoundNodeModulator_DistributionPitch/*Ref DistributionFloatUniform'Default__SoundNodeModulator.DistributionPitch'*/,
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