namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_PoliceRiotUnit : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_PoliceRiotUnit()
	{
		// Object Offset:0x0000AB42
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011168
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1p' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000111EC
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p' */;
		Mesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001119C
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__Pawn_PoliceRiotUnit.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh1pLowerBody' */;
		bIsFemale = false;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__Pawn_PoliceRiotUnit.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_PoliceRiotUnit.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000111EC
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceRiotUnit.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_PoliceRiotUnit.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__Pawn_PoliceRiotUnit.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_PoliceRiotUnit.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceRiotUnit.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__Pawn_PoliceRiotUnit.Arrow")/*Ref ArrowComponent'Default__Pawn_PoliceRiotUnit.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x000111EC
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__Pawn_PoliceRiotUnit.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceRiotUnit.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_PoliceRiotUnit.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Pawn_PoliceRiotUnit.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_PoliceRiotUnit.CollisionCylinder'*/;
	}
}
}