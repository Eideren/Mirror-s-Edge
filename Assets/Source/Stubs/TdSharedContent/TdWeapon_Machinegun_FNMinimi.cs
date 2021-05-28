// NO OVERWRITE

namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Machinegun_FNMinimi : TdWeapon_Heavy/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_Machinegun_FNMinimi()
	{
		// Object Offset:0x0000B1DD
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-FNMinimi";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_4Spread_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_4Spread_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		BulletTraceTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_Heavy_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_Heavy_01'*/;
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell556_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell556_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x0001350E
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample()
				{
					LeftAmplitude = 20,
					RightAmplitude = 0,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
				new ForceFeedbackWaveform.WaveformSample()
				{
					LeftAmplitude = 0,
					RightAmplitude = 20,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Machinegun_FNMinimi.FiringWaveformObj' */;
		MaxAmmo = 99;
		ReloadTime = 6.60f;
		AmmoCount = 99;
		InstantHitDamageMP = new array<float>
		{
			13.0f,
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
		FallOffDistance = 6000.0f;
		DeathAnimType = 5;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_HeavyMG_FNMiniMe.Fire.Fire1P")/*Ref SoundCue'A_WP_HeavyMG_FNMiniMe.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_HeavyMG_FNMiniMe.Reverb.Reverb1P")/*Ref SoundCue'A_WP_HeavyMG_FNMiniMe.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_HeavyMG_FNMiniMe.Fire.Fire3P")/*Ref SoundCue'A_WP_HeavyMG_FNMiniMe.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_HeavyMG_FNMiniMe.Reverb.Reverb3P")/*Ref SoundCue'A_WP_HeavyMG_FNMiniMe.Reverb.Reverb3P'*/,
		};
		WeaponCollisionSnd = LoadAsset<SoundCue>("A_WP_Drops.Heavy.HeavyDrop")/*Ref SoundCue'A_WP_Drops.Heavy.HeavyDrop'*/;
		WeaponClickSnd = LoadAsset<SoundCue>("A_WP_Handling.Heavy.DryFire")/*Ref SoundCue'A_WP_Handling.Heavy.DryFire'*/;
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014623
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001467B
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNMinimi.PA_FNMinimi")/*Ref PhysicsAsset'WP_FNMinimi.PA_FNMinimi'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.ThirdPersonMesh' */;
		CombatRange_Min = 500.0f;
		CombatRange_Max = 15000.0f;
		CombatRange_Preferred = 1000.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 15,
			Length_Max = 25,
			Pause_Min = 1.50f,
			Pause_Max = 2.0f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 15,
			Length_Max = 25,
			Pause_Min = 1.50f,
			Pause_Max = 2.0f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 20,
			Length_Max = 30,
			Pause_Min = 1.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 2.80f,
			Time_Max = 3.20f,
		};
		CombatRange_Max_CHASE = 15000.0f;
		CombatRange_Preferred_CHASE = 1000.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 15,
			Length_Max = 25,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 15,
			Length_Max = 25,
			Pause_Min = 1.0f,
			Pause_Max = 1.50f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 20,
			Length_Max = 30,
			Pause_Min = 1.50f,
		};
		PreReloadTime = 0.50f;
		RecoilAmount = 1.0f;
		MaxRecoil = 1.0f;
		KickbackAmount = 50.0f;
		FireInterval = new array<float>
		{
			0.120f,
		};
		Spread = new array<float>
		{
			0.040f,
		};
		InstantHitDamage = new array<float>
		{
			36.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_HighCaliber_Bullet>(),
		};
		EquipTime = 1.0f;
		WeaponRange = 20000.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014623
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.FirstPersonMesh' */;
		PickupSound = LoadAsset<SoundCue>("A_WP_Handling.Heavy.HeavyHandling")/*Ref SoundCue'A_WP_Handling.Heavy.HeavyHandling'*/;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001467B
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNMinimi.PA_FNMinimi")/*Ref PhysicsAsset'WP_FNMinimi.PA_FNMinimi'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014623
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00014623
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNMinimi.AS_C1P_TwoHanded_FNMinimi'*/,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.FirstPersonMesh' */,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0001467B
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNMinimi.SK_FNMinimi")/*Ref SkeletalMesh'WP_FNMinimi.SK_FNMinimi'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNMinimi.PA_FNMinimi")/*Ref PhysicsAsset'WP_FNMinimi.PA_FNMinimi'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNMinimi.AS_F3P_TwoHanded_FNMinimi'*/,
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
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Machinegun_FNMinimi.ThirdPersonMesh' */,
		};
	}
}
}