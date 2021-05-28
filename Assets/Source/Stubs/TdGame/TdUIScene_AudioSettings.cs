namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_AudioSettings : TdUIScene_OptionMenu/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public UIDataStore_TdStringList StringList;
	public /*transient */UITdOptionButton AudioDeviceOptionButton;
	public /*transient */string OldAudioDevice;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public override /*function */void InitializeSettings()
	{
	
	}
	
	public override /*function */void SaveWidgetValues()
	{
	
	}
	
	public override /*function */void OnAccept()
	{
	
	}
	
	public virtual /*function */void ApplyAudioSettings()
	{
	
	}
	
	public override /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public TdUIScene_AudioSettings()
	{
		// Object Offset:0x00568107
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_AudioSettings.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_AudioSettings.SceneEventComponent'*/;
	}
}
}