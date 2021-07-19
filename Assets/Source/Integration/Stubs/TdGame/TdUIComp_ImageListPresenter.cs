namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_ImageListPresenter : TdUIComp_ListPresenterBase/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	[Category("TdImageListProperties")] public Font SelectedFont;
	[Category("TdImageListProperties")] public Font UnselectedFont;
	[Category("TdImageListProperties")] public Object.Color SelectedBgColor;
	[Category("TdImageListProperties")] public Object.Color UnselectedBgColor;
	[Category("TdImageListProperties")] public bool bDrawBackground;
	[Category("TdImageListProperties")] public float Padding_X;
	[Category("TdImageListProperties")] public float Padding_Y;
	
	public override /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
		// stub
	}
	
	public TdUIComp_ImageListPresenter()
	{
		var Default__TdUIComp_ImageListPresenter_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ImageListPresenter.NormalOverlayTemplate' */;
		var Default__TdUIComp_ImageListPresenter_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ImageListPresenter.ActiveOverlayTemplate' */;
		var Default__TdUIComp_ImageListPresenter_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ImageListPresenter.SelectionOverlayTemplate' */;
		var Default__TdUIComp_ImageListPresenter_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ImageListPresenter.HoverOverlayTemplate' */;
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
			[0] = Default__TdUIComp_ImageListPresenter_NormalOverlayTemplate/*Ref UITexture'Default__TdUIComp_ImageListPresenter.NormalOverlayTemplate'*/,
			[1] = Default__TdUIComp_ImageListPresenter_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIComp_ImageListPresenter.ActiveOverlayTemplate'*/,
			[2] = Default__TdUIComp_ImageListPresenter_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIComp_ImageListPresenter.SelectionOverlayTemplate'*/,
			[3] = Default__TdUIComp_ImageListPresenter_HoverOverlayTemplate/*Ref UITexture'Default__TdUIComp_ImageListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}