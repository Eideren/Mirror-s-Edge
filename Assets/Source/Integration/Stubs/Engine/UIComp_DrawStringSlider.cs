namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawStringSlider : UIComp_DrawString/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	public UIComp_DrawStringSlider()
	{
		// Object Offset:0x0041DA7C
		StringStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultSliderCaptionStyle",
		};
	}
}
}