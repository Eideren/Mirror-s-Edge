namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIFocusLabel : UILabel/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIFocusLabel()
	{
		var Default__TdUIFocusLabel_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__TdUIFocusLabel.LabelStringRenderer' */;
		var Default__TdUIFocusLabel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIFocusLabel.WidgetEventComponent' */;
		// Object Offset:0x00687220
		StringRenderComponent = Default__TdUIFocusLabel_LabelStringRenderer/*Ref UIComp_DrawString'Default__TdUIFocusLabel.LabelStringRenderer'*/;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<TdUIState_FakeActive>(),
		};
		EventProvider = Default__TdUIFocusLabel_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIFocusLabel.WidgetEventComponent'*/;
	}
}
}