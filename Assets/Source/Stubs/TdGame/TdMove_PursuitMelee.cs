namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_PursuitMelee : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties JumpKickAttackPropertiesE;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties RunAttackPropertiesE;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties StandAttackPropertiesE;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties SlideAttackPropertiesE;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties ShoveAttackPropertiesE;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties JumpKickAttackPropertiesN;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties RunAttackPropertiesN;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties StandAttackPropertiesN;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties SlideAttackPropertiesN;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties ShoveAttackPropertiesN;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties JumpKickAttackPropertiesH;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties RunAttackPropertiesH;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties StandAttackPropertiesH;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties SlideAttackPropertiesH;
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties ShoveAttackPropertiesH;
	public /*protected */bool bAttackDidHit;
	public TdAI_Pursuit.EPursuitMeleeAttackType AttackType;
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated event */void StopMove()
	{
	
	}
	
	public override /*function */bool IsInterruptableByDodge()
	{
	
		return default;
	}
	
	public override /*simulated function */void TriggerMove()
	{
	
	}
	
	public virtual /*simulated function */TdMove_BotMelee.MeleeAttackProperties GetAttackProperties(TdAI_Pursuit.EPursuitMeleeAttackType Attack)
	{
	
		return default;
	}
	
	public override /*simulated function */void TriggerHit()
	{
	
	}
	
	public override /*simulated function */void TriggerMiss()
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*simulated function */void StopMissAnimation()
	{
	
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
	
		return default;
	}
	
	public override /*simulated function */void EnableLOI()
	{
	
	}
	
	public TdMove_PursuitMelee()
	{
		// Object Offset:0x005CEFA2
		JumpKickAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 40.0f,
			HitRange = 170.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 2.0f,
			Damage = 50.0f,
			AttackSpeed = 0.950f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 120.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		RunAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 90.0f,
			HitRange = 120.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 2.20f,
			Damage = 35.0f,
			AttackSpeed = 0.50f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 80.0f,
			HitDetectionStartTime = 0.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = default,
			bIsInterruptableByDodge = false,
		};
		StandAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 100.0f,
			HitRange = 120.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 35.0f,
			AttackSpeed = 0.950f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 180.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = default,
			bIsInterruptableByDodge = false,
		};
		SlideAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 120.0f,
			HitRange = 200.0f,
			AttackHeightAdjustment = -70.0f,
			MissedAttackPenelty = 1.50f,
			Damage = 35.0f,
			AttackSpeed = 0.950f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 80.0f,
			HitDetectionStartTime = 0.50f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		ShoveAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 65.0f,
			HitRange = 140.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 15.0f,
			AttackSpeed = 0.950f,
			RotationSpeed = 360.0f,
			RotationLimitAngle = 360.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = -1.0f,
			PredictionWeight = 0.0f,
			InvulnerableDamageTypes = default,
			bIsInterruptableByDodge = false,
		};
		JumpKickAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 40.0f,
			HitRange = 170.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 1.50f,
			Damage = 50.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 0.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		RunAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 90.0f,
			HitRange = 120.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 1.70f,
			Damage = 35.0f,
			AttackSpeed = 0.550f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 0.0f,
			HitDetectionStartTime = 0.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		StandAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 100.0f,
			HitRange = 120.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 35.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 180.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 0.80f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"MeleePunsh",
			},
			bIsInterruptableByDodge = false,
		};
		SlideAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 120.0f,
			HitRange = 200.0f,
			AttackHeightAdjustment = -70.0f,
			MissedAttackPenelty = 1.0f,
			Damage = 35.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 0.0f,
			HitDetectionStartTime = 0.50f,
			PredictionTime = 0.30f,
			PredictionWeight = 1.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		ShoveAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 65.0f,
			HitRange = 140.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 15.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 360.0f,
			RotationLimitAngle = 360.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = -1.0f,
			PredictionWeight = 0.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		JumpKickAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 40.0f,
			HitRange = 170.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.550f,
			Damage = 50.0f,
			AttackSpeed = 1.20f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 120.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 0.80f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		RunAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 90.0f,
			HitRange = 120.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.650f,
			Damage = 35.0f,
			AttackSpeed = 0.60f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 80.0f,
			HitDetectionStartTime = 0.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 0.80f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		StandAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 100.0f,
			HitRange = 120.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.350f,
			Damage = 35.0f,
			AttackSpeed = 1.20f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 180.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.30f,
			PredictionWeight = 0.80f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"MeleePunsh",
			},
			bIsInterruptableByDodge = true,
		};
		SlideAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 120.0f,
			HitRange = 200.0f,
			AttackHeightAdjustment = -70.0f,
			MissedAttackPenelty = 0.650f,
			Damage = 35.0f,
			AttackSpeed = 1.20f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 80.0f,
			HitDetectionStartTime = 0.50f,
			PredictionTime = 0.30f,
			PredictionWeight = 0.80f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = false,
		};
		ShoveAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 65.0f,
			HitRange = 140.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.350f,
			Damage = 15.0f,
			AttackSpeed = 1.10f,
			RotationSpeed = 360.0f,
			RotationLimitAngle = 360.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = -1.0f,
			PredictionWeight = 0.0f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"AllMelee",
			},
			bIsInterruptableByDodge = true,
		};
		bEnableFootPlacement = false;
	}
}
}