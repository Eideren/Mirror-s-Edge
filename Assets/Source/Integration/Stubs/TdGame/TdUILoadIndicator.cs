namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUILoadIndicator : TdUIObject/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline] public UILabel IndicatorLabel;
	[export, editinline] public UIImage IndicatorImage;
	[export, editinline] public UILabel IndicatorLabelBlack;
	
	public TdUILoadIndicator()
	{
		var Default__TdUILoadIndicator_LoadIndicatorLabel_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__TdUILoadIndicator.LoadIndicatorLabel.LabelStringRenderer' */;
		var Default__TdUILoadIndicator_LoadIndicatorLabel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorLabel.WidgetEventComponent' */;
		var Default__TdUILoadIndicator_LoadIndicatorLabel = new UILabel
		{
			// Object Offset:0x031573AA
			StringRenderComponent = Default__TdUILoadIndicator_LoadIndicatorLabel_LabelStringRenderer/*Ref UIComp_DrawString'Default__TdUILoadIndicator.LoadIndicatorLabel.LabelStringRenderer'*/,
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
			EventProvider = Default__TdUILoadIndicator_LoadIndicatorLabel_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorLabel.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__TdUILoadIndicator.LoadIndicatorLabel' */;
		var Default__TdUILoadIndicator_LoadIndicatorImage_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUILoadIndicator.LoadIndicatorImage.ImageComponentTemplate' */;
		var Default__TdUILoadIndicator_LoadIndicatorImage_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorImage.WidgetEventComponent' */;
		var Default__TdUILoadIndicator_LoadIndicatorImage = new UIImage
		{
			// Object Offset:0x031574A6
			ImageComponent = Default__TdUILoadIndicator_LoadIndicatorImage_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__TdUILoadIndicator.LoadIndicatorImage.ImageComponentTemplate'*/,
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
			EventProvider = Default__TdUILoadIndicator_LoadIndicatorImage_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorImage.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__TdUILoadIndicator.LoadIndicatorImage' */;
		var Default__TdUILoadIndicator_LoadIndicatorLabelBlack_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__TdUILoadIndicator.LoadIndicatorLabelBlack.LabelStringRenderer' */;
		var Default__TdUILoadIndicator_LoadIndicatorLabelBlack_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorLabelBlack.WidgetEventComponent' */;
		var Default__TdUILoadIndicator_LoadIndicatorLabelBlack = new UILabel
		{
			// Object Offset:0x031575A2
			StringRenderComponent = Default__TdUILoadIndicator_LoadIndicatorLabelBlack_LabelStringRenderer/*Ref UIComp_DrawString'Default__TdUILoadIndicator.LoadIndicatorLabelBlack.LabelStringRenderer'*/,
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
			EventProvider = Default__TdUILoadIndicator_LoadIndicatorLabelBlack_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILoadIndicator.LoadIndicatorLabelBlack.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__TdUILoadIndicator.LoadIndicatorLabelBlack' */;
		var Default__TdUILoadIndicator_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILoadIndicator.WidgetEventComponent' */;
		// Object Offset:0x0068C323
		IndicatorLabel = Default__TdUILoadIndicator_LoadIndicatorLabel/*Ref UILabel'Default__TdUILoadIndicator.LoadIndicatorLabel'*/;
		IndicatorImage = Default__TdUILoadIndicator_LoadIndicatorImage/*Ref UIImage'Default__TdUILoadIndicator.LoadIndicatorImage'*/;
		IndicatorLabelBlack = Default__TdUILoadIndicator_LoadIndicatorLabelBlack/*Ref UILabel'Default__TdUILoadIndicator.LoadIndicatorLabelBlack'*/;
		requiresTick = true;
		EventProvider = Default__TdUILoadIndicator_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILoadIndicator.WidgetEventComponent'*/;
	}
}
}