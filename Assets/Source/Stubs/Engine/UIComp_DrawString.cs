namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawString : UIComp_DrawComponents, 
		UIStyleResolver/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	public /*private native const noexport */Object.Pointer VfTable_IUIStyleResolver;
	public /*transient */UIDataStoreSubscriber SubscriberOwner;
	public name StyleResolverTag;
	public /*private transient */UIString ValueString;
	public /*const transient */Core.ClassT<UIString> StringClass;
	public/*(Presentation)*/ StaticArray<UIRoot.AutoSizeData, UIRoot.AutoSizeData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ AutoSizeParameters;
	public/*(Presentation)*/ /*private */StaticArray<UIRoot.UIRenderingSubregion, UIRoot.UIRenderingSubregion>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ ClampRegion;
	public/*(Presentation)*/ bool bDisablePixelAligning;
	public/*(Data)*/ bool bIgnoreMarkup;
	public/*(Debug)*/ /*transient */bool bRefreshString;
	public /*transient */bool bReapplyFormatting;
	public/*(StyleOverride)*/ UIRoot.UITextStyleOverride TextStyleCustomization;
	public /*private */UIRoot.UIStyleReference StringStyle;
	public/*(Presentation)*/ StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ Padding;
	
	// Export UUIComp_DrawString::execSetValue(FFrame&, void* const)
	public virtual /*native final function */void SetValue(string NewText)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execGetValue(FFrame&, void* const)
	public virtual /*native final function */string GetValue(/*optional */bool? _bReturnProcessedText = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execRefreshValue(FFrame&, void* const)
	public virtual /*native final function */void RefreshValue()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execIsSubregionEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsSubregionEnabled(UIRoot.EUIOrientation Orientation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execGetSubregionSize(FFrame&, void* const)
	public virtual /*native final function */float GetSubregionSize(UIRoot.EUIOrientation Orientation, /*optional */UIRoot.EUIExtentEvalType? _OutputType = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execGetSubregionOffset(FFrame&, void* const)
	public virtual /*native final function */float GetSubregionOffset(UIRoot.EUIOrientation Orientation, /*optional */UIRoot.EUIExtentEvalType? _OutputType = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execGetSubregionAlignment(FFrame&, void* const)
	public virtual /*native final function */UIRoot.EUIAlignment GetSubregionAlignment(UIRoot.EUIOrientation Orientation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execEnableSubregion(FFrame&, void* const)
	public virtual /*native final function */void EnableSubregion(UIRoot.EUIOrientation Orientation, /*optional */bool? _bShouldEnable = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetSubregionSize(FFrame&, void* const)
	public virtual /*native final function */void SetSubregionSize(UIRoot.EUIOrientation Orientation, float NewValue, UIRoot.EUIExtentEvalType EvalType)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetSubregionOffset(FFrame&, void* const)
	public virtual /*native final function */void SetSubregionOffset(UIRoot.EUIOrientation Orientation, float NewValue, UIRoot.EUIExtentEvalType EvalType)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetSubregionAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetSubregionAlignment(UIRoot.EUIOrientation Orientation, UIRoot.EUIAlignment NewValue)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetColor(FFrame&, void* const)
	public virtual /*native final function */void SetColor(Object.LinearColor NewColor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetOpacity(FFrame&, void* const)
	public virtual /*native final function */void SetOpacity(float NewOpacity)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetPadding(FFrame&, void* const)
	public virtual /*native final function */void SetPadding(float HorizontalPadding, float VerticalPadding)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetFont(FFrame&, void* const)
	public virtual /*native final function */void SetFont(Font NewFont)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetAttributes(FFrame&, void* const)
	public virtual /*native final function */void SetAttributes(UIRoot.UITextAttributes NewAttributes)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetAlignment(UIRoot.EUIOrientation Orientation, UIRoot.EUIAlignment NewAlignment)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetWrapMode(FFrame&, void* const)
	public virtual /*native final function */void SetWrapMode(UIRoot.ETextClipMode NewClipMode)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetClipAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetClipAlignment(UIRoot.EUIAlignment NewClipAlignment)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetAutoScaling(FFrame&, void* const)
	public virtual /*native final function */void SetAutoScaling(UIRoot.ETextAutoScaleMode NewAutoScaleMode, /*optional */float? _NewMinScaleValue = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetScale(FFrame&, void* const)
	public virtual /*native final function */void SetScale(UIRoot.EUIOrientation Orientation, float NewScale)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execSetSpacingAdjust(FFrame&, void* const)
	public virtual /*native final function */void SetSpacingAdjust(UIRoot.EUIOrientation Orientation, float NewSpacingAdjust)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomColor(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomColor()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomOpacity(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomOpacity()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomPadding(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomPadding()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomFont(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomFont()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomAttributes(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomAttributes()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomAlignment(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomAlignment()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomClipMode(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomClipMode()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomClipAlignment(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomClipAlignment()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomAutoScaling(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomAutoScaling()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomScale(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomScale()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execDisableCustomSpacingAdjust(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomSpacingAdjust()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawString::execGetWrapMode(FFrame&, void* const)
	public virtual /*native final function */UIRoot.ETextClipMode GetWrapMode()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execGetAppliedStringStyle(FFrame&, void* const)
	public virtual /*native final function */UIStyle_Combo GetAppliedStringStyle(/*optional */UIState? _DesiredMenuState = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execGetFinalStringStyle(FFrame&, void* const)
	public virtual /*native final function */bool GetFinalStringStyle(ref UIRoot.UICombinedStyleData FinalStyleData)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execGetStyleResolverTag(FFrame&, void* const)
	public virtual /*native final function */name GetStyleResolverTag()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execSetStyleResolverTag(FFrame&, void* const)
	public virtual /*native final function */bool SetStyleResolverTag(name NewResolverTag)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execNotifyResolveStyle(FFrame&, void* const)
	public virtual /*native final function */bool NotifyResolveStyle(UISkin ActiveSkin, bool bClearExistingValue, /*optional */UIState? _CurrentMenuState = default, /*const optional */name? _StylePropertyName = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawString::execSetAutoSizeExtent(FFrame&, void* const)
	public virtual /*native final function */void SetAutoSizeExtent(UIRoot.EUIOrientation Orientation, float MinValue, float MaxValue, UIRoot.EUIExtentEvalType MinScaleType, UIRoot.EUIExtentEvalType MaxScaleType)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */bool IsAutoSizeEnabled(UIRoot.EUIOrientation Orientation)
	{
	
		return default;
	}
	
	public virtual /*final event */void EnableAutoSizing(UIRoot.EUIOrientation Orientation, /*optional */bool? _bShouldEnable = default)
	{
	
	}
	
	public virtual /*final event */void SetAutoSizePadding(UIRoot.EUIOrientation Orientation, float NearValue, float FarValue, UIRoot.EUIExtentEvalType NearScaleType, UIRoot.EUIExtentEvalType FarScaleType)
	{
	
	}
	
	public UIComp_DrawString()
	{
		// Object Offset:0x002DE1AB
		StyleResolverTag = (name)"String Style";
		StringClass = ClassT<UIString>()/*Ref Class'UIString'*/;
		ClampRegion = new StaticArray<UIRoot.UIRenderingSubregion, UIRoot.UIRenderingSubregion>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
		{ 
			[0] = new UIRoot.UIRenderingSubregion
			{
				ClampRegionSize = new UIRoot.UIScreenValue_Extent
				{
					Value = 1.0f,
					ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentSelf,
					Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
				},
				ClampRegionOffset = new UIRoot.UIScreenValue_Extent
				{
					Value = 0.0f,
					ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentSelf,
					Orientation = UIRoot.EUIOrientation.UIORIENT_Horizontal,
				},
				ClampRegionAlignment = UIRoot.EUIAlignment.UIALIGN_Default,
				bSubregionEnabled = false,
			},
			[1] = new UIRoot.UIRenderingSubregion
			{
				ClampRegionSize = new UIRoot.UIScreenValue_Extent
				{
					Value = 1.0f,
					ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentSelf,
					Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
				},
				ClampRegionOffset = new UIRoot.UIScreenValue_Extent
				{
					Value = 0.0f,
					ScaleType = UIRoot.EUIExtentEvalType.UIEXTENTEVAL_PercentSelf,
					Orientation = UIRoot.EUIOrientation.UIORIENT_Vertical,
				},
				ClampRegionAlignment = UIRoot.EUIAlignment.UIALIGN_Default,
				bSubregionEnabled = false,
			},
	 	};
		TextStyleCustomization = new UIRoot.UITextStyleOverride
		{
			DrawFont = default,
			TextAttributes = new UIRoot.UITextAttributes
			{
				Bold = false,
				Italic = false,
				Underline = false,
				Shadow = false,
				Strikethrough = false,
			},
			TextAlignment = new StaticArray<UIRoot.EUIAlignment, UIRoot.EUIAlignment>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = UIRoot.EUIAlignment.UIALIGN_Left,
				[1] = UIRoot.EUIAlignment.UIALIGN_Left,
			},
			ClipMode = UIRoot.ETextClipMode.CLIP_None,
			ClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left,
			AutoScaling = new UIRoot.TextAutoScaleValue
			{
				MinScale = 0.60f,
				AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
			},
			DrawScale = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = 1.0f,
				[1] = 1.0f,
			},
			SpacingAdjust = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = 0.0f,
				[1] = 0.0f,
			},
			bOverrideDrawFont = false,
			bOverrideAttributes = false,
			bOverrideAlignment = false,
			bOverrideClipMode = false,
			bOverrideClipAlignment = false,
			bOverrideAutoScale = false,
			bOverrideScale = false,
			bOverrideSpacingAdjust = false,
			DrawColor = new LinearColor
			{
				R=1.0f,
				G=1.0f,
				B=1.0f,
				A=1.0f
			},
			Opacity = 1.0f,
			Padding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = 0.0f,
				[1] = 0.0f,
			},
			bOverrideDrawColor = false,
			bOverrideOpacity = false,
			bOverridePadding = false,
		};
		StringStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultComboStyle",
			RequiredStyleClass = ClassT<UIStyle_Combo>()/*Ref Class'UIStyle_Combo'*/,
			AssignedStyleID = new UIRoot.STYLE_ID
			{
				A = 0,
				B = 0,
				C = 0,
				D = 0,
			},
			ResolvedStyle = default,
		};
	}
}
}