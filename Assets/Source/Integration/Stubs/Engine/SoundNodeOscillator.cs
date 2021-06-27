namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeOscillator : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ DistributionFloat.RawDistributionFloat Amplitude;
	public/*()*/ DistributionFloat.RawDistributionFloat Frequency;
	public/*()*/ DistributionFloat.RawDistributionFloat Offset;
	public/*()*/ DistributionFloat.RawDistributionFloat Center;
	public/*()*/ bool bModulatePitch;
	public/*()*/ bool bModulateVolume;
	
	public SoundNodeOscillator()
	{
		var Default__SoundNodeOscillator_DistributionAmplitude = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeOscillator.DistributionAmplitude' */;
		var Default__SoundNodeOscillator_DistributionFrequency = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeOscillator.DistributionFrequency' */;
		var Default__SoundNodeOscillator_DistributionOffset = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeOscillator.DistributionOffset' */;
		var Default__SoundNodeOscillator_DistributionCenter = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeOscillator.DistributionCenter' */;
		// Object Offset:0x003EA0AF
		Amplitude = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeOscillator.DistributionAmplitude")/*Ref DistributionFloatUniform'Default__SoundNodeOscillator.DistributionAmplitude'*/,
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
		Frequency = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeOscillator.DistributionFrequency")/*Ref DistributionFloatUniform'Default__SoundNodeOscillator.DistributionFrequency'*/,
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
		Offset = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeOscillator.DistributionOffset")/*Ref DistributionFloatUniform'Default__SoundNodeOscillator.DistributionOffset'*/,
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
		Center = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeOscillator.DistributionCenter")/*Ref DistributionFloatUniform'Default__SoundNodeOscillator.DistributionCenter'*/,
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
	}
}
}