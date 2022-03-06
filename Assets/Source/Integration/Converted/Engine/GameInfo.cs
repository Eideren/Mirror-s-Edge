// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameInfo : Info/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public bool TdPaused;
	[Const] public bool bEnableLOI;
	public bool bRestartLevel;
	public bool bPauseable;
	public bool bTeamGame;
	public bool bGameEnded;
	public bool bOverTime;
	public bool bDelayedStart;
	public bool bWaitingToStartMatch;
	[globalconfig] public bool bChangeLevels;
	public bool bAlreadyChanged;
	public bool bLoggingGame;
	[globalconfig] public bool bAdminCanPause;
	public bool bGameRestarted;
	public bool bLevelChange;
	[globalconfig] public bool bKickLiveIdlers;
	public bool bUsingArbitration;
	public bool bHasArbitratedHandshakeBegun;
	public bool bNeedsEndGameHandshake;
	public bool bIsEndGameHandshakeComplete;
	public bool bHasEndGameHandshakeBegun;
	public bool bFixedPlayerStart;
	public bool bAutomatedPerfTesting;
	public bool bAutoContinueToNextRound;
	public bool bUsingAutomatedTestingMapList;
	public bool bAutomatedTestingWithOpen;
	public bool bDoingAFlyThrough;
	public bool bCheckingForFragmentation;
	public bool bCheckingForMemLeaks;
	public bool bDoingMemStartupStats;
	public bool bDoFearCostFallOff;
	public bool bUseSeamlessTravel;
	public bool bHasNetworkError;
	[Const] public bool bRequiresPushToTalk;
	public float SavedGameSpeed;
	[Const] public float PauseGameSpeed;
	public int AutomatedPerfRemainingTime;
	public int AutomatedTestingMapIndex;
	[globalconfig] public array</*config */String> AutomatedMapTestingList;
	[globalconfig] public int NumAutomatedMapTestingCycles;
	public int NumberOfMatchesPlayed;
	public int NumMapListCyclesDone;
	public String AutomatedTestingExecCommandToRunAtStartMatch;
	public String AutomatedMapTestingTransitionMap;
	public String BugLocString;
	public String BugRotString;
	public array<PlayerController> PendingArbitrationPCs;
	public array<PlayerController> ArbitrationPCs;
	[globalconfig] public float ArbitrationHandshakeTimeout;
	[globalconfig] public float GameDifficulty;
	[globalconfig] public int GoreLevel;
	public float GameSpeed;
	public Core.ClassT<Pawn> DefaultPawnClass;
	public Core.ClassT<ScoreBoard> ScoreBoardType;
	public Core.ClassT<HUD> HUDType;
	[globalconfig] public int MaxSpectators;
	public int MaxSpectatorsAllowed;
	public int NumSpectators;
	[globalconfig] public int MaxPlayers;
	public int MaxPlayersAllowed;
	public int NumPlayers;
	public int NumBots;
	public int NumTravellingPlayers;
	public int CurrentID;
	[Const, localized] public String DefaultPlayerName;
	[Const, localized] public String GameName;
	public float FearCostFallOff;
	[config] public int GoalScore;
	[config] public int MaxLives;
	[config] public int TimeLimit;
	public Core.ClassT<LocalMessage> DeathMessageClass;
	public Core.ClassT<GameMessage> GameMessageClass;
	public Mutator BaseMutator;
	public Core.ClassT<AccessControl> AccessControlClass;
	public AccessControl AccessControl;
	public GameRules GameRulesModifiers;
	public Core.ClassT<BroadcastHandler> BroadcastHandlerClass;
	public BroadcastHandler BroadcastHandler;
	public Core.ClassT<PlayerController> PlayerControllerClass;
	public Core.ClassT<PlayerReplicationInfo> PlayerReplicationInfoClass;
	public String DialogueManagerClass;
	public DialogueManager DialogueManager;
	[Category] public Core.ClassT<GameReplicationInfo> GameReplicationInfoClass;
	public GameReplicationInfo GameReplicationInfo;
	[globalconfig] public float MaxIdleTime;
	[globalconfig] public float MaxTimeMargin;
	[globalconfig] public float TimeMarginSlack;
	[globalconfig] public float MinTimeMargin;
	public array<PlayerReplicationInfo> InactivePRIArray;
	public array< /*delegate*/GameInfo.CanUnpause > Pausers;
	public OnlineSubsystem OnlineSub;
	public OnlineGameInterface GameInterface;
	public OnlineGameSettings GameSettings;
	public Core.ClassT<OnlineStatsWrite> OnlineStatsWriteClass;
	public/*protected*/ CoverReplicator CoverReplicatorBase;
	[Const] public Core.ClassT<OnlineGameSettings> OnlineGameSettingsClass;
	public String ServerOptions;
	public /*delegate*/GameInfo.CanUnpause __CanUnpause__Delegate;
	
	public override /*event */void PreBeginPlay()
	{
		if(NotEqual_InterfaceInterface(GameInterface, (default(OnlineGameInterface))))
		{
			GameSettings = GameInterface.GetGameSettings();
			if(GameSettings != default)
			{
				bUsingArbitration = GameSettings.bUsesArbitration;
			}
		}
		SetGameSpeed(GameSpeed);
		GameReplicationInfo = Spawn(GameReplicationInfoClass, default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
		WorldInfo.GRI = GameReplicationInfo;
		GameReplicationInfo.bIsArbitrated = bUsingArbitration;
		InitGameReplicationInfo();
		if(DialogueManagerClass != "")
		{
			DialogueManager = Spawn(((DynamicLoadObject(DialogueManagerClass, ClassT<Class>(), default(bool?))) as ClassT<DialogueManager>), default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
		}
	}
	
	public virtual /*function */String FindPlayerByID(int PlayerId)
	{
		/*local */PlayerReplicationInfo PRI = default;
	
		PRI = GameReplicationInfo.FindPlayerByID(PlayerId);
		if(PRI != default)
		{
			return PRI.PlayerName;
		}
		return "";
	}
	
	public /*function */static bool UseLowGore(WorldInfo WI)
	{
		#warning static function overriding is not implemented, this function looks like it relies on it
		// thankfully it is never overriden so the line below has been changed to work around the issue
		// Note: DefaultAs returns a new object of the instance from which we called the static function,
		//       it can be 'GameInfo' or any other class deriving from it. 
		
		//return (DefaultAs<GameInfo>().GoreLevel > 0) && ((int)WI.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/);
		return (new GameInfo().GoreLevel > 0) && ((int)WI.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/);
	}
	
	public virtual /*function */CoverReplicator GetCoverReplicator()
	{
		if((CoverReplicatorBase == default) && ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			CoverReplicatorBase = Spawn(ClassT<CoverReplicator>(), default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
		}
		return CoverReplicatorBase;
	}
	
	public override /*event */void eventPostBeginPlay()
	{
		if(MaxIdleTime > ((float)(0)))
		{
			MaxIdleTime = FMax(MaxIdleTime, 20.0f);
		}
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
		{
			UpdateGameSettings();
		}
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? GameInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => GameInfo_Reset;
	public /*function */void GameInfo_Reset()
	{
		/*Transformed 'base.' to specific call*/Actor_Reset();
		bGameEnded = false;
		bOverTime = false;
		InitGameReplicationInfo();
	}
	
	public virtual /*function */bool ShouldReset(Actor ActorToReset)
	{
		return true;
	}
	
	public virtual /*function */void ResetLevel()
	{
		/*local */Controller C = default;
		/*local */Actor A = default;
		/*local */Sequence GameSeq = default;
		/*local */array<SequenceObject> AllSeqEvents = default;
		/*local */int I = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e0.MoveNext() && (C = (Controller)e0.Current) == C)
		{
			if(((C) as PlayerController) != default)
			{
				((C) as PlayerController).ClientReset();
			}
			C.Reset();		
		}	
		
		// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e92 = AllActors(ClassT<Actor>()).GetEnumerator();
		while(e92.MoveNext() && (A = (Actor)e92.Current) == A)
		{
			if(((A != this) && !A.IsA("Controller")) && ShouldReset(A))
			{
				A.Reset();
			}		
		}	
		Reset();
		GameSeq = WorldInfo.GetGameSequence();
		if(GameSeq != default)
		{
			GameSeq.Reset();
			GameSeq.FindSeqObjectsByClass(ClassT<SeqEvent_LevelReset>(), true, ref/*probably?*/ AllSeqEvents);
			I = 0;
			J0x11E:{}
			if(I < AllSeqEvents.Length)
			{
				((AllSeqEvents[I]) as SeqEvent_LevelReset).CheckActivate(WorldInfo, default, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
				++ I;
				goto J0x11E;
			}
		}
	}
	
	public override Timer_del Timer { get => bfield_Timer ?? GameInfo_Timer; set => bfield_Timer = value; } Timer_del bfield_Timer;
	public override Timer_del global_Timer => GameInfo_Timer;
	public /*event */void GameInfo_Timer()
	{
		BroadcastHandler.UpdateSentText();
		if(bDoFearCostFallOff)
		{
			DoNavFearCostFallOff();
		}
		if((bAutomatedPerfTesting && AutomatedPerfRemainingTime > 0) && bAutoContinueToNextRound == false)
		{
			-- AutomatedPerfRemainingTime;
			if(AutomatedPerfRemainingTime <= 0)
			{
				ConsoleCommand("EXIT", default(bool?));
			}
		}
	}
	
	// Export UGameInfo::execDoNavFearCostFallOff(FFrame&, void* const)
	public virtual /*native final function */void DoNavFearCostFallOff()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*function */void NotifyNavigationChanged(NavigationPoint N)
	{
	
	}
	
	public virtual /*event */void GameEnding()
	{
		EndLogging("serverquit");
	}
	
	public virtual /*event */void KickIdler(PlayerController PC)
	{
		AccessControl.KickPlayer(PC, AccessControl.IdleKickReason);
	}
	
	public virtual /*function */void InitGameReplicationInfo()
	{
		GameReplicationInfo.GameClass = (ClassT<GameInfo>)Class;
		GameReplicationInfo.MaxLives = MaxLives;
	}
	
	// Export UGameInfo::execGetNetworkNumber(FFrame&, void* const)
	public virtual /*native function */String GetNetworkNumber()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*function */int GetNumPlayers()
	{
		return NumPlayers + NumTravellingPlayers;
	}
	
	public virtual /*function */int GetServerPort()
	{
		/*local */String S = default;
		/*local */int I = default;
	
		S = WorldInfo.GetAddressURL();
		I = InStr(S, ":", default(bool?));
		assert(I >= 0);
		return StringToInt((Mid(S, I + 1, default(int?))));
	}
	
	public delegate bool CanOpenPauseMenu_del();
	public virtual CanOpenPauseMenu_del CanOpenPauseMenu { get => bfield_CanOpenPauseMenu ?? GameInfo_CanOpenPauseMenu; set => bfield_CanOpenPauseMenu = value; } CanOpenPauseMenu_del bfield_CanOpenPauseMenu;
	public virtual CanOpenPauseMenu_del global_CanOpenPauseMenu => GameInfo_CanOpenPauseMenu;
	public /*function */bool GameInfo_CanOpenPauseMenu()
	{
		return true;
	}


	#warning Default declaration for delegate split into own function
	public delegate bool CanUnpause();
	public bool CanUnpause_Default()
	{
		return true;
	}
	
	public virtual /*function */bool SetPause(PlayerController PC, /*optional *//*delegate*/GameInfo.CanUnpause _CanUnpauseDelegate = default)
	{
		/*local */int FoundIndex = default;
	
		var CanUnpauseDelegate = _CanUnpauseDelegate ?? default;
		if((((bPauseable || bAdminCanPause && AccessControl.IsAdmin(PC))) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)))
		{
			FoundIndex = Pausers.Find(CanUnpauseDelegate);
			if(FoundIndex == -1)
			{
				FoundIndex = Pausers.Length;
				Pausers.Length = FoundIndex + 1;
				Pausers[FoundIndex] = CanUnpauseDelegate;
			}
			if(WorldInfo.Pauser == default)
			{
				WorldInfo.Pauser = PC.PlayerReplicationInfo;
			}
			return true;
		}
		return false;
	}
	
	public virtual /*function */void ClearPause()
	{
		/*local */int Index = default;
		/*local *//*delegate*/GameInfo.CanUnpause CanUnpauseCriteriaMet = default;
	
		Index = 0;
		J0x07:{}
		if(Index < Pausers.Length)
		{
			CanUnpauseCriteriaMet = Pausers[Index];
			#warning Changed to default declaration
			//if(CanUnpause())
			if(CanUnpause_Default())
			{
				Pausers.Remove(Index, 1);
				-- Index;
			}
			++ Index;
			goto J0x07;
		}
		if(Pausers.Length == 0)
		{
			WorldInfo.Pauser = default;
		}
	}
	
	public virtual /*function */void DebugPause()
	{
		/*local */int Index = default;
		/*local *//*delegate*/GameInfo.CanUnpause CanUnpauseCriteriaMet = default;
	
		Index = 0;
		J0x07:{}
		if(Index < Pausers.Length)
		{
			CanUnpauseCriteriaMet = Pausers[Index];
			#warning Changed to default declaration
			if(CanUnpause_Default())
			//if(CanUnpause())
			{			
			}
			++ Index;
			goto J0x07;
		}
	}
	
	public virtual /*exec function */void TdPause()
	{
		if(TdPaused && WorldInfo.TimeDilation != PauseGameSpeed)
		{
			TdPaused = false;
		}
		TdPaused = !TdPaused;
		if(TdPaused)
		{
			SavedGameSpeed = WorldInfo.TimeDilation;
		}
		WorldInfo.TimeDilation = ((TdPaused) ? PauseGameSpeed : SavedGameSpeed);
	}
	
	// Export UGameInfo::execIsTdPaused(FFrame&, void* const)
	public virtual /*native function */bool IsTdPaused()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public virtual /*function */void SetGameSpeed(float T)
	{
		GameSpeed = FMax(T, 0.10f);
		WorldInfo.TimeDilation = GameSpeed;
		SetTimer(WorldInfo.TimeDilation, true, default(name?), default(Object));
	}
	
	public /*function */static bool GrabOption(ref String Options, ref String Result)
	{
		if(Left(Options, 1) == "?")
		{
			Result = Mid(Options, 1, default(int?));
			if(InStr(Result, "?", default(bool?)) >= 0)
			{
				Result = Left(Result, InStr(Result, "?", default(bool?)));
			}
			Options = Mid(Options, 1, default(int?));
			if(InStr(Options, "?", default(bool?)) >= 0)
			{
				Options = Mid(Options, InStr(Options, "?", default(bool?)), default(int?));			
			}
			else
			{
				Options = "";
			}
			return true;		
		}
		else
		{
			return false;
		}
	}
	
	public /*function */static void GetKeyValue(String Pair, ref String Key, ref String Value)
	{
		if(InStr(Pair, "=", default(bool?)) >= 0)
		{
			Key = Left(Pair, InStr(Pair, "=", default(bool?)));
			Value = Mid(Pair, InStr(Pair, "=", default(bool?)) + 1, default(int?));		
		}
		else
		{
			Key = Pair;
			Value = "";
		}
	}
	
	public /*function */static String ParseOption(String Options, String InKey)
	{
		/*local */String Pair = default, Key = default, Value = default;
	
	
		J0x00:{}	if(GrabOption(ref/*probably?*/ Options, ref/*probably?*/ Pair))
		{
			GetKeyValue(Pair, ref/*probably?*/ Key, ref/*probably?*/ Value);
			if(ApproximatelyEqual(Key, InKey))
			{
				return Value;
			}
			goto J0x00;
		}
		return "";
	}
	
	public /*function */static bool HasOption(String Options, String InKey)
	{
		/*local */String Pair = default, Key = default, Value = default;
	
	
		J0x00:{}	if(GrabOption(ref/*probably?*/ Options, ref/*probably?*/ Pair))
		{
			GetKeyValue(Pair, ref/*probably?*/ Key, ref/*probably?*/ Value);
			if(ApproximatelyEqual(Key, InKey))
			{
				return true;
			}
			goto J0x00;
		}
		return false;
	}
	
	public /*function */static int GetIntOption(String Options, String ParseString, int CurrentValue)
	{
		/*local */String InOpt = default;
	
		InOpt = ParseOption(Options, ParseString);
		if(InOpt != "")
		{
			return StringToInt((InOpt));
		}
		return CurrentValue;
	}
	
	public /*event */static Core.ClassT<GameInfo> SetGameType(String MapName, String Options, String Portal)
	{
		#warning static function overriding is not implemented, this function looks like it relies on it
		// thankfully it is never overriden so the line below has been changed to work around the issue
		// Note: DefaultAs returns a new object of the instance from which we called the static function,
		//       it can be 'GameInfo' or any other class deriving from it. 

		//return DefaultAs<Object>().Class;
		return ClassT<GameInfo>();
	}
	
	public virtual /*event */void InitGame(String Options, ref String ErrorMessage)
	{
		/*local */String InOpt = default, LeftOpt = default;
		/*local */int pos = default;
		/*local */Core.ClassT<AccessControl> ACClass = default;
	
		MaxPlayers = Clamp(GetIntOption(Options, "MaxPlayers", MaxPlayers), 0, MaxPlayersAllowed);
		MaxSpectators = Clamp(GetIntOption(Options, "MaxSpectators", MaxSpectators), 0, MaxSpectatorsAllowed);
		GameDifficulty = FMax(0.0f, ((float)(GetIntOption(Options, "Difficulty", ((int)(GameDifficulty))))));
		InOpt = ParseOption(Options, "GameSpeed");
		if(InOpt != "")
		{
			SetGameSpeed(StringToFloat((InOpt)));
		}
		TimeLimit = Max(0, GetIntOption(Options, "TimeLimit", TimeLimit));
		AutomatedPerfRemainingTime = 60 * TimeLimit;
		BroadcastHandler = Spawn(BroadcastHandlerClass, default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
		InOpt = ParseOption(Options, "AccessControl");
		if(InOpt != "")
		{
			ACClass = ((DynamicLoadObject(InOpt, ClassT<Class>(), default(bool?))) as ClassT<AccessControl>);
		}
		if(ACClass == default)
		{
			ACClass = AccessControlClass;
		}
		LeftOpt = ParseOption(Options, "AdminName");
		InOpt = ParseOption(Options, "AdminPassword");
		if(((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/)) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)))
		{
			AccessControl = Spawn(ACClass, default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
			if((AccessControl != default) && InOpt != "")
			{
				AccessControl.SetAdminPassword(InOpt);
			}
		}
		InOpt = ParseOption(Options, "Mutator");
		if(InOpt != "")
		{
			J0x26A:{}
			if(InOpt != "")
			{
				pos = InStr(InOpt, ",", default(bool?));
				if(pos > 0)
				{
					LeftOpt = Left(InOpt, pos);
					InOpt = Right(InOpt, (Len(InOpt) - pos) - 1);				
				}
				else
				{
					LeftOpt = InOpt;
					InOpt = "";
				}
				AddMutator(LeftOpt, true);
				goto J0x26A;
			}
		}
		InOpt = ParseOption(Options, "GamePassword");
		if((InOpt != "") && AccessControl != default)
		{
			AccessControl.SetGamePassword(InOpt);
		}
		bAutomatedPerfTesting = ApproximatelyEqual((ParseOption(Options, "AutomatedPerfTesting")), "1");
		bFixedPlayerStart = ApproximatelyEqual((ParseOption(Options, "FixedPlayerStart")), "1");
		bDoingAFlyThrough = ApproximatelyEqual((ParseOption(Options, "causeevent")), "FlyThrough");
		bCheckingForFragmentation = ApproximatelyEqual((ParseOption(Options, "CheckingForFragmentation")), "1");
		bCheckingForMemLeaks = ApproximatelyEqual((ParseOption(Options, "CheckingForMemLeaks")), "1");
		bDoingMemStartupStats = ApproximatelyEqual((ParseOption(Options, "DoingMemStartupStats")), "1");
		BugLocString = ParseOption(Options, "BugLoc");
		BugRotString = ParseOption(Options, "BugRot");
		if(BaseMutator != default)
		{
			BaseMutator.InitMutator(Options, ref/*probably?*/ ErrorMessage);
		}
		OnlineSub = GameEngine.GetOnlineSubsystem();
		if(OnlineSub != default)
		{
			GameInterface = OnlineSub.GameInterface;
		}
		if((((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface)))) && GameInterface.GetGameSettings() == default)
		{
			ServerOptions = Options;
			if((ProcessServerLogin()) == false)
			{
				RegisterServer();
			}
		}
	}
	
	public virtual /*function */void ParseAutomatedTestingOptions(String Options)
	{
		/*local */String InOpt = default;
	
		InOpt = ParseOption(Options, "bUsingAutomatedTestingMapList");
		if(InOpt != "")
		{
			bUsingAutomatedTestingMapList = StringToBool((InOpt));
		}
		if(bUsingAutomatedTestingMapList == true)
		{
			if(AutomatedMapTestingList.Length == 0)
			{
				bUsingAutomatedTestingMapList = false;
			}
		}
		InOpt = ParseOption(Options, "bAutomatedTestingWithOpen");
		if(InOpt != "")
		{
			bAutomatedTestingWithOpen = StringToBool((InOpt));
		}
		AutomatedTestingExecCommandToRunAtStartMatch = ParseOption(Options, "AutomatedTestingExecCommandToRunAtStartMatch");
		AutomatedMapTestingTransitionMap = ParseOption(Options, "AutomatedMapTestingTransitionMap");
		InOpt = ParseOption(Options, "AutomatedTestingMapIndex");
		if(InOpt != "")
		{
			AutomatedTestingMapIndex = StringToInt((InOpt));
		}
		if(bAutomatedTestingWithOpen == true)
		{
			InOpt = ParseOption(Options, "NumberOfMatchesPlayed");
			if(InOpt != "")
			{
				NumberOfMatchesPlayed = StringToInt((InOpt));
			}
			InOpt = ParseOption(Options, "NumMapListCyclesDone");
			if(InOpt != "")
			{
				NumMapListCyclesDone = StringToInt((InOpt));
			}		
		}
		else
		{
			AutomatedMapTestingTransitionMap = "";
		}
	}
	
	public virtual /*function */void AddMutator(String mutname, /*optional */bool? _bUserAdded = default)
	{
		/*local */Core.ClassT<Mutator> mutClass = default;
		/*local */Mutator mut = default;
		/*local */int I = default;
	
		var bUserAdded = _bUserAdded ?? default;
		if(!AllowMutator(mutname))
		{
			return;
		}
		mutClass = ((DynamicLoadObject(mutname, ClassT<Class>(), default(bool?))) as ClassT<Mutator>);
		if(mutClass == default)
		{
			return;
		}
		if((mutClass.DefaultAs<Mutator>().GroupNames.Length > 0) && BaseMutator != default)
		{
			mut = BaseMutator;
			J0x6E:{}
			if(mut != default)
			{
				I = 0;
				J0x80:{}
				if(I < mut.GroupNames.Length)
				{
					if(mutClass.DefaultAs<Mutator>().GroupNames.Find(mut.GroupNames[I]) != -1)
					{
						return;
					}
					++ I;
					goto J0x80;
				}
				mut = mut.NextMutator;
				goto J0x6E;
			}
		}
		mut = BaseMutator;
		J0xFA:{}
		if(mut != default)
		{
			if(mut.Class == mutClass)
			{
				return;
			}
			mut = mut.NextMutator;
			goto J0xFA;
		}
		mut = Spawn(mutClass, default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
		if(mut == default)
		{
			return;
		}
		mut.bUserAdded = bUserAdded;
		if(BaseMutator == default)
		{
			BaseMutator = mut;		
		}
		else
		{
			BaseMutator.AddMutator(mut);
		}
	}
	
	public virtual /*function */void AddGameRules(Core.ClassT<GameRules> GRClass)
	{
		if(GRClass != default)
		{
			if(GameRulesModifiers == default)
			{
				GameRulesModifiers = Spawn(GRClass, default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));			
			}
			else
			{
				GameRulesModifiers.AddGameRules(Spawn(GRClass, default(Actor), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?)));
			}
		}
	}
	
	public virtual /*function */void RemoveMutator(Mutator MutatorToRemove)
	{
		/*local */Mutator M = default;
	
		if(BaseMutator == MutatorToRemove)
		{
			BaseMutator = MutatorToRemove.NextMutator;		
		}
		else
		{
			if(BaseMutator != default)
			{
				M = BaseMutator;
				J0x3D:{}
				if(M != default)
				{
					if(M.NextMutator == MutatorToRemove)
					{
						M.NextMutator = MutatorToRemove.NextMutator;
						goto J0x9B;
					}
					M = M.NextMutator;
					goto J0x3D;
				}
			}
		}
		J0x9B:{}
	}
	
	public virtual /*event */String GetBeaconText()
	{
		return (((((WorldInfo.ComputerName + " ") + Left(WorldInfo.Title, 24)) + "\\t") + ((GetNumPlayers())).ToString()) + "/") + ((MaxPlayers)).ToString();
	}
	
	public virtual /*function */void ProcessServerTravel(String URL, /*optional */bool? _bAbsolute = default)
	{
		/*local */PlayerController P = default, LocalPlayer = default;
		/*local */bool bSeamless = default;
		/*local */String NextMap = default;
		/*local */Object.Guid NextMapGuid = default;
		/*local */int OptionStart = default;
	
		var bAbsolute = _bAbsolute ?? default;
		bLevelChange = true;
		EndLogging("mapchange");
		bSeamless = bUseSeamlessTravel && WorldInfo.TimeSeconds < 172800.0f;
		if(InStr(Caps(URL), "?RESTART", default(bool?)) != -1)
		{
			NextMap = ((WorldInfo.GetPackageName())).ToString();		
		}
		else
		{
			OptionStart = InStr(URL, "?", default(bool?));
			if(OptionStart == -1)
			{
				NextMap = URL;			
			}
			else
			{
				NextMap = Left(URL, OptionStart);
			}
		}
		NextMapGuid = GetPackageGuid(((name)(NextMap)));
		
		// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ P)
		using var e210 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e210.MoveNext() && (P = (PlayerController)e210.Current) == P)
		{
			if(AsNetConnection(P.Player) != default)
			{
				P.ClientTravel(URL, Actor.ETravelType.TRAVEL_Relative/*2*/, bSeamless, NextMapGuid);
				continue;
			}
			LocalPlayer = P;
			P.PreClientTravel();		
		}	
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/)) && LocalPlayer != default)
		{
			WorldInfo.NextURL = (((((((WorldInfo.NextURL + "?Team=") + LocalPlayer.GetDefaultURL("Team")) + "?Name=") + LocalPlayer.GetDefaultURL("Name")) + "?Class=") + LocalPlayer.GetDefaultURL("Class")) + "?Character=") + LocalPlayer.GetDefaultURL("Character");
		}
		if(bSeamless)
		{
			WorldInfo.SeamlessTravel(WorldInfo.NextURL, bAbsolute, default(Object.Guid?));
			WorldInfo.NextURL = "";		
		}
		else
		{
			if((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) && ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/))
			{
				WorldInfo.NextSwitchCountdown = 0.0f;
			}
		}
	}
	
	public virtual /*function */bool RequiresPassword()
	{
		return (AccessControl != default) && AccessControl.RequiresPassword();
	}
	
	public virtual /*event */void PreLogin(String Options, String Address, ref String ErrorMessage)
	{
		/*local */bool bSpectator = default, bPerfTesting = default;
	
		if(((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && bUsingArbitration) && bHasArbitratedHandshakeBegun)
		{
			ErrorMessage = GameMessageClass.DefaultAs<GameMessage>().ArbitrationMessage;
			return;
		}
		bPerfTesting = ApproximatelyEqual((ParseOption(Options, "AutomatedPerfTesting")), "1");
		bSpectator = (bPerfTesting || ApproximatelyEqual((ParseOption(Options, "SpectatorOnly")), "1"));
		if(AccessControl != default)
		{
			AccessControl.PreLogin(Options, Address, ref/*probably?*/ ErrorMessage, bSpectator);
		}
	}
	
	public virtual /*function */bool AtCapacity(bool bSpectator)
	{
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			return false;
		}
		if(bSpectator)
		{
			return (NumSpectators >= MaxSpectators) && ((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/)) || NumPlayers > 0);		
		}
		else
		{
			return (MaxPlayers > 0) && (GetNumPlayers()) >= MaxPlayers;
		}
	}
	
	public virtual /*event */PlayerController Login(String Portal, String Options, ref String ErrorMessage)
	{
		/*local */NavigationPoint StartSpot = default;
		/*local */PlayerController NewPlayer = default;
		/*local */String InName = default, inCharacter = default, InPassword = default;
		/*local */byte InTeam = default;
		/*local */bool bSpectator = default, bAdmin = default, bPerfTesting = default;
		/*local */Object.Rotator SpawnRotation = default;
	
		bAdmin = false;
		if(bUsingArbitration && bHasArbitratedHandshakeBegun)
		{
			ErrorMessage = GameMessageClass.DefaultAs<GameMessage>().MaxedOutMessage;
			return default;
		}
		if(BaseMutator != default)
		{
			BaseMutator.ModifyLogin(ref/*probably?*/ Portal, ref/*probably?*/ Options);
		}
		bPerfTesting = ApproximatelyEqual((ParseOption(Options, "AutomatedPerfTesting")), "1");
		bSpectator = (bPerfTesting || ApproximatelyEqual((ParseOption(Options, "SpectatorOnly")), "1"));
		InName = Left(ParseOption(Options, "Name"), 20);
		InTeam = (byte)((byte)(GetIntOption(Options, "Team", 255)));
		InPassword = ParseOption(Options, "Password");
		if(AccessControl != default)
		{
			bAdmin = AccessControl.ParseAdminOptions(Options);
		}
		if(!bAdmin && AtCapacity(bSpectator))
		{
			ErrorMessage = GameMessageClass.DefaultAs<GameMessage>().MaxedOutMessage;
			return default;
		}
		if(bAdmin && AtCapacity(false))
		{
			bSpectator = true;
		}
		InTeam = (byte)PickTeam((byte)InTeam, default);
		StartSpot = FindPlayerStart(default, (byte)InTeam, Portal);
		if(StartSpot == default)
		{
			ErrorMessage = GameMessageClass.DefaultAs<GameMessage>().FailedPlaceMessage;
			return default;
		}
		SpawnRotation.Yaw = StartSpot.Rotation.Yaw;
		NewPlayer = Spawn(PlayerControllerClass, default(Actor), default(name?), StartSpot.Location, SpawnRotation, default(Actor), default(bool?));
		if(NewPlayer == default)
		{
			ErrorMessage = GameMessageClass.DefaultAs<GameMessage>().FailedSpawnMessage;
			return default;
		}
		NewPlayer.StartSpot = StartSpot;
		NewPlayer.PlayerReplicationInfo.PlayerId = ++ CurrentID;
		if(InName == "")
		{
			InName = DefaultPlayerName + ((NewPlayer.PlayerReplicationInfo.PlayerId)).ToString();
		}
		ChangeName(NewPlayer, InName, false);
		inCharacter = ParseOption(Options, "Character");
		NewPlayer.SetCharacter(inCharacter);
		if((((bSpectator || NewPlayer.PlayerReplicationInfo.bOnlySpectator)) || !ChangeTeam(NewPlayer, ((int)InTeam), false)))
		{
			NewPlayer.GotoState("Spectating", default(name?), default(bool?), default(bool?));
			NewPlayer.PlayerReplicationInfo.bOnlySpectator = true;
			NewPlayer.PlayerReplicationInfo.bIsSpectator = true;
			NewPlayer.PlayerReplicationInfo.bOutOfLives = true;
			return NewPlayer;
		}
		if((AccessControl != default) && AccessControl.AdminLogin(NewPlayer, InPassword))
		{
			AccessControl.AdminEntered(NewPlayer);
		}
		if(bDelayedStart)
		{
			NewPlayer.GotoState("PlayerWaiting", default(name?), default(bool?), default(bool?));
			return NewPlayer;
		}
		return NewPlayer;
	}
	
	public delegate void StartMatch_del();
	public virtual StartMatch_del StartMatch { get => bfield_StartMatch ?? GameInfo_StartMatch; set => bfield_StartMatch = value; } StartMatch_del bfield_StartMatch;
	public virtual StartMatch_del global_StartMatch => GameInfo_StartMatch;
	public /*function */void GameInfo_StartMatch()
	{
		/*local */Actor A = default;
	
		
		// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e0 = AllActors(ClassT<Actor>()).GetEnumerator();
		while(e0.MoveNext() && (A = (Actor)e0.Current) == A)
		{
			A.MatchStarting();		
		}	
		StartHumans();
		StartBots();
		bWaitingToStartMatch = false;
		StartOnlineGame();
		WorldInfo.NotifyMatchStarted(default(bool?), default(bool?), default(bool?));
	}
	
	public virtual /*function */void StartOnlineGame()
	{
		if(NotEqual_InterfaceInterface(GameInterface, (default(OnlineGameInterface))))
		{
			GameInterface.AddStartOnlineGameCompleteDelegate(OnStartOnlineGameComplete);
			GameInterface.StartOnlineGame();		
		}
		else
		{
			GameReplicationInfo.StartMatch();
		}
	}
	
	public virtual /*function */void OnStartOnlineGameComplete(bool bWasSuccessful)
	{
		/*local */PlayerController PC = default;
		/*local */String StatGuid = default;
	
		GameInterface.ClearStartOnlineGameCompleteDelegate(OnStartOnlineGameComplete);
		if(bWasSuccessful && NotEqual_InterfaceInterface(OnlineSub.StatsInterface, (default(OnlineStatsInterface))))
		{
			StatGuid = OnlineSub.StatsInterface.GetHostStatGuid();
			if(StatGuid != "")
			{
				
				// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
				using var e120 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
				while(e120.MoveNext() && (PC = (PlayerController)e120.Current) == PC)
				{
					if(PC.IsLocalPlayerController() == false)
					{
						PC.ClientRegisterHostStatGuid(StatGuid);
					}				
				}			
			}
		}
		GameReplicationInfo.StartMatch();
	}
	
	public virtual /*function */void StartHumans()
	{
		/*local */PlayerController P = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ P)
		using var e0 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (P = (PlayerController)e0.Current) == P)
		{
			if(P.Pawn == default)
			{
				if(bGameEnded)
				{				
					return;
					continue;
				}
				if(P.CanRestartPlayer())
				{
					RestartPlayer(P);
				}
			}		
		}	
	}
	
	public virtual /*function */void StartBots()
	{
		/*local */Controller P = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ P)
		using var e0 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e0.MoveNext() && (P = (Controller)e0.Current) == P)
		{
			if(P.bIsPlayer && !P.IsA("PlayerController"))
			{
				if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
				{
					RestartPlayer(P);
					continue;
				}
				P.GotoState("Dead", "MPStart", default(bool?), default(bool?));
			}		
		}	
	}
	
	public virtual /*function */void RestartPlayer(Controller NewPlayer)
	{
		/*local */NavigationPoint StartSpot = default;
		/*local */int TeamNum = default, Idx = default;
		/*local */array<SequenceObject> Events = default;
		/*local */SeqEvent_PlayerSpawned SpawnedEvent = default;
	
		if((bRestartLevel && ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) && ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/))
		{
			return;
		}
		TeamNum = ((((NewPlayer.PlayerReplicationInfo == default) || NewPlayer.PlayerReplicationInfo.Team == default)) ? 255 : NewPlayer.PlayerReplicationInfo.Team.TeamIndex);
		StartSpot = FindPlayerStart(NewPlayer, (byte)((byte)(TeamNum)), default(String?));
		if(StartSpot == default)
		{
			if(NewPlayer.StartSpot != default)
			{
				StartSpot = NewPlayer.StartSpot;			
			}
			else
			{
				return;
			}
		}
		if(NewPlayer.Pawn == default)
		{
			NewPlayer.Pawn = SpawnDefaultPawnFor(NewPlayer, StartSpot);
		}
		if(NewPlayer.Pawn == default)
		{
			NewPlayer.GotoState("Dead", default(name?), default(bool?), default(bool?));
			if(((NewPlayer) as PlayerController) != default)
			{
				((NewPlayer) as PlayerController).ClientGotoState("Dead", "Begin");
			}		
		}
		else
		{
			NewPlayer.Pawn.SetAnchor(StartSpot);
			if(((NewPlayer) as PlayerController) != default)
			{
				((NewPlayer) as PlayerController).TimeMargin = -0.10f;
				StartSpot.AnchoredPawn = default;
			}
			NewPlayer.Pawn.LastStartSpot = ((StartSpot) as PlayerStart);
			NewPlayer.Pawn.LastStartTime = WorldInfo.TimeSeconds;
			NewPlayer.Possess(NewPlayer.Pawn, false);
			NewPlayer.Pawn.PlayTeleportEffect(true, true);
			NewPlayer.ClientSetRotation(NewPlayer.Pawn.Rotation, default(bool?));
			if(!WorldInfo.bNoDefaultInventoryForPlayer)
			{
				AddDefaultInventory(NewPlayer.Pawn);
			}
			SetPlayerDefaults(NewPlayer.Pawn);
			if(WorldInfo.GetGameSequence() != default)
			{
				WorldInfo.GetGameSequence().FindSeqObjectsByClass(ClassT<SeqEvent_PlayerSpawned>(), true, ref/*probably?*/ Events);
				Idx = 0;
				J0x348:{}
				if(Idx < Events.Length)
				{
					SpawnedEvent = ((Events[Idx]) as SeqEvent_PlayerSpawned);
					if((SpawnedEvent != default) && SpawnedEvent.CheckActivate(NewPlayer, NewPlayer, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?)))
					{
						SpawnedEvent.SpawnPoint = StartSpot;
						SpawnedEvent.PopulateLinkedVariableValues();
					}
					++ Idx;
					goto J0x348;
				}
			}
		}
	}
	
	public virtual /*function */Pawn SpawnDefaultPawnFor(Controller NewPlayer, NavigationPoint StartSpot)
	{
		/*local */Core.ClassT<Pawn> DefaultPlayerClass = default;
		/*local */Object.Rotator StartRotation = default;
		/*local */Pawn ResultPawn = default;
	
		DefaultPlayerClass = GetDefaultPlayerClass(NewPlayer);
		StartRotation.Yaw = StartSpot.Rotation.Yaw;
		ResultPawn = Spawn(DefaultPlayerClass, default(Actor), default(name?), StartSpot.Location, StartRotation, default(Actor), default(bool?));
		if(ResultPawn == default)
		{
		}
		return ResultPawn;
	}
	
	public virtual /*function */Core.ClassT<Pawn> GetDefaultPlayerClass(Controller C)
	{
		return DefaultPawnClass;
	}
	
	public virtual /*function */void ReplicateStreamingStatus(PlayerController PC)
	{
		/*local */int LevelIndex = default;
		/*local */LevelStreaming TheLevel = default;
	
		if((((PC.Player) as LocalPlayer) == default) && AsChildConnection(PC.Player) == default)
		{
			if(WorldInfo.CommittedLevelNames.Length > 0)
			{
				LevelIndex = 0;
				J0x53:{}
				if(LevelIndex < WorldInfo.CommittedLevelNames.Length)
				{
					PC.ClientPrepareMapChange(WorldInfo.CommittedLevelNames[LevelIndex], LevelIndex == 0, LevelIndex == (WorldInfo.CommittedLevelNames.Length - 1));
					++ LevelIndex;
					goto J0x53;
				}
				PC.ClientCommitMapChange(default(bool?), default(bool?));
			}
			if(WorldInfo.StreamingLevels.Length > 0)
			{
				LevelIndex = 0;
				J0xF5:{}
				if(LevelIndex < WorldInfo.StreamingLevels.Length)
				{
					TheLevel = WorldInfo.StreamingLevels[LevelIndex];
					if(TheLevel != default)
					{
						PC.ClientUpdateLevelStreamingStatus(TheLevel.PackageName, TheLevel.bShouldBeLoaded, TheLevel.bShouldBeVisible, TheLevel.bShouldBlockOnLoad);
					}
					++ LevelIndex;
					goto J0xF5;
				}
				PC.ClientFlushLevelStreaming();
			}
			if(WorldInfo.PreparingLevelNames.Length > 0)
			{
				LevelIndex = 0;
				J0x1BB:{}
				if(LevelIndex < WorldInfo.PreparingLevelNames.Length)
				{
					PC.ClientPrepareMapChange(WorldInfo.PreparingLevelNames[LevelIndex], LevelIndex == 0, LevelIndex == (WorldInfo.PreparingLevelNames.Length - 1));
					++ LevelIndex;
					goto J0x1BB;
				}
			}
		}
	}
	
	public delegate void PostLogin_del(PlayerController NewPlayer);
	public virtual PostLogin_del PostLogin { get => bfield_PostLogin ?? GameInfo_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public virtual PostLogin_del global_PostLogin => GameInfo_PostLogin;
	public /*event */void GameInfo_PostLogin(PlayerController NewPlayer)
	{
		/*local */String Address = default, StatGuid = default;
		/*local */int pos = default;
	
		if(NewPlayer.PlayerReplicationInfo.bOnlySpectator)
		{
			++ NumSpectators;		
		}
		else
		{
			if((WorldInfo.IsInSeamlessTravel() || NewPlayer.HasClientLoadedCurrentWorld()))
			{
				++ NumPlayers;			
			}
			else
			{
				++ NumTravellingPlayers;
			}
		}
		UpdateGameSettingsCounts();
		Address = NewPlayer.GetPlayerNetworkAddress();
		pos = InStr(Address, ":", default(bool?));
		NewPlayer.PlayerReplicationInfo.SavedNetworkAddress = ((pos > 0) ? Left(Address, pos) : Address);
		FindInactivePRI(NewPlayer);
		if(!bDelayedStart)
		{
			bRestartLevel = false;
			if(bWaitingToStartMatch)
			{
				StartMatch();			
			}
			else
			{
				RestartPlayer(NewPlayer);
			}
			bRestartLevel = DefaultAs<GameInfo>().bRestartLevel;
		}
		NewPlayer.ClientSetHUD(HUDType, ScoreBoardType);
		if(NewPlayer.Pawn != default)
		{
			NewPlayer.Pawn.ClientSetRotation(NewPlayer.Pawn.Rotation);
		}
		NewPlayer.ClientCapBandwidth(NewPlayer.Player.CurrentNetSpeed);
		if(BaseMutator != default)
		{
			BaseMutator.NotifyLogin(NewPlayer);
		}
		ReplicateStreamingStatus(NewPlayer);
		NewPlayer.ServerSendMusicInfo();
		if(CoverReplicatorBase != default)
		{
			NewPlayer.SpawnCoverReplicator();
		}
		NewPlayer.ClientSetOnlineStatus();
		if((GameReplicationInfo.bMatchHasBegun && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.StatsInterface, (default(OnlineStatsInterface))))
		{
			StatGuid = OnlineSub.StatsInterface.GetHostStatGuid();
			if(StatGuid != "")
			{
				NewPlayer.ClientRegisterHostStatGuid(StatGuid);
			}
		}
		if(bRequiresPushToTalk)
		{
			NewPlayer.ClientStopNetworkedVoice();		
		}
		else
		{
			NewPlayer.ClientStartNetworkedVoice();
		}
		if(NewPlayer.PlayerReplicationInfo.bOnlySpectator)
		{
			NewPlayer.ClientGotoState("Spectating", default(name?));
		}
	}
	
	public virtual /*event */void PreExit()
	{
	
	}
	
	public delegate void Logout_del(Controller Exiting);
	public virtual Logout_del Logout { get => bfield_Logout ?? GameInfo_Logout; set => bfield_Logout = value; } Logout_del bfield_Logout;
	public virtual Logout_del global_Logout => GameInfo_Logout;
	public /*function */void GameInfo_Logout(Controller Exiting)
	{
		/*local */PlayerController PC = default;
		/*local */int PCIndex = default;
	
		PC = ((Exiting) as PlayerController);
		if(PC != default)
		{
			if(PC.PlayerReplicationInfo.bOnlySpectator)
			{
				-- NumSpectators;			
			}
			else
			{
				if((WorldInfo.IsInSeamlessTravel() || PC.HasClientLoadedCurrentWorld()))
				{
					-- NumPlayers;				
				}
				else
				{
					-- NumTravellingPlayers;
				}
				UpdateGameSettingsCounts();
			}
			if((bUsingArbitration && bHasArbitratedHandshakeBegun) && !bHasEndGameHandshakeBegun)
			{
			}
			if(((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && NotEqual_InterfaceInterface(GameInterface, (default(OnlineGameInterface)))) && GameInterface.GetGameSettings() != default)
			{
				GameInterface.UnregisterPlayer(PC.PlayerReplicationInfo.UniqueId);
			}
			if(bUsingArbitration)
			{
				PCIndex = ArbitrationPCs.Find(PC);
				if(PCIndex != -1)
				{
					ArbitrationPCs.Remove(PCIndex, 1);
				}
			}
		}
		if(BaseMutator != default)
		{
			BaseMutator.NotifyLogout(Exiting);
		}
	}
	
	public virtual /*event */void AcceptInventory(Pawn PlayerPawn)
	{
	
	}
	
	public virtual /*event */void AddDefaultInventory(Pawn P)
	{
		P.AddDefaultInventory();
		if(P.InvManager == default)
		{
		}
	}
	
	public virtual /*function */void Mutate(String MutateString, PlayerController Sender)
	{
		if(BaseMutator != default)
		{
			BaseMutator.Mutate(MutateString, Sender);
		}
	}
	
	public virtual /*function */void SetPlayerDefaults(Pawn PlayerPawn)
	{
		PlayerPawn.AirControl = PlayerPawn.DefaultAs<Pawn>().AirControl;
		PlayerPawn.GroundSpeed = PlayerPawn.DefaultAs<Pawn>().GroundSpeed;
		PlayerPawn.WaterSpeed = PlayerPawn.DefaultAs<Pawn>().WaterSpeed;
		PlayerPawn.AirSpeed = PlayerPawn.DefaultAs<Pawn>().AirSpeed;
		PlayerPawn.Acceleration = PlayerPawn.DefaultAs<Actor>().Acceleration;
		PlayerPawn.AccelRate = PlayerPawn.DefaultAs<Pawn>().AccelRate;
		PlayerPawn.JumpZ = PlayerPawn.DefaultAs<Pawn>().JumpZ;
		if(BaseMutator != default)
		{
			BaseMutator.ModifyPlayer(PlayerPawn);
		}
		PlayerPawn.PhysicsVolume.ModifyPlayer(PlayerPawn);
	}
	
	public delegate void NotifyKilled_del(Controller Killer, Controller Killed, Pawn KilledPawn);
	public virtual NotifyKilled_del NotifyKilled { get => bfield_NotifyKilled ?? GameInfo_NotifyKilled; set => bfield_NotifyKilled = value; } NotifyKilled_del bfield_NotifyKilled;
	public virtual NotifyKilled_del global_NotifyKilled => GameInfo_NotifyKilled;
	public /*function */void GameInfo_NotifyKilled(Controller Killer, Controller Killed, Pawn KilledPawn)
	{
		/*local */Controller C = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e0.MoveNext() && (C = (Controller)e0.Current) == C)
		{
		}
		#warning not sure what's going on here, I'll just log stuff
		System.Console.WriteLine( $"{nameof(GameInfo_NotifyKilled)} called, function is mangled" );
		/*
		@NULL
		Killer
		Killed
		KilledPawn
		)		
		*/
	}
	
	public virtual /*function */void Killed(Controller Killer, Controller KilledPlayer, Pawn KilledPawn, Core.ClassT<DamageType> DamageType)
	{
		if((KilledPlayer != default) && KilledPlayer.bIsPlayer)
		{
			KilledPlayer.PlayerReplicationInfo.Deaths += ((float)(1));
			KilledPlayer.PlayerReplicationInfo.SetNetUpdateTime(FMin(KilledPlayer.PlayerReplicationInfo.NetUpdateTime, WorldInfo.TimeSeconds + (0.30f * FRand())));
			BroadcastDeathMessage(Killer, KilledPlayer, DamageType);
		}
		if(KilledPlayer != default)
		{
			ScoreKill(Killer, KilledPlayer);
		}
		DiscardInventory(KilledPawn, Killer);
		NotifyKilled(Killer, KilledPlayer, KilledPawn);
	}
	
	public delegate bool PreventDeath_del(Pawn KilledPawn, Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation);
	public virtual PreventDeath_del PreventDeath { get => bfield_PreventDeath ?? GameInfo_PreventDeath; set => bfield_PreventDeath = value; } PreventDeath_del bfield_PreventDeath;
	public virtual PreventDeath_del global_PreventDeath => GameInfo_PreventDeath;
	public /*function */bool GameInfo_PreventDeath(Pawn KilledPawn, Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		if(GameRulesModifiers == default)
		{
			return false;
		}
		return GameRulesModifiers.PreventDeath(KilledPawn, Killer, DamageType, HitLocation);
	}
	
	public virtual /*function */void BroadcastDeathMessage(Controller Killer, Controller Other, Core.ClassT<DamageType> DamageType)
	{
		if(((Killer == Other) || Killer == default))
		{
			BroadcastLocalized(this, DeathMessageClass, 1, default, Other.PlayerReplicationInfo, DamageType);		
		}
		else
		{
			BroadcastLocalized(this, DeathMessageClass, 0, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);
		}
	}
	
	public /*function */static String ParseKillMessage(String KillerName, String VictimName, String DeathMessage)
	{
		return Repl(Repl(DeathMessage, "`k", KillerName, default(bool?)), "`o", VictimName, default(bool?));
	}
	
	public virtual /*function */void Kick(String S)
	{
		if(AccessControl != default)
		{
			AccessControl.Kick(S);
		}
	}
	
	public virtual /*function */void KickBan(String S)
	{
		if(AccessControl != default)
		{
			AccessControl.KickBan(S);
		}
	}
	
	public virtual /*function */bool CanSpectate(PlayerController Viewer, PlayerReplicationInfo ViewTarget)
	{
		return true;
	}
	
	public virtual /*function */void ReduceDamage(ref int Damage, Pawn injured, Controller InstigatedBy, Object.Vector HitLocation, ref Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
		/*local */int OriginalDamage = default;
	
		OriginalDamage = Damage;
		if((injured.PhysicsVolume.bNeutralZone || injured.InGodMode()))
		{
			Damage = 0;
			return;		
		}
		else
		{
			if((Damage > 0) && injured.InvManager != default)
			{
				injured.InvManager.ModifyDamage(Damage, InstigatedBy, HitLocation, Momentum, DamageType);
			}
		}
		if(GameRulesModifiers != default)
		{
			GameRulesModifiers.NetDamage(OriginalDamage, ref/*probably?*/ Damage, injured, InstigatedBy, HitLocation, ref/*probably?*/ Momentum, DamageType);
		}
	}
	
	public virtual /*function */bool CheckRelevance(Actor Other)
	{
		if(Other.bPhysXMutatable)
		{
			if(!IsPhysXEnhanced() && InStr("PHYSXONLY", Caps(((Other.Group)).ToString()), default(bool?)) >= 0)
			{
				return false;			
			}
			else
			{
				if((IsPhysXEnhanced()) && InStr("PHYSXREMOVE", Caps(((Other.Group)).ToString()), default(bool?)) >= 0)
				{
					return false;
				}
			}
		}
		if(BaseMutator == default)
		{
			return true;
		}
		return BaseMutator.CheckRelevance(Other);
	}
	
	public virtual /*function */bool ShouldRespawn(PickupFactory Other)
	{
		return ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/);
	}
	
	public virtual /*function */bool PickupQuery(Pawn Other, Core.ClassT<Inventory> ItemClass, Actor Pickup)
	{
		/*local */byte bAllowPickup = default;
	
		if((GameRulesModifiers != default) && GameRulesModifiers.OverridePickupQuery(Other, ItemClass, Pickup, ref/*probably?*/ bAllowPickup))
		{
			return ByteToBool((bAllowPickup));
		}
		if(Other.InvManager == default)
		{
			return false;		
		}
		else
		{
			return Other.InvManager.HandlePickupQuery(ItemClass, Pickup);
		}
	}
	
	public virtual /*function */void DiscardInventory(Pawn Other, /*optional */Controller _Killer = default)
	{
		var Killer = _Killer ?? default;
		if(Other.InvManager != default)
		{
			Other.InvManager.DiscardInventory();
		}
	}
	
	public virtual /*function */void ChangeName(Controller Other, /*coerce */String S, bool bNameChange)
	{
		if(S == "")
		{
			return;
		}
		Other.PlayerReplicationInfo.SetPlayerName(S);
	}
	
	public virtual /*function */bool ChangeTeam(Controller Other, int N, bool bNewTeam)
	{
		return true;
	}
	
	public virtual /*function */byte PickTeam(byte Current, Controller C)
	{
		return Current;
	}
	
	public virtual /*function */void SendPlayer(PlayerController aPlayer, String URL)
	{
		aPlayer.ClientTravel(URL, Actor.ETravelType.TRAVEL_Relative/*2*/, default(bool?), default(Object.Guid?));
	}
	
	public virtual /*function */String GetNextMap()
	{
	
		return default;
	}
	
	public virtual /*function */String GetNextAutomatedTestingMap()
	{
		/*local */String MapName = default;
		/*local */PlayerController PC = default;
		/*local */bool bResetMapIndex = default;
	
		if(bUsingAutomatedTestingMapList)
		{
			if((AutomatedTestingMapIndex >= 0) && Len(AutomatedMapTestingTransitionMap) > 0)
			{
				++ AutomatedTestingMapIndex;
				AutomatedTestingMapIndex *= -1;
				MapName = AutomatedMapTestingTransitionMap;			
			}
			else
			{
				if(Len(AutomatedMapTestingTransitionMap) > 0)
				{
					AutomatedTestingMapIndex *= -1;
				}
				if(AutomatedTestingMapIndex >= AutomatedMapTestingList.Length)
				{
					AutomatedTestingMapIndex = 0;
					++ NumMapListCyclesDone;
					bResetMapIndex = true;
				}
				MapName = AutomatedMapTestingList[AutomatedTestingMapIndex];
			}
			if(bAutomatedTestingWithOpen == true)
			{
				if((NumMapListCyclesDone >= NumAutomatedMapTestingCycles) && NumAutomatedMapTestingCycles != 0)
				{
					if(bCheckingForMemLeaks == true)
					{
						ConsoleCommand("STOPTRACKING", default(bool?));
						ConsoleCommand("DUMPALLOCSTOFILE", default(bool?));
					}
				}			
			}
			else
			{
				
				// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
				using var e271 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
				while(e271.MoveNext() && (PC = (PlayerController)e271.Current) == PC)
				{
					if(bResetMapIndex)
					{
						++ PC.PlayerReplicationInfo.AutomatedTestingData.NumMapListCyclesDone;
					}
					if((PC.PlayerReplicationInfo.AutomatedTestingData.NumMapListCyclesDone >= NumAutomatedMapTestingCycles) && NumAutomatedMapTestingCycles != 0)
					{
						if(bCheckingForMemLeaks == true)
						{
							ConsoleCommand("STOPTRACKING", default(bool?));
							ConsoleCommand("DUMPALLOCSTOFILE", default(bool?));
						}
					}				
				}			
			}
			return MapName;
		}
		return "";
	}
	
	public virtual /*function */bool GetTravelType()
	{
		return false;
	}
	
	public virtual /*function */void RestartGame()
	{
		/*local */String NextMap = default, TransitionMapCmdLine = default, URLString = default;
		/*local */int URLMapLen = default, MapNameLen = default;
	
		if(bUsingArbitration)
		{
			if(bIsEndGameHandshakeComplete)
			{
				NotifyArbitratedMatchEnd();
			}
			return;
		}
		if((GameRulesModifiers != default) && GameRulesModifiers.HandleRestartGame())
		{
			return;
		}
		if(bGameRestarted)
		{
			return;
		}
		bGameRestarted = true;
		if(bChangeLevels && !bAlreadyChanged)
		{
			bAlreadyChanged = true;
			if(bUsingAutomatedTestingMapList)
			{
				NextMap = GetNextAutomatedTestingMap();			
			}
			else
			{
				NextMap = GetNextMap();
			}
			if(NextMap != "")
			{
				if(bUsingAutomatedTestingMapList == false)
				{
					WorldInfo.ServerTravel(NextMap, GetTravelType());				
				}
				else
				{
					if(bAutomatedTestingWithOpen == false)
					{
						URLString = WorldInfo.GetLocalURL();
						URLMapLen = Len(URLString);
						MapNameLen = InStr(URLString, "?", default(bool?));
						if(MapNameLen != -1)
						{
							URLString = Right(URLString, URLMapLen - MapNameLen);
						}
						TransitionMapCmdLine = ((NextMap + URLString) + "?AutomatedTestingMapIndex=") + ((AutomatedTestingMapIndex)).ToString();
						WorldInfo.ServerTravel(TransitionMapCmdLine, GetTravelType());					
					}
					else
					{
						TransitionMapCmdLine = (((("?AutomatedTestingMapIndex=" + ((AutomatedTestingMapIndex)).ToString()) + "?NumberOfMatchesPlayed=") + ((NumberOfMatchesPlayed)).ToString()) + "?NumMapListCyclesDone=") + ((NumMapListCyclesDone)).ToString();
						ConsoleCommand(("open " + NextMap) + TransitionMapCmdLine, default(bool?));
					}
				}
				return;
			}
		}
		WorldInfo.ServerTravel("?Restart", GetTravelType());
	}
	
	public virtual /*event */void Broadcast(Actor Sender, /*coerce */String msg, /*optional */name? _Type = default)
	{
		var Type = _Type ?? default;
		BroadcastHandler.Broadcast(Sender, msg, Type);
	}
	
	public virtual /*function */void BroadcastTeam(Controller Sender, /*coerce */String msg, /*optional */name? _Type = default)
	{
		var Type = _Type ?? default;
		BroadcastHandler.BroadcastTeam(Sender, msg, Type);
	}
	
	public virtual /*event */void BroadcastLocalized(Actor Sender, Core.ClassT<LocalMessage> Message, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		var Switch = _Switch ?? default;
		var RelatedPRI_1 = _RelatedPRI_1 ?? default;
		var RelatedPRI_2 = _RelatedPRI_2 ?? default;
		var OptionalObject = _OptionalObject ?? default;
		BroadcastHandler.AllowBroadcastLocalized(Sender, Message, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
	}
	
	public virtual /*event */void BroadcastLocalizedTeam(int TeamIndex, Actor Sender, Core.ClassT<LocalMessage> Message, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		var Switch = _Switch ?? default;
		var RelatedPRI_1 = _RelatedPRI_1 ?? default;
		var RelatedPRI_2 = _RelatedPRI_2 ?? default;
		var OptionalObject = _OptionalObject ?? default;
		BroadcastHandler.AllowBroadcastLocalizedTeam(TeamIndex, Sender, Message, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
	}
	
	public virtual /*function */bool CheckModifiedEndGame(PlayerReplicationInfo Winner, String Reason)
	{
		return (GameRulesModifiers != default) && !GameRulesModifiers.CheckEndGame(Winner, Reason);
	}
	
	public virtual /*function */bool CheckEndGame(PlayerReplicationInfo Winner, String Reason)
	{
		/*local */Controller P = default;
	
		if(CheckModifiedEndGame(Winner, Reason))
		{
			return false;
		}
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ P)
		using var e25 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e25.MoveNext() && (P = (Controller)e25.Current) == P)
		{
			P.GameHasEnded(default(Actor), default(bool?));		
		}	
		return true;
	}
	
	public virtual /*function */void WriteOnlineStats()
	{
	
	}
	
	public virtual /*function */void WriteOnlinePlayerScores()
	{
		/*local */int Index = default;
		/*local */array<OnlineSubsystem.OnlinePlayerScore> PlayerScores = default;
	
		if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.StatsInterface, (default(OnlineStatsInterface))))
		{
			PlayerScores.Length = GameReplicationInfo.PRIArray.Length;
			Index = 0;
			J0x49:{}
			if(Index < GameReplicationInfo.PRIArray.Length)
			{
				PlayerScores[Index].PlayerId = GameReplicationInfo.PRIArray[Index].UniqueId;
				if(bTeamGame)
				{
					PlayerScores[Index].TeamId = GameReplicationInfo.PRIArray[Index].Team.TeamIndex;
					PlayerScores[Index].Score = ((int)(GameReplicationInfo.PRIArray[Index].Team.Score));
					goto J0x17B;
				}
				PlayerScores[Index].TeamId = Index;
				PlayerScores[Index].Score = ((int)(GameReplicationInfo.PRIArray[Index].Score));
				J0x17B:{}
				++ Index;
				goto J0x49;
			}
			OnlineSub.StatsInterface.WriteOnlinePlayerScores(ref/*probably?*/ PlayerScores);
		}
	}
	
	public virtual /*function */void EndGame(PlayerReplicationInfo Winner, String Reason)
	{
		/*local */int Index = default;
	
		if(!CheckEndGame(Winner, Reason))
		{
			bOverTime = true;
			return;
		}
		if(!bUsingArbitration)
		{
			WriteOnlineStats();
			WriteOnlinePlayerScores();
			GameReplicationInfo.EndGame();
			GameInterface.EndOnlineGame();		
		}
		else
		{
			GameReplicationInfo.bMatchIsOver = true;
			if(bNeedsEndGameHandshake)
			{
				Index = 0;
				J0x90:{}
				if(Index < InactivePRIArray.Length)
				{
					InactivePRIArray[Index].bIsInactive = true;
					InactivePRIArray[Index].RemoteRole = ((Actor.ENetRole)InactivePRIArray[Index].DefaultAs<Actor>().RemoteRole);
					++ Index;
					goto J0x90;
				}
				SetTimer(2.0f, false, "ProcessEndGameHandshake", default(Object));
				bNeedsEndGameHandshake = false;
				bIsEndGameHandshakeComplete = false;
			}
		}
		bGameEnded = true;
		EndLogging(Reason);
	}
	
	public virtual /*function */void EndLogging(String Reason)
	{
	
	}
	
	public virtual /*function */bool ShouldSpawnAtStartSpot(Controller Player)
	{
		return (((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && Player != default) && Player.StartSpot != default) && (bWaitingToStartMatch || (Player.PlayerReplicationInfo != default) && Player.PlayerReplicationInfo.bWaitingPlayer);
	}
	
	public virtual /*function */NavigationPoint FindPlayerStart(Controller Player, /*optional */byte? _InTeam = default, /*optional */String? _IncomingName = default)
	{
		/*local */NavigationPoint N = default, BestStart = default;
		/*local */Teleporter Tel = default;
	
		var InTeam = _InTeam ?? default;
		var IncomingName = _IncomingName ?? default;
		if(GameRulesModifiers != default)
		{
			N = GameRulesModifiers.FindPlayerStart(Player, (byte)InTeam, IncomingName);
			if(N != default)
			{
				return N;
			}
		}
		if(IncomingName != "")
		{
			
			// foreach WorldInfo.AllNavigationPoints(ClassT<Teleporter>(), ref/*probably?*/ Tel)
			using var e83 = WorldInfo.AllNavigationPoints(ClassT<Teleporter>()).GetEnumerator();
			while(e83.MoveNext() && (Tel = (Teleporter)e83.Current) == Tel)
			{
				if(ApproximatelyEqual(((Tel.Tag)).ToString(), IncomingName))
				{				
					return Tel;
				}			
			}		
		}
		if((ShouldSpawnAtStartSpot(Player)) && ((((Player.StartSpot) as PlayerStart) == default) || (RatePlayerStart(((Player.StartSpot) as PlayerStart), (byte)InTeam, Player)) >= 0.0f))
		{
			return Player.StartSpot;
		}
		BestStart = ChoosePlayerStart(Player, (byte)InTeam);
		if((BestStart == default) && Player == default)
		{
			
			// foreach AllActors(ClassT<NavigationPoint>(), ref/*probably?*/ N)
			using var e312 = AllActors(ClassT<NavigationPoint>()).GetEnumerator();
			while(e312.MoveNext() && (N = (NavigationPoint)e312.Current) == N)
			{
				BestStart = N;
				break;			
			}		
		}
		return BestStart;
	}
	
	public virtual /*function */PlayerStart ChoosePlayerStart(Controller Player, /*optional */byte? _InTeam = default)
	{
		/*local */PlayerStart P = default, BestStart = default;
		/*local */float BestRating = default, NewRating = default;
		/*local */byte Team = default;
	
		var InTeam = _InTeam ?? default;
		Team = (byte)((((Player != default) && Player.PlayerReplicationInfo != default) && Player.PlayerReplicationInfo.Team != default) ? ((byte)(Player.PlayerReplicationInfo.Team.TeamIndex)) : InTeam);
		
		// foreach WorldInfo.AllNavigationPoints(ClassT<PlayerStart>(), ref/*probably?*/ P)
		using var e118 = WorldInfo.AllNavigationPoints(ClassT<PlayerStart>()).GetEnumerator();
		while(e118.MoveNext() && (P = (PlayerStart)e118.Current) == P)
		{
			NewRating = RatePlayerStart(P, (byte)Team, Player);
			if(NewRating > BestRating)
			{
				BestRating = NewRating;
				BestStart = P;
			}		
		}	
		return BestStart;
	}
	
	public delegate float RatePlayerStart_del(PlayerStart P, byte Team, Controller Player);
	public virtual RatePlayerStart_del RatePlayerStart { get => bfield_RatePlayerStart ?? GameInfo_RatePlayerStart; set => bfield_RatePlayerStart = value; } RatePlayerStart_del bfield_RatePlayerStart;
	public virtual RatePlayerStart_del global_RatePlayerStart => GameInfo_RatePlayerStart;
	public /*function */float GameInfo_RatePlayerStart(PlayerStart P, byte Team, Controller Player)
	{
		if(!P.bEnabled)
		{
			return 10.0f;
		}
		return ((float)(((P.bPrimaryStart) ? 100 : 20)));
	}
	
	public virtual /*function */void AddObjectiveScore(PlayerReplicationInfo Scorer, int Score)
	{
		if(Scorer != default)
		{
			Scorer.Score += ((float)(Score));
		}
		if(GameRulesModifiers != default)
		{
			GameRulesModifiers.ScoreObjective(Scorer, Score);
		}
	}
	
	public virtual /*function */void ScoreObjective(PlayerReplicationInfo Scorer, int Score)
	{
		AddObjectiveScore(Scorer, Score);
		CheckScore(Scorer);
	}
	
	public virtual /*function */bool CheckScore(PlayerReplicationInfo Scorer)
	{
		return true;
	}
	
	public virtual /*function */void ScoreKill(Controller Killer, Controller Other)
	{
		if(((Killer == Other) || Killer == default))
		{
			if((Other != default) && Other.PlayerReplicationInfo != default)
			{
				Other.PlayerReplicationInfo.Score -= ((float)(1));
				Other.PlayerReplicationInfo.bForceNetUpdate = true;
			}		
		}
		else
		{
			if(Killer.PlayerReplicationInfo != default)
			{
				Killer.PlayerReplicationInfo.Score += ((float)(1));
				Killer.PlayerReplicationInfo.bForceNetUpdate = true;
				++ Killer.PlayerReplicationInfo.Kills;
			}
		}
		if(GameRulesModifiers != default)
		{
			GameRulesModifiers.ScoreKill(Killer, Other);
		}
		if(((Killer != default) || MaxLives > 0))
		{
			CheckScore(Killer.PlayerReplicationInfo);
		}
	}
	
	public virtual /*function */void ModifyScoreKill(Controller Killer, Controller Other)
	{
		if(GameRulesModifiers != default)
		{
			GameRulesModifiers.ScoreKill(Killer, Other);
		}
	}
	
	public /*function */static String ParseMessageString(Controller Who, String Message)
	{
		return Message;
	}
	
	public virtual /*function */void DriverEnteredVehicle(Vehicle V, Pawn P)
	{
		if(BaseMutator != default)
		{
			BaseMutator.DriverEnteredVehicle(V, P);
		}
	}
	
	public virtual /*function */bool CanLeaveVehicle(Vehicle V, Pawn P)
	{
		if(BaseMutator == default)
		{
			return true;
		}
		return BaseMutator.CanLeaveVehicle(V, P);
	}
	
	public virtual /*function */void DriverLeftVehicle(Vehicle V, Pawn P)
	{
		if(BaseMutator != default)
		{
			BaseMutator.DriverLeftVehicle(V, P);
		}
	}
	
	public virtual /*exec function */void KillBots()
	{
	
	}
	
	public virtual /*function */bool PlayerCanRestartGame(PlayerController aPlayer)
	{
		return true;
	}
	
	public virtual /*function */bool PlayerCanRestart(PlayerController aPlayer)
	{
		return true;
	}
	
	public /*function */static bool AllowReactionTime()
	{
		return false;
	}
	
	public /*function */static bool AllowMutator(String MutatorClassName)
	{
		return !WorldInfo.IsDemoBuild();
	}
	
	public virtual /*function */bool AllowCheats(PlayerController P)
	{
		return ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/);
	}
	
	public virtual /*event */void PreCommitMapChange(String PreviousMapName, String NextMapName)
	{
	
	}
	
	public virtual /*event */void PostCommitMapChange()
	{
	
	}
	
	public virtual /*function */void AddInactivePRI(PlayerReplicationInfo PRI, PlayerController PC)
	{
		/*local */int I = default;
		/*local */PlayerReplicationInfo NewPRI = default;
		/*local */bool bIsConsole = default;
	
		if(!PRI.bFromPreviousLevel && !PRI.bOnlySpectator)
		{
			NewPRI = PRI.Duplicate();
			WorldInfo.GRI.RemovePRI(NewPRI);
			NewPRI.RemoteRole = Actor.ENetRole.ROLE_None/*0*/;
			NewPRI.LifeSpan = 300.0f;
			bIsConsole = WorldInfo.IsConsoleBuild(default(WorldInfo.EConsoleType?));
			I = 0;
			J0xAF:{}
			if(I < InactivePRIArray.Length)
			{
				if(((((((InactivePRIArray[I] == default) || InactivePRIArray[I].bDeleteMe)) || !bIsConsole && InactivePRIArray[I].SavedNetworkAddress == NewPRI.SavedNetworkAddress)) || bIsConsole && InactivePRIArray[I].AreUniqueNetIdsEqual(NewPRI)))
				{
					InactivePRIArray.Remove(I, 1);
					-- I;
				}
				++ I;
				goto J0xAF;
			}
			InactivePRIArray[InactivePRIArray.Length] = NewPRI;
			if(InactivePRIArray.Length > 16)
			{
				InactivePRIArray.Remove(0, InactivePRIArray.Length - 16);
			}
		}
		PRI.Destroy();
		RecalculateSkillRating();
	}
	
	public virtual /*function */bool FindInactivePRI(PlayerController PC)
	{
		/*local */String NewNetworkAddress = default, NewName = default;
		/*local */int I = default;
		/*local */PlayerReplicationInfo OldPRI = default;
		/*local */bool bIsConsole = default;
	
		if(PC.PlayerReplicationInfo.bOnlySpectator)
		{
			return false;
		}
		bIsConsole = WorldInfo.IsConsoleBuild(default(WorldInfo.EConsoleType?));
		NewNetworkAddress = PC.PlayerReplicationInfo.SavedNetworkAddress;
		NewName = PC.PlayerReplicationInfo.PlayerName;
		I = 0;
		J0x7C:{}
		if(I < InactivePRIArray.Length)
		{
			if(((InactivePRIArray[I] == default) || InactivePRIArray[I].bDeleteMe))
			{
				InactivePRIArray.Remove(I, 1);
				-- I;
				goto J0x233;
			}
			if(((bIsConsole && InactivePRIArray[I].AreUniqueNetIdsEqual(PC.PlayerReplicationInfo)) || (!bIsConsole && ApproximatelyEqual(InactivePRIArray[I].SavedNetworkAddress, NewNetworkAddress)) && ApproximatelyEqual(InactivePRIArray[I].PlayerName, NewName)))
			{
				OldPRI = PC.PlayerReplicationInfo;
				PC.PlayerReplicationInfo = InactivePRIArray[I];
				PC.PlayerReplicationInfo.SetOwner(PC);
				PC.PlayerReplicationInfo.RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy/*1*/;
				PC.PlayerReplicationInfo.LifeSpan = 0.0f;
				OverridePRI(PC, OldPRI);
				WorldInfo.GRI.AddPRI(PC.PlayerReplicationInfo);
				InactivePRIArray.Remove(I, 1);
				OldPRI.Destroy();
				return true;
			}
			J0x233:{}
			++ I;
			goto J0x7C;
		}
		return false;
	}
	
	public virtual /*function */void OverridePRI(PlayerController PC, PlayerReplicationInfo OldPRI)
	{
		PC.PlayerReplicationInfo.OverrideWith(OldPRI);
	}
	
	public virtual /*event */void GetSeamlessTravelActorList(bool bToEntry, ref array<Actor> ActorList)
	{
		/*local */int I = default;
	
		I = 0;
		J0x07:{}
		if(I < WorldInfo.GRI.PRIArray.Length)
		{
			WorldInfo.GRI.PRIArray[I].bFromPreviousLevel = true;
			ActorList[ActorList.Length] = WorldInfo.GRI.PRIArray[I];
			++ I;
			goto J0x07;
		}
		if(bToEntry)
		{
			ActorList[ActorList.Length] = WorldInfo.GRI;
			if(BroadcastHandler != default)
			{
				ActorList[ActorList.Length] = BroadcastHandler;
			}
		}
		if(BaseMutator != default)
		{
			BaseMutator.GetSeamlessTravelActorList(bToEntry, ref/*probably?*/ ActorList);
		}
	}
	
	// Export UGameInfo::execSwapPlayerControllers(FFrame&, void* const)
	public virtual /*native final function */void SwapPlayerControllers(PlayerController OldPC, PlayerController NewPC)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*event */void PostSeamlessTravel()
	{
		/*local */Controller C = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e0.MoveNext() && (C = (Controller)e0.Current) == C)
		{
			if(C.bIsPlayer)
			{
				if(((C) as PlayerController) == default)
				{
					HandleSeamlessTravelPlayer(ref/*probably?*/ C);
					continue;
				}
				if(!C.PlayerReplicationInfo.bOnlySpectator)
				{
					++ NumTravellingPlayers;
				}
				if(((C) as PlayerController).HasClientLoadedCurrentWorld())
				{
					HandleSeamlessTravelPlayer(ref/*probably?*/ C);
				}
			}		
		}	
		if((bWaitingToStartMatch && !bDelayedStart) && (NumPlayers + NumBots) > 0)
		{
			StartMatch();
		}
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
		{
			UpdateGameSettings();
		}
	}
	
	public virtual /*function */void UpdateGameSettings()
	{
	
	}
	
	public delegate void HandleSeamlessTravelPlayer_del(ref Controller C);
	public virtual HandleSeamlessTravelPlayer_del HandleSeamlessTravelPlayer { get => bfield_HandleSeamlessTravelPlayer ?? GameInfo_HandleSeamlessTravelPlayer; set => bfield_HandleSeamlessTravelPlayer = value; } HandleSeamlessTravelPlayer_del bfield_HandleSeamlessTravelPlayer;
	public virtual HandleSeamlessTravelPlayer_del global_HandleSeamlessTravelPlayer => GameInfo_HandleSeamlessTravelPlayer;
	public /*event */void GameInfo_HandleSeamlessTravelPlayer(ref Controller C)
	{
		/*local */Object.Rotator StartRotation = default;
		/*local */NavigationPoint StartSpot = default;
		/*local */PlayerController PC = default, NewPC = default;
		/*local */PlayerReplicationInfo OldPRI = default;
	
		PC = ((C) as PlayerController);
		if((PC != default) && PC.Class != PlayerControllerClass)
		{
			if(PC.Player != default)
			{
				NewPC = Spawn(PlayerControllerClass, default(Actor), default(name?), PC.Location, PC.Rotation, default(Actor), default(bool?));
				if(NewPC == default)
				{
					PC.Destroy();
					return;				
				}
				else
				{
					PC.CleanUpAudioComponents();
					PC.SeamlessTravelTo(NewPC);
					NewPC.SeamlessTravelFrom(PC);
					SwapPlayerControllers(PC, NewPC);
					PC = NewPC;
					C = NewPC;
				}			
			}
			else
			{
				PC.Destroy();
			}		
		}
		else
		{
			C.PlayerReplicationInfo.Reset();
			OldPRI = C.PlayerReplicationInfo;
			C.InitPlayerReplicationInfo();
			OldPRI.SeamlessTravelTo(C.PlayerReplicationInfo);
			OldPRI.Destroy();
		}
		if(!bTeamGame && C.PlayerReplicationInfo.Team != default)
		{
			C.PlayerReplicationInfo.Team.Destroy();
			C.PlayerReplicationInfo.Team = default;
		}
		StartSpot = FindPlayerStart(C, (byte)C.GetTeamNum(), default(String?));
		if(StartSpot == default)
		{		
		}
		else
		{
			StartRotation.Yaw = StartSpot.Rotation.Yaw;
			C.SetLocation(StartSpot.Location);
			C.SetRotation(StartRotation);
		}
		C.StartSpot = StartSpot;
		if(PC != default)
		{
			PC.CleanUpAudioComponents();
			PC.ClientInitializeDataStores();
			PC.SetViewTarget(PC, default(Camera.ViewTargetTransitionParams?));
			if(PC.PlayerReplicationInfo.bOnlySpectator)
			{
				PC.GotoState("Spectating", default(name?), default(bool?), default(bool?));
				PC.ClientGotoState("Spectating", default(name?));
				PC.PlayerReplicationInfo.bIsSpectator = true;
				PC.PlayerReplicationInfo.bOutOfLives = true;
				++ NumSpectators;			
			}
			else
			{
				++ NumPlayers;
				-- NumTravellingPlayers;
				PC.GotoState("PlayerWaiting", default(name?), default(bool?), default(bool?));
			}
			PC.ClientSetHUD(HUDType, ScoreBoardType);
			ReplicateStreamingStatus(PC);
			PC.ServerSendMusicInfo();
			if(CoverReplicatorBase != default)
			{
				PC.SpawnCoverReplicator();
			}
			PC.ClientSetOnlineStatus();		
		}
		else
		{
			++ NumBots;
			C.GotoState("RoundEnded", default(name?), default(bool?), default(bool?));
		}
		if(BaseMutator != default)
		{
			BaseMutator.NotifyLogin(C);
		}
	}
	
	public virtual /*function */void UpdateGameSettingsCounts()
	{
		if((GameSettings != default) && GameSettings.bIsLanMatch)
		{
			GameSettings.NumOpenPublicConnections = GameSettings.NumPublicConnections - (GetNumPlayers());
			if(GameSettings.NumOpenPublicConnections < 0)
			{
				GameSettings.NumOpenPublicConnections = 0;
			}
		}
	}
	
	public delegate void ProcessClientRegistrationCompletion_del(PlayerController PC, bool bWasSuccessful);
	public virtual ProcessClientRegistrationCompletion_del ProcessClientRegistrationCompletion { get => bfield_ProcessClientRegistrationCompletion ?? GameInfo_ProcessClientRegistrationCompletion; set => bfield_ProcessClientRegistrationCompletion = value; } ProcessClientRegistrationCompletion_del bfield_ProcessClientRegistrationCompletion;
	public virtual ProcessClientRegistrationCompletion_del global_ProcessClientRegistrationCompletion => GameInfo_ProcessClientRegistrationCompletion;
	public /*function */void GameInfo_ProcessClientRegistrationCompletion(PlayerController PC, bool bWasSuccessful)
	{
	
	}
	
	public delegate void StartArbitrationRegistration_del();
	public virtual StartArbitrationRegistration_del StartArbitrationRegistration { get => bfield_StartArbitrationRegistration ?? GameInfo_StartArbitrationRegistration; set => bfield_StartArbitrationRegistration = value; } StartArbitrationRegistration_del bfield_StartArbitrationRegistration;
	public virtual StartArbitrationRegistration_del global_StartArbitrationRegistration => GameInfo_StartArbitrationRegistration;
	public /*function */void GameInfo_StartArbitrationRegistration()
	{
	
	}
	
	public delegate void StartArbitratedMatch_del();
	public virtual StartArbitratedMatch_del StartArbitratedMatch { get => bfield_StartArbitratedMatch ?? GameInfo_StartArbitratedMatch; set => bfield_StartArbitratedMatch = value; } StartArbitratedMatch_del bfield_StartArbitratedMatch;
	public virtual StartArbitratedMatch_del global_StartArbitratedMatch => GameInfo_StartArbitratedMatch;
	public /*function */void GameInfo_StartArbitratedMatch()
	{
	
	}
	
	public delegate void RegisterServerForArbitration_del();
	public virtual RegisterServerForArbitration_del RegisterServerForArbitration { get => bfield_RegisterServerForArbitration ?? GameInfo_RegisterServerForArbitration; set => bfield_RegisterServerForArbitration = value; } RegisterServerForArbitration_del bfield_RegisterServerForArbitration;
	public virtual RegisterServerForArbitration_del global_RegisterServerForArbitration => GameInfo_RegisterServerForArbitration;
	public /*function */void GameInfo_RegisterServerForArbitration()
	{
	
	}
	
	public delegate void ArbitrationRegistrationComplete_del(bool bWasSuccessful);
	public virtual ArbitrationRegistrationComplete_del ArbitrationRegistrationComplete { get => bfield_ArbitrationRegistrationComplete ?? GameInfo_ArbitrationRegistrationComplete; set => bfield_ArbitrationRegistrationComplete = value; } ArbitrationRegistrationComplete_del bfield_ArbitrationRegistrationComplete;
	public virtual ArbitrationRegistrationComplete_del global_ArbitrationRegistrationComplete => GameInfo_ArbitrationRegistrationComplete;
	public /*function */void GameInfo_ArbitrationRegistrationComplete(bool bWasSuccessful)
	{
	
	}
	
	public delegate bool MatchIsInProgress_del();
	public virtual MatchIsInProgress_del MatchIsInProgress { get => bfield_MatchIsInProgress ?? GameInfo_MatchIsInProgress; set => bfield_MatchIsInProgress = value; } MatchIsInProgress_del bfield_MatchIsInProgress;
	public virtual MatchIsInProgress_del global_MatchIsInProgress => GameInfo_MatchIsInProgress;
	public /*function */bool GameInfo_MatchIsInProgress()
	{
		return true;
	}
	
	public virtual /*function */void ProcessEndGameHandshake()
	{
		/*local */int Index = default;
	
		bHasEndGameHandshakeBegun = true;
		Index = 0;
		J0x0F:{}
		if(Index < ArbitrationPCs.Length)
		{
			if(!ArbitrationPCs[Index].bDeleteMe)
			{
				ArbitrationPCs[Index].ClientWriteArbitrationEndGameData(OnlineStatsWriteClass);
				PendingArbitrationPCs[PendingArbitrationPCs.Length] = ArbitrationPCs[Index];
			}
			++ Index;
			goto J0x0F;
		}
		if(PendingArbitrationPCs.Length == 0)
		{
			ServerWriteArbitrationEndGameData();		
		}
		else
		{
			SetTimer(5.0f, false, "ServerWriteArbitrationEndGameData", default(Object));
		}
	}
	
	public virtual /*function */void ProcessClientDataWriteCompletion(PlayerController PC)
	{
		/*local */int FoundIndex = default;
	
		FoundIndex = PendingArbitrationPCs.Find(PC);
		if(FoundIndex != -1)
		{
			PendingArbitrationPCs.Remove(FoundIndex, 1);
		}
		if(PendingArbitrationPCs.Length == 0)
		{
			ServerWriteArbitrationEndGameData();
		}
	}
	
	public virtual /*function */void ServerWriteArbitrationEndGameData()
	{
		SetTimer(0.0f, false, "ServerWriteArbitrationEndGameData", default(Object));
		WriteOnlineStats();
		WriteOnlinePlayerScores();
		if(NotEqual_InterfaceInterface(GameInterface, (default(OnlineGameInterface))))
		{
			GameInterface.EndOnlineGame();
		}
		bIsEndGameHandshakeComplete = true;
		PendingArbitrationPCs.Length = 0;
		ArbitrationPCs.Length = 0;
		RestartGame();
	}
	
	public virtual /*function */void NotifyArbitratedMatchEnd()
	{
		/*local */PlayerController PC = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			if(PC.IsLocalPlayerController() == false)
			{
				PC.ClientArbitratedMatchEnded();
			}		
		}	
		
		// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e77 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e77.MoveNext() && (PC = (PlayerController)e77.Current) == PC)
		{
			if(PC.IsLocalPlayerController())
			{
				PC.ClientArbitratedMatchEnded();
			}		
		}	
	}
	
	public virtual /*function */void UpdateGameplayMuteList(PlayerController PC)
	{
	
	}
	
	public virtual /*function */void RecalculateSkillRating()
	{
		/*local */int Index = default;
		/*local */array<OnlineSubsystem.UniqueNetId> Players = default;
		/*local */OnlineSubsystem.UniqueNetId ZeroId = default;
	
		if(((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
		{
			Index = 0;
			J0x4E:{}
			if(Index < GameReplicationInfo.PRIArray.Length)
			{
				if(ZeroId != GameReplicationInfo.PRIArray[Index].UniqueId)
				{
					Players[Players.Length] = GameReplicationInfo.PRIArray[Index].UniqueId;
				}
				++ Index;
				goto J0x4E;
			}
			OnlineSub.GameInterface.RecalculateSkillRating(ref/*probably?*/ Players);
		}
	}
	
	public virtual /*event */void MatineeCancelled()
	{
	
	}
	
	public virtual /*function */bool ProcessServerLogin()
	{
		if(OnlineSub != default)
		{
			if(NotEqual_InterfaceInterface(OnlineSub.PlayerInterface, (default(OnlinePlayerInterface))))
			{
				OnlineSub.PlayerInterface.AddLoginChangeDelegate(OnLoginChange, default(byte?));
				OnlineSub.PlayerInterface.AddLoginFailedDelegate(0, OnLoginFailed);
				if(OnlineSub.PlayerInterface.AutoLogin() == false)
				{
					ClearAutoLoginDelegates();
					return false;
				}
				return true;
			}
		}
		return false;
	}
	
	public virtual /*function */void ClearAutoLoginDelegates()
	{
		if(NotEqual_InterfaceInterface(OnlineSub.PlayerInterface, (default(OnlinePlayerInterface))))
		{
			OnlineSub.PlayerInterface.ClearLoginChangeDelegate(OnLoginChange, default(byte?));
			OnlineSub.PlayerInterface.ClearLoginFailedDelegate(0, OnLoginFailed);
		}
	}
	
	public virtual /*function */void OnLoginFailed(byte LocalUserNum, OnlineSubsystem.EOnlineServerConnectionStatus ErrorCode)
	{
		ClearAutoLoginDelegates();
	}
	
	public virtual /*function */void OnLoginChange()
	{
		ClearAutoLoginDelegates();
		RegisterServer();
	}
	
	public virtual /*function */void RegisterServer()
	{
		if(((OnlineGameSettingsClass != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
		{
			GameSettings =  OnlineGameSettingsClass.New();
			GameSettings.UpdateFromURL(ref/*probably?*/ ServerOptions, this);
			OnlineSub.GameInterface.AddCreateOnlineGameCompleteDelegate(OnServerCreateComplete);
			if(!OnlineSub.GameInterface.CreateOnlineGame(0, GameSettings))
			{
				OnlineSub.GameInterface.ClearCreateOnlineGameCompleteDelegate(OnServerCreateComplete);
			}		
		}
	}
	
	public virtual /*function */void OnServerCreateComplete(bool bWasSuccessful)
	{
		OnlineSub.GameInterface.ClearCreateOnlineGameCompleteDelegate(OnServerCreateComplete);
		if(bWasSuccessful == false)
		{
			if(GameSettings.bIsLanMatch == false)
			{
				GameSettings.bIsLanMatch = true;
				OnlineSub.GameInterface.AddCreateOnlineGameCompleteDelegate(OnServerCreateComplete);
				if(!OnlineSub.GameInterface.CreateOnlineGame(0, GameSettings))
				{
					OnlineSub.GameInterface.ClearCreateOnlineGameCompleteDelegate(OnServerCreateComplete);
				}			
			}		
		}
		else
		{
			UpdateGameSettings();
		}
	}
	
	public virtual /*event */void StartAutomatedMapTestTimer()
	{
		if(((WorldInfo != default) && AutomatedTestingMapIndex < 0) && bCheckingForMemLeaks == true)
		{
			WorldInfo.DoMemoryTracking();
		}
		SetTimer(15.0f, false, "CloseAutomatedMapTestTimer", default(Object));
	}
	
	public virtual /*function */void CloseAutomatedMapTestTimer()
	{
		if(AutomatedTestingMapIndex < 0)
		{
			RestartGame();
		}
	}
	
	public virtual /*function */void IncrementAutomatedTestingMapIndex()
	{
		if(bUsingAutomatedTestingMapList)
		{
			if(bAutomatedTestingWithOpen == true)
			{			
			}
			else
			{
				if(AutomatedTestingMapIndex >= 0)
				{
					++ AutomatedTestingMapIndex;
				}
			}
		}
	}
	
	public virtual /*function */void IncrementNumberOfMatchesPlayed()
	{
		++ NumberOfMatchesPlayed;
	}
	
	public virtual /*event */void SetPlayerStart(String StartLocation)
	{
	
	}
	
	// Export UGameInfo::execIsPhysXEnhanced(FFrame&, void* const)
	public /*native function */static bool IsPhysXEnhanced()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public delegate void ArbitrationTimeout_del();
	public virtual ArbitrationTimeout_del ArbitrationTimeout { get => bfield_ArbitrationTimeout ?? (()=>{}); set => bfield_ArbitrationTimeout = value; } ArbitrationTimeout_del bfield_ArbitrationTimeout;
	public virtual ArbitrationTimeout_del global_ArbitrationTimeout => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Timer = null;
		CanOpenPauseMenu = null;
		StartMatch = null;
		PostLogin = null;
		Logout = null;
		NotifyKilled = null;
		PreventDeath = null;
		RatePlayerStart = null;
		HandleSeamlessTravelPlayer = null;
		ProcessClientRegistrationCompletion = null;
		StartArbitrationRegistration = null;
		StartArbitratedMatch = null;
		RegisterServerForArbitration = null;
		ArbitrationRegistrationComplete = null;
		MatchIsInProgress = null;
	
	}
	
	protected /*function */bool GameInfo_PendingMatch_MatchIsInProgress()// state function
	{
		return false;
	}
	
	protected /*function */void GameInfo_PendingMatch_StartMatch()// state function
	{
		if(bUsingArbitration)
		{
			StartArbitrationRegistration();		
		}
		else
		{
			global_StartMatch();
		}
	}
	
	protected /*function */void GameInfo_PendingMatch_StartArbitrationRegistration()// state function
	{
		/*local */PlayerController PC = default;
		/*local */OnlineSubsystem.UniqueNetId HostId = default;
	
		if(!bHasArbitratedHandshakeBegun)
		{
			bHasArbitratedHandshakeBegun = true;
			
			// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
			using var e19 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e19.MoveNext() && (PC = (PlayerController)e19.Current) == PC)
			{
				HostId = PC.PlayerReplicationInfo.UniqueId;
				break;			
			}		
			PendingArbitrationPCs.Length = 0;
			
			// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
			using var e82 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e82.MoveNext() && (PC = (PlayerController)e82.Current) == PC)
			{
				if(!PC.IsLocalPlayerController())
				{
					PC.ClientSetHostUniqueId(HostId);
					PC.ClientRegisterForArbitration();
					PendingArbitrationPCs[PendingArbitrationPCs.Length] = PC;
					continue;
				}
				ArbitrationPCs[ArbitrationPCs.Length] = PC;			
			}		
			SetTimer(ArbitrationHandshakeTimeout, false, "ArbitrationTimeout", default(Object));
		}
	}
	
	protected /*function */void GameInfo_PendingMatch_RegisterServerForArbitration()// state function
	{
		if(NotEqual_InterfaceInterface(GameInterface, (default(OnlineGameInterface))))
		{
			GameInterface.AddArbitrationRegistrationCompleteDelegate(b => ArbitrationRegistrationComplete(b));
			GameInterface.RegisterForArbitration();		
		}
		else
		{
			ArbitrationRegistrationComplete(true);
		}
	}
	
	protected /*function */void GameInfo_PendingMatch_ArbitrationRegistrationComplete(bool bWasSuccessful)// state function
	{
		GameInterface.AddArbitrationRegistrationCompleteDelegate(b => ArbitrationRegistrationComplete(b));
		if(bWasSuccessful)
		{
			StartArbitratedMatch();		
		}
		else
		{
			ConsoleCommand("Disconnect", default(bool?));
		}
	}
	
	protected /*function */void GameInfo_PendingMatch_ArbitrationTimeout()// state function
	{
		/*local */int Index = default;
	
		Index = 0;
		J0x07:{}
		if(Index < PendingArbitrationPCs.Length)
		{
			AccessControl.KickPlayer(PendingArbitrationPCs[Index], GameMessageClass.DefaultAs<GameMessage>().MaxedOutMessage);
			++ Index;
			goto J0x07;
		}
		PendingArbitrationPCs.Length = 0;
		RegisterServerForArbitration();
	}
	
	protected /*function */void GameInfo_PendingMatch_StartArbitratedMatch()// state function
	{
		bNeedsEndGameHandshake = true;
		global_StartMatch();
	}
	
	protected /*function */void GameInfo_PendingMatch_ProcessClientRegistrationCompletion(PlayerController PC, bool bWasSuccessful)// state function
	{
		/*local */int FoundIndex = default;
	
		FoundIndex = PendingArbitrationPCs.Find(PC);
		if(FoundIndex != -1)
		{
			PendingArbitrationPCs.Remove(FoundIndex, 1);
			if(bWasSuccessful)
			{
				ArbitrationPCs[ArbitrationPCs.Length] = PC;			
			}
			else
			{
				AccessControl.KickPlayer(PC, GameMessageClass.DefaultAs<GameMessage>().MaxedOutMessage);
			}
		}
		if(PendingArbitrationPCs.Length == 0)
		{
			SetTimer(0.0f, false, "ArbitrationTimeout", default(Object));
			RegisterServerForArbitration();
		}
	}
	
	protected /*event */void GameInfo_PendingMatch_EndState(name NextStateName)// state function
	{
		SetTimer(0.0f, false, "ArbitrationTimeout", default(Object));
		if(NotEqual_InterfaceInterface(GameInterface, (default(OnlineGameInterface))))
		{
			GameInterface.ClearArbitrationRegistrationCompleteDelegate(b => ArbitrationRegistrationComplete(b));
		}
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) PendingMatch()/*auto state PendingMatch*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			MatchIsInProgress = GameInfo_PendingMatch_MatchIsInProgress;
			StartMatch = GameInfo_PendingMatch_StartMatch;
			StartArbitrationRegistration = GameInfo_PendingMatch_StartArbitrationRegistration;
			RegisterServerForArbitration = GameInfo_PendingMatch_RegisterServerForArbitration;
			ArbitrationRegistrationComplete = GameInfo_PendingMatch_ArbitrationRegistrationComplete;
			ArbitrationTimeout = GameInfo_PendingMatch_ArbitrationTimeout;
			StartArbitratedMatch = GameInfo_PendingMatch_StartArbitratedMatch;
			ProcessClientRegistrationCompletion = GameInfo_PendingMatch_ProcessClientRegistrationCompletion;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, GameInfo_PendingMatch_EndState);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PendingMatch": return PendingMatch();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return PendingMatch();
	}
	public GameInfo()
	{
		// Object Offset:0x00330E4C
		bRestartLevel = true;
		bPauseable = true;
		bDelayedStart = true;
		bChangeLevels = true;
		PauseGameSpeed = 0.00000010f;
		GameDifficulty = 1.0f;
		GameSpeed = 1.0f;
		HUDType = ClassT<HUD>()/*Ref Class'HUD'*/;
		MaxSpectators = 2;
		MaxSpectatorsAllowed = 32;
		MaxPlayers = 16;
		MaxPlayersAllowed = 32;
		CurrentID = 1;
		DefaultPlayerName = "Player";
		GameName = "Game";
		FearCostFallOff = 0.950f;
		DeathMessageClass = ClassT<LocalMessage>()/*Ref Class'LocalMessage'*/;
		GameMessageClass = ClassT<GameMessage>()/*Ref Class'GameMessage'*/;
		AccessControlClass = ClassT<AccessControl>()/*Ref Class'AccessControl'*/;
		BroadcastHandlerClass = ClassT<BroadcastHandler>()/*Ref Class'BroadcastHandler'*/;
		PlayerControllerClass = ClassT<PlayerController>()/*Ref Class'PlayerController'*/;
		PlayerReplicationInfoClass = ClassT<PlayerReplicationInfo>()/*Ref Class'PlayerReplicationInfo'*/;
		GameReplicationInfoClass = ClassT<GameReplicationInfo>()/*Ref Class'GameReplicationInfo'*/;
		TimeMarginSlack = 1.350f;
		MinTimeMargin = -1.0f;
		Components = default;
	}
}
}