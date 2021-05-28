namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_MenuListPresenter : TdUIComp_ListPresenterBase/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public/*()*/ int CaptionHeight;
	
	public override /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
	
	}
	
	public TdUIComp_MenuListPresenter()
	{
		// Object Offset:0x006830CD
		CaptionHeight = 20;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__TdUIComp_MenuListPresenter.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIComp_MenuListPresenter.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__TdUIComp_MenuListPresenter.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIComp_MenuListPresenter.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__TdUIComp_MenuListPresenter.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIComp_MenuListPresenter.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__TdUIComp_MenuListPresenter.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIComp_MenuListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}