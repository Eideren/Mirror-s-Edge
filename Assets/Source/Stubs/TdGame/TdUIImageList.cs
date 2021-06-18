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
		var Default__TdUIImageList_ImageListPresentationComponent = new TdUIComp_ImageListPresenter
		{
			// Object Offset:0x0068C11C
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = LoadAsset<UITexture>("Default__TdUIImageList.ImageListPresentationComponent.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = LoadAsset<UITexture>("Default__TdUIImageList.ImageListPresentationComponent.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = LoadAsset<UITexture>("Default__TdUIImageList.ImageListPresentationComponent.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = LoadAsset<UITexture>("Default__TdUIImageList.ImageListPresentationComponent.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIImageList.ImageListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: TdUIComp_ImageListPresenter'Default__TdUIImageList.ImageListPresentationComponent' */;
		// Object Offset:0x00687BA9
		CellDataComponent = Default__TdUIImageList_ImageListPresentationComponent;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIImageList.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIImageList.WidgetEventComponent'*/;
	}
}
}