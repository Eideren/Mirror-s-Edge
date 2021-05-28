namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SPLevelRacePause : TdUIScene_SPPause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
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
	
	public virtual /*function */void OnRestartRace()
	{
	
	}
	
	public TdUIScene_SPLevelRacePause()
	{
		// Object Offset:0x006AC34C
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_SPLevelRacePause.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_SPLevelRacePause.SceneEventComponent'*/;
	}
}
}