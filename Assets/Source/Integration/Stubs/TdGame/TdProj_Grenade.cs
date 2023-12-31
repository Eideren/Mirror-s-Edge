namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProj_Grenade : TdProjectile/*
		abstract
		notplaceable
		hidecategories(Navigation)*/{
	[Category] [export, editinline] public PrimitiveComponent Mesh;
	public float TimeToExplode;
	[Category("Sounds")] public SoundCue ExplodingSound;
	[Category("Sounds")] public SoundCue BouncingSound;
	[Category("Effects")] public ParticleSystem ExplodingEffect;
	[Category] [export, editinline] public ParticleSystemComponent PSC_SmokeTrail;
	[repnotify] public bool bHasExploded;
	[export, editinline] public AudioComponent InFlightSound;
	public SoundCue InFlightSoundTemplate;
	
	//replication
	//{
	//	 if(bNetDirty)
	//		bHasExploded;
	//}
	
	public override /*simulated function */void eventPostBeginPlay()
	{
		// stub
	}
	
	public override /*simulated function */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public override /*simulated function */void Init(Object.Vector Direction)
	{
		// stub
	}
	
	public virtual /*event */void ActivateCollision()
	{
		// stub
	}
	
	public override RigidBodyCollision_del RigidBodyCollision { get => bfield_RigidBodyCollision ?? TdProj_Grenade_RigidBodyCollision; set => bfield_RigidBodyCollision = value; } RigidBodyCollision_del bfield_RigidBodyCollision;
	public override RigidBodyCollision_del global_RigidBodyCollision => TdProj_Grenade_RigidBodyCollision;
	public /*event */void TdProj_Grenade_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)
	{
		// stub
	}
	
	public virtual /*simulated function */void DoExplosion()
	{
		// stub
	}
	
	public virtual /*simulated function */void DestroyTheProjectile(ParticleSystemComponent PSC)
	{
		// stub
	}
	
	public virtual /*simulated function */void HideProjectile()
	{
		// stub
	}
	
	public virtual /*function */void WarnProjExplode()
	{
		// stub
	}
	
	public override /*simulated function */void Explode(Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public virtual /*simulated function */void GrenadeExplosion(Object.Vector HitLocation, Object.Vector HitNormal, bool bOnGround)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		RigidBodyCollision = null;
	
	}
	public TdProj_Grenade()
	{
		var Default__TdProj_Grenade_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdProj_Grenade.CollisionCylinder' */;
		var Default__TdProj_Grenade_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdProj_Grenade.Sprite' */;
		// Object Offset:0x0064E0CC
		TimeToExplode = 9.0f;
		ExplodingSound = LoadAsset<SoundCue>("A_WP_Default.Fire.Reverb")/*Ref SoundCue'A_WP_Default.Fire.Reverb'*/;
		BouncingSound = LoadAsset<SoundCue>("A_WP_Default.Fire.Fire")/*Ref SoundCue'A_WP_Default.Fire.Fire'*/;
		ExplodingEffect = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_SmokeGrenade_Smoke_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_SmokeGrenade_Smoke_01'*/;
		InnerCoreDamage = 600;
		InnerCoreDamageRadius = 256;
		OuterCoreDamage = 400.0f;
		OuterCoreDamageRadius = 512;
		MaxSpeed = 0.0f;
		Damage = 50.0f;
		MomentumTransfer = 1.0f;
		CylinderComponent = Default__TdProj_Grenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_Grenade.CollisionCylinder'*/;
		bAlwaysRelevant = true;
		bNetInitialRotation = true;
		bKillDuringLevelTransition = true;
		bCollideComplex = true;
		bBounce = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdProj_Grenade_Sprite/*Ref SpriteComponent'Default__TdProj_Grenade.Sprite'*/,
			Default__TdProj_Grenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_Grenade.CollisionCylinder'*/,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		LifeSpan = 10.0f;
		CollisionComponent = Default__TdProj_Grenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_Grenade.CollisionCylinder'*/;
	}
}
}