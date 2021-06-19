namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListPresenterCascade : UIComp_ListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public UIComp_ListPresenterCascade()
	{
		var Default__UIComp_ListPresenterCascade_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterCascade.NormalOverlayTemplate' */;
		var Default__UIComp_ListPresenterCascade_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterCascade.ActiveOverlayTemplate' */;
		var Default__UIComp_ListPresenterCascade_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterCascade.SelectionOverlayTemplate' */;
		var Default__UIComp_ListPresenterCascade_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__UIComp_ListPresenterCascade.HoverOverlayTemplate' */;
		// Object Offset:0x0041D767
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__UIComp_ListPresenterCascade_NormalOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterCascade.NormalOverlayTemplate'*/,
			[1] = Default__UIComp_ListPresenterCascade_ActiveOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterCascade.ActiveOverlayTemplate'*/,
			[2] = Default__UIComp_ListPresenterCascade_SelectionOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterCascade.SelectionOverlayTemplate'*/,
			[3] = Default__UIComp_ListPresenterCascade_HoverOverlayTemplate/*Ref UITexture'Default__UIComp_ListPresenterCascade.HoverOverlayTemplate'*/,
	 	};
	}
}
}