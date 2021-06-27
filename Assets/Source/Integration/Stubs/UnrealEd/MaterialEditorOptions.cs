namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialEditorOptions : Object/*
		native
		config(EditorUserSettings)
		hidecategories(Object)*/{
	public/*(Options)*/ /*config */bool bShowGrid;
	public/*(Options)*/ /*config */bool bShowBackground;
	public/*(Options)*/ /*config */bool bHideUnusedConnectors;
	public/*(Options)*/ /*config */bool bDrawCurves;
	public/*(Options)*/ /*config */bool bRealtimeMaterialViewport;
	public/*(Options)*/ /*config */bool bRealtimeExpressionViewport;
	public/*(Options)*/ /*config */bool bAlwaysRefreshAllPreviews;
	
	public MaterialEditorOptions()
	{
		// Object Offset:0x00026C37
		bShowGrid = true;
		bDrawCurves = true;
	}
}
}