namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_LevelListPresenter : TdUIComp_ImageListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public TdUIComp_LevelListPresenter()
	{
		var Default__TdUIComp_LevelListPresenter_NormalOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_LevelListPresenter.NormalOverlayTemplate' */;
		var Default__TdUIComp_LevelListPresenter_ActiveOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_LevelListPresenter.ActiveOverlayTemplate' */;
		var Default__TdUIComp_LevelListPresenter_SelectionOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_LevelListPresenter.SelectionOverlayTemplate' */;
		var Default__TdUIComp_LevelListPresenter_HoverOverlayTemplate = new UITexture
		{
		}/* Reference: UITexture'Default__TdUIComp_LevelListPresenter.HoverOverlayTemplate' */;
		// Object Offset:0x00682D23
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = Default__TdUIComp_LevelListPresenter_NormalOverlayTemplate/*Ref UITexture'Default__TdUIComp_LevelListPresenter.NormalOverlayTemplate'*/,
			[1] = Default__TdUIComp_LevelListPresenter_ActiveOverlayTemplate/*Ref UITexture'Default__TdUIComp_LevelListPresenter.ActiveOverlayTemplate'*/,
			[2] = Default__TdUIComp_LevelListPresenter_SelectionOverlayTemplate/*Ref UITexture'Default__TdUIComp_LevelListPresenter.SelectionOverlayTemplate'*/,
			[3] = Default__TdUIComp_LevelListPresenter_HoverOverlayTemplate/*Ref UITexture'Default__TdUIComp_LevelListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}