namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIString : UIRoot/* within UIScreenObject*//*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public new UIScreenObject Outer => base.Outer as UIScreenObject;
	
	public /*native transient */array<Object.Pointer> Nodes;
	public /*transient */UIRoot.UICombinedStyleData StringStyleData;
	public /*transient */Object.Vector2D StringExtent;
	
	// Export UUIString::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(string InputString, bool bIgnoreMarkup)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIString::execGetValue(FFrame&, void* const)
	public virtual /*native final function */string GetValue(/*optional */bool bReturnProcessedText = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIString::execGetAutoScaleValue(FFrame&, void* const)
	public virtual /*native final function */void GetAutoScaleValue(Object.Vector2D BoundingRegionSize, Object.Vector2D StringSize, ref Object.Vector2D out_AutoScalePercent)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIString::execContainsMarkup(FFrame&, void* const)
	public virtual /*native final function */bool ContainsMarkup()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public UIString()
	{
		// Object Offset:0x0042F154
		StringStyleData = new UIRoot.UICombinedStyleData
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
			TextClipMode = UIRoot.ETextClipMode.CLIP_Normal,
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