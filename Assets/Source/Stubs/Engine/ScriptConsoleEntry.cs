namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ScriptConsoleEntry : UIPanel/*
		hidecategories(Object,UIRoot,Object)*/{
	public const string ConsolePromptText = "(> ";
	
	public /*export editinline */UIEditBox InputBox;
	public /*export editinline */UIImage UpperConsoleBorder;
	public /*export editinline */UIImage LowerConsoleBorder;
	
	public override /*event */void Initialized()
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void SetValue(String NewValue)
	{
	
	}
	
	public virtual /*function */void OnCreateChild(UIObject CreatedWidget, UIScreenObject CreatorContainer)
	{
	
	}
	
	public ScriptConsoleEntry()
	{
		// Object Offset:0x003B4FEF
		InputBox = new UIEditBox
		{
			// Object Offset:0x004CE6F2
			DataSource = new UIRoot.UIDataStoreBinding
			{
				MarkupString = "(> ",
			},
			StringRenderComponent = LoadAsset<UIComp_DrawStringEditbox>("Default__ScriptConsoleEntry.ConsoleInputTemplate.EditboxStringRenderer")/*Ref UIComp_DrawStringEditbox'Default__ScriptConsoleEntry.ConsoleInputTemplate.EditboxStringRenderer'*/,
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__ScriptConsoleEntry.ConsoleInputTemplate.EditboxBackgroundTemplate")/*Ref UIComp_DrawImage'Default__ScriptConsoleEntry.ConsoleInputTemplate.EditboxBackgroundTemplate'*/,
			WidgetTag = (name)"InputBox",
			PrimaryStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleStyle",
			},
			__OnCreate__Delegate = (CreatedWidget, CreatorContainer) => OnCreateChild(CreatedWidget, CreatorContainer),
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[3] = 16.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[3] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__ScriptConsoleEntry.ConsoleInputTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ScriptConsoleEntry.ConsoleInputTemplate.WidgetEventComponent'*/,
		}/* Reference: UIEditBox'Default__ScriptConsoleEntry.ConsoleInputTemplate' */;
		UpperConsoleBorder = new UIImage
		{
			// Object Offset:0x004CE8BA
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__ScriptConsoleEntry.UpperBorderTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__ScriptConsoleEntry.UpperBorderTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"UpperConsoleBorder",
			PrimaryStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleImageStyle",
			},
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = 1.0f,
					[3] = 2.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__ScriptConsoleEntry.UpperBorderTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ScriptConsoleEntry.UpperBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ScriptConsoleEntry.UpperBorderTemplate' */;
		LowerConsoleBorder = new UIImage
		{
			// Object Offset:0x004CE9E6
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__ScriptConsoleEntry.LowerBorderTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__ScriptConsoleEntry.LowerBorderTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"LowerConsoleBorder",
			PrimaryStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleImageStyle",
			},
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = 1.0f,
					[3] = 2.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__ScriptConsoleEntry.LowerBorderTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ScriptConsoleEntry.LowerBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ScriptConsoleEntry.LowerBorderTemplate' */;
		BackgroundImageComponent = new UIComp_DrawImage
		{
			// Object Offset:0x004CEB12
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ConsoleBackgroundStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__ScriptConsoleEntry.PanelBackgroundTemplate' */;
		WidgetTag = (name)"ConsoleInputBox";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"ConsoleStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__ScriptConsoleEntry.WidgetEventComponent")/*Ref UIComp_Event'Default__ScriptConsoleEntry.WidgetEventComponent'*/;
	}
}
}