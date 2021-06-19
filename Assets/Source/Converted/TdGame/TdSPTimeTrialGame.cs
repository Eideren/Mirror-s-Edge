// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPTimeTrialGame : TdSPGame, 
		TdCheckpointListener/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public enum ETTStretch 
	{
		ETTS_None,
		ETTS_CranesA01,
		ETTS_CranesB01,
		ETTS_CranesB02,
		ETTS_EdgeA01,
		ETTS_StormdrainA01,
		ETTS_StormdrainA02,
		ETTS_StormdrainB01,
		ETTS_StormdrainB02,
		ETTS_StormdrainB03,
		ETTS_ConvoyA01,
		ETTS_ConvoyA02,
		ETTS_ConvoyB01,
		ETTS_ConvoyB02,
		ETTS_MallA01,
		ETTS_TutorialA01,
		ETTS_TutorialA02,
		ETTS_FactoryA01,
		ETTS_SkyscraperA01,
		ETTS_SkyscraperB01,
		ETTS_CranesC01,
		ETTS_TutorialA03,
		ETTS_EscapeA01,
		ETTS_EscapeB01,
		ETTS_CranesD01,
		ETTS_Max
	};
	
	public enum ERaceType 
	{
		ERT_PersonalBest,
		ERT_LeaderboardEntry,
		ERT_MAX
	};
	
	public partial struct TimeData
	{
		public float TotalTime;
		public array<float> IntermediateTimes;
		public array<float> AccumulatedIntermediateTimes;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006656A9
	//		TotalTime = 0.0f;
	//		IntermediateTimes = default;
	//		AccumulatedIntermediateTimes = default;
	//	}
	};
	
	public /*private config */int RaceFinishLineTime;
	public /*private config */float RaceFinishLineFadeTimePct;
	public /*private */float RaceFinishLineTimer;
	public /*private config */int RaceCountDownTime;
	public /*private */int RaceCountDownTimer;
	public /*private transient */TdPlaceableCheckpointManager CheckpointManager;
	public /*private transient */TdLookAtPoint CheckpointLookAtHelper;
	public /*private transient */TdPlaceableCheckpoint NextCheckPoint;
	public /*private transient */TdPlaceableCheckpoint LastCheckPoint;
	public /*transient */int NumCheckPoints;
	public /*transient */int NumPassedCheckPoints;
	public /*transient */int NumPassedTimerCheckPoints;
	public /*private transient */float LastCheckpointTimeStamp;
	public /*private transient */TdPlayerPawn RacingPawn;
	public /*protected transient */TdPlayerController RacingPlayer;
	public /*private transient */Object.Vector LastValidPlayerLocation;
	public /*private transient */float LastPlayerResetTime;
	public /*transient */byte bDelayPauseUntilRaceStarted;
	public /*transient */TdSPTimeTrialGame.ETTStretch ActiveTTStretch;
	public /*protected */TdSPTimeTrialGame.ERaceType RaceType;
	public /*transient */bool HasGhost;
	public /*private */bool bInitailRaceSpawn;
	public /*transient */TdSPPostProcessingBase PostProcess;
	public /*protected */float QualifyingTime;
	public StaticArray<float, float, float>/*[3]*/ StarRatingTimes;
	public /*transient */TdPlaceableCheckpointManager.TrackData CurrentTackData;
	public /*transient */TdSPTimeTrialGame.TimeData CurrentTimeData;
	public /*transient */TdSPTimeTrialGame.TimeData TimeDataToBeat;
	public /*transient */float RaceStartTimeStamp;
	public /*transient */float RaceEndTimeStamp;
	public /*transient */float PlayerDistance;
	public /*private transient */Core.ClassT<TdLocalMessage> TdTTMessageClass;
	public /*private transient */Core.ClassT<TdVictoryMessage> VictoryMessageClass;
	public /*private transient */Core.ClassT<TdLocalMessage> TimeMessageClass;
	public /*private transient */Core.ClassT<TdLocalMessage> TimeFinishMessageClass;
	public /*protected */TdGhostManager GhostManager;
	public /*private */UIDataStore_TdTimeTrialData TimeTrialData;
	
	public override /*event */void InitGame(String Options, ref String ErrorMessage)
	{
		/*local */String StretchStr = default;
		/*local */int ParsedRaceType = default;
	
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
		StretchStr = ParseOption(Options, "Stretch");
		ParsedRaceType = Max(0, GetIntOption(Options, "RaceType", ParsedRaceType));
		bOnlineMode = StringToBool((ParseOption(Options, "OnlineMode")));
		ActiveTTStretch = ((TdSPTimeTrialGame.ETTStretch)GetStretchFromName(((name)(StretchStr))));
		RaceType = ((TdSPTimeTrialGame.ERaceType)GetRaceTypeFromInt(ParsedRaceType));
		SendKismetEvent(ClassT<SeqEvt_TTRaceLoaded>());
	}
	
	public virtual /*function */TdPlaceableCheckpointManager.TrackData GetTrackData(int Stretch)
	{
		/*local */TdSPTimeTrialGame.ETTStretch OldStretch = default;
		/*local */TdPlaceableCheckpointManager.TrackData TData = default;
	
		OldStretch = ((TdSPTimeTrialGame.ETTStretch)ActiveTTStretch);
		ActiveTTStretch = ((TdSPTimeTrialGame.ETTStretch)((byte)(Stretch)));
		TData = CheckpointManager.GetTrackData(Stretch, ChoosePlayerStart(default, (byte)default(byte?)));
		ActiveTTStretch = ((TdSPTimeTrialGame.ETTStretch)OldStretch);
		return TData;
	}
	
	public /*function */static TdSPTimeTrialGame.ETTStretch GetStretchFromName(name Stretch)
	{
		/*local */int Idx = default;
	
		Idx = 0;
		J0x07:{}
		if(Idx < 25)
		{
			if(GetEnum(ObjectConst<Enum>("ETTStretch"), Idx) == Stretch)
			{
				return ((TdSPTimeTrialGame.ETTStretch)((byte)(Idx)));
			}
			++ Idx;
			goto J0x07;
		}
		return TdSPTimeTrialGame.ETTStretch.ETTS_None/*0*/;
	}
	
	public /*function */static TdSPTimeTrialGame.ERaceType GetRaceTypeFromInt(int InRaceType)
	{
		return ((TdSPTimeTrialGame.ERaceType)((byte)(InRaceType)));
	}
	
	public delegate float GetPlayerTime_del();
	public virtual GetPlayerTime_del GetPlayerTime { get => bfield_GetPlayerTime ?? TdSPTimeTrialGame_GetPlayerTime; set => bfield_GetPlayerTime = value; } GetPlayerTime_del bfield_GetPlayerTime;
	public virtual GetPlayerTime_del global_GetPlayerTime => TdSPTimeTrialGame_GetPlayerTime;
	public /*function */float TdSPTimeTrialGame_GetPlayerTime()
	{
		return CurrentTimeData.TotalTime;
	}
	
	public override GetLookAtPoint_del GetLookAtPoint { get => bfield_GetLookAtPoint ?? TdSPTimeTrialGame_GetLookAtPoint; set => bfield_GetLookAtPoint = value; } GetLookAtPoint_del bfield_GetLookAtPoint;
	public override GetLookAtPoint_del global_GetLookAtPoint => TdSPTimeTrialGame_GetLookAtPoint;
	public /*function */TdLookAtPoint TdSPTimeTrialGame_GetLookAtPoint(TdPawn Player)
	{
		return default;
	}
	
	public override /*function */void OnPlayerDead()
	{
	
	}
	
	public override CanOpenPauseMenu_del CanOpenPauseMenu { get => bfield_CanOpenPauseMenu ?? TdSPTimeTrialGame_CanOpenPauseMenu; set => bfield_CanOpenPauseMenu = value; } CanOpenPauseMenu_del bfield_CanOpenPauseMenu;
	public override CanOpenPauseMenu_del global_CanOpenPauseMenu => TdSPTimeTrialGame_CanOpenPauseMenu;
	public /*function */bool TdSPTimeTrialGame_CanOpenPauseMenu()
	{
		return false;
	}
	
	public override /*event */void PreBeginPlay()
	{
		/*local */DataStoreClient DataStoreManager = default;
	
		base.PreBeginPlay();
		AccuireSpectatorPoints();
		CheckpointManager = Spawn(ClassT<TdPlaceableCheckpointManager>(), this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
		CheckpointManager.Initialize(ClassT<TdTimerCheckpoint>(), this);
		if(((((int)ActiveTTStretch) > ((int)TdSPTimeTrialGame.ETTStretch.ETTS_None/*0*/)) && ((int)ActiveTTStretch) < ((int)TdSPTimeTrialGame.ETTStretch.ETTS_Max/*25*/)) && CheckpointManager.CanFindTrack(((int)ActiveTTStretch)))
		{
			CheckpointManager.ShowTrack(((int)ActiveTTStretch), true);
		}
		CheckpointLookAtHelper = Spawn(ClassT<TdLookAtPointSpawnable>(), this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
		GhostManager = Spawn(ClassT<TdGhostManager>(), default(Actor?), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
		TdTTMessageClass = ((DynamicLoadObject("TdTTContent.TdTimeTrialMessage", ClassT<Class>(), default(bool?))) as ClassT<TdLocalMessage>);
		VictoryMessageClass = ((DynamicLoadObject("TdTTContent.TdTTVictoryMessage", ClassT<Class>(), default(bool?))) as ClassT<TdVictoryMessage>);
		TimeMessageClass = ((DynamicLoadObject("TdTTContent.TdTimeMessage", ClassT<Class>(), default(bool?))) as ClassT<TdLocalMessage>);
		TimeFinishMessageClass = ((DynamicLoadObject("TdTTContent.TdFinishlineTimeMessage", ClassT<Class>(), default(bool?))) as ClassT<TdLocalMessage>);
		DataStoreManager = UIInteraction.GetDataStoreClient();
		if((TimeTrialData == default) && DataStoreManager != default)
		{
			TimeTrialData = ((DataStoreManager.FindDataStore("TdTimeTrialData", default(LocalPlayer?))) as UIDataStore_TdTimeTrialData);
		}
	}
	
	public override /*event */void PostSublevelStreaming(String Options)
	{
		if(((((int)ActiveTTStretch) > ((int)TdSPTimeTrialGame.ETTStretch.ETTS_None/*0*/)) && ((int)ActiveTTStretch) < ((int)TdSPTimeTrialGame.ETTStretch.ETTS_Max/*25*/)) && CheckpointManager.CanFindTrack(((int)ActiveTTStretch)))
		{
			CheckpointManager.ShowTrack(((int)ActiveTTStretch), true);
		}
	}
	
	public override PostLogin_del PostLogin { get => bfield_PostLogin ?? TdSPTimeTrialGame_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public override PostLogin_del global_PostLogin => TdSPTimeTrialGame_PostLogin;
	public /*event */void TdSPTimeTrialGame_PostLogin(PlayerController NewPlayer)
	{
		/*Transformed 'base.' to specific call*/GameInfo_PostLogin(NewPlayer);
		RacingPlayer = ((NewPlayer) as TdPlayerController);
		RacingPlayer.SetViewTarget(GetFirstSpectatorPoint(), default(Camera.ViewTargetTransitionParams?));
		RacingPlayer.ClientOpenScene("TdStartRace");
	}
	
	public override /*function */void RestartPlayer(Controller C)
	{
		base.RestartPlayer(C);
		RacingPawn = ((C.Pawn) as TdPlayerPawn);
	}
	
	public delegate void OnCheckpointCompleted_del(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller);
	public virtual OnCheckpointCompleted_del OnCheckpointCompleted { get => bfield_OnCheckpointCompleted ?? TdSPTimeTrialGame_OnCheckpointCompleted; set => bfield_OnCheckpointCompleted = value; } OnCheckpointCompleted_del bfield_OnCheckpointCompleted;
	public virtual OnCheckpointCompleted_del global_OnCheckpointCompleted => TdSPTimeTrialGame_OnCheckpointCompleted;
	public /*function */void TdSPTimeTrialGame_OnCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller)
	{
	
	}
	
	public override /*function */PlayerStart ChoosePlayerStart(Controller Player, /*optional */byte? _InTeam = default)
	{
		/*local */PlayerStart CurrentStart = default;
		/*local */TdTimeTrialStart BestTTStart = default;
		/*local */int Idx = default;
	
		var InTeam = _InTeam ?? default;
		Idx = 0;
		J0x08:{}
		if(Idx < StartPoints.Length)
		{
			CurrentStart = StartPoints[Idx];
			BestTTStart = ((CurrentStart) as TdTimeTrialStart);
			if((BestTTStart != default) && ((int)BestTTStart.TrackIndex) == ((int)ActiveTTStretch))
			{
				if(!bInitailRaceSpawn)
				{
					return BestTTStart;
					goto J0x90;
				}
				if(BestTTStart.bPrimaryStart)
				{
					return BestTTStart;
				}
			}
			J0x90:{}
			++ Idx;
			goto J0x08;
		}
		return CurrentStart;
	}
	
	public virtual /*function */void ResetPlayer(TdPlayerPawn PawnToReset, /*optional */NavigationPoint? _StartSpot = default)
	{
		/*local */NavigationPoint PlayerStartPoint = default;
		/*local */Object.Rotator ControllerRotation = default;
	
		var StartSpot = _StartSpot ?? default;
		PawnToReset.LastResetTimeStamp = WorldInfo.TimeSeconds;
		if(StartSpot == default)
		{
			PlayerStartPoint = FindClosestStartSpot(LastValidPlayerLocation);		
		}
		else
		{
			PlayerStartPoint = StartSpot;
		}
		PawnToReset.SetLocation(PlayerStartPoint.Location);
		if((NextCheckPoint != default) && !IsInState("RaceCountDown", default(bool?)))
		{
			ControllerRotation = ((Rotator)(NextCheckPoint.Location - PawnToReset.Location));
			ControllerRotation.Pitch = Clamp(ControllerRotation.Pitch, -8192, 8192);
			ControllerRotation.Roll = 0;
			PawnToReset.Controller.SetRotation(ControllerRotation);
			ControllerRotation.Pitch = 0;
			PawnToReset.SetRotation(ControllerRotation);		
		}
		else
		{
			ControllerRotation = PlayerStartPoint.Rotation;
			ControllerRotation.Roll = 0;
			ControllerRotation.Pitch = 0;
			PawnToReset.SetRotation(ControllerRotation);
			PawnToReset.Controller.SetRotation(ControllerRotation);
		}
		PawnToReset.GotoState("None", default(name?), default(bool?), default(bool?));
		PawnToReset.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		PawnToReset.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.0f);
		PawnToReset.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnToReset.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnToReset.Health = 100;
		PawnToReset.EnterFallingHeight = PlayerStartPoint.Location.Z;
		PawnToReset.ResetMoves();
		LastPlayerResetTime = WorldInfo.TimeSeconds;
	}
	
	public virtual /*function */void StoreLastValidPlayerLocation()
	{
		if(((RacingPawn != default) && ((int)RacingPawn.Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) && ((((int)RacingPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) || ((int)RacingPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Slide/*16*/)) || ((int)RacingPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Crouch/*15*/))
		{
			LastValidPlayerLocation = RacingPawn.Location;
		}
	}
	
	public override PreventDeath_del PreventDeath { get => bfield_PreventDeath ?? TdSPTimeTrialGame_PreventDeath; set => bfield_PreventDeath = value; } PreventDeath_del bfield_PreventDeath;
	public override PreventDeath_del global_PreventDeath => TdSPTimeTrialGame_PreventDeath;
	public /*function */bool TdSPTimeTrialGame_PreventDeath(Pawn KilledPawn, Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		/*local */TdPlayerPawn KilledPlayerPawn = default;
	
		KilledPlayerPawn = ((KilledPawn) as TdPlayerPawn);
		ResetPlayer(KilledPlayerPawn, default(NavigationPoint?));
		((RacingPlayer.myHUD) as TdHUD).Reset();
		((RacingPlayer.myHUD) as TdHUD).TriggerCustomColorFadeIn(1.50f, MakeLinearColor(0.0f, 0.0f, 0.0f, 1.0f), default(bool?), default, true);
		return true;
	}
	
	public virtual /*function */void SetIgnoreInput(bool bIgnore)
	{
		/*local */TdPlayerController PC = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (TdPlayerController)e0.Current) == PC)
		{
			PC.IgnoreButtonInput(bIgnore);
			PC.IgnoreLookInput(bIgnore);
			PC.IgnoreMoveInput(bIgnore);
			if(!bIgnore)
			{
				RacingPawn.StopIgnoreLookInput();
				RacingPawn.StopIgnoreMoveInput();
			}		
		}	
	}
	
	public delegate void ResetPlayerToLatestCheckpoint_del();
	public virtual ResetPlayerToLatestCheckpoint_del ResetPlayerToLatestCheckpoint { get => bfield_ResetPlayerToLatestCheckpoint ?? TdSPTimeTrialGame_ResetPlayerToLatestCheckpoint; set => bfield_ResetPlayerToLatestCheckpoint = value; } ResetPlayerToLatestCheckpoint_del bfield_ResetPlayerToLatestCheckpoint;
	public virtual ResetPlayerToLatestCheckpoint_del global_ResetPlayerToLatestCheckpoint => TdSPTimeTrialGame_ResetPlayerToLatestCheckpoint;
	public /*exec function */void TdSPTimeTrialGame_ResetPlayerToLatestCheckpoint()
	{
	
	}
	
	public virtual /*exec function */void StartRaceCountDown()
	{
		GotoState("RaceCountDown", default(name?), default(bool?), default(bool?));
	}
	
	public delegate void PrepareRace_del();
	public virtual PrepareRace_del PrepareRace { get => bfield_PrepareRace ?? TdSPTimeTrialGame_PrepareRace; set => bfield_PrepareRace = value; } PrepareRace_del bfield_PrepareRace;
	public virtual PrepareRace_del global_PrepareRace => TdSPTimeTrialGame_PrepareRace;
	public /*exec function */void TdSPTimeTrialGame_PrepareRace()
	{
		/*local */String QualifierTimeString = default, StarTimeString = default;
	
		if(((((int)ActiveTTStretch) <= ((int)TdSPTimeTrialGame.ETTStretch.ETTS_None/*0*/)) || ((int)ActiveTTStretch) >= ((int)TdSPTimeTrialGame.ETTStretch.ETTS_Max/*25*/)) || !CheckpointManager.CanFindTrack(((int)ActiveTTStretch)))
		{
			return;
		}
		if((((int)RaceType) >= ((int)TdSPTimeTrialGame.ERaceType.ERT_MAX/*2*/)) || ((int)RaceType) < ((int)TdSPTimeTrialGame.ERaceType.ERT_PersonalBest/*0*/))
		{
			RaceType = TdSPTimeTrialGame.ERaceType.ERT_PersonalBest/*0*/;
		}
		GhostManager.StopGhostRecording(RacingPawn);
		GhostManager.StopGhostPlayback();
		WorldInfo.MyDecalManager.ResetPool();
		WorldInfo.MyEmitterPool.ResetPool();
		ResetLevel();
		bRestartLevel = false;
		StartMatch();
		bRestartLevel = DefaultAs<GameInfo>().bRestartLevel;
		TriggerEventsOnLevelReload(RacingPlayer);
		TimeTrialData.GetStringValueFromProviderSet("TdTimeTrialStretches", "QualifyingTime", TimeTrialData.GetCurrentWorkingStretchProviderIndex(), ref/*probably?*/ QualifierTimeString);
		QualifyingTime = StringToFloat((QualifierTimeString));
		TimeTrialData.GetStringValueFromProviderSet("TdTimeTrialStretches", "Rating1Time", TimeTrialData.GetCurrentWorkingStretchProviderIndex(), ref/*probably?*/ StarTimeString);
		StarRatingTimes[2] = StringToFloat((StarTimeString));
		TimeTrialData.GetStringValueFromProviderSet("TdTimeTrialStretches", "Rating2Time", TimeTrialData.GetCurrentWorkingStretchProviderIndex(), ref/*probably?*/ StarTimeString);
		StarRatingTimes[1] = StringToFloat((StarTimeString));
		TimeTrialData.GetStringValueFromProviderSet("TdTimeTrialStretches", "Rating3Time", TimeTrialData.GetCurrentWorkingStretchProviderIndex(), ref/*probably?*/ StarTimeString);
		StarRatingTimes[0] = StringToFloat((StarTimeString));
		if(TimeTrialData.GetTargetRaceData().TotalTime == 3599.990f)
		{
			TimeDataToBeat = CreateFakeTimeData(((TdSPTimeTrialGame.ETTStretch)ActiveTTStretch), QualifyingTime);		
		}
		else
		{
			TimeDataToBeat = ReadTimeData(((int)ActiveTTStretch), ((int)RaceType));
		}
		if(TimeTrialData.CurrentGhost != default)
		{
			GhostManager.PlaybackData = TimeTrialData.CurrentGhost.RawBytes;
			HasGhost = true;
		}
		((RacingPlayer.myHUD) as TdHUD).ClearLocalMessages();
	}
	
	public virtual /*function */void TriggerEventsOnLevelReload(Controller NewPlayer)
	{
		/*local */Sequence GameSeq = default;
		/*local */array<SequenceObject> Events = default;
		/*local */int I = default;
	
		GameSeq = WorldInfo.GetGameSequence();
		if(GameSeq != default)
		{
			Events.Remove(0, Events.Length);
			GameSeq.FindSeqObjectsByClass(ClassT<SeqEvent_LevelLoaded>(), true, ref/*probably?*/ Events);
			I = 0;
			J0x50:{}
			if(I < Events.Length)
			{
				((Events[I]) as SeqEvent_LevelLoaded).CheckActivate(WorldInfo, default, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
				++ I;
				goto J0x50;
			}
		}
	}
	
	public virtual /*function */TdSPTimeTrialGame.TimeData CreateFakeTimeData(TdSPTimeTrialGame.ETTStretch Stretch, float TimeToBeat)
	{
		/*local */TdSPTimeTrialGame.TimeData NewTimeData = default;
		/*local */int Idx = default;
		/*local */float IntMPct = default, AccumTime = default;
		/*local */bool bOldInitailRaceSpawn = default;
	
		bOldInitailRaceSpawn = bOldInitailRaceSpawn;
		bInitailRaceSpawn = true;
		CurrentTackData = CheckpointManager.GetTrackData(((int)Stretch), ChoosePlayerStart(default, (byte)default(byte?)));
		bInitailRaceSpawn = bOldInitailRaceSpawn;
		NewTimeData.IntermediateTimes.Insert(0, CurrentTackData.IntermediateDistance.Length);
		NewTimeData.TotalTime = TimeToBeat;
		AccumTime = 0.0f;
		Idx = 0;
		J0x9A:{}
		if(Idx < CurrentTackData.IntermediateDistance.Length)
		{
			IntMPct = CurrentTackData.IntermediateDistance[Idx] / CurrentTackData.TotalDistance;
			AccumTime += (IntMPct * TimeToBeat);
			NewTimeData.IntermediateTimes[Idx] = IntMPct * TimeToBeat;
			NewTimeData.AccumulatedIntermediateTimes[Idx] = AccumTime;
			++ Idx;
			goto J0x9A;
		}
		Idx = 0;
		J0x146:{}
		if(Idx < NewTimeData.IntermediateTimes.Length)
		{
			++ Idx;
			goto J0x146;
		}
		return NewTimeData;
	}
	
	public virtual /*function */void CreateTimeData(TdPlaceableCheckpointManager.TrackData InTrackData, float InTotalTime, array<float> InTimes, ref TdSPTimeTrialGame.TimeData NewTimeData)
	{
		/*local */float AccumTime = default, IntMPct = default;
		/*local */int NumIntermediateTimes = default, Idx = default, InLength = default;
	
		NewTimeData.IntermediateTimes.Remove(0, NewTimeData.IntermediateTimes.Length);
		NewTimeData.AccumulatedIntermediateTimes.Remove(0, NewTimeData.AccumulatedIntermediateTimes.Length);
		NumIntermediateTimes = InTrackData.IntermediateDistance.Length;
		NewTimeData.IntermediateTimes.Insert(0, NumIntermediateTimes);
		NewTimeData.AccumulatedIntermediateTimes.Insert(0, NumIntermediateTimes);
		NewTimeData.TotalTime = InTotalTime;
		InLength = 0;
		J0xA8:{}
		if(InLength < InTimes.Length)
		{
			if(InTimes[InLength] == 0.0f)
			{
				goto J0xDA;
			}
			++ InLength;
			goto J0xA8;
		}
		J0xDA:{}
		if(InLength != NumIntermediateTimes)
		{
			AccumTime = 0.0f;
			Idx = 0;
			J0xFB:{}
			if(Idx < NumIntermediateTimes)
			{
				IntMPct = InTrackData.IntermediateDistance[Idx] / InTrackData.TotalDistance;
				AccumTime += (IntMPct * InTotalTime);
				NewTimeData.IntermediateTimes[Idx] = IntMPct * InTotalTime;
				NewTimeData.AccumulatedIntermediateTimes[Idx] = AccumTime;
				++ Idx;
				goto J0xFB;
			}		
		}
		else
		{
			AccumTime = 0.0f;
			Idx = 0;
			J0x1A9:{}
			if(Idx < NumIntermediateTimes)
			{
				AccumTime += InTimes[Idx];
				NewTimeData.IntermediateTimes[Idx] = InTimes[Idx];
				NewTimeData.AccumulatedIntermediateTimes[Idx] = AccumTime;
				++ Idx;
				goto J0x1A9;
			}
		}
	}
	
	public virtual /*function */TdSPTimeTrialGame.TimeData ReadTimeData(int Stretch, int InRaceType)
	{
		/*local */TdSPTimeTrialGame.TimeData NewTimeData = default;
		/*local */TdTTInput.TTData TargetTTData = default;
		/*local */int Idx = default;
	
		bInitailRaceSpawn = true;
		CurrentTackData = CheckpointManager.GetTrackData(Stretch, ChoosePlayerStart(default, (byte)default(byte?)));
		bInitailRaceSpawn = false;
		TargetTTData = TimeTrialData.GetTargetRaceData();
		CreateTimeData(CurrentTackData, TargetTTData.TotalTime, TargetTTData.IntermediateTimes.NewCopy(), ref/*probably?*/ NewTimeData);
		Idx = 0;
		J0x90:{}
		if(Idx < NewTimeData.IntermediateTimes.Length)
		{
			++ Idx;
			goto J0x90;
		}
		return NewTimeData;
	}
	
	public override /*function */void WriteOnlinePlayerScores()
	{
	
	}
	
	public override /*function */void WriteOnlineStats()
	{
		if(!IsSpectatingGhost())
		{
			if(TimeTrialData.TTOnlineInput != default)
			{
				PostProcess =  ClassT<TdSPTimeTrialPostProcessing>().New(this);
				PostProcess.ProcessRace(TimeTrialData.TTOnlineInput, TimeTrialData.GetCurrentWorkingStretchId(), OnOnlinePostProcessDone);			
			}
			else
			{
				OnOnlinePostProcessDone(default);
			}		
		}
		else
		{
			OnAllPostProcessDone(default);
		}
	}
	
	public virtual /*private final function */void OnOnlinePostProcessDone(TdTTResult Result)
	{
		TimeTrialData.TTOnlineResult = Result;
		if(Result != default)
		{
			Result.PrintResult();
		}
		PostProcess =  ClassT<TdSPTimeTrialPostProcessing>().New(this);
		PostProcess.ProcessRace(TimeTrialData.TTOfflineInput, TimeTrialData.GetCurrentWorkingStretchId(), OnOfflinePostProcessDone);
	}
	
	public virtual /*private final function */void OnOfflinePostProcessDone(TdTTResult Result)
	{
		TimeTrialData.TTOfflineResult = Result;
		Result.PrintResult();
		OnAllPostProcessDone(TimeTrialData.GetTimeTrialResult());
	}
	
	public virtual /*private final function */void OnAllPostProcessDone(TdTTResult FinalResult)
	{
		PostProcess = default;
		RacingPlayer.OnTTStretchCompleted(TimeTrialData.TTOnlineResult, TimeTrialData.TTOfflineResult);
		if(FinalResult != default)
		{
			if(FinalResult.IncreasedStarRating())
			{
				RacingPlayer.ClientOpenScene("TdStarRating");			
			}
			else
			{
				if(FinalResult.WasNewRecord())
				{
					RacingPlayer.ClientOpenScene("TdNewRecord");				
				}
				else
				{
					RacingPlayer.ClientOpenScene("TdEndOfRace");
				}
			}		
		}
		else
		{
			RacingPlayer.ClientOpenScene("TdEndOfRace");
		}
	}
	
	public override /*function */void OnlineConnectionLost()
	{
		if(PostProcess != default)
		{
			PostProcess.PPOnlineConnectionLost();
		}
	}
	
	public virtual /*exec function */void RecordGhost()
	{
		if(IsSpectatingGhost())
		{
			return;
		}
		if(RacingPawn != default)
		{
			GhostManager.RecordGhost(RacingPawn);		
		}
	}
	
	public virtual /*exec function */void StopGhostRecording()
	{
		if(IsSpectatingGhost())
		{
			return;
		}
		if(RacingPawn != default)
		{
			GhostManager.StopGhostRecording(RacingPawn);		
		}
	}
	
	public virtual /*function */bool IsSpectatingGhost()
	{
		return (RacingPlayer != default) && RacingPlayer.PlayerReplicationInfo.bOnlySpectator;
	}
	
	public virtual /*exec function */void ViewGhost()
	{
		if(IsSpectatingGhost())
		{
			RacingPlayer.NextViewTarget();
		}
	}
	
	public virtual /*function */void SendKismetEvent(Core.ClassT<SequenceEvent> EventClass)
	{
		/*local */int Index = default;
		/*local */Sequence GameSequence = default;
		/*local */array<SequenceObject> TimeTrialEvents = default;
	
		GameSequence = WorldInfo.GetGameSequence();
		GameSequence.FindSeqObjectsByClass(EventClass, true, ref/*probably?*/ TimeTrialEvents);
		Index = 0;
		J0x38:{}
		if(Index < TimeTrialEvents.Length)
		{
			((TimeTrialEvents[Index]) as SequenceEvent).CheckActivate(this, this, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
			++ Index;
			goto J0x38;
		}
	}
	
	public delegate void CountDownTimer_del();
	public virtual CountDownTimer_del CountDownTimer { get => bfield_CountDownTimer ?? TdSPTimeTrialGame_CountDownTimer; set => bfield_CountDownTimer = value; } CountDownTimer_del bfield_CountDownTimer;
	public virtual CountDownTimer_del global_CountDownTimer => TdSPTimeTrialGame_CountDownTimer;
	public /*private final function */void TdSPTimeTrialGame_CountDownTimer()
	{
	
	}
	
	public override /*event */void GameEnding()
	{
		base.GameEnding();
		StopGhostRecording();
		if(GhostManager != default)
		{
			GhostManager.StopGhostPlayback();
		}
	}
	
	public virtual /*function */void ClearIgnoreInput()
	{
		/*local */TdPlayerController PC = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (TdPlayerController)e0.Current) == PC)
		{
			PC.ResetPlayerMovementInput();
			PC.bCinematicMode = false;
			PC.bGodMode = false;		
		}	
	}
	
	public delegate void DisableIgnoreInputTimer_del();
	public virtual DisableIgnoreInputTimer_del DisableIgnoreInputTimer { get => bfield_DisableIgnoreInputTimer ?? TdSPTimeTrialGame_DisableIgnoreInputTimer; set => bfield_DisableIgnoreInputTimer = value; } DisableIgnoreInputTimer_del bfield_DisableIgnoreInputTimer;
	public virtual DisableIgnoreInputTimer_del global_DisableIgnoreInputTimer => TdSPTimeTrialGame_DisableIgnoreInputTimer;
	public /*private final function */void TdSPTimeTrialGame_DisableIgnoreInputTimer()
	{
	
	}
	
	public delegate void OnMaxFaded_del();
	public virtual OnMaxFaded_del OnMaxFaded { get => bfield_OnMaxFaded ?? TdSPTimeTrialGame_OnMaxFaded; set => bfield_OnMaxFaded = value; } OnMaxFaded_del bfield_OnMaxFaded;
	public virtual OnMaxFaded_del global_OnMaxFaded => TdSPTimeTrialGame_OnMaxFaded;
	public /*function */void TdSPTimeTrialGame_OnMaxFaded()
	{
	
	}
	
	public delegate void StartRace_del();
	public virtual StartRace_del StartRace { get => bfield_StartRace ?? (()=>{}); set => bfield_StartRace = value; } StartRace_del bfield_StartRace;
	public virtual StartRace_del global_StartRace => ()=>{};
	
	public delegate void ProcessTimedata_del(TdPlaceableCheckpoint Checkpoint);
	public virtual ProcessTimedata_del ProcessTimedata { get => bfield_ProcessTimedata ?? ((_a)=>{}); set => bfield_ProcessTimedata = value; } ProcessTimedata_del bfield_ProcessTimedata;
	public virtual ProcessTimedata_del global_ProcessTimedata => (_a)=>{};
	
	public delegate void ProcessCheckpointCompleted_del(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller);
	public virtual ProcessCheckpointCompleted_del ProcessCheckpointCompleted { get => bfield_ProcessCheckpointCompleted ?? ((_1,_2,_a)=>{}); set => bfield_ProcessCheckpointCompleted = value; } ProcessCheckpointCompleted_del bfield_ProcessCheckpointCompleted;
	public virtual ProcessCheckpointCompleted_del global_ProcessCheckpointCompleted => (_1,_2,_a)=>{};
	
	public delegate void ProcessLastCheckpointCompleted_del(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller);
	public virtual ProcessLastCheckpointCompleted_del ProcessLastCheckpointCompleted { get => bfield_ProcessLastCheckpointCompleted ?? ((_1,_2,_a)=>{}); set => bfield_ProcessLastCheckpointCompleted = value; } ProcessLastCheckpointCompleted_del bfield_ProcessLastCheckpointCompleted;
	public virtual ProcessLastCheckpointCompleted_del global_ProcessLastCheckpointCompleted => (_1,_2,_a)=>{};
	
	public delegate void RaceCompleted_del(TdPlayerController Controller);
	public virtual RaceCompleted_del RaceCompleted { get => bfield_RaceCompleted ?? ((_a)=>{}); set => bfield_RaceCompleted = value; } RaceCompleted_del bfield_RaceCompleted;
	public virtual RaceCompleted_del global_RaceCompleted => (_a)=>{};
	
	public delegate void SendFinishlineKismet_del(bool bNewRecord);
	public virtual SendFinishlineKismet_del SendFinishlineKismet { get => bfield_SendFinishlineKismet ?? ((_a)=>{}); set => bfield_SendFinishlineKismet = value; } SendFinishlineKismet_del bfield_SendFinishlineKismet;
	public virtual SendFinishlineKismet_del global_SendFinishlineKismet => (_a)=>{};
	
	#warning Renamed RaceOver, conflicting with state of the same name
	public delegate void RaceOver_del();
	public virtual RaceOver_del RaceOver_ { get => bfield_RaceOver ?? (()=>{}); set => bfield_RaceOver = value; } RaceOver_del bfield_RaceOver;
	public virtual RaceOver_del global_RaceOver => ()=>{};
	
	public delegate void KillRacingPawn_del();
	public virtual KillRacingPawn_del KillRacingPawn { get => bfield_KillRacingPawn ?? (()=>{}); set => bfield_KillRacingPawn = value; } KillRacingPawn_del bfield_KillRacingPawn;
	public virtual KillRacingPawn_del global_KillRacingPawn => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		GetPlayerTime = null;
		GetLookAtPoint = null;
		CanOpenPauseMenu = null;
		PostLogin = null;
		OnCheckpointCompleted = null;
		PreventDeath = null;
		ResetPlayerToLatestCheckpoint = null;
		PrepareRace = null;
		CountDownTimer = null;
		DisableIgnoreInputTimer = null;
		OnMaxFaded = null;
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PreRace()/*auto state PreRace*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, null);
	}
	
	
	protected /*function */void TdSPTimeTrialGame_RaceCountDown_BeginState(name PreviousState)// state function
	{
		/*local */TdSPTimeTrialGame.TimeData ZeroTimeData = default;
		/*local */PlayerStart StartSpot = default;
	
		bDelayPauseUntilRaceStarted = (byte)0;
		if(!CheckpointManager.ActivateTrack(((int)ActiveTTStretch)))
		{
			GotoState("PreRace", default(name?), default(bool?), default(bool?));
			return;
		}
		NumPassedCheckPoints = 0;
		NumPassedTimerCheckPoints = 0;
		NumCheckPoints = CheckpointManager.GetTrackSize();
		LastCheckPoint = default;
		NextCheckPoint = CheckpointManager.GetFirstCheckpoint();
		NextCheckPoint.Show(true, ((int)ActiveTTStretch), default(bool?));
		RaceStartTimeStamp = -1.0f;
		RaceEndTimeStamp = -1.0f;
		CurrentTimeData = ZeroTimeData;
		CurrentTimeData.IntermediateTimes.Insert(0, CurrentTackData.IntermediateDistance.Length);
		if((RacingPawn == default) && !IsSpectatingGhost())
		{
			bRestartLevel = false;
			RestartPlayer(RacingPlayer);
			bRestartLevel = DefaultAs<GameInfo>().bRestartLevel;
		}
		bInitailRaceSpawn = true;
		StartSpot = ChoosePlayerStart(default, (byte)default(byte?));
		if(!IsSpectatingGhost())
		{
			ResetPlayer(RacingPawn, StartSpot);
			SetIgnoreInput(true);
			RacingPlayer.SetCameraMode("FirstPerson");
			RacingPawn.SetFirstPerson(true);		
		}
		else
		{
			RacingPlayer.SetViewTarget(GetFirstSpectatorPoint(), default(Camera.ViewTargetTransitionParams?));
		}
		CurrentTackData = CheckpointManager.GetTrackData(((int)ActiveTTStretch), StartSpot);
		bInitailRaceSpawn = false;
		SetTimer(1.0f, true, "CountDownTimer", default(Object?));
		RaceCountDownTimer = RaceCountDownTime + 1;
		SendKismetEvent(ClassT<SeqEvt_TTRaceCountDownStarted>());
		RacingPawn.UnCrouch();
		RacingPlayer.bDuck = (byte)0;
	}
	
	protected /*function */bool TdSPTimeTrialGame_RaceCountDown_CanOpenPauseMenu()// state function
	{
		return true;
	}
	
	protected /*exec function */void TdSPTimeTrialGame_RaceCountDown_PrepareRace()// state function
	{
		GotoState("PreRace", default(name?), default(bool?), default(bool?));
		ClearTimer("CountDownTimer", default(Object?));
		global_PrepareRace();
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceCountDown_EndState(name NextStateName)// state function
	{
		RacingPlayer.SetCinematicMode(false, false, false, true, true, true, true);
		ClearIgnoreInput();
	}
	
	protected /*private final function */void TdSPTimeTrialGame_RaceCountDown_CountDownTimer()// state function
	{
		Timer();
		-- RaceCountDownTimer;
		if(RaceCountDownTimer <= 0)
		{
			StartRace();		
		}
		else
		{
			if(RaceCountDownTimer == 2)
			{
				BroadcastLocalizedMessage(TdTTMessageClass, 26, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));			
			}
			else
			{
				if(RaceCountDownTimer == 1)
				{
					bDelayPauseUntilRaceStarted = (byte)1;
					BroadcastLocalizedMessage(TdTTMessageClass, 25, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
				}
			}
		}
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceCountDown_StartRace()// state function
	{
		ClearTimer("CountDownTimer", default(Object?));
		BroadcastLocalizedMessage(TdTTMessageClass, 24, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
		SendKismetEvent(ClassT<SeqEvt_TTRaceStarted>());
		if(!IsSpectatingGhost())
		{
			GhostManager.StopGhostRecording(RacingPawn);
			GhostManager.RecordGhost(RacingPawn);
		}
		if(HasGhost)
		{
			GhostManager.StopGhostPlayback();
			GhostManager.PlaybackGhost();
		}
		GotoState("RaceInProgress", default(name?), default(bool?), default(bool?));
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RaceCountDown()/*state RaceCountDown*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			CanOpenPauseMenu = TdSPTimeTrialGame_RaceCountDown_CanOpenPauseMenu;
			PrepareRace = TdSPTimeTrialGame_RaceCountDown_PrepareRace;
			CountDownTimer = TdSPTimeTrialGame_RaceCountDown_CountDownTimer;
			StartRace = TdSPTimeTrialGame_RaceCountDown_StartRace;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdSPTimeTrialGame_RaceCountDown_BeginState, StateFlow, TdSPTimeTrialGame_RaceCountDown_EndState);
	}
	
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_BeginState(name PreviousState)// state function
	{
		RaceStartTimeStamp = WorldInfo.TimeSeconds;
		LastCheckpointTimeStamp = WorldInfo.TimeSeconds;
		PlayerDistance = 0.0f;
	}
	
	protected /*function */bool TdSPTimeTrialGame_RaceInProgress_CanOpenPauseMenu()// state function
	{
		return true;
	}
	
	protected /*function */TdLookAtPoint TdSPTimeTrialGame_RaceInProgress_GetLookAtPoint(TdPawn Player)// state function
	{
		if(!Player.Moves[((int)Player.MovementState)].CanUseLookAtHint())
		{
			return default;
		}
		if(NextCheckPoint != default)
		{
			CheckpointLookAtHelper.SetLocation(NextCheckPoint.Location);
		}
		return CheckpointLookAtHelper;
	}
	
	protected /*exec function */void TdSPTimeTrialGame_RaceInProgress_ResetPlayerToLatestCheckpoint()// state function
	{
		if((WorldInfo.TimeSeconds - LastPlayerResetTime) > 2.0f)
		{
			WorldInfo.MyEmitterPool.ResetPool();
			RacingPawn.ResetMoves();
			RacingPlayer.bDuck = (byte)0;
			ResetPlayer(RacingPawn, default(NavigationPoint?));
			SetIgnoreInput(true);
			SetTimer(0.80f, false, "DisableIgnoreInputTimer", default(Object?));
			((RacingPlayer.myHUD) as TdHUD).Reset();
			((RacingPlayer.myHUD) as TdHUD).TriggerCustomColorFadeIn(1.50f, MakeLinearColor(0.0f, 0.0f, 0.0f, 1.0f), default(bool?), default, true);
		}
	}
	
	protected /*private final function */void TdSPTimeTrialGame_RaceInProgress_DisableIgnoreInputTimer()// state function
	{
		SetIgnoreInput(false);
	}
	
	protected /*function */float TdSPTimeTrialGame_RaceInProgress_GetPlayerTime()// state function
	{
		return WorldInfo.TimeSeconds - RaceStartTimeStamp;
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_EndState(name NextStateName)// state function
	{
		bDelayPauseUntilRaceStarted = (byte)0;
		if(!IsSpectatingGhost())
		{
			PlayerDistance *= 0.010f;
		}
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_Tick(float DeltaTime)// state function
	{
		/*local */float PlayerSpeed = default, RaceTimeStamp = default;
	
		if(((int)bDelayPauseUntilRaceStarted) > ((int)1))
		{
			((RacingPlayer.myHUD) as TdTimeTrialHUD).DelayedPauseGame();
		}
		bDelayPauseUntilRaceStarted = (byte)0;
		if(!IsSpectatingGhost())
		{
			PlayerSpeed = VSize(RacingPawn.Velocity);
			PlayerDistance += (PlayerSpeed * DeltaTime);
			RaceTimeStamp = WorldInfo.TimeSeconds;
			if(((RaceTimeStamp - RaceStartTimeStamp) > QualifyingTime) && GhostManager.GhostRecordDriver != default)
			{
				GhostManager.StopGhostRecording(RacingPawn);
			}
		}
	}
	
	protected /*function */NavigationPoint TdSPTimeTrialGame_RaceInProgress_FindClosestStartSpot(Object.Vector ObjectLocation)// state function
	{
		/*local */int Index = default;
		/*local */PlayerStart PlayerStartPoint = default;
		/*local */TdTimeTrialStart TTStart = default;
		/*local */TdPlaceableCheckpoint PlaceableCheckPoint = default;
		/*local */TdTimerCheckpoint TimerCheckpoint = default;
	
		if(LastCheckPoint != default)
		{
			TimerCheckpoint = ((LastCheckPoint) as TdTimerCheckpoint);
			if(LastCheckPoint.bShouldBeBased && !TimerCheckpoint.bNoRespawn)
			{
				return LastCheckPoint;
			}
			PlaceableCheckPoint = LastCheckPoint;
			J0x56:{}
			if(!PlaceableCheckPoint.bShouldBeBased || TimerCheckpoint.bNoRespawn)
			{
				PlaceableCheckPoint = CheckpointManager.GetPreviousCheckpoint(PlaceableCheckPoint);
				TimerCheckpoint = ((PlaceableCheckPoint) as TdTimerCheckpoint);
				if(PlaceableCheckPoint == CheckpointManager.GetFirstCheckpoint())
				{
					return PlaceableCheckPoint;
				}
				goto J0x56;
			}
			return PlaceableCheckPoint;		
		}
		else
		{
			if(StartPoints.Length == 0)
			{
				return default;
			}
			PlayerStartPoint = StartPoints[0];
			Index = 1;
			J0xF9:{}
			if(Index < StartPoints.Length)
			{
				TTStart = ((StartPoints[Index]) as TdTimeTrialStart);
				if((TTStart != default) && ((int)TTStart.TrackIndex) == ((int)ActiveTTStretch))
				{
					return TTStart;
				}
				++ Index;
				goto J0xF9;
			}
			return PlayerStartPoint;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_OnCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller)// state function
	{
		if(!IsSpectatingGhost() && Pawn.IsA("TdGhostPawn"))
		{
			return;
		}
		if(NextCheckPoint == Checkpoint)
		{
			if(!IsSpectatingGhost() && Checkpoint.ShouldGenerateTrackData(((int)ActiveTTStretch)) || CheckpointManager.GetFinalCheckpoint() == Checkpoint)
			{
				ProcessTimedata(Checkpoint);
				++ NumPassedTimerCheckPoints;			
			}
			else
			{
				if(CheckpointManager.GetFinalCheckpoint() != NextCheckPoint)
				{
					BroadcastLocalizedMessage(TimeMessageClass, 2147483647, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
				}
			}
			++ NumPassedCheckPoints;
			if(CheckpointManager.GetFinalCheckpoint() == Checkpoint)
			{
				ProcessLastCheckpointCompleted(Checkpoint, Pawn, Controller);			
			}
			else
			{
				ProcessCheckpointCompleted(Checkpoint, Pawn, Controller);
			}
		}
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_ProcessTimedata(TdPlaceableCheckpoint Checkpoint)// state function
	{
		/*local */float ImtermediateDiffTime = default;
	
		CurrentTimeData.IntermediateTimes[NumPassedTimerCheckPoints] = WorldInfo.TimeSeconds - LastCheckpointTimeStamp;
		CurrentTimeData.AccumulatedIntermediateTimes[NumPassedTimerCheckPoints] = WorldInfo.TimeSeconds - RaceStartTimeStamp;
		if(TimeDataToBeat.AccumulatedIntermediateTimes[NumPassedTimerCheckPoints] > 0.0f)
		{
			ImtermediateDiffTime = CurrentTimeData.AccumulatedIntermediateTimes[NumPassedTimerCheckPoints] - TimeDataToBeat.AccumulatedIntermediateTimes[NumPassedTimerCheckPoints];		
		}
		else
		{
			ImtermediateDiffTime = -CurrentTimeData.AccumulatedIntermediateTimes[NumPassedTimerCheckPoints];
		}
		LastCheckpointTimeStamp = WorldInfo.TimeSeconds;
		if(CheckpointManager.GetFinalCheckpoint() != NextCheckPoint)
		{
			BroadcastLocalizedMessage(TimeMessageClass, Round(ImtermediateDiffTime * ((float)(100))), default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
		}
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_ProcessCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller)// state function
	{
		LastCheckPoint = NextCheckPoint;
		LastCheckPoint.Show(false, ((int)ActiveTTStretch), default(bool?));
		NextCheckPoint = CheckpointManager.GetNextCheckpoint(NextCheckPoint);
		NextCheckPoint.Show(true, ((int)ActiveTTStretch), default(bool?));
		((Controller.myHUD) as TdTimeTrialHUD).TriggerCheckPointEffect();
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_ProcessLastCheckpointCompleted(TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller)// state function
	{
		Checkpoint.Show(false, ((int)ActiveTTStretch), default(bool?));
		if(!IsSpectatingGhost())
		{
			RaceCompleted(Controller);
		}
		GotoState("RaceFinishLine", default(name?), default(bool?), default(bool?));
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_RaceCompleted(TdPlayerController Controller)// state function
	{
		/*local */float TimeDifference = default;
	
		RaceEndTimeStamp = WorldInfo.TimeSeconds;
		CurrentTimeData.TotalTime = RaceEndTimeStamp - RaceStartTimeStamp;
		TimeDifference = CurrentTimeData.TotalTime - TimeDataToBeat.TotalTime;
		if(TimeDataToBeat.TotalTime == ((float)(0)))
		{
			TimeDifference = -CurrentTimeData.TotalTime;
		}
		if(TimeDifference < 0.0f)
		{
			BroadcastLocalizedMessage(VictoryMessageClass, 28, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
			SendFinishlineKismet(true);		
		}
		else
		{
			BroadcastLocalizedMessage(VictoryMessageClass, 31, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
			SendFinishlineKismet(false);
		}
		BroadcastLocalizedMessage(TimeFinishMessageClass, Round(TimeDifference * ((float)(100))), default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_SendFinishlineKismet(bool bNewRecord)// state function
	{
		/*local */int Index = default;
		/*local */Sequence GameSequence = default;
		/*local */array<SequenceObject> TimeTrialEvents = default;
		/*local */array<int> OutputLinks = default;
	
		GameSequence = WorldInfo.GetGameSequence();
		GameSequence.FindSeqObjectsByClass(ClassT<SeqEvt_TTFinishLine>(), true, ref/*probably?*/ TimeTrialEvents);
		Index = 0;
		J0x38:{}
		if(Index < TimeTrialEvents.Length)
		{
			if(bNewRecord)
			{
				OutputLinks[0] = 0;			
			}
			else
			{
				OutputLinks[0] = 1;
			}
			((TimeTrialEvents[Index]) as SequenceEvent).CheckActivate(this, this, default(bool?), ref/*probably?*/ OutputLinks, default(bool?));
			++ Index;
			goto J0x38;
		}
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceInProgress_Timer()// state function
	{
		/*Transformed 'base.' to specific call*/GameInfo_Timer();
		if(!IsSpectatingGhost())
		{
			StoreLastValidPlayerLocation();
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RaceInProgress()/*state RaceInProgress*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			CanOpenPauseMenu = TdSPTimeTrialGame_RaceInProgress_CanOpenPauseMenu;
			GetLookAtPoint = TdSPTimeTrialGame_RaceInProgress_GetLookAtPoint;
			ResetPlayerToLatestCheckpoint = TdSPTimeTrialGame_RaceInProgress_ResetPlayerToLatestCheckpoint;
			DisableIgnoreInputTimer = TdSPTimeTrialGame_RaceInProgress_DisableIgnoreInputTimer;
			GetPlayerTime = TdSPTimeTrialGame_RaceInProgress_GetPlayerTime;
			Tick = TdSPTimeTrialGame_RaceInProgress_Tick;
			FindClosestStartSpot = TdSPTimeTrialGame_RaceInProgress_FindClosestStartSpot;
			OnCheckpointCompleted = TdSPTimeTrialGame_RaceInProgress_OnCheckpointCompleted;
			ProcessTimedata = TdSPTimeTrialGame_RaceInProgress_ProcessTimedata;
			ProcessCheckpointCompleted = TdSPTimeTrialGame_RaceInProgress_ProcessCheckpointCompleted;
			ProcessLastCheckpointCompleted = TdSPTimeTrialGame_RaceInProgress_ProcessLastCheckpointCompleted;
			RaceCompleted = TdSPTimeTrialGame_RaceInProgress_RaceCompleted;
			SendFinishlineKismet = TdSPTimeTrialGame_RaceInProgress_SendFinishlineKismet;
			Timer = TdSPTimeTrialGame_RaceInProgress_Timer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdSPTimeTrialGame_RaceInProgress_BeginState, StateFlow, TdSPTimeTrialGame_RaceInProgress_EndState);
	}
	
	
	protected /*function */void TdSPTimeTrialGame_RaceFinishLine_BeginState(name PreviousState)// state function
	{
		RaceFinishLineTimer = 0.0f;
		((RacingPlayer.myHUD) as TdHUD).ToggleReactionTime(true);
		SetIgnoreInput(true);
		RacingPlayer.SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_REACTION_TIME/*3*/, default(float?), default(bool?), default(float?));
	}
	
	protected /*event */void TdSPTimeTrialGame_RaceFinishLine_Tick(float DeltaTime)// state function
	{
		/*local */float MinGameSpeed = default, GameSpeedToDrain = default, NewGameSpeed = default, GameSpeedFadeTimePct = default;
	
		/*Transformed 'base.' to specific call*/Actor_Tick(DeltaTime);
		RaceFinishLineTimer += (DeltaTime / WorldInfo.TimeDilation);
		MinGameSpeed = 0.10f;
		GameSpeedFadeTimePct = RaceFinishLineFadeTimePct;
		if(RaceFinishLineTimer > ((float)(RaceFinishLineTime)))
		{
			GhostManager.StopGhostPlayback();
			GhostManager.StopGhostRecording(RacingPawn);
			GotoState("EndAnimation", default(name?), default(bool?), default(bool?));		
		}
		else
		{
			if(RaceFinishLineTimer > (((float)(RaceFinishLineTime)) * (1.0f - GameSpeedFadeTimePct)))
			{			
			}
			else
			{
				GameSpeedToDrain = DeltaTime / (((float)(RaceFinishLineTime)) * GameSpeedFadeTimePct);
				GameSpeedToDrain /= WorldInfo.TimeDilation;
				NewGameSpeed = GameSpeed - GameSpeedToDrain;
				NewGameSpeed = FMax(MinGameSpeed, NewGameSpeed);
				SetGameSpeed(NewGameSpeed);
			}
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RaceFinishLine()/*state RaceFinishLine*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ PrepareRace = ()=>{};
	
			Tick = TdSPTimeTrialGame_RaceFinishLine_Tick;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdSPTimeTrialGame_RaceFinishLine_BeginState, StateFlow, null);
	}
	
	
	protected /*function */void TdSPTimeTrialGame_EndAnimation_BeginState(name PreviousState)// state function
	{
		SendKismetEvent(ClassT<SeqEvt_TTRaceFinished>());
		RaceOver();
	}
	
	protected /*function */void TdSPTimeTrialGame_EndAnimation_RaceOver()// state function
	{
		((RacingPlayer.myHUD) as TdTimeTrialHUD).TriggerCustomColorBlink(0.060f, 0.40f, 1.0f, 1.0f, 1.0f, true, () => OnMaxFaded());
	}
	
	protected /*function */void TdSPTimeTrialGame_EndAnimation_OnMaxFaded()// state function
	{
		((RacingPlayer.myHUD) as TdHUD).ClearLocalMessages();
		((RacingPlayer.myHUD) as TdHUD).ToggleReactionTime(false);
		((RacingPlayer.myHUD) as TdHUD).EffectManager.ReactionTimeEffect.Hide();
		RacingPlayer.SetViewTarget(GetLastSpectatorPoint(), default(Camera.ViewTargetTransitionParams?));
		SetGameSpeed(1.0f);
		GotoState("RaceOver", default(name?), default(bool?), default(bool?));
		RacingPlayer.SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/, default(float?), default(bool?), default(float?));
	}
	
	protected /*function */void TdSPTimeTrialGame_EndAnimation_EndState(name NextStateName)// state function
	{
		SetIgnoreInput(false);
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) EndAnimation()/*state EndAnimation*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ PrepareRace = ()=>{};
	
			RaceOver_ = TdSPTimeTrialGame_EndAnimation_RaceOver;
			OnMaxFaded = TdSPTimeTrialGame_EndAnimation_OnMaxFaded;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdSPTimeTrialGame_EndAnimation_BeginState, StateFlow, TdSPTimeTrialGame_EndAnimation_EndState);
	}
	
	
	protected /*function */void TdSPTimeTrialGame_RaceOver_BeginState(name PreviousState)// state function
	{
		RaceStartTimeStamp = -1.0f;
		RaceEndTimeStamp = -1.0f;
		NextCheckPoint = default;
		LastCheckPoint = default;
		EndGame(RacingPlayer.PlayerReplicationInfo, "RaceOver");
		KillRacingPawn();
		RacingPlayer.SetViewTarget(GetLastSpectatorPoint(), default(Camera.ViewTargetTransitionParams?));
		if(((((int)ActiveTTStretch) > ((int)TdSPTimeTrialGame.ETTStretch.ETTS_None/*0*/)) && ((int)ActiveTTStretch) < ((int)TdSPTimeTrialGame.ETTStretch.ETTS_Max/*25*/)) && CheckpointManager.CanFindTrack(((int)ActiveTTStretch)))
		{
			CheckpointManager.ShowTrack(((int)ActiveTTStretch), true);
		}
	}
	
	protected /*function */void TdSPTimeTrialGame_RaceOver_KillRacingPawn()// state function
	{
		/*local */Pawn OldPawn = default;
	
		if(RacingPlayer.Pawn != default)
		{
			OldPawn = RacingPlayer.Pawn;
			RacingPlayer.Pawn.StopFiring();
			RacingPlayer.UnPossess();
			if(((OldPawn) as TdPawn) != default)
			{
				OldPawn.Destroy();
			}
		}
		RacingPlayer.ClientReset();
		RacingPlayer.Reset();
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RaceOver()/*state RaceOver*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			KillRacingPawn = TdSPTimeTrialGame_RaceOver_KillRacingPawn;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdSPTimeTrialGame_RaceOver_BeginState, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PreRace": return PreRace();
			case "RaceCountDown": return RaceCountDown();
			case "RaceInProgress": return RaceInProgress();
			case "RaceFinishLine": return RaceFinishLine();
			case "EndAnimation": return EndAnimation();
			case "RaceOver": return RaceOver();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return PreRace();
	}



	void TdCheckpointListener.OnCheckpointCompleted( TdPlaceableCheckpoint Checkpoint, TdPlayerPawn Pawn, TdPlayerController Controller )
	{
		OnCheckpointCompleted( Checkpoint, Pawn, Controller );
	}
	
	
	
	public TdSPTimeTrialGame()
	{
		// Object Offset:0x00668EAD
		RaceFinishLineTime = 4;
		RaceFinishLineFadeTimePct = 0.050f;
		RaceCountDownTime = 3;
		bAllowDifficultyChange = false;
		bEnableLOI = false;
		bDelayedStart = true;
		HUDType = ClassT<TdTimeTrialHUD>()/*Ref Class'TdTimeTrialHUD'*/;
		OnlineStatsWriteClass = ClassT<TdLeaderboardWriteSPTT>()/*Ref Class'TdLeaderboardWriteSPTT'*/;
	}
}
}