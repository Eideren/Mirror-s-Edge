namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIComp_ListPresenterCascade : UIComp_ListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public UIComp_ListPresenterCascade()
	{
		// Object Offset:0x0041D767
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__UIComp_ListPresenterCascade.NormalOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterCascade.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__UIComp_ListPresenterCascade.ActiveOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterCascade.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__UIComp_ListPresenterCascade.SelectionOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterCascade.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__UIComp_ListPresenterCascade.HoverOverlayTemplate")/*Ref UITexture'Default__UIComp_ListPresenterCascade.HoverOverlayTemplate'*/,
	 	};
	}
}
}