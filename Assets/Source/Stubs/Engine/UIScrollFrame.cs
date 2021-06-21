namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIScrollFrame : UIContainer/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Image)*/ /*const export editinline */UIComp_DrawImage StaticBackgroundImage;
	public /*private duplicatetransient const */UIScrollbar ScrollbarHorizontal;
	public /*private duplicatetransient const */UIScrollbar ScrollbarVertical;
	public/*()*/ /*private editconst editinline transient */UIRoot.UIScreenValue_Extent HorizontalClientRegion;
	public/*()*/ /*private editconst editinline transient */UIRoot.UIScreenValue_Extent VerticalClientRegion;
	public /*private transient */Object.Vector2D ClientRegionPosition;
	public /*private transient */StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ FrameBounds;
	public /*private const transient */bool bRefreshScrollbars;
	public /*private const transient */bool bRecalculateClientRegion;
	
	// Export UUIScrollFrame::execRefreshScrollbars(FFrame&, void* const)
	public virtual /*native final function */void RefreshScrollbars(/*optional */bool? _bImmediately = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIScrollFrame::execReapplyFormatting(FFrame&, void* const)
	public virtual /*native final function */void ReapplyFormatting(/*optional */bool? _bImmediately = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIScrollFrame::execScrollRegion(FFrame&, void* const)
	public virtual /*native final function */bool ScrollRegion(UIScrollbar Sender, float PositionChange, /*optional */bool? _bPositionMaxed = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execSetClientRegionPosition(FFrame&, void* const)
	public virtual /*native final function */bool SetClientRegionPosition(UIRoot.EUIOrientation Orientation, float NewPosition)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execSetClientRegionPositionVector(FFrame&, void* const)
	public virtual /*native final function */bool SetClientRegionPositionVector(Object.Vector2D NewPosition)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execGetClientRegionPosition(FFrame&, void* const)
	public virtual /*native final function */float GetClientRegionPosition(UIRoot.EUIOrientation Orientation)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execGetClientRegionSize(FFrame&, void* const)
	public virtual /*native final function */float GetClientRegionSize(UIRoot.EUIOrientation Orientation)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execGetClientRegionPositionVector(FFrame&, void* const)
	public virtual /*native final function */Object.Vector2D GetClientRegionPositionVector()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execGetClientRegionSizeVector(FFrame&, void* const)
	public virtual /*native final function */Object.Vector2D GetClientRegionSizeVector()
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIScrollFrame::execGetClipRegion(FFrame&, void* const)
	public virtual /*native function */void GetClipRegion(ref float MinX, ref float MinY, ref float MaxX, ref float MaxY)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIScrollFrame::execGetVisibleRegionPercentage(FFrame&, void* const)
	public virtual /*native final function */float GetVisibleRegionPercentage(UIRoot.EUIOrientation Orientation)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
		// stub
	}
	
	public override /*event */void RemovedChild(UIScreenObject WidgetOwner, UIObject OldChild, /*optional */array<UIObject>? _ExclusionSet = default)
	{
		// stub
	}
	
	public virtual /*final function */void OnChildRepositioned(UIScreenObject Sender)
	{
		// stub
	}
	
	public virtual /*private final event */void ScrollZoneClicked(UIScrollbar Sender, float PositionPerc, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnApplyScrolling(UIAction_ApplyScrolling Action)
	{
		// stub
	}
	
	public UIScrollFrame()
	{
		var Default__UIScrollFrame_HorzScrollbarTemplate_ScrollBarBackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScrollFrame.HorzScrollbarTemplate.ScrollBarBackgroundImageTemplate' */;
		var Default__UIScrollFrame_HorzScrollbarTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScrollFrame.HorzScrollbarTemplate.WidgetEventComponent' */;
		var Default__UIScrollFrame_HorzScrollbarTemplate = new UIScrollbar
		{
			// Object Offset:0x005D3652
			BackgroundImageComponent = Default__UIScrollFrame_HorzScrollbarTemplate_ScrollBarBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIScrollFrame.HorzScrollbarTemplate.ScrollBarBackgroundImageTemplate'*/,
			ScrollbarOrientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
			__OnScrollActivity__Delegate = (Sender, PositionChange, bPositionMaxed) => ScrollRegion(Sender, PositionChange, bPositionMaxed),
			__OnClickedScrollZone__Delegate = (Sender, PositionPerc, PlayerIndex) => ScrollZoneClicked(Sender, PositionPerc, PlayerIndex),
			PrivateFlags = 970,
			bHidden = true,
			EventProvider = Default__UIScrollFrame_HorzScrollbarTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScrollFrame.HorzScrollbarTemplate.WidgetEventComponent'*/,
		}/* Reference: UIScrollbar'Default__UIScrollFrame.HorzScrollbarTemplate' */;
		var Default__UIScrollFrame_VertScrollbarTemplate_ScrollBarBackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIScrollFrame.VertScrollbarTemplate.ScrollBarBackgroundImageTemplate' */;
		var Default__UIScrollFrame_VertScrollbarTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScrollFrame.VertScrollbarTemplate.WidgetEventComponent' */;
		var Default__UIScrollFrame_VertScrollbarTemplate = new UIScrollbar
		{
			// Object Offset:0x005D3736
			BackgroundImageComponent = Default__UIScrollFrame_VertScrollbarTemplate_ScrollBarBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIScrollFrame.VertScrollbarTemplate.ScrollBarBackgroundImageTemplate'*/,
			__OnScrollActivity__Delegate = (Sender, PositionChange, bPositionMaxed) => ScrollRegion(Sender, PositionChange, bPositionMaxed),
			__OnClickedScrollZone__Delegate = (Sender, PositionPerc, PlayerIndex) => ScrollZoneClicked(Sender, PositionPerc, PlayerIndex),
			PrivateFlags = 970,
			bHidden = true,
			EventProvider = Default__UIScrollFrame_VertScrollbarTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIScrollFrame.VertScrollbarTemplate.WidgetEventComponent'*/,
		}/* Reference: UIScrollbar'Default__UIScrollFrame.VertScrollbarTemplate' */;
		var Default__UIScrollFrame_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIScrollFrame.WidgetEventComponent' */;
		// Object Offset:0x0044F49F
		ScrollbarHorizontal = Default__UIScrollFrame_HorzScrollbarTemplate/*Ref UIScrollbar'Default__UIScrollFrame.HorzScrollbarTemplate'*/;
		ScrollbarVertical = Default__UIScrollFrame_VertScrollbarTemplate/*Ref UIScrollbar'Default__UIScrollFrame.VertScrollbarTemplate'*/;
		VerticalClientRegion = new UIRoot.UIScreenValue_Extent
		{
			Value = 0.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
		};
		bRefreshScrollbars = true;
		bRecalculateClientRegion = true;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultImageStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		bSupportsPrimaryStyle = false;
		EventProvider = Default__UIScrollFrame_WidgetEventComponent/*Ref UIComp_Event'Default__UIScrollFrame.WidgetEventComponent'*/;
	}
}
}