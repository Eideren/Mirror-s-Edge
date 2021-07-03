namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AITeam : Actor/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public const int SIXTH_SENSE_TIME = 2;
	public const int CHECK_MANOUVERS_TIME = 1;
	
	public enum EForcedAggressionLevel 
	{
		FAL_Aggressive,
		FAL_Cautious,
		FAL_None,
		FAL_MAX
	};
	
	public enum ESide 
	{
		TdSide_Cops,
		TdSide_Criminals,
		TdSide_MAX
	};
	
	public /*private */AITeam.EForcedAggressionLevel ForcedAggressionLevel;
	public/*(Logic)*/ AITeam.ESide Side;
	public/*(Debug)*/ /*config */bool bAILogging;
	public bool TabsOutOfSync;
	public bool scriptingActivated;
	public bool bHaveDrawnDebug;
	public array<TdAIController> Members;
	public String TeamName;
	public TdAIController Leader;
	public FileLog AILogFile;
	public int logTabs;
	public float lastLogTime;
	public name lastLogStateName;
	public /*config */array</*config */name> AILogFilter;
	public array<TdAIController> FiringMembers;
	public array<TdAIController> MovingMembers;
	public /*transient */array<Route> PatrolRoutes;
	public array<bool> PatrolRoutesPicked;
	public /*transient */array<NavigationPoint> GuardSpots;
	public array<bool> GuardSpotsPicked;
	public TdPawn Enemy;
	public float EnemyNotSeenTime;
	public TdAIManager AIManager;
	public /*private */TdAI_Riot ShieldFormationMaster;
	
	// Export UAITeam::execAddMember(FFrame&, void* const)
	public virtual /*native function */void AddMember(TdAIController NewMember)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UAITeam::execRemoveMember(FFrame&, void* const)
	public virtual /*native function */void RemoveMember(TdAIController Member)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UAITeam::execGetNearestNavToPoint(FFrame&, void* const)
	public virtual /*native function */NavigationPoint GetNearestNavToPoint(Object.Vector ChkPoint, /*optional */Class _RequiredClass = default, /*optional */array<NavigationPoint>? _ExcludeList = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public virtual /*final event */void AILog_Internal(/*coerce */String LogText, /*optional */name? _LogCategory = default, /*optional */bool? _bForce = default)
	{
		// stub
	}
	
	public virtual /*final function */void LogFunction_Internal(/*coerce */String FuncName, bool Start, /*coerce optional */String? _S = default, /*optional */name? _LogCategory = default)
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? AITeam_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => AITeam_Reset;
	public /*function */void AITeam_Reset()
	{
		// stub
	}
	
	public virtual /*function */void SetHaveDrawnDebug(bool flag)
	{
		// stub
	}
	
	public virtual /*function */bool HaveDrawnDebug()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetShieldFormationMaster(TdAI_Riot Master)
	{
		// stub
	}
	
	public virtual /*function */TdAIController GetClosestMember(Object.Vector P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ClientMessage(/*coerce */String S)
	{
		// stub
	}
	
	public virtual /*function */void DrawDebug(ref String Text)
	{
		// stub
	}
	
	public virtual /*function */void NotifyCombatStarted()
	{
		// stub
	}
	
	public virtual /*event */void OnMemberAdded(TdAIController Drone)
	{
		// stub
	}
	
	public virtual /*event */void OnMemberRemoved(TdAIController Drone)
	{
		// stub
	}
	
	public virtual /*function */void HandleEnemySeen(TdAIController Drone, TdPawn aPawn)
	{
		// stub
	}
	
	public virtual /*function */void HandleEnemyExposed(TdPawn aPawn)
	{
		// stub
	}
	
	public virtual /*function */void NotifyDamage(TdAIController Drone, TdPawn InstigatedBy)
	{
		// stub
	}
	
	public virtual /*function */void NoticedEnemy(TdAIController Drone, TdPawn aPawn)
	{
		// stub
	}
	
	public virtual /*function */void ExposedEnemy(TdPawn aPawn)
	{
		// stub
	}
	
	public virtual /*function */void HeardEnemy(TdAIController Drone, TdPawn aPawn)
	{
		// stub
	}
	
	public virtual /*function */void ReportNoise(Object.Vector pos)
	{
		// stub
	}
	
	public virtual /*function */void ReportSuspect(Object.Vector pos)
	{
		// stub
	}
	
	public virtual /*function */void SetForcedAggressionLevel(AITeam.EForcedAggressionLevel A)
	{
		// stub
	}
	
	public virtual /*function */AITeam.EForcedAggressionLevel GetForcedAggressionLevel()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ForgetEnemy()
	{
		// stub
	}
	
	public virtual /*function */void SetEnemy(TdPawn aPawn)
	{
		// stub
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? AITeam_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => AITeam_Tick;
	public /*event */void AITeam_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void NotifyEnemyIsDead()
	{
		// stub
	}
	
	public virtual /*function */void AskForClosestIdleTask(TdAIController C, ref Route R, ref NavigationPoint G)
	{
		// stub
	}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public virtual /*function */TdAI_Riot GetShieldMaster(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdAI_Riot GetShieldMasterAll(TdAIController C)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnAIReleaseScripting(SeqAct_AIReleaseScripting Action)
	{
		// stub
	}
	
	public virtual /*function */void OnAIImmobile(SeqAct_AIImmobile Action)
	{
		// stub
	}
	
	public virtual /*function */void OnTdAIStasis(SeqAct_TdAIStasis Action)
	{
		// stub
	}
	
	public virtual /*function */void OnTdSetPathLimits(SeqAct_TdSetPathLimits Action)
	{
		// stub
	}
	
	public virtual /*function */void OnAIHoldFire(SeqAct_AIHoldFire Action)
	{
		// stub
	}
	
	public virtual /*function */void OnAIForceWalking(SeqAct_AIForceWalking Action)
	{
		// stub
	}
	
	public virtual /*function */void OnTdAIPerfectAim(SeqAct_TdAIPerfectAim Action)
	{
		// stub
	}
	
	public virtual /*function */void OnAIFireAt(SeqAct_AIFireAt Action)
	{
		// stub
	}
	
	public virtual /*function */void OnSetCombatRange(SeqAct_SetCombatRange Action)
	{
		// stub
	}
	
	public virtual /*function */void OnSetCoverGroup(SeqAct_SetCoverGroup Action)
	{
		// stub
	}
	
	public virtual /*event */void OnForceAggression(AITeam.EForcedAggressionLevel A)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Tick = null;
	
	}
	
	protected /*function */void AITeam_DEBUGSTATE_BeginState(name PreviousStateName)// state function
	{
		// stub
	}
	
	protected /*function */void AITeam_DEBUGSTATE_EndState(name NextStateName)// state function
	{
		// stub
	}
	
	protected /*function */void AITeam_DEBUGSTATE_PushedState()// state function
	{
		// stub
	}
	
	protected /*function */void AITeam_DEBUGSTATE_PoppedState()// state function
	{
		// stub
	}
	
	protected /*function */void AITeam_DEBUGSTATE_ContinuedState()// state function
	{
		// stub
	}
	
	protected /*function */void AITeam_DEBUGSTATE_PausedState()// state function
	{
		// stub
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) DEBUGSTATE()/*state DEBUGSTATE*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Error()/*state Error extends DEBUGSTATE*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) TeamState()/*state TeamState extends DEBUGSTATE*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle extends TeamState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Investigate()/*state Investigate extends TeamState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Search()/*state Search extends TeamState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "DEBUGSTATE": return DEBUGSTATE();
			case "Error": return Error();
			case "TeamState": return TeamState();
			case "Idle": return Idle();
			case "Investigate": return Investigate();
			case "Search": return Search();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Idle();
	}
	public AITeam()
	{
		// Object Offset:0x004858AD
		ForcedAggressionLevel = AITeam.EForcedAggressionLevel.FAL_None;
		TeamName = "Unnamed";
		EnemyNotSeenTime = 99999.0f;
	}
}
}