namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_PursuitCop : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ float FootStepPitchMultiplier;
	
	public override /*function */bool CanBlock()
	{
	
		return default;
	}
	
	public override /*function */SoundCue GetSpecificFootStepSound(TdPhysicalMaterialFootSteps FootStepSounds, int FootDown)
	{
	
		return default;
	}
	
	public override /*function */bool ShouldMeleeCauseStumbleFar()
	{
	
		return default;
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdBotPawn_PursuitCop_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdBotPawn_PursuitCop_TakeDamage;
	public /*function */void TdBotPawn_PursuitCop_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public override /*function */bool IsDoingSpecialMove()
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public TdBotPawn_PursuitCop()
	{
		// Object Offset:0x0001ED14
		FootStepPitchMultiplier = 1.50f;
		bCanDoTakedownMoves = true;
		AudibleFeetRange = 5000.0f;
		DeathAnimDeathFrontHard = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 1.0f,
			PawnImpulse = 650.0f,
			PawnZImpulse = 400.0f,
		};
		DeathAnimDeathBackHard = new TdBotPawn.DeathAnimData
		{
			PlaybackSpeed = 1.0f,
			PawnImpulse = 450.0f,
			PawnZImpulse = 300.0f,
			BoneImpulse = 800.0f,
			GravityModifier = 0.80f,
			TimeToEnableRagdoll = 0.10f,
			TimeToBlendOutMotors = 0.20f,
			TimeToDisableMotors = 0.250f,
			TimeToBoneImpulse = 0.120f,
			TimeToFullRagdoll = 0.250f,
		};
		DeathAnimDeathByAuto = new TdBotPawn.DeathAnimData
		{
			PawnImpulse = 800.0f,
			PawnZImpulse = 250.0f,
		};
		MaxLookAhead = 230;
		MaxRotationSpeed = 30000;
		MaxRotationAcceleration = 160000;
		RotationSpeedDiffForMaxAcceleration = 18000;
		AnimationRunSpeed = 720.0f;
		bDisableSkelControlSpring = true;
		ActorCylinderComponent = new CylinderComponent
		{
			// Object Offset:0x000225DA
			CollisionRadius = 70.0f,
		}/* Reference: CylinderComponent'Default__TdBotPawn_PursuitCop.ActorCollisionCylinder' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022C02
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PursuitCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PursuitCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PursuitCop.TdPawnMesh3p' */;
		MoveClasses = new array< Core.ClassT<TdMove> >
		{
			default,
			ClassT<TdMove_Walking>(),
			ClassT<TdMove_FallingBot>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_VaultBot>(),
			ClassT<TdMove_VaultBot>(),
			ClassT<TdMove_GrabPullUpBot>(),
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_SlideBot>(),
			ClassT<TdMove_PursuitMelee>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_BotLanding>(),
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
			ClassT<TdMove_Stumble_Pursuit>(),
			ClassT<TdMove_DisarmedBot>(),
			ClassT<TdMove_StepUp>(),
			ClassT<TdMove_RumpSlide>(),
			ClassT<TdMove_Interact>(),
			ClassT<TdMove_WallRunBot>(),
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
			ClassT<TdMove_BotFlip>(),
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_MeleeWallrun>(),
			ClassT<TdMove_MeleeCrouch>(),
			ClassT<TdMove_JumpBot_Short>(),
			ClassT<TdMove_JumpBot_Medium>(),
			ClassT<TdMove_JumpBot_Long>(),
			ClassT<TdMove_JumpIntoGrabBot>(),
			ClassT<TdMove_StandGrabHeaveBot>(),
			ClassT<TdMove_BotMeleeDodge>(),
			ClassT<TdMove_BotPursuitFinishingAttack>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_FallingUncontrolled>(),
			ClassT<TdMove_SwingJump>(),
			ClassT<TdMove_AnimationPlayback>(),
			ClassT<TdMove_EnterCover>(),
			ClassT<TdMove_Cover>(),
			ClassT<TdMove_Disabled>(),
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
			ClassT<TdMove_BotPursuitGetDistance>(),
			ClassT<TdMove_Cutscene>(),
		};
		ArmorBulletsHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.10f,
			Medium = 0.20f,
			Hard = 0.40f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Medium = 0.50f,
			Hard = 0.60f,
		};
		bCanWalkOffLedges = true;
		WalkingPct = 0.30f;
		AIMaxFallSpeedFactor = 3.0f;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_PursuitCop.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PursuitCop.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_PursuitCop.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_PursuitCop.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022C02
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PursuitCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PursuitCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PursuitCop.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PursuitCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PursuitCop.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_PursuitCop.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_PursuitCop.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_PursuitCop.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_PursuitCop.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PursuitCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PursuitCop.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_PursuitCop.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_PursuitCop.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PursuitCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PursuitCop.MyLightEnvironment'*/,
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00022C02
				AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_PursuitCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_PursuitCop.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_PursuitCop.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_PursuitCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PursuitCop.CollisionCylinder'*/,
			new CylinderComponent
			{
				// Object Offset:0x000225DA
				CollisionRadius = 70.0f,
			}/* Reference: CylinderComponent'Default__TdBotPawn_PursuitCop.ActorCollisionCylinder' */,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_PursuitCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_PursuitCop.CollisionCylinder'*/;
	}
}
}