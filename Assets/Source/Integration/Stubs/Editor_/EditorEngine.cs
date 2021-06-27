namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EditorEngine : Engine/*
		transient
		native
		config(Engine)
		noexport*/{
	public /*private native const noexport */Object.Pointer VfTable_FCallbackEventDevice;
	public /*const */Model TempModel;
	public /*const */TransBuffer Trans;
	public /*const */TextBuffer Results;
	public /*const */array<Object.Pointer> ActorProperties;
	public /*const */Object.Pointer LevelProperties;
	public /*const */Texture2D Bad;
	public /*const */Texture2D Bkgnd;
	public /*const */Texture2D BkgndHi;
	public /*const */Texture2D BadHighlight;
	public /*const */Texture2D MaterialArrow;
	public /*const */Texture2D MaterialBackdrop;
	public /*const transient */SoundCue PreviewSoundCue;
	public /*const export editinline transient */AudioComponent PreviewAudioComponent;
	public StaticMesh TexPropCube;
	public StaticMesh TexPropSphere;
	public StaticMesh TexPropPlane;
	public StaticMesh TexPropCylinder;
	public /*const */bool bFastRebuild;
	public /*const */bool bBootstrapping;
	public /*const */bool bIsImportingT3D;
	public /*const */int TerrainEditBrush;
	public /*const */int ClickFlags;
	public /*const */Package ParentContext;
	public /*const */Object.Vector ClickLocation;
	public /*const */Object.Plane ClickPlane;
	public /*const */Object.Vector MouseMovement;
	public /*native const */array<Object.Pointer> ViewportClients;
	public /*const */float FarClippingPlane;
	public Scene.EDetailMode DetailMode;
	public /*const noexport */Object.Pointer ConstraintsVtbl;
	public/*(Grid)*/ /*noexport config */bool GridEnabled;
	public/*(Grid)*/ /*noexport config */bool SnapScaleEnabled;
	public/*(Grid)*/ /*noexport config */bool SnapVertices;
	public/*(Grid)*/ /*noexport config */int ScaleGridSize;
	public/*(Grid)*/ /*noexport config */float SnapDistance;
	public/*(Grid)*/ /*noexport config */StaticArray<float, float, float, float, float, float, float, float, float, float, float>/*[11]*/ GridSizes;
	public/*(Grid)*/ /*noexport config */int CurrentGridSz;
	public/*(RotationGrid)*/ /*noexport config */bool RotGridEnabled;
	public/*(RotationGrid)*/ /*noexport config */Object.Rotator RotGridSize;
	public/*(Advanced)*/ /*config */bool UseSizingBox;
	public/*(Advanced)*/ /*config */bool UseAxisIndicator;
	public/*(Advanced)*/ /*config */float FOVAngle;
	public/*(Advanced)*/ /*config */bool GodMode;
	public/*(Advanced)*/ /*config */String AutoSaveDir;
	public/*(Advanced)*/ /*config */bool InvertwidgetZAxis;
	public/*(Advanced)*/ /*config */String GameCommandLine;
	public/*(Advanced)*/ /*globalconfig */array</*config */String> EditPackages;
	public/*(Advanced)*/ /*config */String EditPackagesInPath;
	public/*(Advanced)*/ /*config */String EditPackagesOutPath;
	public/*(Advanced)*/ /*config */String FRScriptOutputPath;
	public/*(Advanced)*/ /*config */bool AlwaysShowTerrain;
	public/*(Advanced)*/ /*config */bool UseActorRotationGizmo;
	public/*(Advanced)*/ /*config */bool bShowBrushMarkerPolys;
	public/*(Advanced)*/ /*config */bool bUseMayaCameraControls;
	public/*(Advanced)*/ /*config */bool bPrefabsLocked;
	public/*(Advanced)*/ /*config */bool bEnableSocketSnapping;
	public /*config */String HeightMapExportClassName;
	public /*const */array<ActorFactory> ActorFactories;
	public String UserOpenedFile;
	public/*(Advanced)*/ /*config */String InEditorGameURLOptions;
	public /*const */World PlayWorld;
	public /*const */Object.Vector PlayWorldLocation;
	public /*const */Object.Rotator PlayWorldRotation;
	public /*const */bool bIsPlayWorldQueued;
	public /*const */bool bHasPlayWorldPlacement;
	public /*const */bool bWorldPackageWasDirty;
	public /*const */int PlayWorldDestination;
	public /*const */Object.Pointer InEditorPropagator;
	public /*const */Object.Pointer RemotePropagator;
	public bool bIsPushingView;
	public /*const transient */bool bColorPickModeEnabled;
	public /*const transient */bool bDecalUpdateRequested;
	public /*const transient */TextureRenderTarget2D ScratchRenderTarget;
	public /*const transient */Texture2D StreamingBoundsTexture;
	
	public EditorEngine()
	{
		// Object Offset:0x0000F1CF
		Bad = LoadAsset<Texture2D>("EditorResources.Bad")/*Ref Texture2D'EditorResources.Bad'*/;
		Bkgnd = LoadAsset<Texture2D>("EditorResources.Bkgnd")/*Ref Texture2D'EditorResources.Bkgnd'*/;
		BkgndHi = LoadAsset<Texture2D>("EditorResources.BkgndHi")/*Ref Texture2D'EditorResources.BkgndHi'*/;
		BadHighlight = LoadAsset<Texture2D>("EditorResources.BadHighlight")/*Ref Texture2D'EditorResources.BadHighlight'*/;
		MaterialArrow = LoadAsset<Texture2D>("EditorResources.MaterialArrow")/*Ref Texture2D'EditorResources.MaterialArrow'*/;
		MaterialBackdrop = LoadAsset<Texture2D>("EditorResources.MaterialBackdrop")/*Ref Texture2D'EditorResources.MaterialBackdrop'*/;
		TexPropCube = LoadAsset<StaticMesh>("EditorMeshes.TexPropCube")/*Ref StaticMesh'EditorMeshes.TexPropCube'*/;
		TexPropSphere = LoadAsset<StaticMesh>("EditorMeshes.TexPropSphere")/*Ref StaticMesh'EditorMeshes.TexPropSphere'*/;
		TexPropPlane = LoadAsset<StaticMesh>("EditorMeshes.TexPropPlane")/*Ref StaticMesh'EditorMeshes.TexPropPlane'*/;
		TexPropCylinder = LoadAsset<StaticMesh>("EditorMeshes.TexPropCylinder")/*Ref StaticMesh'EditorMeshes.TexPropCylinder'*/;
		DetailMode = default;
		ConstraintsVtbl = default;
		GridEnabled = true;
		SnapScaleEnabled = true;
		ScaleGridSize = 5;
		SnapDistance = 10.0f;
		CurrentGridSz = 4;
		RotGridEnabled = true;
		RotGridSize = new Rotator
		{
			Pitch=1024,
			Yaw=1024,
			Roll=1024
		};
		UseAxisIndicator = true;
		FOVAngle = 90.0f;
		GodMode = true;
		AutoSaveDir = "..\\TdGame\\Content\\Maps\\Autosaves";
		InvertwidgetZAxis = true;
		GameCommandLine = "-log";
		EditPackages = new array</*config */String>
		{
			"Core",
			"Engine",
			"GameFramework",
			"Editor",
			"UnrealEd",
			"Ts",
			"IpDrv",
			"Tp",
			"TdGame",
			"TdSharedContent",
			"TdSpContent",
			"TdSpBossContent",
			"TdMpContent",
			"TdTuContent",
			"TdTTContent",
			"TdMenuContent",
			"TdEditor",
			"Fp",
		};
		EditPackagesInPath = "..\\Development\\Src";
		EditPackagesOutPath = "..\\TdGame\\Script";
		FRScriptOutputPath = "..\\TdGame\\ScriptFinalRelease";
		bUseMayaCameraControls = true;
		bPrefabsLocked = true;
		HeightMapExportClassName = "TerrainHeightMapExporterTextT3D";
		LocalPlayerClassName = "Editor.EditorPlayer";
	}
}
}