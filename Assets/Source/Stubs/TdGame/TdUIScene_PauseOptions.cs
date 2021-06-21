namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_PauseOptions : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
		// stub
	}
	
	public virtual /*function */void UpdateGamepadSettingVis(bool bIsVisible)
	{
		// stub
	}
	
	public override /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnOpenControlsSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenAudioSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenVideoSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenGameSettings()
	{
		// stub
	}
	
	public virtual /*function */void OnOpenGamepadSettings()
	{
		// stub
	}
	
	public TdUIScene_PauseOptions()
	{
		var Default__TdUIScene_PauseOptions_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_PauseOptions.SceneEventComponent' */;
		// Object Offset:0x0055F1DD
		EventProvider = Default__TdUIScene_PauseOptions_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_PauseOptions.SceneEventComponent'*/;
	}
}
}