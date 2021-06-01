namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn_CriminalFixer : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public Pawn_CriminalFixer()
	{
		// Object Offset:0x0000A4A5
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalFixer.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalFixer.ActorCollisionCylinder'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010F40
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1p' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010FC4
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p' */;
		Mesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010F74
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__Pawn_CriminalFixer.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh1pLowerBody' */;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__Pawn_CriminalFixer.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_CriminalFixer.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00010FC4
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalFixer.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__Pawn_CriminalFixer.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__Pawn_CriminalFixer.DrawFrust0")/*Ref DrawFrustumComponent'Default__Pawn_CriminalFixer.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalFixer.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__Pawn_CriminalFixer.Arrow")/*Ref ArrowComponent'Default__Pawn_CriminalFixer.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00010FC4
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__Pawn_CriminalFixer.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalFixer.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__Pawn_CriminalFixer.ActorCollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalFixer.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__Pawn_CriminalFixer.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__Pawn_CriminalFixer.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__Pawn_CriminalFixer.CollisionCylinder")/*Ref CylinderComponent'Default__Pawn_CriminalFixer.CollisionCylinder'*/;
	}
}
}