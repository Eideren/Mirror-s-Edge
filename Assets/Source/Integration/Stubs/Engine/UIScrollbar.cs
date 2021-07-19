namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScrollbar : UIObject/*
		native
		hidecategories(Object,UIRoot,Object,Object,UIScreenObject,UIObject,Focus,Presentation,Splitscreen,States)*/{
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage BackgroundImageComponent;
	[Const] public/*private*/ UIScrollbarButton IncrementButton;
	[Const] public/*private*/ UIScrollbarButton DecrementButton;
	[Const] public/*private*/ UIScrollbarMarkerButton MarkerButton;
	public/*private*/ UIRoot.UIStyleReference IncrementStyle;
	public/*private*/ UIRoot.UIStyleReference DecrementStyle;
	public/*private*/ UIRoot.UIStyleReference MarkerStyle;
	[transient] public/*private*/ float NudgeValue;
	[Category] public float NudgeMultiplier;
	[transient] public/*private*/ float NudgePercent;
	[transient] public/*private*/ float MarkerPosPercent;
	[transient] public/*private*/ float MarkerSizePercent;
	[Category] public UIRoot.UIScreenValue_Extent BarWidth;
	[Category] public UIRoot.UIScreenValue_Extent MinimumMarkerSize;
	[Category] public UIRoot.UIScreenValue_Extent ButtonsExtent;
	[Category] public UIRoot.EUIOrientation ScrollbarOrientation;
	[Category] public bool bAddCornerPadding;
	[transient] public/*private*/ bool bInitializeMarker;
	[transient] public UIRoot.UIScreenValue_Position MousePosition;
	[transient] public/*private*/ float MousePositionDelta;
	public /*delegate*/UIScrollbar.OnScrollActivity __OnScrollActivity__Delegate;
	public /*delegate*/UIScrollbar.OnClickedScrollZone __OnClickedScrollZone__Delegate;
	
	public delegate bool OnScrollActivity(UIScrollbar Sender, float PositionChange, /*optional */bool? _bPositionMaxed = default);
	
	public delegate void OnClickedScrollZone(UIScrollbar Sender, float PositionPerc, int PlayerIndex);
	
	// Export UUIScrollbar::execGetMarkerButtonPosition(FFrame&, void* const)
	public virtual /*native final function */float GetMarkerButtonPosition()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScrollbar::execGetScrollZoneExtent(FFrame&, void* const)
	public virtual /*native final function */float GetScrollZoneExtent(/*optional */ref float ScrollZoneStart/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScrollbar::execGetScrollZoneWidth(FFrame&, void* const)
	public virtual /*native final function */float GetScrollZoneWidth()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIScrollbar::execSetMarkerSize(FFrame&, void* const)
	public virtual /*native final function */void SetMarkerSize(float SizePercentage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execSetMarkerPosition(FFrame&, void* const)
	public virtual /*native final function */void SetMarkerPosition(float PositionPercentage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execSetNudgeSizePercent(FFrame&, void* const)
	public virtual /*native final function */void SetNudgeSizePercent(float NudgePercentage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execSetNudgeSizePixels(FFrame&, void* const)
	public virtual /*native final function */void SetNudgeSizePixels(float NudgePixels)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execEnableCornerPadding(FFrame&, void* const)
	public virtual /*native final function */void EnableCornerPadding(bool FlagValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execScrollIncrement(FFrame&, void* const)
	public virtual /*native final function */void ScrollIncrement(UIScreenObject Sender, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execScrollDecrement(FFrame&, void* const)
	public virtual /*native final function */void ScrollDecrement(UIScreenObject Sender, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execDragScrollBegin(FFrame&, void* const)
	public virtual /*native final function */void DragScrollBegin(UIScreenObject Sender, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execDragScrollEnd(FFrame&, void* const)
	public virtual /*native final function */void DragScrollEnd(UIScreenObject Sender, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIScrollbar::execDragScroll(FFrame&, void* const)
	public virtual /*native final function */void DragScroll(UIScrollbarMarkerButton Sender, int PlayerIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*final function */float GetNudgeValue()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */float GetNudgePercent()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */float GetMarkerPosPercent()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */float GetMarkerSizePercent()
	{
		// stub
		return default;
	}
	
	public UIScrollbar()
	{
		var Default__UIScrollbar_ScrollBarBackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1BBA
			StyleResolverTag = (name)"Background Image Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultScrollZoneStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UIScrollbar.ScrollBarBackgroundImageTemplate' */;
		var Default__UIScrollbar_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScrollbar.WidgetEventComponent' */;
		// Object Offset:0x0044D76D
		BackgroundImageComponent = Default__UIScrollbar_ScrollBarBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIScrollbar.ScrollBarBackgroundImageTemplate'*/;
		IncrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultIncrementButtonStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		DecrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultDecrementButtonStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		MarkerStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultScrollBarStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		NudgeValue = 1.0f;
		NudgeMultiplier = 1.0f;
		MarkerSizePercent = 1.0f;
		BarWidth = new UIRoot.UIScreenValue_Extent
		{
			Value = 16.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		MinimumMarkerSize = new UIRoot.UIScreenValue_Extent
		{
			Value = 12.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
		};
		ButtonsExtent = new UIRoot.UIScreenValue_Extent
		{
			Value = 16.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
		};
		ScrollbarOrientation = UIRoot.EUIOrientation.UIORIENT_Vertical;
		bAddCornerPadding = true;
		bInitializeMarker = true;
		MousePosition = new UIRoot.UIScreenValue_Position
		{
			Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = 0.0f,
				[1] = 0.0f,
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
			},
		};
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultScrollZoneStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		PrivateFlags = 1044;
		bSupportsPrimaryStyle = false;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Pressed>(),
			ClassT<UIState_Active>(),
		};
		EventProvider = Default__UIScrollbar_WidgetEventComponent/*Ref UIComp_Event'Default__UIScrollbar.WidgetEventComponent'*/;
	}
}
}