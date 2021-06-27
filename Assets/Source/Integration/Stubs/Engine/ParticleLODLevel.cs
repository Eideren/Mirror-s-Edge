namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleLODLevel : Object/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public /*const */int Level;
	public /*const deprecated */int LevelSetting;
	public bool bEnabled;
	public bool ConvertedModules;
	public /*export editinline */ParticleModuleRequired RequiredModule;
	public /*export editinline */array</*export editinline */ParticleModule> Modules;
	public /*export */ParticleModule TypeDataModule;
	public /*export */ParticleModuleSpawn SpawnModule;
	public /*native */array<ParticleModuleSpawnBase> SpawningModules;
	public /*native */array<ParticleModule> SpawnModules;
	public /*native */array<ParticleModule> UpdateModules;
	public /*native */array<ParticleModuleOrbit> OrbitModules;
	public int PeakActiveParticles;
	
	public ParticleLODLevel()
	{
		// Object Offset:0x003785B9
		bEnabled = true;
		ConvertedModules = true;
	}
}
}