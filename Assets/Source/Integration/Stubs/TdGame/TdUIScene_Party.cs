namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Party : TdUIScene_Popup/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIScene_Party()
	{
		var Default__TdUIScene_Party_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Party.SceneEventComponent' */;
		// Object Offset:0x006A54F7
		EventProvider = Default__TdUIScene_Party_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Party.SceneEventComponent'*/;
	}
}
}