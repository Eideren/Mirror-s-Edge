namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EmitterPool : Actor/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct /*native */EmitterBaseInfo
	{
		public /*export editinline */ParticleSystemComponent PSC;
		public Actor Base;
		public Object.Vector RelativeLocation;
		public Object.Rotator RelativeRotation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00317207
	//		PSC = default;
	//		Base = default;
	//		RelativeLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RelativeRotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//	}
	};
	
	public /*protected export editinline */ParticleSystemComponent PSCTemplate;
	public /*const export editinline */array</*export editinline */ParticleSystemComponent> PoolComponents;
	public /*export editinline */array</*export editinline */ParticleSystemComponent> ActiveComponents;
	public /*config */int MaxActiveEffects;
	public /*globalconfig */bool bLogPoolOverflow;
	public /*globalconfig */bool bLogPoolOverflowList;
	public array<EmitterPool.EmitterBaseInfo> RelativePSCs;
	public float SMC_MIC_ReductionTime;
	public /*transient */float SMC_MIC_CurrentReductionTime;
	public int IdealStaticMeshComponents;
	public int IdealMaterialInstanceConstants;
	public /*private const export editinline */array</*export editinline */StaticMeshComponent> FreeSMComponents;
	public /*private const */array<MaterialInstanceConstant> FreeMatInstConsts;
	
	public virtual /*function */void OnParticleSystemFinished(ParticleSystemComponent PSC)
	{
		// stub
	}
	
	// Export UEmitterPool::execReturnToPool(FFrame&, void* const)
	public virtual /*protected native final function */void ReturnToPool(ParticleSystemComponent PSC)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UEmitterPool::execFreeStaticMeshComponents(FFrame&, void* const)
	public virtual /*protected native final function */void FreeStaticMeshComponents(ParticleSystemComponent PSC)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UEmitterPool::execGetFreeStaticMeshComponent(FFrame&, void* const)
	public virtual /*protected native final function */StaticMeshComponent GetFreeStaticMeshComponent(/*optional */bool? _bCreateNewObject = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UEmitterPool::execFreeMaterialInstanceConstants(FFrame&, void* const)
	public virtual /*protected native final function */void FreeMaterialInstanceConstants(StaticMeshComponent SMC)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UEmitterPool::execGetFreeMatInstConsts(FFrame&, void* const)
	public virtual /*protected native final function */MaterialInstanceConstant GetFreeMatInstConsts(/*optional */bool? _bCreateNewObject = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UEmitterPool::execGetPooledComponent(FFrame&, void* const)
	public virtual /*protected native final function */ParticleSystemComponent GetPooledComponent(ParticleSystem EmitterTemplate)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*function */ParticleSystemComponent SpawnEmitter(ParticleSystem EmitterTemplate, Object.Vector SpawnLocation, /*optional */Object.Rotator? _SpawnRotation = default, /*optional */Actor _AttachToActor = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ResetPool()
	{
		// stub
	}
	
	public virtual /*function */ParticleSystemComponent SpawnEmitterCustomLifetime(ParticleSystem EmitterTemplate)
	{
		// stub
		return default;
	}
	
	public EmitterPool()
	{
		var Default__EmitterPool_ParticleSystemComponent0 = new ParticleSystemComponent
		{
			// Object Offset:0x004CAC02
			AbsoluteTranslation = true,
			AbsoluteRotation = true,
		}/* Reference: ParticleSystemComponent'Default__EmitterPool.ParticleSystemComponent0' */;
		// Object Offset:0x00317B7C
		PSCTemplate = Default__EmitterPool_ParticleSystemComponent0/*Ref ParticleSystemComponent'Default__EmitterPool.ParticleSystemComponent0'*/;
		SMC_MIC_ReductionTime = 2.50f;
		IdealStaticMeshComponents = 250;
		IdealMaterialInstanceConstants = 250;
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}