namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_AudioSettings : TdUIScene_OptionMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public UIDataStore_TdStringList StringList;
	[transient] public UITdOptionButton AudioDeviceOptionButton;
	[transient] public String OldAudioDevice;
	
	public override /*event */void PostInitialize()
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
	
	public override /*function */void SaveWidgetValues()
	{
		// stub
	}
	
	public override /*function */void OnAccept()
	{
		// stub
	}
	
	public virtual /*function */void ApplyAudioSettings()
	{
		// stub
	}
	
	public override /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public TdUIScene_AudioSettings()
	{
		var Default__TdUIScene_AudioSettings_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_AudioSettings.SceneEventComponent' */;
		// Object Offset:0x00568107
		EventProvider = Default__TdUIScene_AudioSettings_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_AudioSettings.SceneEventComponent'*/;
	}
}
}