namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KAssetSpawnable : KAsset/*
		notplaceable
		hidecategories(Navigation)*/{
	public KAssetSpawnable()
	{
		// Object Offset:0x0034C459
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/;
		SkeletalMeshComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x004CED7E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__KAssetSpawnable.KAssetSkelMeshComponent' */;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/,
			new SkeletalMeshComponent
			{
				// Object Offset:0x004CED7E
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/,
			}/* Reference: SkeletalMeshComponent'Default__KAssetSpawnable.KAssetSkelMeshComponent' */,
		};
		CollisionComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x004CED7E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAssetSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAssetSpawnable.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__KAssetSpawnable.KAssetSkelMeshComponent' */;
	}
}
}