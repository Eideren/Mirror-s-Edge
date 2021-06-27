namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUILevelList : TdUIImageList/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdUILevelList()
	{
		var Default__TdUILevelList_LevelListPresentationComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUILevelList.LevelListPresentationComponent.NormalOverlayTemplate' */;
		var Default__TdUILevelList_LevelListPresentationComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUILevelList.LevelListPresentationComponent.ActiveOverlayTemplate' */;
		var Default__TdUILevelList_LevelListPresentationComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUILevelList.LevelListPresentationComponent.SelectionOverlayTemplate' */;
		var Default__TdUILevelList_LevelListPresentationComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUILevelList.LevelListPresentationComponent.HoverOverlayTemplate' */;
		var Default__TdUILevelList_LevelListPresentationComponent = new TdUIComp_LevelListPresenter
		{
			// Object Offset:0x03149E25
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__TdUILevelList_LevelListPresentationComponent_NormalOverlayTemplate/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = Default__TdUILevelList_LevelListPresentationComponent_ActiveOverlayTemplate/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = Default__TdUILevelList_LevelListPresentationComponent_SelectionOverlayTemplate/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = Default__TdUILevelList_LevelListPresentationComponent_HoverOverlayTemplate/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_LevelListPresenter'Default__TdUILevelList.LevelListPresentationComponent' */;
		var Default__TdUILevelList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUILevelList.WidgetEventComponent' */;
		// Object Offset:0x0068C1A4
		CellDataComponent = Default__TdUILevelList_LevelListPresentationComponent/*Ref TdUIComp_LevelListPresenter'Default__TdUILevelList.LevelListPresentationComponent'*/;
		EventProvider = Default__TdUILevelList_WidgetEventComponent/*Ref UIComp_Event'Default__TdUILevelList.WidgetEventComponent'*/;
	}
}
}