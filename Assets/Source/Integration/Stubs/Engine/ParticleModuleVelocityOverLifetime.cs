namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleVelocityOverLifetime : ParticleModuleVelocityBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Velocity")] public DistributionVector.RawDistributionVector VelOverLife;
	[Category("Velocity")] [export] public bool Absolute;
	
	public ParticleModuleVelocityOverLifetime()
	{
		var Default__ParticleModuleVelocityOverLifetime_DistributionVelOverLife = new DistributionVectorConstantCurve
		{
		}/* Reference: DistributionVectorConstantCurve'Default__ParticleModuleVelocityOverLifetime.DistributionVelOverLife' */;
		// Object Offset:0x0038B3E7
		VelOverLife = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstantCurve>("Default__ParticleModuleVelocityOverLifetime.DistributionVelOverLife")/*Ref DistributionVectorConstantCurve'Default__ParticleModuleVelocityOverLifetime.DistributionVelOverLife'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				0.0f,
				0.0f,
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
		bSpawnModule = true;
		bUpdateModule = true;
	}
}
}