namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPLevelRace : TdSPStoryGame/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdPlayerController RacingController;
	public float TargetTime;
	public bool bRaceOver;
	public /*private */UIDataStore_TdTimeTrialData TimeTrialData;
	public /*transient */TdSPPostProcessingBase PostProcess;
	
	public override Tick_del Tick { get => bfield_Tick ?? TdSPLevelRace_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdSPLevelRace_Tick;
	public /*function */void TdSPLevelRace_Tick(float DeltaTime)
	{
		/*Transformed 'base.' to specific call*/TdSPStoryGame_Tick(DeltaTime);
		if(ShouldIncremetLevelTimer())
		{
			TdGameData.TimeAttackClock += DeltaTime;
			if(RacingController.myPawn != default)
			{
				TdGameData.TimeAttackDistance += ((RacingController.myPawn.VelocityMagnitude * DeltaTime) * 0.010f);
			}
		}
	}
	
	public virtual /*function */bool ShouldIncremetLevelTimer()
	{
		return (((((!bRaceOver && RacingController != default) && !RacingController.bCinematicMode) && WorldInfo.Pauser == default) && !RacingController.IsButtonInputIgnored()) && ((RacingController.Pawn) as TdPlayerPawn).bAllowMoveChange) && !((RacingController.Pawn) as TdPlayerPawn).bSRPauseTimer;
	}
	
	public override /*event */void PostBeginPlay()
	{
		/*local */DataStoreClient DataStoreManager = default;
		/*local */String QualifierTimeString = default;
	
		base.PostBeginPlay();
		DataStoreManager = UIInteraction.GetDataStoreClient();
		if((TimeTrialData == default) && DataStoreManager != default)
		{
			TimeTrialData = ((DataStoreManager.FindDataStore("TdTimeTrialData", default(LocalPlayer))) as UIDataStore_TdTimeTrialData);
			TargetTime = TimeTrialData.GetTargetRaceData().TotalTime;
			if(TargetTime == 3599.990f)
			{
				TimeTrialData.GetStringValueFromProviderSet("TdLevelRaceStretches", "QualifyingTime", TimeTrialData.GetCurrentWorkingStretchProviderIndex(), ref/*probably?*/ QualifierTimeString);
				TargetTime = StringToFloat((QualifierTimeString));
			}
		}
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdSPLevelRace_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdSPLevelRace_Reset;
	public /*function */void TdSPLevelRace_Reset()
	{
		/*Transformed 'base.' to specific call*/TdSPGame_Reset();
		bRaceOver = false;
		PostProcess = default;
	}
	
	public override PostLogin_del PostLogin { get => bfield_PostLogin ?? TdSPLevelRace_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public override PostLogin_del global_PostLogin => TdSPLevelRace_PostLogin;
	public /*event */void TdSPLevelRace_PostLogin(PlayerController NewPlayer)
	{
		/*Transformed 'base.' to specific call*/TdSPStoryGame_PostLogin(NewPlayer);
		RacingController = ((NewPlayer) as TdPlayerController);
	}
	
	public override /*function */void OnPlayerDead()
	{
		SetTimer(PlayerRespawnTime, false, "ResetLevel", default(Object));
	}
	
	public virtual /*function */void RestartRace()
	{
		/*local */String AdditionalURL = default, MapName = default;
	
		TdGameData.TimeAttackClock = 0.0f;
		TdGameData.TimeAttackDistance = 0.0f;
		TdGameData.CheckpointManager.SetActiveCheckpoint("");
		AdditionalURL = "?OnlineMode=" + ((bOnlineMode)).ToString();
		MapName = TimeTrialData.GetStretchMapFilename(TimeTrialData.GetCurrentWorkingStretchProviderIndex(), "TdLevelRaceStretches");
		TdGameData.StartGame(MapName, "", "TdGame.TdSPLevelRace", AdditionalURL, false, true);
	}
	
	public override CanOpenPauseMenu_del CanOpenPauseMenu { get => bfield_CanOpenPauseMenu ?? TdSPLevelRace_CanOpenPauseMenu; set => bfield_CanOpenPauseMenu = value; } CanOpenPauseMenu_del bfield_CanOpenPauseMenu;
	public override CanOpenPauseMenu_del global_CanOpenPauseMenu => TdSPLevelRace_CanOpenPauseMenu;
	public /*function */bool TdSPLevelRace_CanOpenPauseMenu()
	{
		return /*Transformed 'base.' to specific call*/TdSPGame_CanOpenPauseMenu() && PostProcess == default;
	}
	
	public override /*function */void OnLevelCompleted(TdPlayerController PC, String CurrentLevelName, /*optional */String? _InNextLevelName = default, /*optional */String? _InNextCheckpointName = default)
	{
		var InNextLevelName = _InNextLevelName ?? default;
		var InNextCheckpointName = _InNextCheckpointName ?? default;
		bRaceOver = true;
		if(TimeTrialData.TTOnlineInput != default)
		{
			PostProcess =  ClassT<TdSPLevelRacePostProcessing>().New(this);
			PostProcess.ProcessRace(TimeTrialData.TTOnlineInput, TimeTrialData.GetCurrentWorkingStretchId(), OnOnlinePostProcessDone);		
		}
		else
		{
			OnOnlinePostProcessDone(default);
		}
	}
	
	public virtual /*private final function */void OnOnlinePostProcessDone(TdTTResult Result)
	{
		TimeTrialData.TTOnlineResult = Result;
		if(Result != default)
		{
			Result.PrintResult();
		}
		PostProcess =  ClassT<TdSPLevelRacePostProcessing>().New(this);
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
		/*local */TdGameUISceneClient SC = default;
	
		RacingController.OnLRCompleted(TimeTrialData.TTOnlineResult, TimeTrialData.TTOfflineResult);
		PostProcess = default;
		SC = ((UIRoot.GetSceneClient()) as TdGameUISceneClient);
		if(SC != default)
		{
			SC.OpenSceneEx(TdHUDContent.GetUISceneByName("TdEndOfLevelRace", "TdSpContent.TdHUDContentSP"), SC.Outer.Outer.Outer.GamePlayers[0], default(UIScene.ESceneTransitionAnim?), default(/*delegate*/UIScene.OnSceneActivated));
		}
	}
	
	public override /*function */void OnlineConnectionLost()
	{
		if(PostProcess != default)
		{
			PostProcess.PPOnlineConnectionLost();
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
		Reset = null;
		PostLogin = null;
		CanOpenPauseMenu = null;
	
	}
	public TdSPLevelRace()
	{
		// Object Offset:0x0065F5C2
		bAllowDifficultyChange = false;
		HUDType = ClassT<TdSPLevelRaceHUD>()/*Ref Class'TdSPLevelRaceHUD'*/;
		OnlineStatsWriteClass = ClassT<TdLeaderboardWriteSPTT>()/*Ref Class'TdLeaderboardWriteSPTT'*/;
	}
}
}