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
		var Default__TdBotPawn_JKSniper_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_JKSniper.ActorCollisionCylinder' */;
		var Default__TdBotPawn_JKSniper_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x000227D6
			bEnabled = false,
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment' */;
		var Default__TdBotPawn_JKSniper_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000229F6
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_JKSniper_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment'*/,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = true,
				Cinematic_1 = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p' */;
		var Default__TdBotPawn_JKSniper_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_JKSniper_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_JKSniper.DrawFrust0' */;
		var Default__TdBotPawn_JKSniper_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder' */;
		var Default__TdBotPawn_JKSniper_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_JKSniper.Arrow' */;
		// Object Offset:0x0001C577
		ActorCylinderComponent = Default__TdBotPawn_JKSniper_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_JKSniper_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p'*/;
		SceneCapture = Default__TdBotPawn_JKSniper_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_JKSniper_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_JKSniper.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_JKSniper_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_JKSniper_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_JKSniper_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_JKSniper.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_JKSniper_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_JKSniper.DrawFrust0'*/,
			Default__TdBotPawn_JKSniper_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/,
			Default__TdBotPawn_JKSniper_Arrow/*Ref ArrowComponent'Default__TdBotPawn_JKSniper.Arrow'*/,
			Default__TdBotPawn_JKSniper_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_JKSniper.MyLightEnvironment'*/,
			Default__TdBotPawn_JKSniper_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_JKSniper.TdPawnMesh3p'*/,
			Default__TdBotPawn_JKSniper_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/,
			Default__TdBotPawn_JKSniper_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_JKSniper_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_JKSniper.CollisionCylinder'*/;
	}
}
}