namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIStyle_Image : UIStyle_Data/*
		native
		hidecategories(Object,UIRoot)*/{
	public/*()*/ Surface DefaultImage;
	public/*()*/ UIRoot.TextureCoordinates Coordinates;
	public/*()*/ StaticArray<UIRoot.UIImageAdjustmentData, UIRoot.UIImageAdjustmentData>/*[UIRoot.EUIOrientation.UIORIENT_MAX]*/ AdjustmentType;
	
	public UIStyle_Image()
	{
		// Object Offset:0x00452E31
		DefaultImage = LoadAsset<Texture2D>("EngineResources.DefaultTexture")/*Ref Texture2D'EngineResources.DefaultTexture'*/;
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
	 	};
		UIEditorControlClass = "WxStyleImagePropertiesGroup";
	}
}
}