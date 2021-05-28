namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CascadeOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	public/*(Options)*/ /*config */bool bShowModuleDump;
	public/*(Options)*/ /*config */bool bUseSubMenus;
	public/*(Options)*/ /*config */bool bUseSpaceBarReset;
	public/*(Options)*/ /*config */bool bUseSpaceBarResetInLevel;
	public/*(Options)*/ /*config */bool bShowGrid;
	public/*(Options)*/ /*config */bool bShowParticleCounts;
	public/*(Options)*/ /*config */bool bShowParticleTimes;
	public/*(Options)*/ /*config */bool bShowParticleDistance;
	public/*(Options)*/ /*config */bool bShowFloor;
	public/*(Options)*/ /*config */bool bUseSlimCascadeDraw;
	public/*(Options)*/ /*config */bool bCenterCascadeModuleText;
	public/*(Options)*/ /*config */Object.Color BackgroundColor;
	public/*(Options)*/ /*config */Object.Color Empty_Background;
	public/*(Options)*/ /*config */Object.Color Emitter_Background;
	public/*(Options)*/ /*config */Object.Color Emitter_Unselected;
	public/*(Options)*/ /*config */Object.Color Emitter_Selected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_General_Unselected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_General_Selected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_TypeData_Unselected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_TypeData_Selected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Beam_Unselected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Beam_Selected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Trail_Unselected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Trail_Selected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Spawn_Unselected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Spawn_Selected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Required_Unselected;
	public/*(Options)*/ /*config */Object.Color ModuleColor_Required_Selected;
	public/*(Options)*/ /*config */Object.Color GridColor_Hi;
	public/*(Options)*/ /*config */Object.Color GridColor_Low;
	public/*(Options)*/ /*config */float GridPerspectiveSize;
	public/*(Options)*/ /*config */string FloorMesh;
	public/*(Options)*/ /*config */Object.Vector FloorPosition;
	public/*(Options)*/ /*config */Object.Rotator FloorRotation;
	public/*(Options)*/ /*config */float FloorScale;
	public/*(Options)*/ /*config */Object.Vector FloorScale3D;
	public/*(Options)*/ /*config */string PostProcessChainName;
	public/*(Options)*/ /*config */int ShowPPFlags;
	public/*(Options)*/ /*config */int SlimCascadeDrawHeight;
	
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