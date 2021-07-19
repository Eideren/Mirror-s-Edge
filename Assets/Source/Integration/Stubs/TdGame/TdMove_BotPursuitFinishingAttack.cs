namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotPursuitFinishingAttack : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	[Category] [config] public TdMove_BotMelee.MeleeAttackProperties FinishingAttackProperties;
	
	public override /*simulated function */void TriggerMove()
	{
		// stub
	}
	
	public override /*simulated event */void StopMove()
	{
		// stub
	}
	
	public override /*simulated function */void TriggerMiss()
	{
		// stub
	}
	
	public override /*simulated function */void TriggerHit()
	{
		// stub
	}
	
	public override /*simulated function */void OnTimer()
	{
		// stub
	}
	
	public override /*simulated function */bool TestHit()
	{
		// stub
		return default;
	}
	
	public TdMove_BotPursuitFinishingAttack()
	{
		// Object Offset:0x005A4B2B
		FinishingAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 0.0f,
			HitRange = 0.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 700.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 0.0f,
			HitDetectionStartTime = -1.0f,
			PredictionTime = 0.0f,
			PredictionWeight = 0.0f,
			InvulnerableDamageTypes = default,
			bIsInterruptableByDodge = false,
		};
		bEnableFootPlacement = false;
	}
}
}