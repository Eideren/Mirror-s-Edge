namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_PatrolCop_Steyr : TdBotPawn_PatrolCop/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public TdBotPawn_PatrolCop_Steyr()
	{
		// Object Offset:0x0001DDD3
		AdditionalSkeletalMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022B62
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p")/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/,
			ShadowParent = LoadAsset<TdSkeletalMeshComponent>("Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p")/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.AdditionalSkeletalMeshComponent' */;
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022BCE
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p' */;
		ArmorBulletsHeadSettings = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022BCE
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_PatrolCop_Steyr.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_PatrolCop_Steyr.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00022BCE
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/;
	}
}
}