namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITabPage : UIContainer, 
		UIDataStoreSubscriber/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int CAPTION_DATABINDING_INDEX = 0;
	public const int TOOLTIP_DATABINDING_INDEX = 1;
	public const int DESCRIPTION_DATABINDING_INDEX = 2;
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIDataStoreSubscriber;
	[Const] public Core.ClassT<UITabButton> ButtonClass;
	public/*protected*/ UITabButton TabButton;
	[Category("Data")] public/*private*/ UIRoot.UIDataStoreBinding ButtonCaption;
	[Category("Data")] public/*private*/ UIRoot.UIDataStoreBinding ButtonToolTip;
	[Category("Data")] public/*private*/ UIRoot.UIDataStoreBinding PageDescription;
	
	public virtual /*event */bool ActivatePage(int PlayerIndex, bool bActivate, /*optional */bool? _bTakeFocus = default)
	{
		// stub
		return default;
	}
	
	public /*protected event */static UITabButton CreateTabButton(UITabControl TabControl)
	{
		// stub
		return default;
	}
	
	public virtual /*event */bool LinkToTabButton(UITabButton NewButton, UITabControl TabControl)
	{
		// stub
		return default;
	}
	
	public override /*event */void RemovedFromParent(UIScreenObject WidgetOwner)
	{
		// stub
	}
	
	// Export UUITabPage::execGetOwnerTabControl(FFrame&, void* const)
	public virtual /*native final function */UITabControl GetOwnerTabControl()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */UITabButton GetTabButton(/*optional */UITabControl _TabControl = default)
	{
		// stub
		return default;
	}
	
	// Export UUITabPage::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUITabPage::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUITabPage::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUITabPage::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUITabPage::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUITabPage::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void AddedToTabControl(UITabControl TabControl)
	{
		// stub
	}
	
	public virtual /*function */bool CanActivatePage(int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public virtual /*function */void SetTabCaption(String NewButtonMarkup)
	{
		// stub
	}
	
	public virtual /*function */bool IsActivePage()
	{
		// stub
		return default;
	}
	
	public UITabPage()
	{
		var Default__UITabPage_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UITabPage.WidgetEventComponent' */;
		// Object Offset:0x00458410
		ButtonClass = ClassT<UITabButton>()/*Ref Class'UITabButton'*/;
		ButtonToolTip = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = 1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		PageDescription = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = 2,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		PrivateFlags = 640;
		EventProvider = Default__UITabPage_WidgetEventComponent/*Ref UIComp_Event'Default__UITabPage.WidgetEventComponent'*/;
		__NotifyActiveStateChanged__Delegate = (Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState) => OnActiveStateChanged(Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState);
	}
}
}