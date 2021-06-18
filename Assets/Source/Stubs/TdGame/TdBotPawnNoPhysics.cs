namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawnNoPhysics : TdBotPawn/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override SetMove_del SetMove { get => bfield_SetMove ?? TdBotPawnNoPhysics_SetMove; set => bfield_SetMove = value; } SetMove_del bfield_SetMove;
	public override SetMove_del global_SetMove => TdBotPawnNoPhysics_SetMove;
	public /*simulated event */bool TdBotPawnNoPhysics_SetMove(TdPawn.EMovement NewMove, /*optional */bool? _bViaReplication = default, /*optional */bool? _bCheckCanDo = default)
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		SetMove = null;
	
	}
	public TdBotPawnNoPhysics()
	{
		var Default__TdBotPawnNoPhysics_ActorCollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4996
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.ActorCollisionCylinder' */;
		var Default__TdBotPawnNoPhysics_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031281AE
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawnNoPhysics.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawnNoPhysics.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawnNoPhysics.TdPawnMesh3p' */;
		var Default__TdBotPawnNoPhysics_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4A02
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.CollisionCylinder' */;
		// Object Offset:0x0052E774
		ActorCylinderComponent = Default__TdBotPawnNoPhysics_ActorCollisionCylinder;
		Mesh3p = Default__TdBotPawnNoPhysics_TdPawnMesh3p;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawnNoPhysics.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawnNoPhysics.DrawFrust0'*/;
		Mesh = Default__TdBotPawnNoPhysics_TdPawnMesh3p;
		CylinderComponent = Default__TdBotPawnNoPhysics_CollisionCylinder;
		bAlwaysRelevant = true;
		bCollideActors = false;
		bBlockActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawnNoPhysics.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawnNoPhysics.DrawFrust0'*/,
			Default__TdBotPawnNoPhysics_CollisionCylinder,
			LoadAsset<ArrowComponent>("Default__TdBotPawnNoPhysics.Arrow")/*Ref ArrowComponent'Default__TdBotPawnNoPhysics.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawnNoPhysics.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawnNoPhysics.MyLightEnvironment'*/,
			Default__TdBotPawnNoPhysics_TdPawnMesh3p,
			Default__TdBotPawnNoPhysics_CollisionCylinder,
			Default__TdBotPawnNoPhysics_ActorCollisionCylinder,
		};
		CollisionComponent = Default__TdBotPawnNoPhysics_CollisionCylinder;
	}
}
}