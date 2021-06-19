namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class WorldInfo : ZoneInfo/*
		native
		nativereplication
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision,Actor,Advanced,Display,Events,Object,Attachment)*/{
	public enum ENetMode 
	{
		NM_Standalone,
		NM_DedicatedServer,
		NM_ListenServer,
		NM_Client,
		NM_MAX
	};
	
	public enum EConsoleType 
	{
		CONSOLE_Any,
		CONSOLE_Xbox360,
		CONSOLE_PS3,
		CONSOLE_MAX
	};
	
	public partial struct /*native */NetViewer
	{
		public PlayerController InViewer;
		public Actor Viewer;
		public Object.Vector ViewLocation;
		public Object.Vector ViewDir;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C6EB5
	//		InViewer = default;
	//		Viewer = default;
	//		ViewLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		ViewDir = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native */CompartmentRunList
	{
		public/*()*/ /*editconst */bool RigidBody;
		public/*()*/ /*editconst */bool Fluid;
		public/*()*/ /*editconst */bool Cloth;
		public/*()*/ /*editconst */bool SoftBody;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C702D
	//		RigidBody = true;
	//		Fluid = true;
	//		Cloth = true;
	//		SoftBody = true;
	//	}
	};
	
	public partial struct /*native */PhysXTiming
	{
		public/*()*/ bool bFixedTimeStep;
		public/*()*/ float TimeStep;
		public/*()*/ int MaxSubSteps;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C7159
	//		bFixedTimeStep = false;
	//		TimeStep = 0.020f;
	//		MaxSubSteps = 5;
	//	}
	};
	
	public partial struct /*native */PhysXSceneTimings
	{
		public/*()*/ /*editinline */WorldInfo.PhysXTiming PrimarySceneTiming;
		public/*()*/ /*editinline */WorldInfo.PhysXTiming CompartmentTimingRigidBody;
		public/*()*/ /*editinline */WorldInfo.PhysXTiming CompartmentTimingFluid;
		public/*()*/ /*editinline */WorldInfo.PhysXTiming CompartmentTimingCloth;
		public/*()*/ /*editinline */WorldInfo.PhysXTiming CompartmentTimingSoftBody;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C72D5
	//		PrimarySceneTiming = new WorldInfo.PhysXTiming
	//		{
	//			bFixedTimeStep = false,
	//			TimeStep = 0.020f,
	//			MaxSubSteps = 5,
	//		};
	//		CompartmentTimingRigidBody = new WorldInfo.PhysXTiming
	//		{
	//			bFixedTimeStep = false,
	//			TimeStep = 0.020f,
	//			MaxSubSteps = 2,
	//		};
	//		CompartmentTimingFluid = new WorldInfo.PhysXTiming
	//		{
	//			bFixedTimeStep = false,
	//			TimeStep = 0.020f,
	//			MaxSubSteps = 1,
	//		};
	//		CompartmentTimingCloth = new WorldInfo.PhysXTiming
	//		{
	//			bFixedTimeStep = true,
	//			TimeStep = 0.020f,
	//			MaxSubSteps = 2,
	//		};
	//		CompartmentTimingSoftBody = new WorldInfo.PhysXTiming
	//		{
	//			bFixedTimeStep = true,
	//			TimeStep = 0.020f,
	//			MaxSubSteps = 2,
	//		};
	//	}
	};
	
	public partial struct /*native */PhysXEmitterVerticalProperties
	{
		public/*()*/ bool bDisableLod;
		public/*()*/ int ParticlesLodMin;
		public/*()*/ int ParticlesLodMax;
		public/*()*/ int PacketsPerPhysXParticleSystemMax;
		public/*()*/ bool bApplyCylindricalPacketCulling;
		public/*()*/ float SpawnLodVsFifoBias;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C7681
	//		bDisableLod = true;
	//		ParticlesLodMin = 0;
	//		ParticlesLodMax = 15000;
	//		PacketsPerPhysXParticleSystemMax = 500;
	//		bApplyCylindricalPacketCulling = true;
	//		SpawnLodVsFifoBias = 1.0f;
	//	}
	};
	
	public partial struct /*native */PhysXVerticalProperties
	{
		public/*()*/ /*editinline */WorldInfo.PhysXEmitterVerticalProperties Emitters;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C7791
	//		Emitters = new WorldInfo.PhysXEmitterVerticalProperties
	//		{
	//			bDisableLod = true,
	//			ParticlesLodMin = 0,
	//			ParticlesLodMax = 15000,
	//			PacketsPerPhysXParticleSystemMax = 500,
	//			bApplyCylindricalPacketCulling = true,
	//			SpawnLodVsFifoBias = 1.0f,
	//		};
	//	}
	};
	
	public/*(Baker)*/ bool UsePhotonMap;
	public/*(Baker)*/ bool UseIBL;
	public /*transient */bool bReloadScriptLevels;
	public /*transient */bool bReloadScriptLevelsDone;
	public bool bRemoveRebuildLighting;
	public bool bEnableUIPostProcessing;
	public bool bMapNeedsLightingFullyRebuilt;
	public bool bMapHasPathingErrors;
	public bool bRequestedBlockOnAsyncLoading;
	public bool bBegunPlay;
	public bool bPlayersOnly;
	public /*transient */bool bDropDetail;
	public /*transient */bool bAggressiveLOD;
	public bool bStartup;
	public bool bPathsRebuilt;
	public bool bHasPathNodes;
	public /*transient */bool bUseConsoleInput;
	public/*()*/ bool bNoDefaultInventoryForPlayer;
	public/*()*/ bool bNoPathWarnings;
	public bool bHighPriorityLoading;
	public bool bHighPriorityLoadingLocal;
	public/*(Physics)*/ /*editconst */bool bPrimarySceneHW;
	public/*(Physics)*/ bool bSupportDoubleBufferedPhysics;
	public/*(Baker)*/ Object.Vector SkyColor;
	public/*(Baker)*/ String IBLFileName;
	public/*(Baker)*/ float IBLIntensity;
	public/*(Baker)*/ Object.Vector2D CameraResolution;
	public/*()*/ /*private config */PostProcessVolume.PostProcessSettings DefaultPostProcessSettings;
	public/*()*/ /*private */PostProcessVolume.TdPostProcessModifier DefaultPostProcessSettingsModifierXbox360;
	public/*()*/ /*private */PostProcessVolume.TdPostProcessModifier DefaultPostProcessSettingsModifierPS3;
	public/*()*/ /*private */PostProcessVolume.TdPostProcessModifier DefaultPostProcessSettingsModifierPC;
	public/*()*/ /*config */float SquintModeKernelSize;
	public /*noimport const transient */PostProcessVolume HighestPriorityPostProcessVolume;
	public/*()*/ /*config */ReverbVolume.ReverbSettings DefaultReverbSettings;
	public /*noimport const transient */ReverbVolume HighestPriorityReverbVolume;
	public /*noimport const transient */array<PortalVolume> PortalVolumes;
	public/*()*/ /*const editconst editinline */array</*editconst editinline */LevelStreaming> StreamingLevels;
	public/*(Editor)*/ StaticArray<BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark>/*[10]*/ BookMarks;
	public/*(Editor)*/ /*editinline */array</*editinline */ClipPadEntry> ClipPadEntries;
	public float TimeDilation;
	public float DemoPlayTimeDilation;
	public float TimeSeconds;
	public float RealTimeSeconds;
	public float AudioTimeSeconds;
	public /*const transient */float DeltaSeconds;
	public float TdTimeDilation;
	public /*const transient */float SavedDeltaSeconds;
	public float PauseDelay;
	public float RealTimeToUnPause;
	public PlayerReplicationInfo Pauser;
	public String VisibleGroups;
	public /*transient */String SelectedGroups;
	public Texture2D DefaultTexture;
	public Texture2D WireframeTexture;
	public Texture2D WhiteSquareTexture;
	public Texture2D LargeVertex;
	public Texture2D BSPVertex;
	public/*()*/ TextureCube CubeMapOverride;
	public/*()*/ float PointLightRadiusGlobalModifyer;
	public array<String> DeferredExecs;
	public /*transient */GameReplicationInfo GRI;
	public WorldInfo.ENetMode NetMode;
	public String ComputerName;
	public String EngineVersion;
	public String MinNetVersion;
	public GameInfo Game;
	public/*()*/ float StallZ;
	public /*transient */float WorldGravityZ;
	public /*const globalconfig */float DefaultGravityZ;
	public/*()*/ float GlobalGravityZ;
	public /*globalconfig */float RBPhysicsGravityScaling;
	public /*private const transient */NavigationPoint NavigationPointList;
	public /*private const */Controller ControllerList;
	public /*const */Pawn PawnList;
	public /*const transient */CoverLink CoverList;
	public float MoveRepSize;
	public /*const */array<WorldInfo.NetViewer> ReplicationViewers;
	public String NextURL;
	public float NextSwitchCountdown;
	public/*()*/ int PackedLightAndShadowMapTextureSize;
	public/*()*/ Object.Vector DefaultColorScale;
	public/*()*/ array< Core.ClassT<GameInfo> > GameTypesSupportedOnThisMap;
	public /*const transient */array<name> PreparingLevelNames;
	public /*const transient */array<name> CommittedLevelNames;
	public SeqAct_CrossFadeMusicTracks LastMusicAction;
	public MusicTrackDataStructures.MusicTrackStruct LastMusicTrack;
	public/*()*/ /*const localized */String Title;
	public/*()*/ String Author;
	public/*()*/ /*protected export editinline */MapInfo MyMapInfo;
	public /*globalconfig */String EmitterPoolClassPath;
	public EmitterPool MyEmitterPool;
	public /*globalconfig */String DecalManagerClassPath;
	public DecalManager MyDecalManager;
	public/*(Physics)*/ float MaxPhysicsDeltaTime;
	public/*(Physics)*/ /*editinline */WorldInfo.PhysXSceneTimings PhysicsTimings;
	public/*(Physics)*/ /*editconst */array</*editconst */WorldInfo.CompartmentRunList> CompartmentRunFrames;
	public PhysicsLODVerticalEmitter EmitterVertical;
	public/*(Physics)*/ /*editinline */WorldInfo.PhysXVerticalProperties VerticalProperties;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Pauser, TimeDilation, 
	//		WorldGravityZ, bHighPriorityLoading;
	//}
	
	// Export UWorldInfo::execGetModifiedPostProcessSettings(FFrame&, void* const)
	public virtual /*native function */PostProcessVolume.PostProcessSettings GetModifiedPostProcessSettings()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */void SetSceneExposureReset(bool B)
	{
	
	}
	
	public virtual /*final function */bool IsServer()
	{
	
		return default;
	}
	
	// Export UWorldInfo::execGetGravityZ(FFrame&, void* const)
	public override /*native function */float GetGravityZ()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execGetGameSequence(FFrame&, void* const)
	public virtual /*native final function */Sequence GetGameSequence()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execSetLevelRBGravity(FFrame&, void* const)
	public virtual /*native final function */void SetLevelRBGravity(Object.Vector NewGrav)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execGetLocalURL(FFrame&, void* const)
	public virtual /*native simulated function */String GetLocalURL()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execIsDemoBuild(FFrame&, void* const)
	public /*native final simulated function */static bool IsDemoBuild()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execIsConsoleBuild(FFrame&, void* const)
	public /*native final simulated function */static bool IsConsoleBuild(/*optional */WorldInfo.EConsoleType? _ConsoleType = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execIsPlayInEditor(FFrame&, void* const)
	public /*native final simulated function */static bool IsPlayInEditor()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execForceGarbageCollection(FFrame&, void* const)
	public virtual /*native final simulated function */void ForceGarbageCollection(/*optional */bool? _bFullPurge = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execVerifyNavList(FFrame&, void* const)
	public virtual /*native final simulated function */void VerifyNavList()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execGetAddressURL(FFrame&, void* const)
	public virtual /*native simulated function */String GetAddressURL()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */Core.ClassT<GameInfo> GetGameClass()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool IsLOIEnabled()
	{
	
		return default;
	}
	
	public virtual /*event */void ServerTravel(String URL, /*optional */bool? _bAbsolute = default)
	{
	
	}
	
	public virtual /*function */void ThisIsNeverExecuted(DefaultPhysicsVolume P)
	{
	
	}
	
	public override /*simulated function */void PreBeginPlay()
	{
	
	}
	
	public override /*simulated function */void PostBeginPlay()
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? WorldInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => WorldInfo_Reset;
	public /*function */void WorldInfo_Reset()
	{
	
	}
	
	// Export UWorldInfo::execAllNavigationPoints(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<NavigationPoint/* N*/> AllNavigationPoints(Core.ClassT<NavigationPoint> BaseClass)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	// Export UWorldInfo::execRadiusNavigationPoints(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<NavigationPoint/* N*/> RadiusNavigationPoints(Core.ClassT<NavigationPoint> BaseClass, Object.Vector Point, float Radius)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	// Export UWorldInfo::execNavigationPointCheck(FFrame&, void* const)
	public virtual /*native final function */void NavigationPointCheck(Object.Vector Point, Object.Vector Extent, /*optional */ref array<NavigationPoint> Navs/* = default*/, /*optional */ref array<ReachSpec> Specs/* = default*/)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execAllControllers(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Controller/* C*/> AllControllers(Core.ClassT<Controller> BaseClass)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	// Export UWorldInfo::execAllPawns(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Pawn/* P*/> AllPawns(Core.ClassT<Pawn> BaseClass, /*optional */Object.Vector? _TestLocation = default, /*optional */float? _TestRadius = default)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	// Export UWorldInfo::execNotifyMatchStarted(FFrame&, void* const)
	public virtual /*native final function */void NotifyMatchStarted(/*optional */bool? _bShouldActivateLevelStartupEvents = default, /*optional */bool? _bShouldActivateLevelBeginningEvents = default, /*optional */bool? _bShouldActivateLevelLoadedEvents = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execPrepareMapChange(FFrame&, void* const)
	public virtual /*native final function */void PrepareMapChange(/*const */ref array<name> LevelNames)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execIsPreparingMapChange(FFrame&, void* const)
	public virtual /*native final function */bool IsPreparingMapChange()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execIsMapChangeReady(FFrame&, void* const)
	public virtual /*native final function */bool IsMapChangeReady()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execCommitMapChange(FFrame&, void* const)
	public virtual /*native final function */void CommitMapChange(/*optional */bool? _bShouldSkipLevelStartupEvent = default, /*optional */bool? _bShouldSkipLevelBeginningEvent = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execSeamlessTravel(FFrame&, void* const)
	public virtual /*native final function */void SeamlessTravel(String URL, /*optional */bool? _bAbsolute = default, /*init optional */Object.Guid? _MapPackageGuid = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execIsInSeamlessTravel(FFrame&, void* const)
	public virtual /*native final function */bool IsInSeamlessTravel()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execSetSeamlessTravelMidpointPause(FFrame&, void* const)
	public virtual /*native final function */void SetSeamlessTravelMidpointPause(bool bNowPaused)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execGetMapInfo(FFrame&, void* const)
	public virtual /*native final function */MapInfo GetMapInfo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execSetMapInfo(FFrame&, void* const)
	public virtual /*native final function */void SetMapInfo(MapInfo NewMapInfo)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UWorldInfo::execGetMapName(FFrame&, void* const)
	public virtual /*native final function */String GetMapName(/*optional */bool? _bIncludePrefix = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execGetDetailMode(FFrame&, void* const)
	public virtual /*native final function */Scene.EDetailMode GetDetailMode()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execIsRecordingDemo(FFrame&, void* const)
	public virtual /*native final function */bool IsRecordingDemo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execIsPlayingDemo(FFrame&, void* const)
	public virtual /*native final function */bool IsPlayingDemo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UWorldInfo::execDoMemoryTracking(FFrame&, void* const)
	public virtual /*native function */void DoMemoryTracking()
	{
		#warning NATIVE FUNCTION !
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
	
	}
	public WorldInfo()
	{
		var Default__WorldInfo_PhysicsLODVerticalEmitter0 = new PhysicsLODVerticalEmitter
		{
		}/* Reference: PhysicsLODVerticalEmitter'Default__WorldInfo.PhysicsLODVerticalEmitter0' */;
		// Object Offset:0x004622A5
		IBLIntensity = 1.0f;
		CameraResolution = new Vector2D
		{
			X=320.0f,
			Y=240.0f
		};
		DefaultPostProcessSettings = new PostProcessVolume.PostProcessSettings
		{
			bEnableBloom = true,
			bEnableDOF = false,
			bEnableMotionBlur = false,
			bEnableSceneEffect = true,
			Bloom_Scale = 1.0f,
			Bloom_InterpolationDuration = 1.0f,
			DOF_FalloffExponent = 4.0f,
			DOF_BlurKernelSize = 16.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_ModulateBlurColor = new Color
			{
				R=255,
				G=255,
				B=255,
				A=255
			},
			DOF_FocusType = DOFEffect.EFocusType.FOCUS_Distance,
			DOF_FocusInnerRadius = 2000.0f,
			DOF_FocusDistance = 1600.0f,
			DOF_FocusPosition = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			DOF_InterpolationDuration = 1.0f,
			DOF_Autofocus = true,
			DOF_AutofocusMaxDistance = 150.0f,
			DOF_AutofocusSpeed = 1.0f,
			MotionBlur_MaxVelocity = 1.0f,
			MotionBlur_Amount = 0.50f,
			MotionBlur_FullMotionBlur = true,
			MotionBlur_CameraRotationThreshold = 45.0f,
			MotionBlur_CameraTranslationThreshold = 10000.0f,
			MotionBlur_InterpolationDuration = 1.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			Scene_MidTones = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=1.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_InterpolationDuration = 1.0f,
			HazeColor = new Vector
			{
				X=1.0f,
				Y=1.0f,
				Z=0.80f
			},
			HazeAngleCurve = 5.0f,
			HazeAngleStart = 0.50f,
			HazeDistanceCurve = 1.50f,
			HazeDistanceDivider = 7500.0f,
			HazeAngleClampHigh = 2.0f,
			HazeTotalClampCloseHigh = 10.0f,
			HazeTotalClampFarHigh = 10.0f,
			HazeTotalClampFarDistance = 1.0f,
			HazeMultiplier = 1.0f,
			HazeTotalClampLow = 0.0f,
			HazeEnabled = false,
			HazeSunLocation = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_ExposureManual = 1.0f,
			Scene_ExposureSpeedUp = 3.50f,
			Scene_ExposureSpeedDown = 4.50f,
			Scene_ExposureHigh = 1.650f,
			Scene_ExposureLow = 0.850f,
			Scene_ExposureReset = true,
			TdMotionBlurAmount = 0.50f,
			TdMotionBlurStartPlayerSpeed = 400.0f,
			TdMotionBlurEnabled = true,
			TdMotionBlurUseDistance = false,
			TdMotionBlurUseDirection = true,
			TdMotionBlurForce = false,
			TdMotionBlurForcedDirection = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			TdMotionBlurForcedAmount = 0.0f,
			TdMotionBlurMask = default,
			SaturationMask = default,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		DefaultPostProcessSettingsModifierXbox360 = new PostProcessVolume.TdPostProcessModifier
		{
			Bloom_Scale = 0.0f,
			DOF_FalloffExponent = 0.0f,
			DOF_BlurKernelSize = 0.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_FocusInnerRadius = 0.0f,
			DOF_FocusDistance = 0.0f,
			DOF_AutofocusMaxDistance = 0.0f,
			DOF_AutofocusSpeed = 0.0f,
			MotionBlur_MaxVelocity = 0.0f,
			MotionBlur_Amount = 0.0f,
			MotionBlur_CameraRotationThreshold = 0.0f,
			MotionBlur_CameraTranslationThreshold = 0.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_MidTones = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeColor = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeAngleCurve = 0.0f,
			HazeAngleStart = 0.0f,
			HazeDistanceCurve = 0.0f,
			HazeDistanceDivider = 0.0f,
			HazeAngleClampHigh = 0.0f,
			HazeTotalClampCloseHigh = 0.0f,
			HazeTotalClampFarHigh = 0.0f,
			HazeTotalClampFarDistance = 0.0f,
			HazeMultiplier = 0.0f,
			HazeTotalClampLow = 0.0f,
			Scene_ExposureManual = 0.0f,
			Scene_ExposureSpeedUp = 0.0f,
			Scene_ExposureSpeedDown = 0.0f,
			Scene_ExposureHigh = 0.0f,
			Scene_ExposureLow = 0.0f,
			TdMotionBlurAmount = 0.0f,
			TdMotionBlurStartPlayerSpeed = 0.0f,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[1] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[2] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[3] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[4] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[5] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[6] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[7] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[8] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[9] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[10] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[11] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[12] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[13] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[14] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[15] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		DefaultPostProcessSettingsModifierPS3 = new PostProcessVolume.TdPostProcessModifier
		{
			Bloom_Scale = 0.0f,
			DOF_FalloffExponent = 0.0f,
			DOF_BlurKernelSize = 0.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_FocusInnerRadius = 0.0f,
			DOF_FocusDistance = 0.0f,
			DOF_AutofocusMaxDistance = 0.0f,
			DOF_AutofocusSpeed = 0.0f,
			MotionBlur_MaxVelocity = 0.0f,
			MotionBlur_Amount = 0.0f,
			MotionBlur_CameraRotationThreshold = 0.0f,
			MotionBlur_CameraTranslationThreshold = 0.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_MidTones = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeColor = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeAngleCurve = 0.0f,
			HazeAngleStart = 0.0f,
			HazeDistanceCurve = 0.0f,
			HazeDistanceDivider = 0.0f,
			HazeAngleClampHigh = 0.0f,
			HazeTotalClampCloseHigh = 0.0f,
			HazeTotalClampFarHigh = 0.0f,
			HazeTotalClampFarDistance = 0.0f,
			HazeMultiplier = 0.0f,
			HazeTotalClampLow = 0.0f,
			Scene_ExposureManual = 0.0f,
			Scene_ExposureSpeedUp = 0.0f,
			Scene_ExposureSpeedDown = 0.0f,
			Scene_ExposureHigh = 0.0f,
			Scene_ExposureLow = 0.0f,
			TdMotionBlurAmount = 0.0f,
			TdMotionBlurStartPlayerSpeed = 0.0f,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[1] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[2] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[3] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[4] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[5] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[6] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[7] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[8] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[9] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[10] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[11] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[12] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[13] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[14] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[15] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		DefaultPostProcessSettingsModifierPC = new PostProcessVolume.TdPostProcessModifier
		{
			Bloom_Scale = 0.0f,
			DOF_FalloffExponent = 0.0f,
			DOF_BlurKernelSize = 0.0f,
			DOF_MaxNearBlurAmount = 0.0f,
			DOF_MaxFarBlurAmount = 0.0f,
			DOF_FocusInnerRadius = 0.0f,
			DOF_FocusDistance = 0.0f,
			DOF_AutofocusMaxDistance = 0.0f,
			DOF_AutofocusSpeed = 0.0f,
			MotionBlur_MaxVelocity = 0.0f,
			MotionBlur_Amount = 0.0f,
			MotionBlur_CameraRotationThreshold = 0.0f,
			MotionBlur_CameraTranslationThreshold = 0.0f,
			Scene_Desaturation = 0.0f,
			Scene_HighLights = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_MidTones = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			Scene_Shadows = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeColor = new Vector
			{
				X=0.0f,
				Y=0.0f,
				Z=0.0f
			},
			HazeAngleCurve = 0.0f,
			HazeAngleStart = 0.0f,
			HazeDistanceCurve = 0.0f,
			HazeDistanceDivider = 0.0f,
			HazeAngleClampHigh = 0.0f,
			HazeTotalClampCloseHigh = 0.0f,
			HazeTotalClampFarHigh = 0.0f,
			HazeTotalClampFarDistance = 0.0f,
			HazeMultiplier = 0.0f,
			HazeTotalClampLow = 0.0f,
			Scene_ExposureManual = 0.0f,
			Scene_ExposureSpeedUp = 0.0f,
			Scene_ExposureSpeedDown = 0.0f,
			Scene_ExposureHigh = 0.0f,
			Scene_ExposureLow = 0.0f,
			TdMotionBlurAmount = 0.0f,
			TdMotionBlurStartPlayerSpeed = 0.0f,
			Curves = new PostProcessVolume.CurveInfo
			{
				Ms = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[1] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[2] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[3] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[4] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[5] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[6] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[7] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[8] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[9] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[10] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[11] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[12] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[13] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[14] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
					[15] = new Vector
				{
					X=1.0f,
					Y=1.0f,
					Z=1.0f
				},
				},
				Bs = new StaticArray<Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector, Object.Vector>/*[16]*/()
				{
					[0] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[1] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[2] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[3] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[4] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[5] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[6] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[7] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[8] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[9] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[10] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[11] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[12] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[13] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[14] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
					[15] = new Vector
				{
					X=0.0f,
					Y=0.0f,
					Z=0.0f
				},
				},
				ControlPointsR = default,
				ControlPointsG = default,
				ControlPointsB = default,
				ControlPointsA = default,
			},
		};
		SquintModeKernelSize = 128.0f;
		DefaultReverbSettings = new ReverbVolume.ReverbSettings
		{
			ReverbType = ReverbVolume.ReverbPreset.REVERB_Default,
			Volume = 0.50f,
			FadeTime = 2.0f,
		};
		TimeDilation = 1.0f;
		DemoPlayTimeDilation = 1.0f;
		TdTimeDilation = 1.0f;
		VisibleGroups = "None";
		DefaultTexture = LoadAsset<Texture2D>("EngineResources.DefaultTexture")/*Ref Texture2D'EngineResources.DefaultTexture'*/;
		WhiteSquareTexture = LoadAsset<Texture2D>("EngineResources.WhiteSquareTexture")/*Ref Texture2D'EngineResources.WhiteSquareTexture'*/;
		LargeVertex = LoadAsset<Texture2D>("EngineResources.LargeVertex")/*Ref Texture2D'EngineResources.LargeVertex'*/;
		BSPVertex = LoadAsset<Texture2D>("EngineResources.BSPVertex")/*Ref Texture2D'EngineResources.BSPVertex'*/;
		PointLightRadiusGlobalModifyer = 1.0f;
		StallZ = 1000000.0f;
		DefaultGravityZ = -800.0f;
		RBPhysicsGravityScaling = 1.0f;
		MoveRepSize = 42.0f;
		PackedLightAndShadowMapTextureSize = 1024;
		DefaultColorScale = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		LastMusicTrack = new MusicTrackDataStructures.MusicTrackStruct
		{
			Params = new MusicTrackDataStructures.MusicTrackParamStruct
			{
				FadeInTime = 5.0f,
				FadeInVolumeLevel = 1.0f,
				DelayBetweenOldAndNewTrack = 0.0f,
				FadeOutTime = 5.0f,
				FadeOutVolumeLevel = 0.0f,
			},
			TrackType = (name)"None",
			TheSoundCue = default,
			bAutoPlay = false,
		};
		EmitterPoolClassPath = "TdGame.TdEmitterPool";
		DecalManagerClassPath = "Engine.DecalManager";
		MaxPhysicsDeltaTime = 0.33333330f;
		PhysicsTimings = new WorldInfo.PhysXSceneTimings
		{
			PrimarySceneTiming = new WorldInfo.PhysXTiming
			{
				bFixedTimeStep = false,
				TimeStep = 0.020f,
				MaxSubSteps = 5,
			},
			CompartmentTimingRigidBody = new WorldInfo.PhysXTiming
			{
				bFixedTimeStep = false,
				TimeStep = 0.020f,
				MaxSubSteps = 2,
			},
			CompartmentTimingFluid = new WorldInfo.PhysXTiming
			{
				bFixedTimeStep = false,
				TimeStep = 0.020f,
				MaxSubSteps = 1,
			},
			CompartmentTimingCloth = new WorldInfo.PhysXTiming
			{
				bFixedTimeStep = true,
				TimeStep = 0.020f,
				MaxSubSteps = 2,
			},
			CompartmentTimingSoftBody = new WorldInfo.PhysXTiming
			{
				bFixedTimeStep = true,
				TimeStep = 0.020f,
				MaxSubSteps = 2,
			},
		};
		EmitterVertical = Default__WorldInfo_PhysicsLODVerticalEmitter0/*Ref PhysicsLODVerticalEmitter'Default__WorldInfo.PhysicsLODVerticalEmitter0'*/;
		VerticalProperties = new WorldInfo.PhysXVerticalProperties
		{
			Emitters = new WorldInfo.PhysXEmitterVerticalProperties
			{
				bDisableLod = true,
				ParticlesLodMin = 0,
				ParticlesLodMax = 15000,
				PacketsPerPhysXParticleSystemMax = 500,
				bApplyCylindricalPacketCulling = true,
				SpawnLodVsFifoBias = 1.0f,
			},
		};
		bWorldGeometry = true;
		bAlwaysRelevant = true;
		bBlockActors = true;
		bHiddenEd = true;
		Components = default;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
	}
}
}