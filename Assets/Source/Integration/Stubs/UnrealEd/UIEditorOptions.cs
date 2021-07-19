namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEditorOptions : UIRoot/*
		native
		config(Editor)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public const int AUTOEXPAND_VALUE = 0;
	
	public partial struct ViewportDimension
	{
		[config] public int X;
		[config] public int Y;
		[config] public int Width;
		[config] public int Height;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002CF41
	//		X = 0;
	//		Y = 0;
	//		Width = 0;
	//		Height = 0;
	//	}
	};
	
	[config] public UIEditorOptions.ViewportDimension WindowPosition;
	[config] public int DataStoreBrowserSashPosition;
	[config] public int ViewportGutterSize;
	[config] public int VirtualSizeX;
	[config] public int VirtualSizeY;
	[config] public bool bRenderViewportOutline;
	[config] public bool bRenderContainerOutline;
	[config] public bool bRenderSelectionOutline;
	[config] public bool bRenderPerWidgetSelectionOutline;
	[config] public bool bRenderTitleSafeRegionOutline;
	[config] public bool mViewDrawBkgnd;
	[config] public bool mViewDrawGrid;
	[config] public bool bViewShowWireframe;
	[config] public bool bSnapToGrid;
	[config] public bool bShowDockHandles;
	[config] public int ToolMode;
	[config] public int GridSize;
	
	public UIEditorOptions()
	{
		// Object Offset:0x0002D2F3
		WindowPosition = new UIEditorOptions.ViewportDimension
		{
			X = 256,
			Y = 256,
			Width = 1024,
			Height = 768,
		};
		bRenderViewportOutline = true;
		bRenderContainerOutline = true;
		bRenderSelectionOutline = true;
		bRenderPerWidgetSelectionOutline = true;
		mViewDrawGrid = true;
		bSnapToGrid = true;
		bShowDockHandles = true;
		GridSize = 8;
	}
}
}