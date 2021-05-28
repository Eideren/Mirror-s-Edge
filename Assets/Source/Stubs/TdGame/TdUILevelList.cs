namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUILevelList : TdUIImageList/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdUILevelList()
	{
		// Object Offset:0x0068C1A4
		CellDataComponent = new TdUIComp_LevelListPresenter
		{
			// Object Offset:0x03149E25
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = LoadAsset<UITexture>("Default__TdUILevelList.LevelListPresentationComponent.NormalOverlayTemplate")/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = LoadAsset<UITexture>("Default__TdUILevelList.LevelListPresentationComponent.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = LoadAsset<UITexture>("Default__TdUILevelList.LevelListPresentationComponent.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = LoadAsset<UITexture>("Default__TdUILevelList.LevelListPresentationComponent.HoverOverlayTemplate")/*Ref UITexture'Default__TdUILevelList.LevelListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_LevelListPresenter'Default__TdUILevelList.LevelListPresentationComponent' */;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUILevelList.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUILevelList.WidgetEventComponent'*/;
	}
}
}