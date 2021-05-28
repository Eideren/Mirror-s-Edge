namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_PatrolCop_Remington : TdBotPawn_PatrolCop/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public TdBotPawn_PatrolCop_Remington()
	{
		// Object Offset:0x0001D35C
		DeathAnimDeathFrontHard = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 1.0f,
		};
		DeathAnimDeathBackHard = new TdBotPawn.DeathAnimData
		{
			PawnImpulse = 450.0f,
			PawnZImpulse = 300.0f,
			BoneImpulse = 800.0f,
			GravityModifier = 0.820f,
			TimeToEnableRagdoll = 0.250f,
			TimeToBlendOutMotors = 0.40f,
			TimeToBoneImpulse = 0.270f,
		};
		DeathAnimDeathByAuto = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 0.70f,
			PawnImpulse = 500.0f,
			PawnZImpulse = 75.0f,
			BoneImpulse = 150.0f,
		};
		AdditionalSkeletalMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022AC2
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p")/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p'*/,
			ShadowParent = LoadAsset<TdSkeletalMeshComponent>("Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p")/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Remington.AdditionalSkeletalMeshComponent' */;
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Remington.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Remington.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022B2E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p' */;
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
			ClassT<TdMove_Melee_PatrolCop_Remington>(),
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
			ClassT<TdMove_BotMeleeSecondSwing_CopRemington>(),
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
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Medium = 0.10f,
			Hard = 0.30f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.30f,
		};
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_PatrolCop_Remington.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Remington.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_PatrolCop_Remington.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Remington.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022B2E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_PatrolCop_Remington.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PatrolCop_Remington.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_PatrolCop_Remington.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_PatrolCop_Remington.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_PatrolCop_Remington.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_PatrolCop_Remington.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00022B2E
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PatrolCop_Remington.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PatrolCop_Remington.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Remington.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Remington.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PatrolCop_Remington.CollisionCylinder'*/;
	}
}
}