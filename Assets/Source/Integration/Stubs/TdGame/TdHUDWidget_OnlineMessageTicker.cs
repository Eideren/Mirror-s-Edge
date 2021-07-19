namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_OnlineMessageTicker : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline, deprecated] public UIImage LogoImage;
	[export, editinline, deprecated] public UIImage TickerBGImage;
	[export, editinline, deprecated] public UILabel TickerTextLabel;
	[deprecated] public Texture LogoImageTextre;
	[deprecated] public Texture TickerBGImageTexture;
	
	public TdHUDWidget_OnlineMessageTicker()
	{
		var Default__TdHUDWidget_OnlineMessageTicker_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdHUDWidget_OnlineMessageTicker.WidgetEventComponent' */;
		// Object Offset:0x00577C43
		requiresTick = true;
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = 0.050f,
				[1] = 0.90f,
				[2] = 0.950f,
				[3] = 0.80f,
			},
		};
		EventProvider = Default__TdHUDWidget_OnlineMessageTicker_WidgetEventComponent/*Ref UIComp_Event'Default__TdHUDWidget_OnlineMessageTicker.WidgetEventComponent'*/;
	}
}
}