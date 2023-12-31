namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIRoot : Object/*
		abstract
		native
		hidecategories(Object,UIRoot)*/{
	public const int TEMP_SPLITSCREEN_INDEX = 0;
	public const int PRIVATE_NotEditorSelectable = 0x001;
	public const int PRIVATE_TreeHidden = 0x002;
	public const int PRIVATE_NotFocusable = 0x004;
	public const int PRIVATE_NotDockable = 0x008;
	public const int PRIVATE_NotRotatable = 0x010;
	public const int PRIVATE_ManagedStyle = 0x020;
	public const int PRIVATE_TreeHiddenRecursive = 0x042;
	public const int PRIVATE_EditorNoDelete = 0x080;
	public const int PRIVATE_EditorNoRename = 0x100;
	public const int PRIVATE_EditorNoReparent = 0x200;
	public const int PRIVATE_PropagateState = 0x400;
	public const int PRIVATE_KeepFocusedState = 0x800;
	public const int PRIVATE_Protected = 0x380;
	public const double ASPECTRATIO_Normal = 1.333333f;
	public const double ASPECTRATIO_Monitor = 1.25f;
	public const double ASPECTRATIO_Widescreen = 1.777778f;
	public const int DEFAULT_SIZE_X = 1024;
	public const int DEFAULT_SIZE_Y = 768;
	public const string SCENE_DATASTORE_TAG = "SceneData";
	public const int MAX_SUPPORTED_GAMEPADS = 4;
	
	public enum EMaterialAdjustmentType 
	{
		ADJUST_None,
		ADJUST_Normal,
		ADJUST_Justified,
		ADJUST_Bound,
		ADJUST_Stretch,
		ADJUST_MAX
	};
	
	public enum EPositionEvalType 
	{
		EVALPOS_None,
		EVALPOS_PixelViewport,
		EVALPOS_PixelScene,
		EVALPOS_PixelOwner,
		EVALPOS_PercentageViewport,
		EVALPOS_PercentageOwner,
		EVALPOS_PercentageScene,
		EVALPOS_MAX
	};
	
	public enum EUIExtentEvalType 
	{
		UIEXTENTEVAL_Pixels,
		UIEXTENTEVAL_PercentSelf,
		UIEXTENTEVAL_PercentOwner,
		UIEXTENTEVAL_PercentScene,
		UIEXTENTEVAL_PercentViewport,
		UIEXTENTEVAL_MAX
	};
	
	public enum EUIDockPaddingEvalType 
	{
		UIPADDINGEVAL_Pixels,
		UIPADDINGEVAL_PercentTarget,
		UIPADDINGEVAL_PercentOwner,
		UIPADDINGEVAL_PercentScene,
		UIPADDINGEVAL_PercentViewport,
		UIPADDINGEVAL_MAX
	};
	
	public enum EUIAutoSizeConstraintType 
	{
		UIAUTOSIZEREGION_Minimum,
		UIAUTOSIZEREGION_Maximum,
		UIAUTOSIZEREGION_MAX
	};
	
	public enum ETextClipMode 
	{
		CLIP_None,
		CLIP_Normal,
		CLIP_Ellipsis,
		CLIP_Wrap,
		CLIP_MAX
	};
	
	public enum ETextAutoScaleMode 
	{
		UIAUTOSCALE_None,
		UIAUTOSCALE_Normal,
		UIAUTOSCALE_Justified,
		UIAUTOSCALE_ResolutionBased,
		UIAUTOSCALE_MAX
	};
	
	public enum EUIAlignment 
	{
		UIALIGN_Left,
		UIALIGN_Center,
		UIALIGN_Right,
		UIALIGN_Default,
		UIALIGN_MAX
	};
	
	public enum EUIListElementState 
	{
		ELEMENT_Normal,
		ELEMENT_Active,
		ELEMENT_Selected,
		ELEMENT_UnderCursor,
		ELEMENT_MAX
	};
	
	public enum EColumnHeaderState 
	{
		COLUMNHEADER_Normal,
		COLUMNHEADER_PrimarySort,
		COLUMNHEADER_SecondarySort,
		COLUMNHEADER_MAX
	};
	
	public enum EUIOrientation 
	{
		UIORIENT_Horizontal,
		UIORIENT_Vertical,
		UIORIENT_MAX
	};
	
	public enum EUIWidgetFace 
	{
		UIFACE_Left,
		UIFACE_Top,
		UIFACE_Right,
		UIFACE_Bottom,
		UIFACE_MAX
	};
	
	public enum EUIAspectRatioConstraint 
	{
		UIASPECTRATIO_AdjustNone,
		UIASPECTRATIO_AdjustWidth,
		UIASPECTRATIO_AdjustHeight,
		UIASPECTRATIO_MAX
	};
	
	public enum EUIDefaultPenColor 
	{
		UIPEN_White,
		UIPEN_Black,
		UIPEN_Grey,
		UIPEN_MAX
	};
	
	public enum ENavigationLinkType 
	{
		NAVLINK_Automatic,
		NAVLINK_Manual,
		NAVLINK_MAX
	};
	
	public enum EScreenInputMode 
	{
		INPUTMODE_None,
		INPUTMODE_Locked,
		INPUTMODE_MatchingOnly,
		INPUTMODE_ActiveOnly,
		INPUTMODE_Free,
		INPUTMODE_Simultaneous,
		INPUTMODE_MAX
	};
	
	public enum ESplitscreenRenderMode 
	{
		SPLITRENDER_Fullscreen,
		SPLITRENDER_PlayerOwner,
		SPLITRENDER_MAX
	};
	
	public enum EUIDataProviderFieldType 
	{
		DATATYPE_Property,
		DATATYPE_Provider,
		DATATYPE_RangeProperty,
		DATATYPE_Collection,
		DATATYPE_ProviderCollection,
		DATATYPE_MAX
	};
	
	public enum ERotationAnchor 
	{
		RA_Absolute,
		RA_Center,
		RA_PivotLeft,
		RA_PivotRight,
		RA_PivotTop,
		RA_PivotBottom,
		RA_UpperLeft,
		RA_UpperRight,
		RA_LowerLeft,
		RA_LowerRight,
		RA_MAX
	};
	
	public partial struct /*native atomic */WIDGET_ID// extends Guid
	{
		public int A;
		public int B;
		public int C;
		public int D;
			// Object Offset:0x0001D60F
	//		A = 0;
	//		B = 0;
	//		C = 0;
	//		D = 0;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native atomic */STYLE_ID// extends Guid
	{
		public int A;
		public int B;
		public int C;
		public int D;
			// Object Offset:0x0001D60F
	//		A = 0;
	//		B = 0;
	//		C = 0;
	//		D = 0;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */UIRangeData
	{
		[Category("Range")] public float CurrentValue;
		[Category("Range")] public float MinValue;
		[Category("Range")] public float MaxValue;
		[Category("Range")] public float NudgeValue;
		[Category("Range")] public bool bIntRange;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BD974
	//		CurrentValue = 0.0f;
	//		MinValue = 0.0f;
	//		MaxValue = 0.0f;
	//		NudgeValue = 0.0f;
	//		bIntRange = false;
	//	}
	};
	
	public partial struct /*native */UIProviderScriptFieldValue
	{
		[Const] public name PropertyTag;
		public UIRoot.EUIDataProviderFieldType PropertyType;
		public String StringValue;
		public Surface ImageValue;
		public array<int> ArrayValue;
		public UIRoot.UIRangeData RangeValue;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BDB7C
	//		PropertyTag = (name)"None";
	//		PropertyType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property;
	//		StringValue = "";
	//		ImageValue = default;
	//		ArrayValue = default;
	//		RangeValue = new UIRoot.UIRangeData
	//		{
	//			CurrentValue = 0.0f,
	//			MinValue = 0.0f,
	//			MaxValue = 0.0f,
	//			NudgeValue = 0.0f,
	//			bIntRange = false,
	//		};
	//	}
	};
	
	public partial struct /*native */UIProviderFieldValue// extends UIProviderScriptFieldValue
	{
		[Const] public name PropertyTag;
		public UIRoot.EUIDataProviderFieldType PropertyType;
		public String StringValue;
		public Surface ImageValue;
		public array<int> ArrayValue;
		public UIRoot.UIRangeData RangeValue;
	
		[native, Const, transient] public Object.Pointer CustomStringNode;
			// Object Offset:0x002BDB7C
	//		PropertyTag = (name)"None";
	//		PropertyType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property;
	//		StringValue = "";
	//		ImageValue = default;
	//		ArrayValue = default;
	//		RangeValue = new UIRoot.UIRangeData
	//		{
	//			CurrentValue = 0.0f,
	//			MinValue = 0.0f,
	//			MaxValue = 0.0f,
	//			NudgeValue = 0.0f,
	//			bIntRange = false,
	//		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */UIStyleReference
	{
		public name DefaultStyleTag;
		[Const] public Core.ClassT<UIStyle_Data> RequiredStyleClass;
		[Const] public UIRoot.STYLE_ID AssignedStyleID;
		[Const, transient] public UIStyle ResolvedStyle;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BDE24
	//		DefaultStyleTag = (name)"None";
	//		RequiredStyleClass = default;
	//		AssignedStyleID = new UIRoot.STYLE_ID
	//		{
	//			A = 0,
	//			B = 0,
	//			C = 0,
	//			D = 0,
	//		};
	//		ResolvedStyle = default;
	//	}
	};
	
	public partial struct /*native */UIScreenValue
	{
		[Category] public float Value;
		[Category] public UIRoot.EPositionEvalType ScaleType;
		[Category] public UIRoot.EUIOrientation Orientation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE04F
	//		Value = 0.0f;
	//		ScaleType = UIRoot.EPositionEvalType.EVALPOS_PixelViewport;
	//		Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal;
	//	}
	};
	
	public partial struct /*native */UIScreenValue_Extent
	{
		[Category] public float Value;
		[Category] public UIRoot.EUIExtentEvalType ScaleType;
		[Category] public UIRoot.EUIOrientation Orientation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE16F
	//		Value = 0.0f;
	//		ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels;
	//		Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal;
	//	}
	};
	
	public partial struct /*native */UIScreenValue_Position
	{
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Value;
		[Category] public StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ ScaleType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE25F
	//		Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//			[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	// 		};
	//	}
	};
	
	public partial struct /*native */UIScreenValue_Bounds
	{
		[Category] [editconst] public StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ Value;
		[Category] [editconst] public StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ ScaleType;
		[transient] public StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ bInvalidated;
		[Category] public UIRoot.EUIAspectRatioConstraint AspectRatioMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE3CB
	//		Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 1.0f,
	//			[3] = 1.0f,
	// 		};
	//		ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
	//			[1] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
	//			[2] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
	//			[3] = UIRoot.EPositionEvalType.EVALPOS_PercentageOwner,
	// 		};
	//		bInvalidated = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 1,
	//			[1] = 1,
	//			[2] = 1,
	//			[3] = 1,
	// 		};
	//		AspectRatioMode = UIRoot.EUIAspectRatioConstraint.UIASPECTRATIO_AdjustNone;
	//	}
	};
	
	public partial struct /*native */UIAnchorPosition// extends UIScreenValue_Position
	{
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Value;
		[Category] public StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ ScaleType;
	
		[Category] public float ZDepth;
			// Object Offset:0x002BE25F
	//		Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//			[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	// 		};
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE5A3
	//		ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EPositionEvalType.EVALPOS_None,
	//			[1] = UIRoot.EPositionEvalType.EVALPOS_None,
	// 		};
	//	}
	};
	
	public partial struct /*native */ScreenPositionRange// extends UIScreenValue_Position
	{
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Value;
		[Category] public StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ ScaleType;
			// Object Offset:0x002BE25F
	//		Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//			[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	// 		};
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE61B
	//		ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EPositionEvalType.EVALPOS_None,
	//			[1] = UIRoot.EPositionEvalType.EVALPOS_None,
	// 		};
	//	}
	};
	
	public partial struct /*native */UIScreenValue_DockPadding
	{
		[Category] [editconst] public StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ PaddingValue;
		[Category] [editconst] public StaticArray<UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ PaddingScaleType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE6EF
	//		PaddingValue = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 0.0f,
	//			[3] = 0.0f,
	// 		};
	//		PaddingScaleType = new StaticArray<UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//			[1] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//			[2] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//			[3] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	// 		};
	//	}
	};
	
	public partial struct /*native */UIScreenValue_AutoSizeRegion
	{
		[Category] public StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/ Value;
		[Category] public StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/ EvalType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE873
	//		Value = new StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		EvalType = new StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	//			[1] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	// 		};
	//	}
	};
	
	public partial struct /*native */AutoSizePadding// extends UIScreenValue_AutoSizeRegion
	{
		[Category] public StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/ Value;
		[Category] public StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/ EvalType;
			// Object Offset:0x002BE873
	//		Value = new StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		EvalType = new StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	//			[1] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	// 		};
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */AutoSizeData
	{
		[Category] public UIRoot.UIScreenValue_AutoSizeRegion Extent;
		[Category] public UIRoot.AutoSizePadding Padding;
		[Category] public bool bAutoSizeEnabled;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BE9E7
	//		Extent = new UIRoot.UIScreenValue_AutoSizeRegion
	//		{
	//			Value = new StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			EvalType = new StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	//				[1] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	//			},
	//		};
	//		Padding = new UIRoot.AutoSizePadding
	//		{
	//			Value = new StaticArray<float, float>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			EvalType = new StaticArray<UIRoot.EUIExtentEvalType, UIRoot.EUIExtentEvalType>/*[UIRoot.EUIAutoSizeConstraintType.UIAUTOSIZEREGION_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	//				[1] = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
	//			},
	//		};
	//		bAutoSizeEnabled = false;
	//	}
	};
	
	public partial struct /*native */UIRenderingSubregion
	{
		[Category] public UIRoot.UIScreenValue_Extent ClampRegionSize;
		[Category] public UIRoot.UIScreenValue_Extent ClampRegionOffset;
		[Category] public UIRoot.EUIAlignment ClampRegionAlignment;
		[Category] public bool bSubregionEnabled;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BEC37
	//		ClampRegionSize = new UIRoot.UIScreenValue_Extent
	//		{
	//			Value = 1.0f,
	//			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentSelf,
	//			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
	//		};
	//		ClampRegionOffset = new UIRoot.UIScreenValue_Extent
	//		{
	//			Value = 0.0f,
	//			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentSelf,
	//			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
	//		};
	//		ClampRegionAlignment = UIRoot.EUIAlignment.UIALIGN_Default;
	//		bSubregionEnabled = false;
	//	}
	};
	
	public partial struct /*native transient */InputEventSubscription
	{
		[init] public name KeyName;
		[init] public array<UIScreenObject> Subscribers;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BEE3F
	//		KeyName = (name)"None";
	//		Subscribers = default;
	//	}
	};
	
	public partial struct /*native */DefaultEventSpecification
	{
		public UIEvent EventTemplate;
		public Core.ClassT<UIState> EventState;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BEF17
	//		EventTemplate = default;
	//		EventState = default;
	//	}
	};
	
	public partial struct /*native */InputKeyAction
	{
		[Category] public name InputKeyName;
		[Category] public Object.EInputEvent InputKeyState;
		[Category] public array<SequenceAction> ActionsToExecute;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BF043
	//		InputKeyName = (name)"None";
	//		InputKeyState = Object.EInputEvent.IE_Released;
	//		ActionsToExecute = default;
	//	}
	};
	
	public partial struct /*native */StateInputKeyAction// extends InputKeyAction
	{
		[Category] public name InputKeyName;
		[Category] public Object.EInputEvent InputKeyState;
		[Category] public array<SequenceAction> ActionsToExecute;
	
		[Category] public Core.ClassT<UIState> Scope;
			// Object Offset:0x002BF043
	//		InputKeyName = (name)"None";
	//		InputKeyState = Object.EInputEvent.IE_Released;
	//		ActionsToExecute = default;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BF10B
	//		Scope = ClassT<UIState_Enabled>()/*Ref Class'UIState_Enabled'*/;
	//		InputKeyState = Object.EInputEvent.IE_Pressed;
	//	}
	};
	
	public partial struct /*native transient */PlayerInteractionData
	{
		[init, transient] public UIObject FocusedControl;
		[init, transient] public UIObject LastFocusedControl;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BF1DF
	//		FocusedControl = default;
	//		LastFocusedControl = default;
	//	}
	};
	
	public partial struct /*native */UIFocusPropagationData
	{
		[Category] [Const, editconst, transient] public UIObject FirstFocusTarget;
		[Category] [Const, editconst, transient] public UIObject LastFocusTarget;
		[Category] [Const, editconst, transient] public UIObject NextFocusTarget;
		[Category] [Const, editconst, transient] public UIObject PrevFocusTarget;
		[transient] public bool bPendingReceiveFocus;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BF33B
	//		FirstFocusTarget = default;
	//		LastFocusTarget = default;
	//		NextFocusTarget = default;
	//		PrevFocusTarget = default;
	//		bPendingReceiveFocus = false;
	//	}
	};
	
	public partial struct /*native */UINavigationData
	{
		[Category] [editconst, transient] public StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ NavigationTarget;
		[Category] [editconst] public StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ ForcedNavigationTarget;
		[Category] public StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ bNullOverride;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BF48F
	//		NavigationTarget = new StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = default,
	//			[1] = default,
	//			[2] = default,
	//			[3] = default,
	// 		};
	//		ForcedNavigationTarget = new StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = default,
	//			[1] = default,
	//			[2] = default,
	//			[3] = default,
	// 		};
	//		bNullOverride = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0,
	//			[1] = 0,
	//			[2] = 0,
	//			[3] = 0,
	// 		};
	//	}
	};
	
	public partial struct /*native */UIDockingSet
	{
		[Const] public UIObject OwnerWidget;
		[Category] [editconst] public/*private*/ StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ TargetWidget;
		[Category] [editconst] public/*private*/ UIRoot.UIScreenValue_DockPadding DockPadding;
		[Category] public bool bLockWidthWhenDocked;
		[Category] public bool bLockHeightWhenDocked;
		[Category] [editconst] public/*private*/ StaticArray<UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ TargetFace;
		[transient] public StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ bResolved;
		[transient] public StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ bLinking;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BF783
	//		OwnerWidget = default;
	//		TargetWidget = new StaticArray<UIObject, UIObject, UIObject, UIObject>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = default,
	//			[1] = default,
	//			[2] = default,
	//			[3] = default,
	// 		};
	//		DockPadding = new UIRoot.UIScreenValue_DockPadding
	//		{
	//			PaddingValue = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//				[2] = 0.0f,
	//				[3] = 0.0f,
	//			},
	//			PaddingScaleType = new StaticArray<UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType, UIRoot.EUIDockPaddingEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//				[1] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//				[2] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//				[3] = UIRoot.EUIDockPaddingEvalType.UIPADDINGEVAL_Pixels,
	//			},
	//		};
	//		bLockWidthWhenDocked = false;
	//		bLockHeightWhenDocked = false;
	//		TargetFace = new StaticArray<UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace, UIRoot.EUIWidgetFace>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = default,
	//			[1] = default,
	//			[2] = default,
	//			[3] = default,
	// 		};
	//		bResolved = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0,
	//			[1] = 0,
	//			[2] = 0,
	//			[3] = 0,
	// 		};
	//		bLinking = new StaticArray<byte, byte, byte, byte>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0,
	//			[1] = 0,
	//			[2] = 0,
	//			[3] = 0,
	// 		};
	//	}
	};
	
	public partial struct /*native */UIDockingNode
	{
		[Category] public UIObject Widget;
		[Category] public UIRoot.EUIWidgetFace Face;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BFB3F
	//		Widget = default;
	//		Face = UIRoot.EUIWidgetFace.UIFACE_Left;
	//	}
	};
	
	public partial struct /*native */UIRotation
	{
		[Category] public Object.Rotator Rotation;
		[transient] public Object.Matrix TransformMatrix;
		[Category] public UIRoot.UIAnchorPosition AnchorPosition;
		[Category] public UIRoot.ERotationAnchor AnchorType;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BFC73
	//		Rotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		TransformMatrix = new Matrix
	//		{
	//			XPlane={X=0.0f,
	//			Y=1.0f,
	//			Z=0.0f,
	//			W=0.0f},
	//			YPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=1.0f,
	//			W=0.0f},
	//			ZPlane={X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=1.0f},
	//			WPlane={X=1.0f,
	//			Y=0.0f,
	//			Z=0.0f,
	//			W=0.0f}
	//		};
	//		AnchorPosition = new UIRoot.UIAnchorPosition
	//		{
	//			ZDepth = 0.0f,
	//			Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//				[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//			},
	//		};
	//		AnchorType = UIRoot.ERotationAnchor.RA_Center;
	//	}
	};
	
	public partial struct /*native */UIDataStoreBinding
	{
		[Const, transient] public UIDataStoreSubscriber Subscriber;
		[Category] [Const, editconst] public UIRoot.EUIDataProviderFieldType RequiredFieldType;
		[Category] [Const] public String MarkupString;
		[Const, transient] public int BindingIndex;
		[Const, transient] public name DataStoreName;
		[Const, transient] public name DataStoreField;
		[Const, transient] public UIDataStore ResolvedDataStore;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002BFF53
	//		Subscriber = default;
	//		RequiredFieldType = default;
	//		MarkupString = "";
	//		BindingIndex = -1;
	//		DataStoreName = (name)"None";
	//		DataStoreField = (name)"None";
	//		ResolvedDataStore = default;
	//	}
	};
	
	public partial struct /*native transient */UIStyleSubscriberReference
	{
		[init] public name SubscriberId;
		[init] public UIStyleResolver Subscriber;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C00B7
	//		SubscriberId = (name)"None";
	//		Subscriber = default;
	//	}
	};
	
	public partial struct /*native transient */StyleReferenceId
	{
		[init] public name StyleReferenceTag;
		[init] public Property StyleProperty;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C0187
	//		StyleReferenceTag = (name)"None";
	//		StyleProperty = default;
	//	}
	};
	
	public partial struct /*native */UITextAttributes
	{
		[Category] public bool Bold;
		[Category] public bool Italic;
		[Category] public bool Underline;
		[Category] public bool Shadow;
		[Category] public bool Strikethrough;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C02D7
	//		Bold = false;
	//		Italic = false;
	//		Underline = false;
	//		Shadow = false;
	//		Strikethrough = false;
	//	}
	};
	
	public partial struct /*native */UIImageAdjustmentData
	{
		[Category] public UIRoot.ScreenPositionRange ProtectedRegion;
		[Category] public UIRoot.EMaterialAdjustmentType AdjustmentType;
		[Category] public UIRoot.EUIAlignment Alignment;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C042B
	//		ProtectedRegion = new UIRoot.ScreenPositionRange
	//		{
	//			Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//				[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//			},
	//		};
	//		AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal;
	//		Alignment = UIRoot.EUIAlignment.UIALIGN_Left;
	//	}
	};
	
	public partial struct /*native */TextureCoordinates
	{
		[Category] public float U;
		[Category] public float V;
		[Category] public float UL;
		[Category] public float VL;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C05F3
	//		U = 0.0f;
	//		V = 0.0f;
	//		UL = 0.0f;
	//		VL = 0.0f;
	//	}
	};
	
	public partial struct /*native */UIStringCaretParameters
	{
		[Category] public bool bDisplayCaret;
		[Category] public UIRoot.EUIDefaultPenColor CaretType;
		[Category] public float CaretWidth;
		[Category] public name CaretStyle;
		[transient] public int CaretPosition;
		[transient] public MaterialInterface CaretMaterial;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C07AB
	//		bDisplayCaret = false;
	//		CaretType = UIRoot.EUIDefaultPenColor.UIPEN_White;
	//		CaretWidth = 1.0f;
	//		CaretStyle = (name)"DefaultCaretStyle";
	//		CaretPosition = 0;
	//		CaretMaterial = default;
	//	}
	};
	
	public partial struct /*native transient */RenderParameters
	{
		[init] public float DrawX;
		[init] public float DrawY;
		[init] public float DrawXL;
		[init] public float DrawYL;
		[init] public Object.Vector2D Scaling;
		[init] public Font DrawFont;
		[init] public StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ TextAlignment;
		[init] public Object.Vector2D ImageExtent;
		[init] public UIRoot.TextureCoordinates DrawCoords;
		[init] public Object.Vector2D SpacingAdjust;
		[init] public float ViewportHeight;
		[init] public bool bForcePixelAlignment;
		[init] public bool bForceRenderColor;
		[init] public Object.LinearColor ForcedColor;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C0B17
	//		DrawX = 0.0f;
	//		DrawY = 0.0f;
	//		DrawXL = 0.0f;
	//		DrawYL = 0.0f;
	//		Scaling = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		DrawFont = default;
	//		TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EUIAlignment.UIALIGN_Left,
	//			[1] = UIRoot.EUIAlignment.UIALIGN_Left,
	// 		};
	//		ImageExtent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		DrawCoords = new UIRoot.TextureCoordinates
	//		{
	//			U = 0.0f,
	//			V = 0.0f,
	//			UL = 0.0f,
	//			VL = 0.0f,
	//		};
	//		SpacingAdjust = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		ViewportHeight = 0.0f;
	//		bForcePixelAlignment = false;
	//		bForceRenderColor = false;
	//		ForcedColor = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//	}
	};
	
	public partial struct /*native */TextAutoScaleValue
	{
		[Category] public float MinScale;
		[Category] public UIRoot.ETextAutoScaleMode AutoScaleMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C0E0B
	//		MinScale = 0.60f;
	//		AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None;
	//	}
	};
	
	public partial struct /*native */UIStyleOverride
	{
		[Category] public Object.LinearColor DrawColor;
		[Category] public float Opacity;
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Padding;
		public bool bOverrideDrawColor;
		public bool bOverrideOpacity;
		public bool bOverridePadding;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C0F8B
	//		DrawColor = new LinearColor
	//		{
	//			R=1.0f,
	//			G=1.0f,
	//			B=1.0f,
	//			A=1.0f
	//		};
	//		Opacity = 1.0f;
	//		Padding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		bOverrideDrawColor = false;
	//		bOverrideOpacity = false;
	//		bOverridePadding = false;
	//	}
	};
	
	public partial struct /*native */UITextStyleOverride// extends UIStyleOverride
	{
		[Category] public Object.LinearColor DrawColor;
		[Category] public float Opacity;
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Padding;
		public bool bOverrideDrawColor;
		public bool bOverrideOpacity;
		public bool bOverridePadding;
	
		[Category] public Font DrawFont;
		[Category] public UIRoot.UITextAttributes TextAttributes;
		[Category] public StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ TextAlignment;
		[Category] public UIRoot.ETextClipMode ClipMode;
		[Category] public UIRoot.EUIAlignment ClipAlignment;
		[Category] public UIRoot.TextAutoScaleValue AutoScaling;
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ DrawScale;
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ SpacingAdjust;
		public bool bOverrideDrawFont;
		public bool bOverrideAttributes;
		public bool bOverrideAlignment;
		public bool bOverrideClipMode;
		public bool bOverrideClipAlignment;
		public bool bOverrideAutoScale;
		public bool bOverrideScale;
		public bool bOverrideSpacingAdjust;
			// Object Offset:0x002C0F8B
	//		DrawColor = new LinearColor
	//		{
	//			R=1.0f,
	//			G=1.0f,
	//			B=1.0f,
	//			A=1.0f
	//		};
	//		Opacity = 1.0f;
	//		Padding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		bOverrideDrawColor = false;
	//		bOverrideOpacity = false;
	//		bOverridePadding = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C1373
	//		AutoScaling = new UIRoot.TextAutoScaleValue
	//		{
	//			MinScale = 0.60f,
	//			AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
	//		};
	//		DrawScale = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 1.0f,
	//			[1] = 1.0f,
	// 		};
	//		DrawColor = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=0.0f
	//		};
	//		Opacity = 0.0f;
	//	}
	};
	
	public partial struct /*native */UIImageStyleOverride// extends UIStyleOverride
	{
		[Category] public Object.LinearColor DrawColor;
		[Category] public float Opacity;
		[Category] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Padding;
		public bool bOverrideDrawColor;
		public bool bOverrideOpacity;
		public bool bOverridePadding;
	
		[Category] public UIRoot.TextureCoordinates Coordinates;
		[Category] public StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ Formatting;
		public bool bOverrideCoordinates;
		public bool bOverrideFormatting;
			// Object Offset:0x002C0F8B
	//		DrawColor = new LinearColor
	//		{
	//			R=1.0f,
	//			G=1.0f,
	//			B=1.0f,
	//			A=1.0f
	//		};
	//		Opacity = 1.0f;
	//		Padding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		bOverrideDrawColor = false;
	//		bOverrideOpacity = false;
	//		bOverridePadding = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C154B
	//		Formatting = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	// 		};
	//		DrawColor = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=0.0f
	//		};
	//		Opacity = 0.0f;
	//	}
	};
	
	public partial struct /*native transient */UICombinedStyleData
	{
		[init] public Object.LinearColor TextColor;
		[init] public Object.LinearColor ImageColor;
		[init] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ TextPadding;
		[init] public StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ ImagePadding;
		[init] public Font DrawFont;
		[init] public Surface FallbackImage;
		[init] public UIRoot.TextureCoordinates AtlasCoords;
		[init] public UIRoot.UITextAttributes TextAttributes;
		[init] public StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ TextAlignment;
		[init] public UIRoot.ETextClipMode TextClipMode;
		[init] public UIRoot.EUIAlignment TextClipAlignment;
		[init] public StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ AdjustmentType;
		[init] public UIRoot.TextAutoScaleValue TextAutoScaling;
		[init] public Object.Vector2D TextScale;
		[init] public Object.Vector2D TextSpacingAdjust;
		[init, Const] public/*private*/ bool bInitialized;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C1AD3
	//		TextColor = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//		ImageColor = new LinearColor
	//		{
	//			R=0.0f,
	//			G=0.0f,
	//			B=0.0f,
	//			A=1.0f
	//		};
	//		TextPadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		ImagePadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	// 		};
	//		DrawFont = default;
	//		FallbackImage = default;
	//		AtlasCoords = new UIRoot.TextureCoordinates
	//		{
	//			U = 0.0f,
	//			V = 0.0f,
	//			UL = 0.0f,
	//			VL = 0.0f,
	//		};
	//		TextAttributes = new UIRoot.UITextAttributes
	//		{
	//			Bold = false,
	//			Italic = false,
	//			Underline = false,
	//			Shadow = false,
	//			Strikethrough = false,
	//		};
	//		TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = UIRoot.EUIAlignment.UIALIGN_Left,
	//			[1] = UIRoot.EUIAlignment.UIALIGN_Left,
	// 		};
	//		TextClipMode = default;
	//		TextClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left;
	//		AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//		{ 
	//			[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	// 		};
	//		TextAutoScaling = new UIRoot.TextAutoScaleValue
	//		{
	//			MinScale = 0.60f,
	//			AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
	//		};
	//		TextScale = new Vector2D
	//		{
	//			X=1.0f,
	//			Y=1.0f
	//		};
	//		TextSpacingAdjust = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		bInitialized = false;
	//	}
	};
	
	public partial struct /*native transient */UIStringNodeModifier
	{
		public partial struct /*native transient */ModifierData
		{
			[init, Const, transient] public UIStyle_Data Style;
			[init, Const, transient] public array<Font> InlineFontStack;
	
	//		structdefaultproperties
	//		{
	//			// Object Offset:0x002C223F
	//			Style = default;
	//			InlineFontStack = default;
	//		}
		};
	
		[init, Const, transient] public UIRoot.UICombinedStyleData CustomStyleData;
		[init, Const, transient] public UIRoot.UICombinedStyleData BaseStyleData;
		[init, Const, transient] public/*private*/ array<UIRoot.UIStringNodeModifier.ModifierData> ModifierStack;
		[init, Const, transient] public/*private*/ UIState CurrentMenuState;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C22AF
	//		CustomStyleData = new UIRoot.UICombinedStyleData
	//		{
	//			TextColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			ImageColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			TextPadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			ImagePadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			DrawFont = default,
	//			FallbackImage = default,
	//			AtlasCoords = new UIRoot.TextureCoordinates
	//			{
	//				U = 0.0f,
	//				V = 0.0f,
	//				UL = 0.0f,
	//				VL = 0.0f,
	//			},
	//			TextAttributes = new UIRoot.UITextAttributes
	//			{
	//				Bold = false,
	//				Italic = false,
	//				Underline = false,
	//				Shadow = false,
	//				Strikethrough = false,
	//			},
	//			TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIAlignment.UIALIGN_Left,
	//				[1] = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			TextClipMode = default,
	//			TextClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//				[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			},
	//			TextAutoScaling = new UIRoot.TextAutoScaleValue
	//			{
	//				MinScale = 0.60f,
	//				AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
	//			},
	//			TextScale = new Vector2D
	//			{
	//				X=1.0f,
	//				Y=1.0f
	//			},
	//			TextSpacingAdjust = new Vector2D
	//			{
	//				X=0.0f,
	//				Y=0.0f
	//			},
	//			bInitialized = false,
	//		};
	//		BaseStyleData = new UIRoot.UICombinedStyleData
	//		{
	//			TextColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			ImageColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			TextPadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			ImagePadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			DrawFont = default,
	//			FallbackImage = default,
	//			AtlasCoords = new UIRoot.TextureCoordinates
	//			{
	//				U = 0.0f,
	//				V = 0.0f,
	//				UL = 0.0f,
	//				VL = 0.0f,
	//			},
	//			TextAttributes = new UIRoot.UITextAttributes
	//			{
	//				Bold = false,
	//				Italic = false,
	//				Underline = false,
	//				Shadow = false,
	//				Strikethrough = false,
	//			},
	//			TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIAlignment.UIALIGN_Left,
	//				[1] = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			TextClipMode = default,
	//			TextClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//				[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			},
	//			TextAutoScaling = new UIRoot.TextAutoScaleValue
	//			{
	//				MinScale = 0.60f,
	//				AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
	//			},
	//			TextScale = new Vector2D
	//			{
	//				X=1.0f,
	//				Y=1.0f
	//			},
	//			TextSpacingAdjust = new Vector2D
	//			{
	//				X=0.0f,
	//				Y=0.0f
	//			},
	//			bInitialized = false,
	//		};
	//		ModifierStack = default;
	//		CurrentMenuState = default;
	//	}
	};
	
	public partial struct /*native transient */UIStringNode
	{
		[init, native, Const, noexport, transient] public Object.Pointer VfTable;
		[init, Const, transient] public UIDataStore NodeDataStore;
		[init, native, Const, transient] public Object.Pointer ParentNode;
		[Category] [init] public String SourceText;
		[Category] [init] public Object.Vector2D Extent;
		[Category] [init] public Object.Vector2D Scaling;
		[init] public bool bForceWrap;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C301F
	//		NodeDataStore = default;
	//		SourceText = "";
	//		Extent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		Scaling = new Vector2D
	//		{
	//			X=1.0f,
	//			Y=1.0f
	//		};
	//		bForceWrap = false;
	//	}
	};
	
	public partial struct /*native transient */UIStringNode_Text// extends UIStringNode
	{
		[init, native, Const, noexport, transient] public Object.Pointer VfTable;
		[init, Const, transient] public UIDataStore NodeDataStore;
		[init, native, Const, transient] public Object.Pointer ParentNode;
		[Category] [init] public String SourceText;
		[Category] [init] public Object.Vector2D Extent;
		[Category] [init] public Object.Vector2D Scaling;
		[init] public bool bForceWrap;
	
		[Category] [init] public String RenderedText;
		[init] public UIRoot.UICombinedStyleData NodeStyleParameters;
			// Object Offset:0x002C301F
	//		NodeDataStore = default;
	//		SourceText = "";
	//		Extent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		Scaling = new Vector2D
	//		{
	//			X=1.0f,
	//			Y=1.0f
	//		};
	//		bForceWrap = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C3157
	//		NodeStyleParameters = new UIRoot.UICombinedStyleData
	//		{
	//			TextColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			ImageColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			TextPadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			ImagePadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			DrawFont = default,
	//			FallbackImage = default,
	//			AtlasCoords = new UIRoot.TextureCoordinates
	//			{
	//				U = 0.0f,
	//				V = 0.0f,
	//				UL = 0.0f,
	//				VL = 0.0f,
	//			},
	//			TextAttributes = new UIRoot.UITextAttributes
	//			{
	//				Bold = false,
	//				Italic = false,
	//				Underline = false,
	//				Shadow = false,
	//				Strikethrough = false,
	//			},
	//			TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIAlignment.UIALIGN_Left,
	//				[1] = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			TextClipMode = default,
	//			TextClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//				[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			},
	//			TextAutoScaling = new UIRoot.TextAutoScaleValue
	//			{
	//				MinScale = 0.60f,
	//				AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
	//			},
	//			TextScale = new Vector2D
	//			{
	//				X=1.0f,
	//				Y=1.0f
	//			},
	//			TextSpacingAdjust = new Vector2D
	//			{
	//				X=0.0f,
	//				Y=0.0f
	//			},
	//			bInitialized = false,
	//		};
	//		Scaling = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native transient */UIStringNode_Image// extends UIStringNode
	{
		[init, native, Const, noexport, transient] public Object.Pointer VfTable;
		[init, Const, transient] public UIDataStore NodeDataStore;
		[init, native, Const, transient] public Object.Pointer ParentNode;
		[Category] [init] public String SourceText;
		[Category] [init] public Object.Vector2D Extent;
		[Category] [init] public Object.Vector2D Scaling;
		[init] public bool bForceWrap;
	
		[Category] [init] public Object.Vector2D ForcedExtent;
		[Category] [init] public UIRoot.TextureCoordinates TexCoords;
		[Category] [init] public UITexture RenderedImage;
			// Object Offset:0x002C301F
	//		NodeDataStore = default;
	//		SourceText = "";
	//		Extent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		Scaling = new Vector2D
	//		{
	//			X=1.0f,
	//			Y=1.0f
	//		};
	//		bForceWrap = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C3823
	//		Scaling = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native transient */UIStringNode_NestedMarkupParent// extends UIStringNode
	{
		[init, native, Const, noexport, transient] public Object.Pointer VfTable;
		[init, Const, transient] public UIDataStore NodeDataStore;
		[init, native, Const, transient] public Object.Pointer ParentNode;
		[Category] [init] public String SourceText;
		[Category] [init] public Object.Vector2D Extent;
		[Category] [init] public Object.Vector2D Scaling;
		[init] public bool bForceWrap;
			// Object Offset:0x002C301F
	//		NodeDataStore = default;
	//		SourceText = "";
	//		Extent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//		Scaling = new Vector2D
	//		{
	//			X=1.0f,
	//			Y=1.0f
	//		};
	//		bForceWrap = false;
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C3883
	//		Scaling = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native transient */UIStringNode_FormattedNodeParent// extends UIStringNode_Text
	{
		[init, native, Const, noexport, transient] public Object.Pointer VfTable;
		[init, Const, transient] public UIDataStore NodeDataStore;
		[init, native, Const, transient] public Object.Pointer ParentNode;
		[Category] [init] public String SourceText;
		[Category] [init] public Object.Vector2D Extent;
		[Category] [init] public Object.Vector2D Scaling;
		[init] public bool bForceWrap;
	
		[Category] [init] public String RenderedText;
		[init] public UIRoot.UICombinedStyleData NodeStyleParameters;
			// Object Offset:0x002C3157
	//		NodeStyleParameters = new UIRoot.UICombinedStyleData
	//		{
	//			TextColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			ImageColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=1.0f
	//			},
	//			TextPadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			ImagePadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = 0.0f,
	//				[1] = 0.0f,
	//			},
	//			DrawFont = default,
	//			FallbackImage = default,
	//			AtlasCoords = new UIRoot.TextureCoordinates
	//			{
	//				U = 0.0f,
	//				V = 0.0f,
	//				UL = 0.0f,
	//				VL = 0.0f,
	//			},
	//			TextAttributes = new UIRoot.UITextAttributes
	//			{
	//				Bold = false,
	//				Italic = false,
	//				Underline = false,
	//				Shadow = false,
	//				Strikethrough = false,
	//			},
	//			TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = UIRoot.EUIAlignment.UIALIGN_Left,
	//				[1] = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			TextClipMode = default,
	//			TextClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//				[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = 0.0f,
	//						[1] = 0.0f,
	//					},
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
	//				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
	//			},
	//			},
	//			TextAutoScaling = new UIRoot.TextAutoScaleValue
	//			{
	//				MinScale = 0.60f,
	//				AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
	//			},
	//			TextScale = new Vector2D
	//			{
	//				X=1.0f,
	//				Y=1.0f
	//			},
	//			TextSpacingAdjust = new Vector2D
	//			{
	//				X=0.0f,
	//				Y=0.0f
	//			},
	//			bInitialized = false,
	//		};
	//		Scaling = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C38E3
	//		NodeStyleParameters = new UIRoot.UICombinedStyleData
	//		{
	//			TextColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=0.0f
	//			},
	//			ImageColor = new LinearColor
	//			{
	//				R=0.0f,
	//				G=0.0f,
	//				B=0.0f,
	//				A=0.0f
	//			},
	//			TextClipMode = UIRoot.ETextClipMode.CLIP_None,
	//			AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//			{
	//				[0] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_None,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_None,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_None,
	//			},
	//				[1] = new UIRoot.UIImageAdjustmentData
	//			{
	//				ProtectedRegion = new UIRoot.ScreenPositionRange
	//				{
	//					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
	//					{
	//						[0] = UIRoot.EPositionEvalType.EVALPOS_None,
	//						[1] = UIRoot.EPositionEvalType.EVALPOS_None,
	//					},
	//				},
	//				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_None,
	//			},
	//			},
	//			TextAutoScaling = new UIRoot.TextAutoScaleValue
	//			{
	//				MinScale = 0.0f,
	//			},
	//			TextScale = new Vector2D
	//			{
	//				X=0.0f,
	//				Y=0.0f
	//			},
	//		};
	//	}
	};
	
	public partial struct /*native transient */WrappedStringElement
	{
		[init] public String Value;
		[init] public Object.Vector2D LineExtent;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C3BEB
	//		Value = "";
	//		LineExtent = new Vector2D
	//		{
	//			X=0.0f,
	//			Y=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native export */UIMouseCursor
	{
		[Category] public name CursorStyle;
		[Category] public UITexture Cursor;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C3CC3
	//		CursorStyle = (name)"None";
	//		Cursor = default;
	//	}
	};
	
	public partial struct /*native transient */InputEventParameters
	{
		[init, Const, transient] public int PlayerIndex;
		[init, Const, transient] public int ControllerId;
		[init, Const, transient] public name InputKeyName;
		[init, Const, transient] public Object.EInputEvent EventType;
		[init, Const, transient] public float InputDelta;
		[init, Const, transient] public float DeltaTime;
		[init, Const, transient] public bool bAltPressed;
		[init, Const, transient] public bool bCtrlPressed;
		[init, Const, transient] public bool bShiftPressed;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C3EC7
	//		PlayerIndex = 0;
	//		ControllerId = 0;
	//		InputKeyName = (name)"None";
	//		EventType = Object.EInputEvent.IE_Pressed;
	//		InputDelta = 0.0f;
	//		DeltaTime = 0.0f;
	//		bAltPressed = false;
	//		bCtrlPressed = false;
	//		bShiftPressed = false;
	//	}
	};
	
	public partial struct /*native transient */SubscribedInputEventParameters// extends InputEventParameters
	{
		[init, Const, transient] public int PlayerIndex;
		[init, Const, transient] public int ControllerId;
		[init, Const, transient] public name InputKeyName;
		[init, Const, transient] public Object.EInputEvent EventType;
		[init, Const, transient] public float InputDelta;
		[init, Const, transient] public float DeltaTime;
		[init, Const, transient] public bool bAltPressed;
		[init, Const, transient] public bool bCtrlPressed;
		[init, Const, transient] public bool bShiftPressed;
	
		[init, Const, transient] public name InputAliasName;
			// Object Offset:0x002C3EC7
	//		PlayerIndex = 0;
	//		ControllerId = 0;
	//		InputKeyName = (name)"None";
	//		EventType = Object.EInputEvent.IE_Pressed;
	//		InputDelta = 0.0f;
	//		DeltaTime = 0.0f;
	//		bAltPressed = false;
	//		bCtrlPressed = false;
	//		bShiftPressed = false;
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */UIAxisEmulationDefinition
	{
		public name AxisInputKey;
		public name AdjacentAxisInputKey;
		public bool bEmulateButtonPress;
		public StaticArray<name, name>/*[2]*/ InputKeyToEmulate;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C4117
	//		AxisInputKey = (name)"None";
	//		AdjacentAxisInputKey = (name)"None";
	//		bEmulateButtonPress = false;
	//		InputKeyToEmulate = new StaticArray<name, name>/*[2]*/()
	//		{ 
	//			[0] = (name)"None",
	//			[1] = (name)"None",
	// 		};
	//	}
	};
	
	public partial struct /*native export */RawInputKeyEventData
	{
		public name InputKeyName;
		public byte ModifierKeyFlags;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C4247
	//		InputKeyName = (name)"None";
	//		ModifierKeyFlags = 56;
	//	}
	};
	
	public partial struct /*native export */UIInputActionAlias
	{
		public name InputAliasName;
		public array<UIRoot.RawInputKeyEventData> LinkedInputKeys;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C4344
	//		InputAliasName = (name)"None";
	//		LinkedInputKeys = default;
	//	}
	};
	
	public partial struct /*native export transient */UIInputAliasValue
	{
		[init] public byte ModifierFlagMask;
		[init] public name InputAliasName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C4414
	//		ModifierFlagMask = 0;
	//		InputAliasName = (name)"None";
	//	}
	};
	
	public partial struct /*native export */UIInputAliasMap
	{
		[native, Const, transient] public Object.MultiMap_Mirror InputAliasLookupTable;
	};
	
	public partial struct /*native export */UIInputAliasStateMap
	{
		public String StateClassName;
		public Core.ClassT<UIState> State;
		public array<UIRoot.UIInputActionAlias> StateInputAliases;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C45AD
	//		StateClassName = "";
	//		State = default;
	//		StateInputAliases = default;
	//	}
	};
	
	public partial struct /*native */UIInputAliasClassMap
	{
		public String WidgetClassName;
		public Core.ClassT<UIScreenObject> WidgetClass;
		public array<UIRoot.UIInputAliasStateMap> WidgetStates;
		[native, Const, transient] public /*map<0,0>*/map<object, object> StateLookupTable;
		[native, Const, transient] public /*map<0,0>*/map<object, object> StateReverseLookupTable;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002C4761
	//		WidgetClassName = "";
	//		WidgetClass = default;
	//		WidgetStates = default;
	//	}
	};
	
	public /*final function */static bool IsConsole(/*optional */WorldInfo.EConsoleType? _ConsoleType = default)
	{
		// stub
		return default;
	}
	
	// Export UUIRoot::execGetCurrentUIController(FFrame&, void* const)
	public /*native final function */static UIInteraction GetCurrentUIController()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIRoot::execGetSceneClient(FFrame&, void* const)
	public /*native final function */static GameUISceneClient GetSceneClient()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIRoot::execGetFaceOrientation(FFrame&, void* const)
	public /*native final function */static UIRoot.EUIOrientation GetFaceOrientation(UIRoot.EUIWidgetFace Face)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIRoot::execGetCursorPosition(FFrame&, void* const)
	public /*native final function */static bool GetCursorPosition(ref int CursorX, ref int CursorY, /*const optional */UIScene _Scene = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIRoot::execGetCursorSize(FFrame&, void* const)
	public /*native final function */static bool GetCursorSize(ref float CursorXL, ref float CursorYL)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIRoot::execSetMouseCaptureOverride(FFrame&, void* const)
	public /*native final function */static void SetMouseCaptureOverride(bool bCaptureMouse)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIRoot::execGetPrimitiveTransform(FFrame&, void* const)
	public /*native final function */static Object.Matrix GetPrimitiveTransform(UIObject Widget, /*optional */bool? _bIncludeAnchorPosition = default, /*optional */bool? _bIncudeRotation = default, /*optional */bool? _bIncludeScale = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIRoot::execSetDataStoreFieldValue(FFrame&, void* const)
	public /*native final function */static bool SetDataStoreFieldValue(String InDataStoreMarkup, /*const */ref UIRoot.UIProviderFieldValue InFieldValue, /*optional */UIScene _OwnerScene = default, /*optional */LocalPlayer _OwnerPlayer = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public /*function */static bool SetDataStoreStringValue(String InDataStoreMarkup, String InStringValue, /*optional */UIScene _OwnerScene = default, /*optional */LocalPlayer _OwnerPlayer = default)
	{
		// stub
		return default;
	}
	
	// Export UUIRoot::execGetDataStoreFieldValue(FFrame&, void* const)
	public /*native final function */static bool GetDataStoreFieldValue(String InDataStoreMarkup, ref UIRoot.UIProviderFieldValue OutFieldValue, /*optional */UIScene _OwnerScene = default, /*optional */LocalPlayer _OwnerPlayer = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public /*function */static bool GetDataStoreStringValue(String InDataStoreMarkup, ref String OutStringValue, /*optional */UIScene _OwnerScene = default, /*optional */LocalPlayer _OwnerPlayer = default)
	{
		// stub
		return default;
	}
	
	public /*final function */static String ConvertWidgetIDToString(UIObject SourceWidget)
	{
		// stub
		return default;
	}
	
}
}