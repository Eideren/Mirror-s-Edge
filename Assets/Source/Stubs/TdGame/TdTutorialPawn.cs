namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTutorialPawn : TdPlayerPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public TdTutorialListener TutorialListener;
	
	public override SetMove_del SetMove { get => bfield_SetMove ?? TdTutorialPawn_SetMove; set => bfield_SetMove = value; } SetMove_del bfield_SetMove;
	public override SetMove_del global_SetMove => TdTutorialPawn_SetMove;
	public /*simulated event */bool TdTutorialPawn_SetMove(TdPawn.EMovement NewMove, /*optional */bool? _bViaReplication = default, /*optional */bool? _bCheckCanDo = default)
	{
	
		return default;
	}
	
	public override /*function */void OnTutorialEvent(int TutorialEvent)
	{
	
	}
	
	public override Died_del Died { get => bfield_Died ?? TdTutorialPawn_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => TdTutorialPawn_Died;
	public /*function */bool TdTutorialPawn_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
	
		return default;
	}
	
	public override /*function */void TossWeapon(Weapon Weap, /*optional */Object.Vector? _ForceVelocity = default)
	{
	
	}
	
	public override /*simulated function */void UpdateAnimSets(/*optional */TdWeapon? _iWeapon = default)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		SetMove = null;
		Died = null;
	
	}
	public TdTutorialPawn()
	{
		// Object Offset:0x0067FFE6
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdTutorialPawn.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialPawn.ActorCollisionCylinder'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031282BA
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment1P'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdTutorialPawn.TdPawnMesh1p' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0312833E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdTutorialPawn.TdPawnMesh3p' */;
		Mesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031282EE
			ParentAnimComponent = LoadAsset<TdSkeletalMeshComponent>("Default__TdTutorialPawn.TdPawnMesh1p")/*Ref TdSkeletalMeshComponent'Default__TdTutorialPawn.TdPawnMesh1p'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdTutorialPawn.TdPawnMesh1pLowerBody' */;
		MoveClasses = new array< Core.ClassT<TdMove> >
		{
			default,
			ClassT<TdMove_Walking>(),
			ClassT<TdMove_Falling>(),
			ClassT<TdMove_Grab>(),
			ClassT<TdMove_WallRun>(),
			ClassT<TdMove_WallRun>(),
			ClassT<TdMove_WallClimb>(),
			ClassT<TdMove_SpringBoard>(),
			ClassT<TdMove_SpeedVault>(),
			ClassT<TdMove_VaultOver>(),
			ClassT<TdMove_GrabPullUp>(),
			ClassT<TdMove_Jump>(),
			ClassT<TdMove_WallrunJump>(),
			ClassT<TdMove_GrabJump>(),
			ClassT<TdMove_IntoGrab>(),
			ClassT<TdMove_Crouch>(),
			ClassT<TdMove_Slide>(),
			ClassT<TdMove_Melee>(),
			ClassT<TdMove_Disarm_Tutorial>(),
			ClassT<TdMove_Barge>(),
			ClassT<TdMove_Landing>(),
			ClassT<TdMove_Climb>(),
			ClassT<TdMove_IntoClimb>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_180Turn>(),
			ClassT<TdMove_180TurnInAir>(),
			ClassT<TdMove_LayOnGround>(),
			ClassT<TdMove_IntoZipLine>(),
			ClassT<TdMove_ZipLine>(),
			ClassT<TdMove_Balance>(),
			ClassT<TdMove_LedgeWalk>(),
			ClassT<TdMove_GrabTransfer>(),
			ClassT<TdMove_MeleeAir>(),
			ClassT<TdMove_DodgeJump>(),
			ClassT<TdMove_WallrunDodgeJump>(),
			ClassT<TdMove_Stumble>(),
			ClassT<TdMove_Disarmed>(),
			ClassT<TdMove_StepUp>(),
			ClassT<TdMove_RumpSlide>(),
			ClassT<TdMove_Interact>(),
			ClassT<TdMove_WallRun>(),
			default,
			default,
			default,
			default,
			default,
			default,
			ClassT<TdMove_Vertigo>(),
			ClassT<TdMove_MeleeSlide>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimb180TurnJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_MeleeVault>(),
			default,
			ClassT<TdMove_StumbleHard>(),
			ClassT<TdMove_BotRoll>(),
			default,
			default,
			default,
			ClassT<TdMove_Swing>(),
			ClassT<TdMove_Coil>(),
			ClassT<TdMove_MeleeWallrun>(),
			ClassT<TdMove_MeleeCrouch>(),
			default,
			default,
			default,
			default,
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_FallingUncontrolled>(),
			ClassT<TdMove_SwingJump>(),
			ClassT<TdMove_AnimationPlayback>(),
			default,
			default,
			default,
			ClassT<TdMove_SoftLanding>(),
			default,
			default,
			ClassT<TdMove_AutoStepUp>(),
			ClassT<TdMove_MeleeAirAbove>(),
			default,
			default,
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
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdTutorialPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdTutorialPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdTutorialPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdTutorialPawn.DrawFrust0'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0312833E
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdTutorialPawn.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTutorialPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialPawn.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdTutorialPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdTutorialPawn.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdTutorialPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdTutorialPawn.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdTutorialPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialPawn.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdTutorialPawn.Arrow")/*Ref ArrowComponent'Default__TdTutorialPawn.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0312833E
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment'*/,
			}/* Reference: TdSkeletalMeshComponent'Default__TdTutorialPawn.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdTutorialPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialPawn.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdTutorialPawn.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialPawn.ActorCollisionCylinder'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdTutorialPawn.MyLightEnvironment1P")/*Ref DynamicLightEnvironmentComponent'Default__TdTutorialPawn.MyLightEnvironment1P'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTutorialPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialPawn.CollisionCylinder'*/;
	}
}
}