namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_JKSniper : TdBotPawnNoPhysics/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated function */void Turn(float DeltaTime)
	{
	
	}
	
	public override /*event */Object.Vector GetViewpointLocation(/*optional */bool? _ForceCrouch = default)
	{
	
		return default;
	}
	
	public TdBotPawn_JKSniper()
	{
		// Object Offset:0x0001C577
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_JKSniper.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000229F6
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_JKSniper.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment'*/,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = true,
				Cinematic_1 = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p' */;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_JKSniper.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_JKSniper.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000229F6
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_JKSniper.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment'*/,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = true,
				Cinematic_1 = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_JKSniper.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_JKSniper.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_JKSniper.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_JKSniper.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_JKSniper.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_JKSniper.Arrow'*/,
			new DynamicLightEnvironmentComponent
			{
				// Object Offset:0x000227D6
				bEnabled = false,
			}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment' */,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x000229F6
				AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_JKSniper.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment'*/,
				LightingChannels = new LightComponent.LightingChannelContainer
				{
					Dynamic = true,
					Cinematic_1 = true,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_JKSniper.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_JKSniper.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_JKSniper.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/;
	}
}
}