namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_AssaultRifle_HKG36 : TdWeapon_Heavy/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_AssaultRifle_HKG36()
	{
		var Default__TdWeapon_AssaultRifle_HKG36_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000141D3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_G36C.SK_G36C")/*Ref SkeletalMesh'WP_G36C.SK_G36C'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_G36C.AS_C1P_TwoHanded_G36C")/*Ref TdAnimSet'AS_C1P_TwoHanded_G36C.AS_C1P_TwoHanded_G36C'*/,
			},
			bDisableWarningWhenAnimNotFound = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.FirstPersonMesh' */;
		var Default__TdWeapon_AssaultRifle_HKG36_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014247
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_G36C.SK_G36C")/*Ref SkeletalMesh'WP_G36C.SK_G36C'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_G36C.PA_G36C")/*Ref PhysicsAsset'WP_G36C.PA_G36C'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_G36C.AS_F3P_TwoHanded_G36C")/*Ref TdAnimSet'AS_F3P_TwoHanded_G36C.AS_F3P_TwoHanded_G36C'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			bDisableWarningWhenAnimNotFound = true,
			bUseAsOccluder = false,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.ThirdPersonMesh' */;
		// Object Offset:0x00009EEE
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-G36C";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_4Spread_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_4Spread_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		BulletTraceTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_Heavy_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_Heavy_01'*/;
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell556_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell556_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		MaxAmmo = 30;
		ReloadTime = 3.50f;
		AmmoCount = 30;
		InstantHitDamageMP = new array<float>
		{
			25.0f,
		};
		bAutomaticReFire = new array<bool>
		{
			false,
		};
		WeaponFallOffTypes = new array<TdWeapon.EWeaponFallOffType>
		{
			147,
		};
		FallOffDistance = 2000.0f;
		DeathAnimType = 2;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_G36.Fire.Fire1P")/*Ref SoundCue'A_WP_Assault_G36.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_G36.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Assault_G36.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_G36.Fire.Fire3P")/*Ref SoundCue'A_WP_Assault_G36.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_G36.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Assault_G36.Reverb.Reverb3P'*/,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_G36C.AS_C1P_TwoHanded_G36C")/*Ref TdAnimSet'AS_C1P_TwoHanded_G36C.AS_C1P_TwoHanded_G36C'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_G36C.AS_F3P_TwoHanded_G36C")/*Ref TdAnimSet'AS_F3P_TwoHanded_G36C.AS_F3P_TwoHanded_G36C'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_G36C.AS_F3P_TwoHanded_G36C")/*Ref TdAnimSet'AS_F3P_TwoHanded_G36C.AS_F3P_TwoHanded_G36C'*/;
		Mesh1p = Default__TdWeapon_AssaultRifle_HKG36_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_AssaultRifle_HKG36_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.ThirdPersonMesh'*/;
		CombatRange_Min = 2000.0f;
		CombatRange_Max = 5000.0f;
		CombatRange_Preferred = 3000.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
			Length_Max = 9,
			Pause_Min = 0.30f,
			Pause_Max = 0.80f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Max = 6,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 4,
		};
		CombatRange_Max_CHASE = 5000.0f;
		CombatRange_Preferred_CHASE = 3000.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
			Length_Max = 9,
			Pause_Min = 0.30f,
			Pause_Max = 0.80f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 6,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 4,
		};
		MaxRecoil = 1.0f;
		FireInterval = new array<float>
		{
			0.0850f,
		};
		InstantHitDamage = new array<float>
		{
			30.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_HighCaliber_Bullet>(),
		};
		EquipTime = 0.750f;
		WeaponRange = 9000.0f;
		Mesh = Default__TdWeapon_AssaultRifle_HKG36_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.FirstPersonMesh'*/;
		DroppedPickupMesh = Default__TdWeapon_AssaultRifle_HKG36_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_AssaultRifle_HKG36_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_AssaultRifle_HKG36_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.FirstPersonMesh'*/,
			Default__TdWeapon_AssaultRifle_HKG36_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_HKG36.ThirdPersonMesh'*/,
		};
	}
}
}