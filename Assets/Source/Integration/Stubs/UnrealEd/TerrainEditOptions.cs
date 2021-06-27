namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainEditOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	public/*(Options)*/ /*config */int Solid1_Strength;
	public/*(Options)*/ /*config */int Solid1_Radius;
	public/*(Options)*/ /*config */int Solid1_Falloff;
	public/*(Options)*/ /*config */int Solid2_Strength;
	public/*(Options)*/ /*config */int Solid2_Radius;
	public/*(Options)*/ /*config */int Solid2_Falloff;
	public/*(Options)*/ /*config */int Solid3_Strength;
	public/*(Options)*/ /*config */int Solid3_Radius;
	public/*(Options)*/ /*config */int Solid3_Falloff;
	public/*(Options)*/ /*config */int Solid4_Strength;
	public/*(Options)*/ /*config */int Solid4_Radius;
	public/*(Options)*/ /*config */int Solid4_Falloff;
	public/*(Options)*/ /*config */int Solid5_Strength;
	public/*(Options)*/ /*config */int Solid5_Radius;
	public/*(Options)*/ /*config */int Solid5_Falloff;
	public/*(Options)*/ /*config */int Noisy1_Strength;
	public/*(Options)*/ /*config */int Noisy1_Radius;
	public/*(Options)*/ /*config */int Noisy1_Falloff;
	public/*(Options)*/ /*config */int Noisy2_Strength;
	public/*(Options)*/ /*config */int Noisy2_Radius;
	public/*(Options)*/ /*config */int Noisy2_Falloff;
	public/*(Options)*/ /*config */int Noisy3_Strength;
	public/*(Options)*/ /*config */int Noisy3_Radius;
	public/*(Options)*/ /*config */int Noisy3_Falloff;
	public/*(Options)*/ /*config */int Noisy4_Strength;
	public/*(Options)*/ /*config */int Noisy4_Radius;
	public/*(Options)*/ /*config */int Noisy4_Falloff;
	public/*(Options)*/ /*config */int Noisy5_Strength;
	public/*(Options)*/ /*config */int Noisy5_Radius;
	public/*(Options)*/ /*config */int Noisy5_Falloff;
	public/*(Options)*/ /*config */int Current_Tool;
	public/*(Options)*/ /*config */int Current_Brush;
	public/*(Options)*/ /*config */int Current_Strength;
	public/*(Options)*/ /*config */int Current_Radius;
	public/*(Options)*/ /*config */int Current_Falloff;
	public/*(Options)*/ /*config */bool bSoftSelectEnabled;
	public/*(Options)*/ /*config */bool bConstrainedEditing;
	public/*(Options)*/ /*config */bool bShowFoliageMeshes;
	public/*(Options)*/ /*config */bool bShowDecoarationMeshes;
	public/*(Options)*/ /*config */int Current_MirrorFlag;
	public/*(Options)*/ /*config */int SliderRange_Low_Strength;
	public/*(Options)*/ /*config */int SliderRange_High_Strength;
	public/*(Options)*/ /*config */int SliderRange_Low_Radius;
	public/*(Options)*/ /*config */int SliderRange_High_Radius;
	public/*(Options)*/ /*config */int SliderRange_Low_Falloff;
	public/*(Options)*/ /*config */int SliderRange_High_Falloff;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_BackgroundColor;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_BackgroundColor2;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_BackgroundColor3;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_SelectedColor;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_SelectedColor2;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_SelectedColor3;
	public/*(Options)*/ /*config */Object.Color TerrainLayerBrowser_BorderColor;
	
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