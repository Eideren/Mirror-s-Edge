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
		// stub
	}
	
	public override /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		// stub
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void SetupDockingLinks()
	{
		// stub
	}
	
	public virtual /*function */void SetValue(String NewValue)
	{
		// stub
	}
	
	public ConsoleEntry()
	{
		var Default__ConsoleEntry_ConsolePromptTemplate_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__ConsoleEntry.ConsolePromptTemplate.LabelStringRenderer' */;
		var Default__ConsoleEntry_ConsolePromptTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__ConsoleEntry.ConsolePromptTemplate.WidgetEventComponent' */;
		var Default__ConsoleEntry_ConsolePromptTemplate = new UILabel
		{
			// Object Offset:0x005D3302
			DataSource = new UIRoot.UIDataStoreBinding
			{
				MarkupString = "(> ",
			},
			StringRenderComponent = Default__ConsoleEntry_ConsolePromptTemplate_LabelStringRenderer/*Ref UIComp_DrawString'Default__ConsoleEntry.ConsolePromptTemplate.LabelStringRenderer'*/,
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
			EventProvider = Default__ConsoleEntry_ConsolePromptTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__ConsoleEntry.ConsolePromptTemplate.WidgetEventComponent'*/,
		}/* Reference: UILabel'Default__ConsoleEntry.ConsolePromptTemplate' */;
		var Default__ConsoleEntry_ConsolePromptBackgroundTemplate_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate.ImageComponentTemplate' */;
		var Default__ConsoleEntry_ConsolePromptBackgroundTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__ConsoleEntry.ConsolePromptBackgroundTemplate.WidgetEventComponent' */;
		var Default__ConsoleEntry_ConsolePromptBackgroundTemplate = new UIImage
		{
			// Object Offset:0x005D2F06
			ImageComponent = Default__ConsoleEntry_ConsolePromptBackgroundTemplate_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate.ImageComponentTemplate'*/,
			WidgetTag = (name)"ConsoleBackground",
			TabIndex = 1,
			EventProvider = Default__ConsoleEntry_ConsolePromptBackgroundTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__ConsoleEntry.ConsolePromptBackgroundTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate' */;
		var Default__ConsoleEntry_InputBoxTemplate_EditboxStringRenderer = new UIComp_DrawStringEditbox
		{
		}/* Reference: UIComp_DrawStringEditbox'Default__ConsoleEntry.InputBoxTemplate.EditboxStringRenderer' */;
		var Default__ConsoleEntry_InputBoxTemplate_EditboxBackgroundTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__ConsoleEntry.InputBoxTemplate.EditboxBackgroundTemplate' */;
		var Default__ConsoleEntry_InputBoxTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__ConsoleEntry.InputBoxTemplate.WidgetEventComponent' */;
		var Default__ConsoleEntry_InputBoxTemplate = new UIEditBox
		{
			// Object Offset:0x005D283E
			StringRenderComponent = Default__ConsoleEntry_InputBoxTemplate_EditboxStringRenderer/*Ref UIComp_DrawStringEditbox'Default__ConsoleEntry.InputBoxTemplate.EditboxStringRenderer'*/,
			BackgroundImageComponent = Default__ConsoleEntry_InputBoxTemplate_EditboxBackgroundTemplate/*Ref UIComp_DrawImage'Default__ConsoleEntry.InputBoxTemplate.EditboxBackgroundTemplate'*/,
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
			EventProvider = Default__ConsoleEntry_InputBoxTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__ConsoleEntry.InputBoxTemplate.WidgetEventComponent'*/,
		}/* Reference: UIEditBox'Default__ConsoleEntry.InputBoxTemplate' */;
		var Default__ConsoleEntry_LowerConsoleBorderTemplate_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__ConsoleEntry.LowerConsoleBorderTemplate.ImageComponentTemplate' */;
		var Default__ConsoleEntry_LowerConsoleBorderTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__ConsoleEntry.LowerConsoleBorderTemplate.WidgetEventComponent' */;
		var Default__ConsoleEntry_LowerConsoleBorderTemplate = new UIImage
		{
			// Object Offset:0x005D2F86
			ImageComponent = Default__ConsoleEntry_LowerConsoleBorderTemplate_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__ConsoleEntry.LowerConsoleBorderTemplate.ImageComponentTemplate'*/,
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
			EventProvider = Default__ConsoleEntry_LowerConsoleBorderTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__ConsoleEntry.LowerConsoleBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ConsoleEntry.LowerConsoleBorderTemplate' */;
		var Default__ConsoleEntry_UpperConsoleBorderTemplate_ImageComponentTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__ConsoleEntry.UpperConsoleBorderTemplate.ImageComponentTemplate' */;
		var Default__ConsoleEntry_UpperConsoleBorderTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__ConsoleEntry.UpperConsoleBorderTemplate.WidgetEventComponent' */;
		var Default__ConsoleEntry_UpperConsoleBorderTemplate = new UIImage
		{
			// Object Offset:0x005D306A
			ImageComponent = Default__ConsoleEntry_UpperConsoleBorderTemplate_ImageComponentTemplate/*Ref UIComp_DrawImage'Default__ConsoleEntry.UpperConsoleBorderTemplate.ImageComponentTemplate'*/,
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
			EventProvider = Default__ConsoleEntry_UpperConsoleBorderTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__ConsoleEntry.UpperConsoleBorderTemplate.WidgetEventComponent'*/,
		}/* Reference: UIImage'Default__ConsoleEntry.UpperConsoleBorderTemplate' */;
		var Default__ConsoleEntry_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__ConsoleEntry.WidgetEventComponent' */;
		// Object Offset:0x002E3309
		ConsolePromptLabel = Default__ConsoleEntry_ConsolePromptTemplate/*Ref UILabel'Default__ConsoleEntry.ConsolePromptTemplate'*/;
		ConsolePromptBackground = Default__ConsoleEntry_ConsolePromptBackgroundTemplate/*Ref UIImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate'*/;
		InputBox = Default__ConsoleEntry_InputBoxTemplate/*Ref UIEditBox'Default__ConsoleEntry.InputBoxTemplate'*/;
		LowerConsoleBorder = Default__ConsoleEntry_LowerConsoleBorderTemplate/*Ref UIImage'Default__ConsoleEntry.LowerConsoleBorderTemplate'*/;
		UpperConsoleBorder = Default__ConsoleEntry_UpperConsoleBorderTemplate/*Ref UIImage'Default__ConsoleEntry.UpperConsoleBorderTemplate'*/;
		WidgetTag = (name)"ConsoleEntry";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"ConsoleStyle",
		};
		bSupportsPrimaryStyle = false;
		Children = new array<UIObject>
		{
			Default__ConsoleEntry_InputBoxTemplate/*Ref UIEditBox'Default__ConsoleEntry.InputBoxTemplate'*/,
			Default__ConsoleEntry_ConsolePromptBackgroundTemplate/*Ref UIImage'Default__ConsoleEntry.ConsolePromptBackgroundTemplate'*/,
			Default__ConsoleEntry_ConsolePromptTemplate/*Ref UILabel'Default__ConsoleEntry.ConsolePromptTemplate'*/,
			Default__ConsoleEntry_LowerConsoleBorderTemplate/*Ref UIImage'Default__ConsoleEntry.LowerConsoleBorderTemplate'*/,
			Default__ConsoleEntry_UpperConsoleBorderTemplate/*Ref UIImage'Default__ConsoleEntry.UpperConsoleBorderTemplate'*/,
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
		};
		EventProvider = Default__ConsoleEntry_WidgetEventComponent/*Ref UIComp_Event'Default__ConsoleEntry.WidgetEventComponent'*/;
	}
}
}