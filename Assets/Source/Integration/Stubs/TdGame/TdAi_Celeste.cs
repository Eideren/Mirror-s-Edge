namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAi_Celeste : TdAI_Pursuit/*
		native
		config(AIMeleeAttacks)
		notplaceable
		hidecategories(Navigation)*/{
	public enum ECelesteStage 
	{
		EC_Stage1,
		EC_Stage2,
		EC_MAX
	};
	
	public int RecentHitsTaken;
	public /*private */bool bAfterDisarm;
	public bool bIsVulnerableToDisarm;
	public /*private */bool bRestrictFire;
	public /*private */Core.ClassT<DamageType> LastTakenDamageType;
	public /*private */TdPathLimits OtherPlatformPathLimit;
	public /*private */TdAi_Celeste.ECelesteStage bStageInFight;
	public int bMeleeHitCount;
	public /*private */float RestrictFireTimestamp;
	
	public override /*function */void AddSpecialOutput(ref String Text)
	{
		// stub
	}
	
	public override AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAi_Celeste_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public override AllowFire_del global_AllowFire => TdAi_Celeste_AllowFire;
	public /*event */bool TdAi_Celeste_AllowFire()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsGapBetweenMeAndEnemyAprox()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdAi_Celeste.ECelesteStage GetCelesteBossFightStage()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdAI_Pursuit.EPursuitMeleeAttackType GetPendingCelesteMeleeAttack()
	{
		// stub
		return default;
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*event */bool NotifyBump(Actor Other, Object.Vector HitNormal)
	{
		// stub
		return default;
	}
	
	public override /*function */bool ShouldEnterHold()
	{
		// stub
		return default;
	}
	
	public override /*function */bool ShouldTaserOnInterruptedMelee()
	{
		// stub
		return default;
	}
	
	public override /*function */bool UseGetDistance()
	{
		// stub
		return default;
	}
	
	public override ShouldEnterMelee_del ShouldEnterMelee { get => bfield_ShouldEnterMelee ?? TdAi_Celeste_ShouldEnterMelee; set => bfield_ShouldEnterMelee = value; } ShouldEnterMelee_del bfield_ShouldEnterMelee;
	public override ShouldEnterMelee_del global_ShouldEnterMelee => TdAi_Celeste_ShouldEnterMelee;
	public /*function */bool TdAi_Celeste_ShouldEnterMelee(float Range)
	{
		// stub
		return default;
	}
	
	public override /*function */TdAIController.EDisarmState QueryDisarmState(TdPawn Disarmer)
	{
		// stub
		return default;
	}
	
	public override /*function */bool OkToMoveDirectlyToPoint()
	{
		// stub
		return default;
	}
	
	public override NotifyPrepareForMeleeAttack_del NotifyPrepareForMeleeAttack { get => bfield_NotifyPrepareForMeleeAttack ?? TdAi_Celeste_NotifyPrepareForMeleeAttack; set => bfield_NotifyPrepareForMeleeAttack = value; } NotifyPrepareForMeleeAttack_del bfield_NotifyPrepareForMeleeAttack;
	public override NotifyPrepareForMeleeAttack_del global_NotifyPrepareForMeleeAttack => TdAi_Celeste_NotifyPrepareForMeleeAttack;
	public /*function */bool TdAi_Celeste_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void NotifyDisarmed()
	{
		// stub
	}
	
	public virtual /*function */void RemovePlayerStuckOnGround()
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public override NotifyDamage_del NotifyDamage { get => bfield_NotifyDamage ?? TdAi_Celeste_NotifyDamage; set => bfield_NotifyDamage = value; } NotifyDamage_del bfield_NotifyDamage;
	public override NotifyDamage_del global_NotifyDamage => TdAi_Celeste_NotifyDamage;
	public /*function */void TdAi_Celeste_NotifyDamage(Controller InstigatedBy, Core.ClassT<DamageType> DamageType, int Damage)
	{
		// stub
	}
	
	public virtual /*function */void ClearRecentHitsTaken()
	{
		// stub
	}
	
	public override /*function */void NotifyAttackMiss(TdAI_Pursuit.EPursuitMeleeAttackType AttackType)
	{
		// stub
	}
	
	public override /*protected function */void ChooseLongRangeAttackMove()
	{
		// stub
	}
	
	public override /*protected function */void ChoosePrepAndAttackMove()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		AllowFire = null;
		ShouldEnterMelee = null;
		NotifyPrepareForMeleeAttack = null;
		NotifyDamage = null;
	
	}
	
	protected /*function */void TdAi_Celeste_Taser_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Taser()/*state Taser*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Taser": return Taser();
			default: return base.FindState(stateName);
		}
	}
	public TdAi_Celeste()
	{
		var Default__TdAi_Celeste_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAi_Celeste.Sprite' */;
		// Object Offset:0x004DBDF5
		FirstTaserDelay = 0.50f;
		TaserBurstLength = 1.0f;
		BetweenTaserDelay = 0.0f;
		JumpKickAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 401.0f,
		};
		RunAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 550.0f,
			MinMeleeAttackRange = 400.0f,
			MeleeAttackMoveDist = 770.0f,
			MinVelocity = 300.0f,
		};
		StandAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 271.0f,
		};
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAi_Celeste_Sprite/*Ref SpriteComponent'Default__TdAi_Celeste.Sprite'*/,
		};
	}
}
}