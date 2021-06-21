namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIEditBox : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public enum EEditBoxCharacterSet 
	{
		CHARSET_All,
		CHARSET_NoSpecial,
		CHARSET_AlphaOnly,
		CHARSET_NumericOnly,
		CHARSET_AlphaNumeric,
		CHARSET_MAX
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding DataSource;
	public/*(Data)*/ /*noclear const export editinline */UIComp_DrawStringEditbox StringRenderComponent;
	public/*(Image)*/ /*const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public/*(Text)*/ /*const localized */String InitialValue;
	public/*(Text)*/ /*private */bool bReadOnly;
	public/*(Text)*/ bool bPasswordMode;
	public/*(Text)*/ int MaxCharacters;
	public/*(Text)*/ UIEditBox.EEditBoxCharacterSet CharacterSet;
	public /*delegate*/UIEditBox.OnSubmitText __OnSubmitText__Delegate;
	
	public delegate bool OnSubmitText(UIEditBox Sender, int PlayerIndex);
	
	public virtual /*final function */void SetBackgroundImage(Surface NewImage)
	{
		// stub
	}
	
	// Export UUIEditBox::execSetValue(FFrame&, void* const)
	public virtual /*native final function */void SetValue(String NewText, /*optional */int? _PlayerIndex = default, /*optional */bool? _bSkipNotification = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIEditBox::execGetValue(FFrame&, void* const)
	public virtual /*native final function */String GetValue(/*optional */bool? _bReturnUserText = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIEditBox::execCalculateCaretPositionFromCursorLocation(FFrame&, void* const)
	public virtual /*native function */int CalculateCaretPositionFromCursorLocation(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIEditBox::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIEditBox::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIEditBox::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUIEditBox::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIEditBox::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIEditBox::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUIEditBox::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*final function */bool IsReadOnly()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetReadOnly(bool bShouldBeReadOnly)
	{
		// stub
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
	
	public UIEditBox()
	{
		var Default__UIEditBox_EditboxStringRenderer = new UIComp_DrawStringEditbox
		{
			// Object Offset:0x00444B23
			StringCaret = new UIRoot.UIStringCaretParameters
			{
				bDisplayCaret = true,
			},
			bIgnoreMarkup = true,
		}/* Reference: UIComp_DrawStringEditbox'Default__UIEditBox.EditboxStringRenderer' */;
		var Default__UIEditBox_EditboxBackgroundTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x00444B9B
			StyleResolverTag = (name)"Background Image Style",
		}/* Reference: UIComp_DrawImage'Default__UIEditBox.EditboxBackgroundTemplate' */;
		var Default__UIEditBox_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIEditBox.WidgetEventComponent' */;
		// Object Offset:0x002E2970
		DataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		StringRenderComponent = Default__UIEditBox_EditboxStringRenderer/*Ref UIComp_DrawStringEditbox'Default__UIEditBox.EditboxStringRenderer'*/;
		BackgroundImageComponent = Default__UIEditBox_EditboxBackgroundTemplate/*Ref UIComp_DrawImage'Default__UIEditBox.EditboxBackgroundTemplate'*/;
		InitialValue = "Initial Editbox Value";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultEditboxStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
		};
		bSupportsPrimaryStyle = false;
		DefaultStates = new array< Core.ClassT<UIState> >
		{
			ClassT<UIState_Enabled>(),
			ClassT<UIState_Disabled>(),
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__UIEditBox_WidgetEventComponent/*Ref UIComp_Event'Default__UIEditBox.WidgetEventComponent'*/;
	}
}
}