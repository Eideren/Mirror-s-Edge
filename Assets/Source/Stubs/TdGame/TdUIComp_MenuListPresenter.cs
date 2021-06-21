namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_MenuListPresenter : TdUIComp_ListPresenterBase/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public/*()*/ int CaptionHeight;
	
	public override /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
		// stub
	}
	
	public TdUIComp_MenuListPresenter()
	{
		var Default__TdUIComp_MenuListPresenter_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_MenuListPresenter.NormalOverlayTemplate' */;
		var Default__TdUIComp_MenuListPresenter_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_MenuListPresenter.ActiveOverlayTemplate' */;
		var Default__TdUIComp_MenuListPresenter_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_MenuListPresenter.SelectionOverlayTemplate' */;
		var Default__TdUIComp_MenuListPresenter_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_MenuListPresenter.HoverOverlayTemplate' */;
		// Object Offset:0x006830CD
		CaptionHeight = 20;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__TdUIComp_MenuListPresenter_NormalOverlayTemplate/*Ref UITexture'Default__TdUIComp_MenuListPresenter.NormalOverlayTemplate'*/,
			[1] = Default__TdUIComp_MenuListPresenter_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIComp_MenuListPresenter.ActiveOverlayTemplate'*/,
			[2] = Default__TdUIComp_MenuListPresenter_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIComp_MenuListPresenter.SelectionOverlayTemplate'*/,
			[3] = Default__TdUIComp_MenuListPresenter_HoverOverlayTemplate/*Ref UITexture'Default__TdUIComp_MenuListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}