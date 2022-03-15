// NO OVERWRITE

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
		[Category] [editconst] public bool RigidBody;
		[Category] [editconst] public bool Fluid;
		[Category] [editconst] public bool Cloth;
		[Category] [editconst] public bool SoftBody;
	
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
		[Category] public bool bFixedTimeStep;
		[Category] public float TimeStep;
		[Category] public int MaxSubSteps;
	
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
		[Category] [editinline] public WorldInfo.PhysXTiming PrimarySceneTiming;
		[Category] [editinline] public WorldInfo.PhysXTiming CompartmentTimingRigidBody;
		[Category] [editinline] public WorldInfo.PhysXTiming CompartmentTimingFluid;
		[Category] [editinline] public WorldInfo.PhysXTiming CompartmentTimingCloth;
		[Category] [editinline] public WorldInfo.PhysXTiming CompartmentTimingSoftBody;
	
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
		[Category] public bool bDisableLod;
		[Category] public int ParticlesLodMin;
		[Category] public int ParticlesLodMax;
		[Category] public int PacketsPerPhysXParticleSystemMax;
		[Category] public bool bApplyCylindricalPacketCulling;
		[Category] public float SpawnLodVsFifoBias;
	
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
		[Category] [editinline] public WorldInfo.PhysXEmitterVerticalProperties Emitters;
	
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
	
	[Category("Baker")] public bool UsePhotonMap;
	[Category("Baker")] public bool UseIBL;
	[transient] public bool bReloadScriptLevels;
	[transient] public bool bReloadScriptLevelsDone;
	public bool bRemoveRebuildLighting;
	public bool bEnableUIPostProcessing;
	public bool bMapNeedsLightingFullyRebuilt;
	public bool bMapHasPathingErrors;
	public bool bRequestedBlockOnAsyncLoading;
	public bool bBegunPlay;
	public bool bPlayersOnly;
	[transient] public bool bDropDetail;
	[transient] public bool bAggressiveLOD;
	public bool bStartup;
	public bool bPathsRebuilt;
	public bool bHasPathNodes;
	[transient] public bool bUseConsoleInput;
	[Category] public bool bNoDefaultInventoryForPlayer;
	[Category] public bool bNoPathWarnings;
	public bool bHighPriorityLoading;
	public bool bHighPriorityLoadingLocal;
	[Category("Physics")] [editconst] public bool bPrimarySceneHW;
	[Category("Physics")] public bool bSupportDoubleBufferedPhysics;
	[Category("Baker")] public Object.Vector SkyColor;
	[Category("Baker")] public String IBLFileName;
	[Category("Baker")] public float IBLIntensity;
	[Category("Baker")] public Object.Vector2D CameraResolution;
	[Category] [config] public/*private*/ PostProcessVolume.PostProcessSettings DefaultPostProcessSettings;
	[Category] public/*private*/ PostProcessVolume.TdPostProcessModifier DefaultPostProcessSettingsModifierXbox360;
	[Category] public/*private*/ PostProcessVolume.TdPostProcessModifier DefaultPostProcessSettingsModifierPS3;
	[Category] public/*private*/ PostProcessVolume.TdPostProcessModifier DefaultPostProcessSettingsModifierPC;
	[Category] [config] public float SquintModeKernelSize;
	[noimport, Const, transient] public PostProcessVolume HighestPriorityPostProcessVolume;
	[Category] [config] public ReverbVolume.ReverbSettings DefaultReverbSettings;
	[noimport, Const, transient] public ReverbVolume HighestPriorityReverbVolume;
	[noimport, Const, transient] public array<PortalVolume> PortalVolumes;
	[Category] [Const, editconst, editinline] public array</*editconst editinline */LevelStreaming> StreamingLevels;
	[Category("Editor")] public StaticArray<BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark, BookMark>/*[10]*/ BookMarks;
	[Category("Editor")] [editinline] public array</*editinline */ClipPadEntry> ClipPadEntries;
	public float TimeDilation;
	public float DemoPlayTimeDilation;
	public float TimeSeconds;
	public float RealTimeSeconds;
	public float AudioTimeSeconds;
	[Const, transient] public float DeltaSeconds;
	public float TdTimeDilation;
	[Const, transient] public float SavedDeltaSeconds;
	public float PauseDelay;
	public float RealTimeToUnPause;
	public PlayerReplicationInfo Pauser;
	public String VisibleGroups;
	[transient] public String SelectedGroups;
	public Texture2D DefaultTexture;
	public Texture2D WireframeTexture;
	public Texture2D WhiteSquareTexture;
	public Texture2D LargeVertex;
	public Texture2D BSPVertex;
	[Category] public TextureCube CubeMapOverride;
	[Category] public float PointLightRadiusGlobalModifyer;
	public array<String> DeferredExecs;
	[transient] public GameReplicationInfo GRI;
	public WorldInfo.ENetMode NetMode;
	public String ComputerName;
	public String EngineVersion;
	public String MinNetVersion;
	public GameInfo Game;
	[Category] public float StallZ;
	[transient] public float WorldGravityZ;
	[Const, globalconfig] public float DefaultGravityZ;
	[Category] public float GlobalGravityZ;
	[globalconfig] public float RBPhysicsGravityScaling;
	[Const, transient] public/*private*/ NavigationPoint NavigationPointList;
	[Const] public/*private*/ Controller ControllerList;
	[Const] public Pawn PawnList;
	[Const, transient] public CoverLink CoverList;
	public float MoveRepSize;
	[Const] public array<WorldInfo.NetViewer> ReplicationViewers;
	public String NextURL;
	public float NextSwitchCountdown;
	[Category] public int PackedLightAndShadowMapTextureSize;
	[Category] public Object.Vector DefaultColorScale;
	[Category] public array< Core.ClassT<GameInfo> > GameTypesSupportedOnThisMap;
	[Const, transient] public array<name> PreparingLevelNames;
	[Const, transient] public array<name> CommittedLevelNames;
	public SeqAct_CrossFadeMusicTracks LastMusicAction;
	public MusicTrackDataStructures.MusicTrackStruct LastMusicTrack;
	[Category] [Const, localized] public String Title;
	[Category] public String Author;
	[Category] [export, editinline] public/*protected*/ MapInfo MyMapInfo;
	[globalconfig] public String EmitterPoolClassPath;
	public EmitterPool MyEmitterPool;
	[globalconfig] public String DecalManagerClassPath;
	public DecalManager MyDecalManager;
	[Category("Physics")] public float MaxPhysicsDeltaTime;
	[Category("Physics")] [editinline] public WorldInfo.PhysXSceneTimings PhysicsTimings;
	[Category("Physics")] [editconst] public array</*editconst */WorldInfo.CompartmentRunList> CompartmentRunFrames;
	public PhysicsLODVerticalEmitter EmitterVertical;
	[Category("Physics")] [editinline] public WorldInfo.PhysXVerticalProperties VerticalProperties;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		Pauser, TimeDilation, 
	//		WorldGravityZ, bHighPriorityLoading;
	//}
	
	// Export UWorldInfo::execGetModifiedPostProcessSettings(FFrame&, void* const)
	public virtual /*native function */PostProcessVolume.PostProcessSettings GetModifiedPostProcessSettings()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final function */void SetSceneExposureReset(bool B)
	{
		// stub
	}
	
	public virtual /*final function */bool IsServer()
	{
		// stub
		return default;
	}
	
	// Export UWorldInfo::execGetGravityZ(FFrame&, void* const)
	//public override /*native function */float GetGravityZ()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	// stub
	//	return default;
	//}
	
	// Export UWorldInfo::execGetGameSequence(FFrame&, void* const)
	public virtual /*native final function */Sequence GetGameSequence()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return new();
	}
	
	// Export UWorldInfo::execSetLevelRBGravity(FFrame&, void* const)
	public virtual /*native final function */void SetLevelRBGravity(Object.Vector NewGrav)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execGetLocalURL(FFrame&, void* const)
	public virtual /*native simulated function */String GetLocalURL()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execIsDemoBuild(FFrame&, void* const)
	public /*native final simulated function */static bool IsDemoBuild()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execIsConsoleBuild(FFrame&, void* const)
	public /*native final simulated function */static bool IsConsoleBuild(/*optional */WorldInfo.EConsoleType? _ConsoleType = default)
	{
		NativeMarkers.MarkUnimplemented("Returns false by default");
		// stub
		return false;
	}
	
	// Export UWorldInfo::execIsPlayInEditor(FFrame&, void* const)
	public /*native final simulated function */static bool IsPlayInEditor()
	{
		NativeMarkers.MarkUnimplemented("Returns false by default");
		// stub
		return false;
	}
	
	// Export UWorldInfo::execForceGarbageCollection(FFrame&, void* const)
	public virtual /*native final simulated function */void ForceGarbageCollection(/*optional */bool? _bFullPurge = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execVerifyNavList(FFrame&, void* const)
	public virtual /*native final simulated function */void VerifyNavList()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execGetAddressURL(FFrame&, void* const)
	public virtual /*native simulated function */String GetAddressURL()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*simulated function */Core.ClassT<GameInfo> GetGameClass()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated function */bool IsLOIEnabled()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void ServerTravel(String URL, /*optional */bool? _bAbsolute = default)
	{
		// stub
	}
	
	public virtual /*function */void ThisIsNeverExecuted(DefaultPhysicsVolume P)
	{
		// stub
	}
	
	public override /*simulated function */void PreBeginPlay()
	{
		// stub
	}
	
	public override /*simulated function */void eventPostBeginPlay()
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? WorldInfo_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => WorldInfo_Reset;
	public /*function */void WorldInfo_Reset()
	{
		// stub
	}
	
	// Export UWorldInfo::execAllNavigationPoints(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<NavigationPoint/* N*/> AllNavigationPoints(Core.ClassT<NavigationPoint> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	// stub
	//	yield break;
	//}
	
	// Export UWorldInfo::execRadiusNavigationPoints(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<NavigationPoint/* N*/> RadiusNavigationPoints(Core.ClassT<NavigationPoint> BaseClass, Object.Vector Point, float Radius)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		yield break;
	}
	
	// Export UWorldInfo::execNavigationPointCheck(FFrame&, void* const)
	public virtual /*native final function */void NavigationPointCheck(Object.Vector Point, Object.Vector Extent, /*optional */ref array<NavigationPoint> Navs/* = default*/, /*optional */ref array<ReachSpec> Specs/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execAllControllers(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Controller/* C*/> AllControllers(Core.ClassT<Controller> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	// stub
	//	yield break;
	//}
	//
	//// Export UWorldInfo::execAllPawns(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<Pawn/* P*/> AllPawns(Core.ClassT<Pawn> BaseClass, /*optional */Object.Vector? _TestLocation = default, /*optional */float? _TestRadius = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	// stub
	//	yield break;
	//}
	
	// Export UWorldInfo::execNotifyMatchStarted(FFrame&, void* const)
	public virtual /*native final function */void NotifyMatchStarted(/*optional */bool? _bShouldActivateLevelStartupEvents = default, /*optional */bool? _bShouldActivateLevelBeginningEvents = default, /*optional */bool? _bShouldActivateLevelLoadedEvents = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execPrepareMapChange(FFrame&, void* const)
	public virtual /*native final function */void PrepareMapChange(/*const */ref array<name> LevelNames)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execIsPreparingMapChange(FFrame&, void* const)
	public virtual /*native final function */bool IsPreparingMapChange()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execIsMapChangeReady(FFrame&, void* const)
	public virtual /*native final function */bool IsMapChangeReady()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execCommitMapChange(FFrame&, void* const)
	public virtual /*native final function */void CommitMapChange(/*optional */bool? _bShouldSkipLevelStartupEvent = default, /*optional */bool? _bShouldSkipLevelBeginningEvent = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execSeamlessTravel(FFrame&, void* const)
	public virtual /*native final function */void SeamlessTravel(String URL, /*optional */bool? _bAbsolute = default, /*init optional */Object.Guid? _MapPackageGuid = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execIsInSeamlessTravel(FFrame&, void* const)
	public virtual /*native final function */bool IsInSeamlessTravel()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execSetSeamlessTravelMidpointPause(FFrame&, void* const)
	public virtual /*native final function */void SetSeamlessTravelMidpointPause(bool bNowPaused)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execGetMapInfo(FFrame&, void* const)
	public virtual /*native final function */MapInfo GetMapInfo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execSetMapInfo(FFrame&, void* const)
	public virtual /*native final function */void SetMapInfo(MapInfo NewMapInfo)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UWorldInfo::execGetMapName(FFrame&, void* const)
	public virtual /*native final function */String GetMapName(/*optional */bool? _bIncludePrefix = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execGetDetailMode(FFrame&, void* const)
	public virtual /*native final function */Scene.EDetailMode GetDetailMode()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execIsRecordingDemo(FFrame&, void* const)
	public virtual /*native final function */bool IsRecordingDemo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execIsPlayingDemo(FFrame&, void* const)
	public virtual /*native final function */bool IsPlayingDemo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UWorldInfo::execDoMemoryTracking(FFrame&, void* const)
	public virtual /*native function */void DoMemoryTracking()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
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