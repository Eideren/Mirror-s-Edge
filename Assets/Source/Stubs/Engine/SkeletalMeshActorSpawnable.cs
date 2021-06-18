namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshActorSpawnable : SkeletalMeshActor/*
		notplaceable
		hidecategories(Navigation)*/{
	public SkeletalMeshActorSpawnable()
	{
		var Default__SkeletalMeshActorSpawnable_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x004CEDE6
			Animations = LoadAsset<AnimNodeSequence>("Default__SkeletalMeshActorSpawnable.SkeletalMeshComponent0.AnimNodeSeq0")/*Ref AnimNodeSequence'Default__SkeletalMeshActorSpawnable.SkeletalMeshComponent0.AnimNodeSeq0'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorSpawnable.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__SkeletalMeshActorSpawnable.SkeletalMeshComponent0' */;
		// Object Offset:0x003E8076
		SkeletalMeshComponent = Default__SkeletalMeshActorSpawnable_SkeletalMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorSpawnable.MyLightEnvironment'*/;
		FacialAudioComp = LoadAsset<AudioComponent>("Default__SkeletalMeshActorSpawnable.FaceAudioComponent")/*Ref AudioComponent'Default__SkeletalMeshActorSpawnable.FaceAudioComponent'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__SkeletalMeshActorSpawnable.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__SkeletalMeshActorSpawnable.MyLightEnvironment'*/,
			Default__SkeletalMeshActorSpawnable_SkeletalMeshComponent0,
			LoadAsset<AudioComponent>("Default__SkeletalMeshActorSpawnable.FaceAudioComponent")/*Ref AudioComponent'Default__SkeletalMeshActorSpawnable.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__SkeletalMeshActorSpawnable_SkeletalMeshComponent0;
	}
}
}