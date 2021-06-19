namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeDelay : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ DistributionFloat.RawDistributionFloat DelayDuration;
	
	public SoundNodeDelay()
	{
		var Default__SoundNodeDelay_DistributionDelayDuration = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__SoundNodeDelay.DistributionDelayDuration' */;
		// Object Offset:0x003E9092
		DelayDuration = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeDelay.DistributionDelayDuration")/*Ref DistributionFloatUniform'Default__SoundNodeDelay.DistributionDelayDuration'*/,
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