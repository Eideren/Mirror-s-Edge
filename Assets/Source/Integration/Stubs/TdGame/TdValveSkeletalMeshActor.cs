namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdValveSkeletalMeshActor : SkeletalMeshActor/*
		placeable
		hidecategories(Navigation)*/{
	public virtual /*simulated function */void PlayAnimation(name AnimSeqName, float Rate)
	{
		// stub
	}
	
	public virtual /*simulated function */void AddValveRoll(int RollValue)
	{
		// stub
	}
	
	public TdValveSkeletalMeshActor()
	{
		var Default__TdValveSkeletalMeshActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment' */;
		var Default__TdValveSkeletalMeshActor_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BEAA
			SkeletalMesh = LoadAsset<SkeletalMesh>("P_Pipes.Valve_01.SK_Valve_01")/*Ref SkeletalMesh'P_Pipes.Valve_01.SK_Valve_01'*/,
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Valve.AT_Valve")/*Ref AnimTree'AT_Valve.AT_Valve'*/,
			Animations = default,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_Valve.AS_Valve")/*Ref TdAnimSet'AS_Valve.AS_Valve'*/,
			},
			LightEnvironment = Default__TdValveSkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0' */;
		var Default__TdValveSkeletalMeshActor_FaceAudioComponent = new AudioComponent
		{
		}/* Reference: AudioComponent'Default__TdValveSkeletalMeshActor.FaceAudioComponent' */;
		// Object Offset:0x006BCAB2
		SkeletalMeshComponent = Default__TdValveSkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0'*/;
		LightEnvironment = Default__TdValveSkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/;
		FacialAudioComp = Default__TdValveSkeletalMeshActor_FaceAudioComponent/*Ref AudioComponent'Default__TdValveSkeletalMeshActor.FaceAudioComponent'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdValveSkeletalMeshActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/,
			Default__TdValveSkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0'*/,
			Default__TdValveSkeletalMeshActor_FaceAudioComponent/*Ref AudioComponent'Default__TdValveSkeletalMeshActor.FaceAudioComponent'*/,
		};
		CollisionComponent = Default__TdValveSkeletalMeshActor_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0'*/;
	}
}
}