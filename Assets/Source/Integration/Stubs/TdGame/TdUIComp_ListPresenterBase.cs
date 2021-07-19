namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_ListPresenterBase : UIComp_ListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	[init, noimport, editconst, editinline, transient] public array</*init editconst editinline */TdListElement> ListElements;
	[Category] public int SelectedItemHeight;
	
	public virtual /*event */void DrawElement(Canvas Canvas, int ElementIndex, UIRoot.RenderParameters Parameters, bool bElementIsSelected)
	{
		// stub
	}
	
	public TdUIComp_ListPresenterBase()
	{
		var Default__TdUIComp_ListPresenterBase_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ListPresenterBase.NormalOverlayTemplate' */;
		var Default__TdUIComp_ListPresenterBase_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ListPresenterBase.ActiveOverlayTemplate' */;
		var Default__TdUIComp_ListPresenterBase_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ListPresenterBase.SelectionOverlayTemplate' */;
		var Default__TdUIComp_ListPresenterBase_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_ListPresenterBase.HoverOverlayTemplate' */;
		// Object Offset:0x006823D6
		SelectedItemHeight = 50;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__TdUIComp_ListPresenterBase_NormalOverlayTemplate/*Ref UITexture'Default__TdUIComp_ListPresenterBase.NormalOverlayTemplate'*/,
			[1] = Default__TdUIComp_ListPresenterBase_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIComp_ListPresenterBase.ActiveOverlayTemplate'*/,
			[2] = Default__TdUIComp_ListPresenterBase_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIComp_ListPresenterBase.SelectionOverlayTemplate'*/,
			[3] = Default__TdUIComp_ListPresenterBase_HoverOverlayTemplate/*Ref UITexture'Default__TdUIComp_ListPresenterBase.HoverOverlayTemplate'*/,
	 	};
	}
}
}