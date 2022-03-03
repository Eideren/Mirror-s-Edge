namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeADSR : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public enum SoundInterpolationMethod 
	{
		INTERPOLATION_Linear,
		INTERPOLATION_Smooth,
		INTERPOLATION_Square,
		INTERPOLATION_Fast,
		INTERPOLATION_MAX
	};
	
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod AttackInterpolationMethod;
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod DecayInterpolationMethod;
	[Category] public TdSoundNodeADSR.SoundInterpolationMethod ReleaseInterpolationMethod;
	[Category] public DistributionFloat.RawDistributionFloat Attack;
	[Category] public DistributionFloat.RawDistributionFloat Decay;
	[Category] public DistributionFloat.RawDistributionFloat Sustain;
	[Category] public DistributionFloat.RawDistributionFloat Release;
	[Category] public bool bModulatePitch;
	[Category] public bool bModulateVolume;



	public class DistributionAttack : DistributionFloatUniform
	{
		public DistributionAttack()
		{
		} /* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionAttack' */
	}



	public class DistributionDecay : DistributionFloatUniform
	{
		public DistributionDecay()
		{
		} /* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionDecay' */
	}



	public class DistributionSustain : DistributionFloatUniform
	{
		public DistributionSustain()
		{
			// Object Offset:0x01AFC87E
			Min = 1.0f;
			Max = 1.0f;
		} /* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionSustain' */
	}



	public class DistributionRelease : DistributionFloatUniform
	{
		public DistributionRelease()
		{
		} /* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionRelease' */
	}



	public TdSoundNodeADSR()
	{
		var Default__TdSoundNodeADSR_DistributionAttack = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionAttack' */;
		var Default__TdSoundNodeADSR_DistributionDecay = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionDecay' */;
		var Default__TdSoundNodeADSR_DistributionSustain = new DistributionFloatUniform
		{
			// Object Offset:0x01AFC87E
			Min = 1.0f,
			Max = 1.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionSustain' */;
		var Default__TdSoundNodeADSR_DistributionRelease = new DistributionFloatUniform
		{
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeADSR.DistributionRelease' */;
		// Object Offset:0x00659A40
		Attack = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdSoundNodeADSR_DistributionAttack,
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
		Decay = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdSoundNodeADSR_DistributionDecay,
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
		Sustain = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdSoundNodeADSR_DistributionSustain,
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
		Release = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__TdSoundNodeADSR_DistributionRelease,
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
		bModulateVolume = true;
	}
}
}