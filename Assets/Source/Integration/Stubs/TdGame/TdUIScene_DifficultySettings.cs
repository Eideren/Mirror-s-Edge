namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_DifficultySettings : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UITdOptionButton DifficultyOptionButton;
	public OnlinePlayerInterface PlayerInterface;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCancel()
	{
		// stub
	}
	
	public virtual /*function */void OnAccept()
	{
		// stub
	}
	
	public virtual /*event */void OnProfileWriteComplete(bool bSucceeded)
	{
		// stub
	}
	
	public virtual /*function */void TryWriteProfile()
	{
		// stub
	}
	
	public virtual /*function */void OnStartGame()
	{
		// stub
	}
	
	public virtual /*private final function */void ProfileWriteFailed_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileWriteFailed_PreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void OnProfileWriteFailed_Closed(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_DifficultySettings()
	{
		var Default__TdUIScene_DifficultySettings_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_DifficultySettings.SceneEventComponent' */;
		// Object Offset:0x006953B3
		EventProvider = Default__TdUIScene_DifficultySettings_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_DifficultySettings.SceneEventComponent'*/;
	}
}
}