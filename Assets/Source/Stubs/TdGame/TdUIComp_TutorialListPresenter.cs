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
			[0] = LoadAsset<UITexture>("Default__TdUIComp_TutorialListPresenter.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__TdUIComp_TutorialListPresenter.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__TdUIComp_TutorialListPresenter.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__TdUIComp_TutorialListPresenter.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIComp_TutorialListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}