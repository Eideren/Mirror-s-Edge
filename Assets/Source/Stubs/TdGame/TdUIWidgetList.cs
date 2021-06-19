// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIWidgetList : TdUIDrawPanel, 
		UIDataStoreSubscriber/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native */GeneratedObjectInfo
	{
		public name OptionProviderName;
		public UIObject LabelObj;
		public UIObject OptionObj;
		public UIDataProvider OptionProvider;
		public float OptionY;
		public float OptionHeight;
		public float OptionX;
		public float OptionWidth;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00688298
	//		OptionProviderName = (name)"None";
	//		LabelObj = default;
	//		OptionObj = default;
	//		OptionProvider = default;
	//		OptionY = 0.0f;
	//		OptionHeight = 0.0f;
	//		OptionX = 0.0f;
	//		OptionWidth = 0.0f;
	//	}
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStoreSubscriber;
	public /*transient */UIScrollbar VerticalScrollbar;
	public /*transient */int CurrentIndex;
	public /*transient */int PreviousIndex;
	public /*transient */array<TdUIWidgetList.GeneratedObjectInfo> GeneratedObjects;
	public/*(Data)*/ UIRoot.UIDataStoreBinding DataSource;
	public /*const transient */UIListElementProvider DataProvider;
	public /*transient */int MaxVisibleItems;
	public /*transient */bool bRegenOptions;
	public /*delegate*/TdUIWidgetList.OnOptionFocused __OnOptionFocused__Delegate;
	public /*delegate*/TdUIWidgetList.OnOptionChanged __OnOptionChanged__Delegate;
	public /*delegate*/TdUIWidgetList.OnAcceptOptions __OnAcceptOptions__Delegate;
	
	public delegate void OnOptionFocused(UIScreenObject InObject, UIDataProvider OptionProvider);
	
	public delegate void OnOptionChanged(UIScreenObject InObject, name OptionName, int PlayerIndex);
	
	public delegate void OnAcceptOptions(UIScreenObject InObject, int PlayerIndex);
	
	// Export UTdUIWidgetList::execSetSelectedOptionIndex(FFrame&, void* const)
	public virtual /*native function */void SetSelectedOptionIndex(int OptionIdx)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIWidgetList::execInitializeScrollbars(FFrame&, void* const)
	public virtual /*native function */void InitializeScrollbars()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void GetSupportedUIActionKeyNames(ref array<name> out_KeyNames)
	{
	
	}
	
	public virtual /*function */void RefreshAllOptions()
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*event */void SetupOptionBindings()
	{
	
	}
	
	public virtual /*function */void ClickedScrollZone(UIScrollbar Sender, float PositionPerc, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */bool ScrollVertical(UIScrollbar Sender, float PositionChange, /*optional */bool? _bPositionMaxed = default)
	{
	
		return default;
	}
	
	public virtual /*function */int GetObjectInfoIndexFromName(name ProviderName)
	{
	
		return default;
	}
	
	public virtual /*function */int GetObjectInfoIndexFromObject(UIObject Sender)
	{
	
		return default;
	}
	
	#warning is overriding a delegate !? Probably the default implementation
	public /*override*/ /*function */void OnValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnOption_NotifyActiveStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public virtual /*function */void SelectItem(int OptionIdx)
	{
	
	}
	
	public virtual /*function */void SetNewCurrentOption(int OptionIndex)
	{
	
	}
	
	public virtual /*function */void SelectNextItem(/*optional */bool? _bWrap = default)
	{
	
	}
	
	public virtual /*function */void SelectPreviousItem(/*optional */bool? _bWrap = default)
	{
	
	}
	
	public virtual /*function */bool ProcessInputKey(/*const */ref UIRoot.SubscribedInputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*event */void DrawPanel()
	{
	
	}
	
	// Export UTdUIWidgetList::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIWidgetList::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIWidgetList::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIWidgetList::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIWidgetList::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdUIWidgetList::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
	}
	
	public TdUIWidgetList()
	{
		var Default__TdUIWidgetList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIWidgetList.WidgetEventComponent' */;
		// Object Offset:0x00689E54
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
		requiresTick = true;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
		};
		EventProvider = Default__TdUIWidgetList_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIWidgetList.WidgetEventComponent'*/;
	}
}
}