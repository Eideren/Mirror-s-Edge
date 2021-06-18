namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ConsoleEntry : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const string ConsolePromptText = "(> ";
	
	public UILabel ConsolePromptLabel;
	public UIImage ConsolePromptBackground;
	public UIEditBox InputBox;
	public UIImage LowerConsoleBorder;
	public UIImage UpperConsoleBorder;
	public /*transient */int CursorPosition;
	public/*()*/ bool bRenderCursor;
	
	public override /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
	
	}
	
	public override /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void SetupDockingLinks()
	{
	
	}
	
	public virtual /*function */void SetValue(String NewValue)
	{
	
	}
	
	public ConsoleEntry()
	{
		var Default__ConsoleEntry_ConsolePromptTemplate = new UILabel
		{
			// Object Offset:0x005D3302
			DataSource = new UIRoot.UIDataStoreBinding
			{
				MarkupString = "(> ",
			},
			StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__ConsoleEntry.ConsolePromptTemplate.LabelStringRenderer")/*Ref UIComp_DrawString'Default__ConsoleEntry.ConsolePromptTemplate.LabelStringRenderer'*/,
			WidgetTag = (name)"ConsolePrompt",
			TabIndex = 2,
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[2] = 20.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__ConsoleEntry.ConsolePromptTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ConsoleEntry.ConsolePromptTemplate.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__ConsoleEntry.ConsolePromptTemplate' */;
		var Default__ConsoleEntry_ConsolePromptBackgroundTemplate = new UIImage
		{
			// Object Offset:0x005D2F06
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__ConsoleEntry.ConsolePromptBackgroundTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"ConsoleBackground",
			TabIndex = 1,
			EventProvider = LoadAsset<UIComp_Event>("Default__ConsoleEntry.ConsolePromptBackgroundTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ConsoleEntry.ConsolePromptBackgroundTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate' */;
		var Default__ConsoleEntry_InputBoxTemplate = new UIEditBox
		{
			// Object Offset:0x005D283E
			StringRenderComponent = LoadAsset<UIComp_DrawStringEditbox>("Default__ConsoleEntry.InputBoxTemplate.EditboxStringRenderer")/*Ref UIComp_DrawStringEditbox'Default__ConsoleEntry.InputBoxTemplate.EditboxStringRenderer'*/,
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__ConsoleEntry.InputBoxTemplate.EditboxBackgroundTemplate")/*Ref UIComp_DrawImage'Default__ConsoleEntry.InputBoxTemplate.EditboxBackgroundTemplate'*/,
			WidgetTag = (name)"InputBox",
			TabIndex = 0,
			Position = new UIRoot.UIScreenValue_Bounds
			{
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[1] = UIRoot.EPositionEvalType.EVALPOS_PixelViewport,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__ConsoleEntry.InputBoxTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ConsoleEntry.InputBoxTemplate.WidgetEventComponent'*/,
		}/* Reference: UIEditBox'Default__ConsoleEntry.InputBoxTemplate' */;
		var Default__ConsoleEntry_LowerConsoleBorderTemplate = new UIImage
		{
			// Object Offset:0x005D2F86
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__ConsoleEntry.LowerConsoleBorderTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__ConsoleEntry.LowerConsoleBorderTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"LowerConsoleBorder",
			TabIndex = 3,
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
			EventProvider = LoadAsset<UIComp_Event>("Default__ConsoleEntry.LowerConsoleBorderTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ConsoleEntry.LowerConsoleBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ConsoleEntry.LowerConsoleBorderTemplate' */;
		var Default__ConsoleEntry_UpperConsoleBorderTemplate = new UIImage
		{
			// Object Offset:0x005D306A
			ImageComponent = LoadAsset<UIComp_DrawImage>("Default__ConsoleEntry.UpperConsoleBorderTemplate.ImageComponentTemplate")/*Ref UIComp_DrawImage'Default__ConsoleEntry.UpperConsoleBorderTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"UpperConsoleBorder",
			TabIndex = 4,
			DockTargets = new UIRoot.UIDockingSet
			{
				bLockHeightWhenDocked = true,
			},
			Position = new UIRoot.UIScreenValue_Bounds
			{
				Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[1] = 2.0f,
					[2] = 1.0f,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
				ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
				{
					[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
					[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
					#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
				},
			},
			EventProvider = LoadAsset<UIComp_Event>("Default__ConsoleEntry.UpperConsoleBorderTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__ConsoleEntry.UpperConsoleBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ConsoleEntry.UpperConsoleBorderTemplate' */;
		// Object Offset:0x002E3309
		ConsolePromptLabel = Default__ConsoleEntry_ConsolePromptTemplate;
		ConsolePromptBackground = Default__ConsoleEntry_ConsolePromptBackgroundTemplate;
		InputBox = Default__ConsoleEntry_InputBoxTemplate;
		LowerConsoleBorder = Default__ConsoleEntry_LowerConsoleBorderTemplate;
		UpperConsoleBorder = Default__ConsoleEntry_UpperConsoleBorderTemplate;
		WidgetTag = (name)"ConsoleEntry";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"ConsoleStyle",
		};
		bSupportsPrimaryStyle = false;
		Children = new array<UIObject>
		{
			Default__ConsoleEntry_InputBoxTemplate,
			Default__ConsoleEntry_ConsolePromptBackgroundTemplate,
			Default__ConsoleEntry_ConsolePromptTemplate,
			Default__ConsoleEntry_LowerConsoleBorderTemplate,
			Default__ConsoleEntry_UpperConsoleBorderTemplate,
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__ConsoleEntry.WidgetEventComponent")/*Ref UIComp_Event'Default__ConsoleEntry.WidgetEventComponent'*/;
	}
}
}