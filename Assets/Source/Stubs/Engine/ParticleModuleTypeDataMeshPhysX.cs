namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataMeshPhysX : ParticleModuleTypeDataMesh/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object,Object)*/{
	public enum EPhysXMeshRotationMethod 
	{
		PMRM_Disabled,
		PMRM_Spherical,
		PMRM_Box,
		PMRM_LongBox,
		PMRM_FlatBox,
		PMRM_Velocity,
		PMRM_MAX
	};
	
	public/*(PhysXEmitter)*/ PhysXParticleSystem PhysXParSys;
	public/*(PhysXEmitter)*/ ParticleModuleTypeDataMeshPhysX.EPhysXMeshRotationMethod PhysXRotationMethod;
	public/*(PhysXEmitter)*/ float FluidRotationCoefficient;
	public /*native */Object.Pointer RenderInstance;
	public/*(PhysXEmitter)*/ ParticleModuleTypeDataPhysX.PhysXEmitterVerticalLodProperties VerticalLod;
	
	public ParticleModuleTypeDataMeshPhysX()
	{
		// Object Offset:0x003852EA
		PhysXRotationMethod = ParticleModuleTypeDataMeshPhysX.EPhysXMeshRotationMethod.PMRM_Spherical;
		FluidRotationCoefficient = 5.0f;
		VerticalLod = new ParticleModuleTypeDataPhysX.PhysXEmitterVerticalLodProperties
		{
			WeightForFifo = 1.0f,
			WeightForSpawnLod = 1.0f,
			SpawnLodRateVsLifeBias = 1.0f,
			RelativeFadeoutTime = 0.0f,
		};
	}
}
}