namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_HostMatch : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_HostMatch()
	{
		// Object Offset:0x0069A332
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_HostMatch.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_HostMatch.SceneEventComponent'*/;
	}
}
}