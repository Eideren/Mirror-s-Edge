namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UILabel : UIObject, 
		UIDataStoreSubscriber,UIStringRenderer/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStoreSubscriber;
	public /*private native const noexport */Object.Pointer VfTable_IUIStringRenderer;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding DataSource;
	public/*(Data)*/ /*noclear const export editinline */UIComp_DrawString StringRenderComponent;
	public/*(Image)*/ /*const export editinline */UIComp_DrawImage LabelBackground;
	
	// Export UUILabel::execSetValue(FFrame&, void* const)
	public virtual /*native final function */void SetValue(string NewText)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUILabel::execSetTextAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetTextAlignment(UIRoot.EUIAlignment Horizontal, UIRoot.EUIAlignment Vertical)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUILabel::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(string MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUILabel::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */string GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUILabel::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUILabel::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUILabel::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUILabel::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */void SetArrayValue(array<string> ValueArray)
	{
	
	}
	
	public virtual /*function */string GetValue()
	{
	
		return default;
	}
	
	public virtual /*final function */void IgnoreMarkup(bool bShouldIgnoreMarkup)
	{
	
	}
	
	public virtual /*function */void OnSetLabelText(UIAction_SetLabelText Action)
	{
	
	}
	
	public virtual /*function */void OnGetTextValue(UIAction_GetTextValue Action)
	{
	
	}
	
	public UILabel()
	{
		// Object Offset:0x002DF540
		DataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "Initial Label Text",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__UILabel.LabelStringRenderer")/*Ref UIComp_DrawString'Default__UILabel.LabelStringRenderer'*/;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		bSupportsPrimaryStyle = false;
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = 100.0f,
				[3] = 40.0f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				[3] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__UILabel.WidgetEventComponent")/*Ref UIComp_Event'Default__UILabel.WidgetEventComponent'*/;
	}
}
}