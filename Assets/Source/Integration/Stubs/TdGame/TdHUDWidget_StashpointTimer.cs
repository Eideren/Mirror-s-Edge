namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_StashpointTimer : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel StashpointTimerLabel;
	public /*private deprecated */String Text;
	public /*private deprecated */float Completed;
	
	public TdHUDWidget_StashpointTimer()
	{
		var Default__TdHUDWidget_StashpointTimer_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_StashpointTimer.WidgetEventComponent' */;
		// Object Offset:0x00577F29
		requiresTick = true;
		EventProvider = Default__TdHUDWidget_StashpointTimer_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_StashpointTimer.WidgetEventComponent'*/;
	}
}
}