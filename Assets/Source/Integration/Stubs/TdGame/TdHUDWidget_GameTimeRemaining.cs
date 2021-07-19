namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_GameTimeRemaining : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline, deprecated] public UILabel timeLabel;
	
	public TdHUDWidget_GameTimeRemaining()
	{
		var Default__TdHUDWidget_GameTimeRemaining_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_GameTimeRemaining.WidgetEventComponent' */;
		// Object Offset:0x005776F7
		requiresTick = true;
		EventProvider = Default__TdHUDWidget_GameTimeRemaining_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_GameTimeRemaining.WidgetEventComponent'*/;
	}
}
}