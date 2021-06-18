namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Pistol_Colt1911 : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public TdWeapon_Pistol_Colt1911()
	{
		var Default__TdWeapon_Pistol_Colt1911_FiringWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x00013748
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 30,
					RightAmplitude = 10,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Pistol_Colt1911.FiringWaveformObj' */;
		var Default__TdWeapon_Pistol_Colt1911_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000149D3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Colt1911.SK_Colt1911")/*Ref SkeletalMesh'WP_Colt1911.SK_Colt1911'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Colt1911.AS_C1P_OneHanded_Colt1911")/*Ref TdAnimSet'AS_C1P_OneHanded_Colt1911.AS_C1P_OneHanded_Colt1911'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Colt1911.FirstPersonMesh' */;
		var Default__TdWeapon_Pistol_Colt1911_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00014A2B
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_Colt1911.SK_Colt1911")/*Ref SkeletalMesh'WP_Colt1911.SK_Colt1911'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_Colt1911.PA_Colt1911")/*Ref PhysicsAsset'WP_Colt1911.PA_Colt1911'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Colt1911.AS_F3P_OneHanded_Colt1911")/*Ref TdAnimSet'AS_F3P_OneHanded_Colt1911.AS_F3P_OneHanded_Colt1911'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Pistol_Colt1911.ThirdPersonMesh' */;
		// Object Offset:0x0000C28D
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		WeaponPoseProfileName = (name)"OneHanded-Colt1911";
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_Singleshot_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_HandGun_Singleshot_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell9mm_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = Default__TdWeapon_Pistol_Colt1911_FiringWaveformObj;
		MaxAmmo = 8;
		ReloadTime = 2.0f;
		BurstMax = 1;
		AmmoCount = 8;
		InstantHitDamageMP = new array<float>
		{
			12.0f,
		};
		FallOffDistance = 600.0f;
		DeathAnimType = 4;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_Colt1911.Fire.Fire1P")/*Ref SoundCue'A_WP_Pistol_Colt1911.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_Colt1911.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Pistol_Colt1911.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_Colt1911.Fire.Fire3P")/*Ref SoundCue'A_WP_Pistol_Colt1911.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Pistol_Colt1911.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Pistol_Colt1911.Reverb.Reverb3P'*/,
		};
		WeaponClickSnd = LoadAsset<SoundCue>("A_WP_Handling.Pistol.DryFire")/*Ref SoundCue'A_WP_Handling.Pistol.DryFire'*/;
		OutOfAmmoAnimName = (name)"weaponposeempty";
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Colt1911.AS_C1P_OneHanded_Colt1911")/*Ref TdAnimSet'AS_C1P_OneHanded_Colt1911.AS_C1P_OneHanded_Colt1911'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Colt1911.AS_F3P_OneHanded_Colt1911")/*Ref TdAnimSet'AS_F3P_OneHanded_Colt1911.AS_F3P_OneHanded_Colt1911'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Colt1911.AS_F3P_OneHanded_Colt1911")/*Ref TdAnimSet'AS_F3P_OneHanded_Colt1911.AS_F3P_OneHanded_Colt1911'*/;
		Mesh1p = Default__TdWeapon_Pistol_Colt1911_FirstPersonMesh;
		Mesh3p = Default__TdWeapon_Pistol_Colt1911_ThirdPersonMesh;
		CombatRange_Min = 1200.0f;
		CombatRange_Max = 2000.0f;
		CombatRange_Preferred = 1500.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.30f,
			Pause_Max = 0.50f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Max = 1.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 2.50f,
			Time_Max = 3.20f,
		};
		CombatRange_Max_CHASE = 2000.0f;
		CombatRange_Preferred_CHASE = 1500.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 0.30f,
			Pause_Max = 0.50f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Max = 1.50f,
		};
		PreReloadTime = 0.50f;
		RecoilAmount = 2.0f;
		MaxRecoil = 9.0f;
		KickbackAmount = 10.0f;
		FireInterval = new array<float>
		{
			0.20f,
		};
		InstantHitDamage = new array<float>
		{
			42.0f,
		};
		EquipTime = 0.750f;
		WeaponRange = 4500.0f;
		Mesh = Default__TdWeapon_Pistol_Colt1911_FirstPersonMesh;
		DroppedPickupMesh = Default__TdWeapon_Pistol_Colt1911_ThirdPersonMesh;
		PickupFactoryMesh = Default__TdWeapon_Pistol_Colt1911_FirstPersonMesh;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Pistol_Colt1911_FirstPersonMesh,
			Default__TdWeapon_Pistol_Colt1911_ThirdPersonMesh,
		};
	}
}
}