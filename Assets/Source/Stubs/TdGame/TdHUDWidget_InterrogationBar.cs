namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_InterrogationBar : TdHUDWidget_ProgressBar/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdHUDWidget_InterrogationBar()
	{
		var Default__TdHUDWidget_InterrogationBar_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_InterrogationBar.WidgetEventComponent' */;
		// Object Offset:0x00577A8C
		EventProvider = Default__TdHUDWidget_InterrogationBar_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_InterrogationBar.WidgetEventComponent'*/;
	}
}
}