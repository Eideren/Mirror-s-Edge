namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeAmbientNonLoop : SoundNodeAmbient/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public partial struct /*native */AmbientSoundSlot
	{
		public/*()*/ SoundNodeWave Wave;
		public/*()*/ float PitchScale;
		public/*()*/ float VolumeScale;
		public/*()*/ float Weight;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00290A84
	//		Wave = default;
	//		PitchScale = 1.0f;
	//		VolumeScale = 1.0f;
	//		Weight = 1.0f;
	//	}
	};
	
	public/*()*/ DistributionFloat.RawDistributionFloat DelayTime;
	public/*()*/ array<SoundNodeAmbientNonLoop.AmbientSoundSlot> SoundSlots;
	
	public SoundNodeAmbientNonLoop()
	{
		var Default__SoundNodeAmbientNonLoop_DistributionDelayTime = new DistributionFloatUniform
		{
			// Object Offset:0x00467333
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionDelayTime' */;
		var Default__SoundNodeAmbientNonLoop_DistributionMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionMinRadius' */;
		var Default__SoundNodeAmbientNonLoop_DistributionMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionMaxRadius' */;
		var Default__SoundNodeAmbientNonLoop_DistributionLPFMinRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionLPFMinRadius' */;
		var Default__SoundNodeAmbientNonLoop_DistributionLPFMaxRadius = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionLPFMaxRadius' */;
		var Default__SoundNodeAmbientNonLoop_DistributionVolume = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionVolume' */;
		var Default__SoundNodeAmbientNonLoop_DistributionPitch = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionPitch' */;
		// Object Offset:0x00290B2C
		DelayTime = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionDelayTime")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionDelayTime'*/,
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
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionMinRadius'*/,
		};
		MaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionMaxRadius'*/,
		};
		LPFMinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionLPFMinRadius'*/,
		};
		LPFMaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionLPFMaxRadius'*/,
		};
		VolumeModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionVolume")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionVolume'*/,
		};
		PitchModulation = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAmbientNonLoop.DistributionPitch")/*Ref DistributionFloatUniform'Default__SoundNodeAmbientNonLoop.DistributionPitch'*/,
		};
	}
}
}