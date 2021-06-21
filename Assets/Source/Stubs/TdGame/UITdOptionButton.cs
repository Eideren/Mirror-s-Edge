namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITdOptionButton : TdUIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public const string UIKEY_MoveCursorLeft = "UIKEY_MoveCursorLeft";
	public const string UIKEY_MoveCursorRight = "UIKEY_MoveCursorRight";
	
	public enum EOptionButtonArrow 
	{
		OPTBUT_ArrowLeft,
		OPTBUT_ArrowRight,
		OPTBUT_MAX
	};
	
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public UIButton ArrowLeftButton;
	public UIButton ArrowRightButton;
	public /*private */UIRoot.UIStyleReference IncrementStyle;
	public /*private */UIRoot.UIStyleReference DecrementStyle;
	public/*(Presentation)*/ UIRoot.UIScreenValue ButtonSize;
	public/*(Presentation)*/ UIRoot.UIScreenValue ButtonSpacing;
	public/*(Presentation)*/ bool bIncludeDisabledItems;
	public/*()*/ bool bWrapOptions;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public/*(Data)*/ /*noclear const export editinline */UIComp_DrawString StringRenderComponent;
	public /*transient */int CurrentIndex;
	public/*(Sound)*/ name IncrementCue;
	public/*(Sound)*/ name DecrementCue;
	public/*(Sound)*/ name ClickedCue;
	public/*(Data)*/ UIRoot.UIDataStoreBinding DataSource;
	public /*const transient */UIListElementProvider DataProvider;
	public/*()*/ name CellTag;
	public float PreventChangeSelection;
	
	// Export UUITdOptionButton::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execHasPrevValue(FFrame&, void* const)
	public virtual /*native function */bool HasPrevValue()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execHasNextValue(FFrame&, void* const)
	public virtual /*native function */bool HasNextValue()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execSetPrevValue(FFrame&, void* const)
	public virtual /*native function */void SetPrevValue()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execSetNextValue(FFrame&, void* const)
	public virtual /*native function */void SetNextValue()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execUpdateArrowStates(FFrame&, void* const)
	public virtual /*native function */void UpdateArrowStates()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execGetCurrentIndex(FFrame&, void* const)
	public virtual /*native function */int GetCurrentIndex()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execSetCurrentIndex(FFrame&, void* const)
	public virtual /*native function */void SetCurrentIndex(int NewIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UUITdOptionButton::execIsCurrentElementEnabled(FFrame&, void* const)
	public virtual /*native function */bool IsCurrentElementEnabled()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUITdOptionButton::execGetCurrentValue(FFrame&, void* const)
	public virtual /*native function */int GetCurrentValue()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public virtual /*function */void VerifyArrowButtons()
	{
		// stub
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*event */void OnMoveSelectionLeft(int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*event */void OnMoveSelectionRight(int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */bool OnArrowLeft_Clicked(UIScreenObject InButton, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnArrowRight_Clicked(UIScreenObject InButton, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public UITdOptionButton()
	{
		var Default__UITdOptionButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x006EEA37
			StyleResolverTag = (name)"Background Image Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"ButtonBackground",
			},
		}/* Reference: UIComp_DrawImage'Default__UITdOptionButton.BackgroundImageTemplate' */;
		var Default__UITdOptionButton_LabelStringRenderer = new UIComp_DrawString
		{
			// Object Offset:0x006EEAB7
			StyleResolverTag = (name)"Caption Style",
			StringStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultOptionButtonStyle",
			},
		}/* Reference: UIComp_DrawString'Default__UITdOptionButton.LabelStringRenderer' */;
		var Default__UITdOptionButton_ButtonClickHandler = new UIEvent_OnClick
		{
		}/* Reference: UIEvent_OnClick'Default__UITdOptionButton.ButtonClickHandler' */;
		var Default__UITdOptionButton_WidgetEventComponent = new UIComp_Event
		{
			// Object Offset:0x006EE983
			DefaultEvents = new array<UIRoot.DefaultEventSpecification>
			{
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_Initialized>("Engine.Default__UIObject.WidgetInitializedEvent")/*Ref UIEvent_Initialized'Engine.Default__UIObject.WidgetInitializedEvent'*/,
					EventState = default,
				},
				new UIRoot.DefaultEventSpecification
				{
					EventTemplate = LoadAsset<UIEvent_OnClick>("Default__UITdOptionButton.ButtonClickHandler")/*Ref UIEvent_OnClick'Default__UITdOptionButton.ButtonClickHandler'*/,
					EventState = ClassT<UIState_Focused>()/*Ref Class'UIState_Focused'*/,
				},
			},
		}/* Reference: UIComp_Event'Default__UITdOptionButton.WidgetEventComponent' */;
		// Object Offset:0x006EE1EC
		IncrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultOptionButtonRightArrowStyle",
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
		DecrementStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultOptionButtonLeftArrowStyle",
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
		ButtonSize = new UIRoot.UIScreenValue
		{
			Value = 0.0f,
			ScaleType = UIRoot.EPositionEvalType.EVALPOS_PixelViewport,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		ButtonSpacing = new UIRoot.UIScreenValue
		{
			Value = 0.0f,
			ScaleType = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		bWrapOptions = true;
		BackgroundImageComponent = Default__UITdOptionButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UITdOptionButton.BackgroundImageTemplate'*/;
		StringRenderComponent = Default__UITdOptionButton_LabelStringRenderer/*Ref UIComp_DrawString'Default__UITdOptionButton.LabelStringRenderer'*/;
		IncrementCue = (name)"SliderIncrement";
		DecrementCue = (name)"SliderDecrement";
		ClickedCue = (name)"Clicked";
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
			ClassT<UIState_Focused>(),
			ClassT<UIState_Active>(),
			ClassT<UIState_Pressed>(),
		};
		EventProvider = Default__UITdOptionButton_WidgetEventComponent/*Ref UIComp_Event'Default__UITdOptionButton.WidgetEventComponent'*/;
	}
}
}