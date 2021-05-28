namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UINumericEditBoxButton : UIButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public UINumericEditBoxButton()
	{
		// Object Offset:0x0044599B
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericEditBoxButton.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UINumericEditBoxButton.BackgroundImageTemplate'*/;
		PrivateFlags = 47;
		EventProvider = LoadAsset<UIComp_Event>("Default__UINumericEditBoxButton.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericEditBoxButton.WidgetEventComponent'*/;
	}
}
}