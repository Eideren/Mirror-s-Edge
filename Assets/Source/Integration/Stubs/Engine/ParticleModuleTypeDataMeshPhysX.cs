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
	
	[Category("PhysXEmitter")] public PhysXParticleSystem PhysXParSys;
	[Category("PhysXEmitter")] public ParticleModuleTypeDataMeshPhysX.EPhysXMeshRotationMethod PhysXRotationMethod;
	[Category("PhysXEmitter")] public float FluidRotationCoefficient;
	[native] public Object.Pointer RenderInstance;
	[Category("PhysXEmitter")] public ParticleModuleTypeDataPhysX.PhysXEmitterVerticalLodProperties VerticalLod;
	
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