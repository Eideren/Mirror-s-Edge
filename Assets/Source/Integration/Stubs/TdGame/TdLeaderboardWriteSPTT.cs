namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLeaderboardWriteSPTT : TdOnlineStatsWrite{
	public TdLeaderboardWriteSPTT()
	{
		// Object Offset:0x00585D23
		Properties = new array<Settings.SettingsProperty>
		{
			new Settings.SettingsProperty
			{
				PropertyId = 20,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 21,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 22,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 23,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 24,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 25,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 26,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 27,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 28,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 41,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 43,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 44,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
			new Settings.SettingsProperty
			{
				PropertyId = 19,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Int32,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
		};
		ViewIds = new array<int>
		{
			0,
		};
		RatingId = 20;
		PeriodFlags = new OnlineStats.StatPeriodFlags
		{
			bIndefinite = true,
			bWeekly = true,
			bMonthly = true,
		};
	}
}
}