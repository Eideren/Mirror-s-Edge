namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TutorialPause : TdUIScene_Pause/*
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
	
	public virtual /*private final function */void Skip_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void NotifySkipMsgBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnSkip_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnStayInTutorial(bool bStayInTutorial)
	{
		// stub
	}
	
	public virtual /*function */void OnSkipTutorial()
	{
		// stub
	}
	
	public TdUIScene_TutorialPause()
	{
		var Default__TdUIScene_TutorialPause_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_TutorialPause.SceneEventComponent' */;
		// Object Offset:0x006B6622
		EventProvider = Default__TdUIScene_TutorialPause_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_TutorialPause.SceneEventComponent'*/;
	}
}
}