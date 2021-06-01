namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeDuckTrigger : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*(MixGroups)*/ array<name> MixGroups;
	public/*()*/ float DuckDuration;
	public/*()*/ float DuckLevel;
	public/*()*/ DistributionFloat.RawDistributionFloat MinRadius;
	public/*()*/ DistributionFloat.RawDistributionFloat MaxRadius;
	public/*()*/ SoundNodeAttenuation.SoundDistanceModel DistanceModel;
	public/*()*/ bool bAttenuate;
	public/*()*/ bool bInvertMixGroupSelection;
	
	public TdSoundNodeDuckTrigger()
	{
		// Object Offset:0x0065AE64
		DuckDuration = 3.0f;
		DuckLevel = 0.30f;
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeDuckTrigger.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeDuckTrigger.DistributionMinRadius'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				100.0f,
				100.0f,
				100.0f,
				100.0f,
				100.0f,
				100.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		MaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeDuckTrigger.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeDuckTrigger.DistributionMaxRadius'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				1000.0f,
				1000.0f,
				1000.0f,
				1000.0f,
				1000.0f,
				1000.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}