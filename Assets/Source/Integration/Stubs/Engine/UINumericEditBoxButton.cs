namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UINumericEditBoxButton : UIButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public UINumericEditBoxButton()
	{
		var Default__UINumericEditBoxButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UINumericEditBoxButton.BackgroundImageTemplate' */;
		var Default__UINumericEditBoxButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UINumericEditBoxButton.WidgetEventComponent' */;
		// Object Offset:0x0044599B
		BackgroundImageComponent = Default__UINumericEditBoxButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UINumericEditBoxButton.BackgroundImageTemplate'*/;
		PrivateFlags = 47;
		EventProvider = Default__UINumericEditBoxButton_WidgetEventComponent/*Ref UIComp_Event'Default__UINumericEditBoxButton.WidgetEventComponent'*/;
	}
}
}