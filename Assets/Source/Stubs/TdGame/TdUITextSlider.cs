namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITextSlider : UISlider/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public enum ESliderButtonArrow 
	{
		SLIDERARROW_Left,
		SLIDERARROW_Right,
		SLIDERARROW_MAX
	};
	
	public UIRoot.UIStyleReference LeftArrowStyle;
	public UIRoot.UIStyleReference RightArrowStyle;
	public Core.ClassT<UIState> LeftArrowState;
	public Core.ClassT<UIState> RightArrowState;
	public/*(Image)*/ /*export editinlineuse */UITexture LeftArrowTexture;
	public/*(Image)*/ /*export editinlineuse */UITexture RightArrowTexture;
	
	public TdUITextSlider()
	{
		// Object Offset:0x006BC092
		LeftArrowStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultButtonLeftArrowStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		RightArrowStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultButtonRightArrowStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		LeftArrowState = ClassT<UIState_Enabled>()/*Ref Class'UIState_Enabled'*/;
		RightArrowState = ClassT<UIState_Enabled>()/*Ref Class'UIState_Enabled'*/;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUITextSlider.SliderBackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUITextSlider.SliderBackgroundImageTemplate'*/;
		SliderBarImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUITextSlider.SliderBarImageTemplate")/*Ref UIComp_DrawImage'Default__TdUITextSlider.SliderBarImageTemplate'*/;
		MarkerImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUITextSlider.SliderMarkerImageTemplate")/*Ref UIComp_DrawImage'Default__TdUITextSlider.SliderMarkerImageTemplate'*/;
		CaptionRenderComponent = LoadAsset<UIComp_DrawStringSlider>("Default__TdUITextSlider.SliderCaptionRenderer")/*Ref UIComp_DrawStringSlider'Default__TdUITextSlider.SliderCaptionRenderer'*/;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultComboStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITextSlider.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITextSlider.WidgetEventComponent'*/;
	}
}
}