namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleVelocityInheritParent : ParticleModuleVelocityBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Velocity")] public DistributionVector.RawDistributionVector Scale;
	
	public ParticleModuleVelocityInheritParent()
	{
		var Default__ParticleModuleVelocityInheritParent_DistributionScale = new DistributionVectorConstant
		{
			// Object Offset:0x0046824F
			Constant = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
		}/* Reference: DistributionVectorConstant'Default__ParticleModuleVelocityInheritParent.DistributionScale' */;
		// Object Offset:0x0038B1C0
		Scale = new DistributionVector.RawDistributionVector
		{
			Distribution = Default__ParticleModuleVelocityInheritParent_DistributionScale/*Ref DistributionVectorConstant'Default__ParticleModuleVelocityInheritParent.DistributionScale'*/,
			Type = 0,
			Op = 1,
			LookupTableNumElements = 1,
			LookupTableChunkSize = 3,
			LookupTable = new array<float>
			{
				1.0f,
				1.0f,
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
		bSpawnModule = true;
	}
}
}