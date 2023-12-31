namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIProgressBar : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIDataStorePublisher;
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage BackgroundImageComponent;
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage FillImageComponent;
	[Category("Image")] [noclear, Const, export, editinline] public UIComp_DrawImage OverlayImageComponent;
	[Category("Image")] public bool bDrawOverlay;
	[Category("Data")] [editconst] public/*private*/ UIRoot.UIDataStoreBinding DataSource;
	[Category("ProgressBar")] public UIRoot.UIRangeData ProgressBarValue;
	[Category("ProgressBar")] public UIRoot.EUIOrientation ProgressBarOrientation;
	
	public virtual /*protected final function */void OnSetProgressBarValue(UIAction_SetProgressBarValue Action)
	{
		// stub
	}
	
	public virtual /*protected final function */void OnGetProgressBarValue(UIAction_GetProgressBarValue Action)
	{
		// stub
	}
	
	// Export UUIProgressBar::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIProgressBar::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIProgressBar::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIProgressBar::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIProgressBar::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIProgressBar::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIProgressBar::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIProgressBar::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(/*coerce */float NewValue, /*optional */bool? _bPercentageValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIProgressBar::execGetValue(FFrame&, void* const)
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
	
	public virtual /*final function */void SetFillImage(Surface NewImage)
	{
		// stub
	}
	
	public virtual /*final function */void SetOverlayImage(Surface NewImage)
	{
		// stub
	}
	
	public UIProgressBar()
	{
		var Default__UIProgressBar_ProgressBarBackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1A0A
			StyleResolverTag = (name)"Background Image Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultSliderStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UIProgressBar.ProgressBarBackgroundImageTemplate' */;
		var Default__UIProgressBar_ProgressBarFillImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1A8A
			StyleResolverTag = (name)"Fill Image Style",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultSliderBarStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UIProgressBar.ProgressBarFillImageTemplate' */;
		var Default__UIProgressBar_ProgressBarOverlayImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1B0A
			StyleResolverTag = (name)"Overlay Image Style",
		}/* Reference: UIComp_DrawImage'Default__UIProgressBar.ProgressBarOverlayImageTemplate' */;
		var Default__UIProgressBar_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIProgressBar.WidgetEventComponent' */;
		// Object Offset:0x0044BCA4
		BackgroundImageComponent = Default__UIProgressBar_ProgressBarBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIProgressBar.ProgressBarBackgroundImageTemplate'*/;
		FillImageComponent = Default__UIProgressBar_ProgressBarFillImageTemplate/*Ref UIComp_DrawImage'Default__UIProgressBar.ProgressBarFillImageTemplate'*/;
		OverlayImageComponent = Default__UIProgressBar_ProgressBarOverlayImageTemplate/*Ref UIComp_DrawImage'Default__UIProgressBar.ProgressBarOverlayImageTemplate'*/;
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
		ProgressBarValue = new UIRoot.UIRangeData
		{
			CurrentValue = 33.0f,
			MinValue = 0.0f,
			MaxValue = 100.0f,
			NudgeValue = 1.0f,
			bIntRange = false,
		};
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
		EventProvider = Default__UIProgressBar_WidgetEventComponent/*Ref UIComp_Event'Default__UIProgressBar.WidgetEventComponent'*/;
	}
}
}