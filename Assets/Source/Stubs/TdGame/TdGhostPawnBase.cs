namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGhostPawnBase : TdPawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public ParticleSystem TrailParticleSystem_Normal;
	public ParticleSystem TrailParticleSystem_Wide;
	public /*export editinline transient */ParticleSystemComponent TrailHeadPSC;
	public /*export editinline transient */ParticleSystemComponent TrailNeckPSC;
	public /*export editinline transient */ParticleSystemComponent TrailSpinePSC;
	public /*export editinline transient */ParticleSystemComponent TrailSpine2PSC;
	public /*export editinline transient */ParticleSystemComponent TrailRightHandPSC;
	public /*export editinline transient */ParticleSystemComponent TrailLeftHandPSC;
	public /*export editinline transient */ParticleSystemComponent TrailRightFootPSC;
	public /*export editinline transient */ParticleSystemComponent TrailLeftFootPSC;
	public name TrailHeadSocket;
	public name TrailNeckSocket;
	public name TrailSpineSocket;
	public name TrailSpine2Socket;
	public name TrailRightHandSocket;
	public name TrailLeftHandSocket;
	public name TrailLeftFootSocket;
	public name TrailRightFootSocket;
	public DecalMaterial FootDecalMaterial;
	public /*export editinline */AudioComponent AmbientSound;
	public SoundCue AmbientSoundSC;
	public int SmoothYaw;
	public int TargetYaw;
	
	public virtual /*simulated function */void ActivateGhostEffects()
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdGhostPawnBase_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdGhostPawnBase_Tick;
	public /*simulated function */void TdGhostPawnBase_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*simulated function */void RotateSmooth(float DeltaTime)
	{
	
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated function */void SetShowGhost(bool bShow)
	{
	
	}
	
	public override /*simulated function */void ActuallyPlayFootParticleEffect(int FootDown, Actor.TraceHitInfo HitInfo, /*optional */Object.Vector? _HitLoc = default, /*optional */Object.Vector? _HitNormal = default)
	{
	
	}
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public override /*simulated event */bool IsSameTeam(Pawn Other)
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public TdGhostPawnBase()
	{
		var Default__TdGhostPawnBase_ActorCollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdGhostPawnBase.ActorCollisionCylinder' */;
		var Default__TdGhostPawnBase_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdGhostPawnBase.SceneCaptureCharacterComponent0' */;
		var Default__TdGhostPawnBase_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdGhostPawnBase.DrawFrust0' */;
		var Default__TdGhostPawnBase_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdGhostPawnBase.CollisionCylinder' */;
		var Default__TdGhostPawnBase_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdGhostPawnBase.Arrow' */;
		var Default__TdGhostPawnBase_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdGhostPawnBase.MyLightEnvironment' */;
		var Default__TdGhostPawnBase_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x031281E2
			LightEnvironment = Default__TdGhostPawnBase_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdGhostPawnBase.MyLightEnvironment'*/,
		}/* Reference: TdSkeletalMeshComponent'Default__TdGhostPawnBase.TdPawnMesh3p' */;
		// Object Offset:0x0054F195
		ActorCylinderComponent = Default__TdGhostPawnBase_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdGhostPawnBase.ActorCollisionCylinder'*/;
		SceneCapture = Default__TdGhostPawnBase_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdGhostPawnBase.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdGhostPawnBase_DrawFrust0/*Ref DrawFrustumComponent'Default__TdGhostPawnBase.DrawFrust0'*/;
		CylinderComponent = Default__TdGhostPawnBase_CollisionCylinder/*Ref CylinderComponent'Default__TdGhostPawnBase.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGhostPawnBase_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdGhostPawnBase.SceneCaptureCharacterComponent0'*/,
			Default__TdGhostPawnBase_DrawFrust0/*Ref DrawFrustumComponent'Default__TdGhostPawnBase.DrawFrust0'*/,
			Default__TdGhostPawnBase_CollisionCylinder/*Ref CylinderComponent'Default__TdGhostPawnBase.CollisionCylinder'*/,
			Default__TdGhostPawnBase_Arrow/*Ref ArrowComponent'Default__TdGhostPawnBase.Arrow'*/,
			Default__TdGhostPawnBase_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdGhostPawnBase.MyLightEnvironment'*/,
			Default__TdGhostPawnBase_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdGhostPawnBase.TdPawnMesh3p'*/,
			Default__TdGhostPawnBase_CollisionCylinder/*Ref CylinderComponent'Default__TdGhostPawnBase.CollisionCylinder'*/,
			Default__TdGhostPawnBase_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdGhostPawnBase.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdGhostPawnBase_CollisionCylinder/*Ref CylinderComponent'Default__TdGhostPawnBase.CollisionCylinder'*/;
	}
}
}