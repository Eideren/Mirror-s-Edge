namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPedSkeletalMeshActor : SkeletalMeshActor/*
		placeable
		hidecategories(Navigation)*/{
	public TdPedSkeletalMeshActor()
	{
		var Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BCAE
			Animations = LoadAsset<AnimNodeSequence>("Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0.AnimNodeSeq0")/*Ref AnimNodeSequence'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0.AnimNodeSeq0'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdPedSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0' */;
		// Object Offset:0x0060A8F6
		SkeletalMeshComponent = Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdPedSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment'*/;
		FacialAudioComp = LoadAsset<AudioComponent>("Default__TdPedSkeletalMeshActor.FaceAudioComponent")/*Ref AudioComponent'Default__TdPedSkeletalMeshActor.FaceAudioComponent'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdPedSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment'*/,
			Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0,
			LoadAsset<AudioComponent>("Default__TdPedSkeletalMeshActor.FaceAudioComponent")/*Ref AudioComponent'Default__TdPedSkeletalMeshActor.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0;
	}
}
}