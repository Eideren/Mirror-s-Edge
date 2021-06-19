namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ButtonBar : TdUIScene_Overlay/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_ButtonBar()
	{
		var Default__TdUIScene_ButtonBar_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ButtonBar.SceneEventComponent' */;
		// Object Offset:0x0068E8DC
		EventProvider = Default__TdUIScene_ButtonBar_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ButtonBar.SceneEventComponent'*/;
	}
}
}