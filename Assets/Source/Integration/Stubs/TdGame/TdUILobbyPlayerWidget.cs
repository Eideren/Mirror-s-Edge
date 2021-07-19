namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUILobbyPlayerWidget : TdUIPlayerSlotBase/*
		hidecategories(Object,UIRoot,Object)*/{
	[export, editinline] public TdUIFocusLabel PlayerNameLabel;
	[export, editinline] public UIImage PlayerIsReadyImage;
	[export, editinline] public UIImage PlayerRoleImage;
	
	public TdUILobbyPlayerWidget()
	{
		var Default__TdUILobbyPlayerWidget_iPlayerNameLabel_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__TdUILobbyPlayerWidget.iPlayerNameLabel.LabelStringRenderer' */;
		var Default__TdUILobbyPlayerWidget_iPlayerNameLabel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerNameLabel.WidgetEventComponent' */;
		var Default__TdUILobbyPlayerWidget_iPlayerNameLabel = new TdUIFocusLabel
		{
			// Object Offset:0x0314A04D
			StringRenderComponent = Default__TdUILobbyPlayerWidget_iPlayerNameLabel_LabelStringRenderer/*Ref UIComp_DrawString'Default__TdUILobbyPlayerWidget.iPlayerNameLabel.LabelStringRenderer'*/,
			WidgetTag = (name)"PlayerNameLabel",
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = 0.20f,
					[2] = 0.60f,
					[3] = 1.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = Default__TdUILobbyPlayerWidget_iPlayerNameLabel_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerNameLabel.WidgetEventComponent'*/,
		}/* Reference: TdUIFocusLabel'Default__TdUILobbyPlayerWidget.iPlayerNameLabel' */;
		var Default__TdUILobbyPlayerWidget_iPlayerIsReadyImage_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.ImageComponentTemplate' */;
		var Default__TdUILobbyPlayerWidget_iPlayerIsReadyImage_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.WidgetEventComponent' */;
		var Default__TdUILobbyPlayerWidget_iPlayerIsReadyImage = new UIImage
		{
			// Object Offset:0x037AD7AE
			ImageComponent = Default__TdUILobbyPlayerWidget_iPlayerIsReadyImage_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.ImageComponentTemplate'*/,
			WidgetTag = (name)"PlayerIsReadyImage",
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = 0.20f,
					[3] = 1.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = Default__TdUILobbyPlayerWidget_iPlayerIsReadyImage_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage' */;
		var Default__TdUILobbyPlayerWidget_iPlayerRoleImage_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUILobbyPlayerWidget.iPlayerRoleImage.ImageComponentTemplate' */;
		var Default__TdUILobbyPlayerWidget_iPlayerRoleImage_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerRoleImage.WidgetEventComponent' */;
		var Default__TdUILobbyPlayerWidget_iPlayerRoleImage = new UIImage
		{
			// Object Offset:0x037AD8B2
			ImageComponent = Default__TdUILobbyPlayerWidget_iPlayerRoleImage_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__TdUILobbyPlayerWidget.iPlayerRoleImage.ImageComponentTemplate'*/,
			WidgetTag = (name)"PlayerRoleImage",
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[0] = 0.80f,
					[2] = 0.20f,
					[3] = 1.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = Default__TdUILobbyPlayerWidget_iPlayerRoleImage_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerRoleImage.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__TdUILobbyPlayerWidget.iPlayerRoleImage' */;
		var Default__TdUILobbyPlayerWidget_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUILobbyPlayerWidget.BackgroundImageTemplate' */;
		var Default__TdUILobbyPlayerWidget_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILobbyPlayerWidget.WidgetEventComponent' */;
		// Object Offset:0x0068C639
		PlayerNameLabel = Default__TdUILobbyPlayerWidget_iPlayerNameLabel/*Ref TdUIFocusLabel'Default__TdUILobbyPlayerWidget.iPlayerNameLabel'*/;
		PlayerIsReadyImage = Default__TdUILobbyPlayerWidget_iPlayerIsReadyImage/*Ref UIImage'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage'*/;
		PlayerRoleImage = Default__TdUILobbyPlayerWidget_iPlayerRoleImage/*Ref UIImage'Default__TdUILobbyPlayerWidget.iPlayerRoleImage'*/;
		BackgroundImageComponent = Default__TdUILobbyPlayerWidget_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__TdUILobbyPlayerWidget.BackgroundImageTemplate'*/;
		EventProvider = Default__TdUILobbyPlayerWidget_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.WidgetEventComponent'*/;
	}
}
}