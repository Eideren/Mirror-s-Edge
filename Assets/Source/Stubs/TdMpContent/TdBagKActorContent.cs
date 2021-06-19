namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagKActorContent : TdBagKActor/*
		placeable*/{
	public TdBagKActorContent()
	{
		var Default__TdBagKActorContent_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBagKActorContent.ActorCollisionCylinder' */;
		var Default__TdBagKActorContent_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment' */;
		var Default__TdBagKActorContent_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x00010ED0
			StaticMesh = LoadAsset<StaticMesh>("Bag.S_Bag")/*Ref StaticMesh'Bag.S_Bag'*/,
			LightEnvironment = Default__TdBagKActorContent_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment'*/,
			bUseAsOccluder = false,
		}/* Reference: StaticMeshComponent'Default__TdBagKActorContent.StaticMeshComponent0' */;
		// Object Offset:0x0000B217
		ActorCylinderComponent = Default__TdBagKActorContent_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBagKActorContent.ActorCollisionCylinder'*/;
		StaticMeshComponent = Default__TdBagKActorContent_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActorContent.StaticMeshComponent0'*/;
		LightEnvironment = Default__TdBagKActorContent_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBagKActorContent_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment'*/,
			Default__TdBagKActorContent_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActorContent.StaticMeshComponent0'*/,
			Default__TdBagKActorContent_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActorContent.StaticMeshComponent0'*/,
			Default__TdBagKActorContent_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBagKActorContent.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBagKActorContent_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdBagKActorContent.StaticMeshComponent0'*/;
	}
}
}