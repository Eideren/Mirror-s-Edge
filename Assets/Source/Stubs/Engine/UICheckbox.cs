namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UICheckbox : UIButton, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public/*(Sound)*/ name CheckedCue;
	public/*(Sound)*/ name UncheckedCue;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding ValueDataSource;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage CheckedImageComponent;
	public/*(Value)*/ /*private */bool bIsChecked;
	
	public virtual /*final function */void SetCheckImage(Surface NewImage)
	{
	
	}
	
	public virtual /*final function */bool IsChecked()
	{
	
		return default;
	}
	
	// Export UUICheckbox::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(string MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUICheckbox::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */string GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUICheckbox::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUICheckbox::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUICheckbox::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUICheckbox::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUICheckbox::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUICheckbox::execSetValue(FFrame&, void* const)
	public virtual /*native function */void SetValue(bool bShouldBeChecked, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */void OnSetBoolValue(UIAction_SetBoolValue Action)
	{
	
	}
	
	public UICheckbox()
	{
		// Object Offset:0x00419E86
		CheckedCue = (name)"CheckboxChecked";
		UncheckedCue = (name)"CheckboxUnchecked";
		ValueDataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		CheckedImageComponent = new UIComp_DrawImage
		{
			// Object Offset:0x005D141A
			StyleResolverTag = (name)"Check Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultCheckbox",
			},
		}/* Reference: UIComp_DrawImage'Default__UICheckbox.CheckedImageTemplate' */;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UICheckbox.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UICheckbox.BackgroundImageTemplate'*/;
		ClickedCue = (name)"None";
		EventProvider = LoadAsset<UIComp_Event>("Default__UICheckbox.WidgetEventComponent")/*Ref UIComp_Event'Default__UICheckbox.WidgetEventComponent'*/;
	}
}
}