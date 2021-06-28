namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_Tutorial : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIDataStore_TdTutorialData TutorialData;
	public /*transient */UIList ChallengeList;
	public /*transient */UILabel GradeATimeLabel;
	public /*transient */UILabel GradeBTimeLabel;
	public /*transient */UILabel GradeCTimeLabel;
	public /*transient */UILabel PlayerTimeTimeLabel;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Back(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Race(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Tutorial(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnChallengeList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnStartChallenge(bool bRace)
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_Tutorial()
	{
		var Default__TdUIScene_Tutorial_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_Tutorial.SceneEventComponent' */;
		// Object Offset:0x006B50B5
		EventProvider = Default__TdUIScene_Tutorial_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_Tutorial.SceneEventComponent'*/;
	}
}
}