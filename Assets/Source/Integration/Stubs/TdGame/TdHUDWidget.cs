namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget : TdHUDObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public TdHUDWidget()
	{
		var Default__TdHUDWidget_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget.WidgetEventComponent' */;
		// Object Offset:0x00577505
		EventProvider = Default__TdHUDWidget_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget.WidgetEventComponent'*/;
	}
}
}