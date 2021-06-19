namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_DifficultySettings : TdUIScene_SubMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UITdOptionButton DifficultyOptionButton;
	public OnlinePlayerInterface PlayerInterface;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Accept(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */void OnCancel()
	{
	
	}
	
	public virtual /*function */void OnAccept()
	{
	
	}
	
	public virtual /*event */void OnProfileWriteComplete(bool bSucceeded)
	{
	
	}
	
	public virtual /*function */void TryWriteProfile()
	{
	
	}
	
	public virtual /*function */void OnStartGame()
	{
	
	}
	
	public virtual /*private final function */void ProfileWriteFailed_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnProfileWriteFailed_PreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*private final function */void OnProfileWriteFailed_Closed(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnCloseScene()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
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