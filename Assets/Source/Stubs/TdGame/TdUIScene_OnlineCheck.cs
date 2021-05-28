namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_OnlineCheck : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*delegate*/TdUIScene_OnlineCheck.PlayOffline __PlayOffline__Delegate;
	
	public delegate void PlayOffline();
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_PlayOffline(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public virtual /*function */void OnPlayOffline()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed_PlayOffline(UIScene ClosedScene)
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_OnlineCheck()
	{
		// Object Offset:0x006A45A5
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_OnlineCheck.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_OnlineCheck.SceneEventComponent'*/;
	}
}
}