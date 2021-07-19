namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Engine : Subsystem/*
		abstract
		transient
		native
		config(Engine)*/{
	public enum ETransitionType 
	{
		TT_None,
		TT_Paused,
		TT_Loading,
		TT_Saving,
		TT_Connecting,
		TT_Precaching,
		TT_MAX
	};
	
	public partial struct /*native */DropNoteInfo
	{
		public Object.Vector Location;
		public Object.Rotator Rotation;
		public String Comment;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00319E44
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Rotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		Comment = "";
	//	}
	};
	
	public/*private*/ Font TinyFont;
	[globalconfig] public String TinyFontName;
	public/*private*/ Font SmallFont;
	[globalconfig] public String SmallFontName;
	public/*private*/ Font MediumFont;
	[globalconfig] public String MediumFontName;
	public/*private*/ Font LargeFont;
	[globalconfig] public String LargeFontName;
	public/*private*/ Font SubtitleFont;
	[globalconfig] public String SubtitleFontName;
	public/*private*/ array<Font> AdditionalFonts;
	[globalconfig] public array</*config */String> AdditionalFontNames;
	public Core.ClassT<Console> ConsoleClass;
	[globalconfig] public String ConsoleClassName;
	public Core.ClassT<GameViewportClient> GameViewportClientClass;
	[globalconfig] public String GameViewportClientClassName;
	public Core.ClassT<DataStoreClient> DataStoreClientClass;
	[globalconfig] public String DataStoreClientClassName;
	public Core.ClassT<LocalPlayer> LocalPlayerClass;
	[config] public String LocalPlayerClassName;
	public Material DefaultMaterial;
	[globalconfig] public String DefaultMaterialName;
	public Material WireframeMaterial;
	[globalconfig] public String WireframeMaterialName;
	public Material EmissiveTexturedMaterial;
	[globalconfig] public String EmissiveTexturedMaterialName;
	public Material GeomMaterial;
	[globalconfig] public String GeomMaterialName;
	public Material DefaultFogVolumeMaterial;
	[globalconfig] public String DefaultFogVolumeMaterialName;
	public Material TickMaterial;
	[globalconfig] public String TickMaterialName;
	public Material CrossMaterial;
	[globalconfig] public String CrossMaterialName;
	public Material LevelColorationLitMaterial;
	[globalconfig] public String LevelColorationLitMaterialName;
	public Material LevelColorationUnlitMaterial;
	[globalconfig] public String LevelColorationUnlitMaterialName;
	public Material RemoveSurfaceMaterial;
	[globalconfig] public String RemoveSurfaceMaterialName;
	[globalconfig] public array</*config */Object.Color> LightComplexityColors;
	[globalconfig] public array</*config */Object.Color> ShaderComplexityColors;
	[globalconfig] public bool bUsePixelShaderComplexity;
	[globalconfig] public bool bUseAdditiveComplexity;
	[config] public bool bCaptureCharacterLighting;
	[Category("Settings")] [config] public bool bUseSound;
	[Category("Settings")] [config] public bool bUseTextureStreaming;
	[Category("Settings")] [config] public bool bUseBackgroundLevelStreaming;
	[Category("Settings")] [config] public bool bSubtitlesEnabled;
	[Category("Settings")] [config] public bool bSubtitlesForcedOff;
	[Category("Settings")] [config] public bool bForceStaticTerrain;
	public bool bKeepLighting;
	[config] public bool bForceCPUSkinning;
	[config] public bool bUsePostProcessEffects;
	[config] public bool bOnScreenKismetWarnings;
	[config] public bool bEnableKismetLogging;
	[config] public bool bAllowMatureLanguage;
	[config] public bool bEnableVSMShadows;
	[config] public bool bEnableBranchingPCFShadows;
	[config] public bool bAllowBetterModulatedShadows;
	[config] public bool bRenderTerrainCollisionAsOverlay;
	[config] public bool bDisablePhysXHardwareSupport;
	[config] public bool bPauseOnLossOfFocus;
	[Const, globalconfig] public bool bEnableColorClear;
	[globalconfig] public float MaxPixelShaderAdditiveComplexityCount;
	[globalconfig] public float MaxPixelShaderOpaqueComplexityCount;
	[globalconfig] public float MaxVertexShaderComplexityCount;
	[globalconfig] public float MinTextureDensity;
	[globalconfig] public float IdealTextureDensity;
	[globalconfig] public float MaxTextureDensity;
	[globalconfig] public float MinLightmapTextureDensity;
	[globalconfig] public float IdealLightmapTextureDensity;
	[globalconfig] public float MaxLightmapTextureDensity;
	public Material EditorBrushMaterial;
	[globalconfig] public String EditorBrushMaterialName;
	public PhysicalMaterial DefaultPhysMaterial;
	[globalconfig] public String DefaultPhysMaterialName;
	public Material TerrainErrorMaterial;
	[globalconfig] public String TerrainErrorMaterialName;
	[globalconfig] public int TerrainMaterialMaxTextureCount;
	[globalconfig] public int TerrainTessellationCheckCount;
	[globalconfig] public float TerrainTessellationCheckDistance;
	public Core.ClassT<OnlineSubsystem> OnlineSubsystemClass;
	[globalconfig] public String DefaultOnlineSubsystemName;
	public PostProcessChain DefaultPostProcess;
	[config] public String DefaultPostProcessName;
	public PostProcessChain ThumbnailSkeletalMeshPostProcess;
	[config] public String ThumbnailSkeletalMeshPostProcessName;
	public PostProcessChain ThumbnailParticleSystemPostProcess;
	[config] public String ThumbnailParticleSystemPostProcessName;
	public PostProcessChain ThumbnailMaterialPostProcess;
	[config] public String ThumbnailMaterialPostProcessName;
	public PostProcessChain DefaultUIScenePostProcess;
	[config] public String DefaultUIScenePostProcessName;
	public Material DefaultUICaretMaterial;
	[globalconfig] public String DefaultUICaretMaterialName;
	public Material SceneCaptureReflectActorMaterial;
	[globalconfig] public String SceneCaptureReflectActorMaterialName;
	public Material SceneCaptureCubeActorMaterial;
	[globalconfig] public String SceneCaptureCubeActorMaterialName;
	public Texture2D RandomAngleTexture;
	[globalconfig] public String RandomAngleTextureName;
	public Texture2D RandomNormalTexture;
	[globalconfig] public String RandomNormalTextureName;
	[Category("Settings")] [config] public float TimeBetweenPurgingPendingKillObjects;
	[Const] public Client Client;
	[init] public array</*init */LocalPlayer> GamePlayers;
	[Const] public GameViewportClient GameViewport;
	[init] public array</*init */String> DeferredCommands;
	public int TickCycles;
	public int GameCycles;
	public int ClientCycles;
	[Const] public DebugManager DebugManager;
	[native] public Object.Pointer RemoteControlExec;
	[Category("Colors")] public Object.Color C_WorldBox;
	[Category("Colors")] public Object.Color C_BrushWire;
	[Category("Colors")] public Object.Color C_AddWire;
	[Category("Colors")] public Object.Color C_SubtractWire;
	[Category("Colors")] public Object.Color C_SemiSolidWire;
	[Category("Colors")] public Object.Color C_NonSolidWire;
	[Category("Colors")] public Object.Color C_WireBackground;
	[Category("Colors")] public Object.Color C_ScaleBoxHi;
	[Category("Colors")] public Object.Color C_VolumeCollision;
	[Category("Colors")] public Object.Color C_BSPCollision;
	[Category("Colors")] public Object.Color C_OrthoBackground;
	[Category("Colors")] public Object.Color C_Volume;
	[Category("Settings")] public float StreamingDistanceFactor;
	[Const, config] public String ScoutClassName;
	public Engine.ETransitionType TransitionType;
	public String TransitionDescription;
	public String TransitionGameType;
	[config] public float MeshLODRange;
	[config] public float ShadowFilterRadius;
	[config] public float DepthBias;
	[config] public float ModShadowFadeDistanceExponent;
	[config] public float CameraRotationThreshold;
	[config] public float CameraTranslationThreshold;
	[config] public float PrimitiveProbablyVisibleTime;
	[config] public float PercentUnoccludedRequeries;
	[config] public float ShadowVolumeLightRadiusThreshold;
	[config] public float ShadowVolumePrimitiveScreenSpacePercentageThreshold;
	[config] public int MaxParticleResize;
	[config] public int MaxParticleResizeWarn;
	public Material TerrainCollisionMaterial;
	[globalconfig] public String TerrainCollisionMaterialName;
	[config] public int BeginUPTryCount;
	[transient] public array<Engine.DropNoteInfo> PendingDroppedNotes;
	[globalconfig] public String DynamicCoverMeshComponentName;
	[globalconfig] public float NetClientTicksPerSecond;
	[native, Const, transient] public/*private*/ TdLOIGroupManager LOIGroupManager;
	
	// Export UEngine::execGetCurrentWorldInfo(FFrame&, void* const)
	public /*native final function */static WorldInfo GetCurrentWorldInfo()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetTinyFont(FFrame&, void* const)
	public /*native final function */static Font GetTinyFont()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetSmallFont(FFrame&, void* const)
	public /*native final function */static Font GetSmallFont()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetMediumFont(FFrame&, void* const)
	public /*native final function */static Font GetMediumFont()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetLargeFont(FFrame&, void* const)
	public /*native final function */static Font GetLargeFont()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetAdditionalFont(FFrame&, void* const)
	public /*native final function */static Font GetAdditionalFont(int AdditionalFontIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execIsSplitScreen(FFrame&, void* const)
	public /*native final function */static bool IsSplitScreen()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetAudioDevice(FFrame&, void* const)
	public /*native final function */static AudioDevice GetAudioDevice()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execGetLastMovieName(FFrame&, void* const)
	public /*native final function */static String GetLastMovieName()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execPlayLoadMapMovie(FFrame&, void* const)
	public /*native final function */static bool PlayLoadMapMovie()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UEngine::execStopMovie(FFrame&, void* const)
	public /*native final function */static void StopMovie(bool bDelayStopUntilGameHasRendered)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UEngine::execRemoveAllOverlays(FFrame&, void* const)
	public /*native final function */static void RemoveAllOverlays()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UEngine::execAddOverlay(FFrame&, void* const)
	public /*native final function */static void AddOverlay(Font Font, String Text, float X, float Y, float ScaleX, float ScaleY, bool bIsCentered, /*optional */ref Object.LinearColor TextColor/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UEngine::execAddOverlayWrapped(FFrame&, void* const)
	public /*native final function */static void AddOverlayWrapped(Font Font, String Text, float X, float Y, float ScaleX, float ScaleY, float WrapWidth, /*optional */ref Object.LinearColor TextColor/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*event */void DispatchExternalUIChange(bool bIsOpening)
	{
		// stub
	}
	
	public Engine()
	{
		// Object Offset:0x0031A806
		TinyFontName = "UI_Fonts_Final.Helvetica_Small_Normal";
		SmallFontName = "EngineFonts.SmallFont";
		MediumFontName = "UI_Fonts_Final.Helvetica_Small_Normal";
		LargeFontName = "EngineFonts.LargeFont";
		SubtitleFontName = "UI_Fonts_Final.Helvetica_Small_Bold";
		ConsoleClassName = "TdGame.TdConsole";
		GameViewportClientClassName = "TdGame.TdGameViewportClient";
		DataStoreClientClassName = "Engine.DataStoreClient";
		LocalPlayerClassName = "Engine.LocalPlayer";
		DefaultMaterialName = "EngineMaterials.DefaultMaterial";
		WireframeMaterialName = "EngineMaterials.WireframeMaterial";
		EmissiveTexturedMaterialName = "EngineMaterials.EmissiveTexturedMaterial";
		GeomMaterialName = "EngineMaterials.GeomMaterial";
		DefaultFogVolumeMaterialName = "EngineMaterials.FogVolumeMaterial";
		TickMaterialName = "EditorMaterials.Tick_Mat";
		CrossMaterialName = "EditorMaterials.Cross_Mat";
		LevelColorationLitMaterialName = "EngineMaterials.LevelColorationLitMaterial";
		LevelColorationUnlitMaterialName = "EngineMaterials.LevelColorationUnlitMaterial";
		RemoveSurfaceMaterialName = "EngineMaterials.RemoveSurfaceMaterial";
		LightComplexityColors = new array</*config */Object.Color>
		{
		}
		#warning Exception thrown while deserializing LightComplexityColors
		/*System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
		   at System.Collections.Generic.List`1.get_Item(Int32 index)
		   at UELib.UName.Deserialize(IUnrealStream stream) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Types\UName.cs:line 65
		   at UELib.UName..ctor(IUnrealStream stream) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Types\UName.cs:line 46
		   at UELib.UObjectStream.ReadNameReference() in D:\MirrorsEdge\Sources\Unreal-Library\src\UnrealStream.cs:line 961
		   at UELib.Core.UDefaultProperty.Deserialize() in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 151
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 646
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 762 */;
		ShaderComplexityColors = new array</*config */Object.Color>
		{
		}
		#warning Exception thrown while deserializing ShaderComplexityColors
		/*System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
		   at System.Collections.Generic.List`1.get_Item(Int32 index)
		   at UELib.UName.Deserialize(IUnrealStream stream) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Types\UName.cs:line 65
		   at UELib.UName..ctor(IUnrealStream stream) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Types\UName.cs:line 46
		   at UELib.UObjectStream.ReadNameReference() in D:\MirrorsEdge\Sources\Unreal-Library\src\UnrealStream.cs:line 961
		   at UELib.Core.UDefaultProperty.Deserialize() in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 151
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 646
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 762 */;
		bUsePixelShaderComplexity = true;
		bUseAdditiveComplexity = true;
		bCaptureCharacterLighting = true;
		bUseSound = true;
		bUseTextureStreaming = true;
		bUseBackgroundLevelStreaming = true;
		bSubtitlesEnabled = true;
		bOnScreenKismetWarnings = true;
		bEnableVSMShadows = true;
		bAllowBetterModulatedShadows = true;
		bDisablePhysXHardwareSupport = true;
		MaxPixelShaderAdditiveComplexityCount = 300.0f;
		MaxPixelShaderOpaqueComplexityCount = 100.0f;
		MaxVertexShaderComplexityCount = 100.0f;
		IdealTextureDensity = 13.0f;
		MaxTextureDensity = 55.0f;
		MinLightmapTextureDensity = 0.0010f;
		IdealLightmapTextureDensity = 0.050f;
		MaxLightmapTextureDensity = 2.50f;
		EditorBrushMaterialName = "EngineMaterials.EditorBrushMaterial";
		DefaultPhysMaterialName = "EngineMaterials.DefaultPhysicalMaterial";
		TerrainErrorMaterialName = "EngineMaterials.MaterialError_Mat";
		TerrainMaterialMaxTextureCount = 16;
		TerrainTessellationCheckCount = 6;
		TerrainTessellationCheckDistance = 4096.0f;
		DefaultOnlineSubsystemName = "Tp.TpSystem";
		DefaultPostProcessName = "FX_PostProcess.FX_PostProcess";
		ThumbnailSkeletalMeshPostProcessName = "EngineMaterials.DefaultThumbnailPostProcess";
		ThumbnailParticleSystemPostProcessName = "EngineMaterials.DefaultThumbnailPostProcess";
		ThumbnailMaterialPostProcessName = "EngineMaterials.DefaultThumbnailPostProcess";
		DefaultUIScenePostProcessName = "FX_PostProcess.FX_PostProcessUI";
		DefaultUICaretMaterialName = "EngineMaterials.BlinkingCaret";
		SceneCaptureReflectActorMaterialName = "EngineMaterials.ScreenMaterial";
		SceneCaptureCubeActorMaterialName = "EngineMaterials.CubeMaterial";
		RandomAngleTextureName = "EngineMaterials.RandomAngles";
		RandomNormalTextureName = "EngineMaterials.RandomNormal";
		TimeBetweenPurgingPendingKillObjects = 60.0f;
		C_WorldBox = new Color
		{
			R=0,
			G=0,
			B=40,
			A=255
		};
		C_BrushWire = new Color
		{
			R=192,
			G=0,
			B=0,
			A=255
		};
		C_AddWire = new Color
		{
			R=127,
			G=127,
			B=255,
			A=255
		};
		C_SubtractWire = new Color
		{
			R=255,
			G=192,
			B=63,
			A=255
		};
		C_SemiSolidWire = new Color
		{
			R=127,
			G=255,
			B=0,
			A=255
		};
		C_NonSolidWire = new Color
		{
			R=63,
			G=192,
			B=32,
			A=255
		};
		C_WireBackground = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		C_ScaleBoxHi = new Color
		{
			R=223,
			G=149,
			B=157,
			A=255
		};
		C_VolumeCollision = new Color
		{
			R=149,
			G=223,
			B=157,
			A=255
		};
		C_BSPCollision = new Color
		{
			R=149,
			G=157,
			B=223,
			A=255
		};
		C_OrthoBackground = new Color
		{
			R=163,
			G=163,
			B=163,
			A=255
		};
		C_Volume = new Color
		{
			R=255,
			G=196,
			B=255,
			A=255
		};
		ScoutClassName = "TdGame.TdScout";
		ShadowFilterRadius = 2.0f;
		DepthBias = 0.020f;
		ModShadowFadeDistanceExponent = 0.20f;
		CameraRotationThreshold = 45.0f;
		CameraTranslationThreshold = 10000.0f;
		PrimitiveProbablyVisibleTime = 8.0f;
		PercentUnoccludedRequeries = 0.1250f;
		ShadowVolumeLightRadiusThreshold = 1000.0f;
		ShadowVolumePrimitiveScreenSpacePercentageThreshold = 0.250f;
		TerrainCollisionMaterialName = "EngineMaterials.TerrainCollisionMaterial";
		BeginUPTryCount = 200000;
		NetClientTicksPerSecond = 200.0f;
	}
}
}