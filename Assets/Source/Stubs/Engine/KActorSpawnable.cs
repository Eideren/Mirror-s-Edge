namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KActorSpawnable : KActor/*
		native
		notplaceable*/{
	public virtual /*simulated function */void Initialize()
	{
		// stub
	}
	
	public virtual /*simulated function */void Recycle()
	{
		// stub
	}
	
	// Export UKActorSpawnable::execResetComponents(FFrame&, void* const)
	public virtual /*native function */void ResetComponents()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public KActorSpawnable()
	{
		var Default__KActorSpawnable_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__KActorSpawnable.MyLightEnvironment' */;
		var Default__KActorSpawnable_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x005798BA
			LightEnvironment = Default__KActorSpawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__KActorSpawnable.MyLightEnvironment'*/,
		}/* Reference: StaticMeshComponent'Default__KActorSpawnable.StaticMeshComponent0' */;
		// Object Offset:0x0034B467
		StaticMeshComponent = Default__KActorSpawnable_StaticMeshComponent0/*Ref StaticMeshComponent'Default__KActorSpawnable.StaticMeshComponent0'*/;
		LightEnvironment = Default__KActorSpawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__KActorSpawnable.MyLightEnvironment'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__KActorSpawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__KActorSpawnable.MyLightEnvironment'*/,
			Default__KActorSpawnable_StaticMeshComponent0/*Ref StaticMeshComponent'Default__KActorSpawnable.StaticMeshComponent0'*/,
		};
		CollisionComponent = Default__KActorSpawnable_StaticMeshComponent0/*Ref StaticMeshComponent'Default__KActorSpawnable.StaticMeshComponent0'*/;
	}
}
}