namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_AudioVideoSettings : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_AudioVideoSettings()
	{
		// Object Offset:0x0068E30A
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_AudioVideoSettings.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_AudioVideoSettings.SceneEventComponent'*/;
	}
}
}