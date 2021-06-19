namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITdShelfOptionButton : UITdOptionButton/*
		hidecategories(Object,UIRoot,Object)*/{
	public UITdShelfOptionButton()
	{
		var Default__UITdShelfOptionButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UITdShelfOptionButton.BackgroundImageTemplate' */;
		var Default__UITdShelfOptionButton_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__UITdShelfOptionButton.LabelStringRenderer' */;
		var Default__UITdShelfOptionButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UITdShelfOptionButton.WidgetEventComponent' */;
		// Object Offset:0x006EEB37
		BackgroundImageComponent = Default__UITdShelfOptionButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UITdShelfOptionButton.BackgroundImageTemplate'*/;
		StringRenderComponent = Default__UITdShelfOptionButton_LabelStringRenderer/*Ref UIComp_DrawString'Default__UITdShelfOptionButton.LabelStringRenderer'*/;
		EventProvider = Default__UITdShelfOptionButton_WidgetEventComponent/*Ref UIComp_Event'Default__UITdShelfOptionButton.WidgetEventComponent'*/;
	}
}
}