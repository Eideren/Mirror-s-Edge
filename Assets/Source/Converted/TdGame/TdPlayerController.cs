// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerController : GamePlayerController, 
		TdController/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public partial struct /*native */ReactionTimeSettings
	{
		public float Easy;
		public float Medium;
		public float Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00612845
	//		Easy = 0.0f;
	//		Medium = 0.0f;
	//		Hard = 0.0f;
	//	}
	};
	
	public partial struct /*native */LocalEnemy
	{
		public TdPawn Enemy;
		public bool bVisible;
		public float LastNetSendTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00612959
	//		Enemy = default;
	//		bVisible = false;
	//		LastNetSendTime = -2.0f;
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_ITdController;
	public bool InfiniteAmmo;
	public /*private config */bool bDebugPostProcessFreeFlight;
	public bool bReleasedJump;
	public bool bLeftThumbStickPassedDeadZone;
	public bool bRightThumbStickPassedDeadZone;
	public bool bDebugCloseCombat;
	public bool bDisableSkipCutscenes;
	public bool bReactionTime;
	public bool bOverrideReactionTimeSettings;
	public bool bJesusMode;
	public bool bStefanMode;
	public bool bIsWalking;
	public bool bIsStopping;
	public bool FailedToSpawn;
	public bool bDisableLoadFromLastCheckpoint;
	public/*(Sounds)*/ /*config */bool bDebugSoundMixGroups;
	public/*(Sounds)*/ /*config */bool bDebugSoundVelocity;
	public/*(Sounds)*/ /*config */bool bDebugSoundReverbVolumes;
	public /*private transient */bool ControllerTilt;
	public /*private */bool VisualizeControllerTilt;
	public bool bRopeburnDisarmSucceeded;
	public float TimePressedJump;
	public /*config */float JumpTapTime;
	public /*config */float BagSearchTapTime;
	public float LastEmoteMessageTime;
	public /*config */float AllowedEmoteMessageInterval;
	public /*private transient */Core.ClassT<TdLocalMessage> TdEmoteMessageClass;
	public /*transient */TdPawn TargetingPawn;
	public /*transient */float TargetingPawnInterp;
	public /*config */float TargetingCutoffAngle;
	public TdPawn TargetPawn;
	public Actor TargetActor;
	public Object.Vector TargetActorLocation;
	public /*config */float LookAtTimeDelay;
	public TdLookAtPoint CurrentLookAtPoint;
	public TdLookAtPoint CurrentForcedLookAtPoint;
	public TdPawn.EMovementAction MeleeLastAction;
	public /*private */byte bIgnoreButtonInput;
	public AudioDevice.ESoundMode CurrentSoundMode;
	public /*transient */TdPawn.WalkingState CachedWalkingState;
	public /*config */float CloseCombatMinRange;
	public /*config */float CloseCombatMaxRange;
	public /*config */float CloseCombatRangeTime;
	public /*config */float CloseCombatMaxAngle;
	public /*config */float CloseCombatPawnDistanceBias;
	public float InputSize;
	public/*(Speed)*/ /*config */float InputMaxSprintRaduisLimit;
	public/*(Speed)*/ /*config */float InputMaxSprintHeightLimit;
	public/*(Speed)*/ /*config */float InputMaxWalkRadiusLimit;
	public/*(WallRunning)*/ /*config */float WallRunningAlignTime;
	public int WallRunningAlignYaw;
	public int LOIIndex;
	public float ReactionTimeEnergy;
	public/*(ReactionTime)*/ /*const config */float ReactionTimeSpawnLevel;
	public/*(ReactionTime)*/ /*const config */float ReactionTimeDrain;
	public/*(ReactionTime)*/ /*const config */float ReactionTimeMaxEffect;
	public/*(ReactionTime)*/ /*const config */float ReactionTimeFadeIn;
	public/*(ReactionTime)*/ /*const config */float ReactionTimeFadeOut;
	public/*(ReactionTime)*/ /*transient */float ReactionTimeEnergyBuildRate;
	public /*private const config */TdPlayerController.ReactionTimeSettings ReactionTimeBuildRates;
	public/*(WallClimbing)*/ /*config */float WallClimbingDodgeJumpThreshold;
	public/*(WallRunning)*/ /*config */float WallRunningDodgeJumpThreshold;
	public /*config */float WalkCyclePart1;
	public /*config */float WalkCyclePart2;
	public /*config */float AccelerationTime;
	public /*config */float StopAnimBlendIn;
	public /*config */float StopAnimBlendOut;
	public /*config */float StoppingVelocity;
	public array<TdPlayerController.LocalEnemy> LocalEnemies;
	public int NextLocalEnemyToCheckLOS;
	public /*transient */float LastEnemyNetSendTime;
	public TdDebugOutput DebugOutput;
	public Object.Rotator VehicleRotation;
	public Object.Rotator DriverRotation;
	public/*(Team)*/ /*config */int Team;
	public TdPlayerPawn myPawn;
	public Actor StickyActor;
	public/*(StickyAim)*/ /*config */float StickySpeed;
	public float FOVZoomRate;
	public /*transient */float FOVZoomDelay;
	public float MouseX;
	public float MouseY;
	public Core.ClassT<Pawn> CharacterClass;
	public /*private */TdAnnouncerBase Announcer;
	public Core.ClassT<UIDataStore_TdTutorialData> TutorialDataClass;
	public Core.ClassT<UIDataStore_TdTimeTrialData> TimeTrialDataClass;
	public Core.ClassT<UIDataStore_TdStringAliasBindingsMap> StringAliasBindingsMapClass;
	public /*protected transient */UIDataStore_TdTutorialData TutorialDataStore;
	public /*protected transient */UIDataStore_TdTimeTrialData TimeTrialDataStore;
	public /*protected transient */UIDataStore_TdStringAliasBindingsMap StringAliasBindingsMapStore;
	public /*protected transient */TdStatsManager StatsManager;
	public /*private transient */float ActualAccelX;
	public /*private transient */float ActualAccelY;
	public /*private transient */float ActualAccelZ;
	public /*config */float SixAxisDisarmZ;
	public /*config */float SixAxisDisarmY;
	public /*config */float SixAxisRollZ;
	public /*config */float SixAxisRollY;
	public /*transient */float DisarmTimeMultiplier;
	public /*private */float LastZAxisTilt;
	public /*private */float LastYAxisTilt;
	public array<SeqEvt_TdWeaponFired> WeaponFiredEvents;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		myPawn;
	//}
	
	// Export UTdPlayerController::execGetTeam(FFrame&, void* const)
	public virtual /*native function */int GetTeam()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPlayerController::execGetAATarget(FFrame&, void* const)
	public virtual /*native function */TdPawn GetAATarget(float MaxDistance)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPlayerController::execGetMeleeTarget(FFrame&, void* const)
	public virtual /*native function */TdPawn GetMeleeTarget(float MaxDistance)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPlayerController::execLocalEnemyActors(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<TdPawn/* enemyIt*/> LocalEnemyActors()
	{
		#warning NATIVE FUNCTION !
		yield break;
	}
	
	// Export UTdPlayerController::execSetSoundModeNative(FFrame&, void* const)
	public virtual /*native final function */void SetSoundModeNative(AudioDevice.ESoundMode SoundMode, float FadeTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPlayerController::execCheckCutsceneSkippable(FFrame&, void* const)
	public virtual /*native function */bool CheckCutsceneSkippable()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */void SetCharacter(String inCharacter)
	{
		CharacterClass = ((DynamicLoadObject(inCharacter, ClassT<Class>(), default(bool?))) as ClassT<Pawn>);
	}
	
	public virtual /*event */TdProfileSettings GetProfileSettings()
	{
		return ((OnlinePlayerData.ProfileProvider.Profile) as TdProfileSettings);
	}
	
	public override /*reliable client simulated event */void TeamMessage(PlayerReplicationInfo PRI, /*coerce */String S, name Type, /*optional */float? _MsgLifeTime = default)
	{
		var MsgLifeTime = _MsgLifeTime ?? default;
		base.TeamMessage(PRI, S, Type, MsgLifeTime);
	}
	
	public virtual /*reliable client simulated function */void ClientOpenScene(name Scene)
	{
		((myHUD) as TdHUD).OpenSceneByName(Scene);
	}
	
	public override /*function */void NotifyTakeHit(Controller InstigatedBy, Object.Vector HitLocation, int Damage, Core.ClassT<DamageType> DamageType, Object.Vector Momentum)
	{
		/*local */int iDam = default;
	
		base.NotifyTakeHit(InstigatedBy, HitLocation, Damage, DamageType, Momentum);
		iDam = Clamp(Damage, 0, 250);
		if(!bGodMode)
		{
			if(InstigatedBy == default)
			{
				ClientPlayTakeHit(vect(0.0f, 0.0f, 0.0f), (byte)((byte)(iDam)), DamageType);			
			}
			else
			{
				ClientPlayTakeHit(InstigatedBy.Pawn.Location - HitLocation, (byte)((byte)(iDam)), DamageType);
			}
		}
	}
	
	public virtual /*exec function */void QuitGame()
	{
		ConsoleCommand("Quit", default(bool?));
	}
	
	public override /*event */void OnLoadLevels(/*optional */bool? _bUnload = default)
	{
		var bUnload = _bUnload ?? false;
		base.OnLoadLevels(bUnload);
		if((myPawn != default) && bUnload)
		{
			myPawn.CameraNoiseControlRoll1p.SetSkelControlStrength(0.0f, 0.10f);
			myPawn.CameraNoiseControlPitch1p.SetSkelControlStrength(0.0f, 0.10f);		
		}
		else
		{
			ConditionalBlockWhileLoading();
		}
	}
	
	public virtual /*function */void ConditionalBlockWhileLoading()
	{
		if((((myHUD != default) && !WorldInfo.IsConsoleBuild(default(WorldInfo.EConsoleType?))) && false) && (!myPawn.bAllowMoveChange || myPawn.bSRPauseTimer))
		{
			((myHUD) as TdHUD).NotifyDiskAccess(true, TsSystem.ETsDiskAccess.TSD_LoadingLevel/*10*/);
			ClientFlushLevelStreaming();
		}
	}
	
	// Export UTdPlayerController::execEnableHighPrioLoading(FFrame&, void* const)
	public virtual /*native function */void EnableHighPrioLoading(/*optional */bool? _bEnable = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void NextViewTarget_del();
	public virtual NextViewTarget_del NextViewTarget { get => bfield_NextViewTarget ?? TdPlayerController_NextViewTarget; set => bfield_NextViewTarget = value; } NextViewTarget_del bfield_NextViewTarget;
	public virtual NextViewTarget_del global_NextViewTarget => TdPlayerController_NextViewTarget;
	public /*exec function */void TdPlayerController_NextViewTarget()
	{
	
	}
	
	public delegate void PrevViewTarget_del();
	public virtual PrevViewTarget_del PrevViewTarget { get => bfield_PrevViewTarget ?? TdPlayerController_PrevViewTarget; set => bfield_PrevViewTarget = value; } PrevViewTarget_del bfield_PrevViewTarget;
	public virtual PrevViewTarget_del global_PrevViewTarget => TdPlayerController_PrevViewTarget;
	public /*exec function */void TdPlayerController_PrevViewTarget()
	{
	
	}
	
	public virtual /*unreliable client simulated function */void ClientPlayTakeHit(Object.Vector HitLoc, byte Damage, Core.ClassT<DamageType> DamageType)
	{
		if(myHUD.IsA("TdHUD"))
		{
			((myHUD) as TdHUD).PlayTakeHit(HitLoc, ((int)Damage), DamageType);
		}
	}
	
	public override /*reliable client simulated function */void ClientSetHUD(Core.ClassT<HUD> newHUDType, Core.ClassT<ScoreBoard> newScoringType)
	{
		/*local */TdProfileSettings ProfileSettings = default;
		/*local */int Value = default;
		/*local */TdHUD myTdHUD = default;
		/*local */TdSPHUD myTdSPHUD = default;
		/*local */Core.ClassT<TdAnnouncerBase> AnnouncerClass = default;
	
		base.ClientSetHUD(newHUDType, newScoringType);
		myTdHUD = ((myHUD) as TdHUD);
		if((myTdHUD != default) && myTdHUD.AnnouncerClassName != "")
		{
			AnnouncerClass = ((DynamicLoadObject(myTdHUD.AnnouncerClassName, ClassT<Class>(), default(bool?))) as ClassT<TdAnnouncerBase>);
			if(AnnouncerClass != default)
			{
				Announcer = Spawn(AnnouncerClass, this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
			}
		}
		ProfileSettings = GetProfileSettings();
		if((ProfileSettings != default) && ProfileSettings.GetProfileSettingValueIdByName("Reticule", ref/*probably?*/ Value))
		{
			myTdSPHUD = ((myHUD) as TdSPHUD);
			if(myTdSPHUD != default)
			{
				myTdSPHUD.SetDrawCrosshairFlag(((TdProfileSettings.EReticuleValues)((byte)(Value))));
			}
		}
	}
	
	public virtual /*reliable client simulated function */void ClientPlayAnnouncement(Core.ClassT<TdLocalMessage> InMessageClass, int Switch, /*optional */PlayerReplicationInfo? _PRI_1 = default, /*optional */PlayerReplicationInfo? _PRI_2 = default)
	{
		/*local */SoundNodeWave Announcement = default;
	
		var PRI_1 = _PRI_1 ?? default;
		var PRI_2 = _PRI_2 ?? default;
		Announcement = InMessageClass.Static.GetAnnouncementSound(this, Switch, PRI_1, PRI_2, default(Object?));
		PlayAnnouncement(InMessageClass, Announcement);
	}
	
	public virtual /*function */void PlayAnnouncement(Core.ClassT<TdLocalMessage> InMessageClass, SoundNodeWave Announcement)
	{
		if(((WorldInfo.GRI == default) || Announcer == default))
		{
			return;
		}
		Announcer.PlayAnnouncement(InMessageClass, Announcement);
	}
	
	public virtual /*final exec function */void TriggerEmoteMessage(int Switch)
	{
		if((WorldInfo.GRI.IsMultiplayerGame() && myPawn != default) && (LastEmoteMessageTime + AllowedEmoteMessageInterval) < WorldInfo.TimeSeconds)
		{
			LastEmoteMessageTime = WorldInfo.TimeSeconds;
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				TdAnnouncerBase.Play3DLocationalAnnouncement(myPawn, TdEmoteMessageClass, Switch, false, false, PlayerReplicationInfo, default(PlayerReplicationInfo?));
			}
			ServerTriggerEmoteMessage(Switch);
		}
	}
	
	public virtual /*unreliable server final function */void ServerTriggerEmoteMessage(int Switch)
	{
		TdAnnouncerBase.Play3DLocationalAnnouncement(myPawn, TdEmoteMessageClass, Switch, true, false, PlayerReplicationInfo, default(PlayerReplicationInfo?));
	}
	
	public virtual /*function */void NotifyWeaponFired(Weapon PlayerWeapon)
	{
		/*local */int Index = default;
		/*local */SeqEvt_TdWeaponFired WeaponFiredEvent = default;
	
		Index = 0;
		J0x07:{}
		if(Index < WeaponFiredEvents.Length)
		{
			WeaponFiredEvent = WeaponFiredEvents[Index];
			if(WeaponFiredEvent == default)
			{
				goto J0xD1;
			}
			if((WeaponFiredEvent.ConditionalWeaponClass != default) && !ClassIsChildOf(PlayerWeapon.Class, WeaponFiredEvent.ConditionalWeaponClass))
			{
				goto J0xD1;
			}
			if((WeaponFiredEvent.ConditionalVolume != default) && !myPawn.IsTouchingVolume(WeaponFiredEvent.ConditionalVolume))
			{
				goto J0xD1;
			}
			WeaponFiredEvent.CheckActivate(this, PlayerWeapon, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
			J0xD1:{}
			++ Index;
			goto J0x07;
		}
	}
	
	public virtual /*exec function */void ReloadWeapon()
	{
		if(((((((int)myPawn.Moves[((int)myPawn.MovementState)].MovementGroup) > ((int)TdMove.EMovementGroup.MG_Free/*0*/)) || ((int)myPawn.AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/))) || ((int)myPawn.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/)))
		{
			return;
		}
		UnZoom();
		((Pawn.Weapon) as TdWeapon).ReloadWeapon();
	}
	
	public delegate void PressedSwitchWeapon_del();
	public virtual PressedSwitchWeapon_del PressedSwitchWeapon { get => bfield_PressedSwitchWeapon ?? TdPlayerController_PressedSwitchWeapon; set => bfield_PressedSwitchWeapon = value; } PressedSwitchWeapon_del bfield_PressedSwitchWeapon;
	public virtual PressedSwitchWeapon_del global_PressedSwitchWeapon => TdPlayerController_PressedSwitchWeapon;
	public /*exec function */void TdPlayerController_PressedSwitchWeapon()
	{
		/*local */TdInventoryManager InvMan = default;
		/*local */TdMOVE_Disarm DisarmMove = default;
	
		if(IsButtonInputIgnored())
		{
			return;
		}
		myPawn.OnTutorialEvent(19);
		InvMan = ((Pawn.InvManager) as TdInventoryManager);
		DisarmTimeMultiplier = 1.0f;
		if(((((((((((((((((((((int)myPawn.AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/)) || ((int)myPawn.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/))) || WorldInfo.Pauser != default)) || myPawn.IsFiring())) || myPawn.IsReloading())) || bCinematicMode)) || ((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Falling/*2*/))) || ((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Landing/*20*/))) || ((int)myPawn.Moves[((int)myPawn.MovementState)].MovementGroup) > ((int)TdMove.EMovementGroup.MG_Free/*0*/))) || ((myPawn.Weapon) as TdWeapon).IsZooming()))
		{
			return;		
		}
		else
		{
			if(myPawn.Weapon != default)
			{
				UnZoom();
				myPawn.DropWeapon();
				return;			
			}
			else
			{
				if(SnatchAttempt())
				{
					return;				
				}
				else
				{
					if((InvMan != default) && myPawn.Moves[((int)myPawn.MovementState)].bAllowPickup)
					{
						InvMan.PressedSwitchWeapon();
						if(myPawn.Weapon == default)
						{
							DisarmMove = ((myPawn.Moves[18]) as TdMOVE_Disarm);
							DisarmMove.ForceMiss(true);
							myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Snatch/*4*/);
						}
					}
				}
			}
		}
		if((myPawn.Weapon != default) && myPawn.Weapon.IsA("TdWeapon_Sniper_BarretM95"))
		{
			CallPopUp(TdSPHUD.EPopUpType.PUT_Sniper/*1*/, 4.0f);
		}
	}
	
	public override NextWeapon_del NextWeapon { get => bfield_NextWeapon ?? TdPlayerController_NextWeapon; set => bfield_NextWeapon = value; } NextWeapon_del bfield_NextWeapon;
	public override NextWeapon_del global_NextWeapon => TdPlayerController_NextWeapon;
	public /*exec function */void TdPlayerController_NextWeapon()
	{
	
	}
	
	public override PrevWeapon_del PrevWeapon { get => bfield_PrevWeapon ?? TdPlayerController_PrevWeapon; set => bfield_PrevWeapon = value; } PrevWeapon_del bfield_PrevWeapon;
	public override PrevWeapon_del global_PrevWeapon => TdPlayerController_PrevWeapon;
	public /*exec function */void TdPlayerController_PrevWeapon()
	{
	
	}
	
	public virtual /*exec function */void PickWeapon(int Index)
	{
		/*local */TdInventoryManager InvMan = default;
	
		if(WorldInfo.Pauser != default)
		{
			return;
		}
		InvMan = ((Pawn.InvManager) as TdInventoryManager);
		if(InvMan != default)
		{
			UnZoom();
			InvMan.SwitchToSpecificWeapon(Index);
		}
	}
	
	public virtual /*exec function */void ListWeapons()
	{
		/*local */TdInventoryManager InvMan = default;
	
		if(WorldInfo.Pauser != default)
		{
			return;
		}
		InvMan = ((Pawn.InvManager) as TdInventoryManager);
		if(InvMan != default)
		{
			InvMan.ListInventory();
		}
	}
	
	public virtual /*exec function */void LockCameraOnTarget(/*optional */byte? _FireModeNum = default)
	{
		/*local */Object.Vector CamLoc = default, StartShot = default, EndShot = default, X = default, Y = default, Z = default,
			HitLocation = default, HitNormal = default, ZeroVec = default;
	
		/*local */Actor HitActor = default;
		/*local */Actor.TraceHitInfo HitInfo = default;
		/*local */Object.Rotator CamRot = default;
	
		var FireModeNum = _FireModeNum ?? default;
		if(PlayerCamera.CameraStyle != "FreeFlight")
		{
			return;
		}
		GetPlayerViewPoint(ref/*probably?*/ CamLoc, ref/*probably?*/ CamRot);
		GetAxes(CamRot, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		ZeroVec = vect(0.0f, 0.0f, 0.0f);
		StartShot = CamLoc;
		EndShot = StartShot + (10000.0f * X);
		HitActor = Pawn.Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, EndShot, StartShot, true, ZeroVec, ref/*probably?*/ HitInfo, default(int?));
		if(HitActor != default)
		{
			SetCameraMode("FixedPerson");
			SetFixedPersonCameraSettings(HitActor);
		}
	}
	
	public virtual /*exec function */void SwitchMesh(/*optional */byte? _FireModeNum = default)
	{
		var FireModeNum = _FireModeNum ?? default;
		if(myPawn.Mesh == myPawn.Mesh3p)
		{
			myPawn.SetFirstPerson(true);		
		}
		else
		{
			myPawn.SetFirstPerson(false);
		}
	}
	
	public virtual /*function */void SetFixedPersonCameraSettings(Actor A)
	{
		((PlayerCamera) as TdPlayerCamera).FreeflightPosition = ((PlayerCamera) as TdPlayerCamera).FreeflightPosition - A.Location;
		((PlayerCamera) as TdPlayerCamera).FixedPersonDistance = VSize(((PlayerCamera) as TdPlayerCamera).FreeflightPosition);
		((PlayerCamera) as TdPlayerCamera).FreeflightPosition = Normal(((PlayerCamera) as TdPlayerCamera).FreeflightPosition);
		((PlayerCamera) as TdPlayerCamera).FixedPersonVectorRelativeRotator = A.Rotation;
		((PlayerCamera) as TdPlayerCamera).FreeflightRotation = ((PlayerCamera) as TdPlayerCamera).FreeflightRotation - A.Rotation;
		myPawn.StopIgnoreMoveInput();
		myPawn.StopIgnoreLookInput();
		PlayerCamera.SetViewTarget(A, default(Camera.ViewTargetTransitionParams?));
	}
	
	public virtual /*function */void OnTdSlideshow(SeqAct_TdSlideShow Action)
	{
	
	}
	
	public override /*function */void OnControllerChanged(int ControllerId, bool bIsConnected)
	{
		/*local */LocalPlayer LocPlayer = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		if((LocPlayer != default) && LocPlayer.ControllerId == ControllerId)
		{
			bIsControllerConnected = bIsConnected;
			if((bIsConnected == false) && !IsInMainMenu())
			{
				DelayedPauseGame();
			}
		}
	}
	
	public override /*function */void OnExternalUIChanged(bool bIsOpening)
	{
		/*local */GameUISceneClient SceneClient = default;
	
		SceneClient = UIRoot.GetSceneClient();
		if(WorldInfo.IsConsoleBuild(WorldInfo.EConsoleType.CONSOLE_PS3/*2*/))
		{
			SceneClient.bInputIntercepted = bIsOpening;
		}
		SceneClient.ActivateBGSaturation(bIsOpening, 2);
		bIsExternalUIOpen = bIsOpening;
		if(bIsOpening && !IsInMainMenu())
		{
			DelayedPauseGame();
		}
	}
	
	public virtual /*function */void TdPlayerFailDead()
	{
		GotoState("Dead", default(name?), default(bool?), default(bool?));
	}
	
	public virtual /*function */void OnTdPlayerFail(SeqAct_TdPlayerFail FailAction)
	{
		/*local */TdHUD HUD = default;
	
		HUD = ((myHUD) as TdHUD);
		if(HUD != default)
		{
			HUD.TriggerCustomColorFadeOut(0.10f, MakeLinearColor(0.0f, 0.0f, 0.0f, 1.0f), default(bool?), default(/*delegate*/TdHUD.OnMaxFade?));
		}
		SetTimer(0.20f, false, "TdPlayerFailDead", default(Object?));
	}
	
	public virtual /*function */bool IsInMainMenu()
	{
		return ApproximatelyEqual(WorldInfo.GetMapName(default(bool?)), "TDMAINMENU");
	}
	
	public override /*function */void SetCameraMode(name NewCamMode)
	{
		/*local */bool bUsePp = default;
	
		bUsePp = NewCamMode == "FirstPerson";
		if(myHUD != default)
		{
			((myHUD) as TdHUD).EffectManager.TogglePostProcessEffects(bUsePp);
		}
		base.SetCameraMode(NewCamMode);
	}
	
	public virtual /*exec function */void FreeFlightCamera(/*optional */byte? _FireModeNum = default)
	{
		var FireModeNum = _FireModeNum ?? default;
		if(PlayerCamera.CameraStyle == "FreeFlight")
		{
			SetCameraMode("FixedPerson");
			SetFixedPersonCameraSettings(Pawn);		
		}
		else
		{
			if(PlayerCamera.CameraStyle == "FixedPerson")
			{
				SetCameraMode("Fixed");
				PlayerCamera.SetViewTarget(Pawn, default(Camera.ViewTargetTransitionParams?));			
			}
			else
			{
				if(PlayerCamera.CameraStyle == "Fixed")
				{
					SetCameraMode("FreeCam");				
				}
				else
				{
					if(PlayerCamera.CameraStyle == "FreeCam")
					{
						SetCameraMode("ThirdPerson");					
					}
					else
					{
						if(PlayerCamera.CameraStyle == "ThirdPerson")
						{
							if(myPawn != default)
							{
								myPawn.SetFirstPerson(true);
							}
							SetCameraMode("FirstPerson");						
						}
						else
						{
							if(PlayerCamera.IsA("TdPlayerCamera"))
							{
								SetCameraMode("FreeFlight");
								((PlayerCamera) as TdPlayerCamera).FreeflightPosition = Pawn.Location;
								((PlayerCamera) as TdPlayerCamera).FreeflightRotation = Pawn.Rotation;
								myPawn.SetIgnoreMoveInput(default(float?));
								myPawn.SetIgnoreLookInput(default(float?));
								myPawn.SetFirstPerson(false);
								myPawn.Mesh.ForceSkelUpdate();
							}
						}
					}
				}
			}
		}
	}
	
	public virtual /*unreliable server function */void ReplicateSound(SoundCue SCue, Pawn Source)
	{
		/*local */PlayerController PC = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			PC.ClientHearSound(SCue, Source, Source.Location, true, default(bool?));		
		}	
	}
	
	public override /*unreliable client simulated event */void ClientHearSound(SoundCue ASound, Actor SourceActor, Object.Vector SourceLocation, bool bStopWhenOwnerDestroyed, /*optional */bool? _bIsOccluded = default)
	{
		/*local *//*editinline */AudioComponent AC = default;
	
		var bIsOccluded = _bIsOccluded ?? default;
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
			if(((((SourceActor == (GetViewTarget())) || SourceActor == this)) || SourceActor == Pawn))
			{
				AC = GetPooledAudioComponent(ASound, default, bStopWhenOwnerDestroyed, default(bool?), default(Object.Vector?));
				if(AC == default)
				{
					return;
				}
				if(!IsZero(SourceLocation) && SourceLocation != SourceActor.Location)
				{
					AC.bUseOwnerLocation = false;
					AC.Location = SourceLocation;
					AC.bAllowSpatialization = true;				
				}
				else
				{
					AC.bAllowSpatialization = false;
				}			
			}
			else
			{
				AC = GetPooledAudioComponent(ASound, SourceActor, bStopWhenOwnerDestroyed, default(bool?), default(Object.Vector?));
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
	
	public virtual /*reliable client simulated event */void Kismet_ClientTdPlaySound(SoundCue ASound, Actor SourceActor, float VolumeMultiplier, float PitchMultiplier, float LowPassMultiplier, float OcclusionCheckInterval, float OcclusionVolumeDuckLevel, float OcclusionFilterDuckLevel, float OcclusionFadeTime, float FadeInTime, bool bSuppressSubtitles, bool bSuppressSpatialization, Object.Vector SoundOffset, bool bSoundOffsetDebug)
	{
		/*local *//*editinline */AudioComponent AC = default;
	
		if(SourceActor != default)
		{
			if((ASound.FaceFXAnimName != "") && SourceActor.PlayActorFaceFXAnim(ASound.FaceFXAnimSetRef, ASound.FaceFXGroupName, ASound.FaceFXAnimName))
			{			
			}
			else
			{
				AC = GetPooledAudioComponent(ASound, SourceActor, true, default(bool?), default(Object.Vector?));
				if(AC != default)
				{
					AC.VolumeMultiplier = VolumeMultiplier;
					AC.PitchMultiplier = PitchMultiplier;
					AC.LowPassMultiplier = LowPassMultiplier;
					AC.SubtitlePriority = 10000.0f;
					AC.bSuppressSubtitles = bSuppressSubtitles;
					AC.FadeIn(FadeInTime, 1.0f);
					if(bSuppressSpatialization)
					{
						AC.bAllowSpatialization = false;					
					}
					else
					{
						AC.OcclusionCheckInterval = OcclusionCheckInterval;
						AC.OcclusionVolumeDuckLevel = OcclusionVolumeDuckLevel;
						AC.OcclusionFilterDuckLevel = OcclusionFilterDuckLevel;
						AC.OcclusionFadeTime = OcclusionFadeTime;
						AC.LocationOffset = SoundOffset;
						AC.bDebugOffset = bSoundOffsetDebug;
					}
				}
			}
			if((((((((ASound.SoundGroup == "VOMain") || ASound.SoundGroup == "DialogueRadio")) || ASound.SoundGroup == "DialogueFaith")) || ASound.SoundGroup == "DialogueOther")) && !(WorldInfo.Game != default) && WorldInfo.Game.IsA("TdSPTimeTrialGame"))
			{
				SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_INGAME_VO/*2*/, ASound.GetCueDuration() + 0.30f, default(bool?), default(float?));
			}
		}
	}
	
	public virtual /*simulated function */bool CanDoSoundMode(AudioDevice.ESoundMode SoundMode)
	{
		switch(SoundMode)
		{
			case AudioDevice.ESoundMode.SOUNDMODE_INGAME_VO/*2*/:
				if((((((((((bReactionTime || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_GENERIC_DEATH/*9*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_DEATH_BY_FALLING/*8*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_INGAME_CUTSCENES/*1*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_CUSTOM_TRACK_INGAME_CUTSCENES/*7*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_FALLING_TO_DEATH/*6*/)))
				{
					return false;
				}
				break;
			case AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/:
				if(bReactionTime)
				{
					return false;
				}
				goto case AudioDevice.ESoundMode.SOUNDMODE_REACTION_TIME/*3*/;// UnrealScript fallthrough
			case AudioDevice.ESoundMode.SOUNDMODE_REACTION_TIME/*3*/:
			case AudioDevice.ESoundMode.SOUNDMODE_PAUSE/*4*/:
				if(((((((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_GENERIC_DEATH/*9*/)) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_DEATH_BY_FALLING/*8*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_FALLING_TO_DEATH/*6*/)))
				{
					return false;
				}
				break;
			case AudioDevice.ESoundMode.SOUNDMODE_INGAME_CUTSCENES/*1*/:
				if(((((((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_GENERIC_DEATH/*9*/)) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_DEATH_BY_FALLING/*8*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_FALLING_TO_DEATH/*6*/)))
				{
					return false;
				}
				break;
			case AudioDevice.ESoundMode.SOUNDMODE_CUSTOM_TRACK_INGAME_CUTSCENES/*7*/:
				if(((((((((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_INGAME_CUTSCENES/*1*/)) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_GENERIC_DEATH/*9*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_DEATH_BY_FALLING/*8*/))) || ((int)CurrentSoundMode) == ((int)AudioDevice.ESoundMode.SOUNDMODE_FALLING_TO_DEATH/*6*/)))
				{
					return false;
				}
				break;
			default:
				break;
		}
		return true;
	}
	
	public virtual /*function */void SetSoundMode(AudioDevice.ESoundMode SoundMode, /*optional */float? _Duration = default, /*optional */bool? _WithForce = default, /*optional */float? _FadeTime = default)
	{
		var Duration = _Duration ?? default;
		var WithForce = _WithForce ?? false;
		var FadeTime = _FadeTime ?? default;
		if(!WithForce && !CanDoSoundMode(((AudioDevice.ESoundMode)SoundMode)))
		{
			return;
		}
		if((Duration > 0.0f) && ((((int)CurrentSoundMode) != ((int)SoundMode)) || GetTimerRate("ClearSoundMode", default(Object?)) < Duration))
		{
			SetTimer(Duration, false, "ClearSoundMode", default(Object?));
		}
		CurrentSoundMode = ((AudioDevice.ESoundMode)SoundMode);
		SetSoundModeNative(((AudioDevice.ESoundMode)SoundMode), FadeTime);
	}
	
	public virtual /*simulated function */void ClearSoundMode()
	{
		if(IsDead())
		{
			SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_GENERIC_DEATH/*9*/, default(float?), default(bool?), default(float?));		
		}
		else
		{
			if(this.IsInState("PlayerDying", default(bool?)) && ((int)myPawn.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
			{
				SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_FALLING_TO_DEATH/*6*/, default(float?), default(bool?), default(float?));			
			}
			else
			{
				if(bReactionTime)
				{
					SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_REACTION_TIME/*3*/, default(float?), default(bool?), default(float?));				
				}
				else
				{
					SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/, default(float?), default(bool?), default(float?));
				}
			}
		}
	}
	
	// Export UTdPlayerController::execStopSounds(FFrame&, void* const)
	public virtual /*native final function */void StopSounds(float FadeOutTime, /*optional */name? _SoundGroup = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*exec function */void ToggleServerDebugger()
	{
		ToggleDebugger();
	}
	
	// Export UTdPlayerController::execToggleDebugger(FFrame&, void* const)
	public virtual /*reliable server native final function */void ToggleDebugger()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override StartAltFire_del StartAltFire { get => bfield_StartAltFire ?? TdPlayerController_StartAltFire; set => bfield_StartAltFire = value; } StartAltFire_del bfield_StartAltFire;
	public override StartAltFire_del global_StartAltFire => TdPlayerController_StartAltFire;
	public /*exec function */void TdPlayerController_StartAltFire(/*optional */byte? _FireModeNum = default)
	{
		var FireModeNum = _FireModeNum ?? default;
	}
	
	public override /*exec function */void StopAltFire(/*optional */byte? _FireModeNum = default)
	{
		var FireModeNum = _FireModeNum ?? default;
	}
	
	public override StartFire_del StartFire { get => bfield_StartFire ?? TdPlayerController_StartFire; set => bfield_StartFire = value; } StartFire_del bfield_StartFire;
	public override StartFire_del global_StartFire => TdPlayerController_StartFire;
	public /*exec function */void TdPlayerController_StartFire(/*optional */byte? _FireModeNum = default)
	{
		var FireModeNum = _FireModeNum ?? default;
		if(((((myPawn.Weapon.IsA("TdWeapon_Light") && ((int)myPawn.Moves[((int)myPawn.MovementState)].MovementGroup) >= ((int)TdMove.EMovementGroup.MG_TwoHandsBusy/*2*/)) || myPawn.Weapon.IsA("TdWeapon_Heavy") && ((int)myPawn.Moves[((int)myPawn.MovementState)].MovementGroup) >= ((int)TdMove.EMovementGroup.MG_OneHandBusy/*1*/))) || ((int)myPawn.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/)))
		{
			return;
		}
		/*Transformed 'base.' to specific call*/PlayerController_StartFire((byte)FireModeNum);
	}
	
	public override /*function */void Pause()
	{
		if(!WorldInfo.Game.IsTdPaused())
		{
			WorldInfo.Game.TdPause();
		}
	}
	
	public virtual /*exec function */void PauseGame()
	{
		((myHUD) as TdHUD).PauseGame();
	}
	
	public virtual /*function */void DelayedPauseGame()
	{
		((myHUD) as TdHUD).DelayedPauseGame();
	}
	
	public virtual /*exec function */void OpenInGameMenu()
	{
		if(!IsButtonInputIgnored())
		{
			((myHUD) as TdHUD).OpenInGameMenu();
		}
	}
	
	public virtual /*function */PlayerOwnerDataStore GetCurrentPlayerData()
	{
		return CurrentPlayerData;
	}
	
	public override ClientRestart_del ClientRestart { get => bfield_ClientRestart ?? TdPlayerController_ClientRestart; set => bfield_ClientRestart = value; } ClientRestart_del bfield_ClientRestart;
	public override ClientRestart_del global_ClientRestart => TdPlayerController_ClientRestart;
	public /*reliable client simulated function */void TdPlayerController_ClientRestart(Pawn NewPawn)
	{
		/*Transformed 'base.' to specific call*/PlayerController_ClientRestart(NewPawn);
		bReactionTime = false;
		ReactionTimeEnergy = ReactionTimeSpawnLevel;
		bOverrideReactionTimeSettings = false;
		AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_EndFullMomentum/*7*/);
		WorldInfo.Game.SetGameSpeed(1.0f);
		if(myHUD != default)
		{
			((myHUD) as TdHUD).PlayerOwnerRestart();
		}
		SetAudioProfileSettings();
		SetPause(false, default(/*delegate*/PlayerController.CanUnpause?));
		SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/, default(float?), true, 1.50f);
	}
	
	public virtual /*function */void ForcePreRoundSpectate()
	{
		/*local */Pawn PawnToKill = default;
	
		if(Pawn != default)
		{
			PawnToKill = Pawn;
			Pawn.StopFiring();
			UnPossess();
			PawnToKill.Died(default, default, PawnToKill.Location);
			PawnToKill.Destroy();
		}
		GotoState("PlayerWaiting", default(name?), default(bool?), default(bool?));
		if(!ViewTarget.IsA("TdSpectatorPoint"))
		{
			ServerViewNextSpectatorPoint();
		}
	}
	
	public virtual /*reliable client simulated function */void ClientForcePreRoundSpectate()
	{
		/*local */Pawn PawnToKill = default;
	
		if(Pawn != default)
		{
			PawnToKill = Pawn;
			Pawn.StopFiring();
			UnPossess();
			PawnToKill.Died(default, default, PawnToKill.Location);
			PawnToKill.Destroy();
		}
		GotoState("PlayerWaiting", default(name?), default(bool?), default(bool?));
		if(!ViewTarget.IsA("TdSpectatorPoint"))
		{
			ServerViewNextSpectatorPoint();
		}
	}
	
	public delegate void NextStaticViewTarget_del();
	public virtual NextStaticViewTarget_del NextStaticViewTarget { get => bfield_NextStaticViewTarget ?? TdPlayerController_NextStaticViewTarget; set => bfield_NextStaticViewTarget = value; } NextStaticViewTarget_del bfield_NextStaticViewTarget;
	public virtual NextStaticViewTarget_del global_NextStaticViewTarget => TdPlayerController_NextStaticViewTarget;
	public /*exec function */void TdPlayerController_NextStaticViewTarget()
	{
	
	}
	
	public delegate void PrevStaticViewTarget_del();
	public virtual PrevStaticViewTarget_del PrevStaticViewTarget { get => bfield_PrevStaticViewTarget ?? TdPlayerController_PrevStaticViewTarget; set => bfield_PrevStaticViewTarget = value; } PrevStaticViewTarget_del bfield_PrevStaticViewTarget;
	public virtual PrevStaticViewTarget_del global_PrevStaticViewTarget => TdPlayerController_PrevStaticViewTarget;
	public /*exec function */void TdPlayerController_PrevStaticViewTarget()
	{
	
	}
	
	public virtual /*unreliable server final function */void ServerViewNextSpectatorPoint()
	{
		/*local */TdGameInfo MyGameClass = default;
		/*local */TdSpectatorPoint NewSpectatorPoint = default, CurrSpectatorPoint = default;
	
		MyGameClass = ((WorldInfo.Game) as TdGameInfo);
		if(MyGameClass != default)
		{
			CurrSpectatorPoint = ((GetViewTarget()) as TdSpectatorPoint);
			if(CurrSpectatorPoint != default)
			{
				NewSpectatorPoint = MyGameClass.GetNextSpectatorPoint(CurrSpectatorPoint);			
			}
			else
			{
				NewSpectatorPoint = MyGameClass.GetFirstSpectatorPoint();
			}
			if(NewSpectatorPoint != default)
			{
				SetViewTarget(NewSpectatorPoint, default(Camera.ViewTargetTransitionParams?));
				ClientSetViewTarget(NewSpectatorPoint, default(Camera.ViewTargetTransitionParams?));			
			}
			else
			{
				ServerViewNextPlayer();
			}
		}
	}
	
	public virtual /*unreliable server final function */void ServerViewPrevSpectatorPoint()
	{
		/*local */TdGameInfo MyGameClass = default;
		/*local */TdSpectatorPoint NewSpectatorPoint = default, CurrSpectatorPoint = default;
	
		MyGameClass = ((WorldInfo.Game) as TdGameInfo);
		if(MyGameClass != default)
		{
			CurrSpectatorPoint = ((GetViewTarget()) as TdSpectatorPoint);
			if(CurrSpectatorPoint != default)
			{
				NewSpectatorPoint = MyGameClass.GetPrevSpectatorPoint(CurrSpectatorPoint);			
			}
			else
			{
				NewSpectatorPoint = MyGameClass.GetFirstSpectatorPoint();
			}
			if(NewSpectatorPoint != default)
			{
				SetViewTarget(NewSpectatorPoint, default(Camera.ViewTargetTransitionParams?));
				ClientSetViewTarget(NewSpectatorPoint, default(Camera.ViewTargetTransitionParams?));			
			}
			else
			{
				ServerViewNextPlayer();
			}
		}
	}
	
	public override /*function */bool ViewAPlayer(int Dir)
	{
		/*local */TdPlayerPawn PlayerPawn = default;
		/*local */bool bSuccess = default;
	
		bSuccess = base.ViewAPlayer(Dir);
		if(!bSuccess)
		{
			PlayerPawn = ((WorldInfo.PawnList) as TdPlayerPawn);
			if(PlayerPawn != default)
			{
				SetViewTarget(PlayerPawn, default(Camera.ViewTargetTransitionParams?));
				if(PlayerCamera.CameraStyle == "ThirdPerson")
				{
					SetCameraMode("FirstPerson");
					PlayerPawn.SetFirstPerson(true);				
				}
				else
				{
					SetCameraMode("ThirdPerson");
					PlayerPawn.SetFirstPerson(false);
				}
				return true;
			}
		}
		return bSuccess;
	}
	
	public override PawnDied_del PawnDied { get => bfield_PawnDied ?? TdPlayerController_PawnDied; set => bfield_PawnDied = value; } PawnDied_del bfield_PawnDied;
	public override PawnDied_del global_PawnDied => TdPlayerController_PawnDied;
	public /*function */void TdPlayerController_PawnDied(Pawn inPawn)
	{
		/*local */Object.Vector EyeLocation = default;
		/*local */Object.Rotator EyeRotation = default;
	
		GetActorEyesViewPoint(ref/*probably?*/ EyeLocation, ref/*probably?*/ EyeRotation);
		/*Transformed 'base.' to specific call*/PlayerController_PawnDied(inPawn);
		SetLocation(EyeLocation);
		SetRotation(EyeRotation);
	}
	
	public override /*event */void KickWarning()
	{
		ReceiveLocalizedMessage(ClassT<TdGameMessage>(), 15, default(PlayerReplicationInfo?), default(PlayerReplicationInfo?), default(Object?));
	}
	
	public virtual /*function */Object.Vector GetFloor()
	{
		return OldFloor;
	}
	
	public virtual /*function */float GetGrabJumpTime()
	{
		return 0.0f;
	}
	
	public virtual /*exec function */void SetCameraRotationAid(Object.Rotator desiredRot)
	{
	
	}
	
	public virtual /*function */void OnMovementStateChange(name NewState)
	{
		if(GetStateName() != NewState)
		{
			GotoState(NewState, default(name?), default(bool?), default(bool?));
		}
	}
	
	// Export UTdPlayerController::execMaintainEnemyList(FFrame&, void* const)
	public virtual /*native final function */void MaintainEnemyList()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override PlayerTick_del PlayerTick { get => bfield_PlayerTick ?? TdPlayerController_PlayerTick; set => bfield_PlayerTick = value; } PlayerTick_del bfield_PlayerTick;
	public override PlayerTick_del global_PlayerTick => TdPlayerController_PlayerTick;
	public /*event */void TdPlayerController_PlayerTick(float DeltaTime)
	{
		MaintainEnemyList();
		MouseX = PlayerInput.aMouseX;
		MouseY = PlayerInput.aMouseY;
		if(ControllerTilt)
		{
			ActualAccelX = PlayerInput.aPS3AccelX;
			ActualAccelY = PlayerInput.aPS3AccelY;
			ActualAccelZ = PlayerInput.aPS3AccelZ;		
		}
		else
		{
			ActualAccelX = 0.0f;
			ActualAccelY = 0.0f;
			ActualAccelZ = 0.0f;
		}
		/*Transformed 'base.' to specific call*/PlayerController_PlayerTick(DeltaTime);
		UpdateReactionTime(DeltaTime);
		if(!WorldInfo.IsPlayInEditor())
		{
			UpdateMomentumStats(DeltaTime);
		}
	}
	
	public virtual /*function */void UpdateMomentumStats(float DeltaTime)
	{
		if(myPawn == default)
		{
			if(((int)CachedWalkingState) == ((int)TdPawn.WalkingState.WAS_Sprint/*5*/))
			{
				AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_EndFullMomentum/*7*/);
			}		
		}
		else
		{
			if(((int)myPawn.CurrentWalkingState) != ((int)CachedWalkingState))
			{
				if((((int)myPawn.CurrentWalkingState) == ((int)TdPawn.WalkingState.WAS_Sprint/*5*/)) && !myPawn.bUncontrolledSlide)
				{
					AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_StartFullMomentum/*6*/);				
				}
				else
				{
					AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_EndFullMomentum/*7*/);
				}
				CachedWalkingState = ((TdPawn.WalkingState)myPawn.CurrentWalkingState);			
			}
			else
			{
				if((((int)CachedWalkingState) == ((int)TdPawn.WalkingState.WAS_Sprint/*5*/)) && myPawn.bUncontrolledSlide)
				{
					AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_EndFullMomentum/*7*/);
				}
			}
		}
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */Canvas Canvas = default;
	
		Canvas = HUD.Canvas;
		Canvas.SetDrawColor(255, 255, 255, 255);
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText((((("CONTROLLER " + (GetItemName(((this)).ToString()))) + " Physics ") + (GetPhysicsName())) + " Pawn ") + (GetItemName(((Pawn)).ToString())), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		if(Pawn == default)
		{
			if(PlayerReplicationInfo == default)
			{
				Canvas.DrawText("NO PLAYERREPLICATIONINFO", false, default(float?), default(float?));			
			}
			else
			{
				PlayerReplicationInfo.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
			}
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			#warning commented out UI debug function
			// base(Actor).DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		}
		if((PlayerCamera != default) && HUD.ShouldDisplayDebug("Camera"))
		{
			PlayerCamera.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		}
		Canvas.SetDrawColor(0, 255, 0, 255);
		out_YPos += (out_YL + ((float)(10)));
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Current State: " + ((GetStateName())).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Physics state: " + (GetPhysicsName()), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Ignore look: " + ((bIgnoreLookInput)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Ignore move: " + ((bIgnoreMoveInput)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Ibnore button: " + ((bIgnoreButtonInput)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Cinematic: " + ((bCinematicMode)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("bDuck: " + ((bDuck)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("bIsLoading: " + ((IsLoadingLevel())).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		Canvas.DrawText("Controller rotation: " + ((Rotation)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		if(Pawn != default)
		{
			Canvas.DrawText("Pawn rotation: " + ((Pawn.Rotation)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText((((("Pawn position: " + ((Pawn.Location.X)).ToString()) + ", ") + ((Pawn.Location.Y)).ToString()) + ", ") + ((Pawn.Location.Z)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
	}
	
	public override /*simulated event */void PreBeginPlay()
	{
		base.PreBeginPlay();
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			TdEmoteMessageClass = ((DynamicLoadObject("TdMpContent.TdEmoteMessage", ClassT<Class>(), default(bool?))) as ClassT<TdLocalMessage>);
		}
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		/*local */TdOnScreenErrorHandler ErrorHandler = default;
	
		base.PostBeginPlay();
		DefaultFOV = ClassT<TdPlayerCamera>().DefaultAs<Camera>().DefaultFOV;
		DesiredFOV = DefaultFOV;
		FOVAngle = DefaultFOV;
		FOVZoomRate = 0.0f;
		ReactionTimeEnergy = ReactionTimeSpawnLevel;
		ErrorHandler =  ClassT<TdOnScreenErrorHandler>().New();
		ErrorHandler.Initialize();
	}
	
	public override Possess_del Possess { get => bfield_Possess ?? TdPlayerController_Possess; set => bfield_Possess = value; } Possess_del bfield_Possess;
	public override Possess_del global_Possess => TdPlayerController_Possess;
	public /*event */void TdPlayerController_Possess(Pawn inPawn, bool bVehicleTransition)
	{
		/*Transformed 'base.' to specific call*/PlayerController_Possess(inPawn, bVehicleTransition);
		myPawn = ((Pawn) as TdPlayerPawn);
		myPawn.SetDifficultyLevel(GetDifficultyLevel());
		if(myPawn == default)
		{
		}
		if((IsInMainMenu()) && !IsButtonInputIgnored())
		{
			IgnoreButtonInput(true);
		}
	}
	
	public override /*function */void AcknowledgePossession(Pawn P)
	{
		base.AcknowledgePossession(P);
	}
	
	public override /*function */void OnToggleGodMode(SeqAct_ToggleGodMode inAction)
	{
		base.OnToggleGodMode(inAction);
		if(bGodMode)
		{
			((myHUD) as TdHUD).EffectManager.ResetParticles();
		}
	}
	
	public virtual /*function */void OnTdEnablePlayerInput(SeqAct_TdEnablePlayerInput Action)
	{
		SetCinematicMode(false, false, false, true, true, true, true);
		bDisableSkipCutscenes = false;
		myPawn.FinishAnimControl();
		IgnoreButtonInput(false);
		myPawn.StopIgnoreMoveInput();
		myPawn.StopIgnoreLookInput();
		bGodMode = false;
	}
	
	public virtual /*function */void OnTdDisablePlayerInput(SeqAct_TdDisablePlayerInput Action)
	{
		if(Action.bSetCinematicMode)
		{
			UnZoom();
			myPawn.DropWeapon();
			SetCinematicMode(true, false, false, Action.bDisablePlayerMoveInput, Action.bDisablePlayerLookInput, true, true);		
		}
		else
		{
			IgnoreMoveInput(Action.bDisablePlayerMoveInput);
			IgnoreLookInput(Action.bDisablePlayerLookInput);
		}
		IgnoreButtonInput(true);
		bDuck = (byte)0;
		bReleasedJump = true;
		bGodMode = true;
		if(Action.bDisableSkipCutscenes)
		{
			bDisableSkipCutscenes = true;
		}
	}
	
	public override /*function */void SetCinematicMode(bool bInCinematicMode, bool bHidePlayer, bool bAffectsHUD, bool bAffectsMovement, bool bAffectsTurning, bool bAffectsButtons, bool bSwitchSoundMode)
	{
		if(bInCinematicMode)
		{
			if(bSwitchSoundMode)
			{
				SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_CUSTOM_TRACK_INGAME_CUTSCENES/*7*/, default(float?), default(bool?), default(float?));
			}
			SetTimer(1.20f, false, "CallSkippablePopUp", default(Object?));		
		}
		else
		{
			if(bSwitchSoundMode)
			{
				ClearSoundMode();
			}
		}
		base.SetCinematicMode(bInCinematicMode, bHidePlayer, bAffectsHUD, bAffectsMovement, bAffectsTurning, bAffectsButtons, bSwitchSoundMode);
	}
	
	public virtual /*simulated function */void CallSkippablePopUp()
	{
		if(bCinematicMode && IsCutsceneSkippable())
		{
			CallPopUp(TdSPHUD.EPopUpType.PUT_Skip/*5*/, 8.0f);
		}
	}
	
	public virtual /*function */void IgnoreButtonInput(bool bNewButtonInput)
	{
		bIgnoreButtonInput = (byte)((byte)(Max(((int)bIgnoreButtonInput) + ((bNewButtonInput) ? 1 : -1), 0)));
	}
	
	public virtual /*function */bool IsButtonInputIgnored()
	{
		return ((int)bIgnoreButtonInput) > ((int)0);
	}
	
	public override /*event */void OnProfileReadComplete(bool bSucceeded)
	{
		/*local */Actor A = default;
		/*local */TdProfileSettings P = default;
		/*local */TdSPGame Game = default;
	
		P = GetProfileSettings();
		RetrieveSettingsFromProfile();
		SetDifficultyLevel(GetDifficultyLevel());
		if(bCanSeeLOI && WorldInfo.IsLOIEnabled())
		{
			
			// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
			using var e80 = AllActors(ClassT<Actor>()).GetEnumerator();
			while(e80.MoveNext() && (A = (Actor)e80.Current) == A)
			{
				if(A.bLOIObject)
				{
					A.AssignPlayerToLOI(this);
				}			
			}		
		}
		if(P != default)
		{
			if(StatsManager == default)
			{
				StatsManager =  ClassT<TdStatsManager>().New(this);
			}
			StatsManager.SetToDefaults(P);
			Game = ((WorldInfo.Game) as TdSPGame);
			if(Game != default)
			{
				StatsManager.LoadStatsFromProfile(P, Game.bShouldSaveCheckpointProgress, Game.bShouldSaveCheckpointProgress, true);
			}		
		}
	}
	
	public override /*function */void ClientUpdatePosition()
	{
		/*local */TdSavedMove CurrentMove = default;
		/*local */int realbRun = default, realbDuck = default;
		/*local */bool bRealJump = default, bRealStopJump = default, bRealPreciseDestination = default;
	
		bUpdatePosition = false;
		if((Pawn != default) && ((int)Pawn.Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			return;
		}
		realbRun = ((int)bRun);
		realbDuck = ((int)bDuck);
		bRealJump = bPressedJump;
		bRealStopJump = bReleasedJump;
		bUpdating = true;
		bRealPreciseDestination = bPreciseDestination;
		ClearAckedMoves();
		CurrentMove = ((SavedMoves) as TdSavedMove);
		J0x94:{}
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
			CurrentMove = ((CurrentMove.NextMove) as TdSavedMove);
			goto J0x94;
		}
		bUpdating = false;
		bDuck = (byte)((byte)(realbDuck));
		bRun = (byte)((byte)(realbRun));
		bPressedJump = bRealJump;
		bReleasedJump = bRealStopJump;
		bPreciseDestination = bRealPreciseDestination;
	}
	
	public override /*event */void InitInputSystem()
	{
		/*local */TdPlayerInput PlI = default;
	
		DebugOutput =  ClassT<TdDebugOutput>().New();
		base.InitInputSystem();
		PlI = ((PlayerInput) as TdPlayerInput);
		if(PlI != default)
		{
			if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
			{
				PlI.InitInputSystem(ClassT<TdSPGame>());			
			}
			else
			{
				PlI.InitInputSystem(ClassT<TdMPTeamDMGame>());
			}
		}
	}
	
	public override LongClientAdjustPosition_del LongClientAdjustPosition { get => bfield_LongClientAdjustPosition ?? TdPlayerController_LongClientAdjustPosition; set => bfield_LongClientAdjustPosition = value; } LongClientAdjustPosition_del bfield_LongClientAdjustPosition;
	public override LongClientAdjustPosition_del global_LongClientAdjustPosition => TdPlayerController_LongClientAdjustPosition;
	public /*unreliable client simulated function */void TdPlayerController_LongClientAdjustPosition(float TimeStamp, name NewState, Actor.EPhysics newPhysics, float NewLocX, float NewLocY, float NewLocZ, float NewVelX, float NewVelY, float NewVelZ, Actor NewBase, float NewFloorX, float NewFloorY, float NewFloorZ)
	{
		/*Transformed 'base.' to specific call*/PlayerController_LongClientAdjustPosition(TimeStamp, NewState, ((Actor.EPhysics)newPhysics), NewLocX, NewLocY, NewLocZ, NewVelX, NewVelY, NewVelZ, NewBase, NewFloorX, NewFloorY, NewFloorZ);
	}
	
	public override /*function */void CallServerMove(SavedMove NewMove, Object.Vector ClientLoc, byte ClientRoll, int View, SavedMove OldMove)
	{
		if(OldMove != default)
		{
			SendServerMove(OldMove, vect(1.0f, 2.0f, 3.0f), (byte)ClientRoll, View, default);
		}
		if(PendingMove != default)
		{
			SendServerMove(PendingMove, vect(1.0f, 2.0f, 3.0f), (byte)ClientRoll, View, default);
		}
		SendServerMove(NewMove, ClientLoc, (byte)ClientRoll, View, OldMove);
	}
	
	public virtual /*exec function */void ToggleDynamicContrast()
	{
		((myHUD) as TdHUD).ToggleToneMapping();
	}
	
	public virtual /*final function */void SendServerMove(SavedMove NewMove, Object.Vector ClientLoc, byte ClientRoll, int View, SavedMove OldMove)
	{
		if(myPawn != default)
		{
			if(myPawn.IsInMove(TdPawn.EMovement.MOVE_VaultOver/*9*/) && NewMove.bForceRMVelocity)
			{
				VaultServerMove(NewMove.TimeStamp, NewMove.RMVelocity * ((float)(10)), ClientLoc, (byte)NewMove.CompressedFlags(), (byte)ClientRoll, View);			
			}
			else
			{
				if(NewMove.bForceRMVelocity)
				{
					RMServerMove(NewMove.TimeStamp, NewMove.RMVelocity * ((float)(10)), ClientLoc, (byte)NewMove.CompressedFlags(), (byte)ClientRoll, View);				
				}
				else
				{
					ServerMove(NewMove.TimeStamp, NewMove.Acceleration * ((float)(10)), ClientLoc, (byte)NewMove.CompressedFlags(), (byte)ClientRoll, View);
				}
			}		
		}
		else
		{
			ServerMove(NewMove.TimeStamp, NewMove.Acceleration * ((float)(10)), ClientLoc, (byte)NewMove.CompressedFlags(), (byte)ClientRoll, View);
		}
	}
	
	public virtual /*reliable server function */void RMServerMove(float TimeStamp, Object.Vector InAccel, Object.Vector ClientLoc, byte MoveFlags, byte ClientRoll, int View)
	{
		if(CurrentTimeStamp >= TimeStamp)
		{
			return;
		}
		Pawn.bForceRMVelocity = true;
		Pawn.RMVelocity = InAccel * 0.10f;
		InAccel = Pawn.AccelRate * Normal(InAccel);
		ServerMove(TimeStamp, InAccel, ClientLoc, (byte)MoveFlags, (byte)ClientRoll, View);
		Pawn.bForceRMVelocity = false;
	}
	
	public virtual /*reliable server function */void VaultServerMove(float TimeStamp, Object.Vector InAccel, Object.Vector ClientLoc, byte MoveFlags, byte ClientRoll, int View)
	{
		/*local */Object.Rotator ViewRot = default, PawnRot = default, DeltaRot = default;
		/*local */float DeltaTime = default;
	
		if(CurrentTimeStamp >= TimeStamp)
		{
			return;
		}
		if(myPawn == default)
		{
			ServerMove(TimeStamp, Normal(InAccel), ClientLoc, (byte)MoveFlags, (byte)ClientRoll, View);
			return;
		}
		if(ClientLoc != vect(1.0f, 2.0f, 3.0f))
		{
			myPawn.SetLocation(ClientLoc);
		}
		myPawn.Velocity = InAccel * 0.10f;
		bWasSpeedHack = false;
		DeltaTime = FMin(MaxResponseTime, TimeStamp - CurrentTimeStamp);
		CurrentTimeStamp = TimeStamp;
		ServerTimeStamp = WorldInfo.TimeSeconds;
		ViewRot.Pitch = View & 65535;
		ViewRot.Yaw = /*>>*/ShiftR(View, 16);
		ViewRot.Roll = 0;
		LastActiveTime = WorldInfo.TimeSeconds;
		DeltaRot = Rotation - ViewRot;
		SetRotation(ViewRot);
		if(AcknowledgedPawn != Pawn)
		{
			return;
		}
		if(Pawn != default)
		{
			PawnRot = Rotation;
			PawnRot.Roll = 256 * ((int)ClientRoll);
			Pawn.FaceRotation(PawnRot, DeltaTime);
		}
		if(((Pawn == default) || !Pawn.bHardAttach))
		{
			SavedMoveClass.Static.SetFlags((byte)MoveFlags, this);
			ProcessMove(DeltaTime, InAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, DeltaRot);
			bDoubleJump = false;
		}
		PendingAdjustment.TimeStamp = TimeStamp;
		PendingAdjustment.bAckGoodMove = 1;
	}
	
	public override UpdateRotation_del UpdateRotation { get => bfield_UpdateRotation ?? TdPlayerController_UpdateRotation; set => bfield_UpdateRotation = value; } UpdateRotation_del bfield_UpdateRotation;
	public override UpdateRotation_del global_UpdateRotation => TdPlayerController_UpdateRotation;
	public /*function */void TdPlayerController_UpdateRotation(float DeltaTime)
	{
		/*local */Object.Rotator DeltaRot = default, NewRotation = default, ViewRotation = default;
		/*local */float RotSpeedMod = default;
	
		ViewRotation = Rotation;
		DesiredRotation = ViewRotation;
		if(myPawn != default)
		{
			RotSpeedMod = FMax(0.40f, 1.0f - ((float)(Min(1, ((int)(Abs(((float)(Normalize(Rotation - myPawn.Rotation).Pitch)) / 16384.0f) + 0.30f))))));		
		}
		else
		{
			RotSpeedMod = 1.0f;
		}
		if(bRightThumbStickPassedDeadZone)
		{
			DeltaRot.Yaw = ((int)(PlayerInput.aTurn * RotSpeedMod));
			DeltaRot.Pitch = ((int)(PlayerInput.aLookUp));
		}
		if(bCinematicMode && Pawn != default)
		{
			SetRotation(Pawn.Rotation);		
		}
		else
		{
			if(myPawn != default)
			{
				if(CurrentForcedLookAtPoint != default)
				{
					CurrentForcedLookAtPoint.UpdateViewRotation(ViewRotation, DeltaTime, ref/*probably?*/ DeltaRot, myPawn.GetEyeLocation(myPawn.Location));				
				}
				else
				{
					if(CurrentLookAtPoint != default)
					{
						CurrentLookAtPoint.UpdateViewRotation(ViewRotation, DeltaTime, ref/*probably?*/ DeltaRot, myPawn.GetEyeLocation(myPawn.Location));
					}
				}
				myPawn.Moves[((int)myPawn.MovementState)].UpdateViewRotation(ref/*probably?*/ ViewRotation, DeltaTime, ref/*probably?*/ DeltaRot);
			}
			ProcessViewRotation(DeltaTime, ref/*probably?*/ ViewRotation, DeltaRot);
			ViewRotation.Roll = 0;
			SetRotation(ViewRotation);
		}
		ViewShake(DeltaTime);
		NewRotation = ViewRotation;
		NewRotation.Roll = Rotation.Roll;
		if(Pawn != default)
		{
			Pawn.FaceRotation(NewRotation, DeltaTime);
		}
		UpdateStickyAim(DeltaTime);
		if(!bRightThumbStickPassedDeadZone)
		{
			if((Abs(PlayerInput.aTurn) < 0.30f) && Abs(PlayerInput.aLookUp) < 0.30f)
			{
				bRightThumbStickPassedDeadZone = true;
			}
		}
	}
	
	public virtual /*function */void UpdateReactionTime(float DeltaTime)
	{
		/*local */float ReactionTimeToDrain = default, ReactionTimeToFadeIn = default, ReactionTimeToFadeOut = default, NewGameSpeed = default;
	
		if(myPawn == default)
		{
			return;
		}
		if(bReactionTime)
		{
			if(!bOverrideReactionTimeSettings)
			{
				ReactionTimeToDrain = (100.0f / ReactionTimeDrain) * DeltaTime;
				ReactionTimeToDrain /= WorldInfo.TimeDilation;
				ReactionTimeEnergy -= ReactionTimeToDrain;
			}
			if(ReactionTimeEnergy <= ((float)(0)))
			{
				bReactionTime = false;
				((myHUD) as TdHUD).ToggleReactionTime(false);
				ReactionTimeEnergy = 0.0f;
				NewGameSpeed = 1.0f;
				SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/, default(float?), default(bool?), default(float?));
				myPawn.OnTutorialEvent(22);			
			}
			else
			{
				ReactionTimeToFadeIn = ReactionTimeFadeIn;
				ReactionTimeToFadeOut = ReactionTimeFadeOut;
				if(ReactionTimeEnergy > ReactionTimeToFadeIn)
				{
					NewGameSpeed = Lerp(ReactionTimeMaxEffect, 1.0f, (ReactionTimeEnergy - ReactionTimeToFadeIn) / (100.0f - ReactionTimeToFadeIn));				
				}
				else
				{
					if(ReactionTimeEnergy < ReactionTimeToFadeOut)
					{
						NewGameSpeed = Lerp(1.0f, ReactionTimeMaxEffect, ReactionTimeEnergy / ReactionTimeToFadeOut);					
					}
					else
					{
						NewGameSpeed = ReactionTimeMaxEffect;
					}
				}
			}
			WorldInfo.Game.SetGameSpeed(NewGameSpeed);		
		}
		else
		{
			if(ReactionTimeEnergy < 100.0f)
			{
				ReactionTimeEnergy += ((ReactionTimeEnergyBuildRate * DeltaTime) * myPawn.VelocityMagnitude);
				if((ReactionTimeEnergy >= 100.0f) && WorldInfo.GRI.GameClass.Static.AllowReactionTime())
				{
					ReactionTimeEnergy = 100.0f;
					((myHUD) as TdHUD).EffectManager.ActivateReactionTimeTeaser();
				}
			}
		}
	}
	
	public virtual /*function */void OnTdGiveFullReactionEnergy(SeqAct_TdGiveFullReactionEnergy Action)
	{
		ForceFullReactionTimeEnergy();
	}
	
	public virtual /*function */void OnTdEnableReactionTime(SeqAct_TdEnableReactionTime Action)
	{
		bOverrideReactionTimeSettings = true;
		bReactionTime = true;
		ReactionTimeEnergy = 90.0f;
		((myHUD) as TdHUD).ToggleReactionTime(true);
		SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_REACTION_TIME/*3*/, default(float?), default(bool?), default(float?));
	}
	
	public virtual /*function */void OnTdDisableReactionTime(SeqAct_TdDisableReactionTime Action)
	{
		bOverrideReactionTimeSettings = false;
		ReactionTimeEnergy = 20.0f;
		SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_NORMAL/*0*/, default(float?), default(bool?), default(float?));
	}
	
	// Export UTdPlayerController::execIsLoadingLevel(FFrame&, void* const)
	public virtual /*native function */bool IsLoadingLevel()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void OnTdBlockWhileLoading(SeqAct_TdBlockWhileLoading Action)
	{
		if(IsLoadingLevel())
		{
			if((!Action.bOnlyInSpeedrun || WorldInfo.Game.IsA("TdSPLevelRace")))
			{
				((myHUD) as TdHUD).NotifyDiskAccess(true, TsSystem.ETsDiskAccess.TSD_LoadingLevel/*10*/);
				ClientFlushLevelStreaming();
			}
		}
	}
	
	public virtual /*function */void OnTdFadeEffect(SeqAct_TdFadeEffect Action)
	{
	
	}
	
	public virtual /*function */void OnTdTutorialReset(SeqAct_TdTutorialReset Action)
	{
	
	}
	
	public virtual /*function */void OnTdAddAdditionalAnimSets(SeqAct_TdAddAdditionalAnimSets Action)
	{
	
	}
	
	public virtual /*function */void ForceFullReactionTimeEnergy()
	{
		if(bReactionTime)
		{
			WorldInfo.Game.SetGameSpeed(1.0f);
		}
		bReactionTime = false;
		ReactionTimeEnergy = 100.0f;
		((myHUD) as TdHUD).EffectManager.ActivateReactionTimeTeaser();
	}
	
	public delegate void AttemptReactionTime_del();
	public virtual AttemptReactionTime_del AttemptReactionTime { get => bfield_AttemptReactionTime ?? TdPlayerController_AttemptReactionTime; set => bfield_AttemptReactionTime = value; } AttemptReactionTime_del bfield_AttemptReactionTime;
	public virtual AttemptReactionTime_del global_AttemptReactionTime => TdPlayerController_AttemptReactionTime;
	public /*exec function */void TdPlayerController_AttemptReactionTime()
	{
		if(!WorldInfo.GRI.GameClass.Static.AllowReactionTime())
		{
			return;
		}
		if((bCinematicMode || IsButtonInputIgnored()))
		{
			return;
		}
		if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
		{
			return;
		}
		if((myPawn.IsInState("Dying", default(bool?)) || myPawn.IsInState("UncontrolledFall", default(bool?))))
		{
			return;
		}
		if(((ReactionTimeEnergy < ((float)(100))) || WorldInfo.Game.GameSpeed < 1.0f))
		{
			return;
		}
		((myHUD) as TdHUD).ToggleReactionTime(true);
		bReactionTime = true;
		SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_REACTION_TIME/*3*/, default(float?), default(bool?), default(float?));
		myPawn.OnTutorialEvent(15);
	}
	
	public virtual /*function */void UpdateStickyAim(float DeltaTime)
	{
		/*local */TdHUD HUD = default;
		/*local */TdWeapon CurrentWeapon = default;
		/*local */TdMove CurrentMove = default;
	
		if(myPawn == default)
		{
			return;
		}
		HUD = ((myHUD) as TdHUD);
		CurrentWeapon = ((myPawn.Weapon) as TdWeapon);
		CurrentMove = myPawn.Moves[((int)myPawn.MovementState)];
		if(((((HUD == default) || CurrentWeapon == default)) || CurrentMove == default))
		{
			return;
		}
		CurrentWeapon.UpdateStickyActor(HUD, this, CurrentMove, DeltaTime);
	}
	
	public virtual /*function */void ForceNewStickyActor(Actor NewStickyActor)
	{
		((myPawn.Weapon) as TdWeapon).ForceNewStickyActor(NewStickyActor, ((myHUD) as TdHUD), this, myPawn.Moves[((int)myPawn.MovementState)], 0.0f);
	}
	
	public virtual /*exec function */void LookBehind()
	{
		if(((IsButtonInputIgnored()) || myPawn == default))
		{
			return;
		}
		if(((int)myPawn.Moves[((int)myPawn.MovementState)].MovementGroup) >= ((int)TdMove.EMovementGroup.MG_NonInteractive/*3*/))
		{
			return;
		}
		myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Turn/*16*/);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ServerLookBehind();
		}
	}
	
	public virtual /*reliable server function */void ServerLookBehind()
	{
		myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Turn/*16*/);
	}
	
	public virtual /*exec function */void AttackPress()
	{
		if(IsButtonInputIgnored())
		{
			return;
		}
		if((!myPawn.HasWeapon() || (((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) && myPawn.Moves[19].CanDoMove()))
		{
			myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Melee/*3*/);		
		}
		else
		{
			StartFire((byte)default(byte?));
		}
	}
	
	public virtual /*exec function */void AttackRelease()
	{
		if(IsButtonInputIgnored())
		{
			return;
		}
		if(myPawn.HasWeapon())
		{
			StopFire((byte)default(byte?));
		}
	}
	
	public virtual /*function */Actor GetOtherTarget(float MaxDistance, ref Object.Vector HitLocation)
	{
		/*local */Actor HitActor = default;
		/*local */Object.Vector HitNormal = default;
	
		HitActor = Pawn.Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, Pawn.Location, Pawn.Location + (((Vector)(Pawn.Rotation)) * MaxDistance), true, default(Object.Vector?), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, 8);
		return HitActor;
	}
	
	public virtual /*function */bool InMeleeMove()
	{
		return ((myPawn.Moves[((int)myPawn.MovementState)]) as TdMove_MeleeBase) != default;
	}
	
	public virtual /*function */bool SnatchAttempt()
	{
		/*local */float CloseCombatRange = default, ForwardVelocity = default;
	
		if(!((myPawn != default) && ((int)myPawn.MovementState) != ((int)TdPawn.EMovement.MOVE_Snatch/*18*/)) && !myPawn.HasWeapon())
		{
			return false;
		}
		ForwardVelocity = Dot(myPawn.Velocity, ((Vector)(myPawn.Rotation)));
		CloseCombatRange = FMin(FMax(FMax(0.0f, ForwardVelocity) * 0.40f, CloseCombatMinRange), CloseCombatMaxRange);
		TargetPawn = GetHumanTarget(CloseCombatRange, CloseCombatMaxAngle);
		if(TargetPawn == default)
		{
			return false;
		}
		if((((int)TargetPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Stumble/*35*/)) && (Dot(Normal(TargetPawn.Location - Pawn.Location), ((Vector)(Pawn.Rotation)))) < 0.0f)
		{
			myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Melee/*3*/);		
		}
		else
		{
			myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Snatch/*4*/);
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				ServerTriggerSnatch(TargetPawn);
			}
		}
		return true;
	}
	
	public virtual /*reliable server function */void ServerTriggerSnatch(TdPawn TargetPawnReplication)
	{
		TargetPawn = TargetPawnReplication;
		myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Snatch/*4*/);
	}
	
	public virtual /*function */TdPawn GetHumanTarget(float MaxDistance, float MaxAngle)
	{
		/*local */TdPawn P = default, ClosestPawn = default;
		/*local */float MinDistance = default;
	
		if(((Pawn == default) || Pawn.Controller == default))
		{
			return default;
		}
		MinDistance = 10000000.0f;
		
		// foreach ((myPawn.Controller) as TdPlayerController).LocalEnemyActors(ref/*probably?*/ P)
		using var e47 = ((myPawn.Controller) as TdPlayerController).LocalEnemyActors().GetEnumerator();
		while(e47.MoveNext() && (P = (TdPawn)e47.Current) == P)
		{
			if((Dot(((Vector)(Pawn.Controller.Rotation)), Normal(P.Location - Pawn.Location))) > MaxAngle)
			{
				if((VSize(Pawn.Location - P.Location) < MinDistance) && P.IsValidEnemyTargetFor(Pawn.PlayerReplicationInfo, true))
				{
					ClosestPawn = P;
					MinDistance = VSize(Pawn.Location - P.Location);
				}
				if(bDebugCloseCombat)
				{
					DrawDebugSphereTime(P.Location, 4.0f, 4, 0, 0, 150, 20.0f);
				}
				continue;
			}
			if(bDebugCloseCombat)
			{
				DrawDebugSphereTime(P.Location, 4.0f, 4, 30, 30, 30, 20.0f);
			}		
		}	
		if(ClosestPawn == default)
		{
			return default;
		}
		if(bDebugCloseCombat && MinDistance < MaxDistance)
		{
			DrawDebugSphereTime(ClosestPawn.Location, 4.50f, 4, 255, 0, 0, 20.0f);
			DrawDebugLineTime(myPawn.Location, ClosestPawn.Location, 255, 0, 0, 20.0f);
		}
		return (((VSize2D(Pawn.Location - ClosestPawn.Location) < MaxDistance) && VSize(Pawn.Location - ClosestPawn.Location) < CloseCombatMaxRange) ? ClosestPawn : default);
	}
	
	public virtual /*exec function */void UsePress()
	{
		if(IsButtonInputIgnored())
		{
			return;
		}
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			SetTimer(BagSearchTapTime, false, "UseCarriedObject", default(Object?));
		}
	}
	
	public virtual /*exec function */void UseRelease()
	{
		if(IsButtonInputIgnored())
		{
			return;
		}
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			if(IsTimerActive("UseCarriedObject", default(Object?)))
			{
				ClearTimer("UseCarriedObject", default(Object?));
				ServerUseCarriedObject(true);
			}
		}
		Use();
	}
	
	public override /*function */bool TriggerInteracted()
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
	
		if(((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Interact/*39*/))
		{
			return false;
		}
		if(Pawn != default)
		{
			GetTriggerUseList(InteractDistance, 60.0f, 0.0f, true, ref/*probably?*/ useList);
			if(useList.Length > 0)
			{
				GetPlayerViewPoint(ref/*probably?*/ cameraLoc, ref/*probably?*/ cameraRot);
				J0x66:{}
				if(useList.Length > 0)
				{
					A = useList[useList.Length - 1];
					useList.Length = useList.Length - 1;
					Weight = Dot(Normal(A.Location - cameraLoc), ((Vector)(cameraRot)));
					Weight += (1.0f - (VSize(A.Location - Pawn.Location) / InteractDistance));
					bInserted = false;
					Idx = 0;
					J0x104:{}
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
						goto J0x104;
					}
					if(!bInserted)
					{
						Idx = sortedList.Length;
						sortedList[Idx] = A;
						weightList[Idx] = Weight;
					}
					goto J0x66;
				}
				Idx = 0;
				J0x1C5:{}
				if(Idx < sortedList.Length)
				{
					if(sortedList[Idx].UsedBy(Pawn))
					{
						return true;
					}
					++ Idx;
					goto J0x1C5;
				}
			}
		}
		return false;
	}
	
	public virtual /*function */void UseCarriedObject()
	{
		ServerUseCarriedObject(false);
	}
	
	public virtual /*unreliable server function */void ServerUseCarriedObject(bool bTapped)
	{
		/*local */TdPlayerReplicationInfo MyPRI = default;
	
		MyPRI = ((PlayerReplicationInfo) as TdPlayerReplicationInfo);
		if(myPawn != default)
		{
			if(myPawn.IsCarryingObject())
			{
				if(bTapped)
				{
					MyPRI.OnUseCarriedObject(myPawn);				
				}
				else
				{
					MyPRI.OnUseCarriedObject(myPawn.CarriedObject.GetCarriedActor());
				}			
			}
			else
			{
				MyPRI.OnUseCarriedObject(myPawn);
			}
		}
	}
	
	public virtual /*exec function */void LookAtPress()
	{
		/*local */TdGameInfo GInfo = default;
	
		if(bCinematicMode)
		{
			return;
		}
		GInfo = ((WorldInfo.Game) as TdGameInfo);
		if(GInfo != default)
		{
			CurrentLookAtPoint = GInfo.GetLookAtPoint(myPawn);
			if(CurrentLookAtPoint != default)
			{
				CurrentLookAtPoint.SetupTime(0.60f, 3.0f);			
			}
			else
			{
				ClientPlaySound(ObjectConst<SoundCue>("Negative"));
			}
		}
	}
	
	public virtual /*exec function */void LookAtRelease()
	{
		CurrentLookAtPoint = default;
	}
	
	public virtual /*exec function */void PlayIdleDemo()
	{
		if(((((IsButtonInputIgnored()) || myPawn == default)) || myPawn.Weapon != default))
		{
			return;
		}
		myPawn.PlayIdleDemo();
	}
	
	public virtual /*function */void CheckCrouch()
	{
		/*local */bool bIsCrouching = default;
	
		if((((IsButtonInputIgnored()) && ((int)bDuck) != ((int)0)) || myPawn == default))
		{
			return;
		}
		bIsCrouching = (myPawn.IsInMove(TdPawn.EMovement.MOVE_Crouch/*15*/) || myPawn.IsInMove(TdPawn.EMovement.MOVE_Slide/*16*/));
		if(bIsCrouching && ((((int)bDuck) == ((int)0)) || ((int)myPawn.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/)))
		{
			myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_StopCrouch/*6*/);		
		}
		else
		{
			if((((int)bDuck) != ((int)0)) && !myPawn.IsInMove(TdPawn.EMovement.MOVE_Slide/*16*/))
			{
				myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Crouch/*5*/);
			}
		}
	}
	
	public virtual /*function */void CheckJumpPressed()
	{
		if(IsButtonInputIgnored())
		{
			return;
		}
		if((myPawn.Weapon != default) && ((myPawn.Weapon) as TdWeapon).IsZooming())
		{
			return;
		}
		if((!bUpdating && bPressedJump) && Pawn != default)
		{
			myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Jump/*1*/);
		}
	}
	
	public virtual /*function */void CheckJumpReleased()
	{
		if((!bUpdating && bReleasedJump) && Pawn != default)
		{
			myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_StopJump/*2*/);
			TimePressedJump = -1.0f;
			bPressedJump = false;
		}
	}
	
	public delegate bool ShouldDelayJump_del();
	public virtual ShouldDelayJump_del ShouldDelayJump { get => bfield_ShouldDelayJump ?? TdPlayerController_ShouldDelayJump; set => bfield_ShouldDelayJump = value; } ShouldDelayJump_del bfield_ShouldDelayJump;
	public virtual ShouldDelayJump_del global_ShouldDelayJump => TdPlayerController_ShouldDelayJump;
	public /*function */bool TdPlayerController_ShouldDelayJump()
	{
		return false;
	}
	
	public delegate void SetInputHint_del();
	public virtual SetInputHint_del SetInputHint { get => bfield_SetInputHint ?? TdPlayerController_SetInputHint; set => bfield_SetInputHint = value; } SetInputHint_del bfield_SetInputHint;
	public virtual SetInputHint_del global_SetInputHint => TdPlayerController_SetInputHint;
	public /*function */void TdPlayerController_SetInputHint()
	{
		/*local */TdPawn.EMoveActionHint Hint = default;
		/*local */bool bMax = default;
	
		if(((IsButtonInputIgnored()) || myPawn == default))
		{
			return;
		}
		Hint = TdPawn.EMoveActionHint.MAH_None/*0*/;
		bMax = false;
		if(bLeftThumbStickPassedDeadZone)
		{
			if(PlayerInput.aBaseY > 0.80f)
			{
				Hint = ((TdPawn.EMoveActionHint)((((PlayerInput) as TdPlayerInput).bInvertGamepadYAxis) ? 4 : 3));
				bMax = PlayerInput.aBaseY > 0.960f;			
			}
			else
			{
				if(PlayerInput.aBaseY < -0.80f)
				{
					Hint = ((TdPawn.EMoveActionHint)((((PlayerInput) as TdPlayerInput).bInvertGamepadYAxis) ? 3 : 4));
					bMax = PlayerInput.aBaseY < -0.960f;
				}
			}
			if(PlayerInput.aStrafe > 0.30f)
			{
				Hint = TdPawn.EMoveActionHint.MAH_Right/*2*/;
				bMax = PlayerInput.aStrafe > 0.960f;			
			}
			else
			{
				if(PlayerInput.aStrafe < -0.30f)
				{
					Hint = TdPawn.EMoveActionHint.MAH_Left/*1*/;
					bMax = PlayerInput.aStrafe < -0.960f;
				}
			}
		}
		myPawn.SetMoveActionHint(((TdPawn.EMoveActionHint)Hint), bMax);
		if((Abs(PlayerInput.aBaseY) < 0.30f) && Abs(PlayerInput.aStrafe) < 0.30f)
		{
			bLeftThumbStickPassedDeadZone = true;
		}
	}
	
	public override /*simulated function */void RegisterPlayerDataStores()
	{
		base.RegisterPlayerDataStores();
		TdRegisterPlayerDataStores();
	}
	
	public override /*simulated function */void UnregisterPlayerDataStores()
	{
		base.UnregisterPlayerDataStores();
		TdUnregisterPlayerDataStores();
	}
	
	public override /*function */bool SetPause(bool bPause, /*optional *//*delegate*/PlayerController.CanUnpause? _CanUnpauseDelegate = default)
	{
		/*local */bool bResult = default;
	
		var CanUnpauseDelegate = _CanUnpauseDelegate ?? default;
		bResult = base.SetPause(bPause, CanUnpauseDelegate);
		if(bPause == IsPaused())
		{
			if(bPause)
			{
				SetAudioGroupVolume("InGameMusic", 0.250f);			
			}
			else
			{
				SetAudioGroupVolume("InGameMusic", 1.0f);
			}
		}
		return bResult;
	}
	
	public virtual /*exec function */void RetrieveSettingsFromProfile()
	{
		SetAudioProfileSettings();
		SetVideoProfileSettings();
		SetKeyBindingsProfileSettings();
		SetControlBindingsProfileSettings(default(array<Input.KeyBind>?));
		SetGameProfileSettings();
	}
	
	public virtual /*exec function */void SetAudioProfileSettings()
	{
		/*local */int Value = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings.GetProfileSettingValueIntByName("MasterVolume", ref/*probably?*/ Value))
		{
			SetAudioGroupVolume("Master", ((float)(Value)) / 10.0f);
		}
		if(ProfileSettings.GetProfileSettingValueIntByName("MusicVolume", ref/*probably?*/ Value))
		{
			SetAudioGroupVolume("Music", ((float)(Value)) / 10.0f);
		}
		if(ProfileSettings.GetProfileSettingValueIntByName("DialogueVolume", ref/*probably?*/ Value))
		{
			if((WorldInfo.Game != default) && WorldInfo.Game.IsA("TdSPTimeTrialGame"))
			{
				SetAudioGroupVolume("VO", 0.0f);			
			}
			else
			{
				SetAudioGroupVolume("VO", ((float)(Value)) / 10.0f);
			}
		}
	}
	
	public virtual /*exec function */void SetVideoProfileSettings()
	{
		/*local */int Value = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings.GetProfileSettingValueIntByName("Brightness", ref/*probably?*/ Value))
		{
			SetGamma(((float)(Value)) / 10.0f);
		}
		if(ProfileSettings.GetProfileSettingValueIntByName("Contrast", ref/*probably?*/ Value))
		{
			SetContrast(((float)(Value)) / 10.0f);
		}
	}
	
	public virtual /*exec function */void SetKeyBindingsProfileSettings()
	{
		/*local */TdPlayerInput TdInput = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		TdInput = ((PlayerInput) as TdPlayerInput);
		if(TdInput != default)
		{
			ProfileSettings.ApplyKeyBindings(TdInput);
			ProfileSettings.ApplyGamepadBindings(TdInput, default(array<Input.KeyBind>?));
		}
		ClearDataStoreBindingsCache();
	}
	
	public virtual /*function */void ClearDataStoreBindingsCache()
	{
		/*local */LocalPlayer LP = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdStringAliasBindingsMap BindingsDataStore = default;
	
		LP = ((Player) as LocalPlayer);
		if(LP != default)
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				BindingsDataStore = ((DataStoreManager.FindDataStore("StringAliasBindings", LP)) as UIDataStore_TdStringAliasBindingsMap);
				if(BindingsDataStore != default)
				{
					BindingsDataStore.ClearBoundKeyCache();
					BindingsDataStore.RefreshSubscribers(default(name?), default(bool?), default(UIDataProvider?), default(int?));
				}
			}
		}
	}
	
	public virtual /*exec function */void SetMouseProfileSettings()
	{
		/*local */int Value = default;
		/*local */TdPlayerInput TdInput = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		TdInput = ((PlayerInput) as TdPlayerInput);
		if(TdInput != default)
		{
			if(ProfileSettings.GetProfileSettingValueIntByName("Sensitivity", ref/*probably?*/ Value))
			{
				TdInput.SetRangedSensitivityMultiplier(((float)(Value)) / 10.0f);
			}
			if(ProfileSettings.GetProfileSettingValueIdByName("InvertYAxis", ref/*probably?*/ Value))
			{
				TdInput.bInvertMouse = Value == 1;
			}
		}
	}
	
	public virtual /*exec function */void SetControlBindingsProfileSettings(/*optional */array<Input.KeyBind>? _PresetMappings = default)
	{
		/*local */int Value = default;
		/*local */TdPlayerInput TdInput = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		var PresetMappings = _PresetMappings ?? default;
		ProfileSettings = GetProfileSettings();
		TdInput = ((PlayerInput) as TdPlayerInput);
		if(TdInput != default)
		{
			if(ProfileSettings.GetProfileSettingValueIntByName("Sensitivity", ref/*probably?*/ Value))
			{
				TdInput.SetRangedSensitivityMultiplier(((float)(Value)) / 10.0f);
			}
			if(ProfileSettings.GetProfileSettingValueIdByName("InvertYAxis", ref/*probably?*/ Value))
			{
				TdInput.bInvertMouse = Value == 1;
			}
			if(ProfileSettings.GetProfileSettingValueIdByName("ControllerVibration", ref/*probably?*/ Value))
			{
				ForceFeedbackManager.bAllowsForceFeedback = Value == 1;
			}
			if(ProfileSettings.GetProfileSettingValueIdByName("AutoAim", ref/*probably?*/ Value))
			{
			}
			ProfileSettings.ApplyGamepadBindings(TdInput, PresetMappings.NewCopy());
		}
		ControllerTilt = (!ProfileSettings.GetProfileSettingValueIdByName("ControllerTilt", ref/*probably?*/ Value) || Value == 1);
		SetControllerTiltDesiredIfAvailable(ControllerTilt);
		SetControllerTiltActive(ControllerTilt);
		ControllerTilt = ControllerTilt && IsControllerTiltActive();
		ClearDataStoreBindingsCache();
	}
	
	public virtual /*exec function */void SetGameProfileSettings()
	{
		/*local */int Value = default;
		/*local */TdProfileSettings ProfileSettings = default;
		/*local */TdSPHUD CurrentSPHud = default;
	
		SetDifficultyLevel(GetDifficultyLevel());
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings.GetProfileSettingValueIdByName("GameSubtitles", ref/*probably?*/ Value))
		{
			if((WorldInfo.Game != default) && WorldInfo.Game.IsA("TdSPTimeTrialGame"))
			{
				SetShowSubtitles(false);			
			}
			else
			{
				SetShowSubtitles(Value != 0);
			}
		}
		if(ProfileSettings.GetProfileSettingValueIdByName("FaithOVision", ref/*probably?*/ Value))
		{
			UpdateFaithOVisionFlag(GetDifficultyLevel());
		}
		if(ProfileSettings.GetProfileSettingValueIdByName("Reticule", ref/*probably?*/ Value))
		{
			CurrentSPHud = ((myHUD) as TdSPHUD);
			if(CurrentSPHud != default)
			{
				CurrentSPHud.SetDrawCrosshairFlag(((TdProfileSettings.EReticuleValues)((byte)(Value))));
			}
		}
	}
	
	public virtual /*function */void SetDifficultyLevel(int Level)
	{
		/*local */TdAIController AIGuy = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdAIController>(), ref/*probably?*/ AIGuy)
		using var e0 = WorldInfo.AllControllers(ClassT<TdAIController>()).GetEnumerator();
		while(e0.MoveNext() && (AIGuy = (TdAIController)e0.Current) == AIGuy)
		{
			AIGuy.SetDifficultyLevel(Level);		
		}	
		if(myPawn != default)
		{
			myPawn.SetDifficultyLevel(Level);
		}
		switch(Level)
		{
			case 0:
				ReactionTimeEnergyBuildRate = ReactionTimeBuildRates.Easy;
				break;
			case 1:
				ReactionTimeEnergyBuildRate = ReactionTimeBuildRates.Medium;
				break;
			case 2:
				ReactionTimeEnergyBuildRate = ReactionTimeBuildRates.Hard;
				goto default;// UnrealScript fallthrough
			default:
				break;
		}
		UpdateFaithOVisionFlag(Level);
	}
	
	public virtual /*function */int GetDifficultyLevel()
	{
		/*local */int Value = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		if(((WorldInfo.Game) as TdSPLevelRace) != default)
		{
			return 1;
		}
		ProfileSettings = GetProfileSettings();
		if((ProfileSettings != default) && ProfileSettings.GetProfileSettingValueIdByName("GameDifficulty", ref/*probably?*/ Value))
		{
			return Value;		
		}
		else
		{
			return 1;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*function */int GetFaithOVisionFromProfile()
	{
		/*local */int Value = default;
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if((ProfileSettings != default) && ProfileSettings.GetProfileSettingValueIdByName("FaithOVision", ref/*probably?*/ Value))
		{
			return Value;		
		}
		else
		{
			return 2;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*function */void UpdateFaithOVisionFlag(int DifficultyLevel)
	{
		/*local */TdAIController AIController = default;
		/*local */Actor A = default;
		/*local */bool bOldValue = default;
	
		bOldValue = bCanSeeLOI;
		if(((WorldInfo.Game) as TdSPTutorialGame) != default)
		{
			LOIIndex = 2;
			bCanSeeLOI = true;		
		}
		else
		{
			if(DifficultyLevel != 2)
			{
				LOIIndex = GetFaithOVisionFromProfile();
				bCanSeeLOI = LOIIndex != 0;			
			}
			else
			{
				bCanSeeLOI = false;
				LOIIndex = 0;
			}
		}
		
		// foreach WorldInfo.AllControllers(ClassT<TdAIController>(), ref/*probably?*/ AIController)
		using var e119 = WorldInfo.AllControllers(ClassT<TdAIController>()).GetEnumerator();
		while(e119.MoveNext() && (AIController = (TdAIController)e119.Current) == AIController)
		{
			AIController.myPawn.SetRunnerVisionEnabled(LOIIndex == 2);		
		}	
		if((bCanSeeLOI && !bOldValue) && WorldInfo.IsLOIEnabled())
		{
			
			// foreach AllActors(ClassT<Actor>(), ref/*probably?*/ A)
			using var e236 = AllActors(ClassT<Actor>()).GetEnumerator();
			while(e236.MoveNext() && (A = (Actor)e236.Current) == A)
			{
				if(A.bLOIObject)
				{
					A.AssignPlayerToLOI(this);
				}			
			}		
		}
	}
	
	public virtual /*function */bool IsAiRunnerVisionEnabled()
	{
		return LOIIndex == 2;
	}
	
	public virtual /*function */void SetNewDifficulty(int I)
	{
		/*local */TdProfileSettings ProfileSettings = default;
		/*local */int SettingId = default;
	
		if(((I < 0) || I > 2))
		{
			return;
		}
		ProfileSettings = GetProfileSettings();
		if((ProfileSettings != default) && ProfileSettings.GetProfileSettingId("GameDifficulty", ref/*probably?*/ SettingId))
		{
			ProfileSettings.SetProfileSettingValueId(SettingId, I);
			SetDifficultyLevel(I);
		}
	}
	
	// Export UTdPlayerController::execSetGamma(FFrame&, void* const)
	public virtual /*native function */void SetGamma(float GammaValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPlayerController::execSetContrast(FFrame&, void* const)
	public virtual /*native function */void SetContrast(float ContrastValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void TdRegisterPlayerDataStores()
	{
		/*local */LocalPlayer LP = default;
		/*local */DataStoreClient DataStoreManager = default;
	
		LP = ((Player) as LocalPlayer);
		if(LP != default)
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				TutorialDataStore = ((DataStoreManager.FindDataStore("TdTutorialData", LP)) as UIDataStore_TdTutorialData);
				if(TutorialDataStore == default)
				{
					TutorialDataStore = DataStoreManager.CreateDataStore(TutorialDataClass);
					if(TutorialDataStore != default)
					{
						DataStoreManager.RegisterDataStore(TutorialDataStore, LP);
					}
				}
				StringAliasBindingsMapStore = ((DataStoreManager.FindDataStore("StringAliasBindings", LP)) as UIDataStore_TdStringAliasBindingsMap);
				if(StringAliasBindingsMapStore == default)
				{
					StringAliasBindingsMapStore = DataStoreManager.CreateDataStore(StringAliasBindingsMapClass);
					if(StringAliasBindingsMapStore != default)
					{
						DataStoreManager.RegisterDataStore(StringAliasBindingsMapStore, LP);
					}
				}
			}
		}
	}
	
	public virtual /*function */void TdUnregisterPlayerDataStores()
	{
		/*local */LocalPlayer LP = default;
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdTutorialData TutorialData = default;
		/*local */UIDataStore_TdStringAliasBindingsMap BindingsMap = default;
	
		LP = ((Player) as LocalPlayer);
		if(LP != default)
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				TutorialDataStore = default;
				TutorialData = ((DataStoreManager.FindDataStore("TdTutorialData", LP)) as UIDataStore_TdTutorialData);
				if(TutorialData != default)
				{
					DataStoreManager.UnregisterDataStore(TutorialData);
				}
				StringAliasBindingsMapStore = default;
				BindingsMap = ((DataStoreManager.FindDataStore("StringAliasBindings", default(LocalPlayer?))) as UIDataStore_TdStringAliasBindingsMap);
				if(BindingsMap != default)
				{
					DataStoreManager.UnregisterDataStore(BindingsMap);
				}
			}
		}
	}
	
	public virtual /*exec function */void ShowAchievementStats()
	{
	
	}
	
	public virtual /*function */int GetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID Id)
	{
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings == default)
		{
			return -1;
		}
		return StatsManager.GetStatCount(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), ProfileSettings);
	}
	
	public virtual /*function */void ResetStats(bool bLevelStats, bool bGameStats, bool bGlobalStats)
	{
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings == default)
		{
			return;
		}
		StatsManager.ResetStats(ProfileSettings, bLevelStats, bGameStats, bGlobalStats);
	}
	
	public virtual /*function */void LoadStatsFromProfile(bool bLevelStats, bool bGameStats, bool bGlobalStats)
	{
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings == default)
		{
			return;
		}
		StatsManager.LoadStatsFromProfile(ProfileSettings, bLevelStats, bGameStats, bGlobalStats);
	}
	
	public virtual /*function */void SaveStatsToProfile(bool bLevelStats, bool bGameStats, bool bGlobalStats)
	{
		/*local */TdProfileSettings ProfileSettings = default;
	
		ProfileSettings = GetProfileSettings();
		if(ProfileSettings == default)
		{
			return;
		}
		StatsManager.SaveStatsToProfile(ProfileSettings, bLevelStats, bGameStats, bGlobalStats);
	}
	
	public virtual /*function */void AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID Id)
	{
		/*local */float time_stamp = default;
		/*local */TdProfileSettings ProfileSettings = default;
		/*local */bool bSaveProfile = default, bNew = default;
	
		time_stamp = WorldInfo.TimeSeconds;
		ProfileSettings = GetProfileSettings();
		bSaveProfile = false;
		if(ProfileSettings == default)
		{
			return;
		}
		switch(Id)
		{
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_0a/*11*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_0b/*12*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_0c/*13*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_1a/*14*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_1b/*15*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_1c/*16*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_2a/*17*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_2b/*18*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_2c/*19*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_3a/*20*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_3b/*21*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_3c/*22*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_4a/*23*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_4b/*24*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_4c/*25*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_5a/*26*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_5b/*27*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_5c/*28*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_6a/*29*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_6b/*30*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_6c/*31*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_7a/*32*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_7b/*33*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_7c/*34*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_8a/*35*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_8b/*36*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_8c/*37*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_9a/*38*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_9b/*39*/:
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_PackageFound_9c/*40*/:
				bNew = StatsManager.GetStatCount(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), ProfileSettings) == 0;
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					UnlockAchievement(43);
					if(ProfileSettings.IsAllBagsFound())
					{
						UnlockAchievement(42);
					}
				}
				if(ProfileSettings.IsXBagsFound(StatsManager))
				{
					UnlockAchievement(44);
				}
				bSaveProfile = true;
				if(bNew)
				{
					TriggerPickupFlash();
				}
				break;
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_SPMeleeAirKills/*2*/:
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					bSaveProfile = false;
					UnlockAchievement(33);
				}
				break;
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_SPMeleeDisarmKills/*3*/:
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					bSaveProfile = false;
					UnlockAchievement(34);
				}
				break;
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_MeleeKills/*1*/:
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					bSaveProfile = false;
					UnlockAchievement(35);
				}
				break;
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_EndFullMomentum/*7*/:
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					bSaveProfile = false;
					UnlockAchievement(32);
				}
				break;
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_180Taunt/*10*/:
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					bSaveProfile = false;
					UnlockAchievement(36);
				}
				break;
			case SeqAct_TdRegisterStat.EAchievementStatsID.EASID_LandingOnEnemyHead/*9*/:
				if(StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings))
				{
					bSaveProfile = false;
					UnlockAchievement(37);
				}
				break;
			default:
				StatsManager.RegisterStats(((SeqAct_TdRegisterStat.EAchievementStatsID)Id), time_stamp, ProfileSettings);
				break;
		}
		if(bSaveProfile)
		{
			TryWriteProfile();
		}
	}
	
	public virtual /*private final function */void TryWriteProfile()
	{
		/*local */TdProfileSettings ProfileSettings = default;
		/*local */LocalPlayer LocPlayer = default;
		/*local */int ControllerId = default;
	
		LocPlayer = ((Player) as LocalPlayer);
		ProfileSettings = GetProfileSettings();
		ControllerId = LocPlayer.ControllerId;
		if(((OnlineSub != default) && LocPlayer != default) && ProfileSettings != default)
		{
			OnlineSub.PlayerInterface.AddWriteProfileSettingsCompleteDelegate((byte)((byte)(ControllerId)), OnProfileWriteComplete);
			if(!OnlineSub.PlayerInterface.WriteProfileSettings((byte)((byte)(ControllerId)), ProfileSettings))
			{
				OnlineSub.PlayerInterface.ClearWriteProfileSettingsCompleteDelegate((byte)((byte)(ControllerId)), OnProfileWriteComplete);
			}
		}
	}
	
	public virtual /*private final function */void OnProfileWriteComplete(bool bSuccess)
	{
		OnlineSub.PlayerInterface.ClearWriteProfileSettingsCompleteDelegate((byte)((byte)(UIInteraction.GetPlayerControllerId(0))), OnProfileWriteComplete);
		if(bSuccess)
		{		
		}
		else
		{
			ShowErrorMessageBox();
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
		/*local */TdGameUISceneClient SceneClient = default;
	
		ErrorMessageBox = ((OpenedScene) as TdUIScene_MessageBox);
		SceneClient = ((UIRoot.GetSceneClient()) as TdGameUISceneClient);
		ErrorMessageBox.bPauseGameWhileActive = true;
		SceneClient.RequestPausedUpdate();
		ErrorMessageBox.DisplayAcceptCancelRetryBox("<Strings:TdGameUI.TdMessageBox.FailedToWriteProfileProgress_Message>", "<Strings:TdGameUI.TdMessageBox.FailedToWriteProfile_Title>", OnErrorMessageBoxClosed, default(bool?));
	}
	
	public virtual /*private final function */void OnErrorMessageBoxClosed(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		switch(SelectedOption)
		{
			case 1:
				TryWriteProfile();
				goto default;// UnrealScript fallthrough
			default:
				break;
		}
	}
	
	public virtual /*event */void CallPopUp(TdSPHUD.EPopUpType Type, float Duration)
	{
		/*local */TdSPHUD HUD = default;
		/*local */String Message = default;
	
		HUD = ((myHUD) as TdSPHUD);
		if(HUD == default)
		{
			return;
		}
		switch(Type)
		{
			case TdSPHUD.EPopUpType.PUT_Sniper/*1*/:
				Message = Localize("TdPopUps", "PopUp1", "TdGameUI");
				break;
			case TdSPHUD.EPopUpType.PUT_Bag/*4*/:
				Message = HUD.BuildBagString();
				break;
			case TdSPHUD.EPopUpType.PUT_Objective/*2*/:
				Message = Localize("TdPopUps", "PopUp2", "TdGameUI");
				break;
			case TdSPHUD.EPopUpType.PUT_Tutorial/*3*/:
				Message = Localize("TdPopUps", "PopUp3", "TdGameUI");
				break;
			case TdSPHUD.EPopUpType.PUT_Skip/*5*/:
				Message = Localize("TdPopUps", "PopUp4", "TdGameUI");
				break;
			default:
				break;
		}
		HUD.ActivatePopUp(((TdSPHUD.EPopUpType)Type), Duration, Message);
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdPlayerController_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdPlayerController_Reset;
	public /*function */void TdPlayerController_Reset()
	{
		/*Transformed 'base.' to specific call*/PlayerController_Reset();
		PlayerInput.ResetInput();
		bCinemaDisableInputMove = false;
		bCinemaDisableInputLook = false;
		bCinematicMode = false;
		bIgnoreLookInput = (byte)0;
		bIgnoreMoveInput = (byte)0;
		bGodMode = false;
		ClientStopForceFeedbackWaveform(default(ForceFeedbackWaveform?));
		bOverrideReactionTimeSettings = false;
		ReactionTimeEnergy = 0.0f;
		UpdateReactionTime(1.0f);
		bReactionTime = false;
		ReactionTimeEnergy = ReactionTimeSpawnLevel;
		TargetingPawn = default;
		TargetingPawnInterp = 0.0f;
		TargetPawn = default;
		TargetActor = default;
		CurrentLookAtPoint = default;
		CurrentForcedLookAtPoint = default;
		bLeftThumbStickPassedDeadZone = DefaultAs<TdPlayerController>().bLeftThumbStickPassedDeadZone;
		bRightThumbStickPassedDeadZone = DefaultAs<TdPlayerController>().bRightThumbStickPassedDeadZone;
		LocalEnemies.Length = 0;
		bDisableLoadFromLastCheckpoint = false;
		AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_EndFullMomentum/*7*/);
	}
	
	public virtual /*function */void OnDisableLoadFromLastCheckpoint(SeqAct_DisableLoadFromLastCheckpoint Action)
	{
		bDisableLoadFromLastCheckpoint = Action.bShouldBeDisabled;
	}
	
	public virtual /*function */bool CanLoadFromLastCheckpoint()
	{
		return !bDisableLoadFromLastCheckpoint && IsCutsceneSkippable();
	}
	
	public virtual /*function */void OnLevelCompleted(int LevelIndex, TdSPGame Game)
	{
		/*local */TdProfileSettings Profile = default;
		/*local */SeqAct_TdUnlockAchievement.ETdAchievements Id = default;
		/*local */int Difficulty = default, ProRunner = default;
	
		Profile = GetProfileSettings();
		if(Profile == default)
		{
			return;
		}
		Profile.OnLevelCompleted(LevelIndex);
		if((LevelIndex >= 1) && LevelIndex <= 10)
		{
			StatsManager.SaveStatsToProfile(Profile, false, Game.bShouldSaveCheckpointProgress, true);
			if(LevelIndex == 10)
			{
				if(Profile.GetProfileSettingValueId(/*maybe?*/TdProfileSettings.TDPID_GameDifficulty, ref/*probably?*/ Difficulty) && Difficulty == 2)
				{
					if(Profile.GetProfileSettingValueInt(/*maybe?*/TdProfileSettings.TDPID_ProRunner, ref/*probably?*/ ProRunner) && ProRunner == 1)
					{
						if(Game.bShouldSaveCheckpointProgress)
						{
							Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_SP_On_Hard_Complete/*27*/;
							UnlockAchievement(((int)Id));
						}
					}
				}
				Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_SP_Complete/*26*/;
				UnlockAchievement(((int)Id));
				if(Game.bShouldSaveCheckpointProgress)
				{
					if((GetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_HittingEnemyWithWeapon/*5*/)) == 0)
					{
						Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Complete_Game_Without_Bullet_Hurting/*31*/;
						UnlockAchievement(((int)Id));					
					}
					else
					{
						Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Complete_Game_Without_Bullet_Hurting/*31*/;
					}
				}			
			}
			else
			{
				Id = ((SeqAct_TdUnlockAchievement.ETdAchievements)((byte)((((int)/*unsupported function token*/1) + LevelIndex) - 1)));
				UnlockAchievement(((int)Id));
			}
			if(Game.bAllowSPLevelAchievements)
			{
				if((GetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_ShotsFired/*0*/)) == 0)
				{
					Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Complete_Level_Without_Shooting/*30*/;
					UnlockAchievement(((int)Id));				
				}
				else
				{
					Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Complete_Level_Without_Shooting/*30*/;
				}
				if((GetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_HeavyLanding/*8*/)) == 0)
				{
					Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Beat_Level_Without_Heavy_Landing/*29*/;
					UnlockAchievement(((int)Id));				
				}
				else
				{
					Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Beat_Level_Without_Heavy_Landing/*29*/;
				}
				if((GetStatCount(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_HitByEnemyWeapon/*4*/)) == 0)
				{
					Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Beat_Level_Without_Getting_Shot/*28*/;
					UnlockAchievement(((int)Id));				
				}
				else
				{
					Id = SeqAct_TdUnlockAchievement.ETdAchievements.ETA_Beat_Level_Without_Getting_Shot/*28*/;
				}			
			}
		}
	}
	
	public virtual /*function */void TriggerPickupFlash()
	{
		((myHUD) as TdHUD).TriggerCustomColorBlink(0.060f, 0.40f, 1.0f, 1.0f, 1.0f, true, default(/*delegate*/TdHUD.OnMaxFade?));
		ClientPlaySound(ObjectConst<SoundCue>("BagFound"));
		CallPopUp(TdSPHUD.EPopUpType.PUT_Bag/*4*/, 5.0f);
	}
	
	public virtual /*function */void OnLRCompleted(TdTTResult OnlineResult, TdTTResult OfflineResult)
	{
		/*local */DataStoreClient DataStoreManager = default;
		/*local */UIDataStore_TdTimeTrialData TimeTrialData = default;
		/*local */int ProviderIndex = default;
	
		if((((OnlineResult != default) && OnlineResult.bBeatQualifyerTime) || OfflineResult.bBeatQualifyerTime))
		{
			DataStoreManager = UIInteraction.GetDataStoreClient();
			if(DataStoreManager != default)
			{
				TimeTrialData = ((DataStoreManager.FindDataStore("TdTimeTrialData", default(LocalPlayer?))) as UIDataStore_TdTimeTrialData);
				if(TimeTrialData != default)
				{
					ProviderIndex = TimeTrialData.GetStretchProviderIndexFromId(TimeTrialData.GetCurrentWorkingStretchId(), "TdLevelRaceStretches");
					if(ProviderIndex != -1)
					{
						UnlockAchievement(16 + ProviderIndex);
					}
				}
			}
		}
	}
	
	public virtual /*function */void OnTTStretchCompleted(TdTTResult OnlineResult, TdTTResult OfflineResult)
	{
		if((((OnlineResult != default) && OnlineResult.CurrentTime.TotalRating >= 50) || OfflineResult.CurrentTime.TotalRating >= 50))
		{
			UnlockAchievement(15);
		}
		if((((OnlineResult != default) && OnlineResult.CurrentTime.TotalRating >= 35) || OfflineResult.CurrentTime.TotalRating >= 35))
		{
			UnlockAchievement(14);
		}
		if((((OnlineResult != default) && OnlineResult.CurrentTime.TotalRating >= 20) || OfflineResult.CurrentTime.TotalRating >= 20))
		{
			UnlockAchievement(13);
		}
		if((((OnlineResult != default) && OnlineResult.bBeatQualifyerTime) || OfflineResult.bBeatQualifyerTime))
		{
			UnlockAchievement(10);
		}
		if(GetProfileSettings().IsAllTTStretchesUnlocked())
		{
			UnlockAchievement(12);
		}
	}
	
	public virtual /*function */void UnlockAchievement(int AchievementId)
	{
		/*local */SeqAct_TdUnlockAchievement.ETdAchievements TempEnum = default;
		/*local */String NameOfEnum = default;
	
		TempEnum = ((SeqAct_TdUnlockAchievement.ETdAchievements)((byte)(AchievementId)));
		NameOfEnum = "Achievement unlocked: " + " " + ((TempEnum)).ToString();
		ClientUnlockAchievement(AchievementId, NameOfEnum);
	}
	
	public virtual /*reliable client simulated function */void ClientUnlockAchievement(int AchievementId, String Description)
	{
		/*local */LocalPlayer LocPlayer = default;
	
		if(OnlineSub != default)
		{
			if(NotEqual_InterfaceInterface(OnlineSub.PlayerInterfaceEx, (default(OnlinePlayerInterfaceEx))))
			{
				LocPlayer = ((Player) as LocalPlayer);
				OnlineSub.PlayerInterfaceEx.UnlockAchievement((byte)((byte)(LocPlayer.ControllerId)), AchievementId);			
			}		
		}
	}
	
	public virtual /*exec function */void ZoomWeapon()
	{
		/*local */TdWeapon TdW = default;
		/*local */float FOV = default, Rate = default, delay = default;
	
		if(!myPawn.CanZoom())
		{
			return;
		}
		if(((((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) || ((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Crouch/*15*/)))
		{
			TdW = ((Pawn.Weapon) as TdWeapon);
			if(((TdW != default) && TdW.bCanZoom) && !TdW.IsZooming())
			{
				TdW.ToggleZoom(ref/*probably?*/ FOV, ref/*probably?*/ Rate, ref/*probably?*/ delay);
				StartZoom(FOV, Rate, delay);
			}
		}
	}
	
	public override /*function */void AdjustFOV(float DeltaTime)
	{
		/*local */float DeltaFOV = default;
	
		FOVZoomDelay -= DeltaTime;
		if((FOVAngle != DesiredFOV) && FOVZoomDelay <= 0.0f)
		{
			FOVZoomDelay = 0.0f;
			if(FOVZoomRate > 0.0f)
			{
				DeltaFOV = FOVZoomRate * DeltaTime;
				if(FOVAngle > DesiredFOV)
				{
					FOVAngle = FMax(DesiredFOV, FOVAngle - DeltaFOV);				
				}
				else
				{
					FOVAngle = FMin(DesiredFOV, FOVAngle + DeltaFOV);
				}			
			}
			else
			{
				FOVAngle = DesiredFOV;
			}
		}
	}
	
	public virtual /*simulated function */void StartZoom(float NewDesiredFOV, float NewZoomRate, float delay)
	{
		FOVZoomRate = NewZoomRate;
		DesiredFOV = NewDesiredFOV;
		FOVZoomDelay = delay;
	}
	
	public virtual /*reliable client simulated function */void ClientStopZoom()
	{
		DesiredFOV = FOVAngle;
		FOVZoomRate = 0.0f;
	}
	
	// Export UTdPlayerController::execSetNearClippingPlane(FFrame&, void* const)
	public virtual /*native simulated function */void SetNearClippingPlane(float Value)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */void EndZoom()
	{
		DesiredFOV = DefaultFOV;
		FOVAngle = DefaultFOV;
		FOVZoomRate = 0.0f;
	}
	
	public virtual /*simulated event */void UnZoom()
	{
		/*local */TdWeapon TdW = default;
		/*local */float FOV = default, Rate = default;
	
		TdW = ((Pawn.Weapon) as TdWeapon);
		if((TdW != default) && TdW.IsZoomingOrZoomed())
		{
			TdW.ZoomOut(ref/*probably?*/ FOV, ref/*probably?*/ Rate);
			StartZoom(DefaultFOV, Rate, 0.0f);		
		}
		else
		{
			DesiredFOV = DefaultFOV;
			FOVZoomRate = 20.0f;
		}
	}
	
	public virtual /*reliable client simulated function */void ClientEndZoom()
	{
		EndZoom();
	}
	
	public override /*reliable client simulated function */void ClientSetOnlineStatus()
	{
		/*local */array<Settings.LocalizedStringSetting> StringSettings = default;
		/*local */array<Settings.SettingsProperty> Properties = default;
		/*local */int StatusId = default, ControllerId = default;
		/*local */Settings.LocalizedStringSetting StringSetting = default;
	
		ControllerId = ((Player) as LocalPlayer).ControllerId;
		StatusId = 0;
		if(IsInMainMenu())
		{
			StatusId = 1;		
		}
		else
		{
			if(((((WorldInfo.GRI.GameClass) as ClassT<TdSPStoryGame>) != default) || ((WorldInfo.GRI.GameClass) as ClassT<TdSPTutorialGame>) != default))
			{
				if(((WorldInfo.GRI.GameClass) as ClassT<TdSPLevelRace>) != default)
				{
					StatusId = 4;				
				}
				else
				{
					StatusId = 2;
				}
				StringSetting.Id = 1;
				StringSetting.ValueIndex = GetMapId(default(bool?));
				StringSettings.AddItem(StringSetting);			
			}
			else
			{
				if(((WorldInfo.GRI.GameClass) as ClassT<TdSPTimeTrialGame>) != default)
				{
					StatusId = 3;
					StringSetting.Id = 0;
					StringSetting.ValueIndex = GetMapId(true);
					StringSettings.AddItem(StringSetting);
				}
			}
		}
		OnlineSub.PlayerInterface.SetOnlineStatus((byte)((byte)(ControllerId)), StatusId, ref/*probably?*/ StringSettings, ref/*probably?*/ Properties);
	}
	
	public virtual /*function */int GetMapId(/*optional */bool? _TimeTrial = default)
	{
		/*local */array<TpPresenceManager.PresBind> PresBindings = default;
		/*local */TdGameUISceneClient SceneClient = default;
		/*local */UIDataStore_TdTimeTrialData TTDataStore = default;
		/*local */int Idx = default;
	
		var TimeTrial = _TimeTrial ?? default;
		if(WorldInfo.IsConsoleBuild(default(WorldInfo.EConsoleType?)))
		{
			PresBindings = ClassT<TpPresenceManager>().DefaultAs<TpPresenceManager>().PresenceBindings;
			Idx = 0;
			J0x31:{}
			if(Idx < PresBindings.Length)
			{
				if(ApproximatelyEqual(PresBindings[Idx].LevelName, WorldInfo.GetMapName(default(bool?))))
				{
					return PresBindings[Idx].PresenceId;
				}
				++ Idx;
				goto J0x31;
			}		
		}
		else
		{
			SceneClient = ((GetUIController().SceneClient) as TdGameUISceneClient);
			if(TimeTrial)
			{
				TTDataStore = ((SceneClient.FindDataStore("TdTimeTrialData", default(LocalPlayer?))) as UIDataStore_TdTimeTrialData);
				return TTDataStore.GetCurrentWorkingStretchProviderIndex();
			}
			return SceneClient.GetGameDataStore().GetMapIndexFromFileName(WorldInfo.GetMapName(default(bool?)));
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public override /*function */void ResetPlayerMovementInput()
	{
		base.ResetPlayerMovementInput();
		bIgnoreButtonInput = (byte)DefaultAs<TdPlayerController>().bIgnoreButtonInput;
	}
	
	public virtual /*event */bool IsCutsceneSkippable()
	{
		return !bDisableSkipCutscenes;
	}
	
	// Export UTdPlayerController::execSkipCutscene(FFrame&, void* const)
	public virtual /*native exec function */bool SkipCutscene()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void InitializeNavigation()
	{
		/*local */float TriggerTime = default;
	
		TriggerTime = 4.0f + (FRand() * 5.0f);
		SetTimer(TriggerTime, false, "Jump", PlayerInput);
		SetTimer(TriggerTime + 0.40f, false, "LookBehind", default(Object?));
		SetTimer(TriggerTime + 0.60f, false, "RandomLieOnBack", default(Object?));
	}
	
	// Export UTdPlayerController::execGetInvViewProjection(FFrame&, void* const)
	public virtual /*native function */Object.Matrix GetInvViewProjection()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPlayerController::execIsControllerTiltActive(FFrame&, void* const)
	public override /*native simulated function */bool IsControllerTiltActive()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPlayerController::execSetControllerTiltDesiredIfAvailable(FFrame&, void* const)
	public override /*native simulated function */void SetControllerTiltDesiredIfAvailable(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPlayerController::execSetControllerTiltActive(FFrame&, void* const)
	public override /*native simulated function */void SetControllerTiltActive(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPlayerController::execSetOnlyUseControllerTiltInput(FFrame&, void* const)
	public override /*native simulated function */void SetOnlyUseControllerTiltInput(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPlayerController::execSetUseTiltForwardAndBack(FFrame&, void* const)
	public override /*native simulated function */void SetUseTiltForwardAndBack(bool bActive)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void CheckTriggerStopAnim_del();
	public virtual CheckTriggerStopAnim_del CheckTriggerStopAnim { get => bfield_CheckTriggerStopAnim ?? (()=>{}); set => bfield_CheckTriggerStopAnim = value; } CheckTriggerStopAnim_del bfield_CheckTriggerStopAnim;
	public virtual CheckTriggerStopAnim_del global_CheckTriggerStopAnim => ()=>{};
	
	public delegate void PlayStop_del();
	public virtual PlayStop_del PlayStop { get => bfield_PlayStop ?? (()=>{}); set => bfield_PlayStop = value; } PlayStop_del bfield_PlayStop;
	public virtual PlayStop_del global_PlayStop => ()=>{};
	
	public delegate bool ShouldPlayStopAnim_del();
	public virtual ShouldPlayStopAnim_del ShouldPlayStopAnim { get => bfield_ShouldPlayStopAnim ?? (()=>default); set => bfield_ShouldPlayStopAnim = value; } ShouldPlayStopAnim_del bfield_ShouldPlayStopAnim;
	public virtual ShouldPlayStopAnim_del global_ShouldPlayStopAnim => ()=>default;
	
	public delegate void PlayStopLeft_del();
	public virtual PlayStopLeft_del PlayStopLeft { get => bfield_PlayStopLeft ?? (()=>{}); set => bfield_PlayStopLeft = value; } PlayStopLeft_del bfield_PlayStopLeft;
	public virtual PlayStopLeft_del global_PlayStopLeft => ()=>{};
	
	public delegate void PlayStopRight_del();
	public virtual PlayStopRight_del PlayStopRight { get => bfield_PlayStopRight ?? (()=>{}); set => bfield_PlayStopRight = value; } PlayStopRight_del bfield_PlayStopRight;
	public virtual PlayStopRight_del global_PlayStopRight => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		NextViewTarget = null;
		PrevViewTarget = null;
		PressedSwitchWeapon = null;
		NextWeapon = null;
		PrevWeapon = null;
		StartAltFire = null;
		StartFire = null;
		ClientRestart = null;
		NextStaticViewTarget = null;
		PrevStaticViewTarget = null;
		PawnDied = null;
		PlayerTick = null;
		Possess = null;
		LongClientAdjustPosition = null;
		UpdateRotation = null;
		AttemptReactionTime = null;
		ShouldDelayJump = null;
		SetInputHint = null;
		Reset = null;
	
	}
	
	protected /*reliable server function */void TdPlayerController_PlayerWaiting_ServerRestartPlayer()// state function
	{
		WorldInfo.Game.RestartPlayer(this);
	}
	
	protected /*exec function */void TdPlayerController_PlayerWaiting_NextViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewNextPlayer();
		}
	}
	
	protected /*exec function */void TdPlayerController_PlayerWaiting_PrevViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewPrevPlayer();
		}
	}
	
	protected /*exec function */void TdPlayerController_PlayerWaiting_NextStaticViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewNextSpectatorPoint();
		}
	}
	
	protected /*exec function */void TdPlayerController_PlayerWaiting_PrevStaticViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewPrevSpectatorPoint();
		}
	}
	
	protected /*unreliable server function */void TdPlayerController_PlayerWaiting_ServerViewNextPlayer()// state function
	{
		/*local */TdPawn MyPawnViewTarget = default;
	
		/*Transformed 'base.' to specific call*/PlayerController_ServerViewNextPlayer();
		if(IsLocalPlayerController())
		{
			MyPawnViewTarget = ((ViewTarget) as TdPawn);
			if(MyPawnViewTarget != default)
			{
				SetCameraMode("ThirdPerson");
				MyPawnViewTarget.SetFirstPerson(false);
			}
		}
	}
	
	protected /*reliable client simulated event */void TdPlayerController_PlayerWaiting_ClientSetViewTarget(Actor A, /*optional */Camera.ViewTargetTransitionParams? _TransitionParams = default)// state function
	{
		var TransitionParams = _TransitionParams ?? default;
		/*Transformed 'base.' to specific call*/PlayerController_ClientSetViewTarget(A, TransitionParams);
		if(ViewTarget.IsA("TdPawn"))
		{
			((ViewTarget) as TdPawn).SetFirstPerson(false);
			SetCameraMode("ThirdPerson");		
		}
		else
		{
			if(ViewTarget.IsA("TdSpectatorPoint"))
			{
				SetCameraMode("Spectating");
			}
		}
	}
	
	protected /*function */bool TdPlayerController_PlayerWaiting_IsDead()// state function
	{
		return true;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerWaiting()/*auto state PlayerWaiting*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ AttemptReactionTime = ()=>{}; StartFire = (_a)=>{};
	
			ServerRestartPlayer = TdPlayerController_PlayerWaiting_ServerRestartPlayer;
			NextViewTarget = TdPlayerController_PlayerWaiting_NextViewTarget;
			PrevViewTarget = TdPlayerController_PlayerWaiting_PrevViewTarget;
			NextStaticViewTarget = TdPlayerController_PlayerWaiting_NextStaticViewTarget;
			PrevStaticViewTarget = TdPlayerController_PlayerWaiting_PrevStaticViewTarget;
			ServerViewNextPlayer = TdPlayerController_PlayerWaiting_ServerViewNextPlayer;
			ClientSetViewTarget = TdPlayerController_PlayerWaiting_ClientSetViewTarget;
			IsDead = TdPlayerController_PlayerWaiting_IsDead;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, null);
	}
	
	
	protected /*event */bool TdPlayerController_PlayerWalking_NotifyLanded(Object.Vector HitNormal, Actor FloorActor)// state function
	{
		return bUpdating;
	}
	
	protected /*function */void TdPlayerController_PlayerWalking_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		if(((Pawn == default) || myPawn == default))
		{
			return;
		}
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			myPawn.SetRemoteViewYaw(Rotation.Yaw);
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
		}
		Pawn.Acceleration = newAccel;
		CheckCrouch();
		CheckJumpPressed();
		CheckJumpReleased();
	}
	
	protected /*function */void TdPlayerController_PlayerWalking_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default, newAccel = default, WalkDirection = default;
	
		/*local */Object.Rotator OldRotation = default;
		/*local */bool SprintRequested = default;
	
		GetAxes(Pawn.Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		CheckTriggerStopAnim();
		if(bIsStopping)
		{
			if(((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
			{
				myPawn.Velocity = Normal(myPawn.Velocity) * StoppingVelocity;
				newAccel = Normal(myPawn.Velocity) * StoppingVelocity;
			}		
		}
		else
		{
			WalkDirection = Normal((PlayerInput.aForward * X) + (PlayerInput.aStrafe * Y));
			if(((int)myPawn.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
			{
				bIsStopping = false;
				newAccel = myPawn.GetSprintAcceleration(PlayerInput.aForward, PlayerInput.aStrafe, ((int)(PlayerInput.aTurn)), DeltaTime);			
			}
			else
			{
				if(VSize2D(WalkDirection) > 0.0f)
				{
					AccelerationTime += DeltaTime;
					StoppingVelocity = 200.0f;
					SprintRequested = ((PlayerInput.aForward > InputMaxSprintHeightLimit) && InputSize > InputMaxSprintRaduisLimit) && (Dot(Pawn.Velocity, WalkDirection)) > ((float)(0));
					if(SprintRequested)
					{
						newAccel = myPawn.GetSprintAcceleration(PlayerInput.aForward, PlayerInput.aStrafe, ((int)(PlayerInput.aTurn)), DeltaTime);					
					}
					else
					{
						if(VSize2D(WalkDirection) > 0.50f)
						{
							newAccel = myPawn.GetWalkAcceleration(PlayerInput.aForward, PlayerInput.aStrafe, ((int)(PlayerInput.aTurn)), DeltaTime);						
						}
						else
						{
							PlayerInput.aForward = 0.10f * myPawn.sign(PlayerInput.aForward);
							PlayerInput.aStrafe = 0.10f * myPawn.sign(PlayerInput.aStrafe);
							newAccel = myPawn.GetWalkAcceleration(PlayerInput.aForward, PlayerInput.aStrafe, ((int)(PlayerInput.aTurn)), DeltaTime);
						}
					}				
				}
				else
				{
					newAccel = myPawn.GetWalkAcceleration(PlayerInput.aForward, PlayerInput.aStrafe, ((int)(PlayerInput.aTurn)), DeltaTime);
					if((AccelerationTime > 0.0f) && AccelerationTime < 0.150f)
					{
						bIsStopping = true;
						SetTimer(0.250f, false, "PlayStop", default(Object?));
						StoppingVelocity = 35.0f;
						myPawn.Velocity = Normal(myPawn.Velocity) * StoppingVelocity;
					}
					AccelerationTime = 0.0f;
				}
			}
		}
		OldRotation = Rotation;
		UpdateRotation(DeltaTime);
		bDoubleJump = false;
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bReleasedJump = false;
		bPressedJump = false;
		if(ControllerTilt)
		{
			if(((ActualAccelZ - LastZAxisTilt) < SixAxisDisarmZ) && (ActualAccelY - LastYAxisTilt) > SixAxisDisarmY)
			{
				DisarmTimeMultiplier = 0.20f;
				SnatchAttempt();
			}
			if(((((ActualAccelZ - LastZAxisTilt) > SixAxisRollZ) && (ActualAccelY - LastYAxisTilt) > SixAxisRollY) && ((int)myPawn.Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/)) && (myPawn.RollTriggerTime + 0.80f) < myPawn.WorldInfo.TimeSeconds)
			{
				myPawn.RollTriggerTime = myPawn.WorldInfo.TimeSeconds + 0.20f;
			}
			LastZAxisTilt = ActualAccelZ;
			LastYAxisTilt = ActualAccelY;
		}
	}
	
	protected /*function */void TdPlayerController_PlayerWalking_CheckTriggerStopAnim()// state function
	{
		/*local */float WalkCyclePos = default;
	
		if(((int)myPawn.MovementState) != ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			return;
		}
		if((Abs(PlayerInput.aForward) <= 0.010f) && Abs(PlayerInput.aStrafe) <= 0.010f)
		{
			if(bIsWalking)
			{
				if(myPawn.MasterSync3p.Groups[0].MasterNode.AnimSeq == default)
				{
					return;
				}
				WalkCyclePos = myPawn.MasterSync3p.Groups[0].MasterNode.CurrentTime / myPawn.MasterSync3p.Groups[0].MasterNode.AnimSeq.SequenceLength;
				if(WalkCyclePos >= WalkCyclePart2)
				{
					PlayStopLeft();				
				}
				else
				{
					if(WalkCyclePos <= WalkCyclePart1)
					{
						PlayStopLeft();					
					}
					else
					{
						PlayStopRight();
					}
				}
				bIsStopping = false;
				bIsWalking = false;
			}		
		}
		else
		{
			if((!bIsWalking && !bIsStopping) && ((int)myPawn.CurrentWalkingState) >= ((int)TdPawn.WalkingState.WAS_Walk/*2*/))
			{
				ClearTimer("PlayStopLeft", default(Object?));
				ClearTimer("PlayStopRight", default(Object?));
				myPawn.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody_Dir/*3*/, StopAnimBlendOut);
				bIsWalking = true;
				bIsStopping = false;
			}
		}
	}
	
	protected /*event */void TdPlayerController_PlayerWalking_PlayStop()// state function
	{
		bIsStopping = false;
	}
	
	protected /*function */bool TdPlayerController_PlayerWalking_ShouldPlayStopAnim()// state function
	{
		/*local */TdWeapon TdW = default;
	
		TdW = ((myPawn.Weapon) as TdWeapon);
		return (((int)myPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) && ((TdW == default) || (((int)TdW.WeaponType) != ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) && !TdW.IsZoomingOrZoomed());
	}
	
	protected /*event */void TdPlayerController_PlayerWalking_PlayStopLeft()// state function
	{
		if(ShouldPlayStopAnim())
		{
			myPawn.PlayCustomAnim(TdPawn.CustomNodeType.CNT_LowerBody/*5*/, "walktostandpassleft", 1.0f, StopAnimBlendIn, StopAnimBlendOut, false, true, false, default(bool?));
		}
		bIsStopping = false;
	}
	
	protected /*event */void TdPlayerController_PlayerWalking_PlayStopRight()// state function
	{
		if(ShouldPlayStopAnim())
		{
			myPawn.PlayCustomAnim(TdPawn.CustomNodeType.CNT_LowerBody/*5*/, "walktostandpassright", 1.0f, StopAnimBlendIn, StopAnimBlendOut, false, true, false, default(bool?));
		}
		bIsStopping = false;
	}
	
	protected /*function */void TdPlayerController_PlayerWalking_BeginState(name PreviousStateName)// state function
	{
		DoubleClickDir = Actor.EDoubleClickDir.DCLICK_None/*0*/;
		bPressedJump = false;
		GroundPitch = 0;
		bIsStopping = false;
		if(Pawn != default)
		{
			Pawn.ShouldCrouch(false);
			if(((((((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/)) && ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/)) && ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_Flying/*4*/)) && ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_WallClimbing/*13*/)) && ((int)Pawn.Physics) != ((int)Actor.EPhysics.PHYS_WallRunning/*12*/))
			{
				Pawn.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
			}
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerWalking()/*state PlayerWalking*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			NotifyLanded = TdPlayerController_PlayerWalking_NotifyLanded;
			ProcessMove = TdPlayerController_PlayerWalking_ProcessMove;
			PlayerMove = TdPlayerController_PlayerWalking_PlayerMove;
			CheckTriggerStopAnim = TdPlayerController_PlayerWalking_CheckTriggerStopAnim;
			PlayStop = TdPlayerController_PlayerWalking_PlayStop;
			ShouldPlayStopAnim = TdPlayerController_PlayerWalking_ShouldPlayStopAnim;
			PlayStopLeft = TdPlayerController_PlayerWalking_PlayStopLeft;
			PlayStopRight = TdPlayerController_PlayerWalking_PlayStopRight;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_PlayerWalking_BeginState, StateFlow, null);
	}
	
	
	protected /*function */void TdPlayerController_PlayerGrabbing_BeginState(name PreviousStateName)// state function
	{
		if(((int)myPawn.MovementState) != ((int)TdPawn.EMovement.MOVE_Climb/*21*/))
		{
			bLeftThumbStickPassedDeadZone = false;		
		}
		else
		{
			bLeftThumbStickPassedDeadZone = true;
		}
	}
	
	protected /*function */void TdPlayerController_PlayerGrabbing_EndState(name NextStateName)// state function
	{
		bLeftThumbStickPassedDeadZone = true;
	}
	
	protected /*function */void TdPlayerController_PlayerGrabbing_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		if((myPawn != default) && !(myPawn.bForceRMVelocity || myPawn.bIsUsingRootMotion))
		{
			if(newAccel.Y > 8.0f)
			{
				myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ShimmyRightLong/*15*/);			
			}
			else
			{
				if(newAccel.Y < -8.0f)
				{
					myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ShimmyLeftLong/*13*/);				
				}
				else
				{
					if(newAccel.Y > 3.0f)
					{
						myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ShimmyRight/*14*/);					
					}
					else
					{
						if(newAccel.Y < -3.0f)
						{
							myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ShimmyLeft/*12*/);						
						}
						else
						{
							if((newAccel.X > 8.0f) && ((int)myPawn.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
							{
								myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ClimbUpLong/*9*/);							
							}
							else
							{
								if((newAccel.X < -8.0f) && ((int)myPawn.MoveActionHint) == ((int)TdPawn.EMoveActionHint.MAH_Down/*4*/))
								{
									myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ClimbDownLong/*10*/);								
								}
								else
								{
									if(newAccel.X > 3.0f)
									{
										myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ClimbUp/*7*/);									
									}
									else
									{
										if(newAccel.X < -3.0f)
										{
											myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ClimbDown/*8*/);										
										}
										else
										{
											myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_None/*0*/);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
			myPawn.SetRemoteViewYaw(Rotation.Yaw);
		}
		Pawn.Acceleration = vect(0.0f, 0.0f, 0.0f);
		CheckJumpPressed();
		CheckJumpReleased();
		CheckCrouch();
	}
	
	protected /*function */bool TdPlayerController_PlayerGrabbing_ShouldDelayJump()// state function
	{
		return false;
	}
	
	protected /*function */void TdPlayerController_PlayerGrabbing_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector newAccel = default;
		/*local */Object.Rotator OldRotation = default, ViewRotation = default;
		/*local */bool bDelayJump = default;
	
		OldRotation = Rotation;
		ViewRotation = Rotation;
		newAccel = vect(0.0f, 0.0f, 0.0f);
		newAccel.X = PlayerInput.aForward * 10.0f;
		newAccel.Y = PlayerInput.aStrafe * 10.0f;
		SetRotation(ViewRotation);
		UpdateRotation(DeltaTime);
		if(bPressedJump && ShouldDelayJump())
		{
			bDelayJump = !bReleasedJump;
			bPressedJump = false;		
		}
		else
		{
			bDelayJump = false;
			bReleasedJump = false;
		}
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bReleasedJump = false;
		bPressedJump = bDelayJump;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerGrabbing()/*state PlayerGrabbing*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			ProcessMove = TdPlayerController_PlayerGrabbing_ProcessMove;
			ShouldDelayJump = TdPlayerController_PlayerGrabbing_ShouldDelayJump;
			PlayerMove = TdPlayerController_PlayerGrabbing_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_PlayerGrabbing_BeginState, StateFlow, TdPlayerController_PlayerGrabbing_EndState);
	}
	
	
	protected /*function */void TdPlayerController_PlayerBalanceWalk_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector newAccel = default;
		/*local */Object.Rotator OldRotation = default;
		/*local */float Balance = default;
	
		Balance = ((ControllerTilt && PlayerInput.aStrafe == 0.0f) ? PlayerInput.aPS3AccelX : PlayerInput.aStrafe);
		newAccel = ((Vector)(myPawn.Rotation)) * (Dot(myPawn.GetWalkAcceleration(PlayerInput.aForward, 0.0f, ((int)(PlayerInput.aTurn)), DeltaTime), ((Vector)(myPawn.Rotation))));
		newAccel += ((Cross(((Vector)(myPawn.Rotation)), vect(0.0f, 0.0f, 1.0f))) * Balance);
		OldRotation = Rotation;
		UpdateRotation(DeltaTime);
		bDoubleJump = false;
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bReleasedJump = false;
		bPressedJump = false;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerBalanceWalk()/*state PlayerBalanceWalk extends PlayerWalking*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
	
			// Inherited from TdPlayerController.PlayerWalking
			NotifyLanded = TdPlayerController_PlayerWalking_NotifyLanded;
			ProcessMove = TdPlayerController_PlayerWalking_ProcessMove;
			PlayerMove = TdPlayerController_PlayerWalking_PlayerMove;
			CheckTriggerStopAnim = TdPlayerController_PlayerWalking_CheckTriggerStopAnim;
			PlayStop = TdPlayerController_PlayerWalking_PlayStop;
			ShouldPlayStopAnim = TdPlayerController_PlayerWalking_ShouldPlayStopAnim;
			PlayStopLeft = TdPlayerController_PlayerWalking_PlayStopLeft;
			PlayStopRight = TdPlayerController_PlayerWalking_PlayStopRight;
	
			PlayerMove = TdPlayerController_PlayerBalanceWalk_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_PlayerWalking_BeginState, StateFlow, null);
	}
	
	
	protected /*function */void TdPlayerController_PlayerLedgeWalking_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector newAccel = default;
		/*local */Object.Rotator OldRotation = default;
	
		newAccel.Y = PlayerInput.aStrafe * 10.0f;
		newAccel.X = PlayerInput.aForward * 10.0f;
		newAccel.Z = 0.0f;
		OldRotation = Rotation;
		UpdateRotation(DeltaTime);
		bDoubleJump = false;
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bReleasedJump = false;
		bPressedJump = false;
	}
	
	protected /*function */void TdPlayerController_PlayerLedgeWalking_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		if((myPawn != default) && !(myPawn.bForceRMVelocity || myPawn.bIsUsingRootMotion))
		{
			if(newAccel.Y > 6.0f)
			{
				myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ShimmyRight/*14*/);			
			}
			else
			{
				if(newAccel.Y < -6.0f)
				{
					myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_ShimmyLeft/*12*/);				
				}
				else
				{
					myPawn.HandleMoveAction(TdPawn.EMovementAction.MA_None/*0*/);
				}
			}
		}
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
			myPawn.SetRemoteViewYaw(Rotation.Yaw);
		}
		Pawn.Acceleration = vect(0.0f, 0.0f, 0.0f);
		CheckJumpPressed();
		CheckJumpReleased();
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerLedgeWalking()/*state PlayerLedgeWalking extends PlayerWalking*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
	
			// Inherited from TdPlayerController.PlayerWalking
			NotifyLanded = TdPlayerController_PlayerWalking_NotifyLanded;
			ProcessMove = TdPlayerController_PlayerWalking_ProcessMove;
			PlayerMove = TdPlayerController_PlayerWalking_PlayerMove;
			CheckTriggerStopAnim = TdPlayerController_PlayerWalking_CheckTriggerStopAnim;
			PlayStop = TdPlayerController_PlayerWalking_PlayStop;
			ShouldPlayStopAnim = TdPlayerController_PlayerWalking_ShouldPlayStopAnim;
			PlayStopLeft = TdPlayerController_PlayerWalking_PlayStopLeft;
			PlayStopRight = TdPlayerController_PlayerWalking_PlayStopRight;
	
			/*ignores*/ SetInputHint = ()=>{};
	
			PlayerMove = TdPlayerController_PlayerLedgeWalking_PlayerMove;
			ProcessMove = TdPlayerController_PlayerLedgeWalking_ProcessMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_PlayerWalking_BeginState, StateFlow, null);
	}
	
	
	protected /*function */void TdPlayerController_PlayerWallWalking_UpdateRotation(float DeltaTime)// state function
	{
		/*local */Object.Rotator ViewRotation = default, DeltaRot = default;
	
		ViewRotation = Rotation;
		DesiredRotation = ViewRotation;
		DeltaRot.Yaw = ((int)(PlayerInput.aTurn));
		DeltaRot.Pitch = ((int)(PlayerInput.aLookUp));
		if(myPawn != default)
		{
			if(CurrentLookAtPoint != default)
			{
				CurrentLookAtPoint.UpdateViewRotation(ViewRotation, DeltaTime, ref/*probably?*/ DeltaRot, myPawn.Location);
			}
			myPawn.Moves[((int)myPawn.MovementState)].UpdateViewRotation(ref/*probably?*/ ViewRotation, DeltaTime, ref/*probably?*/ DeltaRot);
		}
		ProcessViewRotation(DeltaTime, ref/*probably?*/ ViewRotation, DeltaRot);
		SetRotation(ViewRotation);
		ViewShake(DeltaTime);
		if(Pawn != default)
		{
			Pawn.FaceRotation(Pawn.Rotation, DeltaTime);
		}
		UpdateStickyAim(DeltaTime);
	}
	
	protected /*function */void TdPlayerController_PlayerWallWalking_ProcessMove(float DeltaTime, Object.Vector newAccel, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRot)// state function
	{
		Pawn.Acceleration = newAccel;
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			myPawn.SetRemoteViewYaw(Rotation.Yaw);
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
		}
		CheckJumpPressed();
		CheckJumpReleased();
		CheckCrouch();
	}
	
	protected /*function */bool TdPlayerController_PlayerWallWalking_ShouldDelayJump()// state function
	{
		return false;
	}
	
	protected /*function */void TdPlayerController_PlayerWallWalking_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector newAccel = default;
		/*local */Object.Rotator OldRotation = default, ViewRotation = default;
		/*local */bool bDelayJump = default;
	
		GroundPitch = 0;
		ViewRotation = Rotation;
		SetRotation(ViewRotation);
		OldRotation = Rotation;
		UpdateRotation(DeltaTime);
		newAccel = vect(0.0f, 0.0f, 0.0f);
		if(bPressedJump && ShouldDelayJump())
		{
			bDelayJump = !bReleasedJump;
			bPressedJump = false;		
		}
		else
		{
			bDelayJump = false;
			bReleasedJump = false;
		}
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bReleasedJump = false;
		bPressedJump = bDelayJump;
	}
	
	protected /*function */void TdPlayerController_PlayerWallWalking_SetInputHint()// state function
	{
		/*local */float StrafeThresholdValue = default;
	
		/*Transformed 'base.' to specific call*/TdPlayerController_SetInputHint();
		StrafeThresholdValue = ((myPawn.IsInMove(TdPawn.EMovement.MOVE_WallClimbing/*6*/)) ? WallClimbingDodgeJumpThreshold : WallRunningDodgeJumpThreshold);
		if(bLeftThumbStickPassedDeadZone)
		{
			if(PlayerInput.aStrafe > StrafeThresholdValue)
			{
				myPawn.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_Right/*2*/, PlayerInput.aStrafe > 0.960f);			
			}
			else
			{
				if(PlayerInput.aStrafe < -StrafeThresholdValue)
				{
					myPawn.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_Left/*1*/, PlayerInput.aStrafe < -0.960f);				
				}
				else
				{
					if(((int)myPawn.MoveActionHint) != ((int)TdPawn.EMoveActionHint.MAH_Up/*3*/))
					{
						myPawn.SetMoveActionHint(TdPawn.EMoveActionHint.MAH_None/*0*/, false);
					}
				}
			}
		}
	}
	
	protected /*function */void TdPlayerController_PlayerWallWalking_BeginState(name PreviousStateName)// state function
	{
		WallRunningAlignYaw = Pawn.Rotation.Yaw;
		OldFloor = Pawn.Floor;
		GetAxes(Rotation, ref/*probably?*/ ViewX, ref/*probably?*/ ViewY, ref/*probably?*/ ViewZ);
		GroundPitch = 0;
	}
	
	protected /*function */void TdPlayerController_PlayerWallWalking_EndState(name NextStateName)// state function
	{
		GroundPitch = 0;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerWallWalking()/*state PlayerWallWalking*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			UpdateRotation = TdPlayerController_PlayerWallWalking_UpdateRotation;
			ProcessMove = TdPlayerController_PlayerWallWalking_ProcessMove;
			ShouldDelayJump = TdPlayerController_PlayerWallWalking_ShouldDelayJump;
			PlayerMove = TdPlayerController_PlayerWallWalking_PlayerMove;
			SetInputHint = TdPlayerController_PlayerWallWalking_SetInputHint;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_PlayerWallWalking_BeginState, StateFlow, TdPlayerController_PlayerWallWalking_EndState);
	}
	
	
	protected /*exec function */void TdPlayerController_Spectating_NextStaticViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewNextSpectatorPoint();
		}
	}
	
	protected /*exec function */void TdPlayerController_Spectating_PrevStaticViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewPrevSpectatorPoint();
		}
	}
	
	protected /*exec function */void TdPlayerController_Spectating_NextViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewNextPlayer();
		}
	}
	
	protected /*exec function */void TdPlayerController_Spectating_PrevViewTarget()// state function
	{
		if(WorldInfo.GRI.AllowViewTargetSwitching())
		{
			ServerViewPrevPlayer();
		}
	}
	
	protected /*unreliable server function */void TdPlayerController_Spectating_ServerViewNextPlayer()// state function
	{
		/*local */TdPawn MyPawnViewTarget = default;
	
		/*Transformed 'base.' to specific call*/PlayerController_ServerViewNextPlayer();
		if(IsLocalPlayerController())
		{
			MyPawnViewTarget = ((ViewTarget) as TdPawn);
			if(MyPawnViewTarget != default)
			{
				SetCameraMode("ThirdPerson");
				MyPawnViewTarget.SetFirstPerson(false);
			}
		}
	}
	
	protected /*reliable client simulated event */void TdPlayerController_Spectating_ClientSetViewTarget(Actor A, /*optional */Camera.ViewTargetTransitionParams? _TransitionParams = default)// state function
	{
		var TransitionParams = _TransitionParams ?? default;
		/*Transformed 'base.' to specific call*/PlayerController_ClientSetViewTarget(A, TransitionParams);
		if(ViewTarget.IsA("TdPawn"))
		{
			((ViewTarget) as TdPawn).SetFirstPerson(false);
			SetCameraMode("ThirdPerson");		
		}
		else
		{
			if(ViewTarget.IsA("TdSpectatorPoint"))
			{
				SetCameraMode("Spectating");
			}
		}
	}
	
	protected /*event */void TdPlayerController_Spectating_PlayerTick(float DeltaTime)// state function
	{
		if(ViewTarget.IsA("Pawn"))
		{
			TargetViewRotation = ViewTarget.Rotation;
			TargetViewRotation.Pitch = /*<<*/ShiftL(((int)((ViewTarget) as Pawn).RemoteViewPitch), ((int)8));
		}
		/*Transformed 'base(PlayerController).' to specific call*/PlayerController_PlayerTick(DeltaTime);
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Spectating()/*state Spectating*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ StartFire = (_a)=>{}; StartAltFire = (_a)=>{}; AttemptReactionTime = ()=>{};
	
			NextStaticViewTarget = TdPlayerController_Spectating_NextStaticViewTarget;
			PrevStaticViewTarget = TdPlayerController_Spectating_PrevStaticViewTarget;
			NextViewTarget = TdPlayerController_Spectating_NextViewTarget;
			PrevViewTarget = TdPlayerController_Spectating_PrevViewTarget;
			ServerViewNextPlayer = TdPlayerController_Spectating_ServerViewNextPlayer;
			ClientSetViewTarget = TdPlayerController_Spectating_ClientSetViewTarget;
			PlayerTick = TdPlayerController_Spectating_PlayerTick;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, null);
	}
	
	
	protected /*function */void TdPlayerController_Ropeburn_BeginState(name PreviousStateName)// state function
	{
		bRopeburnDisarmSucceeded = false;
	}
	
	protected /*function */void TdPlayerController_Ropeburn_EndState(name NextStateName)// state function
	{
		bRopeburnDisarmSucceeded = false;
		bIgnoreButtonInput = (byte)0;
	}
	
	protected /*function */void TdPlayerController_Ropeburn_ProcessMove(float DeltaTime, Object.Vector PawnAcceleration, Actor.EDoubleClickDir DoubleClickMove, Object.Rotator DeltaRotation)// state function
	{
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			myPawn.SetRemoteViewYaw(Rotation.Yaw);
			Pawn.SetRemoteViewPitch(Rotation.Pitch);
		}
	}
	
	protected /*function */void TdPlayerController_Ropeburn_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Rotator PreviousRotation = default;
	
		PreviousRotation = Rotation;
		UpdateRotation(DeltaTime);
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ProcessMove(DeltaTime, vect(0.0f, 0.0f, 0.0f), Actor.EDoubleClickDir.DCLICK_None/*0*/, PreviousRotation - Rotation);
		}
	}
	
	protected /*exec function */void TdPlayerController_Ropeburn_PressedSwitchWeapon()// state function
	{
		if(!bCinematicMode)
		{
			bRopeburnDisarmSucceeded = true;
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Ropeburn()/*state Ropeburn*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			ProcessMove = TdPlayerController_Ropeburn_ProcessMove;
			PlayerMove = TdPlayerController_Ropeburn_PlayerMove;
			PressedSwitchWeapon = TdPlayerController_Ropeburn_PressedSwitchWeapon;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_Ropeburn_BeginState, StateFlow, TdPlayerController_Ropeburn_EndState);
	}
	
	
	protected /*function */void TdPlayerController_PlayerDying_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector newAccel = default;
		/*local */Object.Rotator OldRotation = default, ViewRotation = default;
		/*local */bool bDelayJump = default;
	
		OldRotation = Rotation;
		ViewRotation = Rotation;
		newAccel = vect(0.0f, 0.0f, 0.0f);
		newAccel.X = PlayerInput.aForward * 10.0f;
		newAccel.Y = PlayerInput.aStrafe * 10.0f;
		SetRotation(ViewRotation);
		UpdateRotation(DeltaTime);
		if(bPressedJump && ShouldDelayJump())
		{
			bDelayJump = !bReleasedJump;
			bPressedJump = false;		
		}
		else
		{
			bDelayJump = false;
			bReleasedJump = false;
		}
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);		
		}
		else
		{
			ProcessMove(DeltaTime, newAccel, Actor.EDoubleClickDir.DCLICK_None/*0*/, OldRotation - Rotation);
		}
		bReleasedJump = false;
		bPressedJump = bDelayJump;
	}
	
	protected /*function */void TdPlayerController_PlayerDying_BeginState(name PreviousStateName)// state function
	{
		OnTdDisableReactionTime(default);
		/*Transformed 'base.' to specific call*/Object_BeginState(PreviousStateName);
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) PlayerDying()/*state PlayerDying*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ ProcessMove = (_1,_2,_3,_a)=>{};
	
			PlayerMove = TdPlayerController_PlayerDying_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerController_PlayerDying_BeginState, StateFlow, null);
	}
	
	
	protected /*exec function */void TdPlayerController_Dead_NextViewTarget()// state function
	{
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			ServerViewNextPlayer();
		}
	}
	
	protected /*exec function */void TdPlayerController_Dead_PrevViewTarget()// state function
	{
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			ServerViewPrevPlayer();
		}
	}
	
	protected /*exec function */void TdPlayerController_Dead_NextStaticViewTarget()// state function
	{
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			ServerViewNextSpectatorPoint();
		}
	}
	
	protected /*exec function */void TdPlayerController_Dead_PrevStaticViewTarget()// state function
	{
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			ServerViewPrevSpectatorPoint();
		}
	}
	
	protected /*function */void TdPlayerController_Dead_BeginState(name PreviousStateName)// state function
	{
		/*local */TdSPGame SPGame = default;
	
		SPGame = ((WorldInfo.Game) as TdSPGame);
		if(SPGame != default)
		{
			SPGame.OnPlayerDead();
		}
		myPawn = default;
		/*Transformed 'base.' to specific call*/PlayerController_Dead_BeginState(PreviousStateName);
		if(WorldInfo.GRI.IsMultiplayerGame())
		{
			IgnoreLookInput(false);
			IgnoreMoveInput(false);
			ServerViewNextSpectatorPoint();		
		}
		else
		{
			SetViewTarget(this, default(Camera.ViewTargetTransitionParams?));
		}
		StopSounds(0.10f, "VO");
		ClientStopForceFeedbackWaveform(default(ForceFeedbackWaveform?));
	}
	
	protected /*unreliable server function */void TdPlayerController_Dead_ServerViewNextPlayer()// state function
	{
		/*local */TdPawn MyPawnViewTarget = default;
	
		/*Transformed 'base.' to specific call*/PlayerController_ServerViewNextPlayer();
		if(IsLocalPlayerController())
		{
			MyPawnViewTarget = ((ViewTarget) as TdPawn);
			if(MyPawnViewTarget != default)
			{
				SetCameraMode("ThirdPerson");
				MyPawnViewTarget.SetFirstPerson(false);
			}
		}
	}
	
	protected /*reliable client simulated event */void TdPlayerController_Dead_ClientSetViewTarget(Actor A, /*optional */Camera.ViewTargetTransitionParams? _TransitionParams = default)// state function
	{
		var TransitionParams = _TransitionParams ?? default;
		/*Transformed 'base.' to specific call*/PlayerController_ClientSetViewTarget(A, TransitionParams);
		if(ViewTarget.IsA("TdPawn"))
		{
			((ViewTarget) as TdPawn).SetFirstPerson(false);
			SetCameraMode("ThirdPerson");		
		}
		else
		{
			if(ViewTarget.IsA("TdSpectatorPoint"))
			{
				SetCameraMode("Spectating");
			}
		}
	}
	
	protected /*function */void TdPlayerController_Dead_PlayerMove(float DeltaTime)// state function
	{
		/*local */Object.Vector X = default, Y = default, Z = default;
		/*local */Object.Rotator DeltaRot = default, ViewRotation = default;
	
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
		if(ViewTarget != this)
		{
			ViewRotation.Roll = 0;
		}
		SetRotation(ViewRotation);
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			ReplicateMove(DeltaTime, vect(0.0f, 0.0f, 0.0f), Actor.EDoubleClickDir.DCLICK_None/*0*/, rot(0, 0, 0));
		}
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Dead()/*state Dead*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ StartFire = (_a)=>{}; AttemptReactionTime = ()=>{};
	
			NextViewTarget = TdPlayerController_Dead_NextViewTarget;
			PrevViewTarget = TdPlayerController_Dead_PrevViewTarget;
			NextStaticViewTarget = TdPlayerController_Dead_NextStaticViewTarget;
			PrevStaticViewTarget = TdPlayerController_Dead_PrevStaticViewTarget;
			ServerViewNextPlayer = TdPlayerController_Dead_ServerViewNextPlayer;
			ClientSetViewTarget = TdPlayerController_Dead_ClientSetViewTarget;
			PlayerMove = TdPlayerController_Dead_PlayerMove;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		;		;				
		}
	
		return (TdPlayerController_Dead_BeginState, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PlayerWaiting": return PlayerWaiting();
			case "PlayerWalking": return PlayerWalking();
			case "PlayerGrabbing": return PlayerGrabbing();
			case "PlayerBalanceWalk": return PlayerBalanceWalk();
			case "PlayerLedgeWalking": return PlayerLedgeWalking();
			case "PlayerWallWalking": return PlayerWallWalking();
			case "Spectating": return Spectating();
			case "Ropeburn": return Ropeburn();
			case "PlayerDying": return PlayerDying();
			case "Dead": return Dead();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return PlayerWaiting();
	}
	public TdPlayerController()
	{
		var Default__TdPlayerController_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdPlayerController.CollisionCylinder' */;
		var Default__TdPlayerController_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdPlayerController.Sprite' */;
		// Object Offset:0x006251F4
		bLeftThumbStickPassedDeadZone = true;
		bRightThumbStickPassedDeadZone = true;
		JumpTapTime = 0.150f;
		BagSearchTapTime = 0.30f;
		AllowedEmoteMessageInterval = 3.0f;
		TargetingCutoffAngle = 3900.0f;
		LookAtTimeDelay = 0.60f;
		CloseCombatMinRange = 170.0f;
		CloseCombatMaxRange = 360.0f;
		CloseCombatRangeTime = 0.70f;
		CloseCombatMaxAngle = 0.70f;
		InputMaxSprintRaduisLimit = 0.70f;
		InputMaxSprintHeightLimit = 0.70f;
		InputMaxWalkRadiusLimit = 0.690f;
		WallRunningAlignTime = 0.20f;
		ReactionTimeSpawnLevel = 99.90f;
		ReactionTimeDrain = 8.0f;
		ReactionTimeMaxEffect = 0.250f;
		ReactionTimeFadeIn = 90.0f;
		ReactionTimeFadeOut = 20.0f;
		ReactionTimeBuildRates = new TdPlayerController.ReactionTimeSettings
		{
			Easy = 0.0070f,
			Medium = 0.0050f,
			Hard = 0.0030f,
		};
		WallClimbingDodgeJumpThreshold = 0.80f;
		WallRunningDodgeJumpThreshold = 0.80f;
		WalkCyclePart1 = 0.20f;
		WalkCyclePart2 = 0.70f;
		StopAnimBlendIn = 0.10f;
		StopAnimBlendOut = 0.150f;
		Team = 1;
		StickySpeed = 100.0f;
		TutorialDataClass = ClassT<UIDataStore_TdTutorialData>()/*Ref Class'UIDataStore_TdTutorialData'*/;
		TimeTrialDataClass = ClassT<UIDataStore_TdTimeTrialData>()/*Ref Class'UIDataStore_TdTimeTrialData'*/;
		StringAliasBindingsMapClass = ClassT<UIDataStore_TdStringAliasBindingsMap>()/*Ref Class'UIDataStore_TdStringAliasBindingsMap'*/;
		SixAxisDisarmZ = -0.10f;
		SixAxisDisarmY = 0.450f;
		SixAxisRollZ = 0.350f;
		SixAxisRollY = 0.050f;
		DisarmTimeMultiplier = 1.0f;
		CameraClass = ClassT<TdPlayerCamera>()/*Ref Class'TdPlayerCamera'*/;
		SavedMoveClass = ClassT<TdSavedMove>()/*Ref Class'TdSavedMove'*/;
		CheatClass = ClassT<TdCheatManager>()/*Ref Class'TdCheatManager'*/;
		InputClass = ClassT<TdPlayerInputConsole>()/*Ref Class'TdPlayerInputConsole'*/;
		CylinderComponent = Default__TdPlayerController_CollisionCylinder/*Ref CylinderComponent'Default__TdPlayerController.CollisionCylinder'*/;
		bNotifyFallingHitWall = true;
		MinHitWall = 1.0f;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPlayerController_Sprite/*Ref SpriteComponent'Default__TdPlayerController.Sprite'*/,
			Default__TdPlayerController_CollisionCylinder/*Ref CylinderComponent'Default__TdPlayerController.CollisionCylinder'*/,
		};
		CollisionComponent = Default__TdPlayerController_CollisionCylinder/*Ref CylinderComponent'Default__TdPlayerController.CollisionCylinder'*/;
	}
}
}