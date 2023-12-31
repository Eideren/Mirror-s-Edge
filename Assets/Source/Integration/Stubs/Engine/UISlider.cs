namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISlider : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIDataStorePublisher;
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage BackgroundImageComponent;
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage SliderBarImageComponent;
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage MarkerImageComponent;
	[Category("Data")] [editconst] public/*private*/ UIRoot.UIDataStoreBinding DataSource;
	[Category("Data")] [Const, export, editinline] public UIComp_DrawStringSlider CaptionRenderComponent;
	[Category("Slider")] public UIRoot.UIRangeData SliderValue;
	[Category("Slider")] public bool bRenderCaption;
	[Category("Slider")] public UIRoot.EUIOrientation SliderOrientation;
	[Category("Slider")] public UIRoot.UIScreenValue_Extent BarSize;
	[Category("Slider")] public UIRoot.UIScreenValue_Extent MarkerHeight;
	[Category("Slider")] public UIRoot.UIScreenValue_Extent MarkerWidth;
	[Category("Sound")] public name IncrementCue;
	[Category("Sound")] public name DecrementCue;
	
	// Export UUISlider::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISlider::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISlider::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISlider::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISlider::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISlider::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUISlider::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISlider::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(/*coerce */float NewValue, /*optional */bool? _bPercentageValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUISlider::execGetValue(FFrame&, void* const)
	public virtual /*native final function */float GetValue(/*optional */bool? _bPercentageValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final function */void SetBackgroundImage(Surface NewImage)
	{
		// stub
	}
	
	public virtual /*final function */void SetBarImage(Surface NewImage)
	{
		// stub
	}
	
	public virtual /*final function */void SetMarkerImage(Surface NewImage)
	{
		// stub
	}
	
	public virtual /*final function */void OnStateChanged(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
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
		var Default__UISlider_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UISlider.WidgetEventComponent' */;
		// Object Offset:0x00450883
		BackgroundImageComponent = Default__UISlider_SliderBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UISlider.SliderBackgroundImageTemplate'*/;
		SliderBarImageComponent = Default__UISlider_SliderBarImageTemplate/*Ref UIComp_DrawImage'Default__UISlider.SliderBarImageTemplate'*/;
		MarkerImageComponent = Default__UISlider_SliderMarkerImageTemplate/*Ref UIComp_DrawImage'Default__UISlider.SliderMarkerImageTemplate'*/;
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
		EventProvider = Default__UISlider_WidgetEventComponent/*Ref UIComp_Event'Default__UISlider.WidgetEventComponent'*/;
		__NotifyActiveStateChanged__Delegate = (Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState) => OnStateChanged(Sender, PlayerIndex, NewlyActiveState, PreviouslyActiveState);
	}
}
}