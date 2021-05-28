namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotPursuitFinishingAttack : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public/*()*/ /*config */TdMove_BotMelee.MeleeAttackProperties FinishingAttackProperties;
	
	public override /*simulated function */void TriggerMove()
	{
	
	}
	
	public override /*simulated event */void StopMove()
	{
	
	}
	
	public override /*simulated function */void TriggerMiss()
	{
	
	}
	
	public override /*simulated function */void TriggerHit()
	{
	
	}
	
	public override /*simulated function */void OnTimer()
	{
	
	}
	
	public override /*simulated function */bool TestHit()
	{
	
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