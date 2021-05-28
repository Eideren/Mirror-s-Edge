// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIButtonBar : TdUIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int TDBUTTONBAR_MAX_BUTTONS = 6;
	public const int TDBUTTONBAR_BUTTON_SPACING_CONNECTED = -20;
	public const int TDBUTTONBAR_BUTTON_SPACING = -50;
	
	public /*export editinline */StaticArray<TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton>/*[6]*/ Buttons;
	public /*delegate*/TdUIButtonBar.OnPlayClickNotification __OnPlayClickNotification__Delegate;
	
	public delegate bool OnPlayClickNotification(/*const */ref UIRoot.InputEventParameters EventParms);
	
	// Export UTdUIButtonBar::execCanAcceptFocus(FFrame&, void* const)
	public override /*native function */bool CanAcceptFocus(/*optional */int PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIButtonBar::execBuildFakeInputEvent(FFrame&, void* const)
	public virtual /*native function */UIRoot.InputEventParameters BuildFakeInputEvent(/*const */ref UIRoot.InputEventParameters SourceEvent, name FakeKey)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
	
	}
	
	public virtual /*function */int AppendButton(string ButtonTextMarkup, /*delegate*/UIObject.OnClicked ButtonDelegate)
	{
	
		return default;
	}
	
	public virtual /*function */void CheckMarkup(ref string ButtonTextMarkup)
	{
	
	}
	
	public virtual /*function */void SetButton(int ButtonIndex, string ButtonTextMarkup, /*delegate*/UIObject.OnClicked ButtonDelegate)
	{
	
	}
	
	public virtual /*function */void ClearButton(int ButtonIndex)
	{
	
	}
	
	public virtual /*function */void ClearButtons()
	{
	
	}
	
	public virtual /*function */void ToggleButton(int ButtonIndex, bool bActive)
	{
	
	}
	
	public virtual /*function */void ToggleAllButtons(bool bActive)
	{
	
	}
	
	public virtual /*function */void ToggleSetButtons(bool bActive)
	{
	
	}
	
	public virtual /*function */void DisableButton(int ButtonIndex, bool bDisable)
	{
	
	}
	
	public virtual /*function */void DisableAllButtons(bool bDisable)
	{
	
	}
	
	public virtual /*function */void PlayInputNotificationClickToKey(UIScreenObject EventObject, UIRoot.InputEventParameters EventParms)
	{
	
	}
	
	public TdUIButtonBar()
	{
		// Object Offset:0x00681F3E
		Buttons = new StaticArray<TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton, TdUIButtonBarButton>()
		{ 
			[0] = new TdUIButtonBarButton()
			{
				// Object Offset:0x03135CA2
				CaptionDataSource = new UIRoot.UIDataStoreBinding
				{
					MarkupString = "Button 0",
				},
				StringRenderComponent = LoadAsset<UIComp_TdDropShadowString>("Default__TdUIButtonBar.ButtonTemplate0.ButtonBarStringRendererDS")/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBar.ButtonTemplate0.ButtonBarStringRendererDS'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBar.ButtonTemplate0.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBar.ButtonTemplate0.BackgroundImageTemplate'*/,
				WidgetTag = (name)"butButtonBarButton0",
				TabIndex = 0,
				Position = new UIRoot.UIScreenValue_Bounds
				{
					Value = new StaticArray<float, float, float, float>()
					{
						[0] = 0.90f,
						[2] = 0.10f,
						#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
					},
				},
				EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.ButtonTemplate0.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.ButtonTemplate0.WidgetEventComponent'*/,
			}/* Reference: TdUIButtonBarButton'Default__TdUIButtonBar.ButtonTemplate0' */,
			[1] = new TdUIButtonBarButton()
			{
				// Object Offset:0x03135DEB
				CaptionDataSource = new UIRoot.UIDataStoreBinding
				{
					MarkupString = "Button 1",
				},
				StringRenderComponent = LoadAsset<UIComp_TdDropShadowString>("Default__TdUIButtonBar.ButtonTemplate1.ButtonBarStringRendererDS")/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBar.ButtonTemplate1.ButtonBarStringRendererDS'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBar.ButtonTemplate1.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBar.ButtonTemplate1.BackgroundImageTemplate'*/,
				WidgetTag = (name)"butButtonBarButton1",
				TabIndex = 1,
				Position = new UIRoot.UIScreenValue_Bounds
				{
					Value = new StaticArray<float, float, float, float>()
					{
						[0] = 0.90f,
						[2] = 0.10f,
						#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
					},
				},
				EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.ButtonTemplate1.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.ButtonTemplate1.WidgetEventComponent'*/,
			}/* Reference: TdUIButtonBarButton'Default__TdUIButtonBar.ButtonTemplate1' */,
			[2] = new TdUIButtonBarButton()
			{
				// Object Offset:0x03135F34
				CaptionDataSource = new UIRoot.UIDataStoreBinding
				{
					MarkupString = "Button 2",
				},
				StringRenderComponent = LoadAsset<UIComp_TdDropShadowString>("Default__TdUIButtonBar.ButtonTemplate2.ButtonBarStringRendererDS")/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBar.ButtonTemplate2.ButtonBarStringRendererDS'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBar.ButtonTemplate2.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBar.ButtonTemplate2.BackgroundImageTemplate'*/,
				WidgetTag = (name)"butButtonBarButton2",
				TabIndex = 2,
				Position = new UIRoot.UIScreenValue_Bounds
				{
					Value = new StaticArray<float, float, float, float>()
					{
						[0] = 0.90f,
						[2] = 0.10f,
						#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
					},
				},
				EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.ButtonTemplate2.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.ButtonTemplate2.WidgetEventComponent'*/,
			}/* Reference: TdUIButtonBarButton'Default__TdUIButtonBar.ButtonTemplate2' */,
			[3] = new TdUIButtonBarButton()
			{
				// Object Offset:0x0313607D
				CaptionDataSource = new UIRoot.UIDataStoreBinding
				{
					MarkupString = "Button 3",
				},
				StringRenderComponent = LoadAsset<UIComp_TdDropShadowString>("Default__TdUIButtonBar.ButtonTemplate3.ButtonBarStringRendererDS")/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBar.ButtonTemplate3.ButtonBarStringRendererDS'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBar.ButtonTemplate3.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBar.ButtonTemplate3.BackgroundImageTemplate'*/,
				WidgetTag = (name)"butButtonBarButton3",
				TabIndex = 3,
				Position = new UIRoot.UIScreenValue_Bounds
				{
					Value = new StaticArray<float, float, float, float>()
					{
						[0] = 0.90f,
						[2] = 0.10f,
						#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
					},
				},
				EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.ButtonTemplate3.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.ButtonTemplate3.WidgetEventComponent'*/,
			}/* Reference: TdUIButtonBarButton'Default__TdUIButtonBar.ButtonTemplate3' */,
			[4] = new TdUIButtonBarButton()
			{
				// Object Offset:0x031361C6
				CaptionDataSource = new UIRoot.UIDataStoreBinding
				{
					MarkupString = "Button 4",
				},
				StringRenderComponent = LoadAsset<UIComp_TdDropShadowString>("Default__TdUIButtonBar.ButtonTemplate4.ButtonBarStringRendererDS")/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBar.ButtonTemplate4.ButtonBarStringRendererDS'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBar.ButtonTemplate4.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBar.ButtonTemplate4.BackgroundImageTemplate'*/,
				WidgetTag = (name)"butButtonBarButton4",
				TabIndex = 4,
				Position = new UIRoot.UIScreenValue_Bounds
				{
					Value = new StaticArray<float, float, float, float>()
					{
						[0] = 0.90f,
						[2] = 0.10f,
						#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
					},
				},
				EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.ButtonTemplate4.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.ButtonTemplate4.WidgetEventComponent'*/,
			}/* Reference: TdUIButtonBarButton'Default__TdUIButtonBar.ButtonTemplate4' */,
			[5] = new TdUIButtonBarButton()
			{
				// Object Offset:0x0313630F
				CaptionDataSource = new UIRoot.UIDataStoreBinding
				{
					MarkupString = "Button 5",
				},
				StringRenderComponent = LoadAsset<UIComp_TdDropShadowString>("Default__TdUIButtonBar.ButtonTemplate5.ButtonBarStringRendererDS")/*Ref UIComp_TdDropShadowString'Default__TdUIButtonBar.ButtonTemplate5.ButtonBarStringRendererDS'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__TdUIButtonBar.ButtonTemplate5.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__TdUIButtonBar.ButtonTemplate5.BackgroundImageTemplate'*/,
				WidgetTag = (name)"butButtonBarButton5",
				TabIndex = 5,
				Position = new UIRoot.UIScreenValue_Bounds
				{
					Value = new StaticArray<float, float, float, float>()
					{
						[0] = 0.90f,
						[2] = 0.10f,
						#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
					},
				},
				EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.ButtonTemplate5.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.ButtonTemplate5.WidgetEventComponent'*/,
			}/* Reference: TdUIButtonBarButton'Default__TdUIButtonBar.ButtonTemplate5' */,
	 	};
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>()
			{
				[1] = 0.950f,
				[3] = 0.050f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIButtonBar.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIButtonBar.WidgetEventComponent'*/;
	}
}
}