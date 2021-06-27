namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ContextMenuListPresenter : UIComp_ListPresenterCascade/* within UIContextMenu*//*
		native
		hidecategories(Object)*/{
	public new UIContextMenu Outer => base.Outer as UIContextMenu;
	
	public UIComp_ContextMenuListPresenter()
	{
		var Default__UIComp_ContextMenuListPresenter_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ContextMenuListPresenter.NormalOverlayTemplate' */;
		var Default__UIComp_ContextMenuListPresenter_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ContextMenuListPresenter.ActiveOverlayTemplate' */;
		var Default__UIComp_ContextMenuListPresenter_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ContextMenuListPresenter.SelectionOverlayTemplate' */;
		var Default__UIComp_ContextMenuListPresenter_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ContextMenuListPresenter.HoverOverlayTemplate' */;
		// Object Offset:0x0041D87E
		bDisplayColumnHeaders = false;
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__UIComp_ContextMenuListPresenter_NormalOverlayTemplate/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.NormalOverlayTemplate'*/,
			[1] = Default__UIComp_ContextMenuListPresenter_ActiveOverlayTemplate/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.ActiveOverlayTemplate'*/,
			[2] = Default__UIComp_ContextMenuListPresenter_SelectionOverlayTemplate/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.SelectionOverlayTemplate'*/,
			[3] = Default__UIComp_ContextMenuListPresenter_HoverOverlayTemplate/*Ref UITexture'Default__UIComp_ContextMenuListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}