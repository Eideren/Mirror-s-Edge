namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SetRoleListPopup : TdUIScene_Popup/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_SetRoleListPopup()
	{
		// Object Offset:0x006A6369
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_SetRoleListPopup.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_SetRoleListPopup.SceneEventComponent'*/;
	}
}
}