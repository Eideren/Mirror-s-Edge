namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_OptionMenu : TdUIScene_SubMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIPanel SettingsPanel;
	[transient] public array<UIObject> OptionObjects;
	public array<int> OldOptionValues;
	public/*protected*/ bool bChanged;
	public OnlinePlayerInterface PlayerInterface;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void InitWidgets()
	{
		// stub
	}
	
	public virtual /*function */void BackupWidgetValues()
	{
		// stub
	}
	
	public virtual /*function */void ResetWidgetValues()
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
	
	public virtual /*function */bool OnButtonBar_Reset(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*protected function */void OnReset_MessageBoxCallback(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnReset()
	{
		// stub
	}
	
	public virtual /*function */void OnReset_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnCancel()
	{
		// stub
	}
	
	public virtual /*private final function */void WillNotSave_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */void OnWillNotSave_OptionSelected(TdUIScene_MessageBox MsgBoxScene, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnCancel_Confirm(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnCancelChanges()
	{
		// stub
	}
	
	public virtual /*function */void OnAccept()
	{
		// stub
	}
	
	public virtual /*function */void InitializeSettings()
	{
		// stub
	}
	
	public virtual /*event */void OnProfileWriteComplete(bool bSucceeded)
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
	
	public virtual /*function */void OnProfileWriteFailed_Closed(TdUIScene_MessageBox MsgBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void DoReset()
	{
		// stub
	}
	
	public virtual /*function */void OnCloseScene(/*optional */UIScene.ESceneTransitionAnim? _SceneAnim = default)
	{
		// stub
	}
	
	public virtual /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnChange()
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
	
	public virtual /*function */void SaveWidgetValues()
	{
		// stub
	}
	
	public virtual /*function */void ResetSettingsToDefault()
	{
		// stub
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