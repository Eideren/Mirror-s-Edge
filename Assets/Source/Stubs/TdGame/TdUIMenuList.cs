namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIMenuList : TdUIListBase/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIMenuList()
	{
		var Default__TdUIMenuList_MenuListPresentationComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIMenuList.MenuListPresentationComponent.NormalOverlayTemplate' */;
		var Default__TdUIMenuList_MenuListPresentationComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIMenuList.MenuListPresentationComponent.ActiveOverlayTemplate' */;
		var Default__TdUIMenuList_MenuListPresentationComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIMenuList.MenuListPresentationComponent.SelectionOverlayTemplate' */;
		var Default__TdUIMenuList_MenuListPresentationComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIMenuList.MenuListPresentationComponent.HoverOverlayTemplate' */;
		var Default__TdUIMenuList_MenuListPresentationComponent = new TdUIComp_MenuListPresenter
		{
			// Object Offset:0x03149EDD
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__TdUIMenuList_MenuListPresentationComponent_NormalOverlayTemplate/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = Default__TdUIMenuList_MenuListPresentationComponent_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = Default__TdUIMenuList_MenuListPresentationComponent_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = Default__TdUIMenuList_MenuListPresentationComponent_HoverOverlayTemplate/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_MenuListPresenter'Default__TdUIMenuList.MenuListPresentationComponent' */;
		var Default__TdUIMenuList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIMenuList.WidgetEventComponent' */;
		// Object Offset:0x0068C764
		CellDataComponent = Default__TdUIMenuList_MenuListPresentationComponent/*Ref TdUIComp_MenuListPresenter'Default__TdUIMenuList.MenuListPresentationComponent'*/;
		EventProvider = Default__TdUIMenuList_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIMenuList.WidgetEventComponent'*/;
	}
}
}