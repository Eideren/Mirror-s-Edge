namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_Assault : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public TdBotPawn_Assault()
	{
		var Default__TdBotPawn_Assault_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Assault.ActorCollisionCylinder' */;
		var Default__TdBotPawn_Assault_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_Assault.MyLightEnvironment' */;
		var Default__TdBotPawn_Assault_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000207B6
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_Assault_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Assault.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Assault.TdPawnMesh3p' */;
		var Default__TdBotPawn_Assault_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_Assault.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_Assault_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_Assault.DrawFrust0' */;
		var Default__TdBotPawn_Assault_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Assault.CollisionCylinder' */;
		var Default__TdBotPawn_Assault_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_Assault.Arrow' */;
		// Object Offset:0x0001B8CA
		AnimationExitReloadTime = 2.10f;
		ActorCylinderComponent = Default__TdBotPawn_Assault_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Assault.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_Assault_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Assault.TdPawnMesh3p'*/;
		MoveClasses = new array< Core.ClassT<TdMove> >
		{
			default,
			ClassT<TdMove_Walking>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Melee_Assault>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_180TurnInAir>(),
			ClassT<TdMove_LayOnGroundBot>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_DodgeJump>(),
			ClassT<TdMove_WallrunDodgeJump>(),
			ClassT<TdMove_StumbleBot>(),
			ClassT<TdMove_DisarmedBot>(),
			ClassT<TdMove_StepUp>(),
			ClassT<TdMove_RumpSlide>(),
			ClassT<TdMove_Interact>(),
			ClassT<TdMove_WallRun>(),
			ClassT<TdMove_BotStop>(),
			ClassT<TdMove_BotStartWalking>(),
			ClassT<TdMove_BotStartRunning>(),
			ClassT<TdMove_BotTurnRunning>(),
			ClassT<TdMove_BotTurnStanding>(),
			ClassT<TdMove_ExitCover>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_MeleeSlide>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimb180TurnJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_BotMeleeSecondSwing_Assault>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_BotRoll>(),
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_MeleeWallrun>(),
			ClassT<TdMove_MeleeCrouch>(),
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_FallingUncontrolled>(),
			ClassT<TdMove_SwingJump>(),
			ClassT<TdMove_AnimationPlayback>(),
			ClassT<TdMove_EnterCover>(),
			ClassT<TdMove_Cover>(),
			ClassT<TdMove_BotStumbleFalling>(),
			ClassT<TdMove_SoftLanding>(),
			default,
			default,
			ClassT<TdMove_AutoStepUp>(),
			ClassT<TdMove_MeleeAirAboveBot>(),
			default,
			ClassT<TdMove_BotBlock>(),
			ClassT<TdMove_AirBarge>(),
			default,
			default,
			default,
			default,
			default,
			ClassT<TdMove_SkillRoll>(),
			default,
			ClassT<TdMove_Cutscene>(),
		};
		ArmorBulletsHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.50f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.50f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.50f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.50f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.50f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.50f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.40f,
			Hard = 0.50f,
		};
		SceneCapture = Default__TdBotPawn_Assault_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Assault.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_Assault_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Assault.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_Assault_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Assault.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_Assault_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Assault.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_Assault_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Assault.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_Assault_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Assault.DrawFrust0'*/,
			Default__TdBotPawn_Assault_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Assault.CollisionCylinder'*/,
			Default__TdBotPawn_Assault_Arrow/*Ref ArrowComponent'Default__TdBotPawn_Assault.Arrow'*/,
			Default__TdBotPawn_Assault_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Assault.MyLightEnvironment'*/,
			Default__TdBotPawn_Assault_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Assault.TdPawnMesh3p'*/,
			Default__TdBotPawn_Assault_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Assault.CollisionCylinder'*/,
			Default__TdBotPawn_Assault_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Assault.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_Assault_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Assault.CollisionCylinder'*/;
	}
}
}