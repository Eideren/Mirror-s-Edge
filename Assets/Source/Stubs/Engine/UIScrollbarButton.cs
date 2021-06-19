namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScrollbarButton : UIButton/* within UIScrollbar*//*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public new UIScrollbar Outer => base.Outer as UIScrollbar;
	
	public UIScrollbarButton()
	{
		var Default__UIScrollbarButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScrollbarButton.BackgroundImageTemplate' */;
		var Default__UIScrollbarButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScrollbarButton.WidgetEventComponent' */;
		// Object Offset:0x0044E064
		BackgroundImageComponent = Default__UIScrollbarButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIScrollbarButton.BackgroundImageTemplate'*/;
		PrivateFlags = 47;
		EventProvider = Default__UIScrollbarButton_WidgetEventComponent/*Ref UIComp_Event'Default__UIScrollbarButton.WidgetEventComponent'*/;
	}
}
}