namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_SupportHelicopterGunner : TdBotPawn/*
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
	
	public TdBotPawn_SupportHelicopterGunner()
	{
		var Default__TdBotPawn_SupportHelicopterGunner_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder' */;
		var Default__TdBotPawn_SupportHelicopterGunner_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment' */;
		var Default__TdBotPawn_SupportHelicopterGunner_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022D7A
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_SupportHelicopterGunner_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment'*/,
			CastShadow = false,
			bCastDynamicShadow = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p' */;
		var Default__TdBotPawn_SupportHelicopterGunner_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_SupportHelicopterGunner_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0' */;
		var Default__TdBotPawn_SupportHelicopterGunner_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder' */;
		var Default__TdBotPawn_SupportHelicopterGunner_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_SupportHelicopterGunner.Arrow' */;
		// Object Offset:0x0002217C
		ActorCylinderComponent = Default__TdBotPawn_SupportHelicopterGunner_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_SupportHelicopterGunner_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p'*/;
		SceneCapture = Default__TdBotPawn_SupportHelicopterGunner_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_SupportHelicopterGunner_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_SupportHelicopterGunner_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_SupportHelicopterGunner_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_SupportHelicopterGunner_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_SupportHelicopterGunner_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0'*/,
			Default__TdBotPawn_SupportHelicopterGunner_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/,
			Default__TdBotPawn_SupportHelicopterGunner_Arrow/*Ref ArrowComponent'Default__TdBotPawn_SupportHelicopterGunner.Arrow'*/,
			Default__TdBotPawn_SupportHelicopterGunner_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment'*/,
			Default__TdBotPawn_SupportHelicopterGunner_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p'*/,
			Default__TdBotPawn_SupportHelicopterGunner_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/,
			Default__TdBotPawn_SupportHelicopterGunner_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_SupportHelicopterGunner_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/;
	}
}
}