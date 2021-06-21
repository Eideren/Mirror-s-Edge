namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_Tutorial : TdBotPawn/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public virtual /*exec function */void AnimationHideWeapon()
	{
		// stub
	}
	
	public override /*simulated function */void Turn(float DeltaTime)
	{
		// stub
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdBotPawn_Tutorial_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdBotPawn_Tutorial_TakeDamage;
	public /*function */void TdBotPawn_Tutorial_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
		// stub
	}
	
	public override /*event */void AddToInventory(Core.ClassT<TdWeapon> WeaponClass)
	{
		// stub
	}
	
	public override /*function */bool PreventWeaponImpactEffect(Controller InstigatorController)
	{
		// stub
		return default;
	}
	
	public override Landed_del Landed { get => bfield_Landed ?? TdBotPawn_Tutorial_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public override Landed_del global_Landed => TdBotPawn_Tutorial_Landed;
	public /*event */void TdBotPawn_Tutorial_Landed(Object.Vector iNormal, Actor iActor)
	{
		// stub
	}
	
	public override /*function */bool ShouldBlock(Core.ClassT<DamageType> MeleeDamageType)
	{
		// stub
		return default;
	}
	
	public override /*function */bool ShouldMeleeCauseFall()
	{
		// stub
		return default;
	}
	
	public override /*function */bool ShouldMeleeCauseStumbleFar()
	{
		// stub
		return default;
	}
	
	public override /*function */void UseLegRotation(bool UseLegRotation)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
		Landed = null;
	
	}
	public TdBotPawn_Tutorial()
	{
		var Default__TdBotPawn_Tutorial_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Tutorial.ActorCollisionCylinder' */;
		var Default__TdBotPawn_Tutorial_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x01B6866E
			bEnabled = false,
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdBotPawn_Tutorial.MyLightEnvironment' */;
		var Default__TdBotPawn_Tutorial_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031280FE
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Cop.AT_Cop")/*Ref AnimTree'AT_Cop.AT_Cop'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Cop_SWAT.Male3p_Physics")/*Ref PhysicsAsset'CH_TKY_Cop_SWAT.Male3p_Physics'*/,
			LightEnvironment = Default__TdBotPawn_Tutorial_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Tutorial.MyLightEnvironment'*/,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Cinematic_2 = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Tutorial.TdPawnMesh3p' */;
		var Default__TdBotPawn_Tutorial_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdBotPawn_Tutorial.SceneCaptureCharacterComponent0' */;
		var Default__TdBotPawn_Tutorial_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdBotPawn_Tutorial.DrawFrust0' */;
		var Default__TdBotPawn_Tutorial_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdBotPawn_Tutorial.CollisionCylinder' */;
		var Default__TdBotPawn_Tutorial_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBotPawn_Tutorial.Arrow' */;
		// Object Offset:0x0052E221
		bUseLegRotation = false;
		bHeadPitchAlwaysOk = true;
		bDisableSkelControlSpring = true;
		ActorCylinderComponent = Default__TdBotPawn_Tutorial_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Tutorial.ActorCollisionCylinder'*/;
		Mesh3p = Default__TdBotPawn_Tutorial_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Tutorial.TdPawnMesh3p'*/;
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
			ClassT<TdMove_MeleeDummy>(),
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
			ClassT<TdMove_StumbleTutorialBot>(),
			ClassT<TdMove_DisarmedTutorial>(),
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
		SceneCapture = Default__TdBotPawn_Tutorial_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Tutorial.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdBotPawn_Tutorial_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Tutorial.DrawFrust0'*/;
		Mesh = Default__TdBotPawn_Tutorial_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Tutorial.TdPawnMesh3p'*/;
		CylinderComponent = Default__TdBotPawn_Tutorial_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Tutorial.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBotPawn_Tutorial_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Tutorial.SceneCaptureCharacterComponent0'*/,
			Default__TdBotPawn_Tutorial_DrawFrust0/*Ref DrawFrustumComponent'Default__TdBotPawn_Tutorial.DrawFrust0'*/,
			Default__TdBotPawn_Tutorial_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Tutorial.CollisionCylinder'*/,
			Default__TdBotPawn_Tutorial_Arrow/*Ref ArrowComponent'Default__TdBotPawn_Tutorial.Arrow'*/,
			Default__TdBotPawn_Tutorial_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Tutorial.MyLightEnvironment'*/,
			Default__TdBotPawn_Tutorial_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdBotPawn_Tutorial.TdPawnMesh3p'*/,
			Default__TdBotPawn_Tutorial_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Tutorial.CollisionCylinder'*/,
			Default__TdBotPawn_Tutorial_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Tutorial.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdBotPawn_Tutorial_CollisionCylinder/*Ref CylinderComponent'Default__TdBotPawn_Tutorial.CollisionCylinder'*/;
	}
}
}