namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UITexture : UIRoot/*
		native
		editinlinenew
		hidecategories(Object,UIRoot)*/{
	[transient] public/*private*/ UIRoot.UICombinedStyleData ImageStyleData;
	public Surface ImageTexture;
	
	// Export UUITexture::execSetImageStyle(FFrame&, void* const)
	public virtual /*native final function */void SetImageStyle(UIStyle_Image NewImageStyle)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UUITexture::execHasValidStyleData(FFrame&, void* const)
	public virtual /*native final function */bool HasValidStyleData()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*final function */Surface GetSurface()
	{
		// stub
		return default;
	}
	
	public UITexture()
	{
		// Object Offset:0x0041C75D
		ImageStyleData = new UIRoot.UICombinedStyleData
		{
			TextColor = new LinearColor
			{
				R=0.0f,
				G=0.0f,
				B=0.0f,
				A=1.0f
			},
			ImageColor = new LinearColor
			{
				R=0.0f,
				G=0.0f,
				B=0.0f,
				A=1.0f
			},
			TextPadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = 0.0f,
				[1] = 0.0f,
			},
			ImagePadding = new StaticArray<float, float>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
			{
				[0] = 0.0f,
				[1] = 0.0f,
			},
			DrawFont = default,
			FallbackImage = default,
			AtlasCoords = new UIRoot.TextureCoordinates
			{
				U = 0.0f,
				V = 0.0f,
				UL = 0.0f,
				VL = 0.0f,
			},
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
			TextClipMode = default,
			TextClipAlignment = UIRoot.EUIAlignment.UIALIGN_Left,
			AdjustmentType = new StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/()
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
			TextAutoScaling = new UIRoot.TextAutoScaleValue
			{
				MinScale = 0.60f,
				AutoScaleMode = UIRoot.ETextAutoScaleMode.UIAUTOSCALE_None,
			},
			TextScale = new Vector2D
			{
				X=1.0f,
				Y=1.0f
			},
			TextSpacingAdjust = new Vector2D
			{
				X=0.0f,
				Y=0.0f
			},
			bInitialized = false,
		};
	}
}
}