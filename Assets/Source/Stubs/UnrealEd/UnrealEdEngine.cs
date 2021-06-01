namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UnrealEdEngine : EditorEngine/*
		transient
		native
		config(Engine)
		noexport*/{
	public partial struct /*native */ClassMoveInfo
	{
		public /*config */String ClassName;
		public /*config */String PackageName;
		public /*config */String GroupName;
		public /*config */bool bActive;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002F1D2
	//		ClassName = "";
	//		PackageName = "";
	//		GroupName = "";
	//		bActive = false;
	//	}
	};
	
	public /*const noexport */Object.Pointer NotifyVtbl;
	public /*const */UnrealEdOptions EditorOptionsInst;
	public /*const */BrowserManager BrowserManager;
	public /*const */ThumbnailManager ThumbnailManager;
	public /*config */String BrowserManagerClassName;
	public /*config */String ThumbnailManagerClassName;
	public /*const config */int AutoSaveIndex;
	public /*const */float AutosaveCount;
	public/*(Advanced)*/ /*config */bool AutoSave;
	public/*(Advanced)*/ /*config */int AutosaveTimeMinutes;
	public /*const */Material MaterialCopyPasteBuffer;
	public /*const */Object MatineeCopyPasteBuffer;
	public array<AnimationCompressionAlgorithm> AnimationCompressionAlgorithms;
	public /*config */array</*config */String> PackagesToBeFullyLoadedAtStartup;
	public /*config */array</*config */name> HiddenKismetClassNames;
	public /*config */array</*config */UnrealEdEngine.ClassMoveInfo> ClassRelocationInfo;
	
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