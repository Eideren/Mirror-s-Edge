namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeDelayToDistance : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public DistributionFloat.RawDistributionFloat SpeedOfSound;
	[Category] public float MaxDistance;
	
	public TdSoundNodeDelayToDistance()
	{
		var Default__TdSoundNodeDelayToDistance_DistributionSpeedOfSound = new DistributionFloatUniform
		{
			// Object Offset:0x01B1D806
			Min = 33100.0f,
			Max = 33101.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeDelayToDistance.DistributionSpeedOfSound' */;
		// Object Offset:0x0065AB0D
		SpeedOfSound = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeDelayToDistance.DistributionSpeedOfSound")/*Ref DistributionFloatUniform'Default__TdSoundNodeDelayToDistance.DistributionSpeedOfSound'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				33100.0f,
				33101.0f,
				33100.0f,
				33101.0f,
				33100.0f,
				33101.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		MaxDistance = 100000.0f;
	}
}
}