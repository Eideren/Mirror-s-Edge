namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_HUD : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public virtual /*function */void ShowMessage()
	{
	
	}
	
	public TdUIScene_HUD()
	{
		// Object Offset:0x0069A41F
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_HUD.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_HUD.SceneEventComponent'*/;
	}
}
}