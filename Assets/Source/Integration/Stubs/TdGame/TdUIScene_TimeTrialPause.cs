namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TimeTrialPause : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UILabelButton GhostButton;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void OnBack()
	{
		// stub
	}
	
	public override /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void Restart_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void NotifyRestartMsgBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnRestart_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnToggleGhost()
	{
		// stub
	}
	
	public virtual /*function */void OnRestartStretch()
	{
		// stub
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public TdUIScene_TimeTrialPause()
	{
		var Default__TdUIScene_TimeTrialPause_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_TimeTrialPause.SceneEventComponent' */;
		// Object Offset:0x006B3989
		EventProvider = Default__TdUIScene_TimeTrialPause_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_TimeTrialPause.SceneEventComponent'*/;
	}
}
}