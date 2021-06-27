namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdMPData : UIDataStore_OnlineGameSettings/*
		transient
		hidecategories(Object,UIRoot)*/{
	public const int GAME_MODE = 0x0000800B;
	public const int CONTEXT_MAPNAME = 8;
	
	public UIDataStore_TdMPData()
	{
		// Object Offset:0x006DEBD5
		GameSettingsCfgList = new array<UIDataStore_OnlineGameSettings.GameSettingsCfg>
		{
			new UIDataStore_OnlineGameSettings.GameSettingsCfg
			{
				GameSettingsClass = ClassT<TdMPSettings>()/*Ref Class'TdMPSettings'*/,
				Provider = default,
				GameSettings = default,
				SettingsName = (name)"TdMP",
			},
		};
		Tag = (name)"TdMPGameSettings";
	}
}
}