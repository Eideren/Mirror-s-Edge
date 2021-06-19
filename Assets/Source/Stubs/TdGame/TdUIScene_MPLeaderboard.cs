namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_MPLeaderboard : TdUIScene_Leaderboard/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_MPLeaderboard()
	{
		var Default__TdUIScene_MPLeaderboard_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_MPLeaderboard.SceneEventComponent' */;
		// Object Offset:0x006A2692
		EventProvider = Default__TdUIScene_MPLeaderboard_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_MPLeaderboard.SceneEventComponent'*/;
	}
}
}