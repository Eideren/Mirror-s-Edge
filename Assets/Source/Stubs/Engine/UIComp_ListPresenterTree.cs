namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListPresenterTree : UIComp_ListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public UIComp_ListPresenterTree()
	{
		// Object Offset:0x0041E25A
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__UIComp_ListPresenterTree.NormalOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterTree.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__UIComp_ListPresenterTree.ActiveOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterTree.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__UIComp_ListPresenterTree.SelectionOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterTree.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__UIComp_ListPresenterTree.HoverOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterTree.HoverOverlayTemplate'*/,
	 	};
	}
}
}