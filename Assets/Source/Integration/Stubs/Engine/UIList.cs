namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIList : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int ResizeBufferPixels = 5;
	
	public enum ECellAutoSizeMode 
	{
		CELLAUTOSIZE_None,
		CELLAUTOSIZE_Uniform,
		CELLAUTOSIZE_Constrain,
		CELLAUTOSIZE_AdjustList,
		CELLAUTOSIZE_MAX
	};
	
	public enum ECellLinkType 
	{
		LINKED_None,
		LINKED_Rows,
		LINKED_Columns,
		LINKED_MAX
	};
	
	public enum EListWrapBehavior 
	{
		LISTWRAP_None,
		LISTWRAP_Smooth,
		LISTWRAP_Jump,
		LISTWRAP_MAX
	};
	
	public partial struct /*native transient */CellHitDetectionInfo
	{
		public /*init */int HitColumn;
		public /*init */int HitRow;
		public /*init */int ResizeColumn;
		public /*init */int ResizeRow;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041F13F
	//		HitColumn = 0;
	//		HitRow = 0;
	//		ResizeColumn = 0;
	//		ResizeRow = 0;
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent RowHeight;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent MinColumnSize;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent ColumnWidth;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent HeaderCellPadding;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent HeaderElementSpacing;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent CellSpacing;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent CellPadding;
	public /*transient */int Index;
	public /*transient */int TopIndex;
	public/*(Presentation)*/ /*duplicatetransient editconst transient */int MaxVisibleItems;
	public/*(List)*/ /*protected */int ColumnCount;
	public/*(List)*/ /*protected */int RowCount;
	public/*(List)*/ UIList.ECellAutoSizeMode ColumnAutoSizeMode;
	public/*(List)*/ UIList.ECellAutoSizeMode RowAutoSizeMode;
	public/*(List)*/ UIList.ECellLinkType CellLinkType;
	public/*(Presentation)*/ UIList.EListWrapBehavior WrapType;
	public/*(List)*/ bool bEnableMultiSelect;
	public/*(List)*/ bool bEnableVerticalScrollbar;
	public /*transient */bool bInitializeScrollbars;
	public/*(List)*/ bool bAllowDisabledItemSelection;
	public/*(List)*/ bool bSingleClickSubmission;
	public/*(List)*/ /*private */bool bUpdateItemUnderCursor;
	public/*(List)*/ /*private */bool bHoverStateOverridesSelected;
	public/*(List)*/ bool bAllowColumnResizing;
	public/*(Debug)*/ /*transient */bool bDisplayDataBindings;
	public /*const transient */bool bSortingList;
	public UIScrollbar VerticalScrollbar;
	public StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/ GlobalCellStyle;
	public UIRoot.UIStyleReference ColumnHeaderStyle;
	public StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EColumnHeaderState.COLUMNHEADER_MAX]*/ ColumnHeaderBackgroundStyle;
	public StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/ ItemOverlayStyle;
	public /*const transient */int ResizeColumn;
	public /*private transient */int SetIndexMutex;
	public /*private transient */int ValueChangeNotificationMutex;
	public/*(Data)*/ UIRoot.UIDataStoreBinding DataSource;
	public /*const transient */UIListElementProvider DataProvider;
	public /*const transient */array<int> Items;
	public /*transient */array<int> SelectedItems;
	public/*(Presentation)*/ /*export editinline */UIComp_ListElementSorter SortComponent;
	public/*(Data)*/ /*export editinline */UIComp_ListPresenter CellDataComponent;
	public/*(Sound)*/ name SubmitDataSuccessCue;
	public/*(Sound)*/ name SubmitDataFailedCue;
	public/*(Sound)*/ name DecrementIndexCue;
	public/*(Sound)*/ name IncrementIndexCue;
	public/*(Sound)*/ name SortAscendingCue;
	public/*(Sound)*/ name SortDescendingCue;
	public /*delegate*/UIList.OnSubmitSelection __OnSubmitSelection__Delegate;
	public /*delegate*/UIList.OnListElementsSorted __OnListElementsSorted__Delegate;
	
	public delegate void OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default);
	
	public delegate void OnListElementsSorted(UIList Sender);
	
	// Export UUIList::execScrollVertical(FFrame&, void* const)
	public virtual /*native final function */bool ScrollVertical(UIScrollbar Sender, float PositionChange, /*optional */bool? _bPositionMaxed = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execRemoveElement(FFrame&, void* const)
	public virtual /*native function */int RemoveElement(int ElementToRemove)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetItemCount(FFrame&, void* const)
	public virtual /*native function */int GetItemCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetMaxVisibleElementCount(FFrame&, void* const)
	public virtual /*native function */int GetMaxVisibleElementCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetMaxNumVisibleRows(FFrame&, void* const)
	public virtual /*native final function */int GetMaxNumVisibleRows()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetMaxNumVisibleColumns(FFrame&, void* const)
	public virtual /*native final function */int GetMaxNumVisibleColumns()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetTotalRowCount(FFrame&, void* const)
	public virtual /*native final function */int GetTotalRowCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetTotalColumnCount(FFrame&, void* const)
	public virtual /*native final function */int GetTotalColumnCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execSetColumnCount(FFrame&, void* const)
	public virtual /*native final function */void SetColumnCount(int NewColumnCount)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execSetRowCount(FFrame&, void* const)
	public virtual /*native final function */void SetRowCount(int NewRowCount)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execGetColumnWidth(FFrame&, void* const)
	public virtual /*native final function */float GetColumnWidth(/*optional */int? _ColumnIndex = default, /*optional */bool? _bColHeader = default, /*optional */bool? _bReturnUnformattedValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetRowHeight(FFrame&, void* const)
	public virtual /*native function */float GetRowHeight(/*optional */int? _RowIndex = default, /*optional */bool? _bColHeader = default, /*optional */bool? _bReturnUnformattedValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetClientRegion(FFrame&, void* const)
	public virtual /*native function */Object.Vector2D GetClientRegion()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execCalculateIndexFromCursorLocation(FFrame&, void* const)
	public virtual /*native function */int CalculateIndexFromCursorLocation(/*optional */bool? _bRequireValidIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetResizeColumn(FFrame&, void* const)
	public virtual /*native function */int GetResizeColumn(/*const optional */ref UIList.CellHitDetectionInfo ClickedCell/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetSelectedItems(FFrame&, void* const)
	public virtual /*native final function */array<int> GetSelectedItems()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetCurrentItem(FFrame&, void* const)
	public virtual /*native final function */int GetCurrentItem()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execGetElementValue(FFrame&, void* const)
	public virtual /*native final function */String GetElementValue(int ElementIndex, /*optional */int? _CellIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execFindItemIndex(FFrame&, void* const)
	public virtual /*native final function */int FindItemIndex(String ItemValue, /*optional */int? _CellIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execSetIndex(FFrame&, void* const)
	public virtual /*native final function */bool SetIndex(int NewIndex, /*optional */bool? _bClampValue = default, /*optional */bool? _bSkipNotification = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execSetTopIndex(FFrame&, void* const)
	public virtual /*native final function */bool SetTopIndex(int NewTopIndex, /*optional */bool? _bClampValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execIsElementEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsElementEnabled(int ElementIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execCanSelectElement(FFrame&, void* const)
	public virtual /*native final function */bool CanSelectElement(int ElementIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execSetHotTracking(FFrame&, void* const)
	public virtual /*native final function */void SetHotTracking(bool bShouldUpdateItemUnderCursor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execIsHotTrackingEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsHotTrackingEnabled()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIList::execIsElementAutoSizingEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsElementAutoSizingEnabled()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIList::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*protected final function */void OnSetListIndex(UIAction_SetListIndex Action)
	{
		// stub
	}
	
	public virtual /*function */void OnGetTextValue(UIAction_GetTextValue Action)
	{
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
	
	public virtual /*final event */bool AllMutexesDisabled()
	{
		// stub
		return default;
	}
	
	public virtual /*final event */void IncrementAllMutexes()
	{
		// stub
	}
	
	public virtual /*final event */void DecrementAllMutexes(/*optional */bool? _bDispatchUpdates = default)
	{
		// stub
	}
	
	public virtual /*final event */void EnableSetIndex()
	{
		// stub
	}
	
	public virtual /*final event */void DisableSetIndex()
	{
		// stub
	}
	
	public virtual /*final event */bool IsSetIndexEnabled()
	{
		// stub
		return default;
	}
	
	public virtual /*final event */void EnableValueChangeNotification()
	{
		// stub
	}
	
	public virtual /*final event */void DisableValueChangeNotification()
	{
		// stub
	}
	
	public virtual /*final event */bool IsValueChangeNotificationEnabled()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void EnableColumnHeaderRendering(/*optional */bool? _bShouldRenderColHeaders = default)
	{
		// stub
	}
	
	public virtual /*final function */bool ShouldRenderColumnHeaders()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ClickedScrollZone(UIScrollbar Sender, float PositionPerc, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*final function */void OnStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	// Export UUIList::execClearCellBinding(FFrame&, void* const)
	public virtual /*native function */bool ClearCellBinding()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public UIList()
	{
		var Default__UIList_ListPresentationComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIList.ListPresentationComponent.NormalOverlayTemplate' */;
		var Default__UIList_ListPresentationComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIList.ListPresentationComponent.ActiveOverlayTemplate' */;
		var Default__UIList_ListPresentationComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIList.ListPresentationComponent.SelectionOverlayTemplate' */;
		var Default__UIList_ListPresentationComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIList.ListPresentationComponent.HoverOverlayTemplate' */;
		var Default__UIList_ListPresentationComponent = new UIComp_ListPresenter
		{
			// Object Offset:0x004228AB
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__UIList_ListPresentationComponent_NormalOverlayTemplate/*Ref UITexture'Default__UIList.ListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = Default__UIList_ListPresentationComponent_ActiveOverlayTemplate/*Ref UITexture'Default__UIList.ListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = Default__UIList_ListPresentationComponent_SelectionOverlayTemplate/*Ref UITexture'Default__UIList.ListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = Default__UIList_ListPresentationComponent_HoverOverlayTemplate/*Ref UITexture'Default__UIList.ListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: UIComp_ListPresenter'Default__UIList.ListPresentationComponent' */;
		var Default__UIList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIList.WidgetEventComponent' */;
		// Object Offset:0x00421280
		RowHeight = new UIRoot.UIScreenValue_Extent
		{
			Value = 16.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		MinColumnSize = new UIRoot.UIScreenValue_Extent
		{
			Value = 0.50f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		ColumnWidth = new UIRoot.UIScreenValue_Extent
		{
			Value = 100.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		Index = -1;
		TopIndex = -1;
		ColumnCount = 1;
		RowCount = 4;
		ColumnAutoSizeMode = UIList.ECellAutoSizeMode.CELLAUTOSIZE_Uniform;
		RowAutoSizeMode = UIList.ECellAutoSizeMode.CELLAUTOSIZE_Constrain;
		CellLinkType = UIList.ECellLinkType.LINKED_Columns;
		bEnableVerticalScrollbar = true;
		bInitializeScrollbars = true;
		bAllowColumnResizing = true;
		GlobalCellStyle = new StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultCellStyleNormal",
				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[1] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultCellStyleActive",
				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[2] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultCellStyleSelected",
				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[3] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultCellStyleHover",
				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
	 	};
		ColumnHeaderStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultColumnHeaderStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
		ColumnHeaderBackgroundStyle = new StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EColumnHeaderState.COLUMNHEADER_MAX]*/()
		{ 
			[0] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"None",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[1] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"None",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[2] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"None",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
	 	};
		ItemOverlayStyle = new StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ListItemBackgroundNormalStyle",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[1] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ListItemBackgroundActiveStyle",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[2] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ListItemBackgroundSelectedStyle",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
			[3] = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ListItemBackgroundHoverStyle",
				RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
				AssignedStyleID = new UIRoot.STYLE_ID
				{
					A = 0,
					B = 0,
					C = 0,
					D = 0,
				},
				ResolvedStyle = default,
			},
	 	};
		ResizeColumn = -1;
		DataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Collection,
			MarkupString = "",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		CellDataComponent = Default__UIList_ListPresentationComponent/*Ref UIComp_ListPresenter'Default__UIList.ListPresentationComponent'*/;
		SubmitDataSuccessCue = (name)"ListSubmit";
		SubmitDataFailedCue = (name)"GenericError";
		DecrementIndexCue = (name)"ListUp";
		IncrementIndexCue = (name)"ListDown";
		SortAscendingCue = (name)"SortAscending";
		SortDescendingCue = (name)"SortDescending";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultListStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		PrivateFlags = 1024;
		bSupportsPrimaryStyle = false;
		DebugBoundsColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__UIList_WidgetEventComponent/*Ref UIComp_Event'Default__UIList.WidgetEventComponent'*/;
		__NotifyActiveStateChanged__Delegate = (Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState) => OnStateChanged(Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState);
	}
}
}