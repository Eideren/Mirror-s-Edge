namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIListBase : UIList/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public override /*event */void PostInitialize()
	{
	
	}
	
	// Export UTdUIListBase::execGetCellFieldValue(FFrame&, void* const)
	public virtual /*native function */bool GetCellFieldValue(UIList InList, name InCellTag, int InListIndex, ref UIRoot.UIProviderFieldValue OutValue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUIListBase::execGetRowHeight(FFrame&, void* const)
	public override /*native function */float GetRowHeight(/*optional */int? _RowIndex = default, /*optional */bool? _bColHeader = default, /*optional */bool? _bReturnUnformattedValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdUIListBase()
	{
		// Object Offset:0x006878F2
		WrapType = UIList.EListWrapBehavior.LISTWRAP_Jump;
		CellDataComponent = new UIComp_ListPresenter
		{
			// Object Offset:0x00687A25
			ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
			{ 
				[0] = LoadAsset<UITexture>("Default__TdUIListBase.ListPresentationComponent.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.NormalOverlayTemplate'*/,
				[1] = LoadAsset<UITexture>("Default__TdUIListBase.ListPresentationComponent.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.ActiveOverlayTemplate'*/,
				[2] = LoadAsset<UITexture>("Default__TdUIListBase.ListPresentationComponent.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.SelectionOverlayTemplate'*/,
				[3] = LoadAsset<UITexture>("Default__TdUIListBase.ListPresentationComponent.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIListBase.ListPresentationComponent.HoverOverlayTemplate'*/,
	 		},
		}/* Reference: UIComp_ListPresenter'Default__TdUIListBase.ListPresentationComponent' */;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIListBase.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUIListBase.WidgetEventComponent'*/;
	}
}
}