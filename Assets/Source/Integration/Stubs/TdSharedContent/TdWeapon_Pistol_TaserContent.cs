// NO OVERWRITE

namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_TaserContent : TdWeapon_Pistol_Taser/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_Pistol_TaserContent()
	{
		var Default__TdWeapon_Pistol_TaserContent_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014F3F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Taser.SK_Taser")/*Ref SkeletalMesh'WP_Taser.SK_Taser'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Taser.AS_C1P_OneHanded_Taser")/*Ref TdAnimSet'AS_C1P_OneHanded_Taser.AS_C1P_OneHanded_Taser'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.FirstPersonMesh' */;
		var Default__TdWeapon_Pistol_TaserContent_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014F97
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Taser.SK_Taser")/*Ref SkeletalMesh'WP_Taser.SK_Taser'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Taser.PA_Taser")/*Ref PhysicsAsset'WP_Taser.PA_Taser'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Taser.AS_F3P_OneHanded_Taser")/*Ref TdAnimSet'AS_F3P_OneHanded_Taser.AS_F3P_OneHanded_Taser'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			bUseAsOccluder = false,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.ThirdPersonMesh' */;
		// Object Offset:0x0000D5AE
		ImpactMissPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Taser_TaserMiss_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Taser_TaserMiss_01'*/;
		ImpactHitPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Taser_TaserBodyHit_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Taser_TaserBodyHit_01'*/;
		WeaponFireSndLoop = LoadAsset<SoundCue>("A_WP_Taser_X26.Fire.FireLoop")/*Ref SoundCue'A_WP_Taser_X26.Fire.FireLoop'*/;
		WeaponNotBodyImpactSnd = LoadAsset<SoundCue>("A_Effects_Bullet_Impacts.Taser.Taser_NotBody_Impact")/*Ref SoundCue'A_Effects_Bullet_Impacts.Taser.Taser_NotBody_Impact'*/;
		WeaponBodyImpactSnd = LoadAsset<SoundCue>("A_Effects_Bullet_Impacts.Taser.Taser_Body_Impact")/*Ref SoundCue'A_Effects_Bullet_Impacts.Taser.Taser_Body_Impact'*/;
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Taser_TaserFire01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Taser_TaserFire01'*/;
		MaxAmmo = 10;
		ReloadTime = 3.10f;
		BurstMax = 0;
		AmmoCount = 999999;
		InstantHitDamageMP = new array<float>
		{
			0.0f,
		};
		bAutomaticReFire = new array<bool>
		{
			false,
		};
		FallOffDistance = 600.0f;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Taser_X26.Fire.Fire")/*Ref SoundCue'A_WP_Taser_X26.Fire.Fire'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_Effects_Bullet_Impacts.Taser.Taser_NotBody_Impact")/*Ref SoundCue'A_Effects_Bullet_Impacts.Taser.Taser_NotBody_Impact'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Taser_X26.Fire.Fire")/*Ref SoundCue'A_WP_Taser_X26.Fire.Fire'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_Effects_Bullet_Impacts.Taser.Taser_NotBody_Impact")/*Ref SoundCue'A_Effects_Bullet_Impacts.Taser.Taser_NotBody_Impact'*/,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Taser.AS_C1P_OneHanded_Taser")/*Ref TdAnimSet'AS_C1P_OneHanded_Taser.AS_C1P_OneHanded_Taser'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Taser.AS_F3P_OneHanded_Taser")/*Ref TdAnimSet'AS_F3P_OneHanded_Taser.AS_F3P_OneHanded_Taser'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Taser.AS_F3P_OneHanded_Taser")/*Ref TdAnimSet'AS_F3P_OneHanded_Taser.AS_F3P_OneHanded_Taser'*/;
		Mesh1p = Default__TdWeapon_Pistol_TaserContent_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Pistol_TaserContent_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.ThirdPersonMesh'*/;
		StickyMaxDistance = 2000.0f;
		CombatRange_Min = 100.0f;
		CombatRange_Max = 1000.0f;
		CombatRange_Preferred = 500.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 10,
			Length_Max = 10,
			Pause_Min = 1.50f,
			Pause_Max = 2.0f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 10,
			Length_Max = 10,
			Pause_Min = 1.50f,
			Pause_Max = 2.0f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 10,
			Length_Max = 10,
			Pause_Min = 1.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 3.90f,
			Time_Max = 4.20f,
		};
		CombatRange_Max_CHASE = 1000.0f;
		CombatRange_Preferred_CHASE = 500.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 10,
			Length_Max = 10,
			Pause_Min = 1.50f,
			Pause_Max = 2.0f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 10,
			Length_Max = 10,
			Pause_Min = 1.50f,
			Pause_Max = 2.0f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 10,
			Length_Max = 10,
			Pause_Min = 1.50f,
		};
		PreReloadTime = 0.50f;
		WeaponFireTypes = new array<Weapon.EWeaponFireType>
		{
			#warning fallofftype values are weird, replaced with default
			//149,
			default
		};
		FireInterval = new array<float>
		{
			0.20f,
		};
		Spread = new array<float>
		{
			0.0f,
		};
		InstantHitDamage = new array<float>
		{
			10.0f,
		};
		InstantHitMomentum = new array<float>
		{
			15.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_Taser>(),
		};
		EquipTime = 0.750f;
		WeaponRange = 1000.0f;
		Mesh = Default__TdWeapon_Pistol_TaserContent_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.FirstPersonMesh'*/;
		DroppedPickupMesh = Default__TdWeapon_Pistol_TaserContent_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Pistol_TaserContent_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Pistol_TaserContent_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.FirstPersonMesh'*/,
			Default__TdWeapon_Pistol_TaserContent_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_TaserContent.ThirdPersonMesh'*/,
		};
	}
}
}