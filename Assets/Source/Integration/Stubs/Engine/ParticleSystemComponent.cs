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
		public/*()*/ name Name;
		public/*()*/ ParticleSystemComponent.EParticleSysParamType ParamType;
		public/*()*/ float Scalar;
		public/*()*/ Object.Vector Vector;
		public/*()*/ Object.Color Color;
		public/*()*/ Actor Actor;
		public/*()*/ MaterialInterface Material;
	
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
	
	public/*()*/ /*const */ParticleSystem Template;
	public /*native const transient */array<Object.Pointer> EmitterInstances;
	public /*private duplicatetransient const transient */array</*export editinline */StaticMeshComponent> SMComponents;
	public /*private duplicatetransient const transient */array<MaterialInterface> SMMaterialInterfaces;
	public/*()*/ bool bAutoActivate;
	public /*const */bool bWasCompleted;
	public /*const */bool bSuppressSpawning;
	public /*const */bool bWasDeactivated;
	public/*()*/ bool bResetOnDetach;
	public bool bUpdateOnDedicatedServer;
	public bool bJustAttached;
	public /*transient */bool bIsActive;
	public bool bWarmingUp;
	public bool bIsCachedInPool;
	public/*(LOD)*/ bool bOverrideLODMethod;
	public bool bSkipUpdateDynamicDataDuringTick;
	public bool bUpdateComponentInTick;
	public bool bDeferredBeamUpdate;
	public /*transient */bool bForcedInActive;
	public /*transient */bool bIsWarmingUp;
	public /*transient */bool bIsViewRelevanceDirty;
	public/*()*/ /*editinline */array</*editinline */ParticleSystemComponent.ParticleSysParam> InstanceParameters;
	public Object.Vector OldPosition;
	public Object.Vector PartSysVelocity;
	public float WarmupTime;
	public int LODLevel;
	public/*()*/ float SecondsBeforeInactive;
	public int EditorLODLevel;
	public /*transient */float AccumTickTime;
	public/*(LOD)*/ ParticleSystem.ParticleSystemLODMethod LODMethod;
	public /*const transient */array<PrimitiveComponent.MaterialViewRelevance> CachedViewRelevanceFlags;
	public /*delegate*/ParticleSystemComponent.OnSystemFinished __OnSystemFinished__Delegate;
	
	public delegate void OnSystemFinished(ParticleSystemComponent PSystem);
	
	// Export UParticleSystemComponent::execSetTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetTemplate(ParticleSystem NewTemplate)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execActivateSystem(FFrame&, void* const)
	public virtual /*native final function */void ActivateSystem(/*optional */bool? _bFlagAsJustAttached = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execDeactivateSystem(FFrame&, void* const)
	public virtual /*native final function */void DeactivateSystem()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execKillParticlesForced(FFrame&, void* const)
	public virtual /*native final function */void KillParticlesForced()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetSkipUpdateDynamicDataDuringTick(FFrame&, void* const)
	public virtual /*native final function */void SetSkipUpdateDynamicDataDuringTick(bool bInSkipUpdateDynamicDataDuringTick)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execGetSkipUpdateDynamicDataDuringTick(FFrame&, void* const)
	public virtual /*native final function */bool GetSkipUpdateDynamicDataDuringTick()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execSetKillOnDeactivate(FFrame&, void* const)
	public virtual /*native function */void SetKillOnDeactivate(int EmitterIndex, bool bKill)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetKillOnCompleted(FFrame&, void* const)
	public virtual /*native function */void SetKillOnCompleted(int EmitterIndex, bool bKill)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execRewindEmitterInstance(FFrame&, void* const)
	public virtual /*native function */void RewindEmitterInstance(int EmitterIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execRewindEmitterInstances(FFrame&, void* const)
	public virtual /*native function */void RewindEmitterInstances()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamType(FFrame&, void* const)
	public virtual /*native function */void SetBeamType(int EmitterIndex, int NewMethod)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTessellationFactor(FFrame&, void* const)
	public virtual /*native function */void SetBeamTessellationFactor(int EmitterIndex, float NewFactor)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamEndPoint(FFrame&, void* const)
	public virtual /*native function */void SetBeamEndPoint(int EmitterIndex, Object.Vector NewEndPoint)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamDistance(FFrame&, void* const)
	public virtual /*native function */void SetBeamDistance(int EmitterIndex, float Distance)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamSourcePoint(FFrame&, void* const)
	public virtual /*native function */void SetBeamSourcePoint(int EmitterIndex, Object.Vector NewSourcePoint, int SourceIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamSourceTangent(FFrame&, void* const)
	public virtual /*native function */void SetBeamSourceTangent(int EmitterIndex, Object.Vector NewTangentPoint, int SourceIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamSourceStrength(FFrame&, void* const)
	public virtual /*native function */void SetBeamSourceStrength(int EmitterIndex, float NewSourceStrength, int SourceIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTargetPoint(FFrame&, void* const)
	public virtual /*native function */void SetBeamTargetPoint(int EmitterIndex, Object.Vector NewTargetPoint, int TargetIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTargetTangent(FFrame&, void* const)
	public virtual /*native function */void SetBeamTargetTangent(int EmitterIndex, Object.Vector NewTangentPoint, int TargetIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetBeamTargetStrength(FFrame&, void* const)
	public virtual /*native function */void SetBeamTargetStrength(int EmitterIndex, float NewTargetStrength, int TargetIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetLODLevel(FFrame&, void* const)
	public virtual /*native final function */void SetLODLevel(int InLODLevel)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetEditorLODLevel(FFrame&, void* const)
	public virtual /*native final function */void SetEditorLODLevel(int InLODLevel)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execGetLODLevel(FFrame&, void* const)
	public virtual /*native final function */int GetLODLevel()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetEditorLODLevel(FFrame&, void* const)
	public virtual /*native final function */int GetEditorLODLevel()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execSetFloatParameter(FFrame&, void* const)
	public virtual /*native final function */void SetFloatParameter(name ParameterName, float Param)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetVectorParameter(FFrame&, void* const)
	public virtual /*native final function */void SetVectorParameter(name ParameterName, Object.Vector Param)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetColorParameter(FFrame&, void* const)
	public virtual /*native final function */void SetColorParameter(name ParameterName, Object.Color Param)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetActorParameter(FFrame&, void* const)
	public virtual /*native final function */void SetActorParameter(name ParameterName, Actor Param)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetMaterialParameter(FFrame&, void* const)
	public virtual /*native final function */void SetMaterialParameter(name ParameterName, MaterialInterface Param)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execGetFloatParameter(FFrame&, void* const)
	public virtual /*native function */bool GetFloatParameter(/*const */name InName, ref float OutFloat)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetVectorParameter(FFrame&, void* const)
	public virtual /*native function */bool GetVectorParameter(/*const */name InName, ref Object.Vector OutVector)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetColorParameter(FFrame&, void* const)
	public virtual /*native function */bool GetColorParameter(/*const */name InName, ref Object.Color OutColor)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetActorParameter(FFrame&, void* const)
	public virtual /*native function */bool GetActorParameter(/*const */name InName, ref Actor OutActor)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execGetMaterialParameter(FFrame&, void* const)
	public virtual /*native function */bool GetMaterialParameter(/*const */name InName, ref MaterialInterface OutMaterial)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UParticleSystemComponent::execClearParameter(FFrame&, void* const)
	public virtual /*native final function */void ClearParameter(name ParameterName, /*optional */ParticleSystemComponent.EParticleSysParamType? _ParameterType = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execSetActive(FFrame&, void* const)
	public virtual /*native final function */void SetActive(bool bNowActive)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UParticleSystemComponent::execResetToDefaults(FFrame&, void* const)
	public virtual /*native final function */void ResetToDefaults()
	{
		 // #warning NATIVE FUNCTION !
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