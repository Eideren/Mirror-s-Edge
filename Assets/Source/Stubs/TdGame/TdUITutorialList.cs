namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITutorialList : TdUIImageList/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdUITutorialList()
	{
		// Object Offset:0x006BC4AD
		CellDataComponent = new TdUIComp_TutorialListPresenter
		{
			// Object Offset:0x03149F95
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = LoadAsset<UITexture>("Default__TdUITutorialList.TutorialListPresentationComponent.NormalOverlayTemplate")/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = LoadAsset<UITexture>("Default__TdUITutorialList.TutorialListPresentationComponent.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = LoadAsset<UITexture>("Default__TdUITutorialList.TutorialListPresentationComponent.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = LoadAsset<UITexture>("Default__TdUITutorialList.TutorialListPresentationComponent.HoverOverlayTemplate")/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_TutorialListPresenter'Default__TdUITutorialList.TutorialListPresentationComponent' */;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITutorialList.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITutorialList.WidgetEventComponent'*/;
	}
}
}