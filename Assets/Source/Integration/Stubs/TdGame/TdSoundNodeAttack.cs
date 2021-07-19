namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundNodeAttack : SoundNode/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public bool bModulatePitch;
	[Category] public bool bModulateVolume;
	[Category("Attack")] public TdSoundNodeADSR.SoundInterpolationMethod AttackInterpolationMethod;
	[Category("Decay")] public TdSoundNodeADSR.SoundInterpolationMethod DecayInterpolationMethod;
	[Category("Attack")] public TdSoundNodeADSR.SoundInterpolationMethod AttackDistanceModel;
	[Category("Decay")] public TdSoundNodeADSR.SoundInterpolationMethod DecayDistanceModel;
	[Category("Attack")] public float AttackAtMinRadius;
	[Category("Attack")] public float AttackAtMaxRadius;
	[Category("Decay")] public float DecayAtMinRadius;
	[Category("Decay")] public float DecayAtMaxRadius;
	[Category("Attack")] public DistributionFloat.RawDistributionFloat AttackMinRadius;
	[Category("Attack")] public DistributionFloat.RawDistributionFloat AttackMaxRadius;
	[Category("Decay")] public DistributionFloat.RawDistributionFloat DecayMinRadius;
	[Category("Decay")] public DistributionFloat.RawDistributionFloat DecayMaxRadius;
	
	public TdSoundNodeAttack()
	{
		var Default__TdSoundNodeAttack_ADistributionMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x01B1D716
			Min = 100.0f,
			Max = 100.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeAttack.ADistributionMinRadius' */;
		var Default__TdSoundNodeAttack_ADistributionMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x01B1D6C6
			Min = 1000.0f,
			Max = 1000.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeAttack.ADistributionMaxRadius' */;
		var Default__TdSoundNodeAttack_DDistributionMinRadius = new DistributionFloatUniform
		{
			// Object Offset:0x01B1D7B6
			Min = 100.0f,
			Max = 100.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeAttack.DDistributionMinRadius' */;
		var Default__TdSoundNodeAttack_DDistributionMaxRadius = new DistributionFloatUniform
		{
			// Object Offset:0x01B1D766
			Min = 1000.0f,
			Max = 1000.0f,
		}/* Reference: DistributionFloatUniform'Default__TdSoundNodeAttack.DDistributionMaxRadius' */;
		// Object Offset:0x0065A1E3
		bModulateVolume = true;
		AttackAtMinRadius = 0.050f;
		AttackAtMaxRadius = 0.050f;
		DecayAtMinRadius = 1.0f;
		DecayAtMaxRadius = 1.0f;
		AttackMinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttack.ADistributionMinRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttack.ADistributionMinRadius'*/,
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
		AttackMaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttack.ADistributionMaxRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttack.ADistributionMaxRadius'*/,
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
		DecayMinRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttack.DDistributionMinRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttack.DDistributionMinRadius'*/,
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
		DecayMaxRadius = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatUniform>("Default__TdSoundNodeAttack.DDistributionMaxRadius")/*Ref DistributionFloatUniform'Default__TdSoundNodeAttack.DDistributionMaxRadius'*/,
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