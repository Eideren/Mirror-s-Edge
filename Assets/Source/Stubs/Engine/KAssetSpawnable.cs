namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KAssetSpawnable : KAsset/*
		notplaceable
		hidecategories(Navigation)*/{
	public KAssetSpawnable()
	{
		var Default__KAssetSpawnable_KAssetSkelMeshComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x004CED7E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__KAssetSpawnable.KAssetSkelMeshComponent' */;
		// Object Offset:0x0034C459
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/;
		SkeletalMeshComponent = Default__KAssetSpawnable_KAssetSkelMeshComponent;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/,
			Default__KAssetSpawnable_KAssetSkelMeshComponent,
		};
		CollisionComponent = Default__KAssetSpawnable_KAssetSkelMeshComponent;
	}
}
}