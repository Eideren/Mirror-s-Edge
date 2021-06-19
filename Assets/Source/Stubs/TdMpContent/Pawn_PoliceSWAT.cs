namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_PoliceSWAT : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_PoliceSWAT()
	{
		var Default__Pawn_PoliceSWAT_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_PoliceSWAT.ActorCollisionCylinder' */;
		var Default__Pawn_PoliceSWAT_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment1P' */;
		var Default__Pawn_PoliceSWAT_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011220
			LightEnvironment = Default__Pawn_PoliceSWAT_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1p' */;
		var Default__Pawn_PoliceSWAT_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment' */;
		var Default__Pawn_PoliceSWAT_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000112A4
			LightEnvironment = Default__Pawn_PoliceSWAT_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh3p' */;
		var Default__Pawn_PoliceSWAT_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011254
			ParentAnimComponent = Default__Pawn_PoliceSWAT_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1p'*/,
			LightEnvironment = Default__Pawn_PoliceSWAT_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1pLowerBody' */;
		var Default__Pawn_PoliceSWAT_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_PoliceSWAT_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Pawn_PoliceSWAT.DrawFrust0' */;
		var Default__Pawn_PoliceSWAT_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder' */;
		var Default__Pawn_PoliceSWAT_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Pawn_PoliceSWAT.Arrow' */;
		// Object Offset:0x0000AD89
		ActorCylinderComponent = Default__Pawn_PoliceSWAT_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_PoliceSWAT_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1p'*/;
		Mesh3p = Default__Pawn_PoliceSWAT_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__Pawn_PoliceSWAT_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh1pLowerBody'*/;
		bIsFemale = false;
		SceneCapture = Default__Pawn_PoliceSWAT_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_PoliceSWAT_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_PoliceSWAT.DrawFrust0'*/;
		Mesh = Default__Pawn_PoliceSWAT_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh3p'*/;
		CylinderComponent = Default__Pawn_PoliceSWAT_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_PoliceSWAT_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceSWAT.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_PoliceSWAT_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_PoliceSWAT.DrawFrust0'*/,
			Default__Pawn_PoliceSWAT_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/,
			Default__Pawn_PoliceSWAT_Arrow/*Ref ArrowComponent'Default__Pawn_PoliceSWAT.Arrow'*/,
			Default__Pawn_PoliceSWAT_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment'*/,
			Default__Pawn_PoliceSWAT_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceSWAT.TdPawnMesh3p'*/,
			Default__Pawn_PoliceSWAT_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/,
			Default__Pawn_PoliceSWAT_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.ActorCollisionCylinder'*/,
			Default__Pawn_PoliceSWAT_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceSWAT.MyLightEnvironment1P'*/,
		};
		CollisionComponent = Default__Pawn_PoliceSWAT_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceSWAT.CollisionCylinder'*/;
	}
}
}