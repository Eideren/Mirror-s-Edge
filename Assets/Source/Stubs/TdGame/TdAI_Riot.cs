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
	
	}
	
	public virtual /*function */void UpdateFormationRadius()
	{
	
	}
	
	public override /*function */bool TdFindPathToward(Actor anActor)
	{
	
		return default;
	}
	
	public override /*function */void TdFindPathTo(Object.Vector aPoint)
	{
	
	}
	
	// Export UTdAI_Riot::execSetBestAnchor(FFrame&, void* const)
	public override /*native function */void SetBestAnchor()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*function */bool OkToMoveDirectlyToPoint()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsInFormation(Pawn P)
	{
	
		return default;
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override /*event */void Initialize()
	{
	
	}
	
	public override /*function */void ReportBotDied()
	{
	
	}
	
	public override AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAI_Riot_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public override AllowFire_del global_AllowFire => TdAI_Riot_AllowFire;
	public /*event */bool TdAI_Riot_AllowFire()
	{
	
		return default;
	}
	
	public override CheckCrouching_del CheckCrouching { get => bfield_CheckCrouching ?? TdAI_Riot_CheckCrouching; set => bfield_CheckCrouching = value; } CheckCrouching_del bfield_CheckCrouching;
	public override CheckCrouching_del global_CheckCrouching => TdAI_Riot_CheckCrouching;
	public /*function */void TdAI_Riot_CheckCrouching()
	{
	
	}
	
	public override /*function */bool IsOkToRun()
	{
	
		return default;
	}
	
	public override /*function */void AddSpecialOutput(ref String Text)
	{
	
	}
	
	public override /*function */void BeginAdvance()
	{
	
	}
	
	public override /*function */void EndAdvance()
	{
	
	}
	
	public override /*function */Object.Vector GetAdvancePoint()
	{
	
		return default;
	}
	
	// Export UTdAI_Riot::execIsWide(FFrame&, void* const)
	public virtual /*native function */bool IsWide()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool ShouldBackaway()
	{
	
		return default;
	}
	
	public override /*function */bool ShouldMoveIn()
	{
	
		return default;
	}
	
	public virtual /*event */void NotifyNewPlayerNavigationPointForShieldWall()
	{
	
	}
	
	public virtual /*function */bool ShouldStop()
	{
	
		return default;
	}
	
	public override /*function */void TestAdvanceMovement()
	{
	
	}
	
	public virtual /*function */void AssignPosition(TdAIController C, int pos)
	{
	
	}
	
	public virtual /*function */void ResignPosition(int pos)
	{
	
	}
	
	public virtual /*function */bool CloserThanCurrentClient(TdAIController C, int I)
	{
	
		return default;
	}
	
	public virtual /*function */bool ApplyForFormationPosition(TdAIController C)
	{
	
		return default;
	}
	
	public virtual /*function */bool CanMoveIntoPosition(TdAIController C)
	{
	
		return default;
	}
	
	public virtual /*function */void RemoveFromFormation(TdAIController C)
	{
	
	}
	
	public virtual /*function */void BreakFormation()
	{
	
	}
	
	public override /*function */bool IsReadyToMove()
	{
	
		return default;
	}
	
	public virtual /*function */bool AreClientsReadyToMove()
	{
	
		return default;
	}
	
	public virtual /*function */bool EnemyVisibleToWholeFormation()
	{
	
		return default;
	}
	
	public virtual /*function */void ApplyForShieldMasterPosition()
	{
	
	}
	
	public virtual /*function */void SetShieldMaster()
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAI_Riot_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAI_Riot_Tick;
	public /*event */void TdAI_Riot_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void SwitchFormationPositions()
	{
	
	}
	
	public virtual /*function */void TrySwitchPositions(int P1, int P2)
	{
	
	}
	
	public virtual /*function */void SwitchPositions(int P1, int P2)
	{
	
	}
	
	public virtual /*function */bool AnyClientsTrailingBehind()
	{
	
		return default;
	}
	
	public virtual /*function */bool AnyClientsTrailingBehindAlot()
	{
	
		return default;
	}
	
	public virtual /*function */float GetMoveDist()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateShieldFormation(float FormationWidth, float FormationDepth)
	{
	
	}
	
	public override ShouldEnterMelee_del ShouldEnterMelee { get => bfield_ShouldEnterMelee ?? TdAI_Riot_ShouldEnterMelee; set => bfield_ShouldEnterMelee = value; } ShouldEnterMelee_del bfield_ShouldEnterMelee;
	public override ShouldEnterMelee_del global_ShouldEnterMelee => TdAI_Riot_ShouldEnterMelee;
	public /*function */bool TdAI_Riot_ShouldEnterMelee(float Range)
	{
	
		return default;
	}
	
	public override /*function */TdAIController.EDisarmState QueryDisarmState(TdPawn Disarmer)
	{
	
		return default;
	}
	
	public override /*function */bool AskToCrouch()
	{
	
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
	
	}
	
	protected /*function */void TdAI_Riot_RiotMelee_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */void TdAI_Riot_RiotMelee_UpdatePawnFocus()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RiotMelee()/*state RiotMelee extends TdState*/
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
		// Object Offset:0x004E0255
		MeleeTimer = 2.0f;
		CFormationWidth = 100.0f;
		CFormationDepth = 90.0f;
		bAvoidPopulatedPaths = false;
		MeleeState = (name)"RiotMelee";
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAI_Riot.Sprite")/*Ref SpriteComponent'Default__TdAI_Riot.Sprite'*/,
		};
	}
}
}