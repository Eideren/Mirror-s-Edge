namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Pursuit : TdAIController/*
		native
		config(AIMeleeAttacks)
		notplaceable
		hidecategories(Navigation)*/{
	public enum EPrepMoveType 
	{
		EPrepMove_Run,
		EPrepMove_Grenade,
		EPrepMove_Roll,
		EPrepMove_Flip,
		EPrepMove_NrOfPossiblePrepMoves,
		EPrepMove_None,
		EPrepMove_MAX
	};
	
	public enum EPursuitMeleeAttackType 
	{
		EMeleeAttack_JumpKick,
		EMeleeAttack_Sliding,
		EMeleeAttack_Standing,
		EMeleeAttack_Run,
		EMeleeAttack_Shove,
		EMeleeAttack_NrOfPossibleAttacks,
		EMeleeAttack_None,
		EMeleeAttack_MAX
	};
	
	public enum EMeleeSubState 
	{
		E_WantDistance,
		E_WantToAttack,
		E_PeneltyState,
		E_MAX
	};
	
	public partial struct /*native */AttackDistance
	{
		public/*()*/ float MaxMeleeAttackRange;
		public/*()*/ float MinMeleeAttackRange;
		public/*()*/ float MeleeAttackMoveDist;
		public/*()*/ float MinVelocity;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004D40FF
	//		MaxMeleeAttackRange = 0.0f;
	//		MinMeleeAttackRange = 0.0f;
	//		MeleeAttackMoveDist = 0.0f;
	//		MinVelocity = 0.0f;
	//	}
	};
	
	public partial struct /*native */SAttackDelays
	{
		public/*()*/ float Easy;
		public/*()*/ float Medium;
		public/*()*/ float Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004D422B
	//		Easy = 0.0f;
	//		Medium = 0.0f;
	//		Hard = 0.0f;
	//	}
	};
	
	public /*protected */TdAI_Pursuit.EMeleeSubState MeleeSubState;
	public TdAI_Pursuit.EPursuitMeleeAttackType PendingMeleeAttack;
	public /*protected */TdAI_Pursuit.EPrepMoveType PrepMoveType;
	public /*protected */TdAI_Pursuit.EPrepMoveType OldPrepMoveType;
	public/*(Melee)*/ TdAI_Pursuit.EPursuitMeleeAttackType DebugMeleeAttack;
	public/*(Melee)*/ TdAI_Pursuit.EPrepMoveType DebugPrepMove;
	public Object.Rotator tempRotator;
	public /*protected */float MinMeleeAttackRange;
	public /*protected */float MaxMeleeAttackRange;
	public /*protected */float MeleeAttackMoveDist;
	public /*protected */float MinVelocity;
	public /*private */int HealthLastTick;
	public /*private */int NrOfDodges;
	public /*private */float TimeOfLastMeleeAttack;
	public /*private */bool bIsDoingFinishingAttack;
	public /*private */bool bUpdateMelee;
	public /*private */float fAdvanceStartedTimeStamp;
	public /*private */float fPursuitStartedTimeStamp;
	public /*private */float WantDistanceTimeStamp;
	public /*private */float PeneltyTimeStamp;
	public /*protected */float PeneltyTime;
	public /*private */NavigationPoint TaserSpot;
	public /*private */float AquireTaserSpotTimeStamp;
	public /*private */NavigationPoint TempNavigationPoint;
	public /*private */float FirstTaserDelay;
	public /*private */float TaserBurstLength;
	public /*private */float BetweenTaserDelay;
	public/*(Melee)*/ /*config */TdAI_Pursuit.AttackDistance JumpKickAttackDistance;
	public/*(Melee)*/ /*config */TdAI_Pursuit.AttackDistance RunAttackDistance;
	public/*(Melee)*/ /*config */TdAI_Pursuit.AttackDistance StandAttackDistance;
	public/*(Melee)*/ /*config */TdAI_Pursuit.AttackDistance ShoveAttackDistance;
	public/*(Melee)*/ /*config */TdAI_Pursuit.AttackDistance SlideAttackDistance;
	public/*(Melee)*/ /*editinline */TdMove_PursuitMelee PursuitMeleeMove;
	public/*(Melee)*/ /*config */TdAI_Pursuit.SAttackDelays AttackDelays;
	
	public override /*function */void AddSpecialOutput(ref string Text)
	{
	
	}
	
	public virtual /*function */TdAI_Pursuit.EPursuitMeleeAttackType GetPendingMeleeAttack()
	{
	
		return default;
	}
	
	// Export UTdAI_Pursuit::execHasSpawned(FFrame&, void* const)
	public virtual /*native final function */bool HasSpawned()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override Possess_del Possess { get => bfield_Possess ?? TdAI_Pursuit_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public override Possess_del global_Possess => TdAI_Pursuit_Possess;
	public /*event */void TdAI_Pursuit_Possess(Pawn inPawn, bool bVehicleTransition)
	{
	
	}
	
	public override /*function */bool CanSearch()
	{
	
		return default;
	}
	
	public override /*function */bool CanInvestigate()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanSetGoal()
	{
	
		return default;
	}
	
	public override /*function */bool ShouldStopAfterMove()
	{
	
		return default;
	}
	
	public override /*function */TdAIController.EDisarmState QueryDisarmState(TdPawn Disarmer)
	{
	
		return default;
	}
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Pursuit_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Pursuit_TestCombatTransitions;
	public /*function */void TdAI_Pursuit_TestCombatTransitions()
	{
	
	}
	
	public override /*function */bool IsOkToUpdatePath()
	{
	
		return default;
	}
	
	public override /*function */void ReportNearMiss(float Distance)
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAI_Pursuit_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Pursuit_Tick;
	public /*event */void TdAI_Pursuit_Tick(float DeltaTime)
	{
	
	}
	
	public override NotifyDamage_del NotifyDamage { get => bfield_NotifyDamage ?? TdAI_Pursuit_NotifyDamage; set => bfield_NotifyDamage = value; } NotifyDamage_del bfield_NotifyDamage;
	public override NotifyDamage_del global_NotifyDamage => TdAI_Pursuit_NotifyDamage;
	public /*function */void TdAI_Pursuit_NotifyDamage(Controller InstigatedBy, Core.ClassT<DamageType> DamageType, int Damage)
	{
	
	}
	
	public virtual /*function */bool UseGetDistance()
	{
	
		return default;
	}
	
	public virtual /*function */void StartWalkingOrRunning()
	{
	
	}
	
	public virtual /*function */void StartRunning()
	{
	
	}
	
	public override /*function */void ForceNewPath()
	{
	
	}
	
	public override /*event */bool PreStopMove()
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyMoveStopped()
	{
	
	}
	
	public virtual /*function */void TaserStateChange()
	{
	
	}
	
	public virtual /*function */void CheckExitTaserState()
	{
	
	}
	
	public virtual /*function */bool ShouldEnterTaserState()
	{
	
		return default;
	}
	
	public override /*function */void NotifyPlayerReachable()
	{
	
	}
	
	public virtual /*function */void UpdatePlayerLookAtOffset()
	{
	
	}
	
	public virtual /*function */bool ShouldEnterAdvance()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldExitAdvance()
	{
	
		return default;
	}
	
	public override CheckCrouching_del CheckCrouching { get => bfield_CheckCrouching ?? TdAI_Pursuit_CheckCrouching; set => bfield_CheckCrouching = value; } CheckCrouching_del bfield_CheckCrouching;
	public override CheckCrouching_del global_CheckCrouching => TdAI_Pursuit_CheckCrouching;
	public /*function */void TdAI_Pursuit_CheckCrouching()
	{
	
	}
	
	public override /*function */void UpdateCombatDistances()
	{
	
	}
	
	public override /*function */bool ShouldBackaway()
	{
	
		return default;
	}
	
	public override /*function */bool ShouldMoveIn()
	{
	
		return default;
	}
	
	public override AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAI_Pursuit_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public override AllowFire_del global_AllowFire => TdAI_Pursuit_AllowFire;
	public /*event */bool TdAI_Pursuit_AllowFire()
	{
	
		return default;
	}
	
	public override /*function */bool IsOkToRun()
	{
	
		return default;
	}
	
	public override /*function */void TestAdvanceMovement()
	{
	
	}
	
	public override /*function */void BeginAdvance()
	{
	
	}
	
	public override /*function */void EndAdvance()
	{
	
	}
	
	public virtual /*function */bool ShouldEnterHold()
	{
	
		return default;
	}
	
	public override /*event */bool ThrowGrenadeRequest(TdGrenadeTargetArea TargetArea)
	{
	
		return default;
	}
	
	public override /*function */Object.Vector GetPredictedEnemyLocation()
	{
	
		return default;
	}
	
	public virtual /*function */Object.Vector GetPredictedEnemyLocationAfterDoingMeleeAttack(TdAI_Pursuit.EPursuitMeleeAttackType MeleeAttackType)
	{
	
		return default;
	}
	
	public virtual /*function */float GetAttackSpeedFactor(TdAI_Pursuit.EPursuitMeleeAttackType AttackType)
	{
	
		return default;
	}
	
	public override /*function */bool AskToCrouch()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsDoingFinishingAttack()
	{
	
		return default;
	}
	
	public virtual /*function */float GetAttackDelay()
	{
	
		return default;
	}
	
	public override ShouldEnterMelee_del ShouldEnterMelee { get => bfield_ShouldEnterMelee ?? TdAI_Pursuit_ShouldEnterMelee; set => bfield_ShouldEnterMelee = value; } ShouldEnterMelee_del bfield_ShouldEnterMelee;
	public override ShouldEnterMelee_del global_ShouldEnterMelee => TdAI_Pursuit_ShouldEnterMelee;
	public /*function */bool TdAI_Pursuit_ShouldEnterMelee(float Range)
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldExitMelee()
	{
	
		return default;
	}
	
	public virtual /*function */bool OkToMelee()
	{
	
		return default;
	}
	
	public virtual /*function */void GoTo_WantMeleeDistance()
	{
	
	}
	
	public virtual /*function */void GoTo_MeleePenelty()
	{
	
	}
	
	public virtual /*function */void GoTo_WantToMeleeAttack()
	{
	
	}
	
	public virtual /*function */void UpdateMeleeSubstate()
	{
	
	}
	
	public virtual /*function */void TestMelee()
	{
	
	}
	
	public virtual /*function */void TriggerMeleeMove()
	{
	
	}
	
	public virtual /*function */void ExitMelee(string S)
	{
	
	}
	
	public virtual /*function */void ShoveEnemy()
	{
	
	}
	
	public override NotifyPrepareForMeleeAttack_del NotifyPrepareForMeleeAttack { get => bfield_NotifyPrepareForMeleeAttack ?? TdAI_Pursuit_NotifyPrepareForMeleeAttack; set => bfield_NotifyPrepareForMeleeAttack = value; } NotifyPrepareForMeleeAttack_del bfield_NotifyPrepareForMeleeAttack;
	public override NotifyPrepareForMeleeAttack_del global_NotifyPrepareForMeleeAttack => TdAI_Pursuit_NotifyPrepareForMeleeAttack;
	public /*function */bool TdAI_Pursuit_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyFinishingMovePossible()
	{
	
	}
	
	public virtual /*function */float GetPredictedEnemyDistance(float Time)
	{
	
		return default;
	}
	
	public virtual /*function */void ReleaseMeleeLock()
	{
	
	}
	
	public virtual /*function */bool ShouldTaserOnInterruptedMelee()
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyAttackMiss(TdAI_Pursuit.EPursuitMeleeAttackType AttackType)
	{
	
	}
	
	public virtual /*protected function */void ChoosePrepAndAttackMove()
	{
	
	}
	
	public virtual /*protected function */void ChooseLongRangeAttackMove()
	{
	
	}
	
	public virtual /*protected function */void ChoosePointBlankAttackMove()
	{
	
	}
	
	public virtual /*protected function */void SetAttackMoveProperties()
	{
	
	}
	
	public virtual /*private final function */void PrepMoveTimerFunction()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Possess = null;
		TestCombatTransitions = null;
		Tick = null;
		NotifyDamage = null;
		CheckCrouching = null;
		AllowFire = null;
		ShouldEnterMelee = null;
		NotifyPrepareForMeleeAttack = null;
	
	}
	
	protected /*function */void TdAI_Pursuit_Pursuit_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Pursuit_Pursuit_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Pursuit()/*state Pursuit extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Pursuit_Taser_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Pursuit_Taser_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Taser()/*state Taser extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Advance()/*state Advance*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Pursuit_Hold_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Pursuit_Hold_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Hold()/*state Hold*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Pursuit_PursuitMelee_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Pursuit_PursuitMelee_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*event */void TdAI_Pursuit_PursuitMelee_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected /*function */void TdAI_Pursuit_PursuitMelee_UpdatePawnFocus()// state function
	{
	
	}
	
	protected /*function */bool TdAI_Pursuit_PursuitMelee_OkToDoStartMove()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PursuitMelee()/*state PursuitMelee*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Pursuit_MeleeInterrupted_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Pursuit_MeleeInterrupted_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) MeleeInterrupted()/*state MeleeInterrupted extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Pursuit": return Pursuit();
			case "Taser": return Taser();
			case "Advance": return Advance();
			case "Hold": return Hold();
			case "PursuitMelee": return PursuitMelee();
			case "MeleeInterrupted": return MeleeInterrupted();
			default: return base.FindState(stateName);
		}
	}
	public TdAI_Pursuit()
	{
		// Object Offset:0x004DA06E
		MeleeSubState = TdAI_Pursuit.EMeleeSubState.E_WantToAttack;
		DebugMeleeAttack = TdAI_Pursuit.EPursuitMeleeAttackType.EMeleeAttack_None;
		DebugPrepMove = TdAI_Pursuit.EPrepMoveType.EPrepMove_None;
		FirstTaserDelay = 2.50f;
		TaserBurstLength = 0.50f;
		BetweenTaserDelay = 1.50f;
		JumpKickAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 400.0f,
			MinMeleeAttackRange = 270.0f,
			MeleeAttackMoveDist = 500.0f,
			MinVelocity = 300.0f,
		};
		RunAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 451.0f,
			MinMeleeAttackRange = 350.0f,
			MeleeAttackMoveDist = 450.0f,
			MinVelocity = 0.0f,
		};
		StandAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 300.0f,
			MinMeleeAttackRange = 0.0f,
			MeleeAttackMoveDist = 0.0f,
			MinVelocity = 0.0f,
		};
		ShoveAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 150.0f,
			MinMeleeAttackRange = 0.0f,
			MeleeAttackMoveDist = 0.0f,
			MinVelocity = 0.0f,
		};
		SlideAttackDistance = new TdAI_Pursuit.AttackDistance
		{
			MaxMeleeAttackRange = 550.0f,
			MinMeleeAttackRange = 450.0f,
			MeleeAttackMoveDist = 580.0f,
			MinVelocity = 300.0f,
		};
		AttackDelays = new TdAI_Pursuit.SAttackDelays
		{
			Easy = 1.0f,
			Medium = 0.50f,
			Hard = 0.0f,
		};
		PathNetworkMask = 65535;
		MeleeState = (name)"PursuitMelee";
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAI_Pursuit.Sprite")/*Ref SpriteComponent'Default__TdAI_Pursuit.Sprite'*/,
		};
	}
}
}