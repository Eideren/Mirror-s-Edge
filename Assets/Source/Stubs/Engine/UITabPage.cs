namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITabPage : UIContainer, 
		UIDataStoreSubscriber/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int CAPTION_DATABINDING_INDEX = 0;
	public const int TOOLTIP_DATABINDING_INDEX = 1;
	public const int DESCRIPTION_DATABINDING_INDEX = 2;
	
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStoreSubscriber;
	public /*const */Core.ClassT<UITabButton> ButtonClass;
	public /*protected */UITabButton TabButton;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding ButtonCaption;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding ButtonToolTip;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding PageDescription;
	
	public virtual /*event */bool ActivatePage(int PlayerIndex, bool bActivate, /*optional */bool? _bTakeFocus = default)
	{
	
		return default;
	}
	
	public /*protected event */static UITabButton CreateTabButton(UITabControl TabControl)
	{
	
		return default;
	}
	
	public virtual /*event */bool LinkToTabButton(UITabButton NewButton, UITabControl TabControl)
	{
	
		return default;
	}
	
	public override /*event */void RemovedFromParent(UIScreenObject WidgetOwner)
	{
	
	}
	
	// Export UUITabPage::execGetOwnerTabControl(FFrame&, void* const)
	public virtual /*native final function */UITabControl GetOwnerTabControl()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */UITabButton GetTabButton(/*optional */UITabControl? _TabControl = default)
	{
	
		return default;
	}
	
	// Export UUITabPage::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUITabPage::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUITabPage::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUITabPage::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUITabPage::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUITabPage::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void AddedToTabControl(UITabControl TabControl)
	{
	
	}
	
	public virtual /*function */bool CanActivatePage(int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public virtual /*function */void SetTabCaption(String NewButtonMarkup)
	{
	
	}
	
	public virtual /*function */bool IsActivePage()
	{
	
		return default;
	}
	
	public UITabPage()
	{
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UITabPage.WidgetEventComponent")/*Ref UIComp_Event'Default__UITabPage.WidgetEventComponent'*/;
		__NotifyActiveStateChanged__Delegate = (Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState) => OnActiveStateChanged(Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState);
	}
}
}