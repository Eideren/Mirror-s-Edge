namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SubMenu : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void RegisterFocusLabelParents(UIScreenObject Parent)
	{
	
	}
	
	public virtual /*function */void UpdateFocusLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public TdUIScene_SubMenu()
	{
		// Object Offset:0x00563DC9
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_SubMenu.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_SubMenu.SceneEventComponent'*/;
	}
}
}