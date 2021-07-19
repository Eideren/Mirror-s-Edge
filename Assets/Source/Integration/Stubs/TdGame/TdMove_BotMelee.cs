namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotMelee : TdPhysicsMove/*
		native
		config(AIMeleeAttacks)*/{
	public enum EMeleeStage 
	{
		EStage_FirstAnimation,
		EStage_SecondAnimation,
		EStage_MAX
	};
	
	public partial struct /*native */MeleeAttackProperties
	{
		[Category] public float HitAngle;
		[Category] public float HitRange;
		[Category] public float AttackHeightAdjustment;
		[Category] public float MissedAttackPenelty;
		[Category] public float Damage;
		[Category] public float AttackSpeed;
		[Category] public float RotationSpeed;
		[Category] public float RotationLimitAngle;
		[Category] public float HitDetectionStartTime;
		[Category] public float PredictionTime;
		[Category] public float PredictionWeight;
		[Category] [config] public array</*config */name> InvulnerableDamageTypes;
		[Category] public bool bIsInterruptableByDodge;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0059F6B8
	//		HitAngle = 0.0f;
	//		HitRange = 0.0f;
	//		AttackHeightAdjustment = 0.0f;
	//		MissedAttackPenelty = 0.0f;
	//		Damage = 0.0f;
	//		AttackSpeed = 0.0f;
	//		RotationSpeed = 0.0f;
	//		RotationLimitAngle = 0.0f;
	//		HitDetectionStartTime = 0.0f;
	//		PredictionTime = 0.0f;
	//		PredictionWeight = 0.0f;
	//		InvulnerableDamageTypes = default;
	//		bIsInterruptableByDodge = false;
	//	}
	};
	
	public/*protected*/ float BlendInTime;
	public/*protected*/ float BlendOutTime;
	public/*protected*/ name AnimationName;
	public/*private*/ Object.Vector PredictedEnemyLocation;
	public/*protected*/ TdMove_BotMelee.EMeleeStage MeleeStage;
	public/*protected*/ TdMove_BotMelee.MeleeAttackProperties AttackProperties;
	public/*private*/ float AnimationLength;
	public/*private*/ Object.Vector EnemyStartLocation;
	public/*private*/ Object.Rotator WantedRotation;
	public bool DrawDebug;
	[Category] [config] public TdMove_BotMelee.MeleeAttackProperties GenericAttackProperties;
	
	public virtual /*function */bool IsInterruptableByDodge()
	{
		// stub
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void OnTimer()
	{
		// stub
	}
	
	public virtual /*simulated function */void EnableLOI()
	{
		// stub
	}
	
	public virtual /*private final function */float GetAnimationLenght()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public override /*simulated function */void PostStopMove()
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public virtual /*event */void OnAfterFirstAnimation()
	{
		// stub
	}
	
	public override /*simulated function */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
		// stub
	}
	
	public virtual /*simulated function */void TriggerMove()
	{
		// stub
	}
	
	public virtual /*event */bool TestHit()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */void TriggerMiss()
	{
		// stub
	}
	
	public virtual /*event */void TriggerHit()
	{
		// stub
	}
	
	public virtual /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void TriggerHitPlayer()
	{
		// stub
	}
	
	public TdMove_BotMelee()
	{
		// Object Offset:0x005A0BAE
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 75.0f,
			HitRange = 150.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 20.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 360.0f,
			RotationLimitAngle = 180.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = -0.10f,
			PredictionWeight = 0.0f,
			InvulnerableDamageTypes = default,
			bIsInterruptableByDodge = false,
		};
		bEnableFootPlacement = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}