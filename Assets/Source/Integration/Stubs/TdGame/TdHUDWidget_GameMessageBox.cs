namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_GameMessageBox : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline, deprecated] public UILabel MessageLabel;
	
	public TdHUDWidget_GameMessageBox()
	{
		var Default__TdHUDWidget_GameMessageBox_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_GameMessageBox.WidgetEventComponent' */;
		// Object Offset:0x005775FC
		requiresTick = true;
		EventProvider = Default__TdHUDWidget_GameMessageBox_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_GameMessageBox.WidgetEventComponent'*/;
	}
}
}