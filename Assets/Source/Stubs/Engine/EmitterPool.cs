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
	
	}
	
	// Export UEmitterPool::execReturnToPool(FFrame&, void* const)
	public virtual /*protected native final function */void ReturnToPool(ParticleSystemComponent PSC)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UEmitterPool::execFreeStaticMeshComponents(FFrame&, void* const)
	public virtual /*protected native final function */void FreeStaticMeshComponents(ParticleSystemComponent PSC)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UEmitterPool::execGetFreeStaticMeshComponent(FFrame&, void* const)
	public virtual /*protected native final function */StaticMeshComponent GetFreeStaticMeshComponent(/*optional */bool bCreateNewObject = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEmitterPool::execFreeMaterialInstanceConstants(FFrame&, void* const)
	public virtual /*protected native final function */void FreeMaterialInstanceConstants(StaticMeshComponent SMC)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UEmitterPool::execGetFreeMatInstConsts(FFrame&, void* const)
	public virtual /*protected native final function */MaterialInstanceConstant GetFreeMatInstConsts(/*optional */bool bCreateNewObject = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEmitterPool::execGetPooledComponent(FFrame&, void* const)
	public virtual /*protected native final function */ParticleSystemComponent GetPooledComponent(ParticleSystem EmitterTemplate)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */ParticleSystemComponent SpawnEmitter(ParticleSystem EmitterTemplate, Object.Vector SpawnLocation, /*optional */Object.Rotator SpawnRotation = default, /*optional */Actor AttachToActor = default)
	{
	
		return default;
	}
	
	public virtual /*function */void ResetPool()
	{
	
	}
	
	public virtual /*function */ParticleSystemComponent SpawnEmitterCustomLifetime(ParticleSystem EmitterTemplate)
	{
	
		return default;
	}
	
	public EmitterPool()
	{
		// Object Offset:0x00317B7C
		PSCTemplate = new ParticleSystemComponent
		{
			// Object Offset:0x004CAC02
			AbsoluteTranslation = true,
			AbsoluteRotation = true,
		}/* Reference: ParticleSystemComponent'Default__EmitterPool.ParticleSystemComponent0' */;
		SMC_MIC_ReductionTime = 2.50f;
		IdealStaticMeshComponents = 250;
		IdealMaterialInstanceConstants = 250;
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}