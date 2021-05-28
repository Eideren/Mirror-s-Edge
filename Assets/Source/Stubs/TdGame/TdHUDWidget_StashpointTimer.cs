namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_StashpointTimer : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel StashpointTimerLabel;
	public /*private deprecated */string Text;
	public /*private deprecated */float Completed;
	
	public TdHUDWidget_StashpointTimer()
	{
		// Object Offset:0x00577F29
		requiresTick = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDWidget_StashpointTimer.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDWidget_StashpointTimer.WidgetEventComponent'*/;
	}
}
}