namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UnrealEdEngine : EditorEngine/*
		transient
		native
		config(Engine)
		noexport*/{
	public partial struct /*native */ClassMoveInfo
	{
		[config] public String ClassName;
		[config] public String PackageName;
		[config] public String GroupName;
		[config] public bool bActive;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002F1D2
	//		ClassName = "";
	//		PackageName = "";
	//		GroupName = "";
	//		bActive = false;
	//	}
	};
	
	[Const, noexport] public Object.Pointer NotifyVtbl;
	[Const] public UnrealEdOptions EditorOptionsInst;
	[Const] public BrowserManager BrowserManager;
	[Const] public ThumbnailManager ThumbnailManager;
	[config] public String BrowserManagerClassName;
	[config] public String ThumbnailManagerClassName;
	[Const, config] public int AutoSaveIndex;
	[Const] public float AutosaveCount;
	[Category("Advanced")] [config] public bool AutoSave;
	[Category("Advanced")] [config] public int AutosaveTimeMinutes;
	[Const] public Material MaterialCopyPasteBuffer;
	[Const] public Object MatineeCopyPasteBuffer;
	public array<AnimationCompressionAlgorithm> AnimationCompressionAlgorithms;
	[config] public array</*config */String> PackagesToBeFullyLoadedAtStartup;
	[config] public array</*config */name> HiddenKismetClassNames;
	[config] public array</*config */UnrealEdEngine.ClassMoveInfo> ClassRelocationInfo;
	
	public UnrealEdEngine()
	{
		// Object Offset:0x0002F27A
		NotifyVtbl = default;
		AutoSave = true;
		AutosaveTimeMinutes = 10;
		PackagesToBeFullyLoadedAtStartup = new array</*config */String>
		{
			"EditorMaterials",
			"EditorMeshes",
			"EditorResources",
			"EngineMaterials",
			"EngineFonts",
			"EngineScenes",
			"EngineResources",
			"DefaultUISkin",
			"Engine_MI_Shaders",
		};
	}
}
}