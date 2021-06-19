namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_Glock18c : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_Pistol_Glock18c()
	{
		var Default__TdWeapon_Pistol_Glock18c_FiringWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x00013816
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 15,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Pistol_Glock18c.FiringWaveformObj' */;
		var Default__TdWeapon_Pistol_Glock18c_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014C77
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.FirstPersonMesh' */;
		var Default__TdWeapon_Pistol_Glock18c_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014DBF
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Glock18.SK_Glock18")/*Ref SkeletalMesh'WP_Glock18.SK_Glock18'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Glock18.SK_Glock18_PA")/*Ref PhysicsAsset'WP_Glock18.SK_Glock18_PA'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.ThirdPersonMesh' */;
		// Object Offset:0x0000CD7B
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		WeaponPoseProfileName = (name)"OneHanded-Glock18";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_FullAuto_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = Default__TdWeapon_Pistol_Glock18c_FiringWaveformObj/*Ref ForceFeedbackWaveform'Default__TdWeapon_Pistol_Glock18c.FiringWaveformObj'*/;
		ReloadTime = 2.0f;
		InstantHitDamageMP = new array<float>
		{
			8.0f,
		};
		FallOffDistance = 600.0f;
		DeathAnimType = 4;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_AutoPistol_Glock18c.Fire.Fire1P")/*Ref SoundCue'A_WP_AutoPistol_Glock18c.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_AutoPistol_Glock18c.Reverb.Reverb1P")/*Ref SoundCue'A_WP_AutoPistol_Glock18c.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_AutoPistol_Glock18c.Fire.Fire3P")/*Ref SoundCue'A_WP_AutoPistol_Glock18c.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_AutoPistol_Glock18c.Reverb.Reverb3P")/*Ref SoundCue'A_WP_AutoPistol_Glock18c.Reverb.Reverb3P'*/,
		};
		WeaponClickSnd = LoadAsset<SoundCue>("A_WP_Handling.Pistol.DryFire")/*Ref SoundCue'A_WP_Handling.Pistol.DryFire'*/;
		OutOfAmmoAnimName = (name)"weaponposeempty";
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/;
		Mesh1p = Default__TdWeapon_Pistol_Glock18c_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Pistol_Glock18c_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.ThirdPersonMesh'*/;
		CombatRange_Min = 1200.0f;
		CombatRange_Max = 2500.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 3,
			Length_Max = 3,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 3,
			Pause_Min = 1.0f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Max = 2,
			Pause_Max = 1.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 2.50f,
			Time_Max = 3.20f,
		};
		CombatRange_Max_CHASE = 2500.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 3,
			Length_Max = 3,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 2,
			Length_Max = 3,
			Pause_Min = 1.0f,
			Pause_Max = 1.20f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 2,
			Pause_Max = 1.50f,
		};
		PreReloadTime = 0.50f;
		RecoilAmount = 2.0f;
		MaxRecoil = 9.0f;
		KickbackAmount = 10.0f;
		FiringStatesArray = new array<name>
		{
			(name)"WeaponBursting",
		};
		FireInterval = new array<float>
		{
			0.10f,
		};
		InstantHitDamage = new array<float>
		{
			17.0f,
		};
		InstantHitMomentum = new array<float>
		{
			12.0f,
		};
		EquipTime = 0.750f;
		WeaponRange = 4500.0f;
		Mesh = Default__TdWeapon_Pistol_Glock18c_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.FirstPersonMesh'*/;
		DroppedPickupMesh = Default__TdWeapon_Pistol_Glock18c_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Pistol_Glock18c_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Pistol_Glock18c_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.FirstPersonMesh'*/,
			Default__TdWeapon_Pistol_Glock18c_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Glock18c.ThirdPersonMesh'*/,
		};
	}
}
}