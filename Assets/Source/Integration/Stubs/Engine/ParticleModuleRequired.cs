namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRequired : ParticleModule/*
		native
		editinlinenew
		hidecategories(Object,Object,Cascade)*/{
	[Category("Emitter")] public MaterialInterface Material;
	[Category("Emitter")] public ParticleSpriteEmitter.EParticleScreenAlignment ScreenAlignment;
	public ParticleEmitter.EParticleBurstMethod ParticleBurstMethod;
	[Category("SubUV")] public ParticleEmitter.EParticleSubUVInterpMethod InterpolationMethod;
	[Category("Cascade")] public ParticleEmitter.EEmitterRenderMode EmitterRenderMode;
	[Category("Emitter")] public bool bUseLocalSpace;
	[Category("Emitter")] public bool bKillOnDeactivate;
	[Category("Emitter")] public bool bKillOnCompleted;
	[Category("Emitter")] public bool bRequiresSorting;
	[Category("Duration")] public bool bEmitterDurationUseRange;
	[Category("Duration")] public bool bDurationRecalcEachLoop;
	[Category("delay")] public bool bDelayFirstLoopOnly;
	[Category("SubUV")] public bool bScaleUV;
	public bool bDirectUV;
	[Category("Rendering")] public bool bUseMaxDrawCount;
	[Category("Duration")] public float EmitterDuration;
	[Category("Duration")] public float EmitterDurationLow;
	[Category("Duration")] public int EmitterLoops;
	public DistributionFloat.RawDistributionFloat SpawnRate;
	[noclear, export] public array</*export */ParticleEmitter.ParticleBurst> BurstList;
	[Category("delay")] public float EmitterDelay;
	[Category("SubUV")] public int SubImages_Horizontal;
	[Category("SubUV")] public int SubImages_Vertical;
	public float RandomImageTime;
	[Category("SubUV")] public int RandomImageChanges;
	[Category("Rendering")] public int MaxDrawCount;
	[Category("Cascade")] public Object.Color EmitterEditorColor;
	
	public ParticleModuleRequired()
	{
		var Default__ParticleModuleRequired_RequiredDistributionSpawnRate = new DistributionFloatConstant
		{
		}/* Reference: DistributionFloatConstant'Default__ParticleModuleRequired.RequiredDistributionSpawnRate' */;
		// Object Offset:0x00380EA7
		bUseMaxDrawCount = true;
		EmitterDuration = 1.0f;
		SpawnRate = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__ParticleModuleRequired_RequiredDistributionSpawnRate/*Ref DistributionFloatConstant'Default__ParticleModuleRequired.RequiredDistributionSpawnRate'*/,
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
		SubImages_Horizontal = 1;
		SubImages_Vertical = 1;
		MaxDrawCount = 500;
		bSpawnModule = true;
		bUpdateModule = true;
		IdenticalIgnoreProperties = new array<name>
		{
			(name)"bSpawnModule",
			(name)"bUpdateModule",
			(name)"bCurvesAsColor",
			(name)"b3DDrawMode",
			(name)"bSupported3DDrawMode",
			(name)"bEditable",
			(name)"ModuleEditorColor",
			(name)"IdenticalIgnoreProperties",
			(name)"LODValidity",
			(name)"SpawnRate",
			(name)"ParticleBurstMethod",
			(name)"BurstList",
		};
	}
}
}