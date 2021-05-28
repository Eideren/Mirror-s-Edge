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
		public /*config */int X;
		public /*config */int Y;
		public /*config */int Width;
		public /*config */int Height;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002CF41
	//		X = 0;
	//		Y = 0;
	//		Width = 0;
	//		Height = 0;
	//	}
	};
	
	public /*config */UIEditorOptions.ViewportDimension WindowPosition;
	public /*config */int DataStoreBrowserSashPosition;
	public /*config */int ViewportGutterSize;
	public /*config */int VirtualSizeX;
	public /*config */int VirtualSizeY;
	public /*config */bool bRenderViewportOutline;
	public /*config */bool bRenderContainerOutline;
	public /*config */bool bRenderSelectionOutline;
	public /*config */bool bRenderPerWidgetSelectionOutline;
	public /*config */bool bRenderTitleSafeRegionOutline;
	public /*config */bool mViewDrawBkgnd;
	public /*config */bool mViewDrawGrid;
	public /*config */bool bViewShowWireframe;
	public /*config */bool bSnapToGrid;
	public /*config */bool bShowDockHandles;
	public /*config */int ToolMode;
	public /*config */int GridSize;
	
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