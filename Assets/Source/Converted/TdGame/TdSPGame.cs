namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPGame : TdGameInfo/*
		abstract
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct OnLevelCompletedAsyncHelper
	{
		public string NextLevelName;
		public string NextCheckpointName;
		public int ControllerId;
		public TdPlayerController PC;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0058D879
	//		NextLevelName = "";
	//		NextCheckpointName = "";
	//		ControllerId = -1;
	//		PC = default;
	//	}
	};
	
	public bool bShouldSaveCheckpointProgress;
	public bool bAllowSPLevelAchievements;
	public /*protected config */float PlayerRespawnTime;
	public /*transient */TdSPGame.OnLevelCompletedAsyncHelper OnLCAsyncHelper;
	public TdAIManager AIManager;
	
	public override /*event */void InitGame(string Options, ref string ErrorMessage)
	{
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
		bShouldSaveCheckpointProgress = StringToBool((ParseOption(Options, "AllowCPSaving")));
		bAllowSPLevelAchievements = StringToBool((ParseOption(Options, "AllowLevelAchievements")));
		InitGameDebug();
	}
	
	public virtual /*private final function */void InitGameDebug()
	{
	
	}
	
	public virtual /*function */void InitAI()
	{
		AIManager = Spawn(ClassT<TdAIManager>(), default(Actor), default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
	}
	
	public virtual /*function */void OnPlayerDead()
	{
		SetTimer(PlayerRespawnTime, false, "ResetLevel", default(Object));
	}
	
	public virtual /*function */void RestartFromLastCheckpoint()
	{
		/*local */TdPlayerController C = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (C = (TdPlayerController)e0.Current) == C)
		{
			((C.myHUD) as TdHUD).TriggerCustomColorFadeOut(0.50f, MakeLinearColor(1.0f, 1.0f, 1.0f, 1.0f), default(bool), default(/*delegate*/TdHUD.OnMaxFade));		
		}	
		SetTimer(0.50f, false, "RestartFromLastCheckpointDead", default(Object));
	}
	
	public virtual /*function */void RestartFromLastCheckpointDead()
	{
		/*local */TdPlayerController C = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (C = (TdPlayerController)e0.Current) == C)
		{
			C.GotoState("Dead", default(name), default(bool), default(bool));
			C.LoadStatsFromProfile(bShouldSaveCheckpointProgress, bShouldSaveCheckpointProgress, true);		
		}	
	}
	
	public virtual /*function */void RespawnTimer()
	{
		/*local */TdPlayerController C = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdGameData GameData = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (C = (TdPlayerController)e0.Current) == C)
		{
			if(C.IsDead())
			{
				DataStoreManager = UIInteraction.GetDataStoreClient();
				if(DataStoreManager != default)
				{
					GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
					if(GameData != default)
					{
						GameData.RestartFromLastCheckpoint(default(bool), default(bool));					
					}
					continue;
				}
			}		
		}	
	}
	
	public override /*function */void StartOnlineGame()
	{
		GameReplicationInfo.StartMatch();
	}
	
	public override /*exec function */void KillBots()
	{
		/*local */Pawn P = default;
		/*local */AITeam T = default;
	
		
		// foreach DynamicActors(ClassT<Pawn>(), ref/*probably?*/ P)
		using var e0 = DynamicActors(ClassT<Pawn>()).GetEnumerator();
		while(e0.MoveNext() && (P = (Pawn)e0.Current) == P)
		{
			if(!P.IsPlayerPawn())
			{
				if(P.Controller != default)
				{
					P.Controller.Destroy();
				}
				P.Destroy();
			}		
		}	
		
		// foreach DynamicActors(ClassT<AITeam>(), ref/*probably?*/ T)
		using var e100 = DynamicActors(ClassT<AITeam>()).GetEnumerator();
		while(e100.MoveNext() && (T = (AITeam)e100.Current) == T)
		{
			T.Reset();		
		}	
	}
	
	public override /*event */void PreBeginPlay()
	{
		base.PreBeginPlay();
		InitAI();
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdSPGame_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdSPGame_Reset;
	public /*function */void TdSPGame_Reset()
	{
		/*local */TdSPGame.OnLevelCompletedAsyncHelper ZeroHelper = default;
	
		/*Transformed 'base.' to specific call*/TdGameInfo_Reset();
		OnLCAsyncHelper = ZeroHelper;
	}
	
	public override CanOpenPauseMenu_del CanOpenPauseMenu { get => bfield_CanOpenPauseMenu ?? TdSPGame_CanOpenPauseMenu; set => bfield_CanOpenPauseMenu = value; } CanOpenPauseMenu_del bfield_CanOpenPauseMenu;
	public override CanOpenPauseMenu_del global_CanOpenPauseMenu => TdSPGame_CanOpenPauseMenu;
	public /*function */bool TdSPGame_CanOpenPauseMenu()
	{
		/*local */TdSPGame.OnLevelCompletedAsyncHelper ZeroHelper = default;
	
		return /*Transformed 'base.' to specific call*/GameInfo_CanOpenPauseMenu() && OnLCAsyncHelper == ZeroHelper;
	}
	
	public virtual /*function */void OnLevelCompleted(TdPlayerController PC, string CurrentLevelName, /*optional */string InNextLevelName = default, /*optional */string InNextCheckpointName = default)
	{
		/*local */int LevelIndex = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdGameData GameData = default;
	
		LevelIndex = -1;
		DataStoreManager = UIInteraction.GetDataStoreClient();
		if(DataStoreManager != default)
		{
			GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
			if(GameData != default)
			{
				LevelIndex = GameData.GetMapIndexFromFileName(CurrentLevelName);
			}
		}
		PC.OnLevelCompleted(LevelIndex, this);
		OnLCAsyncHelper.NextLevelName = InNextLevelName;
		OnLCAsyncHelper.NextCheckpointName = InNextCheckpointName;
		OnLCAsyncHelper.ControllerId = ((PC.Player) as LocalPlayer).ControllerId;
		OnLCAsyncHelper.PC = PC;
		TryWriteProfeile();
	}
	
	public virtual /*function */void TryWriteProfeile()
	{
		/*local */TdProfileSettings Profile = default;
	
		((UIRoot.GetCurrentUIController()) as TdUIInteraction).BlockUIInput(true);
		Profile = OnLCAsyncHelper.PC.GetProfileSettings();
		if(((Profile != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.PlayerInterface, (default(OnlinePlayerInterface))))
		{
			OnlineSub.PlayerInterface.AddWriteProfileSettingsCompleteDelegate((byte)((byte)(OnLCAsyncHelper.ControllerId)), OnProfileWriteCompleted);
			if(!OnlineSub.PlayerInterface.WriteProfileSettings((byte)((byte)(OnLCAsyncHelper.ControllerId)), Profile))
			{
				((UIRoot.GetCurrentUIController()) as TdUIInteraction).BlockUIInput(false);
				OnlineSub.PlayerInterface.ClearWriteProfileSettingsCompleteDelegate((byte)((byte)(OnLCAsyncHelper.ControllerId)), OnProfileWriteCompleted);
				ShowErrorMessageBox();
			}
		}
	}
	
	public virtual /*function */void OnProfileWriteCompleted(bool bWasSuccessful)
	{
		/*local */bool bIsGameComplete = default;
		/*local */TdGameUISceneClient SceneClient = default;
		/*local */PlayerController PC = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdGameData GameData = default;
	
		OnlineSub.PlayerInterface.ClearWriteProfileSettingsCompleteDelegate((byte)((byte)(OnLCAsyncHelper.ControllerId)), OnProfileWriteCompleted);
		((UIRoot.GetCurrentUIController()) as TdUIInteraction).BlockUIInput(false);
		if(bWasSuccessful)
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
				if(GameData != default)
				{
					bIsGameComplete = GameData.GetMapIndexFromFileName(WorldInfo.GetMapName(default(bool))) == 10;
				}
			}
			if(bIsGameComplete)
			{
				SceneClient = ((UIRoot.GetSceneClient()) as TdGameUISceneClient);
				
				// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
				using var e269 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
				while(e269.MoveNext() && (PC = (PlayerController)e269.Current) == PC)
				{
					SceneClient.OpenSceneEx(TdHUDContent.GetUISceneByName("TdCredits", default(string)), ((PC.Player) as LocalPlayer), UIScene.ESceneTransitionAnim.ANIM_All/*0*/, OnCreditsOpened);				
				}						
			}
			else
			{
				OnLoadNextLevel();
			}		
		}
		else
		{
			ShowErrorMessageBox();
		}
	}
	
	public virtual /*function */void OnCreditsOpened(UIScene OpenedScene, bool bInitialActivation)
	{
		if(bInitialActivation)
		{
			((OpenedScene) as TdUIScene_TdCredits).SetFinalCredits(OnLoadNextLevel);
		}
	}
	
	public virtual /*private final function */void ShowErrorMessageBox()
	{
		/*local */TdGameUISceneClient SceneClient = default;
	
		SceneClient = ((UIRoot.GetSceneClient()) as TdGameUISceneClient);
		SceneClient.OpenMessageBox(OnShowErrorMessageBox_Init, UIScene.ESceneTransitionAnim.ANIM_Target/*2*/);
	}
	
	public virtual /*private final function */void OnShowErrorMessageBox_Init(UIScene OpenedScene, bool bInitialActivation)
	{
		/*local */TdUIScene_MessageBox ErrorMessageBox = default;
	
		ErrorMessageBox = ((OpenedScene) as TdUIScene_MessageBox);
		ErrorMessageBox.DisplayAcceptCancelRetryBox("<Strings:TdGameUI.TdMessageBox.FailedToWriteProfileProgress_Message>", "<Strings:TdGameUI.TdMessageBox.FailedToWriteProfile_Title>", OnErrorMessageBoxClosed, default(bool));
	}
	
	public virtual /*private final function */void OnErrorMessageBoxClosed(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		switch(SelectedOption)
		{
			case 1:
				TryWriteProfeile();
				break;
			default:
				OnLoadNextLevel();
				break;
		}
	}
	
	public override /*event */void SetPlayerStart(string StartLocation)
	{
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdGameData GameData = default;
	
		DataStoreManager = UIInteraction.GetDataStoreClient();
		if(DataStoreManager != default)
		{
			GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
			if(GameData != default)
			{
				GameData.CheckpointManager.SetActiveCheckpoint(StartLocation);
			}
		}
	}
	
	public virtual /*function */void OnLoadNextLevel()
	{
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdGameData GameData = default;
	
		if(bShouldSaveCheckpointProgress)
		{
			if(OnLCAsyncHelper.NextLevelName != "")
			{
				DataStoreManager = UIInteraction.GetDataStoreClient();
				if(DataStoreManager != default)
				{
					OnLCAsyncHelper.PC = default;
					GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
					if(GameData != default)
					{
						GameData.StartGame(OnLCAsyncHelper.NextLevelName, OnLCAsyncHelper.NextCheckpointName, default(string), "?PlayCutSceneMovie", bShouldSaveCheckpointProgress, true);
					}
				}
			}		
		}
		else
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			OnLCAsyncHelper.PC = default;
			GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer))) as UIDataStore_TdGameData);
			GameData.QuitToMainMenu();
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		CanOpenPauseMenu = null;
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PendingMatch()/*auto state PendingMatch*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			StartMatch();
			yield return Flow.Stop;				
		}
	
		return (null, StateFlow, null);
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
	public TdSPGame()
	{
		// Object Offset:0x0058EFB7
		PlayerRespawnTime = 0.10f;
		OnLCAsyncHelper = new TdSPGame.OnLevelCompletedAsyncHelper
		{
			NextLevelName = "",
			NextCheckpointName = "",
			ControllerId = -1,
			PC = default,
		};
		bDelayedStart = false;
		HUDType = ClassT<TdSPHUD>()/*Ref Class'TdSPHUD'*/;
	}
}
}