namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpRankingService : TpSystemHandler/*
		abstract
		transient
		native
		config(RankingStats)*/{
	public /*const config transient */int Rank_Unranked;
	public /*const config transient */int Rank_Max;
	public /*delegate*/TpRankingService.OnReadOnlineStatsComplete __OnReadOnlineStatsComplete__Delegate;
	public /*delegate*/TpRankingService.OnFlushOnlineStatsComplete __OnFlushOnlineStatsComplete__Delegate;
	
	public override /*simulated function */void Initialize(TpSystemBase InSystemBase)
	{
	
	}
	
	// Export UTpRankingService::execReadOnlineStats(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStats(/*const */ref array<OnlineSubsystem.UniqueNetId> Players, OnlineStatsRead StatsRead)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpRankingService::execReadOnlineStatsForFriends(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStatsForFriends(OnlineStatsRead StatsRead)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpRankingService::execReadOnlineStatsByRank(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStatsByRank(OnlineStatsRead StatsRead, /*optional */int StartIndex = default, /*optional */int NumToRead = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpRankingService::execReadOnlineStatsByRankAroundPlayer(FFrame&, void* const)
	public virtual /*native function */bool ReadOnlineStatsByRankAroundPlayer(OnlineStatsRead StatsRead, /*optional */int NumRows = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void OnReadOnlineStatsComplete(bool bWasSuccessful);
	
	// Export UTpRankingService::execFreeStats(FFrame&, void* const)
	public virtual /*native function */void FreeStats(OnlineStatsRead StatsRead)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpRankingService::execWriteOnlinePlayerScores(FFrame&, void* const)
	public virtual /*native function */bool WriteOnlinePlayerScores(/*const */ref array<OnlineSubsystem.OnlinePlayerScore> PlayerScores)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpRankingService::execWriteOnlineStats(FFrame&, void* const)
	public virtual /*native function */bool WriteOnlineStats(OnlineSubsystem.UniqueNetId Player, OnlineStatsWrite StatsWrite)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTpRankingService::execFlushOnlineStats(FFrame&, void* const)
	public virtual /*native function */bool FlushOnlineStats()
	{
		#warning NATIVE FUNCTION !
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