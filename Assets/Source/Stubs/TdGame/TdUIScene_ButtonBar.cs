namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ButtonBar : TdUIScene_Overlay/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_ButtonBar()
	{
		// Object Offset:0x0068E8DC
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_ButtonBar.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_ButtonBar.SceneEventComponent'*/;
	}
}
}