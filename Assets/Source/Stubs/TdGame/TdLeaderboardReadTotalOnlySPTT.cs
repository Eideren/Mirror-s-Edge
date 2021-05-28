// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLeaderboardReadTotalOnlySPTT : TdOnlineStatsRead{
	public TdLeaderboardReadTotalOnlySPTT()
	{
		// Object Offset:0x00584FDF
		SortColumnId = 20;
		ColumnIds = new array<int>
		{
			20,
		};
		ColumnMappings = new array<OnlineStatsRead.ColumnMetaData>
		{
			new ColumnMetaData()
			{
				Id = 20,
				Name = (name)"TotalTime",
				ColumnName = "",
			},
		};
		ColumnTypes = new array<Settings.ESettingsDataType>
		{
			#warning weird ass values for enums, using random valid values
			Settings.ESettingsDataType.SDT_String,
			//252,
		};
	}
}
}