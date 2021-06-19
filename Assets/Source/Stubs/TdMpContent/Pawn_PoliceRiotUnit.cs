namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_PoliceRiotUnit : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_PoliceRiotUnit()
	{
		var Default__Pawn_PoliceRiotUnit_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder' */;
		var Default__Pawn_PoliceRiotUnit_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P' */;
		var Default__Pawn_PoliceRiotUnit_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011168
			LightEnvironment = Default__Pawn_PoliceRiotUnit_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1p' */;
		var Default__Pawn_PoliceRiotUnit_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment' */;
		var Default__Pawn_PoliceRiotUnit_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000111EC
			LightEnvironment = Default__Pawn_PoliceRiotUnit_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p' */;
		var Default__Pawn_PoliceRiotUnit_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001119C
			ParentAnimComponent = Default__Pawn_PoliceRiotUnit_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1p'*/,
			LightEnvironment = Default__Pawn_PoliceRiotUnit_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1pLowerBody' */;
		var Default__Pawn_PoliceRiotUnit_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_PoliceRiotUnit_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Pawn_PoliceRiotUnit.DrawFrust0' */;
		var Default__Pawn_PoliceRiotUnit_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder' */;
		var Default__Pawn_PoliceRiotUnit_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Pawn_PoliceRiotUnit.Arrow' */;
		// Object Offset:0x0000AB42
		ActorCylinderComponent = Default__Pawn_PoliceRiotUnit_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_PoliceRiotUnit_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1p'*/;
		Mesh3p = Default__Pawn_PoliceRiotUnit_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__Pawn_PoliceRiotUnit_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1pLowerBody'*/;
		bIsFemale = false;
		SceneCapture = Default__Pawn_PoliceRiotUnit_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_PoliceRiotUnit_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_PoliceRiotUnit.DrawFrust0'*/;
		Mesh = Default__Pawn_PoliceRiotUnit_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p'*/;
		CylinderComponent = Default__Pawn_PoliceRiotUnit_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_PoliceRiotUnit_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_PoliceRiotUnit_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_PoliceRiotUnit.DrawFrust0'*/,
			Default__Pawn_PoliceRiotUnit_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/,
			Default__Pawn_PoliceRiotUnit_Arrow/*Ref ArrowComponent'Default__Pawn_PoliceRiotUnit.Arrow'*/,
			Default__Pawn_PoliceRiotUnit_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
			Default__Pawn_PoliceRiotUnit_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p'*/,
			Default__Pawn_PoliceRiotUnit_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/,
			Default__Pawn_PoliceRiotUnit_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder'*/,
			Default__Pawn_PoliceRiotUnit_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P'*/,
		};
		CollisionComponent = Default__Pawn_PoliceRiotUnit_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/;
	}
}
}