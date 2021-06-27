namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLoginSettings : Settings/*
		native*/{
	public enum ETdLoginSettingsFilter 
	{
		TDLS_ALLOW_EA_MAIL,
		TDLS_ALLOW_THIRD_PARTY_EMAIL,
		TDLS_ALLOW_MAX
	};
	
	public enum ETdLoginSettingsFilter_Options 
	{
		TDLSO_YES,
		TDLSO_NO,
		TDLSO_MAX
	};
	
	public TdLoginSettings()
	{
		// Object Offset:0x0058C68E
		LocalizedSettings = new array<Settings.LocalizedStringSetting>
		{
			new Settings.LocalizedStringSetting
			{
				Id = 0,
				ValueIndex = 1,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.LocalizedStringSetting
			{
				Id = 1,
				ValueIndex = 1,
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
		};
		LocalizedSettingsMappings = new array<Settings.LocalizedStringSettingMetaData>
		{
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 0,
				Name = (name)"AllowEAMail",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Yes>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.No>",
						bIsWildcard = false,
					},
				},
			},
			new Settings.LocalizedStringSettingMetaData
			{
				Id = 1,
				Name = (name)"AllowThirdPartyEmail",
				ColumnHeaderText = "",
				ValueMappings = new array<Settings.StringIdToStringMapping>
				{
					new Settings.StringIdToStringMapping
					{
						Id = 0,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.Yes>",
						bIsWildcard = false,
					},
					new Settings.StringIdToStringMapping
					{
						Id = 1,
						Name = (name)"<Strings:TdGameUI.TdSettingsMappings.No>",
						bIsWildcard = false,
					},
				},
			},
		};
	}
}
}