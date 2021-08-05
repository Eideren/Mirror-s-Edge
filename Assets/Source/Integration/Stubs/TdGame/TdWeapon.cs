// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon : Weapon/*
		abstract
		native
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public const int MAX_TRACERS = 3;
	
	public enum EWeaponFallOffType 
	{
		EWFOT_Linear,
		EWFOT_Logarithmic,
		EWFOT_Inverse,
		EWFOT_LogReverse,
		EWFOT_MAX
	};
	
	public enum EWeaponDecalType 
	{
		EWDT_Light,
		EWDT_Heavy,
		EWDT_ShotGun,
		EWDT_None,
		EWDT_MAX
	};
	
	public enum EWeaponReloadAnimationType 
	{
		WRAT_Start,
		WRAT_Reload,
		WRAT_End,
		WRAT_MAX
	};
	
	public partial struct /*native */FloatDifficultySettings
	{
		public float Easy;
		public float Medium;
		public float Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006C17A4
	//		Easy = 0.0f;
	//		Medium = 0.0f;
	//		Hard = 0.0f;
	//	}
	};
	
	public partial struct /*native */AIBurstInfo
	{
		[Category] public int Length_Min;
		[Category] public int Length_Max;
		[Category] public float Pause_Min;
		[Category] public float Pause_Max;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006C18E0
	//		Length_Min = 0;
	//		Length_Max = 0;
	//		Pause_Min = 0.0f;
	//		Pause_Max = 0.0f;
	//	}
	};
	
	public partial struct /*native */AIReloadInfo
	{
		[Category] public float Time_Min;
		[Category] public float Time_Max;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006C19E0
	//		Time_Min = 0.0f;
	//		Time_Max = 0.0f;
	//	}
	};
	
	public partial struct /*native */PendingImpact
	{
		public float TimeToImpact;
		public Actor.ImpactInfo Impact;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006C1AAC
	//		TimeToImpact = 0.0f;
	//		Impact = new Actor.ImpactInfo
	//		{
	//			HitActor = default,
	//			HitLocation = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			HitNormal = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			RayDir = new Vector
	//			{
	//				X=0.0f,
	//				Y=0.0f,
	//				Z=0.0f
	//			},
	//			HitInfo = new Actor.TraceHitInfo
	//			{
	//				Material = default,
	//				PhysMaterial = default,
	//				Item = 0,
	//				LevelIndex = 0,
	//				BoneName = (name)"None",
	//				HitComponent = default,
	//			},
	//			TracedDistance = 0.0f,
	//		};
	//	}
	};
	
	[Const] public array<name> AimOffsetProfileNames;
	[Const] public name WeaponPoseProfileName;
	[Category] public Object.Rotator OneHandedRightShoulderRotationOffset;
	[Category] public Object.Vector OneHandedRightShoulderTranslationOffset;
	[Category] public Object.Vector weaponDrawOffset;
	[Category] public Object.Rotator weaponRotationOffset;
	public bool bTakingDamage;
	public bool bAutoReload;
	public bool bAutoDrop;
	public bool bCanZoom;
	public bool bPlayFlyBys;
	public bool bRemoteWeapon;
	[Category("StickyAim")] [config] public bool bStickyAim;
	[Category("StickyAim")] [config] public bool bDebugStickyAim;
	public bool OverrideWeaponFireTypeForAI;
	public name ReloadingState;
	[Category] [config] public Object.Vector WeaponDropAngularVelocity;
	[Category] [config] public Object.Vector WeaponDropLinearVelocity;
	[Category] [config] public int TimeThrownWeaponStaysInWorld;
	[Category("WeaponEffects")] public TdAnimNodeSlot WeaponAnimationNode1p;
	[Category("WeaponEffects")] public TdAnimNodeSlot WeaponAnimationNode3p;
	[Category("WeaponEffects")] [export, editinline] public ParticleSystemComponent MuzzleFlashPSC;
	[Category("WeaponEffects")] public ParticleSystem MuzzleFlashPSCTemplate;
	public name MuzzleFlashSocket;
	[Category("WeaponEffects")] public ParticleSystem BulletTraceTemplate;
	[Category("WeaponEffects")] public ParticleSystem ShellEjectPS;
	public name ShellEjectSocket;
	public float ShellEjectDelay;
	[transient] public TdEmitter ShellEjectEmitter;
	public/*protected*/ ForceFeedbackWaveform FiringWaveform;
	[Category("Ammunition")] public int MaxAmmo;
	[Category("Ammunition")] public float StartReloadTime;
	[Category("Ammunition")] public float ReloadTime;
	[Category("Ammunition")] public float EndReloadTime;
	[Category("Ammunition")] public int BurstMax;
	public int AmmoCount;
	public int BurstCnt;
	public int ClipCount;
	public/*protected*/ int PassThroughLimit;
	[Category] public array<float> InstantHitDamageMP;
	[Const] public Texture2D NormalCrossHair;
	[Const] public Texture2D OnTargetCrossHair;
	[Const] public Object.LinearColor OnTargetCrossHairColor;
	[Category] public array<bool> bAutomaticReFire;
	[Category] public array<bool> bStallReFire;
	[Category] public array<float> FireIntervalNoise;
	[transient] public array<float> ActualFireIntervalNoise;
	public array<TdWeapon.EWeaponFallOffType> WeaponFallOffTypes;
	[Category] public float FallOffDistance;
	[config] public int DeathAnimType;
	[config] public/*private*/ TdWeapon.FloatDifficultySettings FallOffDistances;
	[config] public/*private*/ TdWeapon.FloatDifficultySettings Ranges;
	[config] public/*private*/ TdWeapon.FloatDifficultySettings Damages;
	[Category("Speed")] public float MovementRecoilWhenFire;
	[Category("Sounds")] public array<SoundCue> WeaponFireSnd1p;
	[Category("Sounds")] public array<SoundCue> WeaponReverbSnd1p;
	[Category("Sounds")] public array<SoundCue> WeaponFireSnd3p;
	[Category("Sounds")] public array<SoundCue> WeaponReverbSnd3p;
	[Category("Sounds")] public SoundCue WeaponCollisionSnd;
	[Category("Sounds")] public SoundCue WeaponClickSnd;
	[Category("Sounds")] public SoundCue WeaponSlapBackSnd;
	[Category("Sounds")] public int MaxNumberOfSlapBackRays;
	[Category("Sounds")] public int NumberOfSlapBacks;
	[Category("Sounds")] public int RangeOfSlapBackRays;
	public name OutOfAmmoAnimName;
	public TdPawn.EWeaponType WeaponType;
	[Category] public TdWeapon.EWeaponDecalType DecalTypeToUse;
	public AnimSet AnimationSetCharacter1p;
	public AnimSet AnimationSetFemale3p;
	public AnimSet AnimationSetMale3p;
	[export, editinline] public TdSkeletalMeshComponent Mesh1p;
	[export, editinline] public TdSkeletalMeshComponent Mesh3p;
	[Category("AimAssist")] public int MaxAssistDistance;
	[Category("AimAssist")] public float AssistInnerRadius;
	[Category("AimAssist")] public float AssistInnerHeight;
	[Category("AimAssist")] public float MaxAssistValueYaw;
	[Category("AimAssist")] public float MaxAssistValuePitch;
	[Category("AimAssist")] public float StrafeAssistMultiplier;
	[Category("AimAssist")] public float MaxAssistScaleDist;
	[Category("AimAssist")] public float MaxAssistScaleVal;
	[Category("AimAssist")] public float MinAssistScaleDist;
	[Category("AimAssist")] public float MinAssistScaleVal;
	[Category("StickyAim")] [config] public float StickyAimModifier;
	[Category("StickyAim")] public float StickyMaxDistance;
	[Category("StickyAim")] public Actor StickyActor;
	[Category("StickyAim")] public Object.Rotator StickyRotation;
	[config] public float AIDamageMultiplier;
	[config] public/*protected*/ float CombatRange_Min;
	[config] public/*protected*/ float CombatRange_Max;
	[config] public/*protected*/ float CombatRange_Preferred;
	[Category("AISettings")] [config] public/*protected*/ TdWeapon.AIBurstInfo AimedBurst_Near;
	[Category("AISettings")] [config] public/*protected*/ TdWeapon.AIBurstInfo AimedBurst_Mid;
	[Category("AISettings")] [config] public/*protected*/ TdWeapon.AIBurstInfo AimedBurst_Far;
	[Category("AISettings")] [config] public TdWeapon.AIReloadInfo ReloadReadyTime;
	[Category("AISettings")] [config] public/*protected*/ float MinKeepFiringTime;
	[Category("AISettings")] [config] public/*protected*/ float MaxKeepFiringTime;
	[config] public/*protected*/ float CombatRange_Max_CHASE;
	[config] public/*protected*/ float CombatRange_Preferred_CHASE;
	[Category("AISettings")] [config] public/*protected*/ float MinKeepFiringTime_CHASE;
	[Category("AISettings")] [config] public/*protected*/ float MaxKeepFiringTime_CHASE;
	[Category("AISettings")] [config] public/*protected*/ TdWeapon.AIBurstInfo AimedBurst_Near_CHASE;
	[Category("AISettings")] [config] public/*protected*/ TdWeapon.AIBurstInfo AimedBurst_Mid_CHASE;
	[Category("AISettings")] [config] public/*protected*/ TdWeapon.AIBurstInfo AimedBurst_Far_CHASE;
	[Category("AISettings")] [config] public float PreReloadTime;
	public float ReloadWaitTime;
	[export, editinline] public DecalComponent DefaultDecalComponent;
	public Material DefaultDecalMaterial;
	public PhysicalMaterial DefaultImpactMaterial;
	[Category] [config] public/*private*/ float DecalStretchingMultiplier;
	[Category] public float DecalCullDistance;
	[transient] public array<TdWeapon.PendingImpact> PendingImpacts;
	public StaticArray<TdEmitter, TdEmitter, TdEmitter>/*[3]*/ TracerEmitters;
	public int TracerEmitterIdx;
	[config] public float RecoilAmount;
	[config] public float RecoilRecoverTime;
	[config] public float MinRecoil;
	[config] public float MaxRecoil;
	[config] public float KickbackAmount;
	[transient] public array<MaterialInstanceConstant> LOIMaterialInstances;
	[transient] public float LOILastUpdateEffectAmount;
	[transient] public float LOIDisplayEffectTime;
	public name LOIparameter;
	[transient] public float LOIOriginalDisplayEffectTime;
	[Category] public float DebugDistance;
	
	//replication
	//{
	//	 if((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetOwner)
	//		AmmoCount, ClipCount;
	//
	//	 if((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetInitial)
	//		MaxAmmo;
	//}
	
	public virtual /*exec function */void DebugSlapBacks()
	{
	
	}
	
	public virtual /*exec function */void DebugWeapons()
	{
	
	}
	
	public virtual /*simulated function */void DrawWeaponFallOff(HUD HUD)
	{
	
	}
	
	public override /*simulated function */void GetWeaponDebug(ref array<String> DebugInfo)
	{
	
	}
	
	// Export UTdWeapon::execLOINotify(FFrame&, void* const)
	public virtual /*native final function */void LOINotify(bool toggle)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*final event */void InitLOIMtrlInstances()
	{
	
	}
	
	// Export UTdWeapon::execGetMinKeepFiringTime(FFrame&, void* const)
	public virtual /*native final function */float GetMinKeepFiringTime()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdWeapon::execGetMaxKeepFiringTime(FFrame&, void* const)
	public virtual /*native final function */float GetMaxKeepFiringTime()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*simulated function */void PreBeginPlay()
	{
	
	}
	
	public override /*simulated function */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public virtual /*simulated function */String GetOwnerName()
	{
	
		return default;
	}
	
	public override /*simulated function */float GetFireInterval(byte FireModeNum)
	{
	
		return default;
	}
	
	public virtual /*function */void SetDifficultyLevel(int Difficulty)
	{
	
	}
	
	public virtual /*simulated function */TdAnimNodeSlot GetWeaponAnimationNode1p()
	{
	
		return default;
	}
	
	public virtual /*simulated function */TdAnimNodeSlot GetWeaponAnimationNode3p()
	{
	
		return default;
	}
	
	public virtual /*final simulated event */AnimNodeSequence GetWeaponAnimation()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void UpdateAnimSets(bool bIsFemale, bool bIsFirstPerson)
	{
	
	}
	
	public virtual /*simulated function */void UpdateAnimations()
	{
	
	}
	
	public virtual /*simulated function */void SetFirstPerson(bool bActive)
	{
	
	}
	
	public override /*simulated function */Actor.ImpactInfo CalcWeaponFire(Object.Vector StartTrace, Object.Vector EndTrace, /*optional */ref array<Actor.ImpactInfo> ImpactList/* = default*/)
	{
	
		return default;
	}
	
	public override /*simulated function */bool PassThroughDamage(Actor HitActor, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool GetReloadAnimName(TdWeapon.EWeaponReloadAnimationType ReloadType, ref name ReloadAnimName)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void WeaponPlaySounds3p()
	{
	
	}
	
	public virtual /*simulated function */void WeaponPlaySounds1p()
	{
	
	}
	
	public virtual /*simulated function */void WeaponPlaySlapBackSound(SoundCue SC)
	{
	
	}
	
	public override /*simulated function */void PlayFiringSound()
	{
	
	}
	
	public virtual /*simulated function */void PlayReverbSound()
	{
	
	}
	
	public virtual /*simulated function */void AttachWeaponComponentsToPlayer(/*optional */bool? _bIsFirstPerson = default)
	{
	
	}
	
	public override /*simulated function */void DetachWeapon()
	{
	
	}
	
	public virtual /*simulated function */void AttachWeaponEffects(TdSkeletalMeshComponent SKMesh)
	{
	
	}
	
	public virtual /*simulated function */void DetachWeaponEffects(TdSkeletalMeshComponent SKMesh)
	{
	
	}
	
	public virtual /*simulated function */void CauseMuzzleFlash()
	{
	
	}
	
	public virtual /*simulated function */void MuzzleFlashTimer()
	{
	
	}
	
	public virtual /*simulated function */void StopMuzzleFlash()
	{
	
	}
	
	public override /*simulated function */void PlayFireEffects(byte FireModeNum, /*optional */Object.Vector? _HitLocation = default)
	{
	
	}
	
	public override /*simulated function */void StopFireEffects(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void PlayShellCaseEject()
	{
	
	}
	
	public virtual /*simulated function */void HideShellEject()
	{
	
	}
	
	public virtual /*function */void AdjustPlayerDamage(ref int Damage, Controller InstigatedBy, Object.Vector Hit, ref Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public override ShouldRefire_del ShouldRefire { get => bfield_ShouldRefire ?? TdWeapon_ShouldRefire; set => bfield_ShouldRefire = value; } ShouldRefire_del bfield_ShouldRefire;
	public override ShouldRefire_del global_ShouldRefire => TdWeapon_ShouldRefire;
	public /*simulated function */bool TdWeapon_ShouldRefire()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void WeaponFired(byte FiringMode, /*optional */Object.Vector? _HitLocation = default)
	{
	
	}
	
	public virtual /*simulated function */void WeaponStoppedFiring(byte FiringMode)
	{
	
	}
	
	public virtual /*simulated function */void FlashCountUpdated(byte FlashCount, byte FiringMode, bool bViaReplication)
	{
	
	}
	
	public virtual /*simulated function */void FlashLocationUpdated(byte FiringMode, Object.Vector FlashLocation, bool bViaReplication)
	{
	
	}
	
	public virtual /*simulated function */void CalcRemoteImpactEffects(byte FireModeNum, Object.Vector GivenHitLocation)
	{
	
	}
	
	public virtual /*simulated function */Actor.ImpactInfo CalcRemoteWeaponFire(Object.Vector StartTrace, Object.Vector EndTrace)
	{
	
		return default;
	}
	
	public override /*simulated function */void ProcessInstantHit(byte FiringMode, Actor.ImpactInfo Impact)
	{
	
	}
	
	public virtual /*simulated function */void RegisterPendingImpact(Actor.ImpactInfo Impact)
	{
	
	}
	
	public virtual /*simulated event */void PlayImpactEffects(Actor.ImpactInfo Impact)
	{
	
	}
	
	public virtual /*simulated function */void SpawnTracerEffect(Object.Vector HitLocation)
	{
	
	}
	
	public virtual /*simulated function */void SpawnImpactSounds(Actor.ImpactInfo Impact)
	{
	
	}
	
	public virtual /*simulated function */SoundCue GetImpactSound(PhysicalMaterial PMaterial)
	{
	
		return default;
	}
	
	public virtual /*simulated function */SoundCue GetWeaponSpecificImpactSound(TdPhysicalMaterialImpactSounds ImpactSounds)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void SpawnImpactEffects(Actor.ImpactInfo Impact)
	{
	
	}
	
	public override /*simulated function */bool EffectIsRelevant(Object.Vector SpawnLocation, bool bForceDedicated, /*optional */float? _CullDistance = default)
	{
	
		return default;
	}
	
	public virtual /*final function */ParticleSystem GetImpactEffect(PhysicalMaterial PMaterial)
	{
	
		return default;
	}
	
	public virtual /*function */ParticleSystem GetSpecificImpactEffect(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public virtual /*function */ParticleSystem GetSpecificImpactEffectPhysX(TdPhysicalMaterialImpactEffects ImpactEffects)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void SpawnImpactDecal(Actor.ImpactInfo Impact)
	{
	
	}
	
	public virtual /*simulated function */bool IsDecalRelevant(Object.Vector SpawnLocation, /*optional */float? _CullDistance = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */DecalComponent GetDecalData(Actor.TraceHitInfo HitInfo, /*optional */float? _ImpactAngle = default)
	{
	
		return default;
	}
	
	public virtual /*simulated function */DecalComponent ActuallyGetDecal(PhysicalMaterial mtrl, float Angle)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void InitDefaultDecalProperties()
	{
	
	}
	
	public override /*simulated function */void InstantFire()
	{
	
	}
	
	public override /*simulated function */void ClearFlashLocation()
	{
	
	}
	
	public virtual /*simulated function */bool GetFireAnimName(ref name FireAnimName)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void PlayFiringAnimation()
	{
	
	}
	
	public virtual /*simulated function */void PlayCustomWeaponAnimation(name AnimationName)
	{
	
	}
	
	public override /*simulated function */void ConsumeAmmo(byte FireModeNum)
	{
	
	}
	
	public virtual /*simulated function */void PlayReloadAnimation(TdWeapon.EWeaponReloadAnimationType ReloadType)
	{
	
	}
	
	public override IsFiring_del IsFiring { get => bfield_IsFiring ?? TdWeapon_IsFiring; set => bfield_IsFiring = value; } IsFiring_del bfield_IsFiring;
	public override IsFiring_del global_IsFiring => TdWeapon_IsFiring;
	public /*simulated function */bool TdWeapon_IsFiring()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void StopFiring(/*optional */float? _BlendTime = default)
	{
	
	}
	
	public delegate bool IsReloading_del();
	public virtual IsReloading_del IsReloading { get => bfield_IsReloading ?? TdWeapon_IsReloading; set => bfield_IsReloading = value; } IsReloading_del bfield_IsReloading;
	public virtual IsReloading_del global_IsReloading => TdWeapon_IsReloading;
	public /*simulated function */bool TdWeapon_IsReloading()
	{
	
		return default;
	}
	
	public delegate bool IsInStateReloading_del();
	public virtual IsInStateReloading_del IsInStateReloading { get => bfield_IsInStateReloading ?? TdWeapon_IsInStateReloading; set => bfield_IsInStateReloading = value; } IsInStateReloading_del bfield_IsInStateReloading;
	public virtual IsInStateReloading_del global_IsInStateReloading => TdWeapon_IsInStateReloading;
	public /*simulated function */bool TdWeapon_IsInStateReloading()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void StopReloading(/*optional */float? _BlendTime = default, /*optional */bool? _SuccessfulReload = default)
	{
	
	}
	
	public override /*simulated function */bool HasAmmo(byte FireModeNum, /*optional */int? _Amount = default)
	{
	
		return default;
	}
	
	public override /*simulated function */bool HasAnyAmmo()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void IncrementReloadCount()
	{
	
	}
	
	public virtual /*simulated function */void ClearReloadCount()
	{
	
	}
	
	public override WeaponEmpty_del WeaponEmpty { get => bfield_WeaponEmpty ?? TdWeapon_WeaponEmpty; set => bfield_WeaponEmpty = value; } WeaponEmpty_del bfield_WeaponEmpty;
	public override WeaponEmpty_del global_WeaponEmpty => TdWeapon_WeaponEmpty;
	public /*simulated function */void TdWeapon_WeaponEmpty()
	{
	
	}
	
	public virtual /*simulated function */void ReloadWaitComplete()
	{
	
	}
	
	public virtual /*simulated function */void WeaponReloadedTimer()
	{
	
	}
	
	public virtual /*simulated function */void AssignAmmo()
	{
	
	}
	
	public delegate void WeaponReloaded_del(/*optional */bool? _SuccessfulReload = default);
	public virtual WeaponReloaded_del WeaponReloaded { get => bfield_WeaponReloaded ?? TdWeapon_WeaponReloaded; set => bfield_WeaponReloaded = value; } WeaponReloaded_del bfield_WeaponReloaded;
	public virtual WeaponReloaded_del global_WeaponReloaded => TdWeapon_WeaponReloaded;
	public /*simulated function */void TdWeapon_WeaponReloaded(/*optional */bool? _SuccessfulReload = default)
	{
	
	}
	
	public delegate void ReloadWeapon_del();
	public virtual ReloadWeapon_del ReloadWeapon { get => bfield_ReloadWeapon ?? TdWeapon_ReloadWeapon; set => bfield_ReloadWeapon = value; } ReloadWeapon_del bfield_ReloadWeapon;
	public virtual ReloadWeapon_del global_ReloadWeapon => TdWeapon_ReloadWeapon;
	public /*simulated function */void TdWeapon_ReloadWeapon()
	{
	
	}
	
	public virtual /*reliable server function */void ServerReloadWeapon()
	{
	
	}
	
	public virtual /*simulated function */bool IsZoomingOrZoomed()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool IsZooming()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool ToggleZoom(ref float outDesiredFOV, ref float outZoomRate, ref float outDelay)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void ZoomOut(ref float outDesiredFOV, ref float outZoomRate)
	{
	
	}
	
	public virtual /*simulated function */void TimeWeaponReloading()
	{
	
	}
	
	public virtual /*simulated function */void TimeWeaponEndReloading()
	{
	
	}
	
	public override /*simulated function */void TimeWeaponPutDown()
	{
	
	}
	
	public virtual /*simulated function */void TimeWeaponPutAway()
	{
	
	}
	
	public virtual /*simulated function */void TimeReloadWait()
	{
	
	}
	
	public override /*simulated function */void ActiveRenderOverlays(HUD H)
	{
	
	}
	
	public virtual /*simulated function */bool IsValidCrosshairTarget(TdHUD myHUD)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool IsValidStickyActor(Actor PotentialStickyActor, Pawn myPawn)
	{
	
		return default;
	}
	
	public virtual /*simulated function */int GetFinalStickyAngle(TdMove CurrentMove, TdPawn StickyPawn)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void ForceNewStickyActor(Actor NewStickyActor, TdHUD HUD, Controller Controller, TdMove CurrentMove, float DeltaTime)
	{
	
	}
	
	public virtual /*simulated function */void UpdateStickyActor(TdHUD HUD, Controller Controller, TdMove CurrentMove, float DeltaTime)
	{
	
	}
	
	public virtual /*reliable server function */void ServerResetStickyActor()
	{
	
	}
	
	public virtual /*reliable server function */void ServerUpdateStickyActor(Actor inActor)
	{
	
	}
	
	public virtual /*simulated function */void SetStickyAimOffset(float DeltaTime, Object.Rotator ControllerRotation)
	{
	
	}
	
	public override StartFire_del StartFire { get => bfield_StartFire ?? TdWeapon_StartFire; set => bfield_StartFire = value; } StartFire_del bfield_StartFire;
	public override StartFire_del global_StartFire => TdWeapon_StartFire;
	public /*simulated function */void TdWeapon_StartFire(byte FireModeNum)
	{
	
	}
	
	public override /*simulated function */Object.Rotator GetAdjustedAim(Object.Vector StartFireLoc)
	{
	
		return default;
	}
	
	public virtual /*reliable server function */void ServerStartStickyFire(byte FireModeNum, int StickyYaw, int StickyPitch, Actor SA)
	{
	
	}
	
	public override ServerStartFire_del ServerStartFire { get => bfield_ServerStartFire ?? TdWeapon_ServerStartFire; set => bfield_ServerStartFire = value; } ServerStartFire_del bfield_ServerStartFire;
	public override ServerStartFire_del global_ServerStartFire => TdWeapon_ServerStartFire;
	public /*reliable server function */void TdWeapon_ServerStartFire(byte FireModeNum)
	{
	
	}
	
	public override /*simulated function */void FireAmmunition()
	{
	
	}
	
	public virtual /*simulated function */void WeaponStartReloading(/*optional */float? _WaitTime = default)
	{
	
	}
	
	public delegate void WeaponStoppedReloading_del();
	public virtual WeaponStoppedReloading_del WeaponStoppedReloading { get => bfield_WeaponStoppedReloading ?? TdWeapon_WeaponStoppedReloading; set => bfield_WeaponStoppedReloading = value; } WeaponStoppedReloading_del bfield_WeaponStoppedReloading;
	public virtual WeaponStoppedReloading_del global_WeaponStoppedReloading => TdWeapon_WeaponStoppedReloading;
	public /*simulated function */void TdWeapon_WeaponStoppedReloading()
	{
	
	}
	
	public override RefireCheckTimer_del RefireCheckTimer { get => bfield_RefireCheckTimer ?? TdWeapon_RefireCheckTimer; set => bfield_RefireCheckTimer = value; } RefireCheckTimer_del bfield_RefireCheckTimer;
	public override RefireCheckTimer_del global_RefireCheckTimer => TdWeapon_RefireCheckTimer;
	public /*simulated function */void TdWeapon_RefireCheckTimer()
	{
	
	}
	
	public virtual /*simulated function */int GetMaxBurstCnt()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void AbortBurst()
	{
	
	}
	
	public virtual /*simulated function */float GetInstantHitDamage(int Mode, float Distance)
	{
	
		return default;
	}
	
	public virtual /*simulated function */float GetInstantHitMomentum(int Mode, float Distance)
	{
	
		return default;
	}
	
	public override /*function */void DropFrom(Object.Vector StartLocation, Object.Vector StartVelocity)
	{
	
	}
	
	public virtual /*function */void DropFromEx(Object.Vector StartLocation, Object.Vector StartVelocity, Object.Rotator StartRotation, Object.Vector StartAngularVelocity)
	{
	
	}
	
	public delegate void WeaponEndReloaded_del();
	public virtual WeaponEndReloaded_del WeaponEndReloaded { get => bfield_WeaponEndReloaded ?? (()=>{}); set => bfield_WeaponEndReloaded = value; } WeaponEndReloaded_del bfield_WeaponEndReloaded;
	public virtual WeaponEndReloaded_del global_WeaponEndReloaded => ()=>{};
	
	public delegate void DropWeaponTimer_del();
	public virtual DropWeaponTimer_del DropWeaponTimer { get => bfield_DropWeaponTimer ?? (()=>{}); set => bfield_DropWeaponTimer = value; } DropWeaponTimer_del bfield_DropWeaponTimer;
	public virtual DropWeaponTimer_del global_DropWeaponTimer => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		ShouldRefire = null;
		IsFiring = null;
		IsReloading = null;
		IsInStateReloading = null;
		WeaponEmpty = null;
		WeaponReloaded = null;
		ReloadWeapon = null;
		StartFire = null;
		ServerStartFire = null;
		WeaponStoppedReloading = null;
		RefireCheckTimer = null;
	
	}
	
	protected /*simulated function */bool TdWeapon_WeaponFiring_IsFiring()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_WeaponFiring_RefireCheckTimer()// state function
	{
	
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponFiring()/*simulated state WeaponFiring*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void TdWeapon_WeaponReloading_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */bool TdWeapon_WeaponReloading_IsReloading()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */bool TdWeapon_WeaponReloading_IsInStateReloading()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */bool TdWeapon_WeaponReloading_ShouldRefire()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_WeaponReloading_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*simulated function */bool TdWeapon_WeaponReloading_TryPutDown()// state function
	{
	
		return default;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponReloading()/*simulated state WeaponReloading*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void TdWeapon_WeaponLoopReloading_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_WeaponLoopReloading_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*simulated function */bool TdWeapon_WeaponLoopReloading_IsReloading()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */bool TdWeapon_WeaponLoopReloading_IsInStateReloading()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_WeaponLoopReloading_WeaponReloaded(/*optional */bool? _SuccessfulReload = default)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_WeaponLoopReloading_WeaponEndReloaded()// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_WeaponLoopReloading_WeaponStoppedReloading()// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_WeaponLoopReloading_StartFire(byte FireModeNum)// state function
	{
	
	}
	
	protected /*reliable server function */void TdWeapon_WeaponLoopReloading_ServerStartFire(byte FireModeNum)// state function
	{
	
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponLoopReloading()/*simulated state WeaponLoopReloading extends WeaponReloading*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void TdWeapon_WeaponBursting_BeginState(name PrevStateName)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_WeaponBursting_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*simulated function */bool TdWeapon_WeaponBursting_TryPutDown()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */bool TdWeapon_WeaponBursting_IsFiring()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_WeaponBursting_RefireCheckTimer()// state function
	{
	
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponBursting()/*simulated state WeaponBursting extends WeaponFiring*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */void TdWeapon_WeaponPuttingDown_WeaponIsDown()// state function
	{
	
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) WeaponPuttingDown()/*simulated state WeaponPuttingDown*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdWeapon_OutOfAmmo_BeginState(name PreviouseState)// state function
	{
	
	}
	
	protected /*function */void TdWeapon_OutOfAmmo_DropWeaponTimer()// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_OutOfAmmo_StartFire(byte FireModeNum)// state function
	{
	
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) OutOfAmmo()/*simulated state OutOfAmmo*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "WeaponFiring": return WeaponFiring();
			case "WeaponReloading": return WeaponReloading();
			case "WeaponLoopReloading": return WeaponLoopReloading();
			case "WeaponBursting": return WeaponBursting();
			case "WeaponPuttingDown": return WeaponPuttingDown();
			case "OutOfAmmo": return OutOfAmmo();
			default: return base.FindState(stateName);
		}
	}
	public TdWeapon()
	{
		var Default__TdWeapon_FiringWaveformObj = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CFF4
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 10,
					RightAmplitude = 5,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					Duration = 0.20f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdWeapon.FiringWaveformObj' */;
		var Default__TdWeapon_FirstPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x006CD455
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Weapons.AT_C1P_Weapon_Default")/*Ref AnimTree'AT_Weapons.AT_C1P_Weapon_Default'*/,
			bUpdateSkelWhenNotRendered = false,
			bIgnoreControllersWhenNotRendered = true,
			bForceDiscardRootMotion = true,
			DepthPriorityGroup = Scene.ESceneDepthPriorityGroup.SDPG_Foreground,
			bOnlyOwnerSee = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon.FirstPersonMesh' */;
		var Default__TdWeapon_ThirdPersonMesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x006CD519
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_Weapons.AT_Weapon_Default")/*Ref AnimTree'AT_Weapons.AT_Weapon_Default'*/,
			bUpdateSkelWhenNotRendered = false,
			bIgnoreControllersWhenNotRendered = true,
			bForceDiscardRootMotion = true,
			bOwnerNoSeeWithShadow = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon.ThirdPersonMesh' */;
		// Object Offset:0x006CC06C
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
		};
		WeaponPoseProfileName = (name)"Default";
		bAutoDrop = true;
		bPlayFlyBys = true;
		bStickyAim = true;
		OverrideWeaponFireTypeForAI = true;
		ReloadingState = (name)"WeaponReloading";
		WeaponDropLinearVelocity = new Vector
		{
			X=50.0f,
			Y=200.0f,
			Z=-80.0f
		};
		TimeThrownWeaponStaysInWorld = 1000;
		MuzzleFlashSocket = (name)"MuzzleFlashSocket";
		BulletTraceTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_BulletTracerDistort_01'*/;
		FiringWaveform = Default__TdWeapon_FiringWaveformObj/*Ref ForceFeedbackWaveform'Default__TdWeapon.FiringWaveformObj'*/;
		MaxAmmo = 33;
		ReloadTime = 2.30f;
		BurstMax = 3;
		AmmoCount = 33;
		ClipCount = -1;
		PassThroughLimit = 3;
		InstantHitDamageMP = new array<float>
		{
			4.0f,
		};
		NormalCrossHair = LoadAsset<Texture2D>("TdUIResources_InGame.CrossHair_Standard")/*Ref Texture2D'TdUIResources_InGame.CrossHair_Standard'*/;
		OnTargetCrossHair = LoadAsset<Texture2D>("TdUIResources_InGame.CrossHair_Standard")/*Ref Texture2D'TdUIResources_InGame.CrossHair_Standard'*/;
		OnTargetCrossHairColor = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=1.0f,
			A=1.0f
		};
		bAutomaticReFire = new array<bool>
		{
			false,
		};
		FireIntervalNoise = new array<float>
		{
			0.10f,
		};
		ActualFireIntervalNoise = new array<float>
		{
			0.0f,
		};
		WeaponFallOffTypes = new array<TdWeapon.EWeaponFallOffType>
		{
			#warning weird ass EWeaponFallOffType value replaced with default
			//150,
			default
		};
		FallOffDistance = 1000.0f;
		WeaponFireSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Default.Fire.Fire")/*Ref SoundCue'A_WP_Default.Fire.Fire'*/,
		};
		WeaponReverbSnd1p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Default.Fire.Reverb")/*Ref SoundCue'A_WP_Default.Fire.Reverb'*/,
		};
		WeaponFireSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Default.Fire.Reverb")/*Ref SoundCue'A_WP_Default.Fire.Reverb'*/,
		};
		WeaponReverbSnd3p = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_WP_Default.Fire.Fire")/*Ref SoundCue'A_WP_Default.Fire.Fire'*/,
		};
		MaxNumberOfSlapBackRays = 5;
		NumberOfSlapBacks = 2;
		RangeOfSlapBackRays = 10000;
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_None;
		Mesh1p = Default__TdWeapon_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.FirstPersonMesh'*/;
		Mesh3p = Default__TdWeapon_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.ThirdPersonMesh'*/;
		MaxAssistDistance = 600;
		AssistInnerRadius = 0.40f;
		AssistInnerHeight = 0.40f;
		MaxAssistValueYaw = 0.40f;
		MaxAssistValuePitch = 0.40f;
		StrafeAssistMultiplier = 0.20f;
		MaxAssistScaleDist = 600.0f;
		MaxAssistScaleVal = 2.0f;
		MinAssistScaleDist = 30.0f;
		MinAssistScaleVal = 0.50f;
		StickyMaxDistance = 5000.0f;
		AIDamageMultiplier = 1.0f;
		CombatRange_Min = 1000.0f;
		CombatRange_Max = 3000.0f;
		CombatRange_Preferred = 2000.0f;
		AimedBurst_Near = new TdWeapon.AIBurstInfo
		{
			Length_Min = 5,
			Length_Max = 6,
			Pause_Min = 0.50f,
			Pause_Max = 1.0f,
		};
		AimedBurst_Mid = new TdWeapon.AIBurstInfo
		{
			Length_Min = 3,
			Length_Max = 5,
			Pause_Min = 0.50f,
			Pause_Max = 1.0f,
		};
		AimedBurst_Far = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 3,
			Pause_Min = 1.0f,
			Pause_Max = 2.0f,
		};
		ReloadReadyTime = new TdWeapon.AIReloadInfo
		{
			Time_Min = 1.0f,
			Time_Max = 1.0f,
		};
		MinKeepFiringTime = 0.20f;
		MaxKeepFiringTime = 0.80f;
		CombatRange_Max_CHASE = 3000.0f;
		CombatRange_Preferred_CHASE = 2000.0f;
		MinKeepFiringTime_CHASE = 0.60f;
		MaxKeepFiringTime_CHASE = 1.20f;
		AimedBurst_Near_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 5,
			Length_Max = 6,
			Pause_Min = 0.50f,
			Pause_Max = 1.0f,
		};
		AimedBurst_Mid_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 3,
			Length_Max = 5,
			Pause_Min = 0.50f,
			Pause_Max = 1.0f,
		};
		AimedBurst_Far_CHASE = new TdWeapon.AIBurstInfo
		{
			Length_Min = 1,
			Length_Max = 3,
			Pause_Min = 1.0f,
			Pause_Max = 2.0f,
		};
		DefaultDecalMaterial = LoadAsset<DecalMaterial>("FX_ImpactEffects.Materials.M_FX_Decals_BulletImpacts_Generic_01")/*Ref DecalMaterial'FX_ImpactEffects.Materials.M_FX_Decals_BulletImpacts_Generic_01'*/;
		DefaultImpactMaterial = LoadAsset<PhysicalMaterial>("TDPhysicalMaterials.Concrete.PM_Concrete")/*Ref PhysicalMaterial'TDPhysicalMaterials.Concrete.PM_Concrete'*/;
		DecalStretchingMultiplier = 1.50f;
		DecalCullDistance = 1000.0f;
		RecoilAmount = 0.80f;
		RecoilRecoverTime = 0.10f;
		MaxRecoil = 6.0f;
		KickbackAmount = 20.0f;
		LOIparameter = (name)"LOI_Strength";
		FiringStatesArray = new array<name>
		{
			(name)"WeaponBursting",
		};
		WeaponFireTypes = new array<Weapon.EWeaponFireType>
		{
			#warning weird ass EWeaponFireType value replaced with default
			//154,
			default
		};
		FireInterval = new array<float>
		{
			0.1250f,
		};
		Spread = new array<float>
		{
			0.030f,
		};
		InstantHitDamage = new array<float>
		{
			4.0f,
		};
		InstantHitMomentum = new array<float>
		{
			20.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			ClassT<TdDmgType_LowCaliber_Bullet>(),
		};
		EquipTime = 0.30f;
		PutDownTime = 0.30f;
		WeaponRange = 12000.0f;
		Mesh = Default__TdWeapon_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.FirstPersonMesh'*/;
		PickupSound = LoadAsset<SoundCue>("A_WP_Default.Fire.Fire")/*Ref SoundCue'A_WP_Default.Fire.Fire'*/;
		DroppedPickupClass = ClassT<TdPickup>()/*Ref Class'TdPickup'*/;
		DroppedPickupMesh = Default__TdWeapon_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.ThirdPersonMesh'*/;
		PickupFactoryMesh = Default__TdWeapon_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.FirstPersonMesh'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeapon_FirstPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.FirstPersonMesh'*/,
			Default__TdWeapon_ThirdPersonMesh/*Ref TdSkeletalMeshComponent'Default__TdWeapon.ThirdPersonMesh'*/,
		};
	}
}
}