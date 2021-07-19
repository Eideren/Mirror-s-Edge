namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_ReactionTime : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline, deprecated] public UILabel ReactionTimeLabel;
	
	public TdHUDWidget_ReactionTime()
	{
		var Default__TdHUDWidget_ReactionTime_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_ReactionTime.WidgetEventComponent' */;
		// Object Offset:0x00577DD6
		requiresTick = true;
		EventProvider = Default__TdHUDWidget_ReactionTime_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_ReactionTime.WidgetEventComponent'*/;
	}
}
}