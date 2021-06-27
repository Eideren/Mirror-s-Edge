namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleRequired : ParticleModule/*
		native
		editinlinenew
		hidecategories(Object,Object,Cascade)*/{
	public/*(Emitter)*/ MaterialInterface Material;
	public/*(Emitter)*/ ParticleSpriteEmitter.EParticleScreenAlignment ScreenAlignment;
	public ParticleEmitter.EParticleBurstMethod ParticleBurstMethod;
	public/*(SubUV)*/ ParticleEmitter.EParticleSubUVInterpMethod InterpolationMethod;
	public/*(Cascade)*/ ParticleEmitter.EEmitterRenderMode EmitterRenderMode;
	public/*(Emitter)*/ bool bUseLocalSpace;
	public/*(Emitter)*/ bool bKillOnDeactivate;
	public/*(Emitter)*/ bool bKillOnCompleted;
	public/*(Emitter)*/ bool bRequiresSorting;
	public/*(Duration)*/ bool bEmitterDurationUseRange;
	public/*(Duration)*/ bool bDurationRecalcEachLoop;
	public/*(delay)*/ bool bDelayFirstLoopOnly;
	public/*(SubUV)*/ bool bScaleUV;
	public bool bDirectUV;
	public/*(Rendering)*/ bool bUseMaxDrawCount;
	public/*(Duration)*/ float EmitterDuration;
	public/*(Duration)*/ float EmitterDurationLow;
	public/*(Duration)*/ int EmitterLoops;
	public DistributionFloat.RawDistributionFloat SpawnRate;
	public /*noclear export */array</*export */ParticleEmitter.ParticleBurst> BurstList;
	public/*(delay)*/ float EmitterDelay;
	public/*(SubUV)*/ int SubImages_Horizontal;
	public/*(SubUV)*/ int SubImages_Vertical;
	public float RandomImageTime;
	public/*(SubUV)*/ int RandomImageChanges;
	public/*(Rendering)*/ int MaxDrawCount;
	public/*(Cascade)*/ Object.Color EmitterEditorColor;
	
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
			Distribution = LoadAsset<DistributionFloatConstant>("Default__ParticleModuleRequired.RequiredDistributionSpawnRate")/*Ref DistributionFloatConstant'Default__ParticleModuleRequired.RequiredDistributionSpawnRate'*/,
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