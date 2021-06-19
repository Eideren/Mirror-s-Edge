namespace MEdge.TdSpBossContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_Celeste : TdBotPawn_PursuitCop/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */bool LoseWeaponAfterDisarm()
	{
	
		return default;
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdBotPawn_Celeste_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdBotPawn_Celeste_TakeDamage;
	public /*function */void TdBotPawn_Celeste_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public override RegenerateHealth_del RegenerateHealth { get => bfield_RegenerateHealth ?? TdBotPawn_Celeste_RegenerateHealth; set => bfield_RegenerateHealth = value; } RegenerateHealth_del bfield_RegenerateHealth;
	public override RegenerateHealth_del global_RegenerateHealth => TdBotPawn_Celeste_RegenerateHealth;
	public /*function */void TdBotPawn_Celeste_RegenerateHealth(float DeltaTime)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
		RegenerateHealth = null;
	
	}
	public TdBotPawn_Celeste()
	{
		var Default__TdBotPawn_Celeste_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Celeste.ActorCollisionCylinder' */;
		var Default__TdBotPawn_Celeste_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment' */;
		var Default__TdBotPawn_Celeste_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00003A7E
			LightEnvironment = Default__TdBotPawn_Celeste_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p' */;
		var Default__TdBotPawn_Celeste_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_Celeste_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_Celeste.DrawFrust0' */;
		var Default__TdBotPawn_Celeste_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder' */;
		var Default__TdBotPawn_Celeste_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_Celeste.Arrow' */;
		// Object Offset:0x00002EB6
		CMaxPathDistSq = 25000000.0f;
		ActorCylinderComponent = Default__TdBotPawn_Celeste_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Celeste.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_Celeste_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p'*/;
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
			ClassT<TdMove_Melee_BossCeleste>(),
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
			ClassT<TdMove_Stumble_BossCeleste>(),
			ClassT<TdMove_Disarmed_BossCeleste>(),
			ClassT<TdMove_StepUp>(),
			ClassT<TdMove_RumpSlide>(),
			ClassT<TdMove_Interact>(),
			ClassT<TdMove_WallRunBot>(),
			ClassT<TdMove_BotStopCeleste>(),
			ClassT<TdMove_BotStartWalking>(),
			ClassT<TdMove_BotStartRunning>(),
			ClassT<TdMove_BotTurnRunning>(),
			ClassT<TdMove_BotTurnStandingCeleste>(),
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
			ClassT<TdMove_Disabled>(),
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
			Easy = 0.20f,
			Hard = 0.20f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.60f,
			Medium = 0.60f,
			Hard = 0.60f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.50f,
			Hard = 0.50f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.0f,
			Medium = 0.0f,
			Hard = 0.0f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.0f,
			Medium = 0.0f,
			Hard = 0.0f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.0f,
			Medium = 0.0f,
			Hard = 0.0f,
		};
		SceneCapture = Default__TdBotPawn_Celeste_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_Celeste_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Celeste.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_Celeste_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_Celeste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_Celeste_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_Celeste_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Celeste.DrawFrust0'*/,
			Default__TdBotPawn_Celeste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/,
			Default__TdBotPawn_Celeste_Arrow/*Ref ArrowComponent'Default__TdBotPawn_Celeste.Arrow'*/,
			Default__TdBotPawn_Celeste_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment'*/,
			Default__TdBotPawn_Celeste_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p'*/,
			Default__TdBotPawn_Celeste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/,
			Default__TdBotPawn_Celeste_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Celeste.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_Celeste_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/;
	}
}
}