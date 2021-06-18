namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshActorMATSpawnable : SkeletalMeshActorMAT/*
		notplaceable
		hidecategories(Navigation)*/{
	public SkeletalMeshActorMATSpawnable()
	{
		var Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x004CEDB2
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorMATSpawnable.SkeletalMeshComponent0' */;
		// Object Offset:0x003E7F27
		SkeletalMeshComponent = Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment'*/;
		FacialAudioComp = LoadAsset<AudioComponent>("Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent")/*Ref AudioComponent'Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment'*/,
			Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0,
			LoadAsset<AudioComponent>("Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent")/*Ref AudioComponent'Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0;
	}
}
}