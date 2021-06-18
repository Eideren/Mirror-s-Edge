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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIContextMenu::execOpen(FFrame&, void* const)
	public virtual /*native final function */bool Open(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIContextMenu::execClose(FFrame&, void* const)
	public virtual /*native final function */bool Close(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*event */bool SetMenuItems(UIObject Widget, array<String> NewMenuItems, /*optional */bool? _bClearExisting = default, /*optional */int? _InsertIndex = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool InsertMenuItem(UIObject Widget, String Item, /*optional */int? _InsertIndex = default, /*optional */bool? _bAllowDuplicates = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool ClearMenuItems(UIObject Widget)
	{
	
		return default;
	}
	
	public virtual /*event */bool RemoveMenuItem(UIObject Widget, String ItemToRemove)
	{
	
		return default;
	}
	
	public virtual /*event */bool RemoveMenuItemAtIndex(UIObject Widget, int IndexToRemove)
	{
	
		return default;
	}
	
	public virtual /*event */bool GetAllMenuItems(UIObject Widget, ref array<String> out_MenuItems)
	{
	
		return default;
	}
	
	public virtual /*event */bool GetMenuItem(UIObject Widget, int IndexToGet, ref String out_MenuItem)
	{
	
		return default;
	}
	
	public virtual /*event */int FindMenuItemIndex(UIObject Widget, String ItemToFind)
	{
	
		return default;
	}
	
	public UIContextMenu()
	{
		var Default__UIContextMenu_ContextMenuDataComponent = new UIComp_ContextMenuListPresenter
		{
			// Object Offset:0x005D12D2
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = LoadAsset<UITexture>("Default__UIContextMenu.ContextMenuDataComponent.NormalOverlayTemplate")/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.NormalOverlayTemplate'*/,
				[1] = LoadAsset<UITexture>("Default__UIContextMenu.ContextMenuDataComponent.ActiveOverlayTemplate")/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.ActiveOverlayTemplate'*/,
				[2] = LoadAsset<UITexture>("Default__UIContextMenu.ContextMenuDataComponent.SelectionOverlayTemplate")/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.SelectionOverlayTemplate'*/,
				[3] = LoadAsset<UITexture>("Default__UIContextMenu.ContextMenuDataComponent.HoverOverlayTemplate")/*Ref UITexture'Default__UIContextMenu.ContextMenuDataComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: UIComp_ContextMenuListPresenter'Default__UIContextMenu.ContextMenuDataComponent' */;
		// Object Offset:0x00424006
		ColumnAutoSizeMode = UIList.ECellAutoSizeMode.CELLAUTOSIZE_AdjustList;
		RowAutoSizeMode = UIList.ECellAutoSizeMode.CELLAUTOSIZE_AdjustList;
		WrapType = UIList.EListWrapBehavior.LISTWRAP_Jump;
		bEnableVerticalScrollbar = false;
		bInitializeScrollbars = false;
		bSingleClickSubmission = true;
		bUpdateItemUnderCursor = true;
		CellDataComponent = Default__UIContextMenu_ContextMenuDataComponent;
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UIContextMenu.WidgetEventComponent")/*Ref UIComp_Event'Default__UIContextMenu.WidgetEventComponent'*/;
	}
}
}