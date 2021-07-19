namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpRankingService : TpSystemHandler/*
		abstract
		transient
		native
		config(RankingStats)*/{
	[Const, config, transient] public int Rank_Unranked;
	[Const, config, transient] public int Rank_Max;
	public /*delegate*/TpRankingService.OnReadOnlineStatsComplete __OnReadOnlineStatsComplete__Delegate;
	public /*delegate*/TpRankingService.OnFlushOnlineStatsComplete __OnFlushOnlineStatsComplete__Delegate;
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
		// stub
	}
	
	// Export UTpRankingService::execReadOnlineStats(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStats(/*const */ref array<OnlineSubsystem.UniqueNetId> Players, OnlineStatsRead StatsRead)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpRankingService::execReadOnlineStatsForFriends(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStatsForFriends(OnlineStatsRead StatsRead)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpRankingService::execReadOnlineStatsByRank(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStatsByRank(OnlineStatsRead StatsRead, /*optional */int? _StartIndex = default, /*optional */int? _NumToRead = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpRankingService::execReadOnlineStatsByRankAroundPlayer(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStatsByRankAroundPlayer(OnlineStatsRead StatsRead, /*optional */int? _NumRows = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnReadOnlineStatsComplete(bool bWasSuccessful);
	
	// Export UTpRankingService::execFreeStats(FFrame&, void* const)
	public virtual /*native function */void FreeStats(OnlineStatsRead StatsRead)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTpRankingService::execWriteOnlinePlayerScores(FFrame&, void* const)
	public virtual /*native function */bool WriteOnlinePlayerScores(/*const */ref array<OnlineSubsystem.OnlinePlayerScore> PlayerScores)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpRankingService::execWriteOnlineStats(FFrame&, void* const)
	public virtual /*native function */bool WriteOnlineStats(OnlineSubsystem.UniqueNetId Player, OnlineStatsWrite StatsWrite)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTpRankingService::execFlushOnlineStats(FFrame&, void* const)
	public virtual /*native function */bool FlushOnlineStats()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public delegate void OnFlushOnlineStatsComplete(bool bWasSuccessful);
	
	public TpRankingService()
	{
		// Object Offset:0x00042E98
		Rank_Unranked = -1;
		Rank_Max = 50000;
	}
}
}