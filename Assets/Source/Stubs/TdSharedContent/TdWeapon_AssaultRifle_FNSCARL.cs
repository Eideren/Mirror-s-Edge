// NO OVERWRITE

namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_AssaultRifle_FNSCARL : TdWeapon_Heavy/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_AssaultRifle_FNSCARL()
	{
		// Object Offset:0x0000969E
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-FNSCARL";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_4Spread_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_4Spread_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		BulletTraceTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_Heavy_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_Heavy_01'*/;
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell556_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell556_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x00013236
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample()
				{
					LeftAmplitude = 30,
					RightAmplitude = 0,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
				new ForceFeedbackWaveform.WaveformSample()
				{
					LeftAmplitude = 0,
					RightAmplitude = 30,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 0.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_AssaultRifle_FNSCARL.FiringWaveformObj' */;
		MaxAmmo = 30;
		ReloadTime = 2.20f;
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
			#warning fallofftype values are weird, replaced with default
			//147,
			default
		};
		FallOffDistance = 2000.0f;
		DeathAnimType = 2;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_FNSCARL.Fire.Fire1P")/*Ref SoundCue'A_WP_Assault_FNSCARL.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_FNSCARL.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Assault_FNSCARL.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_FNSCARL.Fire.Fire3P")/*Ref SoundCue'A_WP_Assault_FNSCARL.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Assault_FNSCARL.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Assault_FNSCARL.Reverb.Reverb3P'*/,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00013EB7
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			bDisableWarningWhenAnimNotFound = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014037
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.ThirdPersonMesh' */;
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
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 2.80f,
			Time_Max = 3.20f,
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
		PreReloadTime = 0.50f;
		MaxRecoil = 0.0f;
		FireInterval = new array<float>
		{
			0.110f,
		};
		Spread = new array<float>
		{
			0.020f,
		};
		InstantHitDamage = new array<float>
		{
			35.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_HighCaliber_Bullet>(),
		};
		EquipTime = 0.750f;
		WeaponRange = 9000.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00013EB7
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			bDisableWarningWhenAnimNotFound = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.FirstPersonMesh' */;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014037
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00013EB7
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			bDisableWarningWhenAnimNotFound = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00013EB7
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_C1P_TwoHanded_FNSCARL.AS_C1P_TwoHanded_FNSCARL'*/,
				},
				bUpdateJointsFromAnimation = true,
				bEnableFullAnimWeightBodies = true,
				bDisableWarningWhenAnimNotFound = true,
				RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
				RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
				{
					Default = true,
					GameplayPhysics = true,
					EffectPhysics = true,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.FirstPersonMesh' */,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00014037
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_FNSCARL.Mesh.SK_FNSCARL")/*Ref SkeletalMesh'WP_FNSCARL.Mesh.SK_FNSCARL'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("WP_FNSCARL.Mesh.PA_FNSCARL")/*Ref PhysicsAsset'WP_FNSCARL.Mesh.PA_FNSCARL'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL")/*Ref TdAnimSet'AS_F3P_TwoHanded_FNSCARL.AS_F3P_TwoHanded_FNSCARL'*/,
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
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_AssaultRifle_FNSCARL.ThirdPersonMesh' */,
		};
	}
}
}