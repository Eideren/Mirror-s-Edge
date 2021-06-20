namespace MEdge.TdSharedContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Sniper_BarretM95 : TdWeapon_Heavy/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public MaterialEffect ScopeEffect;
	public /*transient */MaterialInstanceConstant ScopeEffectMaterialInstance;
	public bool LasersAttached;
	public /*transient */bool bZoomed;
	public /*transient */bool bIsZooming;
	public /*private transient */bool bWasZoomed;
	public/*(WeaponEffects)*/ ParticleSystem LaserBeamTemplate;
	public/*(WeaponEffects)*/ ParticleSystem LaserHitTemplate;
	public/*(WeaponEffects)*/ LensFlare LaserSourceLensFlareTemplate;
	public name LaserSightSocket;
	public TdEmitter LaserBeamEmitter;
	public TdLensFlareSource LaserSourceLensFlare;
	public TdEmitter LaserHitEmitter;
	public /*transient */float LaserBeamFadeParameter;
	public/*()*/ float ZoomFOV;
	public/*()*/ float ZoomRate;
	public/*()*/ float ZoomDelay;
	public/*()*/ float AdditionalUnzoomedSpread;
	public /*private transient */float ScopeDelayX;
	public /*private transient */float ScopeDelayY;
	public /*private transient */Object.Rotator ScopeRotationCache;
	
	public override /*simulated function */void AttachWeaponEffects(TdSkeletalMeshComponent SKMesh)
	{
	
	}
	
	public override /*simulated function */void DetachWeaponEffects(TdSkeletalMeshComponent SKMesh)
	{
	
	}
	
	public virtual /*simulated function */void InitiateScopeEffect()
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdWeapon_Sniper_BarretM95_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdWeapon_Sniper_BarretM95_Tick;
	public /*simulated function */void TdWeapon_Sniper_BarretM95_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void TickLaserBeam()
	{
	
	}
	
	public virtual /*simulated function */void TickScopeEffect(float DeltaTime)
	{
	
	}
	
	public override /*simulated function */Object.Rotator AddSpread(Object.Rotator BaseAim)
	{
	
		return default;
	}
	
	public override /*simulated function */bool GetFireAnimName(ref name FireAnimName)
	{
	
		return default;
	}
	
	public override /*simulated function */bool IsZoomingOrZoomed()
	{
	
		return default;
	}
	
	public override /*simulated function */bool IsZooming()
	{
	
		return default;
	}
	
	public override /*simulated function */bool ToggleZoom(ref float outDesiredFOV, ref float outZoomRate, ref float outDelay)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void ZoomIn(ref float outDesiredFOV, ref float outZoomRate)
	{
	
	}
	
	public override /*simulated function */void ZoomOut(ref float outDesiredFOV, ref float outZoomRate)
	{
	
	}
	
	public virtual /*function */void DoneZoomingOut()
	{
	
	}
	
	public virtual /*function */void DoneZoomingIn()
	{
	
	}
	
	public virtual /*function */void PlayZoomOutAnimation()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public TdWeapon_Sniper_BarretM95()
	{
		var Default__TdWeapon_Sniper_BarretM95_FiringWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x00013BBC
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 100,
					RightAmplitude = 0,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 15,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_LinearDecreasing,
					Duration = 1.50f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon_Sniper_BarretM95.FiringWaveformObj' */;
		var Default__TdWeapon_Sniper_BarretM95_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0001576B
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_M95.SK_M95")/*Ref SkeletalMesh'WP_M95.SK_M95'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_M95.AS_C1P_TwoHanded_M95")/*Ref TdAnimSet'AS_C1P_TwoHanded_M95.AS_C1P_TwoHanded_M95'*/,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.FirstPersonMesh' */;
		var Default__TdWeapon_Sniper_BarretM95_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x000157C3
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_M95.SK_M95")/*Ref SkeletalMesh'WP_M95.SK_M95'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("WP_M95.PA_M95")/*Ref PhysicsAsset'WP_M95.PA_M95'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_M95.AS_F3P_TwoHanded_M95")/*Ref TdAnimSet'AS_F3P_TwoHanded_M95.AS_F3P_TwoHanded_M95'*/,
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
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.ThirdPersonMesh' */;
		// Object Offset:0x0001260F
		LaserBeamTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserBeam_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserBeam_01'*/;
		LaserHitTemplate = LoadAsset<TdParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserDot_01")/*Ref TdParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserDot_01'*/;
		LaserSourceLensFlareTemplate = LoadAsset<LensFlare>("FX_LightEffects.LensFlares.LF_FX_LensFlare_LaserFlare_01")/*Ref LensFlare'FX_LightEffects.LensFlares.LF_FX_LensFlare_LaserFlare_01'*/;
		LaserSightSocket = (name)"LaserSight2";
		LaserBeamFadeParameter = 1.0f;
		ZoomFOV = 12.0f;
		ZoomRate = 800.0f;
		ZoomDelay = 0.40f;
		AdditionalUnzoomedSpread = 0.50f;
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"TwoHanded",
		};
		WeaponPoseProfileName = (name)"TwoHanded-M95";
		bAutoReload = true;
		bCanZoom = true;
		bStickyAim = false;
		MuzzleFlashPSCTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_Heavy_Singleshot_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_MuzzleFlash1p_Heavy_Singleshot_01'*/;
		MuzzleFlashSocket = (name)"Muzzleflash";
		BulletTraceTemplate = default;
		ShellEjectPS = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_Shell556_Auto")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_Shell556_Auto'*/;
		ShellEjectSocket = (name)"ShellEject";
		FiringWaveform = Default__TdWeapon_Sniper_BarretM95_FiringWaveformObj/*Ref ForceFeedbackWaveform'Default__TdWeapon_Sniper_BarretM95.FiringWaveformObj'*/;
		MaxAmmo = 20;
		ReloadTime = 4.0f;
		BurstMax = 1;
		AmmoCount = 20;
		ClipCount = 0;
		InstantHitDamageMP = new array<float>
		{
			50.0f,
		};
		WeaponFallOffTypes = new array<TdWeapon.EWeaponFallOffType>
		{
			148,
		};
		FallOffDistance = 180000.0f;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Fire.Fire1P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Fire.Fire1P'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Reverb.Reverb1P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Reverb.Reverb1P'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Fire.Fire3P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Fire.Fire3P'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Reverb.Reverb3P'*/,
		};
		WeaponCollisionSnd = LoadAsset<SoundCue>("A_WP_Drops.Heavy.HeavyDrop")/*Ref SoundCue'A_WP_Drops.Heavy.HeavyDrop'*/;
		WeaponSlapBackSnd = LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Slapback.Slapback")/*Ref SoundCue'A_WP_Sniper_BarretM95.Slapback.Slapback'*/;
		MaxNumberOfSlapBackRays = 7;
		NumberOfSlapBacks = 5;
		RangeOfSlapBackRays = 15000;
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_M95.AS_C1P_TwoHanded_M95")/*Ref TdAnimSet'AS_C1P_TwoHanded_M95.AS_C1P_TwoHanded_M95'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_M95.AS_F3P_TwoHanded_M95")/*Ref TdAnimSet'AS_F3P_TwoHanded_M95.AS_F3P_TwoHanded_M95'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_M95.AS_F3P_TwoHanded_M95")/*Ref TdAnimSet'AS_F3P_TwoHanded_M95.AS_F3P_TwoHanded_M95'*/;
		Mesh1p = Default__TdWeapon_Sniper_BarretM95_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_Sniper_BarretM95_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.ThirdPersonMesh'*/;
		AIDamageMultiplier = 0.80f;
		CombatRange_Min = 800.0f;
		CombatRange_Max = 20000.0f;
		CombatRange_Preferred = 5000.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 2.50f,
			Pause_Max = 2.50f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 2.50f,
			Pause_Max = 2.50f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Min = 2.50f,
			Pause_Max = 2.50f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 4.50f,
			Time_Max = 4.70f,
		};
		CombatRange_Max_CHASE = 20000.0f;
		CombatRange_Preferred_CHASE = 5000.0f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 2.50f,
			Pause_Max = 2.50f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 1,
			Pause_Min = 2.50f,
			Pause_Max = 2.50f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Max = 1,
			Pause_Min = 2.50f,
			Pause_Max = 2.50f,
		};
		RecoilAmount = 1.0f;
		KickbackAmount = 10.0f;
		FireInterval = new array<float>
		{
			1.70f,
		};
		Spread = new array<float>
		{
			0.0010f,
		};
		InstantHitDamage = new array<float>
		{
			100.0f,
		};
		InstantHitMomentum = new array<float>
		{
			50.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_Sniper_Bullet>(),
		};
		EquipTime = 0.750f;
		WeaponRange = 20000.0f;
		Mesh = Default__TdWeapon_Sniper_BarretM95_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.FirstPersonMesh'*/;
		PickupSound = LoadAsset<SoundCue>("A_WP_Handling.Heavy.HeavyHandling")/*Ref SoundCue'A_WP_Handling.Heavy.HeavyHandling'*/;
		DroppedPickupMesh = Default__TdWeapon_Sniper_BarretM95_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_Sniper_BarretM95_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_Sniper_BarretM95_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.FirstPersonMesh'*/,
			Default__TdWeapon_Sniper_BarretM95_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon_Sniper_BarretM95.ThirdPersonMesh'*/,
		};
	}
}
}