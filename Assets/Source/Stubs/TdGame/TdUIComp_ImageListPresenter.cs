namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_ImageListPresenter : TdUIComp_ListPresenterBase/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public/*(TdImageListProperties)*/ Font SelectedFont;
	public/*(TdImageListProperties)*/ Font UnselectedFont;
	public/*(TdImageListProperties)*/ Object.Color SelectedBgColor;
	public/*(TdImageListProperties)*/ Object.Color UnselectedBgColor;
	public/*(TdImageListProperties)*/ bool bDrawBackground;
	public/*(TdImageListProperties)*/ float Padding_X;
	public/*(TdImageListProperties)*/ float Padding_Y;
	
	public override /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
	
	}
	
	public TdUIComp_ImageListPresenter()
	{
		// Object Offset:0x00682B2C
		SelectedFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Small_Normal")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Small_Normal'*/;
		UnselectedFont = LoadAsset<MultiFont>("UI_Fonts_Final.Helvetica_Small_Normal")/*Ref MultiFont'UI_Fonts_Final.Helvetica_Small_Normal'*/;
		SelectedBgColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=255
		};
		UnselectedBgColor = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		bDrawBackground = true;
		Padding_X = 5.0f;
		Padding_Y = 5.0f;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__TdUIComp_ImageListPresenter.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ImageListPresenter.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__TdUIComp_ImageListPresenter.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ImageListPresenter.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__TdUIComp_ImageListPresenter.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ImageListPresenter.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__TdUIComp_ImageListPresenter.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ImageListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}