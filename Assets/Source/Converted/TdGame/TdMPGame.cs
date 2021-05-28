namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPGame : TdGameInfo/*
		abstract
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct DeadPlayerController
	{
		public TdPlayerController C;
		public float TimeToRespawn;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005F458A
	//		C = default;
	//		TimeToRespawn = 0.0f;
	//	}
	};
	
	public /*config */string IpServerNumber;
	public /*const config */float GlobalPlayerRespawnTime;
	public /*const config */float IndividualPlayerMinRespawnTime;
	public /*const config */float TimeBetweenRounds;
	public /*const config */float TimeBetweenMatches;
	public /*const config */int MaxRounds;
	public int RoundCount;
	public /*protected */array<string> CriminalClasses;
	public /*protected */array<string> PoliceClasses;
	public array<TdMPGame.DeadPlayerController> DeadControllers;
	public bool bInitialSpawn;
	public /*config */bool bUseWarmup;
	public Core.ClassT<TdVictoryMessage> VictoryMessageClass;
	public /*config */int MinWarmupPlayersNeeded;
	public /*config */int WarmupCountDownTime;
	
	public override /*event */void InitGame(string Options, ref string ErrorMessage)
	{
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
		TimeLimit = Max(0, GetIntOption(Options, "TimeLimit", TimeLimit));
		MaxPlayers = Max(0, GetIntOption(Options, "MaxPlayers", MaxPlayers));
		MinWarmupPlayersNeeded = Max(0, GetIntOption(Options, "MinWarmupPlayersNeeded", MinWarmupPlayersNeeded));
		MinWarmupPlayersNeeded = Min(MinWarmupPlayersNeeded, MaxPlayers);
		bUseWarmup = ApproximatelyEqual((ParseOption(Options, "bUseWarmup")), "1");
		DeathMessageClass = ((DynamicLoadObject("TdMpContent.TdDeathMessage", ClassT<Class>(), default(bool))) as ClassT<TdLocalMessage>);
	}
	
	public override /*function */void PreBeginPlay()
	{
		base.PreBeginPlay();
		AccuireSpectatorPoints();
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdMPGame_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdMPGame_Reset;
	public /*function */void TdMPGame_Reset()
	{
		/*Transformed 'base.' to specific call*/TdGameInfo_Reset();
		SetGameTimer(false, ((float)(TimeLimit * 60)), ((float)(TimeLimit)));
	}
	
	public override /*function */void InitGameReplicationInfo()
	{
		SetGameTimer(false, ((float)(TimeLimit * 60)), ((float)(TimeLimit)));
		base.InitGameReplicationInfo();
	}
	
	public override StartMatch_del StartMatch { get => bfield_StartMatch ?? TdMPGame_StartMatch; set => bfield_StartMatch = value; } StartMatch_del bfield_StartMatch;
	public override StartMatch_del global_StartMatch => TdMPGame_StartMatch;
	public /*function */void TdMPGame_StartMatch()
	{
		/*local */Actor A = default;
	
		SetGameTimer(true, ((float)(TimeLimit * 60)), ((float)(TimeLimit)));
		((GameReplicationInfo) as TdGameReplicationInfo).bMatchIsInWarmup = false;
		
		// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e52 = AllActors(ClassT<Actor>()).GetEnumerator();
		while(e52.MoveNext() && (A = (Actor)e52.Current) == A)
		{
			A.MatchStarting();		
		}	
		bWaitingToStartMatch = false;
		RoundCount = 0;
		GotoState("MatchInProgress", default(name), default(bool), default(bool));
		StartOnlineGame();
		WorldInfo.NotifyMatchStarted(default(bool), default(bool), default(bool));
	}
	
	public override /*function */bool CheckEndGame(PlayerReplicationInfo Winner, string Reason)
	{
		GameReplicationInfo.Winner = Winner;
		return base.CheckEndGame(Winner, Reason);
	}
	
	public override /*function */void EndGame(PlayerReplicationInfo Winner, string Reason)
	{
		base.EndGame(Winner, Reason);
		if(bGameEnded)
		{
			GotoState("MatchOver", default(name), default(bool), default(bool));
		}
	}
	
	public virtual /*function */void KillRemainingPlayers()
	{
		/*local */Controller Player = default;
		/*local */PlayerController PC = default;
		/*local */Pawn OldPawn = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ Player)
		using var e0 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e0.MoveNext() && (Player = (Controller)e0.Current) == Player)
		{
			if(Player.Pawn != default)
			{
				OldPawn = Player.Pawn;
				Player.Pawn.StopFiring();
				Player.UnPossess();
				if(((OldPawn) as TdPawn) != default)
				{
					OldPawn.Destroy();
				}
			}
			PC = ((Player) as PlayerController);
			if(PC != default)
			{
				PC.ClientReset();
				PC.Reset();
			}		
		}	
	}
	
	public virtual /*function */void RespawnBag()
	{
	
	}
	
	public override /*function */Core.ClassT<Pawn> GetDefaultPlayerClass(Controller C)
	{
		/*local */Core.ClassT<Pawn> ResultClass = default;
		/*local */int RandIndex = default;
		/*local */string ClassName = default;
	
		if((CriminalClasses.Length == 0) || PoliceClasses.Length == 0)
		{
			return DefaultPawnClass;
		}
		if(C.PlayerReplicationInfo != default)
		{
			if(Rand(1) == 0)
			{
				RandIndex = Rand(CriminalClasses.Length);
				ClassName = CriminalClasses[RandIndex];			
			}
			else
			{
				RandIndex = Rand(PoliceClasses.Length);
				ClassName = PoliceClasses[RandIndex];
			}
			ResultClass = ((DynamicLoadObject(ClassName, ClassT<Class>(), default(bool))) as ClassT<Pawn>);
		}
		if(ResultClass == default)
		{
			ResultClass = DefaultPawnClass;
		}
		return ResultClass;
	}
	
	public override /*function */Pawn SpawnDefaultPawnFor(Controller NewPlayer, NavigationPoint StartSpot)
	{
		/*local */Object.Rotator StartRotation = default;
		/*local */Pawn ResultPawn = default;
		/*local */Object.Vector SpawnOffset = default;
		/*local */int Attempts = default;
		/*local */float Radius = default;
	
		StartRotation.Yaw = StartSpot.Rotation.Yaw;
		Attempts = 0;
		J0x32:{}
		if(Attempts < 5)
		{
			ResultPawn = Spawn(GetDefaultPlayerClass(NewPlayer), default(Actor), default(name), StartSpot.Location + SpawnOffset, StartRotation, default(Actor), false);
			if(ResultPawn == default)
			{
				if(((StartSpot) as TdPlayerStart) != default)
				{
					Radius = ((StartSpot) as TdPlayerStart).Radius;				
				}
				else
				{
					Radius = ClassT<TdPlayerStart>().DefaultAs<TdPlayerStart>().Radius;
				}
				SpawnOffset.X = ((float)(Rand(((int)(Radius * ((float)(2))))))) - Radius;
				SpawnOffset.Y = ((float)(Rand(((int)(Radius * ((float)(2))))))) - Radius;
				goto J0x11D;
			}
			goto J0x127;
			J0x11D:{}
			++ Attempts;
			goto J0x32;
		}
		J0x127:{}
		return ResultPawn;
	}
	
	public virtual /*function */void OpenPostGameScene()
	{
		/*local */TdPlayerController TdPC = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ TdPC)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (TdPC = (TdPlayerController)e0.Current) == TdPC)
		{
			if(TdPC != default)
			{
				TdPC.ClientOpenScene("TdEndOfRound");
			}		
		}	
	}
	
	public virtual /*function */void AddToRespawnList(Controller C)
	{
		/*local */TdMPGame.DeadPlayerController DeadC = default;
	
		if(C.IsA("TdPlayerController") && !C.PlayerReplicationInfo.bOnlySpectator)
		{
			DeadC.C = ((C) as TdPlayerController);
			DeadC.TimeToRespawn = WorldInfo.TimeSeconds + IndividualPlayerMinRespawnTime;
			DeadControllers.Insert(DeadControllers.Length, 1);
			DeadControllers[DeadControllers.Length - 1] = DeadC;
		}
	}
	
	public virtual /*function */void ClearRespawnList()
	{
		DeadControllers.Remove(0, DeadControllers.Length);
		DeadControllers.Length = 0;
	}
	
	public virtual /*function */void RemoveFromRespawnList(Controller C)
	{
		/*local */int Idx = default;
	
		if(C.IsA("TdPlayerController"))
		{
			Idx = 0;
			J0x1F:{}
			if(Idx < DeadControllers.Length)
			{
				if(DeadControllers[Idx].C == C)
				{
					DeadControllers.Remove(-- Idx, 1);
				}
				++ Idx;
				goto J0x1F;
			}
		}
	}
	
	public override /*function */void BroadcastDeathMessage(Controller Killer, Controller Other, Core.ClassT<DamageType> DamageType)
	{
		if(Killer == Other)
		{
			BroadcastLocalized(this, DeathMessageClass, 14, default(PlayerReplicationInfo), Other.PlayerReplicationInfo, DamageType);		
		}
		else
		{
			if(Killer == default)
			{
				BroadcastLocalized(this, DeathMessageClass, 13, default(PlayerReplicationInfo), Other.PlayerReplicationInfo, DamageType);			
			}
			else
			{
				if(Killer.PlayerReplicationInfo.Team == Other.PlayerReplicationInfo.Team)
				{
					BroadcastLocalized(this, DeathMessageClass, 15, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);				
				}
				else
				{
					if(((DamageType) as ClassT<TdDmgType_Melee>) != default)
					{
						BroadcastLocalized(this, DeathMessageClass, 16, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);					
					}
					else
					{
						BroadcastLocalized(this, DeathMessageClass, 12, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);
					}
				}
			}
		}
	}
	
	public delegate void EndWarmup_del();
	public virtual EndWarmup_del EndWarmup { get => bfield_EndWarmup ?? TdMPGame_EndWarmup; set => bfield_EndWarmup = value; } EndWarmup_del bfield_EndWarmup;
	public virtual EndWarmup_del global_EndWarmup => TdMPGame_EndWarmup;
	public /*function */void TdMPGame_EndWarmup()
	{
	
	}
	
	public delegate void StartWarmup_del();
	public virtual StartWarmup_del StartWarmup { get => bfield_StartWarmup ?? TdMPGame_StartWarmup; set => bfield_StartWarmup = value; } StartWarmup_del bfield_StartWarmup;
	public virtual StartWarmup_del global_StartWarmup => TdMPGame_StartWarmup;
	public /*function */void TdMPGame_StartWarmup()
	{
	
	}
	
	public delegate void HandleLateWarmupJoin_del(Controller NewPlayer);
	public virtual HandleLateWarmupJoin_del HandleLateWarmupJoin { get => bfield_HandleLateWarmupJoin ?? TdMPGame_HandleLateWarmupJoin; set => bfield_HandleLateWarmupJoin = value; } HandleLateWarmupJoin_del bfield_HandleLateWarmupJoin;
	public virtual HandleLateWarmupJoin_del global_HandleLateWarmupJoin => TdMPGame_HandleLateWarmupJoin;
	public /*function */void TdMPGame_HandleLateWarmupJoin(Controller NewPlayer)
	{
	
	}
	
	public virtual /*function */bool CheckStartGame()
	{
		if((NumTravellingPlayers > 0) || MinWarmupPlayersNeeded > NumPlayers)
		{
			return false;
		}
		return true;
	}
	
	public virtual /*function */void SetGameTimer(bool bEnable, /*optional */float RemainingTime = default, /*optional */float RemainingMinute = default)
	{
		RemainingTime = -1.0f;
		RemainingMinute = -1.0f;
		GameReplicationInfo.bStopCountDown = !bEnable;
		if(RemainingTime >= ((float)(0)))
		{
			GameReplicationInfo.RemainingTime = ((int)(RemainingTime));
		}
		if(RemainingMinute >= ((float)(0)))
		{
			GameReplicationInfo.RemainingMinute = ((int)(RemainingMinute));
		}
	}
	
	public delegate void InitialSpawn_del();
	public virtual InitialSpawn_del InitialSpawn { get => bfield_InitialSpawn ?? (()=>{}); set => bfield_InitialSpawn = value; } InitialSpawn_del bfield_InitialSpawn;
	public virtual InitialSpawn_del global_InitialSpawn => ()=>{};
	
	public delegate void RespawnTimer_del();
	public virtual RespawnTimer_del RespawnTimer { get => bfield_RespawnTimer ?? (()=>{}); set => bfield_RespawnTimer = value; } RespawnTimer_del bfield_RespawnTimer;
	public virtual RespawnTimer_del global_RespawnTimer => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		StartMatch = null;
		EndWarmup = null;
		StartWarmup = null;
		HandleLateWarmupJoin = null;
	
	}
	
	protected /*function */void TdMPGame_PendingMatch_EndState(name NextStateName)// state function
	{
		/*Transformed 'base.' to specific call*/GameInfo_PendingMatch_EndState(NextStateName);
	}
	
	protected /*function */void TdMPGame_PendingMatch_BeginState(name PreviousStateName)// state function
	{
		/*Transformed 'base.' to specific call*/Object_BeginState(PreviousStateName);
		if(!bUseWarmup || bUseWarmup && CheckStartGame())
		{
			StartMatch();		
		}
		else
		{
			StartWarmup();
		}
	}
	
	protected /*event */void TdMPGame_PendingMatch_PostLogin(PlayerController NewPlayer)// state function
	{
		/*Transformed 'base.' to specific call*/GameInfo_PostLogin(NewPlayer);
		HandleLateWarmupJoin(NewPlayer);
	}
	
	protected /*function */void TdMPGame_PendingMatch_StartWarmup()// state function
	{
		/*local */TdPlayerController C = default;
	
		SetGameTimer(false, default(float), default(float));
		((GameReplicationInfo) as TdGameReplicationInfo).bMatchIsInWarmup = true;
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e36 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e36.MoveNext() && (C = (TdPlayerController)e36.Current) == C)
		{
			if(!C.PlayerReplicationInfo.bOnlySpectator)
			{
				RestartPlayer(C);
			}		
		}	
	}
	
	protected /*function */void TdMPGame_PendingMatch_HandleLateWarmupJoin(Controller NewPlayer)// state function
	{
		if(bUseWarmup)
		{
			if(CheckStartGame())
			{
				EndWarmup();			
			}
			else
			{
				if(!NewPlayer.PlayerReplicationInfo.bOnlySpectator)
				{
					RestartPlayer(NewPlayer);
				}
			}
		}
	}
	
	protected /*function */void TdMPGame_PendingMatch_EndWarmup()// state function
	{
		/*local */TdPlayerController C = default;
	
		if(GameReplicationInfo.bStopCountDown)
		{
			SetGameTimer(true, ((float)(WarmupCountDownTime)), 1.0f);
		}
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e42 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e42.MoveNext() && (C = (TdPlayerController)e42.Current) == C)
		{
			if(!C.PlayerReplicationInfo.bOnlySpectator)
			{
				C.ForcePreRoundSpectate();
				C.ClientForcePreRoundSpectate();
			}		
		}	
	}
	
	protected /*event */void TdMPGame_PendingMatch_Timer()// state function
	{
		global_Timer();
		if(GameReplicationInfo.RemainingTime <= 0)
		{
			StartMatch();
		}
	}
	
	protected /*function */float TdMPGame_PendingMatch_RatePlayerStart(PlayerStart P, byte Team, Controller Player)// state function
	{
		/*local */float Score = default;
	
		Score += ((float)(Rand(100)));
		return ((float)(Max(0, ((int)(Score)))));
	}
	
	protected /*event */void TdMPGame_PendingMatch_HandleSeamlessTravelPlayer(ref Controller C)// state function
	{
		/*Transformed 'base.' to specific call*/GameInfo_HandleSeamlessTravelPlayer(ref/*probably?*/ C);
		HandleLateWarmupJoin(C);
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PendingMatch()/*auto state PendingMatch*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			PostLogin = TdMPGame_PendingMatch_PostLogin;
			StartWarmup = TdMPGame_PendingMatch_StartWarmup;
			HandleLateWarmupJoin = TdMPGame_PendingMatch_HandleLateWarmupJoin;
			EndWarmup = TdMPGame_PendingMatch_EndWarmup;
			Timer = TdMPGame_PendingMatch_Timer;
			RatePlayerStart = TdMPGame_PendingMatch_RatePlayerStart;
			HandleSeamlessTravelPlayer = TdMPGame_PendingMatch_HandleSeamlessTravelPlayer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdMPGame_PendingMatch_BeginState, StateFlow, TdMPGame_PendingMatch_EndState);
	}
	
	
	protected /*function */void TdMPGame_MatchInProgress_BeginState(name PreviousStateName)// state function
	{
		DeadControllers.Remove(0, DeadControllers.Length);
		bInitialSpawn = true;
		InitialSpawn();
		bInitialSpawn = false;
		SetTimer(GlobalPlayerRespawnTime, true, "RespawnTimer", default(Object));
	}
	
	protected /*simulated function */void TdMPGame_MatchInProgress_EndState(name NextStateName)// state function
	{
		DeadControllers.Remove(0, DeadControllers.Length);
		ClearTimer("RespawnTimer", default(Object));
	}
	
	protected /*event */void TdMPGame_MatchInProgress_PostLogin(PlayerController NewPlayer)// state function
	{
		/*Transformed 'base.' to specific call*/GameInfo_PostLogin(NewPlayer);
		AddToRespawnList(NewPlayer);
	}
	
	protected /*function */void TdMPGame_MatchInProgress_Logout(Controller Exiting)// state function
	{
		RemoveFromRespawnList(Exiting);
		/*Transformed 'base.' to specific call*/GameInfo_Logout(Exiting);
	}
	
	protected /*function */void TdMPGame_MatchInProgress_InitialSpawn()// state function
	{
		/*local */TdPlayerController C = default;
		/*local */int SpawnAttempts = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (C = (TdPlayerController)e0.Current) == C)
		{
			SpawnAttempts = 0;
			J0x24:{}
			if(C.IsDead() && !C.PlayerReplicationInfo.bOnlySpectator)
			{
				RestartPlayer(C);
				if(SpawnAttempts >= 3)
				{
					AddToRespawnList(C);
					continue;
				}
				++ SpawnAttempts;
				goto J0x24;
			}		
		}	
	}
	
	protected /*function */void TdMPGame_MatchInProgress_NotifyKilled(Controller Killer, Controller Killed, Pawn KilledPawn)// state function
	{
		global_NotifyKilled(Killer, Killed, KilledPawn);
		AddToRespawnList(Killed);
	}
	
	protected /*event */void TdMPGame_MatchInProgress_Timer()// state function
	{
		global_Timer();
		if(TimeLimit > 0)
		{
			GameReplicationInfo.bStopCountDown = false;
			if(GameReplicationInfo.RemainingTime <= 0)
			{
				EndGame(default(PlayerReplicationInfo), "TimeLimit");
			}
		}
	}
	
	protected /*function */void TdMPGame_MatchInProgress_RespawnTimer()// state function
	{
		/*local */int SpawnAttempts = default, Idx = default;
		/*local */TdPlayerController C = default;
	
		assert(DeadControllers.Length > MaxPlayers);
		Idx = 0;
		J0x18:{}
		if(Idx < DeadControllers.Length)
		{
			if(DeadControllers[Idx].TimeToRespawn <= WorldInfo.TimeSeconds)
			{
				SpawnAttempts = 0;
				C = DeadControllers[Idx].C;
				J0x75:{}
				if(SpawnAttempts <= 3)
				{
					RestartPlayer(C);
					++ SpawnAttempts;
					if(!C.IsDead())
					{
						DeadControllers.Remove(-- Idx, 1);
						goto J0xC4;
					}
					goto J0x75;
				}
				J0xC4:{}
				goto J0xCA;
			}
			goto J0xD4;
			J0xCA:{}
			++ Idx;
			goto J0x18;
		}
		J0xD4:{}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) MatchInProgress()/*state MatchInProgress*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			PostLogin = TdMPGame_MatchInProgress_PostLogin;
			Logout = TdMPGame_MatchInProgress_Logout;
			InitialSpawn = TdMPGame_MatchInProgress_InitialSpawn;
			NotifyKilled = TdMPGame_MatchInProgress_NotifyKilled;
			Timer = TdMPGame_MatchInProgress_Timer;
			RespawnTimer = TdMPGame_MatchInProgress_RespawnTimer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdMPGame_MatchInProgress_BeginState, StateFlow, TdMPGame_MatchInProgress_EndState);
	}
	
	
	protected /*function */void TdMPGame_MatchOver_BeginState(name PreviousStateName)// state function
	{
		SetGameTimer(true, TimeBetweenMatches, 1.0f);
		KillRemainingPlayers();
		ClearRespawnList();
		OpenPostGameScene();
	}
	
	protected /*event */void TdMPGame_MatchOver_Timer()// state function
	{
		global_Timer();
		if(GameReplicationInfo.RemainingTime <= 0)
		{
			RestartGame();
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) MatchOver()/*state MatchOver*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			/*ignores*/ RespawnTimer = ()=>{};
	
			Timer = TdMPGame_MatchOver_Timer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdMPGame_MatchOver_BeginState, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PendingMatch": return PendingMatch();
			case "MatchInProgress": return MatchInProgress();
			case "MatchOver": return MatchOver();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return PendingMatch();
	}
	public TdMPGame()
	{
		// Object Offset:0x005F6A3A
		CriminalClasses = new array<string>
		{
			"TdMpContent.Pawn_CriminalHeavy",
			"TdMpContent.Pawn_CriminalProwler",
			"TdMpContent.Pawn_CriminalFixer",
		};
		PoliceClasses = new array<string>
		{
			"TdMpContent.Pawn_PoliceSWAT",
			"TdMpContent.Pawn_PoliceUndercover",
			"TdMpContent.Pawn_PoliceRiotUnit",
		};
		VictoryMessageClass = ClassT<TdVictoryMessage>()/*Ref Class'TdVictoryMessage'*/;
		bAllowViewTargetSwitching = true;
		HUDType = ClassT<TdMPHUD>()/*Ref Class'TdMPHUD'*/;
		GameMessageClass = ClassT<TdGameMessage>()/*Ref Class'TdGameMessage'*/;
	}
}
}