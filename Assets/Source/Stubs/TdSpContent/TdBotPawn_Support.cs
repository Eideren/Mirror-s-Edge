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
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Support.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Support.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022D0E
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Support.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p' */;
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
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_Support.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Support.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_Support.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_Support.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022D0E
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Support.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Support.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_Support.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Support.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_Support.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_Support.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Support.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_Support.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_Support.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Support.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00022D0E
				AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Support.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Support.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Support.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Support.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Support.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Support.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Support.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Support.CollisionCylinder'*/;
	}
}
}