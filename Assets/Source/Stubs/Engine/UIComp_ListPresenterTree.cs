namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListPresenterTree : UIComp_ListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public UIComp_ListPresenterTree()
	{
		var Default__UIComp_ListPresenterTree_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterTree.NormalOverlayTemplate' */;
		var Default__UIComp_ListPresenterTree_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterTree.ActiveOverlayTemplate' */;
		var Default__UIComp_ListPresenterTree_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterTree.SelectionOverlayTemplate' */;
		var Default__UIComp_ListPresenterTree_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterTree.HoverOverlayTemplate' */;
		// Object Offset:0x0041E25A
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__UIComp_ListPresenterTree_NormalOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterTree.NormalOverlayTemplate'*/,
			[1] = Default__UIComp_ListPresenterTree_ActiveOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterTree.ActiveOverlayTemplate'*/,
			[2] = Default__UIComp_ListPresenterTree_SelectionOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterTree.SelectionOverlayTemplate'*/,
			[3] = Default__UIComp_ListPresenterTree_HoverOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterTree.HoverOverlayTemplate'*/,
	 	};
	}
}
}