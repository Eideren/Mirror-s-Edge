namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_HostMatch : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_HostMatch()
	{
		var Default__TdUIScene_HostMatch_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_HostMatch.SceneEventComponent' */;
		// Object Offset:0x0069A332
		EventProvider = Default__TdUIScene_HostMatch_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_HostMatch.SceneEventComponent'*/;
	}
}
}