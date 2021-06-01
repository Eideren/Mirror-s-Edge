namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdValveSkeletalMeshActor : SkeletalMeshActor/*
		placeable
		hidecategories(Navigation)*/{
	public virtual /*simulated function */void PlayAnimation(name AnimSeqName, float Rate)
	{
	
	}
	
	public virtual /*simulated function */void AddValveRoll(int RollValue)
	{
	
	}
	
	public TdValveSkeletalMeshActor()
	{
		// Object Offset:0x006BCAB2
		SkeletalMeshComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BEAA
			SkeletalMesh = LoadAsset<SkeletalMesh>("P_Pipes.Valve_01.SK_Valve_01")/*Ref SkeletalMesh'P_Pipes.Valve_01.SK_Valve_01'*/,
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Valve.AT_Valve")/*Ref AnimTree'AT_Valve.AT_Valve'*/,
			Animations = default,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_Valve.AS_Valve")/*Ref TdAnimSet'AS_Valve.AS_Valve'*/,
			},
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdValveSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0' */;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdValveSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/;
		FacialAudioComp = LoadAsset<AudioComponent>("Default__TdValveSkeletalMeshActor.FaceAudioComponent")/*Ref AudioComponent'Default__TdValveSkeletalMeshActor.FaceAudioComponent'*/;
		bCollideActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdValveSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/,
			new SkeletalMeshComponent
			{
				// Object Offset:0x0279BEAA
				SkeletalMesh = LoadAsset<SkeletalMesh>("P_Pipes.Valve_01.SK_Valve_01")/*Ref SkeletalMesh'P_Pipes.Valve_01.SK_Valve_01'*/,
				AnimTreeTemplate = LoadAsset<AnimTree>("AT_Valve.AT_Valve")/*Ref AnimTree'AT_Valve.AT_Valve'*/,
				Animations = default,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_Valve.AS_Valve")/*Ref TdAnimSet'AS_Valve.AS_Valve'*/,
				},
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdValveSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/,
			}/* Reference: SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0' */,
			LoadAsset<AudioComponent>("Default__TdValveSkeletalMeshActor.FaceAudioComponent")/*Ref AudioComponent'Default__TdValveSkeletalMeshActor.FaceAudioComponent'*/,
		};
		CollisionComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BEAA
			SkeletalMesh = LoadAsset<SkeletalMesh>("P_Pipes.Valve_01.SK_Valve_01")/*Ref SkeletalMesh'P_Pipes.Valve_01.SK_Valve_01'*/,
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Valve.AT_Valve")/*Ref AnimTree'AT_Valve.AT_Valve'*/,
			Animations = default,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_Valve.AS_Valve")/*Ref TdAnimSet'AS_Valve.AS_Valve'*/,
			},
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdValveSkeletalMeshActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdValveSkeletalMeshActor.MyLightEnvironment'*/,
		}/* Reference: SkeletalMeshComponent'Default__TdValveSkeletalMeshActor.SkeletalMeshComponent0' */;
	}
}
}