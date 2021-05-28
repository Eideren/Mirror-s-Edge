namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabButton : UITabButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public TdUITabButton()
	{
		// Object Offset:0x006B70D5
		StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__TdUITabButton.LabelStringRenderer")/*Ref UIComp_DrawString'Default__TdUITabButton.LabelStringRenderer'*/;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUITabButton.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUITabButton.BackgroundImageTemplate'*/;
		PrivateFlags = 935;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITabButton.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITabButton.WidgetEventComponent'*/;
	}
}
}