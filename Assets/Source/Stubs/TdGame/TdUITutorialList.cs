namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITutorialList : TdUIImageList/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdUITutorialList()
	{
		var Default__TdUITutorialList_TutorialListPresentationComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.NormalOverlayTemplate' */;
		var Default__TdUITutorialList_TutorialListPresentationComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.ActiveOverlayTemplate' */;
		var Default__TdUITutorialList_TutorialListPresentationComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.SelectionOverlayTemplate' */;
		var Default__TdUITutorialList_TutorialListPresentationComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.HoverOverlayTemplate' */;
		var Default__TdUITutorialList_TutorialListPresentationComponent = new TdUIComp_TutorialListPresenter
		{
			// Object Offset:0x03149F95
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__TdUITutorialList_TutorialListPresentationComponent_NormalOverlayTemplate/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = Default__TdUITutorialList_TutorialListPresentationComponent_ActiveOverlayTemplate/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = Default__TdUITutorialList_TutorialListPresentationComponent_SelectionOverlayTemplate/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = Default__TdUITutorialList_TutorialListPresentationComponent_HoverOverlayTemplate/*Ref UITexture'Default__TdUITutorialList.TutorialListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_TutorialListPresenter'Default__TdUITutorialList.TutorialListPresentationComponent' */;
		var Default__TdUITutorialList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITutorialList.WidgetEventComponent' */;
		// Object Offset:0x006BC4AD
		CellDataComponent = Default__TdUITutorialList_TutorialListPresentationComponent/*Ref TdUIComp_TutorialListPresenter'Default__TdUITutorialList.TutorialListPresentationComponent'*/;
		EventProvider = Default__TdUITutorialList_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITutorialList.WidgetEventComponent'*/;
	}
}
}