namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_RiotCop : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdBotPawn_RiotCop_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdBotPawn_RiotCop_TakeDamage;
	public /*function */void TdBotPawn_RiotCop_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public override /*function */bool CanBlock()
	{
	
		return default;
	}
	
	public override /*function */void SetWalking(bool Walk)
	{
	
	}
	
	public override /*function */bool ShouldMeleeCauseFall()
	{
	
		return default;
	}
	
	public override /*function */bool UseWeaponLOI()
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public TdBotPawn_RiotCop()
	{
		var Default__TdBotPawn_RiotCop_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_RiotCop.ActorCollisionCylinder' */;
		var Default__TdBotPawn_RiotCop_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_RiotCop.MyLightEnvironment' */;
		var Default__TdBotPawn_RiotCop_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022C6E
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_RiotCop_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_RiotCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_RiotCop.TdPawnMesh3p' */;
		var Default__TdBotPawn_RiotCop_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_RiotCop.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_RiotCop_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_RiotCop.DrawFrust0' */;
		var Default__TdBotPawn_RiotCop_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_RiotCop.CollisionCylinder' */;
		var Default__TdBotPawn_RiotCop_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_RiotCop.Arrow' */;
		// Object Offset:0x0001FDD3
		ActorCylinderComponent = Default__TdBotPawn_RiotCop_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_RiotCop.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_RiotCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_RiotCop.TdPawnMesh3p'*/;
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
			ClassT<TdMove_Melee_Riot>(),
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
			Easy = 0.50f,
			Medium = 0.60f,
			Hard = 0.80f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.60f,
			Hard = 0.80f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.60f,
			Hard = 0.80f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.40f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.40f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.40f,
		};
		ArmorBulletsHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.60f,
			Hard = 0.80f,
		};
		ArmorBulletsBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.60f,
			Hard = 0.80f,
		};
		ArmorBulletsLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.50f,
			Medium = 0.60f,
			Hard = 0.80f,
		};
		ArmorMeleeHeadSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.40f,
		};
		ArmorMeleeBodySettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.40f,
		};
		ArmorMeleeLegsSettings_CHASE = new TdPawn.ArmorSettings
		{
			Easy = 0.20f,
			Medium = 0.30f,
			Hard = 0.40f,
		};
		SceneCapture = Default__TdBotPawn_RiotCop_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_RiotCop.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_RiotCop_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_RiotCop.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_RiotCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_RiotCop.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_RiotCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_RiotCop.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_RiotCop_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_RiotCop.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_RiotCop_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_RiotCop.DrawFrust0'*/,
			Default__TdBotPawn_RiotCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_RiotCop.CollisionCylinder'*/,
			Default__TdBotPawn_RiotCop_Arrow/*Ref ArrowComponent'Default__TdBotPawn_RiotCop.Arrow'*/,
			Default__TdBotPawn_RiotCop_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_RiotCop.MyLightEnvironment'*/,
			Default__TdBotPawn_RiotCop_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_RiotCop.TdPawnMesh3p'*/,
			Default__TdBotPawn_RiotCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_RiotCop.CollisionCylinder'*/,
			Default__TdBotPawn_RiotCop_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_RiotCop.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_RiotCop_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_RiotCop.CollisionCylinder'*/;
	}
}
}