namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_DrawImage : UIComp_DrawComponents, 
		UIStyleResolver,CustomPropertyItemHandler/* within UIObject*//*
		native
		editinlinenew
		hidecategories(Object)*/{
	public new UIObject Outer => base.Outer as UIObject;
	
	public /*private native const noexport */Object.Pointer VfTable_IUIStyleResolver;
	public /*private native const noexport */Object.Pointer VfTable_ICustomPropertyItemHandler;
	public name StyleResolverTag;
	public/*(StyleOverride)*/ /*export editinlineuse */UITexture ImageRef;
	public/*(StyleOverride)*/ UIRoot.UIImageStyleOverride StyleCustomization;
	public/*(Presentation)*/ bool bDisablePixelAligning;
	public /*private */UIRoot.UIStyleReference ImageStyle;
	
	// Export UUIComp_DrawImage::execGetAppliedImageStyle(FFrame&, void* const)
	public virtual /*native final function */UIStyle_Image GetAppliedImageStyle(/*optional */UIState? _DesiredMenuState = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawImage::execSetImage(FFrame&, void* const)
	public virtual /*native final function */void SetImage(Surface NewImage)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execSetCoordinates(FFrame&, void* const)
	public virtual /*native final function */void SetCoordinates(UIRoot.TextureCoordinates NewCoordinates)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execSetColor(FFrame&, void* const)
	public virtual /*native final function */void SetColor(Object.LinearColor NewColor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execSetOpacity(FFrame&, void* const)
	public virtual /*native final function */void SetOpacity(float NewOpacity)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execSetPadding(FFrame&, void* const)
	public virtual /*native final function */void SetPadding(float HorizontalPadding, float VerticalPadding)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execSetFormatting(FFrame&, void* const)
	public virtual /*native final function */void SetFormatting(UIRoot.EUIOrientation Orientation, UIRoot.UIImageAdjustmentData NewFormattingData)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execDisableCustomCoordinates(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomCoordinates()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execDisableCustomColor(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomColor()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execDisableCustomOpacity(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomOpacity()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execDisableCustomPadding(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomPadding()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execDisableCustomFormatting(FFrame&, void* const)
	public virtual /*native final function */void DisableCustomFormatting()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIComp_DrawImage::execGetImage(FFrame&, void* const)
	public virtual /*native final function */Surface GetImage()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawImage::execGetStyleResolverTag(FFrame&, void* const)
	public virtual /*native final function */name GetStyleResolverTag()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawImage::execSetStyleResolverTag(FFrame&, void* const)
	public virtual /*native final function */bool SetStyleResolverTag(name NewResolverTag)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIComp_DrawImage::execNotifyResolveStyle(FFrame&, void* const)
	public virtual /*native final function */bool NotifyResolveStyle(UISkin ActiveSkin, bool bClearExistingValue, /*optional */UIState? _CurrentMenuState = default, /*const optional */name? _StylePropertyName = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public UIComp_DrawImage()
	{
		// Object Offset:0x002E0198
		StyleResolverTag = (name)"Image Style";
		StyleCustomization = new UIRoot.UIImageStyleOverride
		{
			Coordinates = new UIRoot.TextureCoordinates
			{
				U = 0.0f,
				V = 0.0f,
				UL = 0.0f,
				VL = 0.0f,
			},
			Formatting = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = new UIRoot.UIImageAdjustmentData
			{
				ProtectedRegion = new UIRoot.ScreenPositionRange
				{
					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
					{
						[0] = 0.0f,
						[1] = 0.0f,
					},
					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
					{
						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
					},
				},
				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
			},
				[1] = new UIRoot.UIImageAdjustmentData
			{
				ProtectedRegion = new UIRoot.ScreenPositionRange
				{
					Value = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
					{
						[0] = 0.0f,
						[1] = 0.0f,
					},
					ScaleType = new StaticArray<UIRoot.EPositionEvalType, UIRoot.EPositionEvalType>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
					{
						[0] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
						[1] = UIRoot.EPositionEvalType.EVALPOS_PixelOwner,
					},
				},
				AdjustmentType = UIRoot.EMaterialAdjustmentType.ADJUST_Normal,
				Alignment = UIRoot.EUIAlignment.UIALIGN_Left,
			},
			},
			bOverrideCoordinates = false,
			bOverrideFormatting = false,
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
		ImageStyle = new UIRoot.UIStyleReference
		{
			DefaultStyleTag = (name)"DefaultImageStyle",
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
	}
}
}