namespace MEdge.TdSpBossContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_SniperCeleste : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */void PauseFiring()
	{
		// stub
	}
	
	public TdBotPawn_SniperCeleste()
	{
		var Default__TdBotPawn_SniperCeleste_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder' */;
		var Default__TdBotPawn_SniperCeleste_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCeleste.MyLightEnvironment' */;
		var Default__TdBotPawn_SniperCeleste_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00003AB2
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_SniperCeleste_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCeleste.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SniperCeleste.TdPawnMesh3p' */;
		var Default__TdBotPawn_SniperCeleste_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_SniperCeleste_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_SniperCeleste.DrawFrust0' */;
		var Default__TdBotPawn_SniperCeleste_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder' */;
		var Default__TdBotPawn_SniperCeleste_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_SniperCeleste.Arrow' */;
		// Object Offset:0x000035F7
		AnimationRunSpeed = 720.0f;
		ActorCylinderComponent = Default__TdBotPawn_SniperCeleste_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_SniperCeleste_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_SniperCeleste.TdPawnMesh3p'*/;
		ArmorBulletsHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.20f,
			Hard = 0.20f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.60f,
			Medium = 0.60f,
			Hard = 0.60f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.50f,
			Hard = 0.50f,
		};
		SceneCapture = Default__TdBotPawn_SniperCeleste_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_SniperCeleste_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_SniperCeleste.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_SniperCeleste_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_SniperCeleste.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_SniperCeleste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_SniperCeleste_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_SniperCeleste_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_SniperCeleste.DrawFrust0'*/,
			Default__TdBotPawn_SniperCeleste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/,
			Default__TdBotPawn_SniperCeleste_Arrow/*Ref ArrowComponent'Default__TdBotPawn_SniperCeleste.Arrow'*/,
			Default__TdBotPawn_SniperCeleste_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCeleste.MyLightEnvironment'*/,
			Default__TdBotPawn_SniperCeleste_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_SniperCeleste.TdPawnMesh3p'*/,
			Default__TdBotPawn_SniperCeleste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/,
			Default__TdBotPawn_SniperCeleste_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_SniperCeleste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/;
	}
}
}