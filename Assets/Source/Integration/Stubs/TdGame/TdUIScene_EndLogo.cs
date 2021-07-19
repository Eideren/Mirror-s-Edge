namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_EndLogo : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIImage Logo;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public TdUIScene_EndLogo()
	{
		var Default__TdUIScene_EndLogo_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_EndLogo.SceneEventComponent' */;
		// Object Offset:0x0069559F
		EventProvider = Default__TdUIScene_EndLogo_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_EndLogo.SceneEventComponent'*/;
	}
}
}