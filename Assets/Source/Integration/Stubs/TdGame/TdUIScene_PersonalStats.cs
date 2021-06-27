namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_PersonalStats : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_PersonalStats()
	{
		var Default__TdUIScene_PersonalStats_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_PersonalStats.SceneEventComponent' */;
		// Object Offset:0x006A55A6
		EventProvider = Default__TdUIScene_PersonalStats_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_PersonalStats.SceneEventComponent'*/;
	}
}
}