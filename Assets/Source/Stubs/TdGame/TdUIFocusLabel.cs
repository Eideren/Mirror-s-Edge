namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIFocusLabel : UILabel/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIFocusLabel()
	{
		// Object Offset:0x00687220
		StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__TdUIFocusLabel.LabelStringRenderer")/*Ref UIComp_DrawString'Default__TdUIFocusLabel.LabelStringRenderer'*/;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<TdUIState_FakeActive>(),
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIFocusLabel.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIFocusLabel.WidgetEventComponent'*/;
	}
}
}