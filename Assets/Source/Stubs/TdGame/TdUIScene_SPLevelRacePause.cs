namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SPLevelRacePause : TdUIScene_SPPause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
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
	
	public virtual /*function */void OnRestartRace()
	{
		// stub
	}
	
	public TdUIScene_SPLevelRacePause()
	{
		var Default__TdUIScene_SPLevelRacePause_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SPLevelRacePause.SceneEventComponent' */;
		// Object Offset:0x006AC34C
		EventProvider = Default__TdUIScene_SPLevelRacePause_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SPLevelRacePause.SceneEventComponent'*/;
	}
}
}