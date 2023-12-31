namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_PatrolCop : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */SoundCue GetSpecificFootStepSound(TdPhysicalMaterialFootSteps FootStepSounds, int FootDown)
	{
		// stub
		return default;
	}
	
	public TdBotPawn_PatrolCop()
	{
		var Default__TdBotPawn_PatrolCop_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop.MyLightEnvironment' */;
		var Default__TdBotPawn_PatrolCop_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001D250
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_PatrolCop_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.TdPawnMesh3p' */;
		var Default__TdBotPawn_PatrolCop_AdditionalSkeletalMeshComponent = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001D2D4
			ParentAnimComponent = Default__TdBotPawn_PatrolCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.TdPawnMesh3p'*/,
			bDisableWarningWhenAnimNotFound = true,
			ShadowParent = Default__TdBotPawn_PatrolCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.TdPawnMesh3p'*/,
			LightEnvironment = Default__TdBotPawn_PatrolCop_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.AdditionalSkeletalMeshComponent' */;
		var Default__TdBotPawn_PatrolCop_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_PatrolCop.ActorCollisionCylinder' */;
		var Default__TdBotPawn_PatrolCop_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_PatrolCop_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_PatrolCop.DrawFrust0' */;
		var Default__TdBotPawn_PatrolCop_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_PatrolCop.CollisionCylinder' */;
		var Default__TdBotPawn_PatrolCop_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_PatrolCop.Arrow' */;
		// Object Offset:0x0001CB15
		AdditionalSkeletalMesh = Default__TdBotPawn_PatrolCop_AdditionalSkeletalMeshComponent/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.AdditionalSkeletalMeshComponent'*/;
		ActorCylinderComponent = Default__TdBotPawn_PatrolCop_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_PatrolCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.TdPawnMesh3p'*/;
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
			ClassT<TdMove_Melee_PatrolCop>(),
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
			ClassT<TdMove_Disabled>(),
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
			Hard = 0.20f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Hard = 0.20f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Hard = 0.20f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Hard = 0.10f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Hard = 0.10f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Hard = 0.10f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Hard = 0.20f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Hard = 0.20f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Hard = 0.20f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Hard = 0.10f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Hard = 0.10f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Hard = 0.10f,
		};
		SceneCapture = Default__TdBotPawn_PatrolCop_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_PatrolCop_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_PatrolCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_PatrolCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_PatrolCop_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_PatrolCop_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop.DrawFrust0'*/,
			Default__TdBotPawn_PatrolCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop.CollisionCylinder'*/,
			Default__TdBotPawn_PatrolCop_Arrow/*Ref ArrowComponent'Default__TdBotPawn_PatrolCop.Arrow'*/,
			Default__TdBotPawn_PatrolCop_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop.MyLightEnvironment'*/,
			Default__TdBotPawn_PatrolCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop.TdPawnMesh3p'*/,
			Default__TdBotPawn_PatrolCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop.CollisionCylinder'*/,
			Default__TdBotPawn_PatrolCop_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_PatrolCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop.CollisionCylinder'*/;
	}
}
}