namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_Health : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline, deprecated] public UILabel healthLabel;
	
	public TdHUDWidget_Health()
	{
		var Default__TdHUDWidget_Health_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_Health.WidgetEventComponent' */;
		// Object Offset:0x005777F2
		EventProvider = Default__TdHUDWidget_Health_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_Health.WidgetEventComponent'*/;
	}
}
}