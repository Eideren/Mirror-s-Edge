namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TimeTrialPause : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabelButton GhostButton;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void OnBack()
	{
	
	}
	
	public override /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
	
		return default;
	}
	
	public virtual /*private final function */void Restart_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void NotifyRestartMsgBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnRestart_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnToggleGhost()
	{
	
	}
	
	public virtual /*function */void OnRestartStretch()
	{
	
	}
	
	public virtual /*function */void OnSceneClosed(UIScene ClosedScene)
	{
	
	}
	
	public TdUIScene_TimeTrialPause()
	{
		// Object Offset:0x006B3989
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_TimeTrialPause.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_TimeTrialPause.SceneEventComponent'*/;
	}
}
}