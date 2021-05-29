// NO OVERWRITE

namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Shotgun_Neostead : TdWeapon_Heavy/*
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
	
	public TdWeapon_Shotgun_Neostead()
	{
		// Object Offset:0x0000E379
		PelletCount = 10;
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-Neostead";
		bPlayFlyBys = false;
		ReloadingState = (name)"WeaponLoopReloading";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_Shotgun_Singleshot_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_Shotgun_Singleshot_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		BulletTraceTemplate = default;
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_ShellSlug")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_ShellSlug'*/;
		ShellEjectSocket = (name)"ShellEject";
		ShellEjectDelay = 0.90f;
		FiringWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x000138E4
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
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Shotgun_Neostead.FiringWaveformObj' */;
		MaxAmmo = 12;
		StartReloadTime = 0.66670f;
		ReloadTime = 1.26670f;
		EndReloadTime = 2.36670f;
		BurstMax = 1;
		AmmoCount = 12;
		PassThroughLimit = 0;
		InstantHitDamageMP = new array<float>
		{
			10.50f,
		};
		FallOffDistance = 1500.0f;
		DeathAnimType = 3;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Neostead.Fire.Fire1P")/*Ref SoundCue'A_WP_Shotgun_Neostead.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Neostead.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Shotgun_Neostead.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Neostead.Fire.Fire3P")/*Ref SoundCue'A_WP_Shotgun_Neostead.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Shotgun_Neostead.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Shotgun_Neostead.Reverb.Reverb3P'*/,
		};
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_ShotGun;
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00015117
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001516F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Neostead.PA_Neostead")/*Ref PhysicsAsset'WP_Neostead.PA_Neostead'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.ThirdPersonMesh' */;
		CombatRange_Min = 500.0f;
		CombatRange_Max = 4000.0f;
		CombatRange_Preferred = 1500.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.60f,
			Pause_Max = 0.80f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.80f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Min = 1.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 5.90f,
			Time_Max = 6.20f,
		};
		CombatRange_Max_CHASE = 4000.0f;
		CombatRange_Preferred_CHASE = 1500.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.60f,
			Pause_Max = 0.80f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.80f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Min = 1.50f,
		};
		PreReloadTime = 1.50f;
		RecoilAmount = 3.0f;
		MaxRecoil = 9.0f;
		KickbackAmount = 50.0f;
		WeaponFireTypes = new array<Weapon.EWeaponFireType>
		{
			#warning fallofftype values are weird, replaced with default
			//149,
			default
		};
		FireInterval = new array<float>
		{
			1.10f,
		};
		Spread = new array<float>
		{
			0.10f,
		};
		InstantHitDamage = new array<float>
		{
			16.0f,
		};
		InstantHitMomentum = new array<float>
		{
			30.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_Shotgun>(),
		};
		EquipTime = 1.20f;
		PutDownTime = 1.0f;
		WeaponRange = 6000.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00015117
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.FirstPersonMesh' */;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001516F
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Neostead.PA_Neostead")/*Ref PhysicsAsset'WP_Neostead.PA_Neostead'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00015117
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00015117
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_C1P_TwoHanded_Neostead.AS_C1P_TwoHanded_Neostead'*/,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.FirstPersonMesh' */,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0001516F
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Neostead.SK_Neostead")/*Ref SkeletalMesh'WP_Neostead.SK_Neostead'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Neostead.PA_Neostead")/*Ref PhysicsAsset'WP_Neostead.PA_Neostead'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead")/*Ref TdAnimSet'AS_F3P_TwoHanded_Neostead.AS_F3P_TwoHanded_Neostead'*/,
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
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Shotgun_Neostead.ThirdPersonMesh' */,
		};
	}
}
}