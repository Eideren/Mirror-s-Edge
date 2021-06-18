namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScrollbar : UIObject/*
		native
		hidecategories(Object,UIRoot,Object,Object,UIScreenObject,UIObject,Focus,Presentation,Splitscreen,States)*/{
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public /*private const */UIScrollbarButton IncrementButton;
	public /*private const */UIScrollbarButton DecrementButton;
	public /*private const */UIScrollbarMarkerButton MarkerButton;
	public /*private */UIRoot.UIStyleReference IncrementStyle;
	public /*private */UIRoot.UIStyleReference DecrementStyle;
	public /*private */UIRoot.UIStyleReference MarkerStyle;
	public /*private transient */float NudgeValue;
	public/*()*/ float NudgeMultiplier;
	public /*private transient */float NudgePercent;
	public /*private transient */float MarkerPosPercent;
	public /*private transient */float MarkerSizePercent;
	public/*()*/ UIRoot.UIScreenValue_Extent BarWidth;
	public/*()*/ UIRoot.UIScreenValue_Extent MinimumMarkerSize;
	public/*()*/ UIRoot.UIScreenValue_Extent ButtonsExtent;
	public/*()*/ UIRoot.EUIOrientation ScrollbarOrientation;
	public/*()*/ bool bAddCornerPadding;
	public /*private transient */bool bInitializeMarker;
	public /*transient */UIRoot.UIScreenValue_Position MousePosition;
	public /*private transient */float MousePositionDelta;
	public /*delegate*/UIScrollbar.OnScrollActivity __OnScrollActivity__Delegate;
	public /*delegate*/UIScrollbar.OnClickedScrollZone __OnClickedScrollZone__Delegate;
	
	public delegate bool OnScrollActivity(UIScrollbar Sender, float PositionChange, /*optional */bool? _bPositionMaxed = default);
	
	public delegate void OnClickedScrollZone(UIScrollbar Sender, float PositionPerc, int PlayerIndex);
	
	// Export UUIScrollbar::execGetMarkerButtonPosition(FFrame&, void* const)
	public virtual /*native final function */float GetMarkerButtonPosition()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScrollbar::execGetScrollZoneExtent(FFrame&, void* const)
	public virtual /*native final function */float GetScrollZoneExtent(/*optional */ref float ScrollZoneStart/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScrollbar::execGetScrollZoneWidth(FFrame&, void* const)
	public virtual /*native final function */float GetScrollZoneWidth()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIScrollbar::execSetMarkerSize(FFrame&, void* const)
	public virtual /*native final function */void SetMarkerSize(float SizePercentage)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execSetMarkerPosition(FFrame&, void* const)
	public virtual /*native final function */void SetMarkerPosition(float PositionPercentage)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execSetNudgeSizePercent(FFrame&, void* const)
	public virtual /*native final function */void SetNudgeSizePercent(float NudgePercentage)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execSetNudgeSizePixels(FFrame&, void* const)
	public virtual /*native final function */void SetNudgeSizePixels(float NudgePixels)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execEnableCornerPadding(FFrame&, void* const)
	public virtual /*native final function */void EnableCornerPadding(bool FlagValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execScrollIncrement(FFrame&, void* const)
	public virtual /*native final function */void ScrollIncrement(UIScreenObject Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execScrollDecrement(FFrame&, void* const)
	public virtual /*native final function */void ScrollDecrement(UIScreenObject Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execDragScrollBegin(FFrame&, void* const)
	public virtual /*native final function */void DragScrollBegin(UIScreenObject Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execDragScrollEnd(FFrame&, void* const)
	public virtual /*native final function */void DragScrollEnd(UIScreenObject Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIScrollbar::execDragScroll(FFrame&, void* const)
	public virtual /*native final function */void DragScroll(UIScrollbarMarkerButton Sender, int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void Initialized()
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*final function */float GetNudgeValue()
	{
	
		return default;
	}
	
	public virtual /*final function */float GetNudgePercent()
	{
	
		return default;
	}
	
	public virtual /*final function */float GetMarkerPosPercent()
	{
	
		return default;
	}
	
	public virtual /*final function */float GetMarkerSizePercent()
	{
	
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
		// Object Offset:0x0044D76D
		BackgroundImageComponent = Default__UIScrollbar_ScrollBarBackgroundImageTemplate;
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UIScrollbar.WidgetEventComponent")/*Ref UIComp_Event'Default__UIScrollbar.WidgetEventComponent'*/;
	}
}
}