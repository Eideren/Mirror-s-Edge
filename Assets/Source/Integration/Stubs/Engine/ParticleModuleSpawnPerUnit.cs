namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleSpawnPerUnit : ParticleModuleSpawnBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	[Category("Spawn")] public float UnitScalar;
	[Category("Spawn")] public DistributionFloat.RawDistributionFloat SpawnPerUnit;
	[Category("Spawn")] public bool bIgnoreSpawnRateWhenMoving;
	[Category("Spawn")] public float MovementTolerance;
	
	public ParticleModuleSpawnPerUnit()
	{
		var Default__ParticleModuleSpawnPerUnit_RequiredDistributionSpawnPerUnit = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleSpawnPerUnit.RequiredDistributionSpawnPerUnit' */;
		// Object Offset:0x00382A6F
		UnitScalar = 50.0f;
		SpawnPerUnit = new DistributionFloat.RawDistributionFloat
		{
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleSpawnPerUnit.RequiredDistributionSpawnPerUnit")/*Ref DistributionFloatConstant'Default__ParticleModuleSpawnPerUnit.RequiredDistributionSpawnPerUnit'*/,
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
		MovementTolerance = 0.10f;
		bSpawnModule = true;
	}
}
}