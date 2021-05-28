namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleVelocityInheritParent : ParticleModuleVelocityBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public/*(Velocity)*/ DistributionVector.RawDistributionVector Scale;
	
	public ParticleModuleVelocityInheritParent()
	{
		// Object Offset:0x0038B1C0
		Scale = new DistributionVector.RawDistributionVector
		{
			Distribution = LoadAsset<DistributionVectorConstant>("Default__ParticleModuleVelocityInheritParent.DistributionScale")/*Ref DistributionVectorConstant'Default__ParticleModuleVelocityInheritParent.DistributionScale'*/,
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