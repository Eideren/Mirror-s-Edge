namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIDrawPanel : TdUIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*()*/ bool bUseFullViewport;
	public Canvas Canvas;
	public float pLeft;
	public float pTop;
	public float pWidth;
	public float pHeight;
	public float ResolutionScale;
	public /*delegate*/TdUIDrawPanel.DrawDelegate __DrawDelegate__Delegate;
	
	// Export UTdUIDrawPanel::execDraw2DLine(FFrame&, void* const)
	public virtual /*native final function */void Draw2DLine(int X1, int Y1, int X2, int Y2, Object.Color LineColor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public delegate bool DrawDelegate(Canvas C);
	
	public virtual /*event */void DrawPanel()
	{
		// stub
	}
	
	public TdUIDrawPanel()
	{
		var Default__TdUIDrawPanel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIDrawPanel.WidgetEventComponent' */;
		// Object Offset:0x00683D09
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
		};
		EventProvider = Default__TdUIDrawPanel_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIDrawPanel.WidgetEventComponent'*/;
	}
}
}