namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIContextMenu : UIList/*
		native
		hidecategories(Object,UIRoot,Object,List)*/{
	public enum EContextMenuItemType 
	{
		CMIT_Normal,
		CMIT_Submenu,
		CMIT_Separator,
		CMIT_Check,
		CMIT_Radio,
		CMIT_MAX
	};
	
	public partial struct /*native transient */ContextMenuItem
	{
		public /*init const transient */UIContextMenu OwnerMenu;
		public /*init native const transient */Object.Pointer ParentItem;
		public /*init */UIContextMenu.EContextMenuItemType ItemType;
		public /*init */String ItemText;
		public /*init */int ItemId;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00422A93
	//		OwnerMenu = default;
	//		ItemType = UIContextMenu.EContextMenuItemType.CMIT_Normal;
	//		ItemText = "";
	//		ItemId = -1;
	//	}
	};
	
	public /*const transient */UIObject InvokingWidget;
	public /*const transient */array<UIContextMenu.ContextMenuItem> MenuItems;
	public /*const transient */bool bResolvePosition;
	
	// Export UUIContextMenu::execIsActiveContextMenu(FFrame&, void* const)
	public virtual /*native final function */bool IsActiveContextMenu()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIContextMenu::execOpen(FFrame&, void* const)
	public virtual /*native final function */bool Open(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIContextMenu::execClose(FFrame&, void* const)
	public virtual /*native final function */bool Close(/*optional */int? _PlayerIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*event */bool SetMenuItems(UIObject Widget, array<String> NewMenuItems, /*optional */bool? _bClearExisting = default, /*optional */int? _InsertIndex = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool InsertMenuItem(UIObject Widget, String Item, /*optional */int? _InsertIndex = default, /*optional */bool? _bAllowDuplicates = default)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool ClearMenuItems(UIObject Widget)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool RemoveMenuItem(UIObject Widget, String ItemToRemove)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool RemoveMenuItemAtIndex(UIObject Widget, int IndexToRemove)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool GetAllMenuItems(UIObject Widget, ref array<String> out_MenuItems)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool GetMenuItem(UIObject Widget, int IndexToGet, ref String out_MenuItem)
	{
		// stub
		return default;
	}
	
	public virtual /*event */int FindMenuItemIndex(UIObject Widget, String ItemToFind)
	{
		// stub
		return default;
	}
	
	public UIContextMenu()
	{
		var Default__UIContextMenu_ContextMenuDataComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIContextMenu.ContextMenuDataComponent.NormalOverlayTemplate' */;
		var Default__UIContextMenu_ContextMenuDataComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIContextMenu.ContextMenuDataComponent.ActiveOverlayTemplate' */;
		var Default__UIContextMenu_ContextMenuDataComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIContextMenu.ContextMenuDataComponent.SelectionOverlayTemplate' */;
		var Default__UIContextMenu_ContextMenuDataComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIContextMenu.ContextMenuDataComponent.HoverOverlayTemplate' */;
		var Default__UIContextMenu_ContextMenuDataComponent = new UIComp_ContextMenuListPresenter
		{
			// Object Offset:0x005D12D2
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__UIContextMenu_ContextMenuDataComponent_NormalOverlayTemplate/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.NormalOverlayTemplate'*/,
				[1] = Default__UIContextMenu_ContextMenuDataComponent_ActiveOverlayTemplate/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.ActiveOverlayTemplate'*/,
				[2] = Default__UIContextMenu_ContextMenuDataComponent_SelectionOverlayTemplate/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.SelectionOverlayTemplate'*/,
				[3] = Default__UIContextMenu_ContextMenuDataComponent_HoverOverlayTemplate/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: UIComp_ContextMenuListPresenter'Default__UIContextMenu.ContextMenuDataComponent' */;
		var Default__UIContextMenu_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIContextMenu.WidgetEventComponent' */;
		// Object Offset:0x00424006
		ColumnAutoSizeMode = UIList.ECellAutoSizeMode.CELLAUTOSIZE_AdjustList;
		RowAutoSizeMode = UIList.ECellAutoSizeMode.CELLAUTOSIZE_AdjustList;
		WrapType = UIList.EListWrapBehavior.LISTWRAP_Jump;
		bEnableVerticalScrollbar = false;
		bInitializeScrollbars = false;
		bSingleClickSubmission = true;
		bUpdateItemUnderCursor = true;
		CellDataComponent = Default__UIContextMenu_ContextMenuDataComponent/*Ref UIComp_ContextMenuListPresenter'Default__UIContextMenu.ContextMenuDataComponent'*/;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultContextMenuStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		bEnableActiveCursorUpdates = true;
		bSupportsPrimaryStyle = true;
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = 16.0f,
				[3] = 100.0f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[0] = UIRoot.EPositionEvalType.EVALPOS_PixelViewport,
				[1] = UIRoot.EPositionEvalType.EVALPOS_PixelViewport,
				[2] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
			},
		};
		bHidden = true;
		EventProvider = Default__UIContextMenu_WidgetEventComponent/*Ref UIComp_Event'Default__UIContextMenu.WidgetEventComponent'*/;
	}
}
}