namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProj_FlashbangGrenade : TdProj_Grenade/*
		notplaceable
		hidecategories(Navigation)*/{
	public float LookAwayDamageScale;
	public/*(WeaponEffects)*/ float DynamicLightFlashDuration;
	public /*transient */float DynamicLightFlashTimer;
	public/*(WeaponEffects)*/ Object.Color DynamicLightFlashColor;
	public/*(WeaponEffects)*/ float DynamicLightFlashBrightness;
	public/*(WeaponEffects)*/ /*export editinline */PointLightComponent DynamicLightFlashLight;
	
	public override /*simulated function */bool HurtRadius(float BaseDamage, float InDamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, /*optional */Actor? _IgnoredActor = default, /*optional */Controller? _InstigatedByController = default, /*optional */bool? _bDoFullDamage = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void TriggerDynamicLightFlash()
	{
		// stub
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdProj_FlashbangGrenade_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdProj_FlashbangGrenade_Tick;
	public /*event */void TdProj_FlashbangGrenade_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*simulated function */void DisableDynamicLightFlash()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public TdProj_FlashbangGrenade()
	{
		var Default__TdProj_FlashbangGrenade_LightComponent0 = new PointLightComponent
		{
			// Object Offset:0x0064F0D9
			Radius = 1600.0f,
			FalloffExponent = 1.0f,
			bEnabled = false,
			CastShadows = false,
			CastDynamicShadows = false,
			bCastCompositeShadow = true,
		}/* Reference: PointLightComponent'Default__TdProj_FlashbangGrenade.LightComponent0' */;
		var Default__TdProj_FlashbangGrenade_GrenadeMesh0 = new SkeletalMeshComponent
		{
			// Object Offset:0x0064EF29
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
			Scale = 1.50f,
		}/* Reference: SkeletalMeshComponent'Default__TdProj_FlashbangGrenade.GrenadeMesh0' */;
		var Default__TdProj_FlashbangGrenade_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdProj_FlashbangGrenade.CollisionCylinder' */;
		var Default__TdProj_FlashbangGrenade_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdProj_FlashbangGrenade.Sprite' */;
		// Object Offset:0x0064EBFA
		LookAwayDamageScale = 0.30f;
		DynamicLightFlashDuration = 0.40f;
		DynamicLightFlashColor = new Color
		{
			R=255,
			G=240,
			B=225,
			A=255
		};
		DynamicLightFlashBrightness = 4.0f;
		DynamicLightFlashLight = Default__TdProj_FlashbangGrenade_LightComponent0/*Ref PointLightComponent'Default__TdProj_FlashbangGrenade.LightComponent0'*/;
		Mesh = Default__TdProj_FlashbangGrenade_GrenadeMesh0/*Ref SkeletalMeshComponent'Default__TdProj_FlashbangGrenade.GrenadeMesh0'*/;
		ExplodingSound = LoadAsset<SoundCue>("A_WP_Grenade_FlashBang.Fire.Det")/*Ref SoundCue'A_WP_Grenade_FlashBang.Fire.Det'*/;
		BouncingSound = LoadAsset<SoundCue>("A_WP_Grenade_Smoke.Foley.DropBounce")/*Ref SoundCue'A_WP_Grenade_Smoke.Foley.DropBounce'*/;
		ExplodingEffect = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_FlashBangGrenade_AfterSmoke_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_FlashBangGrenade_AfterSmoke_01'*/;
		InnerCoreDamage = 50;
		InnerCoreDamageRadius = 500;
		OuterCoreDamage = 10.0f;
		OuterCoreDamageRadius = 1500;
		Damage = 0.0f;
		DamageRadius = 2000.0f;
		MyDamageType = ClassT<TdDmgType_Flashbang>()/*Ref Class'TdDmgType_Flashbang'*/;
		CylinderComponent = Default__TdProj_FlashbangGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_FlashbangGrenade.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdProj_FlashbangGrenade_Sprite/*Ref SpriteComponent'Default__TdProj_FlashbangGrenade.Sprite'*/,
			Default__TdProj_FlashbangGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_FlashbangGrenade.CollisionCylinder'*/,
			Default__TdProj_FlashbangGrenade_GrenadeMesh0/*Ref SkeletalMeshComponent'Default__TdProj_FlashbangGrenade.GrenadeMesh0'*/,
		};
		CollisionComponent = Default__TdProj_FlashbangGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_FlashbangGrenade.CollisionCylinder'*/;
	}
}
}