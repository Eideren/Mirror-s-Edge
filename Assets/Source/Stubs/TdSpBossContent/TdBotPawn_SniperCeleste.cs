namespace MEdge.TdSpBossContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_SniperCeleste : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */void PauseFiring()
	{
	
	}
	
	public TdBotPawn_SniperCeleste()
	{
		var Default__TdBotPawn_SniperCeleste_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00003AB2
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SniperCeleste.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCeleste.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SniperCeleste.TdPawnMesh3p' */;
		// Object Offset:0x000035F7
		AnimationRunSpeed = 720.0f;
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_SniperCeleste_TdPawnMesh3p;
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
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_SniperCeleste.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_SniperCeleste.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_SniperCeleste_TdPawnMesh3p;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCeleste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCeleste.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_SniperCeleste.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_SniperCeleste.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCeleste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_SniperCeleste.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_SniperCeleste.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SniperCeleste.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCeleste.MyLightEnvironment'*/,
			Default__TdBotPawn_SniperCeleste_TdPawnMesh3p,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCeleste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCeleste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCeleste.CollisionCylinder'*/;
	}
}
}