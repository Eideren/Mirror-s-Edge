namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIStyle_Text : UIStyle_Data/*
		native
		hidecategories(Object,UIRoot)*/{
	public Font StyleFont;
	public UIRoot.UITextAttributes Attributes;
	public StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Alignment;
	public UIRoot.ETextClipMode ClipMode;
	public UIRoot.EUIAlignment ClipAlignment;
	public UIRoot.TextAutoScaleValue AutoScaling;
	public Object.Vector2D Scale;
	public Object.Vector2D SpacingAdjust;
	
	public UIStyle_Text()
	{
		// Object Offset:0x00453294
		StyleFont = LoadAsset<Font>("EngineFonts.SmallFont")/*Ref Font'EngineFonts.SmallFont'*/;
		Alignment[1] = UIRoot.EUIAlignment.UIALIGN_Center;
		AutoScaling = new UIRoot.TextAutoScaleValue
		{
			MinScale = 0.60f,
			AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
		};
		Scale = new Vector2D
		{
			X=1.0f,
			Y=1.0f
		};
		UIEditorControlClass = "WxStyleTextPropertiesGroup";
	}
}
}