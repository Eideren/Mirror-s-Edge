namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPanel : UIContainer/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Image)*/ /*const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public/*()*/ bool bEnforceClipping;
	
	public virtual /*final function */void SetBackgroundImage(Surface NewImage)
	{
	
	}
	
	public UIPanel()
	{
		// Object Offset:0x003B49E8
		BackgroundImageComponent = new UIComp_DrawImage
		{
			// Object Offset:0x003B4B63
			StyleResolverTag = (name)"Panel Background Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"PanelBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIPanel.PanelBackgroundTemplate' */;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"PanelBackground",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		bSupportsPrimaryStyle = false;
		EventProvider = LoadAsset<UIComp_Event>("Default__UIPanel.WidgetEventComponent")/*Ref UIComp_Event'Default__UIPanel.WidgetEventComponent'*/;
	}
}
}