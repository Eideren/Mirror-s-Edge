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
		#warning NATIVE FUNCTION !
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
		// Object Offset:0x00680C0C
		StringRenderComponent = Default__TdUIButtonBarButton_ButtonBarStringRendererDS;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBarButton.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBarButton.BackgroundImageTemplate'*/;
		bNeverFocus = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBarButton.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBarButton.WidgetEventComponent'*/;
	}
}
}