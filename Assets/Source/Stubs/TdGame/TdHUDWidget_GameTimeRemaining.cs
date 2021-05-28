namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_GameTimeRemaining : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel timeLabel;
	
	public TdHUDWidget_GameTimeRemaining()
	{
		// Object Offset:0x005776F7
		requiresTick = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDWidget_GameTimeRemaining.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDWidget_GameTimeRemaining.WidgetEventComponent'*/;
	}
}
}