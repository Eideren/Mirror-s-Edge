namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIProgressBar : UIObject, 
		UIDataStorePublisher/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIDataStorePublisher;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage BackgroundImageComponent;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage FillImageComponent;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage OverlayImageComponent;
	public/*(Image)*/ bool bDrawOverlay;
	public/*(Data)*/ /*private editconst */UIRoot.UIDataStoreBinding DataSource;
	public/*(ProgressBar)*/ UIRoot.UIRangeData ProgressBarValue;
	public/*(ProgressBar)*/ UIRoot.EUIOrientation ProgressBarOrientation;
	
	public virtual /*protected final function */void OnSetProgressBarValue(UIAction_SetProgressBarValue Action)
	{
	
	}
	
	public virtual /*protected final function */void OnGetProgressBarValue(UIAction_GetProgressBarValue Action)
	{
	
	}
	
	// Export UUIProgressBar::execSetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */void SetDataStoreBinding(String MarkupText, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIProgressBar::execGetDataStoreBinding(FFrame&, void* const)
	public virtual /*native final function */String GetDataStoreBinding(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIProgressBar::execRefreshSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIProgressBar::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public virtual /*native final function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIProgressBar::execGetBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIProgressBar::execClearBoundDataStores(FFrame&, void* const)
	public virtual /*native final function */void ClearBoundDataStores()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIProgressBar::execSaveSubscriberValue(FFrame&, void* const)
	public virtual /*native final function */bool SaveSubscriberValue(ref array<UIDataStore> out_BoundDataStores, /*optional */int? _BindingIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIProgressBar::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(/*coerce */float NewValue, /*optional */bool? _bPercentageValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIProgressBar::execGetValue(FFrame&, void* const)
	public virtual /*native final function */float GetValue(/*optional */bool? _bPercentageValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */void SetBackgroundImage(Surface NewImage)
	{
	
	}
	
	public virtual /*final function */void SetFillImage(Surface NewImage)
	{
	
	}
	
	public virtual /*final function */void SetOverlayImage(Surface NewImage)
	{
	
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
		// Object Offset:0x0044BCA4
		BackgroundImageComponent = Default__UIProgressBar_ProgressBarBackgroundImageTemplate;
		FillImageComponent = Default__UIProgressBar_ProgressBarFillImageTemplate;
		OverlayImageComponent = Default__UIProgressBar_ProgressBarOverlayImageTemplate;
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
		EventProvider = LoadAsset<UIComp_Event>("Default__UIProgressBar.WidgetEventComponent")/*Ref UIComp_Event'Default__UIProgressBar.WidgetEventComponent'*/;
	}
}
}