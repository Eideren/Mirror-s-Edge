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
	
	[Category] public SoundNodeAttenuation.SoundDistanceModel DistanceModel;
	[Category] public DistributionFloat.RawDistributionFloat MinRadius;
	[Category] public DistributionFloat.RawDistributionFloat MaxRadius;
	[Category] public float dBAttenuationAtMax;
	[Category] public DistributionFloat.RawDistributionFloat LPFMinRadius;
	[Category] public DistributionFloat.RawDistributionFloat LPFMaxRadius;
	[Category] public bool bSpatialize;
	[Category] public bool bAttenuate;
	[Category] public bool bAttenuateWithLowPassFilter;



	public class DistributionMaxRadius : DistributionFloatUniform
	{
		public DistributionMaxRadius()
		{
			Min = 5000.0f;
			Max = 5000.0f;
		}
	}
	public class DistributionMinRadius : DistributionFloatUniform
	{
		public DistributionMinRadius()
		{
			Min = 400.0f;
			Max = 400.0f;
		}
	}
	
	public class DistributionLPFMinRadius : DistributionFloatUniform
	{
		public DistributionLPFMinRadius()
		{
			Min = 1500.0f;
			Max = 1500.0f;
		}
	}
	
	public class DistributionLPFMaxRadius : DistributionFloatUniform
	{
		public DistributionLPFMaxRadius()
		{
			Min = 5000.0f;
			Max = 5000.0f;
		}
	}



	public SoundNodeAttenuation()
	{
		var Default__SoundNodeAttenuation_DistributionMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x004679EB
			Min = 400.0f,
			Max = 400.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionMinRadius' */;
		var Default__SoundNodeAttenuation_DistributionMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x0046799B
			Min = 5000.0f,
			Max = 5000.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionMaxRadius' */;
		var Default__SoundNodeAttenuation_DistributionLPFMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x0046794B
			Min = 1500.0f,
			Max = 1500.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionLPFMinRadius' */;
		var Default__SoundNodeAttenuation_DistributionLPFMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x004678FB
			Min = 5000.0f,
			Max = 5000.0f,
		}/* Reference: DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionLPFMaxRadius' */;
		// Object Offset:0x003E8A18
		MinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SoundNodeAttenuation_DistributionMinRadius/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionMinRadius'*/,
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
			Distribution = Default__SoundNodeAttenuation_DistributionMaxRadius/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionMaxRadius'*/,
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
			Distribution = Default__SoundNodeAttenuation_DistributionLPFMinRadius/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionLPFMinRadius'*/,
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
			Distribution = Default__SoundNodeAttenuation_DistributionLPFMaxRadius/*Ref DistributionFloatUniform'Default__SoundNodeAttenuation.DistributionLPFMaxRadius'*/,
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