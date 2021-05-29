namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIManager : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public const double MinDotForBurstPriority = 0.71f;
	public const double MinDistForBurstPriority = 1000f;
	public const int cMaxAIUsingMelee = 1;
	
	public partial struct /*native */PathfindingStruct
	{
		public TdAIController C;
		public float LastPathfindTimeStamp;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004EB32A
	//		C = default;
	//		LastPathfindTimeStamp = 0.0f;
	//	}
	};
	
	public partial struct /*native */Burst
	{
		public TdBotPawn Pawn;
		public float StartTime;
		public float Duration;
		public bool bActive;
		public bool bPriorityBurst;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004EB47A
	//		Pawn = default;
	//		StartTime = 0.0f;
	//		Duration = 0.0f;
	//		bActive = false;
	//		bPriorityBurst = false;
	//	}
	};
	
	public array<TdAIController> AIControllers;
	public /*private */array<AITeam> Teams;
	public /*private */TdPlayerPawn Player;
	public TdPawn Enemy;
	public /*private */array<TdGrenadeTargetArea> GrenadeTargetAreas;
	public /*private */TdAIController GrenadeThrowingBot;
	public /*private */TdProj_Grenade ActiveGrenade;
	public bool bPlayerInvisibleToAI;
	public bool bHasAnyoneStartedTestingCombatTransitionsThisFrame;
	public /*private */bool bLastSeenLocationHasBeenRestored;
	public /*private */bool bPredictedLastSeenLocationHasBeenSet;
	public /*private */bool bHaveTriedToPredict;
	public bool CheckedLastSeenLocation;
	public bool bAggressiveChaseAI;
	public/*(AIManager)*/ bool UseBurstControl;
	public/*(AIManager)*/ bool UseBulletControl;
	public /*private */array<TdAIController> BotsUsingMelee;
	public /*private */int NumNotifiedAI;
	public /*private */int NotifiedIndex;
	public /*private */int TaserSpotSearchesThisFrame;
	public int UpdateVisibilityIndex;
	public int MaxNumPathfindsPerFrame;
	public int NumPathfindsThisFrame;
	public /*private */array<TdAIManager.PathfindingStruct> PathfindingData;
	public array<int> PathfindsPerFrameHistory;
	public int PathfindsArrayIndex;
	public float BiggestAveragePathfindsPerSecond;
	public float LongestWaitTime;
	public Object.Vector PlayerViewLocation;
	public Object.Rotator PlayerViewRotation;
	public Object.Vector PlayerViewpointLocation;
	public NavigationPoint PlayerNavigationPointForShieldWall;
	public int ShieldFormations;
	public NavigationPoint PlayerNavigationPoint;
	public float LSLTimeStamp;
	public Object.Vector LastSeenLocation;
	public /*private */Object.Vector OldLastSeenLocation;
	public /*private */Object.Vector ReallyOldLastSeenLocation;
	public Object.Vector LastSeenHeadLocation;
	public /*private */NavigationPoint CurrentNavPointToCheck;
	public int ShotsFiredThisFrame;
	public/*(AIManager)*/ int MaxShotsFiredPerFrame;
	public int ShotsFiredThisSecond;
	public/*(AIManager)*/ int MaxShotsFiredPerSecond;
	public float CurrentMeasuringSecond;
	public float LastShotFiredTimeStamp;
	public int NumCleanFramesSinceLastShotFired;
	public/*(AIManager)*/ int MaxNumCleanFrames;
	public array<TdAIManager.Burst> Bursts;
	public int NumberOfActiveBursts;
	public int BurstPriorityCount;
	public/*(AIManager)*/ int MaxSimultaneousBursts;
	public int NumberOfFireIntentsThisFrame;
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAIManager_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAIManager_Tick;
	public /*event */void TdAIManager_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void UpdateFiringStats()
	{
	
	}
	
	public virtual /*function */void ReportBulletFired()
	{
	
	}
	
	public virtual /*function */void ReportFireIntent()
	{
	
	}
	
	public virtual /*function */bool OkToFireBullet()
	{
	
		return default;
	}
	
	public virtual /*function */void ClearFiringStats()
	{
	
	}
	
	public virtual /*function */bool AskToBurst(TdBotPawn Pawn, float BurstDuration)
	{
	
		return default;
	}
	
	public virtual /*function */bool CheckBurstPriority(TdBotPawn Pawn)
	{
	
		return default;
	}
	
	public virtual /*function */bool PrioritizedOver(TdBotPawn P1, TdBotPawn P2)
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateBursts()
	{
	
	}
	
	public virtual /*function */void ReportBurstFinished(TdBotPawn Pawn)
	{
	
	}
	
	public virtual /*private final function */void RemoveBurst(TdBotPawn Pawn)
	{
	
	}
	
	public virtual /*function */bool OkToStartTestingCombatTransitions()
	{
	
		return default;
	}
	
	// Export UTdAIManager::execGetBlockingPawn(FFrame&, void* const)
	public virtual /*native function */TdBotPawn GetBlockingPawn(TdAIController me, bool bCrouching, /*optional */bool? _UpdateMoveDir = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void NotifyPlayerNavigationPointChanged()
	{
	
	}
	
	// Export UTdAIManager::execIsOkToUpdateVisibility(FFrame&, void* const)
	public virtual /*native function */bool IsOkToUpdateVisibility(TdAIController C)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool AllowPathfinding(TdAIController C)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsPathfindingTimestampOkForNewPathfind(TdAIController C)
	{
	
		return default;
	}
	
	public virtual /*function */void RegisterPathfind(TdAIController C)
	{
	
	}
	
	public virtual /*function */void TimestampPathfind(TdAIController C)
	{
	
	}
	
	public virtual /*function */void RegisterWaitTime(float WaitTime)
	{
	
	}
	
	public virtual /*function */void DrawDebugInfo(PlayerController PlayerC, Canvas aCanvas)
	{
	
	}
	
	public virtual /*function */void ShowPrioritizedBurst()
	{
	
	}
	
	public virtual /*function */float GetAveragePathfindsPerSecond()
	{
	
		return default;
	}
	
	// Export UTdAIManager::execUpdatePlayerNavigationPoint(FFrame&, void* const)
	public virtual /*native function */void UpdatePlayerNavigationPoint()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIManager::execUpdatePlayerNavigationPointForShieldWall(FFrame&, void* const)
	public virtual /*native function */void UpdatePlayerNavigationPointForShieldWall(AITeam Team)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void AddTeam(AITeam T)
	{
	
	}
	
	public virtual /*function */void RemoveTeam(AITeam T)
	{
	
	}
	
	public virtual /*function */NavigationPoint GetPlayerNavigationPointForShieldWall()
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyCheckedLastSeenPosition()
	{
	
	}
	
	// Export UTdAIManager::execPlayerMoveOkForLastSeenLocationUpdate(FFrame&, void* const)
	public virtual /*native function */bool PlayerMoveOkForLastSeenLocationUpdate(TdPawn aPawn)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIManager::execSetLastSeenLocation(FFrame&, void* const)
	public virtual /*native final function */void SetLastSeenLocation(/*optional */TdPawn? _aPawn = default, /*optional */Object.Vector? _L = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIManager::execFindPredictedLastSeenLocation(FFrame&, void* const)
	public virtual /*private native final function */void FindPredictedLastSeenLocation()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIManager::execSetLastSeenLocationLocal(FFrame&, void* const)
	public virtual /*private native final function */void SetLastSeenLocationLocal(Object.Vector Loc)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIManager::execRestoreOldLastSeenLocation(FFrame&, void* const)
	public virtual /*private native final function */void RestoreOldLastSeenLocation(Object.Vector L)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void SetPlayer(TdPlayerPawn InPlayer)
	{
	
	}
	
	public virtual /*function */void Add(TdAIController Bot)
	{
	
	}
	
	public virtual /*function */void RemoveBot(TdAIController Bot)
	{
	
	}
	
	public virtual /*function */void AddGrenadeArea(TdGrenadeTargetArea TargetArea)
	{
	
	}
	
	public virtual /*function */void RemoveGrenadeArea(TdGrenadeTargetArea TargetArea)
	{
	
	}
	
	public virtual /*function */void FinishedThrowingGrenade(TdProj_Grenade Grenade)
	{
	
	}
	
	public virtual /*function */bool NearbyOffensiveGrenadeExists(TdBotPawn Pawn)
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyGrenadeExploded(Object.Vector ExplosionLocation, float Lifetime)
	{
	
	}
	
	public virtual /*event */void GrenadeTick()
	{
	
	}
	
	public virtual /*function */void NotifyPlayerSpotted(Pawn TheEnemy)
	{
	
	}
	
	public virtual /*function */void ReportUsingMelee(TdAIController C, bool flag)
	{
	
	}
	
	public virtual /*function */bool OkToMelee(TdAIController C)
	{
	
		return default;
	}
	
	public virtual /*function */bool SomeoneElseIsPursuingOrMeleeing(TdAIController me)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAnyoneDoingAFinishingAttack(/*optional */TdAIController? _exclude = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsAnyoneEngagedInCloseCombat(TdAIController me)
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyPlayerReachable()
	{
	
	}
	
	public virtual /*exec function */void ChaseAI()
	{
	
	}
	
	// Export UTdAIManager::execGetNumberOfFriendsWithinRadius2D(FFrame&, void* const)
	public virtual /*native final function */int GetNumberOfFriendsWithinRadius2D(TdAIController me, Object.Vector pos, float Radius)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIManager::execFindBestTaserSpot(FFrame&, void* const)
	public virtual /*native final function */bool FindBestTaserSpot(TdAIController C, ref NavigationPoint np, Object.Vector Point, int NetworkID, /*optional */float? _MaxDist = default, /*optional */float? _MaxDistZ = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIManager::execIsGoalForAnyBot(FFrame&, void* const)
	public virtual /*native final function */bool IsGoalForAnyBot(NavigationPoint np, /*optional */TdAIController? _exclude = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public TdAIManager()
	{
		// Object Offset:0x004EE4E4
		UseBurstControl = true;
		MaxSimultaneousBursts = 2;
	}
}
}