namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_ProgressBar : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*noclear const export editinline deprecated */UIComp_DrawImage ProgressBarBackgroundImage;
	public /*noclear const export editinline deprecated */UIComp_DrawImage ProgressBarFillImage;
	public /*deprecated */UIRoot.UIRangeData ProgressBarValue;
	public /*deprecated */UIRoot.EUIOrientation ProgressBarOrientation;
	
	public TdHUDWidget_ProgressBar()
	{
		var Default__TdHUDWidget_ProgressBar_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_ProgressBar.WidgetEventComponent' */;
		// Object Offset:0x00577961
		requiresTick = true;
		EventProvider = Default__TdHUDWidget_ProgressBar_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_ProgressBar.WidgetEventComponent'*/;
	}
}
}