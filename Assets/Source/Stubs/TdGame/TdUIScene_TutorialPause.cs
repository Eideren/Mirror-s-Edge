namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TutorialPause : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
	
		return default;
	}
	
	public virtual /*private final function */void Skip_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void NotifySkipMsgBox_OptionSelected(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnSkip_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnStayInTutorial(bool bStayInTutorial)
	{
	
	}
	
	public virtual /*function */void OnSkipTutorial()
	{
	
	}
	
	public TdUIScene_TutorialPause()
	{
		// Object Offset:0x006B6622
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_TutorialPause.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_TutorialPause.SceneEventComponent'*/;
	}
}
}