namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_SupportHelicopterGunner : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated function */void Turn(float DeltaTime)
	{
	
	}
	
	public override /*event */Object.Vector GetViewpointLocation(/*optional */bool ForceCrouch = default)
	{
	
		return default;
	}
	
	public TdBotPawn_SupportHelicopterGunner()
	{
		// Object Offset:0x0002217C
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022D7A
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment'*/,
			CastShadow = false,
			bCastDynamicShadow = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p' */;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022D7A
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment'*/,
			CastShadow = false,
			bCastDynamicShadow = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SupportHelicopterGunner.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_SupportHelicopterGunner.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_SupportHelicopterGunner.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_SupportHelicopterGunner.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00022D7A
				AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Helicopter")/*Ref AnimTree'AT_Cop.AT_Helicopter'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SupportHelicopterGunner.MyLightEnvironment'*/,
				CastShadow = false,
				bCastDynamicShadow = false,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SupportHelicopterGunner.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SupportHelicopterGunner.CollisionCylinder'*/;
	}
}
}