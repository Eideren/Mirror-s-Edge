namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_CriminalProwler : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_CriminalProwler()
	{
		var Default__Pawn_CriminalProwler_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_CriminalProwler.ActorCollisionCylinder' */;
		var Default__Pawn_CriminalProwler_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment1P' */;
		var Default__Pawn_CriminalProwler_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000110B0
			LightEnvironment = Default__Pawn_CriminalProwler_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1p' */;
		var Default__Pawn_CriminalProwler_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment' */;
		var Default__Pawn_CriminalProwler_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011134
			LightEnvironment = Default__Pawn_CriminalProwler_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p' */;
		var Default__Pawn_CriminalProwler_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000110E4
			ParentAnimComponent = Default__Pawn_CriminalProwler_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1p'*/,
			LightEnvironment = Default__Pawn_CriminalProwler_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1pLowerBody' */;
		var Default__Pawn_CriminalProwler_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_CriminalProwler_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Pawn_CriminalProwler.DrawFrust0' */;
		var Default__Pawn_CriminalProwler_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder' */;
		var Default__Pawn_CriminalProwler_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Pawn_CriminalProwler.Arrow' */;
		// Object Offset:0x0000A917
		ActorCylinderComponent = Default__Pawn_CriminalProwler_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalProwler.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_CriminalProwler_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1p'*/;
		Mesh3p = Default__Pawn_CriminalProwler_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__Pawn_CriminalProwler_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1pLowerBody'*/;
		SceneCapture = Default__Pawn_CriminalProwler_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_CriminalProwler_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_CriminalProwler.DrawFrust0'*/;
		Mesh = Default__Pawn_CriminalProwler_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p'*/;
		CylinderComponent = Default__Pawn_CriminalProwler_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_CriminalProwler_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_CriminalProwler_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_CriminalProwler.DrawFrust0'*/,
			Default__Pawn_CriminalProwler_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/,
			Default__Pawn_CriminalProwler_Arrow/*Ref ArrowComponent'Default__Pawn_CriminalProwler.Arrow'*/,
			Default__Pawn_CriminalProwler_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
			Default__Pawn_CriminalProwler_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p'*/,
			Default__Pawn_CriminalProwler_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/,
			Default__Pawn_CriminalProwler_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalProwler.ActorCollisionCylinder'*/,
			Default__Pawn_CriminalProwler_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment1P'*/,
		};
		CollisionComponent = Default__Pawn_CriminalProwler_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/;
	}
}
}