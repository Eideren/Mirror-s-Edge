namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIListBase : UIList/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	// Export UTdUIListBase::execGetCellFieldValue(FFrame&, void* const)
	public virtual /*native function */bool GetCellFieldValue(UIList InList, name InCellTag, int InListIndex, ref UIRoot.UIProviderFieldValue OutValue)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdUIListBase::execGetRowHeight(FFrame&, void* const)
	public override /*native function */float GetRowHeight(/*optional */int? _RowIndex = default, /*optional */bool? _bColHeader = default, /*optional */bool? _bReturnUnformattedValue = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public TdUIListBase()
	{
		var Default__TdUIListBase_ListPresentationComponent_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIListBase.ListPresentationComponent.NormalOverlayTemplate' */;
		var Default__TdUIListBase_ListPresentationComponent_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIListBase.ListPresentationComponent.ActiveOverlayTemplate' */;
		var Default__TdUIListBase_ListPresentationComponent_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIListBase.ListPresentationComponent.SelectionOverlayTemplate' */;
		var Default__TdUIListBase_ListPresentationComponent_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIListBase.ListPresentationComponent.HoverOverlayTemplate' */;
		var Default__TdUIListBase_ListPresentationComponent = new UIComp_ListPresenter
		{
			// Object Offset:0x00687A25
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = Default__TdUIListBase_ListPresentationComponent_NormalOverlayTemplate/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = Default__TdUIListBase_ListPresentationComponent_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = Default__TdUIListBase_ListPresentationComponent_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = Default__TdUIListBase_ListPresentationComponent_HoverOverlayTemplate/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: UIComp_ListPresenter'Default__TdUIListBase.ListPresentationComponent' */;
		var Default__TdUIListBase_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIListBase.WidgetEventComponent' */;
		// Object Offset:0x006878F2
		WrapType = UIList.EListWrapBehavior.LISTWRAP_Jump;
		CellDataComponent = Default__TdUIListBase_ListPresentationComponent/*Ref UIComp_ListPresenter'Default__TdUIListBase.ListPresentationComponent'*/;
		EventProvider = Default__TdUIListBase_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIListBase.WidgetEventComponent'*/;
	}
}
}