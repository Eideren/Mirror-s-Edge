namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_CriminalProwler : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_CriminalProwler()
	{
		// Object Offset:0x0000A917
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalProwler.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalProwler.ActorCollisionCylinder'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000110B0
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1p' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011134
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p' */;
		Mesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000110E4
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__Pawn_CriminalProwler.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh1pLowerBody' */;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__Pawn_CriminalProwler.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_CriminalProwler.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011134
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalProwler.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalProwler.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__Pawn_CriminalProwler.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_CriminalProwler.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalProwler.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__Pawn_CriminalProwler.Arrow")/*Ref ArrowComponent'Default__Pawn_CriminalProwler.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00011134
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalProwler.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalProwler.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalProwler.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalProwler.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalProwler.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalProwler.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalProwler.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalProwler.CollisionCylinder'*/;
	}
}
}