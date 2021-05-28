namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScrollbarButton : UIButton/* within UIScrollbar*//*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public new UIScrollbar Outer => base.Outer as UIScrollbar;
	
	public UIScrollbarButton()
	{
		// Object Offset:0x0044E064
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIScrollbarButton.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIScrollbarButton.BackgroundImageTemplate'*/;
		PrivateFlags = 47;
		EventProvider = LoadAsset<UIComp_Event>("Default__UIScrollbarButton.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScrollbarButton.WidgetEventComponent'*/;
	}
}
}