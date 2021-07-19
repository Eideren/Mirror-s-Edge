namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialEditorOptions : Object/*
		native
		config(EditorUserSettings)
		hidecategories(Object)*/{
	[Category("Options")] [config] public bool bShowGrid;
	[Category("Options")] [config] public bool bShowBackground;
	[Category("Options")] [config] public bool bHideUnusedConnectors;
	[Category("Options")] [config] public bool bDrawCurves;
	[Category("Options")] [config] public bool bRealtimeMaterialViewport;
	[Category("Options")] [config] public bool bRealtimeExpressionViewport;
	[Category("Options")] [config] public bool bAlwaysRefreshAllPreviews;
	
	public MaterialEditorOptions()
	{
		// Object Offset:0x00026C37
		bShowGrid = true;
		bDrawCurves = true;
	}
}
}