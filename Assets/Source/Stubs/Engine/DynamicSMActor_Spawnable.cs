namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DynamicSMActor_Spawnable : DynamicSMActor/*
		notplaceable
		hidecategories(Navigation)*/{
	public DynamicSMActor_Spawnable()
	{
		// Object Offset:0x00313181
		StaticMeshComponent = new StaticMeshComponent
		{
			// Object Offset:0x005797E2
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor_Spawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/,
		}/* Reference: StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0' */;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor_Spawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/;
		bCollideActors = true;
		bBlockActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor_Spawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/,
			new StaticMeshComponent
			{
				// Object Offset:0x005797E2
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor_Spawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/,
			}/* Reference: StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0' */,
		};
		CollisionComponent = new StaticMeshComponent
		{
			// Object Offset:0x005797E2
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__DynamicSMActor_Spawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__DynamicSMActor_Spawnable.MyLightEnvironment'*/,
		}/* Reference: StaticMeshComponent'Default__DynamicSMActor_Spawnable.StaticMeshComponent0' */;
	}
}
}