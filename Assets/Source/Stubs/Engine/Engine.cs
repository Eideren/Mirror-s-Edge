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
		public string Comment;
	
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
	
	public /*private */Font TinyFont;
	public /*globalconfig */string TinyFontName;
	public /*private */Font SmallFont;
	public /*globalconfig */string SmallFontName;
	public /*private */Font MediumFont;
	public /*globalconfig */string MediumFontName;
	public /*private */Font LargeFont;
	public /*globalconfig */string LargeFontName;
	public /*private */Font SubtitleFont;
	public /*globalconfig */string SubtitleFontName;
	public /*private */array<Font> AdditionalFonts;
	public /*globalconfig */array</*config */string> AdditionalFontNames;
	public Core.ClassT<Console> ConsoleClass;
	public /*globalconfig */string ConsoleClassName;
	public Core.ClassT<GameViewportClient> GameViewportClientClass;
	public /*globalconfig */string GameViewportClientClassName;
	public Core.ClassT<DataStoreClient> DataStoreClientClass;
	public /*globalconfig */string DataStoreClientClassName;
	public Core.ClassT<LocalPlayer> LocalPlayerClass;
	public /*config */string LocalPlayerClassName;
	public Material DefaultMaterial;
	public /*globalconfig */string DefaultMaterialName;
	public Material WireframeMaterial;
	public /*globalconfig */string WireframeMaterialName;
	public Material EmissiveTexturedMaterial;
	public /*globalconfig */string EmissiveTexturedMaterialName;
	public Material GeomMaterial;
	public /*globalconfig */string GeomMaterialName;
	public Material DefaultFogVolumeMaterial;
	public /*globalconfig */string DefaultFogVolumeMaterialName;
	public Material TickMaterial;
	public /*globalconfig */string TickMaterialName;
	public Material CrossMaterial;
	public /*globalconfig */string CrossMaterialName;
	public Material LevelColorationLitMaterial;
	public /*globalconfig */string LevelColorationLitMaterialName;
	public Material LevelColorationUnlitMaterial;
	public /*globalconfig */string LevelColorationUnlitMaterialName;
	public Material RemoveSurfaceMaterial;
	public /*globalconfig */string RemoveSurfaceMaterialName;
	public /*globalconfig */array</*config */Object.Color> LightComplexityColors;
	public /*globalconfig */array</*config */Object.Color> ShaderComplexityColors;
	public /*globalconfig */bool bUsePixelShaderComplexity;
	public /*globalconfig */bool bUseAdditiveComplexity;
	public /*config */bool bCaptureCharacterLighting;
	public/*(Settings)*/ /*config */bool bUseSound;
	public/*(Settings)*/ /*config */bool bUseTextureStreaming;
	public/*(Settings)*/ /*config */bool bUseBackgroundLevelStreaming;
	public/*(Settings)*/ /*config */bool bSubtitlesEnabled;
	public/*(Settings)*/ /*config */bool bSubtitlesForcedOff;
	public/*(Settings)*/ /*config */bool bForceStaticTerrain;
	public bool bKeepLighting;
	public /*config */bool bForceCPUSkinning;
	public /*config */bool bUsePostProcessEffects;
	public /*config */bool bOnScreenKismetWarnings;
	public /*config */bool bEnableKismetLogging;
	public /*config */bool bAllowMatureLanguage;
	public /*config */bool bEnableVSMShadows;
	public /*config */bool bEnableBranchingPCFShadows;
	public /*config */bool bAllowBetterModulatedShadows;
	public /*config */bool bRenderTerrainCollisionAsOverlay;
	public /*config */bool bDisablePhysXHardwareSupport;
	public /*config */bool bPauseOnLossOfFocus;
	public /*const globalconfig */bool bEnableColorClear;
	public /*globalconfig */float MaxPixelShaderAdditiveComplexityCount;
	public /*globalconfig */float MaxPixelShaderOpaqueComplexityCount;
	public /*globalconfig */float MaxVertexShaderComplexityCount;
	public /*globalconfig */float MinTextureDensity;
	public /*globalconfig */float IdealTextureDensity;
	public /*globalconfig */float MaxTextureDensity;
	public /*globalconfig */float MinLightmapTextureDensity;
	public /*globalconfig */float IdealLightmapTextureDensity;
	public /*globalconfig */float MaxLightmapTextureDensity;
	public Material EditorBrushMaterial;
	public /*globalconfig */string EditorBrushMaterialName;
	public PhysicalMaterial DefaultPhysMaterial;
	public /*globalconfig */string DefaultPhysMaterialName;
	public Material TerrainErrorMaterial;
	public /*globalconfig */string TerrainErrorMaterialName;
	public /*globalconfig */int TerrainMaterialMaxTextureCount;
	public /*globalconfig */int TerrainTessellationCheckCount;
	public /*globalconfig */float TerrainTessellationCheckDistance;
	public Core.ClassT<OnlineSubsystem> OnlineSubsystemClass;
	public /*globalconfig */string DefaultOnlineSubsystemName;
	public PostProcessChain DefaultPostProcess;
	public /*config */string DefaultPostProcessName;
	public PostProcessChain ThumbnailSkeletalMeshPostProcess;
	public /*config */string ThumbnailSkeletalMeshPostProcessName;
	public PostProcessChain ThumbnailParticleSystemPostProcess;
	public /*config */string ThumbnailParticleSystemPostProcessName;
	public PostProcessChain ThumbnailMaterialPostProcess;
	public /*config */string ThumbnailMaterialPostProcessName;
	public PostProcessChain DefaultUIScenePostProcess;
	public /*config */string DefaultUIScenePostProcessName;
	public Material DefaultUICaretMaterial;
	public /*globalconfig */string DefaultUICaretMaterialName;
	public Material SceneCaptureReflectActorMaterial;
	public /*globalconfig */string SceneCaptureReflectActorMaterialName;
	public Material SceneCaptureCubeActorMaterial;
	public /*globalconfig */string SceneCaptureCubeActorMaterialName;
	public Texture2D RandomAngleTexture;
	public /*globalconfig */string RandomAngleTextureName;
	public Texture2D RandomNormalTexture;
	public /*globalconfig */string RandomNormalTextureName;
	public/*(Settings)*/ /*config */float TimeBetweenPurgingPendingKillObjects;
	public /*const */Client Client;
	public /*init */array</*init */LocalPlayer> GamePlayers;
	public /*const */GameViewportClient GameViewport;
	public /*init */array</*init */string> DeferredCommands;
	public int TickCycles;
	public int GameCycles;
	public int ClientCycles;
	public /*const */DebugManager DebugManager;
	public /*native */Object.Pointer RemoteControlExec;
	public/*(Colors)*/ Object.Color C_WorldBox;
	public/*(Colors)*/ Object.Color C_BrushWire;
	public/*(Colors)*/ Object.Color C_AddWire;
	public/*(Colors)*/ Object.Color C_SubtractWire;
	public/*(Colors)*/ Object.Color C_SemiSolidWire;
	public/*(Colors)*/ Object.Color C_NonSolidWire;
	public/*(Colors)*/ Object.Color C_WireBackground;
	public/*(Colors)*/ Object.Color C_ScaleBoxHi;
	public/*(Colors)*/ Object.Color C_VolumeCollision;
	public/*(Colors)*/ Object.Color C_BSPCollision;
	public/*(Colors)*/ Object.Color C_OrthoBackground;
	public/*(Colors)*/ Object.Color C_Volume;
	public/*(Settings)*/ float StreamingDistanceFactor;
	public /*const config */string ScoutClassName;
	public Engine.ETransitionType TransitionType;
	public string TransitionDescription;
	public string TransitionGameType;
	public /*config */float MeshLODRange;
	public /*config */float ShadowFilterRadius;
	public /*config */float DepthBias;
	public /*config */float ModShadowFadeDistanceExponent;
	public /*config */float CameraRotationThreshold;
	public /*config */float CameraTranslationThreshold;
	public /*config */float PrimitiveProbablyVisibleTime;
	public /*config */float PercentUnoccludedRequeries;
	public /*config */float ShadowVolumeLightRadiusThreshold;
	public /*config */float ShadowVolumePrimitiveScreenSpacePercentageThreshold;
	public /*config */int MaxParticleResize;
	public /*config */int MaxParticleResizeWarn;
	public Material TerrainCollisionMaterial;
	public /*globalconfig */string TerrainCollisionMaterialName;
	public /*config */int BeginUPTryCount;
	public /*transient */array<Engine.DropNoteInfo> PendingDroppedNotes;
	public /*globalconfig */string DynamicCoverMeshComponentName;
	public /*globalconfig */float NetClientTicksPerSecond;
	public /*private native const transient */TdLOIGroupManager LOIGroupManager;
	
	// Export UEngine::execGetCurrentWorldInfo(FFrame&, void* const)
	public /*native final function */static WorldInfo GetCurrentWorldInfo()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetTinyFont(FFrame&, void* const)
	public /*native final function */static Font GetTinyFont()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetSmallFont(FFrame&, void* const)
	public /*native final function */static Font GetSmallFont()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetMediumFont(FFrame&, void* const)
	public /*native final function */static Font GetMediumFont()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetLargeFont(FFrame&, void* const)
	public /*native final function */static Font GetLargeFont()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetAdditionalFont(FFrame&, void* const)
	public /*native final function */static Font GetAdditionalFont(int AdditionalFontIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execIsSplitScreen(FFrame&, void* const)
	public /*native final function */static bool IsSplitScreen()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetAudioDevice(FFrame&, void* const)
	public /*native final function */static AudioDevice GetAudioDevice()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execGetLastMovieName(FFrame&, void* const)
	public /*native final function */static string GetLastMovieName()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execPlayLoadMapMovie(FFrame&, void* const)
	public /*native final function */static bool PlayLoadMapMovie()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UEngine::execStopMovie(FFrame&, void* const)
	public /*native final function */static void StopMovie(bool bDelayStopUntilGameHasRendered)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UEngine::execRemoveAllOverlays(FFrame&, void* const)
	public /*native final function */static void RemoveAllOverlays()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UEngine::execAddOverlay(FFrame&, void* const)
	public /*native final function */static void AddOverlay(Font Font, string Text, float X, float Y, float ScaleX, float ScaleY, bool bIsCentered, /*optional */ref Object.LinearColor TextColor/* = default*/)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UEngine::execAddOverlayWrapped(FFrame&, void* const)
	public /*native final function */static void AddOverlayWrapped(Font Font, string Text, float X, float Y, float ScaleX, float ScaleY, float WrapWidth, /*optional */ref Object.LinearColor TextColor/* = default*/)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */void DispatchExternalUIChange(bool bIsOpening)
	{
	
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
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 657
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 773 */;
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
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 657
		   at UELib.Core.UDefaultProperty.DeserializeDefaultPropertyValue(PropertyType type, DeserializeFlags& deserializeFlags) in D:\MirrorsEdge\Sources\Unreal-Library\src\Core\Classes\UDefaultProperty.cs:line 773 */;
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