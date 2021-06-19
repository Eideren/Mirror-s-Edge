namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_FindMatch : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_FindMatch()
	{
		var Default__TdUIScene_FindMatch_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_FindMatch.SceneEventComponent' */;
		// Object Offset:0x0069896F
		EventProvider = Default__TdUIScene_FindMatch_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_FindMatch.SceneEventComponent'*/;
	}
}
}