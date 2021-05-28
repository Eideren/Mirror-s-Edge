namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_BerettaM93R : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_Pistol_BerettaM93R()
	{
		// Object Offset:0x0000BB61
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		WeaponPoseProfileName = (name)"OneHanded-BerettaM93R";
		OneHandedRightShoulderTranslationOffset = new Vector
		{
			X=0.0f,
			Y=0.80f,
			Z=-1.430f
		};
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x0001367A
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 10,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Pistol_BerettaM93R.FiringWaveformObj' */;
		MaxAmmo = 21;
		ReloadTime = 2.0f;
		AmmoCount = 21;
		InstantHitDamageMP = new array<float>
		{
			20.0f,
		};
		bAutomaticReFire = new array<bool>
		{
			false,
		};
		FallOffDistance = 600.0f;
		DeathAnimType = 10;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_BerettaM93R.Fire.Fire1P")/*Ref SoundCue'A_WP_Pistol_BerettaM93R.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_BerettaM93R.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Pistol_BerettaM93R.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_BerettaM93R.Fire.Fire3P")/*Ref SoundCue'A_WP_Pistol_BerettaM93R.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_BerettaM93R.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Pistol_BerettaM93R.Reverb.Reverb3P'*/,
		};
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000147FB
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014853
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_BerettaM93R.PA_BerettaM93R")/*Ref PhysicsAsset'WP_BerettaM93R.PA_BerettaM93R'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.ThirdPersonMesh' */;
		CombatRange_Min = 1200.0f;
		CombatRange_Max = 2500.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Pause_Min = 1.0f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 4,
			Pause_Max = 1.50f,
		};
		CombatRange_Max_CHASE = 2500.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 6,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Pause_Min = 1.0f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 4,
			Pause_Max = 1.50f,
		};
		RecoilAmount = 0.50f;
		KickbackAmount = 10.0f;
		FireInterval = new array<float>
		{
			0.10f,
		};
		InstantHitDamage = new array<float>
		{
			19.0f,
		};
		EquipTime = 0.750f;
		WeaponRange = 4500.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000147FB
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.FirstPersonMesh' */;
		DroppedPickupMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014853
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_BerettaM93R.PA_BerettaM93R")/*Ref PhysicsAsset'WP_BerettaM93R.PA_BerettaM93R'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.ThirdPersonMesh' */;
		PickupFactoryMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000147FB
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.FirstPersonMesh' */;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x000147FB
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_C1P_OneHanded_BerettaM93R.AS_C1P_OneHanded_BerettaM93R'*/,
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.FirstPersonMesh' */,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00014853
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_BerettaM93R.SK_BerettaM93R")/*Ref SkeletalMesh'WP_BerettaM93R.SK_BerettaM93R'*/,
				PhysicsAsset = LoadAsset<PhysicsAsset>("WP_BerettaM93R.PA_BerettaM93R")/*Ref PhysicsAsset'WP_BerettaM93R.PA_BerettaM93R'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R")/*Ref TdAnimSet'AS_F3P_OneHanded_BerettaM93R.AS_F3P_OneHanded_BerettaM93R'*/,
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
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_BerettaM93R.ThirdPersonMesh' */,
		};
	}
}
}