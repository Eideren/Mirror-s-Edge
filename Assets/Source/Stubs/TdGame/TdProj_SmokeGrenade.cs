namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProj_SmokeGrenade : TdProj_Grenade/*
		notplaceable
		hidecategories(Navigation)*/{
	public override /*simulated function */void GrenadeExplosion(Object.Vector HitLocation, Object.Vector HitNormal, bool bOnGround)
	{
	
	}
	
	public TdProj_SmokeGrenade()
	{
		var Default__TdProj_SmokeGrenade_GrenadeMesh0 = new SkeletalMeshComponent
		{
			// Object Offset:0x0279BD16
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SmokeGrenade.SK_SmokeGrenade")/*Ref SkeletalMesh'WP_SmokeGrenade.SK_SmokeGrenade'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_SmokeGrenade.PA_SmokeGrenade")/*Ref PhysicsAsset'WP_SmokeGrenade.PA_SmokeGrenade'*/,
			PhysicsWeight = 1.0f,
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			CollideActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: SkeletalMeshComponent'Default__TdProj_SmokeGrenade.GrenadeMesh0' */;
		var Default__TdProj_SmokeGrenade_TrailParticleSystemComponent0 = new ParticleSystemComponent
		{
			// Object Offset:0x01D75097
			Template = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_SmokeGrenade_Trail_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_SmokeGrenade_Trail_01'*/,
		}/* Reference: ParticleSystemComponent'Default__TdProj_SmokeGrenade.TrailParticleSystemComponent0' */;
		var Default__TdProj_SmokeGrenade_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdProj_SmokeGrenade.CollisionCylinder' */;
		var Default__TdProj_SmokeGrenade_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdProj_SmokeGrenade.Sprite' */;
		// Object Offset:0x0064F5BB
		Mesh = Default__TdProj_SmokeGrenade_GrenadeMesh0/*Ref SkeletalMeshComponent'Default__TdProj_SmokeGrenade.GrenadeMesh0'*/;
		ExplodingSound = LoadAsset<SoundCue>("A_WP_Grenade_Smoke.Fire.Det")/*Ref SoundCue'A_WP_Grenade_Smoke.Fire.Det'*/;
		BouncingSound = LoadAsset<SoundCue>("A_WP_Grenade_Smoke.Foley.DropBounce")/*Ref SoundCue'A_WP_Grenade_Smoke.Foley.DropBounce'*/;
		PSC_SmokeTrail = Default__TdProj_SmokeGrenade_TrailParticleSystemComponent0/*Ref ParticleSystemComponent'Default__TdProj_SmokeGrenade.TrailParticleSystemComponent0'*/;
		InFlightSoundTemplate = LoadAsset<SoundCue>("A_WP_Grenade_Smoke.Fire.Pre")/*Ref SoundCue'A_WP_Grenade_Smoke.Fire.Pre'*/;
		Damage = 0.0f;
		DamageRadius = 0.0f;
		MomentumTransfer = 0.0f;
		MyDamageType = default;
		CylinderComponent = Default__TdProj_SmokeGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_SmokeGrenade.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdProj_SmokeGrenade_Sprite/*Ref SpriteComponent'Default__TdProj_SmokeGrenade.Sprite'*/,
			Default__TdProj_SmokeGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_SmokeGrenade.CollisionCylinder'*/,
			Default__TdProj_SmokeGrenade_GrenadeMesh0/*Ref SkeletalMeshComponent'Default__TdProj_SmokeGrenade.GrenadeMesh0'*/,
		};
		CollisionComponent = Default__TdProj_SmokeGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_SmokeGrenade.CollisionCylinder'*/;
	}
}
}