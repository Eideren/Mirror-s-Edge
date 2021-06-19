namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_Support : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */void SetWalking(bool Walk)
	{
	
	}
	
	public TdBotPawn_Support()
	{
		var Default__TdBotPawn_Support_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Support.ActorCollisionCylinder' */;
		var Default__TdBotPawn_Support_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment' */;
		var Default__TdBotPawn_Support_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022D0E
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_Support_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p' */;
		var Default__TdBotPawn_Support_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_Support.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_Support_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_Support.DrawFrust0' */;
		var Default__TdBotPawn_Support_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder' */;
		var Default__TdBotPawn_Support_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_Support.Arrow' */;
		// Object Offset:0x000212BC
		DeathAnimDeathFront = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 0.50f,
			PawnImpulse = 250.0f,
			PawnZImpulse = 75.0f,
			BoneImpulse = 50.0f,
			GravityModifier = 1.0f,
			TimeToDisableMotors = 0.40f,
			TimeToFullRagdoll = 0.40f,
		};
		DeathAnimDeathFrontHard = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 0.70f,
			PawnImpulse = 50.0f,
			PawnZImpulse = 50.0f,
			BoneImpulse = 50.0f,
			GravityModifier = 1.0f,
			TimeToEnableRagdoll = 0.10f,
			TimeToBlendOutMotors = 0.150f,
			TimeToDisableMotors = 0.30f,
			TimeToFullRagdoll = 0.30f,
		};
		DeathAnimDeathBackHard = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 1.0f,
			PawnImpulse = 300.0f,
			PawnZImpulse = 175.0f,
			BoneImpulse = 50.0f,
			GravityModifier = 1.0f,
			TimeToEnableRagdoll = 0.10f,
			TimeToBlendOutMotors = 0.20f,
			TimeToDisableMotors = 0.150f,
			TimeToBoneImpulse = 0.120f,
			TimeToFullRagdoll = 0.150f,
		};
		DeathAnimDeathByAuto = new TdBotPawn.DeathAnimData
		{
			PawnImpulse = 50.0f,
			PawnZImpulse = 100.0f,
			GravityModifier = 1.0f,
			TimeToEnableRagdoll = 0.40f,
			TimeToBlendOutMotors = 0.30f,
			TimeToDisableMotors = 0.50f,
			TimeToBoneImpulse = 0.450f,
			TimeToFullRagdoll = 0.50f,
		};
		AnimationWalkSpeed = 140.0f;
		ActorCylinderComponent = Default__TdBotPawn_Support_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Support.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_Support_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p'*/;
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
			ClassT<TdMove_Melee_SupportCop>(),
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
			ClassT<TdMove_BotMeleeSecondSwing_Support>(),
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
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.70f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.40f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		SceneCapture = Default__TdBotPawn_Support_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Support.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_Support_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Support.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_Support_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_Support_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_Support_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Support.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_Support_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Support.DrawFrust0'*/,
			Default__TdBotPawn_Support_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/,
			Default__TdBotPawn_Support_Arrow/*Ref ArrowComponent'Default__TdBotPawn_Support.Arrow'*/,
			Default__TdBotPawn_Support_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment'*/,
			Default__TdBotPawn_Support_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p'*/,
			Default__TdBotPawn_Support_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/,
			Default__TdBotPawn_Support_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Support.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_Support_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/;
	}
}
}