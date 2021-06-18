namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_PoliceUndercover : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_PoliceUndercover()
	{
		var Default__Pawn_PoliceUndercover_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000112D8
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceUndercover.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1p' */;
		var Default__Pawn_PoliceUndercover_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001135C
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceUndercover.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh3p' */;
		var Default__Pawn_PoliceUndercover_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001130C
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__Pawn_PoliceUndercover.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceUndercover.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceUndercover.TdPawnMesh1pLowerBody' */;
		// Object Offset:0x0000AFD0
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceUndercover.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_PoliceUndercover_TdPawnMesh1p;
		Mesh3p = Default__Pawn_PoliceUndercover_TdPawnMesh3p;
		Mesh1pLowerBody = Default__Pawn_PoliceUndercover_TdPawnMesh1pLowerBody;
		bIsFemale = false;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__Pawn_PoliceUndercover.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_PoliceUndercover.DrawFrust0'*/;
		Mesh = Default__Pawn_PoliceUndercover_TdPawnMesh3p;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceUndercover.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceUndercover.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__Pawn_PoliceUndercover.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_PoliceUndercover.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceUndercover.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__Pawn_PoliceUndercover.Arrow")/*Ref ArrowComponent'Default__Pawn_PoliceUndercover.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceUndercover.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment'*/,
			Default__Pawn_PoliceUndercover_TdPawnMesh3p,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceUndercover.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceUndercover.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceUndercover.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceUndercover.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceUndercover.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceUndercover.CollisionCylinder'*/;
	}
}
}