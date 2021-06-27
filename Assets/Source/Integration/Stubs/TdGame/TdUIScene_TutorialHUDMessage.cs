namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_TutorialHUDMessage : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel MessageText;
	public /*transient */float PopUpTimeStamp;
	public /*transient */bool bAutoClose;
	public /*transient */bool bFallButtonThrough;
	public /*transient */bool bIgnoreCloseOnContinue;
	public /*transient */float Duration;
	public /*transient */array<name> ContinueKeyNames;
	public /*transient */array<name> PauseKeyNames;
	public /*transient */array<name> IGMKeyNames;
	public /*transient */UIPanel ScenePanel;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */void SetupCustomButtonBar(String ButtonCallout, TdProfileSettings.EDigitalButtonActions Key, bool bFallThrough)
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
		// stub
	}
	
	public virtual /*function */void SetText(String Text)
	{
		// stub
	}
	
	public virtual /*function */void OnPauseGame()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenInGameMenu()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_TutorialHUDMessage()
	{
		var Default__TdUIScene_TutorialHUDMessage_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_TutorialHUDMessage.SceneEventComponent' */;
		// Object Offset:0x006B5EDD
		Duration = -1.0f;
		bDisplayCursor = false;
		bAlwaysRenderScene = true;
		bPauseGameWhileActive = false;
		SceneInputMode = UIRoot.EScreenInputMode.INPUTMODE_None;
		EventProvider = Default__TdUIScene_TutorialHUDMessage_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_TutorialHUDMessage.SceneEventComponent'*/;
	}
}
}