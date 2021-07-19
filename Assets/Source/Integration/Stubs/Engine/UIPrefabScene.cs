namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPrefabScene : UIScene/*
		transient
		native
		hidecategories(Object,UIRoot,Object)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FCallbackEventDevice;
	
	public UIPrefabScene()
	{
		var Default__UIPrefabScene_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIPrefabScene.SceneEventComponent' */;
		// Object Offset:0x0044B142
		EventProvider = Default__UIPrefabScene_SceneEventComponent/*Ref UIComp_Event'Default__UIPrefabScene.SceneEventComponent'*/;
	}
}
}