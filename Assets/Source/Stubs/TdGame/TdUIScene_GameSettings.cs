namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_GameSettings : TdUIScene_OptionMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UITdOptionButton LOIOptionButton;
	public /*transient */UITdOptionButton DifficultyOptionButton;
	public /*transient */UITdOptionButton ReticuleOptionButton;
	public /*transient */UITdOptionButton SubtitlesOptionButton;
	public /*transient */TdProfileSettings TdProfile;
	public /*transient */int CachedDifficulty;
	public /*transient */bool bAllowDifficultyChange;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*event */void SceneActivated(bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*private final function */void ProRunnerWarning_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*private final function */void ProRunnerWarning_OnSelection(TdUIScene_MessageBox MessageBox, int SelectedOption, int PlayerIndex)
	{
		// stub
	}
	
	public override /*function */void OnReset_MsgBoxInit(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */void DoReset()
	{
		// stub
	}
	
	public override /*function */void UpdateFocusLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public virtual /*private final function */void UpdateLOIState()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_StorageLoc(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnSetStorageLoc()
	{
		// stub
	}
	
	public override /*function */void SaveWidgetValues()
	{
		// stub
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
		// stub
	}
	
	public override /*function */void InitializeSettings()
	{
		// stub
	}
	
	public TdUIScene_GameSettings()
	{
		var Default__TdUIScene_GameSettings_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_GameSettings.SceneEventComponent' */;
		// Object Offset:0x0056BB17
		EventProvider = Default__TdUIScene_GameSettings_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_GameSettings.SceneEventComponent'*/;
	}
}
}