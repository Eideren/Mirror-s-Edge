namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISlider : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage SliderBarImageComponent;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage MarkerImageComponent;
	public/*(Data)*/ /*private editconst */UIRoot.UIDataStoreBinding DataSource;
	public/*(Data)*/ /*const export editinline */UIComp_DrawStringSlider CaptionRenderComponent;
	public/*(Slider)*/ UIRoot.UIRangeData SliderValue;
	public/*(Slider)*/ bool bRenderCaption;
	public/*(Slider)*/ UIRoot.EUIOrientation SliderOrientation;
	public/*(Slider)*/ UIRoot.UIScreenValue_Extent BarSize;
	public/*(Slider)*/ UIRoot.UIScreenValue_Extent MarkerHeight;
	public/*(Slider)*/ UIRoot.UIScreenValue_Extent MarkerWidth;
	public/*(Sound)*/ name IncrementCue;
	public/*(Sound)*/ name DecrementCue;
	
	// Export UUISlider::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISlider::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISlider::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISlider::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISlider::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISlider::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUISlider::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISlider::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(/*coerce */float NewValue, /*optional */bool? _bPercentageValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUISlider::execGetValue(FFrame&, void* const)
	public virtual /*native final function */float GetValue(/*optional */bool? _bPercentageValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */void SetBackgroundImage(Surface NewImage)
	{
	
	}
	
	public virtual /*final function */void SetBarImage(Surface NewImage)
	{
	
	}
	
	public virtual /*final function */void SetMarkerImage(Surface NewImage)
	{
	
	}
	
	public virtual /*final function */void OnStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public UISlider()
	{
		var Default__UISlider_SliderBackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1CA2
			StyleResolverTag = (name)"Slider Background Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultSliderStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UISlider.SliderBackgroundImageTemplate' */;
		var Default__UISlider_SliderBarImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1D22
			StyleResolverTag = (name)"Slider Bar Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultSliderBarStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UISlider.SliderBarImageTemplate' */;
		var Default__UISlider_SliderMarkerImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1DA2
			StyleResolverTag = (name)"Slider Marker Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultSliderMarkerStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UISlider.SliderMarkerImageTemplate' */;
		// Object Offset:0x00450883
		BackgroundImageComponent = Default__UISlider_SliderBackgroundImageTemplate;
		SliderBarImageComponent = Default__UISlider_SliderBarImageTemplate;
		MarkerImageComponent = Default__UISlider_SliderMarkerImageTemplate;
		DataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_RangeProperty,
			MarkupString = "",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		SliderValue = new UIRoot.UIRangeData
		{
			CurrentValue = 0.0f,
			MinValue = 0.0f,
			MaxValue = 100.0f,
			NudgeValue = 1.0f,
			bIntRange = false,
		};
		bRenderCaption = true;
		BarSize = new UIRoot.UIScreenValue_Extent
		{
			Value = 32.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		MarkerHeight = new UIRoot.UIScreenValue_Extent
		{
			Value = 16.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
		};
		MarkerWidth = new UIRoot.UIScreenValue_Extent
		{
			Value = 16.0f,
			ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_Pixels,
			Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
		};
		IncrementCue = (name)"SliderIncrement";
		DecrementCue = (name)"SliderDecrement";
		PrimaryStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultSliderStyle",
			RequiredStyleClass = ClassT<UIStyle_Image>()/*Ref Class'UIStyle_Image'*/,
		};
		bSupportsPrimaryStyle = false;
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[3] = 32.0f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
			ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UISlider.WidgetEventComponent")/*Ref UIComp_Event'Default__UISlider.WidgetEventComponent'*/;
		__NotifyActiveStateChanged__Delegate = (Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState) => OnStateChanged(Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState);
	}
}
}