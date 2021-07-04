// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIButtonBarButton : UILabelButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*delegate*/TdUIButtonBarButton.OnClickNotification __OnClickNotification__Delegate;
	
	public delegate void OnClickNotification(UIScreenObject EventObject, UIRoot.InputEventParameters EventParms);
	
	// Export UTdUIButtonBarButton::execCanAcceptFocus(FFrame&, void* const)
	public override /*native function */bool CanAcceptFocus(/*optional */int? _PlayerIndex = default)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public TdUIButtonBarButton()
	{
		var Default__TdUIButtonBarButton_ButtonBarStringRendererDS = new UIComp_TdDropShadowString
		{
			// Object Offset:0x03135B66
			DropShadowStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"TdLabelTextButtonBarButtonStyleDropShadow",
			},
			StyleResolverTag = (name)"Caption Style",
			AutoSizeParameters = new UIRoot.AutoSizeData
			{
				bAutoSizeEnabled = true,
			},
			StringStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"TdLabelTextButtonBarButtonStyle",
			},
		}/* Reference: UIComp_TdDropShadowString'Default__TdUIButtonBarButton.ButtonBarStringRendererDS' */;
		var Default__TdUIButtonBarButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUIButtonBarButton.BackgroundImageTemplate' */;
		var Default__TdUIButtonBarButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIButtonBarButton.WidgetEventComponent' */;
		// Object Offset:0x00680C0C
		StringRenderComponent = Default__TdUIButtonBarButton_ButtonBarStringRendererDS/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBarButton.ButtonBarStringRendererDS'*/;
		BackgroundImageComponent = Default__TdUIButtonBarButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__TdUIButtonBarButton.BackgroundImageTemplate'*/;
		bNeverFocus = true;
		EventProvider = Default__TdUIButtonBarButton_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIButtonBarButton.WidgetEventComponent'*/;
	}
}
}