namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIImage : TdUIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Widget)*/ /*const */Surface Image;
	public/*(Widget)*/ UIRoot.TextureCoordinates Coordinates;
	public/*(Widget)*/ /*const */Object.LinearColor ImageColor;
	public/*(Widget)*/ bool centered;
	public/*(Widget)*/ bool stretched;
	public float Scale;
	
	// Export UTdUIImage::execSetImage(FFrame&, void* const)
	public virtual /*native function */void SetImage(Surface _newImage, /*optional */UIRoot.TextureCoordinates? __newCoordinates = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdUIImage::execSetScale(FFrame&, void* const)
	public virtual /*native function */void SetScale(float _newScale)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public TdUIImage()
	{
		var Default__TdUIImage_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIImage.WidgetEventComponent' */;
		// Object Offset:0x0068754C
		ImageColor = new LinearColor
		{
			R=1.0f,
			G=1.0f,
			B=1.0f,
			A=1.0f
		};
		Scale = 1.0f;
		EventProvider = Default__TdUIImage_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIImage.WidgetEventComponent'*/;
	}
}
}