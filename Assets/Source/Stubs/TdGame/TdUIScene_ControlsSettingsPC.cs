namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ControlsSettingsPC : TdUIScene_OptionMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void SetupButtonBar()
	{
	
	}
	
	public virtual /*function */bool OnKeyMappingsButton_Clicked(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public virtual /*function */bool OnGamepadSettingsButton_Clicked(UIScreenObject Sender, int PlayerIndex)
	{
	
		return default;
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public override /*function */void InitializeSettings()
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
	
	public TdUIScene_ControlsSettingsPC()
	{
		// Object Offset:0x00567A13
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_ControlsSettingsPC.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_ControlsSettingsPC.SceneEventComponent'*/;
	}
}
}