namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIContainer : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[Category("Presentation")] [export, editinline] public UIComp_AutoAlignment AutoAlignment;
	
	public UIContainer()
	{
		var Default__UIContainer_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIContainer.WidgetEventComponent' */;
		// Object Offset:0x003B480F
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
		};
		EventProvider = Default__UIContainer_WidgetEventComponent/*Ref UIComp_Event'Default__UIContainer.WidgetEventComponent'*/;
	}
}
}