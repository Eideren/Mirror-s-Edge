namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Leaderboard : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_Leaderboard()
	{
		var Default__TdUIScene_Leaderboard_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Leaderboard.SceneEventComponent' */;
		// Object Offset:0x0069A4DA
		EventProvider = Default__TdUIScene_Leaderboard_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Leaderboard.SceneEventComponent'*/;
	}
}
}