namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_PoliceSWAT : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_PoliceSWAT()
	{
		var Default__Pawn_PoliceSWAT_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011220
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceSWAT.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1p' */;
		var Default__Pawn_PoliceSWAT_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000112A4
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceSWAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh3p' */;
		var Default__Pawn_PoliceSWAT_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011254
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__Pawn_PoliceSWAT.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceSWAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1pLowerBody' */;
		// Object Offset:0x0000AD89
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceSWAT.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_PoliceSWAT_TdPawnMesh1p;
		Mesh3p = Default__Pawn_PoliceSWAT_TdPawnMesh3p;
		Mesh1pLowerBody = Default__Pawn_PoliceSWAT_TdPawnMesh1pLowerBody;
		bIsFemale = false;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__Pawn_PoliceSWAT.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_PoliceSWAT.DrawFrust0'*/;
		Mesh = Default__Pawn_PoliceSWAT_TdPawnMesh3p;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceSWAT.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__Pawn_PoliceSWAT.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_PoliceSWAT.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceSWAT.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__Pawn_PoliceSWAT.Arrow")/*Ref ArrowComponent'Default__Pawn_PoliceSWAT.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceSWAT.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment'*/,
			Default__Pawn_PoliceSWAT_TdPawnMesh3p,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceSWAT.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceSWAT.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceSWAT.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceSWAT.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/;
	}
}
}