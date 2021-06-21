namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ControlsSettingsPC : TdUIScene_OptionMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnKeyMappingsButton_Clicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnGamepadSettingsButton_Clicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
		// stub
	}
	
	public override /*function */void InitializeSettings()
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
	
	public TdUIScene_ControlsSettingsPC()
	{
		var Default__TdUIScene_ControlsSettingsPC_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ControlsSettingsPC.SceneEventComponent' */;
		// Object Offset:0x00567A13
		EventProvider = Default__TdUIScene_ControlsSettingsPC_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ControlsSettingsPC.SceneEventComponent'*/;
	}
}
}