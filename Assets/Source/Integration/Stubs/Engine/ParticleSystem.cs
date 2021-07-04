namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleSystem : Object/*
		native
		hidecategories(Object)*/{
	public enum EParticleSystemUpdateMode 
	{
		EPSUM_RealTime,
		EPSUM_FixedTime,
		EPSUM_MAX
	};
	
	public enum ParticleSystemLODMethod 
	{
		PARTICLESYSTEMLODMETHOD_Automatic,
		PARTICLESYSTEMLODMETHOD_DirectSet,
		PARTICLESYSTEMLODMETHOD_MAX
	};
	
	public/*()*/ ParticleSystem.EParticleSystemUpdateMode SystemUpdateMode;
	public/*(LOD)*/ ParticleSystem.ParticleSystemLODMethod LODMethod;
	public/*()*/ float UpdateTime_FPS;
	public float UpdateTime_Delta;
	public/*()*/ float WarmupTime;
	public /*export editinline */array</*export editinline */ParticleEmitter> Emitters;
	public /*export editinline transient */ParticleSystemComponent PreviewComponent;
	public Object.Rotator ThumbnailAngle;
	public float ThumbnailDistance;
	public/*(Thumbnail)*/ float ThumbnailWarmup;
	public bool bLit;
	public bool bRegenerateLODDuplicate;
	public/*(Bounds)*/ bool bUseFixedRelativeBoundingBox;
	public bool bShouldResetPeakCounts;
	public /*transient */bool bHasPhysics;
	public/*(Thumbnail)*/ bool bUseRealtimeThumbnail;
	public bool ThumbnailImageOutOfDate;
	public /*export */InterpCurveEdSetup CurveEdSetup;
	public/*(LOD)*/ float LODDistanceCheckTime;
	public/*(LOD)*/ /*editfixedsize */array<float> LODDistances;
	public int EditorLODSetting;
	public/*(Bounds)*/ Object.Box FixedRelativeBoundingBox;
	public/*()*/ float SecondsBeforeInactive;
	public String FloorMesh;
	public Object.Vector FloorPosition;
	public Object.Rotator FloorRotation;
	public float FloorScale;
	public Object.Vector FloorScale3D;
	public Texture2D ThumbnailImage;
	
	// Export UParticleSystem::execGetCurrentLODMethod(FFrame&, void* const)
	public virtual /*native function */ParticleSystem.ParticleSystemLODMethod GetCurrentLODMethod()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystem::execGetLODLevelCount(FFrame&, void* const)
	public virtual /*native function */int GetLODLevelCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystem::execGetLODDistance(FFrame&, void* const)
	public virtual /*native function */float GetLODDistance(int LODLevelIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystem::execSetCurrentLODMethod(FFrame&, void* const)
	public virtual /*native function */void SetCurrentLODMethod(ParticleSystem.ParticleSystemLODMethod InMethod)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystem::execSetLODDistance(FFrame&, void* const)
	public virtual /*native function */bool SetLODDistance(int LODLevelIndex, float InDistance)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public ParticleSystem()
	{
		// Object Offset:0x0038B91E
		UpdateTime_FPS = 60.0f;
		UpdateTime_Delta = 1.0f;
		ThumbnailDistance = 200.0f;
		ThumbnailWarmup = 1.0f;
		bLit = true;
		ThumbnailImageOutOfDate = true;
		LODDistanceCheckTime = 5.0f;
		FixedRelativeBoundingBox = new Box
		{
			Min={X=-1.0f,
			Y=-1.0f,
			Z=-1.0f},
			Max={X=1.0f,
			Y=1.0f,
			Z=1.0f},
			IsValid=0
		};
		FloorMesh = "EditorMeshes.AnimTreeEd_PreviewFloor";
		FloorScale = 1.0f;
		FloorScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
	}
}
}