namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeDuckTrigger : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category("MixGroups")] public array<name> MixGroups;
	[Category] public float DuckDuration;
	[Category] public float DuckLevel;
	[Category] public DistributionFloat.RawDistributionFloat MinRadius;
	[Category] public DistributionFloat.RawDistributionFloat MaxRadius;
	[Category] public SoundNodeAttenuation.SoundDistanceModel DistanceModel;
	[Category] public bool bAttenuate;
	[Category] public bool bInvertMixGroupSelection;
	
	public class DistributionMinRadius : DistributionFloatUniform
	{
		public DistributionMinRadius(){// Object Offset:0x01AFCB9E
			Min = 100.0f;
			Max = 100.0f;
		}
	}/* Reference: DistributionFloatUniform'Default__TdSoundNodeDuckTrigger.DistributionMinRadius' */;
	public class DistributionMaxRadius : DistributionFloatUniform
	{
		public DistributionMaxRadius(){// Object Offset:0x01AFCC1A
			Min = 1000.0f;
			Max = 1000.0f;
		}
	}/* Reference: DistributionFloatUniform'Default__TdSoundNodeDuckTrigger.DistributionMaxRadius' */;
	
	public TdSoundNodeDuckTrigger()
	{
		var Default__TdSoundNodeDuckTrigger_DistributionMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x01AFCB9E
			Min = 100.0f,
			Max = 100.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeDuckTrigger.DistributionMinRadius' */;
		var Default__TdSoundNodeDuckTrigger_DistributionMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x01AFCC1A
			Min = 1000.0f,
			Max = 1000.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeDuckTrigger.DistributionMaxRadius' */;
		// Object Offset:0x0065AE64
		DuckDuration = 3.0f;
		DuckLevel = 0.30f;
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdSoundNodeDuckTrigger_DistributionMinRadius,
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
			Distribution = Default__TdSoundNodeDuckTrigger_DistributionMaxRadius,
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