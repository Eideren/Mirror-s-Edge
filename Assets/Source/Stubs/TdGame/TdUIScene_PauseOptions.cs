namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_PauseOptions : TdUIScene_Pause/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void PostInitialize()
	{
	
	}
	
	public override /*function */void OnControllerChange(int ControllerId, bool Connected)
	{
	
	}
	
	public virtual /*function */void UpdateGamepadSettingVis(bool bIsVisible)
	{
	
	}
	
	public override /*function */bool HandleOptionButton(UILabelButton OptionButton)
	{
	
		return default;
	}
	
	public virtual /*function */void OnOpenControlsSettings()
	{
	
	}
	
	public virtual /*function */void OnOpenAudioSettings()
	{
	
	}
	
	public virtual /*function */void OnOpenVideoSettings()
	{
	
	}
	
	public virtual /*function */void OnOpenGameSettings()
	{
	
	}
	
	public virtual /*function */void OnOpenGamepadSettings()
	{
	
	}
	
	public TdUIScene_PauseOptions()
	{
		// Object Offset:0x0055F1DD
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_PauseOptions.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_PauseOptions.SceneEventComponent'*/;
	}
}
}