namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleLODLevel : Object/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Const] public int Level;
	[Const, deprecated] public int LevelSetting;
	public bool bEnabled;
	public bool ConvertedModules;
	[export, editinline] public ParticleModuleRequired RequiredModule;
	[export, editinline] public array</*export editinline */ParticleModule> Modules;
	[export] public ParticleModule TypeDataModule;
	[export] public ParticleModuleSpawn SpawnModule;
	[native] public array<ParticleModuleSpawnBase> SpawningModules;
	[native] public array<ParticleModule> SpawnModules;
	[native] public array<ParticleModule> UpdateModules;
	[native] public array<ParticleModuleOrbit> OrbitModules;
	public int PeakActiveParticles;
	
	public ParticleLODLevel()
	{
		// Object Offset:0x003785B9
		bEnabled = true;
		ConvertedModules = true;
	}
}
}