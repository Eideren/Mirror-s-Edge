namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Tutorial : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	[transient] public TdTutorialListener TutorialListener;
	[transient] public bool bAttackInitiated;
	[transient] public bool bHasEmittedPreAttackEvent;
	[transient] public bool bHasEmittedPostAttackEvent;
	[transient] public int DisarmEventIdentifier;
	
	// Export UTdAI_Tutorial::execUpdateAnchor(FFrame&, void* const)
	public override /*native function */void UpdateAnchor()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*event */void Initialize()
	{
		// stub
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdAI_Tutorial_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Tutorial_Tick;
	public /*event */void TdAI_Tutorial_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */bool CanAttack()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ShouldBlockAttack(Core.ClassT<DamageType> AttackType)
	{
		// stub
		return default;
	}
	
	public override NotifyPrepareForMeleeAttack_del NotifyPrepareForMeleeAttack { get => bfield_NotifyPrepareForMeleeAttack ?? TdAI_Tutorial_NotifyPrepareForMeleeAttack; set => bfield_NotifyPrepareForMeleeAttack = value; } NotifyPrepareForMeleeAttack_del bfield_NotifyPrepareForMeleeAttack;
	public override NotifyPrepareForMeleeAttack_del global_NotifyPrepareForMeleeAttack => TdAI_Tutorial_NotifyPrepareForMeleeAttack;
	public /*function */bool TdAI_Tutorial_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
		// stub
		return default;
	}
	
	public override NotifyDamage_del NotifyDamage { get => bfield_NotifyDamage ?? TdAI_Tutorial_NotifyDamage; set => bfield_NotifyDamage = value; } NotifyDamage_del bfield_NotifyDamage;
	public override NotifyDamage_del global_NotifyDamage => TdAI_Tutorial_NotifyDamage;
	public /*function */void TdAI_Tutorial_NotifyDamage(Controller ControllerInstigator, Core.ClassT<DamageType> DamageType, int Damage)
	{
		// stub
	}
	
	public override /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
		// stub
		return default;
	}
	
	public override /*function */void NotifyMeleeFinished()
	{
		// stub
	}
	
	public override /*function */void OnDisarmed()
	{
		// stub
	}
	
	public override /*function */void TriggerCannedAnim(int Move, name AnimationName)
	{
		// stub
	}
	
	public virtual /*function */void EmitFailedEvent()
	{
		// stub
	}
	
	public virtual /*function */void EmitMeleeAttackSucceededEvent()
	{
		// stub
	}
	
	public virtual /*function */void EmitPreAttackEvent()
	{
		// stub
	}
	
	public virtual /*function */void EmitPostAttackEvent()
	{
		// stub
	}
	
	public virtual /*function */void EmitDisarmSucceededEvent()
	{
		// stub
	}
	
	public virtual /*function */void EmitWeaponDroppedEvent()
	{
		// stub
	}
	
	public virtual /*function */void OnTdAiInitiateAttack(SeqAct_TdAiInitiateAttack Action)
	{
		// stub
	}
	
	public virtual /*function */bool IsCloseToPlayer()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsFacingPlayer()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsDisarmChallenge()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool PlayerHasWeapon()
	{
		// stub
		return default;
	}
	
	// Export UTdAI_Tutorial::execSetBestAnchor(FFrame&, void* const)
	public override /*native function */void SetBestAnchor()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void OnResetChallenge()
	{
		// stub
	}
	
	public virtual /*function */void ResetPose()
	{
		// stub
	}
	
	public override UpdatePose_del UpdatePose { get => bfield_UpdatePose ?? TdAI_Tutorial_UpdatePose; set => bfield_UpdatePose = value; } UpdatePose_del bfield_UpdatePose;
	public override UpdatePose_del global_UpdatePose => TdAI_Tutorial_UpdatePose;
	public /*function */void TdAI_Tutorial_UpdatePose()
	{
		// stub
	}
	
	public override UpdatePawnFocus_del UpdatePawnFocus { get => bfield_UpdatePawnFocus ?? TdAI_Tutorial_UpdatePawnFocus; set => bfield_UpdatePawnFocus = value; } UpdatePawnFocus_del bfield_UpdatePawnFocus;
	public override UpdatePawnFocus_del global_UpdatePawnFocus => TdAI_Tutorial_UpdatePawnFocus;
	public /*function */void TdAI_Tutorial_UpdatePawnFocus()
	{
		// stub
	}
	
	public override SeePlayer_del SeePlayer { get => bfield_SeePlayer ?? TdAI_Tutorial_SeePlayer; set => bfield_SeePlayer = value; } SeePlayer_del bfield_SeePlayer;
	public override SeePlayer_del global_SeePlayer => TdAI_Tutorial_SeePlayer;
	public /*event */void TdAI_Tutorial_SeePlayer(Pawn iPawn)
	{
		// stub
	}
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Tutorial_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Tutorial_TestCombatTransitions;
	public /*function */void TdAI_Tutorial_TestCombatTransitions()
	{
		// stub
	}
	
	public virtual /*function */void SetIdleState()
	{
		// stub
	}
	
	public override /*simulated event */int SetupTemplate(AITemplate TheTemplate)
	{
		// stub
		return default;
	}
	
	public delegate bool ShouldEmitPreAttackEvent_del();
	public virtual ShouldEmitPreAttackEvent_del ShouldEmitPreAttackEvent { get => bfield_ShouldEmitPreAttackEvent ?? (()=>default); set => bfield_ShouldEmitPreAttackEvent = value; } ShouldEmitPreAttackEvent_del bfield_ShouldEmitPreAttackEvent;
	public virtual ShouldEmitPreAttackEvent_del global_ShouldEmitPreAttackEvent => ()=>default;
	
	public delegate bool ShouldEnterMeleeMove_del();
	public virtual ShouldEnterMeleeMove_del ShouldEnterMeleeMove { get => bfield_ShouldEnterMeleeMove ?? (()=>default); set => bfield_ShouldEnterMeleeMove = value; } ShouldEnterMeleeMove_del bfield_ShouldEnterMeleeMove;
	public virtual ShouldEnterMeleeMove_del global_ShouldEnterMeleeMove => ()=>default;
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
		NotifyPrepareForMeleeAttack = null;
		NotifyDamage = null;
		UpdatePose = null;
		UpdatePawnFocus = null;
		SeePlayer = null;
		TestCombatTransitions = null;
	
	}
	
	protected /*function */void TdAI_Tutorial_Idle_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	(System.Action<name>, StateFlow, System.Action<name>) WhatToDo()/*state WhatToDo*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool TdAI_Tutorial_AnimationPlayback_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)// state function
	{
		// stub
		return default;
	}
	
	protected /*function */void TdAI_Tutorial_AnimationPlayback_NotifyDamage(Controller ControllerInstigator, Core.ClassT<DamageType> DamageType, int Damage)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) AnimationPlayback()/*state AnimationPlayback*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Tutorial_Stumble_UpdatePose()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Stumble()/*state Stumble*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Tutorial_CombatTutorialMelee_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_Tutorial_CombatTutorialMelee_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected /*event */void TdAI_Tutorial_CombatTutorialMelee_Tick(float DeltaTime)// state function
	{
		// stub
	}
	
	protected /*function */bool TdAI_Tutorial_CombatTutorialMelee_ShouldEmitPreAttackEvent()// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool TdAI_Tutorial_CombatTutorialMelee_ShouldEnterMeleeMove()// state function
	{
		// stub
		return default;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) CombatTutorialMelee()/*state CombatTutorialMelee extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Idle": return Idle();
			case "WhatToDo": return WhatToDo();
			case "AnimationPlayback": return AnimationPlayback();
			case "Stumble": return Stumble();
			case "CombatTutorialMelee": return CombatTutorialMelee();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Idle();
	}
	public TdAI_Tutorial()
	{
		var Default__TdAI_Tutorial_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Tutorial.Sprite' */;
		// Object Offset:0x004E4C63
		bAllowFocus = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Tutorial_Sprite/*Ref SpriteComponent'Default__TdAI_Tutorial.Sprite'*/,
		};
	}
}
}