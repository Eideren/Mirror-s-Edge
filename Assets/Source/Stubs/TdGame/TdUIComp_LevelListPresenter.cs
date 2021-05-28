namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIComp_LevelListPresenter : TdUIComp_ImageListPresenter/* within UIList*//*
		native
		hidecategories(Object)*/{
	public new UIList Outer => base.Outer as UIList;
	
	public TdUIComp_LevelListPresenter()
	{
		// Object Offset:0x00682D23
		ListItemOverlay = new StaticArray<UITexture, UITexture, UITexture, UITexture>/*[UIRoot.EUIListElementState.ELEMENT_MAX]*/()
		{ 
			[0] = LoadAsset<UITexture>("Default__TdUIComp_LevelListPresenter.NormalOverlayTemplate")/*Ref UITexture'Default__TdUIComp_LevelListPresenter.NormalOverlayTemplate'*/,
			[1] = LoadAsset<UITexture>("Default__TdUIComp_LevelListPresenter.ActiveOverlayTemplate")/*Ref UITexture'Default__TdUIComp_LevelListPresenter.ActiveOverlayTemplate'*/,
			[2] = LoadAsset<UITexture>("Default__TdUIComp_LevelListPresenter.SelectionOverlayTemplate")/*Ref UITexture'Default__TdUIComp_LevelListPresenter.SelectionOverlayTemplate'*/,
			[3] = LoadAsset<UITexture>("Default__TdUIComp_LevelListPresenter.HoverOverlayTemplate")/*Ref UITexture'Default__TdUIComp_LevelListPresenter.HoverOverlayTemplate'*/,
	 	};
	}
}
}