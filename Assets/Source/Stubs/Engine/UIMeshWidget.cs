namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIMeshWidget : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*()*/ /*const editconst export editinline */StaticMeshComponent Mesh;
	
	public UIMeshWidget()
	{
		// Object Offset:0x004449BC
		Mesh = LoadAsset<StaticMeshComponent>("Default__UIMeshWidget.WidgetMesh")/*Ref StaticMeshComponent'Default__UIMeshWidget.WidgetMesh'*/;
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UIMeshWidget.WidgetEventComponent")/*Ref UIComp_Event'Default__UIMeshWidget.WidgetEventComponent'*/;
	}
}
}