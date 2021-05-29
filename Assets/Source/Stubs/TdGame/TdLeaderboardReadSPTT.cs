// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLeaderboardReadSPTT : TdOnlineStatsRead{
	public TdLeaderboardReadSPTT()
	{
		// Object Offset:0x00584CC3
		SortColumnId = 20;
		ColumnIds = new array<int>
		{
			19,
			20,
			41,
			43,
			44,
		};
		ColumnMappings = new array<OnlineStatsRead.ColumnMetaData>
		{
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 19,
				Name = (name)"Rating",
				ColumnName = "RATING",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 20,
				Name = (name)"TotalTime",
				ColumnName = "TIME",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 41,
				Name = (name)"HasGhost",
				ColumnName = " ",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 43,
				Name = (name)"AvgSpeed",
				ColumnName = "AVG SPEED",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 44,
				Name = (name)"Distance",
				ColumnName = "DISTANCE",
			},
		};
		ColumnTypes = new array<Settings.ESettingsDataType>
		{
			#warning weird ass values for enums, using random valid values
			Settings.ESettingsDataType.SDT_DateTime,
			Settings.ESettingsDataType.SDT_Int32,
			//253,
			//59,
			0,
			0,
			0,
		};
	}
}
}