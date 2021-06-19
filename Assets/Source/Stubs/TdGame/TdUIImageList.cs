namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIImageList : TdUIListBase/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	// Export UTdUIImageList::execGetRowHeight(FFrame&, void* const)
	public override /*native function */float GetRowHeight(/*optional */int? _RowIndex = default, /*optional */bool? _bColHeader = default, /*optional */bool? _bReturnUnformattedValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdUIImageList()
	{
		var Default__TdUIImageList_ImageListPresentationComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIImageList.ImageListPresentationComponent.NormalOverlayTemplate' */;
		var Default__TdUIImageList_ImageListPresentationComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIImageList.ImageListPresentationComponent.ActiveOverlayTemplate' */;
		var Default__TdUIImageList_ImageListPresentationComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIImageList.ImageListPresentationComponent.SelectionOverlayTemplate' */;
		var Default__TdUIImageList_ImageListPresentationComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIImageList.ImageListPresentationComponent.HoverOverlayTemplate' */;
		var Default__TdUIImageList_ImageListPresentationComponent = new TdUIComp_ImageListPresenter
		{
			// Object Offset:0x0068C11C
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__TdUIImageList_ImageListPresentationComponent_NormalOverlayTemplate/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = Default__TdUIImageList_ImageListPresentationComponent_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = Default__TdUIImageList_ImageListPresentationComponent_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = Default__TdUIImageList_ImageListPresentationComponent_HoverOverlayTemplate/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_ImageListPresenter'Default__TdUIImageList.ImageListPresentationComponent' */;
		var Default__TdUIImageList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIImageList.WidgetEventComponent' */;
		// Object Offset:0x00687BA9
		CellDataComponent = Default__TdUIImageList_ImageListPresentationComponent/*Ref TdUIComp_ImageListPresenter'Default__TdUIImageList.ImageListPresentationComponent'*/;
		EventProvider = Default__TdUIImageList_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIImageList.WidgetEventComponent'*/;
	}
}
}