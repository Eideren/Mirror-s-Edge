namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Melee_BossCeleste : TdMove_PursuitMelee/*
		config(AIMeleeAttacks)*/{
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public TdMove_Melee_BossCeleste()
	{
		// Object Offset:0x005D098F
		JumpKickAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			Damage = 25.0f,
			AttackSpeed = 0.60f,
			RotationLimitAngle = 0.0f,
			PredictionWeight = 1.20f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"Dummy",
			},
		};
		RunAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			MissedAttackPenelty = 2.0f,
			Damage = 20.0f,
			AttackSpeed = 1.0f,
			RotationLimitAngle = 0.0f,
			PredictionTime = 0.10f,
			PredictionWeight = 1.20f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"Dummy",
			},
		};
		StandAttackPropertiesE = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 65.0f,
			HitRange = 100.0f,
			MissedAttackPenelty = 1.0f,
			Damage = 15.0f,
			AttackSpeed = 0.70f,
			PredictionTime = 0.150f,
			PredictionWeight = 0.80f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"Dummy",
			},
		};
		JumpKickAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			MissedAttackPenelty = 2.0f,
			Damage = 25.0f,
			AttackSpeed = 0.60f,
			PredictionWeight = 1.20f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"Dummy",
			},
		};
		RunAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			MissedAttackPenelty = 2.0f,
			Damage = 20.0f,
			AttackSpeed = 1.0f,
			PredictionTime = 0.10f,
			PredictionWeight = 1.20f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"Dummy",
			},
		};
		StandAttackPropertiesN = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 65.0f,
			HitRange = 100.0f,
			MissedAttackPenelty = 1.0f,
			Damage = 15.0f,
			AttackSpeed = 0.70f,
			PredictionTime = 0.150f,
			InvulnerableDamageTypes = new array</*config */name>
			{
				(name)"Dummy",
			},
		};
		JumpKickAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			MissedAttackPenelty = 1.0f,
			Damage = 35.0f,
			AttackSpeed = 0.70f,
			RotationLimitAngle = 0.0f,
			PredictionWeight = 1.0f,
		};
		RunAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			MissedAttackPenelty = 1.0f,
			Damage = 30.0f,
			AttackSpeed = 1.10f,
			RotationLimitAngle = 0.0f,
			PredictionTime = 0.10f,
			PredictionWeight = 1.0f,
		};
		StandAttackPropertiesH = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 65.0f,
			HitRange = 100.0f,
			MissedAttackPenelty = 0.80f,
			Damage = 25.0f,
			AttackSpeed = 0.80f,
			PredictionTime = 0.150f,
		};
	}
}
}