namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_MPPause : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_MPPause()
	{
		// Object Offset:0x006A2741
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_MPPause.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_MPPause.SceneEventComponent'*/;
	}
}
}