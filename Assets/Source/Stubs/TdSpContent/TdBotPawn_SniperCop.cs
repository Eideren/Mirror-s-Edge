namespace MEdge.TdSpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn_SniperCop : TdBotPawn_Assault/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */void PauseFiring()
	{
	
	}
	
	public TdBotPawn_SniperCop()
	{
		// Object Offset:0x00020910
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCop.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCop.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022CDA
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SniperCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SniperCop.TdPawnMesh3p' */;
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
			ClassT<TdMove_BotMeleeSecondSwing_Sniper>(),
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
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_SniperCop.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCop.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_SniperCop.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_SniperCop.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00022CDA
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SniperCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCop.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SniperCop.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCop.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn_SniperCop.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn_SniperCop.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn_SniperCop.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn_SniperCop.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCop.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn_SniperCop.Arrow")/*Ref ArrowComponent'Default__TdBotPawn_SniperCop.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SniperCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCop.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00022CDA
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn_SniperCop.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn_SniperCop.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn_SniperCop.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCop.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCop.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCop.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn_SniperCop.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn_SniperCop.CollisionCylinder'*/;
	}
}
}