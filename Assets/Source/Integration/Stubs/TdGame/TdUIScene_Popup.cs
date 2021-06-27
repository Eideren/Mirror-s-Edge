namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Popup : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_Popup()
	{
		var Default__TdUIScene_Popup_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Popup.SceneEventComponent' */;
		// Object Offset:0x006A5430
		EventProvider = Default__TdUIScene_Popup_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Popup.SceneEventComponent'*/;
	}
}
}