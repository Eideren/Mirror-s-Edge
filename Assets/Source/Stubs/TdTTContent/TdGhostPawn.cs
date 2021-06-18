namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdGhostPawn : TdGhostPawnBase/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public TdGhostPawn()
	{
		var Default__TdGhostPawn_ActorCollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x0000639B
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdGhostPawn.ActorCollisionCylinder' */;
		var Default__TdGhostPawn_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000064D3
			SkeletalMesh = LoadAsset<SkeletalMesh>("TT_Ghost.GhostCharacter_01")/*Ref SkeletalMesh'TT_Ghost.GhostCharacter_01'*/,
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_C3P.AT_C3P")/*Ref AnimTree'AT_C3P.AT_C3P'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_Unarmed.AS_F3P_Unarmed")/*Ref TdAnimSet'AS_F3P_Unarmed.AS_F3P_Unarmed'*/,
			},
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdGhostPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdGhostPawn.MyLightEnvironment'*/,
			bOwnerNoSeeWithShadow = false,
			bCastDynamicShadow = false,
			CollideActors = false,
			BlockZeroExtent = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdGhostPawn.TdPawnMesh3p' */;
		var Default__TdGhostPawn_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00006407
			CollideActors = false,
			BlockActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdGhostPawn.CollisionCylinder' */;
		// Object Offset:0x0000506A
		TrailParticleSystem_Normal = LoadAsset<ParticleSystem>("TT_Ghost.Effects.PS_FX_GhostTrail_01")/*Ref ParticleSystem'TT_Ghost.Effects.PS_FX_GhostTrail_01'*/;
		TrailParticleSystem_Wide = LoadAsset<ParticleSystem>("TT_Ghost.Effects.PS_FX_GhostTrail_Wider_01")/*Ref ParticleSystem'TT_Ghost.Effects.PS_FX_GhostTrail_Wider_01'*/;
		TrailHeadSocket = (name)"Trail_Head";
		TrailNeckSocket = (name)"Trail_Neck";
		TrailSpineSocket = (name)"Trail_Spine";
		TrailSpine2Socket = (name)"Trail_Spine2";
		TrailRightHandSocket = (name)"Trail_RighHand";
		TrailLeftHandSocket = (name)"Trail_LeftHand";
		TrailLeftFootSocket = (name)"Trail_LeftFoot";
		TrailRightFootSocket = (name)"Trail_RightFoot";
		FootDecalMaterial = LoadAsset<DecalMaterial>("TT_Ghost.Materials.M_FX_FootPrintsDecal_01")/*Ref DecalMaterial'TT_Ghost.Materials.M_FX_FootPrintsDecal_01'*/;
		AmbientSoundSC = LoadAsset<SoundCue>("A_TimeTrial.Cues.Ghost_Proxy")/*Ref SoundCue'A_TimeTrial.Cues.Ghost_Proxy'*/;
		bDisableCharacterSounds = true;
		ActorCylinderComponent = Default__TdGhostPawn_ActorCollisionCylinder;
		Mesh3p = Default__TdGhostPawn_TdPawnMesh3p;
		bSimulateGravity = false;
		bSimGravityDisabled = true;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdGhostPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdGhostPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdGhostPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdGhostPawn.DrawFrust0'*/;
		Mesh = Default__TdGhostPawn_TdPawnMesh3p;
		CylinderComponent = Default__TdGhostPawn_CollisionCylinder;
		bAlwaysRelevant = true;
		bBlockActors = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdGhostPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdGhostPawn.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdGhostPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdGhostPawn.DrawFrust0'*/,
			Default__TdGhostPawn_CollisionCylinder,
			LoadAsset<ArrowComponent>("Default__TdGhostPawn.Arrow")/*Ref ArrowComponent'Default__TdGhostPawn.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdGhostPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdGhostPawn.MyLightEnvironment'*/,
			Default__TdGhostPawn_TdPawnMesh3p,
			Default__TdGhostPawn_CollisionCylinder,
			Default__TdGhostPawn_ActorCollisionCylinder,
		};
		CollisionComponent = Default__TdGhostPawn_CollisionCylinder;
	}
}
}