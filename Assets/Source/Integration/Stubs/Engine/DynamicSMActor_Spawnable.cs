namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicSMActor_Spawnable : DynamicSMActor/*
		notplaceable
		hidecategories(Navigation)*/{
	public DynamicSMActor_Spawnable()
	{
		var Default__DynamicSMActor_Spawnable_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment' */;
		var Default__DynamicSMActor_Spawnable_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x005797E2
			LightEnvironment = Default__DynamicSMActor_Spawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/,
		}/* Reference: StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0' */;
		// Object Offset:0x00313181
		StaticMeshComponent = Default__DynamicSMActor_Spawnable_StaticMeshComponent0/*Ref StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0'*/;
		LightEnvironment = Default__DynamicSMActor_Spawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/;
		bCollideActors = true;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DynamicSMActor_Spawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/,
			Default__DynamicSMActor_Spawnable_StaticMeshComponent0/*Ref StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0'*/,
		};
		CollisionComponent = Default__DynamicSMActor_Spawnable_StaticMeshComponent0/*Ref StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0'*/;
	}
}
}