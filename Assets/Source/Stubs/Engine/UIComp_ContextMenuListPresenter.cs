namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ContextMenuListPresenter : UIComp_ListPresenterCascade/* within UIContextMenu*//*
		native
		hidecategories(Object)*/{
	public new UIContextMenu Outer => base.Outer as UIContextMenu;
	
	public UIComp_ContextMenuListPresenter()
	{
		// Object Offset:0x0041D87E
		bDisplayColumnHeaders = false;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__UIComp_ContextMenuListPresenter.NormalOverlayTemplate")/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__UIComp_ContextMenuListPresenter.ActiveOverlayTemplate")/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__UIComp_ContextMenuListPresenter.SelectionOverlayTemplate")/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__UIComp_ContextMenuListPresenter.HoverOverlayTemplate")/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}