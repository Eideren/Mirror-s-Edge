namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_Dummy : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public TdBotPawn_Dummy()
	{
		// Object Offset:0x0001C26F
		AiInitializeWeaponAnimationState = TdPawn.EWeaponAnimState.WS_Ready;
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Dummy.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Dummy.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0002298A
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Dummy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p' */;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_Dummy.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_Dummy.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0002298A
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Dummy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Dummy.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_Dummy.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_Dummy.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Dummy.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_Dummy.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_Dummy.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Dummy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment'*/,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0002298A
				AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Dummy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Dummy.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Dummy.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Dummy.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Dummy.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/;
	}
}
}