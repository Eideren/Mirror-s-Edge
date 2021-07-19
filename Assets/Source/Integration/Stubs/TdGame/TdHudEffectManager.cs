namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffectManager : Object/* within TdHUD*//*
		native
		config(HudEffects)*/{
	public partial struct /*native */DirectionalParticleSystemSlot
	{
		public float Direction;
		public TdEmitter EffectEmitter;
		public Object.Vector EmitterOrigin;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005710C1
	//		Direction = 0.0f;
	//		EffectEmitter = default;
	//		EmitterOrigin = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public new TdHUD Outer => base.Outer as TdHUD;
	
	public/*private*/ TdHUD TheHUD;
	[transient] public/*private*/ float SpazzElapse;
	[config] public/*private*/ float SpazzThrottle;
	public Object.Vector SunLocation;
	public float LastSunScale;
	public float NextSunScale;
	public float LastSunScaleTime;
	public float SunScaleTime;
	public TdDirectionalHazePostProcess SunHazePP;
	public float AverageFocusDistance;
	public DOFAndBloomEffect DOFAndBloomPP;
	public TdToneMappingPostProcess ToneMappingPP;
	public TdMotionBlurPostProcess MotionBlur;
	[config] public bool bEnableHitEffect;
	[config] public bool bEnableHitEffectPP;
	[config] public bool bEnableHitEffectBlur;
	[config] public bool bEnableHitEffectCameraShake;
	[config] public bool bEnableHitEffectParticles;
	[config] public bool bEnableFallDamageEffect;
	[config] public bool bEnableSaturationEffect;
	[config] public bool bEnableReactionTimeEffect;
	[transient] public bool bReactionTimeActivated;
	[config] public bool bEnableHealthEffect;
	public bool bFadeInDeathEffect;
	[config] public bool bEnableDeathEffect;
	[config] public bool bEnableStreakEffect;
	[config] public bool bEnableUncontrolledFallingEffect;
	[transient] public bool bForceUncontrolledFall;
	[config] public bool bEnableUIPostProcessing;
	[transient] public/*private*/ bool UIBlurDemo;
	[config] public bool bDebugBlur;
	[config] public bool bDebugHealth;
	[config] public bool bDebugParticles;
	[config] public bool bDebugTaserDamage;
	[config] public bool bDebugStunDamage;
	[config] public bool bDebugReactionTime;
	[config] public bool bDebugUncontrolledFallingEffect;
	public TdHudEffect_Bullet BulletHitEffect;
	public TdHudEffect_Taser TaserHitEffect;
	public TdHudEffect_ElectricShock ElectricShockHitEffect;
	public TdHudEffect_Melee MeleeHitEffect;
	public TdHudEffect_FallDamage FallDamageEffect;
	public TdHudEffect_ExplosionDamage ExplosionDamageEffect;
	public TdHudEffect_Saturation SaturationEffect;
	[Category] [editinline] public TdHudEffect_Flashbang FlashbangEffect;
	public TdHudEffect_ReactionTime ReactionTimeEffect;
	[transient] public array<TdHudEffect> HudImpactEffects;
	[transient] public StaticArray<TdHudEffectManager.DirectionalParticleSystemSlot, TdHudEffectManager.DirectionalParticleSystemSlot, TdHudEffectManager.DirectionalParticleSystemSlot, TdHudEffectManager.DirectionalParticleSystemSlot>/*[4]*/ DirectionalParticleSystemSlots;
	[transient] public int HitEmitterPointer;
	[transient] public float HitEffectBlurTimer;
	[transient] public float HitEffectBlurFadeInTimer;
	[transient] public float HitEffectBlurFadeInDuration;
	[transient] public float HitEffectBlurFadeInStart;
	[transient] public float HitEffectBlurFadeOutTimer;
	[transient] public float HitEffectBlurFadeOutDuration;
	[transient] public float HitEffectFocusDistance;
	[transient] public float HitEffectFocusDistanceStart;
	[transient] public float HitEffectMaxFarBlurAmount;
	[transient] public MaterialInstanceConstant HealthEffectMaterialInstance;
	public MaterialEffect HealthEffect;
	[config] public TdHudEffect.PPSettings PPHealthSaturationSettings;
	[transient] public float PPHSSFadeInTimer;
	[transient] public float PPHSSFadeInStart;
	[transient] public float PPHSSPeakDurationTimer;
	[transient] public float PPHSSFadeOutTimer;
	[transient] public float PPHSSTargetStrength;
	[transient] public float PPHSSCurrentStrength;
	public MaterialEffect DeathEffect;
	[transient] public MaterialInstanceConstant DeathEffectMaterialInstance;
	[config] public float DeathEffectSpeed;
	public ParticleSystem StreakEffectParticles;
	[config] public float StreakDistanceInMovementDirection;
	[config] public float StreakDistanceInCameraDirection;
	[config] public float StreakEffectFadeTime;
	public float StreakEffectMaxSpeed;
	[transient] public Emitter StreakEffectEmitter;
	[transient] public float StreakEffectStrength;
	[transient] public Object.Vector StreakEffectDirection;
	[config] public float UncontrolledFallingSpeedLimit;
	[config] public float UncontrolledFallingEffectSpeed;
	[config] public float UncontrolledFallingEffectClamp;
	[config] public Object.Vector UncontrolledFallingEmitterOffset;
	public ParticleSystem UncontrolledFallingParticles;
	[transient] public MaterialInstanceConstant UncontrolledFallingMaterialInstance;
	public MaterialEffect UncontrolledFallingEffect;
	[transient] public TdEmitter UncontrolledFallingEffectEmitter;
	[transient] public float UncontrolledFallingEffectFader;
	[transient] public Object.Vector ForcedUncontrolledFallVelocity;
	[Category] [config] public float ZoomMaxFarBlurAmount;
	[Category] [config] public float ZoomMaxNearBlurAmount;
	[Category] [config] public float ZoomAutofocusSpeedUp;
	[Category] [config] public float ZoomAutofocusSpeedDown;
	[Category] [config] public float ZoomAutofocusMaxDistance;
	[transient] public/*private*/ float SavedMaxFarBlurAmount;
	[transient] public/*private*/ float SavedMaxNearBlurAmount;
	[transient] public/*private*/ float SavedAutofocusSpeedUp;
	[transient] public/*private*/ float SavedAutofocusSpeedDown;
	[transient] public/*private*/ float SavedAutofocusMaxDistance;
	[transient] public/*private*/ Object.Vector CamLoc;
	[transient] public/*private*/ Object.Rotator CamRot;
	public TdUIBlurEffect UIBlurPP_UI;
	[transient] public/*private*/ float UIBlurTimer;
	[transient] public/*private*/ float UIBlurInSpeed;
	[transient] public/*private*/ float UIBlurOutSpeed;
	public TdPlayerPawn ThePlayerPawn;
	
	// Export UTdHudEffectManager::execDisplayHit(FFrame&, void* const)
	public virtual /*native final function */void DisplayHit(Object.Vector HitDir, int Damage, TdHUD.EDamageType DamageType)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdHudEffectManager::execGetRelativeHitPos(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetRelativeHitPos(Object.Vector Offset, Object.Rotator CameraRotation, float Direction)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */void FadeOutHelper(float Time, Object.LinearColor FadeColor, /*optional */bool? _bRealTime = default)
	{
		// stub
	}
	
	public virtual /*function */void StartUp()
	{
		// stub
	}
	
	public virtual /*function */void InitUIPostProcess()
	{
		// stub
	}
	
	public virtual /*function */void ToggleUIPostProcess()
	{
		// stub
	}
	
	public virtual /*function */void BlurInUI(float FadeInTime)
	{
		// stub
	}
	
	public virtual /*function */void BlurOutUI(float FadeOutTime)
	{
		// stub
	}
	
	public virtual /*function */void SetUIBlur(float T)
	{
		// stub
	}
	
	public virtual /*function */void SetUIBlurEnabled(bool bEnabled)
	{
		// stub
	}
	
	public virtual /*final function */void Update(float DeltaTime, float RenderDelta)
	{
		// stub
	}
	
	public virtual /*function */void UpdateUncontrolledFalling(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */bool IsPlayerInUncontrolledSpeed(ref Object.Vector FallingVelocity)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ResetParticles()
	{
		// stub
	}
	
	public virtual /*function */void ResetPPEffects()
	{
		// stub
	}
	
	public virtual /*function */void UpdateStreakEffect(float Delta)
	{
		// stub
	}
	
	public virtual /*function */void ResetHealthEffect()
	{
		// stub
	}
	
	public virtual /*function */void ResetScopeEffect()
	{
		// stub
	}
	
	public virtual /*function */void DisplayDeath()
	{
		// stub
	}
	
	public virtual /*function */void UnDisplayDeath()
	{
		// stub
	}
	
	public virtual /*function */void UpdateDOF(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void UpdateBlur_UI(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void ActivateZoomInDOF()
	{
		// stub
	}
	
	public virtual /*function */void ActivateSaturationEffect()
	{
		// stub
	}
	
	public virtual /*function */void DeActivateSaturationEffect()
	{
		// stub
	}
	
	public virtual /*function */void DeActivateZoomInDOF()
	{
		// stub
	}
	
	public virtual /*function */void InitSavedDOFValues()
	{
		// stub
	}
	
	public virtual /*function */void ActivateReactionTimeTeaser()
	{
		// stub
	}
	
	public virtual /*function */void ActivateForcedMotionBlur(Object.Vector Direction, float Amount)
	{
		// stub
	}
	
	public virtual /*function */void DeActivateForcedMotionBlur()
	{
		// stub
	}
	
	public virtual /*function */void ResetMotionBlurEffects()
	{
		// stub
	}
	
	public virtual /*function */void ActivateForcedUncontrolledFall(Object.Vector Direction)
	{
		// stub
	}
	
	public virtual /*function */void DeActivateForcedUncontrolledFall()
	{
		// stub
	}
	
	public virtual /*function */void TogglePostProcessEffects(bool bEnable)
	{
		// stub
	}
	
	public TdHudEffectManager()
	{
		// Object Offset:0x005756C5
		SpazzThrottle = 0.20f;
		SunScaleTime = 0.250f;
		bEnableHitEffect = true;
		bEnableHitEffectPP = true;
		bEnableHitEffectBlur = true;
		bEnableHitEffectCameraShake = true;
		bEnableHitEffectParticles = true;
		bEnableFallDamageEffect = true;
		bEnableSaturationEffect = true;
		bEnableReactionTimeEffect = true;
		bEnableHealthEffect = true;
		bEnableDeathEffect = true;
		bEnableStreakEffect = true;
		bEnableUncontrolledFallingEffect = true;
		PPHealthSaturationSettings = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_HealthDesaturate",
			FadeInDuration = 0.060f,
			Duration = 0.50f,
			FadeOutDuration = 0.50f,
		};
		DeathEffectSpeed = 0.250f;
		StreakEffectParticles = LoadAsset<TdParticleSystem>("FX_FirstPEffects.Effects.PS_FX_Blur_SprintStreaks_01")/*Ref TdParticleSystem'FX_FirstPEffects.Effects.PS_FX_Blur_SprintStreaks_01'*/;
		StreakDistanceInMovementDirection = 120.0f;
		StreakDistanceInCameraDirection = 120.0f;
		StreakEffectFadeTime = 0.340f;
		StreakEffectMaxSpeed = 730.0f;
		UncontrolledFallingSpeedLimit = 2000.0f;
		UncontrolledFallingEffectSpeed = 0.50f;
		UncontrolledFallingEffectClamp = 0.990f;
		UncontrolledFallingEmitterOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-200.0f
		};
		UncontrolledFallingParticles = LoadAsset<TdParticleSystem>("FX_FirstPEffects.Effects.PS_FX_FullScreenFX_DeathFalling_01")/*Ref TdParticleSystem'FX_FirstPEffects.Effects.PS_FX_FullScreenFX_DeathFalling_01'*/;
		ZoomMaxFarBlurAmount = 0.90f;
		ZoomMaxNearBlurAmount = 0.60f;
		ZoomAutofocusSpeedUp = 3.0f;
		ZoomAutofocusSpeedDown = 4.50f;
		ZoomAutofocusMaxDistance = 20000.0f;
		SavedAutofocusSpeedUp = 0.50f;
		SavedAutofocusSpeedDown = 6.0f;
		SavedAutofocusMaxDistance = 150.0f;
	}
}
}