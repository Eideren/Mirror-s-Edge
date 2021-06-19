namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabButton : UITabButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public TdUITabButton()
	{
		var Default__TdUITabButton_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__TdUITabButton.LabelStringRenderer' */;
		var Default__TdUITabButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUITabButton.BackgroundImageTemplate' */;
		var Default__TdUITabButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabButton.WidgetEventComponent' */;
		// Object Offset:0x006B70D5
		StringRenderComponent = Default__TdUITabButton_LabelStringRenderer/*Ref UIComp_DrawString'Default__TdUITabButton.LabelStringRenderer'*/;
		BackgroundImageComponent = Default__TdUITabButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__TdUITabButton.BackgroundImageTemplate'*/;
		PrivateFlags = 935;
		EventProvider = Default__TdUITabButton_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabButton.WidgetEventComponent'*/;
	}
}
}