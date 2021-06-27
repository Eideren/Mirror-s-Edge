namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPSettings : OnlineGameSettings/*
		native*/{
	public const int PROP_NonStandardOptions = 0x10000006;
	public const int PROP_DedicatedServer = 0x10000009;
	public const int LSS_MapName = 0;
	public const int MAPNAME_Entry = 0;
	public const int MAPNAME_ExampleEntry = 1;
	public const int GAME_MODE = 0x0000800B;
	public const int GAME_MODE_PURSUIT = 0;
	public const int GAME_MODE_TRAP = 1;
	public const int GAME_MODE_DOUBLESTASH = 2;
	public const int GAME_MODE_BRITTISHBULLDOG = 3;
	public const int FRIENDLY_FIRE = 100;
	public const int FRIENDLY_FIRE_YES = 0;
	public const int FRIENDLY_FIRE_NO = 1;
	public const int SWITCH_SIDES = 101;
	public const int SWITCH_SIDES_YES = 0;
	public const int SWITCH_SIDES_NO = 1;
	public const int PUBLICPRIVATE_MODE = 102;
	public const int PUBLICPRIVATE_MODE_PUBLIC = 0;
	public const int PUBLICPRIVATE_MODE_PRIVATE = 1;
	public const int RANKEDUNRANKED_MODE = 103;
	public const int RANKEDUNRANKED_MODE_RANKED = 0;
	public const int RANKEDUNRANKED_MODE_UNRANKED = 1;
	public const int ROLERESTRICTION = 104;
	public const int ROLERESTRICTION_YES = 0;
	public const int ROLERESTRICTION_NO = 1;
	public const int HEAVYWEAPONSALLOWED = 105;
	public const int HEAVYWEAPONSALLOWED_YES = 0;
	public const int HEAVYWEAPONSALLOWED_NO = 1;
	public const int PROP_ROUNDSTOWIN = 200;
	public const int PROP_STASHESTOWIN = 201;
	public const int PROP_ROUNDTIME = 202;
	public const int PROP_MAXPLAYERS = 203;
	
	public TdMPSettings()
	{
		// Object Offset:0x005FA712
		NumPublicConnections = 16;
		LocalizedSettings = new array<Settings.LocalizedStringSetting>
		{
			new Settings.LocalizedStringSetting
			{
				Id = 32779,
				ValueIndex = 0,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 0,
				ValueIndex = 1,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 100,
				ValueIndex = 0,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 101,
				ValueIndex = 0,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 102,
				ValueIndex = 0,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 103,
				ValueIndex = 0,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 104,
				ValueIndex = 1,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 105,
				ValueIndex = 1,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
		};
		Properties = new array<Settings.SettingsProperty>
		{
			new Settings.SettingsProperty
			{
				PropertyId = 268435462,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 268435465,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 200,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 3,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 201,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 1,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 202,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 10,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 203,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 16,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
		};
		LocalizedSettingsMappings = new array<Settings.LocalizedStringSettingMetaData>
		{
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 32779,
				Name = (name)"GameMode",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 2,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 3,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 0,
				Name = (name)"MapName",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 100,
				Name = (name)"FriendlyFire",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 101,
				Name = (name)"SwitchSides",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 102,
				Name = (name)"PublicPrivateMode",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 103,
				Name = (name)"RankedUnrankedMode",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 104,
				Name = (name)"ROLERESTRICTION",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 105,
				Name = (name)"HeavyWeapons",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"None",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"None",
						bIsWildcard = false,
					},
				},
			},
		};
		PropertyMappings = new array<Settings.SettingsPropertyPropertyMetaData>
		{
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 268435462,
				Name = (name)"NonStandardOptions",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 268435465,
				Name = (name)"DedicatedServer",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 200,
				Name = (name)"RoundsToWin",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 201,
				Name = (name)"StashesToWin",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 202,
				Name = (name)"RoundTimeDuration",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
			new Settings.SettingsPropertyPropertyMetaData
			{
				Id = 203,
				Name = (name)"MaxPlayers",
				ColumnHeaderText = "",
				MappingType = Settings.EPropertyValueMappingType.PVMT_RawValue,
				ValueMappings = default,
				PredefinedValues = default,
				MinVal = 0.0f,
				MaxVal = 0.0f,
				RangeIncrement = 0.0f,
			},
		};
	}
}
}