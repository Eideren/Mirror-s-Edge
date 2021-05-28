namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleTypeDataPhysX : ParticleModuleTypeDataBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public partial struct /*native */PhysXEmitterVerticalLodProperties
	{
		public/*()*/ float WeightForFifo;
		public/*()*/ float WeightForSpawnLod;
		public/*()*/ float SpawnLodRateVsLifeBias;
		public/*()*/ float RelativeFadeoutTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00385106
	//		WeightForFifo = 1.0f;
	//		WeightForSpawnLod = 1.0f;
	//		SpawnLodRateVsLifeBias = 1.0f;
	//		RelativeFadeoutTime = 0.0f;
	//	}
	};
	
	public/*(PhysXEmitter)*/ PhysXParticleSystem PhysXParSys;
	public/*(PhysXEmitter)*/ ParticleModuleTypeDataPhysX.PhysXEmitterVerticalLodProperties VerticalLod;
	
	public ParticleModuleTypeDataPhysX()
	{
		// Object Offset:0x0038544D
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