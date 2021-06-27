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
		// stub
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void OnCreateChild(UIObject CreatedWidget, UIScreenObject CreatorContainer)
	{
		// stub
	}
	
	public UIScriptConsoleScene()
	{
		var Default__UIScriptConsoleScene_BufferTextTemplate_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__UIScriptConsoleScene.BufferTextTemplate.LabelStringRenderer' */;
		var Default__UIScriptConsoleScene_BufferTextTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.BufferTextTemplate.WidgetEventComponent' */;
		var Default__UIScriptConsoleScene_BufferTextTemplate = new UILabel
		{
			// Object Offset:0x005D340E
			StringRenderComponent = Default__UIScriptConsoleScene_BufferTextTemplate_LabelStringRenderer/*Ref UIComp_DrawString'Default__UIScriptConsoleScene.BufferTextTemplate.LabelStringRenderer'*/,
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
			EventProvider = Default__UIScriptConsoleScene_BufferTextTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.BufferTextTemplate.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__UIScriptConsoleScene.BufferTextTemplate' */;
		var Default__UIScriptConsoleScene_BufferBackgroundTemplate_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScriptConsoleScene.BufferBackgroundTemplate.ImageComponentTemplate' */;
		var Default__UIScriptConsoleScene_BufferBackgroundTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.BufferBackgroundTemplate.WidgetEventComponent' */;
		var Default__UIScriptConsoleScene_BufferBackgroundTemplate = new UIImage
		{
			// Object Offset:0x005D31CE
			ImageComponent = Default__UIScriptConsoleScene_BufferBackgroundTemplate_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.BufferBackgroundTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"BufferBackground",
			PrimaryStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleBufferImageStyle",
			},
			EventProvider = Default__UIScriptConsoleScene_BufferBackgroundTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.BufferBackgroundTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__UIScriptConsoleScene.BufferBackgroundTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate_EditboxStringRenderer = new UIComp_DrawStringEditbox
		{
		}/* Reference: UIComp_DrawStringEditbox'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxStringRenderer' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate_EditboxBackgroundTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxBackgroundTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.WidgetEventComponent' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate = new UIEditBox
		{
			// Object Offset:0x005D2922
			StringRenderComponent = Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate_EditboxStringRenderer/*Ref UIComp_DrawStringEditbox'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxStringRenderer'*/,
			BackgroundImageComponent = Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate_EditboxBackgroundTemplate/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.EditboxBackgroundTemplate'*/,
			__OnCreate__Delegate = (CreatedWidget, CreatorContainer) => OnCreateChild(CreatedWidget, CreatorContainer),
			EventProvider = Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate.WidgetEventComponent'*/,
		}/* Reference: UIEditBox'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_UpperBorderTemplate_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.ImageComponentTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_UpperBorderTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.WidgetEventComponent' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_UpperBorderTemplate = new UIImage
		{
			// Object Offset:0x005D32BE
			ImageComponent = Default__UIScriptConsoleScene_CommandRegionTemplate_UpperBorderTemplate_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.ImageComponentTemplate'*/,
			EventProvider = Default__UIScriptConsoleScene_CommandRegionTemplate_UpperBorderTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_LowerBorderTemplate_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.ImageComponentTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_LowerBorderTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.WidgetEventComponent' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_LowerBorderTemplate = new UIImage
		{
			// Object Offset:0x005D327A
			ImageComponent = Default__UIScriptConsoleScene_CommandRegionTemplate_LowerBorderTemplate_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.ImageComponentTemplate'*/,
			EventProvider = Default__UIScriptConsoleScene_CommandRegionTemplate_LowerBorderTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_PanelBackgroundTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.PanelBackgroundTemplate' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.WidgetEventComponent' */;
		var Default__UIScriptConsoleScene_CommandRegionTemplate = new ScriptConsoleEntry
		{
			// Object Offset:0x004CEB8A
			InputBox = Default__UIScriptConsoleScene_CommandRegionTemplate_ConsoleInputTemplate/*Ref UIEditBox'Default__UIScriptConsoleScene.CommandRegionTemplate.ConsoleInputTemplate'*/,
			UpperConsoleBorder = Default__UIScriptConsoleScene_CommandRegionTemplate_UpperBorderTemplate/*Ref UIImage'Default__UIScriptConsoleScene.CommandRegionTemplate.UpperBorderTemplate'*/,
			LowerConsoleBorder = Default__UIScriptConsoleScene_CommandRegionTemplate_LowerBorderTemplate/*Ref UIImage'Default__UIScriptConsoleScene.CommandRegionTemplate.LowerBorderTemplate'*/,
			BackgroundImageComponent = Default__UIScriptConsoleScene_CommandRegionTemplate_PanelBackgroundTemplate/*Ref UIComp_DrawImage'Default__UIScriptConsoleScene.CommandRegionTemplate.PanelBackgroundTemplate'*/,
			EventProvider = Default__UIScriptConsoleScene_CommandRegionTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.CommandRegionTemplate.WidgetEventComponent'*/,
		}/* Reference: ScriptConsoleEntry'Default__UIScriptConsoleScene.CommandRegionTemplate' */;
		var Default__UIScriptConsoleScene_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScriptConsoleScene.SceneEventComponent' */;
		// Object Offset:0x0044C604
		BufferText = Default__UIScriptConsoleScene_BufferTextTemplate/*Ref UILabel'Default__UIScriptConsoleScene.BufferTextTemplate'*/;
		BufferBackground = Default__UIScriptConsoleScene_BufferBackgroundTemplate/*Ref UIImage'Default__UIScriptConsoleScene.BufferBackgroundTemplate'*/;
		CommandRegion = Default__UIScriptConsoleScene_CommandRegionTemplate/*Ref ScriptConsoleEntry'Default__UIScriptConsoleScene.CommandRegionTemplate'*/;
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
		EventProvider = Default__UIScriptConsoleScene_SceneEventComponent/*Ref UIComp_Event'Default__UIScriptConsoleScene.SceneEventComponent'*/;
	}
}
}