namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITdShelfOptionButton : UITdOptionButton/*
		hidecategories(Object,UIRoot,Object)*/{
	public UITdShelfOptionButton()
	{
		// Object Offset:0x006EEB37
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UITdShelfOptionButton.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UITdShelfOptionButton.BackgroundImageTemplate'*/;
		StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__UITdShelfOptionButton.LabelStringRenderer")/*Ref UIComp_DrawString'Default__UITdShelfOptionButton.LabelStringRenderer'*/;
		EventProvider = LoadAsset<UIComp_Event>("Default__UITdShelfOptionButton.WidgetEventComponent")/*Ref UIComp_Event'Default__UITdShelfOptionButton.WidgetEventComponent'*/;
	}
}
}