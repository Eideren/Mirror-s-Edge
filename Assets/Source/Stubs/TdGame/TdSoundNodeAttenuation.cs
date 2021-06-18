namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeAttenuation : SoundNodeAttenuation/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public/*()*/ DistributionFloat.RawDistributionFloat SpeedOfSound;
	public/*()*/ bool bDelay;
	
	public TdSoundNodeAttenuation()
	{
		var Default__TdSoundNodeAttenuation_DistributionSpeedOfSound = new DistributionFloatUniform
		{
			// Object Offset:0x01B12D0E
			Min = 33100.0f,
			Max = 33101.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeAttenuation.DistributionSpeedOfSound' */;
		// Object Offset:0x0065A7CA
		SpeedOfSound = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttenuation.DistributionSpeedOfSound")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttenuation.DistributionSpeedOfSound'*/,
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
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttenuation.DistributionMinRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttenuation.DistributionMinRadius'*/,
		};
		MaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttenuation.DistributionMaxRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttenuation.DistributionMaxRadius'*/,
		};
		LPFMinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttenuation.DistributionLPFMinRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttenuation.DistributionLPFMinRadius'*/,
		};
		LPFMaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttenuation.DistributionLPFMaxRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttenuation.DistributionLPFMaxRadius'*/,
		};
	}
}
}