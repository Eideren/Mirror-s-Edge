namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLeaderboardFullReadSPTT : TdOnlineStatsRead{
	public TdSPTimeTrialGame GameStat;
	public OnlineStatsInterface GameStatInterface;
	public OnlineSubsystem.UniqueNetId PlayerId;
	
	public TdLeaderboardFullReadSPTT()
	{
		// Object Offset:0x00584370
		SortColumnId = 20;
		ColumnIds = new array<int>
		{
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			41,
			19,
			43,
			44,
		};
		PeriodFlags = new OnlineStats.StatPeriodFlags
		{
			bIndefinite = true,
		};
		ColumnTypes = new array<Settings.ESettingsDataType>
		{
			252,
			59,
			0,
			0,
			0,
			0,
			0,
			0,
			252,
			59,
			0,
			0,
			0,
		};
	}
}
}