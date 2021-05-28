namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_OnlineMessageTicker : TdUIScene_Overlay/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*deprecated transient */UIObject Ticker;
	public /*deprecated */float AnimDuration;
	public /*deprecated */float AnimTimeCount;
	public /*deprecated */bool bSceneInitialized;
	public /*deprecated */float TickerDefaultY;
	
	public TdUIScene_OnlineMessageTicker()
	{
		// Object Offset:0x006A4794
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_OnlineMessageTicker.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_OnlineMessageTicker.SceneEventComponent'*/;
	}
}
}