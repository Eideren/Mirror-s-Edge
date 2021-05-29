namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIController : AIController, 
		TdController/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public const int SETUPTEMPLATE_AICONTROLLER = 0;
	public const int SETUPTEMPLATE_AICONTROLLER_1 = 1;
	public const int SETUPTEMPLATE_AICONTROLLER_2 = 2;
	public const int SETUPTEMPLATE_AISNIPER = 3;
	public const int SETUPTEMPLATE_AITUTORIAL = 3;
	public const int LATENT_MOVETO = 501;
	public const int LATENT_STRAFETO = 505;
	public const int LATENT_STRAFEFACING = 507;
	public const int LATENT_FINISHROTATION = 509;
	public const int LATENT_WAITFORLANDING = 528;
	
	public enum EMeleeType 
	{
		MT_Standing,
		MT_Walking,
		MT_Running,
		MT_MAX
	};
	
	public enum EAggressionLevel 
	{
		AL_Aggressive,
		AL_Cautious,
		AL_Defensive,
		AL_MAX
	};
	
	public enum AdvanceAction 
	{
		AA_MoveCloser,
		AA_StandAndFire,
		AA_Backup,
		AA_FindLineOfFire,
		AA_None,
		AA_MAX
	};
	
	public enum MoveDir 
	{
		MDNotSelected,
		MDLeft,
		MDRight,
		MoveDir_MAX
	};
	
	public enum EDisarmState 
	{
		DS_NotPossible,
		DS_Miss,
		DS_Stage1,
		DS_Stage2,
		DS_Stage3,
		DS_MAX
	};
	
	public partial struct /*native */TdLine
	{
		public Object.Vector Start;
		public Object.Vector End;
		public byte R;
		public byte G;
		public byte B;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004AC4C8
	//		Start = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		End = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		R = 0;
	//		G = 0;
	//		B = 0;
	//	}
	};
	
	public partial struct /*native */StoredMovementVarsStruct
	{
		public array<ReachSpec> OldPath;
		public array<NavigationPoint> RouteCache;
		public bool MoveGoalIsEnemy;
		public NavigationPoint OldAnchor;
		public NavigationPoint Anchor;
		public Actor MoveGoal;
		public Object.Vector MovePoint;
		public bool HaltAfterMoveToGoal;
		public float fCurrentRouteDistance;
		public bool bCurrentRouteContainsMoves;
		public bool bFirstDestination;
		public Object.Vector PathfindingGoalPos;
		public Actor OldMoveTarget;
		public Actor MoveTarget;
		public bool bSkipPathFind;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004AC8BB
	//		OldPath = default;
	//		RouteCache = default;
	//		MoveGoalIsEnemy = false;
	//		OldAnchor = default;
	//		Anchor = default;
	//		MoveGoal = default;
	//		MovePoint = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		HaltAfterMoveToGoal = false;
	//		fCurrentRouteDistance = 0.0f;
	//		bCurrentRouteContainsMoves = false;
	//		bFirstDestination = false;
	//		PathfindingGoalPos = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		OldMoveTarget = default;
	//		MoveTarget = default;
	//		bSkipPathFind = false;
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_ITdController;
	public /*protected */int SetupTemplateCount;
	public TdAIController.EMeleeType MeleeType;
	public /*protected */TdAIController.EAggressionLevel AggressionLevel;
	public TdFocusHandler.FocusType WantedFocus;
	public TdAIAnimationController.ECoverDirectionState CoverDirection;
	public /*transient */TdAIAnimationController.ECoverDirectionState ForcedCoverDirection;
	public TdBotPawn.EPose WantedPose;
	public TdAIController.AdvanceAction CurrentAdvanceAction;
	public TdAIController.MoveDir LineOfFireMoveDir;
	public TdAIController.MoveDir MovingBackMoveDir;
	public array<TdAIController.TdLine> BatchedLines;
	public HUD HUD;
	public float PlayerLookAtOffsetZ;
	public /*private */bool bForceKeepMoving;
	public /*private */bool bDebugHalt;
	public bool bFirstShot;
	public bool IAmShieldMaster;
	public /*private */bool bTrailingBehind;
	public /*private */bool bTrailingBehindAlot;
	public bool bIsInPosition;
	public /*private */bool bHasDoneEnemyReachableTest;
	public /*protected */bool bEnemyIsReachable;
	public bool tempBool;
	public bool bRandomCrouch;
	public bool HasTriggeredMeleeAttack;
	public bool ExitMeleeAsSoonAsPossible;
	public /*transient */bool bAllowFocus;
	public /*transient */bool bAllowFocusRotation;
	public bool bAtGoodFiringPosition;
	public /*private */bool bCurrentRouteContainsMoves;
	public /*protected */bool bForceSniperCrouched;
	public bool bFailedLastPathToEnemy;
	public /*protected */bool bIsOkToFire;
	public /*private */bool bCanFireFromHere;
	public /*private */bool bIsWithinAttackAngle;
	public /*protected */bool bHasLineOfFire;
	public /*private */bool bIsWithinFiringDistance;
	public /*private */bool bHoldFire;
	public bool EnemyVisible;
	public bool bPlayerSeenForReal;
	public bool PlayerLookingTowardsMe;
	public bool FireWeapon;
	public /*private */bool bForceFire;
	public bool bReachedMoveGoal;
	public bool bStopMoveToGoal;
	public bool bSkipReachableTest;
	public bool bUseMomentum;
	public bool bSkipPathFind;
	public bool bMovingToGoal;
	public bool bFirstSearch;
	public bool bFirstMoveTowards;
	public bool bClearFirstMoveTowards;
	public bool bFirstDestination;
	public bool bForceMoveTowardToReturn;
	public bool bMoveJustFinished;
	public bool bLandingDone;
	public bool HaltAfterMoveToGoal;
	public bool MoveGoalIsEnemy;
	public bool IsMovingToCover;
	public /*private */bool bRetreatFromCoverWhenExited;
	public bool bExitedCover;
	public bool IsAdvancing;
	public bool bIsWalkingToNode;
	public bool bWaitForRotation;
	public bool bAdvance;
	public bool bIsImmobile;
	public bool bSliding;
	public bool bCheckForLedges;
	public bool IsInCover;
	public bool bCoverDirectionValid;
	public bool bUseCoverCPOL;
	public bool bUseCoverDetour;
	public bool bUseCoverPathRestrictions;
	public /*transient */bool bForceValidCoverDirection;
	public /*protected */bool bUseSaferPaths;
	public /*protected */bool bAvoidPopulatedPaths;
	public /*protected */bool bOldUseSaferPaths;
	public /*protected */bool bOldAvoidPopulatedPaths;
	public bool bEnemyIsAimingAtUs;
	public /*transient */bool bAnimationPlaybackInterrupted;
	public bool bIsInMeleeState;
	public bool bIsFirstBackupTestToTheSide;
	public bool bUsingBackupDir;
	public bool bHasBackupDir;
	public bool scriptingActivated;
	public bool finishedScriptedMove;
	public/*(BotControl)*/ bool bDoAimingLag;
	public/*(BotDebugging)*/ bool bDrawAimingLines;
	public/*(Debug)*/ /*config */bool bAILogging;
	public/*(Debug)*/ /*config */bool bAILogToWindow;
	public bool bPlayerInvisibleToAI;
	public bool TabsOutOfSync;
	public bool bEnemyDead;
	public bool bAllowStumbleRotation;
	public bool bDebugLineOfSight;
	public /*config */bool bUseVoiceOver;
	public bool bMuted;
	public /*private */float ForceKeepMovingEndedTimeStamp;
	public /*protected */float fMinCombatDistance;
	public /*protected */float fMaxCombatDistance;
	public /*protected */float fPreferredCombatDistance;
	public /*protected */int iRecursionGuard;
	public int MaxDistFromLineToBlock;
	public AITeam Team;
	public float fLookbackTime;
	public AITemplate myTemplate;
	public array<string> myScreenLog;
	public TdAimBotBase AimBot;
	public/*()*/ /*editinline */TdAimBotBase RealAimBot;
	public TdAimBotBase PerfectAimBot;
	public Actor ScriptedAimTarget;
	public TdPawn myEnemy;
	public /*protected */Object.Vector PredictedEnemyLocation;
	public array<NavigationPoint> OccupiedNodes;
	public int PathNetworkMask;
	public array<ReachSpec> OldPath;
	public NavigationPoint OldAnchor;
	public TdAIController.StoredMovementVarsStruct StoredMovementVars;
	public TdAI_Riot ShieldMaster;
	public /*private */Object.Vector ShieldWallLocation;
	public Object.Vector tempVector;
	public float tempFloat;
	public int tempInt;
	public float StandUpTimeStamp;
	public float CrouchRange;
	public float ExitedMelee;
	public float EnteredMelee;
	public float ExitMeleeDelay;
	public TdFocusHandler PawnFocus;
	public TdHeadFocusHandler HeadFocus;
	public int HeadFocusPointCount;
	public NavigationPoint GuardSpot;
	public Route PatrolRoute;
	public NavigationPoint ReachablePlayerNavigationPoint;
	public NavigationPoint GoodFiringPosition;
	public NavigationPoint TempGoodFiringPosition;
	public TdPathLimits PathLimits;
	public /*private */float fCurrentRouteDistance;
	public int VisiblePointsIndex;
	public float WeaponFiredTimeStamp;
	public float AdvanceTimer;
	public float EnemyDistance;
	public float EnemyDistance2d;
	public float EnemyDistanceSq;
	public Object.Vector EnemyDir;
	public Object.Vector EnemyDir2D;
	public float EnemyDot;
	public TdCoverController CoverController;
	public TdAIGrenadeController GrenadeController;
	public float OkToTryAgainTimeStamp;
	public Object.Vector LastFailedPathLocation;
	public Object.Vector LastReachableEnemyPos;
	public /*protected */TdBotPawn BlockingPawn;
	public /*private */float CheckedBlockingPawnTimeStamp;
	public float EnemySeenLastTime;
	public Object.Vector LastActuallySeenLocation;
	public float MeleePredictionTime;
	public TdPlayerPawn Player;
	public TdPlayerController PlayerController;
	public float PlayerLookingTowardsMeDot;
	public float PlayerLookingTowardsMeTimeStamp;
	public float TimeSincePlayerLookedAtMe;
	public /*private */float EnemyNotVisibleTimeStamp;
	public Object.Rotator AimingRotation;
	public/*(Suppression)*/ float SuppressionRecoveryTime;
	public/*(Suppression)*/ float SuppressionDeclineTime;
	public/*(Suppression)*/ float SuppressionDistance;
	public/*(Suppression)*/ float SuppressionFactorForDirectHit;
	public float Suppression;
	public /*private */float KeepFiringTime;
	public/*()*/ int RotationSpeedCFG;
	public Actor MoveGoal;
	public Object.Vector MovePoint;
	public Object.Vector PathfindingGoalPos;
	public Object.Vector StartingLocation;
	public float MoveOffset;
	public int UpdatePathInFrames;
	public Actor OldMoveTarget;
	public /*private */float MoveToGoalTimeStamp;
	public float LastShouldRunTimeStamp;
	public /*const */float AdvanceTime;
	public /*protected */float fTimeUntilPlayerWithinMeleeRange;
	public Actor tempDest;
	public TdCover CurrentCover;
	public CoverGroup ActiveCoverGroup;
	public Object.Vector OldFocalPoint;
	public /*protected */float PopulatedPathsCost;
	public name MeleeState;
	public Object.Vector BackupDir;
	public TdBubbleStack Interruptable;
	public Object.Vector tempMovePos;
	public Actor tempMoveToActor;
	public Object.Vector temporaryMovePos;
	public/*(BotControl)*/ /*config */float BotAimingLag;
	public /*private transient */int DifficultyLevel;
	public float lastLogTime;
	public name lastLogStateName;
	public FileLog AILogFile;
	public /*config */array</*config */name> AILogFilter;
	public int logTabs;
	public /*config */array</*config */name> ScreenLogFilter;
	public string DebugString;
	public string DebugString2;
	public float LastStumbleTime;
	public Actor ActorBlockingLineOfSight;
	public float CurrentAimDispersion;
	public TdBotPawn myPawn;
	public TdAIVoiceOverManager VoiceOverManager;
	public TdAIManager AIManager;
	public int voice;
	public/*(Melee)*/ /*editinline */TdMove_BotMelee BotMeleeMove;
	public array<SeqEvt_TdWeaponFired> WeaponFiredEvents;
	
	// Export UTdAIController::execCurrentRouteDist(FFrame&, void* const)
	public virtual /*private native final function */float CurrentRouteDist()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execCheckRemainingPathLength(FFrame&, void* const)
	public virtual /*native final function */float CheckRemainingPathLength(float AngularLimit)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execFindGoodFiringPosition(FFrame&, void* const)
	public virtual /*native final function */NavigationPoint FindGoodFiringPosition(int NetworkID, /*optional */Class? _RequiredClass = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execFindSuppressionSpot(FFrame&, void* const)
	public virtual /*native final function */TdSuppressionSpot FindSuppressionSpot()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execIsFiringPositionUsed(FFrame&, void* const)
	public virtual /*native final function */bool IsFiringPositionUsed(NavigationPoint Nav)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execSetCoverAction(FFrame&, void* const)
	public virtual /*native final latent function */Flow SetCoverAction(byte CoverAction)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execNextNodeIsJumpNode(FFrame&, void* const)
	public virtual /*native final function */bool NextNodeIsJumpNode()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execShouldForceSpeed(FFrame&, void* const)
	public virtual /*native final function */bool ShouldForceSpeed()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execGetForcedSpeed(FFrame&, void* const)
	public virtual /*native final function */float GetForcedSpeed(ref Object.Vector EndLocation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execTdDrawDebugLine(FFrame&, void* const)
	public /*native final function */static void TdDrawDebugLine(Object.Vector LineStart, Object.Vector LineEnd, byte R, byte G, byte B)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execTdDrawDebugSphere(FFrame&, void* const)
	public /*native final function */static void TdDrawDebugSphere(Object.Vector Center, float Radius, int Segments, byte R, byte G, byte B)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execTdFlushLines(FFrame&, void* const)
	public /*native final function */static void TdFlushLines()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execThrowGrenade(FFrame&, void* const)
	public virtual /*native final latent function */Flow ThrowGrenade()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execTdMoveTo(FFrame&, void* const)
	public virtual /*native final latent function */Flow TdMoveTo(Object.Vector NewDestination, /*optional */Actor? _ViewFocus = default, /*optional */bool? _bShouldWalk = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execPointReachableFrom(FFrame&, void* const)
	public virtual /*native final function */bool PointReachableFrom(Object.Vector Start, Object.Vector End)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execIsForcedToWalkToNextNode(FFrame&, void* const)
	public virtual /*native final function */bool IsForcedToWalkToNextNode(/*optional */int? _NodeOffset = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execEnoughSpaceForStartMove(FFrame&, void* const)
	public virtual /*native function */bool EnoughSpaceForStartMove(float SpaceNeeded)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execWillShotHitPlayer(FFrame&, void* const)
	public virtual /*native final function */bool WillShotHitPlayer(TdPlayerPawn PlayerPawn, Object.Vector StartLocation, Object.Vector AimRotation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execHaveAValidCoverPath(FFrame&, void* const)
	public virtual /*native function */bool HaveAValidCoverPath()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void AddSpecialOutput(ref string Text)
	{
	
	}
	
	public delegate void UpdateMoveToActorPosition_del();
	public virtual UpdateMoveToActorPosition_del UpdateMoveToActorPosition { get => bfield_UpdateMoveToActorPosition ?? TdAIController_UpdateMoveToActorPosition; set => bfield_UpdateMoveToActorPosition = value; } UpdateMoveToActorPosition_del bfield_UpdateMoveToActorPosition;
	public virtual UpdateMoveToActorPosition_del global_UpdateMoveToActorPosition => TdAIController_UpdateMoveToActorPosition;
	public /*function */void TdAIController_UpdateMoveToActorPosition()
	{
	
	}
	
	public virtual /*event */void AddToScreenLog(string Text, /*optional */name? _Category = default)
	{
	
	}
	
	public virtual /*function */bool IsFiltered(name Category)
	{
	
		return default;
	}
	
	public virtual /*function */void ToggleScreenLogFilter(name Category)
	{
	
	}
	
	public virtual /*function */void ToggleAILogFilter(name Category)
	{
	
	}
	
	public virtual /*function */void DrawScreenLog(Canvas aCanvas)
	{
	
	}
	
	public virtual /*function */void ClearScreenLog()
	{
	
	}
	
	public virtual /*function */void ToggleDebugHalt()
	{
	
	}
	
	public virtual /*function */void ToggleDebugLineOfSight()
	{
	
	}
	
	public virtual /*function */void DrawDebugInfo(PlayerController PlayerC, Canvas aCanvas)
	{
	
	}
	
	public virtual /*function */void DrawLatentAction(ref string Text)
	{
	
	}
	
	public virtual /*function */void DrawOldPath()
	{
	
	}
	
	// Export UTdAIController::execDrawPath(FFrame&, void* const)
	public virtual /*native final function */void DrawPath()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void DrawPathnodesCloseToCamera(Canvas aCanvas)
	{
	
	}
	
	public virtual /*function */void DrawGages(Canvas aCanvas)
	{
	
	}
	
	public virtual /*function */void DrawNavigationCost(PlayerController PlayerC, Canvas aCanvas)
	{
	
	}
	
	public virtual /*function */void DrawNeighbourCosts(PlayerController PlayerC, Canvas aCanvas, NavigationPoint Node, ref array<NavigationPoint> out_Visited)
	{
	
	}
	
	public virtual /*function */void DrawReachSpecCost(PlayerController PlayerC, Canvas aCanvas, TdReachSpec Spec)
	{
	
	}
	
	public virtual /*function */void DebugMeleeDamageBot(TdPlayerController PC)
	{
	
	}
	
	public virtual /*function */void ShowAimingLines()
	{
	
	}
	
	public virtual /*final event */void AILog_Internal(/*coerce */string LogText, /*optional */name? _LogCategory = default, /*optional */bool? _bForce = default)
	{
	
	}
	
	public virtual /*final function */void LogFunction_Internal(/*coerce */string FuncName, bool Start, /*coerce optional */string? _S = default, /*optional */name? _LogCategory = default)
	{
	
	}
	
	public virtual /*function */bool TdPointReachable(Object.Vector aPoint, /*optional */bool? _bTestBotPawns = default, /*optional */float? _minTimeToCollision = default, /*optional */float? _minDistFromLine = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool TdActorReachable(Actor anActor, /*optional */bool? _bTestBotPawns = default, /*optional */float? _minTimeToCollision = default, /*optional */float? _minDistFromLine = default)
	{
	
		return default;
	}
	
	public virtual /*function */Object.Vector GetPredictedEnemyLocation()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsPredictedEnemyReachable(/*optional */bool? _bTestBotPawns = default)
	{
	
		return default;
	}
	
	public virtual /*function */void HoldFire(bool flag)
	{
	
	}
	
	public virtual /*function */void UnholdFire()
	{
	
	}
	
	public virtual /*function */void SetBossStage(int stage)
	{
	
	}
	
	public virtual /*function */bool IsLastActuallySeenLocationWithinDot(float dotValue)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsEnemyWithinDot(float dotValue)
	{
	
		return default;
	}
	
	public virtual /*event */void Crouch(bool flag)
	{
	
	}
	
	public virtual /*function */bool UpdatePath()
	{
	
		return default;
	}
	
	public virtual /*function */void AbortMoveTo()
	{
	
	}
	
	public virtual /*function */void AbortMovement()
	{
	
	}
	
	public virtual /*function */bool IsInLatentMovement()
	{
	
		return default;
	}
	
	// Export UTdAIController::execIsMoving(FFrame&, void* const)
	public virtual /*native function */bool IsMoving()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool IsRunning()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsInMelee()
	{
	
		return default;
	}
	
	public virtual /*function */void Pause()
	{
	
	}
	
	public virtual /*function */bool HasShield()
	{
	
		return default;
	}
	
	public virtual /*event */name GetCurrentStateName()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsCurrentStateInterruptable()
	{
	
		return default;
	}
	
	public virtual /*function */void SetInterruptable(bool flag, name Identifier)
	{
	
	}
	
	public virtual /*function */void SetPawnRotation(Object.Rotator PawnRotation)
	{
	
	}
	
	public virtual /*function */void SetLocationXY(Object.Vector PawnLocation)
	{
	
	}
	
	public virtual /*function */bool IsAtEnd(Object.Vector Start, Object.Vector End)
	{
	
		return default;
	}
	
	public virtual /*function */void ClientMessage(/*coerce */string S)
	{
	
	}
	
	public virtual /*function */Object.Vector vec3(float X, float Y, float Z)
	{
	
		return default;
	}
	
	public virtual /*function */Object.Vector GetLeftEnemyDir()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsEnemyLookingAtMe2D(float dotLimit)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsEnemyAimingAtMe(float Dist)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsPointAwayFromEnemy(Object.Vector P)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsEnemy(Controller C)
	{
	
		return default;
	}
	
	// Export UTdAIController::execGetCombatDistance(FFrame&, void* const)
	public virtual /*native function */float GetCombatDistance()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */float GetPreferredCombatDistance()
	{
	
		return default;
	}
	
	// Export UTdAIController::execAllowFocusRotation(FFrame&, void* const)
	public virtual /*native final function */bool AllowFocusRotation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */bool IsFriendlyPawn(Pawn TestPlayer)
	{
	
		return default;
	}
	
	public virtual /*function */void Halt()
	{
	
	}
	
	public virtual /*function */void Freeze()
	{
	
	}
	
	public virtual /*function */void ForceKeepMoving(bool flag)
	{
	
	}
	
	public virtual /*function */bool IsForcedToKeepMoving()
	{
	
		return default;
	}
	
	// Export UTdAIController::execDrawTimeline(FFrame&, void* const)
	public virtual /*native final function */void DrawTimeline(Canvas aCanvas)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execRemoveFromTimeline(FFrame&, void* const)
	public virtual /*native final function */void RemoveFromTimeline()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execDrawNavigation(FFrame&, void* const)
	public virtual /*native final function */void DrawNavigation()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override Possess_del Possess { get => bfield_Possess ?? TdAIController_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public override Possess_del global_Possess => TdAIController_Possess;
	public /*event */void TdAIController_Possess(Pawn inPawn, bool bVehicleTransition)
	{
	
	}
	
	public override /*event */void UnPossess()
	{
	
	}
	
	public virtual /*event */void Initialize()
	{
	
	}
	
	public virtual /*function */void ResetAI()
	{
	
	}
	
	public virtual /*function */TdAimBotBase CreateAimBot()
	{
	
		return default;
	}
	
	public delegate void Say_del(int VO, /*optional */float? _probability = default, /*optional */int? _answer = default, /*optional */float? _answerprob = default);
	public virtual Say_del Say { get => bfield_Say ?? TdAIController_Say; set => bfield_Say = value; } Say_del bfield_Say;
	public virtual Say_del global_Say => TdAIController_Say;
	public /*event */void TdAIController_Say(int VO, /*optional */float? _probability = default, /*optional */int? _answer = default, /*optional */float? _answerprob = default)
	{
	
	}
	
	// Export UTdAIController::execClosestFriend(FFrame&, void* const)
	public virtual /*native final function */TdAIController ClosestFriend()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override PawnDied_del PawnDied { get => bfield_PawnDied ?? TdAIController_PawnDied; set => bfield_PawnDied = value; } PawnDied_del bfield_PawnDied;
	public override PawnDied_del global_PawnDied => TdAIController_PawnDied;
	public /*function */void TdAIController_PawnDied(Pawn inPawn)
	{
	
	}
	
	public virtual /*function */void ReportBotDied()
	{
	
	}
	
	public override NotifyKilled_del NotifyKilled { get => bfield_NotifyKilled ?? TdAIController_NotifyKilled; set => bfield_NotifyKilled = value; } NotifyKilled_del bfield_NotifyKilled;
	public override NotifyKilled_del global_NotifyKilled => TdAIController_NotifyKilled;
	public /*function */void TdAIController_NotifyKilled(Controller Killer, Controller Killed, Pawn KilledPawn)
	{
	
	}
	
	public virtual /*function */void NotifyEnemyKilled()
	{
	
	}
	
	public delegate void NotifyStumbleComplete_del();
	public virtual NotifyStumbleComplete_del NotifyStumbleComplete { get => bfield_NotifyStumbleComplete ?? TdAIController_NotifyStumbleComplete; set => bfield_NotifyStumbleComplete = value; } NotifyStumbleComplete_del bfield_NotifyStumbleComplete;
	public virtual NotifyStumbleComplete_del global_NotifyStumbleComplete => TdAIController_NotifyStumbleComplete;
	public /*function */void TdAIController_NotifyStumbleComplete()
	{
	
	}
	
	public virtual /*event */void OnNewTeam(AITeam NewTeam)
	{
	
	}
	
	public virtual /*event */void OnMute(bool bMute)
	{
	
	}
	
	public virtual /*final function */int GetDifficultyLevel()
	{
	
		return default;
	}
	
	public virtual /*event */void UpdateDifficultyLevel()
	{
	
	}
	
	public virtual /*function */void SetDifficultyLevel(int Difficulty)
	{
	
	}
	
	public virtual /*final function */int RetrieveDifficultyLevel()
	{
	
		return default;
	}
	
	public virtual /*simulated event */int SetupTemplate(AITemplate TheTemplate)
	{
	
		return default;
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdAIController_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdAIController_Reset;
	public /*function */void TdAIController_Reset()
	{
	
	}
	
	public override /*function */void Restart(bool bVehicleTransition)
	{
	
	}
	
	public virtual /*function */bool IsOkToUpdatePath()
	{
	
		return default;
	}
	
	public virtual /*function */bool AreFlagsOkForPathUpdate()
	{
	
		return default;
	}
	
	public delegate bool OkToDoStartMove_del();
	public virtual OkToDoStartMove_del OkToDoStartMove { get => bfield_OkToDoStartMove ?? TdAIController_OkToDoStartMove; set => bfield_OkToDoStartMove = value; } OkToDoStartMove_del bfield_OkToDoStartMove;
	public virtual OkToDoStartMove_del global_OkToDoStartMove => TdAIController_OkToDoStartMove;
	public /*function */bool TdAIController_OkToDoStartMove()
	{
	
		return default;
	}
	
	public virtual /*function */float GetCurrentRouteDist()
	{
	
		return default;
	}
	
	public virtual /*function */bool CurrentRouteContainsMoves()
	{
	
		return default;
	}
	
	// Export UTdAIController::execUpdateCurrentRouteDist(FFrame&, void* const)
	public virtual /*native final function */void UpdateCurrentRouteDist()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void UpdateCurrentRouteDistDirect(Object.Vector Goal)
	{
	
	}
	
	public virtual /*event */Object.Vector GetMoveToDestination()
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyGrenadeExploded(Object.Vector ExplosionLocation, float Lifetime)
	{
	
	}
	
	// Export UTdAIController::execPreSuperTick(FFrame&, void* const)
	public virtual /*native final function */void PreSuperTick(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execPostSuperTick(FFrame&, void* const)
	public virtual /*native final function */void PostSuperTick(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAIController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAIController_Tick;
	public /*event */void TdAIController_Tick(float DeltaTime)
	{
	
	}
	
	// Export UTdAIController::execUpdateAnchor(FFrame&, void* const)
	public virtual /*native function */void UpdateAnchor()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execSetBestAnchor(FFrame&, void* const)
	public virtual /*native function */void SetBestAnchor()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */void NoReachableAnchor()
	{
	
	}
	
	public virtual /*function */bool TryToTeleportToNearestAnchor()
	{
	
		return default;
	}
	
	public virtual /*function */void ForceNewPath()
	{
	
	}
	
	public virtual /*function */void UpdateFiringMood()
	{
	
	}
	
	// Export UTdAIController::execUpdateAggressionLevel(FFrame&, void* const)
	public virtual /*native final function */void UpdateAggressionLevel()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execUpdateCombatDistances(FFrame&, void* const)
	public virtual /*native function */void UpdateCombatDistances()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void UpdatePawnFocus_del();
	public virtual UpdatePawnFocus_del UpdatePawnFocus { get => bfield_UpdatePawnFocus ?? TdAIController_UpdatePawnFocus; set => bfield_UpdatePawnFocus = value; } UpdatePawnFocus_del bfield_UpdatePawnFocus;
	public virtual UpdatePawnFocus_del global_UpdatePawnFocus => TdAIController_UpdatePawnFocus;
	public /*function */void TdAIController_UpdatePawnFocus()
	{
	
	}
	
	public virtual /*function */void SetWantedFocus(TdFocusHandler.FocusType F)
	{
	
	}
	
	public virtual /*function */void SetFocus(TdFocusHandler.FocusType F)
	{
	
	}
	
	public delegate void UpdatePose_del();
	public virtual UpdatePose_del UpdatePose { get => bfield_UpdatePose ?? TdAIController_UpdatePose; set => bfield_UpdatePose = value; } UpdatePose_del bfield_UpdatePose;
	public virtual UpdatePose_del global_UpdatePose => TdAIController_UpdatePose;
	public /*function */void TdAIController_UpdatePose()
	{
	
	}
	
	public virtual /*function */void SetWantedPose(TdBotPawn.EPose P)
	{
	
	}
	
	public virtual /*function */void SetPose(TdBotPawn.EPose P)
	{
	
	}
	
	public virtual /*event */void SetRotationReduction(float reductionFactor)
	{
	
	}
	
	public virtual /*final function */void DebugGotoState(name NewState, /*optional */name? _Label = default, /*optional */string? _Reason = default, /*optional */bool? _bForceEvents = default, /*optional */bool? _ForceStateChange = default)
	{
	
	}
	
	public virtual /*protected final function */void TdGotoState(name NewState, /*optional */name? _Label = default, /*optional */string? _Reason = default, /*optional */bool? _bForceEvents = default, /*optional */bool? _ForceStateChange = default)
	{
	
	}
	
	public virtual /*protected final function */void TdPushState(name NewState, /*optional */name? _NewLabel = default, /*optional */string? _Reason = default, /*optional */bool? _ForceStateChange = default)
	{
	
	}
	
	public delegate void TestCombatTransitions_del();
	public virtual TestCombatTransitions_del TestCombatTransitions { get => bfield_TestCombatTransitions ?? TdAIController_TestCombatTransitions; set => bfield_TestCombatTransitions = value; } TestCombatTransitions_del bfield_TestCombatTransitions;
	public virtual TestCombatTransitions_del global_TestCombatTransitions => TdAIController_TestCombatTransitions;
	public /*function */void TdAIController_TestCombatTransitions()
	{
	
	}
	
	public virtual /*function */bool CanSearch()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanInvestigate()
	{
	
		return default;
	}
	
	public override /*function */bool IsInCombat()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateCombatState()
	{
	
	}
	
	public virtual /*function */void StartTestingCombatTransitions()
	{
	
	}
	
	public virtual /*event */void ExposePlayer()
	{
	
	}
	
	public override SeePlayer_del SeePlayer { get => bfield_SeePlayer ?? TdAIController_SeePlayer; set => bfield_SeePlayer = value; } SeePlayer_del bfield_SeePlayer;
	public override SeePlayer_del global_SeePlayer => TdAIController_SeePlayer;
	public /*event */void TdAIController_SeePlayer(Pawn P)
	{
	
	}
	
	public delegate void HandleEnemySeen_del(Pawn aPawn);
	public virtual HandleEnemySeen_del HandleEnemySeen { get => bfield_HandleEnemySeen ?? TdAIController_HandleEnemySeen; set => bfield_HandleEnemySeen = value; } HandleEnemySeen_del bfield_HandleEnemySeen;
	public virtual HandleEnemySeen_del global_HandleEnemySeen => TdAIController_HandleEnemySeen;
	public /*function */void TdAIController_HandleEnemySeen(Pawn aPawn)
	{
	
	}
	
	public virtual /*function */void HandleSuspectSpotted(Pawn aPawn)
	{
	
	}
	
	public virtual /*function */void HandleEnemyExposed(Pawn aPawn)
	{
	
	}
	
	public override /*event */void EnemyNotVisible()
	{
	
	}
	
	public virtual /*function */bool HasAnyEnemies()
	{
	
		return default;
	}
	
	public virtual /*function */void SetEnemy(Pawn NewEnemy)
	{
	
	}
	
	public virtual /*event */void NotifyEnemyVisibilityChange(bool visible)
	{
	
	}
	
	public virtual /*function */void TestLastKnownLocationVisible()
	{
	
	}
	
	public delegate void NotifyDamage_del(Controller InstigatedBy, Core.ClassT<DamageType> DamageType, int Damage);
	public virtual NotifyDamage_del NotifyDamage { get => bfield_NotifyDamage ?? TdAIController_NotifyDamage; set => bfield_NotifyDamage = value; } NotifyDamage_del bfield_NotifyDamage;
	public virtual NotifyDamage_del global_NotifyDamage => TdAIController_NotifyDamage;
	public /*function */void TdAIController_NotifyDamage(Controller InstigatedBy, Core.ClassT<DamageType> DamageType, int Damage)
	{
	
	}
	
	public virtual /*function */void ReportNearMiss(float Distance)
	{
	
	}
	
	public virtual /*function */void AddSuppressionFactor(float S)
	{
	
	}
	
	// Export UTdAIController::execWeAreSuppressed(FFrame&, void* const)
	public virtual /*native final function */bool WeAreSuppressed()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void NotifySuppressed_del();
	public virtual NotifySuppressed_del NotifySuppressed { get => bfield_NotifySuppressed ?? TdAIController_NotifySuppressed; set => bfield_NotifySuppressed = value; } NotifySuppressed_del bfield_NotifySuppressed;
	public virtual NotifySuppressed_del global_NotifySuppressed => TdAIController_NotifySuppressed;
	public /*function */void TdAIController_NotifySuppressed()
	{
	
	}
	
	public override /*event */void HearNoise(float Loudness, Actor NoiseMaker, /*optional */name? _NoiseType = default)
	{
	
	}
	
	public virtual /*function */bool AskToPathfindToEnemy()
	{
	
		return default;
	}
	
	public virtual /*final function */void SucceededPathToEnemy(Object.Vector GoalPosition)
	{
	
	}
	
	public virtual /*final function */void SetFailedPathToEnemy()
	{
	
	}
	
	public virtual /*final function */bool HasEnemyMovedSinceLastFailedPath()
	{
	
		return default;
	}
	
	public virtual /*function */void ResetFocus()
	{
	
	}
	
	public virtual /*function */void NotifyWeaponEmpty()
	{
	
	}
	
	public virtual /*function */void AiReload()
	{
	
	}
	
	// Export UTdAIController::execOkToLaySuppressionFire(FFrame&, void* const)
	public virtual /*native final function */bool OkToLaySuppressionFire()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void NotifyReloaded()
	{
	
	}
	
	public override /*function */void NotifyWeaponFired(Weapon W, byte FireMode)
	{
	
	}
	
	public virtual /*function */void OnWeaponFired(Weapon PawnWeapon)
	{
	
	}
	
	public override SwitchToBestWeapon_del SwitchToBestWeapon { get => bfield_SwitchToBestWeapon ?? TdAIController_SwitchToBestWeapon; set => bfield_SwitchToBestWeapon = value; } SwitchToBestWeapon_del bfield_SwitchToBestWeapon;
	public override SwitchToBestWeapon_del global_SwitchToBestWeapon => TdAIController_SwitchToBestWeapon;
	public /*exec function */void TdAIController_SwitchToBestWeapon(/*optional */bool? _bForceNewWeapon = default)
	{
	
	}
	
	public delegate bool IsOkToFire_del();
	public virtual IsOkToFire_del IsOkToFire { get => bfield_IsOkToFire ?? TdAIController_IsOkToFire; set => bfield_IsOkToFire = value; } IsOkToFire_del bfield_IsOkToFire;
	public virtual IsOkToFire_del global_IsOkToFire => TdAIController_IsOkToFire;
	public /*function */bool TdAIController_IsOkToFire()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanFireFromHere()
	{
	
		return default;
	}
	
	public delegate bool IsWithinAttackAngle_del();
	public virtual IsWithinAttackAngle_del IsWithinAttackAngle { get => bfield_IsWithinAttackAngle ?? TdAIController_IsWithinAttackAngle; set => bfield_IsWithinAttackAngle = value; } IsWithinAttackAngle_del bfield_IsWithinAttackAngle;
	public virtual IsWithinAttackAngle_del global_IsWithinAttackAngle => TdAIController_IsWithinAttackAngle;
	public /*function */bool TdAIController_IsWithinAttackAngle()
	{
	
		return default;
	}
	
	// Export UTdAIController::execShouldKeepFiring(FFrame&, void* const)
	public virtual /*native function */bool ShouldKeepFiring()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execCheckFireCondition(FFrame&, void* const)
	public virtual /*native function */void CheckFireCondition()
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate bool AllowFire_del();
	public virtual AllowFire_del AllowFire { get => bfield_AllowFire ?? TdAIController_AllowFire; set => bfield_AllowFire = value; } AllowFire_del bfield_AllowFire;
	public virtual AllowFire_del global_AllowFire => TdAIController_AllowFire;
	public /*event */bool TdAIController_AllowFire()
	{
	
		return default;
	}
	
	public virtual /*function */void ForceFire(bool bForce)
	{
	
	}
	
	public delegate void StartFiring_del();
	public virtual StartFiring_del StartFiring { get => bfield_StartFiring ?? TdAIController_StartFiring; set => bfield_StartFiring = value; } StartFiring_del bfield_StartFiring;
	public virtual StartFiring_del global_StartFiring => TdAIController_StartFiring;
	public /*function */void TdAIController_StartFiring()
	{
	
	}
	
	public override /*function */void StopFiring()
	{
	
	}
	
	// Export UTdAIController::execIsAIBlockingPath(FFrame&, void* const)
	public virtual /*native final function */TdBotPawn IsAIBlockingPath(Object.Vector pos, /*optional */float? _minTimeToCollision = default, /*optional */float? _minDistFromLine = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execCanSeePlayerFromPoint(FFrame&, void* const)
	public virtual /*native final function */bool CanSeePlayerFromPoint(NavigationPoint np)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated function */void GetPlayerViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
	
	}
	
	// Export UTdAIController::execSelectAdvancePoint(FFrame&, void* const)
	public virtual /*native final function */NavigationPoint SelectAdvancePoint(int NetworkID, /*optional */float? _MaxDist = default, /*optional */float? _MinDist = default, /*optional */Class? _RequiredClass = default, /*optional */bool? _bTestVisibility = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execGetNavpointClosestToPoint(FFrame&, void* const)
	public virtual /*native final function */NavigationPoint GetNavpointClosestToPoint(Object.Vector Point, int NetworkID, /*optional */float? _MaxDist = default, /*optional */float? _MinDist = default, /*optional */float? _MaxDistZ = default, /*optional */float? _MinDistZ = default, /*optional */Class? _RequiredClass = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execCanBeAnchor(FFrame&, void* const)
	public virtual /*native final function */bool CanBeAnchor(NavigationPoint P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execCanBeDestination(FFrame&, void* const)
	public virtual /*native final function */bool CanBeDestination(NavigationPoint P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execGetNearestAnchor(FFrame&, void* const)
	public virtual /*native final function */NavigationPoint GetNearestAnchor()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool IsHitRelevant(Core.ClassT<DamageType> DamageType, name BoneName)
	{
	
		return default;
	}
	
	public override GetAdjustedAimFor_del GetAdjustedAimFor { get => bfield_GetAdjustedAimFor ?? TdAIController_GetAdjustedAimFor; set => bfield_GetAdjustedAimFor = value; } GetAdjustedAimFor_del bfield_GetAdjustedAimFor;
	public override GetAdjustedAimFor_del global_GetAdjustedAimFor => TdAIController_GetAdjustedAimFor;
	public /*function */Object.Rotator TdAIController_GetAdjustedAimFor(Weapon iWeapon, Object.Vector StartFireLocation)
	{
	
		return default;
	}
	
	public virtual /*event */void TdVaultOver()
	{
	
	}
	
	public virtual /*event */void TdSpeedVault()
	{
	
	}
	
	public virtual /*event */void TdJump()
	{
	
	}
	
	public virtual /*event */void TdShortJump()
	{
	
	}
	
	public virtual /*event */void TdMediumJump()
	{
	
	}
	
	public virtual /*event */void TdLongJump()
	{
	
	}
	
	public virtual /*event */void TdGrabHeave()
	{
	
	}
	
	public virtual /*event */void Slide(Object.Vector EndTarget)
	{
	
	}
	
	public virtual /*event */void StopSlide()
	{
	
	}
	
	public delegate bool NotifyPrepareForMeleeAttack_del(Core.ClassT<DamageType> MeleeDamageType);
	public virtual NotifyPrepareForMeleeAttack_del NotifyPrepareForMeleeAttack { get => bfield_NotifyPrepareForMeleeAttack ?? TdAIController_NotifyPrepareForMeleeAttack; set => bfield_NotifyPrepareForMeleeAttack = value; } NotifyPrepareForMeleeAttack_del bfield_NotifyPrepareForMeleeAttack;
	public virtual NotifyPrepareForMeleeAttack_del global_NotifyPrepareForMeleeAttack => TdAIController_NotifyPrepareForMeleeAttack;
	public /*function */bool TdAIController_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
	
		return default;
	}
	
	public virtual /*function */void StartBlocking()
	{
	
	}
	
	public virtual /*function */void OnStoppedBlocking()
	{
	
	}
	
	public virtual /*function */void OnStumble(bool bAllowRotation)
	{
	
	}
	
	public virtual /*function */void OnStumbleEnded()
	{
	
	}
	
	public virtual /*function */void OnMeleedFromAir()
	{
	
	}
	
	public virtual /*function */void OnDisarmed()
	{
	
	}
	
	public virtual /*function */TdAIController.EDisarmState QueryDisarmState(TdPawn Disarmer)
	{
	
		return default;
	}
	
	public virtual /*function */bool StartCannedMove(int Move)
	{
	
		return default;
	}
	
	public virtual /*function */void TriggerCannedAnim(int Move, name CannedAnimationName)
	{
	
	}
	
	public virtual /*function */void StorePathfindingParams()
	{
	
	}
	
	public virtual /*function */void SetPathfindingParams(bool UseSaferPaths, bool AvoidPopulatedPaths)
	{
	
	}
	
	public virtual /*function */void RestorePathfindingParams()
	{
	
	}
	
	public virtual /*function */bool TdFindPathToward(Actor anActor)
	{
	
		return default;
	}
	
	public virtual /*function */void TdFindPathTo(Object.Vector aPoint)
	{
	
	}
	
	public virtual /*event */void ClearMovementFlags()
	{
	
	}
	
	// Export UTdAIController::execSetWalkingToNode(FFrame&, void* const)
	public virtual /*native final function */void SetWalkingToNode(bool flag)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execIsWalkingToNode(FFrame&, void* const)
	public virtual /*native final function */bool IsWalkingToNode()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void ClearRouteCache()
	{
	
	}
	
	public virtual /*function */void BackupPath()
	{
	
	}
	
	public virtual /*event */void ClearOldPath()
	{
	
	}
	
	public virtual /*function */void StoreMovementVariables()
	{
	
	}
	
	public virtual /*function */void RestoreMovementVariables()
	{
	
	}
	
	public virtual /*function */void ClearMovementVariables()
	{
	
	}
	
	public virtual /*function */void OccupyPath()
	{
	
	}
	
	public virtual /*function */void UnoccupyPath()
	{
	
	}
	
	public virtual /*function */void RemoveFromOccupied(NavigationPoint P)
	{
	
	}
	
	public virtual /*function */void ClearPathFor(Controller C)
	{
	
	}
	
	public virtual /*function */bool AdjustAround(Pawn Other)
	{
	
		return default;
	}
	
	public virtual /*function */void EnableBumps()
	{
	
	}
	
	public virtual /*function */Object.Vector GetFloor()
	{
	
		return default;
	}
	
	public virtual /*function */float GetGrabJumpTime()
	{
	
		return default;
	}
	
	public virtual /*function */void SetCameraRotationAid(Object.Rotator desiredRot)
	{
	
	}
	
	public virtual /*function */void SetIsInCover(bool bActivateInCover)
	{
	
	}
	
	public virtual /*event */bool ForceShootAt(TdExplosiveTargetArea TargetArea)
	{
	
		return default;
	}
	
	public virtual /*event */bool ForceGrenadeThrow(TdGrenadeTargetArea TargetArea)
	{
	
		return default;
	}
	
	public virtual /*event */bool ThrowGrenadeRequest(TdGrenadeTargetArea TargetArea)
	{
	
		return default;
	}
	
	public virtual /*function */void OnAIThrowGrenade(SeqAct_AIThrowGrenade seqAct)
	{
	
	}
	
	public delegate bool IsThrowingKismetTriggeredGrenade_del();
	public virtual IsThrowingKismetTriggeredGrenade_del IsThrowingKismetTriggeredGrenade { get => bfield_IsThrowingKismetTriggeredGrenade ?? TdAIController_IsThrowingKismetTriggeredGrenade; set => bfield_IsThrowingKismetTriggeredGrenade = value; } IsThrowingKismetTriggeredGrenade_del bfield_IsThrowingKismetTriggeredGrenade;
	public virtual IsThrowingKismetTriggeredGrenade_del global_IsThrowingKismetTriggeredGrenade => TdAIController_IsThrowingKismetTriggeredGrenade;
	public /*event */bool TdAIController_IsThrowingKismetTriggeredGrenade()
	{
	
		return default;
	}
	
	public virtual /*event */void WaitForKismetCommand()
	{
	
	}
	
	public virtual /*function */void StartScriptedFire(Actor ScriptedTarget)
	{
	
	}
	
	public virtual /*function */void CoverGoToState(string iState)
	{
	
	}
	
	public virtual /*function */void MoveToPos(Object.Vector pos)
	{
	
	}
	
	public virtual /*function */void WalkToPos(Object.Vector pos)
	{
	
	}
	
	public virtual /*function */void RunToPos(Object.Vector pos)
	{
	
	}
	
	public virtual /*function */void MoveStraightToPos(Object.Vector pos)
	{
	
	}
	
	public virtual /*function */void MoveStraightToActor(Actor TargetActor)
	{
	
	}
	
	public virtual /*function */void ActivateStasis(bool flag, bool UpdateState)
	{
	
	}
	
	public delegate void AdvanceTimerCallback_del();
	public virtual AdvanceTimerCallback_del AdvanceTimerCallback { get => bfield_AdvanceTimerCallback ?? TdAIController_AdvanceTimerCallback; set => bfield_AdvanceTimerCallback = value; } AdvanceTimerCallback_del bfield_AdvanceTimerCallback;
	public virtual AdvanceTimerCallback_del global_AdvanceTimerCallback => TdAIController_AdvanceTimerCallback;
	public /*function */void TdAIController_AdvanceTimerCallback()
	{
	
	}
	
	public virtual /*function */void ReportAdvancing(Object.Vector Dest)
	{
	
	}
	
	public virtual /*function */void ReportMoveBack(int VO)
	{
	
	}
	
	public virtual /*function */bool ShouldWeAdvance()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsOkToRun()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsReadyToMove()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateWalking()
	{
	
	}
	
	public virtual /*function */void TestAdvanceMovement()
	{
	
	}
	
	public virtual /*private final function */void UpdateAdvanceState(name Label, string Reason)
	{
	
	}
	
	public virtual /*function */bool IsEnemyBehindMe()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldBackaway()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldMoveIn()
	{
	
		return default;
	}
	
	public virtual /*event */void NotifyNewPlayerNavigationPoint()
	{
	
	}
	
	public virtual /*function */bool IsEnemyOnDifferentNetwork()
	{
	
		return default;
	}
	
	public virtual /*function */bool RandomCrouch()
	{
	
		return default;
	}
	
	public virtual /*function */bool AskToCrouch()
	{
	
		return default;
	}
	
	public delegate void CheckCrouching_del();
	public virtual CheckCrouching_del CheckCrouching { get => bfield_CheckCrouching ?? TdAIController_CheckCrouching; set => bfield_CheckCrouching = value; } CheckCrouching_del bfield_CheckCrouching;
	public virtual CheckCrouching_del global_CheckCrouching => TdAIController_CheckCrouching;
	public /*function */void TdAIController_CheckCrouching()
	{
	
	}
	
	public virtual /*function */void BeginAdvance()
	{
	
	}
	
	public virtual /*function */void EndAdvance()
	{
	
	}
	
	public virtual /*function */Object.Vector GetAdvancePoint()
	{
	
		return default;
	}
	
	public virtual /*function */bool CheckBackupDirectionValid(Object.Vector Dir)
	{
	
		return default;
	}
	
	public override /*event */bool NotifyHitWall(Object.Vector HitNormal, Actor Wall)
	{
	
		return default;
	}
	
	public override /*event */void HitWall(Object.Vector HitNormal, Actor Wall, PrimitiveComponent WallComp)
	{
	
	}
	
	public override /*event */bool NotifyBump(Actor Other, Object.Vector HitNormal)
	{
	
		return default;
	}
	
	public virtual /*function */bool FindBackupDirFromHitNormal(Object.Vector HitNormal)
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateBackup()
	{
	
	}
	
	public virtual /*function */bool OkToLookBack()
	{
	
		return default;
	}
	
	public virtual /*function */void LookBack()
	{
	
	}
	
	public virtual /*function */void SetAdvanceAction(TdAIController.AdvanceAction aa)
	{
	
	}
	
	public virtual /*function */bool FindBackupDir()
	{
	
		return default;
	}
	
	public virtual /*function */Object.Vector GetFindLineOfFirePos(float Dist)
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyPlayerReachable()
	{
	
	}
	
	public virtual /*function */bool ShouldGetWithinPathlimits()
	{
	
		return default;
	}
	
	public virtual /*function */bool EnemyHarmless()
	{
	
		return default;
	}
	
	public delegate bool ShouldEnterMelee_del(float Range);
	public virtual ShouldEnterMelee_del ShouldEnterMelee { get => bfield_ShouldEnterMelee ?? TdAIController_ShouldEnterMelee; set => bfield_ShouldEnterMelee = value; } ShouldEnterMelee_del bfield_ShouldEnterMelee;
	public virtual ShouldEnterMelee_del global_ShouldEnterMelee => TdAIController_ShouldEnterMelee;
	public /*function */bool TdAIController_ShouldEnterMelee(float Range)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsPredictedPositionWithinMeleeRange(float Range)
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyMeleeFinished()
	{
	
	}
	
	public virtual /*function */bool ShouldDoSecondSwing()
	{
	
		return default;
	}
	
	public virtual /*function */bool EnemyIsDisarming()
	{
	
		return default;
	}
	
	public virtual /*function */bool RotationOkForMelee()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateMoveGoal()
	{
	
	}
	
	public virtual /*function */void SetMeleeType(string mt)
	{
	
	}
	
	public virtual /*function */bool UseFullBodyMelee()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateFormationPos(Object.Vector pos)
	{
	
	}
	
	public virtual /*function */void ForceLeaveFormation()
	{
	
	}
	
	public virtual /*function */void LeaveFormation()
	{
	
	}
	
	public virtual /*function */bool IsTrailingBehind()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsTrailingBehindAlot()
	{
	
		return default;
	}
	
	public virtual /*event */void OnStartCustomAnimation(name AnimationName, float PlayRate, float BlendInTime, float BlendOutTime, bool bUseRootMotion, bool bUseRootRotation, bool bLoopAnimation, int FinalAnimationState, bool OverrideAll)
	{
	
	}
	
	public virtual /*event */void OnStopCustomAnimation()
	{
	
	}
	
	public virtual /*event */bool IsInAnimationPlaybackState()
	{
	
		return default;
	}
	
	public virtual /*function */void SetAnimationProperties(name AnimationName, float PlayRate, float BlendInTime, float BlendOutTime, bool bUseRootMotion, bool bUseRootRotation, bool bLoopAnimation, int FinalAnimationState)
	{
	
	}
	
	public virtual /*function */void OnAnimationPlaybackStart()
	{
	
	}
	
	public virtual /*function */void OnAnimationPlaybackExit()
	{
	
	}
	
	public virtual /*function */void StartAnimationPlayback()
	{
	
	}
	
	public virtual /*function */void StopAnimationPlayback()
	{
	
	}
	
	public virtual /*function */void AnimationPlaybackInterrupted()
	{
	
	}
	
	public virtual /*function */void DropCover(bool ShouldNotify, bool bShouldMarkCoverInvalid, /*optional */bool? _bRetreatFromCover = default)
	{
	
	}
	
	public delegate void NotifyCoverDropped_del();
	public virtual NotifyCoverDropped_del NotifyCoverDropped { get => bfield_NotifyCoverDropped ?? TdAIController_NotifyCoverDropped; set => bfield_NotifyCoverDropped = value; } NotifyCoverDropped_del bfield_NotifyCoverDropped;
	public virtual NotifyCoverDropped_del global_NotifyCoverDropped => TdAIController_NotifyCoverDropped;
	public /*function */void TdAIController_NotifyCoverDropped()
	{
	
	}
	
	public virtual /*function */void ClaimCover(TdCover NewCover, /*optional */bool? _CheckCover = default)
	{
	
	}
	
	public virtual /*function */void OnFailedEnterCover()
	{
	
	}
	
	public delegate void CheckCurrentCover_del();
	public virtual CheckCurrentCover_del CheckCurrentCover { get => bfield_CheckCurrentCover ?? TdAIController_CheckCurrentCover; set => bfield_CheckCurrentCover = value; } CheckCurrentCover_del bfield_CheckCurrentCover;
	public virtual CheckCurrentCover_del global_CheckCurrentCover => TdAIController_CheckCurrentCover;
	public /*function */void TdAIController_CheckCurrentCover()
	{
	
	}
	
	public virtual /*function */bool FindClosestCover()
	{
	
		return default;
	}
	
	public virtual /*function */bool FindNewCover(/*optional */float? _minDot = default)
	{
	
		return default;
	}
	
	public virtual /*function */void OnMovementStateChange(name NewState)
	{
	
	}
	
	public delegate void TestExitStumble_del();
	public virtual TestExitStumble_del TestExitStumble { get => bfield_TestExitStumble ?? TdAIController_TestExitStumble; set => bfield_TestExitStumble = value; } TestExitStumble_del bfield_TestExitStumble;
	public virtual TestExitStumble_del global_TestExitStumble => TdAIController_TestExitStumble;
	public /*function */void TdAIController_TestExitStumble()
	{
	
	}
	
	public delegate void UpdateStumbleRotation_del(bool bAllowRotation);
	public virtual UpdateStumbleRotation_del UpdateStumbleRotation { get => bfield_UpdateStumbleRotation ?? TdAIController_UpdateStumbleRotation; set => bfield_UpdateStumbleRotation = value; } UpdateStumbleRotation_del bfield_UpdateStumbleRotation;
	public virtual UpdateStumbleRotation_del global_UpdateStumbleRotation => TdAIController_UpdateStumbleRotation;
	public /*function */void TdAIController_UpdateStumbleRotation(bool bAllowRotation)
	{
	
	}
	
	public override /*function */bool HandlePathObstruction(Actor BlockedBy)
	{
	
		return default;
	}
	
	public virtual /*function */void FireFromCover()
	{
	
	}
	
	public virtual /*function */bool CanSwitchDirection()
	{
	
		return default;
	}
	
	public virtual /*function */void SwitchDirection()
	{
	
	}
	
	public virtual /*function */void MoveToCover(/*optional */bool? _IsTeamManouver = default)
	{
	
	}
	
	public virtual /*function */Object.Vector GetRetreatFromCoverDir()
	{
	
		return default;
	}
	
	public virtual /*function */void ClearExitedCover()
	{
	
	}
	
	public virtual /*function */void AddToMoveTimer(float Time)
	{
	
	}
	
	public virtual /*function */bool OkToMoveDirectlyToPoint()
	{
	
		return default;
	}
	
	public virtual /*function */bool OkToMoveDirectlyToActor()
	{
	
		return default;
	}
	
	public delegate void CheckForceWalk_del();
	public virtual CheckForceWalk_del CheckForceWalk { get => bfield_CheckForceWalk ?? TdAIController_CheckForceWalk; set => bfield_CheckForceWalk = value; } CheckForceWalk_del bfield_CheckForceWalk;
	public virtual CheckForceWalk_del global_CheckForceWalk => TdAIController_CheckForceWalk;
	public /*function */void TdAIController_CheckForceWalk()
	{
	
	}
	
	public virtual /*function */void TimedAbortMove()
	{
	
	}
	
	public virtual /*function */bool ShouldUsePlayerNavigationPoint()
	{
	
		return default;
	}
	
	public virtual /*final function */bool SetMoveLocationEnemy(/*optional */Actor? _NewMoveFocus = default, /*optional */float? _OffsetDist = default, /*optional */bool? _HaltAfterMove = default)
	{
	
		return default;
	}
	
	public virtual /*final event */bool SetMoveGoal(Actor NewMoveGoal, /*optional */Actor? _NewMoveFocus = default, /*optional */float? _OffsetDist = default, /*optional */bool? _HaltAfterMove = default)
	{
	
		return default;
	}
	
	public virtual /*final event */bool SetMovePoint(Object.Vector NewMovePoint, /*optional */Actor? _NewMoveFocus = default, /*optional */float? _OffsetDist = default, /*optional */bool? _HaltAfterMove = default, /*optional */bool? _CanMoveDirectly = default)
	{
	
		return default;
	}
	
	public virtual /*function */void MoveToTarget()
	{
	
	}
	
	public virtual /*function */float GetMoveTimeOutDuration()
	{
	
		return default;
	}
	
	public delegate bool IsAtMoveGoal_del();
	public virtual IsAtMoveGoal_del IsAtMoveGoal { get => bfield_IsAtMoveGoal ?? TdAIController_IsAtMoveGoal; set => bfield_IsAtMoveGoal = value; } IsAtMoveGoal_del bfield_IsAtMoveGoal;
	public virtual IsAtMoveGoal_del global_IsAtMoveGoal => TdAIController_IsAtMoveGoal;
	public /*function */bool TdAIController_IsAtMoveGoal()
	{
	
		return default;
	}
	
	public virtual /*function */void MoveToGoalTimedOut()
	{
	
	}
	
	public virtual /*function */void AdjustRotation()
	{
	
	}
	
	public virtual /*function */void OnSetCoverGroup(SeqAct_SetCoverGroup seqAct)
	{
	
	}
	
	public virtual /*function */void SetCoverGroup(CoverGroup NewGroup)
	{
	
	}
	
	public virtual /*function */void OnTdSetPathLimits(SeqAct_TdSetPathLimits Action)
	{
	
	}
	
	public virtual /*function */void OnTdAIPerfectAim(SeqAct_TdAIPerfectAim Action)
	{
	
	}
	
	public override /*function */void OnAIMoveToActor(SeqAct_AIMoveToActor seqAct)
	{
	
	}
	
	public virtual /*function */void OnTdAIPlayAnimation(SeqAct_TdAIPlayAnimation Action)
	{
	
	}
	
	public virtual /*function */void OnTdTutorialReset(SeqAct_TdTutorialReset Action)
	{
	
	}
	
	public virtual /*function */void OnTdAddAdditionalAnimSets(SeqAct_TdAddAdditionalAnimSets Action)
	{
	
	}
	
	public virtual /*function */void SetImmobile(bool flag)
	{
	
	}
	
	public virtual /*function */void SetStasisMode(bool flag)
	{
	
	}
	
	public virtual /*function */void ScriptActivated(bool Active)
	{
	
	}
	
	// Export UTdAIController::execPointsLeftInPath(FFrame&, void* const)
	public virtual /*native final function */int PointsLeftInPath()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execGetStartPoint(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetStartPoint()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execCanSkipPathNode(FFrame&, void* const)
	public virtual /*native final function */bool CanSkipPathNode(bool testIsSkippable)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void NotifyFalling()
	{
	
	}
	
	// Export UTdAIController::execSkipPathNode(FFrame&, void* const)
	public virtual /*native final simulated function */void SkipPathNode()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execAfterMovePathCleanup(FFrame&, void* const)
	public virtual /*native final simulated function */void AfterMovePathCleanup()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdAIController::execSetMoveTarget(FFrame&, void* const)
	public virtual /*native final simulated function */void SetMoveTarget(Actor A)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void NotifyMoveFinished()
	{
	
	}
	
	public virtual /*function */void NotifySetMove(TdPawn.EMovement OldMove, TdPawn.EMovement NewMove, int iCounter)
	{
	
	}
	
	public virtual /*function */void NotifyMoveChanged(TdPawn.EMovement OldMove, TdPawn.EMovement CurrentMove, int iCounter)
	{
	
	}
	
	public virtual /*function */void NotifyLandingDone()
	{
	
	}
	
	public virtual /*event */void InterruptMovement()
	{
	
	}
	
	public virtual /*event */bool PreStopMove()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldStopAfterMove()
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyBossFightOver()
	{
	
	}
	
	public virtual /*function */void NotifyPawnHasStopped()
	{
	
	}
	
	public virtual /*function */void ToggleCoverCPOL()
	{
	
	}
	
	public virtual /*function */void ToggleCoverDetour()
	{
	
	}
	
	public virtual /*function */void ToggleCoverPath()
	{
	
	}
	
	public virtual /*function */void RecycleBot()
	{
	
	}
	
	// Export UTdAIController::execOkToEvade(FFrame&, void* const)
	public virtual /*native final function */bool OkToEvade()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIController::execOkToBeEvaded(FFrame&, void* const)
	public virtual /*native final function */bool OkToBeEvaded()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void StopHere()
	{
	
	}
	
	public delegate void RunTest_del();
	public virtual RunTest_del RunTest { get => bfield_RunTest ?? (()=>{}); set => bfield_RunTest = value; } RunTest_del bfield_RunTest;
	public virtual RunTest_del global_RunTest => ()=>{};
	
	public delegate int TestCovers_del();
	public virtual TestCovers_del TestCovers { get => bfield_TestCovers ?? (()=>default); set => bfield_TestCovers = value; } TestCovers_del bfield_TestCovers;
	public virtual TestCovers_del global_TestCovers => ()=>default;
	
	public delegate void CoverWasDropped_del();
	public virtual CoverWasDropped_del CoverWasDropped { get => bfield_CoverWasDropped ?? (()=>{}); set => bfield_CoverWasDropped = value; } CoverWasDropped_del bfield_CoverWasDropped;
	public virtual CoverWasDropped_del global_CoverWasDropped => ()=>{};
	
	public delegate bool StopCannedMove_del();
	public virtual StopCannedMove_del StopCannedMove { get => bfield_StopCannedMove ?? (()=>default); set => bfield_StopCannedMove = value; } StopCannedMove_del bfield_StopCannedMove;
	public virtual StopCannedMove_del global_StopCannedMove => ()=>default;
	
	public delegate void StartCannedMoveState_del();
	public virtual StartCannedMoveState_del StartCannedMoveState { get => bfield_StartCannedMoveState ?? (()=>{}); set => bfield_StartCannedMoveState = value; } StartCannedMoveState_del bfield_StartCannedMoveState;
	public virtual StartCannedMoveState_del global_StartCannedMoveState => ()=>{};
	
	public delegate void StopCannedMoveState_del();
	public virtual StopCannedMoveState_del StopCannedMoveState { get => bfield_StopCannedMoveState ?? (()=>{}); set => bfield_StopCannedMoveState = value; } StopCannedMoveState_del bfield_StopCannedMoveState;
	public virtual StopCannedMoveState_del global_StopCannedMoveState => ()=>{};
	
	public delegate bool IsCoverDirectionValid_del();
	public virtual IsCoverDirectionValid_del IsCoverDirectionValid { get => bfield_IsCoverDirectionValid ?? (()=>default); set => bfield_IsCoverDirectionValid = value; } IsCoverDirectionValid_del bfield_IsCoverDirectionValid;
	public virtual IsCoverDirectionValid_del global_IsCoverDirectionValid => ()=>default;
	
	public delegate bool ShouldHoldPosition_del();
	public virtual ShouldHoldPosition_del ShouldHoldPosition { get => bfield_ShouldHoldPosition ?? (()=>default); set => bfield_ShouldHoldPosition = value; } ShouldHoldPosition_del bfield_ShouldHoldPosition;
	public virtual ShouldHoldPosition_del global_ShouldHoldPosition => ()=>default;
	
	public delegate void CheckIntoCover_del();
	public virtual CheckIntoCover_del CheckIntoCover { get => bfield_CheckIntoCover ?? (()=>{}); set => bfield_CheckIntoCover = value; } CheckIntoCover_del bfield_CheckIntoCover;
	public virtual CheckIntoCover_del global_CheckIntoCover => ()=>{};
	
	public delegate void StopMoving_del();
	public virtual StopMoving_del StopMoving { get => bfield_StopMoving ?? (()=>{}); set => bfield_StopMoving = value; } StopMoving_del bfield_StopMoving;
	public virtual StopMoving_del global_StopMoving => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		UpdateMoveToActorPosition = null;
		Possess = null;
		Say = null;
		PawnDied = null;
		NotifyKilled = null;
		NotifyStumbleComplete = null;
		Reset = null;
		OkToDoStartMove = null;
		Tick = null;
		UpdatePawnFocus = null;
		UpdatePose = null;
		TestCombatTransitions = null;
		SeePlayer = null;
		HandleEnemySeen = null;
		NotifyDamage = null;
		NotifySuppressed = null;
		SwitchToBestWeapon = null;
		IsOkToFire = null;
		IsWithinAttackAngle = null;
		AllowFire = null;
		StartFiring = null;
		GetAdjustedAimFor = null;
		NotifyPrepareForMeleeAttack = null;
		IsThrowingKismetTriggeredGrenade = null;
		AdvanceTimerCallback = null;
		CheckCrouching = null;
		ShouldEnterMelee = null;
		NotifyCoverDropped = null;
		CheckCurrentCover = null;
		TestExitStumble = null;
		UpdateStumbleRotation = null;
		CheckForceWalk = null;
		IsAtMoveGoal = null;
	
	}
	
	protected /*function */void TdAIController_TdState_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TdState_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TdState()/*state TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WhatToDo()/*state WhatToDo extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) NoAnchor()/*state NoAnchor extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TdDead_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */bool TdAIController_TdDead_IsDead()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TdDead()/*state TdDead extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_EnemyDead_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) EnemyDead()/*state EnemyDead extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_ForceThrowGrenadeState_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_ForceThrowGrenadeState_EndState(name Next)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ForceThrowGrenadeState()/*state ForceThrowGrenadeState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_ThrowGrenadeState_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_ThrowGrenadeState_EndState(name Next)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ThrowGrenadeState()/*state ThrowGrenadeState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_KismetThrowGrenadeState_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_KismetThrowGrenadeState_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*event */bool TdAIController_KismetThrowGrenadeState_IsThrowingKismetTriggeredGrenade()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) KismetThrowGrenadeState()/*state KismetThrowGrenadeState extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Idle_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_WaitingForKismetCommand_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_WaitingForKismetCommand_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WaitingForKismetCommand()/*state WaitingForKismetCommand extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_ScriptedFire_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_ScriptedFire_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */Object.Rotator TdAIController_ScriptedFire_GetAdjustedAimFor(Weapon Weapon, Object.Vector StartFireLocation)// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ScriptedFire()/*state ScriptedFire extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TdTestingState_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TdTestingState_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TdTestingState()/*state TdTestingState extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TestingState_Test_RunTest()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_Test()/*state TestingState_Test extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */int TdAIController_TestingState_TestCovers_TestCovers()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_TestCovers()/*state TestingState_TestCovers extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TestingState_Run_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_Run()/*state TestingState_Run extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_DebugCoverState_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_DebugCoverState_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_DebugCoverState_ContinuedState()// state function
	{
	
	}
	
	protected /*event */void TdAIController_DebugCoverState_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected /*function */void TdAIController_DebugCoverState_UpdatePawnFocus()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) DebugCoverState()/*state DebugCoverState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) DebugCoverChangePositionState()/*state DebugCoverChangePositionState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) DebugCoverChangeCoverState()/*state DebugCoverChangeCoverState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TestingState_MoveToPos_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TestingState_MoveToPos_EndState(name Next)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_MoveToPos()/*state TestingState_MoveToPos extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TestingState_RunToPos_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TestingState_RunToPos_EndState(name Next)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_RunToPos()/*state TestingState_RunToPos extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TestingState_MoveStraightToPos_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TestingState_MoveStraightToPos_EndState(name Next)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_MoveStraightToPos()/*state TestingState_MoveStraightToPos extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_TestingState_MoveStraightToActor_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TestingState_MoveStraightToActor_EndState(name Next)// state function
	{
	
	}
	
	protected /*function */void TdAIController_TestingState_MoveStraightToActor_UpdateMoveToActorPosition()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TestingState_MoveStraightToActor()/*state TestingState_MoveStraightToActor extends TdTestingState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Immobile_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Immobile_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Immobile_UpdatePawnFocus()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Immobile_UpdatePose()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Immobile()/*state Immobile extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Stasis_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stasis_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Stasis()/*state Stasis extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Error_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Error()/*state Error extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Advance_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Advance_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Advance_NotifySuppressed()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Advance()/*state Advance extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_GetWithinPathLimits_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_GetWithinPathLimits_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) GetWithinPathLimits()/*state GetWithinPathLimits extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Cover_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Cover_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Cover_ContinuedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Cover_AdvanceTimerCallback()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Cover_NotifyCoverDropped()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Cover_CoverWasDropped()// state function
	{
	
	}
	
	protected /*function */bool TdAIController_Cover_ShouldEnterMelee(float Range)// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Cover()/*state Cover extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Melee_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Melee_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Melee()/*state Melee extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_ShieldWall_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_ShieldWall_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ShieldWall()/*state ShieldWall extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_AnimationPlayback_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_AnimationPlayback_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*function */bool TdAIController_AnimationPlayback_IsOkToFire()// state function
	{
	
		return default;
	}
	
	protected /*event */void TdAIController_AnimationPlayback_SeePlayer(Pawn iPawn)// state function
	{
	
	}
	
	protected /*event */void TdAIController_AnimationPlayback_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected /*function */bool TdAIController_AnimationPlayback_NotifyPrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)// state function
	{
	
		return default;
	}
	
	protected /*function */void TdAIController_AnimationPlayback_NotifyDamage(Controller InstigatedBy, Core.ClassT<DamageType> DamageType, int Damage)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) AnimationPlayback()/*state AnimationPlayback extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_CannedMove_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_CannedMove_EndState(name Next)// state function
	{
	
	}
	
	protected /*function */void TdAIController_CannedMove_PushedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_CannedMove_PoppedState()// state function
	{
	
	}
	
	protected /*function */bool TdAIController_CannedMove_StopCannedMove()// state function
	{
	
		return default;
	}
	
	protected /*protected function */void TdAIController_CannedMove_StartCannedMoveState()// state function
	{
	
	}
	
	protected /*protected function */void TdAIController_CannedMove_StopCannedMoveState()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) CannedMove()/*state CannedMove extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Stumble_BeginState(name Previous)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stumble_EndState(name Next)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stumble_UpdatePose()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stumble_UpdatePawnFocus()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stumble_NotifyStumbleComplete()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stumble_TestExitStumble()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Stumble_UpdateStumbleRotation(bool bAllowRotation)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Stumble()/*state Stumble extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_Blocking_BeginState(name PreviousState)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Blocking_EndState(name NextState)// state function
	{
	
	}
	
	protected /*function */void TdAIController_Blocking_UpdatePawnFocus()// state function
	{
	
	}
	
	protected /*function */void TdAIController_Blocking_NotifyStumbleComplete()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Blocking()/*state Blocking extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_SubAction_FireFromCover_PushedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_PoppedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_UpdatePawnFocus()// state function
	{
	
	}
	
	protected /*function */bool TdAIController_SubAction_FireFromCover_IsWithinAttackAngle()// state function
	{
	
		return default;
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_NotifyCoverDropped()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_NotifyDamage(Controller InstigatedBy, Core.ClassT<DamageType> DamageType, int Damage)// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_NotifySuppressed()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_AdvanceTimerCallback()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_FireFromCover_CheckCurrentCover()// state function
	{
	
	}
	
	protected /*function */bool TdAIController_SubAction_FireFromCover_IsCoverDirectionValid()// state function
	{
	
		return default;
	}
	
	protected /*function */bool TdAIController_SubAction_FireFromCover_ShouldHoldPosition()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) SubAction_FireFromCover()/*state SubAction_FireFromCover extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_SubAction_MoveToCover_PushedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_MoveToCover_PoppedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_MoveToCover_NotifyCoverDropped()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) SubAction_MoveToCover()/*state SubAction_MoveToCover extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_SubAction_ExitingCover_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_ExitingCover_EndState(name NextStateName)// state function
	{
	
	}
	
	protected /*event */void TdAIController_SubAction_ExitingCover_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) SubAction_ExitingCover()/*state SubAction_ExitingCover extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_SubAction_MoveToGoal_PushedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_MoveToGoal_PoppedState()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_MoveToGoal_CheckForceWalk()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_MoveToGoal_CheckIntoCover()// state function
	{
	
	}
	
	protected /*function */bool TdAIController_SubAction_MoveToGoal_IsAtMoveGoal()// state function
	{
	
		return default;
	}
	
	protected /*function */void TdAIController_SubAction_MoveToGoal_NotifyCoverDropped()// state function
	{
	
	}
	
	protected /*function */void TdAIController_SubAction_MoveToGoal_StopMoving()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) SubAction_MoveToGoal()/*state SubAction_MoveToGoal extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdAIController_ScriptedMoveTo_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*function */void TdAIController_ScriptedMoveTo_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ScriptedMoveTo()/*state ScriptedMoveTo extends TdState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "TdState": return TdState();
			case "WhatToDo": return WhatToDo();
			case "NoAnchor": return NoAnchor();
			case "TdDead": return TdDead();
			case "EnemyDead": return EnemyDead();
			case "ForceThrowGrenadeState": return ForceThrowGrenadeState();
			case "ThrowGrenadeState": return ThrowGrenadeState();
			case "KismetThrowGrenadeState": return KismetThrowGrenadeState();
			case "Idle": return Idle();
			case "WaitingForKismetCommand": return WaitingForKismetCommand();
			case "ScriptedFire": return ScriptedFire();
			case "TdTestingState": return TdTestingState();
			case "TestingState_Test": return TestingState_Test();
			case "TestingState_TestCovers": return TestingState_TestCovers();
			case "TestingState_Run": return TestingState_Run();
			case "DebugCoverState": return DebugCoverState();
			case "DebugCoverChangePositionState": return DebugCoverChangePositionState();
			case "DebugCoverChangeCoverState": return DebugCoverChangeCoverState();
			case "TestingState_MoveToPos": return TestingState_MoveToPos();
			case "TestingState_RunToPos": return TestingState_RunToPos();
			case "TestingState_MoveStraightToPos": return TestingState_MoveStraightToPos();
			case "TestingState_MoveStraightToActor": return TestingState_MoveStraightToActor();
			case "Immobile": return Immobile();
			case "Stasis": return Stasis();
			case "Error": return Error();
			case "Advance": return Advance();
			case "GetWithinPathLimits": return GetWithinPathLimits();
			case "Cover": return Cover();
			case "Melee": return Melee();
			case "ShieldWall": return ShieldWall();
			case "AnimationPlayback": return AnimationPlayback();
			case "CannedMove": return CannedMove();
			case "Stumble": return Stumble();
			case "Blocking": return Blocking();
			case "SubAction_FireFromCover": return SubAction_FireFromCover();
			case "SubAction_MoveToCover": return SubAction_MoveToCover();
			case "SubAction_ExitingCover": return SubAction_ExitingCover();
			case "SubAction_MoveToGoal": return SubAction_MoveToGoal();
			case "ScriptedMoveTo": return ScriptedMoveTo();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Idle();
	}
	public TdAIController()
	{
		// Object Offset:0x004CF28E
		CurrentAdvanceAction = TdAIController.AdvanceAction.AA_StandAndFire;
		bFirstShot = true;
		bRandomCrouch = true;
		bAllowFocus = true;
		bAllowFocusRotation = true;
		bUseCoverDetour = true;
		bUseCoverPathRestrictions = true;
		bAvoidPopulatedPaths = true;
		bUseVoiceOver = true;
		ForceKeepMovingEndedTimeStamp = -99999.0f;
		MaxDistFromLineToBlock = 50;
		PathNetworkMask = -1;
		ExitedMelee = -9999.0f;
		ExitMeleeDelay = 2.0f;
		AdvanceTime = 6.50f;
		MeleeState = (name)"Melee";
		DifficultyLevel = 1;
		AILogFilter = new array</*config */name>
		{
			(name)"Movement",
			(name)"Navigation",
			(name)"Cover",
			(name)"ClientMessage",
			(name)"Team",
			(name)"Fire",
			(name)"Sniper",
			(name)"Enemy",
			(name)"TestCombatTransitions",
			(name)"VO",
			(name)"Focus",
			(name)"Crouch",
			(name)"Taser",
			(name)"Pursue",
			(name)"AIMelee",
			(name)"AdvanceLog",
			(name)"HoldAndAdvance",
			(name)"ShieldWall",
		};
		ScreenLogFilter = new array</*config */name>
		{
			(name)"Pathfinding",
			(name)"Moves",
			(name)"Movement",
			(name)"ShieldWall",
			(name)"JK",
			(name)"rb",
			(name)"Animations",
			(name)"HeadFocus",
			(name)"MoveChanges",
			(name)"ForceWalk",
			(name)"Pursue",
			(name)"AILog",
			(name)"Taser",
			(name)"Interruptable",
		};
		bAdjustFromWalls = false;
		bCanDoSpecial = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAIController.Sprite")/*Ref SpriteComponent'Default__TdAIController.Sprite'*/,
		};
		RotationRate = new Rotator
		{
			Pitch=20000,
			Yaw=45000,
			Roll=20000
		};
	}
}
}