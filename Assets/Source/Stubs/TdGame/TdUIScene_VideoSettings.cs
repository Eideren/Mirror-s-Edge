namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_VideoSettings : TdUIScene_OptionMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public override /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public override /*function */void InitializeSettings()
	{
	
	}
	
	public override /*function */void SaveWidgetValues()
	{
	
	}
	
	public TdUIScene_VideoSettings()
	{
		// Object Offset:0x00568414
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_VideoSettings.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_VideoSettings.SceneEventComponent'*/;
	}
}
}