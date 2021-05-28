namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_ListPresenterBase : UIComp_ListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public /*init noimport editconst editinline transient */array</*init editconst editinline */TdListElement> ListElements;
	public/*()*/ int SelectedItemHeight;
	
	public virtual /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
	
	}
	
	public TdUIComp_ListPresenterBase()
	{
		// Object Offset:0x006823D6
		SelectedItemHeight = 50;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__TdUIComp_ListPresenterBase.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ListPresenterBase.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__TdUIComp_ListPresenterBase.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ListPresenterBase.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__TdUIComp_ListPresenterBase.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ListPresenterBase.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__TdUIComp_ListPresenterBase.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIComp_ListPresenterBase.HoverOverlayTemplate'*/,
	 	};
	}
}
}