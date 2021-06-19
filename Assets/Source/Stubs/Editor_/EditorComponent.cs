// NO OVERWRITE

namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EditorComponent : PrimitiveComponent/*
		native
		noexport*/{
	public /*const */bool bDrawGrid;
	public /*const */bool bDrawPivot;
	public /*const */bool bDrawBaseInfo;
	public /*const */bool bDrawWorldBox;
	public /*const */bool bDrawColoredOrigin;
	public /*const */bool bDrawKillZ;
	public /*const */Object.Color GridColorHi;
	public /*const */Object.Color GridColorLo;
	public /*const */float PerspectiveGridSize;
	public /*const */Object.Color PivotColor;
	public /*const */float PivotSize;
	public /*const */Object.Color BaseBoxColor;
	
	public EditorComponent()
	{
		// Object Offset:0x0000E1C0
		bDrawGrid = true;
		bDrawPivot = true;
		bDrawBaseInfo = true;
		bDrawWorldBox = true;
		bDrawKillZ = true;
		GridColorHi = new Color
		{
			R=0,
			G=0,
			B=127,
			A=0
		};
		GridColorLo = new Color
		{
			R=0,
			G=0,
			B=63,
			A=0
		};
		PerspectiveGridSize = 262143.0f;
		PivotColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=0
		};
		PivotSize = 0.020f;
		BaseBoxColor = new Color
		{
			R=0,
			G=255,
			B=0,
			A=0
		};
		DepthPriorityGroup = MEdge.Engine.Scene.ESceneDepthPriorityGroup.SDPG_UnrealEdBackground;
	}
}
}