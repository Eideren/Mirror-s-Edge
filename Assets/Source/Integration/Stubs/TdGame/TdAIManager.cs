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
		// stub
	}
	
	public virtual /*function */void UpdateFiringStats()
	{
		// stub
	}
	
	public virtual /*function */void ReportBulletFired()
	{
		// stub
	}
	
	public virtual /*function */void ReportFireIntent()
	{
		// stub
	}
	
	public virtual /*function */bool OkToFireBullet()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ClearFiringStats()
	{
		// stub
	}
	
	public virtual /*function */bool AskToBurst(TdBotPawn Pawn, float BurstDuration)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CheckBurstPriority(TdBotPawn Pawn)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool PrioritizedOver(TdBotPawn P1, TdBotPawn P2)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void UpdateBursts()
	{
		// stub
	}
	
	public virtual /*function */void ReportBurstFinished(TdBotPawn Pawn)
	{
		// stub
	}
	
	public virtual /*private final function */void RemoveBurst(TdBotPawn Pawn)
	{
		// stub
	}
	
	public virtual /*function */bool OkToStartTestingCombatTransitions()
	{
		// stub
		return default;
	}
	
	// Export UTdAIManager::execGetBlockingPawn(FFrame&, void* const)
	public virtual /*native function */TdBotPawn GetBlockingPawn(TdAIController me, bool bCrouching, /*optional */bool? _UpdateMoveDir = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */void NotifyPlayerNavigationPointChanged()
	{
		// stub
	}
	
	// Export UTdAIManager::execIsOkToUpdateVisibility(FFrame&, void* const)
	public virtual /*native function */bool IsOkToUpdateVisibility(TdAIController C)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */bool AllowPathfinding(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsPathfindingTimestampOkForNewPathfind(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void RegisterPathfind(TdAIController C)
	{
		// stub
	}
	
	public virtual /*function */void TimestampPathfind(TdAIController C)
	{
		// stub
	}
	
	public virtual /*function */void RegisterWaitTime(float WaitTime)
	{
		// stub
	}
	
	public virtual /*function */void DrawDebugInfo(PlayerController PlayerC, Canvas aCanvas)
	{
		// stub
	}
	
	public virtual /*function */void ShowPrioritizedBurst()
	{
		// stub
	}
	
	public virtual /*function */float GetAveragePathfindsPerSecond()
	{
		// stub
		return default;
	}
	
	// Export UTdAIManager::execUpdatePlayerNavigationPoint(FFrame&, void* const)
	public virtual /*native function */void UpdatePlayerNavigationPoint()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAIManager::execUpdatePlayerNavigationPointForShieldWall(FFrame&, void* const)
	public virtual /*native function */void UpdatePlayerNavigationPointForShieldWall(AITeam Team)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void AddTeam(AITeam T)
	{
		// stub
	}
	
	public virtual /*function */void RemoveTeam(AITeam T)
	{
		// stub
	}
	
	public virtual /*function */NavigationPoint GetPlayerNavigationPointForShieldWall()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void NotifyCheckedLastSeenPosition()
	{
		// stub
	}
	
	// Export UTdAIManager::execPlayerMoveOkForLastSeenLocationUpdate(FFrame&, void* const)
	public virtual /*native function */bool PlayerMoveOkForLastSeenLocationUpdate(TdPawn aPawn)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIManager::execSetLastSeenLocation(FFrame&, void* const)
	public virtual /*native final function */void SetLastSeenLocation(/*optional */TdPawn _aPawn = default, /*optional */Object.Vector? _L = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAIManager::execFindPredictedLastSeenLocation(FFrame&, void* const)
	public virtual /*private native final function */void FindPredictedLastSeenLocation()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAIManager::execSetLastSeenLocationLocal(FFrame&, void* const)
	public virtual /*private native final function */void SetLastSeenLocationLocal(Object.Vector Loc)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAIManager::execRestoreOldLastSeenLocation(FFrame&, void* const)
	public virtual /*private native final function */void RestoreOldLastSeenLocation(Object.Vector L)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void SetPlayer(TdPlayerPawn InPlayer)
	{
		// stub
	}
	
	public virtual /*function */void Add(TdAIController Bot)
	{
		// stub
	}
	
	public virtual /*function */void RemoveBot(TdAIController Bot)
	{
		// stub
	}
	
	public virtual /*function */void AddGrenadeArea(TdGrenadeTargetArea TargetArea)
	{
		// stub
	}
	
	public virtual /*function */void RemoveGrenadeArea(TdGrenadeTargetArea TargetArea)
	{
		// stub
	}
	
	public virtual /*function */void FinishedThrowingGrenade(TdProj_Grenade Grenade)
	{
		// stub
	}
	
	public virtual /*function */bool NearbyOffensiveGrenadeExists(TdBotPawn Pawn)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void NotifyGrenadeExploded(Object.Vector ExplosionLocation, float Lifetime)
	{
		// stub
	}
	
	public virtual /*event */void GrenadeTick()
	{
		// stub
	}
	
	public virtual /*function */void NotifyPlayerSpotted(Pawn TheEnemy)
	{
		// stub
	}
	
	public virtual /*function */void ReportUsingMelee(TdAIController C, bool flag)
	{
		// stub
	}
	
	public virtual /*function */bool OkToMelee(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool SomeoneElseIsPursuingOrMeleeing(TdAIController me)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsAnyoneDoingAFinishingAttack(/*optional */TdAIController _exclude = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsAnyoneEngagedInCloseCombat(TdAIController me)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void NotifyPlayerReachable()
	{
		// stub
	}
	
	public virtual /*exec function */void ChaseAI()
	{
		// stub
	}
	
	// Export UTdAIManager::execGetNumberOfFriendsWithinRadius2D(FFrame&, void* const)
	public virtual /*native final function */int GetNumberOfFriendsWithinRadius2D(TdAIController me, Object.Vector pos, float Radius)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIManager::execFindBestTaserSpot(FFrame&, void* const)
	public virtual /*native final function */bool FindBestTaserSpot(TdAIController C, ref NavigationPoint np, Object.Vector Point, int NetworkID, /*optional */float? _MaxDist = default, /*optional */float? _MaxDistZ = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIManager::execIsGoalForAnyBot(FFrame&, void* const)
	public virtual /*native final function */bool IsGoalForAnyBot(NavigationPoint np, /*optional */TdAIController _exclude = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
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