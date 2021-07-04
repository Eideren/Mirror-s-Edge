namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListPresenter : UIComp_ListComponentBase, 
		CustomPropertyItemHandler/* within UIList*//*
		native
		hidecategories(Object)*/{
	public partial struct /*native */UIListElementCell
	{
		public /*native const transient */int ContainerElementIndex;
		public /*const transient */UIList OwnerList;
		public /*transient */UIListString ValueString;
		public StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/ CellStyle;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041C0DA
	//		OwnerList = default;
	//		ValueString = default;
	//		CellStyle = new StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
	//		{ 
	//			[0] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	//			[1] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	//			[2] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	//			[3] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	// 		};
	//	}
	};
	
	public partial struct /*native */UIListElementCellTemplate// extends UIListElementCell
	{
		public /*native const transient */int ContainerElementIndex;
		public /*const transient */UIList OwnerList;
		public /*transient */UIListString ValueString;
		public StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/ CellStyle;
	
		public/*()*/ /*editconst editinline */name CellDataField;
		public/*()*/ /*editconst */String ColumnHeaderText;
		public/*()*/ UIRoot.UIScreenValue_Extent CellSize;
		public float CellPosition;
			// Object Offset:0x0041C0DA
	//		OwnerList = default;
	//		ValueString = default;
	//		CellStyle = new StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
	//		{ 
	//			[0] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	//			[1] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	//			[2] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	//			[3] = new UIRoot.UIStyleReference
	//			{
	//				DefaultStyleTag = (name)"None",
	//				RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
	//				AssignedStyleID = new UIRoot.STYLE_ID
	//				{
	//					A = 0,
	//					B = 0,
	//					C = 0,
	//					D = 0,
	//				},
	//				ResolvedStyle = default,
	//			},
	// 		};
	//
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041CE90
	//		CellStyle = new StaticArray<UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference, UIRoot.UIStyleReference>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
	//		{ 
	//			[0] = new UIRoot.UIStyleReference
	//			{
	//				RequiredStyleClass = default,
	//			},
	//			[1] = new UIRoot.UIStyleReference
	//			{
	//				RequiredStyleClass = default,
	//			},
	//			[2] = new UIRoot.UIStyleReference
	//			{
	//				RequiredStyleClass = default,
	//			},
	//			[3] = new UIRoot.UIStyleReference
	//			{
	//				RequiredStyleClass = default,
	//			},
	// 		};
	//	}
	};
	
	public partial struct /*native */UIListItemDataBinding
	{
		public UIListElementCellProvider DataSourceProvider;
		public name DataSourceTag;
		public int DataSourceIndex;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041D060
	//		DataSourceProvider = default;
	//		DataSourceTag = (name)"None";
	//		DataSourceIndex = 0;
	//	}
	};
	
	public partial struct /*native */UIListItem
	{
		public /*const */UIComp_ListPresenter.UIListItemDataBinding DataSource;
		public/*()*/ /*editfixedsize editconst editinline */array</*editconst editinline */UIComp_ListPresenter.UIListElementCell> Cells;
		public/*()*/ /*noimport editconst transient */UIRoot.EUIListElementState ElementState;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041D1B0
	//		DataSource = new UIComp_ListPresenter.UIListItemDataBinding
	//		{
	//			DataSourceProvider = default,
	//			DataSourceTag = (name)"None",
	//			DataSourceIndex = 0,
	//		};
	//		Cells = default;
	//		ElementState = UIRoot.EUIListElementState.ELEMENT_Normal;
	//	}
	};
	
	public partial struct /*native */UIElementCellSchema
	{
		public/*()*/ /*editinline */array</*editinline */UIComp_ListPresenter.UIListElementCellTemplate> Cells;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0041D304
	//		Cells = default;
	//	}
	};
	
	public new UIList Outer => base.Outer as UIList;
	
	public /*private native const noexport */Object.Pointer VfTable_ICustomPropertyItemHandler;
	public/*()*/ /*private const */UIComp_ListPresenter.UIElementCellSchema ElementSchema;
	public/*()*/ /*init noimport editconst editinline transient */array</*init editconst editinline */UIComp_ListPresenter.UIListItem> ListItems;
	public/*(Presentation)*/ bool bDisablePixelAligning;
	public/*()*/ /*private */bool bDisplayColumnHeaders;
	public /*transient */bool bReapplyFormatting;
	public/*()*/ /*private */bool bOnlyDrawEveryOtherElementOverlay;
	public/*(Image)*/ /*export editinlineuse */StaticArray<UITexture, UITexture, UITexture>/*[UIRoot.EColumnHeaderState.COLUMNHEADER_MAX]*/ ColumnHeaderBackground;
	public/*(Image)*/ /*export editinlineuse */StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/ ListItemOverlay;
	public/*(Image)*/ StaticArray<UIRoot.TextureCoordinates, UIRoot.TextureCoordinates, UIRoot.TextureCoordinates>/*[UIRoot.EColumnHeaderState.COLUMNHEADER_MAX]*/ ColumnHeaderBackgroundCoordinates;
	public/*(Image)*/ StaticArray<UIRoot.TextureCoordinates, UIRoot.TextureCoordinates, UIRoot.TextureCoordinates, UIRoot.TextureCoordinates>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/ ListItemOverlayCoordinates;
	
	// Export UUIComp_ListPresenter::execEnableColumnHeaderRendering(FFrame&, void* const)
	public virtual /*native final function */void EnableColumnHeaderRendering(/*optional */bool? _bShouldRenderColHeaders = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_ListPresenter::execShouldRenderColumnHeaders(FFrame&, void* const)
	public virtual /*native final function */bool ShouldRenderColumnHeaders()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_ListPresenter::execShouldAdjustListBounds(FFrame&, void* const)
	public virtual /*native final function */bool ShouldAdjustListBounds(UIRoot.EUIOrientation Orientation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_ListPresenter::execGetCellSchemaProvider(FFrame&, void* const)
	public virtual /*native final function */UIListElementCellProvider GetCellSchemaProvider()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_ListPresenter::execFindElementIndex(FFrame&, void* const)
	public virtual /*native final function */int FindElementIndex(int DataSourceIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public UIComp_ListPresenter()
	{
		var Default__UIComp_ListPresenter_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenter.NormalOverlayTemplate' */;
		var Default__UIComp_ListPresenter_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenter.ActiveOverlayTemplate' */;
		var Default__UIComp_ListPresenter_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenter.SelectionOverlayTemplate' */;
		var Default__UIComp_ListPresenter_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenter.HoverOverlayTemplate' */;
		// Object Offset:0x0041D5D4
		bDisplayColumnHeaders = true;
		bReapplyFormatting = true;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__UIComp_ListPresenter_NormalOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenter.NormalOverlayTemplate'*/,
			[1] = Default__UIComp_ListPresenter_ActiveOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenter.ActiveOverlayTemplate'*/,
			[2] = Default__UIComp_ListPresenter_SelectionOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenter.SelectionOverlayTemplate'*/,
			[3] = Default__UIComp_ListPresenter_HoverOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}