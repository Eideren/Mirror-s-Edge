namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameVehicle : SVehicle/*
		abstract
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public GameVehicle()
	{
		var Default__GameVehicle_MyStayUprightSetup = new RB_StayUprightSetup
		{
		}/* Reference: RB_StayUprightSetup'Default__GameVehicle.MyStayUprightSetup' */;
		var Default__GameVehicle_MyStayUprightConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__GameVehicle.MyStayUprightConstraintInstance' */;
		var Default__GameVehicle_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__GameVehicle.SceneCaptureCharacterComponent0' */;
		var Default__GameVehicle_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__GameVehicle.DrawFrust0' */;
		var Default__GameVehicle_SVehicleMesh = new SkeletalMeshComponent
		{
		}/* Reference: SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh' */;
		var Default__GameVehicle_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__GameVehicle.CollisionCylinder' */;
		// Object Offset:0x00008401
		StayUprightConstraintSetup = Default__GameVehicle_MyStayUprightSetup/*Ref RB_StayUprightSetup'Default__GameVehicle.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = Default__GameVehicle_MyStayUprightConstraintInstance/*Ref RB_ConstraintInstance'Default__GameVehicle.MyStayUprightConstraintInstance'*/;
		SceneCapture = Default__GameVehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__GameVehicle.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__GameVehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__GameVehicle.DrawFrust0'*/;
		Mesh = Default__GameVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh'*/;
		CylinderComponent = Default__GameVehicle_CollisionCylinder/*Ref CylinderComponent'Default__GameVehicle.CollisionCylinder'*/;
		bCanBeAdheredTo = true;
		bCanBeFrictionedTo = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__GameVehicle_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__GameVehicle.SceneCaptureCharacterComponent0'*/,
			Default__GameVehicle_DrawFrust0/*Ref DrawFrustumComponent'Default__GameVehicle.DrawFrust0'*/,
			Default__GameVehicle_CollisionCylinder/*Ref CylinderComponent'Default__GameVehicle.CollisionCylinder'*/,
			Default__GameVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh'*/,
		};
		CollisionComponent = Default__GameVehicle_SVehicleMesh/*Ref SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh'*/;
	}
}
}