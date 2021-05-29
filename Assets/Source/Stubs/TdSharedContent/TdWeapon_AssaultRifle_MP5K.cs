// NO OVERWRITE

namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_AssaultRifle_MP5K : TdWeapon_Heavy/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_AssaultRifle_MP5K()
	{
		// Object Offset:0x0000A686
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-MP5K";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x000133A2
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 10,
					RightAmplitude = 0,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_AssaultRifle_MP5K.FiringWaveformObj' */;
		MaxAmmo = 30;
		ReloadTime = 3.46670f;
		BurstMax = 30;
		AmmoCount = 30;
		InstantHitDamageMP = new array<float>
		{
			10.0f,
		};
		bAutomaticReFire = new array<bool>
		{
			false,
		};
		WeaponFallOffTypes = new array<TdWeapon.EWeaponFallOffType>
		{
			#warning fallofftype values are weird, replaced with default
			//147,
			default
		};
		FallOffDistance = 2000.0f;
		DeathAnimType = 2;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_SMG_MP5K.Fire.Fire1P")/*Ref SoundCue'A_WP_SMG_MP5K.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_SMG_MP5K.Reverb.Reverb1P")/*Ref SoundCue'A_WP_SMG_MP5K.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_SMG_MP5K.Fire.Fire3P")/*Ref SoundCue'A_WP_SMG_MP5K.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_SMG_MP5K.Reverb.Reverb3P")/*Ref SoundCue'A_WP_SMG_MP5K.Reverb.Reverb3P'*/,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000143E3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001443B
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_MP5K.PA_MP5K")/*Ref PhysicsAsset'WP_MP5K.PA_MP5K'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.ThirdPersonMesh' */;
		StickyAimModifier = 0.50f;
		CombatRange_Min = 1500.0f;
		CombatRange_Max = 4000.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
			Pause_Min = 0.30f,
			Pause_Max = 0.50f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Max = 6,
			Pause_Min = 0.80f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 5,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 3.90f,
			Time_Max = 4.20f,
		};
		CombatRange_Max_CHASE = 4000.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
			Pause_Min = 0.30f,
			Pause_Max = 0.50f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 6,
			Pause_Min = 0.80f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 5,
		};
		PreReloadTime = 0.50f;
		MaxRecoil = 1.0f;
		FireInterval = new array<float>
		{
			0.10f,
		};
		Spread = new array<float>
		{
			0.040f,
		};
		InstantHitDamage = new array<float>
		{
			25.0f,
		};
		InstantHitMomentum = new array<float>
		{
			13.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_HighCaliber_Bullet>(),
		};
		EquipTime = 0.750f;
		WeaponRange = 8000.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000143E3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.FirstPersonMesh' */;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001443B
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_MP5K.PA_MP5K")/*Ref PhysicsAsset'WP_MP5K.PA_MP5K'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000143E3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x000143E3
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_C1P_TwoHanded_MP5K.AS_C1P_TwoHanded_MP5K'*/,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.FirstPersonMesh' */,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0001443B
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_MP5K.SK_MP5K")/*Ref SkeletalMesh'WP_MP5K.SK_MP5K'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("WP_MP5K.PA_MP5K")/*Ref PhysicsAsset'WP_MP5K.PA_MP5K'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K")/*Ref TdAnimSet'AS_F3P_TwoHanded_MP5K.AS_F3P_TwoHanded_MP5K'*/,
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
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_MP5K.ThirdPersonMesh' */,
		};
	}
}
}