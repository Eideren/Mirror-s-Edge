namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SPPause : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void LostLastCheckpoint_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadLastCheckpoint_PreConfirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnLoadLastCheckpoint_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void LoadLastLevelCheckpoint()
	{
		// stub
	}
	
	public TdUIScene_SPPause()
	{
		var Default__TdUIScene_SPPause_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SPPause.SceneEventComponent' */;
		// Object Offset:0x006ABD96
		EventProvider = Default__TdUIScene_SPPause_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SPPause.SceneEventComponent'*/;
	}
}
}