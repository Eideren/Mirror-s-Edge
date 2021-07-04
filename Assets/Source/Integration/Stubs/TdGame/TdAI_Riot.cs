namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Riot : TdAIController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public const int CMinDistDiffToSwitchFormationPos = 30;
	
	public array<TdAIController> Clients;
	public array<Object.Vector> FormationPositions;
	public array<bool> IgnoredClients;
	public float fEnemyNotVisibleToWholeFormationTime;
	public float LastMeleeTimeStamp;
	public float MeleeTimer;
	public bool bUsingWideFormation;
	public float LeftWideFormationTimeStamp;
	public /*const */float CFormationWidth;
	public /*const */float CFormationDepth;
	public float FormationCollisionRadius;
	public int FormationWidthCount;
	public/*(Melee)*/ /*editinline */TdMove_Melee_Riot RiotMeleeMove;
	
	public override Possess_del Possess { get => bfield_Possess ?? TdAI_Riot_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public override Possess_del global_Possess => TdAI_Riot_Possess;
	public /*event */void TdAI_Riot_Possess(Pawn inPawn, bool bVehicleTransition)
	{
		// stub
	}
	
	public virtual /*function */void UpdateFormationRadius()
	{
		// stub
	}
	
	public override /*function */bool TdFindPathToward(Actor anActor)
	{
		// stub
		return default;
	}
	
	public override /*function */void TdFindPathTo(Object.Vector aPoint)
	{
		// stub
	}
	
	// Export UTdAI_Riot::execSetBestAnchor(FFrame&, void* const)
	public override /*native function */void SetBestAnchor()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */bool OkToMoveDirectlyToPoint()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsInFormation(Pawn P)
	{
		// stub
		return default;
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*event */void Initialize()
	{
		// stub
	}
	
	public override /*function */void ReportBotDied()
	{
		// stub
	}
	
	public override AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAI_Riot_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public override AllowFire_del global_AllowFire => TdAI_Riot_AllowFire;
	public /*event */bool TdAI_Riot_AllowFire()
	{
		// stub
		return default;
	}
	
	public override CheckCrouching_del CheckCrouching { get => bfield_CheckCrouching ?? TdAI_Riot_CheckCrouching; set => bfield_CheckCrouching = value; } CheckCrouching_del bfield_CheckCrouching;
	public override CheckCrouching_del global_CheckCrouching => TdAI_Riot_CheckCrouching;
	public /*function */void TdAI_Riot_CheckCrouching()
	{
		// stub
	}
	
	public override /*function */bool IsOkToRun()
	{
		// stub
		return default;
	}
	
	public override /*function */void AddSpecialOutput(ref String Text)
	{
		// stub
	}
	
	public override /*function */void BeginAdvance()
	{
		// stub
	}
	
	public override /*function */void EndAdvance()
	{
		// stub
	}
	
	public override /*function */Object.Vector GetAdvancePoint()
	{
		// stub
		return default;
	}
	
	// Export UTdAI_Riot::execIsWide(FFrame&, void* const)
	public virtual /*native function */bool IsWide()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*function */bool ShouldBackaway()
	{
		// stub
		return default;
	}
	
	public override /*function */bool ShouldMoveIn()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void NotifyNewPlayerNavigationPointForShieldWall()
	{
		// stub
	}
	
	public virtual /*function */bool ShouldStop()
	{
		// stub
		return default;
	}
	
	public override /*function */void TestAdvanceMovement()
	{
		// stub
	}
	
	public virtual /*function */void AssignPosition(TdAIController C, int pos)
	{
		// stub
	}
	
	public virtual /*function */void ResignPosition(int pos)
	{
		// stub
	}
	
	public virtual /*function */bool CloserThanCurrentClient(TdAIController C, int I)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool ApplyForFormationPosition(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanMoveIntoPosition(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void RemoveFromFormation(TdAIController C)
	{
		// stub
	}
	
	public virtual /*function */void BreakFormation()
	{
		// stub
	}
	
	public override /*function */bool IsReadyToMove()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AreClientsReadyToMove()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool EnemyVisibleToWholeFormation()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ApplyForShieldMasterPosition()
	{
		// stub
	}
	
	public virtual /*function */void SetShieldMaster()
	{
		// stub
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAI_Riot_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Riot_Tick;
	public /*event */void TdAI_Riot_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void SwitchFormationPositions()
	{
		// stub
	}
	
	public virtual /*function */void TrySwitchPositions(int P1, int P2)
	{
		// stub
	}
	
	public virtual /*function */void SwitchPositions(int P1, int P2)
	{
		// stub
	}
	
	public virtual /*function */bool AnyClientsTrailingBehind()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AnyClientsTrailingBehindAlot()
	{
		// stub
		return default;
	}
	
	public virtual /*function */float GetMoveDist()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void UpdateShieldFormation(float FormationWidth, float FormationDepth)
	{
		// stub
	}
	
	public override ShouldEnterMelee_del ShouldEnterMelee { get => bfield_ShouldEnterMelee ?? TdAI_Riot_ShouldEnterMelee; set => bfield_ShouldEnterMelee = value; } ShouldEnterMelee_del bfield_ShouldEnterMelee;
	public override ShouldEnterMelee_del global_ShouldEnterMelee => TdAI_Riot_ShouldEnterMelee;
	public /*function */bool TdAI_Riot_ShouldEnterMelee(float Range)
	{
		// stub
		return default;
	}
	
	public override /*function */TdAIController.EDisarmState QueryDisarmState(TdPawn Disarmer)
	{
		// stub
		return default;
	}
	
	public override /*function */bool AskToCrouch()
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Possess = null;
		AllowFire = null;
		CheckCrouching = null;
		Tick = null;
		ShouldEnterMelee = null;
	
	}
	
	protected /*function */void TdAI_Riot_RiotMelee_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_Riot_RiotMelee_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected /*function */void TdAI_Riot_RiotMelee_UpdatePawnFocus()// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) RiotMelee()/*state RiotMelee extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "RiotMelee": return RiotMelee();
			default: return base.FindState(stateName);
		}
	}
	public TdAI_Riot()
	{
		var Default__TdAI_Riot_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Riot.Sprite' */;
		// Object Offset:0x004E0255
		MeleeTimer = 2.0f;
		CFormationWidth = 100.0f;
		CFormationDepth = 90.0f;
		bAvoidPopulatedPaths = false;
		MeleeState = (name)"RiotMelee";
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Riot_Sprite/*Ref SpriteComponent'Default__TdAI_Riot.Sprite'*/,
		};
	}
}
}