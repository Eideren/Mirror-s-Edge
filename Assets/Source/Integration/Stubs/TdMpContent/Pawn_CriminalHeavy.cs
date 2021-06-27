namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_CriminalHeavy : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_CriminalHeavy()
	{
		var Default__Pawn_CriminalHeavy_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_CriminalHeavy.ActorCollisionCylinder' */;
		var Default__Pawn_CriminalHeavy_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment1P' */;
		var Default__Pawn_CriminalHeavy_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010FF8
			LightEnvironment = Default__Pawn_CriminalHeavy_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1p' */;
		var Default__Pawn_CriminalHeavy_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment' */;
		var Default__Pawn_CriminalHeavy_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001107C
			LightEnvironment = Default__Pawn_CriminalHeavy_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh3p' */;
		var Default__Pawn_CriminalHeavy_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001102C
			ParentAnimComponent = Default__Pawn_CriminalHeavy_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1p'*/,
			LightEnvironment = Default__Pawn_CriminalHeavy_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1pLowerBody' */;
		var Default__Pawn_CriminalHeavy_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_CriminalHeavy_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Pawn_CriminalHeavy.DrawFrust0' */;
		var Default__Pawn_CriminalHeavy_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder' */;
		var Default__Pawn_CriminalHeavy_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Pawn_CriminalHeavy.Arrow' */;
		// Object Offset:0x0000A6D0
		ActorCylinderComponent = Default__Pawn_CriminalHeavy_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_CriminalHeavy_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1p'*/;
		Mesh3p = Default__Pawn_CriminalHeavy_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__Pawn_CriminalHeavy_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1pLowerBody'*/;
		bIsFemale = false;
		SceneCapture = Default__Pawn_CriminalHeavy_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_CriminalHeavy_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_CriminalHeavy.DrawFrust0'*/;
		Mesh = Default__Pawn_CriminalHeavy_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh3p'*/;
		CylinderComponent = Default__Pawn_CriminalHeavy_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_CriminalHeavy_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_CriminalHeavy_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_CriminalHeavy.DrawFrust0'*/,
			Default__Pawn_CriminalHeavy_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/,
			Default__Pawn_CriminalHeavy_Arrow/*Ref ArrowComponent'Default__Pawn_CriminalHeavy.Arrow'*/,
			Default__Pawn_CriminalHeavy_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment'*/,
			Default__Pawn_CriminalHeavy_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh3p'*/,
			Default__Pawn_CriminalHeavy_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/,
			Default__Pawn_CriminalHeavy_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.ActorCollisionCylinder'*/,
			Default__Pawn_CriminalHeavy_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment1P'*/,
		};
		CollisionComponent = Default__Pawn_CriminalHeavy_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/;
	}
}
}