namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_PoliceUndercover : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_PoliceUndercover()
	{
		var Default__Pawn_PoliceUndercover_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_PoliceUndercover.ActorCollisionCylinder' */;
		var Default__Pawn_PoliceUndercover_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment1P' */;
		var Default__Pawn_PoliceUndercover_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000112D8
			LightEnvironment = Default__Pawn_PoliceUndercover_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1p' */;
		var Default__Pawn_PoliceUndercover_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment' */;
		var Default__Pawn_PoliceUndercover_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001135C
			LightEnvironment = Default__Pawn_PoliceUndercover_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh3p' */;
		var Default__Pawn_PoliceUndercover_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001130C
			ParentAnimComponent = Default__Pawn_PoliceUndercover_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1p'*/,
			LightEnvironment = Default__Pawn_PoliceUndercover_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1pLowerBody' */;
		var Default__Pawn_PoliceUndercover_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_PoliceUndercover_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Pawn_PoliceUndercover.DrawFrust0' */;
		var Default__Pawn_PoliceUndercover_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder' */;
		var Default__Pawn_PoliceUndercover_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Pawn_PoliceUndercover.Arrow' */;
		// Object Offset:0x0000AFD0
		ActorCylinderComponent = Default__Pawn_PoliceUndercover_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_PoliceUndercover_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1p'*/;
		Mesh3p = Default__Pawn_PoliceUndercover_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__Pawn_PoliceUndercover_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1pLowerBody'*/;
		bIsFemale = false;
		SceneCapture = Default__Pawn_PoliceUndercover_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_PoliceUndercover_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_PoliceUndercover.DrawFrust0'*/;
		Mesh = Default__Pawn_PoliceUndercover_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh3p'*/;
		CylinderComponent = Default__Pawn_PoliceUndercover_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_PoliceUndercover_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_PoliceUndercover_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_PoliceUndercover.DrawFrust0'*/,
			Default__Pawn_PoliceUndercover_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/,
			Default__Pawn_PoliceUndercover_Arrow/*Ref ArrowComponent'Default__Pawn_PoliceUndercover.Arrow'*/,
			Default__Pawn_PoliceUndercover_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment'*/,
			Default__Pawn_PoliceUndercover_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh3p'*/,
			Default__Pawn_PoliceUndercover_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/,
			Default__Pawn_PoliceUndercover_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.ActorCollisionCylinder'*/,
			Default__Pawn_PoliceUndercover_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment1P'*/,
		};
		CollisionComponent = Default__Pawn_PoliceUndercover_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/;
	}
}
}