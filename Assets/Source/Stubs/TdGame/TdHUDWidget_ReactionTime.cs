namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_ReactionTime : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel ReactionTimeLabel;
	
	public TdHUDWidget_ReactionTime()
	{
		// Object Offset:0x00577DD6
		requiresTick = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDWidget_ReactionTime.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDWidget_ReactionTime.WidgetEventComponent'*/;
	}
}
}