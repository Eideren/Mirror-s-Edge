namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_Team : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel teamLabel;
	
	public TdHUDWidget_Team()
	{
		var Default__TdHUDWidget_Team_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_Team.WidgetEventComponent' */;
		// Object Offset:0x00578024
		requiresTick = true;
		EventProvider = Default__TdHUDWidget_Team_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_Team.WidgetEventComponent'*/;
	}
}
}