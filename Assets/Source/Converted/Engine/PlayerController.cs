// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerController : Controller/*
		native
		nativereplication
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public const double MAXPOSITIONERRORSQUARED = 3.0;
	public const double MAXNEARZEROVELOCITYSQUARED = 9.0;
	public const double MAXVEHICLEPOSITIONERRORSQUARED = 900.0;
	public const double CLIENTADJUSTUPDATECOST = 180.0;
	public const double MAXCLIENTUPDATEINTERVAL = 0.25;
	
	public enum EInputTypes 
	{
		IT_XAxis,
		IT_YAxis,
		IT_MAX
	};
	
	public enum EInputMatchAction 
	{
		IMA_GreaterThan,
		IMA_LessThan,
		IMA_MAX
	};
	
	public enum EProgressMessageType 
	{
		PMT_Clear,
		PMT_Information,
		PMT_AdminMessage,
		PMT_DownloadProgress,
		PMT_RedrawDownloadProgress,
		PMT_ConnectionFailure,
		PMT_MAX
	};
	
	public partial struct /*native */ClientAdjustment
	{
		public float TimeStamp;
		public Actor.EPhysics newPhysics;
		public Object.Vector NewLoc;
		public Object.Vector NewVel;
		public Actor NewBase;
		public Object.Vector NewFloor;
		public byte bAckGoodMove;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0026A578
	//		TimeStamp = 0.0f;
	//		newPhysics = Actor.EPhysics.PHYS_None;
	//		NewLoc = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		NewVel = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		NewBase = default;
	//		NewFloor = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		bAckGoodMove = 0;
	//	}
	};
	
	public partial struct /*native */InputEntry
	{
		public PlayerController.EInputTypes Type;
		public float Value;
		public float TimeDelta;
		public PlayerController.EInputMatchAction Action;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0026A7BD
	//		Type = PlayerController.EInputTypes.IT_XAxis;
	//		Value = 0.0f;
	//		TimeDelta = 0.0f;
	//		Action = PlayerController.EInputMatchAction.IMA_GreaterThan;
	//	}
	};
	
	public partial struct /*native */InputMatchRequest
	{
		public array<PlayerController.InputEntry> Inputs;
		public Actor MatchActor;
		public name MatchFuncName;
		public name FailedFuncName;
		public name RequestName;
		public /*transient */int MatchIdx;
		public /*transient */float LastMatchTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0026A9D9
	//		Inputs = default;
	//		MatchActor = default;
	//		MatchFuncName = (name)"None";
	//		FailedFuncName = (name)"None";
	//		RequestName = (name)"None";
	//		MatchIdx = 0;
	//		LastMatchTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */DebugTextInfo
	{
		public Actor SrcActor;
		public Object.Vector SrcActorOffset;
		public Object.Vector SrcActorDesiredOffset;
		public string DebugText;
		public /*transient */float TimeRemaining;
		public float Duration;
		public Object.Color TextColor;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0026AC25
	//		SrcActor = default;
	//		SrcActorOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		SrcActorDesiredOffset = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		DebugText = "";
	//		TimeRemaining = 0.0f;
	//		Duration = 0.0f;
	//		TextColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//	}
	};
	
	public /*const */Player Player;
	public Camera PlayerCamera;
	public /*const */Core.ClassT<Camera> CameraClass;
	public DebugCameraController DebugCameraControllerRef;
	public Core.ClassT<DebugCameraController> DebugCameraControllerClass;
	public /*const */Core.ClassT<PlayerOwnerDataStore> PlayerOwnerDataStoreClass;
	public /*protected */PlayerOwnerDataStore CurrentPlayerData;
	public /*protected */UIDataStore_PlayerSettings CurrentPlayerSettings;
	public bool bFrozen;
	public bool bPressedJump;
	public bool bDoubleJump;
	public bool bUpdatePosition;
	public bool bUpdating;
	public /*globalconfig */bool bNeverSwitchOnPickup;
	public bool bCheatFlying;
	public bool bCameraPositionLocked;
	public bool bShortConnectTimeOut;
	public /*const */bool bPendingDestroy;
	public bool bWasSpeedHack;
	public /*const */bool bWasSaturated;
	public /*globalconfig */bool bDynamicNetSpeed;
	public /*globalconfig */bool bAimingHelp;
	public bool bCinematicMode;
	public bool bCinemaDisableInputMove;
	public bool bCinemaDisableInputLook;
	public bool bReplicateAllPawns;
	public bool bIsUsingStreamingVolumes;
	public bool bIsExternalUIOpen;
	public bool bIsControllerConnected;
	public bool bCheckSoundOcclusion;
	public /*globalconfig */bool bLogHearSoundOverflow;
	public /*globalconfig */bool bCheckRelevancyThroughPortals;
	public bool bReceivedUniqueId;
	public /*transient */bool bCanSeeLOI;
	public float MaxResponseTime;
	public float WaitDelay;
	public Pawn AcknowledgedPawn;
	public Actor.EDoubleClickDir DoubleClickDir;
	public byte bIgnoreMoveInput;
	public byte bIgnoreLookInput;
	public /*input */byte bRun;
	public /*input */byte bDuck;
	public /*duplicatetransient const */byte NetPlayerIndex;
	public /*const */Actor ViewTarget;
	public PlayerReplicationInfo RealViewTarget;
	public float FOVAngle;
	public float DesiredFOV;
	public float DefaultFOV;
	public /*const */float LODDistanceFactor;
	public Object.Rotator TargetViewRotation;
	public float TargetEyeHeight;
	public Object.Rotator BlendedTargetViewRotation;
	public HUD myHUD;
	public Core.ClassT<SavedMove> SavedMoveClass;
	public SavedMove SavedMoves;
	public SavedMove FreeMoves;
	public SavedMove PendingMove;
	public Object.Vector LastAckedAccel;
	public float CurrentTimeStamp;
	public float LastUpdateTime;
	public float ServerTimeStamp;
	public float TimeMargin;
	public float ClientUpdateTime;
	public float MaxTimeMargin;
	public float LastActiveTime;
	public int ClientCap;
	public /*globalconfig */float DynamicPingThreshold;
	public float LastPingUpdate;
	public float OldPing;
	public float LastSpeedHackLog;
	public PlayerController.ClientAdjustment PendingAdjustment;
	public StaticArray<string, string>/*[2]*/ ProgressMessage;
	public float ProgressTimeOut;
	public /*const localized */string QuickSaveString;
	public /*const localized */string NoPauseMessage;
	public /*const localized */string ViewingFrom;
	public /*const localized */string OwnCamera;
	public int GroundPitch;
	public Object.Vector OldFloor;
	public /*transient */CheatManager CheatManager;
	public Core.ClassT<CheatManager> CheatClass;
	public/*()*/ /*editinline transient */PlayerInput PlayerInput;
	public Core.ClassT<PlayerInput> InputClass;
	public /*const */Object.Vector FailedPathStart;
	public /*export editinline */CylinderComponent CylinderComponent;
	public /*config */string ForceFeedbackManagerClassName;
	public /*transient */ForceFeedbackManager ForceFeedbackManager;
	public /*transient */array<Interaction> Interactions;
	public array<OnlineSubsystem.UniqueNetId> VoiceMuteList;
	public array<OnlineSubsystem.UniqueNetId> GameplayVoiceMuteList;
	public array<OnlineSubsystem.UniqueNetId> VoicePacketFilter;
	public OnlineSubsystem OnlineSub;
	public OnlineVoiceInterface VoiceInterface;
	public UIDataStore_OnlinePlayerData OnlinePlayerData;
	public /*config */float InteractDistance;
	public array<PlayerController.InputMatchRequest> InputRequests;
	public float LastBroadcastTime;
	public StaticArray<string, string, string, string>/*[4]*/ LastBroadcastString;
	public array<name> PendingMapChangeLevelNames;
	public CoverReplicator MyCoverReplicator;
	public /*private */array<PlayerController.DebugTextInfo> DebugTextList;
	public float SpectatorCameraSpeed;
	public /*duplicatetransient const */NetConnection PendingSwapConnection;
	public float MinRespawnDelay;
	public /*globalconfig */int MaxConcurrentHearSounds;
	public /*export editinline */array</*export editinline */AudioComponent> HearSoundActiveComponents;
	public /*export editinline */array</*export editinline */AudioComponent> HearSoundPoolComponents;
	public array<Actor> HiddenActors;
	public /*delegate*/PlayerController.CanUnpause __CanUnpause__Delegate;
	
	//replication
	//{
	//	 if(((bNetOwner && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && ViewTarget != Pawn) && ((ViewTarget) as Pawn) != default)
	//		TargetEyeHeight, TargetViewRotation;
	//}
	
	public virtual /*reliable client simulated function */void ClientDrawCoordinateSystem(Object.Vector AxisLoc, Object.Rotator AxisRot, float Scale, /*optional */bool bPersistentLines = default)
	{
		DrawDebugCoordinateSystem(AxisLoc, AxisRot, Scale, bPersistentLines);
	}
	
	// Export UPlayerController::execSetNetSpeed(FFrame&, void* const)
	public virtual /*native final function */void SetNetSpeed(int NewSpeed)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execGetPlayerNetworkAddress(FFrame&, void* const)
	public virtual /*native final function */string GetPlayerNetworkAddress()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execGetServerNetworkAddress(FFrame&, void* const)
	public virtual /*native final function */string GetServerNetworkAddress()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execConsoleCommand(FFrame&, void* const)
	public override /*native function */string ConsoleCommand(string Command, /*optional */bool bWriteToLog = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execClientTravel(FFrame&, void* const)
	public virtual /*reliable client native simulated event */void ClientTravel(string URL, Actor.ETravelType TravelType, /*optional */bool bSeamless = default, /*init optional */Object.Guid MapPackageGuid = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execUpdateURL(FFrame&, void* const)
	public virtual /*native(546) final function */void UpdateURL(string NewOption, string NewValue, bool bSave1Default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execGetDefaultURL(FFrame&, void* const)
	public virtual /*native final function */string GetDefaultURL(string Option)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execCopyToClipboard(FFrame&, void* const)
	public virtual /*native function */void CopyToClipboard(string Text)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execPasteFromClipboard(FFrame&, void* const)
	public virtual /*native function */string PasteFromClipboard()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execSetAllowMatureLanguage(FFrame&, void* const)
	public virtual /*native function */void SetAllowMatureLanguage(bool bAllowMatureLanguge)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execSetAudioGroupVolume(FFrame&, void* const)
	public virtual /*native function */void SetAudioGroupVolume(name GroupName, float Volume)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execClientConvolve(FFrame&, void* const)
	public virtual /*private reliable client native final simulated event */void ClientConvolve(string C, int H)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execServerProcessConvolve(FFrame&, void* const)
	public virtual /*private reliable server native final event */void ServerProcessConvolve(string C, int H)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execCheckSpeedHack(FFrame&, void* const)
	public virtual /*native final function */bool CheckSpeedHack(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execFindStairRotation(FFrame&, void* const)
	public virtual /*native(524) final function */int FindStairRotation(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execCleanUpAudioComponents(FFrame&, void* const)
	public virtual /*native function */void CleanUpAudioComponents()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */void OnLoadLevels(/*optional */bool bUnload = default)
	{
		bUnload = false;
		if(bUnload)
		{
			ForceFeedbackManager.StopForceFeedbackWaveform(default(ForceFeedbackWaveform));
		}
	}
	
	public virtual /*function */void OnExternalUIChanged(bool bIsOpening)
	{
		bIsExternalUIOpen = bIsOpening;
		SetPause(bIsOpening, CanUnpauseExternalUI);
	}
	
	public virtual /*function */bool CanUnpauseExternalUI()
	{
		return bIsExternalUIOpen == false;
	}
	
	public override FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? PlayerController_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public override FellOutOfWorld_del global_FellOutOfWorld => PlayerController_FellOutOfWorld;
	public /*simulated event */void PlayerController_FellOutOfWorld(Core.ClassT<DamageType> dmgType)
	{
	
	}
	
	public virtual /*function */void OnControllerChanged(int ControllerId, bool bIsConnected)
	{
		/*local */LocalPlayer LocPlayer = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		if((WorldInfo.IsConsoleBuild(((WorldInfo.EConsoleType)default(WorldInfo.EConsoleType))) && LocPlayer != default) && LocPlayer.ControllerId == ControllerId)
		{
			bIsControllerConnected = bIsConnected;
		}
	}
	
	public virtual /*function */bool CanUnpauseControllerConnected()
	{
		return bIsControllerConnected;
	}
	
	public virtual /*function */CoverReplicator SpawnCoverReplicator()
	{
		if(((MyCoverReplicator == default) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && ((Player) as LocalPlayer) == default)
		{
			MyCoverReplicator = Spawn(ClassT<CoverReplicator>(), this, default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
			MyCoverReplicator.ReplicateInitialCoverInfo();
		}
		return MyCoverReplicator;
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		ResetCameraMode();
		MaxTimeMargin = ClassT<GameInfo>().DefaultAs<GameInfo>().MaxTimeMargin;
		MaxResponseTime = DefaultAs<PlayerController>().MaxResponseTime * WorldInfo.TimeDilation;
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))
		{
			SpawnDefaultHUD();		
		}
		else
		{
			AddCheats();
		}
		SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
		LastActiveTime = WorldInfo.TimeSeconds;
		OnlineSub = GameEngine.GetOnlineSubsystem();
	}
	
	public virtual /*simulated event */void ReceivedPlayer()
	{
		RegisterPlayerDataStores();
	}
	
	public virtual /*event */void PreRender(Canvas Canvas)
	{
	
	}
	
	public virtual /*function */void ResetTimeMargin()
	{
		TimeMargin = -0.10f;
		MaxTimeMargin = ClassT<GameInfo>().DefaultAs<GameInfo>().MaxTimeMargin;
	}
	
	public virtual /*reliable server function */void ServerShortTimeout()
	{
		/*local */Actor A = default;
	
		if(!bShortConnectTimeOut)
		{
			bShortConnectTimeOut = true;
			ResetTimeMargin();
			if(WorldInfo.Pauser != default)
			{
				
				// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
				using var e50 = AllActors(ClassT<Actor>()).GetEnumerator();
				while(e50.MoveNext() && (A = (Actor)e50.Current) == A)
				{
					if(!A.bOnlyRelevantToOwner)
					{
						A.bForceNetUpdate = true;
					}				
				}						
			}
			else
			{
				if(WorldInfo.Game.NumPlayers < 8)
				{
					
					// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
					using var e142 = AllActors(ClassT<Actor>()).GetEnumerator();
					while(e142.MoveNext() && (A = (Actor)e142.Current) == A)
					{
						if((A.NetUpdateFrequency < ((float)(1))) && !A.bOnlyRelevantToOwner)
						{
							A.SetNetUpdateTime(FMin(A.NetUpdateTime, WorldInfo.TimeSeconds + (0.20f * FRand())));
						}					
					}								
				}
				else
				{
					
					// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
					using var e268 = AllActors(ClassT<Actor>()).GetEnumerator();
					while(e268.MoveNext() && (A = (Actor)e268.Current) == A)
					{
						if((A.NetUpdateFrequency < ((float)(1))) && !A.bOnlyRelevantToOwner)
						{
							A.SetNetUpdateTime(FMin(A.NetUpdateTime, WorldInfo.TimeSeconds + (0.50f * FRand())));
						}					
					}				
				}
			}
		}
	}
	
	public override /*function */void ServerGivePawn()
	{
		GivePawn(Pawn);
	}
	
	public virtual /*event */void KickWarning()
	{
		ReceiveLocalizedMessage(ClassT<GameMessage>(), 15, default(PlayerReplicationInfo), default(PlayerReplicationInfo), default(Object));
	}
	
	public virtual /*function */void AddCheats()
	{
		if(((CheatManager == default) && WorldInfo.Game != default) && WorldInfo.Game.AllowCheats(this))
		{
			CheatManager =  CheatClass.New(this);
		}
	}
	
	public virtual /*exec function */void EnableCheats()
	{
		AddCheats();
	}
	
	public virtual /*function */void SpawnDefaultHUD()
	{
		if(((Player) as LocalPlayer) == default)
		{
			return;
		}
		myHUD = Spawn(ClassT<HUD>(), this, default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? PlayerController_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => PlayerController_Reset;
	public /*function */void PlayerController_Reset()
	{
		/*local */Vehicle DrivenVehicle = default;
	
		DrivenVehicle = ((Pawn) as Vehicle);
		if(DrivenVehicle != default)
		{
			DrivenVehicle.DriverLeave(true);
		}
		if(Pawn != default)
		{
			PawnDied(Pawn);
			UnPossess();
		}
		/*Transformed 'base.' to specific call*/Controller_Reset();
		SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
		ResetCameraMode();
		WaitDelay = WorldInfo.TimeSeconds + ((float)(2));
		FixFOV();
		if(PlayerReplicationInfo.bOnlySpectator)
		{
			GotoState("Spectating", default(name), default(bool), default(bool));		
		}
		else
		{
			GotoState("PlayerWaiting", default(name), default(bool), default(bool));
		}
	}
	
	public virtual /*reliable client simulated function */void ClientReset()
	{
		ResetCameraMode();
		SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
		GotoState(((PlayerReplicationInfo.bOnlySpectator) ? "Spectating" : "PlayerWaiting"), default(name), default(bool), default(bool));
	}
	
	public virtual /*function */void CleanOutSavedMoves()
	{
		SavedMoves = default;
		PendingMove = default;
	}
	
	public virtual /*event */void InitInputSystem()
	{
		/*local */Core.ClassT<ForceFeedbackManager> FFManagerClass = default;
		/*local */int I = default;
		/*local */Sequence GameSeq = default;
		/*local */array<SequenceObject> AllInterpActions = default;
	
		if(PlayerInput == default)
		{
			assert(InputClass != default);
			PlayerInput =  InputClass.New(this);
		}
		if(Interactions.Find(PlayerInput) == -1)
		{
			Interactions[Interactions.Length] = PlayerInput;
		}
		if(ForceFeedbackManagerClassName != "")
		{
			FFManagerClass = ((DynamicLoadObject(ForceFeedbackManagerClassName, ClassT<Class>(), default(bool))) as ClassT<ForceFeedbackManager>);
			if(FFManagerClass != default)
			{
				ForceFeedbackManager =  FFManagerClass.New(this);
			}
		}
		OnlineSub = GameEngine.GetOnlineSubsystem();
		if(OnlineSub != default)
		{
			VoiceInterface = OnlineSub.VoiceInterface;
			if(NotEqual_InterfaceInterface(OnlineSub.SystemInterface, (default(OnlineSystemInterface))))
			{
				OnlineSub.SystemInterface.AddExternalUIChangeDelegate(OnExternalUIChanged);
				OnlineSub.SystemInterface.AddControllerChangeDelegate(OnControllerChanged);
			}
			if((NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface)))) && ((Player) as LocalPlayer) != default)
			{
				OnlineSub.GameInterface.AddGameInviteAcceptedDelegate((byte)((byte)(((Player) as LocalPlayer).ControllerId)), OnGameInviteAccepted);
			}
		}
		GameSeq = WorldInfo.GetGameSequence();
		if(GameSeq != default)
		{
			GameSeq.FindSeqObjectsByClass(ClassT<SeqAct_Interp>(), true, ref/*probably?*/ AllInterpActions);
			I = 0;
			J0x1E8:{}
			if(I < AllInterpActions.Length)
			{
				((AllInterpActions[I]) as SeqAct_Interp).AddPlayerToDirectorTracks(this);
				++ I;
				goto J0x1E8;
			}
		}
		SetOnlyUseControllerTiltInput(false);
		SetUseTiltForwardAndBack(true);
		SetControllerTiltActive(false);
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		base.ReplicatedEvent(VarName);
		if(VarName == "PlayerReplicationInfo")
		{
			if(PlayerReplicationInfo != default)
			{
				InitUniquePlayerId();
			}
		}
	}
	
	public virtual /*event */void InitUniquePlayerId()
	{
		/*local */LocalPlayer LocPlayer = default;
		/*local */OnlineGameSettings GameSettings = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		if((((LocPlayer != default) && PlayerReplicationInfo != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.PlayerInterface, (default(OnlinePlayerInterface))))
		{
			OnlineSub.PlayerInterface.GetUniquePlayerId((byte)((byte)(LocPlayer.ControllerId)), ref/*probably?*/ PlayerReplicationInfo.UniqueId);
			if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))
			{
				if(NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
				{
					GameSettings = OnlineSub.GameInterface.GetGameSettings();
				}
				ServerSetUniquePlayerId(PlayerReplicationInfo.UniqueId, (GameSettings != default) && GameSettings.bWasFromInvite);
			}
		}
	}
	
	public virtual /*reliable server function */void ServerSetUniquePlayerId(OnlineSubsystem.UniqueNetId UniqueId, bool bWasInvited)
	{
		/*local */OnlineSubsystem.UniqueNetId ZeroId = default;
	
		if(!bPendingDestroy && !bReceivedUniqueId)
		{
			if(WorldInfo.Game.AccessControl.IsIDBanned(ref/*probably?*/ UniqueId))
			{
				ClientWasKicked();
				Destroy();			
			}
			else
			{
				if(((WorldInfo.IsConsoleBuild(((WorldInfo.EConsoleType)default(WorldInfo.EConsoleType))) && WorldInfo.Game.GameSettings != default) && !WorldInfo.Game.GameSettings.bIsLanMatch) && UniqueId == ZeroId)
				{
					ClientWasKicked();
					Destroy();				
				}
				else
				{
					PlayerReplicationInfo.UniqueId = UniqueId;
					if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
					{
						OnlineSub.GameInterface.RegisterPlayer(PlayerReplicationInfo.UniqueId, bWasInvited);
					}
					if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Client/*3*/))
					{
						WorldInfo.Game.UpdateGameplayMuteList(this);
						WorldInfo.Game.RecalculateSkillRating();
					}
					bReceivedUniqueId = true;
				}
			}
		}
	}
	
	public virtual /*reliable client simulated function */void ClientInitializeDataStores()
	{
		RegisterPlayerDataStores();
	}
	
	public virtual /*simulated function */void RegisterPlayerDataStores()
	{
		/*local */LocalPlayer LP = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */Core.ClassT<UIDataStore_PlayerSettings> PlayerSettingsDataStoreClass = default;
		/*local */Core.ClassT<UIDataStore_OnlinePlayerData> PlayerDataStoreClass = default;
	
		LP = ((Player) as LocalPlayer);
		if(LP != default)
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				CurrentPlayerData = ((DataStoreManager.FindDataStore("PlayerOwner", LP)) as PlayerOwnerDataStore);
				if(CurrentPlayerData == default)
				{
					CurrentPlayerData = DataStoreManager.CreateDataStore(PlayerOwnerDataStoreClass);
					if(CurrentPlayerData != default)
					{
						if(DataStoreManager.RegisterDataStore(CurrentPlayerData, LP))
						{
							if(PlayerReplicationInfo != default)
							{
								PlayerReplicationInfo.BindPlayerOwnerDataProvider();
							}						
						}					
					}				
				}
				CurrentPlayerSettings = ((DataStoreManager.FindDataStore("PlayerSettings", LP)) as UIDataStore_PlayerSettings);
				if(CurrentPlayerSettings == default)
				{
					PlayerSettingsDataStoreClass = ((DataStoreManager.FindDataStoreClass(ClassT<UIDataStore_PlayerSettings>())) as ClassT<UIDataStore_PlayerSettings>);
					if(PlayerSettingsDataStoreClass != default)
					{
						CurrentPlayerSettings = DataStoreManager.CreateDataStore(PlayerSettingsDataStoreClass);
						if(CurrentPlayerSettings != default)
						{
							if(!DataStoreManager.RegisterDataStore(CurrentPlayerSettings, LP))
							{
							}						
						}					
					}				
				}
				OnlinePlayerData = ((DataStoreManager.FindDataStore("OnlinePlayerData", LP)) as UIDataStore_OnlinePlayerData);
				OnlineSub.PlayerInterface.AddReadProfileSettingsCompleteDelegate((byte)((byte)(OnlinePlayerData.Player.ControllerId)), OnProfileReadComplete);
				if(OnlinePlayerData == default)
				{
					PlayerDataStoreClass = ((DataStoreManager.FindDataStoreClass(ClassT<UIDataStore_OnlinePlayerData>())) as ClassT<UIDataStore_OnlinePlayerData>);
					if(PlayerDataStoreClass != default)
					{
						OnlinePlayerData = DataStoreManager.CreateDataStore(PlayerDataStoreClass);
						if(OnlinePlayerData != default)
						{
							if(!DataStoreManager.RegisterDataStore(OnlinePlayerData, LP))
							{
							}						
						}					
					}				
				}
			}
		}
	}
	
	public virtual /*simulated function */void UnregisterPlayerDataStores()
	{
		/*local */LocalPlayer LP = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_OnlinePlayerData PlayerDataStore = default;
	
		LP = ((Player) as LocalPlayer);
		if(LP != default)
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				if(CurrentPlayerData != default)
				{
					if(!DataStoreManager.UnregisterDataStore(CurrentPlayerData))
					{
					}
					CurrentPlayerData = default;				
				}
				if(CurrentPlayerSettings != default)
				{
					if(!DataStoreManager.UnregisterDataStore(CurrentPlayerSettings))
					{
					}
					CurrentPlayerSettings = default;				
				}
				OnlinePlayerData = default;
				PlayerDataStore = ((DataStoreManager.FindDataStore("OnlinePlayerData", LP)) as UIDataStore_OnlinePlayerData);
				if(PlayerDataStore != default)
				{
					if(!DataStoreManager.UnregisterDataStore(PlayerDataStore))
					{
					}				
				}			
			}
		}
	}
	
	public virtual /*event */void OnProfileReadComplete(bool bSucceeded)
	{
	
	}
	
	public virtual /*simulated function */void SetPlayerDataProvider(PlayerDataProvider DataProvider)
	{
		if(CurrentPlayerData == default)
		{
			RegisterPlayerDataStores();
		}
		if(CurrentPlayerData != default)
		{
			if(DataProvider != default)
			{
				CurrentPlayerData.SetPlayerDataProvider(DataProvider);			
			}		
		}
	}
	
	public virtual /*final function */void SetRumbleScale(float ScaleBy)
	{
		if(ForceFeedbackManager != default)
		{
			ForceFeedbackManager.ScaleAllWaveformsBy = ScaleBy;
		}
	}
	
	public virtual /*final function */float GetRumbleScale()
	{
		/*local */float retval = default;
	
		retval = 1.0f;
		if(ForceFeedbackManager != default)
		{
			retval = ForceFeedbackManager.ScaleAllWaveformsBy;
		}
		return retval;
	}
	
	// Export UPlayerController::execIsControllerTiltActive(FFrame&, void* const)
	public virtual /*native simulated function */bool IsControllerTiltActive()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execSetControllerTiltDesiredIfAvailable(FFrame&, void* const)
	public virtual /*native simulated function */void SetControllerTiltDesiredIfAvailable(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execSetControllerTiltActive(FFrame&, void* const)
	public virtual /*native simulated function */void SetControllerTiltActive(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execSetOnlyUseControllerTiltInput(FFrame&, void* const)
	public virtual /*native simulated function */void SetOnlyUseControllerTiltInput(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execSetUseTiltForwardAndBack(FFrame&, void* const)
	public virtual /*native simulated function */void SetUseTiltForwardAndBack(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execIsKeyboardAvailable(FFrame&, void* const)
	public virtual /*native simulated function */bool IsKeyboardAvailable()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execIsMouseAvailable(FFrame&, void* const)
	public virtual /*native simulated function */bool IsMouseAvailable()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void ClientGotoState_del(name NewState, /*optional */name NewLabel = default);
	public virtual ClientGotoState_del ClientGotoState { get => bfield_ClientGotoState ?? PlayerController_ClientGotoState; set => bfield_ClientGotoState = value; } ClientGotoState_del bfield_ClientGotoState;
	public virtual ClientGotoState_del global_ClientGotoState => PlayerController_ClientGotoState;
	public /*reliable client simulated function */void PlayerController_ClientGotoState(name NewState, /*optional */name NewLabel = default)
	{
		if(((NewLabel == "Begin") || NewLabel == "None") && !IsInState(NewState, default(bool)))
		{
			GotoState(NewState, default(name), default(bool), default(bool));		
		}
		else
		{
			GotoState(NewState, NewLabel, default(bool), default(bool));
		}
	}
	
	public virtual /*reliable server function */void AskForPawn()
	{
		if(GamePlayEndedState())
		{
			ClientGotoState(GetStateName(), "Begin");		
		}
		else
		{
			if(Pawn != default)
			{
				GivePawn(Pawn);			
			}
			else
			{
				bFrozen = false;
				ServerRestartPlayer();
			}
		}
	}
	
	public virtual /*reliable client simulated function */void GivePawn(Pawn NewPawn)
	{
		if(NewPawn == default)
		{
			return;
		}
		Pawn = NewPawn;
		NewPawn.Controller = this;
		ClientRestart(Pawn);
	}
	
	public override Possess_del Possess { get => bfield_Possess ?? PlayerController_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public override Possess_del global_Possess => PlayerController_Possess;
	public /*event */void PlayerController_Possess(Pawn aPawn, bool bVehicleTransition)
	{
		/*local */Actor A = default;
		/*local */int I = default;
		/*local */SeqEvent_Touch TouchEvent = default;
	
		if(!PlayerReplicationInfo.bOnlySpectator)
		{
			if(aPawn.Controller != default)
			{
				aPawn.Controller.UnPossess();
			}
			aPawn.PossessedBy(this, bVehicleTransition);
			Pawn = aPawn;
			Pawn.bStasis = false;
			ResetTimeMargin();
			UpdateSex();
			Restart(bVehicleTransition);
			
			// foreach Pawn.TouchingActors(ClassT<Actor>(), ref/*probably?*/ A)
			using var e164 = Pawn.TouchingActors(ClassT<Actor>()).GetEnumerator();
			while(e164.MoveNext() && (A = (Actor)e164.Current) == A)
			{
				I = 0;
				J0xC5:{}
				if(I < A.GeneratedEvents.Length)
				{
					TouchEvent = ((A.GeneratedEvents[I]) as SeqEvent_Touch);
					if((TouchEvent != default) && TouchEvent.bPlayerOnly)
					{
						TouchEvent.CheckTouchActivate(A, Pawn, default(bool));
					}
					++ I;
					goto J0xC5;
				}			
			}		
		}
	}
	
	public virtual /*function */void AcknowledgePossession(Pawn P)
	{
		if(((Player) as LocalPlayer) != default)
		{
			AcknowledgedPawn = P;
			if(P != default)
			{
				P.SetBaseEyeheight();
				P.EyeHeight = P.BaseEyeHeight;
			}
			ServerAcknowledgePossession(P);
		}
	}
	
	public virtual /*reliable server function */void ServerAcknowledgePossession(Pawn P)
	{
		ResetTimeMargin();
		AcknowledgedPawn = P;
	}
	
	public override /*event */void UnPossess()
	{
		if(Pawn != default)
		{
			SetLocation(Pawn.Location);
			Pawn.RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy/*1*/;
			Pawn.UnPossessed();
			CleanOutSavedMoves();
			if((GetViewTarget()) == Pawn)
			{
				SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
			}
		}
		Pawn = default;
	}
	
	public override PawnDied_del PawnDied { get => bfield_PawnDied ?? PlayerController_PawnDied; set => bfield_PawnDied = value; } PawnDied_del bfield_PawnDied;
	public override PawnDied_del global_PawnDied => PlayerController_PawnDied;
	public /*function */void PlayerController_PawnDied(Pawn P)
	{
		if(P != Pawn)
		{
			return;
		}
		if(Pawn != default)
		{
			Pawn.RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy/*1*/;
		}
		/*Transformed 'base.' to specific call*/Controller_PawnDied(P);
	}
	
	public virtual /*reliable client simulated function */void ClientSetHUD(Core.ClassT<HUD> newHUDType, Core.ClassT<ScoreBoard> newScoringType)
	{
		if(myHUD != default)
		{
			myHUD.Destroy();
		}
		if(newHUDType == default)
		{
			myHUD = default;		
		}
		else
		{
			myHUD = Spawn(newHUDType, this, default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
			if(myHUD != default)
			{
				myHUD.SpawnScoreBoard(newScoringType);
			}
		}
	}
	
	public override /*function */void HandlePickup(Inventory Inv)
	{
		ReceiveLocalizedMessage(Inv.MessageClass, default(int), default(PlayerReplicationInfo), default(PlayerReplicationInfo), Inv.Class);
	}
	
	public override /*function */void CleanupPRI()
	{
		WorldInfo.Game.AddInactivePRI(PlayerReplicationInfo, this);
		PlayerReplicationInfo = default;
	}
	
	public virtual /*reliable client simulated event */void ReceiveLocalizedMessage(Core.ClassT<LocalMessage> Message, /*optional */int Switch = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) || WorldInfo.GRI == default)
		{
			return;
		}
		Message.Static.ClientReceive(this, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
	}
	
	public virtual /*unreliable client simulated event */void ClientPlaySound(SoundCue ASound)
	{
		ClientHearSound(ASound, this, Location, false, false);
	}
	
	// Export UPlayerController::execHearSoundFinished(FFrame&, void* const)
	public virtual /*native final simulated function */void HearSoundFinished(AudioComponent AC)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execGetPooledAudioComponent(FFrame&, void* const)
	public virtual /*native function */AudioComponent GetPooledAudioComponent(SoundCue ASound, Actor SourceActor, bool bStopWhenOwnerDestroyed, /*optional */bool bUseLocation = default, /*optional */Object.Vector SourceLocation = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*unreliable client simulated event */void ClientHearSound(SoundCue ASound, Actor SourceActor, Object.Vector SourceLocation, bool bStopWhenOwnerDestroyed, /*optional */bool bIsOccluded = default)
	{
		/*local *//*editinline */AudioComponent AC = default;
	
		if(SourceActor == default)
		{
			AC = GetPooledAudioComponent(ASound, SourceActor, bStopWhenOwnerDestroyed, true, SourceLocation);
			if(AC == default)
			{
				return;
			}
			AC.bUseOwnerLocation = false;
			AC.Location = SourceLocation;		
		}
		else
		{
			if((SourceActor == (GetViewTarget())) || SourceActor == this)
			{
				AC = GetPooledAudioComponent(ASound, default(Actor), bStopWhenOwnerDestroyed, default(bool), default(Object.Vector));
				if(AC == default)
				{
					return;
				}
				AC.bAllowSpatialization = false;			
			}
			else
			{
				AC = GetPooledAudioComponent(ASound, SourceActor, bStopWhenOwnerDestroyed, default(bool), default(Object.Vector));
				if(AC == default)
				{
					return;
				}
				if(!IsZero(SourceLocation) && SourceLocation != SourceActor.Location)
				{
					AC.bUseOwnerLocation = false;
					AC.Location = SourceLocation;
				}
			}
		}
		if(bIsOccluded)
		{
			AC.VolumeMultiplier *= 0.50f;
		}
		AC.Play();
	}
	
	public virtual /*reliable client simulated event */void Kismet_ClientPlaySound(SoundCue ASound, Actor SourceActor, float VolumeMultiplier, float PitchMultiplier, float FadeInTime, bool bSuppressSubtitles, bool bSuppressSpatialization)
	{
		/*local *//*editinline */AudioComponent AC = default;
	
		if(SourceActor != default)
		{
			if((ASound.FaceFXAnimName != "") && SourceActor.PlayActorFaceFXAnim(ASound.FaceFXAnimSetRef, ASound.FaceFXGroupName, ASound.FaceFXAnimName))
			{			
			}
			else
			{
				AC = SourceActor.CreateAudioComponent(ASound, false, true, default(bool), default(Object.Vector), default(bool));
				if(AC != default)
				{
					AC.VolumeMultiplier = VolumeMultiplier;
					AC.PitchMultiplier = PitchMultiplier;
					AC.bAutoDestroy = true;
					AC.SubtitlePriority = 10000.0f;
					AC.bSuppressSubtitles = bSuppressSubtitles;
					AC.FadeIn(FadeInTime, 1.0f);
					if(bSuppressSpatialization)
					{
						AC.bAllowSpatialization = false;
					}
				}
			}
		}
	}
	
	public virtual /*reliable client simulated event */void Kismet_ClientStopSound(SoundCue ASound, Actor SourceActor, float FadeOutTime)
	{
		/*local *//*editinline */AudioComponent AC = default, CheckAC = default;
	
		if(SourceActor == default)
		{
			SourceActor = WorldInfo;
		}
		
		// foreach SourceActor.AllOwnedComponents(ClassT<AudioComponent>(), ref/*probably?*/ CheckAC)
		using var e22 = SourceActor.AllOwnedComponents(ClassT<AudioComponent>()).GetEnumerator();
		while(e22.MoveNext() && (CheckAC = (AudioComponent)e22.Current) == CheckAC)
		{
			if(CheckAC.SoundCue == ASound)
			{
				AC = CheckAC;
				break;
			}		
		}	
		if(AC != default)
		{
			AC.FadeOut(FadeOutTime, 0.0f);
		}
	}
	
	public virtual /*reliable client simulated function */void ClientPlayActorFaceFXAnim(Actor SourceActor, FaceFXAnimSet AnimSet, string GroupName, string SeqName)
	{
		if(SourceActor != default)
		{
			SourceActor.PlayActorFaceFXAnim(AnimSet, GroupName, SeqName);
		}
	}
	
	public virtual /*reliable client simulated event */void ClientMessage(/*coerce */string S, /*optional */name Type = default, /*optional */float MsgLifeTime = default)
	{
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) || WorldInfo.GRI == default)
		{
			return;
		}
		if(Type == "None")
		{
			Type = "Event";
		}
		TeamMessage(PlayerReplicationInfo, S, Type, MsgLifeTime);
	}
	
	public virtual /*reliable client simulated event */void TeamMessage(PlayerReplicationInfo PRI, /*coerce */string S, name Type, /*optional */float MsgLifeTime = default)
	{
		/*local */bool bIsUserCreated = default;
	
		if(myHUD != default)
		{
			myHUD.Message(PRI, S, Type, MsgLifeTime);
		}
		if(((Type == "Say") || Type == "TeamSay") && PRI != default)
		{
			S = (PRI.PlayerName + ": ") + S;
			bIsUserCreated = true;
		}
		if(Player != default)
		{
			if(!bIsUserCreated || bIsUserCreated && CanViewUserCreatedContent())
			{
				((Player) as LocalPlayer).ViewportClient.ViewportConsole.OutputText(S);
			}
		}
	}
	
	public virtual /*function */void PlayBeepSound()
	{
	
	}
	
	public virtual /*event */void ClearOnlineDelegates()
	{
		/*local */LocalPlayer LP = default;
	
		LP = ((Player) as LocalPlayer);
		if((((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/)) || LP != default)
		{
			if(OnlineSub != default)
			{
				if(NotEqual_InterfaceInterface(OnlineSub.SystemInterface, (default(OnlineSystemInterface))))
				{
					OnlineSub.SystemInterface.ClearExternalUIChangeDelegate(OnExternalUIChanged);
					OnlineSub.SystemInterface.ClearControllerChangeDelegate(OnControllerChanged);
				}
				if((NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface)))) && LP != default)
				{
					OnlineSub.GameInterface.ClearGameInviteAcceptedDelegate((byte)((byte)(LP.ControllerId)), OnGameInviteAccepted);
				}
			}
		}
	}
	
	public override /*event */void Destroyed()
	{
		/*local */Vehicle DrivenVehicle = default;
		/*local */Pawn Driver = default;
	
		ClientPlayForceFeedbackWaveform(default(ForceFeedbackWaveform));
		if((((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/)) || ((Player) as LocalPlayer) != default)
		{
			ClearOnlineDelegates();
		}
		if(Pawn != default)
		{
			DrivenVehicle = ((Pawn) as Vehicle);
			if(DrivenVehicle != default)
			{
				Driver = DrivenVehicle.Driver;
				DrivenVehicle.DriverLeave(true);
				if(Driver != default)
				{
					Driver.Health = 0;
					Driver.Died(this, ClassT<DmgType_Suicided>(), Driver.Location);
				}			
			}
			else
			{
				Pawn.Health = 0;
				Pawn.Died(this, ClassT<DmgType_Suicided>(), Pawn.Location);
			}
		}
		if(myHUD != default)
		{
			myHUD.Destroy();
		}
		if(PlayerCamera != default)
		{
			PlayerCamera.Destroy();
			PlayerCamera = default;
		}
		UnregisterPlayerDataStores();
		base.Destroyed();
	}
	
	public virtual /*function */void FixFOV()
	{
		FOVAngle = DefaultAs<PlayerController>().DefaultFOV;
		DesiredFOV = DefaultAs<PlayerController>().DefaultFOV;
		DefaultFOV = DefaultAs<PlayerController>().DefaultFOV;
	}
	
	public virtual /*function */void SetFOV(float NewFOV)
	{
		DesiredFOV = NewFOV;
		FOVAngle = NewFOV;
	}
	
	public virtual /*function */void ResetFOV()
	{
		DesiredFOV = DefaultFOV;
		FOVAngle = DefaultFOV;
	}
	
	public virtual /*exec function */void FOV(float F)
	{
		if(PlayerCamera != default)
		{
			PlayerCamera.SetFOV(F);
			return;
		}
		if(((F >= 80.0f) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) || PlayerReplicationInfo.bOnlySpectator)
		{
			DefaultFOV = FClamp(F, 80.0f, 100.0f);
			DesiredFOV = DefaultFOV;
		}
	}
	
	public virtual /*exec function */void Mutate(string MutateString)
	{
		ServerMutate(MutateString);
	}
	
	public virtual /*reliable server function */void ServerMutate(string MutateString)
	{
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))
		{
			return;
		}
		WorldInfo.Game.Mutate(MutateString, this);
	}
	
	public virtual /*function */bool AllowTextMessage(string msg)
	{
		/*local */int I = default;
	
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) || PlayerReplicationInfo.bAdmin)
		{
			return true;
		}
		if((WorldInfo.Pauser == default) && (WorldInfo.TimeSeconds - LastBroadcastTime) < ((float)(2)))
		{
			return false;
		}
		if((WorldInfo.TimeSeconds - LastBroadcastTime) < ((float)(5)))
		{
			msg = Left(msg, Clamp(Len(msg) - 4, 8, 64));
			I = 0;
			J0xAD:{}
			if(I < 4)
			{
				if(ApproximatelyEqual(LastBroadcastString[I], msg))
				{
					return false;
				}
				++ I;
				goto J0xAD;
			}
		}
		I = 3;
		J0xE2:{}
		if(I > 0)
		{
			LastBroadcastString[I] = LastBroadcastString[I - 1];
			-- I;
			goto J0xE2;
		}
		LastBroadcastTime = WorldInfo.TimeSeconds;
		return true;
	}
	
	public virtual /*exec function */void Say(string msg)
	{
		msg = Left(msg, 128);
		if(AllowTextMessage(msg))
		{
			ServerSay(msg);
		}
	}
	
	public virtual /*unreliable server function */void ServerSay(string msg)
	{
		/*local */PlayerController PC = default;
	
		if(PlayerReplicationInfo.bAdmin && Left(msg, 1) == "#")
		{
			msg = Right(msg, Len(msg) - 1);
			
			// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
			using var e60 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e60.MoveNext() && (PC = (PlayerController)e60.Current) == PC)
			{
				PC.ClearProgressMessages();
				PC.SetProgressTime(6.0f);
				PC.SetProgressMessage(PlayerController.EProgressMessageType.PMT_AdminMessage/*2*/, msg, default(string));			
			}		
			return;
		}
		WorldInfo.Game.Broadcast(this, msg, "Say");
	}
	
	public virtual /*exec function */void TeamSay(string msg)
	{
		msg = Left(msg, 128);
		if(AllowTextMessage(msg))
		{
			ServerTeamSay(msg);
		}
	}
	
	public virtual /*unreliable server function */void ServerTeamSay(string msg)
	{
		LastActiveTime = WorldInfo.TimeSeconds;
		if(!WorldInfo.GRI.GameClass.DefaultAs<GameInfo>().bTeamGame)
		{
			Say(msg);
			return;
		}
		WorldInfo.Game.BroadcastTeam(this, WorldInfo.Game.Static.ParseMessageString(this, msg), "TeamSay");
	}
	
	public virtual /*event */void PreClientTravel()
	{
	
	}
	
	public virtual /*exec function */void Camera(name NewMode)
	{
		ServerCamera(NewMode);
	}
	
	public virtual /*reliable server function */void ServerCamera(name NewMode)
	{
		if(NewMode == "1st")
		{
			NewMode = "FirstPerson";		
		}
		else
		{
			if(NewMode == "3rd")
			{
				NewMode = "ThirdPerson";
			}
		}
		SetCameraMode(NewMode);
	}
	
	public virtual /*reliable client simulated function */void ClientSetCameraMode(name NewCamMode)
	{
		if(PlayerCamera != default)
		{
			PlayerCamera.CameraStyle = NewCamMode;
		}
	}
	
	public virtual /*function */void SetCameraMode(name NewCamMode)
	{
		if(PlayerCamera != default)
		{
			PlayerCamera.CameraStyle = NewCamMode;
			if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
			{
				ClientSetCameraMode(NewCamMode);
			}
		}
	}
	
	public virtual /*event */void ResetCameraMode()
	{
		if(Pawn != default)
		{
			SetCameraMode(Pawn.GetDefaultCameraMode(this));		
		}
		else
		{
			SetCameraMode("FirstPerson");
		}
	}
	
	public virtual /*function */bool UsingFirstPersonCamera()
	{
		return ((PlayerCamera == default) || PlayerCamera.CameraStyle == "FirstPerson") && ((Player) as LocalPlayer) != default;
	}
	
	public virtual /*function */void ClientVoiceMessage(PlayerReplicationInfo Sender, PlayerReplicationInfo Recipient, name MessageType, byte messageID)
	{
	
	}
	
	public virtual /*function */void ForceDeathUpdate()
	{
		LastUpdateTime = WorldInfo.TimeSeconds - ((float)(10));
	}
	
	public virtual /*unreliable server function */void DualServerMove(float TimeStamp0, Object.Vector InAccel0, byte PendingFlags, int View0, float TimeStamp, Object.Vector InAccel, Object.Vector ClientLoc, byte NewFlags, byte ClientRoll, int View)
	{
		ServerMove(TimeStamp0, InAccel0, vect(1.0f, 2.0f, 3.0f), (byte)PendingFlags, (byte)ClientRoll, View0);
		ServerMove(TimeStamp, InAccel, ClientLoc, (byte)NewFlags, (byte)ClientRoll, View);
	}
	
	public virtual /*unreliable server function */void OldServerMove(float OldTimeStamp, byte OldAccelX, byte OldAccelY, byte OldAccelZ, byte OldMoveFlags)
	{
		/*local */Object.Vector Accel = default;
	
		if(AcknowledgedPawn != Pawn)
		{
			return;
		}
		if(CurrentTimeStamp < (OldTimeStamp - 0.0010f))
		{
			Accel.X = ((float)(OldAccelX));
			if(Accel.X > ((float)(127)))
			{
				Accel.X = -1.0f * (Accel.X - ((float)(128)));
			}
			Accel.Y = ((float)(OldAccelY));
			if(Accel.Y > ((float)(127)))
			{
				Accel.Y = -1.0f * (Accel.Y - ((float)(128)));
			}
			Accel.Z = ((float)(OldAccelZ));
			if(Accel.Z > ((float)(127)))
			{
				Accel.Z = -1.0f * (Accel.Z - ((float)(128)));
			}
			Accel *= ((float)(20));
			OldTimeStamp = FMin(OldTimeStamp, CurrentTimeStamp + MaxResponseTime);
			MoveAutonomous(OldTimeStamp - CurrentTimeStamp, (byte)OldMoveFlags, Accel, rot(0, 0, 0));
			CurrentTimeStamp = OldTimeStamp;
		}
	}
	
	public delegate void ServerMove_del(float TimeStamp, Object.Vector InAccel, Object.Vector ClientLoc, byte MoveFlags, byte ClientRoll, int View);
	public virtual ServerMove_del ServerMove { get => bfield_ServerMove ?? PlayerController_ServerMove; set => bfield_ServerMove = value; } ServerMove_del bfield_ServerMove;
	public virtual ServerMove_del global_ServerMove => PlayerController_ServerMove;
	public /*unreliable server function */void PlayerController_ServerMove(float TimeStamp, Object.Vector InAccel, Object.Vector ClientLoc, byte MoveFlags, byte ClientRoll, int View)
	{
		/*local */float DeltaTime = default, clientErr = default;
		/*local */Object.Rotator DeltaRot = default, Rot = default, ViewRot = default;
		/*local */Object.Vector Accel = default, LocDiff = default;
		/*local */int maxPitch = default, ViewPitch = default, ViewYaw = default;
	
		if(CurrentTimeStamp >= TimeStamp)
		{
			return;
		}
		if(AcknowledgedPawn != Pawn)
		{
			InAccel = vect(0.0f, 0.0f, 0.0f);
			GivePawn(Pawn);
		}
		ViewPitch = View & 65535;
		ViewYaw = /*>>*/ShiftR(View, 16);
		Accel = InAccel * 0.10f;
		DeltaTime = FMin(MaxResponseTime, TimeStamp - CurrentTimeStamp);
		if(Pawn == default)
		{
			bWasSpeedHack = false;
			ResetTimeMargin();		
		}
		else
		{
			if(!CheckSpeedHack(DeltaTime))
			{
				if(!bWasSpeedHack)
				{
					if((WorldInfo.TimeSeconds - LastSpeedHackLog) > ((float)(20)))
					{
						LastSpeedHackLog = WorldInfo.TimeSeconds;
					}
					ClientMessage("Speed Hack Detected!", "CriticalEvent", default(float));				
				}
				else
				{
					bWasSpeedHack = true;
				}
				DeltaTime = 0.0f;
				Pawn.Velocity = vect(0.0f, 0.0f, 0.0f);			
			}
			else
			{
				DeltaTime *= Pawn.CustomTimeDilation;
				bWasSpeedHack = false;
			}
		}
		CurrentTimeStamp = TimeStamp;
		ServerTimeStamp = WorldInfo.TimeSeconds;
		ViewRot.Pitch = ViewPitch;
		ViewRot.Yaw = ViewYaw;
		ViewRot.Roll = 0;
		if(InAccel != vect(0.0f, 0.0f, 0.0f))
		{
			LastActiveTime = WorldInfo.TimeSeconds;
		}
		SetRotation(ViewRot);
		if(AcknowledgedPawn != Pawn)
		{
			return;
		}
		if(Pawn != default)
		{
			Rot.Roll = 256 * ((int)ClientRoll);
			Rot.Yaw = ViewYaw;
			if((((int)Pawn.Physics) == ((int)Actor.EPhysics.PHYS_Swimming/*3*/)) || ((int)Pawn.Physics) == ((int)Actor.EPhysics.PHYS_Flying/*4*/))
			{
				maxPitch = 2;			
			}
			else
			{
				maxPitch = 0;
			}
			if((ViewPitch > (maxPitch * Pawn.MaxPitchLimit)) && ViewPitch < (65536 - (maxPitch * Pawn.MaxPitchLimit)))
			{
				if(ViewPitch < 32768)
				{
					Rot.Pitch = maxPitch * Pawn.MaxPitchLimit;				
				}
				else
				{
					Rot.Pitch = 65536 - (maxPitch * Pawn.MaxPitchLimit);
				}			
			}
			else
			{
				Rot.Pitch = ViewPitch;
			}
			DeltaRot = Rotation - Rot;
			Pawn.FaceRotation(Rot, DeltaTime);
		}
		if((WorldInfo.Pauser == default) && DeltaTime > ((float)(0)))
		{
			MoveAutonomous(DeltaTime, (byte)MoveFlags, Accel, DeltaRot);
		}
		if(ClientLoc == vect(1.0f, 2.0f, 3.0f))
		{
			return;		
		}
		else
		{
			if((WorldInfo.TimeSeconds - LastUpdateTime) < (180.0f / ((float)(Player.CurrentNetSpeed))))
			{
				return;
			}
		}
		if(Pawn == default)
		{
			LocDiff = Location - ClientLoc;		
		}
		else
		{
			if(Pawn.bForceRMVelocity)
			{
				LocDiff = vect(0.0f, 0.0f, 0.0f);			
			}
			else
			{
				LocDiff = Pawn.Location - ClientLoc;
			}
		}
		clientErr = Dot(LocDiff, LocDiff);
		if(clientErr > 3.0f)
		{
			if(Pawn == default)
			{
				PendingAdjustment.newPhysics = Physics;
				PendingAdjustment.NewLoc = Location;
				PendingAdjustment.NewVel = Velocity;			
			}
			else
			{
				PendingAdjustment.newPhysics = Pawn.Physics;
				PendingAdjustment.NewVel = Pawn.Velocity;
				PendingAdjustment.NewBase = Pawn.Base;
				if((((Pawn.Base) as InterpActor) != default) || ((Pawn.Base) as Vehicle) != default)
				{
					PendingAdjustment.NewLoc = Pawn.Location - Pawn.Base.Location;				
				}
				else
				{
					PendingAdjustment.NewLoc = Pawn.Location;
				}
				PendingAdjustment.NewFloor = Pawn.Floor;
			}
			LastUpdateTime = WorldInfo.TimeSeconds;
			PendingAdjustment.TimeStamp = TimeStamp;
			PendingAdjustment.bAckGoodMove = 0;		
		}
		else
		{
			PendingAdjustment.TimeStamp = TimeStamp;
			PendingAdjustment.bAckGoodMove = 1;
		}
	}
	
	public virtual /*event */void SendClientAdjustment()
	{
		if(AcknowledgedPawn != Pawn)
		{
			PendingAdjustment.TimeStamp = 0.0f;
			return;
		}
		if(((int)PendingAdjustment.bAckGoodMove) == ((int)1))
		{
			ClientAckGoodMove(PendingAdjustment.TimeStamp);		
		}
		else
		{
			if((Pawn == default) || ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_Spider/*8*/))
			{
				if(PendingAdjustment.NewVel == vect(0.0f, 0.0f, 0.0f))
				{
					if(((GetStateName() == "PlayerWalking") && Pawn != default) && ((int)Pawn.Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/))
					{
						VeryShortClientAdjustPosition(PendingAdjustment.TimeStamp, PendingAdjustment.NewLoc.X, PendingAdjustment.NewLoc.Y, PendingAdjustment.NewLoc.Z, PendingAdjustment.NewBase);					
					}
					else
					{
						ShortClientAdjustPosition(PendingAdjustment.TimeStamp, GetStateName(), ((Actor.EPhysics)PendingAdjustment.newPhysics), PendingAdjustment.NewLoc.X, PendingAdjustment.NewLoc.Y, PendingAdjustment.NewLoc.Z, PendingAdjustment.NewBase);
					}				
				}
				else
				{
					ClientAdjustPosition(PendingAdjustment.TimeStamp, GetStateName(), ((Actor.EPhysics)PendingAdjustment.newPhysics), PendingAdjustment.NewLoc.X, PendingAdjustment.NewLoc.Y, PendingAdjustment.NewLoc.Z, PendingAdjustment.NewVel.X, PendingAdjustment.NewVel.Y, PendingAdjustment.NewVel.Z, PendingAdjustment.NewBase);
				}			
			}
			else
			{
				LongClientAdjustPosition(PendingAdjustment.TimeStamp, GetStateName(), ((Actor.EPhysics)PendingAdjustment.newPhysics), PendingAdjustment.NewLoc.X, PendingAdjustment.NewLoc.Y, PendingAdjustment.NewLoc.Z, PendingAdjustment.NewVel.X, PendingAdjustment.NewVel.Y, PendingAdjustment.NewVel.Z, PendingAdjustment.NewBase, PendingAdjustment.NewFloor.X, PendingAdjustment.NewFloor.Y, PendingAdjustment.NewFloor.Z);
			}
		}
		PendingAdjustment.TimeStamp = 0.0f;
		PendingAdjustment.bAckGoodMove = 0;
	}
	
	public virtual /*unreliable server function */void ServerDrive(float InForward, float InStrafe, float aUp, bool InJump, int View)
	{
		/*local */Object.Rotator ViewRotation = default;
	
		ViewRotation.Pitch = View & 65535;
		ViewRotation.Yaw = /*>>*/ShiftR(View, 16);
		ViewRotation.Roll = 0;
		SetRotation(ViewRotation);
		ProcessDrive(InForward, InStrafe, aUp, InJump);
	}
	
	public delegate void ProcessDrive_del(float InForward, float InStrafe, float InUp, bool InJump);
	public virtual ProcessDrive_del ProcessDrive { get => bfield_ProcessDrive ?? PlayerController_ProcessDrive; set => bfield_ProcessDrive = value; } ProcessDrive_del bfield_ProcessDrive;
	public virtual ProcessDrive_del global_ProcessDrive => PlayerController_ProcessDrive;
	public /*function */void PlayerController_ProcessDrive(float InForward, float InStrafe, float InUp, bool InJump)
	{
		ClientGotoState(GetStateName(), "Begin");
	}
	
	public delegate void ProcessMove_del(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot);
	public virtual ProcessMove_del ProcessMove { get => bfield_ProcessMove ?? PlayerController_ProcessMove; set => bfield_ProcessMove = value; } ProcessMove_del bfield_ProcessMove;
	public virtual ProcessMove_del global_ProcessMove => PlayerController_ProcessMove;
	public /*function */void PlayerController_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)
	{
		if((Pawn != default) && Pawn.Acceleration != newAccel)
		{
			Pawn.Acceleration = newAccel;
		}
	}
	
	public virtual /*function */void MoveAutonomous(float DeltaTime, byte CompressedFlags, Object.Vector newAccel, Object.Rotator DeltaRot)
	{
		/*local */Actor.EDoubleClickDir DoubleClickMove = default;
	
		if((Pawn != default) && Pawn.bHardAttach)
		{
			return;
		}
		DoubleClickMove = ((Actor.EDoubleClickDir)SavedMoveClass.Static.SetFlags((byte)CompressedFlags, this));
		HandleWalking();
		ProcessMove(DeltaTime, newAccel, ((Actor.EDoubleClickDir)DoubleClickMove), DeltaRot);
		if(Pawn != default)
		{
			Pawn.AutonomousPhysics(DeltaTime);		
		}
		else
		{
			AutonomousPhysics(DeltaTime);
		}
		bDoubleJump = false;
	}
	
	public virtual /*unreliable client simulated function */void VeryShortClientAdjustPosition(float TimeStamp, float NewLocX, float NewLocY, float NewLocZ, Actor NewBase)
	{
		/*local */Object.Vector Floor = default;
	
		if(Pawn != default)
		{
			Floor = Pawn.Floor;
		}
		LongClientAdjustPosition(TimeStamp, "PlayerWalking", Actor.EPhysics.PHYS_Walking/*1*/, NewLocX, NewLocY, NewLocZ, 0.0f, 0.0f, 0.0f, NewBase, Floor.X, Floor.Y, Floor.Z);
	}
	
	public virtual /*unreliable client simulated function */void ShortClientAdjustPosition(float TimeStamp, name NewState, Actor.EPhysics newPhysics, float NewLocX, float NewLocY, float NewLocZ, Actor NewBase)
	{
		/*local */Object.Vector Floor = default;
	
		if(Pawn != default)
		{
			Floor = Pawn.Floor;
		}
		LongClientAdjustPosition(TimeStamp, NewState, ((Actor.EPhysics)newPhysics), NewLocX, NewLocY, NewLocZ, 0.0f, 0.0f, 0.0f, NewBase, Floor.X, Floor.Y, Floor.Z);
	}
	
	public virtual /*reliable client simulated function */void ClientCapBandwidth(int Cap)
	{
		ClientCap = Cap;
		if((Player != default) && Player.CurrentNetSpeed > Cap)
		{
			SetNetSpeed(Cap);
		}
	}
	
	public virtual /*unreliable client simulated function */void ClientAckGoodMove(float TimeStamp)
	{
		UpdatePing(TimeStamp);
		CurrentTimeStamp = TimeStamp;
		ClearAckedMoves();
	}
	
	public virtual /*unreliable client simulated function */void ClientAdjustPosition(float TimeStamp, name NewState, Actor.EPhysics newPhysics, float NewLocX, float NewLocY, float NewLocZ, float NewVelX, float NewVelY, float NewVelZ, Actor NewBase)
	{
		/*local */Object.Vector Floor = default;
	
		if(Pawn != default)
		{
			Floor = Pawn.Floor;
		}
		LongClientAdjustPosition(TimeStamp, NewState, ((Actor.EPhysics)newPhysics), NewLocX, NewLocY, NewLocZ, NewVelX, NewVelY, NewVelZ, NewBase, Floor.X, Floor.Y, Floor.Z);
	}
	
	public virtual /*reliable server function */void ServerSetNetSpeed(int NewSpeed)
	{
		SetNetSpeed(NewSpeed);
	}
	
	public virtual /*final function */void UpdatePing(float TimeStamp)
	{
		if(PlayerReplicationInfo != default)
		{
			#warning replaced base call with standard call
			PlayerReplicationInfo/*.base(PlayerController)*/.UpdatePing(TimeStamp);
			if((WorldInfo.TimeSeconds - LastPingUpdate) > ((float)(4)))
			{
				if((bDynamicNetSpeed && OldPing > (DynamicPingThreshold * 0.0010f)) && PlayerReplicationInfo.ExactPing > (DynamicPingThreshold * 0.0010f))
				{
					if(WorldInfo.MoveRepSize < ((float)(64)))
					{
						WorldInfo.MoveRepSize += ((float)(8));					
					}
					else
					{
						if(Player.CurrentNetSpeed >= 6000)
						{
							SetNetSpeed(Player.CurrentNetSpeed - 1000);
							ServerSetNetSpeed(Player.CurrentNetSpeed);
						}
					}
					OldPing = 0.0f;				
				}
				else
				{
					OldPing = PlayerReplicationInfo.ExactPing;
				}
				LastPingUpdate = WorldInfo.TimeSeconds;
				ServerUpdatePing(((int)(((float)(1000)) * PlayerReplicationInfo.ExactPing)));
			}
		}
	}
	
	public delegate void LongClientAdjustPosition_del(float TimeStamp, name NewState, Actor.EPhysics newPhysics, float NewLocX, float NewLocY, float NewLocZ, float NewVelX, float NewVelY, float NewVelZ, Actor NewBase, float NewFloorX, float NewFloorY, float NewFloorZ);
	public virtual LongClientAdjustPosition_del LongClientAdjustPosition { get => bfield_LongClientAdjustPosition ?? PlayerController_LongClientAdjustPosition; set => bfield_LongClientAdjustPosition = value; } LongClientAdjustPosition_del bfield_LongClientAdjustPosition;
	public virtual LongClientAdjustPosition_del global_LongClientAdjustPosition => PlayerController_LongClientAdjustPosition;
	public /*unreliable client simulated function */void PlayerController_LongClientAdjustPosition(float TimeStamp, name NewState, Actor.EPhysics newPhysics, float NewLocX, float NewLocY, float NewLocZ, float NewVelX, float NewVelY, float NewVelZ, Actor NewBase, float NewFloorX, float NewFloorY, float NewFloorZ)
	{
		/*local */Object.Vector NewLocation = default, NewVelocity = default, NewFloor = default;
		/*local */Actor MoveActor = default;
		/*local */SavedMove CurrentMove = default;
		/*local */Actor TheViewTarget = default;
	
		UpdatePing(TimeStamp);
		if(Pawn != default)
		{
			if(Pawn.bTearOff)
			{
				return;
			}
			MoveActor = Pawn;
			TheViewTarget = GetViewTarget();
			if((TheViewTarget != Pawn) && (TheViewTarget == this) || (((TheViewTarget) as Pawn) != default) && ((TheViewTarget) as Pawn).Health <= 0)
			{
				ResetCameraMode();
				SetViewTarget(Pawn, default(Camera.ViewTargetTransitionParams));
			}		
		}
		else
		{
			MoveActor = this;
			if(GetStateName() != NewState)
			{
				if(NewState == "RoundEnded")
				{
					GotoState(NewState, default(name), default(bool), default(bool));				
				}
				else
				{
					if(IsInState("Dead", default(bool)))
					{
						if((NewState != "PlayerWalking") && NewState != "PlayerSwimming")
						{
							GotoState(NewState, default(name), default(bool), default(bool));
						}
						return;					
					}
					else
					{
						if(NewState == "Dead")
						{
							GotoState(NewState, default(name), default(bool), default(bool));
						}
					}
				}
			}
		}
		if(CurrentTimeStamp >= TimeStamp)
		{
			return;
		}
		CurrentTimeStamp = TimeStamp;
		NewLocation.X = NewLocX;
		NewLocation.Y = NewLocY;
		NewLocation.Z = NewLocZ;
		NewVelocity.X = NewVelX;
		NewVelocity.Y = NewVelY;
		NewVelocity.Z = NewVelZ;
		CurrentMove = SavedMoves;
		J0x1F0:{}
		if(CurrentMove != default)
		{
			if(CurrentMove.TimeStamp <= CurrentTimeStamp)
			{
				SavedMoves = CurrentMove.NextMove;
				CurrentMove.NextMove = FreeMoves;
				FreeMoves = CurrentMove;
				if(CurrentMove.TimeStamp == CurrentTimeStamp)
				{
					LastAckedAccel = CurrentMove.Acceleration;
					FreeMoves.Clear();
					if(((((NewBase) as InterpActor) != default) || ((NewBase) as Vehicle) != default) && NewBase == CurrentMove.EndBase)
					{
						if(((GetStateName() == NewState) && IsInState("PlayerWalking", default(bool))) && (((int)MoveActor.Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) || ((int)MoveActor.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
						{
							if(VSizeSq(CurrentMove.SavedRelativeLocation - NewLocation) < 3.0f)
							{
								CurrentMove = default;
								return;							
							}
							else
							{
								if((((((NewBase) as Vehicle) != default) && VSizeSq(Velocity) < 9.0f) && VSizeSq(NewVelocity) < 9.0f) && VSizeSq(CurrentMove.SavedRelativeLocation - NewLocation) < 900.0f)
								{
									CurrentMove = default;
									return;
								}
							}
						}					
					}
					else
					{
						if(((((VSizeSq(CurrentMove.SavedLocation - NewLocation) < 3.0f) && VSizeSq(CurrentMove.SavedVelocity - NewVelocity) < 9.0f) && GetStateName() == NewState) && IsInState("PlayerWalking", default(bool))) && (((int)MoveActor.Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) || ((int)MoveActor.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
						{
							CurrentMove = default;
							return;
						}
					}
					CurrentMove = default;				
				}
				else
				{
					FreeMoves.Clear();
					CurrentMove = SavedMoves;
				}			
			}
			else
			{
				CurrentMove = default;
			}
			goto J0x1F0;
		}
		if(MoveActor.bHardAttach)
		{
			if(MoveActor.Base == default)
			{
				if(NewBase != default)
				{
					MoveActor.SetBase(NewBase, default(Object.Vector), default(SkeletalMeshComponent), default(name));
				}
				if(MoveActor.Base == default)
				{
					MoveActor.SetHardAttach(false);				
				}
				else
				{
					return;
				}			
			}
			else
			{
				return;
			}
		}
		NewFloor.X = NewFloorX;
		NewFloor.Y = NewFloorY;
		NewFloor.Z = NewFloorZ;
		if((((Pawn != default) && ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/)) && Pawn.Mesh != default) && ((int)Pawn.Mesh.RootMotionMode) != ((int)SkeletalMeshComponent.ERootMotionMode.RMM_Ignore/*2*/))
		{
			return;
		}
		CurrentMove = SavedMoves;
		J0x5D4:{}
		if(CurrentMove != default)
		{
			if(CurrentMove.bForceRMVelocity)
			{
				return;
			}
			CurrentMove = CurrentMove.NextMove;
			goto J0x5D4;
		}
		if((((NewBase) as InterpActor) != default) || ((NewBase) as Vehicle) != default)
		{
			NewLocation += NewBase.Location;
		}
		MoveActor.bCanTeleport = false;
		if(((((!MoveActor.SetLocation(NewLocation) && ((MoveActor) as Pawn) != default) && ((MoveActor) as Pawn).CylinderComponent.CollisionHeight > ((MoveActor) as Pawn).CrouchHeight) && !((MoveActor) as Pawn).bIsCrouched) && ((int)newPhysics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) && ((int)MoveActor.Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			MoveActor.SetPhysics(((Actor.EPhysics)newPhysics));
			if(!MoveActor.SetLocation(NewLocation + (vect(0.0f, 0.0f, 1.0f) * ((MoveActor) as Pawn).MaxStepHeight)))
			{
				((MoveActor) as Pawn).ForceCrouch();
				MoveActor.SetLocation(NewLocation);			
			}
			else
			{
				MoveActor.MoveSmooth(vect(0.0f, 0.0f, -1.0f) * ((MoveActor) as Pawn).MaxStepHeight);
			}
		}
		MoveActor.bCanTeleport = true;
		if((((int)MoveActor.Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/)) && ((int)newPhysics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			MoveActor.SetPhysics(((Actor.EPhysics)newPhysics));
		}
		if(MoveActor != this)
		{
			MoveActor.SetBase(NewBase, NewFloor, default(SkeletalMeshComponent), default(name));
		}
		MoveActor.Velocity = NewVelocity;
		UpdateStateFromAdjustment(NewState);
		bUpdatePosition = true;
	}
	
	public virtual /*function */void UpdateStateFromAdjustment(name NewState)
	{
		if(GetStateName() != NewState)
		{
			GotoState(NewState, default(name), default(bool), default(bool));
		}
	}
	
	public virtual /*unreliable server function */void ServerUpdatePing(int NewPing)
	{
		PlayerReplicationInfo.Ping = (byte)((byte)(Min(((int)(0.250f * ((float)(NewPing)))), 250)));
	}
	
	public virtual /*function */void ClearAckedMoves()
	{
		/*local */SavedMove CurrentMove = default;
	
		CurrentMove = SavedMoves;
		J0x0B:{}
		if(CurrentMove != default)
		{
			if(CurrentMove.TimeStamp <= CurrentTimeStamp)
			{
				if(CurrentMove.TimeStamp == CurrentTimeStamp)
				{
					LastAckedAccel = CurrentMove.Acceleration;
				}
				SavedMoves = CurrentMove.NextMove;
				CurrentMove.NextMove = FreeMoves;
				FreeMoves = CurrentMove;
				FreeMoves.Clear();
				CurrentMove = SavedMoves;			
			}
			else
			{
				goto J0xBA;
			}
			goto J0x0B;
		}
		J0xBA:{}
	}
	
	public virtual /*function */void ClientUpdatePosition()
	{
		/*local */SavedMove CurrentMove = default;
		/*local */int realbRun = default, realbDuck = default;
		/*local */bool bRealJump = default, bRealPreciseDestination = default;
	
		bUpdatePosition = false;
		if((Pawn != default) && ((int)Pawn.Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			return;
		}
		realbRun = ((int)bRun);
		realbDuck = ((int)bDuck);
		bRealJump = bPressedJump;
		bUpdating = true;
		bRealPreciseDestination = bPreciseDestination;
		ClearAckedMoves();
		CurrentMove = SavedMoves;
		J0x82:{}
		if(CurrentMove != default)
		{
			if((PendingMove == CurrentMove) && Pawn != default)
			{
				PendingMove.SetInitialPosition(Pawn);
			}
			if(Pawn != default)
			{
				Pawn.bForceRMVelocity = CurrentMove.bForceRMVelocity;
			}
			MoveAutonomous(CurrentMove.Delta, (byte)CurrentMove.CompressedFlags(), CurrentMove.Acceleration, rot(0, 0, 0));
			if(Pawn != default)
			{
				Pawn.bForceRMVelocity = false;
				CurrentMove.SavedLocation = Pawn.Location;
				CurrentMove.SavedVelocity = Pawn.Velocity;
				CurrentMove.EndBase = Pawn.Base;
				if((CurrentMove.EndBase != default) && !CurrentMove.EndBase.bWorldGeometry)
				{
					CurrentMove.SavedRelativeLocation = Pawn.Location - CurrentMove.EndBase.Location;
				}
			}
			CurrentMove = CurrentMove.NextMove;
			goto J0x82;
		}
		bUpdating = false;
		bDuck = (byte)((byte)(realbDuck));
		bRun = (byte)((byte)(realbRun));
		bPressedJump = bRealJump;
		bPreciseDestination = bRealPreciseDestination;
	}
	
	public virtual /*final function */SavedMove GetFreeMove()
	{
		/*local */SavedMove S = default, first = default;
		/*local */int I = default;
	
		if(FreeMoves == default)
		{
			S = SavedMoves;
			J0x16:{}
			if(S != default)
			{
				++ I;
				if(I > 100)
				{
					first = SavedMoves;
					SavedMoves = SavedMoves.NextMove;
					first.Clear();
					first.NextMove = default;
					J0x79:{}
					if(SavedMoves != default)
					{
						S = SavedMoves;
						SavedMoves = SavedMoves.NextMove;
						S.Clear();
						S.NextMove = FreeMoves;
						FreeMoves = S;
						goto J0x79;
					}
					PendingMove = default;
					return first;
				}
				S = S.NextMove;
				goto J0x16;
			}
			return  SavedMoveClass.New(this);		
		}
		else
		{
			S = FreeMoves;
			FreeMoves = FreeMoves.NextMove;
			S.NextMove = default;
			return S;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*function */int CompressAccel(int C)
	{
		if(C >= 0)
		{
			C = Min(C, 127);		
		}
		else
		{
			C = Min(((int)(Abs(((float)(C))))), 127) + 128;
		}
		return C;
	}
	
	public delegate void ReplicateMove_del(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot);
	public virtual ReplicateMove_del ReplicateMove { get => bfield_ReplicateMove ?? PlayerController_ReplicateMove; set => bfield_ReplicateMove = value; } ReplicateMove_del bfield_ReplicateMove;
	public virtual ReplicateMove_del global_ReplicateMove => PlayerController_ReplicateMove;
	public /*function */void PlayerController_ReplicateMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)
	{
		/*local */SavedMove NewMove = default, OldMove = default, AlmostLastMove = default, LastMove = default;
		/*local */byte ClientRoll = default;
		/*local */float NetMoveDelta = default;
	
		if(Player == default)
		{
			return;
		}
		MaxResponseTime = DefaultAs<PlayerController>().MaxResponseTime * WorldInfo.TimeDilation;
		DeltaTime = ((Pawn != default) ? Pawn.CustomTimeDilation : CustomTimeDilation) * FMin(DeltaTime, MaxResponseTime);
		if(SavedMoves != default)
		{
			LastMove = SavedMoves;
			AlmostLastMove = LastMove;
			OldMove = default;
			J0x86:{}
			if(LastMove.NextMove != default)
			{
				if(((OldMove == default) && Pawn != default) && LastMove.IsImportantMove(LastAckedAccel))
				{
					OldMove = LastMove;
				}
				AlmostLastMove = LastMove;
				LastMove = LastMove.NextMove;
				goto J0x86;
			}
		}
		NewMove = GetFreeMove();
		if(NewMove == default)
		{
			return;
		}
		NewMove.SetMoveFor(this, DeltaTime, newAccel, ((Actor.EDoubleClickDir)DoubleClickMove));
		bDoubleJump = false;
		ProcessMove(NewMove.Delta, NewMove.Acceleration, ((Actor.EDoubleClickDir)NewMove.DoubleClickMove), DeltaRot);
		if((PendingMove != default) && PendingMove.CanCombineWith(NewMove, Pawn, MaxResponseTime))
		{
			Pawn.SetLocation(PendingMove.GetStartLocation());
			Pawn.Velocity = PendingMove.StartVelocity;
			if(PendingMove.StartBase != Pawn.Base)
			{
				Pawn.SetBase(PendingMove.StartBase, default(Object.Vector), default(SkeletalMeshComponent), default(name));
			}
			Pawn.Floor = PendingMove.StartFloor;
			NewMove.Delta += PendingMove.Delta;
			NewMove.SetInitialPosition(Pawn);
			if(LastMove == PendingMove)
			{
				if(SavedMoves == PendingMove)
				{
					SavedMoves.NextMove = FreeMoves;
					FreeMoves = SavedMoves;
					SavedMoves = default;				
				}
				else
				{
					PendingMove.NextMove = FreeMoves;
					FreeMoves = PendingMove;
					if(AlmostLastMove != default)
					{
						AlmostLastMove.NextMove = default;
						LastMove = AlmostLastMove;
					}
				}
				FreeMoves.Clear();
			}
			PendingMove = default;
		}
		if(Pawn != default)
		{
			Pawn.AutonomousPhysics(NewMove.Delta);		
		}
		else
		{
			AutonomousPhysics(DeltaTime);
		}
		NewMove.PostUpdate(this);
		if(SavedMoves == default)
		{
			SavedMoves = NewMove;		
		}
		else
		{
			LastMove.NextMove = NewMove;
		}
		if(PendingMove == default)
		{
			if(((Player.CurrentNetSpeed > 10000) && WorldInfo.GRI != default) && WorldInfo.GRI.PRIArray.Length <= 10)
			{
				NetMoveDelta = 0.0110f;			
			}
			else
			{
				NetMoveDelta = FMax(0.02220f, (2.0f * WorldInfo.MoveRepSize) / ((float)(Player.CurrentNetSpeed)));
			}
			if(((WorldInfo.TimeSeconds - ClientUpdateTime) * WorldInfo.TimeDilation) < NetMoveDelta)
			{
				PendingMove = NewMove;
				return;
			}
		}
		ClientUpdateTime = WorldInfo.TimeSeconds;
		ClientRoll = (byte)((byte)((/*>>*/ShiftR(Rotation.Roll, 8)) & 255));
		CallServerMove(NewMove, ((Pawn == default) ? Location : Pawn.Location), (byte)ClientRoll, (/*<<*/ShiftL((Rotation.Yaw & 65535), 16)) + (Rotation.Pitch & 65535), OldMove);
		PendingMove = default;
	}
	
	public virtual /*function */void CallServerMove(SavedMove NewMove, Object.Vector ClientLoc, byte ClientRoll, int View, SavedMove OldMove)
	{
		/*local */Object.Vector BuildAccel = default;
		/*local */byte OldAccelX = default, OldAccelY = default, OldAccelZ = default;
	
		if(OldMove != default)
		{
			BuildAccel = (0.050f * OldMove.Acceleration) + vect(0.50f, 0.50f, 0.50f);
			OldAccelX = (byte)((byte)(CompressAccel(((int)(BuildAccel.X)))));
			OldAccelY = (byte)((byte)(CompressAccel(((int)(BuildAccel.Y)))));
			OldAccelZ = (byte)((byte)(CompressAccel(((int)(BuildAccel.Z)))));
			OldServerMove(OldMove.TimeStamp, (byte)OldAccelX, (byte)OldAccelY, (byte)OldAccelZ, (byte)OldMove.CompressedFlags());
		}
		if(PendingMove != default)
		{
			DualServerMove(PendingMove.TimeStamp, PendingMove.Acceleration * ((float)(10)), (byte)PendingMove.CompressedFlags(), (/*<<*/ShiftL((PendingMove.Rotation.Yaw & 65535), 16)) + (PendingMove.Rotation.Pitch & 65535), NewMove.TimeStamp, NewMove.Acceleration * ((float)(10)), ClientLoc, (byte)NewMove.CompressedFlags(), (byte)ClientRoll, View);		
		}
		else
		{
			ServerMove(NewMove.TimeStamp, NewMove.Acceleration * ((float)(10)), ClientLoc, (byte)NewMove.CompressedFlags(), (byte)ClientRoll, View);
		}
	}
	
	public virtual /*function */void HandleWalking()
	{
		if(Pawn != default)
		{
			Pawn.SetWalking(((int)bRun) != ((int)0));
		}
	}
	
	public delegate void ServerRestartGame_del();
	public virtual ServerRestartGame_del ServerRestartGame { get => bfield_ServerRestartGame ?? PlayerController_ServerRestartGame; set => bfield_ServerRestartGame = value; } ServerRestartGame_del bfield_ServerRestartGame;
	public virtual ServerRestartGame_del global_ServerRestartGame => PlayerController_ServerRestartGame;
	public /*reliable server function */void PlayerController_ServerRestartGame()
	{
	
	}
	
	public virtual /*exec function */void Speech(name Type, int Index, string Callsign)
	{
		ServerSpeech(Type, Index, Callsign);
	}
	
	public virtual /*reliable server function */void ServerSpeech(name Type, int Index, string Callsign)
	{
	
	}
	
	public delegate void RestartLevel_del();
	public virtual RestartLevel_del RestartLevel { get => bfield_RestartLevel ?? PlayerController_RestartLevel; set => bfield_RestartLevel = value; } RestartLevel_del bfield_RestartLevel;
	public virtual RestartLevel_del global_RestartLevel => PlayerController_RestartLevel;
	public /*exec function */void PlayerController_RestartLevel()
	{
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			ClientTravel("?restart", Actor.ETravelType.TRAVEL_Relative/*2*/, default(bool), default(Object.Guid));
		}
	}
	
	public virtual /*exec function */void LocalTravel(string URL)
	{
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			ClientTravel(URL, Actor.ETravelType.TRAVEL_Relative/*2*/, default(bool), default(Object.Guid));
		}
	}
	
	public virtual /*exec function */void QuickSave()
	{
		if(((Pawn != default) && Pawn.Health > 0) && ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			ClientMessage(QuickSaveString, default(name), default(float));
			ConsoleCommand("DEFER SAVEGAME QUICKSAVE.SAV", default(bool));
		}
	}
	
	public virtual /*exec function */void QuickLoad()
	{
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			ConsoleCommand("DEFER LOADGAME QUICKSAVE.SAV", default(bool));
		}
	}


	#warning split default delegate implementation
	public delegate bool CanUnpause();
	public bool CanUnpause_Default()
	{
		// Originally 'WorldInfo.Pauser == this;', haven't verified if this works
		return WorldInfo.Pauser == this.PlayerReplicationInfo;
	}
	
	public virtual /*function */bool SetPause(bool bPause, /*optional *//*delegate*/PlayerController.CanUnpause CanUnpauseDelegate = default)
	{
		/*local */bool bResult = default;
	
		if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Client/*3*/))
		{
			if(bPause == true)
			{
				bFire = (byte)0;
				// 'Cast' delegate
				bResult = WorldInfo.Game.SetPause(this, /*CanUnpauseDelegate*/CanUnpauseDelegate == null ? CanUnpause_Default : () => CanUnpauseDelegate());
				if(bResult)
				{
					if(ForceFeedbackManager != default)
					{
						ForceFeedbackManager.PauseWaveform(true);
					}
				}			
			}
			else
			{
				WorldInfo.Game.ClearPause();
				if((ForceFeedbackManager != default) && WorldInfo.Pauser == default)
				{
					ForceFeedbackManager.PauseWaveform(false);
				}
			}
		}
		return bResult;
	}
	
	public virtual /*exec function */void DebugPause()
	{
		WorldInfo.Game.DebugPause();
	}
	
	public virtual /*final simulated function */bool IsPaused()
	{
		return WorldInfo.Pauser != default;
	}
	
	public virtual /*exec function */void Pause()
	{
		ServerPause();
	}
	
	public virtual /*reliable server function */void ServerPause()
	{
		if(!IsPaused())
		{
			SetPause(true, default(/*delegate*/PlayerController.CanUnpause));		
		}
		else
		{
			SetPause(false, default(/*delegate*/PlayerController.CanUnpause));
		}
	}
	
	public virtual /*exec function */void ShowMenu()
	{
		if(!IsPaused())
		{
			SetPause(true, default(/*delegate*/PlayerController.CanUnpause));
		}
	}
	
	public virtual /*event */void ConditionalPause(bool bDesiredPauseState)
	{
		if(bDesiredPauseState != IsPaused())
		{
			SetPause(bDesiredPauseState, default(/*delegate*/PlayerController.CanUnpause));
		}
	}
	
	public virtual /*reliable server function */void ServerUTrace()
	{
		if((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && (PlayerReplicationInfo == default) || !PlayerReplicationInfo.bAdmin)
		{
			return;
		}
		UTrace();
	}
	
	public virtual /*exec function */void UTrace()
	{
		ConsoleCommand("hidelog", default(bool));
		if(((int)Role) != ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ServerUTrace();
		}
		SetUTracing(!IsUTracing());
	}
	
	public delegate void ThrowWeapon_del();
	public virtual ThrowWeapon_del ThrowWeapon { get => bfield_ThrowWeapon ?? PlayerController_ThrowWeapon; set => bfield_ThrowWeapon = value; } ThrowWeapon_del bfield_ThrowWeapon;
	public virtual ThrowWeapon_del global_ThrowWeapon => PlayerController_ThrowWeapon;
	public /*exec function */void PlayerController_ThrowWeapon()
	{
		if((Pawn == default) || Pawn.Weapon == default)
		{
			return;
		}
		ServerThrowWeapon();
	}
	
	public virtual /*reliable server function */void ServerThrowWeapon()
	{
		if(Pawn.CanThrowWeapon())
		{
			Pawn.ThrowActiveWeapon(default(Core.ClassT<DamageType>));
		}
	}
	
	public delegate void PrevWeapon_del();
	public virtual PrevWeapon_del PrevWeapon { get => bfield_PrevWeapon ?? PlayerController_PrevWeapon; set => bfield_PrevWeapon = value; } PrevWeapon_del bfield_PrevWeapon;
	public virtual PrevWeapon_del global_PrevWeapon => PlayerController_PrevWeapon;
	public /*exec function */void PlayerController_PrevWeapon()
	{
		if(WorldInfo.Pauser != default)
		{
			return;
		}
		if(Pawn.Weapon == default)
		{
			SwitchToBestWeapon(default(bool));
			return;
		}
		if(Pawn.InvManager != default)
		{
			Pawn.InvManager.PrevWeapon();
		}
	}
	
	public delegate void NextWeapon_del();
	public virtual NextWeapon_del NextWeapon { get => bfield_NextWeapon ?? PlayerController_NextWeapon; set => bfield_NextWeapon = value; } NextWeapon_del bfield_NextWeapon;
	public virtual NextWeapon_del global_NextWeapon => PlayerController_NextWeapon;
	public /*exec function */void PlayerController_NextWeapon()
	{
		if(WorldInfo.Pauser != default)
		{
			return;
		}
		if(Pawn.Weapon == default)
		{
			SwitchToBestWeapon(default(bool));
			return;
		}
		if(Pawn.InvManager != default)
		{
			Pawn.InvManager.NextWeapon();
		}
	}
	
	public delegate void StartFire_del(/*optional */byte FireModeNum = default);
	public virtual StartFire_del StartFire { get => bfield_StartFire ?? PlayerController_StartFire; set => bfield_StartFire = value; } StartFire_del bfield_StartFire;
	public virtual StartFire_del global_StartFire => PlayerController_StartFire;
	public /*exec function */void PlayerController_StartFire(/*optional */byte FireModeNum = default)
	{
		if(WorldInfo.Pauser == PlayerReplicationInfo)
		{
			SetPause(false, default(/*delegate*/PlayerController.CanUnpause));
			return;
		}
		if((Pawn != default) && !bCinematicMode)
		{
			Pawn.StartFire((byte)FireModeNum);
		}
	}
	
	public virtual /*exec function */void StopFire(/*optional */byte FireModeNum = default)
	{
		if(Pawn != default)
		{
			Pawn.StopFire((byte)FireModeNum);
		}
	}
	
	public delegate void StartAltFire_del(/*optional */byte FireModeNum = default);
	public virtual StartAltFire_del StartAltFire { get => bfield_StartAltFire ?? PlayerController_StartAltFire; set => bfield_StartAltFire = value; } StartAltFire_del bfield_StartAltFire;
	public virtual StartAltFire_del global_StartAltFire => PlayerController_StartAltFire;
	public /*exec function */void PlayerController_StartAltFire(/*optional */byte FireModeNum = default)
	{
		StartFire(1);
	}
	
	public virtual /*exec function */void StopAltFire(/*optional */byte FireModeNum = default)
	{
		StopFire(1);
	}
	
	public virtual /*function */void GetTriggerUseList(float interactDistanceToCheck, float crosshairDist, float minDot, bool bUsuableOnly, ref array<Trigger> out_useList)
	{
		/*local */int Idx = default;
		/*local */Object.Vector cameraLoc = default;
		/*local */Object.Rotator cameraRot = default;
		/*local */Trigger checkTrigger = default;
		/*local */SeqEvent_Used UseSeq = default;
	
		if(Pawn != default)
		{
			GetPlayerViewPoint(ref/*probably?*/ cameraLoc, ref/*probably?*/ cameraRot);
			
			// foreach Pawn.CollidingActors(ClassT<Trigger>(), ref/*probably?*/ checkTrigger, interactDistanceToCheck, default(Object.Vector), default(bool))
			using var e31 = Pawn.CollidingActors(ClassT<Trigger>(), interactDistanceToCheck, default(Object.Vector), default(bool)).GetEnumerator();
			while(e31.MoveNext() && (checkTrigger = (Trigger)e31.Current) == checkTrigger)
			{
				Idx = 0;
				J0x47:{}
				if(Idx < checkTrigger.GeneratedEvents.Length)
				{
					UseSeq = ((checkTrigger.GeneratedEvents[Idx]) as SeqEvent_Used);
					if((((UseSeq != default) && !bUsuableOnly || checkTrigger.GeneratedEvents[Idx].CheckActivate(checkTrigger, Pawn, true, ref/*probably?*/ /*null*/NullRef.array_int_, default(bool))) && (Dot(Normal(checkTrigger.Location - cameraLoc), ((Vector)(cameraRot)))) >= minDot) && ((UseSeq.bAimToInteract && IsAimingAt(checkTrigger, 0.980f)) && VSize(Pawn.Location - checkTrigger.Location) <= UseSeq.InteractDistance) || !UseSeq.bAimToInteract && VSize(Pawn.Location - checkTrigger.Location) <= UseSeq.InteractDistance)
					{
						out_useList[out_useList.Length] = checkTrigger;
						Idx = checkTrigger.GeneratedEvents.Length;
					}
					++ Idx;
					goto J0x47;
				}			
			}		
		}
	}
	
	public delegate void Use_del();
	public virtual Use_del Use { get => bfield_Use ?? PlayerController_Use; set => bfield_Use = value; } Use_del bfield_Use;
	public virtual Use_del global_Use => PlayerController_Use;
	public /*exec function */void PlayerController_Use()
	{
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			PerformedUseAction();
		}
		ServerUse();
	}
	
	public delegate void ServerUse_del();
	public virtual ServerUse_del ServerUse { get => bfield_ServerUse ?? PlayerController_ServerUse; set => bfield_ServerUse = value; } ServerUse_del bfield_ServerUse;
	public virtual ServerUse_del global_ServerUse => PlayerController_ServerUse;
	public /*unreliable server function */void PlayerController_ServerUse()
	{
		PerformedUseAction();
	}
	
	public virtual /*function */bool PerformedUseAction()
	{
		if(WorldInfo.Pauser == PlayerReplicationInfo)
		{
			if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				SetPause(false, default(/*delegate*/PlayerController.CanUnpause));
			}
			return true;
		}
		if((Pawn == default) || !Pawn.bCanUse)
		{
			return true;
		}
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return false;
		}
		if(((Pawn) as Vehicle) != default)
		{
			return ((Pawn) as Vehicle).DriverLeave(false);
		}
		if(FindVehicleToDrive())
		{
			return true;
		}
		return TriggerInteracted();
	}
	
	public virtual /*function */bool FindVehicleToDrive()
	{
		/*local */Vehicle V = default, Best = default;
		/*local */Object.Vector ViewDir = default, PawnLoc2D = default, VLoc2D = default;
		/*local */float NewDot = default, BestDot = default;
	
		if((((Pawn.Base) as Vehicle) != default) && ((Pawn.Base) as Vehicle).TryToDrive(Pawn))
		{
			return true;
		}
		PawnLoc2D = Pawn.Location;
		PawnLoc2D.Z = 0.0f;
		ViewDir = ((Vector)(Pawn.Rotation));
		
		// foreach Pawn.OverlappingActors(ClassT<Vehicle>(), ref/*probably?*/ V, Pawn.VehicleCheckRadius, default(Object.Vector), default(bool))
		using var e139 = Pawn.OverlappingActors(ClassT<Vehicle>(), Pawn.VehicleCheckRadius, default(Object.Vector), default(bool)).GetEnumerator();
		while(e139.MoveNext() && (V = (Vehicle)e139.Current) == V)
		{
			VLoc2D = V.Location;
			VLoc2D.Z = 0.0f;
			NewDot = Dot(Normal(VLoc2D - PawnLoc2D), ViewDir);
			if((Best == default) || NewDot > BestDot)
			{
				if(FastTrace(V.Location, Pawn.Location, default(Object.Vector), default(bool)))
				{
					Best = V;
					BestDot = NewDot;
				}
			}		
		}	
		return (Best != default) && Best.TryToDrive(Pawn);
	}
	
	public virtual /*function */bool TriggerInteracted()
	{
		/*local */Actor A = default;
		/*local */int Idx = default;
		/*local */float Weight = default;
		/*local */bool bInserted = default;
		/*local */Object.Vector cameraLoc = default;
		/*local */Object.Rotator cameraRot = default;
		/*local */array<Trigger> useList = default;
		/*local */array<Actor> sortedList = default;
		/*local */array<float> weightList = default;
	
		if(Pawn != default)
		{
			GetTriggerUseList(InteractDistance, 60.0f, 0.0f, true, ref/*probably?*/ useList);
			if(useList.Length > 0)
			{
				GetPlayerViewPoint(ref/*probably?*/ cameraLoc, ref/*probably?*/ cameraRot);
				J0x4A:{}
				if(useList.Length > 0)
				{
					A = useList[useList.Length - 1];
					useList.Length = useList.Length - 1;
					Weight = Dot(Normal(A.Location - cameraLoc), ((Vector)(cameraRot)));
					Weight += (1.0f - (VSize(A.Location - Pawn.Location) / InteractDistance));
					bInserted = false;
					Idx = 0;
					J0xE8:{}
					if((Idx < sortedList.Length) && !bInserted)
					{
						if(weightList[Idx] < Weight)
						{
							sortedList.Insert(Idx, 1);
							weightList.Insert(Idx, 1);
							sortedList[Idx] = A;
							weightList[Idx] = Weight;
							bInserted = true;
						}
						++ Idx;
						goto J0xE8;
					}
					if(!bInserted)
					{
						Idx = sortedList.Length;
						sortedList[Idx] = A;
						weightList[Idx] = Weight;
					}
					goto J0x4A;
				}
				Idx = 0;
				J0x1A9:{}
				if(Idx < sortedList.Length)
				{
					if(sortedList[Idx].UsedBy(Pawn))
					{
						return true;
					}
					++ Idx;
					goto J0x1A9;
				}
			}
		}
		return false;
	}
	
	public delegate void Suicide_del();
	public virtual Suicide_del Suicide { get => bfield_Suicide ?? PlayerController_Suicide; set => bfield_Suicide = value; } Suicide_del bfield_Suicide;
	public virtual Suicide_del global_Suicide => PlayerController_Suicide;
	public /*exec function */void PlayerController_Suicide()
	{
		ServerSuicide();
	}
	
	public delegate void ServerSuicide_del();
	public virtual ServerSuicide_del ServerSuicide { get => bfield_ServerSuicide ?? PlayerController_ServerSuicide; set => bfield_ServerSuicide = value; } ServerSuicide_del bfield_ServerSuicide;
	public virtual ServerSuicide_del global_ServerSuicide => PlayerController_ServerSuicide;
	public /*reliable server function */void PlayerController_ServerSuicide()
	{
		if((Pawn != default) && ((WorldInfo.TimeSeconds - Pawn.LastStartTime) > ((float)(10))) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			Pawn.Suicide();
		}
	}
	
	public virtual /*exec function */void SetName(/*coerce */string S)
	{
		/*local */string NewName = default;
		/*local */LocalPlayer LocPlayer = default;
	
		if(S != "")
		{
			LocPlayer = ((Player) as LocalPlayer);
			if(((LocPlayer != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface)))) && NotEqual_InterfaceInterface(OnlineSub.PlayerInterface, (default(OnlinePlayerInterface))))
			{
				if((((int)OnlineSub.PlayerInterface.GetLoginStatus(((byte)(LocPlayer.ControllerId)))) == ((int)OnlineSubsystem.ELoginStatus.LS_LoggedIn/*2*/)) && OnlineSub.GameInterface.GetGameSettings() != default)
				{
					S = OnlineSub.PlayerInterface.GetPlayerNickname((byte)((byte)(LocPlayer.ControllerId)));
				}
			}
			NewName = S;
			ServerChangeName(NewName);
			UpdateURL("Name", NewName, true);
			SaveConfig();
		}
	}
	
	public virtual /*reliable server function */void ServerChangeName(/*coerce */string S)
	{
		if(S != "")
		{
			WorldInfo.Game.ChangeName(this, S, true);
		}
	}
	
	public virtual /*exec function */void SwitchTeam()
	{
		if((PlayerReplicationInfo.Team == default) || PlayerReplicationInfo.Team.TeamIndex == 1)
		{
			ServerChangeTeam(0);		
		}
		else
		{
			ServerChangeTeam(1);
		}
	}
	
	public virtual /*exec function */void ChangeTeam(/*optional */string TeamName = default)
	{
		/*local */int N = default;
	
		if(ApproximatelyEqual(TeamName, "blue"))
		{
			N = 1;		
		}
		else
		{
			if((((ApproximatelyEqual(TeamName, "red")) || PlayerReplicationInfo == default) || PlayerReplicationInfo.Team == default) || PlayerReplicationInfo.Team.TeamIndex > 1)
			{
				N = 0;			
			}
			else
			{
				N = 1 - PlayerReplicationInfo.Team.TeamIndex;
			}
		}
		ServerChangeTeam(N);
	}
	
	public delegate void ServerChangeTeam_del(int N);
	public virtual ServerChangeTeam_del ServerChangeTeam { get => bfield_ServerChangeTeam ?? PlayerController_ServerChangeTeam; set => bfield_ServerChangeTeam = value; } ServerChangeTeam_del bfield_ServerChangeTeam;
	public virtual ServerChangeTeam_del global_ServerChangeTeam => PlayerController_ServerChangeTeam;
	public /*reliable server function */void PlayerController_ServerChangeTeam(int N)
	{
		/*local */TeamInfo OldTeam = default;
	
		OldTeam = PlayerReplicationInfo.Team;
		WorldInfo.Game.ChangeTeam(this, N, true);
		if(WorldInfo.Game.bTeamGame && PlayerReplicationInfo.Team != OldTeam)
		{
			if(Pawn != default)
			{
				Pawn.PlayerChangedTeam();
			}
		}
	}
	
	public virtual /*exec function */void SwitchLevel(string URL)
	{
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/))
		{
			WorldInfo.ServerTravel(URL, default(bool));
		}
	}
	
	public virtual /*exec function */void ClearProgressMessages()
	{
		ClientClearProgressMessages();
	}
	
	public virtual /*reliable client simulated function */void ClientClearProgressMessages()
	{
		/*local */int I = default;
	
		I = 0;
		J0x07:{}
		if(I < 2)
		{
			ProgressMessage[I] = "";
			++ I;
			goto J0x07;
		}
	}
	
	public virtual /*exec event */void SetProgressMessage(PlayerController.EProgressMessageType MessageType, string Message, /*optional */string Title = default)
	{
		ClientSetProgressMessage(((PlayerController.EProgressMessageType)MessageType), Message, Title);
	}
	
	public virtual /*reliable client simulated function */void ClientSetProgressMessage(PlayerController.EProgressMessageType MessageType, string Message, /*optional */string Title = default)
	{
		if(((int)MessageType) == ((int)PlayerController.EProgressMessageType.PMT_Clear/*0*/))
		{
			ClientClearProgressMessages();		
		}
		else
		{
			if(((int)MessageType) == ((int)PlayerController.EProgressMessageType.PMT_ConnectionFailure/*5*/))
			{
				NotifyConnectionError(Message, Title);			
			}
			else
			{
				if(Title != "")
				{
					ProgressMessage[0] = Title;
					ProgressMessage[1] = Message;				
				}
				else
				{
					ProgressMessage[1] = "";
					ProgressMessage[0] = Message;
				}
			}
		}
	}
	
	public virtual /*exec event */void SetProgressTime(float T)
	{
		ClientSetProgressTime(T);
	}
	
	public virtual /*reliable client simulated function */void ClientSetProgressTime(float T)
	{
		ProgressTimeOut = T + WorldInfo.TimeSeconds;
	}
	
	public override /*function */void Restart(bool bVehicleTransition)
	{
		base.Restart(bVehicleTransition);
		ServerTimeStamp = 0.0f;
		ResetTimeMargin();
		EnterStartState();
		ClientRestart(Pawn);
		SetViewTarget(Pawn, default(Camera.ViewTargetTransitionParams));
		ResetCameraMode();
	}
	
	// Export UPlayerController::execServerNotifyLoadedWorld(FFrame&, void* const)
	public virtual /*reliable server native final event */void ServerNotifyLoadedWorld(name WorldPackageName)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */void NotifyLoadedWorld(name WorldPackageName, bool bFinalDest)
	{
		/*local */PlayerStart P = default;
		/*local */Object.Rotator SpawnRotation = default;
	
		SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
		
		// foreach WorldInfo.AllNavigationPoints(ClassT<PlayerStart>(), ref/*probably?*/ P)
		using var e12 = WorldInfo.AllNavigationPoints(ClassT<PlayerStart>()).GetEnumerator();
		while(e12.MoveNext() && (P = (PlayerStart)e12.Current) == P)
		{
			SetLocation(P.Location);
			SpawnRotation.Yaw = P.Rotation.Yaw;
			SetRotation(SpawnRotation);
			break;		
		}	
	}
	
	// Export UPlayerController::execHasClientLoadedCurrentWorld(FFrame&, void* const)
	public virtual /*native final function */bool HasClientLoadedCurrentWorld()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void EnterStartState()
	{
		/*local */name NewState = default;
	
		if(Pawn.PhysicsVolume.bWaterVolume)
		{
			if(Pawn.HeadVolume.bWaterVolume)
			{
				Pawn.BreathTime = Pawn.UnderWaterTime;
			}
			NewState = Pawn.WaterMovementState;		
		}
		else
		{
			NewState = Pawn.LandMovementState;
		}
		if(IsInState(NewState, default(bool)))
		{
			BeginState(NewState);		
		}
		else
		{
			GotoState(NewState, default(name), default(bool), default(bool));
		}
	}
	
	public delegate void ClientRestart_del(Pawn NewPawn);
	public virtual ClientRestart_del ClientRestart { get => bfield_ClientRestart ?? PlayerController_ClientRestart; set => bfield_ClientRestart = value; } ClientRestart_del bfield_ClientRestart;
	public virtual ClientRestart_del global_ClientRestart => PlayerController_ClientRestart;
	public /*reliable client simulated function */void PlayerController_ClientRestart(Pawn NewPawn)
	{
		ResetPlayerMovementInput();
		CleanOutSavedMoves();
		Pawn = NewPawn;
		if((Pawn != default) && Pawn.bTearOff)
		{
			UnPossess();
			Pawn = default;
		}
		AcknowledgePossession(Pawn);
		if(Pawn == default)
		{
			GotoState("WaitingForPawn", default(name), default(bool), default(bool));
			return;
		}
		Pawn.ClientRestart();
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			SetViewTarget(Pawn, default(Camera.ViewTargetTransitionParams));
			ResetCameraMode();
			EnterStartState();
		}
		CleanOutSavedMoves();
	}
	
	public override /*function */void GameHasEnded(/*optional */Actor EndGameFocus = default, /*optional */bool bIsWinner = default)
	{
		SetViewTarget(EndGameFocus, default(Camera.ViewTargetTransitionParams));
		GotoState("RoundEnded", default(name), default(bool), default(bool));
		ClientGameEnded(EndGameFocus, bIsWinner);
	}
	
	public virtual /*reliable client simulated function */void ClientGameEnded(Actor EndGameFocus, bool bIsWinner)
	{
		SetViewTarget(EndGameFocus, default(Camera.ViewTargetTransitionParams));
		GotoState("RoundEnded", default(name), default(bool), default(bool));
	}
	
	public override /*function */void NotifyChangedWeapon(Weapon PreviousWeapon, Weapon NewWeapon)
	{
	
	}
	
	public delegate void PlayerTick_del(float DeltaTime);
	public virtual PlayerTick_del PlayerTick { get => bfield_PlayerTick ?? PlayerController_PlayerTick; set => bfield_PlayerTick = value; } PlayerTick_del bfield_PlayerTick;
	public virtual PlayerTick_del global_PlayerTick => PlayerController_PlayerTick;
	public /*event */void PlayerController_PlayerTick(float DeltaTime)
	{
		if(!bShortConnectTimeOut)
		{
			bShortConnectTimeOut = true;
			ServerShortTimeout();
		}
		if(Pawn != AcknowledgedPawn)
		{
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				if((AcknowledgedPawn != default) && AcknowledgedPawn.Controller == this)
				{
					AcknowledgedPawn.Controller = default;
				}
			}
			AcknowledgePossession(Pawn);
		}
		PlayerInput.PlayerInput_(DeltaTime);
		if(bUpdatePosition)
		{
			ClientUpdatePosition();
		}
		PlayerMove(DeltaTime);
		AdjustFOV(DeltaTime);
	}
	
	public delegate void PlayerMove_del(float DeltaTime);
	public virtual PlayerMove_del PlayerMove { get => bfield_PlayerMove ?? PlayerController_PlayerMove; set => bfield_PlayerMove = value; } PlayerMove_del bfield_PlayerMove;
	public virtual PlayerMove_del global_PlayerMove => PlayerController_PlayerMove;
	public /*function */void PlayerController_PlayerMove(float DeltaTime)
	{
	
	}
	
	public virtual /*function */bool AimingHelp(bool bInstantHit)
	{
		return (((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/)) && bAimingHelp;
	}
	
	public virtual /*event */void CameraLookAtFinished(SeqAct_CameraLookAt Action)
	{
	
	}
	
	public override GetAdjustedAimFor_del GetAdjustedAimFor { get => bfield_GetAdjustedAimFor ?? PlayerController_GetAdjustedAimFor; set => bfield_GetAdjustedAimFor = value; } GetAdjustedAimFor_del bfield_GetAdjustedAimFor;
	public override GetAdjustedAimFor_del global_GetAdjustedAimFor => PlayerController_GetAdjustedAimFor;
	public /*function */Object.Rotator PlayerController_GetAdjustedAimFor(Weapon W, Object.Vector StartFireLoc)
	{
		/*local */Object.Vector FireDir = default, AimSpot = default, HitLocation = default, HitNormal = default, OldAim = default, AimOffset = default;
	
		/*local */Actor BestTarget = default, HitActor = default;
		/*local */float bestAim = default, bestDist = default;
		/*local */bool bNoZAdjust = default, bInstantHit = default;
		/*local */Object.Rotator BaseAimRot = default, AimRot = default;
	
		bInstantHit = (W == default) || W.bInstantHit;
		BaseAimRot = ((Pawn != default) ? Pawn.GetBaseAimRotation() : Rotation);
		FireDir = ((Vector)(BaseAimRot));
		HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, StartFireLoc + (W.GetTraceRange() * FireDir), StartFireLoc, true, default(Object.Vector), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, default(int));
		if((HitActor != default) && HitActor.bProjTarget)
		{
			BestTarget = HitActor;
			bNoZAdjust = true;
			OldAim = HitLocation;
			bestDist = VSize(BestTarget.Location - Pawn.Location);		
		}
		else
		{
			bestAim = 0.90f;
			if(AimingHelp(bInstantHit))
			{
				bestAim = AimHelpDot(bInstantHit);			
			}
			else
			{
				if(bInstantHit)
				{
					bestAim = 1.0f;
				}
			}
			BestTarget = PickTarget(ClassT<Pawn>(), ref/*probably?*/ bestAim, ref/*probably?*/ bestDist, FireDir, StartFireLoc, W.WeaponRange);
			if(BestTarget == default)
			{
				return BaseAimRot;
			}
			OldAim = StartFireLoc + (FireDir * bestDist);
		}
		ShotTarget = ((BestTarget) as Pawn);
		if(!AimingHelp(bInstantHit))
		{
			return BaseAimRot;
		}
		FireDir = BestTarget.Location - StartFireLoc;
		AimSpot = StartFireLoc + (bestDist * Normal(FireDir));
		AimOffset = AimSpot - OldAim;
		if(ShotTarget != default)
		{
			if(bNoZAdjust)
			{
				AimSpot.Z = OldAim.Z;			
			}
			else
			{
				if(AimOffset.Z < ((float)(0)))
				{
					AimSpot.Z = ShotTarget.Location.Z + (0.40f * ShotTarget.CylinderComponent.CollisionHeight);				
				}
				else
				{
					AimSpot.Z = ShotTarget.Location.Z - (0.70f * ShotTarget.CylinderComponent.CollisionHeight);
				}
			}		
		}
		else
		{
			AimSpot.Z = OldAim.Z;
		}
		if(!bNoZAdjust)
		{
			AimRot = ((Rotator)(AimSpot - StartFireLoc));
			if(FOVAngle < (DefaultFOV - ((float)(8))))
			{
				AimRot.Yaw = (AimRot.Yaw + 200) - Rand(400);			
			}
			else
			{
				AimRot.Yaw = (AimRot.Yaw + 375) - Rand(750);
			}
			return AimRot;
		}
		return ((Rotator)(AimSpot - StartFireLoc));
	}
	
	public virtual /*function */float AimHelpDot(bool bInstantHit)
	{
		if(FOVAngle < (DefaultFOV - ((float)(8))))
		{
			return 0.990f;
		}
		if(bInstantHit)
		{
			return 0.970f;
		}
		return 0.930f;
	}
	
	public override NotifyLanded_del NotifyLanded { get => bfield_NotifyLanded ?? PlayerController_NotifyLanded; set => bfield_NotifyLanded = value; } NotifyLanded_del bfield_NotifyLanded;
	public override NotifyLanded_del global_NotifyLanded => PlayerController_NotifyLanded;
	public /*event */bool PlayerController_NotifyLanded(Object.Vector HitNormal, Actor FloorActor)
	{
		return bUpdating;
	}
	
	public virtual /*function */void AdjustFOV(float DeltaTime)
	{
		if(FOVAngle != DesiredFOV)
		{
			if(FOVAngle > DesiredFOV)
			{
				FOVAngle = FOVAngle - FMax(7.0f, (0.90f * DeltaTime) * (FOVAngle - DesiredFOV));			
			}
			else
			{
				FOVAngle = FOVAngle - FMin(-7.0f, (0.90f * DeltaTime) * (FOVAngle - DesiredFOV));
			}
			if(Abs(FOVAngle - DesiredFOV) <= ((float)(10)))
			{
				FOVAngle = DesiredFOV;
			}
		}
	}
	
	public virtual /*event */float GetFOVAngle()
	{
		return ((PlayerCamera != default) ? PlayerCamera.GetFOVAngle() : FOVAngle);
	}
	
	// Export UPlayerController::execIsLocalPlayerController(FFrame&, void* const)
	public override /*native function */bool IsLocalPlayerController()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPlayerController::execSetViewTarget(FFrame&, void* const)
	public virtual /*native function */void SetViewTarget(Actor NewViewTarget, /*optional */Camera.ViewTargetTransitionParams TransitionParams = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void ClientSetViewTarget_del(Actor A, /*optional */Camera.ViewTargetTransitionParams TransitionParams = default);
	public virtual ClientSetViewTarget_del ClientSetViewTarget { get => bfield_ClientSetViewTarget ?? PlayerController_ClientSetViewTarget; set => bfield_ClientSetViewTarget = value; } ClientSetViewTarget_del bfield_ClientSetViewTarget;
	public virtual ClientSetViewTarget_del global_ClientSetViewTarget => PlayerController_ClientSetViewTarget;
	public /*reliable client simulated event */void PlayerController_ClientSetViewTarget(Actor A, /*optional */Camera.ViewTargetTransitionParams TransitionParams = default)
	{
		if(A == default)
		{
			ServerVerifyViewTarget();
		}
		SetViewTarget(A, TransitionParams);
	}
	
	// Export UPlayerController::execGetViewTarget(FFrame&, void* const)
	public virtual /*native function */Actor GetViewTarget()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*reliable server function */void ServerVerifyViewTarget()
	{
		/*local */Actor TheViewTarget = default;
	
		TheViewTarget = GetViewTarget();
		if(TheViewTarget == this)
		{
			return;
		}
		ClientSetViewTarget(TheViewTarget, default(Camera.ViewTargetTransitionParams));
	}
	
	public virtual /*event */void SpawnPlayerCamera()
	{
		if((CameraClass != default) && IsLocalPlayerController())
		{
			PlayerCamera = Spawn(CameraClass, this, default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
			if(PlayerCamera != default)
			{
				PlayerCamera.InitializeFor(this);			
			}		
		}
	}
	
	public override /*simulated event */void GetPlayerViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
		/*local */Actor TheViewTarget = default;
	
		if(PlayerCamera == default)
		{
			if(CameraClass != default)
			{
				PlayerCamera = Spawn(CameraClass, this, default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
				if(PlayerCamera != default)
				{
					PlayerCamera.InitializeFor(this);				
				}
			}
		}
		if(PlayerCamera != default)
		{
			PlayerCamera.GetCameraViewPoint(ref/*probably?*/ out_Location, ref/*probably?*/ out_Rotation);		
		}
		else
		{
			TheViewTarget = GetViewTarget();
			if(TheViewTarget != default)
			{
				out_Location = TheViewTarget.Location;
				out_Rotation = TheViewTarget.Rotation;			
			}
			else
			{
				base.GetPlayerViewPoint(ref/*probably?*/ out_Location, ref/*probably?*/ out_Rotation);
			}
		}
	}
	
	public virtual /*function */void ViewShake(float DeltaTime)
	{
	
	}
	
	public delegate void UpdateRotation_del(float DeltaTime);
	public virtual UpdateRotation_del UpdateRotation { get => bfield_UpdateRotation ?? PlayerController_UpdateRotation; set => bfield_UpdateRotation = value; } UpdateRotation_del bfield_UpdateRotation;
	public virtual UpdateRotation_del global_UpdateRotation => PlayerController_UpdateRotation;
	public /*function */void PlayerController_UpdateRotation(float DeltaTime)
	{
		/*local */Object.Rotator DeltaRot = default, NewRotation = default, ViewRotation = default;
	
		ViewRotation = Rotation;
		DesiredRotation = ViewRotation;
		DeltaRot.Yaw = ((int)(PlayerInput.aTurn));
		DeltaRot.Pitch = ((int)(PlayerInput.aLookUp));
		ProcessViewRotation(DeltaTime, ref/*probably?*/ ViewRotation, DeltaRot);
		SetRotation(ViewRotation);
		ViewShake(DeltaTime);
		NewRotation = ViewRotation;
		NewRotation.Roll = Rotation.Roll;
		if(Pawn != default)
		{
			Pawn.FaceRotation(NewRotation, DeltaTime);
		}
	}
	
	public virtual /*function */void ProcessViewRotation(float DeltaTime, ref Object.Rotator out_ViewRotation, Object.Rotator DeltaRot)
	{
		if(PlayerCamera != default)
		{
			PlayerCamera.ProcessViewRotation(DeltaTime, ref/*probably?*/ out_ViewRotation, ref/*probably?*/ DeltaRot);
		}
		if(Pawn != default)
		{
			Pawn.ProcessViewRotation(DeltaTime, ref/*probably?*/ out_ViewRotation, ref/*probably?*/ DeltaRot);		
		}
		else
		{
			out_ViewRotation += DeltaRot;
			out_ViewRotation = LimitViewRotation(out_ViewRotation, -16384.0f, 16383.0f);
		}
	}
	
	public virtual /*event */Object.Rotator LimitViewRotation(Object.Rotator ViewRotation, float ViewPitchMin, float ViewPitchMax)
	{
		ViewRotation.Pitch = ViewRotation.Pitch & 65535;
		if((((float)(ViewRotation.Pitch)) > ViewPitchMax) && ((float)(ViewRotation.Pitch)) < (((float)(65535)) + ViewPitchMin))
		{
			if(ViewRotation.Pitch < 32768)
			{
				ViewRotation.Pitch = ((int)(ViewPitchMax));			
			}
			else
			{
				ViewRotation.Pitch = ((int)(((float)(65535)) + ViewPitchMin));
			}
		}
		return ViewRotation;
	}
	
	public virtual /*function */void ClearDoubleClick()
	{
		if(PlayerInput != default)
		{
			PlayerInput.DoubleClickTimer = 0.0f;
		}
	}
	
	public virtual /*function */void CheckJumpOrDuck()
	{
		if(bPressedJump && Pawn != default)
		{
			Pawn.DoJump(bUpdating);
		}
	}
	
	public override IsSpectating_del IsSpectating { get => bfield_IsSpectating ?? PlayerController_IsSpectating; set => bfield_IsSpectating = value; } IsSpectating_del bfield_IsSpectating;
	public override IsSpectating_del global_IsSpectating => PlayerController_IsSpectating;
	public /*function */bool PlayerController_IsSpectating()
	{
		return false;
	}
	
	public delegate void ServerSetSpectatorLocation_del(Object.Vector NewLoc);
	public virtual ServerSetSpectatorLocation_del ServerSetSpectatorLocation { get => bfield_ServerSetSpectatorLocation ?? PlayerController_ServerSetSpectatorLocation; set => bfield_ServerSetSpectatorLocation = value; } ServerSetSpectatorLocation_del bfield_ServerSetSpectatorLocation;
	public virtual ServerSetSpectatorLocation_del global_ServerSetSpectatorLocation => PlayerController_ServerSetSpectatorLocation;
	public /*unreliable server function */void PlayerController_ServerSetSpectatorLocation(Object.Vector NewLoc)
	{
		ClientGotoState(GetStateName(), default(name));
	}
	
	public delegate void ServerViewNextPlayer_del();
	public virtual ServerViewNextPlayer_del ServerViewNextPlayer { get => bfield_ServerViewNextPlayer ?? PlayerController_ServerViewNextPlayer; set => bfield_ServerViewNextPlayer = value; } ServerViewNextPlayer_del bfield_ServerViewNextPlayer;
	public virtual ServerViewNextPlayer_del global_ServerViewNextPlayer => PlayerController_ServerViewNextPlayer;
	public /*unreliable server function */void PlayerController_ServerViewNextPlayer()
	{
		if(IsSpectating())
		{
			ViewAPlayer(1);
		}
	}
	
	public virtual /*unreliable server function */void ServerViewPrevPlayer()
	{
		if(IsSpectating())
		{
			ViewAPlayer(-1);
		}
	}
	
	public virtual /*function */bool ViewAPlayer(int Dir)
	{
		/*local */int I = default, CurrentIndex = default, NewIndex = default;
		/*local */PlayerReplicationInfo PRI = default;
		/*local */bool bSuccess = default;
	
		CurrentIndex = -1;
		if(RealViewTarget != default)
		{
			I = 0;
			J0x1D:{}
			if(I < WorldInfo.GRI.PRIArray.Length)
			{
				if(RealViewTarget == WorldInfo.GRI.PRIArray[I])
				{
					CurrentIndex = I;
					goto J0x82;
				}
				++ I;
				goto J0x1D;
			}
		}
		J0x82:{}
		NewIndex = CurrentIndex + Dir;
		J0x94:{}
		if((NewIndex >= 0) && NewIndex < WorldInfo.GRI.PRIArray.Length)
		{
			PRI = WorldInfo.GRI.PRIArray[NewIndex];
			if((((PRI != default) && ((PRI.Owner) as Controller) != default) && ((PRI.Owner) as Controller).Pawn != default) && WorldInfo.Game.CanSpectate(this, PRI))
			{
				bSuccess = true;
				goto J0x180;
			}
			NewIndex = NewIndex + Dir;
			goto J0x94;
		}
		J0x180:{}
		if(!bSuccess)
		{
			CurrentIndex = ((NewIndex < 0) ? WorldInfo.GRI.PRIArray.Length : -1);
			NewIndex = CurrentIndex + Dir;
			J0x1CF:{}
			if((NewIndex >= 0) && NewIndex < WorldInfo.GRI.PRIArray.Length)
			{
				PRI = WorldInfo.GRI.PRIArray[NewIndex];
				if((((PRI != default) && ((PRI.Owner) as Controller) != default) && ((PRI.Owner) as Controller).Pawn != default) && WorldInfo.Game.CanSpectate(this, PRI))
				{
					bSuccess = true;
					goto J0x2BB;
				}
				NewIndex = NewIndex + Dir;
				goto J0x1CF;
			}
		}
		J0x2BB:{}
		if(bSuccess)
		{
			SetViewTarget(PRI, default(Camera.ViewTargetTransitionParams));
		}
		return bSuccess;
	}
	
	public virtual /*unreliable server function */void ServerViewSelf()
	{
		if(IsSpectating())
		{
			ResetCameraMode();
			SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
			ClientSetViewTarget(this, default(Camera.ViewTargetTransitionParams));
			ClientMessage(OwnCamera, "Event", default(float));
		}
	}
	
	public virtual /*function */bool CanRestartPlayer()
	{
		return ((PlayerReplicationInfo != default) && !PlayerReplicationInfo.bOnlySpectator) && HasClientLoadedCurrentWorld();
	}
	
	public virtual /*function */void DrawHUD(HUD H)
	{
		if(Pawn != default)
		{
			Pawn.DrawHUD(H);
		}
		PlayerInput.DrawHUD(H);
	}
	
	public virtual /*function */void OnToggleInput(SeqAct_ToggleInput inAction)
	{
		/*local */bool bNewValue = default;
	
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return;
		}
		if(inAction.InputLinks[0].bHasImpulse)
		{
			if(inAction.bToggleMovement)
			{
				IgnoreMoveInput(false);
				ClientIgnoreMoveInput(false);
			}
			if(inAction.bToggleTurning)
			{
				IgnoreLookInput(false);
				ClientIgnoreLookInput(false);
			}		
		}
		else
		{
			if(inAction.InputLinks[1].bHasImpulse)
			{
				if(inAction.bToggleMovement)
				{
					IgnoreMoveInput(true);
					ClientIgnoreMoveInput(true);
				}
				if(inAction.bToggleTurning)
				{
					IgnoreLookInput(true);
					ClientIgnoreLookInput(true);
				}			
			}
			else
			{
				if(inAction.InputLinks[2].bHasImpulse)
				{
					if(inAction.bToggleMovement)
					{
						bNewValue = !IsMoveInputIgnored();
						IgnoreMoveInput(bNewValue);
						ClientIgnoreMoveInput(bNewValue);
					}
					if(inAction.bToggleTurning)
					{
						bNewValue = !IsLookInputIgnored();
						IgnoreLookInput(bNewValue);
						ClientIgnoreLookInput(bNewValue);
					}
				}
			}
		}
	}
	
	public virtual /*reliable client simulated function */void ClientIgnoreMoveInput(bool bIgnore)
	{
		IgnoreMoveInput(bIgnore);
	}
	
	public virtual /*reliable client simulated function */void ClientIgnoreLookInput(bool bIgnore)
	{
		IgnoreLookInput(bIgnore);
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		base.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		if(HUD.ShouldDisplayDebug("Camera"))
		{
			if(PlayerCamera != default)
			{
				PlayerCamera.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);			
			}
			else
			{
				HUD.Canvas.SetDrawColor(255, 0, 0, (byte)default(byte));
				HUD.Canvas.DrawText("NO CAMERA", default(bool), default(float), default(float));
				out_YPos += out_YL;
				HUD.Canvas.SetPos(4.0f, out_YPos);
			}
		}
		if(HUD.ShouldDisplayDebug("Input"))
		{
			HUD.Canvas.SetDrawColor(255, 0, 0, (byte)default(byte));
			HUD.Canvas.DrawText((((("Input ignoremove " + ((bIgnoreMoveInput)).ToString()) + " ignore look ") + ((bIgnoreLookInput)).ToString()) + " aForward ") + ((PlayerInput.aForward)).ToString(), default(bool), default(float), default(float));
			out_YPos += out_YL;
			HUD.Canvas.SetPos(4.0f, out_YPos);
		}
	}
	
	public virtual /*simulated function */void OnSetCameraTarget(SeqAct_SetCameraTarget inAction)
	{
		/*local */Actor RealCameraTarget = default;
	
		RealCameraTarget = inAction.CameraTarget;
		if(((RealCameraTarget) as Controller) != default)
		{
			RealCameraTarget = ((RealCameraTarget) as Controller).Pawn;
		}
		SetViewTarget(RealCameraTarget, inAction.TransitionParams);
	}
	
	public virtual /*simulated function */void OnToggleHUD(SeqAct_ToggleHUD inAction)
	{
		if(myHUD != default)
		{
			if(inAction.InputLinks[0].bHasImpulse)
			{
				myHUD.bShowHUD = true;			
			}
			else
			{
				if(inAction.InputLinks[1].bHasImpulse)
				{
					myHUD.bShowHUD = false;				
				}
				else
				{
					if(inAction.InputLinks[2].bHasImpulse)
					{
						myHUD.bShowHUD = !myHUD.bShowHUD;
					}
				}
			}
		}
	}
	
	public virtual /*unreliable server function */void ServerCauseEvent(name EventName)
	{
		/*local */array<SequenceObject> AllConsoleEvents = default;
		/*local */SeqEvent_Console ConsoleEvt = default;
		/*local */Sequence GameSeq = default;
		/*local */int Idx = default;
		/*local */bool bFoundEvt = default;
	
		GameSeq = WorldInfo.GetGameSequence();
		if(GameSeq != default)
		{
			GameSeq.FindSeqObjectsByClass(ClassT<SeqEvent_Console>(), true, ref/*probably?*/ AllConsoleEvents);
			Idx = 0;
			J0x43:{}
			if(Idx < AllConsoleEvents.Length)
			{
				ConsoleEvt = ((AllConsoleEvents[Idx]) as SeqEvent_Console);
				if((ConsoleEvt != default) && EventName == ConsoleEvt.ConsoleEventName)
				{
					bFoundEvt = true;
					ConsoleEvt.CheckActivate(this, Pawn, default(bool), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool));
				}
				++ Idx;
				goto J0x43;
			}
		}
		if(!bFoundEvt)
		{
			ListConsoleEvents();
		}
	}
	
	public virtual /*exec function */void CauseEvent(name EventName)
	{
		ServerCauseEvent(EventName);
	}
	
	public virtual /*exec function */void CE(name EventName)
	{
		ServerCauseEvent(EventName);
	}
	
	public virtual /*exec function */void ListConsoleEvents()
	{
		/*local */array<SequenceObject> ConsoleEvents = default;
		/*local */SeqEvent_Console ConsoleEvt = default;
		/*local */Sequence GameSeq = default;
		/*local */int Idx = default;
	
		GameSeq = WorldInfo.GetGameSequence();
		if(GameSeq != default)
		{
			ClientMessage("Console events:", default(name), 15.0f);
			GameSeq.FindSeqObjectsByClass(ClassT<SeqEvent_Console>(), true, ref/*probably?*/ ConsoleEvents);
			Idx = 0;
			J0x64:{}
			if(Idx < ConsoleEvents.Length)
			{
				ConsoleEvt = ((ConsoleEvents[Idx]) as SeqEvent_Console);
				if((ConsoleEvt != default) && ConsoleEvt.bEnabled)
				{
					ClientMessage(("-" + " " + ((ConsoleEvt.ConsoleEventName)).ToString()) + " " + ConsoleEvt.EventDesc, default(name), 15.0f);
				}
				++ Idx;
				goto J0x64;
			}
		}
	}
	
	public virtual /*exec function */void ListCE()
	{
		ListConsoleEvents();
	}
	
	public override /*function */void NotifyTakeHit(Controller InstigatedBy, Object.Vector HitLocation, int Damage, Core.ClassT<DamageType> DamageType, Object.Vector Momentum)
	{
		base.NotifyTakeHit(InstigatedBy, HitLocation, Damage, DamageType, Momentum);
		ClientPlayForceFeedbackWaveform(DamageType.DefaultAs<DamageType>().DamagedFFWaveform);
	}
	
	public virtual /*function */void OnForceFeedback(SeqAct_ForceFeedback Action)
	{
		if(Action.InputLinks[0].bHasImpulse)
		{
			ClientPlayForceFeedbackWaveform(Action.FFWaveform);		
		}
		else
		{
			if(Action.InputLinks[1].bHasImpulse)
			{
				ClientStopForceFeedbackWaveform(Action.FFWaveform);
			}
		}
	}
	
	public virtual /*reliable client final simulated function */void ClientPlayForceFeedbackWaveform(ForceFeedbackWaveform FFWaveform)
	{
		if((PlayerInput != default) && !PlayerInput.bUsingGamepad)
		{
			return;
		}
		if(((ForceFeedbackManager != default) && PlayerReplicationInfo != default) && PlayerReplicationInfo.bControllerVibrationAllowed)
		{
			ForceFeedbackManager.PlayForceFeedbackWaveform(FFWaveform);
		}
	}
	
	public virtual /*reliable client final simulated function */void ClientStopForceFeedbackWaveform(/*optional */ForceFeedbackWaveform FFWaveform = default)
	{
		if(ForceFeedbackManager != default)
		{
			ForceFeedbackManager.StopForceFeedbackWaveform(FFWaveform);
		}
	}
	
	public virtual /*function */void CameraShake(float Duration, Object.Vector newRotAmplitude, Object.Vector newRotFrequency, Object.Vector newLocAmplitude, Object.Vector newLocFrequency, float newFOVAmplitude, float newFOVFrequency)
	{
	
	}
	
	public virtual /*function */void OnToggleCinematicMode(SeqAct_ToggleCinematicMode Action)
	{
		/*local */bool bNewCinematicMode = default;
	
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return;
		}
		if(Action.InputLinks[0].bHasImpulse)
		{
			bNewCinematicMode = true;		
		}
		else
		{
			if(Action.InputLinks[1].bHasImpulse)
			{
				bNewCinematicMode = false;			
			}
			else
			{
				if(Action.InputLinks[2].bHasImpulse)
				{
					bNewCinematicMode = !bCinematicMode;
				}
			}
		}
		SetCinematicMode(bNewCinematicMode, Action.bHidePlayer, Action.bHideHUD, Action.bDisableMovement, Action.bDisableTurning, Action.bDisableInput, Action.bSwitchSoundMode);
	}
	
	public virtual /*function */void SetCinematicMode(bool bInCinematicMode, bool bHidePlayer, bool bAffectsHUD, bool bAffectsMovement, bool bAffectsTurning, bool bAffectsButtons, bool bSwitchSoundMode)
	{
		/*local */bool bAdjustMoveInput = default, bAdjustLookInput = default;
	
		bCinematicMode = bInCinematicMode;
		if(bCinematicMode)
		{
			if((Pawn != default) && bHidePlayer)
			{
				Pawn.SetHidden(true);
			}		
		}
		else
		{
			if(Pawn != default)
			{
				Pawn.SetHidden(false);
			}
		}
		bAdjustMoveInput = bAffectsMovement && bCinematicMode != bCinemaDisableInputMove;
		bAdjustLookInput = bAffectsTurning && bCinematicMode != bCinemaDisableInputLook;
		if(bAdjustMoveInput)
		{
			IgnoreMoveInput(bCinematicMode);
			bCinemaDisableInputMove = bCinematicMode;
		}
		if(bAdjustLookInput)
		{
			IgnoreLookInput(bCinematicMode);
			bCinemaDisableInputLook = bCinematicMode;
		}
		ClientSetCinematicMode(bCinematicMode, bAdjustMoveInput, bAdjustLookInput, bAffectsHUD);
	}
	
	public virtual /*reliable client simulated function */void ClientSetCinematicMode(bool bInCinematicMode, bool bAffectsMovement, bool bAffectsTurning, bool bAffectsHUD)
	{
		bCinematicMode = bInCinematicMode;
		if((myHUD != default) && bAffectsHUD)
		{
			myHUD.bShowHUD = !bCinematicMode;
		}
		if(bAffectsMovement)
		{
			IgnoreMoveInput(bCinematicMode);
		}
		if(bAffectsTurning)
		{
			IgnoreLookInput(bCinematicMode);
		}
	}
	
	public virtual /*function */void IgnoreMoveInput(bool bNewMoveInput)
	{
		bIgnoreMoveInput = (byte)((byte)(Max(((int)bIgnoreMoveInput) + ((bNewMoveInput) ? 1 : -1), 0)));
	}
	
	public virtual /*function */bool IsMoveInputIgnored()
	{
		return ((int)bIgnoreMoveInput) > ((int)0);
	}
	
	public virtual /*function */void IgnoreLookInput(bool bNewLookInput)
	{
		bIgnoreLookInput = (byte)((byte)(Max(((int)bIgnoreLookInput) + ((bNewLookInput) ? 1 : -1), 0)));
	}
	
	public virtual /*function */bool IsLookInputIgnored()
	{
		return ((int)bIgnoreLookInput) > ((int)0);
	}
	
	public virtual /*function */void ResetPlayerMovementInput()
	{
		bIgnoreMoveInput = (byte)DefaultAs<PlayerController>().bIgnoreMoveInput;
		bIgnoreLookInput = (byte)DefaultAs<PlayerController>().bIgnoreLookInput;
	}
	
	public virtual /*function */void OnConsoleCommand(SeqAct_ConsoleCommand inAction)
	{
		ConsoleCommand(inAction.Command, default(bool));
	}
	
	public virtual /*reliable client simulated event */void ClientForceGarbageCollection()
	{
		WorldInfo.ForceGarbageCollection(default(bool));
	}
	
	public virtual /*event */void LevelStreamingStatusChanged(LevelStreaming LevelObject, bool bNewShouldBeLoaded, bool bNewShouldBeVisible, bool bNewShouldBlockOnLoad)
	{
		ClientUpdateLevelStreamingStatus(LevelObject.PackageName, bNewShouldBeLoaded, bNewShouldBeVisible, bNewShouldBlockOnLoad);
	}
	
	// Export UPlayerController::execClientUpdateLevelStreamingStatus(FFrame&, void* const)
	public virtual /*reliable client native final simulated function */void ClientUpdateLevelStreamingStatus(name PackageName, bool bNewShouldBeLoaded, bool bNewShouldBeVisible, bool bNewShouldBlockOnLoad)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execServerUpdateLevelVisibility(FFrame&, void* const)
	public virtual /*reliable server native final event */void ServerUpdateLevelVisibility(name PackageName, bool bIsVisible)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*reliable client simulated event */void ClientPrepareMapChange(name LevelName, bool bFirst, bool bLast)
	{
		/*local */PlayerController PC = default;
	
		
		// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			if(PC != this)
			{			
				return;
				continue;
			}
			break;		
		}	
		if(bFirst)
		{
			PendingMapChangeLevelNames.Length = 0;
			ClearTimer("DelayedPrepareMapChange", default(Object));
		}
		PendingMapChangeLevelNames[PendingMapChangeLevelNames.Length] = LevelName;
		if(bLast)
		{
			DelayedPrepareMapChange();
		}
	}
	
	public virtual /*function */void DelayedPrepareMapChange()
	{
		if(WorldInfo.IsPreparingMapChange())
		{
			SetTimer(0.010f, false, "DelayedPrepareMapChange", default(Object));		
		}
		else
		{
			WorldInfo.PrepareMapChange(ref/*probably?*/ PendingMapChangeLevelNames);
		}
	}
	
	public virtual /*reliable client simulated event */void ClientCommitMapChange(/*optional */bool bShouldSkipLevelStartupEvent = default, /*optional */bool bShouldSkipLevelBeginningEvent = default)
	{
		if(Pawn != default)
		{
			SetViewTarget(Pawn, default(Camera.ViewTargetTransitionParams));		
		}
		else
		{
			SetViewTarget(this, default(Camera.ViewTargetTransitionParams));
		}
		WorldInfo.CommitMapChange(bShouldSkipLevelStartupEvent, bShouldSkipLevelBeginningEvent);
	}
	
	// Export UPlayerController::execClientFlushLevelStreaming(FFrame&, void* const)
	public virtual /*reliable client native final simulated event */void ClientFlushLevelStreaming()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*reliable client simulated event */void ClientSetBlockOnAsyncLoading()
	{
		WorldInfo.bRequestedBlockOnAsyncLoading = true;
	}
	
	public virtual /*exec function */void SaveClassConfig(/*coerce */string ClassName)
	{
		/*local */Class saveClass = default;
	
		saveClass = ((DynamicLoadObject(ClassName, ClassT<Class>(), default(bool))) as ClassT<Object>) as Class;
		if(saveClass != default)
		{
			saveClass.Static.StaticSaveConfig();
		}
	}
	
	public virtual /*exec function */void SaveActorConfig(/*coerce */name actorName)
	{
		/*local */Actor chkActor = default;
	
		
		// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ chkActor)
		using var e0 = AllActors(ClassT<Actor>()).GetEnumerator();
		while(e0.MoveNext() && (chkActor = (Actor)e0.Current) == chkActor)
		{
			if((chkActor != default) && chkActor.Name == actorName)
			{
				chkActor.SaveConfig();
			}		
		}	
	}
	
	public virtual /*final function */UIInteraction GetUIController()
	{
		/*local */LocalPlayer LP = default;
		/*local */UIInteraction Result = default;
	
		LP = ((Player) as LocalPlayer);
		if((LP != default) && LP.Outer.GameViewport != default)
		{
			Result = LP.Outer.GameViewport.UIController;
		}
		return Result;
	}
	
	// Export UPlayerController::execIsPlayerMuted(FFrame&, void* const)
	public virtual /*native final function */bool IsPlayerMuted(/*const */ref OnlineSubsystem.UniqueNetId Sender)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */void GetSeamlessTravelActorList(bool bToEntry, ref array<Actor> ActorList)
	{
		HearSoundActiveComponents.Length = 0;
		HearSoundPoolComponents.Length = 0;
		if(myHUD != default)
		{
			ActorList[ActorList.Length] = myHUD;
			if(myHUD.ScoreBoard != default)
			{
				ActorList[ActorList.Length] = myHUD.ScoreBoard;
			}
		}
	}
	
	public virtual /*function */void SeamlessTravelTo(PlayerController NewPC)
	{
	
	}
	
	public virtual /*function */void SeamlessTravelFrom(PlayerController OldPC)
	{
		OldPC.PlayerReplicationInfo.Reset();
		OldPC.PlayerReplicationInfo.SeamlessTravelTo(PlayerReplicationInfo);
		OldPC.bIsPlayer = false;
		OldPC.PlayerReplicationInfo.Destroy();
		OldPC.PlayerReplicationInfo = default;
	}
	
	public virtual /*reliable client simulated function */void ClientSetOnlineStatus()
	{
	
	}
	
	// Export UPlayerController::execGetPlayerControllerFromNetId(FFrame&, void* const)
	public /*native function */static PlayerController GetPlayerControllerFromNetId(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*reliable client simulated event */void ClientMutePlayer(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		/*local */LocalPlayer LocPlayer = default;
	
		if(NotEqual_InterfaceInterface(VoiceInterface, (default(OnlineVoiceInterface))))
		{
			LocPlayer = ((Player) as LocalPlayer);
			if(LocPlayer != default)
			{
				VoiceInterface.MuteRemoteTalker((byte)((byte)(LocPlayer.ControllerId)), PlayerNetId);
			}
		}
	}
	
	public virtual /*reliable client simulated event */void ClientUnmutePlayer(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		/*local */LocalPlayer LocPlayer = default;
	
		if(NotEqual_InterfaceInterface(VoiceInterface, (default(OnlineVoiceInterface))))
		{
			LocPlayer = ((Player) as LocalPlayer);
			if(LocPlayer != default)
			{
				VoiceInterface.UnmuteRemoteTalker((byte)((byte)(LocPlayer.ControllerId)), PlayerNetId);
			}
		}
	}
	
	public virtual /*function */void GameplayMutePlayer(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		if(GameplayVoiceMuteList.Find("Uid", PlayerNetId.Uid) == -1)
		{
			GameplayVoiceMuteList[GameplayVoiceMuteList.Length] = PlayerNetId;
		}
		if(VoicePacketFilter.Find("Uid", PlayerNetId.Uid) == -1)
		{
			VoicePacketFilter[VoicePacketFilter.Length] = PlayerNetId;
		}
		ClientMutePlayer(PlayerNetId);
	}
	
	public virtual /*function */void GameplayUnmutePlayer(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		/*local */int RemoveIndex = default;
		/*local */PlayerController Other = default;
	
		RemoveIndex = GameplayVoiceMuteList.Find("Uid", PlayerNetId.Uid);
		if(RemoveIndex != -1)
		{
			GameplayVoiceMuteList.Remove(RemoveIndex, 1);
		}
		Other = GetPlayerControllerFromNetId(PlayerNetId);
		if(Other != default)
		{
			if((VoiceMuteList.Find("Uid", PlayerNetId.Uid) == -1) && Other.VoiceMuteList.Find("Uid", PlayerReplicationInfo.UniqueId.Uid) == -1)
			{
				RemoveIndex = VoicePacketFilter.Find("Uid", PlayerNetId.Uid);
				if(RemoveIndex != -1)
				{
					VoicePacketFilter.Remove(RemoveIndex, 1);
				}
			}
			ClientUnmutePlayer(PlayerNetId);
		}
	}
	
	public virtual /*reliable server event */void ServerMutePlayer(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		/*local */PlayerController Other = default;
	
		if(VoiceMuteList.Find("Uid", PlayerNetId.Uid) == -1)
		{
			VoiceMuteList[VoiceMuteList.Length] = PlayerNetId;
		}
		if(VoicePacketFilter.Find("Uid", PlayerNetId.Uid) == -1)
		{
			VoicePacketFilter[VoicePacketFilter.Length] = PlayerNetId;
		}
		ClientMutePlayer(PlayerNetId);
		Other = GetPlayerControllerFromNetId(PlayerNetId);
		if(Other != default)
		{
			if(Other.VoicePacketFilter.Find("Uid", PlayerReplicationInfo.UniqueId.Uid) == -1)
			{
				Other.VoicePacketFilter[Other.VoicePacketFilter.Length] = PlayerReplicationInfo.UniqueId;
			}
			Other.ClientMutePlayer(PlayerReplicationInfo.UniqueId);
		}
	}
	
	public virtual /*reliable server event */void ServerUnmutePlayer(OnlineSubsystem.UniqueNetId PlayerNetId)
	{
		/*local */PlayerController Other = default;
		/*local */int RemoveIndex = default;
	
		RemoveIndex = VoiceMuteList.Find("Uid", PlayerNetId.Uid);
		if(RemoveIndex != -1)
		{
			VoiceMuteList.Remove(RemoveIndex, 1);
		}
		if(GameplayVoiceMuteList.Find("Uid", PlayerNetId.Uid) == -1)
		{
			ClientUnmutePlayer(PlayerNetId);
		}
		Other = GetPlayerControllerFromNetId(PlayerNetId);
		if(Other != default)
		{
			if((Other.VoiceMuteList.Find("Uid", PlayerReplicationInfo.UniqueId.Uid) == -1) && Other.GameplayVoiceMuteList.Find("Uid", PlayerReplicationInfo.UniqueId.Uid) == -1)
			{
				RemoveIndex = VoicePacketFilter.Find("Uid", PlayerNetId.Uid);
				if(RemoveIndex != -1)
				{
					VoicePacketFilter.Remove(RemoveIndex, 1);
				}
				RemoveIndex = Other.VoicePacketFilter.Find("Uid", PlayerReplicationInfo.UniqueId.Uid);
				if(RemoveIndex != -1)
				{
					Other.VoicePacketFilter.Remove(RemoveIndex, 1);
				}
			}
			Other.ClientUnmutePlayer(PlayerReplicationInfo.UniqueId);
		}
	}
	
	public virtual /*event */void NotifyDirectorControl(bool bNowControlling)
	{
	
	}
	
	// Export UPlayerController::execSetShowSubtitles(FFrame&, void* const)
	public virtual /*native simulated function */void SetShowSubtitles(bool bValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPlayerController::execIsShowingSubtitles(FFrame&, void* const)
	public virtual /*native simulated function */bool IsShowingSubtitles()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void NotifyConnectionError(string Message, /*optional */string Title = default)
	{
		if(WorldInfo.Game != default)
		{
			WorldInfo.Game.bHasNetworkError = true;
		}
		ClientTravel("?failed", Actor.ETravelType.TRAVEL_Absolute/*0*/, default(bool), default(Object.Guid));
	}
	
	public virtual /*reliable client simulated event */void ClientWasKicked()
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientRegisterForArbitration()
	{
		if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
		{
			OnlineSub.GameInterface.AddArbitrationRegistrationCompleteDelegate(OnArbitrationRegisterComplete);
			OnlineSub.GameInterface.RegisterForArbitration();		
		}
		else
		{
			ServerRegisteredForArbitration(true);
		}
	}
	
	public virtual /*function */void OnArbitrationRegisterComplete(bool bWasSuccessful)
	{
		OnlineSub.GameInterface.ClearArbitrationRegistrationCompleteDelegate(OnArbitrationRegisterComplete);
		ServerRegisteredForArbitration(bWasSuccessful);
	}
	
	public virtual /*reliable server function */void ServerRegisteredForArbitration(bool bWasSuccessful)
	{
		WorldInfo.Game.ProcessClientRegistrationCompletion(this, bWasSuccessful);
	}
	
	public virtual /*reliable client simulated function */void ClientWriteArbitrationEndGameData(Core.ClassT<OnlineStatsWrite> OnlineStatsWriteClass)
	{
		if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
		{
			ClientWriteOnlinePlayerScores();
			OnlineSub.GameInterface.EndOnlineGame();
		}
		ServerWritenArbitrationEndGameData();
	}
	
	public virtual /*reliable server function */void ServerWritenArbitrationEndGameData()
	{
		WorldInfo.Game.ProcessClientDataWriteCompletion(this);
	}
	
	public virtual /*function */void OnGameInviteAccepted(OnlineGameSettings GameInviteSettings)
	{
		if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
		{
			if(GameInviteSettings != default)
			{
				if(InviteHasEnoughSpace(GameInviteSettings))
				{
					if(CanAllPlayersPlayOnline())
					{
						if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
						{
							WorldInfo.GRI.bNeedsOnlineCleanup = false;
							if(OnlineSub.GameInterface.GetGameSettings().bUsesArbitration)
							{
								ClientWriteOnlinePlayerScores();
							}
							OnlineSub.GameInterface.AddEndOnlineGameCompleteDelegate(OnEndForInviteComplete);
							OnlineSub.GameInterface.EndOnlineGame();						
						}
						else
						{
							OnlineSub.GameInterface.AddJoinOnlineGameCompleteDelegate(OnInviteJoinComplete);
							if(!OnlineSub.GameInterface.AcceptGameInvite((byte)((byte)(((Player) as LocalPlayer).ControllerId))))
							{
								OnlineSub.GameInterface.ClearJoinOnlineGameCompleteDelegate(OnInviteJoinComplete);
							}
						}					
					}
					else
					{
						NotifyNotAllPlayersCanJoinInvite();
					}				
				}
				else
				{
					NotifyNotEnoughSpaceInInvite();
				}			
			}
			else
			{
				NotifyInviteFailed();
			}
		}
	}
	
	public virtual /*function */bool InviteHasEnoughSpace(OnlineGameSettings InviteSettings)
	{
		/*local */int NumLocalPlayers = default;
		/*local */PlayerController PC = default;
	
		
		// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			++ NumLocalPlayers;		
		}	
		return (InviteSettings.NumOpenPrivateConnections + InviteSettings.NumOpenPublicConnections) >= NumLocalPlayers;
	}
	
	public virtual /*function */bool CanAllPlayersPlayOnline()
	{
		/*local */PlayerController PC = default;
		/*local */LocalPlayer LocPlayer = default;
	
		
		// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			LocPlayer = ((PC.Player) as LocalPlayer);
			if(LocPlayer != default)
			{
				if((((int)OnlineSub.PlayerInterface.GetLoginStatus(((byte)(LocPlayer.ControllerId)))) != ((int)OnlineSubsystem.ELoginStatus.LS_LoggedIn/*2*/)) || ((int)OnlineSub.PlayerInterface.CanPlayOnline(((byte)(LocPlayer.ControllerId)))) == ((int)0))
				{				
					return false;
				}
				continue;
			}		
			return false;		
		}	
		return true;
	}
	
	public virtual /*function */void ClearInviteDelegates()
	{
		OnlineSub.GameInterface.ClearEndOnlineGameCompleteDelegate(OnEndForInviteComplete);
		OnlineSub.GameInterface.ClearDestroyOnlineGameCompleteDelegate(OnDestroyForInviteComplete);
		OnlineSub.GameInterface.ClearJoinOnlineGameCompleteDelegate(OnInviteJoinComplete);
	}
	
	public virtual /*function */void OnEndForInviteComplete(bool bWasSuccessful)
	{
		OnlineSub.GameInterface.AddDestroyOnlineGameCompleteDelegate(OnDestroyForInviteComplete);
		OnlineSub.GameInterface.DestroyOnlineGame();
	}
	
	public virtual /*function */void OnDestroyForInviteComplete(bool bWasSuccessful)
	{
		if(bWasSuccessful)
		{
			OnlineSub.GameInterface.AddJoinOnlineGameCompleteDelegate(OnInviteJoinComplete);
			if(!OnlineSub.GameInterface.AcceptGameInvite((byte)((byte)(((Player) as LocalPlayer).ControllerId))))
			{
				OnlineSub.GameInterface.ClearJoinOnlineGameCompleteDelegate(OnInviteJoinComplete);
			}		
		}
		else
		{
			NotifyInviteFailed();
		}
	}
	
	public virtual /*function */void OnInviteJoinComplete(bool bWasSuccessful)
	{
		/*local */string URL = default, ConnectPassword = default;
	
		if(bWasSuccessful)
		{
			if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.GameInterface, (default(OnlineGameInterface))))
			{
				if(OnlineSub.GameInterface.GetResolvedConnectString(ref/*probably?*/ URL))
				{
					if(UIRoot.GetDataStoreStringValue("<Registry:ConnectPassword>", ref/*probably?*/ ConnectPassword, default(UIScene), default(LocalPlayer)) && ConnectPassword != "")
					{
						URL += ("?Password=" + ConnectPassword);
					}
					ConsoleCommand("open " + URL, default(bool));
				}
			}		
		}
		else
		{
			NotifyInviteFailed();
		}
		ClearInviteDelegates();
		UIRoot.SetDataStoreStringValue("<Registry:ConnectPassword>", "", default(UIScene), default(LocalPlayer));
	}
	
	public virtual /*function */void NotifyInviteFailed()
	{
		ClearInviteDelegates();
	}
	
	public virtual /*function */void NotifyNotAllPlayersCanJoinInvite()
	{
	
	}
	
	public virtual /*function */void NotifyNotEnoughSpaceInInvite()
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientArbitratedMatchEnded()
	{
		ConsoleCommand("Disconnect", default(bool));
	}
	
	public virtual /*reliable client simulated function */void ClientWriteOnlinePlayerScores()
	{
		/*local */GameReplicationInfo GRI = default;
		/*local */int Index = default;
		/*local */array<OnlineSubsystem.OnlinePlayerScore> PlayerScores = default;
		/*local */OnlineSubsystem.UniqueNetId ZeroUniqueId = default;
		/*local */bool bIsTeamGame = default;
		/*local */int ScoreIndex = default;
	
		GRI = WorldInfo.GRI;
		if(((GRI != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.StatsInterface, (default(OnlineStatsInterface))))
		{
			bIsTeamGame = ((GRI.GameClass != default) ? GRI.GameClass.DefaultAs<GameInfo>().bTeamGame : false);
			Index = 0;
			J0x8D:{}
			if(Index < GRI.PRIArray.Length)
			{
				if(GRI.PRIArray[Index].UniqueId != ZeroUniqueId)
				{
					ScoreIndex = PlayerScores.Length;
					PlayerScores[ScoreIndex].PlayerId = GRI.PRIArray[Index].UniqueId;
					if(bIsTeamGame)
					{
						PlayerScores[ScoreIndex].TeamId = GRI.PRIArray[Index].Team.TeamIndex;
						PlayerScores[ScoreIndex].Score = ((int)(GRI.PRIArray[Index].Team.Score));
						goto J0x1F7;
					}
					PlayerScores[ScoreIndex].TeamId = Index;
					PlayerScores[ScoreIndex].Score = ((int)(GRI.PRIArray[Index].Score));
				}
				J0x1F7:{}
				++ Index;
				goto J0x8D;
			}
			OnlineSub.StatsInterface.WriteOnlinePlayerScores(ref/*probably?*/ PlayerScores);
		}
	}
	
	public virtual /*reliable client simulated function */void ClientSetHostUniqueId(OnlineSubsystem.UniqueNetId InHostId)
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientStopNetworkedVoice()
	{
		/*local */LocalPlayer LocPlayer = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		if(((LocPlayer != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.VoiceInterface, (default(OnlineVoiceInterface))))
		{
			OnlineSub.VoiceInterface.StopNetworkedVoice((byte)((byte)(LocPlayer.ControllerId)));
		}
	}
	
	public virtual /*reliable client simulated function */void ClientStartNetworkedVoice()
	{
		/*local */LocalPlayer LocPlayer = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		if(((LocPlayer != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.VoiceInterface, (default(OnlineVoiceInterface))))
		{
			OnlineSub.VoiceInterface.StartNetworkedVoice((byte)((byte)(LocPlayer.ControllerId)));
		}
	}
	
	public virtual /*reliable server function */void ServerSendMusicInfo()
	{
		if((((WorldInfo.LastMusicAction != default) && WorldInfo.LastMusicAction.CurrPlayingTrack != default) && WorldInfo.LastMusicAction.CurrPlayingTrack.FadeOutStopTime < 0.0f) && WorldInfo.LastMusicTrack.TheSoundCue != default)
		{
			ClientCrossFadeMusicTrack_PlayTrack(WorldInfo.LastMusicAction, WorldInfo.LastMusicTrack);
		}
	}
	
	public virtual /*reliable client simulated event */void ClientCrossFadeMusicTrack_PlayTrack(SeqAct_CrossFadeMusicTracks MusicAction, MusicTrackDataStructures.MusicTrackStruct MusicTrack)
	{
		if(MusicAction != default)
		{
			MusicAction.ClientSideCrossFadeTrackImmediately(ref/*probably?*/ MusicTrack);		
		}
		else
		{
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				ServerSendMusicInfo();
			}
		}
	}
	
	public virtual /*reliable client simulated event */void ClientFadeOutMusicTrack(SeqAct_CrossFadeMusicTracks MusicAction, float FadeOutTime, float FadeOutVolumeLevel)
	{
		if((MusicAction != default) && MusicAction.CurrPlayingTrack != default)
		{
			MusicAction.CurrPlayingTrack.FadeOut(FadeOutTime, FadeOutVolumeLevel);
			MusicAction.CurrTrackType = "None";
		}
	}
	
	public virtual /*reliable client simulated event */void ClientAdjustMusicTrackVolume(SeqAct_CrossFadeMusicTracks MusicAction, float AdjustVolumeDuration, float AdjustVolumeLevel)
	{
		if((MusicAction != default) && MusicAction.CurrPlayingTrack != default)
		{
			MusicAction.CurrPlayingTrack.AdjustVolume(AdjustVolumeDuration, AdjustVolumeLevel);
		}
	}
	
	public override /*simulated function */void OnDestroy(SeqAct_Destroy Action)
	{
		Action.ScriptLog("Cannot use Destroy action on players", default(bool));
	}
	
	public virtual /*exec function */void ConsoleKey(name Key)
	{
		if(((Player) as LocalPlayer) != default)
		{
			((Player) as LocalPlayer).ViewportClient.ViewportConsole.InputKey(0, Key, Object.EInputEvent.IE_Pressed/*0*/, default(float), default(bool));
		}
	}
	
	public virtual /*exec function */void SendToConsole(string Command)
	{
		if(((Player) as LocalPlayer) != default)
		{
			((Player) as LocalPlayer).ViewportClient.ViewportConsole.ConsoleCommand(Command);
		}
	}
	
	public virtual /*final simulated function */void DrawDebugTextList(Canvas Canvas, float RenderDelta)
	{
		/*local */Object.Vector cameraLoc = default, ScreenLoc = default, Offset = default;
		/*local */Object.Rotator cameraRot = default;
		/*local */int Idx = default;
	
		if(DebugTextList.Length > 0)
		{
			GetPlayerViewPoint(ref/*probably?*/ cameraLoc, ref/*probably?*/ cameraRot);
			Canvas.SetDrawColor(255, 255, 255, (byte)default(byte));
			Canvas.Font = Engine.GetSmallFont();
			Idx = 0;
			J0x5E:{}
			if(Idx < DebugTextList.Length)
			{
				if(DebugTextList[Idx].SrcActor == default)
				{
					DebugTextList.Remove(-- Idx, 1);
					goto J0x23A;
				}
				if(DebugTextList[Idx].TimeRemaining != -1.0f)
				{
					DebugTextList[Idx].TimeRemaining -= RenderDelta;
					if(DebugTextList[Idx].TimeRemaining <= 0.0f)
					{
						DebugTextList.Remove(-- Idx, 1);
						goto J0x23A;
					}
				}
				Offset = VLerp(DebugTextList[Idx].SrcActorOffset, DebugTextList[Idx].SrcActorDesiredOffset, 1.0f - (DebugTextList[Idx].TimeRemaining / DebugTextList[Idx].Duration));
				ScreenLoc = Canvas.Project(DebugTextList[Idx].SrcActor.Location + (/*>>*/ShiftR(Offset, cameraRot)));
				Canvas.SetPos(ScreenLoc.X, ScreenLoc.Y);
				Canvas.DrawColor = DebugTextList[Idx].TextColor;
				Canvas.DrawText(DebugTextList[Idx].DebugText, default(bool), default(float), default(float));
				J0x23A:{}
				++ Idx;
				goto J0x5E;
			}
		}
	}
	
	public virtual /*reliable client final simulated event */void AddDebugText(string DebugText, /*optional */Actor SrcActor = default, /*optional */float Duration = default, /*optional */Object.Vector Offset = default, /*optional */Object.Vector DesiredOffset = default, /*optional */Object.Color TextColor = default, /*optional */bool bSkipOverwriteCheck = default)
	{
		/*local */int Idx = default;
	
		Duration = -1.0f;				
		if((((((int)TextColor.R) == ((int)0)) && ((int)TextColor.G) == ((int)0)) && ((int)TextColor.B) == ((int)0)) && ((int)TextColor.A) == ((int)0))
		{
			TextColor.R = 255;
			TextColor.G = 255;
			TextColor.B = 255;
			TextColor.A = 255;
		}
		if(SrcActor == default)
		{
			SrcActor = Pawn;
		}
		if(SrcActor != default)
		{
			if(Len(DebugText) == 0)
			{
				RemoveDebugText(SrcActor);			
			}
			else
			{
				if(!bSkipOverwriteCheck)
				{
					Idx = DebugTextList.Find("SrcActor", SrcActor);
					if(Idx == -1)
					{
						Idx = DebugTextList.Length;
						DebugTextList.Length = Idx + 1;
					}				
				}
				else
				{
					Idx = DebugTextList.Length;
					DebugTextList.Length = Idx + 1;
				}
				DebugTextList[Idx].SrcActor = SrcActor;
				DebugTextList[Idx].SrcActorOffset = Offset;
				DebugTextList[Idx].SrcActorDesiredOffset = DesiredOffset;
				DebugTextList[Idx].DebugText = DebugText;
				DebugTextList[Idx].TimeRemaining = Duration;
				DebugTextList[Idx].Duration = Duration;
				DebugTextList[Idx].TextColor = TextColor;
			}
		}
	}
	
	public virtual /*reliable client final simulated event */void RemoveDebugText(Actor SrcActor)
	{
		/*local */int Idx = default;
	
		Idx = DebugTextList.Find("SrcActor", SrcActor);
		if(Idx != -1)
		{
			DebugTextList.Remove(Idx, 1);
		}
	}
	
	public virtual /*function */void EnableDebugCamera()
	{
		/*local */Player P = default;
		/*local */Object.Vector eyeLoc = default;
		/*local */Object.Rotator eyeRot = default;
	
		P = this.Player;
		if(((P != default) && Pawn != default) && this.IsLocalPlayerController())
		{
			if(DebugCameraControllerRef == default)
			{
				DebugCameraControllerRef = Spawn(DebugCameraControllerClass, default(Actor), default(name), default(Object.Vector), default(Object.Rotator), default(Actor), default(bool));
			}
			DebugCameraControllerRef.OryginalPlayer = P;
			DebugCameraControllerRef.OryginalControllerRef = this;
			GetPlayerViewPoint(ref/*probably?*/ eyeLoc, ref/*probably?*/ eyeRot);
			DebugCameraControllerRef.SetLocation(eyeLoc);
			DebugCameraControllerRef.SetRotation(eyeRot);
			DebugCameraControllerRef.PlayerCamera.SetFOV(GetFOVAngle());
			DebugCameraControllerRef.PlayerCamera.UpdateCamera(0.0f);
			P.SwitchController(DebugCameraControllerRef);
			DebugCameraControllerRef.OnActivate(this);
		}
	}
	
	public virtual /*reliable client simulated function */void ClientRegisterHostStatGuid(string StatGuid)
	{
		if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.StatsInterface, (default(OnlineStatsInterface))))
		{
			OnlineSub.StatsInterface.AddRegisterHostStatGuidCompleteDelegate(OnRegisterHostStatGuidComplete);
			if(OnlineSub.StatsInterface.RegisterHostStatGuid(ref/*probably?*/ StatGuid) == false)
			{
				OnRegisterHostStatGuidComplete(false);
			}
		}
	}
	
	public virtual /*function */void OnRegisterHostStatGuidComplete(bool bWasSuccessful)
	{
		/*local */string StatGuid = default;
	
		OnlineSub.StatsInterface.ClearRegisterHostStatGuidCompleteDelegateDelegate(OnRegisterHostStatGuidComplete);
		if(bWasSuccessful)
		{
			StatGuid = OnlineSub.StatsInterface.GetClientStatGuid();
			ServerRegisterClientStatGuid(StatGuid);
		}
	}
	
	public virtual /*reliable server function */void ServerRegisterClientStatGuid(string StatGuid)
	{
		if((OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.StatsInterface, (default(OnlineStatsInterface))))
		{
			OnlineSub.StatsInterface.RegisterStatGuid(PlayerReplicationInfo.UniqueId, ref/*probably?*/ StatGuid);
		}
	}
	
	public virtual /*function */bool CanViewUserCreatedContent()
	{
		/*local */LocalPlayer LocPlayer = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		if(((LocPlayer != default) && OnlineSub != default) && NotEqual_InterfaceInterface(OnlineSub.PlayerInterface, (default(OnlinePlayerInterface))))
		{
			return ((int)OnlineSub.PlayerInterface.CanDownloadUserContent((byte)((byte)(LocPlayer.ControllerId)))) == ((int)OnlineSubsystem.EFeaturePrivilegeLevel.FPL_Enabled/*2*/);
		}
		return true;
	}
	
	public virtual /*function */void IncrementNumberOfMatchesPlayed()
	{
		++ PlayerReplicationInfo.AutomatedTestingData.NumberOfMatchesPlayed;
	}
	
	public virtual /*event */void SoakPause(Pawn P)
	{
		SetViewTarget(P, default(Camera.ViewTargetTransitionParams));
		SetPause(true, default(/*delegate*/PlayerController.CanUnpause));
		myHUD.bShowDebugInfo = true;
	}
	
	public virtual /*exec function */void PathStep(/*optional */int Cnt = default)
	{
		Pawn.IncrementPathStep(Max(1, Cnt), myHUD.Canvas);
	}
	
	public virtual /*exec function */void PathChild(/*optional */int Cnt = default)
	{
		Pawn.IncrementPathChild(Max(1, Cnt), myHUD.Canvas);
	}
	
	public virtual /*exec function */void PathClear()
	{
		Pawn.ClearPathStep();
	}
	
	public delegate bool LimitSpectatorVelocity_del();
	public virtual LimitSpectatorVelocity_del LimitSpectatorVelocity { get => bfield_LimitSpectatorVelocity ?? (()=>default); set => bfield_LimitSpectatorVelocity = value; } LimitSpectatorVelocity_del bfield_LimitSpectatorVelocity;
	public virtual LimitSpectatorVelocity_del global_LimitSpectatorVelocity => ()=>default;
	
	public delegate void Jump_del();
	public virtual Jump_del Jump { get => bfield_Jump ?? (()=>{}); set => bfield_Jump = value; } Jump_del bfield_Jump;
	public virtual Jump_del global_Jump => ()=>{};
	
	public delegate void FindGoodView_del();
	public virtual FindGoodView_del FindGoodView { get => bfield_FindGoodView ?? (()=>{}); set => bfield_FindGoodView = value; } FindGoodView_del bfield_FindGoodView;
	public virtual FindGoodView_del global_FindGoodView => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		FellOutOfWorld = null;
		Reset = null;
		ClientGotoState = null;
		Possess = null;
		PawnDied = null;
		ServerMove = null;
		ProcessDrive = null;
		ProcessMove = null;
		LongClientAdjustPosition = null;
		ReplicateMove = null;
		ServerRestartGame = null;
		RestartLevel = null;
		ThrowWeapon = null;
		PrevWeapon = null;
		NextWeapon = null;
		StartFire = null;
		StartAltFire = null;
		Use = null;
		ServerUse = null;
		Suicide = null;
		ServerSuicide = null;
		ServerChangeTeam = null;
		ClientRestart = null;
		PlayerTick = null;
		PlayerMove = null;
		GetAdjustedAimFor = null;
		NotifyLanded = null;
		ClientSetViewTarget = null;
		UpdateRotation = null;
		IsSpectating = null;
		ServerSetSpectatorLocation = null;
		ServerViewNextPlayer = null;
	
	}
	
	protected /*event */void PlayerController_PlayerWalking_NotifyPhysicsVolumeChange(PhysicsVolume NewVolume)// state function
	{
		if(NewVolume.bWaterVolume && Pawn.bCollideWorld)
		{
			GotoState(Pawn.WaterMovementState, default(name), default(bool), default(bool));
		}
	}
	
	protected /*function */void PlayerController_PlayerWalking_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		if(Pawn == default)
		{
			return;
		}
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
		}
		Pawn.Acceleration = newAccel;
		CheckJumpOrDuck();
	}
	
	protected /*function */void PlayerController_PlayerWalking_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default, newAccel = default;
		/*local */Actor.EDoubleClickDir DoubleClickMove = default;
		/*local */Object.Rotator OldRotation = default;
		/*local */bool bSaveJump = default;
	
		if(Pawn == default)
		{
			GotoState("Dead", default(name), default(bool), default(bool));		
		}
		else
		{
			GetAxes(Pawn.Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
			newAccel = (PlayerInput.aForward * X) + (PlayerInput.aStrafe * Y);
			newAccel.Z = 0.0f;
			newAccel = Pawn.AccelRate * Normal(newAccel);
			DoubleClickMove = ((Actor.EDoubleClickDir)PlayerInput.CheckForDoubleClickMove(DeltaTime / WorldInfo.TimeDilation));
			OldRotation = Rotation;
			UpdateRotation(DeltaTime);
			bDoubleJump = false;
			if(bPressedJump && Pawn.CannotJumpNow())
			{
				bSaveJump = true;
				bPressedJump = false;			
			}
			else
			{
				bSaveJump = false;
			}
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				ReplicateMove(DeltaTime, newAccel, ((Actor.EDoubleClickDir)DoubleClickMove), OldRotation - Rotation);			
			}
			else
			{
				ProcessMove(DeltaTime, newAccel, ((Actor.EDoubleClickDir)DoubleClickMove), OldRotation - Rotation);
			}
			bPressedJump = bSaveJump;
		}
	}
	
	protected /*event */void PlayerController_PlayerWalking_BeginState(name PreviousStateName)// state function
	{
		DoubleClickDir = Actor.EDoubleClickDir.DCLICK_None/*0*/;
		bPressedJump = false;
		GroundPitch = 0;
		if(Pawn != default)
		{
			Pawn.ShouldCrouch(false);
			if((((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/)) && ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
			{
				Pawn.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
			}
		}
	}
	
	protected /*event */void PlayerController_PlayerWalking_EndState(name NextStateName)// state function
	{
		GroundPitch = 0;
		if(Pawn != default)
		{
			Pawn.SetRemoteViewPitch(0);
			if(((int)bDuck) == ((int)0))
			{
				Pawn.ShouldCrouch(false);
			}
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerWalking()/*state PlayerWalking*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			NotifyPhysicsVolumeChange = PlayerController_PlayerWalking_NotifyPhysicsVolumeChange;
			ProcessMove = PlayerController_PlayerWalking_ProcessMove;
			PlayerMove = PlayerController_PlayerWalking_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;								
		}
	
		return (PlayerController_PlayerWalking_BeginState, StateFlow, PlayerController_PlayerWalking_EndState);
	}
	
	
	protected /*event */void PlayerController_PlayerClimbing_NotifyPhysicsVolumeChange(PhysicsVolume NewVolume)// state function
	{
		if(NewVolume.bWaterVolume)
		{
			GotoState(Pawn.WaterMovementState, default(name), default(bool), default(bool));		
		}
		else
		{
			GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));
		}
	}
	
	protected /*function */void PlayerController_PlayerClimbing_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		if(Pawn == default)
		{
			return;
		}
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
		}
		Pawn.Acceleration = newAccel;
		if(bPressedJump)
		{
			Pawn.DoJump(bUpdating);
			if(((int)Pawn.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
			{
				GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));
			}
		}
	}
	
	protected /*function */void PlayerController_PlayerClimbing_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default, newAccel = default;
		/*local */Object.Rotator OldRotation = default, ViewRotation = default;
	
		GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		if(Pawn.OnLadder != default)
		{
			newAccel = PlayerInput.aForward * Pawn.OnLadder.ClimbDir;
			if(Pawn.OnLadder.bAllowLadderStrafing)
			{
				newAccel += (PlayerInput.aStrafe * Y);
			}		
		}
		else
		{
			newAccel = (PlayerInput.aForward * X) + (PlayerInput.aStrafe * Y);
		}
		newAccel = Pawn.AccelRate * Normal(newAccel);
		ViewRotation = Rotation;
		SetRotation(ViewRotation);
		OldRotation = Rotation;
		UpdateRotation(DeltaTime);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bPressedJump = false;
	}
	
	protected /*event */void PlayerController_PlayerClimbing_BeginState(name PreviousStateName)// state function
	{
		Pawn.ShouldCrouch(false);
		bPressedJump = false;
	}
	
	protected /*event */void PlayerController_PlayerClimbing_EndState(name NextStateName)// state function
	{
		if(Pawn != default)
		{
			Pawn.SetRemoteViewPitch(0);
			Pawn.ShouldCrouch(false);
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerClimbing()/*state PlayerClimbing*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			NotifyPhysicsVolumeChange = PlayerController_PlayerClimbing_NotifyPhysicsVolumeChange;
			ProcessMove = PlayerController_PlayerClimbing_ProcessMove;
			PlayerMove = PlayerController_PlayerClimbing_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (PlayerController_PlayerClimbing_BeginState, StateFlow, PlayerController_PlayerClimbing_EndState);
	}
	
	
	protected /*function */void PlayerController_PlayerDriving_ProcessDrive(float InForward, float InStrafe, float InUp, bool InJump)// state function
	{
		/*local */Vehicle CurrentVehicle = default;
	
		CurrentVehicle = ((Pawn) as Vehicle);
		if(CurrentVehicle != default)
		{
			bPressedJump = InJump;
			CurrentVehicle.SetInputs(InForward, -InStrafe, InUp);
			CheckJumpOrDuck();
		}
	}
	
	protected /*function */void PlayerController_PlayerDriving_PlayerMove(float DeltaTime)// state function
	{
		UpdateRotation(DeltaTime);
		ProcessDrive(PlayerInput.RawJoyUp, PlayerInput.RawJoyRight, PlayerInput.aUp, bPressedJump);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ServerDrive(PlayerInput.RawJoyUp, PlayerInput.RawJoyRight, PlayerInput.aUp, bPressedJump, (/*<<*/ShiftL((Rotation.Yaw & 65535), 16)) + (Rotation.Pitch & 65535));
		}
		bPressedJump = false;
	}
	
	protected /*unreliable server function */void PlayerController_PlayerDriving_ServerUse()// state function
	{
		/*local */Vehicle CurrentVehicle = default;
	
		CurrentVehicle = ((Pawn) as Vehicle);
		CurrentVehicle.DriverLeave(false);
	}
	
	protected /*event */void PlayerController_PlayerDriving_BeginState(name PreviousStateName)// state function
	{
		CleanOutSavedMoves();
	}
	
	protected /*event */void PlayerController_PlayerDriving_EndState(name NextStateName)// state function
	{
		CleanOutSavedMoves();
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerDriving()/*state PlayerDriving*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			/*ignores*/ ProcessMove = (_,_,_,_)=>{};
	
			ProcessDrive = PlayerController_PlayerDriving_ProcessDrive;
			PlayerMove = PlayerController_PlayerDriving_PlayerMove;
			ServerUse = PlayerController_PlayerDriving_ServerUse;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (PlayerController_PlayerDriving_BeginState, StateFlow, PlayerController_PlayerDriving_EndState);
	}
	
	
	protected /*event */bool PlayerController_PlayerSwimming_NotifyLanded(Object.Vector HitNormal, Actor FloorActor)// state function
	{
		if(Pawn.PhysicsVolume.bWaterVolume)
		{
			Pawn.SetPhysics(Actor.EPhysics.PHYS_Swimming/*3*/);		
		}
		else
		{
			GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));
		}
		return bUpdating;
	}
	
	protected /*event */void PlayerController_PlayerSwimming_NotifyPhysicsVolumeChange(PhysicsVolume NewVolume)// state function
	{
		/*local */Actor HitActor = default;
		/*local */Object.Vector HitLocation = default, HitNormal = default, Checkpoint = default, X = default, Y = default, Z = default;
	
		if(!Pawn.bCollideActors)
		{
			GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));
		}
		if(((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			if(!NewVolume.bWaterVolume)
			{
				Pawn.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
				if(Pawn.Velocity.Z > ((float)(0)))
				{
					GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
					Pawn.bUpAndOut = ((Dot(X, Pawn.Acceleration)) > ((float)(0))) && (Pawn.Acceleration.Z > ((float)(0))) || Rotation.Pitch > 2048;
					if(Pawn.bUpAndOut && Pawn.CheckWaterJump(ref/*probably?*/ HitNormal))
					{
						Pawn.Velocity.Z = Pawn.OutofWaterZ;
						GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));					
					}
					else
					{
						if((Pawn.Velocity.Z > ((float)(160))) || !Pawn.TouchingWaterVolume())
						{
							GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));						
						}
						else
						{
							Checkpoint = Pawn.Location;
							Checkpoint.Z -= (Pawn.CylinderComponent.CollisionHeight + 6.0f);
							HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, Checkpoint, Pawn.Location, false, default(Object.Vector), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, default(int));
							if(HitActor != default)
							{
								GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));							
							}
							else
							{
								SetTimer(0.70f, false, default(name), default(Object));
							}
						}
					}
				}			
			}
			else
			{
				ClearTimer(default(name), default(Object));
				Pawn.SetPhysics(Actor.EPhysics.PHYS_Swimming/*3*/);
			}		
		}
		else
		{
			if(!NewVolume.bWaterVolume)
			{
				GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));
			}
		}
	}
	
	protected /*function */void PlayerController_PlayerSwimming_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		Pawn.Acceleration = newAccel;
	}
	
	protected /*function */void PlayerController_PlayerSwimming_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Rotator OldRotation = default;
		/*local */Object.Vector X = default, Y = default, Z = default, newAccel = default;
	
		if(Pawn == default)
		{
			GotoState("Dead", default(name), default(bool), default(bool));		
		}
		else
		{
			GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
			newAccel = ((PlayerInput.aForward * X) + (PlayerInput.aStrafe * Y)) + (PlayerInput.aUp * vect(0.0f, 0.0f, 1.0f));
			newAccel = Pawn.AccelRate * Normal(newAccel);
			OldRotation = Rotation;
			UpdateRotation(DeltaTime);
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);			
			}
			else
			{
				ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
			}
			bPressedJump = false;
		}
	}
	
	protected /*event */void PlayerController_PlayerSwimming_Timer()// state function
	{
		if(!Pawn.PhysicsVolume.bWaterVolume && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			GotoState(Pawn.LandMovementState, default(name), default(bool), default(bool));
		}
		ClearTimer(default(name), default(Object));
	}
	
	protected /*event */void PlayerController_PlayerSwimming_BeginState(name PreviousStateName)// state function
	{
		ClearTimer(default(name), default(Object));
		if(((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			Pawn.SetPhysics(Actor.EPhysics.PHYS_Swimming/*3*/);
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerSwimming()/*state PlayerSwimming*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			NotifyLanded = PlayerController_PlayerSwimming_NotifyLanded;
			NotifyPhysicsVolumeChange = PlayerController_PlayerSwimming_NotifyPhysicsVolumeChange;
			ProcessMove = PlayerController_PlayerSwimming_ProcessMove;
			PlayerMove = PlayerController_PlayerSwimming_PlayerMove;
			Timer = PlayerController_PlayerSwimming_Timer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;								
		}
	
		return (PlayerController_PlayerSwimming_BeginState, StateFlow, null);
	}
	
	
	protected /*function */void PlayerController_PlayerFlying_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default;
	
		GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		Pawn.Acceleration = ((PlayerInput.aForward * X) + (PlayerInput.aStrafe * Y)) + (PlayerInput.aUp * vect(0.0f, 0.0f, 1.0f));
		Pawn.Acceleration = Pawn.AccelRate * Normal(Pawn.Acceleration);
		if(bCheatFlying && Pawn.Acceleration == vect(0.0f, 0.0f, 0.0f))
		{
			Pawn.Velocity = vect(0.0f, 0.0f, 0.0f);
		}
		UpdateRotation(DeltaTime);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, Pawn.Acceleration, Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));		
		}
		else
		{
			ProcessMove(DeltaTime, Pawn.Acceleration, Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));
		}
	}
	
	protected /*event */void PlayerController_PlayerFlying_BeginState(name PreviousStateName)// state function
	{
		Pawn.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerFlying()/*state PlayerFlying*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			PlayerMove = PlayerController_PlayerFlying_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (PlayerController_PlayerFlying_BeginState, StateFlow, null);
	}
	
	
	protected /*function */bool PlayerController_BaseSpectating_IsSpectating()// state function
	{
		return true;
	}
	
	protected /*function */bool PlayerController_BaseSpectating_LimitSpectatorVelocity()// state function
	{
		if(Location.Z > WorldInfo.StallZ)
		{
			Velocity.Z = FMin(SpectatorCameraSpeed, (WorldInfo.StallZ - Location.Z) - 2.0f);
			return true;		
		}
		else
		{
			if(Location.Z < WorldInfo.KillZ)
			{
				Velocity.Z = FMin(SpectatorCameraSpeed, (WorldInfo.KillZ - Location.Z) + 2.0f);
				return true;
			}
		}
		return false;
	}
	
	protected /*function */void PlayerController_BaseSpectating_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		/*local */float VelSize = default;
	
		Acceleration = Normal(newAccel) * SpectatorCameraSpeed;
		VelSize = VSize(Velocity);
		if(VelSize > ((float)(0)))
		{
			Velocity = Velocity - ((Velocity - (Normal(Acceleration) * VelSize)) * FMin(DeltaTime * ((float)(8)), 1.0f));
		}
		Velocity = Velocity + (Acceleration * DeltaTime);
		if(VSize(Velocity) > SpectatorCameraSpeed)
		{
			Velocity = Normal(Velocity) * SpectatorCameraSpeed;
		}
		LimitSpectatorVelocity();
		if(VSize(Velocity) > ((float)(0)))
		{
			MoveSmooth((((float)(1 + ((int)bRun))) * Velocity) * DeltaTime);
			if(LimitSpectatorVelocity())
			{
				MoveSmooth((Velocity.Z * vect(0.0f, 0.0f, 1.0f)) * DeltaTime);
			}
		}
	}
	
	protected /*function */void PlayerController_BaseSpectating_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default;
	
		GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		Acceleration = ((PlayerInput.aForward * X) + (PlayerInput.aStrafe * Y)) + (PlayerInput.aUp * vect(0.0f, 0.0f, 1.0f));
		UpdateRotation(DeltaTime);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, Acceleration, Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));		
		}
		else
		{
			ProcessMove(DeltaTime, Acceleration, Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));
		}
	}
	
	protected /*unreliable server function */void PlayerController_BaseSpectating_ServerSetSpectatorLocation(Object.Vector NewLoc)// state function
	{
		SetLocation(NewLoc);
	}
	
	protected /*function */void PlayerController_BaseSpectating_ReplicateMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		ProcessMove(DeltaTime, newAccel, ((Actor.EDoubleClickDir)DoubleClickMove), DeltaRot);
		ServerSetSpectatorLocation(Location);
	}
	
	protected /*event */void PlayerController_BaseSpectating_BeginState(name PreviousStateName)// state function
	{
		bCollideWorld = true;
	}
	
	protected /*event */void PlayerController_BaseSpectating_EndState(name NextStateName)// state function
	{
		bCollideWorld = false;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) BaseSpectating()/*state BaseSpectating*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			IsSpectating = PlayerController_BaseSpectating_IsSpectating;
			LimitSpectatorVelocity = PlayerController_BaseSpectating_LimitSpectatorVelocity;
			ProcessMove = PlayerController_BaseSpectating_ProcessMove;
			PlayerMove = PlayerController_BaseSpectating_PlayerMove;
			ServerSetSpectatorLocation = PlayerController_BaseSpectating_ServerSetSpectatorLocation;
			ReplicateMove = PlayerController_BaseSpectating_ReplicateMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (PlayerController_BaseSpectating_BeginState, StateFlow, PlayerController_BaseSpectating_EndState);
	}
	
	
	protected /*exec function */void PlayerController_Spectating_StartFire(/*optional */byte FireModeNum = default)// state function
	{
		ServerViewNextPlayer();
	}
	
	protected /*exec function */void PlayerController_Spectating_StartAltFire(/*optional */byte FireModeNum = default)// state function
	{
		ResetCameraMode();
		ServerViewSelf();
	}
	
	protected /*event */void PlayerController_Spectating_BeginState(name PreviousStateName)// state function
	{
		if(Pawn != default)
		{
			SetLocation(Pawn.Location);
			UnPossess();
		}
		bCollideWorld = true;
	}
	
	protected /*event */void PlayerController_Spectating_EndState(name NextStateName)// state function
	{
		if(PlayerReplicationInfo.bOnlySpectator)
		{
		}
		PlayerReplicationInfo.bIsSpectator = false;
		bCollideWorld = false;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Spectating()/*state Spectating extends BaseSpectating*/
	{
	
		void Begin(name PreviousStateName)
		{
		PlayerController_BaseSpectating_BeginState(PreviousStateName);
		PlayerController_Spectating_BeginState(PreviousStateName);
		}
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
	
			// Inherited from PlayerController.BaseSpectating
			IsSpectating = PlayerController_BaseSpectating_IsSpectating;
			LimitSpectatorVelocity = PlayerController_BaseSpectating_LimitSpectatorVelocity;
			ProcessMove = PlayerController_BaseSpectating_ProcessMove;
			PlayerMove = PlayerController_BaseSpectating_PlayerMove;
			ServerSetSpectatorLocation = PlayerController_BaseSpectating_ServerSetSpectatorLocation;
			ReplicateMove = PlayerController_BaseSpectating_ReplicateMove;
	
			/*ignores*/ RestartLevel = ()=>{}; ClientRestart = (_)=>{}; Suicide = ()=>{}; ThrowWeapon = ()=>{};
	
			StartFire = PlayerController_Spectating_StartFire;
			StartAltFire = PlayerController_Spectating_StartAltFire;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		void End(name PreviousStateName)
		{
		PlayerController_BaseSpectating_EndState(PreviousStateName);
		PlayerController_Spectating_EndState(PreviousStateName);
		}
	
		return (Begin, StateFlow, End);
	}
	
	
	protected /*reliable server function */void PlayerController_PlayerWaiting_ServerChangeTeam(int N)// state function
	{
		WorldInfo.Game.ChangeTeam(this, N, true);
	}
	
	protected /*reliable server function */void PlayerController_PlayerWaiting_ServerRestartPlayer()// state function
	{
		if(WorldInfo.TimeSeconds < WaitDelay)
		{
			return;
		}
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))
		{
			return;
		}
		if(WorldInfo.Game.bWaitingToStartMatch)
		{
			PlayerReplicationInfo.bReadyToPlay = true;		
		}
		else
		{
			WorldInfo.Game.RestartPlayer(this);
		}
	}
	
	protected /*exec function */void PlayerController_PlayerWaiting_StartFire(/*optional */byte FireModeNum = default)// state function
	{
		ServerRestartPlayer();
	}
	
	protected /*event */void PlayerController_PlayerWaiting_EndState(name NextStateName)// state function
	{
		if(PlayerReplicationInfo != default)
		{
			PlayerReplicationInfo.SetWaitingPlayer(false);
		}
		bCollideWorld = false;
	}
	
	protected /*simulated event */void PlayerController_PlayerWaiting_BeginState(name PreviousStateName)// state function
	{
		if(PlayerReplicationInfo != default)
		{
			PlayerReplicationInfo.SetWaitingPlayer(true);
		}
		bCollideWorld = true;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerWaiting()/*auto state PlayerWaiting extends BaseSpectating*/
	{
	
		void Begin(name PreviousStateName)
		{
		PlayerController_BaseSpectating_BeginState(PreviousStateName);
		PlayerController_PlayerWaiting_BeginState(PreviousStateName);
		}
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
	
			// Inherited from PlayerController.BaseSpectating
			IsSpectating = PlayerController_BaseSpectating_IsSpectating;
			LimitSpectatorVelocity = PlayerController_BaseSpectating_LimitSpectatorVelocity;
			ProcessMove = PlayerController_BaseSpectating_ProcessMove;
			PlayerMove = PlayerController_BaseSpectating_PlayerMove;
			ServerSetSpectatorLocation = PlayerController_BaseSpectating_ServerSetSpectatorLocation;
			ReplicateMove = PlayerController_BaseSpectating_ReplicateMove;
	
			/*ignores*/ TakeDamage = (_,_,_,_,_,_,_)=>{}; NextWeapon = ()=>{}; PrevWeapon = ()=>{}; SwitchToBestWeapon = (_)=>{}; Jump = ()=>{}; Suicide = ()=>{}; ServerSuicide = ()=>{};
	
			ServerChangeTeam = PlayerController_PlayerWaiting_ServerChangeTeam;
			ServerRestartPlayer = PlayerController_PlayerWaiting_ServerRestartPlayer;
			StartFire = PlayerController_PlayerWaiting_StartFire;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		void End(name PreviousStateName)
		{
		PlayerController_BaseSpectating_EndState(PreviousStateName);
		PlayerController_PlayerWaiting_EndState(PreviousStateName);
		}
	
		return (Begin, StateFlow, End);
	}
	
	
	protected /*exec function */void PlayerController_WaitingForPawn_StartFire(/*optional */byte FireModeNum = default)// state function
	{
		AskForPawn();
	}
	
	protected /*reliable client simulated function */void PlayerController_WaitingForPawn_ClientGotoState(name NewState, /*optional */name NewLabel = default)// state function
	{
		if(NewState == "RoundEnded")
		{
			global_ClientGotoState(NewState, NewLabel);
		}
	}
	
	protected /*unreliable client simulated function */void PlayerController_WaitingForPawn_LongClientAdjustPosition(float TimeStamp, name NewState, Actor.EPhysics newPhysics, float NewLocX, float NewLocY, float NewLocZ, float NewVelX, float NewVelY, float NewVelZ, Actor NewBase, float NewFloorX, float NewFloorY, float NewFloorZ)// state function
	{
		if(NewState == "RoundEnded")
		{
			GotoState(NewState, default(name), default(bool), default(bool));
		}
	}
	
	protected /*event */void PlayerController_WaitingForPawn_PlayerTick(float DeltaTime)// state function
	{
		global_PlayerTick(DeltaTime);
		if(Pawn != default)
		{
			Pawn.Controller = this;
			Pawn.BecomeViewTarget(this);
			ClientRestart(Pawn);		
		}
		else
		{
			if(!IsTimerActive(default(name), default(Object)) || GetTimerCount(default(name), default(Object)) > 1.0f)
			{
				SetTimer(0.20f, true, default(name), default(Object));
				AskForPawn();
			}
		}
	}
	
	protected /*function */void PlayerController_WaitingForPawn_ReplicateMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		ProcessMove(DeltaTime, newAccel, ((Actor.EDoubleClickDir)DoubleClickMove), DeltaRot);
	}
	
	protected /*event */void PlayerController_WaitingForPawn_Timer()// state function
	{
		AskForPawn();
	}
	
	protected /*event */void PlayerController_WaitingForPawn_BeginState(name PreviousStateName)// state function
	{
		SetTimer(0.20f, true, default(name), default(Object));
		AskForPawn();
	}
	
	protected /*event */void PlayerController_WaitingForPawn_EndState(name NextStateName)// state function
	{
		ResetCameraMode();
		SetTimer(0.0f, false, default(name), default(Object));
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WaitingForPawn()/*state WaitingForPawn extends BaseSpectating*/
	{
	
		void Begin(name PreviousStateName)
		{
		PlayerController_BaseSpectating_BeginState(PreviousStateName);
		PlayerController_WaitingForPawn_BeginState(PreviousStateName);
		}
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
	
			// Inherited from PlayerController.BaseSpectating
			IsSpectating = PlayerController_BaseSpectating_IsSpectating;
			LimitSpectatorVelocity = PlayerController_BaseSpectating_LimitSpectatorVelocity;
			ProcessMove = PlayerController_BaseSpectating_ProcessMove;
			PlayerMove = PlayerController_BaseSpectating_PlayerMove;
			ServerSetSpectatorLocation = PlayerController_BaseSpectating_ServerSetSpectatorLocation;
			ReplicateMove = PlayerController_BaseSpectating_ReplicateMove;
	
			/*ignores*/ KilledBy = (_)=>{};
	
			StartFire = PlayerController_WaitingForPawn_StartFire;
			ClientGotoState = PlayerController_WaitingForPawn_ClientGotoState;
			LongClientAdjustPosition = PlayerController_WaitingForPawn_LongClientAdjustPosition;
			PlayerTick = PlayerController_WaitingForPawn_PlayerTick;
			ReplicateMove = PlayerController_WaitingForPawn_ReplicateMove;
			Timer = PlayerController_WaitingForPawn_Timer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		void End(name PreviousStateName)
		{
		PlayerController_BaseSpectating_EndState(PreviousStateName);
		PlayerController_WaitingForPawn_EndState(PreviousStateName);
		}
	
		return (Begin, StateFlow, End);
	}
	
	
	protected /*function */bool PlayerController_RoundEnded_IsSpectating()// state function
	{
		return true;
	}
	
	protected /*event */void PlayerController_RoundEnded_Possess(Pawn aPawn, bool bVehicleTransition)// state function
	{
		global_Possess(aPawn, bVehicleTransition);
		if(Pawn != default)
		{
			Pawn.TurnOff();
		}
	}
	
	protected /*reliable server function */void PlayerController_RoundEnded_ServerRestartGame()// state function
	{
		if(WorldInfo.Game.PlayerCanRestartGame(this))
		{
			WorldInfo.Game.ResetLevel();
		}
	}
	
	protected /*exec function */void PlayerController_RoundEnded_StartFire(/*optional */byte FireModeNum = default)// state function
	{
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return;
		}
		if(!bFrozen)
		{
			ServerRestartGame();		
		}
		else
		{
			if(!IsTimerActive(default(name), default(Object)))
			{
				SetTimer(1.50f, false, default(name), default(Object));
			}
		}
	}
	
	protected /*function */void PlayerController_RoundEnded_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default;
		/*local */Object.Rotator DeltaRot = default, ViewRotation = default;
	
		GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		ViewRotation = Rotation;
		DeltaRot.Yaw = ((int)(PlayerInput.aTurn));
		DeltaRot.Pitch = ((int)(PlayerInput.aLookUp));
		ProcessViewRotation(DeltaTime, ref/*probably?*/ ViewRotation, DeltaRot);
		SetRotation(ViewRotation);
		ViewShake(DeltaTime);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, vect(0.0f, 0.0f, 0.0f), Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));		
		}
		else
		{
			ProcessMove(DeltaTime, vect(0.0f, 0.0f, 0.0f), Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));
		}
		bPressedJump = false;
	}
	
	protected /*unreliable server function */void PlayerController_RoundEnded_ServerMove(float TimeStamp, Object.Vector InAccel, Object.Vector ClientLoc, byte NewFlags, byte ClientRoll, int View)// state function
	{
		global_ServerMove(TimeStamp, InAccel, ClientLoc, (byte)NewFlags, (byte)ClientRoll, (/*<<*/ShiftL((Rotation.Yaw & 65535), 16)) + (Rotation.Pitch & 65535));
	}
	
	protected /*function */void PlayerController_RoundEnded_FindGoodView()// state function
	{
		/*local */Object.Rotator GoodRotation = default;
	
		GoodRotation = Rotation;
		GetViewTarget().FindGoodEndView(this, ref/*probably?*/ GoodRotation);
		SetRotation(GoodRotation);
	}
	
	protected /*event */void PlayerController_RoundEnded_Timer()// state function
	{
		bFrozen = false;
	}
	
	protected /*event */void PlayerController_RoundEnded_BeginState(name PreviousStateName)// state function
	{
		/*local */Pawn P = default;
	
		FOVAngle = DesiredFOV;
		bFire = (byte)0;
		if(Pawn != default)
		{
			Pawn.TurnOff();
			Pawn.bSpecialHUD = false;
			StopFiring();
		}
		if(myHUD != default)
		{
			myHUD.SetShowScores(true);
		}
		bFrozen = true;
		FindGoodView();
		SetTimer(5.0f, false, default(name), default(Object));
		
		// foreach DynamicActors(ClassT<Pawn>(), ref/*probably?*/ P)
		using var e139 = DynamicActors(ClassT<Pawn>()).GetEnumerator();
		while(e139.MoveNext() && (P = (Pawn)e139.Current) == P)
		{
			P.TurnOff();		
		}	
	}
	
	protected /*event */void PlayerController_RoundEnded_EndState(name NextStateName)// state function
	{
		if(myHUD != default)
		{
			myHUD.SetShowScores(false);
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) RoundEnded()/*state RoundEnded*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			/*ignores*/ KilledBy = (_)=>{}; TakeDamage = (_,_,_,_,_,_,_)=>{}; Suicide = ()=>{}; ServerRestartPlayer = ()=>{}; ThrowWeapon = ()=>{}; Use = ()=>{}; LongClientAdjustPosition = (_,_,_,_,_,_,_,_,_,_,_,_,_)=>{};
	
			IsSpectating = PlayerController_RoundEnded_IsSpectating;
			Possess = PlayerController_RoundEnded_Possess;
			ServerRestartGame = PlayerController_RoundEnded_ServerRestartGame;
			StartFire = PlayerController_RoundEnded_StartFire;
			PlayerMove = PlayerController_RoundEnded_PlayerMove;
			ServerMove = PlayerController_RoundEnded_ServerMove;
			FindGoodView = PlayerController_RoundEnded_FindGoodView;
			Timer = PlayerController_RoundEnded_Timer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;								
		}
	
		return (PlayerController_RoundEnded_BeginState, StateFlow, PlayerController_RoundEnded_EndState);
	}
	
	
	protected /*function */bool PlayerController_Dead_IsDead()// state function
	{
		return true;
	}
	
	protected /*reliable server function */void PlayerController_Dead_ServerRestartPlayer()// state function
	{
		if(!WorldInfo.Game.PlayerCanRestart(this))
		{
			return;
		}
		/*Transformed 'base.' to specific call*/Controller_Dead_ServerRestartPlayer();
	}
	
	protected /*exec function */void PlayerController_Dead_StartFire(/*optional */byte FireModeNum = default)// state function
	{
		if(bFrozen)
		{
			if(!IsTimerActive(default(name), default(Object)) || GetTimerCount(default(name), default(Object)) > MinRespawnDelay)
			{
				bFrozen = false;
			}
			return;
		}
		ServerRestartPlayer();
	}
	
	protected /*exec function */void PlayerController_Dead_Use()// state function
	{
		StartFire(0);
	}
	
	protected /*exec function */void PlayerController_Dead_Jump()// state function
	{
		StartFire(0);
	}
	
	protected /*unreliable server function */void PlayerController_Dead_ServerMove(float TimeStamp, Object.Vector Accel, Object.Vector ClientLoc, byte NewFlags, byte ClientRoll, int View)// state function
	{
		global_ServerMove(TimeStamp, Accel, ClientLoc, 0, (byte)ClientRoll, View);
	}
	
	protected /*function */void PlayerController_Dead_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default;
		/*local */Object.Rotator DeltaRot = default, ViewRotation = default;
	
		if(!bFrozen)
		{
			if(bPressedJump)
			{
				StartFire(0);
				bPressedJump = false;
			}
			GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
			ViewRotation = Rotation;
			DeltaRot.Yaw = ((int)(PlayerInput.aTurn));
			DeltaRot.Pitch = ((int)(PlayerInput.aLookUp));
			ProcessViewRotation(DeltaTime, ref/*probably?*/ ViewRotation, DeltaRot);
			SetRotation(ViewRotation);
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				ReplicateMove(DeltaTime, vect(0.0f, 0.0f, 0.0f), Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));
			}		
		}
		else
		{
			if(!IsTimerActive(default(name), default(Object)) || GetTimerCount(default(name), default(Object)) > MinRespawnDelay)
			{
				bFrozen = false;
			}
		}
		ViewShake(DeltaTime);
	}
	
	protected /*function */void PlayerController_Dead_FindGoodView()// state function
	{
		/*local */Object.Vector cameraLoc = default;
		/*local */Object.Rotator cameraRot = default, ViewRotation = default;
		/*local */int tries = default, besttry = default;
		/*local */float bestDist = default, newdist = default;
		/*local */int startYaw = default;
		/*local */Actor TheViewTarget = default;
	
		ViewRotation = Rotation;
		ViewRotation.Pitch = 56000;
		tries = 0;
		besttry = 0;
		bestDist = 0.0f;
		startYaw = ViewRotation.Yaw;
		TheViewTarget = GetViewTarget();
		tries = 0;
		J0x67:{}
		if(tries < 16)
		{
			cameraLoc = TheViewTarget.Location;
			SetRotation(ViewRotation);
			GetPlayerViewPoint(ref/*probably?*/ cameraLoc, ref/*probably?*/ cameraRot);
			newdist = VSize(cameraLoc - TheViewTarget.Location);
			if(newdist > bestDist)
			{
				bestDist = newdist;
				besttry = tries;
			}
			ViewRotation.Yaw += 4096;
			++ tries;
			goto J0x67;
		}
		ViewRotation.Yaw = startYaw + (besttry * 4096);
		SetRotation(ViewRotation);
	}
	
	protected /*event */void PlayerController_Dead_Timer()// state function
	{
		if(!bFrozen)
		{
			return;
		}
		bFrozen = false;
		bPressedJump = false;
	}
	
	protected /*event */void PlayerController_Dead_BeginState(name PreviousStateName)// state function
	{
		if((Pawn != default) && Pawn.Controller == this)
		{
			Pawn.Controller = default;
		}
		Pawn = default;
		FOVAngle = DesiredFOV;
		Enemy = default;
		bFrozen = true;
		bPressedJump = false;
		FindGoodView();
		SetTimer(MinRespawnDelay, false, default(name), default(Object));
		CleanOutSavedMoves();
	}
	
	protected /*event */void PlayerController_Dead_EndState(name NextStateName)// state function
	{
		CleanOutSavedMoves();
		Velocity = vect(0.0f, 0.0f, 0.0f);
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		if(!PlayerReplicationInfo.bOutOfLives)
		{
			ResetCameraMode();
		}
		bPressedJump = false;
		if(myHUD != default)
		{
			myHUD.SetShowScores(false);
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Dead()/*state Dead*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
			/*ignores*/ KilledBy = (_)=>{}; NextWeapon = ()=>{}; PrevWeapon = ()=>{}; ThrowWeapon = ()=>{};
	
			IsDead = PlayerController_Dead_IsDead;
			ServerRestartPlayer = PlayerController_Dead_ServerRestartPlayer;
			StartFire = PlayerController_Dead_StartFire;
			Use = PlayerController_Dead_Use;
			Jump = PlayerController_Dead_Jump;
			ServerMove = PlayerController_Dead_ServerMove;
			PlayerMove = PlayerController_Dead_PlayerMove;
			FindGoodView = PlayerController_Dead_FindGoodView;
			Timer = PlayerController_Dead_Timer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			if(((Player) as LocalPlayer) != default)
			{
				if(myHUD != default)
				{
					myHUD.PlayerOwnerDied();
				}
			}
			yield return Flow.Stop;										
		}
	
		return (PlayerController_Dead_BeginState, StateFlow, PlayerController_Dead_EndState);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PlayerWalking": return PlayerWalking();
			case "PlayerClimbing": return PlayerClimbing();
			case "PlayerDriving": return PlayerDriving();
			case "PlayerSwimming": return PlayerSwimming();
			case "PlayerFlying": return PlayerFlying();
			case "BaseSpectating": return BaseSpectating();
			case "Spectating": return Spectating();
			case "PlayerWaiting": return PlayerWaiting();
			case "WaitingForPawn": return WaitingForPawn();
			case "RoundEnded": return RoundEnded();
			case "Dead": return Dead();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return PlayerWaiting();
	}
	public PlayerController()
	{
		// Object Offset:0x002897AA
		CameraClass = ClassT<Camera>()/*Ref Class'Camera'*/;
		DebugCameraControllerClass = ClassT<DebugCameraController>()/*Ref Class'DebugCameraController'*/;
		PlayerOwnerDataStoreClass = ClassT<PlayerOwnerDataStore>()/*Ref Class'PlayerOwnerDataStore'*/;
		bDynamicNetSpeed = true;
		bIsUsingStreamingVolumes = true;
		bLogHearSoundOverflow = true;
		bCheckRelevancyThroughPortals = true;
		MaxResponseTime = 0.1250f;
		FOVAngle = 85.0f;
		DesiredFOV = 85.0f;
		DefaultFOV = 85.0f;
		LODDistanceFactor = 1.0f;
		SavedMoveClass = ClassT<SavedMove>()/*Ref Class'SavedMove'*/;
		DynamicPingThreshold = 400.0f;
		LastSpeedHackLog = -100.0f;
		ProgressTimeOut = 8.0f;
		QuickSaveString = "Quick Saving";
		NoPauseMessage = "Game is not pauseable";
		ViewingFrom = "Now viewing from";
		OwnCamera = "Now viewing from own camera";
		CheatClass = ClassT<CheatManager>()/*Ref Class'CheatManager'*/;
		InputClass = ClassT<PlayerInput>()/*Ref Class'PlayerInput'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__PlayerController.CollisionCylinder")/*Ref CylinderComponent'Default__PlayerController.CollisionCylinder'*/;
		ForceFeedbackManagerClassName = "WinDrv.XnaForceFeedbackManager";
		InteractDistance = 512.0f;
		SpectatorCameraSpeed = 600.0f;
		MinRespawnDelay = 1.0f;
		MaxConcurrentHearSounds = 64;
		bIsPlayer = true;
		bCanDoSpecial = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__PlayerController.Sprite")/*Ref SpriteComponent'Default__PlayerController.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__PlayerController.CollisionCylinder")/*Ref CylinderComponent'Default__PlayerController.CollisionCylinder'*/,
		};
		NetPriority = 3.0f;
		CollisionComponent = LoadAsset<CylinderComponent>("Default__PlayerController.CollisionCylinder")/*Ref CylinderComponent'Default__PlayerController.CollisionCylinder'*/;
	}
}
}