namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRotationOverLifetime : ParticleModuleRotationBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Rotation")] public DistributionFloat.RawDistributionFloat RotationOverLife;
	[Category("Rotation")] public bool Scale;
	
	public ParticleModuleRotationOverLifetime()
	{
		var Default__ParticleModuleRotationOverLifetime_DistributionRotOverLife = new DistributionFloatConstantCurve
		{
		}/* Reference: DistributionFloatConstantCurve'Default__ParticleModuleRotationOverLifetime.DistributionRotOverLife' */;
		// Object Offset:0x003813D5
		RotationOverLife = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstantCurve>("Default__ParticleModuleRotationOverLifetime.DistributionRotOverLife")/*Ref DistributionFloatConstantCurve'Default__ParticleModuleRotationOverLifetime.DistributionRotOverLife'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 1,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
				0.0f,
				0.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		Scale = true;
		bUpdateModule = true;
	}
}
}