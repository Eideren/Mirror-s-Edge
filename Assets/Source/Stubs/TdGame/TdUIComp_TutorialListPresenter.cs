namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_TutorialListPresenter : TdUIComp_ImageListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public override /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
	
	}
	
	public TdUIComp_TutorialListPresenter()
	{
		var Default__TdUIComp_TutorialListPresenter_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_TutorialListPresenter.NormalOverlayTemplate' */;
		var Default__TdUIComp_TutorialListPresenter_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_TutorialListPresenter.ActiveOverlayTemplate' */;
		var Default__TdUIComp_TutorialListPresenter_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_TutorialListPresenter.SelectionOverlayTemplate' */;
		var Default__TdUIComp_TutorialListPresenter_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_TutorialListPresenter.HoverOverlayTemplate' */;
		// Object Offset:0x006837FD
		UnselectedBgColor = new Color
		{
			R=100,
			G=100,
			B=100,
			A=255
		};
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__TdUIComp_TutorialListPresenter_NormalOverlayTemplate/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.NormalOverlayTemplate'*/,
			[1] = Default__TdUIComp_TutorialListPresenter_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.ActiveOverlayTemplate'*/,
			[2] = Default__TdUIComp_TutorialListPresenter_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.SelectionOverlayTemplate'*/,
			[3] = Default__TdUIComp_TutorialListPresenter_HoverOverlayTemplate/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}