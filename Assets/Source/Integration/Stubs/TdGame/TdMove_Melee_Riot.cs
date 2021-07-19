namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Melee_Riot : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public/*private*/ bool bHit;
	[Category] [config] public TdMove_BotMelee.MeleeAttackProperties ShieldPushProperties;
	
	public override /*simulated function */void TriggerMove()
	{
		// stub
	}
	
	public override /*simulated function */void TriggerHit()
	{
		// stub
	}
	
	public override /*simulated function */void TriggerMiss()
	{
		// stub
	}
	
	public TdMove_Melee_Riot()
	{
		// Object Offset:0x005D15D7
		ShieldPushProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 180.0f,
			HitRange = 100.0f,
			AttackHeightAdjustment = 0.0f,
			MissedAttackPenelty = 0.0f,
			Damage = 50.0f,
			AttackSpeed = 1.0f,
			RotationSpeed = 0.0f,
			RotationLimitAngle = 180.0f,
			HitDetectionStartTime = 0.250f,
			PredictionTime = -0.10f,
			PredictionWeight = 0.0f,
			InvulnerableDamageTypes = default,
			bIsInterruptableByDodge = false,
		};
	}
}
}