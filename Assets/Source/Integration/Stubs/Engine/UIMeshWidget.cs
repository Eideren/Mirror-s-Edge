namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIMeshWidget : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[Category] [Const, editconst, export, editinline] public StaticMeshComponent Mesh;
	
	public UIMeshWidget()
	{
		var Default__UIMeshWidget_WidgetMesh = new StaticMeshComponent
		{
		}/* Reference: StaticMeshComponent'Default__UIMeshWidget.WidgetMesh' */;
		var Default__UIMeshWidget_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIMeshWidget.WidgetEventComponent' */;
		// Object Offset:0x004449BC
		Mesh = Default__UIMeshWidget_WidgetMesh/*Ref StaticMeshComponent'Default__UIMeshWidget.WidgetMesh'*/;
		bSupportsPrimaryStyle = false;
		bDebugShowBounds = true;
		DebugBoundsColor = new Color
		{
			R=128,
			G=0,
			B=64,
			A=255
		};
		bSupports3DPrimitives = true;
		EventProvider = Default__UIMeshWidget_WidgetEventComponent/*Ref UIComp_Event'Default__UIMeshWidget.WidgetEventComponent'*/;
	}
}
}