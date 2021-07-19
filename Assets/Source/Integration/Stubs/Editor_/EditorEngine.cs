namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EditorEngine : Engine/*
		transient
		native
		config(Engine)
		noexport*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FCallbackEventDevice;
	[Const] public Model TempModel;
	[Const] public TransBuffer Trans;
	[Const] public TextBuffer Results;
	[Const] public array<Object.Pointer> ActorProperties;
	[Const] public Object.Pointer LevelProperties;
	[Const] public Texture2D Bad;
	[Const] public Texture2D Bkgnd;
	[Const] public Texture2D BkgndHi;
	[Const] public Texture2D BadHighlight;
	[Const] public Texture2D MaterialArrow;
	[Const] public Texture2D MaterialBackdrop;
	[Const, transient] public SoundCue PreviewSoundCue;
	[Const, export, editinline, transient] public AudioComponent PreviewAudioComponent;
	public StaticMesh TexPropCube;
	public StaticMesh TexPropSphere;
	public StaticMesh TexPropPlane;
	public StaticMesh TexPropCylinder;
	[Const] public bool bFastRebuild;
	[Const] public bool bBootstrapping;
	[Const] public bool bIsImportingT3D;
	[Const] public int TerrainEditBrush;
	[Const] public int ClickFlags;
	[Const] public Package ParentContext;
	[Const] public Object.Vector ClickLocation;
	[Const] public Object.Plane ClickPlane;
	[Const] public Object.Vector MouseMovement;
	[native, Const] public array<Object.Pointer> ViewportClients;
	[Const] public float FarClippingPlane;
	public Scene.EDetailMode DetailMode;
	[Const, noexport] public Object.Pointer ConstraintsVtbl;
	[Category("Grid")] [noexport, config] public bool GridEnabled;
	[Category("Grid")] [noexport, config] public bool SnapScaleEnabled;
	[Category("Grid")] [noexport, config] public bool SnapVertices;
	[Category("Grid")] [noexport, config] public int ScaleGridSize;
	[Category("Grid")] [noexport, config] public float SnapDistance;
	[Category("Grid")] [noexport, config] public StaticArray<float, float, float, float, float, float, float, float, float, float, float>/*[11]*/ GridSizes;
	[Category("Grid")] [noexport, config] public int CurrentGridSz;
	[Category("RotationGrid")] [noexport, config] public bool RotGridEnabled;
	[Category("RotationGrid")] [noexport, config] public Object.Rotator RotGridSize;
	[Category("Advanced")] [config] public bool UseSizingBox;
	[Category("Advanced")] [config] public bool UseAxisIndicator;
	[Category("Advanced")] [config] public float FOVAngle;
	[Category("Advanced")] [config] public bool GodMode;
	[Category("Advanced")] [config] public String AutoSaveDir;
	[Category("Advanced")] [config] public bool InvertwidgetZAxis;
	[Category("Advanced")] [config] public String GameCommandLine;
	[Category("Advanced")] [globalconfig] public array</*config */String> EditPackages;
	[Category("Advanced")] [config] public String EditPackagesInPath;
	[Category("Advanced")] [config] public String EditPackagesOutPath;
	[Category("Advanced")] [config] public String FRScriptOutputPath;
	[Category("Advanced")] [config] public bool AlwaysShowTerrain;
	[Category("Advanced")] [config] public bool UseActorRotationGizmo;
	[Category("Advanced")] [config] public bool bShowBrushMarkerPolys;
	[Category("Advanced")] [config] public bool bUseMayaCameraControls;
	[Category("Advanced")] [config] public bool bPrefabsLocked;
	[Category("Advanced")] [config] public bool bEnableSocketSnapping;
	[config] public String HeightMapExportClassName;
	[Const] public array<ActorFactory> ActorFactories;
	public String UserOpenedFile;
	[Category("Advanced")] [config] public String InEditorGameURLOptions;
	[Const] public World PlayWorld;
	[Const] public Object.Vector PlayWorldLocation;
	[Const] public Object.Rotator PlayWorldRotation;
	[Const] public bool bIsPlayWorldQueued;
	[Const] public bool bHasPlayWorldPlacement;
	[Const] public bool bWorldPackageWasDirty;
	[Const] public int PlayWorldDestination;
	[Const] public Object.Pointer InEditorPropagator;
	[Const] public Object.Pointer RemotePropagator;
	public bool bIsPushingView;
	[Const, transient] public bool bColorPickModeEnabled;
	[Const, transient] public bool bDecalUpdateRequested;
	[Const, transient] public TextureRenderTarget2D ScratchRenderTarget;
	[Const, transient] public Texture2D StreamingBoundsTexture;
	
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