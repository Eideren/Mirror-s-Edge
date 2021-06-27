namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScrollbarMarkerButton : UIScrollbarButton/* within UIScrollbar*//*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public new UIScrollbar Outer => base.Outer as UIScrollbar;
	
	public /*delegate*/UIScrollbarMarkerButton.OnButtonDragged __OnButtonDragged__Delegate;
	
	public delegate void OnButtonDragged(UIScrollbarMarkerButton Sender, int PlayerIndex);
	
	public UIScrollbarMarkerButton()
	{
		var Default__UIScrollbarMarkerButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1C3A
			StyleResolverTag = (name)"MarkerStyle",
		}/* Reference: UIComp_DrawImage'Default__UIScrollbarMarkerButton.BackgroundImageTemplate' */;
		var Default__UIScrollbarMarkerButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScrollbarMarkerButton.WidgetEventComponent' */;
		// Object Offset:0x0044E255
		BackgroundImageComponent = Default__UIScrollbarMarkerButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIScrollbarMarkerButton.BackgroundImageTemplate'*/;
		EventProvider = Default__UIScrollbarMarkerButton_WidgetEventComponent/*Ref UIComp_Event'Default__UIScrollbarMarkerButton.WidgetEventComponent'*/;
	}
}
}