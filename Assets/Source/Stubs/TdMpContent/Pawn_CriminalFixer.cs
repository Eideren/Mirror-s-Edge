namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_CriminalFixer : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_CriminalFixer()
	{
		var Default__Pawn_CriminalFixer_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_CriminalFixer.ActorCollisionCylinder' */;
		var Default__Pawn_CriminalFixer_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment1P' */;
		var Default__Pawn_CriminalFixer_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010F40
			LightEnvironment = Default__Pawn_CriminalFixer_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1p' */;
		var Default__Pawn_CriminalFixer_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment' */;
		var Default__Pawn_CriminalFixer_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010FC4
			LightEnvironment = Default__Pawn_CriminalFixer_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p' */;
		var Default__Pawn_CriminalFixer_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010F74
			ParentAnimComponent = Default__Pawn_CriminalFixer_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1p'*/,
			LightEnvironment = Default__Pawn_CriminalFixer_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1pLowerBody' */;
		var Default__Pawn_CriminalFixer_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_CriminalFixer_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__Pawn_CriminalFixer.DrawFrust0' */;
		var Default__Pawn_CriminalFixer_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder' */;
		var Default__Pawn_CriminalFixer_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Pawn_CriminalFixer.Arrow' */;
		// Object Offset:0x0000A4A5
		ActorCylinderComponent = Default__Pawn_CriminalFixer_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalFixer.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_CriminalFixer_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1p'*/;
		Mesh3p = Default__Pawn_CriminalFixer_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__Pawn_CriminalFixer_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1pLowerBody'*/;
		SceneCapture = Default__Pawn_CriminalFixer_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_CriminalFixer_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_CriminalFixer.DrawFrust0'*/;
		Mesh = Default__Pawn_CriminalFixer_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p'*/;
		CylinderComponent = Default__Pawn_CriminalFixer_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_CriminalFixer_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_CriminalFixer_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn_CriminalFixer.DrawFrust0'*/,
			Default__Pawn_CriminalFixer_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/,
			Default__Pawn_CriminalFixer_Arrow/*Ref ArrowComponent'Default__Pawn_CriminalFixer.Arrow'*/,
			Default__Pawn_CriminalFixer_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
			Default__Pawn_CriminalFixer_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p'*/,
			Default__Pawn_CriminalFixer_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/,
			Default__Pawn_CriminalFixer_ActorCollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalFixer.ActorCollisionCylinder'*/,
			Default__Pawn_CriminalFixer_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment1P'*/,
		};
		CollisionComponent = Default__Pawn_CriminalFixer_CollisionCylinder/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/;
	}
}
}