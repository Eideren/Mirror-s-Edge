namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SetMapListPopup : TdUIScene_Popup/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_SetMapListPopup()
	{
		// Object Offset:0x006A62BA
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_SetMapListPopup.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_SetMapListPopup.SceneEventComponent'*/;
	}
}
}