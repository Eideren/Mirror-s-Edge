namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_EndLogo : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIImage Logo;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public TdUIScene_EndLogo()
	{
		// Object Offset:0x0069559F
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_EndLogo.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_EndLogo.SceneEventComponent'*/;
	}
}
}