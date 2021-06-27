namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdGameSearch_Pursuit : UIDataStore_OnlineGameSearch/*
		transient
		hidecategories(Object,UIRoot)*/{
	public UIDataStore_TdGameSearch_Pursuit()
	{
		// Object Offset:0x006DE1E0
		GameSearchCfgList = new array<UIDataStore_OnlineGameSearch.GameSearchCfg>
		{
			new UIDataStore_OnlineGameSearch.GameSearchCfg
			{
				GameSearchClass = ClassT<TdGameSearch_Pursuit>()/*Ref Class'TdGameSearch_Pursuit'*/,
				DefaultGameSettingsClass = ClassT<TdMPSettings>()/*Ref Class'TdMPSettings'*/,
				SearchResultsProviderClass = ClassT<UIDataProvider_Settings>()/*Ref Class'UIDataProvider_Settings'*/,
				DesiredSettingsProvider = default,
				SearchResults = default,
				Search = default,
				SearchName = (name)"Pursuit",
			},
		};
		Tag = (name)"TdGameSearch_Pursuit";
	}
}
}