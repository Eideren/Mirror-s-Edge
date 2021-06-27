namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Sniper : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public enum FindResult 
	{
		NoPosFound,
		BetterPosFound,
		UseCurrentPos,
		FindResult_MAX
	};
	
	public TdSniperSpot SniperSpot;
	public/*(BotControl)*/ /*config */float LoseTargetTime;
	public/*(BotControl)*/ /*config */float AimOffset;
	public/*(BotControl)*/ /*config */float RandomWalkSpeed;
	public/*(BotControl)*/ /*config */float TimeToCalibrate;
	public/*(BotControl)*/ /*config */float TimeToCalibrateOnObjectFactor;
	public/*(BotControl)*/ /*config */float TriggerBotAccuracy;
	public/*(BotControl)*/ /*config */float HomingInOnTargetSpeed;
	public/*(BotControl)*/ /*config */float BreakDistance;
	public bool UseLaser;
	public bool ReadyToFire;
	public TdAimBot NormalAimBot;
	public TdAimBotSniper SniperAimBot;
	public Actor AlternativeTarget;
	public TdExplosiveTargetArea AlternativeTargetArea;
	public PathNode WhenPlayerNotVisibleAimAtThisPoint;
	
	public override /*function */bool CanSearch()
	{
		// stub
		return default;
	}
	
	public override /*function */bool CanInvestigate()
	{
		// stub
		return default;
	}
	
	public override /*function */void DrawDebugInfo(PlayerController PlayerC, Canvas aCanvas)
	{
		// stub
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*event */Object.Vector GetWeaponStartTraceLocation()
	{
		// stub
		return default;
	}
	
	public override /*function */void NotifyWeaponFired(Weapon W, byte FireMode)
	{
		// stub
	}
	
	public virtual /*function */void OnAISetSniperBlindAimSpot(SeqAct_AISetSniperBlindAimSpot seqAct)
	{
		// stub
	}
	
	public override /*simulated event */int SetupTemplate(AITemplate TheTemplate)
	{
		// stub
		return default;
	}
	
	public override /*function */TdAimBotBase CreateAimBot()
	{
		// stub
		return default;
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAI_Sniper_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Sniper_Tick;
	public /*event */void TdAI_Sniper_Tick(float DeltaTime)
	{
		// stub
	}
	
	public override /*function */void UpdateCombatState()
	{
		// stub
	}
	
	public override /*function */void OnTdAIPerfectAim(SeqAct_TdAIPerfectAim Action)
	{
		// stub
	}
	
	public virtual /*function */void UpdateAlternativeTarget()
	{
		// stub
	}
	
	public override TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAI_Sniper_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public override TestCombatTransitions_del global_TestCombatTransitions => TdAI_Sniper_TestCombatTransitions;
	public /*function */void TdAI_Sniper_TestCombatTransitions()
	{
		// stub
	}
	
	// Export UTdAI_Sniper::execCheckFireCondition(FFrame&, void* const)
	public override /*native function */void CheckFireCondition()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */bool EnemyClose()
	{
		// stub
		return default;
	}
	
	public delegate void UpdateFocalPoint_del();
	public virtual UpdateFocalPoint_del UpdateFocalPoint { get => bfield_UpdateFocalPoint ?? TdAI_Sniper_UpdateFocalPoint; set => bfield_UpdateFocalPoint = value; } UpdateFocalPoint_del bfield_UpdateFocalPoint;
	public virtual UpdateFocalPoint_del global_UpdateFocalPoint => TdAI_Sniper_UpdateFocalPoint;
	public /*function */void TdAI_Sniper_UpdateFocalPoint()
	{
		// stub
	}
	
	public override AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAI_Sniper_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public override AllowFire_del global_AllowFire => TdAI_Sniper_AllowFire;
	public /*event */bool TdAI_Sniper_AllowFire()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdAI_Sniper.FindResult FindSniperSpot()
	{
		// stub
		return default;
	}
	
	public delegate bool LaserActive_del();
	public virtual LaserActive_del LaserActive { get => bfield_LaserActive ?? TdAI_Sniper_LaserActive; set => bfield_LaserActive = value; } LaserActive_del bfield_LaserActive;
	public virtual LaserActive_del global_LaserActive => TdAI_Sniper_LaserActive;
	public /*function */bool TdAI_Sniper_LaserActive()
	{
		// stub
		return default;
	}
	
	public override /*event */bool ForceShootAt(TdExplosiveTargetArea TargetArea)
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
		TestCombatTransitions = null;
		UpdateFocalPoint = null;
		AllowFire = null;
		LaserActive = null;
	
	}
	
	protected /*function */void TdAI_Sniper_HoldAndSnipe_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_Sniper_HoldAndSnipe_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_Sniper_HoldAndSnipe_UpdateFocalPoint()// state function
	{
		// stub
	}
	
	protected /*event */bool TdAI_Sniper_HoldAndSnipe_AllowFire()// state function
	{
		// stub
		return default;
	}
	
	protected /*function */bool TdAI_Sniper_HoldAndSnipe_LaserActive()// state function
	{
		// stub
		return default;
	}
	
	protected /*function */void TdAI_Sniper_HoldAndSnipe_CheckCrouching()// state function
	{
		// stub
	}
	
	protected /*function */Object.Rotator TdAI_Sniper_HoldAndSnipe_GetAdjustedAimFor(Weapon W, Object.Vector StartFireLoc)// state function
	{
		// stub
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) HoldAndSnipe()/*state HoldAndSnipe extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "HoldAndSnipe": return HoldAndSnipe();
			default: return base.FindState(stateName);
		}
	}
	public TdAI_Sniper()
	{
		var Default__TdAI_Sniper_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Sniper.Sprite' */;
		// Object Offset:0x004E23DF
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Sniper_Sprite/*Ref SpriteComponent'Default__TdAI_Sniper.Sprite'*/,
		};
	}
}
}