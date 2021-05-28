namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TempLoginScene : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_TempLoginScene()
	{
		// Object Offset:0x006B0E6E
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_TempLoginScene.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_TempLoginScene.SceneEventComponent'*/;
	}
}
}