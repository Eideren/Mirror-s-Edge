// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPTutorialGame : TdSPGame, 
		TdCheckpointListener,TdTutorialListener/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public enum ETutorialEvents 
	{
		ETE_None,
		ETE_SkillRoll,
		ETE_LookAtPoint,
		ETE_MeleeAttack,
		ETE_LowMeleeAttack,
		ETE_JumpKickAttack,
		ETE_SlideKickAttack,
		ETE_SpeedVaultAttack,
		ETE_RearDisarm,
		ETE_FrontDisarm,
		ETE_Failed,
		ETE_BJumpTest,
		ETE_BCrouchTest,
		ETE_BTurnTest,
		ETE_BAttackTest,
		ETE_BReactionTime,
		ETE_AiAttackSuccessful,
		ETE_AiPreAttackEvent,
		ETE_AiPostAttackEvent,
		ETE_WeaponDropped,
		ETE_ObjectivesShown,
		ETE_SpeedVault,
		ETE_ReactionTimeDepleted,
		ETE_DisarmInitiated,
		ETE_MeleeFromBehind,
		ETE_MAX
	};
	
	public enum EMovementChallenge 
	{
		EMC_None,
		EMC_JumpTimingOne,
		EMC_SlideOne,
		EMC_JumpTimingTwo,
		EMC_SpeedVault,
		EMC_JumpTimingThree,
		EMC_VaultOver,
		EMC_SlideTwo,
		EMC_HorizontalWallrun,
		EMC_Barge,
		EMC_BalanceWalk,
		EMC_VerticalWallrun,
		EMC_Climb,
		EMC_TransferToPipe,
		EMC_TransferToLedge,
		EMC_Turn180,
		EMC_VerticalWallrunToGrab,
		EMC_JumpToGrab,
		EMC_ZipLine,
		EMC_SoftLanding,
		EMC_WallrunLJump,
		EMC_SpringBoard,
		EMC_FreeStyle,
		EMC_BackToStart,
		EMC_MeleeAttack,
		EMC_LowMeleeAttack,
		EMC_JumpKickAttack,
		EMC_SlideKickAttack,
		EMC_SpeedVaultAttack,
		EMC_DodgeAttack,
		EMC_RearDisarm,
		EMC_FrontDisarm,
		EMC_DiscardWeapon,
		EMC_FrontalDisarmRT,
		EMC_LedgeWalk,
		EMC_Swing,
		EMC_ButtonTest,
		EMC_CoilJump,
		EMC_AnyMovementChallenge,
		EMC_AnyCombatChallenge,
		EMC_Max
	};
	
	public partial struct InitialTutorialState
	{
		public TdSPTutorialGame.EMovementChallenge Challenge;
		public name StateName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0066AB19
	//		Challenge = TdSPTutorialGame.EMovementChallenge.EMC_None;
	//		StateName = (name)"None";
	//	}
	};
	
	public /*private transient */array<TdSPTutorialGame.InitialTutorialState> InitialTutorialStates;
	public /*private transient */TdPlaceableCheckpointManager CheckpointManager;
	public /*private transient */Object.Vector LastValidPlayerLocation;
	public /*private transient */TdSPTutorialGame.EMovementChallenge ActiveMovementChallenge;
	public /*private transient */TdTutorialPawn TutorialPawn;
	public /*private transient */TdPlayerController TutorialPlayer;
	public /*private transient */Core.ClassT<TdLocalMessage> TutorialMessageClass;
	public /*private transient */Core.ClassT<TdLocalMessage> FeedbackMessageClass;
	public /*transient */array<TdPlaceableCheckpoint> NextCheckPoints;
	public /*transient */TdPlaceableCheckpoint LastCheckPoint;
	public /*private transient */bool bTutorialReactionTimeHelper;
	public /*transient */TdAI_Tutorial AiTutorialController;
	public /*delegate*/TdSPTutorialGame.OnStayInTutorial __OnStayInTutorial__Delegate;
	
	public delegate void OnStayInTutorial(bool bStayInTutorial);
	
	public override /*event */void InitGame(String Options, ref String ErrorMessage)
	{
	
	}
	
	public override PostLogin_del PostLogin { get => bfield_PostLogin ?? TdSPTutorialGame_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public override PostLogin_del global_PostLogin => TdSPTutorialGame_PostLogin;
	public /*event */void TdSPTutorialGame_PostLogin(PlayerController NewPlayer)
	{
	
	}
	
	public override /*event */void PreBeginPlay()
	{
	
	}
	
	public override /*function */void RestartPlayer(Controller C)
	{
	
	}
	
	public virtual /*function */void RegisterAiController(TdAIController AIController)
	{
	
	}



	void TdTutorialListener.OnPlayerSetMove( TdPawn.EMovement NewMove, TdPlayerPawn Pawn )
	{
		#warning interface inheritance through delegate instead of function
		this.OnPlayerSetMove( NewMove, Pawn );
	}



	void TdTutorialListener.OnTutorialEvent( int TutorialEvent, TdPawn Pawn )
	{
		#warning interface inheritance through delegate instead of function
		this.OnTutorialEvent( TutorialEvent, Pawn );
	}



	bool TdTutorialListener.CanAttack()
	{
		#warning interface inheritance through delegate instead of function
		return this.CanAttack();
	}



	bool TdTutorialListener.ValidAttack( ClassT<DamageType> AttackType )
	{
		#warning interface inheritance through delegate instead of function
		return this.ValidAttack(AttackType);
	}



	void TdTutorialListener.OnAttackEvent( ClassT<DamageType> AttackType, TdPawn Pawn )
	{
		#warning interface inheritance through delegate instead of function
		this.OnAttackEvent(AttackType, Pawn);
	}



	void TdTutorialListener.OnAiKismetEvent( int EventIdentifier )
	{
		#warning interface inheritance through delegate instead of function
		this.OnAiKismetEvent(EventIdentifier);
	}



	public delegate void OnCheckpointCompleted_del(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller);
	public virtual OnCheckpointCompleted_del OnCheckpointCompleted { get => bfield_OnCheckpointCompleted ?? TdSPTutorialGame_OnCheckpointCompleted; set => bfield_OnCheckpointCompleted = value; } OnCheckpointCompleted_del bfield_OnCheckpointCompleted;
	public virtual OnCheckpointCompleted_del global_OnCheckpointCompleted => TdSPTutorialGame_OnCheckpointCompleted;
	public /*function */void TdSPTutorialGame_OnCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller)
	{
	
	}
	
	public delegate void OnPlayerSetMove_del(TdPawn.EMovement NewMove, TdPlayerPawn Pawn);
	public virtual OnPlayerSetMove_del OnPlayerSetMove { get => bfield_OnPlayerSetMove ?? TdSPTutorialGame_OnPlayerSetMove; set => bfield_OnPlayerSetMove = value; } OnPlayerSetMove_del bfield_OnPlayerSetMove;
	public virtual OnPlayerSetMove_del global_OnPlayerSetMove => TdSPTutorialGame_OnPlayerSetMove;
	public /*function */void TdSPTutorialGame_OnPlayerSetMove(TdPawn.EMovement NewMove, TdPlayerPawn Pawn)
	{
	
	}
	
	public delegate void OnTutorialEvent_del(int TutorialEvent, TdPawn Pawn);
	public virtual OnTutorialEvent_del OnTutorialEvent { get => bfield_OnTutorialEvent ?? TdSPTutorialGame_OnTutorialEvent; set => bfield_OnTutorialEvent = value; } OnTutorialEvent_del bfield_OnTutorialEvent;
	public virtual OnTutorialEvent_del global_OnTutorialEvent => TdSPTutorialGame_OnTutorialEvent;
	public /*function */void TdSPTutorialGame_OnTutorialEvent(int TutorialEvent, TdPawn Pawn)
	{
	
	}
	
	public delegate bool CanAttack_del();
	public virtual CanAttack_del CanAttack { get => bfield_CanAttack ?? TdSPTutorialGame_CanAttack; set => bfield_CanAttack = value; } CanAttack_del bfield_CanAttack;
	public virtual CanAttack_del global_CanAttack => TdSPTutorialGame_CanAttack;
	public /*function */bool TdSPTutorialGame_CanAttack()
	{
	
		return default;
	}
	
	public delegate bool ValidAttack_del(Core.ClassT<DamageType> AttackType);
	public virtual ValidAttack_del ValidAttack { get => bfield_ValidAttack ?? TdSPTutorialGame_ValidAttack; set => bfield_ValidAttack = value; } ValidAttack_del bfield_ValidAttack;
	public virtual ValidAttack_del global_ValidAttack => TdSPTutorialGame_ValidAttack;
	public /*function */bool TdSPTutorialGame_ValidAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public delegate void OnAttackEvent_del(Core.ClassT<DamageType> AttackType, TdPawn Pawn);
	public virtual OnAttackEvent_del OnAttackEvent { get => bfield_OnAttackEvent ?? TdSPTutorialGame_OnAttackEvent; set => bfield_OnAttackEvent = value; } OnAttackEvent_del bfield_OnAttackEvent;
	public virtual OnAttackEvent_del global_OnAttackEvent => TdSPTutorialGame_OnAttackEvent;
	public /*function */void TdSPTutorialGame_OnAttackEvent(Core.ClassT<DamageType> AttackType, TdPawn Pawn)
	{
	
	}
	
	public delegate void OnAiKismetEvent_del(int EventIdentifier);
	public virtual OnAiKismetEvent_del OnAiKismetEvent { get => bfield_OnAiKismetEvent ?? TdSPTutorialGame_OnAiKismetEvent; set => bfield_OnAiKismetEvent = value; } OnAiKismetEvent_del bfield_OnAiKismetEvent;
	public virtual OnAiKismetEvent_del global_OnAiKismetEvent => TdSPTutorialGame_OnAiKismetEvent;
	public /*function */void TdSPTutorialGame_OnAiKismetEvent(int EventIdentifier)
	{
	
	}
	
	public virtual /*function */int GetActiveMovementChallenge()
	{
	
		return default;
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? TdSPTutorialGame_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => TdSPTutorialGame_Timer;
	public /*function */void TdSPTutorialGame_Timer()
	{
	
	}
	
	public virtual /*function */void StoreLastValidPlayerLocation()
	{
	
	}
	
	public virtual /*exec function */void StartMovementChallenge(int Index)
	{
	
	}
	
	public virtual /*exec function */void ReStartMovementChallenge(int Index)
	{
	
	}
	
	public virtual /*function */void ClearActivateTutorialMessages()
	{
	
	}
	
	public virtual /*function */void ReStartCurrentMovementChallengeLight()
	{
	
	}
	
	public virtual /*exec function */void ReStartCurrentMovementChallenge()
	{
	
	}
	
	public delegate bool IsInWalkTrough_del();
	public virtual IsInWalkTrough_del IsInWalkTrough { get => bfield_IsInWalkTrough ?? TdSPTutorialGame_IsInWalkTrough; set => bfield_IsInWalkTrough = value; } IsInWalkTrough_del bfield_IsInWalkTrough;
	public virtual IsInWalkTrough_del global_IsInWalkTrough => TdSPTutorialGame_IsInWalkTrough;
	public /*function */bool TdSPTutorialGame_IsInWalkTrough()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsCombatTutorialChallenge(int Index)
	{
	
		return default;
	}
	
	public virtual /*function */void GetStartSpots(TdSPTutorialGame.EMovementChallenge Track, ref array<TdTutorialStart> TutorialStartSpots)
	{
	
	}
	
	public virtual /*function */PlayerStart FindMCStartSpot(TdSPTutorialGame.EMovementChallenge Track)
	{
	
		return default;
	}
	
	public virtual /*function */PlayerStart GetActivePlayerStart()
	{
	
		return default;
	}
	
	public virtual /*function */void ResetGameSequence()
	{
	
	}
	
	public virtual /*function */void ResetPlayer(TdPlayerPawn PawnToReset, /*optional */NavigationPoint? _StartSpot = default)
	{
	
	}
	
	public override PreventDeath_del PreventDeath { get => bfield_PreventDeath ?? TdSPTutorialGame_PreventDeath; set => bfield_PreventDeath = value; } PreventDeath_del bfield_PreventDeath;
	public override PreventDeath_del global_PreventDeath => TdSPTutorialGame_PreventDeath;
	public /*function */bool TdSPTutorialGame_PreventDeath(Pawn KilledPawn, Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
	
		return default;
	}
	
	public virtual /*function */void SendMCKismetEvent(TdSPTutorialGame.EMovementChallenge MovementChallange, Core.ClassT<SeqEvt_TdMovementChallengeEvent> EventClass, /*optional */TdTutorialCheckpoint? _Sender = default)
	{
	
	}
	
	public virtual /*function */void SendTutorialKismetEvent(TdSPTutorialGame.EMovementChallenge MovementChallange, int TutorialEvent, /*optional */TdTutorialCheckpoint? _Sender = default)
	{
	
	}
	
	public override /*function */void Killed(Controller Killer, Controller KilledPlayer, Pawn KilledPawn, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public virtual /*function */bool GetNextCheckpoints(TdPlaceableCheckpoint Current, ref array<TdPlaceableCheckpoint> outCheckpoints)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsCheckpointIn(TdPlaceableCheckpoint Test, array<TdPlaceableCheckpoint> InCheckPoints)
	{
	
		return default;
	}
	
	public virtual /*function */void CheckTouching(TdPlayerPawn Pawn, array<TdPlaceableCheckpoint> InNextCheckPoints)
	{
	
	}
	
	public virtual /*function */void EnableTutorialReactiontimeHelper()
	{
	
	}
	
	public virtual /*function */void DisableTutorialReactiontimeHelper()
	{
	
	}
	
	public /*function */static bool AllowReactionTime()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsPunchAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsLowMeleeAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsJumpKickAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsSlideKickAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public virtual /*function */bool IsVaultAttack(Core.ClassT<DamageType> AttackType)
	{
	
		return default;
	}
	
	public virtual /*function */void OnTutorialCompleted(/*delegate*/TdSPTutorialGame.OnStayInTutorial InOnStayInTutorial, /*optional */String? _NextLevelName = default)
	{
	
	}
	
	public override /*function */void OnLevelCompleted(TdPlayerController PC, String CurrentLevelName, /*optional */String? _InNextLevelName = default, /*optional */String? _InNextCheckpointName = default)
	{
	
	}
	
	public override /*event */void PostSublevelStreaming(String Options)
	{
	
	}
	
	public virtual /*function */void CheckDeviceConnected()
	{
	
	}
	
	public override /*function */void OnLoadNextLevel()
	{
	
	}
	
	public virtual /*private final function */void OnMsgInit(UIScene OpenScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnPreSelectionAnim(TdUIScene_MessageBox MsgBox, int SIndex, int PIndex)
	{
	
	}
	
	public virtual /*private final function */void OnSelection(TdUIScene_MessageBox MsgBox, int SIndex, int PIndex)
	{
	
	}
	
	public virtual /*function */void ClearIgnoreInput()
	{
	
	}
	
	public override /*function */void SetObjective(name CheckpointName)
	{
	
	}
	
	public delegate void ChallegeCompleted_del(TdPawn Pawn, TdPlayerController Controller);
	public virtual ChallegeCompleted_del ChallegeCompleted { get => bfield_ChallegeCompleted ?? ((a,b)=>{}); set => bfield_ChallegeCompleted = value; } ChallegeCompleted_del bfield_ChallegeCompleted;
	public virtual ChallegeCompleted_del global_ChallegeCompleted => (a,b)=>{};
	
	public delegate bool IsTouchingCheckpoint_del(TdTutorialCheckpoint CP, TdPawn Pawn);
	public virtual IsTouchingCheckpoint_del IsTouchingCheckpoint { get => bfield_IsTouchingCheckpoint ?? ((a,b)=>default); set => bfield_IsTouchingCheckpoint = value; } IsTouchingCheckpoint_del bfield_IsTouchingCheckpoint;
	public virtual IsTouchingCheckpoint_del global_IsTouchingCheckpoint => (a,b)=>default;
	
	public delegate int GetTutorialEventIdenfier_del(Core.ClassT<DamageType> AttackType);
	public virtual GetTutorialEventIdenfier_del GetTutorialEventIdenfier { get => bfield_GetTutorialEventIdenfier ?? ((a)=>default); set => bfield_GetTutorialEventIdenfier = value; } GetTutorialEventIdenfier_del bfield_GetTutorialEventIdenfier;
	public virtual GetTutorialEventIdenfier_del global_GetTutorialEventIdenfier => (a)=>default;
	
	public delegate void TestCheckpointCompletion_del(TdPawn.EMovement NewMove, int TutorialEvent, TdPawn Pawn);
	public virtual TestCheckpointCompletion_del TestCheckpointCompletion { get => bfield_TestCheckpointCompletion ?? ((a,b,c)=>{}); set => bfield_TestCheckpointCompletion = value; } TestCheckpointCompletion_del bfield_TestCheckpointCompletion;
	public virtual TestCheckpointCompletion_del global_TestCheckpointCompletion => (a,b,c)=>{};
	
	public delegate void ProcessCompletedCheckpoint_del(TdTutorialCheckpoint Checkpoint, TdPawn Pawn, TdPlayerController Controller);
	public virtual ProcessCompletedCheckpoint_del ProcessCompletedCheckpoint { get => bfield_ProcessCompletedCheckpoint ?? ((a,b,c)=>{}); set => bfield_ProcessCompletedCheckpoint = value; } ProcessCompletedCheckpoint_del bfield_ProcessCompletedCheckpoint;
	public virtual ProcessCompletedCheckpoint_del global_ProcessCompletedCheckpoint => (a,b,c)=>{};
	
	public delegate void OnLastCheckpointCompleted_del(TdPlaceableCheckpoint Checkpoint, TdPawn Pawn, TdPlayerController Controller);
	public virtual OnLastCheckpointCompleted_del OnLastCheckpointCompleted { get => bfield_OnLastCheckpointCompleted ?? ((a,b,c)=>{}); set => bfield_OnLastCheckpointCompleted = value; } OnLastCheckpointCompleted_del bfield_OnLastCheckpointCompleted;
	public virtual OnLastCheckpointCompleted_del global_OnLastCheckpointCompleted => (a,b,c)=>{};
	protected override void RestoreDefaultFunction()
	{
		PostLogin = null;
		OnCheckpointCompleted = null;
		OnPlayerSetMove = null;
		OnTutorialEvent = null;
		CanAttack = null;
		ValidAttack = null;
		OnAttackEvent = null;
		OnAiKismetEvent = null;
		Timer = null;
		IsInWalkTrough = null;
		PreventDeath = null;
	
	}
	
	protected /*function */void TdSPTutorialGame_Waiting_BeginState(name PreviousState)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Waiting()/*auto state Waiting*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */bool TdSPTutorialGame_WalkThrough_IsInWalkTrough()// state function
	{
	
		return default;
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_BeginState(name PreviousState)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_EndState(name NextState)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_ChallegeCompleted(TdPawn Pawn, TdPlayerController Controller)// state function
	{
	
	}
	
	protected /*function */bool TdSPTutorialGame_WalkThrough_IsTouchingCheckpoint(TdTutorialCheckpoint CP, TdPawn Pawn)// state function
	{
	
		return default;
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_OnTutorialEvent(int TutorialEvent, TdPawn Pawn)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_OnAttackEvent(Core.ClassT<DamageType> AttackType, TdPawn Pawn)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_OnAiKismetEvent(int EventIdentifier)// state function
	{
	
	}
	
	protected /*function */bool TdSPTutorialGame_WalkThrough_CanAttack()// state function
	{
	
		return default;
	}
	
	protected /*function */bool TdSPTutorialGame_WalkThrough_ValidAttack(Core.ClassT<DamageType> AttackType)// state function
	{
	
		return default;
	}
	
	protected /*function */int TdSPTutorialGame_WalkThrough_GetTutorialEventIdenfier(Core.ClassT<DamageType> AttackType)// state function
	{
	
		return default;
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_OnPlayerSetMove(TdPawn.EMovement NewMove, TdPlayerPawn Pawn)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_TestCheckpointCompletion(TdPawn.EMovement NewMove, int TutorialEvent, TdPawn Pawn)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_ProcessCompletedCheckpoint(TdTutorialCheckpoint Checkpoint, TdPawn Pawn, TdPlayerController Controller)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_OnCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_WalkThrough_OnLastCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPawn Pawn, TdPlayerController Controller)// state function
	{
	
	}
	
	protected /*function */NavigationPoint TdSPTutorialGame_WalkThrough_FindClosestStartSpot(Object.Vector ObjectLocation)// state function
	{
	
		return default;
	}
	
	protected /*event */void TdSPTutorialGame_WalkThrough_Tick(float DeltaTime)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WalkThrough()/*state WalkThrough*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdSPTutorialGame_ButtonWalkThrough_BeginState(name PreviousState)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_ButtonWalkThrough_OnPlayerSetMove(TdPawn.EMovement NewMove, TdPlayerPawn Pawn)// state function
	{
	
	}
	
	protected /*function */void TdSPTutorialGame_ButtonWalkThrough_EndState(name NextState)// state function
	{
	
	}
	
	protected /*function */bool TdSPTutorialGame_ButtonWalkThrough_IsInWalkTrough()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ButtonWalkThrough()/*state ButtonWalkThrough extends WalkThrough*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdSPTutorialGame_PlayGround_BeginState(name PreviousState)// state function
	{
	
	}
	
	protected /*function */bool TdSPTutorialGame_PlayGround_PreventDeath(Pawn KilledPawn, Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayGround()/*state PlayGround*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Waiting": return Waiting();
			case "WalkThrough": return WalkThrough();
			case "ButtonWalkThrough": return ButtonWalkThrough();
			case "PlayGround": return PlayGround();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Waiting();
	}
	public TdSPTutorialGame()
	{
		// Object Offset:0x00670828
		InitialTutorialStates = new array<TdSPTutorialGame.InitialTutorialState>
		{
			new TdSPTutorialGame.InitialTutorialState
			{
				Challenge = TdSPTutorialGame.EMovementChallenge.EMC_ButtonTest,
				StateName = (name)"ButtonWalkThrough",
			},
		};
		DefaultPawnClass = ClassT<TdTutorialPawn>()/*Ref Class'TdTutorialPawn'*/;
		HUDType = ClassT<TdTutorialHUD>()/*Ref Class'TdTutorialHUD'*/;
	}



	void TdCheckpointListener.OnCheckpointCompleted( TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller )
	{
		#warning interface inheritance through delegate instead of function
		this.OnCheckpointCompleted( Checkpoint, Pawn, Controller );
	}
}
}