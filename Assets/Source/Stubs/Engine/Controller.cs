namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Controller : Actor/*
		abstract
		native
		nativereplication
		notplaceable
		hidecategories(Navigation)*/{
	public const int LATENT_MOVETOWARD = 503;
	
	public partial struct /*native */VisiblePortalInfo
	{
		public Actor Source;
		public Actor Destination;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00263020
	//		Source = default;
	//		Destination = default;
	//	}
	};
	
	public Pawn Pawn;
	public /*repnotify */PlayerReplicationInfo PlayerReplicationInfo;
	public /*const */int PlayerNum;
	public /*private const */Controller NextController;
	public bool bIsPlayer;
	public bool bGodMode;
	public bool bAffectedByHitEffects;
	public bool bSoaking;
	public bool bSlowerZAcquire;
	public bool bForceStrafe;
	public bool bNotifyPostLanded;
	public bool bNotifyApex;
	public bool bAdvancedTactics;
	public bool bCanDoSpecial;
	public bool bAdjusting;
	public bool bPreparingMove;
	public bool bIgnoreMovementFocus;
	public /*const */bool bLOSflag;
	public bool bUsePlayerHearing;
	public bool bNotifyFallingHitWall;
	public bool bForceDesiredRotation;
	public bool bPreciseDestination;
	public bool bSeeFriendly;
	public bool bUsingPathLanes;
	public /*input */byte bFire;
	public float MinHitWall;
	public float MoveTimer;
	public Actor MoveTarget;
	public Object.Vector Destination;
	public Object.Vector FocalPoint;
	public Actor Focus;
	public StaticArray<Actor, Actor, Actor, Actor>/*[4]*/ GoalList;
	public Object.Vector AdjustLoc;
	public NavigationPoint StartSpot;
	public array<NavigationPoint> RouteCache;
	public ReachSpec CurrentPath;
	public ReachSpec NextRoutePath;
	public Object.Vector CurrentPathDir;
	public Actor RouteGoal;
	public float RouteDist;
	public float LastRouteFind;
	public InterpActor PendingMover;
	public float GroundPitchTime;
	public Object.Vector ViewX;
	public Object.Vector ViewY;
	public Object.Vector ViewZ;
	public Pawn ShotTarget;
	public /*const */Actor LastFailedReach;
	public /*const */float FailedReachTime;
	public /*const */Object.Vector FailedReachLocation;
	public float SightCounter;
	public float RespawnPredictionTime;
	public float InUseNodeCostMultiplier;
	public int HighJumpNodeCostModifier;
	public Pawn Enemy;
	public /*deprecated */Actor Target;
	public array<Controller.VisiblePortalInfo> VisiblePortals;
	public float LaneOffset;
	public /*const */Object.Rotator OldBasedRotation;
	public int currentLaneSlot;
	public int pathMatesCount;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Pawn, PlayerReplicationInfo;
	//}
	
	// Export UController::execIsLocalPlayerController(FFrame&, void* const)
	public virtual /*native function */bool IsLocalPlayerController()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execRouteCache_Empty(FFrame&, void* const)
	public virtual /*native function */void RouteCache_Empty()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UController::execRouteCache_AddItem(FFrame&, void* const)
	public virtual /*native function */void RouteCache_AddItem(NavigationPoint Nav)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UController::execRouteCache_InsertItem(FFrame&, void* const)
	public virtual /*native function */void RouteCache_InsertItem(NavigationPoint Nav, /*optional */int? _Idx = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UController::execRouteCache_RemoveItem(FFrame&, void* const)
	public virtual /*native function */void RouteCache_RemoveItem(NavigationPoint Nav)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UController::execRouteCache_RemoveIndex(FFrame&, void* const)
	public virtual /*native function */void RouteCache_RemoveIndex(int InIndex, /*optional */int? _Count = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? Controller_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => Controller_Reset;
	public /*function */void Controller_Reset()
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientSetLocation(Object.Vector NewLocation, Object.Rotator NewRotation)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientSetRotation(Object.Rotator NewRotation, /*optional */bool? _bResetCamera = default)
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public virtual /*function */void OnPossess(SeqAct_Possess inAction)
	{
	
	}
	
	public delegate void Possess_del(Pawn inPawn, bool bVehicleTransition);
	public virtual Possess_del Possess { get => bfield_Possess ?? Controller_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public virtual Possess_del global_Possess => Controller_Possess;
	public /*event */void Controller_Possess(Pawn inPawn, bool bVehicleTransition)
	{
	
	}
	
	public virtual /*function */void UpdateSex()
	{
	
	}
	
	public virtual /*event */void UnPossess()
	{
	
	}
	
	public delegate void PawnDied_del(Pawn inPawn);
	public virtual PawnDied_del PawnDied { get => bfield_PawnDied ?? Controller_PawnDied; set => bfield_PawnDied = value; } PawnDied_del bfield_PawnDied;
	public virtual PawnDied_del global_PawnDied => Controller_PawnDied;
	public /*function */void Controller_PawnDied(Pawn inPawn)
	{
	
	}
	
	public delegate bool GamePlayEndedState_del();
	public virtual GamePlayEndedState_del GamePlayEndedState { get => bfield_GamePlayEndedState ?? Controller_GamePlayEndedState; set => bfield_GamePlayEndedState = value; } GamePlayEndedState_del bfield_GamePlayEndedState;
	public virtual GamePlayEndedState_del global_GamePlayEndedState => Controller_GamePlayEndedState;
	public /*function */bool Controller_GamePlayEndedState()
	{
	
		return default;
	}
	
	public virtual /*event */void NotifyPostLanded()
	{
	
	}
	
	public override /*event */void Destroyed()
	{
	
	}
	
	public virtual /*function */void CleanupPRI()
	{
	
	}
	
	public virtual /*function */void Restart(bool bVehicleTransition)
	{
	
	}
	
	// Export UController::execBeyondFogDistance(FFrame&, void* const)
	public virtual /*native final function */bool BeyondFogDistance(Object.Vector ViewPoint, Object.Vector OtherPoint)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void EnemyJustTeleported()
	{
	
	}
	
	public virtual /*function */void NotifyTakeHit(Controller InstigatedBy, Object.Vector HitLocation, int Damage, Core.ClassT<DamageType> DamageType, Object.Vector Momentum)
	{
	
	}
	
	public virtual /*function */void InitPlayerReplicationInfo()
	{
	
	}
	
	// Export UController::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void ServerRestartPlayer_del();
	public virtual ServerRestartPlayer_del ServerRestartPlayer { get => bfield_ServerRestartPlayer ?? Controller_ServerRestartPlayer; set => bfield_ServerRestartPlayer = value; } ServerRestartPlayer_del bfield_ServerRestartPlayer;
	public virtual ServerRestartPlayer_del global_ServerRestartPlayer => Controller_ServerRestartPlayer;
	public /*reliable server function */void Controller_ServerRestartPlayer()
	{
	
	}
	
	public virtual /*function */void ServerGivePawn()
	{
	
	}
	
	public virtual /*function */void SetCharacter(String inCharacter)
	{
	
	}
	
	public virtual /*function */void GameHasEnded(/*optional */Actor? _EndGameFocus = default, /*optional */bool? _bIsWinner = default)
	{
	
	}
	
	public delegate void NotifyKilled_del(Controller Killer, Controller Killed, Pawn KilledPawn);
	public virtual NotifyKilled_del NotifyKilled { get => bfield_NotifyKilled ?? Controller_NotifyKilled; set => bfield_NotifyKilled = value; } NotifyKilled_del bfield_NotifyKilled;
	public virtual NotifyKilled_del global_NotifyKilled => Controller_NotifyKilled;
	public /*function */void Controller_NotifyKilled(Controller Killer, Controller Killed, Pawn KilledPawn)
	{
	
	}
	
	public virtual /*function */void NotifyProjLanded(Projectile Proj)
	{
	
	}
	
	public virtual /*function */void WarnProjExplode(Projectile Proj)
	{
	
	}
	
	public virtual /*event */float RatePickup(Actor PickupHolder, Core.ClassT<Inventory> inPickup)
	{
	
		return default;
	}
	
	public virtual /*function */bool FireWeaponAt(Actor inActor)
	{
	
		return default;
	}
	
	public virtual /*event */void StopFiring()
	{
	
	}
	
	public virtual /*function */void RoundHasEnded(/*optional */Actor? _EndRoundFocus = default)
	{
	
	}
	
	public virtual /*function */void HandlePickup(Inventory Inv)
	{
	
	}
	
	public delegate Object.Rotator GetAdjustedAimFor_del(Weapon W, Object.Vector StartFireLoc);
	public virtual GetAdjustedAimFor_del GetAdjustedAimFor { get => bfield_GetAdjustedAimFor ?? Controller_GetAdjustedAimFor; set => bfield_GetAdjustedAimFor = value; } GetAdjustedAimFor_del bfield_GetAdjustedAimFor;
	public virtual GetAdjustedAimFor_del global_GetAdjustedAimFor => Controller_GetAdjustedAimFor;
	public /*function */Object.Rotator Controller_GetAdjustedAimFor(Weapon W, Object.Vector StartFireLoc)
	{
	
		return default;
	}
	
	public virtual /*function */void InstantWarnTarget(Actor InTarget, Weapon FiredWeapon, Object.Vector FireDir)
	{
	
	}
	
	public virtual /*function */void CheckNearMiss(Pawn Shooter, Weapon W, Object.Vector WeapLoc, Object.Vector LineDir, Object.Vector HitLocation)
	{
	
	}
	
	public delegate void ReceiveWarning_del(Pawn Shooter, float projSpeed, Object.Vector FireDir);
	public virtual ReceiveWarning_del ReceiveWarning { get => bfield_ReceiveWarning ?? Controller_ReceiveWarning; set => bfield_ReceiveWarning = value; } ReceiveWarning_del bfield_ReceiveWarning;
	public virtual ReceiveWarning_del global_ReceiveWarning => Controller_ReceiveWarning;
	public /*function */void Controller_ReceiveWarning(Pawn Shooter, float projSpeed, Object.Vector FireDir)
	{
	
	}
	
	public virtual /*function */void ReceiveProjectileWarning(Projectile Proj)
	{
	
	}
	
	public delegate void SwitchToBestWeapon_del(/*optional */bool? _bForceNewWeapon = default);
	public virtual SwitchToBestWeapon_del SwitchToBestWeapon { get => bfield_SwitchToBestWeapon ?? Controller_SwitchToBestWeapon; set => bfield_SwitchToBestWeapon = value; } SwitchToBestWeapon_del bfield_SwitchToBestWeapon;
	public virtual SwitchToBestWeapon_del global_SwitchToBestWeapon => Controller_SwitchToBestWeapon;
	public /*exec function */void Controller_SwitchToBestWeapon(/*optional */bool? _bForceNewWeapon = default)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientSwitchToBestWeapon(/*optional */bool? _bForceNewWeapon = default)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientSetWeapon(Core.ClassT<Weapon> WeaponClass)
	{
	
	}
	
	public virtual /*function */void NotifyChangedWeapon(Weapon PrevWeapon, Weapon NewWeapon)
	{
	
	}
	
	// Export UController::execLineOfSightTo(FFrame&, void* const)
	public virtual /*native(514) final function */bool LineOfSightTo(Actor Other, /*optional */Object.Vector? _chkLocation = default, /*optional */bool? _bTryAlternateTargetLoc = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execCanSee(FFrame&, void* const)
	public virtual /*native(533) final function */bool CanSee(Pawn Other)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execCanSeeByPoints(FFrame&, void* const)
	public virtual /*native(537) final function */bool CanSeeByPoints(Object.Vector ViewLocation, Object.Vector TestLocation, Object.Rotator ViewRotation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execPickTarget(FFrame&, void* const)
	public virtual /*native(531) final function */Pawn PickTarget(Core.ClassT<Pawn> TargetClass, ref float bestAim, ref float bestDist, Object.Vector FireDir, Object.Vector projStart, float MaxRange)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void HearNoise(float Loudness, Actor NoiseMaker, /*optional */name? _NoiseType = default)
	{
	
	}
	
	public delegate void SeePlayer_del(Pawn Seen);
	public virtual SeePlayer_del SeePlayer { get => bfield_SeePlayer ?? Controller_SeePlayer; set => bfield_SeePlayer = value; } SeePlayer_del bfield_SeePlayer;
	public virtual SeePlayer_del global_SeePlayer => Controller_SeePlayer;
	public /*event */void Controller_SeePlayer(Pawn Seen)
	{
	
	}
	
	public virtual /*event */void SeeMonster(Pawn Seen)
	{
	
	}
	
	public virtual /*event */void EnemyNotVisible()
	{
	
	}
	
	// Export UController::execMoveTo(FFrame&, void* const)
	public virtual /*native(500) final latent function */Flow MoveTo(Object.Vector NewDestination, /*optional */Actor? _ViewFocus = default, /*optional */bool? _bShouldWalk = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execMoveToward(FFrame&, void* const)
	public virtual /*native(502) final latent function */Flow MoveToward(Actor NewTarget, /*optional */Actor? _ViewFocus = default, /*optional */float? _DestinationOffset = default, /*optional */bool? _bUseStrafing = default, /*optional */bool? _bShouldWalk = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void SetupSpecialPathAbilities()
	{
	
	}
	
	// Export UController::execFinishRotation(FFrame&, void* const)
	public virtual /*native(508) final latent function */Flow FinishRotation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execFindPathTo(FFrame&, void* const)
	public virtual /*native(518) final function */Actor FindPathTo(Object.Vector aPoint, /*optional */int? _MaxPathLength = default, /*optional */bool? _bReturnPartial = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execFindPathToward(FFrame&, void* const)
	public virtual /*native(517) final function */Actor FindPathToward(Actor anActor, /*optional */bool? _bWeightDetours = default, /*optional */int? _MaxPathLength = default, /*optional */bool? _bReturnPartial = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execFindPathTowardNearest(FFrame&, void* const)
	public virtual /*native final function */Actor FindPathTowardNearest(Core.ClassT<NavigationPoint> GoalClass, /*optional */bool? _bWeightDetours = default, /*optional */int? _MaxPathLength = default, /*optional */bool? _bReturnPartial = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execFindRandomDest(FFrame&, void* const)
	public virtual /*native(525) final function */NavigationPoint FindRandomDest()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execFindPathToIntercept(FFrame&, void* const)
	public virtual /*native final function */Actor FindPathToIntercept(Pawn P, Actor InRouteGoal, /*optional */bool? _bWeightDetours = default, /*optional */int? _MaxPathLength = default, /*optional */bool? _bReturnPartial = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execPointReachable(FFrame&, void* const)
	public virtual /*native(521) final function */bool PointReachable(Object.Vector aPoint)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execActorReachable(FFrame&, void* const)
	public virtual /*native(520) final function */bool ActorReachable(Actor anActor)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void MoveUnreachable(Object.Vector AttemptedDest, Actor AttemptedTarget)
	{
	
	}
	
	// Export UController::execPickWallAdjust(FFrame&, void* const)
	public virtual /*native(526) final function */bool PickWallAdjust(Object.Vector HitNormal)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execWaitForLanding(FFrame&, void* const)
	public virtual /*native(527) final latent function */Flow WaitForLanding(/*optional */float? _waitDuration = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void LongFall()
	{
	
	}
	
	// Export UController::execEndClimbLadder(FFrame&, void* const)
	public virtual /*native function */void EndClimbLadder()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */void MayFall()
	{
	
	}
	
	public virtual /*event */bool AllowDetourTo(NavigationPoint N)
	{
	
		return default;
	}
	
	public virtual /*function */void WaitForMover(InterpActor M)
	{
	
	}
	
	public virtual /*event */bool MoverFinished()
	{
	
		return default;
	}
	
	public virtual /*function */void UnderLift(LiftCenter Lift)
	{
	
	}
	
	public virtual /*event */bool HandlePathObstruction(Actor BlockedBy)
	{
	
		return default;
	}
	
	public virtual /*simulated event */void GetPlayerViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
	
	}
	
	public override /*simulated event */void GetActorEyesViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
	
	}
	
	public virtual /*simulated function */bool IsAimingAt(Actor ATarget, float Epsilon)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool LandingShake()
	{
	
		return default;
	}
	
	public delegate void NotifyPhysicsVolumeChange_del(PhysicsVolume NewVolume);
	public virtual NotifyPhysicsVolumeChange_del NotifyPhysicsVolumeChange { get => bfield_NotifyPhysicsVolumeChange ?? Controller_NotifyPhysicsVolumeChange; set => bfield_NotifyPhysicsVolumeChange = value; } NotifyPhysicsVolumeChange_del bfield_NotifyPhysicsVolumeChange;
	public virtual NotifyPhysicsVolumeChange_del global_NotifyPhysicsVolumeChange => Controller_NotifyPhysicsVolumeChange;
	public /*event */void Controller_NotifyPhysicsVolumeChange(PhysicsVolume NewVolume)
	{
	
	}
	
	public virtual /*event */bool NotifyHeadVolumeChange(PhysicsVolume NewVolume)
	{
	
		return default;
	}
	
	public delegate bool NotifyLanded_del(Object.Vector HitNormal, Actor FloorActor);
	public virtual NotifyLanded_del NotifyLanded { get => bfield_NotifyLanded ?? Controller_NotifyLanded; set => bfield_NotifyLanded = value; } NotifyLanded_del bfield_NotifyLanded;
	public virtual NotifyLanded_del global_NotifyLanded => Controller_NotifyLanded;
	public /*event */bool Controller_NotifyLanded(Object.Vector HitNormal, Actor FloorActor)
	{
	
		return default;
	}
	
	public virtual /*event */bool NotifyHitWall(Object.Vector HitNormal, Actor Wall)
	{
	
		return default;
	}
	
	public virtual /*event */void NotifyFallingHitWall(Object.Vector HitNormal, Actor Wall)
	{
	
	}
	
	public virtual /*event */bool NotifyBump(Actor Other, Object.Vector HitNormal)
	{
	
		return default;
	}
	
	public virtual /*event */void NotifyJumpApex()
	{
	
	}
	
	public virtual /*event */void NotifyMissedJump()
	{
	
	}
	
	// Export UController::execInLatentExecution(FFrame&, void* const)
	public virtual /*native final function */bool InLatentExecution(int LatentActionNumber)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UController::execStopLatentExecution(FFrame&, void* const)
	public virtual /*native final function */void StopLatentExecution()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public override /*simulated function */String GetHumanReadableName()
	{
	
		return default;
	}
	
	public delegate bool IsDead_del();
	public virtual IsDead_del IsDead { get => bfield_IsDead ?? Controller_IsDead; set => bfield_IsDead = value; } IsDead_del bfield_IsDead;
	public virtual IsDead_del global_IsDead => Controller_IsDead;
	public /*function */bool Controller_IsDead()
	{
	
		return default;
	}
	
	public override /*simulated function */void OnMakeNoise(SeqAct_MakeNoise Action)
	{
	
	}
	
	public override /*simulated function */void OnTeleport(SeqAct_Teleport Action)
	{
	
	}
	
	public virtual /*function */void OnToggleGodMode(SeqAct_ToggleGodMode inAction)
	{
	
	}
	
	public virtual /*function */void OnToggleAffectedByHitEffects(SeqAct_ToggleAffectedByHitEffects inAction)
	{
	
	}
	
	public virtual /*simulated function */void NotifyCoverDisabled(CoverLink Link, int SlotIdx)
	{
	
	}
	
	public virtual /*simulated event */void NotifyCoverAdjusted()
	{
	
	}
	
	public virtual /*simulated function */bool NotifyCoverClaimViolation(Controller NewClaim, CoverLink Link, int SlotIdx)
	{
	
		return default;
	}
	
	public override /*simulated function */void OnCauseDamage(SeqAct_CauseDamage Action)
	{
	
	}
	
	public virtual /*function */void NotifyAddInventory(Inventory NewItem)
	{
	
	}
	
	public override /*simulated function */void OnToggleHidden(SeqAct_ToggleHidden Action)
	{
	
	}
	
	public virtual /*function */Controller GetKillerController()
	{
	
		return default;
	}
	
	public delegate bool IsSpectating_del();
	public virtual IsSpectating_del IsSpectating { get => bfield_IsSpectating ?? Controller_IsSpectating; set => bfield_IsSpectating = value; } IsSpectating_del bfield_IsSpectating;
	public virtual IsSpectating_del global_IsSpectating => Controller_IsSpectating;
	public /*function */bool Controller_IsSpectating()
	{
	
		return default;
	}
	
	public virtual /*event */bool IsInCombat()
	{
	
		return default;
	}
	
	public virtual /*function */Actor GetRouteGoalAfter(int RouteIdx)
	{
	
		return default;
	}
	
	public virtual /*event */void CurrentLevelUnloaded()
	{
	
	}
	
	public virtual /*function */void SendMessage(PlayerReplicationInfo Recipient, name MessageType, float Wait, /*optional */Core.ClassT<DamageType>? _DamageType = default)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Possess = null;
		PawnDied = null;
		GamePlayEndedState = null;
		ServerRestartPlayer = null;
		NotifyKilled = null;
		GetAdjustedAimFor = null;
		ReceiveWarning = null;
		SwitchToBestWeapon = null;
		SeePlayer = null;
		NotifyPhysicsVolumeChange = null;
		NotifyLanded = null;
		IsDead = null;
		IsSpectating = null;
	
	}
	
	protected /*function */bool Controller_Dead_IsDead()// state function
	{
	
		return default;
	}
	
	protected /*reliable server function */void Controller_Dead_ServerRestartPlayer()// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Dead()/*state Dead*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool Controller_RoundEnded_GamePlayEndedState()// state function
	{
	
		return default;
	}
	
	protected /*event */void Controller_RoundEnded_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RoundEnded()/*state RoundEnded*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Dead": return Dead();
			case "RoundEnded": return RoundEnded();
			default: return base.FindState(stateName);
		}
	}
	public Controller()
	{
		// Object Offset:0x00268415
		bAffectedByHitEffects = true;
		bSlowerZAcquire = true;
		MinHitWall = -1.0f;
		bHidden = true;
		bOnlyRelevantToOwner = true;
		bHiddenEd = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x00268ACD
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__Controller.Sprite' */,
		};
		RotationRate = new Rotator
		{
			Pitch=30000,
			Yaw=30000,
			Roll=2048
		};
	}
}
}