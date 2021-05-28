namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawCaption : UIComp_DrawString/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	public UIComp_DrawCaption()
	{
		// Object Offset:0x0041D981
		StyleResolverTag = (name)"Caption Style";
		TextStyleCustomization = new UIRoot.UITextStyleOverride
		{
			ClipMode = UIRoot.ETextClipMode.CLIP_Normal,
			bOverrideClipMode = true,
		};
	}
}
}