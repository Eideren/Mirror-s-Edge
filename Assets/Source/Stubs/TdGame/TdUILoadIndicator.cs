namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUILoadIndicator : TdUIObject/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline */UILabel IndicatorLabel;
	public /*export editinline */UIImage IndicatorImage;
	public /*export editinline */UILabel IndicatorLabelBlack;
	
	public TdUILoadIndicator()
	{
		var Default__TdUILoadIndicator_LoadIndicatorLabel = new UILabel
		{
			// Object Offset:0x031573AA
			StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__TdUILoadIndicator.LoadIndicatorLabel.LabelStringRenderer")/*Ref UIComp_DrawString'Default__TdUILoadIndicator.LoadIndicatorLabel.LabelStringRenderer'*/,
			WidgetTag = (name)"LoadIndicatorLabel",
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = 0.350f,
					[1] = 0.10f,
					[2] = 0.590f,
					[3] = 0.80f,
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__TdUILoadIndicator.LoadIndicatorLabel.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorLabel.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__TdUILoadIndicator.LoadIndicatorLabel' */;
		var Default__TdUILoadIndicator_LoadIndicatorImage = new UIImage
		{
			// Object Offset:0x031574A6
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUILoadIndicator.LoadIndicatorImage.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__TdUILoadIndicator.LoadIndicatorImage.ImageComponentTemplate'*/,
			WidgetTag = (name)"LoadIndicatorImage",
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = 0.350f,
					[1] = 0.10f,
					[2] = 0.30f,
					[3] = 0.80f,
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__TdUILoadIndicator.LoadIndicatorImage.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorImage.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__TdUILoadIndicator.LoadIndicatorImage' */;
		var Default__TdUILoadIndicator_LoadIndicatorLabelBlack = new UILabel
		{
			// Object Offset:0x031575A2
			StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__TdUILoadIndicator.LoadIndicatorLabelBlack.LabelStringRenderer")/*Ref UIComp_DrawString'Default__TdUILoadIndicator.LoadIndicatorLabelBlack.LabelStringRenderer'*/,
			WidgetTag = (name)"LoadIndicatorLabelBlack",
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = 0.590f,
					[1] = 0.10f,
					[2] = 0.890f,
					[3] = 0.80f,
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__TdUILoadIndicator.LoadIndicatorLabelBlack.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorLabelBlack.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__TdUILoadIndicator.LoadIndicatorLabelBlack' */;
		// Object Offset:0x0068C323
		IndicatorLabel = Default__TdUILoadIndicator_LoadIndicatorLabel;
		IndicatorImage = Default__TdUILoadIndicator_LoadIndicatorImage;
		IndicatorLabelBlack = Default__TdUILoadIndicator_LoadIndicatorLabelBlack;
		requiresTick = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUILoadIndicator.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILoadIndicator.WidgetEventComponent'*/;
	}
}
}