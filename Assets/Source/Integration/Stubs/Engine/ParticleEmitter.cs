namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleEmitter : Object/*
		abstract
		native
		editinlinenew
		hidecategories(Object)*/{
	public enum EParticleBurstMethod 
	{
		EPBM_Instant,
		EPBM_Interpolated,
		EPBM_MAX
	};
	
	public enum EParticleSubUVInterpMethod 
	{
		PSUVIM_None,
		PSUVIM_Linear,
		PSUVIM_Linear_Blend,
		PSUVIM_Random,
		PSUVIM_Random_Blend,
		PSUVIM_MAX
	};
	
	public enum EEmitterRenderMode 
	{
		ERM_Normal,
		ERM_Point,
		ERM_Cross,
		ERM_None,
		ERM_MAX
	};
	
	public partial struct /*native */ParticleBurst
	{
		[Category] public int Count;
		[Category] public int CountLow;
		[Category] public float Time;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0037809A
	//		Count = 0;
	//		CountLow = -1;
	//		Time = 0.0f;
	//	}
	};
	
	[Category("Particle")] public name EmitterName;
	[deprecated] public bool UseLocalSpace;
	[deprecated] public bool KillOnDeactivate;
	[deprecated] public bool bKillOnCompleted;
	[deprecated] public bool ScaleUV;
	[deprecated] public bool DirectUV;
	[deprecated] public bool bEnabled;
	public bool ConvertedModules;
	[deprecated] public DistributionFloat.RawDistributionFloat SpawnRate;
	[deprecated] public float EmitterDuration;
	[deprecated] public int EmitterLoops;
	[deprecated] public ParticleEmitter.EParticleBurstMethod ParticleBurstMethod;
	[deprecated] public ParticleEmitter.EParticleSubUVInterpMethod InterpolationMethod;
	[deprecated] public ParticleEmitter.EEmitterRenderMode EmitterRenderMode;
	[noclear, export, deprecated] public array</*export */ParticleEmitter.ParticleBurst> BurstList;
	[deprecated] public int SubImages_Horizontal;
	[deprecated] public int SubImages_Vertical;
	[deprecated] public float RandomImageTime;
	[deprecated] public int RandomImageChanges;
	[transient] public int SubUVDataOffset;
	[deprecated] public Object.Color EmitterEditorColor;
	[export, editinline] public array</*export editinline */ParticleLODLevel> LODLevels;
	[export, editinline] public array</*export editinline */ParticleModule> Modules;
	[export] public ParticleModule TypeDataModule;
	[native] public array<ParticleModule> SpawnModules;
	[native] public array<ParticleModule> UpdateModules;
	public int PeakActiveParticles;
	[Category("Particle")] public int InitialAllocationCount;
	
	public ParticleEmitter()
	{
		// Object Offset:0x003781AE
		EmitterName = (name)"Particle Emitter";
		ConvertedModules = true;
	}
}
}