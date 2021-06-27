namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPedSkeletalMeshActor : SkeletalMeshActor/*
		placeable
		hidecategories(Navigation)*/{
	public TdPedSkeletalMeshActor()
	{
		var Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0_AnimNodeSeq0 = new AnimNodeSequence
		{
		}/* Reference: AnimNodeSequence'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0.AnimNodeSeq0' */;
		var Default__TdPedSkeletalMeshActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment' */;
		var Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BCAE
			Animations = Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0_AnimNodeSeq0/*Ref AnimNodeSequence'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0.AnimNodeSeq0'*/,
			LightEnvironment = Default__TdPedSkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0' */;
		var Default__TdPedSkeletalMeshActor_FaceAudioComponent = new AudioComponent
		{
		}/* Reference: AudioComponent'Default__TdPedSkeletalMeshActor.FaceAudioComponent' */;
		// Object Offset:0x0060A8F6
		SkeletalMeshComponent = Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0'*/;
		LightEnvironment = Default__TdPedSkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment'*/;
		FacialAudioComp = Default__TdPedSkeletalMeshActor_FaceAudioComponent/*Ref AudioComponent'Default__TdPedSkeletalMeshActor.FaceAudioComponent'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPedSkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPedSkeletalMeshActor.MyLightEnvironment'*/,
			Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0'*/,
			Default__TdPedSkeletalMeshActor_FaceAudioComponent/*Ref AudioComponent'Default__TdPedSkeletalMeshActor.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__TdPedSkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__TdPedSkeletalMeshActor.SkeletalMeshComponent0'*/;
	}
}
}