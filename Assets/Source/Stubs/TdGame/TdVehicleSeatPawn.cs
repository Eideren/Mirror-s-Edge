namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdVehicleSeatPawn : SVehicle/*
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public TdVehicleSeatPawn()
	{
		var Default__TdVehicleSeatPawn_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB50F6
			CollisionHeight = 0.0f,
			CollisionRadius = 0.0f,
			CollideActors = false,
			BlockActors = false,
			BlockZeroExtent = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdVehicleSeatPawn.CollisionCylinder' */;
		// Object Offset:0x006BF940
		StayUprightConstraintSetup = LoadAsset<RB_StayUprightSetup>("Default__TdVehicleSeatPawn.MyStayUprightSetup")/*Ref RB_StayUprightSetup'Default__TdVehicleSeatPawn.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__TdVehicleSeatPawn.MyStayUprightConstraintInstance")/*Ref RB_ConstraintInstance'Default__TdVehicleSeatPawn.MyStayUprightConstraintInstance'*/;
		bTurnInPlace = true;
		bFollowLookDir = true;
		bStationary = true;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdVehicleSeatPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdVehicleSeatPawn.DrawFrust0'*/;
		Mesh = LoadAsset<SkeletalMeshComponent>("Default__TdVehicleSeatPawn.SVehicleMesh")/*Ref SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh'*/;
		CylinderComponent = Default__TdVehicleSeatPawn_CollisionCylinder;
		InventoryManagerClass = ClassT<TdInventoryManager>()/*Ref Class'TdInventoryManager'*/;
		bIgnoreBaseRotation = true;
		bCollideActors = false;
		bCollideWorld = false;
		bProjTarget = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdVehicleSeatPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdVehicleSeatPawn.DrawFrust0'*/,
			Default__TdVehicleSeatPawn_CollisionCylinder,
			LoadAsset<SkeletalMeshComponent>("Default__TdVehicleSeatPawn.SVehicleMesh")/*Ref SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh'*/,
		};
		Physics = Actor.EPhysics.PHYS_None;
		CollisionComponent = LoadAsset<SkeletalMeshComponent>("Default__TdVehicleSeatPawn.SVehicleMesh")/*Ref SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh'*/;
	}
}
}