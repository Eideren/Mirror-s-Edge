namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLeaderboardRead_Pursuit : TdOnlineStatsRead{
	public TdLeaderboardRead_Pursuit()
	{
		// Object Offset:0x00584887
		ColumnIds = new array<int>
		{
			1,
			2,
			3,
			4,
			5,
		};
		ColumnMappings = new array<OnlineStatsRead.ColumnMetaData>
		{
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 1,
				Name = (name)"Total score",
				ColumnName = "",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 2,
				Name = (name)"Score per round",
				ColumnName = "",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 3,
				Name = (name)"Bag carrier",
				ColumnName = "",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 4,
				Name = (name)"Bags stashed",
				ColumnName = "",
			},
			new OnlineStatsRead.ColumnMetaData
			{
				Id = 5,
				Name = (name)"Bags searched",
				ColumnName = "",
			},
		};
	}
}
}