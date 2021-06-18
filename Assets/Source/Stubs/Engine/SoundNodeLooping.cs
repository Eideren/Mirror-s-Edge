namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SoundNodeLooping : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ bool bLoopIndefinitely;
	public/*()*/ DistributionFloat.RawDistributionFloat LoopCount;
	
	public SoundNodeLooping()
	{
		var Default__SoundNodeLooping_DistributionLoopCount = new DistributionFloatUniform
		{
			// Object Offset:0x00467A53
			Min = 1000000.0f,
			Max = 1000000.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeLooping.DistributionLoopCount' */;
		// Object Offset:0x003E9644
		bLoopIndefinitely = true;
		LoopCount = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SoundNodeLooping.DistributionLoopCount")/*Ref DistributionFloatUniform'Default__SoundNodeLooping.DistributionLoopCount'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				1000000.0f,
				1000000.0f,
				1000000.0f,
				1000000.0f,
				1000000.0f,
				1000000.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
	}
}
}