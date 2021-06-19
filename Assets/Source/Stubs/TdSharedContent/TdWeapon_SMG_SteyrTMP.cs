namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_SMG_SteyrTMP : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_SMG_SteyrTMP()
	{
		var Default__TdWeapon_SMG_SteyrTMP_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000154C7
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SteyrTMP.SK_SteyrTMP")/*Ref SkeletalMesh'WP_SteyrTMP.SK_SteyrTMP'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_SteyrTMP.AS_C1P_OneHanded_SteyrTMP")/*Ref TdAnimSet'AS_C1P_OneHanded_SteyrTMP.AS_C1P_OneHanded_SteyrTMP'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.FirstPersonMesh' */;
		var Default__TdWeapon_SMG_SteyrTMP_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001551F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_SteyrTMP.SK_SteyrTMP")/*Ref SkeletalMesh'WP_SteyrTMP.SK_SteyrTMP'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_SteyrTMP.PA_SteyrTMP")/*Ref PhysicsAsset'WP_SteyrTMP.PA_SteyrTMP'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_SteyrTMP.AS_F3P_OneHanded_SteyrTMP")/*Ref TdAnimSet'AS_F3P_OneHanded_SteyrTMP.AS_F3P_OneHanded_SteyrTMP'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.ThirdPersonMesh' */;
		// Object Offset:0x0000FD6E
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		WeaponPoseProfileName = (name)"OneHanded-SteyrTMP";
		OneHandedRightShoulderRotationOffset = new Rotator
		{
			Pitch=0,
			Yaw=-3,
			Roll=0
		};
		OneHandedRightShoulderTranslationOffset = new Vector
		{
			X=0.0f,
			Y=4.0f,
			Z=-1.0f
		};
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		MaxAmmo = 30;
		ReloadTime = 3.250f;
		AmmoCount = 30;
		InstantHitDamageMP = new array<float>
		{
			10.40f,
		};
		bAutomaticReFire = new array<bool>
		{
			false,
		};
		FallOffDistance = 800.0f;
		DeathAnimType = 10;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_MiniSMG_SteyrTMP.Fire.Fire1P")/*Ref SoundCue'A_WP_MiniSMG_SteyrTMP.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_MiniSMG_SteyrTMP.Reverb.Reverb1P")/*Ref SoundCue'A_WP_MiniSMG_SteyrTMP.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_MiniSMG_SteyrTMP.Fire.Fire3P")/*Ref SoundCue'A_WP_MiniSMG_SteyrTMP.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_MiniSMG_SteyrTMP.Reverb.Reverb3P")/*Ref SoundCue'A_WP_MiniSMG_SteyrTMP.Reverb.Reverb3P'*/,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_SteyrTMP.AS_C1P_OneHanded_SteyrTMP")/*Ref TdAnimSet'AS_C1P_OneHanded_SteyrTMP.AS_C1P_OneHanded_SteyrTMP'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_SteyrTMP.AS_F3P_OneHanded_SteyrTMP")/*Ref TdAnimSet'AS_F3P_OneHanded_SteyrTMP.AS_F3P_OneHanded_SteyrTMP'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_SteyrTMP.AS_F3P_OneHanded_SteyrTMP")/*Ref TdAnimSet'AS_F3P_OneHanded_SteyrTMP.AS_F3P_OneHanded_SteyrTMP'*/;
		Mesh1p = Default__TdWeapon_SMG_SteyrTMP_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_SMG_SteyrTMP_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.ThirdPersonMesh'*/;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 5,
		};
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 5,
		};
		RecoilAmount = 0.60f;
		KickbackAmount = 10.0f;
		FireInterval = new array<float>
		{
			0.060f,
		};
		Spread = new array<float>
		{
			0.0080f,
		};
		InstantHitDamage = new array<float>
		{
			15.50f,
		};
		EquipTime = 0.750f;
		WeaponRange = 3000.0f;
		Mesh = Default__TdWeapon_SMG_SteyrTMP_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.FirstPersonMesh'*/;
		DroppedPickupMesh = Default__TdWeapon_SMG_SteyrTMP_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_SMG_SteyrTMP_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_SMG_SteyrTMP_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.FirstPersonMesh'*/,
			Default__TdWeapon_SMG_SteyrTMP_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_SMG_SteyrTMP.ThirdPersonMesh'*/,
		};
	}
}
}