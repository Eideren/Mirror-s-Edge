namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SubMenu : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void RegisterFocusLabelParents(UIScreenObject Parent)
	{
		// stub
	}
	
	public virtual /*function */void UpdateFocusLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public TdUIScene_SubMenu()
	{
		var Default__TdUIScene_SubMenu_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SubMenu.SceneEventComponent' */;
		// Object Offset:0x00563DC9
		EventProvider = Default__TdUIScene_SubMenu_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SubMenu.SceneEventComponent'*/;
	}
}
}