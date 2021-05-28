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
		public/*()*/ int Count;
		public/*()*/ int CountLow;
		public/*()*/ float Time;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0037809A
	//		Count = 0;
	//		CountLow = -1;
	//		Time = 0.0f;
	//	}
	};
	
	public/*(Particle)*/ name EmitterName;
	public /*deprecated */bool UseLocalSpace;
	public /*deprecated */bool KillOnDeactivate;
	public /*deprecated */bool bKillOnCompleted;
	public /*deprecated */bool ScaleUV;
	public /*deprecated */bool DirectUV;
	public /*deprecated */bool bEnabled;
	public bool ConvertedModules;
	public /*deprecated */DistributionFloat.RawDistributionFloat SpawnRate;
	public /*deprecated */float EmitterDuration;
	public /*deprecated */int EmitterLoops;
	public /*deprecated */ParticleEmitter.EParticleBurstMethod ParticleBurstMethod;
	public /*deprecated */ParticleEmitter.EParticleSubUVInterpMethod InterpolationMethod;
	public /*deprecated */ParticleEmitter.EEmitterRenderMode EmitterRenderMode;
	public /*noclear export deprecated */array</*export */ParticleEmitter.ParticleBurst> BurstList;
	public /*deprecated */int SubImages_Horizontal;
	public /*deprecated */int SubImages_Vertical;
	public /*deprecated */float RandomImageTime;
	public /*deprecated */int RandomImageChanges;
	public /*transient */int SubUVDataOffset;
	public /*deprecated */Object.Color EmitterEditorColor;
	public /*export editinline */array</*export editinline */ParticleLODLevel> LODLevels;
	public /*export editinline */array</*export editinline */ParticleModule> Modules;
	public /*export */ParticleModule TypeDataModule;
	public /*native */array<ParticleModule> SpawnModules;
	public /*native */array<ParticleModule> UpdateModules;
	public int PeakActiveParticles;
	public/*(Particle)*/ int InitialAllocationCount;
	
	public ParticleEmitter()
	{
		// Object Offset:0x003781AE
		EmitterName = (name)"Particle Emitter";
		ConvertedModules = true;
	}
}
}