namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawString : UIComp_DrawComponents, 
		UIStyleResolver/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIStyleResolver;
	[transient] public UIDataStoreSubscriber SubscriberOwner;
	public name StyleResolverTag;
	[transient] public/*private*/ UIString ValueString;
	[Const, transient] public Core.ClassT<UIString> StringClass;
	[Category("Presentation")] public StaticArray<UIRoot.AutoSizeData, UIRoot.AutoSizeData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ AutoSizeParameters;
	[Category("Presentation")] public/*private*/ StaticArray<UIRoot.UIRenderingSubregion, UIRoot.UIRenderingSubregion>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ ClampRegion;
	[Category("Presentation")] public bool bDisablePixelAligning;
	[Category("Data")] public bool bIgnoreMarkup;
	[Category("Debug")] [transient] public bool bRefreshString;
	[transient] public bool bReapplyFormatting;
	[Category("StyleOverride")] public UIRoot.UITextStyleOverride TextStyleCustomization;
	public/*private*/ UIRoot.UIStyleReference StringStyle;
	[Category("Presentation")] public StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ Padding;
	
	// Export UUIComp_DrawString::execSetValue(FFrame&, void* const)
	public virtual /*native final function */void SetValue(String NewText)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execGetValue(FFrame&, void* const)
	public virtual /*native final function */String GetValue(/*optional */bool? _bReturnProcessedText = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execRefreshValue(FFrame&, void* const)
	public virtual /*native final function */void RefreshValue()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execIsSubregionEnabled(FFrame&, void* const)
	public virtual /*native final function */bool IsSubregionEnabled(UIRoot.EUIOrientation Orientation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execGetSubregionSize(FFrame&, void* const)
	public virtual /*native final function */float GetSubregionSize(UIRoot.EUIOrientation Orientation, /*optional */UIRoot.EUIExtentEvalType? _OutputType = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execGetSubregionOffset(FFrame&, void* const)
	public virtual /*native final function */float GetSubregionOffset(UIRoot.EUIOrientation Orientation, /*optional */UIRoot.EUIExtentEvalType? _OutputType = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execGetSubregionAlignment(FFrame&, void* const)
	public virtual /*native final function */UIRoot.EUIAlignment GetSubregionAlignment(UIRoot.EUIOrientation Orientation)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execEnableSubregion(FFrame&, void* const)
	public virtual /*native final function */void EnableSubregion(UIRoot.EUIOrientation Orientation, /*optional */bool? _bShouldEnable = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetSubregionSize(FFrame&, void* const)
	public virtual /*native final function */void SetSubregionSize(UIRoot.EUIOrientation Orientation, float NewValue, UIRoot.EUIExtentEvalType EvalType)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetSubregionOffset(FFrame&, void* const)
	public virtual /*native final function */void SetSubregionOffset(UIRoot.EUIOrientation Orientation, float NewValue, UIRoot.EUIExtentEvalType EvalType)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetSubregionAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetSubregionAlignment(UIRoot.EUIOrientation Orientation, UIRoot.EUIAlignment NewValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetColor(FFrame&, void* const)
	public virtual /*native final function */void SetColor(Object.LinearColor NewColor)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetOpacity(FFrame&, void* const)
	public virtual /*native final function */void SetOpacity(float NewOpacity)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetPadding(FFrame&, void* const)
	public virtual /*native final function */void SetPadding(float HorizontalPadding, float VerticalPadding)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetFont(FFrame&, void* const)
	public virtual /*native final function */void SetFont(Font NewFont)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetAttributes(FFrame&, void* const)
	public virtual /*native final function */void SetAttributes(UIRoot.UITextAttributes NewAttributes)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetAlignment(UIRoot.EUIOrientation Orientation, UIRoot.EUIAlignment NewAlignment)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetWrapMode(FFrame&, void* const)
	public virtual /*native final function */void SetWrapMode(UIRoot.ETextClipMode NewClipMode)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetClipAlignment(FFrame&, void* const)
	public virtual /*native final function */void SetClipAlignment(UIRoot.EUIAlignment NewClipAlignment)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetAutoScaling(FFrame&, void* const)
	public virtual /*native final function */void SetAutoScaling(UIRoot.ETextAutoScaleMode NewAutoScaleMode, /*optional */float? _NewMinScaleValue = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetScale(FFrame&, void* const)
	public virtual /*native final function */void SetScale(UIRoot.EUIOrientation Orientation, float NewScale)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execSetSpacingAdjust(FFrame&, void* const)
	public virtual /*native final function */void SetSpacingAdjust(UIRoot.EUIOrientation Orientation, float NewSpacingAdjust)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomColor(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomColor()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomOpacity(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomOpacity()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomPadding(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomPadding()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomFont(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomFont()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomAttributes(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomAttributes()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomAlignment(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomAlignment()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomClipMode(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomClipMode()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomClipAlignment(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomClipAlignment()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomAutoScaling(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomAutoScaling()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomScale(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomScale()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execDisableCustomSpacingAdjust(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomSpacingAdjust()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUIComp_DrawString::execGetWrapMode(FFrame&, void* const)
	public virtual /*native final function */UIRoot.ETextClipMode GetWrapMode()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execGetAppliedStringStyle(FFrame&, void* const)
	public virtual /*native final function */UIStyle_Combo GetAppliedStringStyle(/*optional */UIState _DesiredMenuState = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execGetFinalStringStyle(FFrame&, void* const)
	public virtual /*native final function */bool GetFinalStringStyle(ref UIRoot.UICombinedStyleData FinalStyleData)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execGetStyleResolverTag(FFrame&, void* const)
	public virtual /*native final function */name GetStyleResolverTag()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execSetStyleResolverTag(FFrame&, void* const)
	public virtual /*native final function */bool SetStyleResolverTag(name NewResolverTag)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execNotifyResolveStyle(FFrame&, void* const)
	public virtual /*native final function */bool NotifyResolveStyle(UISkin ActiveSkin, bool bClearExistingValue, /*optional */UIState _CurrentMenuState = default, /*const optional */name? _StylePropertyName = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIComp_DrawString::execSetAutoSizeExtent(FFrame&, void* const)
	public virtual /*native final function */void SetAutoSizeExtent(UIRoot.EUIOrientation Orientation, float MinValue, float MaxValue, UIRoot.EUIExtentEvalType MinScaleType, UIRoot.EUIExtentEvalType MaxScaleType)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*final function */bool IsAutoSizeEnabled(UIRoot.EUIOrientation Orientation)
	{
		// stub
		return default;
	}
	
	public virtual /*final event */void EnableAutoSizing(UIRoot.EUIOrientation Orientation, /*optional */bool? _bShouldEnable = default)
	{
		// stub
	}
	
	public virtual /*final event */void SetAutoSizePadding(UIRoot.EUIOrientation Orientation, float NearValue, float FarValue, UIRoot.EUIExtentEvalType NearScaleType, UIRoot.EUIExtentEvalType FarScaleType)
	{
		// stub
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