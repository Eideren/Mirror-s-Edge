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
	public virtual /*native final function */void SetValue(String NewText)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUILabel::execSetTextAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetTextAlignment(UIRoot.EUIAlignment Horizontal, UIRoot.EUIAlignment Vertical)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUILabel::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUILabel::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUILabel::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUILabel::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUILabel::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUILabel::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*final function */void SetArrayValue(array<String> ValueArray)
	{
		// stub
	}
	
	public virtual /*function */String GetValue()
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void IgnoreMarkup(bool bShouldIgnoreMarkup)
	{
		// stub
	}
	
	public virtual /*function */void OnSetLabelText(UIAction_SetLabelText Action)
	{
		// stub
	}
	
	public virtual /*function */void OnGetTextValue(UIAction_GetTextValue Action)
	{
		// stub
	}
	
	public UILabel()
	{
		var Default__UILabel_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__UILabel.LabelStringRenderer' */;
		var Default__UILabel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UILabel.WidgetEventComponent' */;
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
		StringRenderComponent = Default__UILabel_LabelStringRenderer/*Ref UIComp_DrawString'Default__UILabel.LabelStringRenderer'*/;
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
		EventProvider = Default__UILabel_WidgetEventComponent/*Ref UIComp_Event'Default__UILabel.WidgetEventComponent'*/;
	}
}
}