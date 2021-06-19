namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdVehicleSeatPawn : SVehicle/*
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public TdVehicleSeatPawn()
	{
		var Default__TdVehicleSeatPawn_MyStayUprightSetup = new RB_StayUprightSetup
		{
		}/* Reference: RB_StayUprightSetup'Default__TdVehicleSeatPawn.MyStayUprightSetup' */;
		var Default__TdVehicleSeatPawn_MyStayUprightConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__TdVehicleSeatPawn.MyStayUprightConstraintInstance' */;
		var Default__TdVehicleSeatPawn_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0' */;
		var Default__TdVehicleSeatPawn_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdVehicleSeatPawn.DrawFrust0' */;
		var Default__TdVehicleSeatPawn_SVehicleMesh = new SkeletalMeshComponent
		{
		}/* Reference: SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh' */;
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
		StayUprightConstraintSetup = Default__TdVehicleSeatPawn_MyStayUprightSetup/*Ref RB_StayUprightSetup'Default__TdVehicleSeatPawn.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = Default__TdVehicleSeatPawn_MyStayUprightConstraintInstance/*Ref RB_ConstraintInstance'Default__TdVehicleSeatPawn.MyStayUprightConstraintInstance'*/;
		bTurnInPlace = true;
		bFollowLookDir = true;
		bStationary = true;
		SceneCapture = Default__TdVehicleSeatPawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdVehicleSeatPawn_DrawFrust0/*Ref DrawFrustumComponent'Default__TdVehicleSeatPawn.DrawFrust0'*/;
		Mesh = Default__TdVehicleSeatPawn_SVehicleMesh/*Ref SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh'*/;
		CylinderComponent = Default__TdVehicleSeatPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdVehicleSeatPawn.CollisionCylinder'*/;
		InventoryManagerClass = ClassT<TdInventoryManager>()/*Ref Class'TdInventoryManager'*/;
		bIgnoreBaseRotation = true;
		bCollideActors = false;
		bCollideWorld = false;
		bProjTarget = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdVehicleSeatPawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdVehicleSeatPawn.SceneCaptureCharacterComponent0'*/,
			Default__TdVehicleSeatPawn_DrawFrust0/*Ref DrawFrustumComponent'Default__TdVehicleSeatPawn.DrawFrust0'*/,
			Default__TdVehicleSeatPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdVehicleSeatPawn.CollisionCylinder'*/,
			Default__TdVehicleSeatPawn_SVehicleMesh/*Ref SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh'*/,
		};
		Physics = Actor.EPhysics.PHYS_None;
		CollisionComponent = Default__TdVehicleSeatPawn_SVehicleMesh/*Ref SkeletalMeshComponent'Default__TdVehicleSeatPawn.SVehicleMesh'*/;
	}
}
}