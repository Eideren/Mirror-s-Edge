namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_OptionMenu : TdUIScene_SubMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIPanel SettingsPanel;
	public /*transient */array<UIObject> OptionObjects;
	public array<int> OldOptionValues;
	public /*protected */bool bChanged;
	public OnlinePlayerInterface PlayerInterface;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void InitWidgets()
	{
	
	}
	
	public virtual /*function */void BackupWidgetValues()
	{
	
	}
	
	public virtual /*function */void ResetWidgetValues()
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
	
	public virtual /*function */bool OnButtonBar_Reset(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*protected function */void OnReset_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnReset()
	{
	
	}
	
	public virtual /*function */void OnReset_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnCancel()
	{
	
	}
	
	public virtual /*private final function */void WillNotSave_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */void OnWillNotSave_OptionSelected(TdUIScene_MessageBox MsgBoxScene, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnCancel_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnCancelChanges()
	{
	
	}
	
	public virtual /*function */void OnAccept()
	{
	
	}
	
	public virtual /*function */void InitializeSettings()
	{
	
	}
	
	public virtual /*event */void OnProfileWriteComplete(bool bSucceeded)
	{
	
	}
	
	public virtual /*private final function */void ProfileWriteFailed_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*private final function */void OnProfileWriteFailed_PreSelection(TdUIScene_MessageBox InMessageBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnProfileWriteFailed_Closed(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void DoReset()
	{
	
	}
	
	public virtual /*function */void OnCloseScene(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
	
	}
	
	public virtual /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnChange()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public override /*event */bool PlayInputKeyNotification(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public virtual /*function */void SaveWidgetValues()
	{
	
	}
	
	public virtual /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public TdUIScene_OptionMenu()
	{
		var Default__TdUIScene_OptionMenu_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_OptionMenu.SceneEventComponent' */;
		// Object Offset:0x00565B4B
		EventProvider = Default__TdUIScene_OptionMenu_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_OptionMenu.SceneEventComponent'*/;
	}
}
}