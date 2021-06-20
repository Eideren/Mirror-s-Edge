namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Shotgun_Remington870 : TdWeapon_Heavy/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public/*()*/ int PelletCount;
	
	public override /*simulated function */void CustomFire()
	{
	
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffect(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public override /*function */ParticleSystem GetSpecificImpactEffectPhysX(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public TdWeapon_Shotgun_Remington870()
	{
		var Default__TdWeapon_Shotgun_Remington870_FiringWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x00013A50
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 50,
					RightAmplitude = 0,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.30f,
				},
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Shotgun_Remington870.FiringWaveformObj' */;
		var Default__TdWeapon_Shotgun_Remington870_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000152EF
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Remington870.SK_Remington870")/*Ref SkeletalMesh'WP_Remington870.SK_Remington870'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Remington.AS_C1P_TwoHanded_Remington")/*Ref TdAnimSet'AS_C1P_TwoHanded_Remington.AS_C1P_TwoHanded_Remington'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.FirstPersonMesh' */;
		var Default__TdWeapon_Shotgun_Remington870_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00015347
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Remington870.SK_Remington870")/*Ref SkeletalMesh'WP_Remington870.SK_Remington870'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Remington870.PA_Remington870")/*Ref PhysicsAsset'WP_Remington870.PA_Remington870'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Remington.AS_F3P_TwoHanded_Remington")/*Ref TdAnimSet'AS_F3P_TwoHanded_Remington.AS_F3P_TwoHanded_Remington'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.ThirdPersonMesh' */;
		// Object Offset:0x0000F2BF
		PelletCount = 10;
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-Remington";
		bPlayFlyBys = false;
		ReloadingState = (name)"WeaponLoopReloading";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_Shotgun_Singleshot_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_Shotgun_Singleshot_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		BulletTraceTemplate = default;
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_ShellSlug")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_ShellSlug'*/;
		ShellEjectSocket = (name)"ShellEject";
		ShellEjectDelay = 0.90f;
		FiringWaveform = Default__TdWeapon_Shotgun_Remington870_FiringWaveformObj/*Ref ForceFeedbackWaveform'Default__TdWeapon_Shotgun_Remington870.FiringWaveformObj'*/;
		MaxAmmo = 7;
		StartReloadTime = 0.66670f;
		ReloadTime = 1.26670f;
		EndReloadTime = 2.36670f;
		BurstMax = 1;
		AmmoCount = 7;
		PassThroughLimit = 0;
		InstantHitDamageMP = new array<float>
		{
			13.0f,
		};
		FallOffDistance = 1500.0f;
		DeathAnimType = 3;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Remington870.Fire.Fire1P")/*Ref SoundCue'A_WP_Shotgun_Remington870.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Remington870.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Shotgun_Remington870.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Remington870.Fire.Fire3P")/*Ref SoundCue'A_WP_Shotgun_Remington870.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Remington870.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Shotgun_Remington870.Reverb.Reverb3P'*/,
		};
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_ShotGun;
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Remington.AS_C1P_TwoHanded_Remington")/*Ref TdAnimSet'AS_C1P_TwoHanded_Remington.AS_C1P_TwoHanded_Remington'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Remington.AS_F3P_TwoHanded_Remington")/*Ref TdAnimSet'AS_F3P_TwoHanded_Remington.AS_F3P_TwoHanded_Remington'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Remington.AS_F3P_TwoHanded_Remington")/*Ref TdAnimSet'AS_F3P_TwoHanded_Remington.AS_F3P_TwoHanded_Remington'*/;
		Mesh1p = Default__TdWeapon_Shotgun_Remington870_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Shotgun_Remington870_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.ThirdPersonMesh'*/;
		CombatRange_Min = 500.0f;
		CombatRange_Max = 2000.0f;
		CombatRange_Preferred = 1500.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.80f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 1.0f,
			Pause_Max = 1.50f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Min = 1.50f,
			Pause_Max = 2.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 4.50f,
			Time_Max = 5.50f,
		};
		CombatRange_Max_CHASE = 2000.0f;
		CombatRange_Preferred_CHASE = 1500.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.80f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 1.0f,
			Pause_Max = 1.50f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Min = 1.50f,
			Pause_Max = 2.50f,
		};
		PreReloadTime = 1.50f;
		RecoilAmount = 3.0f;
		MaxRecoil = 9.0f;
		KickbackAmount = 50.0f;
		WeaponFireTypes = new array<Weapon.EWeaponFireType>
		{
			149,
		};
		FireInterval = new array<float>
		{
			1.20f,
		};
		Spread = new array<float>
		{
			0.120f,
		};
		InstantHitDamage = new array<float>
		{
			16.0f,
		};
		InstantHitMomentum = new array<float>
		{
			28.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_Shotgun>(),
		};
		EquipTime = 1.20f;
		PutDownTime = 1.0f;
		WeaponRange = 6000.0f;
		Mesh = Default__TdWeapon_Shotgun_Remington870_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.FirstPersonMesh'*/;
		DroppedPickupMesh = Default__TdWeapon_Shotgun_Remington870_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Shotgun_Remington870_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Shotgun_Remington870_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.FirstPersonMesh'*/,
			Default__TdWeapon_Shotgun_Remington870_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Remington870.ThirdPersonMesh'*/,
		};
	}
}
}