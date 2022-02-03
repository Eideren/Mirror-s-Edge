namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_Dummy : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated event */void eventPostBeginPlay()
	{
		// stub
	}
	
	public TdBotPawn_Dummy()
	{
		var Default__TdBotPawn_Dummy_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Dummy.ActorCollisionCylinder' */;
		var Default__TdBotPawn_Dummy_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment' */;
		var Default__TdBotPawn_Dummy_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0002298A
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_Dummy_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p' */;
		var Default__TdBotPawn_Dummy_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_Dummy_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_Dummy.DrawFrust0' */;
		var Default__TdBotPawn_Dummy_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder' */;
		var Default__TdBotPawn_Dummy_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_Dummy.Arrow' */;
		// Object Offset:0x0001C26F
		AiInitializeWeaponAnimationState = TdPawn.EWeaponAnimState.WS_Ready;
		ActorCylinderComponent = Default__TdBotPawn_Dummy_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Dummy.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_Dummy_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p'*/;
		SceneCapture = Default__TdBotPawn_Dummy_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_Dummy_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Dummy.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_Dummy_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_Dummy_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_Dummy_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Dummy.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_Dummy_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Dummy.DrawFrust0'*/,
			Default__TdBotPawn_Dummy_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/,
			Default__TdBotPawn_Dummy_Arrow/*Ref ArrowComponent'Default__TdBotPawn_Dummy.Arrow'*/,
			Default__TdBotPawn_Dummy_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Dummy.MyLightEnvironment'*/,
			Default__TdBotPawn_Dummy_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Dummy.TdPawnMesh3p'*/,
			Default__TdBotPawn_Dummy_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/,
			Default__TdBotPawn_Dummy_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Dummy.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_Dummy_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Dummy.CollisionCylinder'*/;
	}
}
}