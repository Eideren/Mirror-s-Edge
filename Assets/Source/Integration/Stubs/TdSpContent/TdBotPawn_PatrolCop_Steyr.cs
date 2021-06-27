namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_PatrolCop_Steyr : TdBotPawn_PatrolCop/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public TdBotPawn_PatrolCop_Steyr()
	{
		var Default__TdBotPawn_PatrolCop_Steyr_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment' */;
		var Default__TdBotPawn_PatrolCop_Steyr_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022BCE
			LightEnvironment = Default__TdBotPawn_PatrolCop_Steyr_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p' */;
		var Default__TdBotPawn_PatrolCop_Steyr_AdditionalSkeletalMeshComponent = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022B62
			ParentAnimComponent = Default__TdBotPawn_PatrolCop_Steyr_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/,
			ShadowParent = Default__TdBotPawn_PatrolCop_Steyr_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/,
			LightEnvironment = Default__TdBotPawn_PatrolCop_Steyr_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.AdditionalSkeletalMeshComponent' */;
		var Default__TdBotPawn_PatrolCop_Steyr_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder' */;
		var Default__TdBotPawn_PatrolCop_Steyr_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_PatrolCop_Steyr_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0' */;
		var Default__TdBotPawn_PatrolCop_Steyr_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder' */;
		var Default__TdBotPawn_PatrolCop_Steyr_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_PatrolCop_Steyr.Arrow' */;
		// Object Offset:0x0001DDD3
		AdditionalSkeletalMesh = Default__TdBotPawn_PatrolCop_Steyr_AdditionalSkeletalMeshComponent/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.AdditionalSkeletalMeshComponent'*/;
		ActorCylinderComponent = Default__TdBotPawn_PatrolCop_Steyr_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_PatrolCop_Steyr_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/;
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
		SceneCapture = Default__TdBotPawn_PatrolCop_Steyr_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_PatrolCop_Steyr_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_PatrolCop_Steyr_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_PatrolCop_Steyr_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_PatrolCop_Steyr_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Steyr.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_PatrolCop_Steyr_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Steyr.DrawFrust0'*/,
			Default__TdBotPawn_PatrolCop_Steyr_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/,
			Default__TdBotPawn_PatrolCop_Steyr_Arrow/*Ref ArrowComponent'Default__TdBotPawn_PatrolCop_Steyr.Arrow'*/,
			Default__TdBotPawn_PatrolCop_Steyr_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Steyr.MyLightEnvironment'*/,
			Default__TdBotPawn_PatrolCop_Steyr_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Steyr.TdPawnMesh3p'*/,
			Default__TdBotPawn_PatrolCop_Steyr_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/,
			Default__TdBotPawn_PatrolCop_Steyr_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_PatrolCop_Steyr_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Steyr.CollisionCylinder'*/;
	}
}
}