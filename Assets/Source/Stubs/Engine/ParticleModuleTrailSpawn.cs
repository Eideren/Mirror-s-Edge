namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTrailSpawn : ParticleModuleTrailBase/*
		native
		editinlinenew
		hidecategories(Object,Object,Object)*/{
	public enum ETrail2SpawnMethod 
	{
		PET2SM_Emitter,
		PET2SM_Velocity,
		PET2SM_Distance,
		PET2SM_MAX
	};
	
	public/*(Spawn)*/ /*noclear export editinline */DistributionFloatParticleParameter SpawnDistanceMap;
	public/*(Spawn)*/ float MinSpawnVelocity;
	
	public ParticleModuleTrailSpawn()
	{
		var Default__ParticleModuleTrailSpawn_DistributionSpawnDistanceMap = new DistributionFloatParticleParameter
		{
			// Object Offset:0x0046728F
			MinInput = 10.0f,
			MaxInput = 100.0f,
			MinOutput = 1.0f,
			MaxOutput = 5.0f,
			Constant = 1.0f,
		}/* Reference: DistributionFloatParticleParameter'Default__ParticleModuleTrailSpawn.DistributionSpawnDistanceMap' */;
		// Object Offset:0x003838E0
		SpawnDistanceMap = Default__ParticleModuleTrailSpawn_DistributionSpawnDistanceMap;
	}
}
}