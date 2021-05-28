namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPrefabScene : UIScene/*
		transient
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*private native const noexport */Object.Pointer VfTable_FCallbackEventDevice;
	
	public UIPrefabScene()
	{
		// Object Offset:0x0044B142
		EventProvider = LoadAsset<UIComp_Event>("Default__UIPrefabScene.SceneEventComponent")/*Ref UIComp_Event'Default__UIPrefabScene.SceneEventComponent'*/;
	}
}
}