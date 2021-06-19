namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Tutorial : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public /*transient */TdTutorialListener TutorialListener;
	public /*transient */bool bAttackInitiated;
	public /*transient */bool bHasEmittedPreAttackEvent;
	public /*transient */bool bHasEmittedPostAttackEvent;
	public /*transient */int DisarmEventIdentifier;
	
	// Export UTdAI_Tutorial::execUpdateAnchor(FFrame&, void* const)
	public override /*native function */void UpdateAnchor()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void Initialize()
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAI_Tutorial_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Tutorial_Tick;
	public /*event */void TdAI_Tutorial_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*function */bool CanAttack()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldBlockAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public override NotifyPrepareForMeleeAttack_del NotifyPrepareForMeleeAttack { get => bfield_NotifyPrepareForMeleeAttack ?? TdAI_Tutorial_NotifyPrepareForMeleeAttack; set => bfield_NotifyPrepareForMeleeAttack = value; } NotifyPrepareForMeleeAttack_del bfield_NotifyPrepareForMeleeAttack;
	public override NotifyPrepareForMeleeAttack_del global_NotifyPrepareForMeleeAttack => TdAI_Tutorial_NotifyPrepareForMeleeAttack;
	public /*function */bool TdAI_Tutorial_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
	
		return default;
	}
	
	public override NotifyDamage_del NotifyDamage { get => bfield_NotifyDamage ?? TdAI_Tutorial_NotifyDamage; set => bfield_NotifyDamage = value; } NotifyDamage_del bfield_NotifyDamage;
	public override NotifyDamage_del global_NotifyDamage => TdAI_Tutorial_NotifyDamage;
	public /*function */void TdAI_Tutorial_NotifyDamage(Controller ControllerInstigator, Core.ClassT<DamageType> DamageType, int Damage)
	{
	
	}
	
	public override /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
	
		return default;
	}
	
	public override /*function */void NotifyMeleeFinished()
	{
	
	}
	
	public override /*function */void OnDisarmed()
	{
	
	}
	
	public override /*function */void TriggerCannedAnim(int Move, name AnimationName)
	{
	
	}
	
	public virtual /*function */void EmitFailedEvent()
	{
	
	}
	
	public virtual /*function */void EmitMeleeAttackSucceededEvent()
	{
	
	}
	
	public virtual /*function */void EmitPreAttackEvent()
	{
	
	}
	
	public virtual /*function */void EmitPostAttackEvent()
	{
	
	}
	
	public virtual /*function */void EmitDisarmSucceededEvent()
	{
	
	}
	
	public virtual /*function */void EmitWeaponDroppedEvent()
	{
	
	}
	
	public virtual /*function */void OnTdAiInitiateAttack(SeqAct_TdAiInitiateAttack Action)
	{
	
	}
	
	public virtual /*function */bool IsCloseToPlayer()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsFacingPlayer()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsDisarmChallenge()
	{
	
		return default;
	}
	
	public virtual /*function */bool PlayerHasWeapon()
	{
	
		return default;
	}
	
	// Export UTdAI_Tutorial::execSetBestAnchor(FFrame&, void* const)
	public override /*native function */void SetBestAnchor()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void OnResetChallenge()
	{
	
	}
	
	public virtual /*function */void ResetPose()
	{
	
	}
	
	public override UpdatePose_del UpdatePose { get => bfield_UpdatePose ?? TdAI_Tutorial_UpdatePose; set => bfield_UpdatePose = value; } UpdatePose_del bfield_UpdatePose;
	public override UpdatePose_del global_UpdatePose => TdAI_Tutorial_UpdatePose;
	public /*function */void TdAI_Tutorial_UpdatePose()
	{
	
	}
	
	public override UpdatePawnFocus_del UpdatePawnFocus { get => bfield_UpdatePawnFocus ?? TdAI_Tutorial_UpdatePawnFocus; set => bfield_UpdatePawnFocus = value; } UpdatePawnFocus_del bfield_UpdatePawnFocus;
	public override UpdatePawnFocus_del global_UpdatePawnFocus => TdAI_Tutorial_UpdatePawnFocus;
	public /*function */void TdAI_Tutorial_UpdatePawnFocus()
	{
	
	}
	
	public override SeePlayer_del SeePlayer { get => bfield_SeePlayer ?? TdAI_Tutorial_SeePlayer; set => bfield_SeePlayer = value; } SeePlayer_del bfield_SeePlayer;
	public override SeePlayer_del global_SeePlayer => TdAI_Tutorial_SeePlayer;
	public /*event */void TdAI_Tutorial_SeePlayer(Pawn iPawn)
	{
	
	}
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Tutorial_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Tutorial_TestCombatTransitions;
	public /*function */void TdAI_Tutorial_TestCombatTransitions()
	{
	
	}
	
	public virtual /*function */void SetIdleState()
	{
	
	}
	
	public override /*simulated event */int SetupTemplate(AITemplate TheTemplate)
	{
	
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
		Tick = null;
		NotifyPrepareForMeleeAttack = null;
		NotifyDamage = null;
		UpdatePose = null;
		UpdatePawnFocus = null;
		SeePlayer = null;
		TestCombatTransitions = null;
	
	}
	
	protected /*function */void TdAI_Tutorial_Idle_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WhatToDo()/*state WhatToDo*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool TdAI_Tutorial_AnimationPlayback_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)// state function
	{
	
		return default;
	}
	
	protected /*function */void TdAI_Tutorial_AnimationPlayback_NotifyDamage(Controller ControllerInstigator, Core.ClassT<DamageType> DamageType, int Damage)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) AnimationPlayback()/*state AnimationPlayback*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Tutorial_Stumble_UpdatePose()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Stumble()/*state Stumble*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAI_Tutorial_CombatTutorialMelee_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Tutorial_CombatTutorialMelee_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*event */void TdAI_Tutorial_CombatTutorialMelee_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected /*function */bool TdAI_Tutorial_CombatTutorialMelee_ShouldEmitPreAttackEvent()// state function
	{
	
		return default;
	}
	
	protected /*function */bool TdAI_Tutorial_CombatTutorialMelee_ShouldEnterMeleeMove()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) CombatTutorialMelee()/*state CombatTutorialMelee extends TdState*/
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