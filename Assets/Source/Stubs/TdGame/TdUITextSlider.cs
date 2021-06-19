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
		var Default__TdUITextSlider_SliderBackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUITextSlider.SliderBackgroundImageTemplate' */;
		var Default__TdUITextSlider_SliderBarImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUITextSlider.SliderBarImageTemplate' */;
		var Default__TdUITextSlider_SliderMarkerImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUITextSlider.SliderMarkerImageTemplate' */;
		var Default__TdUITextSlider_SliderCaptionRenderer = new UIComp_DrawStringSlider
		{
		}/* Reference: UIComp_DrawStringSlider'Default__TdUITextSlider.SliderCaptionRenderer' */;
		var Default__TdUITextSlider_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITextSlider.WidgetEventComponent' */;
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
		BackgroundImageComponent = Default__TdUITextSlider_SliderBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__TdUITextSlider.SliderBackgroundImageTemplate'*/;
		SliderBarImageComponent = Default__TdUITextSlider_SliderBarImageTemplate/*Ref UIComp_DrawImage'Default__TdUITextSlider.SliderBarImageTemplate'*/;
		MarkerImageComponent = Default__TdUITextSlider_SliderMarkerImageTemplate/*Ref UIComp_DrawImage'Default__TdUITextSlider.SliderMarkerImageTemplate'*/;
		CaptionRenderComponent = Default__TdUITextSlider_SliderCaptionRenderer/*Ref UIComp_DrawStringSlider'Default__TdUITextSlider.SliderCaptionRenderer'*/;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultComboStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		EventProvider = Default__TdUITextSlider_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITextSlider.WidgetEventComponent'*/;
	}
}
}