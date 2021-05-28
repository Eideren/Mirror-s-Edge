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
	public /*function */void TdBotPawn_Celeste_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo HitInfo = default, /*optional */Actor DamageCauser = default)
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
		// Object Offset:0x00002EB6
		CMaxPathDistSq = 25000000.0f;
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Celeste.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Celeste.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00003A7E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Celeste.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p' */;
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
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_Celeste.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_Celeste.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00003A7E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Celeste.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Celeste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_Celeste.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_Celeste.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_Celeste.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Celeste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_Celeste.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_Celeste.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Celeste.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00003A7E
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_Celeste.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_Celeste.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_Celeste.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Celeste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_Celeste.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Celeste.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_Celeste.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_Celeste.CollisionCylinder'*/;
	}
}
}