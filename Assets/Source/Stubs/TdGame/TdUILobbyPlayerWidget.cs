namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUILobbyPlayerWidget : TdUIPlayerSlotBase/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline */TdUIFocusLabel PlayerNameLabel;
	public /*export editinline */UIImage PlayerIsReadyImage;
	public /*export editinline */UIImage PlayerRoleImage;
	
	public TdUILobbyPlayerWidget()
	{
		// Object Offset:0x0068C639
		PlayerNameLabel = new TdUIFocusLabel
		{
			// Object Offset:0x0314A04D
			StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__TdUILobbyPlayerWidget.iPlayerNameLabel.LabelStringRenderer")/*Ref UIComp_DrawString'Default__TdUILobbyPlayerWidget.iPlayerNameLabel.LabelStringRenderer'*/,
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
			EventProvider = LoadAsset<UIComp_Event>("Default__TdUILobbyPlayerWidget.iPlayerNameLabel.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerNameLabel.WidgetEventComponent'*/,
		}/* Reference: TdUIFocusLabel'Default__TdUILobbyPlayerWidget.iPlayerNameLabel' */;
		PlayerIsReadyImage = new UIImage
		{
			// Object Offset:0x037AD7AE
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.ImageComponentTemplate'*/,
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
			EventProvider = LoadAsset<UIComp_Event>("Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__TdUILobbyPlayerWidget.iPlayerIsReadyImage' */;
		PlayerRoleImage = new UIImage
		{
			// Object Offset:0x037AD8B2
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUILobbyPlayerWidget.iPlayerRoleImage.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__TdUILobbyPlayerWidget.iPlayerRoleImage.ImageComponentTemplate'*/,
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
			EventProvider = LoadAsset<UIComp_Event>("Default__TdUILobbyPlayerWidget.iPlayerRoleImage.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.iPlayerRoleImage.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__TdUILobbyPlayerWidget.iPlayerRoleImage' */;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUILobbyPlayerWidget.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUILobbyPlayerWidget.BackgroundImageTemplate'*/;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUILobbyPlayerWidget.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILobbyPlayerWidget.WidgetEventComponent'*/;
	}
}
}