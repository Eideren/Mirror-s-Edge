// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSPStoryGame : TdSPGame/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public array<TdBossFight> BossFights;
	public int ActiveBossFight;
	public bool bAllowStreamingVolumes;
	
	public override Tick_del Tick { get => bfield_Tick ?? TdSPStoryGame_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdSPStoryGame_Tick;
	public /*function */void TdSPStoryGame_Tick(float DeltaTime)
	{
		if((ActiveBossFight != -1) && BossFights.Length > ActiveBossFight)
		{
			BossFights[ActiveBossFight].Tick(DeltaTime);
		}
		if(WorldInfo.bReloadScriptLevelsDone)
		{
			OnScriptLevelsReloaded();
			WorldInfo.bReloadScriptLevelsDone = false;
		}
		/*Transformed 'base.' to specific call*/Actor_Tick(DeltaTime);
	}
	
	public override /*event */void PreBeginPlay()
	{
		base.PreBeginPlay();
		VoiceOverManager.Reset();
	}
	
	public override PostLogin_del PostLogin { get => bfield_PostLogin ?? TdSPStoryGame_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public override PostLogin_del global_PostLogin => TdSPStoryGame_PostLogin;
	public /*event */void TdSPStoryGame_PostLogin(PlayerController NewPlayer)
	{
		NewPlayer.bIsUsingStreamingVolumes = false;
		/*Transformed 'base.' to specific call*/GameInfo_PostLogin(NewPlayer);
	}
	
	public /*function */static bool AllowReactionTime()
	{
		return true;
	}
	
	public override /*function */void InitAI()
	{
		base.InitAI();
		VoiceOverManager = Spawn(ClassT<TdAIVoiceOverManager>(), default, default, default, default, default, default);
		
		#warning weird ass add commented out
		//BossFights.Add(0);
		BossFights[0] =  ClassT<TdBossFight>().New(this);
	}
	
	public override /*function */bool UseStreamingVolumes(bool bInFreeCam)
	{
		if(bInFreeCam)
		{
			return bAllowStreamingVolumes;		
		}
		else
		{
			return false;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public override /*function */void ResetLevel()
	{
		WorldInfo.bReloadScriptLevels = true;
		KillBots();
	}
	
	public virtual /*function */void OnScriptLevelsReloaded()
	{
		/*local */PlayerController PC = default;
	
		ResetLevel();
		
		// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e6 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e6.MoveNext() && (PC = (PlayerController)e6.Current) == PC)
		{
			PC.ServerRestartPlayer();		
		}	
	}
	
	public override /*function */NavigationPoint FindPlayerStart(Controller Player, /*optional */byte? _InTeam = default, /*optional */String? _IncomingName = default)
	{
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdGameData GameData = default;
		/*local */NavigationPoint CurrentCheckpoint = default;
	
		var InTeam = _InTeam ?? default;
		var IncomingName = _IncomingName ?? default;
		DataStoreManager = UIInteraction.GetDataStoreClient();
		if(DataStoreManager != default)
		{
			GameData = ((DataStoreManager.FindDataStore("TdGameData", default(LocalPlayer?))) as UIDataStore_TdGameData);
			if(GameData != default)
			{
				CurrentCheckpoint = GameData.CheckpointManager.FindCurrentCheckpoint();
			}
		}
		if(CurrentCheckpoint != default)
		{
			return CurrentCheckpoint;
		}
		return base.FindPlayerStart(Player, (byte)InTeam, IncomingName);
	}
	
	public override /*function */void RestartPlayer(Controller NewPlayer)
	{
		/*local */NavigationPoint StartSpot = default;
		/*local */TdCheckpoint CurrentCheckpoint = default;
		/*local */array<SequenceObject> Events = default;
		/*local */int TeamNum = default, Idx = default;
		/*local */SeqEvent_PlayerSpawned SpawnedEvent = default;
	
		TeamNum = (((NewPlayer.PlayerReplicationInfo == default) || NewPlayer.PlayerReplicationInfo.Team == default) ? 255 : NewPlayer.PlayerReplicationInfo.Team.TeamIndex);
		StartSpot = FindPlayerStart(NewPlayer, (byte)((byte)(TeamNum)), default(String?));
		if(StartSpot == default)
		{
			return;		
		}
		else
		{
			if(StartSpot.IsA("TdCheckpoint"))
			{
				CurrentCheckpoint = ((StartSpot) as TdCheckpoint);
				TriggerEventsOnLevelReload(CurrentCheckpoint, NewPlayer);
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
				Events.Remove(0, Events.Length);
				WorldInfo.GetGameSequence().FindSeqObjectsByClass(ClassT<SeqEvent_PlayerSpawned>(), true, ref/*probably?*/ Events);
				Idx = 0;
				J0x324:{}
				if(Idx < Events.Length)
				{
					SpawnedEvent = ((Events[Idx]) as SeqEvent_PlayerSpawned);
					if((SpawnedEvent != default) && SpawnedEvent.CheckActivate(NewPlayer, NewPlayer, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?)))
					{
						SpawnedEvent.SpawnPoint = StartSpot;
						SpawnedEvent.PopulateLinkedVariableValues();
					}
					++ Idx;
					goto J0x324;
				}
			}
		}
	}
	
	public override /*event */void PostSublevelStreaming(String Options)
	{
		base.PostSublevelStreaming(Options);
		if(!HasOption(Options, "NoControllerCheck"))
		{
			CheckDeviceConnected();
		}
	}
	
	public virtual /*function */void CheckDeviceConnected()
	{
		/*local */TdPlayerController PC = default;
	
		if(WorldInfo.IsConsoleBuild(default(WorldInfo.EConsoleType?)))
		{
			
			// foreach LocalPlayerControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PC)
			using var e20 = LocalPlayerControllers(ClassT<TdPlayerController>()).GetEnumerator();
			while(e20.MoveNext() && (PC = (TdPlayerController)e20.Current) == PC)
			{
				if((OnlineSub != default) && !OnlineSub.SystemInterface.IsControllerConnected(((PC.Player) as LocalPlayer).ControllerId))
				{
					((PC.myHUD) as TdHUD).DelayedPauseGame();
				}			
			}		
		}
	}
	
	public virtual /*function */void TriggerEventsOnLevelReload(TdCheckpoint CurrentCheckpoint, Controller NewPlayer)
	{
		/*local */Sequence GameSeq = default;
		/*local */array<SequenceObject> Events = default;
		/*local */SequenceEvent Event = default;
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
		if(CurrentCheckpoint != default)
		{
			using var v = CurrentCheckpoint.GeneratedEvents.GetEnumerator();while(v.MoveNext() && (Event = (SequenceEvent)v.Current) == Event)
			{
				if(Event.IsA("SeqEvt_TdCheckpointLoaded") || Event.IsA("SeqEvt_TdCheckpointActivated"))
				{
					Event.CheckActivate(NewPlayer, NewPlayer.Pawn, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
				}			
			}		
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
		PostLogin = null;
	
	}
	public TdSPStoryGame()
	{
		// Object Offset:0x0065E80E
		ActiveBossFight = -1;
		bAllowStreamingVolumes = true;
	}
}
}