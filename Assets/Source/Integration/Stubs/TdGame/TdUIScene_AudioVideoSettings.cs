namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_AudioVideoSettings : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_AudioVideoSettings()
	{
		var Default__TdUIScene_AudioVideoSettings_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_AudioVideoSettings.SceneEventComponent' */;
		// Object Offset:0x0068E30A
		EventProvider = Default__TdUIScene_AudioVideoSettings_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_AudioVideoSettings.SceneEventComponent'*/;
	}
}
}