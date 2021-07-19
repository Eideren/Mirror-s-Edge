namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComboBox : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const int TEXT_CHANGED_NOTIFY_MASK = 0x1;
	public const int INDEX_CHANGED_NOTIFY_MASK = 0x2;
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIDataStorePublisher;
	[Const] public Core.ClassT<UIEditBox> ComboEditboxClass;
	[Const] public Core.ClassT<UIToggleButton> ComboButtonClass;
	[Const] public Core.ClassT<UIList> ComboListClass;
	[Category] [noclear, Const, editinline] public UIEditBox ComboEditbox;
	[Category] [noclear, Const, editinline] public UIToggleButton ComboButton;
	[Category] [noclear, Const, editinline] public UIList ComboList;
	[Category("Presentation")] [Const, export, editinline] public UIComp_DrawCaption CaptionRenderComponent;
	[Category("Presentation")] [Const, export, editinline] public UIComp_DrawImage BackgroundRenderComponent;
	[Category("Data")] [Const, editconst] public/*private*/ UIRoot.UIDataStoreBinding CaptionDataSource;
	[Category("Sound")] public name OpenList;
	[Category("Sound")] public name DecrementCue;
	[Category] public bool bLockSelectedItem;
	[Category("Presentation")] public/*private*/ bool bDockListToButton;
	public /*delegate*/UIComboBox.CreateCustomComboEditbox __CreateCustomComboEditbox__Delegate;
	public /*delegate*/UIComboBox.CreateCustomComboButton __CreateCustomComboButton__Delegate;
	public /*delegate*/UIComboBox.CreateCustomComboList __CreateCustomComboList__Delegate;
	
	public delegate UIEditBox CreateCustomComboEditbox(UIComboBox EditboxOwner);
	
	public delegate UIToggleButton CreateCustomComboButton(UIComboBox ButtonOwner);
	
	public delegate UIList CreateCustomComboList(UIComboBox ListOwner);
	
	// Export UUIComboBox::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComboBox::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComboBox::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComboBox::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComboBox::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComboBox::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native function */void ClearBoundDataStores()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComboBox::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*event */void SetVisibility(bool bIsVisible)
	{
		// stub
	}
	
	public virtual /*event */void ShowList(/*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*event */void HideList(/*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*function */void SetEditboxText(String NewText, int PlayerIndex, /*optional */bool? _bListItemsOnly = default, /*optional */bool? _bSkipNotification = default)
	{
		// stub
	}
	
	public virtual /*final function */bool IsListDockedToButton()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetListDocking(bool bDockToButton)
	{
		// stub
	}
	
	public virtual /*function */void EditboxPressed(UIScreenObject EventObject, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void ButtonPressed(UIScreenObject EventObject, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */bool ShowListClickHandler(UIScreenObject EventObject, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void EditboxTextChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void SelectedItemChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void ListItemSelected(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public virtual /*function */void OnGetTextValue(UIAction_GetTextValue Action)
	{
		// stub
	}
	
	public UIComboBox()
	{
		var Default__UIComboBox_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIComboBox.WidgetEventComponent' */;
		// Object Offset:0x0041B835
		ComboEditboxClass = ClassT<UIEditBox>()/*Ref Class'UIEditBox'*/;
		ComboButtonClass = ClassT<UIToggleButton>()/*Ref Class'UIToggleButton'*/;
		ComboListClass = ClassT<UIList>()/*Ref Class'UIList'*/;
		CaptionDataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = 2,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		PrivateFlags = 1024;
		bSupportsPrimaryStyle = false;
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = 256.0f,
				[3] = 32.0f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
		};
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__UIComboBox_WidgetEventComponent/*Ref UIComp_Event'Default__UIComboBox.WidgetEventComponent'*/;
	}
}
}