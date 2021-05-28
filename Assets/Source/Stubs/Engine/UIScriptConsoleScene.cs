namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScriptConsoleScene : UIScene/*
		transient
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline */UILabel BufferText;
	public /*export editinline */UIImage BufferBackground;
	public /*export editinline */ScriptConsoleEntry CommandRegion;
	
	public override /*event */void Initialized()
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void OnCreateChild(UIObject CreatedWidget, UIScreenObject CreatorContainer)
	{
	
	}
	
	public UIScriptConsoleScene()
	{
		// Object Offset:0x0044C604
		BufferText = new UILabel
		{
			// Object Offset:0x005D340E
			StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__UIScriptConsoleScene.BufferTextTemplate.LabelStringRenderer")/*Ref UIComp_DrawString'Default__UIScriptConsoleScene.BufferTextTemplate.LabelStringRenderer'*/,
			WidgetTag = (name)"BufferText",
			PrimaryStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleBufferStyle",
			},
			__OnCreate__Delegate = (CreatedWidget, CreatorContainer) => OnCreateChild(CreatedWidget, CreatorContainer),
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = 1.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.BufferTextTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.BufferTextTemplate.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__UIScriptConsoleScene.BufferTextTemplate' */;
		BufferBackground = new UIImage
		{
			// Object Offset:0x005D31CE
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIScriptConsoleScene.BufferBackgroundTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.BufferBackgroundTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"BufferBackground",
			PrimaryStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleBufferImageStyle",
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.BufferBackgroundTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.BufferBackgroundTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__UIScriptConsoleScene.BufferBackgroundTemplate' */;
		CommandRegion = new ScriptConsoleEntry
		{
			// Object Offset:0x004CEB8A
			InputBox = new UIEditBox
			{
				// Object Offset:0x005D2922
				StringRenderComponent = LoadAsset<UIComp_DrawStringEditbox>("Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxStringRenderer")/*Ref UIComp_DrawStringEditbox'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxStringRenderer'*/,
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxBackgroundTemplate")/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxBackgroundTemplate'*/,
				__OnCreate__Delegate = (CreatedWidget, CreatorContainer) => OnCreateChild(CreatedWidget, CreatorContainer),
				EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.WidgetEventComponent'*/,
			}/* Reference: UIEditBox'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate' */,
			UpperConsoleBorder = new UIImage
			{
				// Object Offset:0x005D32BE
				ImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.ImageComponentTemplate'*/,
				EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.WidgetEventComponent'*/,
			}/* Reference: UIImage'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate' */,
			LowerConsoleBorder = new UIImage
			{
				// Object Offset:0x005D327A
				ImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.ImageComponentTemplate'*/,
				EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.WidgetEventComponent'*/,
			}/* Reference: UIImage'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate' */,
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIScriptConsoleScene.CommandRegionTemplate.PanelBackgroundTemplate")/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.PanelBackgroundTemplate'*/,
			EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.CommandRegionTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.WidgetEventComponent'*/,
		}/* Reference: ScriptConsoleEntry'Default__UIScriptConsoleScene.CommandRegionTemplate' */;
		SceneTag = (name)"ConsoleScene";
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[3] = 0.750f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageViewport,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageViewport,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__UIScriptConsoleScene.SceneEventComponent")/*Ref UIComp_Event'Default__UIScriptConsoleScene.SceneEventComponent'*/;
	}
}
}