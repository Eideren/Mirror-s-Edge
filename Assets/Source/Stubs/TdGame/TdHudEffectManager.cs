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
	
	public /*private */TdHUD TheHUD;
	public /*private transient */float SpazzElapse;
	public /*private config */float SpazzThrottle;
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
	public /*config */bool bEnableHitEffect;
	public /*config */bool bEnableHitEffectPP;
	public /*config */bool bEnableHitEffectBlur;
	public /*config */bool bEnableHitEffectCameraShake;
	public /*config */bool bEnableHitEffectParticles;
	public /*config */bool bEnableFallDamageEffect;
	public /*config */bool bEnableSaturationEffect;
	public /*config */bool bEnableReactionTimeEffect;
	public /*transient */bool bReactionTimeActivated;
	public /*config */bool bEnableHealthEffect;
	public bool bFadeInDeathEffect;
	public /*config */bool bEnableDeathEffect;
	public /*config */bool bEnableStreakEffect;
	public /*config */bool bEnableUncontrolledFallingEffect;
	public /*transient */bool bForceUncontrolledFall;
	public /*config */bool bEnableUIPostProcessing;
	public /*private transient */bool UIBlurDemo;
	public /*config */bool bDebugBlur;
	public /*config */bool bDebugHealth;
	public /*config */bool bDebugParticles;
	public /*config */bool bDebugTaserDamage;
	public /*config */bool bDebugStunDamage;
	public /*config */bool bDebugReactionTime;
	public /*config */bool bDebugUncontrolledFallingEffect;
	public TdHudEffect_Bullet BulletHitEffect;
	public TdHudEffect_Taser TaserHitEffect;
	public TdHudEffect_ElectricShock ElectricShockHitEffect;
	public TdHudEffect_Melee MeleeHitEffect;
	public TdHudEffect_FallDamage FallDamageEffect;
	public TdHudEffect_ExplosionDamage ExplosionDamageEffect;
	public TdHudEffect_Saturation SaturationEffect;
	public/*()*/ /*editinline */TdHudEffect_Flashbang FlashbangEffect;
	public TdHudEffect_ReactionTime ReactionTimeEffect;
	public /*transient */array<TdHudEffect> HudImpactEffects;
	public /*transient */StaticArray<TdHudEffectManager.DirectionalParticleSystemSlot, TdHudEffectManager.DirectionalParticleSystemSlot, TdHudEffectManager.DirectionalParticleSystemSlot, TdHudEffectManager.DirectionalParticleSystemSlot>/*[4]*/ DirectionalParticleSystemSlots;
	public /*transient */int HitEmitterPointer;
	public /*transient */float HitEffectBlurTimer;
	public /*transient */float HitEffectBlurFadeInTimer;
	public /*transient */float HitEffectBlurFadeInDuration;
	public /*transient */float HitEffectBlurFadeInStart;
	public /*transient */float HitEffectBlurFadeOutTimer;
	public /*transient */float HitEffectBlurFadeOutDuration;
	public /*transient */float HitEffectFocusDistance;
	public /*transient */float HitEffectFocusDistanceStart;
	public /*transient */float HitEffectMaxFarBlurAmount;
	public /*transient */MaterialInstanceConstant HealthEffectMaterialInstance;
	public MaterialEffect HealthEffect;
	public /*config */TdHudEffect.PPSettings PPHealthSaturationSettings;
	public /*transient */float PPHSSFadeInTimer;
	public /*transient */float PPHSSFadeInStart;
	public /*transient */float PPHSSPeakDurationTimer;
	public /*transient */float PPHSSFadeOutTimer;
	public /*transient */float PPHSSTargetStrength;
	public /*transient */float PPHSSCurrentStrength;
	public MaterialEffect DeathEffect;
	public /*transient */MaterialInstanceConstant DeathEffectMaterialInstance;
	public /*config */float DeathEffectSpeed;
	public ParticleSystem StreakEffectParticles;
	public /*config */float StreakDistanceInMovementDirection;
	public /*config */float StreakDistanceInCameraDirection;
	public /*config */float StreakEffectFadeTime;
	public float StreakEffectMaxSpeed;
	public /*transient */Emitter StreakEffectEmitter;
	public /*transient */float StreakEffectStrength;
	public /*transient */Object.Vector StreakEffectDirection;
	public /*config */float UncontrolledFallingSpeedLimit;
	public /*config */float UncontrolledFallingEffectSpeed;
	public /*config */float UncontrolledFallingEffectClamp;
	public /*config */Object.Vector UncontrolledFallingEmitterOffset;
	public ParticleSystem UncontrolledFallingParticles;
	public /*transient */MaterialInstanceConstant UncontrolledFallingMaterialInstance;
	public MaterialEffect UncontrolledFallingEffect;
	public /*transient */TdEmitter UncontrolledFallingEffectEmitter;
	public /*transient */float UncontrolledFallingEffectFader;
	public /*transient */Object.Vector ForcedUncontrolledFallVelocity;
	public/*()*/ /*config */float ZoomMaxFarBlurAmount;
	public/*()*/ /*config */float ZoomMaxNearBlurAmount;
	public/*()*/ /*config */float ZoomAutofocusSpeedUp;
	public/*()*/ /*config */float ZoomAutofocusSpeedDown;
	public/*()*/ /*config */float ZoomAutofocusMaxDistance;
	public /*private transient */float SavedMaxFarBlurAmount;
	public /*private transient */float SavedMaxNearBlurAmount;
	public /*private transient */float SavedAutofocusSpeedUp;
	public /*private transient */float SavedAutofocusSpeedDown;
	public /*private transient */float SavedAutofocusMaxDistance;
	public /*private transient */Object.Vector CamLoc;
	public /*private transient */Object.Rotator CamRot;
	public TdUIBlurEffect UIBlurPP_UI;
	public /*private transient */float UIBlurTimer;
	public /*private transient */float UIBlurInSpeed;
	public /*private transient */float UIBlurOutSpeed;
	public TdPlayerPawn ThePlayerPawn;
	
	// Export UTdHudEffectManager::execDisplayHit(FFrame&, void* const)
	public virtual /*native final function */void DisplayHit(Object.Vector HitDir, int Damage, TdHUD.EDamageType DamageType)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdHudEffectManager::execGetRelativeHitPos(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetRelativeHitPos(Object.Vector Offset, Object.Rotator CameraRotation, float Direction)
	{
		 // #warning NATIVE FUNCTION !
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