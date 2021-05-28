namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIMenuList : TdUIListBase/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIMenuList()
	{
		// Object Offset:0x0068C764
		CellDataComponent = new TdUIComp_MenuListPresenter
		{
			// Object Offset:0x03149EDD
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = LoadAsset<UITexture>("Default__TdUIMenuList.MenuListPresentationComponent.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = LoadAsset<UITexture>("Default__TdUIMenuList.MenuListPresentationComponent.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = LoadAsset<UITexture>("Default__TdUIMenuList.MenuListPresentationComponent.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = LoadAsset<UITexture>("Default__TdUIMenuList.MenuListPresentationComponent.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIMenuList.MenuListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_MenuListPresenter'Default__TdUIMenuList.MenuListPresentationComponent' */;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIMenuList.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIMenuList.WidgetEventComponent'*/;
	}
}
}