namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainEditOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	[Category("Options")] [config] public int Solid1_Strength;
	[Category("Options")] [config] public int Solid1_Radius;
	[Category("Options")] [config] public int Solid1_Falloff;
	[Category("Options")] [config] public int Solid2_Strength;
	[Category("Options")] [config] public int Solid2_Radius;
	[Category("Options")] [config] public int Solid2_Falloff;
	[Category("Options")] [config] public int Solid3_Strength;
	[Category("Options")] [config] public int Solid3_Radius;
	[Category("Options")] [config] public int Solid3_Falloff;
	[Category("Options")] [config] public int Solid4_Strength;
	[Category("Options")] [config] public int Solid4_Radius;
	[Category("Options")] [config] public int Solid4_Falloff;
	[Category("Options")] [config] public int Solid5_Strength;
	[Category("Options")] [config] public int Solid5_Radius;
	[Category("Options")] [config] public int Solid5_Falloff;
	[Category("Options")] [config] public int Noisy1_Strength;
	[Category("Options")] [config] public int Noisy1_Radius;
	[Category("Options")] [config] public int Noisy1_Falloff;
	[Category("Options")] [config] public int Noisy2_Strength;
	[Category("Options")] [config] public int Noisy2_Radius;
	[Category("Options")] [config] public int Noisy2_Falloff;
	[Category("Options")] [config] public int Noisy3_Strength;
	[Category("Options")] [config] public int Noisy3_Radius;
	[Category("Options")] [config] public int Noisy3_Falloff;
	[Category("Options")] [config] public int Noisy4_Strength;
	[Category("Options")] [config] public int Noisy4_Radius;
	[Category("Options")] [config] public int Noisy4_Falloff;
	[Category("Options")] [config] public int Noisy5_Strength;
	[Category("Options")] [config] public int Noisy5_Radius;
	[Category("Options")] [config] public int Noisy5_Falloff;
	[Category("Options")] [config] public int Current_Tool;
	[Category("Options")] [config] public int Current_Brush;
	[Category("Options")] [config] public int Current_Strength;
	[Category("Options")] [config] public int Current_Radius;
	[Category("Options")] [config] public int Current_Falloff;
	[Category("Options")] [config] public bool bSoftSelectEnabled;
	[Category("Options")] [config] public bool bConstrainedEditing;
	[Category("Options")] [config] public bool bShowFoliageMeshes;
	[Category("Options")] [config] public bool bShowDecoarationMeshes;
	[Category("Options")] [config] public int Current_MirrorFlag;
	[Category("Options")] [config] public int SliderRange_Low_Strength;
	[Category("Options")] [config] public int SliderRange_High_Strength;
	[Category("Options")] [config] public int SliderRange_Low_Radius;
	[Category("Options")] [config] public int SliderRange_High_Radius;
	[Category("Options")] [config] public int SliderRange_Low_Falloff;
	[Category("Options")] [config] public int SliderRange_High_Falloff;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_BackgroundColor;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_BackgroundColor2;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_BackgroundColor3;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_SelectedColor;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_SelectedColor2;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_SelectedColor3;
	[Category("Options")] [config] public Object.Color TerrainLayerBrowser_BorderColor;
	
	public TerrainEditOptions()
	{
		// Object Offset:0x0002886F
		Solid1_Strength = 100;
		Solid1_Radius = 1;
		Solid1_Falloff = 1;
		Solid2_Strength = 100;
		Solid2_Radius = 8;
		Solid2_Falloff = 8;
		Solid3_Strength = 100;
		Solid3_Radius = 32;
		Solid3_Falloff = 32;
		Solid4_Strength = 100;
		Solid4_Radius = 64;
		Solid4_Falloff = 64;
		Solid5_Strength = 100;
		Solid5_Radius = 128;
		Solid5_Falloff = 128;
		Noisy1_Strength = 100;
		Noisy1_Radius = 1;
		Noisy1_Falloff = 16;
		Noisy2_Strength = 100;
		Noisy2_Radius = 8;
		Noisy2_Falloff = 32;
		Noisy3_Strength = 100;
		Noisy3_Radius = 32;
		Noisy3_Falloff = 64;
		Noisy4_Strength = 100;
		Noisy4_Radius = 64;
		Noisy4_Falloff = 128;
		Noisy5_Strength = 100;
		Noisy5_Radius = 128;
		Noisy5_Falloff = 256;
		Current_Tool = 2;
		Current_Strength = 100;
		Current_Radius = 64;
		Current_Falloff = 128;
		bShowFoliageMeshes = true;
		bShowDecoarationMeshes = true;
		SliderRange_High_Strength = 100;
		SliderRange_High_Radius = 2048;
		SliderRange_High_Falloff = 2048;
		TerrainLayerBrowser_BackgroundColor = new Color
		{
			R=162,
			G=162,
			B=162,
			A=0
		};
		TerrainLayerBrowser_BackgroundColor2 = new Color
		{
			R=192,
			G=192,
			B=192,
			A=0
		};
		TerrainLayerBrowser_BackgroundColor3 = new Color
		{
			R=212,
			G=212,
			B=212,
			A=0
		};
		TerrainLayerBrowser_SelectedColor = new Color
		{
			R=162,
			G=162,
			B=0,
			A=0
		};
		TerrainLayerBrowser_SelectedColor2 = new Color
		{
			R=192,
			G=192,
			B=0,
			A=0
		};
		TerrainLayerBrowser_SelectedColor3 = new Color
		{
			R=212,
			G=212,
			B=0,
			A=0
		};
		TerrainLayerBrowser_BorderColor = new Color
		{
			R=64,
			G=64,
			B=64,
			A=0
		};
	}
}
}