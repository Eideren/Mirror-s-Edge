namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleSystemComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object,Physics,Collision)*/{
	public enum EParticleSysParamType 
	{
		PSPT_None,
		PSPT_Scalar,
		PSPT_Vector,
		PSPT_Color,
		PSPT_Actor,
		PSPT_Material,
		PSPT_MAX
	};
	
	public partial struct ParticleEmitterInstance
	{
	};
	
	public partial struct /*native */ParticleSysParam
	{
		[Category] public name Name;
		[Category] public ParticleSystemComponent.EParticleSysParamType ParamType;
		[Category] public float Scalar;
		[Category] public Object.Vector Vector;
		[Category] public Object.Color Color;
		[Category] public Actor Actor;
		[Category] public MaterialInterface Material;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00314680
	//		Name = (name)"None";
	//		ParamType = ParticleSystemComponent.EParticleSysParamType.PSPT_None;
	//		Scalar = 0.0f;
	//		Vector = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Color = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		Actor = default;
	//		Material = default;
	//	}
	};
	
	[Category] [Const] public ParticleSystem Template;
	[native, Const, transient] public array<Object.Pointer> EmitterInstances;
	[duplicatetransient, Const, transient] public/*private*/ array</*export editinline */StaticMeshComponent> SMComponents;
	[duplicatetransient, Const, transient] public/*private*/ array<MaterialInterface> SMMaterialInterfaces;
	[Category] public bool bAutoActivate;
	[Const] public bool bWasCompleted;
	[Const] public bool bSuppressSpawning;
	[Const] public bool bWasDeactivated;
	[Category] public bool bResetOnDetach;
	public bool bUpdateOnDedicatedServer;
	public bool bJustAttached;
	[transient] public bool bIsActive;
	public bool bWarmingUp;
	public bool bIsCachedInPool;
	[Category("LOD")] public bool bOverrideLODMethod;
	public bool bSkipUpdateDynamicDataDuringTick;
	public bool bUpdateComponentInTick;
	public bool bDeferredBeamUpdate;
	[transient] public bool bForcedInActive;
	[transient] public bool bIsWarmingUp;
	[transient] public bool bIsViewRelevanceDirty;
	[Category] [editinline] public array</*editinline */ParticleSystemComponent.ParticleSysParam> InstanceParameters;
	public Object.Vector OldPosition;
	public Object.Vector PartSysVelocity;
	public float WarmupTime;
	public int LODLevel;
	[Category] public float SecondsBeforeInactive;
	public int EditorLODLevel;
	[transient] public float AccumTickTime;
	[Category("LOD")] public ParticleSystem.ParticleSystemLODMethod LODMethod;
	[Const, transient] public array<PrimitiveComponent.MaterialViewRelevance> CachedViewRelevanceFlags;
	public /*delegate*/ParticleSystemComponent.OnSystemFinished __OnSystemFinished__Delegate;
	
	public delegate void OnSystemFinished(ParticleSystemComponent PSystem);
	
	// Export UParticleSystemComponent::execSetTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetTemplate(ParticleSystem NewTemplate)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execActivateSystem(FFrame&, void* const)
	public virtual /*native final function */void ActivateSystem(/*optional */bool? _bFlagAsJustAttached = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execDeactivateSystem(FFrame&, void* const)
	public virtual /*native final function */void DeactivateSystem()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execKillParticlesForced(FFrame&, void* const)
	public virtual /*native final function */void KillParticlesForced()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetSkipUpdateDynamicDataDuringTick(FFrame&, void* const)
	public virtual /*native final function */void SetSkipUpdateDynamicDataDuringTick(bool bInSkipUpdateDynamicDataDuringTick)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execGetSkipUpdateDynamicDataDuringTick(FFrame&, void* const)
	public virtual /*native final function */bool GetSkipUpdateDynamicDataDuringTick()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execSetKillOnDeactivate(FFrame&, void* const)
	public virtual /*native function */void SetKillOnDeactivate(int EmitterIndex, bool bKill)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetKillOnCompleted(FFrame&, void* const)
	public virtual /*native function */void SetKillOnCompleted(int EmitterIndex, bool bKill)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execRewindEmitterInstance(FFrame&, void* const)
	public virtual /*native function */void RewindEmitterInstance(int EmitterIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execRewindEmitterInstances(FFrame&, void* const)
	public virtual /*native function */void RewindEmitterInstances()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamType(FFrame&, void* const)
	public virtual /*native function */void SetBeamType(int EmitterIndex, int NewMethod)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTessellationFactor(FFrame&, void* const)
	public virtual /*native function */void SetBeamTessellationFactor(int EmitterIndex, float NewFactor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamEndPoint(FFrame&, void* const)
	public virtual /*native function */void SetBeamEndPoint(int EmitterIndex, Object.Vector NewEndPoint)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamDistance(FFrame&, void* const)
	public virtual /*native function */void SetBeamDistance(int EmitterIndex, float Distance)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamSourcePoint(FFrame&, void* const)
	public virtual /*native function */void SetBeamSourcePoint(int EmitterIndex, Object.Vector NewSourcePoint, int SourceIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamSourceTangent(FFrame&, void* const)
	public virtual /*native function */void SetBeamSourceTangent(int EmitterIndex, Object.Vector NewTangentPoint, int SourceIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamSourceStrength(FFrame&, void* const)
	public virtual /*native function */void SetBeamSourceStrength(int EmitterIndex, float NewSourceStrength, int SourceIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTargetPoint(FFrame&, void* const)
	public virtual /*native function */void SetBeamTargetPoint(int EmitterIndex, Object.Vector NewTargetPoint, int TargetIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTargetTangent(FFrame&, void* const)
	public virtual /*native function */void SetBeamTargetTangent(int EmitterIndex, Object.Vector NewTangentPoint, int TargetIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTargetStrength(FFrame&, void* const)
	public virtual /*native function */void SetBeamTargetStrength(int EmitterIndex, float NewTargetStrength, int TargetIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetLODLevel(FFrame&, void* const)
	public virtual /*native final function */void SetLODLevel(int InLODLevel)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetEditorLODLevel(FFrame&, void* const)
	public virtual /*native final function */void SetEditorLODLevel(int InLODLevel)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execGetLODLevel(FFrame&, void* const)
	public virtual /*native final function */int GetLODLevel()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetEditorLODLevel(FFrame&, void* const)
	public virtual /*native final function */int GetEditorLODLevel()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execSetFloatParameter(FFrame&, void* const)
	public virtual /*native final function */void SetFloatParameter(name ParameterName, float Param)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetVectorParameter(FFrame&, void* const)
	public virtual /*native final function */void SetVectorParameter(name ParameterName, Object.Vector Param)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetColorParameter(FFrame&, void* const)
	public virtual /*native final function */void SetColorParameter(name ParameterName, Object.Color Param)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetActorParameter(FFrame&, void* const)
	public virtual /*native final function */void SetActorParameter(name ParameterName, Actor Param)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetMaterialParameter(FFrame&, void* const)
	public virtual /*native final function */void SetMaterialParameter(name ParameterName, MaterialInterface Param)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execGetFloatParameter(FFrame&, void* const)
	public virtual /*native function */bool GetFloatParameter(/*const */name InName, ref float OutFloat)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetVectorParameter(FFrame&, void* const)
	public virtual /*native function */bool GetVectorParameter(/*const */name InName, ref Object.Vector OutVector)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetColorParameter(FFrame&, void* const)
	public virtual /*native function */bool GetColorParameter(/*const */name InName, ref Object.Color OutColor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetActorParameter(FFrame&, void* const)
	public virtual /*native function */bool GetActorParameter(/*const */name InName, ref Actor OutActor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetMaterialParameter(FFrame&, void* const)
	public virtual /*native function */bool GetMaterialParameter(/*const */name InName, ref MaterialInterface OutMaterial)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execClearParameter(FFrame&, void* const)
	public virtual /*native final function */void ClearParameter(name ParameterName, /*optional */ParticleSystemComponent.EParticleSysParamType? _ParameterType = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execSetActive(FFrame&, void* const)
	public virtual /*native final function */void SetActive(bool bNowActive)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UParticleSystemComponent::execResetToDefaults(FFrame&, void* const)
	public virtual /*native final function */void ResetToDefaults()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public ParticleSystemComponent()
	{
		// Object Offset:0x00315DC2
		bAutoActivate = true;
		bIsViewRelevanceDirty = true;
		bTickInEditor = true;
	}
}
}