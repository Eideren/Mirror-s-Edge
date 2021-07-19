namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CascadeOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	[Category("Options")] [config] public bool bShowModuleDump;
	[Category("Options")] [config] public bool bUseSubMenus;
	[Category("Options")] [config] public bool bUseSpaceBarReset;
	[Category("Options")] [config] public bool bUseSpaceBarResetInLevel;
	[Category("Options")] [config] public bool bShowGrid;
	[Category("Options")] [config] public bool bShowParticleCounts;
	[Category("Options")] [config] public bool bShowParticleTimes;
	[Category("Options")] [config] public bool bShowParticleDistance;
	[Category("Options")] [config] public bool bShowFloor;
	[Category("Options")] [config] public bool bUseSlimCascadeDraw;
	[Category("Options")] [config] public bool bCenterCascadeModuleText;
	[Category("Options")] [config] public Object.Color BackgroundColor;
	[Category("Options")] [config] public Object.Color Empty_Background;
	[Category("Options")] [config] public Object.Color Emitter_Background;
	[Category("Options")] [config] public Object.Color Emitter_Unselected;
	[Category("Options")] [config] public Object.Color Emitter_Selected;
	[Category("Options")] [config] public Object.Color ModuleColor_General_Unselected;
	[Category("Options")] [config] public Object.Color ModuleColor_General_Selected;
	[Category("Options")] [config] public Object.Color ModuleColor_TypeData_Unselected;
	[Category("Options")] [config] public Object.Color ModuleColor_TypeData_Selected;
	[Category("Options")] [config] public Object.Color ModuleColor_Beam_Unselected;
	[Category("Options")] [config] public Object.Color ModuleColor_Beam_Selected;
	[Category("Options")] [config] public Object.Color ModuleColor_Trail_Unselected;
	[Category("Options")] [config] public Object.Color ModuleColor_Trail_Selected;
	[Category("Options")] [config] public Object.Color ModuleColor_Spawn_Unselected;
	[Category("Options")] [config] public Object.Color ModuleColor_Spawn_Selected;
	[Category("Options")] [config] public Object.Color ModuleColor_Required_Unselected;
	[Category("Options")] [config] public Object.Color ModuleColor_Required_Selected;
	[Category("Options")] [config] public Object.Color GridColor_Hi;
	[Category("Options")] [config] public Object.Color GridColor_Low;
	[Category("Options")] [config] public float GridPerspectiveSize;
	[Category("Options")] [config] public String FloorMesh;
	[Category("Options")] [config] public Object.Vector FloorPosition;
	[Category("Options")] [config] public Object.Rotator FloorRotation;
	[Category("Options")] [config] public float FloorScale;
	[Category("Options")] [config] public Object.Vector FloorScale3D;
	[Category("Options")] [config] public String PostProcessChainName;
	[Category("Options")] [config] public int ShowPPFlags;
	[Category("Options")] [config] public int SlimCascadeDrawHeight;
	
	public CascadeOptions()
	{
		// Object Offset:0x0001B95D
		bUseSubMenus = true;
		bUseSpaceBarResetInLevel = true;
		bUseSlimCascadeDraw = true;
		bCenterCascadeModuleText = true;
		BackgroundColor = new Color
		{
			R=20,
			G=20,
			B=25,
			A=0
		};
		Empty_Background = new Color
		{
			R=20,
			G=20,
			B=25,
			A=0
		};
		Emitter_Background = new Color
		{
			R=20,
			G=20,
			B=25,
			A=0
		};
		Emitter_Unselected = new Color
		{
			R=255,
			G=100,
			B=0,
			A=0
		};
		Emitter_Selected = new Color
		{
			R=180,
			G=180,
			B=180,
			A=0
		};
		ModuleColor_General_Unselected = new Color
		{
			R=40,
			G=40,
			B=49,
			A=0
		};
		ModuleColor_General_Selected = new Color
		{
			R=255,
			G=100,
			B=0,
			A=0
		};
		ModuleColor_TypeData_Unselected = new Color
		{
			R=15,
			G=20,
			B=20,
			A=0
		};
		ModuleColor_TypeData_Selected = new Color
		{
			R=255,
			G=100,
			B=0,
			A=0
		};
		ModuleColor_Beam_Unselected = new Color
		{
			R=160,
			G=150,
			B=235,
			A=0
		};
		ModuleColor_Beam_Selected = new Color
		{
			R=255,
			G=100,
			B=0,
			A=0
		};
		ModuleColor_Trail_Unselected = new Color
		{
			R=130,
			G=235,
			B=170,
			A=0
		};
		ModuleColor_Trail_Selected = new Color
		{
			R=255,
			G=100,
			B=0,
			A=0
		};
		ModuleColor_Spawn_Unselected = new Color
		{
			R=200,
			G=100,
			B=100,
			A=0
		};
		ModuleColor_Spawn_Selected = new Color
		{
			R=255,
			G=50,
			B=50,
			A=0
		};
		ModuleColor_Required_Unselected = new Color
		{
			R=200,
			G=200,
			B=100,
			A=0
		};
		ModuleColor_Required_Selected = new Color
		{
			R=255,
			G=225,
			B=50,
			A=0
		};
		GridColor_Hi = new Color
		{
			R=0,
			G=100,
			B=255,
			A=0
		};
		GridColor_Low = new Color
		{
			R=0,
			G=100,
			B=255,
			A=0
		};
		GridPerspectiveSize = 1024.0f;
		PostProcessChainName = "EditorMaterials.Cascade.DefaultCascadePostProcess";
		SlimCascadeDrawHeight = 30;
	}
}
}