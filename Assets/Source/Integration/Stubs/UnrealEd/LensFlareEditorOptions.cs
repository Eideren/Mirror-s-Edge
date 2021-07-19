namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LensFlareEditorOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	[Category("Options")] [config] public Object.LinearColor LFED_BackgroundColor;
	[Category("Options")] [config] public Object.LinearColor LFED_Empty_Background;
	[Category("Options")] [config] public Object.LinearColor LFED_Source_ElementEd_Background;
	[Category("Options")] [config] public Object.LinearColor LFED_Source_Unselected;
	[Category("Options")] [config] public Object.LinearColor LFED_Source_Selected;
	[Category("Options")] [config] public Object.LinearColor LFED_ElementEd_Background;
	[Category("Options")] [config] public Object.LinearColor LFED_Element_Unselected;
	[Category("Options")] [config] public Object.LinearColor LFED_Element_Selected;
	[Category("Options")] [config] public bool bShowGrid;
	[Category("Options")] [config] public Object.Color GridColor_Hi;
	[Category("Options")] [config] public Object.Color GridColor_Low;
	[Category("Options")] [config] public float GridPerspectiveSize;
	[Category("Options")] [config] public String PostProcessChainName;
	[Category("Options")] [config] public int ShowPPFlags;
	
	public LensFlareEditorOptions()
	{
		// Object Offset:0x00024DC1
		LFED_BackgroundColor = new LinearColor
		{
			R=0.0980f,
			G=0.0780f,
			B=0.0780f,
			A=1.0f
		};
		LFED_Empty_Background = new LinearColor
		{
			R=0.0f,
			G=0.0f,
			B=0.0f,
			A=1.0f
		};
		LFED_Source_ElementEd_Background = new LinearColor
		{
			R=0.0980f,
			G=0.0780f,
			B=0.0780f,
			A=1.0f
		};
		LFED_Source_Unselected = new LinearColor
		{
			R=0.7840f,
			G=0.7840f,
			B=0.7840f,
			A=1.0f
		};
		LFED_Source_Selected = new LinearColor
		{
			R=0.1960f,
			G=0.5880f,
			B=1.0f,
			A=1.0f
		};
		LFED_ElementEd_Background = new LinearColor
		{
			R=0.0980f,
			G=0.0780f,
			B=0.0780f,
			A=1.0f
		};
		LFED_Element_Unselected = new LinearColor
		{
			R=0.5060f,
			G=0.5060f,
			B=0.5060f,
			A=1.0f
		};
		LFED_Element_Selected = new LinearColor
		{
			R=0.0f,
			G=0.3920f,
			B=1.0f,
			A=1.0f
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
	}
}
}