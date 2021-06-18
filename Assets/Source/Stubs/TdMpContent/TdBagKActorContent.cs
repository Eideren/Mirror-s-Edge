namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagKActorContent : TdBagKActor/*
		placeable*/{
	public TdBagKActorContent()
	{
		var Default__TdBagKActorContent_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x00010ED0
			StaticMesh = LoadAsset<StaticMesh>("Bag.S_Bag")/*Ref StaticMesh'Bag.S_Bag'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBagKActorContent.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment'*/,
			bUseAsOccluder = false,
		}/* Reference: StaticMeshComponent'Default__TdBagKActorContent.StaticMeshComponent0' */;
		// Object Offset:0x0000B217
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBagKActorContent.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBagKActorContent.ActorCollisionCylinder'*/;
		StaticMeshComponent = Default__TdBagKActorContent_StaticMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBagKActorContent.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBagKActorContent.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBagKActorContent.MyLightEnvironment'*/,
			Default__TdBagKActorContent_StaticMeshComponent0,
			Default__TdBagKActorContent_StaticMeshComponent0,
			LoadAsset<CylinderComponent>("Default__TdBagKActorContent.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBagKActorContent.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBagKActorContent_StaticMeshComponent0;
	}
}
}