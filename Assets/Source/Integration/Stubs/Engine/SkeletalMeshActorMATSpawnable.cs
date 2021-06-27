namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshActorMATSpawnable : SkeletalMeshActorMAT/*
		notplaceable
		hidecategories(Navigation)*/{
	public SkeletalMeshActorMATSpawnable()
	{
		var Default__SkeletalMeshActorMATSpawnable_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment' */;
		var Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x004CEDB2
			LightEnvironment = Default__SkeletalMeshActorMATSpawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorMATSpawnable.SkeletalMeshComponent0' */;
		var Default__SkeletalMeshActorMATSpawnable_FaceAudioComponent = new AudioComponent
		{
		}/* Reference: AudioComponent'Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent' */;
		// Object Offset:0x003E7F27
		SkeletalMeshComponent = Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActorMATSpawnable.SkeletalMeshComponent0'*/;
		LightEnvironment = Default__SkeletalMeshActorMATSpawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment'*/;
		FacialAudioComp = Default__SkeletalMeshActorMATSpawnable_FaceAudioComponent/*Ref AudioComponent'Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SkeletalMeshActorMATSpawnable_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorMATSpawnable.MyLightEnvironment'*/,
			Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActorMATSpawnable.SkeletalMeshComponent0'*/,
			Default__SkeletalMeshActorMATSpawnable_FaceAudioComponent/*Ref AudioComponent'Default__SkeletalMeshActorMATSpawnable.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__SkeletalMeshActorMATSpawnable_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__SkeletalMeshActorMATSpawnable.SkeletalMeshComponent0'*/;
	}
}
}