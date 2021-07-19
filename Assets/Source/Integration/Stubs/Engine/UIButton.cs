namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIButton : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage BackgroundImageComponent;
	[Category("Sound")] public name ClickedCue;
	
	public virtual /*final function */void SetImage(Surface NewImage)
	{
		// stub
	}
	
	public UIButton()
	{
		var Default__UIButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x004195DC
			StyleResolverTag = (name)"Background Image Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ButtonBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UIButton.BackgroundImageTemplate' */;
		var Default__UIButton_ButtonClickHandler = new UIEvent_OnClick
		{
		}/* Reference: UIEvent_OnClick'Default__UIButton.ButtonClickHandler' */;
		var Default__UIButton_WidgetEventComponent = new UIComp_Event
		{
			// Object Offset:0x00419528
			DefaultEvents = new array<UIRoot.DefaultEventSpecification>
			{
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_Initialized>("Default__UIObject.WidgetInitializedEvent")/*Ref UIEvent_Initialized'Default__UIObject.WidgetInitializedEvent'*/,
					EventState = default,
				},
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_OnClick>("Default__UIButton.ButtonClickHandler")/*Ref UIEvent_OnClick'Default__UIButton.ButtonClickHandler'*/,
					EventState = ClassT<UIState_Focused>()/*Ref Class'UIState_Focused'*/,
				},
			},
		}/* Reference: UIComp_Event'Default__UIButton.WidgetEventComponent' */;
		// Object Offset:0x004192A1
		BackgroundImageComponent = Default__UIButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIButton.BackgroundImageTemplate'*/;
		ClickedCue = (name)"Clicked";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"ButtonBackground",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		bSupportsPrimaryStyle = false;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__UIButton_WidgetEventComponent/*Ref UIComp_Event'Default__UIButton.WidgetEventComponent'*/;
	}
}
}