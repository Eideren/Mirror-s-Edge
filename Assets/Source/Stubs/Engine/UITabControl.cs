// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITabControl : UIObject/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public enum EUITabAutosizeType 
	{
		TAST_Manual,
		TAST_Fill,
		TAST_Auto,
		TAST_MAX
	};
	
	public/*()*/ /*protected editfixedsize editconst editinline */array</*editconst editinline */UITabPage> Pages;
	public/*()*/ /*editconst editinline transient */UITabPage ActivePage;
	public/*()*/ /*editconst editinline transient */UITabPage PendingPage;
	public/*(Presentation)*/ UIRoot.EUIWidgetFace TabDockFace;
	public/*(Presentation)*/ UITabControl.EUITabAutosizeType TabSizeMode;
	public/*(Presentation)*/ UIRoot.UIScreenValue_Extent TabButtonSize;
	public/*(Presentation)*/ StaticArray<UIRoot.UIScreenValue_Extent, UIRoot.UIScreenValue_Extent>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ TabButtonPadding;
	public /*private */UIRoot.UIStyleReference TabButtonBackgroundStyle;
	public /*private */UIRoot.UIStyleReference TabButtonCaptionStyle;
	public/*(Presentation)*/ /*config */bool bAllowPagePreviews;
	public /*transient */bool bUpdateLayout;
	public/*(Sound)*/ name ActivateTabCue;
	public /*delegate*/UITabControl.OnPageActivated __OnPageActivated__Delegate;
	public /*delegate*/UITabControl.OnPageInserted __OnPageInserted__Delegate;
	public /*delegate*/UITabControl.OnPageRemoved __OnPageRemoved__Delegate;
	
	public delegate void OnPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex);
	
	public delegate void OnPageInserted(UITabControl Sender, UITabPage NewPage, int PlayerIndex);
	
	public delegate void OnPageRemoved(UITabControl Sender, UITabPage OldPage, int PlayerIndex);
	
	// Export UUITabControl::execRequestLayoutUpdate(FFrame&, void* const)
	public virtual /*native final function */void RequestLayoutUpdate()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUITabControl::execGetPageCount(FFrame&, void* const)
	public virtual /*native final function */int GetPageCount()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUITabControl::execGetPageAtIndex(FFrame&, void* const)
	public virtual /*native final function */UITabPage GetPageAtIndex(int PageIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUITabControl::execFindTargetedTab(FFrame&, void* const)
	public virtual /*native final function */UITabButton FindTargetedTab(int PlayerIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUITabControl::execCreateTabPage(FFrame&, void* const)
	public virtual /*native function */UITabPage CreateTabPage(Core.ClassT<UITabPage> TabPageClass, /*optional */UITabPage? _PagePrefab = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*protected event */void PrivateActivatePage(UITabPage PageToActivate, int PlayerIndex)
	{
	
	}
	
	public virtual /*event */bool InsertPage(UITabPage PageToInsert, int PlayerIndex, /*optional */int? _InsertIndex = default, /*optional */bool? _bActivateImmediately = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool RemovePage(UITabPage PageToRemove, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*event */bool ReplacePage(UITabPage ExistingPage, UITabPage NewPage, int PlayerIndex, /*optional */bool? _bFocusPage = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool ActivatePage(UITabPage PageToActivate, int PlayerIndex, /*optional */bool? _bFocusPage = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool ActivateNextPage(int PlayerIndex, /*optional */bool? _bFocusPage = default, /*optional */bool? _bAllowWrapping = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool ActivatePreviousPage(int PlayerIndex, /*optional */bool? _bFocusPage = default, /*optional */bool? _bAllowWrapping = default)
	{
	
		return default;
	}
	
	public virtual /*event */bool EnableTabPage(UITabPage PageToEnable, int PlayerIndex, /*optional */bool? _bEnablePage = default, /*optional */bool? _bActivatePage = default, /*optional */bool? _bFocusPage = default)
	{
	
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*event */void AddedChild(UIScreenObject WidgetOwner, UIObject NewChild)
	{
	
	}
	
	public virtual /*function */bool ActivatePageByCaption(String PageCaption, int PlayerIndex, /*optional */bool? _bFocusPage = default)
	{
	
		return default;
	}
	
	public virtual /*function */bool ActivateBestTab(int PlayerIndex, /*optional */bool? _bFocusPage = default, /*optional */int? _StartIndex = default)
	{
	
		return default;
	}
	
	public virtual /*function */int FindPageIndexByCaption(String PageCaption, /*optional */bool? _bMarkupString = default)
	{
	
		return default;
	}
	
	public virtual /*function */int FindPageIndexByButton(UITabButton SearchButton)
	{
	
		return default;
	}
	
	public virtual /*function */int FindPageIndexByPageRef(UITabPage SearchPage)
	{
	
		return default;
	}
	
	public virtual /*function */bool ProcessInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public virtual /*function */bool TabButtonClicked(UIScreenObject EventObject, int PlayerIndex)
	{
	
		return default;
	}
	
	public UITabControl()
	{
		// Object Offset:0x00456AC7
		TabDockFace = UIRoot.EUIWidgetFace.UIFACE_Top;
		TabSizeMode = UITabControl.EUITabAutosizeType.TAST_Auto;
		TabButtonSize = new UIRoot.UIScreenValue_Extent
		{
			Value = 0.020f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentOwner,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
		};
		TabButtonPadding = new StaticArray<UIRoot.UIScreenValue_Extent, UIRoot.UIScreenValue_Extent>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
		{ 
			[0] = new UIRoot.UIScreenValue_Extent
			{
				Value = 0.020f,
				ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentOwner,
				Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
			},
			[1] = new UIRoot.UIScreenValue_Extent
			{
				Value = 0.020f,
				ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentOwner,
				Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
			},
	 	};
		TabButtonBackgroundStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"TabButtonBackgroundStyle",
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
		TabButtonCaptionStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultTabButtonStringStyle",
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
		bAllowPagePreviews = true;
		bUpdateLayout = true;
		bSupportsPrimaryStyle = false;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Pressed>(),
			ClassT<UIState_Active>(),
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__UITabControl.WidgetEventComponent")/*Ref UIComp_Event'Default__UITabControl.WidgetEventComponent'*/;
		__OnRawInputKey__Delegate = ProcessInputKey;
	}
}
}