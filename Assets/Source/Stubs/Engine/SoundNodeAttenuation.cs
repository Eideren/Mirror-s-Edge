namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeAttenuation : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public enum SoundDistanceModel 
	{
		ATTENUATION_Linear,
		ATTENUATION_Logarithmic,
		ATTENUATION_Inverse,
		ATTENUATION_LogReverse,
		ATTENUATION_NaturalSound,
		ATTENUATION_MAX
	};
	
	public/*()*/ SoundNodeAttenuation.SoundDistanceModel DistanceModel;
	public/*()*/ DistributionFloat.RawDistributionFloat MinRadius;
	public/*()*/ DistributionFloat.RawDistributionFloat MaxRadius;
	public/*()*/ float dBAttenuationAtMax;
	public/*()*/ DistributionFloat.RawDistributionFloat LPFMinRadius;
	public/*()*/ DistributionFloat.RawDistributionFloat LPFMaxRadius;
	public/*()*/ bool bSpatialize;
	public/*()*/ bool bAttenuate;
	public/*()*/ bool bAttenuateWithLowPassFilter;
	
	public SoundNodeAttenuation()
	{
		// Object Offset:0x003E8A18
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAttenuation.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionMinRadius'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAttenuation.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionMaxRadius'*/,
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
		dBAttenuationAtMax = -60.0f;
		LPFMinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAttenuation.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionLPFMinRadius'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeAttenuation.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionLPFMaxRadius'*/,
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
		bSpatialize = true;
		bAttenuate = true;
		bAttenuateWithLowPassFilter = true;
	}
}
}