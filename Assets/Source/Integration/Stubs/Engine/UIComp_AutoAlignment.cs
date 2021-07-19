namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_AutoAlignment : UIComponent/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	[Category] public UIRoot.EUIAlignment HorzAlignment;
	[Category] public UIRoot.EUIAlignment VertAlignment;
	
	public UIComp_AutoAlignment()
	{
		// Object Offset:0x0041BCC0
		HorzAlignment = UIRoot.EUIAlignment.UIALIGN_Default;
		VertAlignment = UIRoot.EUIAlignment.UIALIGN_Default;
	}
}
}