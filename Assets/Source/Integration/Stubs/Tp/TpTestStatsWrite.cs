namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpTestStatsWrite : OnlineStatsWrite{
	public TpTestStatsWrite()
	{
		// Object Offset:0x00046082
		Properties = new array<Settings.SettingsProperty>
		{
			new Settings.SettingsProperty
			{
				PropertyId = 0,
				Data = new Settings.SettingsData
				{
					Type = Settings.ESettingsDataType.SDT_Float,
					Value1 = 0,
				},
				AdvertisementType = Settings.EOnlineDataAdvertisementType.ODAT_DontAdvertise,
			},
		};
		ViewIds = new array<int>
		{
			0,
		};
	}
}
}