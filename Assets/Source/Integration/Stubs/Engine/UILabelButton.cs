namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UILabelButton : UIButton, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding CaptionDataSource;
	public/*(Data)*/ /*noclear const export editinline */UIComp_DrawString StringRenderComponent;
	
	// Export UUILabelButton::execSetCaption(FFrame&, void* const)
	public virtual /*native function */void SetCaption(String NewText)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*final event */String GetCaption()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnSetLabelText(UIAction_SetLabelText Action)
	{
		// stub
	}
	
	public virtual /*function */void OnGetTextValue(UIAction_GetTextValue Action)
	{
		// stub
	}
	
	// Export UUILabelButton::execSetTextAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetTextAlignment(UIRoot.EUIAlignment Horizontal, UIRoot.EUIAlignment Vertical)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUILabelButton::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUILabelButton::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUILabelButton::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUILabelButton::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUILabelButton::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUILabelButton::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native function */void ClearBoundDataStores()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUILabelButton::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public UILabelButton()
	{
		var Default__UILabelButton_LabelStringRenderer = new UIComp_DrawString
		{
			// Object Offset:0x0045370D
			StyleResolverTag = (name)"Caption Style",
			StringStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultLabelButtonStyle",
			},
		}/* Reference: UIComp_DrawString'Default__UILabelButton.LabelStringRenderer' */;
		var Default__UILabelButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UILabelButton.BackgroundImageTemplate' */;
		var Default__UILabelButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UILabelButton.WidgetEventComponent' */;
		// Object Offset:0x0044448D
		CaptionDataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "Button Text",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		StringRenderComponent = Default__UILabelButton_LabelStringRenderer/*Ref UIComp_DrawString'Default__UILabelButton.LabelStringRenderer'*/;
		BackgroundImageComponent = Default__UILabelButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UILabelButton.BackgroundImageTemplate'*/;
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultLabelButtonStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		EventProvider = Default__UILabelButton_WidgetEventComponent/*Ref UIComp_Event'Default__UILabelButton.WidgetEventComponent'*/;
	}
}
}