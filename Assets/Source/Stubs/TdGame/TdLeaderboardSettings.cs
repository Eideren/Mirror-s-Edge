namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLeaderboardSettings : Settings/*
		native*/{
	public enum ETdLeaderboardFilters 
	{
		LF_TimeFrame,
		LF_PlayerFilterType,
		LF_GameModeType,
		LF_MAX
	};
	
	public enum ETdTimeFilterSettings 
	{
		TFS_Weekly,
		TFS_Monthly,
		TFS_AllTime,
		TFS_Max
	};
	
	public enum ETdPlayerFilterSettings 
	{
		PFS_CenteredOnPlayer,
		PFS_Friends,
		PFS_TopRankings,
		PFS_Max
	};
	
	public enum ETdGameModeSettings 
	{
		GMS_TimeTrial,
		GMS_LevelRace,
		GMS_MAX
	};
	
	public virtual /*function */void StepSettingValue(int SettingId, /*optional */bool bIncrease = default)
	{
	
	}
	
	public TdLeaderboardSettings()
	{
		// Object Offset:0x00585393
		LocalizedSettings = new array<Settings.LocalizedStringSetting>
		{
			new Settings.LocalizedStringSetting
			{
				Id = 0,
				ValueIndex = 2,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 1,
				ValueIndex = 2,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 2,
				ValueIndex = 0,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
		};
		LocalizedSettingsMappings = new array<Settings.LocalizedStringSettingMetaData>
		{
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 0,
				Name = (name)"TimeFrame",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Weekly>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Monthly>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 2,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Infinite>",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 1,
				Name = (name)"PlayerFilter",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.CenterPlayer>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Friends>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 2,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.TopRanks>",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 2,
				Name = (name)"GameMode",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.TimeTrial>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.LevelRace>",
						bIsWildcard = false,
					},
				},
			},
		};
	}
}
}