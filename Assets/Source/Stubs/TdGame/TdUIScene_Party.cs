namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Party : TdUIScene_Popup/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_Party()
	{
		// Object Offset:0x006A54F7
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_Party.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_Party.SceneEventComponent'*/;
	}
}
}