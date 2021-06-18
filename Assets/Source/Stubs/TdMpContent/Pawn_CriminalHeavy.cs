namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_CriminalHeavy : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_CriminalHeavy()
	{
		var Default__Pawn_CriminalHeavy_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010FF8
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalHeavy.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1p' */;
		var Default__Pawn_CriminalHeavy_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001107C
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalHeavy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh3p' */;
		var Default__Pawn_CriminalHeavy_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001102C
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__Pawn_CriminalHeavy.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalHeavy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalHeavy.TdPawnMesh1pLowerBody' */;
		// Object Offset:0x0000A6D0
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalHeavy.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.ActorCollisionCylinder'*/;
		Mesh1p = Default__Pawn_CriminalHeavy_TdPawnMesh1p;
		Mesh3p = Default__Pawn_CriminalHeavy_TdPawnMesh3p;
		Mesh1pLowerBody = Default__Pawn_CriminalHeavy_TdPawnMesh1pLowerBody;
		bIsFemale = false;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__Pawn_CriminalHeavy.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_CriminalHeavy.DrawFrust0'*/;
		Mesh = Default__Pawn_CriminalHeavy_TdPawnMesh3p;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalHeavy.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalHeavy.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__Pawn_CriminalHeavy.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_CriminalHeavy.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalHeavy.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__Pawn_CriminalHeavy.Arrow")/*Ref ArrowComponent'Default__Pawn_CriminalHeavy.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalHeavy.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment'*/,
			Default__Pawn_CriminalHeavy_TdPawnMesh3p,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalHeavy.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalHeavy.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalHeavy.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalHeavy.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalHeavy.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalHeavy.CollisionCylinder'*/;
	}
}
}