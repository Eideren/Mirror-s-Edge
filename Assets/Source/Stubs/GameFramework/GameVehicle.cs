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
		// Object Offset:0x00008401
		StayUprightConstraintSetup = LoadAsset<RB_StayUprightSetup>("Default__GameVehicle.MyStayUprightSetup")/*Ref RB_StayUprightSetup'Default__GameVehicle.MyStayUprightSetup'*/;
		StayUprightConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__GameVehicle.MyStayUprightConstraintInstance")/*Ref RB_ConstraintInstance'Default__GameVehicle.MyStayUprightConstraintInstance'*/;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__GameVehicle.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__GameVehicle.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__GameVehicle.DrawFrust0")/*Ref DrawFrustumComponent'Default__GameVehicle.DrawFrust0'*/;
		Mesh = LoadAsset<SkeletalMeshComponent>("Default__GameVehicle.SVehicleMesh")/*Ref SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__GameVehicle.CollisionCylinder")/*Ref CylinderComponent'Default__GameVehicle.CollisionCylinder'*/;
		bCanBeAdheredTo = true;
		bCanBeFrictionedTo = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__GameVehicle.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__GameVehicle.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__GameVehicle.DrawFrust0")/*Ref DrawFrustumComponent'Default__GameVehicle.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__GameVehicle.CollisionCylinder")/*Ref CylinderComponent'Default__GameVehicle.CollisionCylinder'*/,
			LoadAsset<SkeletalMeshComponent>("Default__GameVehicle.SVehicleMesh")/*Ref SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh'*/,
		};
		CollisionComponent = LoadAsset<SkeletalMeshComponent>("Default__GameVehicle.SVehicleMesh")/*Ref SkeletalMeshComponent'Default__GameVehicle.SVehicleMesh'*/;
	}
}
}