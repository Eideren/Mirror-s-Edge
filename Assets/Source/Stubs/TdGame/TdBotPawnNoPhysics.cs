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
		// Object Offset:0x0052E774
		ActorCylinderComponent = new CylinderComponent
		{
			// Object Offset:0x01AB4996
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.ActorCollisionCylinder' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031281AE
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawnNoPhysics.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawnNoPhysics.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawnNoPhysics.TdPawnMesh3p' */;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawnNoPhysics.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawnNoPhysics.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031281AE
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawnNoPhysics.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawnNoPhysics.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawnNoPhysics.TdPawnMesh3p' */;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x01AB4A02
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.CollisionCylinder' */;
		bAlwaysRelevant = true;
		bCollideActors = false;
		bBlockActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawnNoPhysics.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawnNoPhysics.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawnNoPhysics.DrawFrust0'*/,
			//Components[2]=
			new CylinderComponent
			{
				// Object Offset:0x01AB4A02
				CollideActors = false,
				BlockActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.CollisionCylinder' */,
			LoadAsset<ArrowComponent>("Default__TdBotPawnNoPhysics.Arrow")/*Ref ArrowComponent'Default__TdBotPawnNoPhysics.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawnNoPhysics.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawnNoPhysics.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x031281AE
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawnNoPhysics.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawnNoPhysics.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawnNoPhysics.TdPawnMesh3p' */,
			//Components[6]=
			new CylinderComponent
			{
				// Object Offset:0x01AB4A02
				CollideActors = false,
				BlockActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.CollisionCylinder' */,
			//Components[7]=
			new CylinderComponent
			{
				// Object Offset:0x01AB4996
				CollideActors = false,
				BlockActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.ActorCollisionCylinder' */,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x01AB4A02
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdBotPawnNoPhysics.CollisionCylinder' */;
	}
}
}